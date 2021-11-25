using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.AttendanceEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;
using ictus.PIS.PI.Entity;

using Facade.AttendanceFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmHolidayConditionEntry : EntryFormBase
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
		private System.Windows.Forms.CheckBox chkSunday;
		private System.Windows.Forms.CheckBox chkSaturday;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboServiceStaffType;
		private System.Windows.Forms.ComboBox cboCustomer;
		private System.Windows.Forms.ComboBox cboCustomerDept;
		private System.Windows.Forms.GroupBox gpbHoliday;
		private System.Windows.Forms.GroupBox gpbPositionType;
		private System.Windows.Forms.GroupBox gpbServiceStaffType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboHoliday;
		private System.Windows.Forms.RadioButton rdoServiceStaff;
		private System.Windows.Forms.RadioButton rdoOfficeStaff;
	
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.gpbHoliday = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cboHoliday = new System.Windows.Forms.ComboBox();
			this.chkSaturday = new System.Windows.Forms.CheckBox();
			this.chkSunday = new System.Windows.Forms.CheckBox();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.gpbPositionType = new System.Windows.Forms.GroupBox();
			this.rdoServiceStaff = new System.Windows.Forms.RadioButton();
			this.rdoOfficeStaff = new System.Windows.Forms.RadioButton();
			this.gpbServiceStaffType = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cboServiceStaffType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cboCustomer = new System.Windows.Forms.ComboBox();
			this.cboCustomerDept = new System.Windows.Forms.ComboBox();
			this.gpbHoliday.SuspendLayout();
			this.gpbPositionType.SuspendLayout();
			this.gpbServiceStaffType.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbHoliday
			// 
			this.gpbHoliday.Controls.Add(this.label1);
			this.gpbHoliday.Controls.Add(this.cboHoliday);
			this.gpbHoliday.Controls.Add(this.chkSaturday);
			this.gpbHoliday.Controls.Add(this.chkSunday);
			this.gpbHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.gpbHoliday.Location = new System.Drawing.Point(8, 200);
			this.gpbHoliday.Name = "gpbHoliday";
			this.gpbHoliday.Size = new System.Drawing.Size(440, 96);
			this.gpbHoliday.TabIndex = 5;
			this.gpbHoliday.TabStop = false;
			this.gpbHoliday.Text = "กำหนดวันหยุด";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 24);
			this.label1.TabIndex = 28;
			this.label1.Text = "วันหยุดนักขัตฤกษ์";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboHoliday
			// 
			this.cboHoliday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboHoliday.Location = new System.Drawing.Point(112, 56);
			this.cboHoliday.Name = "cboHoliday";
			this.cboHoliday.Size = new System.Drawing.Size(248, 21);
			this.cboHoliday.TabIndex = 27;
			// 
			// chkSaturday
			// 
			this.chkSaturday.Location = new System.Drawing.Point(16, 24);
			this.chkSaturday.Name = "chkSaturday";
			this.chkSaturday.Size = new System.Drawing.Size(72, 24);
			this.chkSaturday.TabIndex = 8;
			this.chkSaturday.Text = "วันเสาร์";
			// 
			// chkSunday
			// 
			this.chkSunday.Location = new System.Drawing.Point(112, 24);
			this.chkSunday.Name = "chkSunday";
			this.chkSunday.Size = new System.Drawing.Size(80, 24);
			this.chkSunday.TabIndex = 9;
			this.chkSunday.Text = "วันอาทิตย์";
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdOK.Location = new System.Drawing.Point(148, 312);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 13;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdCancel.Location = new System.Drawing.Point(236, 312);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 14;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// gpbPositionType
			// 
			this.gpbPositionType.Controls.Add(this.rdoServiceStaff);
			this.gpbPositionType.Controls.Add(this.rdoOfficeStaff);
			this.gpbPositionType.Location = new System.Drawing.Point(8, 8);
			this.gpbPositionType.Name = "gpbPositionType";
			this.gpbPositionType.Size = new System.Drawing.Size(440, 56);
			this.gpbPositionType.TabIndex = 23;
			this.gpbPositionType.TabStop = false;
			this.gpbPositionType.Text = "ประเภทตำแหน่ง";
			// 
			// rdoServiceStaff
			// 
			this.rdoServiceStaff.Checked = true;
			this.rdoServiceStaff.Location = new System.Drawing.Point(88, 24);
			this.rdoServiceStaff.Name = "rdoServiceStaff";
			this.rdoServiceStaff.Size = new System.Drawing.Size(112, 24);
			this.rdoServiceStaff.TabIndex = 24;
			this.rdoServiceStaff.TabStop = true;
			this.rdoServiceStaff.Text = "พนักงานบริการ";
			// 
			// rdoOfficeStaff
			// 
			this.rdoOfficeStaff.Location = new System.Drawing.Point(248, 24);
			this.rdoOfficeStaff.Name = "rdoOfficeStaff";
			this.rdoOfficeStaff.Size = new System.Drawing.Size(112, 24);
			this.rdoOfficeStaff.TabIndex = 23;
			this.rdoOfficeStaff.Text = "พนักงานสำนักงาน";
			this.rdoOfficeStaff.CheckedChanged += new System.EventHandler(this.rdoOfficeStaff_CheckedChanged);
			// 
			// gpbServiceStaffType
			// 
			this.gpbServiceStaffType.Controls.Add(this.label5);
			this.gpbServiceStaffType.Controls.Add(this.label2);
			this.gpbServiceStaffType.Controls.Add(this.cboServiceStaffType);
			this.gpbServiceStaffType.Controls.Add(this.label3);
			this.gpbServiceStaffType.Controls.Add(this.cboCustomer);
			this.gpbServiceStaffType.Controls.Add(this.cboCustomerDept);
			this.gpbServiceStaffType.Location = new System.Drawing.Point(8, 72);
			this.gpbServiceStaffType.Name = "gpbServiceStaffType";
			this.gpbServiceStaffType.Size = new System.Drawing.Size(440, 112);
			this.gpbServiceStaffType.TabIndex = 24;
			this.gpbServiceStaffType.TabStop = false;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label5.Location = new System.Drawing.Point(16, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 24);
			this.label5.TabIndex = 27;
			this.label5.Text = "แผนก";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 24);
			this.label2.TabIndex = 23;
			this.label2.Text = "ประเภทพนักงาน";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboServiceStaffType
			// 
			this.cboServiceStaffType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboServiceStaffType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboServiceStaffType.Location = new System.Drawing.Point(112, 16);
			this.cboServiceStaffType.Name = "cboServiceStaffType";
			this.cboServiceStaffType.Size = new System.Drawing.Size(320, 21);
			this.cboServiceStaffType.TabIndex = 25;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label3.Location = new System.Drawing.Point(16, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 24);
			this.label3.TabIndex = 24;
			this.label3.Text = "ลูกค้า";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboCustomer
			// 
			this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboCustomer.Location = new System.Drawing.Point(112, 48);
			this.cboCustomer.Name = "cboCustomer";
			this.cboCustomer.Size = new System.Drawing.Size(320, 21);
			this.cboCustomer.TabIndex = 26;
			this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
			// 
			// cboCustomerDept
			// 
			this.cboCustomerDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCustomerDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboCustomerDept.Location = new System.Drawing.Point(112, 80);
			this.cboCustomerDept.Name = "cboCustomerDept";
			this.cboCustomerDept.Size = new System.Drawing.Size(88, 21);
			this.cboCustomerDept.TabIndex = 28;
			// 
			// frmHolidayConditionEntry
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(458, 351);
			this.Controls.Add(this.gpbServiceStaffType);
			this.Controls.Add(this.gpbPositionType);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.gpbHoliday);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MinimizeBox = false;
			this.Name = "frmHolidayConditionEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmHolidayConditionEntry_Load);
			this.gpbHoliday.ResumeLayout(false);
			this.gpbPositionType.ResumeLayout(false);
			this.gpbServiceStaffType.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmHolidayCondition parentForm;
		#endregion

