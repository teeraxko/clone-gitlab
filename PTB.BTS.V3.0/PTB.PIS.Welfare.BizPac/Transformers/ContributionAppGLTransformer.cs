using System;
using System.Collections.Generic;
using System.Text;
using PTB.PIS.Welfare.BizPac.FileManager;
using ictus.PIS.Welfare.Entity.ContributionEntities;
using PTB.PIS.Welfare.BizPac.GL;
using PTB.PIS.Welfare.BizPac.BizPacMappingBTS;
using System.Diagnostics;
using PTB.PIS.Welfare.BizPac.PTB.BTS.BTS2SAP.Connection;
using PTB.PIS.Welfare.BizPac.AP;
using System.Threading;
using System.Globalization;

namespace PTB.PIS.Welfare.BizPac.Transformers
{
    public class ContributionAppGLTransformer : Transformer
    {
        public GLJournal journal = new GLJournal();
        private List<string> lines = new List<string>();
        private List<ContributionApplication> apps;

        private DateTime paymentDate;
        public ContributionAppGLTransformer(DateTime connectionDateTime, List<ContributionApplication> apps)
            : base(connectionDateTime)
        {
            this.apps = apps;
            this.paymentDate = connectionDateTime;
        }

        public ContributionAppGLTransformer(DateTime connectionDateTime, List<ContributionApplication> apps, DateTime paymentDate)
            : base(connectionDateTime)
        {
            this.apps = apps;
            this.paymentDate = paymentDate;
        }

        // Kriangkrai A.
        //public override bool Transform()
        //{
        //    BuildHeader();
        //    BuildDebits();
        //    BuildCredits();
        //    RefeshDetailJournalData();
        //    PrepareTextStream();
        //    bool writeTextCompleted = WriteTextStream();
        //    return writeTextCompleted;
        //}

        public override bool Transform()
        {
            try
            {
                currentCultureInfo = Thread.CurrentThread.CurrentCulture;

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

                // Prepare data
                BuildHeader();
                BuildDebits();
                BuildCredits();
                RefeshDetailJournalData();
                //PrepareTextStream();

                ConnectContribution2SAP contribution2SAP = new ConnectContribution2SAP();
                string fileName = contribution2SAP.GetContributionSAPDataFile(journal, paymentDate);

                this.BizPacFile = fileName;

                if (WriteTextStream())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                //   throw ex;
                return false;
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = currentCultureInfo;
            }

            return false;
        }

        private void PrepareTextStream()
        {
            string contributionGLStrTemplete = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},,00,000055,,,,,,,,,,,,,";
            //bizPacFile.FileName = new BizGLFileName(this.connectDateTime);
            // debit lines
            foreach (GLDebit debitItem in journal.Debits)
            {
                string line =
                string.Format(contributionGLStrTemplete,
                    journal.Header.DocTypeCode,
                    journal.Header.DocDate.ToString(Common.EngDateFormat("yyyyMMdd")).Trim(),
                    journal.Header.PostDate.ToString(Common.EngDateFormat("yyyyMMdd")).Trim(),
                    journal.Header.BusinessPlaceCode,
                    journal.LinesCount.ToString(),
                    journal.TotalAmount.ToString("0.00"),
                    journal.Header.RefNo,
                    journal.Header.Descr,
                    journal.Header.CurrCode,
                    journal.Header.ExchangeRate.ToString(),
                    debitItem.Seq.ToString(),
                    debitItem.AccountCode,
                    debitItem.Amount.ToString(),
                    "0.00",
                    debitItem.BusinessUnitCode,
                    debitItem.LineDescrEn);
                this.lines.Add(line);
            }

            // credit lines
            foreach (GLCredit creditItem in journal.Credits)
            {
                string line =
                string.Format(contributionGLStrTemplete,
                    journal.Header.DocTypeCode,
                    journal.Header.DocDate.ToString(Common.EngDateFormat("yyyyMMdd")).Trim(),
                    journal.Header.PostDate.ToString(Common.EngDateFormat("yyyyMMdd")).Trim(),
                    journal.Header.BusinessPlaceCode,
                    journal.LinesCount.ToString(),
                    journal.TotalAmount.ToString("0.00"),
                    journal.Header.RefNo,
                    journal.Header.Descr,
                    journal.Header.CurrCode,
                    journal.Header.ExchangeRate.ToString(),
                    creditItem.Seq.ToString(),
                    creditItem.AccountCode,
                    "0.00",
                    creditItem.Amount.ToString(),
                    "",
                    creditItem.LineDescrEn);
                this.lines.Add(line);
            }
        }

        private bool WriteTextStream()
        {
            ictus.SystemConnection.BizPac.BizPacConnect writer = new ictus.SystemConnection.BizPac.BizPacConnect();
            // Kriangkrai A.
            //return writer.Connect(this.bizPacFile.FileName.ToString(), this.lines);

            return writer.Connect(this.BizPacFile);
            //return true;
        }


