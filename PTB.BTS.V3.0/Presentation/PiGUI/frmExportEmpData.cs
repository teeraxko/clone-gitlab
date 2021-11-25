using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using PresentationBase.CommonGUIBase;
using Facade.PiFacade;
using System.IO;
using System.Globalization;
using System.Data.SqlClient;
using SystemFramework.AppException;

namespace Presentation.PiGUI
{
    public partial class frmExportEmpData : ChildFormBase, IMDIChildFormGUI
    {
        public frmExportEmpData()
            : base()
        {
            InitializeComponent();
        }

        #region IMDIChildFormGUI Members

        public void ExitForm()
        {
            this.Close();
            //throw new Exception("The method or operation is not implemented.");
        }

        public void InitForm()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public void PrintForm()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public void RefreshForm()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        protected EmployeeFacade facadeEmployee = new EmployeeFacade();
        private const string EMP_PROFILE_CSV_REPORT_PATH = @"D:\BTS\EmpProfile\";

        private void Export_Click(object sender, EventArgs e)
        {
            bool isNewEmpChk = chkNewEmp.Checked;
            bool isResignEmpChk = chkResignEmp.Checked;
            bool isUpdateEmpChk = chkUpdateEmp.Checked;

            DataTable result;

            string fileDate = FileNameDateFormat(DateTime.Now);
            string empProfileCSVFolder = EMP_PROFILE_CSV_REPORT_PATH + "EmpProfile_" + fileDate + "\\";

            try
            {
                // Export new Emp. data to CSV file -> filter by "Hire_Date"
                if (isNewEmpChk)
                {
                    result = new DataTable();
                    result = facadeEmployee.GetNewEmployeeToExport(dtpDateFrom.Value.Date, dtpDateTo.Value.Date);

                    #region Generate CSV file to new HR Systems

                    if (result.Rows.Count > 0)
                    {
                        // Validate Export Folder is Exist?
                        bool isExists = System.IO.Directory.Exists(empProfileCSVFolder);

                        // If Export Folder path did not exist, create folder
                        if (!isExists)
                        {
                            System.IO.Directory.CreateDirectory(empProfileCSVFolder);
                        }

                        string newEmpFileName = empProfileCSVFolder + "NewEmp_" + fileDate + ".csv";

                        WriteNewEmpDetailsData(newEmpFileName, result);
                    }
                    #endregion

                }

                // Export Resign employee to CSV file -> filter by "Working_Status" (B = Normal, O = Resign) and Terminated Date
                if (isUpdateEmpChk)
                {
                    result = new DataTable();
                    result = facadeEmployee.GetUpdateEmployeeToExport(dtpDateFrom.Value.Date, dtpDateTo.Value.Date);

                    #region Generate CSV file to new HR Systems

                    if (result.Rows.Count > 0)
                    {
                        // Validate Export Folder is Exist?
                        bool isExists = System.IO.Directory.Exists(empProfileCSVFolder);

                        // If Export Folder path did not exist, create folder
                        if (!isExists)
                        {
                            System.IO.Directory.CreateDirectory(empProfileCSVFolder);
                        }

                        string updateEmpFileName = empProfileCSVFolder + "UpdateEmp_" + fileDate + ".csv";

                        WriteUpdateEmpDetailsData(updateEmpFileName, result);
                    }
                    #endregion
                }

                // Export Update employee to CSV file -> filter by Process_Date
                if (isResignEmpChk)
                {
                    result = new DataTable();
                    result = facadeEmployee.GetResignEmployeeToExport(dtpDateFrom.Value.Date, dtpDateTo.Value.Date);

                    #region Generate CSV file to new HR Systems

                    if (result.Rows.Count > 0)
                    {
                        // Validate Export Folder is Exist?
                        bool isExists = System.IO.Directory.Exists(empProfileCSVFolder);

                        // If Export Folder path did not exist, create folder
                        if (!isExists)
                        {
                            System.IO.Directory.CreateDirectory(empProfileCSVFolder);
                        }

                        string resignEmpFileName = empProfileCSVFolder + "ResignEmp_" + fileDate + ".csv";

                        WriteResignEmpDetailsData(resignEmpFileName, result);
                    }
                    #endregion
                }

                infoMessage("Export Success.");
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
        }

        private string FileNameDateFormat(DateTime datetime)
        {
            DateTimeFormatInfo de = new CultureInfo("en-US", false).DateTimeFormat;
            de.ShortDatePattern = "yyMMddHHmmss";
            de.LongTimePattern = "";
            de.ShortTimePattern = "";
            return datetime.ToString(de).Trim();
        }

        private void WriteNewEmpDetailsData(string fileName, DataTable result)
        {
            using (StreamWriter writeSm = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writeSm.Flush();
                StringBuilder stringBuilder;

                #region Header

                stringBuilder = new StringBuilder();

                int j = 0;
                for (j = 0; j < result.Columns.Count - 1; j++) // Last Column is "END" mark
                {
                    stringBuilder.Append("A" + j);
                    stringBuilder.Append(",");
                }

                stringBuilder.Append("A" + j); // Col A161

                writeSm.WriteLine(stringBuilder.ToString());
                #endregion

                #region Details Data
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    stringBuilder = new StringBuilder();

                    for (j = 0; j < result.Columns.Count - 1; j++) // Last Column is Process_Date
                    {
                        if (result.Rows[i][j].GetType() == typeof(DateTime))
                        {
                            DateTime dateData = (DateTime)result.Rows[i][j];
                            stringBuilder.Append(dateData.ToString("dd/MM/yyyy").Trim());
                        }
                        else
                        {
                            stringBuilder.Append(result.Rows[i][j].ToString().Trim());
                        }

                        stringBuilder.Append(",");
                    }

                    // END
                    stringBuilder.Append("END");

                    writeSm.WriteLine(stringBuilder.ToString());
                }
                #endregion
            }
        }