//		============================== Property ==============================
		private HolidayCondition objHolidayCondition;
		public HolidayCondition ObjHolidayCondition
		{			
			set
			{
				objHolidayCondition = value;
				
				if(value.APositionType.Type == "O")
				{
					rdoOfficeStaff.Checked = true;
				}
				else
				{
					rdoServiceStaff.Checked = true;
				}


                cboServiceStaffType.Text = value.AServiceStaffType.ToString();
                cboCustomer.Text = value.ACustomerDepartment.ACustomer.ToString();
                cboCustomerDept.Text = value.ACustomerDepartment.ToString();

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
			
				if(value.ATraditionalHolidayPattern != null && value.ATraditionalHolidayPattern.AName.Thai != "")
				{
					cboHoliday.Text = value.ATraditionalHolidayPattern.AName.Thai;
				}
			}

			get
			{
				objHolidayCondition = new HolidayCondition();
				string positionType;
				if(rdoOfficeStaff.Checked)
				{
					positionType = "O";
				}
				else
				{
					positionType = "S";
				}

				objHolidayCondition.APositionType = parentForm.FacadeHolidayCondition.GetPositionType(positionType);
				objHolidayCondition.AServiceStaffType =  (ServiceStaffType)cboServiceStaffType.SelectedItem;
				objHolidayCondition.ACustomerDepartment = (CustomerDepartment)cboCustomerDept.SelectedItem;
				objHolidayCondition.ACustomerDepartment.ACustomer = (Customer)cboCustomer.SelectedItem;

				if(chkSaturday.Checked)
				{
					objHolidayCondition.SaturdayBreak = true;				
				}
				else
				{
					objHolidayCondition.SaturdayBreak = false;	
				}

				if(chkSunday.Checked)
				{
					objHolidayCondition.SundayBreak = true;				
				}
				else
				{
					objHolidayCondition.SundayBreak = false;	
				}

				objHolidayCondition.ATraditionalHolidayPattern = (TraditionalHolidayPattern)cboHoliday.SelectedItem;

				positionType = null;

				return objHolidayCondition;
			}
		}

