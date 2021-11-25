using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;


using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;


namespace Presentation.AttendanceGUI
{
	public class frmWorkingTimeConditionEntry : EntryFormBase
	{
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
					parentForm.Dispose();
                    
					parentForm = null;
					objWorkingTimeCondition = null;
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.ComboBox cboServiceStaffType;
		private System.Windows.Forms.ComboBox cboCustomerName;
		private System.Windows.Forms.ComboBox cboCustomerDept;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rdoService;
		private System.Windows.Forms.RadioButton rdoOffice;
		private System.Windows.Forms.GroupBox gpbService;
		private System.Windows.Forms.GroupBox gpbTableId;
		private System.Windows.Forms.GroupBox gpbPositionType;
		private System.Windows.Forms.ComboBox cboTableId;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.gpbTableId = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.rdoService = new System.Windows.Forms.RadioButton();
			this.rdoOffice = new System.Windows.Forms.RadioButton();
			this.cboServiceStaffType = new System.Windows.Forms.ComboBox();
			this.cboCustomerName = new System.Windows.Forms.ComboBox();
			this.cboCustomerDept = new System.Windows.Forms.ComboBox();
			this.gpbService = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.gpbPositionType = new System.Windows.Forms.GroupBox();
			this.cboTableId = new System.Windows.Forms.ComboBox();
			this.gpbTableId.SuspendLayout();
			this.gpbService.SuspendLayout();
			this.gpbPositionType.SuspendLayout();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label4.Location = new System.Drawing.Point(16, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "ชื่อลูกค้า ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label5.Location = new System.Drawing.Point(16, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "ฝ่ายลูกค้า";
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdOK.Location = new System.Drawing.Point(149, 280);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 5;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdCancel.Location = new System.Drawing.Point(229, 280);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 6;
			this.cmdCancel.Text = "ยกเลิก";
			// 
			// gpbTableId
			// 
			this.gpbTableId.Controls.Add(this.label1);
			this.gpbTableId.Controls.Add(this.cboTableId);
			this.gpbTableId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.gpbTableId.Location = new System.Drawing.Point(16, 208);
			this.gpbTableId.Name = "gpbTableId";
			this.gpbTableId.Size = new System.Drawing.Size(408, 56);
			this.gpbTableId.TabIndex = 9;
			this.gpbTableId.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 16);
			this.label1.TabIndex = 12;
			this.label1.Text = "รูปแบบ";
			// 
			// rdoService
			// 
			this.rdoService.Checked = true;
			this.rdoService.Location = new System.Drawing.Point(24, 16);
			this.rdoService.Name = "rdoService";
			this.rdoService.Size = new System.Drawing.Size(104, 16);
			this.rdoService.TabIndex = 11;
			this.rdoService.TabStop = true;
			this.rdoService.Text = "พนักงานบริการ";
			// 
			// rdoOffice
			// 
			this.rdoOffice.Location = new System.Drawing.Point(200, 16);
			this.rdoOffice.Name = "rdoOffice";
			this.rdoOffice.Size = new System.Drawing.Size(120, 16);
			this.rdoOffice.TabIndex = 10;
			this.rdoOffice.Text = "พนักงานสำนักงาน";
			this.rdoOffice.CheckedChanged += new System.EventHandler(this.rdoOffice_CheckedChanged);
			// 
			// cboServiceStaffType
			// 
			this.cboServiceStaffType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboServiceStaffType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboServiceStaffType.Location = new System.Drawing.Point(104, 24);
			this.cboServiceStaffType.Name = "cboServiceStaffType";
			this.cboServiceStaffType.Size = new System.Drawing.Size(288, 21);
			this.cboServiceStaffType.TabIndex = 10;
			// 
			// cboCustomerName
			// 
			this.cboCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboCustomerName.Location = new System.Drawing.Point(104, 56);
			this.cboCustomerName.Name = "cboCustomerName";
			this.cboCustomerName.Size = new System.Drawing.Size(288, 21);
			this.cboCustomerName.TabIndex = 12;
			this.cboCustomerName.SelectedIndexChanged += new System.EventHandler(this.cboCustomerName_SelectedIndexChanged);
			// 
			// cboCustomerDept
			// 
			this.cboCustomerDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCustomerDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboCustomerDept.Location = new System.Drawing.Point(104, 88);
			this.cboCustomerDept.Name = "cboCustomerDept";
			this.cboCustomerDept.Size = new System.Drawing.Size(88, 21);
			this.cboCustomerDept.TabIndex = 13;
			// 
			// gpbService
			// 
			this.gpbService.Controls.Add(this.cboCustomerDept);
			this.gpbService.Controls.Add(this.label5);
			this.gpbService.Controls.Add(this.label4);
			this.gpbService.Controls.Add(this.cboCustomerName);
			this.gpbService.Controls.Add(this.label2);
			this.gpbService.Controls.Add(this.cboServiceStaffType);
			this.gpbService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.gpbService.Location = new System.Drawing.Point(16, 64);
			this.gpbService.Name = "gpbService";
			this.gpbService.Size = new System.Drawing.Size(408, 136);
			this.gpbService.TabIndex = 14;
			this.gpbService.TabStop = false;
			this.gpbService.Text = "พนักงานบริการ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label2.Location = new System.Drawing.Point(16, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "บริการประเภท ";
			// 
			// gpbPositionType
			// 
			this.gpbPositionType.Controls.Add(this.rdoOffice);
			this.gpbPositionType.Controls.Add(this.rdoService);
			this.gpbPositionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.gpbPositionType.Location = new System.Drawing.Point(16, 8);
			this.gpbPositionType.Name = "gpbPositionType";
			this.gpbPositionType.Size = new System.Drawing.Size(408, 48);
			this.gpbPositionType.TabIndex = 15;
			this.gpbPositionType.TabStop = false;
			// 
			// cboTableId
			// 
			this.cboTableId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTableId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboTableId.Location = new System.Drawing.Point(104, 16);
			this.cboTableId.Name = "cboTableId";
			this.cboTableId.Size = new System.Drawing.Size(288, 21);
			this.cboTableId.TabIndex = 14;
			// 
			// frmWorkingTimeConditionEntry
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(442, 319);
			this.Controls.Add(this.gpbPositionType);
			this.Controls.Add(this.gpbService);
			this.Controls.Add(this.gpbTableId);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmWorkingTimeConditionEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmWorkingTimeConditionEntry_Load);
			this.gpbTableId.ResumeLayout(false);
			this.gpbService.ResumeLayout(false);
			this.gpbPositionType.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmWorkingTimeCondition parentForm;
		#endregion

