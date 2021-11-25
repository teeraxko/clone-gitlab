using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.LoanEntities;
using PTB.PIS.Welfare.BBL.CSV;
using ictus.PIS.PI.Entity;
using PTB.PIS.Welfare.BBL.DataAccess;
using System.Diagnostics;

namespace PTB.PIS.Welfare.BBL.Transformers
{
    class BBLTransformerLoan : BBLTransformerBase
    {
        private List<LoanApplication> apps;
        private DateTime connectionDateTime;

        public BBLTransformerLoan(DateTime connectionDateTime, List<LoanApplication> apps)
        {
            this.connectionDateTime = connectionDateTime.Date;
            this.apps = apps;
        }

        public override void Tranform()
        {
            this.BulidHeader();
            foreach (LoanApplication app in this.apps)
            {
                this.BuildDetail(app);
            }

            this.PrepareTextStream();

            BBLDBLoan db = new BBLDBLoan(this.connectionDateTime, Common.CurrentCompany, this.apps);
            db.UpdateData();
        }

        private void BulidHeader()
        {
            this.csvFile.Header.CompName = Common.CompanyInfo.AFullName.English;
            this.csvFile.Header.DueDate = this.connectionDateTime;

        }

        private void BuildDetail(LoanApplication app)
        {
            CSVDetail detailItem = new CSVDetail();
            Employee emp = app.Employee;
            detailItem.Status = "0";
            detailItem.DeptCode = emp.ASection.ADepartment.Code;
            detailItem.EmpNo = emp.EmployeeNo;
            detailItem.EmpFullName = string.Format("{0} {1}", emp.AName.English, emp.ASurname.English);
            detailItem.BankAccCode = BBLDBBankAccount.FillByEmp(Common.CurrentCompany, emp).Code;
            detailItem.Amount = app.CapitalAmount;
            detailItem.Filler = "0000";
            detailItem.TransCode = "6";
            detailItem.Spare = "000";
            this.csvFile.Details.Add(detailItem);
        }

        private void PrepareTextStream()
        {
            string headerTemp = "{0}{1}{2}{3}{4}{5}{6}{7}{8}";
            string detailTemp = "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}";

            string headerLine = string.Format(headerTemp,
                "H",
                this.csvFile.Header.CompName.PadRight(25).Substring(0, 25),
                this.csvFile.Header.DueDate.ToString(Common.EngDateFormat("ddMMyy")).PadRight(6).Trim(),
                this.csvFile.Header.CompAccount.PadRight(10),
                Common.ConvertToBLLMoneyFormat(10, this.csvFile.TotalAmount),
                "000",
                this.csvFile.DetailCount.ToString("0000"),
                "0000000000000000000",
                Common.ConvertToBLLZeroFormat(2, this.csvFile.Header.CompCode));

            this.csvFile.lines.Add(headerLine);

            foreach (CSVDetail detail in this.csvFile.Details)
            {
                string detailLine = string.Format(detailTemp,
                    "I",
                    "0",
                    Common.ConvertToBLLZeroFormat(3, detail.DeptCode),
                    Common.ConvertToBLLZeroFormat(10, detail.EmpNo),
                    detail.EmpFullName.PadRight(35),
                    Common.ConvertToBLLZeroFormat(10, detail.BankAccCode),
                    Common.ConvertToBLLMoneyFormat(10, detail.Amount),
                    "0000",
                    "6",
                    "000",
                    Common.ConvertToBLLZeroFormat(2, this.csvFile.Header.CompCode));
                this.csvFile.lines.Add(detailLine);
            }
            try
            {
                Common.WriteFile(@"D:\COMDAT.DAT", this.csvFile.lines);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
