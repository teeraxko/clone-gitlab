using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

namespace Presentation.VehicleGUI
{
	public class frmVehicleTaxEntry : EntryFormBase
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
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtBrandName;
		private System.Windows.Forms.TextBox txtPlatePrefix;
		private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.DateTimePicker dtpEndDate;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.DateTimePicker dtpStartDate;
		private System.Windows.Forms.Label lblPlateNo;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label lblPlatePrefix;
		private FarPoint.Win.Input.FpDouble fpdVehicleTax;
		
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblPlateNo = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.lblPlatePrefix = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.txtBrandName = new System.Windows.Forms.TextBox();
			this.txtPlatePrefix = new System.Windows.Forms.TextBox();
			this.fpiPlateRunningNo = new FarPoint.Win.Input.FpInteger();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.fpdVehicleTax = new FarPoint.Win.Input.FpDouble();
			this.label8 = new System.Windows.Forms.Label();
			this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
			this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblPlateNo);
			this.groupBox1.Controls.Add(this.label23);
			this.groupBox1.Controls.Add(this.lblPlatePrefix);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.txtBrandName);
			this.groupBox1.Controls.Add(this.txtPlatePrefix);
			this.groupBox1.Controls.Add(this.fpiPlateRunningNo);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(480, 88);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ข้อมูลรถ";
			// 
			// lblPlateNo
			// 
			this.lblPlateNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblPlateNo.Location = new System.Drawing.Point(312, 24);
			this.lblPlateNo.Name = "lblPlateNo";
			this.lblPlateNo.Size = new System.Drawing.Size(72, 24);
			this.lblPlateNo.TabIndex = 123;
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label23.Location = new System.Drawing.Point(288, 24);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(8, 24);
			this.label23.TabIndex = 122;
			this.label23.Text = "-";
			// 
			// lblPlatePrefix
			// 
			this.lblPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblPlatePrefix.Location = new System.Drawing.Point(256, 24);
			this.lblPlatePrefix.Name = "lblPlatePrefix";
			this.lblPlatePrefix.Size = new System.Drawing.Size(40, 24);
			this.lblPlatePrefix.TabIndex = 121;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 23);
			this.label3.TabIndex = 116;
			this.label3.Text = "ยี่ห้อรถ";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label2.Location = new System.Drawing.Point(176, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(8, 16);
			this.label2.TabIndex = 115;
			this.label2.Text = "-";
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label13.Location = new System.Drawing.Point(16, 24);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 23);
			this.label13.TabIndex = 112;
			this.label13.Text = "ทะเบียนรถ";
			// 
			// txtBrandName
			// 
			this.txtBrandName.Enabled = false;
			this.txtBrandName.Location = new System.Drawing.Point(128, 56);
			this.txtBrandName.Name = "txtBrandName";
			this.txtBrandName.Size = new System.Drawing.Size(312, 20);
			this.txtBrandName.TabIndex = 30;
			this.txtBrandName.Text = "";
			// 
			// txtPlatePrefix
			// 
			this.txtPlatePrefix.Enabled = false;
			this.txtPlatePrefix.Location = new System.Drawing.Point(128, 24);
			this.txtPlatePrefix.MaxLength = 3;
			this.txtPlatePrefix.Name = "txtPlatePrefix";
			this.txtPlatePrefix.Size = new System.Drawing.Size(40, 20);
			this.txtPlatePrefix.TabIndex = 14;
			this.txtPlatePrefix.Text = "";
			this.txtPlatePrefix.TextChanged += new System.EventHandler(this.txtPlatePrefix_TextChanged);
			// 
			// fpiPlateRunningNo
			// 
			this.fpiPlateRunningNo.AllowClipboardKeys = true;
			this.fpiPlateRunningNo.AllowNull = true;
			this.fpiPlateRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiPlateRunningNo.Enabled = false;
			this.fpiPlateRunningNo.Location = new System.Drawing.Point(192, 24);
			this.fpiPlateRunningNo.MaxValue = 9999;
			this.fpiPlateRunningNo.MinValue = 0;
			this.fpiPlateRunningNo.Name = "fpiPlateRunningNo";
			this.fpiPlateRunningNo.NullColor = System.Drawing.Color.Transparent;
			this.fpiPlateRunningNo.Size = new System.Drawing.Size(48, 20);
			this.fpiPlateRunningNo.TabIndex = 20;
			this.fpiPlateRunningNo.Text = "";
			this.fpiPlateRunningNo.TextChanged += new System.EventHandler(this.fpiPlateRunningNo_TextChanged);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(259, 240);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 8;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.fpdVehicleTax);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.dtpEndDate);
			this.groupBox2.Controls.Add(this.dtpStartDate);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(16, 104);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(480, 120);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "ข้อมูลภาษีรถยนต์";
			// 
			// fpdVehicleTax
			// 
			this.fpdVehicleTax.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpdVehicleTax.AllowClipboardKeys = true;
			this.fpdVehicleTax.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpdVehicleTax.DecimalPlaces = 2;
			this.fpdVehicleTax.DecimalSeparator = ".";
			this.fpdVehicleTax.FixedPoint = true;
			this.fpdVehicleTax.Location = new System.Drawing.Point(128, 88);
			this.fpdVehicleTax.Name = "fpdVehicleTax";
			this.fpdVehicleTax.NumberGroupSeparator = ",";
			this.fpdVehicleTax.Size = new System.Drawing.Size(96, 20);
			this.fpdVehicleTax.TabIndex = 3;
			this.fpdVehicleTax.Text = "";
			this.fpdVehicleTax.UseSeparator = true;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 88);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 23);
			this.label8.TabIndex = 8;
			this.label8.Text = "ภาษีรถยนต์";
			// 
			// dtpEndDate
			// 
			this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
			this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndDate.Location = new System.Drawing.Point(128, 56);
			this.dtpEndDate.Name = "dtpEndDate";
			this.dtpEndDate.Size = new System.Drawing.Size(96, 20);
			this.dtpEndDate.TabIndex = 2;
			// 
			// dtpStartDate
			// 
			this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
			this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStartDate.Location = new System.Drawing.Point(128, 24);
			this.dtpStartDate.Name = "dtpStartDate";
			this.dtpStartDate.Size = new System.Drawing.Size(96, 20);
			this.dtpStartDate.TabIndex = 1;
			this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 23);
			this.label5.TabIndex = 2;
			this.label5.Text = "วันที่สิ้นสุด";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 1;
			this.label4.Text = "วันที่เริ่มต้น";
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(179, 240);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 7;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmVehicleTaxEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(512, 278);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmVehicleTaxEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isTextChange = true;
		private VehicleTax objVehicleTax;
		private frmVehicleTaxByPlate parentForm;	
		#endregion -Private-

