using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.PiGUI
{
	public class frmrptPersonnalData : ChildFormBase,IMDIChildForm
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
		protected System.Windows.Forms.TextBox txtEmployeeNo;
		protected System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnShow;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint1;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.txtEmployeeNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.crvPrint1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmployeeNo
            // 
            this.txtEmployeeNo.AllowDrop = true;
            this.txtEmployeeNo.Location = new System.Drawing.Point(112, 24);
            this.txtEmployeeNo.MaxLength = 5;
            this.txtEmployeeNo.Name = "txtEmployeeNo";
            this.txtEmployeeNo.Size = new System.Drawing.Size(64, 20);
            this.txtEmployeeNo.TabIndex = 3;
            this.txtEmployeeNo.DoubleClick += new System.EventHandler(this.txtEmployeeNo_DoubleClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "รหัสพนักงาน";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.txtEmployeeNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 64);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(200, 24);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "ดูข้อมูล";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // crvPrint1
            // 
            this.crvPrint1.ActiveViewIndex = -1;
            this.crvPrint1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvPrint1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrint1.DisplayGroupTree = false;
            this.crvPrint1.Location = new System.Drawing.Point(16, 88);
            this.crvPrint1.Name = "crvPrint1";
            this.crvPrint1.ShowCloseButton = false;
            this.crvPrint1.ShowGroupTreeButton = false;
            this.crvPrint1.Size = new System.Drawing.Size(656, 408);
            this.crvPrint1.TabIndex = 5;
            // 
            // frmrptPersonnalData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(688, 502);
            this.Controls.Add(this.crvPrint1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmrptPersonnalData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmrptPersonnalData_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmrptPersonnalData_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		#endregion
		
//		============================== Constructor ==============================

		public frmrptPersonnalData()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานข้อมูลพนักงานรายบุคคล";
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
				objCompany = getCompany();
				ReportDocument rdprint1 = new ReportDocument();

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptPersonalData.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				if(txtEmployeeNo.Text == "")
				{
					rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				}
				else
				{
					rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
					rdprint1.DataDefinition.RecordSelectionFormula = @"{VEmployee.Employee_No} = {@Emp_No}";
					rdprint1.DataDefinition.FormulaFields["Emp_No"].Text = "'" + txtEmployeeNo.Text + "'";
				}
				crvPrint1.ReportSource = rdprint1;

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		==============================Base Event ==============================

		public void InitForm()
		{
			txtEmployeeNo.Text = "";
			crvPrint1.Hide();
			mdiParent.EnableExitCommand(true);		
		}

		public void RefreshForm()
		{
			crvPrint1.Show();
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

		private void txtEmployeeNo_DoubleClick(object sender, System.EventArgs e)
		{
			frmEmplist dialogEmplist = new frmEmplist();
			dialogEmplist.ConditionEmployeeNo = txtEmployeeNo.Text;

			dialogEmplist.ShowDialog();			
			if(dialogEmplist.Selected)
			{
				txtEmployeeNo.Text = dialogEmplist.SelectedEmployee.EmployeeNo;
			}
		}

		private void frmrptPersonnalData_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void btnShow_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			RefreshForm();
			mdiParent.EnableExitCommand(true);
			crvPrint1.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		
		}

        private void frmrptPersonnalData_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvPrint1);
        }
	}
}
