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
using ictus.Common.Entity;

using Entity.VehicleEntities;

using Facade.PiFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;


namespace Presentation.VehicleGUI
{
	/// <summary>
	/// Summary description for frmListofRepairingHistoryByPlateNo.
	/// </summary>
	public class frmListofRepairingHistoryByPlateNo :  ChildFormBase,IMDIChildForm
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Splitter splitter1;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint;
		private System.Windows.Forms.ComboBox cboSparePartName;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region - private -
		private CompanyFacade facadeCompany;
		private SparePartsFacade facadeSpareParts;
		private VehicleFacade facadeVehicle;
		private System.Windows.Forms.Button btnShow;
		private System.Windows.Forms.TextBox txtPlateOfNo;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox txtPlateOfPrefix;
		private System.Windows.Forms.Label label26;
		private frmMain mdiParent;
        private SpareParts cboItem;

		#endregion

		public frmListofRepairingHistoryByPlateNo()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			facadeSpareParts = new SparePartsFacade();
			facadeVehicle = new VehicleFacade();
			this.Text = "รายงานประวัติการซ่อมตามหมายเลขทะเบียน";

			try
			{						
				cboSparePartName.DataSource = facadeSpareParts.DataSourceSpareParts;
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
			{
			}
		}

        private CompanyInfo getCompany()
		{
            CompanyInfo objCompany = new CompanyInfo("12");
			if(facadeCompany.FillCompany(ref objCompany))
			{
				return objCompany;
			}
			else
			{
				return null;
			}
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
			this.txtPlateOfNo = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.txtPlateOfPrefix = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.btnShow = new System.Windows.Forms.Button();
			this.cboSparePartName = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.crvPrint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtPlateOfNo);
			this.groupBox1.Controls.Add(this.label25);
			this.groupBox1.Controls.Add(this.txtPlateOfPrefix);
			this.groupBox1.Controls.Add(this.label26);
			this.groupBox1.Controls.Add(this.btnShow);
			this.groupBox1.Controls.Add(this.cboSparePartName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1028, 72);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// txtPlateOfNo
			// 
			this.txtPlateOfNo.Location = new System.Drawing.Point(176, 12);
			this.txtPlateOfNo.MaxLength = 4;
			this.txtPlateOfNo.Name = "txtPlateOfNo";
			this.txtPlateOfNo.Size = new System.Drawing.Size(56, 20);
			this.txtPlateOfNo.TabIndex = 1;
			this.txtPlateOfNo.Text = "";
			this.txtPlateOfNo.TextChanged += new System.EventHandler(this.txtPlateOfNo_TextChanged);
			this.txtPlateOfNo.DoubleClick += new System.EventHandler(this.txtPlateOfNo_DoubleClick);
			this.txtPlateOfNo.Enter += new System.EventHandler(this.txt_Enter);
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label25.Location = new System.Drawing.Point(160, 12);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(8, 20);
			this.label25.TabIndex = 19;
			this.label25.Text = "-";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label25.Click += new System.EventHandler(this.label25_Click);
			// 
			// txtPlateOfPrefix
			// 
			this.txtPlateOfPrefix.Location = new System.Drawing.Point(112, 12);
			this.txtPlateOfPrefix.MaxLength = 3;
			this.txtPlateOfPrefix.Name = "txtPlateOfPrefix";
			this.txtPlateOfPrefix.Size = new System.Drawing.Size(40, 20);
			this.txtPlateOfPrefix.TabIndex = 0;
			this.txtPlateOfPrefix.Text = "";
			this.txtPlateOfPrefix.TextChanged += new System.EventHandler(this.txtPlateOfPrefix_TextChanged);
			this.txtPlateOfPrefix.Enter += new System.EventHandler(this.txt_Enter);
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(8, 12);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(80, 20);
			this.label26.TabIndex = 18;
			this.label26.Text = "เลขทะเบียนรถ";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label26.Click += new System.EventHandler(this.label26_Click);
			// 
			// btnShow
			// 
			this.btnShow.Location = new System.Drawing.Point(472, 36);
			this.btnShow.Name = "btnShow";
			this.btnShow.TabIndex = 3;
			this.btnShow.Text = "ดูข้อมูล";
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// cboSparePartName
			// 
			this.cboSparePartName.Location = new System.Drawing.Point(112, 36);
			this.cboSparePartName.Name = "cboSparePartName";
			this.cboSparePartName.Size = new System.Drawing.Size(312, 21);
			this.cboSparePartName.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "รายการอะไหล่";
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Enabled = false;
			this.splitter1.Location = new System.Drawing.Point(0, 72);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(1028, 3);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// crvPrint
			// 
			this.crvPrint.ActiveViewIndex = -1;
			this.crvPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvPrint.DisplayGroupTree = false;
			this.crvPrint.Location = new System.Drawing.Point(0, 88);
			this.crvPrint.Name = "crvPrint";
			this.crvPrint.ReportSource = null;
			this.crvPrint.ShowCloseButton = false;
			this.crvPrint.ShowGroupTreeButton = false;
			this.crvPrint.Size = new System.Drawing.Size(1028, 636);
			this.crvPrint.TabIndex = 4;
			// 
			// frmListofRepairingHistoryByPlateNo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1028, 746);
			this.Controls.Add(this.crvPrint);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmListofRepairingHistoryByPlateNo";
			this.Text = "frmListofRepairingHistoryByPlateNo";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofRepairingHistoryByPlateNo_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void InitForm()
		{
			cboSparePartName.SelectedIndex = -1;
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

		private void frmListofRepairingHistoryByPlateNo_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();

		}