        private void WriteUpdateEmpDetailsData(string fileName, DataTable result)
        {
            using (StreamWriter writeSm = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writeSm.Flush();
                StringBuilder stringBuilder;

                #region Header
                stringBuilder = new StringBuilder();

                stringBuilder.Append("รหัสพนักงาน,PersonCardID,คำนำหน้าชื่อไทย,ชื่อ-ไทย,นามสกุล-ไทย,คำนำหน้าชื่อ-อังกฤษ,ชื่อ - อังกฤษ,นามสกุล-อังกฤษ,เพศ,Cmb1,cmb2,Cmb3,Cmb4,Cmb5,Cmb6,Cmb7,Cmb8,Cmb9,Cmb10,ตำแหน่ง,ระดับพนักงาน,การคิดค่าจ้าง,สถานะครอบครัว,วันเริ่มงาน,จำนวนวันทดลองงาน,วันบรรจุ,วันที่ออกงาน,อยู่ / ออก,เลขที่บัตรประชาชน,วันหมดอายุบัตร,เลขที่ผู้เสียภาษี,เลขที่บัตรประกันสังคม,เลขที่สมาชิกกองทุน,รพ.ประกันสังคม,เงินเดือน,งวด1,งวด2,งวด3,งวด4,สถานที่เกิด,วันเกิด,สูง,น้ำหนัก,เชื้อชาติ,สัญชาติ,ศาสนา,กรุ๊ปเลือด,เบอร์โทร,อีเมล์,สถานะการเกณฑ์ทหาร,งานอดิเรก,ความสามารถเรื่องกีฬา,พิมพ์ดีดไทย(คำ/นาที),พิมพ์ดีดอังกฤษ(คำ/นาที),มีใบอนุญาติขับรถ,เลขที่ใบอนุญาติ,มีใบอนุญาติขับขี่รถจักรยานยนต์,เลขที่ใบอนุญาติรถจักรยานยนต์,ชื่อบิดา,อาชีพ,สถานที่ทำงาน,เบอร์ติดต่อ,ชื่อมารดา,อาชีพ,สถานที่ทำงาน,เบอร์ติดต่อ,ชื่อคู่สมรส,อาชีพ,สถานที่ทำงาน,เบอร์ติดต่อ,จำนวนบุตร,จำนวนบุตรชาย,จำนวนบุตรหญิง,ลำดับพี่น้อง,ชื่อบริษัทที่เคยทำงาน1,เบอร์โทรศัพท์,ตำแหน่ง,ลักษณะงาน,Memo,เงินเดือนครั้งสุดท้าย,ชื่อบริษัทที่เคยทำงาน 2,เบอร์โทรศัพท์,ตำแหน่ง,ลักษณะงาน,Memo2,เงินเดือนครั้งล่าสุด 2,ชื่อบริษัทที่เคยทำงาน3,เบอร์โทรศัพท์,ตำแหน่ง,ลักษณะงาน,Memo3,เงินเดือนครั้งสุดท้าย3,ที่อยู่ปัจจุบัน-เลขที่,ซอย,ถนน,ตำบล,อำเภอ,จังหวัด,ประเทศ,รหัสไปรษณีย์,เบอร์โทรศัพท์,ที่อยู่ตามทะเบียนบ้าน-เลขที่,ซอย,ถนน,ตำบล,อำเภอ,จังหวัด,ประเทศ,รหัสไปรษณีย์,เบอร์โทรศัพท์,ประวัติการศึกษา-สถาบัน,ประเทศ,วุฒิการศึกษา,สาขา,เกรดเฉลี่ย,ปีที่เข้า,ปีที่จบ,ประวัติการศึกษา-สถาบัน,ประเทศ,วุฒิการศึกษา,สาขา,เกรดเฉลี่ย,ปีที่เข้า,ปีที่จบ,ประวัติการศึกษา-สถาบัน,ประเทศ,วุฒิการศึกษา,สาขา,เกรดเฉลี่ย,ปีที่เข้า,ปีที่จบ,ประวัติการศึกษา-สถาบัน,ประเทศ,วุฒิการศึกษา,สาขา,เกรดเฉลี่ย,ปีที่เข้า,ปีที่จบ,เลขที่บัญชี,ชื่อธนาคาร,บุตรที่ศึกษาที่สามารถลดหย่อนภาษีได้,เลขที่บัตรประชาชนบุตรที่ศึกษา1,เลขที่บัตรประชาชนบุตรที่ศึกษา2,เลขที่บัตรประชาชนบุตรที่ศึกษา3,บุตรที่ไม่ได้ศึกษาที่สามารถลดหย่อนภาษีได้,เลขที่บัตรประชาชนบุตรที่ไม่ศึกษา1,เลขที่บัตรประชาชนบุตรที่ไม่ศึกษา2,เลขที่บัตรประชาชนบุตรที่ศึกษาไม่3,สถานะภาพการทำงานคู่สมรส,การคิดภาษีคู่สมรส,ลดหย่อนค่าประกันชีวิต,ลดหย่อนค่าดอกเบี้ยกู้ซื้อบ้าน,ลดอย่อนเงินบริจาค,ลำดับสาขาประกันสังคม,ค่าจ้างสะสม,ภาษีสะสม,ประกันสังคมสะสม,กองทุนสำรองสะสม บริษัท,กองทุนสำรองสะสม พนักงาน,ประเภทพนักงาน");

                writeSm.WriteLine(stringBuilder.ToString());
                #endregion

                #region Details Data
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    stringBuilder = new StringBuilder();

                    for (int j = 0; j < result.Columns.Count - 2; j++) // Last Column is Process_Date
                    {
                        if (result.Rows[i][j].GetType() == typeof(DateTime))
                        {
                            DateTime dateData = (DateTime)result.Rows[i][j];
                            stringBuilder.Append(dateData.ToString("dd/MM/yyyy").Trim());
                        }
                        else
                        {
                            stringBuilder.Append(result.Rows[i][j].ToString().Trim());
                        }

                        stringBuilder.Append(",");
                    }

                    // Last Column
                    stringBuilder.Append(result.Rows[i][result.Columns.Count - 2].ToString().Trim());

                    writeSm.WriteLine(stringBuilder.ToString());
                }
                #endregion
            }
        }

