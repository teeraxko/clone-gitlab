using System;
using System.Collections.Generic;
using System.Text;

using ictus.SystemConnection.BizPac.AP;

using PTB.BTS.BTS2BizPacDB;
using PTB.BTS.BTS2BizPacDB.BizPacImplementDB;
using PTB.BTS.BTS2BizPacEntity;
using Entity.PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.Common.Flow;
using Entity.AttendanceEntities;
using ictus.Common.Entity;
using PTB.BTS.BTS2BizPacDB.BizPacReportDB;
using DataAccess.CommonDB;
using DataAccess.VehicleDB;
using Entity.VehicleEntities;
using Entity.CommonEntity;
using ictus.Common.Entity.General;
using PTB.BTS.BTS2SAP;
using System.Globalization;

namespace PTB.BTS.BTS2BizPacFlow.CompulsoryFlow
{
    public class CompulsoryInsuranceBPFlow : BTS2BizPacConnectFlow
    {
        DateTime fiscalYearEndDate = NullConstant.DATETIME;
        //============================== Constructor ==============================
        public CompulsoryInsuranceBPFlow() : base()
        {
            dbConnect = new CompulsoryInsuranceBPDB();
        }

        //============================== Private method ==============================
        #region - Private method -
        private int getDays(DateTime from, DateTime to)
        {
            TimeSpan totalTime = to - from;
            if (totalTime.Days > 0)
            {
                return totalTime.Days;
            }
            else
            {
                return 0;
            }            
        }

        // 6/2/2018 Kriangkrai A. Miner project change to transfer data to SAP
        //private void makeDetail(CompulsoryInsuranceBP compulsoryInsurance, DateTime docDate, DateTime docDateDetail)
        //{
        //    int totalDays = getDays(compulsoryInsurance.APeriod.From, compulsoryInsurance.APeriod.To);
        //    compulsoryInsurance.Year2Days = getDays(fiscalYearEndDate, compulsoryInsurance.APeriod.To);
        //    compulsoryInsurance.Year1Days = totalDays - compulsoryInsurance.Year2Days;
        //    compulsoryInsurance.Year2Amount = Math.Round(compulsoryInsurance.Year2Days * compulsoryInsurance.BaseAmount / totalDays, 2);
        //    compulsoryInsurance.Year1Amount = compulsoryInsurance.BaseAmount - compulsoryInsurance.Year2Amount;

        //    //Set docdate from user input : woranai 30/05/2007
        //    compulsoryInsurance.DocDateControl = docDate.Date;

        //    //Allow user to input date detail in item : Woranai B. 2009/08/17
        //    compulsoryInsurance.DocDateDetail = docDateDetail.Date;
            
        //    compulsoryInsurance.Details = new BTS2BizPacDetailList();

        //    BTS2BizPacDetailAP detailAP;

        //    detailAP = new BTS2BizPacDetailAP();
        //    detailAP.SeqNo = 1;
        //    detailAP.MiscItemCode = "CINSUR";
        //    detailAP.ItemDescription = "Compulsory Insurance Premium ";
        //    if(compulsoryInsurance.AVehicle.PlateStatus == PLATE_STATUS.R)
        //    {
        //        detailAP.ItemDescription += compulsoryInsurance.AVehicle.ChassisNo;
        //    }
        //    else
        //    {
        //        detailAP.ItemDescription += compulsoryInsurance.AVehicle.PlateNumber;
        //    }
        //    detailAP.Quantity = 0;
        //    detailAP.Price = 0;
        //    detailAP.Amount = compulsoryInsurance.Year1Amount;
        //    detailAP.BusinessUnit = "01";
        //    compulsoryInsurance.Details.Add(detailAP);

        //    detailAP = new BTS2BizPacDetailAP();
        //    detailAP.SeqNo = 2;
        //    detailAP.MiscItemCode = "PREP01";
        //    detailAP.ItemDescription = "Prepaid expense";
        //    detailAP.Quantity = 0;
        //    detailAP.Price = 0;
        //    detailAP.Amount = compulsoryInsurance.Year2Amount;
        //    detailAP.BusinessUnit = "";
        //    compulsoryInsurance.Details.Add(detailAP);

        //    detailAP = null;
        //}

