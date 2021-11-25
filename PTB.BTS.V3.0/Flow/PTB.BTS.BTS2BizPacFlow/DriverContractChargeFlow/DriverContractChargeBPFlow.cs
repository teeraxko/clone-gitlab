using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataAccess.CommonDB;
using DataAccess.ContractDB.ContractChargeRateDB;
using DataAccess.PTB.BTS.BTS2BizPacDB.BizPacReportDB;
using Entity.AttendanceEntities;
using Entity.Constants;
using Entity.ContractEntities;
using Flow.AttendanceFlow.CommonBenefitFlow;
using Flow.ContractFlow;
using ictus.Common.Entity;
using PTB.BTS.Attendance.BenefitChargeFlow;
using PTB.BTS.BTS2BizPacDB.BizPacImplementDB;
using PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.BTS2BizPacFlow.DriverDebitNoteCreateFlow;
using PTB.BTS.ContractEntities.ContractChargeRate;
using PTB.BTS.Vehicle.Flow;
using Flow.Comparer;
using ictus.Common.Entity.Time;
using System.Diagnostics;
using PTB.BTS.BTS2SAP;
using System.Threading;

namespace PTB.BTS.BTS2BizPacFlow.DriverContractChargeFlow
{
    public class DriverContractChargeBPFlow : BTS2BizPacConnectFlow
    {
        #region Private Variable
        private DDNCreaterManager DDNCreaterManager;
        private CustomerSpecialChargeDB dbCustomerSpecialCharge;
        private VATRate vat;
        #endregion

        #region Constructor
        public DriverContractChargeBPFlow()
            : base()
        {
            dbConnect = new ContractChargeDetailBPDB(ContractChargeDetailBPDB.CONTRACTTYPEBP.DRIVER);
            dbCustomerSpecialCharge = new CustomerSpecialChargeDB();
        } 
        #endregion

        #region Private Method
        private string createCustomerSpecialCharge(BTS2BizPacList bpList, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder();
            CustomerSpecialCharge charge;
            DriverContractChargeBP driverBP;

            for (int i = 0; i < bpList.Count; i++)
            {
                driverBP = (DriverContractChargeBP)bpList[i];

                decimal specialCharge = decimal.Zero;
                if (driverBP.ACustomer.Code == "000031")
                {
                    specialCharge = driverBP.SpecialAmountJBIC;
                }
                else
                {
                    specialCharge = driverBP.SpecialAmount;
                }

                if (driverBP.TelephoneAmount != decimal.Zero | specialCharge != decimal.Zero)
                {
                    charge = new CustomerSpecialCharge();
                    charge.YearMonth = driverBP.YearMonth;
                    charge.Contract = driverBP;
                    charge.EmployeeNo = driverBP.ServiceStaff.EmployeeNo;
                    charge.TelephoneAmount = driverBP.TelephoneAmount;
                    charge.SpecialAmount = specialCharge;

                    if (driverBP.IsAssignCustomerDepartment)
                    {
                        charge.AssignDepartment = driverBP.ACustomerDepartment;
                    }

                    stringBuilder.Append(dbCustomerSpecialCharge.CommandDeleteCustomerSpecialCharge(charge, company));
                    stringBuilder.Append(dbCustomerSpecialCharge.CommandInsertCustomerSpecialCharge(charge, company));
                }
            }

            return stringBuilder.ToString();
        }

