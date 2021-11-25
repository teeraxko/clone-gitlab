using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppException;
using SystemFramework.AppMessage;

using ictus.Common.Entity.Time;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeTelephoneBenefitEntry : EntryFormBase
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
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DateTimePicker dtpForMonth;
		protected FarPoint.Win.Input.FpDouble fpdTelephone;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.cmdOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.fpdTelephone = new FarPoint.Win.Input.FpDouble();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(55, 120);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.dtpForMonth);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.fpdTelephone);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(240, 96);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label8.Location = new System.Drawing.Point(16, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 23);
			this.label8.TabIndex = 22;
			this.label8.Text = "สำหรับเดือน";
			// 
			// dtpForMonth
			// 
			this.dtpForMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dtpForMonth.CustomFormat = "MM";
			this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpForMonth.Location = new System.Drawing.Point(80, 24);
			this.dtpForMonth.Name = "dtpForMonth";
			this.dtpForMonth.ShowUpDown = true;
			this.dtpForMonth.Size = new System.Drawing.Size(40, 20);
			this.dtpForMonth.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label3.Location = new System.Drawing.Point(176, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "บาท";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "จำนวนเงิน";
			// 
			// fpdTelephone
			// 
			this.fpdTelephone.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpdTelephone.AllowClipboardKeys = true;
			this.fpdTelephone.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.fpdTelephone.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpdTelephone.DecimalPlaces = 0;
			this.fpdTelephone.FixedPoint = true;
			this.fpdTelephone.Location = new System.Drawing.Point(80, 56);
			this.fpdTelephone.Name = "fpdTelephone";
			this.fpdTelephone.NumberGroupSeparator = ",";
			this.fpdTelephone.Size = new System.Drawing.Size(88, 20);
			this.fpdTelephone.TabIndex = 2;
			this.fpdTelephone.Text = "";
			this.fpdTelephone.UseSeparator = true;
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(143, 120);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmEmployeeTelephoneBenefitEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(272, 158);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmdCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmEmployeeTelephoneBenefitEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmEmployeeTelephoneBenefitEntry_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private bool isReadonly = true;
		private frmEmployeeTelephoneBenefit parentForm;
		#endregion

//		============================== Property ==============================
		private TelephoneBenefit objTelephoneBenefit;
		public TelephoneBenefit ObjTelephoneBenefit
		{
			set
			{
				objTelephoneBenefit = value;
				dtpForMonth.Value = value.AYearMonth.DateTime;
				fpdTelephone.Value = value.TotalAmount;
			}
			get
			{
				objTelephoneBenefit = new TelephoneBenefit();
				YearMonth yearMonth = new YearMonth(dtpForMonth.Value);
				objTelephoneBenefit.AYearMonth = yearMonth;
				objTelephoneBenefit.TotalAmount = Convert.ToDecimal(fpdTelephone.Value);
				objTelephoneBenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;
				return objTelephoneBenefit;
			}
		}

//		============================== Constructor ==============================
		public frmEmployeeTelephoneBenefitEntry(frmEmployeeTelephoneBenefit parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeeTelephoneBenefit");
		}	

//		============================== private method ==============================
		private void enableKeyField(bool enable)
		{
			dtpForMonth.Enabled = enable;
		}

		private void clearForm()
		{
			fpdTelephone.MaxValue = 9999;
			fpdTelephone.MinValue = 0;
			fpdTelephone.Value = 0;
		}

		private bool validateForm()
		{
			if(Convert.ToDecimal(fpdTelephone.Value) == 0)
			{
				Message(MessageList.Error.E0002, "จำนวนเงิน" );
				fpdTelephone.Focus();
				return false;
			}
			return true;
		}

//		============================== public method ==============================
		public void InitAddAction(DateTime value)
		{
			baseADD();
			clearForm();
			enableKeyField(true);
			setDTPForYear(dtpForMonth, value);
			dtpForMonth.Value = new System.DateTime(value.Year, 1, 1, 0, 0, 0, 0);
			dtpForMonth.Focus();
		}

		public void InitEditAction(TelephoneBenefit value)
		{
			baseEDIT();
			clearForm();
			ObjTelephoneBenefit = value;
			enableKeyField(false);

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}

//		============================== Base event ==============================
		private void AddEvent()
		{
			try
			{				
				if (validateForm() && parentForm.AddRow(ObjTelephoneBenefit))
				{
					clearForm();
					dtpForMonth.Focus();
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				dtpForMonth.Focus();
			}
			catch(Exception ex)
			{
				Message(ex);
			}		
		}

		private void EditEvent()
		{
			try
			{				
				if (validateForm() && parentForm.UpdateRow(ObjTelephoneBenefit))
				{
					this.Hide();
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
		}
		
//		================================= event ================================
		private void frmEmployeeTelephoneBenefitEntry_Load(object sender, System.EventArgs e)
		{}

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
	}
}
