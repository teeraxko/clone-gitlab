using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.AttendanceEntities;
using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using Entity.ContractEntities;

using Facade.AttendanceFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmOTPatternGeneralConditionEntry : EntryFormBase
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
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.RadioButton rdoService;
		private System.Windows.Forms.RadioButton rdoOffice;
		private System.Windows.Forms.ComboBox cboServiceStaffType;
		private System.Windows.Forms.ComboBox cboCustomer;
		private System.Windows.Forms.ComboBox cboCustomerDept;
		private System.Windows.Forms.ComboBox cboPattern;
		private System.Windows.Forms.GroupBox gpbDetail;

		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			this.gpbDetail = new System.Windows.Forms.GroupBox();
			this.cboPattern = new System.Windows.Forms.ComboBox();
			this.cboCustomerDept = new System.Windows.Forms.ComboBox();
			this.cboCustomer = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cboServiceStaffType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.rdoOffice = new System.Windows.Forms.RadioButton();
			this.rdoService = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.gpbDetail.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbDetail
			// 
			this.gpbDetail.Controls.Add(this.cboPattern);
			this.gpbDetail.Controls.Add(this.cboCustomerDept);
			this.gpbDetail.Controls.Add(this.cboCustomer);
			this.gpbDetail.Controls.Add(this.label5);
			this.gpbDetail.Controls.Add(this.label4);
			this.gpbDetail.Controls.Add(this.cboServiceStaffType);
			this.gpbDetail.Controls.Add(this.label3);
			this.gpbDetail.Controls.Add(this.rdoOffice);
			this.gpbDetail.Controls.Add(this.rdoService);
			this.gpbDetail.Controls.Add(this.label2);
			this.gpbDetail.Controls.Add(this.label1);
			this.gpbDetail.Location = new System.Drawing.Point(8, 8);
			this.gpbDetail.Name = "gpbDetail";
			this.gpbDetail.Size = new System.Drawing.Size(496, 192);
			this.gpbDetail.TabIndex = 0;
			this.gpbDetail.TabStop = false;
			// 
			// cboPattern
			// 
			this.cboPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPattern.Location = new System.Drawing.Point(136, 16);
			this.cboPattern.Name = "cboPattern";
			this.cboPattern.Size = new System.Drawing.Size(304, 21);
			this.cboPattern.TabIndex = 12;
			// 
			// cboCustomerDept
			// 
			this.cboCustomerDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCustomerDept.Location = new System.Drawing.Point(136, 152);
			this.cboCustomerDept.Name = "cboCustomerDept";
			this.cboCustomerDept.Size = new System.Drawing.Size(208, 21);
			this.cboCustomerDept.TabIndex = 11;
			// 
			// cboCustomer
			// 
			this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCustomer.Location = new System.Drawing.Point(136, 120);
			this.cboCustomer.Name = "cboCustomer";
			this.cboCustomer.Size = new System.Drawing.Size(208, 21);
			this.cboCustomer.TabIndex = 10;
			this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "ลูกค้า";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "แผนกลูกค้า";
			// 
			// cboServiceStaffType
			// 
			this.cboServiceStaffType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboServiceStaffType.Location = new System.Drawing.Point(136, 88);
			this.cboServiceStaffType.Name = "cboServiceStaffType";
			this.cboServiceStaffType.Size = new System.Drawing.Size(208, 21);
			this.cboServiceStaffType.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "ประเภทพนักงานบริการ";
			// 
			// rdoOffice
			// 
			this.rdoOffice.Location = new System.Drawing.Point(136, 56);
			this.rdoOffice.Name = "rdoOffice";
			this.rdoOffice.Size = new System.Drawing.Size(104, 16);
			this.rdoOffice.TabIndex = 5;
			this.rdoOffice.Text = "พนักงานสำนักงาน";
			this.rdoOffice.CheckedChanged += new System.EventHandler(this.rdoOffice_CheckedChanged);
			// 
			// rdoService
			// 
			this.rdoService.Checked = true;
			this.rdoService.Location = new System.Drawing.Point(280, 56);
			this.rdoService.Name = "rdoService";
			this.rdoService.Size = new System.Drawing.Size(104, 16);
			this.rdoService.TabIndex = 4;
			this.rdoService.TabStop = true;
			this.rdoService.Text = "พนักงานบริการ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "ประเภทตำแหน่ง";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "รูปแบบ";
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(171, 216);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 1;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(267, 216);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmOTPatternGeneralConditionEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(512, 253);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.gpbDetail);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmOTPatternGeneralConditionEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmOTPatternGeneralConditionEntry_Load);
			this.gpbDetail.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmOTPatternGeneralCondition parentForm;
		#endregion