        private void addTo(DriverContractChargeBP fromBP, DriverContractChargeBP toBP)
        {
            toBP.ChargeAmount += fromBP.ChargeAmount;
            toBP.OTACharge = CommonAttendanceFlow.AddTime(toBP.OTACharge, fromBP.OTACharge);
            toBP.OTARate = fromBP.OTARate;
            toBP.OTBCharge = CommonAttendanceFlow.AddTime(toBP.OTBCharge, fromBP.OTBCharge);
            toBP.OTBRate = fromBP.OTBRate;
            toBP.OTCCharge = CommonAttendanceFlow.AddTime(toBP.OTCCharge, fromBP.OTCCharge);
            toBP.OTCRate = fromBP.OTCRate;
            toBP.Holiday += fromBP.Holiday;
            toBP.HolidayAmount += fromBP.HolidayAmount;
            toBP.Taxi += fromBP.Taxi;
            toBP.TaxiAmount += fromBP.TaxiAmount;
            toBP.DeducTime += fromBP.DeducTime;
            toBP.DeducAmount += fromBP.DeducAmount;
            toBP.TripFar += fromBP.TripFar;
            toBP.TripFarAmount += fromBP.TripFarAmount;
            toBP.TripNear += fromBP.TripNear;
            toBP.TripNearAmount += fromBP.TripNearAmount;
            toBP.NightTrip += fromBP.NightTrip;
            toBP.NightTripAmount += fromBP.NightTripAmount;
            toBP.Other += fromBP.Other;
            toBP.OTADay += fromBP.OTADay;
            toBP.TelephoneAmount += fromBP.TelephoneAmount;
            toBP.SpecialAmount += fromBP.SpecialAmount;

            toBP.OTAHourAdjust = CommonAttendanceFlow.AddTime(toBP.OTAHourAdjust, fromBP.OTAHourAdjust);
            toBP.OTBHourAdjust = CommonAttendanceFlow.AddTime(toBP.OTBHourAdjust, fromBP.OTBHourAdjust);
            toBP.OTCHourAdjust = CommonAttendanceFlow.AddTime(toBP.OTCHourAdjust, fromBP.OTCHourAdjust);
            toBP.OTAAmountAdjust += fromBP.OTAAmountAdjust;
            toBP.OTBAmountAdjust += fromBP.OTBAmountAdjust;
            toBP.OTCAmountAdjust += fromBP.OTCAmountAdjust;
            toBP.HolidayAdjust += fromBP.HolidayAdjust;
            toBP.HolidayAmountAdjust += fromBP.HolidayAmountAdjust;
            toBP.TaxiAdjust += fromBP.TaxiAdjust;
            toBP.TaxiAmountAdjust += fromBP.TaxiAmountAdjust;
            toBP.DeducAdjust += fromBP.DeducAdjust;
            toBP.DeducAmountAdjust += fromBP.DeducAmountAdjust;
            toBP.TripFarAdjust += fromBP.TripFarAdjust;
            toBP.TripFarAmountAdjust += fromBP.TripFarAmountAdjust;
            toBP.TripNearAdjust += fromBP.TripNearAdjust;
            toBP.TripNearAmountAdjust += fromBP.TripNearAmountAdjust;
            toBP.NightTripAdjust += fromBP.NightTripAdjust;
            toBP.NightTripAmountAdjust += fromBP.NightTripAmountAdjust;

            if (fromBP.Line > toBP.Line)
            {
                toBP.Line = fromBP.Line;
            }
        }

