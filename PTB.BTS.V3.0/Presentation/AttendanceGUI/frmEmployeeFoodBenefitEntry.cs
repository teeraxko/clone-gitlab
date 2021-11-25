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

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeFoodBenefitEntry : EntryFormBase
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
		private System.Windows.Forms.DateTimePicker dtpForDay;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdCancel;
		protected FarPoint.Win.Input.FpDouble fpdFoodBenefit;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.dtpForDay = new System.Windows.Forms.DateTimePicker();
			this.cmdOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.fpdFoodBenefit = new FarPoint.Win.Input.FpDouble();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dtpForDay
			// 
			this.dtpForDay.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dtpForDay.CustomFormat = "dd";
			this.dtpForDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpForDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpForDay.Location = new System.Drawing.Point(96, 27);
			this.dtpForDay.Name = "dtpForDay";
			this.dtpForDay.ShowUpDown = true;
			this.dtpForDay.Size = new System.Drawing.Size(40, 20);
			this.dtpForDay.TabIndex = 1;
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(55, 136);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.fpdFoodBenefit);
			this.groupBox1.Controls.Add(this.dtpForDay);
			this.groupBox1.Location = new System.Drawing.Point(18, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(236, 101);
			this.groupBox1.TabIndex = 28;
			this.groupBox1.TabStop = false;
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label8.Location = new System.Drawing.Point(24, 27);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 23);
			this.label8.TabIndex = 22;
			this.label8.Text = "สำหรับวันที่";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label3.Location = new System.Drawing.Point(192, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "บาท";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.Location = new System.Drawing.Point(24, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "จำนวนเงิน";
			// 
			// fpdFoodBenefit
			// 
			this.fpdFoodBenefit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpdFoodBenefit.AllowClipboardKeys = true;
			this.fpdFoodBenefit.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.fpdFoodBenefit.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpdFoodBenefit.DecimalPlaces = 0;
			this.fpdFoodBenefit.FixedPoint = true;
			this.fpdFoodBenefit.Location = new System.Drawing.Point(96, 59);
			this.fpdFoodBenefit.Name = "fpdFoodBenefit";
			this.fpdFoodBenefit.NumberGroupSeparator = ",";
			this.fpdFoodBenefit.Size = new System.Drawing.Size(88, 20);
			this.fpdFoodBenefit.TabIndex = 2;
			this.fpdFoodBenefit.Text = "";
			this.fpdFoodBenefit.UseSeparator = true;
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(143, 136);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmEmployeeFoodBenefitEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(272, 181);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmdCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmEmployeeFoodBenefitEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmEmployeeFoodBenefitEntry";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private bool isReadonly = true;
		private frmEmployeeFoodBenefit parentForm;
		#endregion

//		============================== Property ==============================
		private FoodBenefit objFoodBenefit;
		public FoodBenefit ObjFoodBenefit
		{
			set
			{
				objFoodBenefit = value;
				dtpForDay.Value = value.BenefitDate;
				fpdFoodBenefit.Value = value.TotalAmount;
			}
			get
			{
				objFoodBenefit = new FoodBenefit();
				objFoodBenefit.BenefitDate = dtpForDay.Value.Date;
				objFoodBenefit.TotalAmount = Convert.ToDecimal(fpdFoodBenefit.Value);
				objFoodBenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;
				return objFoodBenefit;
			}
		}

//		============================== Constructor ==============================
		public frmEmployeeFoodBenefitEntry(frmEmployeeFoodBenefit parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeeFoodBenefit");
		}

//		============================== private method ==============================
		private void enableKeyField(bool enable)
		{
			dtpForDay.Enabled = enable;
		}

		private void clearForm()
		{
			fpdFoodBenefit.MaxValue = 9999;
			fpdFoodBenefit.MinValue = 0;
			fpdFoodBenefit.Value = 0;
		}

		private bool validateForm()
		{
			if(Convert.ToDecimal(fpdFoodBenefit.Value) == 0)
			{
				Message(MessageList.Error.E0002, "จำนวนเงิน" );
				fpdFoodBenefit.Focus();
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
			dtpForDay.Value = DateTime.Today;
			setDTPForMonth(dtpForDay, value);
		}

		public void InitEditAction(FoodBenefit value)
		{
			baseEDIT();
			clearForm();
			ObjFoodBenefit = value;
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
				if (validateForm() && parentForm.AddRow(ObjFoodBenefit))
				{
					clearForm();
					dtpForDay.Focus();
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				dtpForDay.Focus();
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
				if (validateForm() && parentForm.UpdateRow(ObjFoodBenefit))
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