		//		============================== Property ====================
		private WorkingTimeCondition objWorkingTimeCondition;
		public WorkingTimeCondition ObjWorkingTimeCondition
		{
			set
			{
				objWorkingTimeCondition = value;
				if(value.APositionType.Type == "S")
				{
					rdoService.Checked = true;
				}
				else
				{
					rdoOffice.Checked = true;
				}

				cboServiceStaffType.Text = value.AServiceStaffType.ToString();
                cboCustomerName.Text = value.ACustomerDepartment.ACustomer.ToString();
                cboCustomerDept.Text = value.ACustomerDepartment.ToString();
				cboTableId.Text = value.AWorkingTimeTable.ToString();
			}
			get
			{
				objWorkingTimeCondition = new WorkingTimeCondition();

				string positionType;
				if(rdoService.Checked)
				{
					positionType = "S";
				}
				else
				{
					positionType = "O";
				}

				objWorkingTimeCondition.APositionType = parentForm.FacadeWorkingTimeCondition.GetPositionType(positionType);
				objWorkingTimeCondition.ACustomerDepartment = (CustomerDepartment)cboCustomerDept.SelectedItem;
				objWorkingTimeCondition.ACustomerDepartment.ACustomer = (Customer)cboCustomerName.SelectedItem;
				objWorkingTimeCondition.AServiceStaffType =  (ServiceStaffType)cboServiceStaffType.SelectedItem;
				objWorkingTimeCondition.AWorkingTimeTable = (WorkingTimeTable)cboTableId.SelectedItem;
				return objWorkingTimeCondition;			
			}
		}
	
