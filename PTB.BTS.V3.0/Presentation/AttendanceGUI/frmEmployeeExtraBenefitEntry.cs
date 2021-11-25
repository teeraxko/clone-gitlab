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

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

using ictus.Common.Entity.Time;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeExtraBenefitEntry : EntryFormBase
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
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.DateTimePicker dtpForMonth;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		protected FarPoint.Win.Input.FpDouble fpdBenefit;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.fpdBenefit = new FarPoint.Win.Input.FpDouble();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(139, 128);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 24);
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(51, 128);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 24);
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// dtpForMonth
			// 
			this.dtpForMonth.CustomFormat = "MM";
			this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpForMonth.Location = new System.Drawing.Point(72, 24);
			this.dtpForMonth.Name = "dtpForMonth";
			this.dtpForMonth.ShowUpDown = true;
			this.dtpForMonth.Size = new System.Drawing.Size(40, 20);
			this.dtpForMonth.TabIndex = 1;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.fpdBenefit);
			this.groupBox3.Controls.Add(this.dtpForMonth);
			this.groupBox3.Location = new System.Drawing.Point(16, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(232, 104);
			this.groupBox3.TabIndex = 30;
			this.groupBox3.TabStop = false;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label6.Location = new System.Drawing.Point(8, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 22;
			this.label6.Text = "สำหรับเดือน";
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label7.Location = new System.Drawing.Point(168, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 23);
			this.label7.TabIndex = 10;
			this.label7.Text = "บาท";
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label9.Location = new System.Drawing.Point(8, 56);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 23);
			this.label9.TabIndex = 2;
			this.label9.Text = "จำนวนเงิน";
			// 
			// fpdBenefit
			// 
			this.fpdBenefit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpdBenefit.AllowClipboardKeys = true;
			this.fpdBenefit.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.fpdBenefit.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpdBenefit.DecimalPlaces = 0;
			this.fpdBenefit.FixedPoint = true;
			this.fpdBenefit.Location = new System.Drawing.Point(72, 56);
			this.fpdBenefit.Name = "fpdBenefit";
			this.fpdBenefit.NumberGroupSeparator = ",";
			this.fpdBenefit.Size = new System.Drawing.Size(88, 20);
			this.fpdBenefit.TabIndex = 2;
			this.fpdBenefit.Text = "";
			this.fpdBenefit.UseSeparator = true;
			// 
			// frmEmployeeExtraBenefitEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(264, 173);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmEmployeeExtraBenefitEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmEmployeeExtraBenefitEntry";
			this.Load += new System.EventHandler(this.frmEmployeeExtraBenefitEntry_Load);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private bool isReadonly = true;
		private frmEmployeeExtraBenefit parentForm;
		#endregion

		//		============================== Property ==============================
		private ExtraBenefit objExtraBenefit;
		public ExtraBenefit ObjExtraBenefit
		{
			set
			{
				objExtraBenefit = value;
				dtpForMonth.Value = value.AYearMonth.DateTime;
				fpdBenefit.Value = value.TotalAmount;
			}
			get
			{
				objExtraBenefit = new ExtraBenefit();
				YearMonth yearMonth = new YearMonth(dtpForMonth.Value);
				objExtraBenefit.AYearMonth = yearMonth;
				objExtraBenefit.TotalAmount = Convert.ToDecimal(fpdBenefit.Value);

				if(!fpdBenefit.Text.Equals("0"))
				{
					objExtraBenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.YES;				
				}
				return objExtraBenefit;
			}
		}

		//		============================== Constructor ==============================
		public frmEmployeeExtraBenefitEntry(frmEmployeeExtraBenefit parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeeExtraBenefit");
		}

		//		============================== private method ==============================
		private void enableKeyField(bool enable)
		{
			dtpForMonth.Enabled = enable;
		}

		private void clearForm()
		{
			fpdBenefit.MaxValue = 9999;
			fpdBenefit.MinValue = 0;
			fpdBenefit.Value = 0;
		}

		private bool validateForm()
		{
			if(Convert.ToDecimal(fpdBenefit.Value) == 0)
			{
				Message(MessageList.Error.E0002, "จำนวนเงิน" );
				fpdBenefit.Focus();
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

		public void InitEditAction(ExtraBenefit value)
		{
			baseEDIT();
			clearForm();
			ObjExtraBenefit = value;
			enableKeyField(false);

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
				if (validateForm() && parentForm.AddRow(ObjExtraBenefit))
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

		private void editEvent()
		{
			try
			{				
				if (validateForm() && parentForm.UpdateRow(ObjExtraBenefit))
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
		private void frmEmployeeExtraBenefitEntry_Load(object sender, System.EventArgs e)
		{}

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
	}
}
