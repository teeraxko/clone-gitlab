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
	public class frmHolidayConditionSpecificEntry : EntryFormBase
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

		private System.Windows.Forms.TextBox txtEmployeeName;
		private System.Windows.Forms.TextBox txtEmployeeNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboHoliday;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.CheckBox chkSaturday;
		private System.Windows.Forms.CheckBox chkSunday;
		private System.Windows.Forms.GroupBox gpbEmployee;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.gpbEmployee = new System.Windows.Forms.GroupBox();
			this.txtEmployeeName = new System.Windows.Forms.TextBox();
			this.txtEmployeeNo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cboHoliday = new System.Windows.Forms.ComboBox();
			this.chkSunday = new System.Windows.Forms.CheckBox();
			this.chkSaturday = new System.Windows.Forms.CheckBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.gpbEmployee.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbEmployee
			// 
			this.gpbEmployee.Controls.Add(this.txtEmployeeName);
			this.gpbEmployee.Controls.Add(this.txtEmployeeNo);
			this.gpbEmployee.Controls.Add(this.label2);
			this.gpbEmployee.Location = new System.Drawing.Point(16, 8);
			this.gpbEmployee.Name = "gpbEmployee";
			this.gpbEmployee.Size = new System.Drawing.Size(440, 64);
			this.gpbEmployee.TabIndex = 0;
			this.gpbEmployee.TabStop = false;
			// 
			// txtEmployeeName
			// 
			this.txtEmployeeName.Enabled = false;
			this.txtEmployeeName.Location = new System.Drawing.Point(160, 24);
			this.txtEmployeeName.Name = "txtEmployeeName";
			this.txtEmployeeName.Size = new System.Drawing.Size(264, 20);
			this.txtEmployeeName.TabIndex = 11;
			this.txtEmployeeName.Text = "";
			// 
			// txtEmployeeNo
			// 
			this.txtEmployeeNo.Location = new System.Drawing.Point(104, 24);
			this.txtEmployeeNo.MaxLength = 5;
			this.txtEmployeeNo.Name = "txtEmployeeNo";
			this.txtEmployeeNo.Size = new System.Drawing.Size(48, 20);
			this.txtEmployeeNo.TabIndex = 10;
			this.txtEmployeeNo.Text = "";
			this.txtEmployeeNo.TextChanged += new System.EventHandler(this.txtEmployeeNo_TextChanged);
			this.txtEmployeeNo.DoubleClick += new System.EventHandler(this.txtEmployeeNo_DoubleClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "ชื่อ - สกุล";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.cboHoliday);
			this.groupBox2.Controls.Add(this.chkSunday);
			this.groupBox2.Controls.Add(this.chkSaturday);
			this.groupBox2.Location = new System.Drawing.Point(16, 80);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(440, 104);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "กำหนดวันหยุด";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label1.Location = new System.Drawing.Point(16, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 24);
			this.label1.TabIndex = 30;
			this.label1.Text = "วันหยุดนักขัตฤกษ์";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboHoliday
			// 
			this.cboHoliday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboHoliday.Location = new System.Drawing.Point(120, 64);
			this.cboHoliday.Name = "cboHoliday";
			this.cboHoliday.Size = new System.Drawing.Size(312, 21);
			this.cboHoliday.TabIndex = 29;
			// 
			// chkSunday
			// 
			this.chkSunday.Location = new System.Drawing.Point(136, 24);
			this.chkSunday.Name = "chkSunday";
			this.chkSunday.TabIndex = 1;
			this.chkSunday.Text = " วันอาทิตย์";
			// 
			// chkSaturday
			// 
			this.chkSaturday.Location = new System.Drawing.Point(16, 24);
			this.chkSaturday.Name = "chkSaturday";
			this.chkSaturday.TabIndex = 0;
			this.chkSaturday.Text = " วันเสาร์";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdCancel.Location = new System.Drawing.Point(243, 200);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 16;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdOK.Location = new System.Drawing.Point(155, 200);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 15;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmHolidayConditionSpecificEntry
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 237);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.gpbEmployee);
			this.Controls.Add(this.groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmHolidayConditionSpecificEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmHolidayConditionSpecificEntry_Load);
			this.gpbEmployee.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isTextChange = true;
		private frmHolidayConditionSpecific parentForm;
		#endregion

