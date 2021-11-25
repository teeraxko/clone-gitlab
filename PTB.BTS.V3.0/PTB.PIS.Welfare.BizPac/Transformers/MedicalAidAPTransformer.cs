using System;
using System.Collections.Generic;
using System.Text;
using PTB.PIS.Welfare.BizPac.AP;
using ictus.PIS.Welfare.Entity.MedicalAidEntities;
using PTB.PIS.Welfare.BizPac.BizPacMappingBTS;
using PTB.PIS.Welfare.BizPac.FileManager;
using PTB.PIS.Welfare.BizPac.DataAccess;
using PTB.PIS.Welfare.BizPac.PTB.BTS.BTS2SAP.Connection;
using System.Threading;
using System.Globalization;

namespace PTB.PIS.Welfare.BizPac.Transformers
{
    internal class MedicalAidAPTransformer : Transformer
    {
        private List<string> lines = new List<string>();

        private List<APJournalForMedicalAid> journals = new List<APJournalForMedicalAid>();

        private List<MedicalAidApplication> apps;

        private DateTime postingDate;

        // Kriangkrai A. 18/2/2018 Modify to transfer to SAP and allow user select posting date from screen
        public MedicalAidAPTransformer(DateTime connectionDateTime, List<MedicalAidApplication> apps, DateTime postingDate)
            : base(connectionDateTime)
        {
            this.apps = apps;
            this.postingDate = postingDate;
        }

        // Kriangkrai A. 18/2/2018 Modify to transfer to SAP and allow user select posting date from screen
        // Main method to transfer data to BizPac
        //public override bool Transform()
        //{
        //    GroupApJournal();
        //    PrepareTextStream();    // Prepare data to export to CSV for BizPac
        //    if (WriteTextStream())  // Write data to CSV and transfer via FTP
        //    {
        //        return UpdateDataBase();
        //    }
        //    else
        //        return false;
        //}

