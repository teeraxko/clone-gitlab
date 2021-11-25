using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared ;
using System.IO;
using System.Configuration;

using ictus.PIS.PI.Entity;
using Entity.VehicleEntities;

using Facade.PiFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;
namespace Presentation.VehicleGUI
{
	public class frmListofRepairingHistorybyVehicle : ChildFormBase,IMDIChildForm
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
		private System.Windows.Forms.TextBox txtPlatePrefix;
		private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdShow;
		private System.Windows.Forms.GroupBox gpbReport;
		
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.gpbReport = new System.Windows.Forms.GroupBox();
			this.txtPlatePrefix = new System.Windows.Forms.TextBox();
			this.fpiPlateRunningNo = new FarPoint.Win.Input.FpInteger();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdShow = new System.Windows.Forms.Button();
			this.gpbReport.SuspendLayout();
			this.SuspendLayout();
			// 
			// crvReport
			// 
			this.crvReport.ActiveViewIndex = -1;
			this.crvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvReport.DisplayGroupTree = false;
			this.crvReport.Location = new System.Drawing.Point(12, 80);
			this.crvReport.Name = "crvReport";
			this.crvReport.ReportSource = null;
			this.crvReport.ShowCloseButton = false;
			this.crvReport.ShowGroupTreeButton = false;
			this.crvReport.Size = new System.Drawing.Size(768, 240);
			this.crvReport.TabIndex = 0;
			// 
			// gpbReport
			// 
			this.gpbReport.Controls.Add(this.txtPlatePrefix);
			this.gpbReport.Controls.Add(this.fpiPlateRunningNo);
			this.gpbReport.Controls.Add(this.label2);
			this.gpbReport.Controls.Add(this.label1);
			this.gpbReport.Controls.Add(this.cmdShow);
			this.gpbReport.Location = new System.Drawing.Point(234, 8);
			this.gpbReport.Name = "gpbReport";
			this.gpbReport.Size = new System.Drawing.Size(324, 64);
			this.gpbReport.TabIndex = 21;
			this.gpbReport.TabStop = false;
			// 
			// txtPlatePrefix
			// 
			this.txtPlatePrefix.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtPlatePrefix.Location = new System.Drawing.Point(100, 24);
			this.txtPlatePrefix.MaxLength = 3;
			this.txtPlatePrefix.Name = "txtPlatePrefix";
			this.txtPlatePrefix.Size = new System.Drawing.Size(36, 20);
			this.txtPlatePrefix.TabIndex = 114;
			this.txtPlatePrefix.Text = "";
			this.txtPlatePrefix.TextChanged += new System.EventHandler(this.txtPlatePrefix_TextChanged);
			// 
			// fpiPlateRunningNo
			// 
			this.fpiPlateRunningNo.AllowClipboardKeys = true;
			this.fpiPlateRunningNo.AllowNull = true;
			this.fpiPlateRunningNo.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.fpiPlateRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiPlateRunningNo.Location = new System.Drawing.Point(156, 24);
			this.fpiPlateRunningNo.MaxValue = 9999;
			this.fpiPlateRunningNo.MinValue = 0;
			this.fpiPlateRunningNo.Name = "fpiPlateRunningNo";
			this.fpiPlateRunningNo.NullColor = System.Drawing.Color.Transparent;
			this.fpiPlateRunningNo.Size = new System.Drawing.Size(48, 20);
			this.fpiPlateRunningNo.TabIndex = 115;
			this.fpiPlateRunningNo.Text = "";
			this.fpiPlateRunningNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpiPlateRunningNo_KeyDown);
			this.fpiPlateRunningNo.DoubleClick += new System.EventHandler(this.fpiPlateRunningNo_DoubleClick);
			this.fpiPlateRunningNo.TextChanged += new System.EventHandler(this.fpiPlateRunningNo_TextChanged);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label2.Location = new System.Drawing.Point(140, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(8, 16);
			this.label2.TabIndex = 116;
			this.label2.Text = "-";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label1.Location = new System.Drawing.Point(28, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 113;
			this.label1.Text = "ทะเบียนรถ";
			// 
			// cmdShow
			// 
			this.cmdShow.Location = new System.Drawing.Point(224, 24);
			this.cmdShow.Name = "cmdShow";
			this.cmdShow.TabIndex = 10;
			this.cmdShow.Text = "ดูข้อมูล";
			this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
			// 
			// frmListofRepairingHistorybyVehicle
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 326);
			this.Controls.Add(this.gpbReport);
			this.Controls.Add(this.crvReport);
			this.Name = "frmListofRepairingHistorybyVehicle";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofRepairingHistorybyVehicle_Load);
			this.gpbReport.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		#region - private -
		private frmMain mdiParent;
		private bool isSetText = true;
		private Vehicle objVehicle;
		private ListofRepairingHistorybyVehicleFacade facadeListofRepairing;
		#endregion

