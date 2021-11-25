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

using ictus.PIS.PI.Entity;

using Facade.PiFacade;
using Facade.ContractFacade;

using Presentation.CommonGUI;
using Presentation.PiGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

namespace Presentation.ContractGUI
{
	public class frmListOfAccidentByEmpNo : ChildFormBase,IMDIChildForm
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
		private System.Windows.Forms.TextBox txtEmpNo;
		private System.Windows.Forms.TextBox txtEmpName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button cmdShow;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtEmpNo = new System.Windows.Forms.TextBox();
			this.txtEmpName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmdShow = new System.Windows.Forms.Button();
			this.crvPrint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmdShow);
			this.groupBox1.Controls.Add(this.txtEmpNo);
			this.groupBox1.Controls.Add(this.txtEmpName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(514, 56);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			// 
			// txtEmpNo
			// 
			this.txtEmpNo.Location = new System.Drawing.Point(64, 17);
			this.txtEmpNo.MaxLength = 5;
			this.txtEmpNo.Name = "txtEmpNo";
			this.txtEmpNo.Size = new System.Drawing.Size(56, 20);
			this.txtEmpNo.TabIndex = 12;
			this.txtEmpNo.Text = "";
			this.txtEmpNo.TextChanged += new System.EventHandler(this.txtEmpNo_TextChanged);
			this.txtEmpNo.DoubleClick += new System.EventHandler(this.txtEmpNo_DoubleClick);
			// 
			// txtEmpName
			// 
			this.txtEmpName.Enabled = false;
			this.txtEmpName.Location = new System.Drawing.Point(128, 17);
			this.txtEmpName.Name = "txtEmpName";
			this.txtEmpName.Size = new System.Drawing.Size(272, 20);
			this.txtEmpName.TabIndex = 13;
			this.txtEmpName.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 20);
			this.label4.TabIndex = 11;
			this.label4.Text = "พนักงาน";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmdShow
			// 
			this.cmdShow.Location = new System.Drawing.Point(408, 16);
			this.cmdShow.Name = "cmdShow";
			this.cmdShow.TabIndex = 14;
			this.cmdShow.Text = "ดูข้อมูล";
			this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
			// 
			// crvPrint
			// 
			this.crvPrint.ActiveViewIndex = -1;
			this.crvPrint.DisplayGroupTree = false;
			this.crvPrint.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crvPrint.Location = new System.Drawing.Point(0, 56);
			this.crvPrint.Name = "crvPrint";
			this.crvPrint.ReportSource = null;
			this.crvPrint.ShowCloseButton = false;
			this.crvPrint.ShowGroupTreeButton = false;
			this.crvPrint.Size = new System.Drawing.Size(514, 375);
			this.crvPrint.TabIndex = 19;
			this.crvPrint.Click += new System.EventHandler(this.cmdShow_Click);
			this.crvPrint.Load += new System.EventHandler(this.crvPrint_Load);
			// 
			// frmListOfAccientByEmpNo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(514, 431);
			this.Controls.Add(this.crvPrint);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmListOfAccientByEmpNo";
			this.Text = "frmrptAssignmentHistorybyDriver";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmrptAssignmentHistorybyDriver_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private frmMain mdiParent;
		private RptAssignmentHistorybyDriverFacade facadeRptAssignmentHistory;
		private frmEmplist formEmplist;
		#endregion

//		============================== Constructor ==============================
		public frmListOfAccidentByEmpNo()
		{
			InitializeComponent();
			this.Text = "รายงานประวัติอุบัติเหตุทั้งหมดของพนักงานแต่ละคน";
			facadeRptAssignmentHistory = new RptAssignmentHistorybyDriverFacade();
			formEmplist = new frmEmplist();
		}

//		============================== Private Method ==============================
		private void ReportDatabaseLogon()
		{
			try
			{
				ReportDocument rdprint1 = new ReportDocument();

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptAccidentByEmpNo.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + (facadeRptAssignmentHistory.GetCompanyInfo()).AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["EmpNo"].Text = "'" + txtEmpNo.Text.Trim() + "'";

				crvPrint.ReportSource = rdprint1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		private void callEmpList()
		{
			try
			{
				formEmplist.ShowDialog();
				if(formEmplist.Selected)
				{
					txtEmpNo.Text = formEmplist.SelectedEmployee.EmployeeNo;
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
			catch(Exception ex)
			{
				Message(ex);
			}
			finally
			{}
		}

		private void displayEmployee()
		{
			try
			{
				Employee employee = facadeRptAssignmentHistory.GetAllEmployee(txtEmpNo.Text.Trim());

				if (validateEmployee(employee))
				{
					txtEmpNo.Text = employee.EmployeeNo;
					txtEmpName.Text = employee.EmployeeName;
					cmdShow.Enabled = true;
				}				
				else
				{
					cmdShow.Enabled = false;
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(EmpNotFoundException ex)
			{
				NullException(ex);
				Message(MessageList.Error.E0004, "รหัสพนักงาน");
				setSelected(txtEmpNo);
				cmdShow.Enabled = false;
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}
			finally
			{}
		}

		private bool validateEmployee(Employee value)
		{
			if (!value.APosition.PositionCode.Equals("28"))
			{
				Message(MessageList.Error.E0002, "รหัสพนักงานที่เป็นคนขับรถ" );
				setSelected(txtEmpNo);
				return false;
			}
			return true;
		}

		private void NullException(Exception ex)
		{
			ex = null;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			txtEmpName.Text = "";
			txtEmpNo.Text = "";
			cmdShow.Enabled = false;
			crvPrint.Hide();
			mdiParent.EnableExitCommand(true);
		}

		public void RefreshForm()
		{
			crvPrint.Show();
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
		private void frmrptAssignmentHistorybyDriver_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void txtEmpNo_TextChanged(object sender, System.EventArgs e)
		{
			if(txtEmpNo.Text.Trim().Length == txtEmpNo.MaxLength)
			{
				displayEmployee();
			}
		}

		private void txtEmpNo_DoubleClick(object sender, System.EventArgs e)
		{
			callEmpList();
		}

		private void cmdShow_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			RefreshForm();
			crvPrint.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void crvPrint_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