//		============================== Constructor ==============================
		public frmHolidayConditionEntry(frmHolidayCondition parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miHolidayCondition");

			try
			{			
				cboCustomer.DataSource = parentForm.FacadeHolidayCondition.DataSourceCustomer;
				cboHoliday.DataSource = parentForm.FacadeHolidayCondition.DataSourceTraditionalHolidayPattern;
				cboServiceStaffType.DataSource = parentForm.FacadeHolidayCondition.DataSourceServiceStaffType;
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
		private void setHolidayCondition()
		{
			if(chkSaturday.Checked)
			{
				objHolidayCondition.SaturdayBreak = true;				
			}
			else
			{
				objHolidayCondition.SaturdayBreak = false;	
			}

			if(chkSunday.Checked)
			{
				objHolidayCondition.SundayBreak = true;				
			}
			else
			{
				objHolidayCondition.SundayBreak = false;	
			}

			objHolidayCondition.ATraditionalHolidayPattern = (TraditionalHolidayPattern)cboHoliday.SelectedItem;
		}

		private void enableKeyField(bool enable)
		{
			gpbPositionType.Enabled = enable;
			gpbServiceStaffType.Enabled = enable;
		}

		private void clearForm()
		{
			rdoServiceStaff.Checked = true;
			chkSaturday.Checked = false;
			chkSunday.Checked = false;
			enableKeyField(true);
			initComboHoliday();

			if(cboServiceStaffType.Items.Count>0)
			{
				cboServiceStaffType.SelectedIndex = -1;
				cboServiceStaffType.SelectedIndex = -1;
				cboServiceStaffType.Text = "";
			}
			
			if(cboCustomer.Items.Count>0)
			{
				cboCustomer.SelectedIndex = -1;
				cboCustomer.SelectedIndex = -1;	
				cboCustomer.Text = "";
			}

			if(cboCustomerDept.Items.Count>0)
			{
				cboCustomerDept.SelectedIndex = -1;
				cboCustomerDept.SelectedIndex = -1;
				cboCustomerDept.Text = "";
			}
		}

		private bool validateForm()
		{
			if(rdoServiceStaff.Checked)
			{
				if(cboCustomer.Text != "" && cboServiceStaffType.Text == "")
				{
					Message(MessageList.Error.E0005, "ประเภทพนักงาน" );
					cboServiceStaffType.Focus();
					return false;
				}

			}
			return true;
		}

		public void initComboHoliday()
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
			clearForm();	
		}

		public void InitEditAction(HolidayCondition value)
		{
			baseEDIT();			
			clearForm();			
			ObjHolidayCondition = value;
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
				if (validateForm() && parentForm.AddRow(ObjHolidayCondition))
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
				setHolidayCondition();

				if (parentForm.UpdateRow(objHolidayCondition))
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
		private void frmHolidayConditionEntry_Load(object sender, System.EventArgs e)
		{					
			switch (action)
			{					
				case ActionType.ADD :
					initComboHoliday();	
					break;
				case ActionType.EDIT :
					if(objHolidayCondition.ATraditionalHolidayPattern == null || objHolidayCondition.ATraditionalHolidayPattern.AName.Thai == "")
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

		private void cboCustomer_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cboCustomer.SelectedIndex != -1)
			{
				Customer customer = (Customer)cboCustomer.SelectedItem;
				cboCustomerDept.DataSource = parentForm.FacadeHolidayCondition.DataSourceCustomerDept(customer);
				cboCustomerDept.Text = "";
			}
		}

		private void rdoOfficeStaff_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdoOfficeStaff.Checked)
			{
				if(cboServiceStaffType.Items.Count>0)
				{
					cboServiceStaffType.SelectedIndex = -1;
					cboServiceStaffType.SelectedIndex = -1;
					cboServiceStaffType.Text = "";
				}
			
				if(cboCustomer.Items.Count>0)
				{
					cboCustomer.SelectedIndex = -1;
					cboCustomer.SelectedIndex = -1;	
					cboCustomer.Text = "";
				}

				if(cboCustomerDept.Items.Count>0)
				{
					cboCustomerDept.SelectedIndex = -1;
					cboCustomerDept.SelectedIndex = -1;
					cboCustomerDept.Text = "";
				}

				gpbServiceStaffType.Enabled = false;
			}
			else
			{
				gpbServiceStaffType.Enabled = true;
			}
		}
	}
}