        /// <summary>
        /// Separate contract charge by department assignment
        /// </summary>
        /// <param name="driverCharge"></param>
        /// <returns>List of DriverContractChargeBP</returns>
        private List<DriverContractChargeBP> separateDepartmentContract(DriverContractChargeBP conditionDriverBP)
        {
            List<DriverContractChargeBP> driverBPList = new List<DriverContractChargeBP>();
            DriverContractChargeBP driverBP = null;

            decimal totalChargeAmount = decimal.Zero, diffChargAmount = decimal.Zero;
            decimal initChargeAmount = conditionDriverBP.ChargeAmount;
            decimal chargePerDay = decimal.Divide(initChargeAmount, GetDays(conditionDriverBP.APeriod, conditionDriverBP.YearMonth));

            //Order item in list
            ContractDepartmentAssignmentComparer comparer = new ContractDepartmentAssignmentComparer();
            comparer.CompareType = ContractDepartmentAssignment.DataPropertyName.ASSIGN_FROM_DATE;

            conditionDriverBP.AssignedDepartmentList.Sort(comparer);

            foreach (ContractDepartmentAssignment deptAssign in conditionDriverBP.AssignedDepartmentList)
            {
                driverBP = conditionDriverBP.CloneDriverCharge(conditionDriverBP);
                driverBP.DepartmentAssignedPeriod = GetAssignPeriod(deptAssign.AssignPeriod, conditionDriverBP.YearMonth);
                driverBP.ACustomerDepartment = deptAssign.AssignDepartment;
                driverBP.ChargeAmount = decimal.Round(decimal.Multiply(driverBP.DepartmentAssignedPeriod.DayDiff, chargePerDay), MidpointRounding.AwayFromZero);
                totalChargeAmount += driverBP.ChargeAmount;

                driverBPList.Add(driverBP);
            }

            //Adjust diff of charge amount to last contract
            if (!totalChargeAmount.Equals(initChargeAmount))
            {
                diffChargAmount = decimal.Subtract(totalChargeAmount, initChargeAmount);
                driverBPList[driverBPList.Count - 1].ChargeAmount -= diffChargAmount;
            }

            return driverBPList;
        }

        /// <summary>
        /// Fill contract department assignment by period
        /// </summary>
        /// <param name="driverChargeBP"></param>
        private void fillContractDepartmentAssignment(DriverContractChargeBP driverChargeBP)
        {
            TimePeriod timePeriod = new TimePeriod(driverChargeBP.YearMonth.MinDateOfMonth, driverChargeBP.YearMonth.MaxDateOfMonth);

            using (ContractDepartmentAssignmentFlow flow = new ContractDepartmentAssignmentFlow(driverChargeBP.AContractChargeList.Company))
            {
                driverChargeBP.AssignedDepartmentList = flow.GetListByContractPeriod(driverChargeBP.ContractNo.ToString(), timePeriod);

                if (driverChargeBP.AssignedDepartmentList != null && driverChargeBP.AssignedDepartmentList.Count == 1)
                {
                    driverChargeBP.ACustomerDepartment = driverChargeBP.AssignedDepartmentList[0].AssignDepartment;
                    driverChargeBP.DepartmentAssignedPeriod = driverChargeBP.AssignedDepartmentList[0].AssignPeriod;
                }
            }
        }
        #endregion

        #region Protected Method
        protected virtual void fillCharge(DriverContractChargeBP driverContractChargeBP)
        {
            BenefitChargeFlow.DriverCharge(driverContractChargeBP);
        }

