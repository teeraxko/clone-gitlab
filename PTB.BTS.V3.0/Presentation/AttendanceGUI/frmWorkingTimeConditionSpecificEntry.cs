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
	public class frmWorkingTimeConditionSpecificEntry : EntryFormBase
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
		private System.Windows.Forms.GroupBox gpbEmployee;
		private System.Windows.Forms.TextBox txtEmployeeName;
		private System.Windows.Forms.TextBox txtEmployeeNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboWorkingTimePattern;
		private System.Windows.Forms.GroupBox gpbWorkingTime;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.gpbEmployee = new System.Windows.Forms.GroupBox();
			this.txtEmployeeName = new System.Windows.Forms.TextBox();
			this.txtEmployeeNo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.gpbWorkingTime = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cboWorkingTimePattern = new System.Windows.Forms.ComboBox();
			this.gpbEmployee.SuspendLayout();
			this.gpbWorkingTime.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdCancel.Location = new System.Drawing.Point(245, 176);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 6;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdOK.Location = new System.Drawing.Point(157, 176);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 5;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// gpbEmployee
			// 
			this.gpbEmployee.Controls.Add(this.txtEmployeeName);
			this.gpbEmployee.Controls.Add(this.txtEmployeeNo);
			this.gpbEmployee.Controls.Add(this.label2);
			this.gpbEmployee.Location = new System.Drawing.Point(17, 8);
			this.gpbEmployee.Name = "gpbEmployee";
			this.gpbEmployee.Size = new System.Drawing.Size(448, 64);
			this.gpbEmployee.TabIndex = 1;
			this.gpbEmployee.TabStop = false;
			// 
			// txtEmployeeName
			// 
			this.txtEmployeeName.Enabled = false;
			this.txtEmployeeName.Location = new System.Drawing.Point(136, 24);
			this.txtEmployeeName.Name = "txtEmployeeName";
			this.txtEmployeeName.Size = new System.Drawing.Size(296, 20);
			this.txtEmployeeName.TabIndex = 80;
			this.txtEmployeeName.TabStop = false;
			this.txtEmployeeName.Text = "";
			// 
			// txtEmployeeNo
			// 
			this.txtEmployeeNo.Location = new System.Drawing.Point(80, 24);
			this.txtEmployeeNo.MaxLength = 5;
			this.txtEmployeeNo.Name = "txtEmployeeNo";
			this.txtEmployeeNo.Size = new System.Drawing.Size(48, 20);
			this.txtEmployeeNo.TabIndex = 3;
			this.txtEmployeeNo.Text = "";
			this.txtEmployeeNo.TextChanged += new System.EventHandler(this.txtEmployeeNo_TextChanged);
			this.txtEmployeeNo.DoubleClick += new System.EventHandler(this.txtEmployeeNo_DoubleClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 80;
			this.label2.Text = "ชื่อ - สกุล";
			// 
			// gpbWorkingTime
			// 
			this.gpbWorkingTime.Controls.Add(this.label1);
			this.gpbWorkingTime.Controls.Add(this.cboWorkingTimePattern);
			this.gpbWorkingTime.Location = new System.Drawing.Point(17, 80);
			this.gpbWorkingTime.Name = "gpbWorkingTime";
			this.gpbWorkingTime.Size = new System.Drawing.Size(448, 80);
			this.gpbWorkingTime.TabIndex = 2;
			this.gpbWorkingTime.TabStop = false;
			this.gpbWorkingTime.Text = " กำหนดรูปแบบเวลาทำงาน";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 24);
			this.label1.TabIndex = 80;
			this.label1.Text = "รูปแบบ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboWorkingTimePattern
			// 
			this.cboWorkingTimePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboWorkingTimePattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboWorkingTimePattern.Location = new System.Drawing.Point(80, 32);
			this.cboWorkingTimePattern.Name = "cboWorkingTimePattern";
			this.cboWorkingTimePattern.Size = new System.Drawing.Size(352, 21);
			this.cboWorkingTimePattern.TabIndex = 4;
			// 
			// frmWorkingTimeConditionSpecificEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(482, 215);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.gpbEmployee);
			this.Controls.Add(this.gpbWorkingTime);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmWorkingTimeConditionSpecificEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmWorkingTimeConditionSpecificEntry_Load);
			this.gpbEmployee.ResumeLayout(false);
			this.gpbWorkingTime.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isTextChange = true;
		private frmWorkingTimeConditionSpecific parentForm;
		
		#endregion

		//		============================== Property ==============================
		private WorkingTimeConditionSpecific objWorkingTimeConditionSpecific;
		public WorkingTimeConditionSpecific ObjWorkingTimeConditionSpecific
		{
			get
			{
				objWorkingTimeConditionSpecific = new WorkingTimeConditionSpecific();
				objWorkingTimeConditionSpecific.AWorkingTimeTable= (WorkingTimeTable)cboWorkingTimePattern.SelectedItem;
				objWorkingTimeConditionSpecific.AEmployee = objEmployee;
				return objWorkingTimeConditionSpecific;
			}
			set
			{
				objWorkingTimeConditionSpecific = value;
				cboWorkingTimePattern.Text = value.AWorkingTimeTable.Description;				
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
		private void enableKeyField(bool enable)
		{
			gpbEmployee.Enabled = enable;
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
		
		private void setCombo()
		{
			cboWorkingTimePattern.SelectedIndex = -1;
			cboWorkingTimePattern.SelectedIndex = -1;
		}

		private void clearForm()
		{
			txtEmployeeNo.Text = "";
			txtEmployeeName.Text = "";
			setCombo();
		}

		private bool validateForm()
		{
			if(txtEmployeeNo.Text == "" || txtEmployeeNo.Text.Length != 5)
			{
				Message(MessageList.Error.E0002, "รหัสพนักงาน" );
				setSelected(txtEmployeeNo);
				return false;
			}
			if(cboWorkingTimePattern.Text == "")
			{
				Message(MessageList.Error.E0005, "รูปแบบ" );
				cboWorkingTimePattern.Focus();
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
			Employee employee = parentForm.FacadeWorkingTimeConditionSpecific.GetEmployee(empNo);
			if(validateEmployee(employee))
			{
				ObjEmployee = employee;
				return true;
			}
			setSelected(txtEmployeeNo);
			return false;
		}

//		============================== Constructor ==============================
		public frmWorkingTimeConditionSpecificEntry(frmWorkingTimeConditionSpecific parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miWorkingTimeConditionSpecific");

			try
			{			
				cboWorkingTimePattern.DataSource = parentForm.FacadeWorkingTimeConditionSpecific.DataSourceWorkingTimeTable;
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

//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			enableKeyField(true);
			clearForm();
			txtEmployeeNo.Focus();
		}

		public void InitEditAction(WorkingTimeConditionSpecific value)
		{
			baseEDIT();			
			clearForm();			
			ObjWorkingTimeConditionSpecific = value;
			ObjEmployee = value.AEmployee;
			enableKeyField(false);
			cboWorkingTimePattern.Focus();

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
				if (validateForm() && validateEmployee(txtEmployeeNo.Text) && parentForm.AddRow(ObjWorkingTimeConditionSpecific))
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
				cboWorkingTimePattern.Focus();
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
				if (parentForm.UpdateRow(ObjWorkingTimeConditionSpecific))
				{
					this.Hide();
				}
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}	
		}


//		============================== Base event ==============================
		private void frmWorkingTimeConditionSpecificEntry_Load(object sender, System.EventArgs e)
		{
			if(action == ActionType.ADD)
			{
				setCombo();
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

		private void txtEmployeeNo_TextChanged(object sender, System.EventArgs e)
		{
			if(isTextChange)
			{
				if(txtEmployeeNo.Text.Length == 5)
				{
					try
					{
						Employee employee = parentForm.FacadeWorkingTimeConditionSpecific.GetEmployee(txtEmployeeNo.Text);
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
