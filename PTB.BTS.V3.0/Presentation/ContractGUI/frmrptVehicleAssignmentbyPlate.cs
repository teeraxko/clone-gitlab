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

using Entity.VehicleEntities;

using Facade.ContractFacade;

using Presentation.CommonGUI;
using Presentation.VehicleGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

namespace Presentation.ContractGUI
{
	public class frmrptVehicleAssignmentbyPlate : ChildFormBase,IMDIChildForm
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
		private System.Windows.Forms.TextBox txtPlatePrefix;
		private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvContract;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtPlatePrefix = new System.Windows.Forms.TextBox();
			this.fpiPlateRunningNo = new FarPoint.Win.Input.FpInteger();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdShow = new System.Windows.Forms.Button();
			this.crvContract = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtPlatePrefix);
			this.groupBox1.Controls.Add(this.fpiPlateRunningNo);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cmdShow);
			this.groupBox1.Location = new System.Drawing.Point(306, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(324, 64);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
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
			// crvContract
			// 
			this.crvContract.ActiveViewIndex = -1;
			this.crvContract.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvContract.DisplayGroupTree = false;
			this.crvContract.Location = new System.Drawing.Point(13, 87);
			this.crvContract.Name = "crvContract";
			this.crvContract.ReportSource = null;
			this.crvContract.ShowCloseButton = false;
			this.crvContract.ShowGroupTreeButton = false;
			this.crvContract.Size = new System.Drawing.Size(911, 232);
			this.crvContract.TabIndex = 19;
			// 
			// frmrptVehicleAssignmentbyPlate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(936, 326);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.crvContract);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmrptVehicleAssignmentbyPlate";
			this.Text = "frmrptVehicleAssignmentbyPlate";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmrptVehicleAssignmentbyPlate_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isSetText = true;
		private frmMain mdiParent;
		private Vehicle objVehicle;
		private RptVehicleAssignmentbyPlateFacade facadeRptVehicleAssignment;
		#endregion

//		============================== Constructor ==============================
		public frmrptVehicleAssignmentbyPlate() : base()
		{
			InitializeComponent();
			this.Text = "รายงานประวัติการจ่ายงานทั้งหมดของรถยนต์";
			facadeRptVehicleAssignment = new RptVehicleAssignmentbyPlateFacade();
		}

		//		============================== Private Method ==============================
		private void ReportDatabaseLogon()
		{
			try
			{
				ReportDocument rdprint1 = new ReportDocument();

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleAssignmentbyPlate.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + (facadeRptVehicleAssignment.GetCompanyInfo()).AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["Vehicle_No"].Text = objVehicle.VehicleNo.ToString();

				crvContract.ReportSource = rdprint1;
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
				Vehicle vehicle = facadeRptVehicleAssignment.GetVehicle(txtPlatePrefix.Text, fpiPlateRunningNo.Text);

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
			cmdShow.Enabled = false;
			txtPlatePrefix.Enabled = true;
			fpiPlateRunningNo.Enabled = true;
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
		
//		============================== Base Event ==============================
		public void InitForm()
		{
			clearForm();
			crvContract.Hide();
			MainMenuNewStatus = false;
			mdiParent.EnableNewCommand(false);
		}

		public void RefreshForm()
		{
			crvContract.Show();
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
		private void frmrptVehicleAssignmentbyPlate_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void txtPlatePrefix_TextChanged(object sender, System.EventArgs e)
		{
            if (txtPlatePrefix.Text.Length == txtPlatePrefix.MaxLength)
			{
				fpiPlateRunningNo.Focus();
			}
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

		private void cmdShow_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			RefreshForm();
			crvContract.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void fpiPlateRunningNo_DoubleClick(object sender, System.EventArgs e)
		{
			formVehicleList();
		}
	}
}
