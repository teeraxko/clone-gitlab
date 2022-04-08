using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ictus.Common.Entity;
using Facade.ContractFacade;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

using ClosedXML.Excel;
using System.IO;
using Entity.CommonEntity;
using Facade.CommonFacade;
using PTB.BTS.Common.Flow;
using ictus.Common.Entity.Time;

namespace PTB.BTS.Batch
{
    public class GenerateExpectedIncomeReport : BatchProcessBase
    {

        private readonly string EMAIL_FORMAT_CODE = "ExpectedIncomeReport";
        private string outputFileName = String.Empty;
        private string outputFile = String.Empty;

        public GenerateExpectedIncomeReport() : base("B01")
        {
            outputFileName = String.Format(CommonConfiguration.ExpectedIncomeReportNamePattern, DateTime.Now.ToString("yyyyMMdd"));
            outputFile = Path.Combine(CommonConfiguration.TempFolder, outputFileName);
        }

        public override void Execute(params object[] args)
        {
            try
            {
                GenerateReport();
            }
            catch (Exception ex)
            {
                LogUtil.Logger.Error(ex);
            }
        }

        private void GenerateReport()
        {
            LogUtil.Logger.Info("Generating Report");
            Company company = (new ContractFacadeBase()).GetCompany();
            using (SqlConnection sqlConn = new SqlConnection(this.DBConnectionString))
            {
                SqlCommand sqlCom = sqlConn.CreateCommand();
                sqlCom.CommandText = "spExpectedIncomeReport";
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.Parameters.Add(new SqlParameter("@CompanyCode", company.CompanyCode));
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCom);
                DataTable dt = new DataTable("Expected Income Report");
                adapter.Fill(dt);
                FillExcel(dt);
                SendEmail();
            }
        }

        private void FillExcel(DataTable dt)
        {
            LogUtil.Logger.Info("Filling excel.");
            string fileTemplate = Path.Combine(CommonConfiguration.FileTemplatePath, "B01_ExpectedIncomeReport.xlsx");
            var wbook = new XLWorkbook(fileTemplate);
            var ws = wbook.Worksheet(1);
            SetFYTableHeader(ws);            
            int rowIndex = 4;            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rowIndex++; //start from row 5   
                int colIndex = 0;

                IXLCell cell = null;
                //Start from A
                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = i + 1;
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = dt.Rows[i]["CustomerShortName"];
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = dt.Rows[i]["CustomerNameEng"];
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = "ทะเบียน : " + String.Concat(dt.Rows[i]["Plate_No_Prefix"], dt.Rows[i]["Plate_No_Running_No"]) + Environment.NewLine
                                                               + "ยี่ห้อ-รุ่น : " + String.Concat(dt.Rows[i]["Model_English_Name"], " ", dt.Rows[i]["Engine_CC"], " cc.") + Environment.NewLine
                                                               + "สี : " + dt.Rows[i]["VehicleColorNameThai"];
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = Convert.ToDateTime(dt.Rows[i]["Contract_Start_Date"]).ToString("yyyy-MM-dd");
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = Convert.ToDateTime(dt.Rows[i]["Contract_End_Date"]).ToString("yyyy-MM-dd");
                SetBorderAround(cell);

                DayMonthYearStructure leasingPeriod = CalculateLeasingPeriod(Convert.ToDateTime(dt.Rows[i]["Contract_Start_Date"]), Convert.ToDateTime(dt.Rows[i]["Contract_End_Date"]).AddDays(1));
                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = String.Format("{0} ปี {1} เดือน {2} วัน",leasingPeriod.Years,leasingPeriod.Months,leasingPeriod.Days);// dt.Rows[i]["LeadPeriod"];
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = dt.Rows[i]["Unit_Charge_Amount"];
                cell.Style.NumberFormat.Format = "#,##0.00";
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = dt.Rows[i]["Contract_No"];
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = dt.Rows[i]["KindOfRental"];
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = dt.Rows[i]["KindOfVehicle"];
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = dt.Rows[i]["ContractRemark"];
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = dt.Rows[i]["1"];
                cell.Style.NumberFormat.Format = "#,##0.00";
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = dt.Rows[i]["2"];
                cell.Style.NumberFormat.Format = "#,##0.00";
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = dt.Rows[i]["3"];
                cell.Style.NumberFormat.Format = "#,##0.00";
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = dt.Rows[i]["4"];
                cell.Style.NumberFormat.Format = "#,##0.00";
                SetBorderAround(cell);

                colIndex++;
                cell = ws.Cell(rowIndex, colIndex);
                cell.Value = dt.Rows[i]["5"];
                cell.Style.NumberFormat.Format = "#,##0.00";
                SetBorderAround(cell);

            }
            //Sum
            rowIndex++;
            IXLCell sumCell = ws.Cell(String.Concat("L", rowIndex));
            sumCell.Value = "รวม";
            sumCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            sumCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            SetBorderAround(sumCell);

            sumCell = ws.Cell(String.Concat("M", rowIndex));
            sumCell.FormulaA1 = String.Format("SUM(M5:M{0})", rowIndex - 1);
            sumCell.Style.NumberFormat.Format = "#,##0.00";
            SetBorderAround(sumCell);

