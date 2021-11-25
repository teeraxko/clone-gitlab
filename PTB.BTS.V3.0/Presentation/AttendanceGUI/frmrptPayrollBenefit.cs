using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.IO.IsolatedStorage;
using System.Configuration;
using System.Text;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using Facade.PiFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;
using System.Globalization;

namespace Presentation.AttendanceGUI
{
    public class frmrptPayrollBenefit : ChildFormBase, IMDIChildForm
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.GroupBox groupBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvpayroll;
        private System.ComponentModel.Container components = null;

        private void InitializeComponent()
        {
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label = new System.Windows.Forms.Label();
            this.cmdShow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crvpayroll = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(89, 24);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(96, 20);
            this.dtpDate.TabIndex = 8;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(35, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(46, 13);
            this.label.TabIndex = 7;
            this.label.Text = "จ่ายวันที่";
            // 
            // cmdShow
            // 
            this.cmdShow.Location = new System.Drawing.Point(209, 24);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(75, 23);
            this.cmdShow.TabIndex = 9;
            this.cmdShow.Text = "ส่งข้อมูล";
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.cmdShow);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Location = new System.Drawing.Point(355, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 56);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // crvpayroll
            // 
            this.crvpayroll.ActiveViewIndex = -1;
            this.crvpayroll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvpayroll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvpayroll.DisplayGroupTree = false;
            this.crvpayroll.Location = new System.Drawing.Point(736, 24);
            this.crvpayroll.Name = "crvpayroll";
            this.crvpayroll.ShowCloseButton = false;
            this.crvpayroll.ShowGroupTreeButton = false;
            this.crvpayroll.Size = new System.Drawing.Size(256, 48);
            this.crvpayroll.TabIndex = 24;
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.DisplayGroupTree = false;
            this.crvReport.Location = new System.Drawing.Point(16, 88);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowCloseButton = false;
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.Size = new System.Drawing.Size(1000, 648);
            this.crvReport.TabIndex = 12;
            // 
            // frmrptPayrollBenefit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.crvReport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crvpayroll);
            this.Name = "frmrptPayrollBenefit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmrptPayrollBenefit_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmrptPayrollBenefit_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region - private -
        private CompanyFacade facadeCompany;
        private frmMain mdiParent;
        private PayrollBenefitFacade facadePayrollBenefit;
        private DateTime forMonth;
        private PayrollPaymentControl payrollPaymentControl;
        private const string exportFile = "Monthly.txt";
        private const string PAYROLL_CSV_REPORT_PATH = @"D:\BTS\Payroll\";
        #endregion

        //		==============================Contructor==============================
        public frmrptPayrollBenefit()
            : base()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            facadePayrollBenefit = new PayrollBenefitFacade();
            this.Text = "Payroll Benefit";
        }

        //		============================== Private Method ==============================
        private CompanyInfo getCompany()
        {
            CompanyInfo objCompany = new CompanyInfo("12");
            if (facadeCompany.FillCompany(ref objCompany))
            {
                return objCompany;
            }
            else
            {
                return null;
            }
        }

        private void deleteFiles()
        {
            string pathFile = Directory.GetCurrentDirectory() + @"\" + exportFile;
            if (File.Exists(pathFile))
            {
                FileInfo file = new FileInfo(pathFile);
                file.Delete();
                file = null;
            }
        }

        private bool validateForm()
        {
            if (facadePayrollBenefit.FillTrPayrollBenefitList())
            {
                TrPayrollBenefit objTrPayrollBenefit;
                for (int i = 0; i < facadePayrollBenefit.ObjTrPayrollBenefitList.Count; i++)
                {
                    objTrPayrollBenefit = facadePayrollBenefit.ObjTrPayrollBenefitList[i];

                    if (objTrPayrollBenefit.OTAHour < 0 || objTrPayrollBenefit.OTBHour < 0 ||
                        objTrPayrollBenefit.OTCHour < 0 || objTrPayrollBenefit.ExtraAmount < 0 ||
                        objTrPayrollBenefit.DeductionAmount < 0)
                    {
                        Message(MessageList.Information.I0004);
                        return false;
                    }
                }
            }
            return true;
        }

