using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.LoanEntities;
using PTB.PIS.Welfare.BizPac.GL;
using PTB.PIS.Welfare.BizPac.FileManager;
using PTB.PIS.Welfare.BizPac.PTB.BTS.BTS2SAP.Connection;
using System.Threading;
using System.Globalization;

namespace PTB.PIS.Welfare.BizPac.Transformers
{
    internal class LoanAppGLTransformer : Transformer
    {

        //mapping GL account code loan
        private const string DEBIT_ACC_CODE = "162001";
        private const string CREDIT_ACC_CODE = "101201";

        public GLJournal journal = new GLJournal();


        private List<string> lines = new List<string>();

        private DateTime paymentDate;

        private DateTime postingDate;

        private List<LoanApplication> apps;
        public LoanAppGLTransformer(DateTime connectionDateTime, List<LoanApplication> apps, DateTime paymentDate)
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
        //    PrepareTextStream(); // Prepare data to Bizpac CSV Format
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

                ConnectLoan2SAP loan2SAP = new ConnectLoan2SAP();
                string fileName = loan2SAP.GetLoanSAPDataFile(journal, paymentDate);

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

        private void BuildHeader()
        {
            LoanApplication temp = null;

            // select max item
            foreach (LoanApplication app in this.apps)
            {
                if (temp == null) temp = app;
                //                if (app.BalanceAmount > temp.BalanceAmount) temp = app;
                if (app.CapitalAmount > temp.CapitalAmount) temp = app;
            }
            //journal.Header.Descr = string.Format("Loan of staff in {0}", temp.AppliedDate.ToString(Common.ShortMonthNameYearFormat()));
            journal.Header.Descr = string.Format("Loan of staff in {0}", paymentDate.ToString(Common.ShortMonthNameYearFormat()));
            journal.Header.DocTypeCode = "PV";
            journal.Header.DocDate = this.paymentDate;
            journal.Header.PostDate = this.paymentDate;
            journal.Header.RefNo = Common.GetNewConnectRefNo();
            this.ListOfRefNo.Add(journal.Header.RefNo);
        }

        private void BuildDebits()
        {
            GLDebit debitItem = new GLDebit();
            foreach (LoanApplication app in this.apps)
            {
                //                debitItem.Amount += app.BalanceAmount;
                debitItem.Amount += app.CapitalAmount;
            }
            debitItem.AccountCode = DEBIT_ACC_CODE;
            debitItem.LineDescrEn = journal.Header.Descr;
            journal.Debits.Add(debitItem);
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

        private GLCredit SetNewCreditItem()
        {
            try
            {
                GLCredit result = new GLCredit();
                result.AccountCode = CREDIT_ACC_CODE;
                result.Amount = this.SumDebit();
                result.LineDescrEn = journal.Header.Descr;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
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


        private void PrepareTextStream()
        {
            string contributionGLStrTemplete = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},,,,,,,,,,,,,,,,";

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

            //return writer.Connect(this.bizPacFile.FileName.ToString(), this.lines);
            return writer.Connect(this.BizPacFile);
            //return true;
        }


    }
}