        protected override bool SpecificConnect(BTS2BizPacList resultListBTS, BTS2BizPacList resultListReport, BTS2BizPacList resultListBizPac)
        {
            DDNCreaterManager = new DDNCreaterManager();
            DDNCreaterManager.RefFlow = this;

            #region Fill charge and group data
            foreach (DriverContractChargeBP driverChargeBP in resultListBTS)
            {
                List<DriverContractChargeBP> listDriverContractCharge = new List<DriverContractChargeBP>();

                fillContractDepartmentAssignment(driverChargeBP);
                //Separate TIS Department
                if (driverChargeBP.AssignedDepartmentList != null && driverChargeBP.AssignedDepartmentList.Count > 1)
                {
                    foreach (DriverContractChargeBP item in separateDepartmentContract(driverChargeBP))
                    {
                        listDriverContractCharge.Add(item);
                    }
                }
                else
                {
                    listDriverContractCharge.Add(driverChargeBP);
                }

                foreach (DriverContractChargeBP item in listDriverContractCharge)
                {
                    fillCharge(item);

                    #region Group data

                    string key = item.ServiceStaff.EmployeeNo + item.ACustomer.Code;
                    if (item.ACustomer.Code == CustomerCodeValue.TIS)
                    {
                        key += item.ACustomerDepartment.Code;
                    }

                    if (resultListReport.Contain(key))
                    {
                        if (key == "13018000001024")
                        {
                            Debug.WriteLine("test");
                        
                        }

                        DriverContractChargeBP exist = (DriverContractChargeBP)resultListReport[key];
                        item.BizPacReference = exist.BizPacReference;
                        addTo(item, exist);
                        exist.TotalDays += GetDays(item.APeriod, item.YearMonth);
                        if (exist.TotalDays == exist.YearMonth.DaysInMonth)
                        {
                            exist.ChargeAmount = exist.ContractCharge.UnitChargeAmount;
                        }
                        //2018-08-14:WatchareeT. Waiting Recheck Code: Calculation Incorrect
                        /* 
                        {
                            if (exist.RateStatus.ToString() == "M")
                            {
                                exist.ChargeAmount = exist.ContractCharge.UnitChargeAmount;
                            }
                            else
                            {
                                if (exist.TotalDays >= 30)
                                {
                                    exist.ChargeAmount = exist.ContractCharge.UnitChargeAmount * 30;
                                }
                                else
                                {
                                    exist.ChargeAmount = exist.ContractCharge.UnitChargeAmount * exist.TotalDays;
                                }
                            }
                        }
                        else
                        {
                            exist.ChargeAmount = exist.ContractCharge.UnitChargeAmount * exist.TotalDays;
                        }*/
                    }
                    else
                    {
                        item.TotalDays = GetDays(item.APeriod, item.YearMonth);
                        item.BizPacReference = new BizPacReference();
                        resultListReport.Add(key, item);
                    }
                    #endregion
                }
            } 
            #endregion            

            #region Create Debit Note & Round
            foreach (DriverContractChargeBP item in resultListReport)
            {
                if (item.ACustomer.Code == CustomerCodeValue.JBIC)
                {
                    item.Line = 1;

                    if (item.OTAHourAdjust < 0)
                    {
                        item.OTACharge = CommonAttendanceFlow.HalfRound(CommonAttendanceFlow.DiffTime(item.OTACharge, item.OTAHourAdjust));
                    }
                    else
                    {
                        item.OTACharge = CommonAttendanceFlow.HalfRound(CommonAttendanceFlow.AddTime(item.OTACharge, item.OTAHourAdjust));
                    }

                    if (item.OTBHourAdjust < 0)
                    {
                        item.OTBCharge = CommonAttendanceFlow.HalfRound(CommonAttendanceFlow.DiffTime(item.OTBCharge, item.OTBHourAdjust));
                    }
                    else
                    {
                        item.OTBCharge = CommonAttendanceFlow.HalfRound(CommonAttendanceFlow.AddTime(item.OTBCharge, item.OTBHourAdjust));
                    }

                    if (item.OTCHourAdjust < 0)
                    {
                        item.OTCCharge = CommonAttendanceFlow.HalfRound(CommonAttendanceFlow.DiffTime(item.OTCCharge, item.OTCHourAdjust));
                    }
                    else
                    {
                        item.OTCCharge = CommonAttendanceFlow.HalfRound(CommonAttendanceFlow.AddTime(item.OTCCharge, item.OTCHourAdjust));
                    }

                    item.Holiday += item.HolidayAdjust;
                    item.HolidayAmount += item.HolidayAmountAdjust;
                    item.Taxi += item.TaxiAdjust;
                    item.TaxiAmount += item.TaxiAmountAdjust;
                    item.TripNear += item.TripNearAdjust;
                    item.TripNearAmount += item.TripNearAmountAdjust;
                    item.TripFar += item.TripFarAdjust;
                    item.TripFarAmount += item.TripFarAmountAdjust;
                    item.NightTrip += item.NightTripAdjust;
                    item.NightTripAmount += item.NightTripAmountAdjust;
                    item.DeducTime += item.DeducAdjust;
                    item.DeducAmount += item.DeducAmountAdjust;
                    item.ChargeAmount += item.SpecialAmount;

                    //## For customer JBIC ##
                    item.SpecialAmountJBIC += item.SpecialAmount;

                    item.OTAAmountAdjust = decimal.Zero;
                    item.OTBAmountAdjust = decimal.Zero;
                    item.OTCAmountAdjust = decimal.Zero;
                    item.HolidayAmountAdjust = decimal.Zero;
                    item.TaxiAmountAdjust = decimal.Zero;
                    item.TripNearAmountAdjust = decimal.Zero;
                    item.TripFarAmountAdjust = decimal.Zero;
                    item.NightTripAmountAdjust = decimal.Zero;
                    item.DeducAmountAdjust = decimal.Zero;
                    item.SpecialAmount = decimal.Zero;
                }
                else
                {
                    item.OTACharge = CommonAttendanceFlow.HalfRound(item.OTACharge);
                    item.OTBCharge = CommonAttendanceFlow.HalfRound(item.OTBCharge);
                    item.OTCCharge = CommonAttendanceFlow.HalfRound(item.OTCCharge);
                    item.OTAHourAdjust = CommonAttendanceFlow.HalfRound(item.OTAHourAdjust);
                    item.OTBHourAdjust = CommonAttendanceFlow.HalfRound(item.OTBHourAdjust);
                    item.OTCHourAdjust = CommonAttendanceFlow.HalfRound(item.OTCHourAdjust);

                }

                //User request TIS same other customer : woranai 20071129
                #region Comment
                //if (driverContractChargeBP.ACustomer.Code == "000001")
                //{
                //    driverContractChargeBP.OTACharge = CommonAttendanceFlow.TISHalfRound(driverContractChargeBP.OTACharge);
                //    driverContractChargeBP.OTBCharge = CommonAttendanceFlow.TISHalfRound(driverContractChargeBP.OTBCharge);
                //    driverContractChargeBP.OTCCharge = CommonAttendanceFlow.TISHalfRound(driverContractChargeBP.OTCCharge);
                //    driverContractChargeBP.OTAHourAdjust = CommonAttendanceFlow.TISHalfRound(driverContractChargeBP.OTAHourAdjust);
                //    driverContractChargeBP.OTBHourAdjust = CommonAttendanceFlow.TISHalfRound(driverContractChargeBP.OTBHourAdjust);
                //    driverContractChargeBP.OTCHourAdjust = CommonAttendanceFlow.TISHalfRound(driverContractChargeBP.OTCHourAdjust);
                //    //Specific case for TIS : woranai 2007/11/16
                //    driverContractChargeBP.OTAAmountAdjust = decimal.Multiply(driverContractChargeBP.OTAHourAdjust, driverContractChargeBP.OTARate);
                //    driverContractChargeBP.OTBAmountAdjust = decimal.Multiply(driverContractChargeBP.OTBHourAdjust, driverContractChargeBP.OTBRate);
                //    driverContractChargeBP.OTCAmountAdjust = decimal.Multiply(driverContractChargeBP.OTCHourAdjust, driverContractChargeBP.OTCRate);
                //} 
                #endregion

                //Cal VAT
                if (vat == null)
                {
                    vat = VehicleFunction.GetVATRate();
                }

                item.VATAmount = Math.Round(item.Amount * vat.Rate / 100m, 2);

                DDNCreaterManager.Add((IBTS2BizPacHeader)item);

                ((DriverContractChargeBP)resultListBTS[item.EntityKey]).BizPacReference = item.BizPacReference;
            } 
            #endregion

            DDNCreaterManager.FillDriverDebitNote(resultListBizPac);

            return true;
        }

