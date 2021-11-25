using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using SystemFramework.AppConfig;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using Facade.PiFacade;
using Presentation.CommonGUI;

namespace Presentation.AttendanceGUI
{
	/// <summary>
	/// Summary description for frmListOfFamilyCarDriverReward.
	/// </summary>
	public class frmListOfFamilyCarDriverReward :  ChildFormBase,IMDIChildForm
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Splitter splitter1;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint;
		private System.Windows.Forms.Button btnShow;
		private System.ComponentModel.Container components = null;
		private frmMain mdiParent;
		private System.Windows.Forms.DateTimePicker dtpCriteria;

		private CompanyFacade facadeCompany;

		public frmListOfFamilyCarDriverReward()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "APPLICATION FOR ON ABSENT AWARD OF FAMILY CAR DRIVER";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpCriteria = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.crvPrint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpCriteria);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Location = new System.Drawing.Point(9, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpCriteria
            // 
            this.dtpCriteria.CustomFormat = "MM/yyyy";
            this.dtpCriteria.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCriteria.Location = new System.Drawing.Point(288, 20);
            this.dtpCriteria.Name = "dtpCriteria";
            this.dtpCriteria.Size = new System.Drawing.Size(76, 20);
            this.dtpCriteria.TabIndex = 2;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(379, 20);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 20);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "ดูข้อมูล";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(760, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // crvPrint
            // 
            this.crvPrint.ActiveViewIndex = -1;
            this.crvPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrint.DisplayGroupTree = false;
            this.crvPrint.Location = new System.Drawing.Point(11, 64);
            this.crvPrint.Name = "crvPrint";
            this.crvPrint.ShowCloseButton = false;
            this.crvPrint.ShowGroupTreeButton = false;
            this.crvPrint.ShowRefreshButton = false;
            this.crvPrint.Size = new System.Drawing.Size(738, 416);
            this.crvPrint.TabIndex = 0;
            // 
            // frmListOfFamilyCarDriverReward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(760, 490);
            this.Controls.Add(this.crvPrint);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmListOfFamilyCarDriverReward";
            this.Text = "รายงานเบี้ยขยัน";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListForNoAccidentReward_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListOfFamilyCarDriverReward_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public void InitForm()
		{
			dtpCriteria.Value = DateTime.Now.Date;
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
		
		private Company getCompany()
		{
			Company objCompany = new Company("12");
			if(facadeCompany.FillCompany(ref objCompany))
			{
				return objCompany;
			}
			else
			{
				return null;
			}
		}

		private void ReportDatabaseLogon()
		{
			try
			{
				crvPrint.Show();
				ReportDocument rdprint1 = new ReportDocument();
				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptListOfNoAbsentReward.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);
				
				
				rdprint1.DataDefinition.ParameterFields["@I_YEAR"].ApplyCurrentValues(CrytalParameterValue(dtpCriteria.Value.Year));
				rdprint1.DataDefinition.ParameterFields["@I_MONTH"].ApplyCurrentValues(CrytalParameterValue(dtpCriteria.Value.Month));
				crvPrint.ReportSource = rdprint1;
			}			
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		private ParameterValues CrytalParameterValue(object paraValue)
		{
			ParameterValues paramValues = new ParameterValues();
			ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue ();
			paramDiscreteValue.Value = paraValue;
			paramValues.Add (paramDiscreteValue);
			return paramValues;
		}

		private void frmListForNoAccidentReward_Load(object sender, System.EventArgs e)
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
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

        private void frmListOfFamilyCarDriverReward_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvPrint);
        }

	}
}