        private void reportDatabaseLogon()
        {
            try
            {
                payrollPaymentControl.AYearMonth = new YearMonth(dtpDate.Value);

                if (facadePayrollBenefit.FillPayrollPaymentControl(ref payrollPaymentControl) && payrollPaymentControl.ABenefitPayment.PaymentStatus.Equals(PAYMENT_STATUS_TYPE.YES))
                {
                    Message(MessageList.Error.E0013, "คำนวณ Payroll Benefit", "ผ่านกระบวนการจ่ายเงินแล้วเมื่อ " + payrollPaymentControl.ABenefitPayment.PaymentDate.ToShortDateString());
                    dtpDate.Focus();
                }
                else
                {
                    if (facadePayrollBenefit.GenPayrollBenefitProcess(dtpDate.Value))
                    {
                        //If error in execute process, it show by try-catch.
                        facadePayrollBenefit.GenPayrollBenefit(dtpDate.Value);

                        // 10/10/2019 Modify system to generate CSV file to new HR systems


                        if (validateForm())
                        {
                            #region Generate CSV file to Monthly.txt
                            //SaveFileDialog saveDialog = new SaveFileDialog();
                            //saveDialog.InitialDirectory = @"c:\..";
                            ////String exportFile = "C:\\Monthly.txt";
                            //String exportFile = "Monthly.txt";
                            //saveDialog.FileName = exportFile;

                            //DialogResult sResult = saveDialog.ShowDialog();
                            ////deleteFiles();

                            //if (sResult.Equals(DialogResult.OK) && facadePayrollBenefit.ObjTrPayrollBenefitList.Count > 0)
                            //{
                            //    //Generate character separated values file.
                            //    //using (StreamWriter writeSm = new StreamWriter(exportFile))
                            //    using (StreamWriter writeSm = new StreamWriter(saveDialog.FileName))
                            //    {
                            //        writeSm.Flush();

                            //        TrPayrollBenefit trPayrollBenefit;
                            //        StringBuilder stringBuilder;

                            //        for (int i = 0; i < facadePayrollBenefit.ObjTrPayrollBenefitList.Count; i++)
                            //        {
                            //            stringBuilder = new StringBuilder();
                            //            trPayrollBenefit = facadePayrollBenefit.ObjTrPayrollBenefitList[i];

                            //            stringBuilder.Append("\" \"");
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("\" \"");
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("\"");
                            //            stringBuilder.Append(facadePayrollBenefit.ObjTrPayrollBenefitList.Company.CompanyCode.ToString().Trim());
                            //            stringBuilder.Append("\"");
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("\"M\"");
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("\"");
                            //            //Key
                            //            stringBuilder.Append(trPayrollBenefit.AEmployee.EmployeeNo.ToString().Trim());
                            //            stringBuilder.Append("\"");
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("0.00");
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("0.00");
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("0.00");
                            //            stringBuilder.Append(",");
                            //            //File1
                            //            stringBuilder.Append(trPayrollBenefit.OTAHour.ToString("0.00"));
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append(trPayrollBenefit.OTBHour.ToString("0.00"));
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append(trPayrollBenefit.OTCHour.ToString("0.00"));
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("0.00");
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("0.00");
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("0.00");
                            //            stringBuilder.Append(",");
                            //            // File2
                            //            stringBuilder.Append(trPayrollBenefit.ExtraAmount.ToString("0.00"));
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("0.00");
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("0.00");
                            //            stringBuilder.Append(",");
                            //            // File3
                            //            stringBuilder.Append(trPayrollBenefit.DeductionAmount.ToString("0.00"));
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("0.00");
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("0.00");
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append("0.00");
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append(dtpDate.Value.ToString("yyMMdd"));
                            //            stringBuilder.Append(",");

                            //            stringBuilder.Append(DateTime.Today.ToString("yyyyMMdd"));

                            //            writeSm.WriteLine(stringBuilder.ToString());
                            //        }
                            //        stringBuilder = null;
                            //        trPayrollBenefit = null;
                            //    }
                            //}
                            #endregion

                            #region Generate CSV file to new HR Systems

                            string fileDate = FileNameDateFormat(DateTime.Now);
                            string payrollCSVFolder = PAYROLL_CSV_REPORT_PATH + "Payroll_" +fileDate + "\\";

                            // Validate Export Folder is Exist?
                            bool isExists = System.IO.Directory.Exists(payrollCSVFolder);

                            if (!isExists)
                            {
                                System.IO.Directory.CreateDirectory(payrollCSVFolder);
                            }

                            if (facadePayrollBenefit.ObjTrPayrollBenefitList.Count > 0)
                            {
                                string otFileName = payrollCSVFolder + "OT_" + fileDate + ".csv";
                                string specialAllowanceFileName = payrollCSVFolder + "SA_" + fileDate + ".csv";
                                string deductionFileName = payrollCSVFolder + "DE_" + fileDate + ".csv";
                                
                                GenerateOTCSV(otFileName, facadePayrollBenefit.ObjTrPayrollBenefitList);
                                GenerateSpecialAllowanceCSV(specialAllowanceFileName, facadePayrollBenefit.ObjTrPayrollBenefitList);
                                GenerateDeductionCSV(deductionFileName, facadePayrollBenefit.ObjTrPayrollBenefitList);
                            }
                            #endregion
                        }

                        #region - Export Method -
                        //======================================
                        //	string exportPath =  exportFileName;			
                        //						string StartDate1 = Convert.ToString(dtpDate.Value.Day);
                        //						string StartDate2 = Convert.ToString(dtpDate.Value.Month);
                        //						string StartDate3 = Convert.ToString(dtpDate.Value.Year);
                        //
                        //						ReportDocument crReportDocument = new ReportDocument(); 
                        //						crReportDocument.Load(@ApplicationProfile.REPORT_PATH + "rptPayrollBenefit.rpt");
                        //						DataSourceConnections dataSourceConnections = crReportDocument.DataSourceConnections;
                        //						IConnectionInfo iConnectionInfo = dataSourceConnections[0];
                        //						iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);
                        //		
                        //						crReportDocument.DataDefinition.FormulaFields["DAY"].Text = StartDate1;
                        //						crReportDocument.DataDefinition.FormulaFields["MONTH"].Text = StartDate2;
                        //						crReportDocument.DataDefinition.FormulaFields["YEAR"].Text = StartDate3;
                        //				
                        //						crvpayroll.ReportSource = crReportDocument;
                        //
                        //						ExportOptions crExportOptions; 
                        //						DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions(); 
                        //
                        //						crDestOptions.DiskFileName = exportPath; 
                        //
                        //						CharacterSeparatedValuesFormatOptions csValuesFormatOptions;
                        //						csValuesFormatOptions = ExportOptions.CreateCharacterSeparatedValuesFormatOptions();
                        //						csValuesFormatOptions.PreserveDateFormatting = true;
                        //						csValuesFormatOptions.PreserveNumberFormatting = true;
                        //			
                        //
                        //						crExportOptions = crReportDocument.ExportOptions; 
                        //						crExportOptions.DestinationOptions = crDestOptions; 
                        //						crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile; 
                        //						crExportOptions.ExportFormatType = ExportFormatType.CharacterSeparatedValues; 
                        //						crExportOptions.ExportFormatOptions = csValuesFormatOptions;
                        //
                        //						crReportDocument.Export(crExportOptions); 
                        #endregion

                        //Load report rptPayrollConnectionCheckList.rpt
                        string Date1 = Convert.ToString(dtpDate.Value.AddMonths(-1).Month);
                        string Date2 = Convert.ToString(dtpDate.Value.AddMonths(-1).Year);

                        ReportDocument crReportDocument1 = new ReportDocument();
                        crReportDocument1.Load(@ApplicationProfile.REPORT_PATH + "rptPayrollConnectionCheckList.rpt");
                        DataSourceConnections dataSourceConnections1 = crReportDocument1.DataSourceConnections;
                        IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                        iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                        crReportDocument1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + getCompany().AFullName.Thai + "'";
                        crReportDocument1.DataDefinition.FormulaFields["MONTH"].Text = Date1;
                        crReportDocument1.DataDefinition.FormulaFields["YEAR"].Text = Date2;

                        crvReport.ReportSource = crReportDocument1;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }

        // 10/10/2019 
        #region Generate CSV file to import data to new HR System
        private string FileNameDateFormat(DateTime datetime)
        {
            DateTimeFormatInfo de = new CultureInfo("en-US", false).DateTimeFormat;
            de.ShortDatePattern = "yyMMddHHmmss";
            de.LongTimePattern = "";
            de.ShortTimePattern = "";
            return datetime.ToString(de).Trim();
        }

        private void GenerateOTCSV(string filename, TrPayrollBenefitList dataList)
        {
            using (StreamWriter writeSm = new StreamWriter(filename, false, Encoding.UTF8))
            {
                writeSm.Flush();

                TrPayrollBenefit trPayrollBenefit;
                StringBuilder stringBuilder;
                
                string otAHH = string.Empty;
                string otAMM = string.Empty;

                string otBHH = string.Empty;
                string otBMM = string.Empty;

                string otCHH = string.Empty;
                string otCMM = string.Empty;

                #region File Header
                // Line 1
                stringBuilder = new StringBuilder();
                stringBuilder.Append(",,วันทำงาน,,,,ขาดงาน,,,,ลาหักเงิน,,,,สาย,,,ออกก่อน,,,,,โอที ช่อง 1,,,โอทีช่อง 2,,,โอที ช่อง 3,,,โอที ช่อง 4,,,โอที ช่อง 5,,,โอทีช่อง 6,");
                writeSm.WriteLine(stringBuilder.ToString());

                // Line 2
                stringBuilder = new StringBuilder();
                stringBuilder.Append("PersonCode,WorkD ,WorkH,WorkM,WorkB ,AbsentD,AbsentH,AbsentM,AbsentB ,LeaveDD,LeaveDH,LeaveDM,LeaveDB,LateH,LateM,LateB,EarlyH,EarlyM,EarlyB ,ShiftN,FoodN,OT1H,OT1M,OT1B,OT2H,OT2M,OT2B,OT3H,OT3M,OT3B,OT4H,OT4M,OT4B,OT5H,OT5M,OT5B,OT6H,OT6M,OT6B");
                writeSm.WriteLine(stringBuilder.ToString());
                
                // Line 3
                stringBuilder = new StringBuilder();
                stringBuilder.Append("รหัสพนักงาน,วันทำงาน,ชั่วโมง,นาที,เงินบาท,วันขาดงาน,ชั่วโมง,นาที,เงินบาท,วันลาหักเงิน,ชั่วโมง,นาที,เงินบาท,ชั่วโมงสาย,นาที,เงินบาท,ชั่วโมงออกก่อน,นาที,เงินบาท,ค่ากะ,ค่าอาหาร,ชั่วโมง,นาที,เงินบาท,ชั่วโมง,นาที,เงินบาท,ชั่วโมง,นาที,เงินบาท,ชั่วโมง,นาที,เงินบาท,ชั่วโมง,นาที,เงินบาท,ชั่วโมง,นาที,เงินบาท");
                writeSm.WriteLine(stringBuilder.ToString());
                #endregion

                // Write Details
                for (int i = 0; i < dataList.Count; i++)
                {
                    stringBuilder = new StringBuilder();
                    trPayrollBenefit = dataList[i];

                    // Prepare Data
                    otAHH = (trPayrollBenefit.OTAHour.ToString("0.00")).Split('.')[0];
                    otAMM = (trPayrollBenefit.OTAHour.ToString("0.00")).Split('.')[1];

                    otBHH = (trPayrollBenefit.OTBHour.ToString("0.00")).Split('.')[0];
                    otBMM = (trPayrollBenefit.OTBHour.ToString("0.00")).Split('.')[1];

                    otCHH = (trPayrollBenefit.OTCHour.ToString("0.00")).Split('.')[0];
                    otCMM = (trPayrollBenefit.OTCHour.ToString("0.00")).Split('.')[1];

                    //Key -> Emp No. (Col. A)
                    stringBuilder.Append(trPayrollBenefit.AEmployee.EmployeeNo.ToString().Trim());
                    stringBuilder.Append(",");

                    //วันทำงาน
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");

                    //ขาดงาน
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");

                    //ลาหักเงิน
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");

                    //สาย
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");

                    //ออกก่อน
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");

                    //ค่ากะ
                    stringBuilder.Append(",");

                    //ค่าอาหาร
                    stringBuilder.Append(",");
                    
                    //โอที 1 (ช่อง1)
                    stringBuilder.Append(otBHH.Trim());
                    stringBuilder.Append(",");
                    stringBuilder.Append(otBMM.Trim());
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");

                    //โอที 1.5 (ช่อง2)
                    stringBuilder.Append(otAHH.Trim());
                    stringBuilder.Append(",");
                    stringBuilder.Append(otAMM.Trim());
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");

                    //โอที 2 (ช่อง3)
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");

                    //โอที 2.5 (ช่อง4)
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");

                    //โอที 3 (ช่อง5)
                    stringBuilder.Append(otCHH.Trim());
                    stringBuilder.Append(",");
                    stringBuilder.Append(otCMM.Trim());
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");

                    //โอทีเหมาจ่าย (ช่อง6)
                    stringBuilder.Append(",");
                    stringBuilder.Append(",");

                    writeSm.WriteLine(stringBuilder.ToString());
                }
                stringBuilder = null;
                trPayrollBenefit = null;
            }
        }

        private void GenerateSpecialAllowanceCSV(string filename, TrPayrollBenefitList dataList)
        {
            using (StreamWriter writeSm = new StreamWriter(filename, false, Encoding.UTF8))
            {
                writeSm.Flush();

                TrPayrollBenefit trPayrollBenefit;
                StringBuilder stringBuilder;

                for (int i = 0; i < dataList.Count; i++)
                {
                    stringBuilder = new StringBuilder();
                    trPayrollBenefit = dataList[i];

                    //Key -> Emp No. (Col. A)
                    stringBuilder.Append(trPayrollBenefit.AEmployee.EmployeeNo.ToString().Trim());
                    stringBuilder.Append(",");

                    //ยอดเงิน
                    stringBuilder.Append(trPayrollBenefit.ExtraAmount.ToString("0.00"));

                    writeSm.WriteLine(stringBuilder.ToString());
                }
                stringBuilder = null;
                trPayrollBenefit = null;
            }
        }

        private void GenerateDeductionCSV(string filename, TrPayrollBenefitList dataList)
        {
            using (StreamWriter writeSm = new StreamWriter(filename, false, Encoding.UTF8))
            {
                writeSm.Flush();

                TrPayrollBenefit trPayrollBenefit;
                StringBuilder stringBuilder;

                for (int i = 0; i < dataList.Count; i++)
                {
                    stringBuilder = new StringBuilder();
                    trPayrollBenefit = dataList[i];

                    //Key -> Emp No. (Col. A)
                    stringBuilder.Append(trPayrollBenefit.AEmployee.EmployeeNo.ToString().Trim());
                    stringBuilder.Append(",");

                    //ยอดเงิน
                    stringBuilder.Append(trPayrollBenefit.DeductionAmount.ToString("0.00"));

                    writeSm.WriteLine(stringBuilder.ToString());
                }

                stringBuilder = null;
                trPayrollBenefit = null;
            }
        }
        #endregion

        //		==============================Base Event ==============================
        public void InitForm()
        {
            try
            {
                payrollPaymentControl = new PayrollPaymentControl();
                payrollPaymentControl.AYearMonth = new YearMonth(DateTime.Today);

                if (facadePayrollBenefit.FillPayrollPaymentControl(ref payrollPaymentControl))
                {
                    dtpDate.Value = payrollPaymentControl.ABenefitPayment.PaymentDate;
                }
                else
                {
                    dtpDate.Value = facadePayrollBenefit.RetriveDate(new System.DateTime(DateTime.Today.Year, DateTime.Today.Month, 21));
                }

                crvpayroll.Hide();
                crvReport.Hide();
                mdiParent.EnableExitCommand(true);
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
            finally
            {
            }
        }

        public void RefreshForm()
        {
            crvReport.Show();
            mdiParent.EnableExitCommand(true);
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        }

        //		============================== Event ==============================
        private void cmdShow_Click(object sender, System.EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            reportDatabaseLogon();
            RefreshForm();
            mdiParent.EnableExitCommand(true);
            crvReport.RefreshReport();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void frmrptPayrollBenefit_Load(object sender, System.EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void dtpDate_ValueChanged(object sender, System.EventArgs e)
        {
            forMonth = new System.DateTime(dtpDate.Value.AddMonths(-1).Year, dtpDate.Value.AddMonths(-1).Month, 1);
        }

        private void frmrptPayrollBenefit_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvpayroll);
            CloseReport(crvReport);
        }
    }
}