            sumCell = ws.Cell(String.Concat("N", rowIndex));
            sumCell.FormulaA1 = String.Format("SUM(N5:N{0})", rowIndex - 1);
            sumCell.Style.NumberFormat.Format = "#,##0.00";
            SetBorderAround(sumCell);

            sumCell = ws.Cell(String.Concat("O", rowIndex));
            sumCell.FormulaA1 = String.Format("SUM(O5:O{0})", rowIndex - 1);
            sumCell.Style.NumberFormat.Format = "#,##0.00";
            SetBorderAround(sumCell);

            sumCell = ws.Cell(String.Concat("P", rowIndex));
            sumCell.FormulaA1 = String.Format("SUM(P5:P{0})", rowIndex - 1);
            sumCell.Style.NumberFormat.Format = "#,##0.00";
            SetBorderAround(sumCell);

            sumCell = ws.Cell(String.Concat("Q", rowIndex));
            sumCell.FormulaA1 = String.Format("SUM(Q5:Q{0})", rowIndex - 1);
            sumCell.Style.NumberFormat.Format = "#,##0.00";
            SetBorderAround(sumCell);
            
            //Set summry font style
            IXLRange sumRange = ws.Range(String.Format("L{0}:Q{0}", rowIndex));
            sumRange.Style.Font.Bold = true;
            //Set focus cell when open
            ws.Cell("A4").SetActive(true);

            //wbook.SaveAs(ms);  cannot use memory due to the it has an error "Excel completed file level validation and repair" while opening.
            wbook.SaveAs(outputFile);
            wbook.Dispose();
        }

        private void SendEmail()
        {
            LogUtil.Logger.Info("Sending email");
            try
            {
                
                System.Net.Mail.Attachment attachment;

                EmailFormat emailFormat = (new EmailFormatFacade()).GetEmailFormat(EMAIL_FORMAT_CODE);
                if (emailFormat == null)
                {
                    throw new KeyNotFoundException(String.Format("EmailFormat Code : {0}", EMAIL_FORMAT_CODE));
                }

                //subject
                string subject = String.Format(emailFormat.Subject, DateTime.Now.ToString("MMM, dd yyyy"));
                //body
                string body = String.Format(emailFormat.Body, DateTime.Now.ToString("MMM, dd yyyy"));
                if (String.IsNullOrEmpty(emailFormat.Footer))
                {
                    body += Environment.NewLine + emailFormat.Footer;
                }

                //attachment
                System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                attachment = new System.Net.Mail.Attachment(outputFile, ct);

                attachment.ContentDisposition.FileName = outputFileName;
                EmailUtil.SendMail(subject
                        , body
                        , GetToEmail()
                        , GetCcEmail()
                        , GetBccEmail()
                        , attachment);
                attachment.Dispose();
            }
            catch 
            {
                throw;
            }
            finally
            {
                DoAfterSendMail(outputFile);
            }
        }

        private void SetFYTableHeader(IXLWorksheet ws)
        {
            //Generate date and time
            ws.Cell("Q2").Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            //Set FY at table header
            String[] fyHeader = GenerateFYHeader(5);
            ws.Cell("M4").Value = fyHeader[0];
            ws.Cell("N4").Value = fyHeader[1];
            ws.Cell("O4").Value = fyHeader[2];
            ws.Cell("P4").Value = fyHeader[3];
            ws.Cell("Q4").Value = fyHeader[4];

        }

        private void SetBorderAround(IXLCell cell)
        {
            cell.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        }

        private String[] GenerateFYHeader(int numberOfFY)
        {
            String[] fy = new string[numberOfFY];
            DateTime curDate = new DateTime(2022, 03, 31);
            int firstYear = curDate.Year;
            if(curDate.Month<=3){ // Jan, Feb, Mar
                firstYear = firstYear-1;
            }

            for(int i =0;i<5;i++){
                fy[i] = String.Format("Apr'{0} - Mar'{1}", (firstYear + i) % 100, (firstYear + i+1)%100);
            }
            return fy;
        }

        private void DoAfterSendMail(string file)
        {
            DeleteAttachemtnFile(file);
        }

        private void DeleteAttachemtnFile(string file)
        {
            LogUtil.Logger.InfoFormat("Deleting file : {0}", file);
            try
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                LogUtil.Logger.Error(ex);
            }
        }

        private string[] GetToEmail()
        {
            return CommonConfiguration.ExpectedIncomeReport_Mail_To.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string[] GetCcEmail()
        {
            return CommonConfiguration.ExpectedIncomeReport_Mail_Cc.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string[] GetBccEmail()
        {
            return String.Concat(CommonConfiguration.TPITAdmin).Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private DayMonthYearStructure CalculateLeasingPeriod(DateTime startDate, DateTime endDate)
        {
            AgeFlow flowAge = new AgeFlow();
            DayMonthYearStructure dayDiff = flowAge.DaysDiff(startDate, endDate);
            return dayDiff;
        }        
      
    }
}
