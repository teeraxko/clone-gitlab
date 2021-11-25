using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.AttendanceEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;

using Facade.AttendanceFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

using ictus.Common.Entity.Time;

namespace Presentation.AttendanceGUI
{
	public class frmTaxiConditionEntry : EntryFormBase
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
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RadioButton rdoPosition;
		private System.Windows.Forms.RadioButton rdoFamily;
		private System.Windows.Forms.DateTimePicker dtpPAfterTime;
		private System.Windows.Forms.DateTimePicker dtpPBeforeTime;
		private System.Windows.Forms.ComboBox cboPCustomer;
		private System.Windows.Forms.DateTimePicker dtpFAfterTime;
		private System.Windows.Forms.DateTimePicker dtpFBeforeTime;
		private System.Windows.Forms.ComboBox cboFCustomerGroup;
		private System.Windows.Forms.TextBox txtPCustomerGroup;
		private System.Windows.Forms.GroupBox gpbPosition;
		private System.Windows.Forms.GroupBox gpbFamily;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.GroupBox gpbKindOfVehicle;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DateTimePicker dtpFAfterTimeForCharge;
		private System.Windows.Forms.DateTimePicker dtpFBeforeTimeForCharge;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.gpbKindOfVehicle = new System.Windows.Forms.GroupBox();
			this.rdoPosition = new System.Windows.Forms.RadioButton();
			this.rdoFamily = new System.Windows.Forms.RadioButton();
			this.gpbPosition = new System.Windows.Forms.GroupBox();
			this.txtPCustomerGroup = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.dtpPAfterTime = new System.Windows.Forms.DateTimePicker();
			this.dtpPBeforeTime = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cboPCustomer = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.gpbFamily = new System.Windows.Forms.GroupBox();
			this.dtpFAfterTimeForCharge = new System.Windows.Forms.DateTimePicker();
			this.dtpFBeforeTimeForCharge = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.dtpFAfterTime = new System.Windows.Forms.DateTimePicker();
			this.dtpFBeforeTime = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cboFCustomerGroup = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.gpbKindOfVehicle.SuspendLayout();
			this.gpbPosition.SuspendLayout();
			this.gpbFamily.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbKindOfVehicle
			// 
			this.gpbKindOfVehicle.Controls.Add(this.rdoPosition);
			this.gpbKindOfVehicle.Controls.Add(this.rdoFamily);
			this.gpbKindOfVehicle.Location = new System.Drawing.Point(24, 16);
			this.gpbKindOfVehicle.Name = "gpbKindOfVehicle";
			this.gpbKindOfVehicle.Size = new System.Drawing.Size(400, 64);
			this.gpbKindOfVehicle.TabIndex = 10;
			this.gpbKindOfVehicle.TabStop = false;
			this.gpbKindOfVehicle.Text = " กำหนดเงื่อนไขค่า Taxi ของ";
			// 
			// rdoPosition
			// 
			this.rdoPosition.Location = new System.Drawing.Point(64, 24);
			this.rdoPosition.Name = "rdoPosition";
			this.rdoPosition.TabIndex = 3;
			this.rdoPosition.Text = " Position Car";
			this.rdoPosition.CheckedChanged += new System.EventHandler(this.rdoPosition_CheckedChanged);
			// 
			// rdoFamily
			// 
			this.rdoFamily.Location = new System.Drawing.Point(232, 24);
			this.rdoFamily.Name = "rdoFamily";
			this.rdoFamily.TabIndex = 4;
			this.rdoFamily.Text = " Family Car";
			// 
			// gpbPosition
			// 
			this.gpbPosition.Controls.Add(this.txtPCustomerGroup);
			this.gpbPosition.Controls.Add(this.label7);
			this.gpbPosition.Controls.Add(this.dtpPAfterTime);
			this.gpbPosition.Controls.Add(this.dtpPBeforeTime);
			this.gpbPosition.Controls.Add(this.label3);
			this.gpbPosition.Controls.Add(this.label2);
			this.gpbPosition.Controls.Add(this.cboPCustomer);
			this.gpbPosition.Controls.Add(this.label1);
			this.gpbPosition.Location = new System.Drawing.Point(24, 80);
			this.gpbPosition.Name = "gpbPosition";
			this.gpbPosition.Size = new System.Drawing.Size(400, 128);
			this.gpbPosition.TabIndex = 8;
			this.gpbPosition.TabStop = false;
			this.gpbPosition.Text = " Position Car";
			// 
			// txtPCustomerGroup
			// 
			this.txtPCustomerGroup.Enabled = false;
			this.txtPCustomerGroup.Location = new System.Drawing.Point(96, 56);
			this.txtPCustomerGroup.Name = "txtPCustomerGroup";
			this.txtPCustomerGroup.Size = new System.Drawing.Size(152, 20);
			this.txtPCustomerGroup.TabIndex = 7;
			this.txtPCustomerGroup.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 24);
			this.label7.TabIndex = 6;
			this.label7.Text = "กลุ่มลูกค้า";
			// 
			// dtpPAfterTime
			// 
			this.dtpPAfterTime.CustomFormat = "HH:mm";
			this.dtpPAfterTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpPAfterTime.Location = new System.Drawing.Point(264, 88);
			this.dtpPAfterTime.Name = "dtpPAfterTime";
			this.dtpPAfterTime.ShowUpDown = true;
			this.dtpPAfterTime.Size = new System.Drawing.Size(72, 20);
			this.dtpPAfterTime.TabIndex = 5;
			// 
			// dtpPBeforeTime
			// 
			this.dtpPBeforeTime.CustomFormat = "HH:mm";
			this.dtpPBeforeTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpPBeforeTime.Location = new System.Drawing.Point(96, 88);
			this.dtpPBeforeTime.Name = "dtpPBeforeTime";
			this.dtpPBeforeTime.ShowUpDown = true;
			this.dtpPBeforeTime.Size = new System.Drawing.Size(64, 20);
			this.dtpPBeforeTime.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(192, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 24);
			this.label3.TabIndex = 3;
			this.label3.Text = "เลิกหลังเวลา";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "เข้าก่อนเวลา";
			// 
			// cboPCustomer
			// 
			this.cboPCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPCustomer.Location = new System.Drawing.Point(96, 24);
			this.cboPCustomer.Name = "cboPCustomer";
			this.cboPCustomer.Size = new System.Drawing.Size(288, 21);
			this.cboPCustomer.TabIndex = 1;
			this.cboPCustomer.SelectedIndexChanged += new System.EventHandler(this.cboPCustomer_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "ลูกค้า";
			// 
			// gpbFamily
			// 
			this.gpbFamily.Controls.Add(this.label11);
			this.gpbFamily.Controls.Add(this.label10);
			this.gpbFamily.Controls.Add(this.dtpFAfterTimeForCharge);
			this.gpbFamily.Controls.Add(this.dtpFBeforeTimeForCharge);
			this.gpbFamily.Controls.Add(this.label8);
			this.gpbFamily.Controls.Add(this.label9);
			this.gpbFamily.Controls.Add(this.dtpFAfterTime);
			this.gpbFamily.Controls.Add(this.dtpFBeforeTime);
			this.gpbFamily.Controls.Add(this.label4);
			this.gpbFamily.Controls.Add(this.label5);
			this.gpbFamily.Controls.Add(this.cboFCustomerGroup);
			this.gpbFamily.Controls.Add(this.label6);
			this.gpbFamily.Location = new System.Drawing.Point(24, 208);
			this.gpbFamily.Name = "gpbFamily";
			this.gpbFamily.Size = new System.Drawing.Size(400, 152);
			this.gpbFamily.TabIndex = 9;
			this.gpbFamily.TabStop = false;
			this.gpbFamily.Text = "  Family Car";
			// 
			// dtpFAfterTimeForCharge
			// 
			this.dtpFAfterTimeForCharge.CustomFormat = "HH:mm";
			this.dtpFAfterTimeForCharge.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFAfterTimeForCharge.Location = new System.Drawing.Point(264, 96);
			this.dtpFAfterTimeForCharge.Name = "dtpFAfterTimeForCharge";
			this.dtpFAfterTimeForCharge.ShowUpDown = true;
			this.dtpFAfterTimeForCharge.Size = new System.Drawing.Size(72, 20);
			this.dtpFAfterTimeForCharge.TabIndex = 9;
			// 
			// dtpFBeforeTimeForCharge
			// 
			this.dtpFBeforeTimeForCharge.CustomFormat = "HH:mm";
			this.dtpFBeforeTimeForCharge.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFBeforeTimeForCharge.Location = new System.Drawing.Point(96, 96);
			this.dtpFBeforeTimeForCharge.Name = "dtpFBeforeTimeForCharge";
			this.dtpFBeforeTimeForCharge.ShowUpDown = true;
			this.dtpFBeforeTimeForCharge.Size = new System.Drawing.Size(64, 20);
			this.dtpFBeforeTimeForCharge.TabIndex = 8;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(192, 96);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 7;
			this.label8.Text = "เลิกหลังเวลา";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 96);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 16);
			this.label9.TabIndex = 6;
			this.label9.Text = "เข้าก่อนเวลา";
			// 
			// dtpFAfterTime
			// 
			this.dtpFAfterTime.CustomFormat = "HH:mm";
			this.dtpFAfterTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFAfterTime.Location = new System.Drawing.Point(264, 56);
			this.dtpFAfterTime.Name = "dtpFAfterTime";
			this.dtpFAfterTime.ShowUpDown = true;
			this.dtpFAfterTime.Size = new System.Drawing.Size(72, 20);
			this.dtpFAfterTime.TabIndex = 5;
			// 
			// dtpFBeforeTime
			// 
			this.dtpFBeforeTime.CustomFormat = "HH:mm";
			this.dtpFBeforeTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFBeforeTime.Location = new System.Drawing.Point(96, 56);
			this.dtpFBeforeTime.Name = "dtpFBeforeTime";
			this.dtpFBeforeTime.ShowUpDown = true;
			this.dtpFBeforeTime.Size = new System.Drawing.Size(64, 20);
			this.dtpFBeforeTime.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(192, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 24);
			this.label4.TabIndex = 3;
			this.label4.Text = "เลิกหลังเวลา";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 24);
			this.label5.TabIndex = 2;
			this.label5.Text = "เข้าก่อนเวลา";
			// 
			// cboFCustomerGroup
			// 
			this.cboFCustomerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFCustomerGroup.Location = new System.Drawing.Point(96, 24);
			this.cboFCustomerGroup.Name = "cboFCustomerGroup";
			this.cboFCustomerGroup.Size = new System.Drawing.Size(152, 21);
			this.cboFCustomerGroup.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 24);
			this.label6.TabIndex = 0;
			this.label6.Text = "กลุ่มลูกค้า";
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdCancel.Location = new System.Drawing.Point(235, 384);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 12;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdOK.Location = new System.Drawing.Point(155, 384);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 11;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 112);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 16);
			this.label10.TabIndex = 10;
			this.label10.Text = "(สำหรับลูกค้า)";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(192, 112);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(72, 16);
			this.label11.TabIndex = 11;
			this.label11.Text = "(สำหรับลูกค้า)";
			// 
			// frmTaxiConditionEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(450, 423);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.gpbKindOfVehicle);
			this.Controls.Add(this.gpbPosition);
			this.Controls.Add(this.gpbFamily);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmTaxiConditionEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmTaxiConditionEntry";
			this.Load += new System.EventHandler(this.frmTaxiConditionEntry_Load);
			this.gpbKindOfVehicle.ResumeLayout(false);
			this.gpbPosition.ResumeLayout(false);
			this.gpbFamily.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmTaxiCondition parentForm;
		#endregion

		private TaxiFamilyCarCondition objTaxiFamilyCarCondition;
		public TaxiFamilyCarCondition ObjTaxiFamilyCarCondition
		{
			set
			{
				objTaxiFamilyCarCondition = value;
				cboFCustomerGroup.Text = value.ACustomerGroup.AName.English;
				dtpFBeforeTime.Value = value.UntilTimeIn;
				dtpFAfterTime.Value = value.SinceTimeOut;
				dtpFBeforeTimeForCharge.Value = value.UntilTimeInForCharge;
				dtpFAfterTimeForCharge.Value = value.SinceTimeOutForCharge;
			}
			get
			{
				objTaxiFamilyCarCondition = new TaxiFamilyCarCondition();
				objTaxiFamilyCarCondition.ACustomerGroup = (CustomerGroup)cboFCustomerGroup.SelectedItem;

				TimePeriod timePeriod;
				timePeriod = new TimePeriod();
				timePeriod = getTimePeriod(dtpFBeforeTime.Value, dtpFAfterTime.Value);
				objTaxiFamilyCarCondition.UntilTimeIn = timePeriod.From;
				objTaxiFamilyCarCondition.SinceTimeOut = timePeriod.To;

				timePeriod = new TimePeriod();
				timePeriod = getTimePeriod(dtpFBeforeTimeForCharge.Value, dtpFAfterTimeForCharge.Value);
				objTaxiFamilyCarCondition.UntilTimeInForCharge = timePeriod.From;
				objTaxiFamilyCarCondition.SinceTimeOutForCharge = timePeriod.To;
				timePeriod = null;

				return objTaxiFamilyCarCondition;
			}		
		}

		private TaxiPositionCarCondition objTaxiPositionCarCondition;
		public TaxiPositionCarCondition ObjTaxiPositionCarCondition
		{
			set
			{
				objTaxiPositionCarCondition = value;
				cboPCustomer.Text = value.ACustomer.ToString();
				dtpPBeforeTime.Value = value.UntilTimeIn;
				dtpPAfterTime.Value = value.SinceTimeOut;
			}
			get
			{
				objTaxiPositionCarCondition = new TaxiPositionCarCondition();
				objTaxiPositionCarCondition.ACustomer = (Customer)cboPCustomer.SelectedItem;

				TimePeriod timePeriod = new TimePeriod();
				timePeriod = getTimePeriod(dtpPBeforeTime.Value, dtpPAfterTime.Value);
				objTaxiPositionCarCondition.UntilTimeIn = timePeriod.From;
				objTaxiPositionCarCondition.SinceTimeOut = timePeriod.To;
				timePeriod = null;

				return objTaxiPositionCarCondition;
			}		
		}