		//		============================== constructor ==============================
		public frmWorkingTimeConditionEntry(frmWorkingTimeCondition parentForm): base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miWorkingTimeCondition");

			try
			{
				cboCustomerName.DataSource = parentForm.FacadeWorkingTimeCondition.DataSourceCustomerName;
				cboServiceStaffType.DataSource = parentForm.FacadeWorkingTimeCondition.DataSourceServiceStaffType;
				cboTableId.DataSource = parentForm.FacadeWorkingTimeCondition.DataSourceWorkingTimeCondition;
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
		private void enableForm(bool enable)
		{
			gpbService.Enabled = enable;
			gpbPositionType.Enabled = enable;
		}

		private void clearForm()
		{
			enableForm(true);
			rdoService.Checked = true;
			InitComboTableId();

			if(cboServiceStaffType.Items.Count>0)
			{
				cboServiceStaffType.SelectedIndex = -1;
				cboServiceStaffType.Text = "";
			}
			if(cboCustomerName.Items.Count>0)
			{
				cboCustomerName.SelectedIndex = -1;
				cboCustomerName.Text = "";
			}
			if(cboCustomerDept.Items.Count>0)
			{
				cboCustomerDept.SelectedIndex = -1;
				cboCustomerDept.Text = "";
			}
		}

		private bool validateForm()
		{
			if(rdoService.Checked)
			{
				if(cboCustomerName.Text != "" && cboServiceStaffType.Text == "")
				{
					Message(MessageList.Error.E0005, "ประเภทพนักงาน" );
					cboServiceStaffType.Focus();
					return false;
				}
			}

			if(cboTableId.Text == "") 
			{
				Message(MessageList.Error.E0005, "รูปแบบ" );
				cboTableId.Focus();
				return false;
			}
			return true;
		}

		private void InitComboTableId()
		{
			if(cboTableId.Items.Count>0)
			{
				cboTableId.SelectedIndex = -1;
				cboTableId.SelectedIndex = -1;
				cboTableId.Text = "";
			}
		}

		//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			clearForm();
			rdoService.Focus();
		}

		public void InitEditAction(WorkingTimeCondition value)
		{
			baseEDIT();
			clearForm();
			ObjWorkingTimeCondition = value;
			enableForm(false);

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
				if (validateForm() && parentForm.AddRow(ObjWorkingTimeCondition))
				{
					clearForm();
					cboServiceStaffType.Focus();
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
				objWorkingTimeCondition.AWorkingTimeTable = (WorkingTimeTable)cboTableId.SelectedItem;
				if (parentForm.UpdateRow(objWorkingTimeCondition))
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

		//		============================== event ==============================
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

		private void cboCustomerName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cboCustomerName.SelectedIndex != -1)
			{
				Customer customer = (Customer)cboCustomerName.SelectedItem;
				cboCustomerDept.DataSource = parentForm.FacadeWorkingTimeCondition.DataSourceCustomerDept(customer);
				cboCustomerDept.Text = "";
			}
		}

		private void rdoOffice_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdoService.Checked)
			{
				gpbService.Enabled = true;
			}
			else
			{
				if(cboServiceStaffType.Items.Count>0)
				{
					cboServiceStaffType.SelectedIndex = -1;
					cboServiceStaffType.SelectedIndex = -1;
					cboServiceStaffType.Text = "";
				}
				if(cboCustomerName.Items.Count>0)
				{
					cboCustomerName.SelectedIndex = -1;
					cboCustomerName.SelectedIndex = -1;
					cboCustomerName.Text = "";
				}
				if(cboCustomerDept.Items.Count>0)
				{
					cboCustomerDept.SelectedIndex = -1;
					cboCustomerDept.SelectedIndex = -1;
					cboCustomerDept.Text = "";
				}
				gpbService.Enabled = false;
			}
		}

		private void frmWorkingTimeConditionEntry_Load(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
					InitComboTableId();
					break;
			}
		}
	}
}