//		===================================== Property ==================================
		private Vehicle aVehicle;
		public Vehicle AVehicle
		{
			set
			{
				aVehicle = value;
				txtPlatePrefix.Text = value.PlatePrefix;
				fpiPlateRunningNo.Text = value.PlateRunningNo;
				txtBrandName.Text = value.AModel.ABrand.AName.English;
			}
		}

//		================================= Constructor ================================
		public frmVehicleTaxEntry(frmVehicleTaxByPlate value)
		{	
			InitializeComponent();
			parentForm = value;	
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentVehicleTaxPlateNo");
		}		
		
//		================================= Private Method ================================
		private void setVehicleTax(VehicleTax value)
		{
			isTextChange = false;
			txtPlatePrefix.Text = value.AVehicle.PlatePrefix;
			fpiPlateRunningNo.Text = value.AVehicle.PlateRunningNo;
			txtBrandName.Text = value.AVehicle.AModel.ABrand.AName.English;			
			dtpStartDate.Value = value.APeriod.From;
			dtpEndDate.Value = value.APeriod.To;	
			fpdVehicleTax.Value = value.TaxAmount;
			isTextChange = true;
		}

		private VehicleTax getVehicleTax()
		{
			objVehicleTax = new VehicleTax();
			objVehicleTax.AVehicle = aVehicle;
			objVehicleTax.APeriod.From = dtpStartDate.Value;
			objVehicleTax.APeriod.To = dtpEndDate.Value;
			objVehicleTax.TaxAmount = Decimal.Parse(fpdVehicleTax.Text);
			return objVehicleTax;		
		}

		#region - validate -
		private bool validateAdd()
		{
			if(dtpStartDate.Value > dtpEndDate.Value)
			{
				Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
				dtpStartDate.Focus();
				return false;
			}

			if(parentForm.FacadeVehicleTaxByPlate.FillVehicleTax(getVehicleTax()))
			{
				Message(MessageList.Error.E0003);
				dtpStartDate.Focus();
				return false;			
			}

			TimePeriod timePeriod = new TimePeriod();
			timePeriod.From = dtpStartDate.Value;
			timePeriod.To = dtpEndDate.Value;
			if(!parentForm.FacadeVehicleTaxByPlate.ValidateVehicleTaxPeriod(timePeriod))
			{
				Message(MessageList.Error.E0014, "ระบุวันที่ในช่วงเวลาดังกล่าวได้");
				dtpStartDate.Focus();
				timePeriod = null;
				return false;
			}
			timePeriod = null;

			if(parentForm.FacadeVehicleTaxByPlate.ObjVehicleTaxList.Count == 0)
			{
				if(aVehicle.RegisterDate.Year != dtpStartDate.Value.Year)
				{
					Message(MessageList.Error.E0002, "ภาษีรถยนต์ของปีแรกก่อน");
					dtpStartDate.Focus();
					return false;
				}
			}			

			return true;		
		}

		private bool validateTaxAmount()
		{
			if(Decimal.Parse(fpdVehicleTax.Text) <= 0)
			{
				Message(MessageList.Error.E0002, "ภาษีรถยนต์");
				fpdVehicleTax.Focus();
				return false;		
			}
			return true;		
		}

		private bool validateVehicle(Vehicle value)
		{
			if(value.AVehicleStatus.Code == "4" || value.AVehicleStatus.Code == "5" || value.AVehicleStatus.Code == "6")
			{
				Message(MessageList.Error.E0014, "ต่อภาษีรถยนต์ที่สิ้นสุดการใช้งานแล้วได้");
				return false;		
			}
			return true;		
		}
		#endregion

		private void enableKeyField(bool enable)
		{
			dtpStartDate.Enabled = enable;
			dtpEndDate.Enabled = enable;
		}

		private void clearForm()
		{
			txtBrandName.Text = "";
			txtPlatePrefix.Text = "";
			fpdVehicleTax.Text = "";
			fpiPlateRunningNo.Text = "";
			isTextChange = false;
			dtpStartDate.Value = DateTime.Today;
			dtpEndDate.Value = DateTime.Today.AddYears(1);
			fpdVehicleTax.MaxValue = 99999.99;
			fpdVehicleTax.MinValue = 0;
			isTextChange = true;
			SetFocusVehicle();
		}

		private void setForm(Vehicle value)
		{
			VehicleTax currentVehicleTax = parentForm.FacadeVehicleTaxByPlate.GetCurrentVehicleTax(value);
			if(currentVehicleTax == null)
			{
				isTextChange = false;
				fpdVehicleTax.Value = 0m;
				dtpStartDate.Value = value.RegisterDate;
				dtpEndDate.Value = value.RegisterDate.AddYears(1);
				isTextChange = true;
			}
			else
			{
				isTextChange = false;
				dtpStartDate.Value = currentVehicleTax.APeriod.To;
				dtpEndDate.Value = currentVehicleTax.APeriod.To.AddYears(1);
				isTextChange = true;
				calTaxAmount();
			}
			currentVehicleTax = null;			
		}

		private void calTaxAmount()
		{
			VehicleTax calVehicleTax = new VehicleTax();
			calVehicleTax.AVehicle = aVehicle;
		
			parentForm.FacadeVehicleTaxByPlate.FillBeginVehicleTax(ref calVehicleTax);

			calVehicleTax.APeriod.To = dtpStartDate.Value;
			parentForm.FacadeVehicleTaxByPlate.CalculateVehicleTaxAmount(ref calVehicleTax);

			fpdVehicleTax.Value = calVehicleTax.TaxAmount;
			calVehicleTax = null;
		}
		
