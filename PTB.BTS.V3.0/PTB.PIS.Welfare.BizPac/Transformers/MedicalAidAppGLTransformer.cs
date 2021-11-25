using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.MedicalAidEntities;
using PTB.PIS.Welfare.BizPac.GL;
using PTB.PIS.Welfare.BizPac.BizPacMappingBTS;
using PTB.PIS.Welfare.BizPac.FileManager;
using PTB.PIS.Welfare.BizPac.PTB.BTS.BTS2SAP.Connection;
using PTB.PIS.Welfare.BizPac.AP;
using System.Threading;
using System.Globalization;

namespace PTB.PIS.Welfare.BizPac.Transformers
{
    internal class MedicalAidAppGLTransformer : Transformer
    {

        public GLJournal journal = new GLJournal();
        private List<string> lines = new List<string>();
        private List<MedicalAidApplication> apps;
        private DateTime paymentDate;

        public MedicalAidAppGLTransformer(DateTime connectionDateTime, List<MedicalAidApplication> apps, DateTime paymentDate)
            : base(connectionDateTime)
        {
            this.apps = apps;
            this.paymentDate = paymentDate;
        }

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

                ConnectMedicalAid2SAP medAid2SAP = new ConnectMedicalAid2SAP();
                string fileName = medAid2SAP.GetMedicalAidNoAttSAPDataFile(journal, paymentDate);
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
            MedicalAidApplication temp = null;
            foreach (MedicalAidApplication app in this.apps)
            {
                if (temp == null) temp = app;
                if (app.AppliedAmount > temp.AppliedAmount) temp = app;
            }
            string hosName = temp.AHospital.Code == "ZZZZZZ" ? temp.NoContractHospitalName : temp.AHospital.EngName.Replace(',', ' ');
            //if (apps.Count > 1)
            //{
            //    // Kriangrkai A.
            //    //journal.Header.Descr = string.Format("Pay Medical Aid : {0} By {1} {2} {3} and others", hosName, temp.AEmployee.APrefix.English + temp.AEmployee.AName.English, temp.AEmployee.ASection.AShortName.English, temp.AEmployee.EmployeeNo);
            //    journal.Header.Descr = string.Format("Medical Aid {0} D. {1} and others", (temp.AEmployee.APrefix.English + temp.AEmployee.AName.English), temp.AEmployee.EmployeeNo);
            //}
            //else
            //{
            //    // Kriangrkai A.
            //    //journal.Header.Descr = string.Format("Pay Medical Aid : {0} By {1} {2} {3}", hosName, temp.AEmployee.APrefix.English + temp.AEmployee.AName.English, temp.AEmployee.ASection.AShortName.English, temp.AEmployee.EmployeeNo);
            //    journal.Header.Descr = string.Format("Medical Aid {0} D. {1}", (temp.AEmployee.APrefix.English + temp.AEmployee.AName.English), temp.AEmployee.EmployeeNo);
            //}
            journal.Header.Descr = "Medical Aid for PTB Staff";
            journal.Header.DocTypeCode = "PV";
            journal.Header.DocDate = this.paymentDate;
            journal.Header.PostDate = this.paymentDate;
            journal.Header.RefNo = Common.GetNewConnectRefNo();
            this.ListOfRefNo.Add(journal.Header.RefNo);
        }

        private void BuildDebits()
        {
            foreach (MedicalAidApplication app in this.apps)
            {
                string deptCode = app.AEmployee.ASection.ADepartment.Code;
                string secCode = app.AEmployee.ASection.Code;
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

        private void PrepareTextStream()
        {
            string medicalAidGLStrTemplete = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},,00,000055,,,,,,,,,,,,,";

            //bizPacFile.FileName = new BizGLFileName(this.connectDateTime);
            // debit lines
            foreach (GLDebit debitItem in journal.Debits)
            {
                string line =
                string.Format(medicalAidGLStrTemplete,
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
                string.Format(medicalAidGLStrTemplete,
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

        private GLDebit SetNewDebitItem(string bizCode, MedicalAidApplication app)
        {
            try
            {
                GLDebit result = new GLDebit();
                result.AccountCode = this.GetAccCodeByBizSec(bizCode);
                result.Amount = app.AppliedAmount;
                result.BusinessUnitCode = bizCode;
                result.LineDescrEn = journal.Header.Descr;
                //Kriangkrai A.
                result.MiscExpenseCode = this.GetSAPMiscCodeByBizSec(bizCode).Code;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
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


        //mapping GL account code Medical aid
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
                default: throw new Exception("Cant mapping Account code " + bizCode);
            }
        }

        private MiscExpenseCode GetSAPMiscCodeByBizSec(string bizCode)
        {
            switch (bizCode.Trim())
            {
                case "01": return new MiscExpenseCode("MEDX01", "Medical-Dept 01");
                case "02": return new MiscExpenseCode("MEDX02", "Medical-Dept 02");
                case "03": return new MiscExpenseCode("MEDX03", "Medical-Dept 03");
                case "05": return new MiscExpenseCode("MEDX03", "Medical-Dept 05");
                case "06": return new MiscExpenseCode("MEDX04", "Medical-Dept 06");
                case "AC": return new MiscExpenseCode("MEDXAC", "Medical-Dept AC");
                case "GA": return new MiscExpenseCode("MEDXGA", "Medical-Dept GA");
                case "PN": return new MiscExpenseCode("MEDXPN", "Medical-Dept PN");
                default: throw new Exception(string.Format("Cant mapping MiscExpense code with SectionCode {0}", bizCode.Trim()));
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