        private void BuildDebits()
        {
            foreach (ContributionApplication app in this.apps)
            {
                string deptCode = app.Employee.ASection.ADepartment.Code;
                string secCode = app.Employee.ASection.Code;
                string bizSecCode = SectionMapManager.GetBizSectionCode(deptCode, secCode);
                GLDebit debitItem = FoundOldSecDebit(bizSecCode);
                if (debitItem != null)
                {
                    debitItem.Amount += app.AppliedAmount;
                }
                else
                {
                    debitItem = this.SetNewDebitItem(bizSecCode, app);
                    journal.Debits.Add(debitItem);
                }


            }
        }

        private void BuildCredits()
        {
            GLCredit creditItem = this.SetNewCreditItem();
            journal.Credits.Add(creditItem);
        }

        private void RefeshDetailJournalData()
        {
            journal.SortDebitData();
            journal.SortCreditData();
            journal.ReSeq();
        }

        private void BuildHeader()
        {
            ContributionApplication temp = null;
            foreach (ContributionApplication app in this.apps)
            {
                if (temp == null) temp = app;
                if (app.AppliedAmount > temp.AppliedAmount) temp = app;
            }

            // Kriangkrai A.
            //if (apps.Count > 1)
            //{
            //    journal.Header.Descr = string.Format("Pay For Welfare - {0} BY {1} {2} {3} and others", temp.Contribution.EngDescription, temp.Employee.APrefix.English + temp.Employee.AName.English, temp.Employee.ASection.AShortName.English, temp.Employee.EmployeeNo);
            //}
            //else
            //{
            //    journal.Header.Descr = string.Format("Pay For Welfare - {0} BY {1} {2} {3}", temp.Contribution.EngDescription, temp.Employee.APrefix.English + temp.Employee.AName.English, temp.Employee.ASection.AShortName.English, temp.Employee.EmployeeNo);

            //}
            journal.Header.Descr = string.Format("Welfare {0} {1} {2}", temp.Contribution.EngDescription, temp.Employee.APrefix.English + temp.Employee.AName.English, temp.Employee.EmployeeNo);

            journal.Header.DocTypeCode = "PV";
            journal.Header.DocDate = journal.Header.PostDate = this.paymentDate;
            journal.Header.RefNo = Common.GetNewConnectRefNo();
            this.ListOfRefNo.Add(journal.Header.RefNo);
        }

        private GLDebit FoundOldSecDebit(string bizCode)
        {
            GLDebit result = null;
            foreach (GLDebit debitItem in journal.Debits)
            {
                if (debitItem.BusinessUnitCode == bizCode)
                {
                    result = debitItem;
                    break;
                }
            }
            return result;
        }

        private GLDebit SetNewDebitItem(string bizCode, ContributionApplication app)
        {
            try
            {
                GLDebit result = new GLDebit();
                result.AccountCode = this.GetAccCodeByBizSec(bizCode);
                result.Amount = app.AppliedAmount;
                result.BusinessUnitCode = bizCode;

                //Kriangkrai A.
                //result.LineDescrEn = journal.Header.Descr;
                result.MiscExpenseCode = this.GetSAPMiscCodeByBizSec(bizCode).Code;
                result.LineDescrEn = string.Format("Welfare {0} {1} {2}", app.Contribution.EngDescription, app.Employee.APrefix.English + app.Employee.AName.English, app.Employee.EmployeeNo);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private MiscExpenseCode GetSAPMiscCodeByBizSec(string bizCode)
        {
            switch (bizCode.Trim())
            {
                case "01": return new MiscExpenseCode("BASE01", "Contribution-Dept 01");
                case "02": return new MiscExpenseCode("BASE02", "Contribution-Dept 02");
                case "03": return new MiscExpenseCode("BASE03", "Contribution-Dept 03");
                case "05": return new MiscExpenseCode("BASE05", "Contribution-Dept 05");
                case "06": return new MiscExpenseCode("BASE06", "Contribution-Dept 06");
                case "AC": return new MiscExpenseCode("BASEAC", "Contribution-Dept AC");
                case "GA": return new MiscExpenseCode("BASEGA", "Contribution-Dept GA");
                case "PN": return new MiscExpenseCode("BASEPN", "Contribution-Dept PN");
                default: throw new Exception(string.Format("Cant mapping MiscExpense code with SectionCode {0}", bizCode.Trim()));
            }
        }

        private GLCredit SetNewCreditItem()
        {
            try
            {
                GLCredit result = new GLCredit();
                result.AccountCode = GLJournal.CASH_ACC_CODE;
                result.Amount = this.SumDebit();
                result.LineDescrEn = journal.Header.Descr;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //mapping GL Account code contribution
        private string GetAccCodeByBizSec(string bizCode)
        {
            switch (bizCode.Trim())
            {
                case "01": return "500202";
                case "02": return "500202";
                case "03": return "500202";
                case "04": return "500202";
                case "05": return "500202";
                case "06": return "500202";
                case "06A": return "500202";
                case "AC": return "520202";
                case "PN": return "520202";
                case "GA": return "520202";
                default: throw new Exception("Cant mapping Account code" + bizCode);
            }
        }

        private Decimal SumDebit()
        {
            decimal result = 0M;
            foreach (GLDebit debitItem in journal.Debits)
            {
                result += debitItem.Amount;
            }
            return result;
        }
    }
}