        public override bool Transform()
        {
            try
            {
                currentCultureInfo = Thread.CurrentThread.CurrentCulture;

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

                GroupApJournal();       // Mapping data in entity
                PrepareTextStream();    // Prepare data as list of string to export to CSV for BizPac

                ConnectMedicalAid2SAP medAidAtt2SAP = new ConnectMedicalAid2SAP();
                string filename = string.Empty;
                filename = medAidAtt2SAP.GetMedicalAidAttSAPDataFile(journals, postingDate);// Mapping in SAP Template
                this.BizPacFile = filename;

                if (WriteTextStream())
                {
                    return UpdateDataBase();    // Update data in DB
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = currentCultureInfo;
            }

            return false;
        }

        private void GroupApJournal()
        {
            foreach (MedicalAidApplication app in this.apps)
            {
                APJournalForMedicalAid journal = GetWorkingJournal(app);
                UpdateItemInJournal(journal, app);
            }
        }

        private APJournalForMedicalAid GetWorkingJournal(MedicalAidApplication app)
        {
            bool isDup = false;
            APJournalForMedicalAid journal = null;
            string venderCode = app.AHospital.Code;
            string invoice = app.InvoiceNo;
            foreach (APJournalForMedicalAid findJournal in this.journals)
            {
                if (findJournal.CheckVendorCodeInvoice(venderCode, invoice))
                {
                    isDup = true;
                    journal = findJournal;
                    break;
                }
            }
            if (!isDup)
            {
                journal = CreateNewJournal(app);
                this.journals.Add(journal);
            }
            journal.Apps.Add(app);

            return journal;
        }


        private void UpdateItemInJournal(APJournal workingJournal, MedicalAidApplication app)
        {
            APItem item = GetWorkingItem(workingJournal, app);
            if (item == null)
            {
                item = CreateNewAPItem(app);
                workingJournal.Items.Add(item);
            }
            else
                item.Amount += app.ActualAmount;
            //              item.Amount += app.AppliedAmount;
        }

        private APItem GetWorkingItem(APJournal workingJournal, MedicalAidApplication app)
        {
            bool isDup = false;
            APItem result = CreateNewAPItem(app);
            foreach (APItem item in workingJournal.Items)
            {
                if (result.MiscExpenseCode == item.MiscExpenseCode)
                {
                    isDup = true;
                    result = item;
                    break;
                }
            }
            if (!isDup)
                result = null;
            return result;
        }

        private APJournalForMedicalAid CreateNewJournal(MedicalAidApplication app)
        {
            APJournalForMedicalAid journal = new APJournalForMedicalAid();
            journal.Header.DocType = "P2";
            journal.Header.DocNo = Common.GetNewConnectRefNo();
            this.listOfRefNo.Add(journal.Header.DocNo);
            // Kriangkrai A. 1/3/2019 set DocDate to posting date which user select from screen
            //journal.Header.DocDate = Common.EndMonthDate(app.CreateDate);
            journal.Header.DocDate = postingDate;
            journal.Header.VenderCode = app.AHospital.Code;
            journal.Header.VenderName = app.AHospital.EngName;
            journal.Header.VendorInvoiceDate = Common.EndMonthDate(app.CreateDate);
            journal.Header.VendorInvoice = app.InvoiceNo;
            journal.Header.VatCode = "VX";
            journal.Header.VatType = "N";
            journal.Header.VatCalType = "E";
            journal.Header.DueDate = Common.EndMonthDate(app.CreateDate);
            journal.Header.BusinessPlace = "0000";
            //journal.Header.Remark = string.Format("Medical charge in {0}", app.CreateDate.ToString("MMM yyyy"));
            journal.Header.Remark = string.Format("Medical charge in {0}", postingDate.ToString(Common.ShortMonthNameYearFormat()));
            journal.Header.InvoiceType = "S";
            return journal;
        }

        private APItem CreateNewAPItem(MedicalAidApplication app)
        {
            APItem result = new APItem();
            result.Amount = app.ActualAmount;
            //            result.Amount = app.AppliedAmount;
            result.Price = 0;
            result.Quantity = 0;
            string deptCode = app.AEmployee.ASection.ADepartment.Code;
            string secCode = app.AEmployee.ASection.Code;
            string bizSecCode = SectionMapManager.GetBizSectionCode(deptCode, secCode);
            //MiscExpenseCode mCode = MiscExpenseCode.GetMiscCodeByBizSec(bizSecCode); // Kriangkrai A. 18/2/2019
            MiscExpenseCode mCode = MiscExpenseCode.GetSAPMiscCodeByBizSec(bizSecCode);
            result.MiscExpenseCode = mCode.Code;
            result.ItemDescr = mCode.Name;
            result.BusinessUnitCode = bizSecCode;
            return result;
        }

        private bool UpdateDataBase()
        {
            bool result = true;
            foreach (APJournalForMedicalAid journal in this.journals)
            {
                BizPacDBBase bizTable = new EmployeeMedicalAidBizDB(journal.Header.DocNo, connectDateTime, Common.CurrentCompany, journal.Apps);
                result = result && bizTable.UpdateData();
                this.ListOfRefNo.Add(journal.Header.DocNo);
            }
            return result;
        }

        private void PrepareTextStream()
        {
            string medicalAidAPStrTemplete = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24}";
            //bizPacFile.FileName = new BizAPFileName(this.connectDateTime);

            foreach (APJournalForMedicalAid journal in this.journals)
            {
                int lineIndex = 0;
                foreach (APItem item in journal.Items)
                {

                    string line =

                        string.Format(medicalAidAPStrTemplete,
                        journal.Header.DocType,
                        journal.Header.DocNo,
                        journal.Header.DocDate.ToString(Common.EngDateFormat("yyyyMMdd")).Trim(),
                        journal.Header.VenderCode,
                        journal.Header.VenderName.Replace(',', ' '),
                        journal.Header.VendorInvoice,
                        journal.Header.VendorInvoiceDate.ToString(Common.EngDateFormat("yyyyMMdd")).Trim(),
                        journal.Header.VatCode,
                        journal.Header.VatType,
                        journal.Header.VatCalType,
                        journal.Header.DueDate.ToString(Common.EngDateFormat("yyyyMMdd")).Trim(),
                        journal.Header.BusinessPlace,
                        journal.Header.Remark,
                        journal.Header.InvoiceType,
                        journal.BaseAmount.ToString(),
                        journal.VatAmount.ToString(),
                        journal.NetAmount.ToString(),
                        Convert.ToString(++lineIndex),
                        item.MiscExpenseCode,
                        item.ItemDescr,
                        item.Quantity.ToString(),
                        item.Price,
                        item.Amount.ToString(),
                        item.BusinessUnitCode,
                        "");

                    this.lines.Add(line);
                }
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

