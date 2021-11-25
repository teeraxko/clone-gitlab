using System;
using System.Text;

using ictus.Common.Entity.General;
using ictus.SystemConnection.BizPac.AP;

using PTB.BTS.BTS2BizPacDB;
using PTB.BTS.BTS2BizPacDB.BizPacImplementDB;
using PTB.BTS.BTS2BizPacEntity;
using Entity.CommonEntity;
using DataAccess.CommonDB;
using ictus.Common.Entity;
using PTB.BTS.BTS2BizPacDB.BizPacReportDB;
using Entity.AttendanceEntities;
using Entity.ContractEntities;
using PTB.BTS.BTS2SAP;

namespace PTB.BTS.BTS2BizPacFlow.VehicleExcessFlow
{
    public class VehicleExcessBPFlow : BTS2BizPacConnectFlow
    {
        //============================== Constructor ==============================
        public VehicleExcessBPFlow() : base()
        {
            dbConnect = new VehicleExcessBPDB();
        }

        //============================== Private method ==============================
        private void generateTRExcessExpense(BTS2BizPacList listBP, BTS2BizPacList excessExpenseList)
        {
            excessExpenseList.Clear();

            ExcessBP excessExpense;
            ExcessBP excessBP;

            for (int i = 0; i < listBP.Count; i++)
            {
                excessExpense = new ExcessBP();
                excessBP = (ExcessBP)listBP[i];

                excessExpense.RepairingNo = excessBP.RepairingNo;
                excessExpense.BillByInsuranceStatus = excessBP.BillByInsuranceStatus;
                excessExpense.AInsuranceCompany = excessBP.AInsuranceCompany;
                excessExpense.Garage = excessBP.Garage;
                excessExpense.BizPacRefNo = excessBP.BizPacRefNo;
                excessExpense.VehicleInfo = excessBP.VehicleInfo;
                excessExpense.InsuranceClaimNo = excessBP.InsuranceClaimNo;
                excessExpense.HappenTime = excessBP.HappenTime;
                excessExpense.InsuranceReceiptNo = excessBP.InsuranceReceiptNo;
                excessExpense.InsuranceReceiptDate = excessBP.InsuranceReceiptDate;
                excessExpense.ActualExcessAmount = excessBP.ActualExcessAmount;
                switch (excessBP.APayer)
                {
                    case PAYER_TYPE.CUSTOMER:
                        if (excessBP.ACustomer != null && excessBP.ACustomer.Code != Customer.DUMMYCODE)
                        {
                            excessExpense.Remark1 = "Collect " + excessBP.ActualExcessAmount.ToString() + "ß from " + excessBP.ACustomer.ShortName;
                        }
                        else
                        {
                            excessExpense.Remark1 = "Collect " + excessBP.ActualExcessAmount.ToString() + "ß";
                        }                            
                        break;
                    case PAYER_TYPE.PTB:
                        excessExpense.Remark1 = "Company payment for this case";
                        break;
                    case PAYER_TYPE.EMPLOYEE:
                        if (excessBP.ADriver != null)
                        {
                            excessExpense.Remark1 = string.Concat("By driver ", excessBP.ADriver.EmployeeIDName);
                        }
                        else
                        {
                            excessExpense.Remark1 = "By driver";
                        }
                        break;
                    case PAYER_TYPE.RESIGN:
                        excessExpense.Remark1 = "Deduct " + excessBP.ActualExcessAmount.ToString() + "ß when he resign";
                        break;
                    default:
                        excessExpense.Remark1 = "";
                        break;
                }

                excessExpenseList.Add(excessExpense);
            }

            excessExpense = null;
            excessBP = null;
        }
        #region - add detail -
            private void addToInsurance(ExcessBP data, CommonList insuranceCompanys)
            {
                ExcessBP existData;
                if(insuranceCompanys.Contain(data.AInsuranceCompany.Code))
                {
                    existData = (ExcessBP)insuranceCompanys.BaseGet(data.AInsuranceCompany.Code);
                    addDetail(data, existData);
                }
                else
                {
                    existData =  createDetail(data, 1);
                    insuranceCompanys.Add(existData.AInsuranceCompany.Code, existData);
                }
                existData = null;
            }

            private void addToGarage(ExcessBP data, CommonList garages)
            {
                ExcessBP existData;
                if (garages.Contain(data.Garage.Code))
                {
                    existData = (ExcessBP)garages.BaseGet(data.Garage.Code);
                    addDetail(data, existData);
                }
                else
                {
                    existData = createDetail(data, 1);
                    garages.Add(existData.Garage.Code, existData);
                }
                existData = null;
            }