//		============================== Constructor ==============================
		public frmListofRepairingHistorybyVehicle()
		{
			InitializeComponent();
			facadeListofRepairing = new ListofRepairingHistorybyVehicleFacade();
			this.Text = "รายงานประวัติการซ่อมทั้งหมดของรถแต่ละคัน ";
		}

//		============================== Private Method ==============================
		private void ReportDatabaseLogon()
		{
			try
			{
				ReportDocument rdPrint = new ReportDocument();
				string Plate = txtPlatePrefix.Text + '-' + fpiPlateRunningNo.Text;
				rdPrint.Load(@ApplicationProfile.REPORT_PATH + "rptRepairingHistorybyVehicle.rpt");

				DataSourceConnections dataSourceConnections = rdPrint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdPrint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + (facadeListofRepairing.GetCompanyInfo()).AFullName.Thai + "'";
				rdPrint.DataDefinition.FormulaFields["Plate"].Text = "'" + Plate + "'";
				crvReport.ReportSource = rdPrint;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		private void formVehicleList()
		{
            FrmVehicleList dialogVehicleList = new FrmVehicleList();
			dialogVehicleList.ConditionPlatePrefix = txtPlatePrefix.Text;		
			dialogVehicleList.ConditionPlateRunningNo = fpiPlateRunningNo.Text;
			dialogVehicleList.ShowDialog();			

			if(dialogVehicleList.Selected)
			{
				setVehicle(dialogVehicleList.SelectedVehicle);
				cmdShow.Enabled = true;
			}
		}

		private void setVehicle(Vehicle value)
		{
			isSetText = false;
			objVehicle = value;
			txtPlatePrefix.Text = value.PlatePrefix;
			fpiPlateRunningNo.Value = value.PlateRunningNo;
			isSetText = true;
		}

		private void setForm()
		{
			if(validateVehiclePlate())
			{
				Vehicle vehicle = facadeListofRepairing.GetVehicle(txtPlatePrefix.Text, fpiPlateRunningNo.Text);

				if(vehicle != null)
				{
					objVehicle = vehicle;
					cmdShow.Enabled = true;
				}
				else
				{
					Message(MessageList.Error.E0004, "เลขทะเบียนรถ");
					setSelected(txtPlatePrefix);
					clearForm();					
				}
				vehicle = null;
			}
		}

		private void clearForm()
		{
			txtPlatePrefix.Text = "";
			fpiPlateRunningNo.Text = "";
			txtPlatePrefix.Enabled = true;
			fpiPlateRunningNo.Enabled = true;
			cmdShow.Enabled = false;
		}

		#region - Validate Checking - 
		private bool validateVehiclePlate()
		{
			if(txtPlatePrefix.Text == "")
			{
				Message(MessageList.Error.E0002, "ทะเบียนรถ");
				txtPlatePrefix.Focus();
				return false;
			}
			else if(fpiPlateRunningNo.Text == "")
			{
				Message(MessageList.Error.E0002, "ทะเบียนรถ");
				fpiPlateRunningNo.Focus();
				return false;
			}
			else
			{return true;}
		}
		#endregion - Validate Checking - 

//		==============================Base Event ==============================
		public void InitForm()
		{
			clearForm();
			crvReport.Hide();
			MainMenuNewStatus = false;
			mdiParent.EnableNewCommand(false);
		}

		public void RefreshForm()
		{
			crvReport.Show();
			txtPlatePrefix.Enabled = false;
			fpiPlateRunningNo.Enabled = false;
			MainMenuNewStatus = true;
			mdiParent.EnableNewCommand(true);
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			MainMenuNewStatus = false;
			mdiParent.EnableNewCommand(false);
			this.Hide();
		}

//		============================== Event ==============================
		private void frmListofRepairingHistorybyVehicle_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void cmdShow_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			RefreshForm();
			crvReport.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void fpiPlateRunningNo_DoubleClick(object sender, System.EventArgs e)
		{
			formVehicleList();
		}

		private void fpiPlateRunningNo_TextChanged(object sender, System.EventArgs e)
		{
			if(isSetText)
			{
				if(fpiPlateRunningNo.Text.Length == 4)
				{
					setForm();
				}
			}
		}

		private void fpiPlateRunningNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == System.Windows.Forms.Keys.Enter)
			{
				setForm();
			}
		}

		private void txtPlatePrefix_TextChanged(object sender, System.EventArgs e)
		{
            if (txtPlatePrefix.Text.Length == txtPlatePrefix.MaxLength)
			{
				fpiPlateRunningNo.Focus();
			}
		}
	}
}