//		============================== Property ==============================
		private OTPatternGeneralCondition objOTPatternGeneralCondition;
		public OTPatternGeneralCondition ObjOTPatternGeneralCondition
		{
			set
			{
				objOTPatternGeneralCondition = value;
				cboPattern.Text = value.AOTPattern.ToString();
                cboServiceStaffType.Text = value.AServiceStaffType.ToString();
				cboCustomer.Text = value.ACustomerDepartment.ACustomer.ToString();
                cboCustomerDept.Text = value.ACustomerDepartment.ToString();

				if(value.APositionType.Type == "O")
				{
					rdoOffice.Checked = true;
				}
				else
				{
					rdoService.Checked = true;
				}
			}
			get
			{
				objOTPatternGeneralCondition = new OTPatternGeneralCondition();
				objOTPatternGeneralCondition.AOTPattern = (OTPattern)cboPattern.SelectedItem;

				string positionType;
				if(rdoOffice.Checked)
				{
					positionType = "O";
				}
				else
				{
					positionType = "S";
				}

				objOTPatternGeneralCondition.APositionType = parentForm.FacadeOTPatternGeneralCondition.GetPositionType(positionType);
				objOTPatternGeneralCondition.AServiceStaffType =  (ServiceStaffType)cboServiceStaffType.SelectedItem;
				objOTPatternGeneralCondition.ACustomerDepartment = (CustomerDepartment)cboCustomerDept.SelectedItem;
				objOTPatternGeneralCondition.ACustomerDepartment.ACustomer = (Customer)cboCustomer.SelectedItem;
				return objOTPatternGeneralCondition;
			}
		}

//		============================== Constructor ==============================
		public frmOTPatternGeneralConditionEntry(frmOTPatternGeneralCondition parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miOTPatternGeneralCondition");

			try
			{			
				cboPattern.DataSource = parentForm.FacadeOTPatternGeneralCondition.DataSourceOTPattern;
				cboCustomer.DataSource = parentForm.FacadeOTPatternGeneralCondition.DataSourceCustomer;
				cboServiceStaffType.DataSource = parentForm.FacadeOTPatternGeneralCondition.DataSourceServiceStaffType;
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
		private void enableKeyField(bool enable)
		{
			cboServiceStaffType.Enabled = enable;
			cboCustomer.Enabled = enable;
			cboCustomerDept.Enabled = enable;
		}

		private void clearForm()
		{
			rdoOffice.Checked = true;
			gpbDetail.Enabled = true;
			cmdOK.Enabled = true;
			
			if(cboPattern.Items.Count>0)
			{
				cboPattern.SelectedIndex = -1;
				cboPattern.SelectedIndex = -1;
				cboPattern.Text = "";
			}
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
			if(cboPattern.Text == "")
			{
				Message(MessageList.Error.E0005, "รูปแบบ" );
				cboPattern.Focus();
				return false;
			}

			if(rdoService.Checked)
			{
				if(cboServiceStaffType.Text == "")
				{
					Message(MessageList.Error.E0005, "ประเภทพนักงาน" );
					cboServiceStaffType.Focus();
					return false;				
				}	
			}
			return true;
		}

//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			enableKeyField(true);
			clearForm();			
		}

		public void InitEditAction(OTPatternGeneralCondition value)
		{
			baseEDIT();			
			clearForm();			
			ObjOTPatternGeneralCondition = value;
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
				if (validateForm() && parentForm.AddRow(ObjOTPatternGeneralCondition))
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

//		============================== Base event ==============================
		private void frmOTPatternGeneralConditionEntry_Load(object sender, System.EventArgs e)
		{}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			addEvent();
		}

		private void rdoOffice_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdoOffice.Checked)
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

				enableKeyField(false);
			}
			else
			{
				enableKeyField(true);
			}
		}

		private void cboCustomer_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cboCustomer.SelectedIndex != -1)
			{
				Customer customer = (Customer)cboCustomer.SelectedItem;
				cboCustomerDept.DataSource = parentForm.FacadeOTPatternGeneralCondition.DataSourceCustomerDept(customer);
				cboCustomerDept.Text = "";
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}
	}
}