        private void makeDetail(CompulsoryInsuranceBP compulsoryInsurance, DateTime docDate, DateTime docDateDetail)
        {
            int totalDays = getDays(compulsoryInsurance.APeriod.From, compulsoryInsurance.APeriod.To);
            compulsoryInsurance.Year2Days = getDays(fiscalYearEndDate, compulsoryInsurance.APeriod.To);
            compulsoryInsurance.Year1Days = totalDays - compulsoryInsurance.Year2Days;
            compulsoryInsurance.Year2Amount = Math.Round(compulsoryInsurance.Year2Days * compulsoryInsurance.BaseAmount / totalDays, 2);
            compulsoryInsurance.Year1Amount = compulsoryInsurance.BaseAmount - compulsoryInsurance.Year2Amount;

            //Set docdate from user input : woranai 30/05/2007
            compulsoryInsurance.DocDateControl = docDate.Date;  // A/C inputting date

            //Allow user to input date detail in item : Woranai B. 2009/08/17
            compulsoryInsurance.DocDateDetail = docDateDetail.Date; // Transfer Date

            compulsoryInsurance.Details = new BTS2BizPacDetailList();

            BTS2BizPacDetailAP detailAP;

            detailAP = new BTS2BizPacDetailAP();
            detailAP.SeqNo = 1;
            detailAP.MiscItemCode = "CINSUR";
            //detailAP.ItemDescription = "Compulsory Ins. Premium {0} " + DateTime.Now.ToString("MMM yyyy", CultureInfo.CreateSpecificCulture("en-US"));
            detailAP.ItemDescription = "Compulsory Ins. Premium {0} " + docDateDetail.Date.ToString("MMM yyyy", CultureInfo.CreateSpecificCulture("en-US"));
            if (compulsoryInsurance.AVehicle.PlateStatus == PLATE_STATUS.R)
            {
                detailAP.ItemDescription = string.Format(detailAP.ItemDescription, (compulsoryInsurance.AVehicle.ChassisNo.Substring((compulsoryInsurance.AVehicle.ChassisNo.Length - 12))));
            }
            else
            {
                detailAP.ItemDescription = string.Format(detailAP.ItemDescription, compulsoryInsurance.AVehicle.PlateNumber);
            }

            detailAP.Quantity = 0;
            detailAP.Price = 0;
            detailAP.Amount = compulsoryInsurance.Year1Amount;
            detailAP.BusinessUnit = "01";

            compulsoryInsurance.Details.Add(detailAP);

            detailAP = new BTS2BizPacDetailAP();
            detailAP.SeqNo = 2;
            detailAP.MiscItemCode = "PREP01";
            detailAP.ItemDescription = "Prepaid expense";
            detailAP.Quantity = 0;
            detailAP.Price = 0;
            detailAP.Amount = compulsoryInsurance.Year2Amount;
            detailAP.BusinessUnit = "";

            compulsoryInsurance.Details.Add(detailAP);

            detailAP = null;
        }

        private void generateTRCompulsoryExpense(BTS2BizPacList listBP, BTS2BizPacList compulsoryExpenseList)
        {
            compulsoryExpenseList.Clear();

            CompulsoryInsuranceBP compulsoryInsuranceBP;
            CompulsoryExpense compulsoryExpense;
            TimePeriod period;
            FiscalYear fiscalYear = CommonFlow.FiscalYear;

            for (int i = 0; i < listBP.Count; i++)
            {
                compulsoryExpense = new CompulsoryExpense();
                compulsoryInsuranceBP = (CompulsoryInsuranceBP)listBP[i];
                period = compulsoryInsuranceBP.APeriod;

                compulsoryExpense.BizPacRefNo = compulsoryInsuranceBP.BizPacRefNo;
                compulsoryExpense.AVehicle = compulsoryInsuranceBP.AVehicle;
                compulsoryExpense.AInsuranceCompany = compulsoryInsuranceBP.AInsuranceCompany;
                compulsoryExpense.PolicyNo = compulsoryInsuranceBP.PolicyNo;
                compulsoryExpense.TaxInvoiceNo = compulsoryInsuranceBP.TaxInvoiceNo;
                compulsoryExpense.TaxInvoiceDate = compulsoryInsuranceBP.TaxInvoiceDate;
                compulsoryExpense.APeriod = period;
                compulsoryExpense.VatAmount = compulsoryInsuranceBP.VatAmount;
                compulsoryExpense.PremiumAmount = compulsoryInsuranceBP.PremiumAmount;
                compulsoryExpense.RevenueStampFee = compulsoryInsuranceBP.RevenueStampFee;
                compulsoryExpense.Year1Days = compulsoryInsuranceBP.Year1Days;
                compulsoryExpense.Year2Days = compulsoryInsuranceBP.Year2Days;
                compulsoryExpense.Year1Amount = compulsoryInsuranceBP.Year1Amount;
                compulsoryExpense.Year2Amount = compulsoryInsuranceBP.Year2Amount;

                compulsoryExpenseList.Add(compulsoryExpense);
            }

            compulsoryInsuranceBP = null;
            compulsoryExpense = null;
            period = null;
            fiscalYear = null;
        }
        #endregion

        //============================== Protected method ==============================
        protected override bool SpecificConnect(BTS2BizPacList listBP, BTS2BizPacList resultListBTS, BTS2BizPacList resultListBP)
        {
            markBizPacRefByTaxInvoice(listBP, resultListBTS, resultListBP);
            
            if (fiscalYearEndDate == null || fiscalYearEndDate == NullConstant.DATETIME)
            {
                fiscalYearEndDate = CommonFlow.FiscalYear.EndDate;
            }

            for (int i = 0; i < resultListBP.Count; i++)
            {
                // Prepare data to generate transfer file
                makeDetail((CompulsoryInsuranceBP)resultListBP[i], listBP.ConnectDate, listBP.DocDateDetail);
            } 
            
            return (listBP.Count == 0);
        }

        protected override bool TRConnect(BTS2BizPacList listBP, TableAccess tableAccess, Company company)
        {
            bool result = false;
            BTS2BizPacList compulsoryExpenseList = new BTS2BizPacList();
            TrCompulsoryExpenseDB dbTrCompulsoryExpense = new TrCompulsoryExpenseDB();

            //prepare data to save to Tr Table
            generateTRCompulsoryExpense(listBP, compulsoryExpenseList);

            dbTrCompulsoryExpense.TableAccess = tableAccess;
             dbTrCompulsoryExpense.DeleteTrCompulsoryExpense();

            //insert data to Tr Table
            result = dbTrCompulsoryExpense.InsertTrCompulsoryExpense(compulsoryExpenseList);

            return result;
        }

        // Kriangkrai A. 14/2/2018 Change way to connect to SAP
        protected override string GenerateCSV2SAP(BTS2BizPacList listBP, DateTime connectDate)
        {
            ConnectCompulsory2SAP sapConnection = new ConnectCompulsory2SAP();
            string filename = sapConnection.GetCompulsorySAPDataFile(listBP, connectDate);

            return filename;
        }
    }
}