		private void btnShow_Click(object sender, System.EventArgs e)
		{
			if(ValidatePlatNo())
			{
				if (HasThisVehicle())
				{
                    //if(ValidateSparePart())
                    //{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						ReportDatabaseLogon();
						RefreshForm();
						mdiParent.EnableExitCommand(true);
						crvPrint.RefreshReport();
						this.Cursor = System.Windows.Forms.Cursors.Default;
                    //}
                    //else
                    //    Message(MessageList.Error.E0002, "รายการอะไหล่" );
				}
				else
					Message(MessageList.Error.E0004, "เลขทะเบียนรถ");

			}
			else
				Message(MessageList.Error.E0002, "เลขทะเบียนรถ" );


		}

		private void ReportDatabaseLogon()
		{
			try
			{
				ReportDocument rdprint1 = new ReportDocument();
                cboItem = (SpareParts)cboSparePartName.SelectedItem;

				// get vehicleNo
				Vehicle objVehicle = new Vehicle();
				objVehicle.PlatePrefix = txtPlateOfPrefix.Text;
				objVehicle.PlateRunningNo = txtPlateOfNo.Text;
				facadeVehicle.DisplayVehicleGeneral(ref objVehicle); 

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptRepairingHistoryByPlateNo.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + this.getCompany().AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["aVehicleNo"].Text = objVehicle.VehicleNo.ToString();
                rdprint1.DataDefinition.RecordSelectionFormula = this.ReportSelecttionFormular();



				crvPrint.ReportSource = rdprint1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}
        private string ReportSelecttionFormular()
        {
            string formular = @"{Vehicle.Vehicle_No} = {@aVehicleNo} AND {Vehicle_Repairing_History.Tax_Invoice_No}<>''";

            //select specific customer
            if (cboSparePartName.Text != "")
            {
                string sparePartCode = cboItem.Code;
                string specificSparePast = " AND {Vehicle_Repairing_Detail.Spare_Parts_Code} = '" + sparePartCode + @"'";
                formular += specificSparePast;
            }


            return formular;
        }

		private void label25_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label26_Click(object sender, System.EventArgs e)
		{
		
		}

		private void txtPlateOfNo_TextChanged(object sender, System.EventArgs e)
		{
			if(txtPlateOfNo.Text.Length == 4)
			{
				if(ValidatePlatNo())
				{
					SendKeys.Send("{TAB}");
				}
				else
					Message(MessageList.Error.E0002, "เลขทะเบียนรถ" );
			}


		}

		private void txtPlateOfPrefix_TextChanged(object sender, System.EventArgs e)
		{
            if (txtPlateOfPrefix.Text.Length == txtPlateOfPrefix.MaxLength)
			{
				SendKeys.Send("{TAB}");
			}

		}

		private void txtPlateOfNo_DoubleClick(object sender, System.EventArgs e)
		{
            FrmVehicleList dialogVehicleList = new FrmVehicleList();
			dialogVehicleList.ConditionPlateRunningNo = txtPlateOfNo.Text;
			dialogVehicleList.ConditionPlatePrefix = txtPlateOfPrefix.Text;
			dialogVehicleList.ShowDialog();			
			if(dialogVehicleList.Selected)
			{
				txtPlateOfPrefix.Text = dialogVehicleList.SelectedVehicle.PlatePrefix;
				txtPlateOfNo.Text = dialogVehicleList.SelectedVehicle.PlateRunningNo;
			}

		}

		private bool ValidatePlatNo()
		{
			return !(txtPlateOfNo.Text.Trim().Length == 0 || txtPlateOfPrefix.Text.Trim().Length == 0);
		}

		private bool HasThisVehicle()
		{
			return VehicleFacade.GetVehicleByPlateNo(txtPlateOfPrefix.Text.Trim(),txtPlateOfNo.Text.Trim()) != null;

		}

		private bool ValidateSparePart()
		{
			return !(cboSparePartName.SelectedIndex == -1);
		}

		private void txt_Enter(object sender, System.EventArgs e)
		{
			TextBox t = (TextBox)sender;
			t.SelectionStart = 0;
			t.SelectionLength = t.Text.Length;
		
		}

	}
}
