using System;
using System.Collections.Generic;
using System.Text;

using ictus.SystemConnection.BizPac.AP;

using PTB.BTS.BTS2BizPacDB;
using PTB.BTS.BTS2BizPacDB.BizPacImplementDB;
using PTB.BTS.BTS2BizPacEntity;
using DataAccess.CommonDB;
using ictus.Common.Entity;
using PTB.BTS.BTS2BizPacDB.BizPacReportDB;
using Entity.AttendanceEntities;
using ictus.Common.Entity.Time;
using Entity.PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.BTS2SAP;

namespace PTB.BTS.BTS2BizPacFlow.BizPacImplementFlow
{
    public class InsuranceTypeOneBPFlow : BTS2BizPacConnectFlow
    {
        //============================== Constructor ==============================
        public InsuranceTypeOneBPFlow() : base()
        {
            dbConnect = new InsuranceTypeOneBPDB();
        }

        private int getDays(DateTime from, DateTime to)
        {
            TimeSpan totalTime = to - from;
          //TimeSpan totalTime = to.AddDays(1) - from;
            if (totalTime.Days > 0)
            {
                return totalTime.Days;
            }
            else
            {
                return 0;
            }
        }

        private void makeDetail(InsuranceTypeOneBP insuranceTypeOneBP, DateTime docDate, DateTime docDateDetail)
        {
            TimePeriod period = insuranceTypeOneBP.APeriod;

            //Set docdate from user input : woranai 30/05/2007
            insuranceTypeOneBP.DocDateControl = docDate;

            //Allow user to input date detail in item : Woranai B. 2009/08/17
            insuranceTypeOneBP.DocDateDetail = docDateDetail.Date;

            decimal amountPerDay = insuranceTypeOneBP.BaseAmount / getDays(period.From, period.To);
            insuranceTypeOneBP.Month1Amount = insuranceTypeOneBP.BaseAmount;
            decimal monthlyAmount;

            int count = 1;

            //Allow user to input date detail for generate insurance expense report : Woranai B. 2009/09/21
            //for (DateTime date = BizPacFixData.END_DATE_OF_MONTH.AddDays(1); date <= period.To; date = date.AddMonths(1))
            
            for (DateTime date = new DateTime(docDateDetail.AddMonths(1).Year, docDateDetail.AddMonths(1).Month, 1); date <= period.To; date = date.AddMonths(1))
            {
                count++;
                if (date.Month == period.To.Month)
                {
                    monthlyAmount = Math.Round(amountPerDay * period.To.Day, 2);
                }
                else
                { 
                    monthlyAmount = Math.Round(amountPerDay * (new YearMonth(date)).DaysInMonth, 2);
                }

                insuranceTypeOneBP.Month1Amount -= monthlyAmount;
                #region - switch case -
                switch (count)
                {
                    case 2:
                        insuranceTypeOneBP.Month2Amount = monthlyAmount;
                        break;
                    case 3:
                        insuranceTypeOneBP.Month3Amount = monthlyAmount;
                        break;
                    case 4:
                        insuranceTypeOneBP.Month4Amount = monthlyAmount;
                        break;
                    case 5:
                        insuranceTypeOneBP.Month5Amount = monthlyAmount;
                        break;
                    case 6:
                        insuranceTypeOneBP.Month6Amount = monthlyAmount;
                        break;
                    case 7:
                        insuranceTypeOneBP.Month7Amount = monthlyAmount;
                        break;
                    case 8:
                        insuranceTypeOneBP.Month8Amount = monthlyAmount;
                        break;
                    case 9:
                        insuranceTypeOneBP.Month9Amount = monthlyAmount;
                        break;
                    case 10:
                        insuranceTypeOneBP.Month10Amount = monthlyAmount;
                        break;
                    case 11:
                        insuranceTypeOneBP.Month11Amount = monthlyAmount;
                        break;
                    case 12:
                        insuranceTypeOneBP.Month12Amount = monthlyAmount;
                        break;
                }
                #endregion
            }

            insuranceTypeOneBP.Details = new BTS2BizPacDetailList();
            BTS2BizPacDetailAP detailAP;

            detailAP = new BTS2BizPacDetailAP();
            detailAP.SeqNo = 1;
            detailAP.MiscItemCode = "VINSUR";
            detailAP.ItemDescription = "Vehicle Insurance Premium in";
            detailAP.Quantity = 0;
            detailAP.Price = 0;
            detailAP.Amount = insuranceTypeOneBP.Month1Amount;
            detailAP.BusinessUnit = "01";
            insuranceTypeOneBP.Details.Add(detailAP);

            detailAP = new BTS2BizPacDetailAP();
            detailAP.SeqNo = 2;
            detailAP.MiscItemCode = "PREP01";
            detailAP.ItemDescription = "Prepaid expense";
            detailAP.Quantity = 0;
            detailAP.Price = 0;
            detailAP.Amount = insuranceTypeOneBP.BaseAmount - insuranceTypeOneBP.Month1Amount;
            detailAP.BusinessUnit = "";
            insuranceTypeOneBP.Details.Add(detailAP);

            detailAP = null;
        }

        protected override bool SpecificConnect(BTS2BizPacList listBP, BTS2BizPacList resultListBTS, BTS2BizPacList resultListBP)
        {
            markBizPacRefByTaxInvoice(listBP, resultListBTS, resultListBP);

            for (int i = 0; i < resultListBP.Count; i++)
            {
                makeDetail((InsuranceTypeOneBP)resultListBP[i], listBP.ConnectDate, listBP.DocDateDetail);
            } 

            return (listBP.Count == 0);
        }

        protected override bool TRConnect(BTS2BizPacList listBP, TableAccess tableAccess, Company company)
        {
            bool result = false;
            BTS2BizPacList insuranceExpenseList = new BTS2BizPacList();
            TrInsuranceExpenseDB dbTrInsuranceExpense = new TrInsuranceExpenseDB();

            dbTrInsuranceExpense.TableAccess = tableAccess;
            dbTrInsuranceExpense.DeleteTrInsuranceExpense();
            result = dbTrInsuranceExpense.InsertTrInsuranceExpense(listBP);

            return result;
        }

        // [TODO] Kriangkrai A. 14/2/2018
        protected override string GenerateCSV2SAP(BTS2BizPacList listBP, DateTime connectDate)
        {
            ConnectInsuranceTypeOne2SAP sapConnection = new ConnectInsuranceTypeOne2SAP();
            string filename = sapConnection.GetInsuranceTypeOneSAPDataFile(listBP, connectDate);

            return filename;
        }
    }
}