        protected override bool TRConnect(BTS2BizPacList listBP, TableAccess tableAccess, Company company)
        {
            bool result = false;
            TrServiceStaffDNAttachDB dbTrServiceStaffDNAttach = new TrServiceStaffDNAttachDB();
            StringBuilder insertBuilder = new StringBuilder();

            foreach (DriverContractChargeBP driverBP in listBP)
            {
                if (driverBP.Line == 1)
                {
                    insertBuilder.Append(dbTrServiceStaffDNAttach.InsertTrServiceStaffDNAttach(driverBP));
                }
                else
                {
                    driverBP.Line = 1;
                    insertBuilder.Append(dbTrServiceStaffDNAttach.InsertTrServiceStaffDNAttach(driverBP));
                    driverBP.Line = 2;
                    insertBuilder.Append(dbTrServiceStaffDNAttach.SpecificInsertTrServiceStaffDNAttach(driverBP));
                }
            }

            dbTrServiceStaffDNAttach.TableAccess = tableAccess;
            dbTrServiceStaffDNAttach.DeleteTrServiceStaffDNAttach();
            result = dbTrServiceStaffDNAttach.ExecuteSQLCommand(insertBuilder.ToString());

            insertBuilder = null;
            return result;
        }

        //Napat C. 15/02/2019
        protected override string GenerateCSV2SAP(BTS2BizPacList listBP, DateTime connectDate)
        {
            ConnectDriverContractCharge2SAP sapConnection = new ConnectDriverContractCharge2SAP();
            string filename = sapConnection.GetDriverContractChargeSAPDataFile(listBP, connectDate.ToString("ddMMyyyy"));

            return filename;
        }
        #endregion

