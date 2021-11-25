using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace PTB.PIS.Welfare.WindowsApp.CommonGUI {
    class Common {
        public static DataTable CreateDataTable(DataColumn[] cols) {
            DataTable dt = new DataTable();
            foreach (DataColumn col in cols) {
                dt.Columns.Add(col);
            }
            return dt;
        }
        
        public static DialogResult ConfirmDeleteResult() {
            return MessageBox.Show("ยืนยันลบข้อมูล", "", MessageBoxButtons.OKCancel);
        }


        public static DateTime EndMonthDate(DateTime date) {
            int year = date.Year;
            int month = date.Month;
            return Common.EndMonthDate(year, month);
        }

        public static DateTime EndMonthDate(int year, int month) {
            int endMonthDay = DateTime.DaysInMonth(year, month);
            return new DateTime(year, month, endMonthDay);
        }

        public static void PaintHeaderSeq(DataGridView dg) {
            dg.RowHeadersWidth = 50;
            //dg.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dg.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            for (int i = 0; i < dg.Rows.Count; i++) {
                dg.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
            }
        }


        public static DateTimeFormatInfo ShortDateFormat(string format)
        {
            DateTimeFormatInfo de = new CultureInfo( "en-US", false ).DateTimeFormat;
            de.ShortDatePattern = format;
            return de;
        }

    }

    internal class Mbox {
        public static DialogResult Confirm(string msg) {
            return MessageBox.Show(msg, "", MessageBoxButtons.OKCancel);
        }
        public static DialogResult ErrorMessage(string message) {
            return MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ConfirmMessage(string message) 
        {
            return MessageBox.Show(message, "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
    }

    internal class MonthYear {
        public static void Diff(DateTime startDate, DateTime endDate, out int year, out int month) {
            if (startDate == DateTime.MinValue) { 
                throw new Exception("cant diff date"); 
            } else {
                year = endDate.Year - startDate.Year;
                month = endDate.Month - startDate.Month;
                int diffday = endDate.Day - startDate.Day;
                if (diffday < 0) {
                    month -= 1;
                }
                if (month < 0) {
                    year -= 1;
                    month += 12;
                }
            }
        }
        }

    }



    public enum DataFormStatus {
        Idle, Insert, Update, Delete
    }

