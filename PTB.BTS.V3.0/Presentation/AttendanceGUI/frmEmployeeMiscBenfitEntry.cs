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
	public class frmEmployeeMiscBenfitEntry : EntryFormBase
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
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		protected FarPoint.Win.Input.FpDouble fpiMiscBenefit;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.fpiMiscBenefit = new FarPoint.Win.Input.FpDouble();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.fpiMiscBenefit);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtDescription);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(488, 80);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// fpiMiscBenefit
			// 
			this.fpiMiscBenefit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiMiscBenefit.AllowClipboardKeys = true;
			this.fpiMiscBenefit.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.fpiMiscBenefit.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiMiscBenefit.DecimalPlaces = 2;
			this.fpiMiscBenefit.FixedPoint = true;
			this.fpiMiscBenefit.Location = new System.Drawing.Point(104, 48);
			this.fpiMiscBenefit.Name = "fpiMiscBenefit";
			this.fpiMiscBenefit.NumberGroupSeparator = ",";
			this.fpiMiscBenefit.Size = new System.Drawing.Size(96, 20);
			this.fpiMiscBenefit.TabIndex = 2;
			this.fpiMiscBenefit.Text = "";
			this.fpiMiscBenefit.UseSeparator = true;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(208, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 24);
			this.label5.TabIndex = 8;
			this.label5.Text = "บาท";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(104, 16);
			this.txtDescription.MaxLength = 50;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(368, 20);
			this.txtDescription.TabIndex = 1;
			this.txtDescription.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 24);
			this.label4.TabIndex = 5;
			this.label4.Text = "รายละเอียด";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "จำนวนเงิน";
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(267, 104);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(179, 104);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmEmployeeMiscBenfitEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(520, 143);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmEmployeeMiscBenfitEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmEmployeeMiscBenfitEntry_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private bool isReadonly = true;
		private frmEmployeeMiscBenefit parentForm;
		#endregion

//		============================== Property ==============================
		private MiscBenefit objMiscBenefit;
		public MiscBenefit ObjMiscBenefit
		{
			set
			{
				objMiscBenefit = value;
				txtDescription.Text = value.Description;
				fpiMiscBenefit.Value = value.TotalAmount;
			}
			get
			{
				objMiscBenefit = new MiscBenefit();
				objMiscBenefit.Description = txtDescription.Text;
				objMiscBenefit.TotalAmount = Convert.ToDecimal(fpiMiscBenefit.Value);
				objMiscBenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;
				return objMiscBenefit;
			}
		}

//		============================== Constructor ==============================
		public frmEmployeeMiscBenfitEntry(frmEmployeeMiscBenefit parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeeMiscBenefit");
		}

//		============================== private method ==============================
		private void enableKeyfield(bool enable)
		{
			txtDescription.Enabled = enable;
		}

		private void clearForm()
		{
			txtDescription.Text = "";
			fpiMiscBenefit.MaxValue = 99999.99;
			fpiMiscBenefit.MinValue = 0;
			fpiMiscBenefit.Value = 0;
		}

		private bool validateForm()
		{
			if(txtDescription.Text.Trim() == "")
			{
				Message(MessageList.Error.E0002, "รายละเอียด" );
				txtDescription.Focus();
				return false;
			}
			if(Convert.ToDecimal(fpiMiscBenefit.Value) == 0)
			{
				Message(MessageList.Error.E0002, "จำนวนเงิน" );
				fpiMiscBenefit.Focus();
				return false;
			}
			return true;
		}

//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			enableKeyfield(true);
			clearForm();
			txtDescription.Focus();
		}

		public void InitEditAction(MiscBenefit value)
		{
			baseEDIT();
			enableKeyfield(false);
			clearForm();
			ObjMiscBenefit = value;

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
				if (validateForm() && parentForm.AddRow(ObjMiscBenefit))
				{
					clearForm();
					txtDescription.Focus();
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				setSelected(txtDescription);
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
				if (validateForm() && parentForm.UpdateRow(ObjMiscBenefit))
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
		private void frmEmployeeMiscBenfitEntry_Load(object sender, System.EventArgs e)
		{
		
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
	}
}
