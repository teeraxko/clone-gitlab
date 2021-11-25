using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.AttendanceEntities;
using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

using Facade.AttendanceFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;
using Presentation.PiGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmTelephoneConditionEntry : EntryFormBase
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		protected FarPoint.Win.Input.FpDouble fpiTelephone;
		private System.Windows.Forms.TextBox txtEmployeeName;
		private System.Windows.Forms.TextBox txtEmployeeNo;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtEmployeeName = new System.Windows.Forms.TextBox();
			this.txtEmployeeNo = new System.Windows.Forms.TextBox();
			this.fpiTelephone = new FarPoint.Win.Input.FpDouble();
			this.label3 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "ค่าโทรศัพท์";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "ชื่อ - สกุล";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtEmployeeName);
			this.groupBox1.Controls.Add(this.txtEmployeeNo);
			this.groupBox1.Controls.Add(this.fpiTelephone);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(456, 96);
			this.groupBox1.TabIndex = 99;
			this.groupBox1.TabStop = false;
			// 
			// txtEmployeeName
			// 
			this.txtEmployeeName.Enabled = false;
			this.txtEmployeeName.Location = new System.Drawing.Point(160, 24);
			this.txtEmployeeName.Name = "txtEmployeeName";
			this.txtEmployeeName.Size = new System.Drawing.Size(272, 20);
			this.txtEmployeeName.TabIndex = 19;
			this.txtEmployeeName.TabStop = false;
			this.txtEmployeeName.Text = "";
			// 
			// txtEmployeeNo
			// 
			this.txtEmployeeNo.Location = new System.Drawing.Point(96, 24);
			this.txtEmployeeNo.MaxLength = 5;
			this.txtEmployeeNo.Name = "txtEmployeeNo";
			this.txtEmployeeNo.Size = new System.Drawing.Size(56, 20);
			this.txtEmployeeNo.TabIndex = 1;
			this.txtEmployeeNo.Text = "";
			this.txtEmployeeNo.TextChanged += new System.EventHandler(this.txtEmployeeNo_TextChanged);
			this.txtEmployeeNo.DoubleClick += new System.EventHandler(this.txtEmployeeNo_DoubleClick);
			// 
			// fpiTelephone
			// 
			this.fpiTelephone.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiTelephone.AllowClipboardKeys = true;
			this.fpiTelephone.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.fpiTelephone.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiTelephone.DecimalPlaces = 0;
			this.fpiTelephone.FixedPoint = true;
			this.fpiTelephone.Location = new System.Drawing.Point(96, 56);
			this.fpiTelephone.Name = "fpiTelephone";
			this.fpiTelephone.NumberGroupSeparator = ",";
			this.fpiTelephone.Size = new System.Drawing.Size(56, 20);
			this.fpiTelephone.TabIndex = 2;
			this.fpiTelephone.Text = "";
			this.fpiTelephone.UseSeparator = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(160, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "บาท";
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(248, 120);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(165, 120);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmTelephoneConditionEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(488, 157);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmTelephoneConditionEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmTelephoneConditionEntry_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isTextChange = true;
		private frmTelephoneCondition parentForm;
		#endregion

//		============================== Property ==============================
		private TelephoneCondition objTelephoneCondition;
		public TelephoneCondition ObjTelephoneCondition
		{
			set
			{
				objTelephoneCondition = value;
				txtEmployeeNo.Text = value.AEmployee.EmployeeNo;
				txtEmployeeName.Text = value.AEmployee.EmployeeName;
				fpiTelephone.Value = value.TelephoneRate;
			}
			get
			{
				objTelephoneCondition = new TelephoneCondition();
				objTelephoneCondition.AEmployee = objEmployee;
				objTelephoneCondition.TelephoneRate = Convert.ToInt16(fpiTelephone.Value);
				return objTelephoneCondition;
			}
		}

		private Employee objEmployee;
		private Employee ObjEmployee
		{
			set
			{
				objEmployee = value;
				isTextChange = false;
				txtEmployeeNo.Text = value.EmployeeNo;
				txtEmployeeName.Text = value.EmployeeName;
				isTextChange = true;
			}		
		}

//		============================== private method ==============================
		private void enableKeyfield(bool enable)
		{
			txtEmployeeNo.Enabled = enable;
		}

		private void formEmployeeList()
		{
			frmEmplist dialogEmplist = new frmEmplist();
			dialogEmplist.ShowDialog();			
			if(dialogEmplist.Selected)
			{
				ObjEmployee = dialogEmplist.SelectedEmployee;
			}		
		}

		private void clearForm()
		{
			txtEmployeeNo.Text = "";
			txtEmployeeName.Text = "";
			fpiTelephone.Value = 0;
			fpiTelephone.MaxValue = 9999;
			fpiTelephone.MinValue = 0;
		}

		private bool validateForm()
		{
			if(Convert.ToInt16(fpiTelephone.Value) == 0)
			{
				Message(MessageList.Error.E0002, "จำนวนเงิน" );
				fpiTelephone.Focus();
				return false;
			}
			if(txtEmployeeNo.Text == "" || txtEmployeeNo.Text.Length != 5)
			{
				Message(MessageList.Error.E0002, "รหัสพนักงาน" );
				setSelected(txtEmployeeNo);
				return false;
			}	
			return true;
		}

		private bool validateEmployee(Employee employee)
		{
			if(employee == null)
			{
				Message(MessageList.Error.E0004, "รหัสพนักงาน" );
				setSelected(txtEmployeeNo);
				return false;
			}
			return true;		
		}

		private bool validateEmployee(string empNo)
		{
			Employee employee = parentForm.FacadeTelephoneCondition.GetEmployee(empNo);
			if(validateEmployee(employee))
			{
				ObjEmployee = employee;
				return true;
			}
			setSelected(txtEmployeeNo);
			return false;
		}

//		============================== Constructor ==============================
		public frmTelephoneConditionEntry(frmTelephoneCondition parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miTelephoneCondition");
		}

//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			enableKeyfield(true);
			clearForm();		
			txtEmployeeNo.Focus();
		}

		public void InitEditAction(TelephoneCondition value)
		{
			baseEDIT();
			enableKeyfield(false);
			clearForm();
			ObjTelephoneCondition = value;
			fpiTelephone.Focus();

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
				if (validateForm() && validateEmployee(txtEmployeeNo.Text) && parentForm.AddRow(ObjTelephoneCondition))
				{
					clearForm();
					txtEmployeeNo.Focus();
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				setSelected(txtEmployeeNo);
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
				if (validateForm() && parentForm.UpdateRow(ObjTelephoneCondition))
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

//		============================== Base event ==============================
		private void frmTelephoneConditionEntry_Load(object sender, System.EventArgs e)
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

		private void txtEmployeeNo_TextChanged(object sender, System.EventArgs e)
		{
			if(isTextChange)
			{
				if(txtEmployeeNo.Text.Length == 5)
				{
					try
					{
						Employee employee = parentForm.FacadeTelephoneCondition.GetEmployee(txtEmployeeNo.Text);
						if(validateEmployee(employee))
						{
							ObjEmployee = employee;
						}
					}
					catch(SqlException sqlex)
					{
						Message(sqlex);
					}
					catch(AppExceptionBase ex)
					{
						Message(ex);
						setSelected(txtEmployeeNo);
					}
					catch(Exception ex)
					{
						Message(ex);
					}
				}
			}
		}

		private void txtEmployeeNo_DoubleClick(object sender, System.EventArgs e)
		{
			formEmployeeList();
		}
	}
}