        #region Public Method
        public override bool Connect(BTS2BizPacList listBP, ref string fileName, Company company)
        {
            bool result = false;
            BTS2BizPacList resultListReport = new BTS2BizPacList();
            BTS2BizPacList resultListBizPac = new BTS2BizPacList();

            if (SpecificConnect(listBP, resultListReport, resultListBizPac))
            {
                TableAccess tableAccess = new TableAccess();

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < listBP.Count; i++)
                {
                    if (i == 141)
                    {
                        Debug.WriteLine("break");
                    }
                    string str = dbBizPacConnectTable.Connect(dbConnect, listBP[i], company);
                    Debug.WriteLine(str);
                    stringBuilder.Append(str);

                }

                try
                {
                    currentCultureInfo = Thread.CurrentThread.CurrentCulture;

                    tableAccess.OpenTransaction();

                    result = TRConnect(resultListReport, tableAccess, company);

                    dbBizPacConnectTable.TableAccess = tableAccess;
                    dbCustomerSpecialCharge.TableAccess = tableAccess;

                    result &= dbBizPacConnectTable.ExecuteCommand(stringBuilder.ToString());

                    if (result && listBP.Count > 0)
                    {
                        string command = createCustomerSpecialCharge(listBP, company);

                        if (command != string.Empty)
                        {
                            result &= dbBizPacConnectTable.ExecuteCommand(command);
                        }
                    }

                    if (result && resultListBizPac.Count > 0)
                    {
                        // Napat C. 15/2/2019 Change way to connect to SAP
                        //// Generate CSV file
                        //string resultFileName = connectBP.Connect(resultListBP);
                        string resultFileName = GenerateCSV2SAP(resultListBizPac, listBP.ConnectDate);
                        connectBP.Connect(resultFileName); // Transfer file via FTP

                        result &= (resultFileName != "");
                        fileName = resultFileName;
                    }

                    if (result)
                    {
                        tableAccess.Transaction.Commit();
                        result = true;
                    }
                    else
                    {
                        tableAccess.Transaction.Rollback();
                    }
                }
                catch (SqlException ex)
                {
                    tableAccess.Transaction.Rollback();
                    throw ex;
                }
                catch (Exception ex)
                {
                    tableAccess.Transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    tableAccess.CloseConnection();
                    tableAccess.Transaction.Dispose();
                    tableAccess = null;
                    stringBuilder = null;

                    Thread.CurrentThread.CurrentCulture = currentCultureInfo;
                }
            }
            listBP.Clear();
            resultListReport = null;
            resultListBizPac = null;

            return result;
        } 
        #endregion
    }
}