            private void fillBTS2BizPacDetail(BTS2BizPacDetailAP detail, ExcessBP data)
            {                
                detail.Quantity = 0;
                detail.Price = 0;
                detail.Amount = data.ActualExcessAmount;
                switch (data.APayer)
                {
                    case PAYER_TYPE.CUSTOMER :
                    {
                        detail.MiscItemCode = "OTH001";
                        detail.ItemDescription = "Excess by CUSTOMER";
                        detail.BusinessUnit = "";
                        break;
                    }
                    case PAYER_TYPE.EMPLOYEE :
                    {
                        detail.MiscItemCode = "DEP001";
                        detail.ItemDescription = "Excess by EMPLOYEE";
                        detail.BusinessUnit = "";
                        break;
                    }
                    case PAYER_TYPE.PTB :
                    {
                        detail.MiscItemCode = "PART03";
                        detail.ItemDescription = "Excess by PTB";
                        detail.BusinessUnit = "01";
                        break;
                    }
                    case PAYER_TYPE.RESIGN :
                    {
                        //TODO : woranai
                        break;
                    }
                    default:
                    {
                        throw new Exception("The method or operation is not implemented.");
                    }
                }
            }

            private ExcessBP createDetail(ExcessBP data, int seq)
            {
                markBizPacRef(data);
                ExcessBP newData = data.Clone();
                newData.ExcessTotalAmount = data.ActualExcessAmount;
                newData.CaseForRemark++;
                BTS2BizPacDetailAP detail = new BTS2BizPacDetailAP();
                detail.SeqNo = seq;
                fillBTS2BizPacDetail(detail, data);
                newData.Details = new Entity.PTB.BTS.BTS2BizPacEntity.BTS2BizPacDetailList();
                newData.Details.Add(data.APayer.ToString() ,detail);
                return newData;
            }

            private void addDetail(ExcessBP data, ExcessBP existData)
            {
                BTS2BizPacDetailAP detail;
                existData.CaseForRemark++;
                copyBizPacRef(existData, data);
                existData.ExcessTotalAmount += data.ActualExcessAmount;

                if (existData.Details.Contain(data.APayer.ToString()))
                {
                    detail = (BTS2BizPacDetailAP)existData.Details.BaseGet(data.APayer.ToString());
                    detail.Amount += data.ActualExcessAmount;
                }
                else
                {
                    detail = new BTS2BizPacDetailAP();
                    detail.SeqNo = existData.Details.Count + 1;                    
                    fillBTS2BizPacDetail(detail, data);
                    existData.Details.Add(data.APayer.ToString(), detail);
                }                
            }
        #endregion

        //============================== Protected method ==============================
        protected override bool SpecificConnect(BTS2BizPacList listBP, BTS2BizPacList resultListBTS, BTS2BizPacList resultListBP)
        {
            CommonList insuranceCompanys = new CommonList();
            CommonList garages = new CommonList();
            ExcessBP data;

            for (int i = 0; i < listBP.Count; i++)
            {
                data = (ExcessBP)listBP[i];

                //Set docdate from user input : woranai 30/05/2007
                data.DocDateControl = listBP.ConnectDate;

                if (data.BillByInsuranceStatus)
                {
                    addToInsurance(data, insuranceCompanys);
                }
                else
                {
                    addToGarage(data, garages);
                }
                resultListBTS.Add(data);
            }

            for (int i = 0; i < insuranceCompanys.Count; i++)
            {
                resultListBP.Add((IBTS2BizPacHeader)insuranceCompanys.BaseGet(i));
            }

            for (int i = 0; i < garages.Count; i++)
            {
                resultListBP.Add((IBTS2BizPacHeader)garages.BaseGet(i));
            }

            return true;
        }

        protected override bool TRConnect(BTS2BizPacList listBP, TableAccess tableAccess, Company company)
        {
            bool result = false;
            BTS2BizPacList excessExpenseList = new BTS2BizPacList();
            TrExcessExpenseDB dbTrExcessExpense = new TrExcessExpenseDB();

            generateTRExcessExpense(listBP, excessExpenseList);

            dbTrExcessExpense.TableAccess = tableAccess;
            dbTrExcessExpense.DeleteTrExcessExpense();
            result = dbTrExcessExpense.InsertTrExcessExpense(excessExpenseList);

            return result;
        }

        // [TODO] Kriangkrai A. 14/2/2018
        protected override string GenerateCSV2SAP(BTS2BizPacList listBP, DateTime connectDate)
        {
            ConnectVehicleExcess2SAP sapConnection = new ConnectVehicleExcess2SAP();
            string filename = sapConnection.GetVehicleExcessSAPDataFile(listBP, connectDate);

            return filename;
        }
    }
}
