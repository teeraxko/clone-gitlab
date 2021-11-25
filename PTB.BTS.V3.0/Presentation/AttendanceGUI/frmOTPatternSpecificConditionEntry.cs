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
	public class frmOTPatternSpecificConditionEntry : EntryFormBase
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

		private System.Windows.Forms.ComboBox cboPattern;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.TextBox txtEmployeeNo;
		private System.Windows.Forms.TextBox txtEmployeeName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox gpbDetail;

		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			this.gpbDetail = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEmployeeName = new System.Windows.Forms.TextBox();
			this.txtEmployeeNo = new System.Windows.Forms.TextBox();
			this.cboPattern = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.gpbDetail.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbDetail
			// 
			this.gpbDetail.Controls.Add(this.label2);
			this.gpbDetail.Controls.Add(this.txtEmployeeName);
			this.gpbDetail.Controls.Add(this.txtEmployeeNo);
			this.gpbDetail.Controls.Add(this.cboPattern);
			this.gpbDetail.Controls.Add(this.label1);
			this.gpbDetail.Location = new System.Drawing.Point(8, 8);
			this.gpbDetail.Name = "gpbDetail";
			this.gpbDetail.Size = new System.Drawing.Size(440, 96);
			this.gpbDetail.TabIndex = 99;
			this.gpbDetail.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 18;
			this.label2.Text = "รหัสพนักงาน";
			// 
			// txtEmployeeName
			// 
			this.txtEmployeeName.Enabled = false;
			this.txtEmployeeName.Location = new System.Drawing.Point(160, 56);
			this.txtEmployeeName.Name = "txtEmployeeName";
			this.txtEmployeeName.Size = new System.Drawing.Size(264, 20);
			this.txtEmployeeName.TabIndex = 17;
			this.txtEmployeeName.TabStop = false;
			this.txtEmployeeName.Text = "";
			// 
			// txtEmployeeNo
			// 
			this.txtEmployeeNo.Location = new System.Drawing.Point(96, 56);
			this.txtEmployeeNo.MaxLength = 5;
			this.txtEmployeeNo.Name = "txtEmployeeNo";
			this.txtEmployeeNo.Size = new System.Drawing.Size(56, 20);
			this.txtEmployeeNo.TabIndex = 2;
			this.txtEmployeeNo.Text = "";
			this.txtEmployeeNo.TextChanged += new System.EventHandler(this.txtEmployeeNo_TextChanged);
			this.txtEmployeeNo.DoubleClick += new System.EventHandler(this.txtEmployeeNo_DoubleClick);
			// 
			// cboPattern
			// 
			this.cboPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPattern.Location = new System.Drawing.Point(96, 24);
			this.cboPattern.Name = "cboPattern";
			this.cboPattern.Size = new System.Drawing.Size(328, 21);
			this.cboPattern.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 13;
			this.label1.Text = "รูปแบบ";
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(235, 120);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(147, 120);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmOTPatternSpecificConditionEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(456, 157);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.gpbDetail);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmOTPatternSpecificConditionEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmOTPatternSpecificConditionEntry_Load);
			this.gpbDetail.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isTextChange = true;
		private frmOTPatternSpecificCondition parentForm;
		
		#endregion

//		============================== Property ==============================
		private OTPatternSpecificCondition objOTPatternSpecificCondition;
		public OTPatternSpecificCondition ObjOTPatternSpeciticCondition
		{
			get
			{
				objOTPatternSpecificCondition = new OTPatternSpecificCondition(parentForm.FacadeOTPatternSpecificCondition.GetCompany());
				objOTPatternSpecificCondition.AOTPattern = (OTPattern)cboPattern.SelectedItem;
				objOTPatternSpecificCondition.AEmployee = objEmployee;
				return objOTPatternSpecificCondition;
			}
			set
			{
				objOTPatternSpecificCondition = value;
				cboPattern.Text = value.AOTPattern.ToString();				
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
			gpbDetail.Enabled = true;

			if(cboPattern.Items.Count>0)
			{
				cboPattern.SelectedIndex = -1;
				cboPattern.SelectedIndex = -1;
				cboPattern.Text = "";
			}
		}

		private bool validateForm()
		{
			if(cboPattern.Text == "")
			{
				Message(MessageList.Error.E0005, "รูปแบบ" );
				cboPattern.Focus();
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
			Employee employee = parentForm.FacadeOTPatternSpecificCondition.GetEmployee(empNo);
			if(validateEmployee(employee))
			{
				ObjEmployee = employee;
				return true;
			}
			setSelected(txtEmployeeNo);
			return false;
		}

//		============================== Constructor ==============================
		public frmOTPatternSpecificConditionEntry(frmOTPatternSpecificCondition parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miOTPatternSpecificCondition");

			try
			{			
				cboPattern.DataSource = parentForm.FacadeOTPatternSpecificCondition.DataSourceOTPattern;
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
			clearForm();			
		}

		public void InitEditAction(OTPatternSpecificCondition value)
		{
			baseEDIT();			
			clearForm();			
			ObjOTPatternSpeciticCondition = value;
			ObjEmployee = value.AEmployee;
			gpbDetail.Enabled = false;
			cmdOK.Enabled = false;

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
				if (validateForm() && validateEmployee(txtEmployeeNo.Text) && parentForm.AddRow(ObjOTPatternSpeciticCondition))
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
				cboPattern.Focus();
			}
			catch(Exception ex)
			{
				Message(ex);
			}		
		}

//		============================== Base event ==============================
		private void frmOTPatternSpecificConditionEntry_Load(object sender, System.EventArgs e)
		{}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			addEvent();
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
						Employee employee = parentForm.FacadeOTPatternSpecificCondition.GetEmployee(txtEmployeeNo.Text);
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
