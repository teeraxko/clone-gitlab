using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using Facade.ContractFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;
using Presentation.VehicleGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.ContractGUI
{
	public class frmVehicleSpareAssignmentEntry : EntryFormBase
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
		private System.Windows.Forms.GroupBox grbVehicle;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Label lblPlateNo;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label lblPlatePrefix;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtPlatePrefix;
		private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBrand;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtModel;
		private System.Windows.Forms.DateTimePicker dtpToDate;
		private System.Windows.Forms.DateTimePicker dtpFromDate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboAssignmentReason;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.grbVehicle = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtBrand = new System.Windows.Forms.TextBox();
			this.lblPlateNo = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.lblPlatePrefix = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.txtPlatePrefix = new System.Windows.Forms.TextBox();
			this.fpiPlateRunningNo = new FarPoint.Win.Input.FpInteger();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboAssignmentReason = new System.Windows.Forms.ComboBox();
			this.dtpToDate = new System.Windows.Forms.DateTimePicker();
			this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.grbVehicle.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grbVehicle
			// 
			this.grbVehicle.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.grbVehicle.Controls.Add(this.label2);
			this.grbVehicle.Controls.Add(this.txtModel);
			this.grbVehicle.Controls.Add(this.label4);
			this.grbVehicle.Controls.Add(this.label1);
			this.grbVehicle.Controls.Add(this.txtBrand);
			this.grbVehicle.Controls.Add(this.lblPlateNo);
			this.grbVehicle.Controls.Add(this.label23);
			this.grbVehicle.Controls.Add(this.lblPlatePrefix);
			this.grbVehicle.Controls.Add(this.label13);
			this.grbVehicle.Controls.Add(this.txtPlatePrefix);
			this.grbVehicle.Controls.Add(this.fpiPlateRunningNo);
			this.grbVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.grbVehicle.Location = new System.Drawing.Point(13, 8);
			this.grbVehicle.Name = "grbVehicle";
			this.grbVehicle.Size = new System.Drawing.Size(376, 120);
			this.grbVehicle.TabIndex = 2;
			this.grbVehicle.TabStop = false;
			this.grbVehicle.Text = "ทะเบียนรถ";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label2.Location = new System.Drawing.Point(156, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 22);
			this.label2.TabIndex = 149;
			this.label2.Text = "-";
			// 
			// txtModel
			// 
			this.txtModel.Enabled = false;
			this.txtModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.txtModel.Location = new System.Drawing.Point(112, 88);
			this.txtModel.MaxLength = 50;
			this.txtModel.Name = "txtModel";
			this.txtModel.Size = new System.Drawing.Size(248, 20);
			this.txtModel.TabIndex = 148;
			this.txtModel.Text = "";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label4.Location = new System.Drawing.Point(16, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 23);
			this.label4.TabIndex = 147;
			this.label4.Text = "รุ่นรถ";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 146;
			this.label1.Text = "ยี่ห้อรถ";
			// 
			// txtBrand
			// 
			this.txtBrand.Enabled = false;
			this.txtBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.txtBrand.Location = new System.Drawing.Point(112, 56);
			this.txtBrand.MaxLength = 50;
			this.txtBrand.Name = "txtBrand";
			this.txtBrand.Size = new System.Drawing.Size(248, 20);
			this.txtBrand.TabIndex = 145;
			this.txtBrand.Text = "";
			// 
			// lblPlateNo
			// 
			this.lblPlateNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblPlateNo.Location = new System.Drawing.Point(296, 24);
			this.lblPlateNo.Name = "lblPlateNo";
			this.lblPlateNo.Size = new System.Drawing.Size(72, 24);
			this.lblPlateNo.TabIndex = 144;
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label23.Location = new System.Drawing.Point(280, 24);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(16, 24);
			this.label23.TabIndex = 143;
			this.label23.Text = "-";
			// 
			// lblPlatePrefix
			// 
			this.lblPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblPlatePrefix.Location = new System.Drawing.Point(240, 24);
			this.lblPlatePrefix.Name = "lblPlatePrefix";
			this.lblPlatePrefix.Size = new System.Drawing.Size(40, 24);
			this.lblPlatePrefix.TabIndex = 142;
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label13.Location = new System.Drawing.Point(16, 24);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 23);
			this.label13.TabIndex = 140;
			this.label13.Text = "ทะเบียนรถ";
			// 
			// txtPlatePrefix
			// 
			this.txtPlatePrefix.Enabled = false;
			this.txtPlatePrefix.Location = new System.Drawing.Point(112, 25);
			this.txtPlatePrefix.MaxLength = 3;
			this.txtPlatePrefix.Name = "txtPlatePrefix";
			this.txtPlatePrefix.Size = new System.Drawing.Size(40, 23);
			this.txtPlatePrefix.TabIndex = 1;
			this.txtPlatePrefix.Text = "";
			this.txtPlatePrefix.TextChanged += new System.EventHandler(this.txtPlatePrefix_TextChanged);
			// 
			// fpiPlateRunningNo
			// 
			this.fpiPlateRunningNo.AllowClipboardKeys = true;
			this.fpiPlateRunningNo.AllowNull = true;
			this.fpiPlateRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiPlateRunningNo.Enabled = false;
			this.fpiPlateRunningNo.Location = new System.Drawing.Point(176, 25);
			this.fpiPlateRunningNo.MaxValue = 9999;
			this.fpiPlateRunningNo.MinValue = 0;
			this.fpiPlateRunningNo.Name = "fpiPlateRunningNo";
			this.fpiPlateRunningNo.NullColor = System.Drawing.Color.Transparent;
			this.fpiPlateRunningNo.Size = new System.Drawing.Size(48, 22);
			this.fpiPlateRunningNo.TabIndex = 2;
			this.fpiPlateRunningNo.Text = "";
			this.fpiPlateRunningNo.TextChanged += new System.EventHandler(this.fpiPlateRunningNo_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.cboAssignmentReason);
			this.groupBox1.Controls.Add(this.dtpToDate);
			this.groupBox1.Controls.Add(this.dtpFromDate);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.groupBox1.Location = new System.Drawing.Point(13, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(376, 96);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ข้อมูลการใช้รถ";
			// 
			// cboAssignmentReason
			// 
			this.cboAssignmentReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboAssignmentReason.Location = new System.Drawing.Point(112, 56);
			this.cboAssignmentReason.MaxLength = 50;
			this.cboAssignmentReason.Name = "cboAssignmentReason";
			this.cboAssignmentReason.Size = new System.Drawing.Size(248, 21);
			this.cboAssignmentReason.TabIndex = 5;
			// 
			// dtpToDate
			// 
			this.dtpToDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpToDate.CustomFormat = "dd/MM/yyyy";
			this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpToDate.Location = new System.Drawing.Point(239, 24);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(96, 20);
			this.dtpToDate.TabIndex = 4;
			// 
			// dtpFromDate
			// 
			this.dtpFromDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
			this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFromDate.Location = new System.Drawing.Point(112, 24);
			this.dtpFromDate.Name = "dtpFromDate";
			this.dtpFromDate.Size = new System.Drawing.Size(96, 20);
			this.dtpFromDate.TabIndex = 3;
			this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label6.Location = new System.Drawing.Point(216, 21);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(15, 27);
			this.label6.TabIndex = 134;
			this.label6.Text = "-";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label8.Location = new System.Drawing.Point(16, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(84, 16);
			this.label8.TabIndex = 132;
			this.label8.Text = "ระยะเวลาการใช้รถ";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label10.Location = new System.Drawing.Point(16, 56);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(45, 16);
			this.label10.TabIndex = 123;
			this.label10.Text = "หมายเหตุ";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(204, 232);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 7;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Location = new System.Drawing.Point(124, 232);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 6;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmVehicleSpareAssignmentEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(402, 264);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grbVehicle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmVehicleSpareAssignmentEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.frmVehicleSpareAssignmentEntry_Load);
			this.grbVehicle.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmVehicleSpareAssignment parentForm;	
		private VehicleAssignment objVehicleAssignment;
		#endregion
		
//		============================== Property ====================
		private Vehicle aVehicle;
		public Vehicle AVehicle
		{
			set
			{
				aVehicle = value;
				txtPlatePrefix.Text = value.PlatePrefix;
				fpiPlateRunningNo.Text = value.PlateRunningNo;
				txtBrand.Text = value.AModel.ABrand.AName.English;
				txtModel.Text = value.AModel.AName.English;
			}
		}	
		
//		============================== Constructor ==============================
		public frmVehicleSpareAssignmentEntry(frmVehicleSpareAssignment parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractAssignmentHistoryVehicelAssignment");

			try
			{			
				cboAssignmentReason.DataSource = parentForm.FacadeVehicleSpareAssignment.DataSourceAssignmentReason;
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
		}

//		============================== Private Method ==============================
		#region - Validate -
		private bool validateForm()
		{
			return validateInputDate() && validateVehicle() && validateReason();
		}

		private bool validateInputDate()
		{
			if(dtpFromDate.Value.Date > dtpToDate.Value.Date)
			{
				Message(MessageList.Error.E0011, "วันที่เริ่มต้น","วันที่สิ้นสุด");
				dtpFromDate.Focus();
				return false;
			}
			return true;
		}

		private bool validateVehicle()
		{
			Vehicle vehicle = parentForm.FacadeVehicleSpareAssignment.GetVehicle(txtPlatePrefix.Text, fpiPlateRunningNo.Text);
			if(vehicle == null)
			{
				Message(MessageList.Error.E0004, "ทะเบียนรถ");
				txtPlatePrefix.Focus();
				vehicle = null;
				return false;
			}
			vehicle = null;
			return true;			
		}

		private bool validateReason()
		{
			if(cboAssignmentReason.Text.Trim() == "")
			{
				Message(MessageList.Error.E0002, "หมายเหตุ" );
				cboAssignmentReason.Focus();
				return false;
			}
			return true;
		}

		private bool validateAvailableVehicle(VehicleAssignment value)
		{
			if(parentForm.FacadeVehicleSpareAssignment.FillExcludeAvailableVehicleSpareAssignment(value))
			{
				Message(MessageList.Error.E0014, "จ่ายงานในช่วงเวลาดังกล่าวได้");
				dtpFromDate.Focus();
				return false;
			}
			return true;
		}

		private bool validatePeriodAssign(VehicleAssignment value)
		{
			if (!value.APeriod.From.Equals(dtpFromDate.Value) || !value.APeriod.To.Equals(dtpToDate.Value))
			{
				VehicleAssignmentList listVehicleAssignment = new VehicleAssignmentList(parentForm.FacadeVehicleSpareAssignment.GetCompany());
				VehicleAssignment vehicleAssignment = new VehicleAssignment();
				vehicleAssignment.AAssignedVehicle = value.AAssignedVehicle;

				if(parentForm.FacadeVehicleSpareAssignment.FillVehicleSpareAssignmentList(ref listVehicleAssignment, vehicleAssignment))
				{
					listVehicleAssignment.Remove(value);

					for(int i=0; i<listVehicleAssignment.Count; i++)
					{
						if((listVehicleAssignment[i].APeriod.From <= dtpToDate.Value) & (listVehicleAssignment[i].APeriod.To >= dtpFromDate.Value))
						{
							Message(MessageList.Error.E0014, "จ่ายงานในช่วงเวลาดังกล่าวได้");
							dtpFromDate.Focus();
							listVehicleAssignment = null;
							return false;
						}
					}
				}
				listVehicleAssignment = null;
				vehicleAssignment = null;
			}
			return true;
		}
		#endregion

		private VehicleAssignment getVehicleAssignment()
		{
			objVehicleAssignment = new VehicleAssignment();
			objVehicleAssignment.AAssignedVehicle = aVehicle;
			objVehicleAssignment.APeriod.From = dtpFromDate.Value.Date;
			objVehicleAssignment.APeriod.To = dtpToDate.Value.Date;
			objVehicleAssignment.AMainVehicle = aVehicle;
			objVehicleAssignment.AssignmentRole = ASSIGNMENT_ROLE_TYPE.SPARE;
			objVehicleAssignment.AAssignmentReason.Name = cboAssignmentReason.Text;
			objVehicleAssignment.AContract = new ContractBase();
			objVehicleAssignment.AContract.ContractNo = new DocumentNo("PTB-C-0000000");
			return objVehicleAssignment;
		}

		private void setVehicleAssignment(VehicleAssignment value)
		{
			objVehicleAssignment = value;
			cboAssignmentReason.Text = value.AAssignmentReason.Name;
			dtpFromDate.Value = value.APeriod.From;
			dtpToDate.Value = value.APeriod.To;
		}

		private void clearCombo()
		{
			if (cboAssignmentReason.Items.Count>0)
			{
				cboAssignmentReason.SelectedIndex = -1;
				cboAssignmentReason.SelectedIndex = -1;
			}
		}

		private void clearForm()
		{
			clearCombo();
			dtpFromDate.Value = DateTime.Today;
			dtpToDate.Value = DateTime.Today;
			dtpFromDate.Focus();
		}

//		============================== Public Method ==============================
		public void InitAddAction(Vehicle value)
		{
			this.title = "การจ่ายงานภายในให้รถ Spare";
			baseADD();
			clearForm();
			AVehicle = value;	
		}

		public void InitEditAction(VehicleAssignment value)
		{
			this.title = "การจ่ายงานภายในให้รถ Spare";
			baseEDIT();
			clearForm();
			AVehicle = value.AMainVehicle;
			setVehicleAssignment(value);

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}

//		============================== Base event ==============================
		private void addEvent()
		{
			try
			{
				VehicleAssignment vehicleAssignment = getVehicleAssignment();
				if (validateForm() && validateAvailableVehicle(vehicleAssignment) && parentForm.AddRow(vehicleAssignment))					
				{
                    this.Hide();
				}
				vehicleAssignment = null;
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}

		private void editEvent()
		{
			try
			{
				if (validateInputDate() && validateReason() && validatePeriodAssign(objVehicleAssignment))
				{
					VehicleAssignment newVehicleAssignment = new VehicleAssignment();

					newVehicleAssignment.AMainVehicle = objVehicleAssignment.AMainVehicle;
					newVehicleAssignment.AAssignedVehicle = objVehicleAssignment.AAssignedVehicle;
					newVehicleAssignment.AssignmentRole = objVehicleAssignment.AssignmentRole;
					newVehicleAssignment.AContract = objVehicleAssignment.AContract;

					newVehicleAssignment.AAssignmentReason.Name = cboAssignmentReason.Text;
					newVehicleAssignment.APeriod.From = dtpFromDate.Value.Date;
					newVehicleAssignment.APeriod.To = dtpToDate.Value.Date;

					if (parentForm.UpdateRow(objVehicleAssignment, newVehicleAssignment))
					{
						this.Hide();
					}
				}				
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}	
		}

//		============================== event ==============================
		private void frmVehicleSpareAssignmentEntry_Load(object sender, System.EventArgs e)
		{
			if(action == ActionType.ADD)
			{
				clearCombo();
			}
		}

		private void fpiPlateRunningNo_TextChanged(object sender, System.EventArgs e)
		{
			lblPlateNo.Text = fpiPlateRunningNo.Text;
		}

		private void txtPlatePrefix_TextChanged(object sender, System.EventArgs e)
		{
			lblPlatePrefix.Text = txtPlatePrefix.Text;
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
					addEvent();
					break;
				case ActionType.EDIT :
					editEvent();
					break;
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void dtpFromDate_ValueChanged(object sender, System.EventArgs e)
		{
			dtpToDate.Value = dtpFromDate.Value;
		}
	}
}