//		================================= Add/Edit Event ================================
		private void AddEvent()
		{
			try
			{
				if(validateAdd() && validateTaxAmount() && validateVehicle(aVehicle))
				{
					if(parentForm.AddRow(getVehicleTax()))
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

		private void EditEvent()
		{
			try
			{
				if (validateTaxAmount())
				{
					SetFocusVehicle();
					if(parentForm.UpdateRow(getVehicleTax()))
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
		
//		================================= Public Method  ================================			
		public void InitAddAction(Vehicle value)	
		{
			this.title = "ภาษีรถยนต์";
			clearForm();
			baseADD();
			enableKeyField(true);
			this.AVehicle = value;
			setForm(value);
		}

		public void InitEditAction(VehicleTax value)
		{
			this.title = "ภาษีรถยนต์";
			baseEDIT();
			clearForm();
			enableKeyField(false);
			this.AVehicle = value.AVehicle;
            setVehicleTax(value);
		
			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}

		public void SetFocusStart()
		{
			dtpStartDate.Focus();
		}
		public void SetFocusVehicle()
		{
			fpdVehicleTax.Focus();
		}

//		================================= Event ================================
		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
					AddEvent();
					break;
				case ActionType.EDIT :
					EditEvent();
					break;
			}		
		}
		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();	
		}

		private void txtPlatePrefix_TextChanged(object sender, System.EventArgs e)
		{
			lblPlatePrefix.Text = txtPlatePrefix.Text;
		}

		private void fpiPlateRunningNo_TextChanged(object sender, System.EventArgs e)
		{
			lblPlateNo.Text = fpiPlateRunningNo.Text;
		}

		private void dtpStartDate_ValueChanged(object sender, System.EventArgs e)
		{
			if(isTextChange)
			{
				dtpEndDate.Value = dtpStartDate.Value.AddYears(1);
				calTaxAmount();
			}
		}
	}
}
