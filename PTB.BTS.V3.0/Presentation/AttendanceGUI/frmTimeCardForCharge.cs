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
using ictus.Common.Entity;

using Facade.ContractFacade;
using Facade.PiFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

namespace Presentation.AttendanceGUI
{
	public class frmTimeCardForCharge : ChildFormBase,IMDIChildForm
	{
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
		private System.Windows.Forms.Label label;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboCustomerDept;
		private System.Windows.Forms.ComboBox comboCustomer;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtEmpNo;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboCustomerDept = new System.Windows.Forms.ComboBox();
            this.comboCustomer = new System.Windows.Forms.ComboBox();
            this.cmdShow = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label = new System.Windows.Forms.Label();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEmpNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboCustomerDept);
            this.groupBox1.Controls.Add(this.comboCustomer);
            this.groupBox1.Controls.Add(this.cmdShow);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 64);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(544, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 109;
            this.label3.Text = "รหัสพนักงาน";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(624, 24);
            this.txtEmpNo.MaxLength = 5;
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(56, 20);
            this.txtEmpNo.TabIndex = 108;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(360, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 21);
            this.label2.TabIndex = 107;
            this.label2.Text = "แผนก";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "บริษัทลูกค้า";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboCustomerDept
            // 
            this.comboCustomerDept.DisplayMember = "name";
            this.comboCustomerDept.Location = new System.Drawing.Point(408, 24);
            this.comboCustomerDept.Name = "comboCustomerDept";
            this.comboCustomerDept.Size = new System.Drawing.Size(120, 21);
            this.comboCustomerDept.TabIndex = 105;
            this.comboCustomerDept.ValueMember = "id";
            // 
            // comboCustomer
            // 
            this.comboCustomer.DisplayMember = "name";
            this.comboCustomer.Location = new System.Drawing.Point(224, 24);
            this.comboCustomer.Name = "comboCustomer";
            this.comboCustomer.Size = new System.Drawing.Size(120, 21);
            this.comboCustomer.TabIndex = 104;
            this.comboCustomer.ValueMember = "id";
            this.comboCustomer.SelectedIndexChanged += new System.EventHandler(this.comboCustomer_SelectedIndexChanged);
            // 
            // cmdShow
            // 
            this.cmdShow.Location = new System.Drawing.Point(696, 24);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(75, 23);
            this.cmdShow.TabIndex = 7;
            this.cmdShow.Text = "ดูข้อมูล";
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(72, 24);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(72, 20);
            this.dtpDate.TabIndex = 6;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(24, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(28, 13);
            this.label.TabIndex = 5;
            this.label.Text = "วันที่";
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
            this.crvReport.Size = new System.Drawing.Size(992, 640);
            this.crvReport.TabIndex = 17;
            // 
            // frmTimeCardForCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.crvReport);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTimeCardForCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTimeCardForCharge_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTimeCardForCharge_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		private TimeCardForChargeFacade facadeTimeCardForChargeFacade;
		private CustomerFacade facadeCustomer;
		private CustomerDeptFacade facadeCustomerDept;

		#endregion
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
		//		============================== Constructor ==============================
		public frmTimeCardForCharge()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			facadeTimeCardForChargeFacade = new TimeCardForChargeFacade();
			this.Text = "TimeCardForCharge";
			facadeCustomer = new CustomerFacade();
			facadeCustomerDept = new CustomerDeptFacade();
			facadeCustomer.DisplayCustomer();


		}
		//		============================== Property ==============================
		public CompanyInfo getCompany()
		{
			objCompany = new CompanyInfo("12");
			if(facadeCompany.FillCompany(ref objCompany))
			{
				return objCompany;
			}
			else
			{
				return null;
			}
		}
		//		============================== Private Method ==============================
		private void ReportDatabaseLogon()
		{
			try
			{
				if(facadeTimeCardForChargeFacade.GenerateTimeCardCharge(dtpDate.Value))
				{
					objCompany = getCompany();
					ReportDocument rdprint1 = new ReportDocument();
					string StartDate2 = Convert.ToString(dtpDate.Value.Month);
					string StartDate3 = Convert.ToString(dtpDate.Value.Year);

					rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptTimeCardForCharge.rpt");
					DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
					IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
					iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

					rdprint1.DataDefinition.RecordSelectionFormula = this.ReportSelecttionFormular();
					rdprint1.DataDefinition.FormulaFields["Comp_Name_Thai"].Text = "'" + objCompany.AFullName.Thai + "'";
					rdprint1.DataDefinition.FormulaFields["Comp_Name_Eng"].Text = "'" + objCompany.AFullName.English + "'";
					rdprint1.DataDefinition.FormulaFields["Month"].Text = StartDate2;
					rdprint1.DataDefinition.FormulaFields["Year"].Text = StartDate3;


					crvReport.ReportSource = rdprint1;
				}
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
			string formular = @"year({Tr_Time_Card_Charge_Detail.For_Date})= ToNumber({@Year}) and month({Tr_Time_Card_Charge_Detail.For_Date}) = ToNumber({@Month}) ";

			//select specific customer
			if (comboCustomer.SelectedIndex > 0)
			{
				string customerName = ((ComboItem)comboCustomer.SelectedItem).name;
				string specificCustomer = " AND {Tr_Time_Card_Charge_Head.Customer_Short_Name} = '" + customerName + @"'";
				formular += specificCustomer;
			}

			//select specific customer department
			if (comboCustomerDept.SelectedIndex > 0)
			{
				string customerDeptName = ((ComboItem)comboCustomerDept.SelectedItem).name;
				string specificDeptCustomer = @" AND {Tr_Time_Card_Charge_Head.Customer_Dept_Short_Name} = '" + customerDeptName+ @"'";
				formular += specificDeptCustomer;
			}

			//select specific employee
			if (txtEmpNo.Text.Trim().Length >0)
			{
				string specificEmployee = string.Empty;
				specificEmployee = @" AND {Tr_Time_Card_Charge_Head.Main_Employee_No} = '" + txtEmpNo.Text.Trim() + @"'";
				formular += specificEmployee;
			}
			return formular;
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
			txtEmpNo.Text  = "";
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

		private void frmTimeCardForCharge_Load(object sender, System.EventArgs e)
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
			txtEmpNo.Text = "";
			RefeshComboCustomerDept();
		}

        private void frmTimeCardForCharge_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvReport);
        }
	}
}