        private void WriteResignEmpDetailsData(string fileName, DataTable result)
        {
            using (StreamWriter writeSm = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writeSm.Flush();
                StringBuilder stringBuilder;

                #region Header
                stringBuilder = new StringBuilder();

                stringBuilder.Append("รหัสพนักงาน,ประเภทการลาออก,สาเหตุการออก,วันที่ลาออก,รายละเอียด");

                writeSm.WriteLine(stringBuilder.ToString());
                #endregion

                #region Details Data
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    stringBuilder = new StringBuilder();

                    for (int j = 0; j < result.Columns.Count - 2; j++) // Last Column is Process_Date
                    {
                        if (result.Rows[i][j].GetType() == typeof(DateTime))
                        {
                            DateTime dateData = (DateTime)result.Rows[i][j];
                            stringBuilder.Append(dateData.ToString("dd/MM/yyyy").Trim());
                        }
                        else
                        {
                            stringBuilder.Append(result.Rows[i][j].ToString().Trim());
                        }

                        stringBuilder.Append(",");
                    }

                    // Last Column
                    stringBuilder.Append(result.Rows[i][result.Columns.Count - 2].ToString().Trim());

                    writeSm.WriteLine(stringBuilder.ToString());
                }
                #endregion
            }
        }

        //private void WriteDetailsData(bool isHaveHeader, string fileName, DataTable result)
        //{
        //    using (StreamWriter writeSm = new StreamWriter(fileName, false, Encoding.UTF8))
        //    {
        //        writeSm.Flush();
        //        StringBuilder stringBuilder;

        //        if (isHaveHeader)
        //        {
        //            // Header
        //            stringBuilder = new StringBuilder();

        //            int j = 0;
        //            for (j = 0; j < result.Columns.Count-1; j++) // Last Column is "END" mark
        //            {
        //                stringBuilder.Append("A" + j);
        //                stringBuilder.Append(",");
        //            }

        //            stringBuilder.Append("A" + j); // Col A161

        //            writeSm.WriteLine(stringBuilder.ToString());
        //        }

        //        // Details Data
        //        for (int i = 0; i < result.Rows.Count; i++)
        //        {
        //            stringBuilder = new StringBuilder();

        //            for (int j = 0; j < result.Columns.Count - 1; j++) // Last Column is Process_Date
        //            {
        //                if (result.Rows[i][j].GetType() == typeof(DateTime))
        //                {
        //                    DateTime dateData = (DateTime)result.Rows[i][j];
        //                    stringBuilder.Append(dateData.ToString("dd/MM/yyyy").Trim());
        //                }
        //                else
        //                {
        //                    stringBuilder.Append(result.Rows[i][j].ToString().Trim());
        //                }

        //                stringBuilder.Append(",");
        //            }

        //            // END
        //            if (isHaveHeader)
        //            {
        //                stringBuilder.Append("END");
        //            }

        //            writeSm.WriteLine(stringBuilder.ToString());
        //        }
        //    }
        //}
    }
}