//		============================== Property ==============================
		private HolidayConditionSpecific objHolidayConditionSpecific;
		public HolidayConditionSpecific ObjHolidayConditionSpecific
		{			
			set
			{
				objHolidayConditionSpecific = value;

				if(value.SaturdayBreak)
				{
					chkSaturday.Checked = true; 
				}
				else
				{
					chkSaturday.Checked = false;
				}

				if(value.SundayBreak)
				{
					chkSunday.Checked = true; 
				}
				else
				{
					chkSunday.Checked = false;
				}	
			
				if(value.ATraditionalHolidayPattern != null  && value.ATraditionalHolidayPattern.AName.Thai != "")
				{
					cboHoliday.Text = value.ATraditionalHolidayPattern.AName.Thai;
				}
			}

			get
			{
				objHolidayConditionSpecific = new HolidayConditionSpecific();
		
				if(chkSaturday.Checked)
				{
					objHolidayConditionSpecific.SaturdayBreak = true;				
				}
				else
				{
					objHolidayConditionSpecific.SaturdayBreak = false;	
				}

				if(chkSunday.Checked)
				{
					objHolidayConditionSpecific.SundayBreak = true;				
				}
				else
				{
					objHolidayConditionSpecific.SundayBreak = false;	
				}

				objHolidayConditionSpecific.ATraditionalHolidayPattern = (TraditionalHolidayPattern)cboHoliday.SelectedItem;
				objHolidayConditionSpecific.AEmployee = objEmployee;
				return objHolidayConditionSpecific;
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

//		============================== Constructor ==============================
		public frmHolidayConditionSpecificEntry(frmHolidayConditionSpecific parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miHolidayConditionSpecific");

			try
			{			
				cboHoliday.DataSource = parentForm.FacadeHolidayConditionSpecific.DataSourceTraditionalHolidayPattern;
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
		private void formEmployeeList()
		{
			frmEmplist dialogEmplist = new frmEmplist();
			dialogEmplist.ShowDialog();			
			if(dialogEmplist.Selected)
			{
				ObjEmployee = dialogEmplist.SelectedEmployee;
			}		
		}

		private void setHolidayConditionSpecific()
		{
			if(chkSaturday.Checked)
			{
				objHolidayConditionSpecific.SaturdayBreak = true;				
			}
			else
			{
				objHolidayConditionSpecific.SaturdayBreak = false;	
			}

			if(chkSunday.Checked)
			{
				objHolidayConditionSpecific.SundayBreak = true;				
			}
			else
			{
				objHolidayConditionSpecific.SundayBreak = false;	
			}

			objHolidayConditionSpecific.ATraditionalHolidayPattern = (TraditionalHolidayPattern)cboHoliday.SelectedItem;
		}

		private void clearForm()
		{
			txtEmployeeNo.Text = "";
			txtEmployeeName.Text = "";
			chkSaturday.Checked = false;
			chkSunday.Checked = false;
			initComboHoliday();
		}

		private bool validateForm()
		{
			if(txtEmployeeNo.Text == "" || txtEmployeeNo.Text.Length != 5)
			{
				Message(MessageList.Error.E0002, "รหัสพนักงาน" );
				txtEmployeeNo.Focus();
				return false;
			}
			return true;
		}

		private bool validateEmployee(Employee employee)
		{
			if(employee == null)
			{
				Message(MessageList.Error.E0004, "รหัสพนักงาน" );
				txtEmployeeNo.Focus();
				return false;
			}
			return true;		
		}

		private void enableKeyField(bool enable)
		{
			gpbEmployee.Enabled = enable;
		}

		private void initComboHoliday()
		{
			if(cboHoliday.Items.Count>0)
			{
				cboHoliday.SelectedIndex = -1;
				cboHoliday.SelectedIndex = -1;
				cboHoliday.Text = "";
			}
		}

//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			enableKeyField(true);
			clearForm();
		}

		public void InitEditAction(HolidayConditionSpecific value)
		{
			baseEDIT();			
			clearForm();			
			ObjHolidayConditionSpecific = value;
			ObjEmployee = value.AEmployee;
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
				if (validateForm() && validateEmployee(objEmployee) && parentForm.AddRow(ObjHolidayConditionSpecific))
				{
					clearForm();
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

		private void EditEvent()
		{
			try
			{
				setHolidayConditionSpecific();

				if (validateForm() && parentForm.UpdateRow(objHolidayConditionSpecific))
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

//		============================== event ==============================
		private void frmHolidayConditionSpecificEntry_Load(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
					initComboHoliday();	
					break;
				case ActionType.EDIT :
					if(objHolidayConditionSpecific.ATraditionalHolidayPattern == null || objHolidayConditionSpecific.ATraditionalHolidayPattern.AName.Thai == "")
					{
						initComboHoliday();
					}
					break;
			}
		}

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

		private void txtEmployeeNo_TextChanged(object sender, System.EventArgs e)
		{
			if(isTextChange)
			{
				if(txtEmployeeNo.Text.Length == 5)
				{
					try
					{
						Employee employee = parentForm.FacadeHolidayConditionSpecific.GetEmployee(txtEmployeeNo.Text);
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
