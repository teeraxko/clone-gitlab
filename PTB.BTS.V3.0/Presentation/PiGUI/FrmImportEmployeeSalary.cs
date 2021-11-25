using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using System.Data.OleDb;
using SystemFramework.AppMessage;
using SystemFramework.AppException;
using System.Data.SqlClient;
using ictus.PIS.PI.Entity;
using System.Collections;
using Facade.PiFacade;

namespace Presentation.PiGUI
{
    public partial class FrmImportEmployeeSalary : ChildFormBase, IMDIChildForm
    {
        #region Private Variable
        private const string COL_EMPNO = "EmployeeNo";
        private const string COL_SALARY = "NewSalary";
        private const string SHEET_SALARY = "EmployeeSalary";
        #endregion

        #region Constructor
        public FrmImportEmployeeSalary()
            : base()
        {
            InitializeComponent();
        } 
        #endregion

        #region Private Method
        private void ImportFile()
        {
            try
            {
                if (ValidateFile())
                {
                    Cursor = Cursors.WaitCursor;

                    DataTable salaryTable = GetDataFromXLS(txtFile.Text.Trim());
                    Hashtable hashTable = GetData(salaryTable);

                    if (hashTable != null && hashTable.Count > 0)
                    {
                        using (EmployeeSalaryFacade facade = new EmployeeSalaryFacade())
                        {
                            if (facade.ImportEmployeeSalary(hashTable))
                            {
                                Message(MessageList.Information.I0001);
                            }
                            else
                            {
                                Message(MessageList.Error.E0014, "ส่งข้อมูลเงินเดือนเข้าสู่ระบบได้");                            
                            }
                        }
                    }

                    Cursor = Cursors.Default;
                }
            }
            catch (Exception sqlex)
            {
                MessageForm(sqlex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private System.Data.DataTable GetDataFromXLS(string strFilePath)
        {
            try
            {
                string strConnectionString = string.Empty;
                strConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source=" + strFilePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1;\"";

                OleDbConnection cnCSV = new OleDbConnection(strConnectionString);
                cnCSV.Open();

                OleDbCommand cmdSelect = new OleDbCommand(string.Format("SELECT * FROM [{0}$]", SHEET_SALARY), cnCSV);
                OleDbDataAdapter daCSV = new OleDbDataAdapter();
                daCSV.SelectCommand = cmdSelect;

                System.Data.DataTable dtCSV = new System.Data.DataTable();

                daCSV.Fill(dtCSV);
                cnCSV.Close();
                daCSV = null;

                return dtCSV;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            { }
        }

        private bool ValidateFile()
        {
            if (txtFile.Text.Trim().Length <= 0)
            {
                Message(MessageList.Error.E0002, "File Name!");
                txtFile.Focus();
                return false;
            }

            if (!System.IO.File.Exists(txtFile.Text.Trim()))
            {
                Message(MessageList.Error.E0004, "ไฟล์ที่เลือก");
                txtFile.Focus();
                return false;
            }

            return true;
        }

        private void ShowMessage(string description)
        {
            MessageBox.Show(description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private Hashtable GetData(DataTable salaryTable)
        {
            EmployeeList employeeList = null;
            Employee employee = null;
            Hashtable hash = new Hashtable();
            int rowCount = 1;

            string message = string.Concat("Error loading row No. {0} column Name. {1} !\nCorrect the data in '", txtFile.Text.Trim(), "' and re-import again. \nDescription : {2}");

            using (EmployeeSalaryFacade facade = new EmployeeSalaryFacade())
            {
                employeeList = facade.GetAllEmployeeList();

                if (employeeList == null)
                {
                    return null;
                }
            }

            foreach (DataRow row in salaryTable.Rows)
            {
                rowCount++;

                if (row.IsNull(COL_EMPNO))
                {
                    ShowMessage(string.Format(message, rowCount.ToString(), COL_EMPNO, "Please input Employee No. !"));
                    return null;
                }

                if (row.IsNull(COL_SALARY))
                {
                    ShowMessage(string.Format(message, rowCount.ToString(), COL_SALARY, "Please input New Salary !"));
                    return null;
                }
                else if (decimal.Parse(row[COL_SALARY].ToString().Trim()) < 0 || decimal.Parse(row[COL_SALARY].ToString().Trim()) > 9999999.99m)
                {
                    ShowMessage(string.Format(message, rowCount.ToString(), COL_SALARY, "New Salary must be between 0 to 9999999.99 !"));
                    return null;
                }

                employee = new Employee(row[COL_EMPNO].ToString().Trim(), employeeList.Company);

                if (!employeeList.Contain(employee))
                {
                    ShowMessage(string.Format(message, rowCount.ToString(), COL_EMPNO, "Employee does not exist !"));
                    return null;
                }

                hash.Add(row[COL_EMPNO].ToString().Trim(), decimal.Parse(row[COL_SALARY].ToString().Trim()));
            }

            return hash;
        }
        #endregion

        #region IMDIChildFormGUI Members

        public void InitForm()
        {
            txtFile.Clear();
        }

        public void RefreshForm()
        {
            throw new NotImplementedException();
        }

        public void PrintForm()
        {
            throw new NotImplementedException();
        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        #region Form Event
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            diaOpenFile.ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportFile();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmImportEmployeeSalary_Load(object sender, EventArgs e)
        {
            InitForm();
            this.WindowState = FormWindowState.Normal;
        }

        private void diaOpenFile_FileOk(object sender, CancelEventArgs e)
        {
            txtFile.Text = diaOpenFile.FileName;
        }
        #endregion
    }
}
