using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared ;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using Entity.ContractEntities;
using ictus.PIS.PI.Entity;
using Facade.ContractFacade;
using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

namespace Presentation.AttendanceGUI
{
	public class frmListofTimeRecordOfDriver : ChildFormBase,IMDIChildForm
	{
		private class ComboItem
		{

			private string _id;
			public string id
			{
				get{return _id;}
			}
			private string _name;
			public string name
			{
				get{return _name;}
			}

			public ComboItem(string id, string name)
			{
				_id = id;
				_name = name;
			}
		}


		private CustomerFacade facadeCustomer;
		private CustomerDeptFacade facadeCustomerDept;

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button cmdShow;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.GroupBox gbCustomer;
		private System.Windows.Forms.ComboBox comboCustomer;
		private System.Windows.Forms.ComboBox comboCustomerDept;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox gbEmployee;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtEmpNoFrom;
		private System.Windows.Forms.TextBox txtEmpNoTo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbEmployee = new System.Windows.Forms.GroupBox();
            this.txtEmpNoTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmpNoFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboCustomerDept = new System.Windows.Forms.ComboBox();
            this.comboCustomer = new System.Windows.Forms.ComboBox();
            this.cmdShow = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1.SuspendLayout();
            this.gbEmployee.SuspendLayout();
            this.gbCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.DisplayGroupTree = false;
            this.crvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReport.Location = new System.Drawing.Point(0, 111);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowCloseButton = false;
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.Size = new System.Drawing.Size(1028, 635);
            this.crvReport.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.gbEmployee);
            this.groupBox1.Controls.Add(this.gbCustomer);
            this.groupBox1.Controls.Add(this.cmdShow);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 108);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 21);
            this.label5.TabIndex = 102;
            this.label5.Text = "เดือน/ปี";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbEmployee
            // 
            this.gbEmployee.Controls.Add(this.txtEmpNoTo);
            this.gbEmployee.Controls.Add(this.label4);
            this.gbEmployee.Controls.Add(this.txtEmpNoFrom);
            this.gbEmployee.Controls.Add(this.label3);
            this.gbEmployee.Location = new System.Drawing.Point(392, 44);
            this.gbEmployee.Name = "gbEmployee";
            this.gbEmployee.Size = new System.Drawing.Size(100, 56);
            this.gbEmployee.TabIndex = 101;
            this.gbEmployee.TabStop = false;
            this.gbEmployee.Text = "รหัสพนักงาน";
            // 
            // txtEmpNoTo
            // 
            this.txtEmpNoTo.Location = new System.Drawing.Point(124, 20);
            this.txtEmpNoTo.MaxLength = 5;
            this.txtEmpNoTo.Name = "txtEmpNoTo";
            this.txtEmpNoTo.Size = new System.Drawing.Size(56, 20);
            this.txtEmpNoTo.TabIndex = 1;
            this.txtEmpNoTo.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(100, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "ถึง";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // txtEmpNoFrom
            // 
            this.txtEmpNoFrom.Location = new System.Drawing.Point(12, 20);
            this.txtEmpNoFrom.MaxLength = 5;
            this.txtEmpNoFrom.Name = "txtEmpNoFrom";
            this.txtEmpNoFrom.Size = new System.Drawing.Size(56, 20);
            this.txtEmpNoFrom.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(184, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "จาก";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.label2);
            this.gbCustomer.Controls.Add(this.label1);
            this.gbCustomer.Controls.Add(this.comboCustomerDept);
            this.gbCustomer.Controls.Add(this.comboCustomer);
            this.gbCustomer.Location = new System.Drawing.Point(8, 44);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(376, 56);
            this.gbCustomer.TabIndex = 100;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "ลูกค้า";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(196, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "แผนก";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "บริษัท";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboCustomerDept
            // 
            this.comboCustomerDept.DisplayMember = "name";
            this.comboCustomerDept.Location = new System.Drawing.Point(248, 20);
            this.comboCustomerDept.Name = "comboCustomerDept";
            this.comboCustomerDept.Size = new System.Drawing.Size(120, 21);
            this.comboCustomerDept.TabIndex = 1;
            this.comboCustomerDept.ValueMember = "id";
            // 
            // comboCustomer
            // 
            this.comboCustomer.DisplayMember = "name";
            this.comboCustomer.Location = new System.Drawing.Point(56, 20);
            this.comboCustomer.Name = "comboCustomer";
            this.comboCustomer.Size = new System.Drawing.Size(120, 21);
            this.comboCustomer.TabIndex = 0;
            this.comboCustomer.ValueMember = "id";
            this.comboCustomer.SelectedIndexChanged += new System.EventHandler(this.comboCustomer_SelectedIndexChanged);
            // 
            // cmdShow
            // 
            this.cmdShow.Location = new System.Drawing.Point(144, 16);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(75, 20);
            this.cmdShow.TabIndex = 1;
            this.cmdShow.Text = "ดูข้อมูล";
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(60, 16);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(72, 20);
            this.dtpDate.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 108);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1028, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // frmListofTimeRecordOfDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.crvReport);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmListofTimeRecordOfDriver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListofTimeRecordOfDriver_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListofTimeRecordOfDriver_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.gbEmployee.ResumeLayout(false);
            this.gbEmployee.PerformLayout();
            this.gbCustomer.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private frmMain mdiParent;
//		============================== Constructor ==============================
		public frmListofTimeRecordOfDriver()
		{
			InitializeComponent();
			this.Text = "TimeRecordOfDriver";
			
			facadeCustomer = new CustomerFacade();
			facadeCustomerDept = new CustomerDeptFacade();
			facadeCustomer.DisplayCustomer();

		}




		//		============================== Private Method ==============================
		private void ReportDatabaseLogon()
		{
			try
			{
				ReportDocument rdprint1 = new ReportDocument();
				string StartDate2 = Convert.ToString(dtpDate.Value.Month);
				string StartDate3 = Convert.ToString(dtpDate.Value.Year);

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptTimeRecordOfDriver.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.RecordSelectionFormula = this.ReportSelecttionFormular();
				rdprint1.DataDefinition.FormulaFields["Month"].Text = StartDate2;
				rdprint1.DataDefinition.FormulaFields["Year"].Text = StartDate3;


				crvReport.ReportSource = rdprint1;
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		==============================Base Event ==============================

		public void InitForm()
		{
			if(DateTime.Today.Month == 1)
			{
				dtpDate.Value = new DateTime(DateTime.Today.AddYears(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);

			}
			else
			{
				dtpDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			}
			crvReport.Hide();
			mdiParent.EnableExitCommand(true);

			RefeshComboCustomer();
			txtEmpNoFrom.Text = string.Empty;
			txtEmpNoTo.Text = string.Empty;

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

		//		==============================Base Event ==============================


		private void frmListofTimeRecordOfDriver_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void cmdShow_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			RefreshForm();
			mdiParent.EnableExitCommand(true);
			crvReport.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void comboCustomer_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtEmpNoFrom.Text = string.Empty;
			RefeshComboCustomerDept();
		}

		private void RefeshComboCustomerDept()
		{
			string selectCustomerCode = ((ComboItem)comboCustomer.SelectedItem).id;
			facadeCustomerDept.DisplayCustomerDepartment(selectCustomerCode);
			comboCustomerDept.Items.Clear();
			comboCustomerDept.Items.Add(new ComboItem("-1","==ทั้งหมด=="));
			for(int i=0; i < facadeCustomerDept.ObjCustomerDepartmentList.Count; i++)
			{
				CustomerDepartment cus = facadeCustomerDept.ObjCustomerDepartmentList[i];
				comboCustomerDept.Items.Add(new ComboItem(cus.Code, cus.ShortName));
			}
			comboCustomerDept.SelectedIndex = 0;
 		}

		private void RefeshComboCustomer()
		{
			comboCustomer.Items.Clear();
			comboCustomer.Items.Add(new ComboItem("-1","==ทั้งหมด=="));
			for(int i=0; i < facadeCustomer.ObjCustomerList.Count; i++)
			{
				Customer cus = facadeCustomer.ObjCustomerList[i];
				comboCustomer.Items.Add(new ComboItem(cus.Code, cus.ShortName));
			}
			comboCustomer.SelectedIndex = 0;
		}

		private string ReportSelecttionFormular()
		{
			string formular = @"year({VTimeRecordForDriver.For_Date})= ToNumber({@Year}) and month({VTimeRecordForDriver.For_Date}) = ToNumber({@Month}) ";
			
			//select specific customer
			if (comboCustomer.SelectedIndex > 0)
			{
				string customerCode = ((ComboItem)comboCustomer.SelectedItem).id;
				string specificCustomer = " AND {Customer.Customer_Code} = '" + customerCode + @"'";
				formular += specificCustomer;
			}

			//select specific customer department
			if (comboCustomerDept.SelectedIndex > 0)
			{
				string customerDeptCode = ((ComboItem)comboCustomerDept.SelectedItem).id;
				string specificDeptCustomer = @" AND {VTimeRecordForDriver.Customer_Department_Code} = '" + customerDeptCode + @"'";
				formular += specificDeptCustomer;
			}

			//select specific employee
			if (txtEmpNoFrom.Text.Trim().Length >0)
			{
				string specificEmployee = string.Empty;
				if (txtEmpNoTo.Text.Trim().Length >0)
				{
					specificEmployee = @" AND {VTimeRecordForDriver.Employee_No} >= '" + txtEmpNoFrom.Text.Trim() + @"' AND {VTimeRecordForDriver.Employee_No} <= '" + txtEmpNoTo.Text.Trim() + @"'";  
				}
				else
				{
					specificEmployee = @" AND {VTimeRecordForDriver.Employee_No} = '" + txtEmpNoFrom.Text.Trim() + @"'";
				}
				formular += specificEmployee;
			}
			return formular;
		}

        private void frmListofTimeRecordOfDriver_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvReport);
        }
	}
}