//		============================== Constructor ==============================
		public frmTaxiConditionEntry(frmTaxiCondition parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miTaxiCondition");

			try
			{			
				cboPCustomer.DataSource = parentForm.FacadeTaxiCondition.DataSourceCustomer;
				cboFCustomerGroup.DataSource = parentForm.FacadeTaxiCondition.DataSourceCustomerGroup;
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

//		============================== private method ==============================
		private void enableIsPosition(bool enable)
		{
			gpbPosition.Enabled = enable;
			gpbFamily.Enabled = !enable;
		}

		private void clearForm()
		{
			gpbKindOfVehicle.Enabled =  true;
			cboFCustomerGroup.Enabled = true;
			cboPCustomer.Enabled = true;
			txtPCustomerGroup.Text = "";
			clearIsFamily();
			clearIsPosition();
		}

		private void clearIsPosition()
		{
			cboFCustomerGroup.SelectedIndex = -1;
			cboFCustomerGroup.SelectedIndex = -1;
			TimeConstant dtConstant = new TimeConstant();
			dtpFBeforeTime.Value = dtConstant.ChangeHourMinute(6,00);
			dtpFAfterTime.Value = dtConstant.ChangeHourMinute(22,00);
			dtpFBeforeTimeForCharge.Value = dtConstant.ChangeHourMinute(6,00);
			dtpFAfterTimeForCharge.Value = dtConstant.ChangeHourMinute(22,00);
			dtConstant = null;
		}

		private void clearIsFamily()
		{
			cboPCustomer.SelectedIndex = -1;
			cboPCustomer.SelectedIndex = -1;
			TimeConstant dtConstant = new TimeConstant();
			dtpPBeforeTime.Value = dtConstant.ChangeHourMinute(6,00);
			dtpPAfterTime.Value = dtConstant.ChangeHourMinute(22,00);
			dtConstant = null;
		}

		private bool validateFamily()
		{
			if(cboFCustomerGroup.Text == "")
			{
				cboFCustomerGroup.Focus();
				Message(MessageList.Error.E0005, "ชื่อกลุ่มลูกค้า" );
				return false;
			}
			return true;
		}

		private bool validatePosition()
		{
			if(cboPCustomer.Text == "")
			{
				cboPCustomer.Focus();
				Message(MessageList.Error.E0005, "ชื่อลูกค้า" );
				return false;
			}
			return true;
		}

//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			clearForm();
			rdoPosition.Checked = true;
			rdoPosition.Focus();
		}

		public void InitEditAction(TaxiFamilyCarCondition value)
		{
			baseEDIT();
			clearForm();
			rdoFamily.Checked = true;
			gpbKindOfVehicle.Enabled = false;
			gpbPosition.Enabled = false;
			ObjTaxiFamilyCarCondition = value;
			cboFCustomerGroup.Enabled = false;
			dtpFAfterTime.Focus();

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}
		
		public void InitEditAction(TaxiPositionCarCondition value)
		{
			baseEDIT();
			clearForm();
			rdoPosition.Checked = true;
			gpbKindOfVehicle.Enabled = false;
			gpbFamily.Enabled = false;
			ObjTaxiPositionCarCondition = value;
			cboPCustomer.Enabled = false;
			dtpPAfterTime.Focus();

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
				if(rdoPosition.Checked)
				{
					if(validatePosition() && parentForm.AddRow(ObjTaxiPositionCarCondition))
					{
						clearForm();
					}
				}
				else
				{
					if(validateFamily() && parentForm.AddRow(ObjTaxiFamilyCarCondition))
					{
						clearForm();
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

		private void editEvent()
		{
			try
			{
				if(rdoPosition.Checked)
				{
					if(validatePosition() && parentForm.UpdateRow(ObjTaxiPositionCarCondition))
					{
						this.Hide();
					}
				}
				else
				{
					if(validateFamily() && parentForm.UpdateRow(ObjTaxiFamilyCarCondition))
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
		private void frmTaxiConditionEntry_Load(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
					clearForm();
					break;
				case ActionType.EDIT :
					if(rdoPosition.Checked)
					{
						clearIsPosition();
					}
					else
					{
						clearIsFamily();
					}
					break;
			}
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

		private void rdoPosition_CheckedChanged(object sender, System.EventArgs e)
		{
			if(action == ActionType.ADD)
			{
				clearForm();

				if(rdoPosition.Checked)
				{
					enableIsPosition(true);
				}
				else
				{
					enableIsPosition(false);
				}
			}
		}

		private void cboPCustomer_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cboPCustomer.Text == "")
			{
				txtPCustomerGroup.Text = "";
			}
			else
			{
				Customer customer = (Customer)cboPCustomer.SelectedItem;
				if(customer != null && customer.ACustomerGroup != null)
				{
					txtPCustomerGroup.Text = customer.ACustomerGroup.AName.English;
				}
			}
		}
	}
}
