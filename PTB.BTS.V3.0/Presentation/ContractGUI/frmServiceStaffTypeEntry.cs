using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.ContractEntities;
using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

using Facade.ContractFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.ContractGUI
{
	public class frmServiceStaffTypeEntry : EntryFormBase
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
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.TextBox txtServiceStaffCode2;
		private System.Windows.Forms.TextBox txtEngDescription;
		private System.Windows.Forms.TextBox txtThaiDescription;
		private System.Windows.Forms.TextBox txtPositionCode;
		private System.Windows.Forms.ComboBox cboPositionName;
		private System.Windows.Forms.GroupBox groupbox1;
		private System.Windows.Forms.TextBox cboPositionCode;
        private TextBox txtIncomeName;
        private TextBox txtIncomeCode;
        private Label label6;
        private Label label5;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.txtIncomeName = new System.Windows.Forms.TextBox();
            this.txtIncomeCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPositionCode = new System.Windows.Forms.TextBox();
            this.txtServiceStaffCode2 = new System.Windows.Forms.TextBox();
            this.cboPositionName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEngDescription = new System.Windows.Forms.TextBox();
            this.txtThaiDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPositionCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupbox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupbox1
            // 
            this.groupbox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupbox1.Controls.Add(this.txtIncomeName);
            this.groupbox1.Controls.Add(this.txtIncomeCode);
            this.groupbox1.Controls.Add(this.label6);
            this.groupbox1.Controls.Add(this.label5);
            this.groupbox1.Controls.Add(this.cboPositionCode);
            this.groupbox1.Controls.Add(this.txtServiceStaffCode2);
            this.groupbox1.Controls.Add(this.cboPositionName);
            this.groupbox1.Controls.Add(this.label4);
            this.groupbox1.Controls.Add(this.txtEngDescription);
            this.groupbox1.Controls.Add(this.txtThaiDescription);
            this.groupbox1.Controls.Add(this.label3);
            this.groupbox1.Controls.Add(this.label2);
            this.groupbox1.Controls.Add(this.txtPositionCode);
            this.groupbox1.Controls.Add(this.label1);
            this.groupbox1.Location = new System.Drawing.Point(16, 8);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(528, 190);
            this.groupbox1.TabIndex = 0;
            this.groupbox1.TabStop = false;
            // 
            // txtIncomeName
            // 
            this.txtIncomeName.Location = new System.Drawing.Point(192, 155);
            this.txtIncomeName.MaxLength = 50;
            this.txtIncomeName.Name = "txtIncomeName";
            this.txtIncomeName.Size = new System.Drawing.Size(320, 20);
            this.txtIncomeName.TabIndex = 13;
            // 
            // txtIncomeCode
            // 
            this.txtIncomeCode.Location = new System.Drawing.Point(192, 128);
            this.txtIncomeCode.MaxLength = 6;
            this.txtIncomeCode.Name = "txtIncomeCode";
            this.txtIncomeCode.Size = new System.Drawing.Size(80, 20);
            this.txtIncomeCode.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Income Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Income Code";
            // 
            // cboPositionCode
            // 
            this.cboPositionCode.Enabled = false;
            this.cboPositionCode.Location = new System.Drawing.Point(192, 20);
            this.cboPositionCode.MaxLength = 2;
            this.cboPositionCode.Name = "cboPositionCode";
            this.cboPositionCode.Size = new System.Drawing.Size(40, 20);
            this.cboPositionCode.TabIndex = 9;
            // 
            // txtServiceStaffCode2
            // 
            this.txtServiceStaffCode2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtServiceStaffCode2.Location = new System.Drawing.Point(240, 47);
            this.txtServiceStaffCode2.MaxLength = 1;
            this.txtServiceStaffCode2.Name = "txtServiceStaffCode2";
            this.txtServiceStaffCode2.Size = new System.Drawing.Size(32, 20);
            this.txtServiceStaffCode2.TabIndex = 4;
            // 
            // cboPositionName
            // 
            this.cboPositionName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPositionName.Location = new System.Drawing.Point(240, 20);
            this.cboPositionName.Name = "cboPositionName";
            this.cboPositionName.Size = new System.Drawing.Size(272, 21);
            this.cboPositionName.TabIndex = 2;
            this.cboPositionName.SelectedIndexChanged += new System.EventHandler(this.cboPosition_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "ตำแหน่ง";
            // 
            // txtEngDescription
            // 
            this.txtEngDescription.Location = new System.Drawing.Point(192, 101);
            this.txtEngDescription.MaxLength = 50;
            this.txtEngDescription.Name = "txtEngDescription";
            this.txtEngDescription.Size = new System.Drawing.Size(320, 20);
            this.txtEngDescription.TabIndex = 6;
            // 
            // txtThaiDescription
            // 
            this.txtThaiDescription.Location = new System.Drawing.Point(192, 74);
            this.txtThaiDescription.MaxLength = 50;
            this.txtThaiDescription.Name = "txtThaiDescription";
            this.txtThaiDescription.Size = new System.Drawing.Size(320, 20);
            this.txtThaiDescription.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "คำอธิบาย (ภาษาอังกฤษ)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "คำอธิบาย (ภาษาไทย)";
            // 
            // txtPositionCode
            // 
            this.txtPositionCode.Enabled = false;
            this.txtPositionCode.Location = new System.Drawing.Point(192, 47);
            this.txtPositionCode.MaxLength = 2;
            this.txtPositionCode.Name = "txtPositionCode";
            this.txtPositionCode.Size = new System.Drawing.Size(40, 20);
            this.txtPositionCode.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสประเภทพนักงาน (Service Staff)";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdOK.Location = new System.Drawing.Point(203, 214);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(283, 214);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmServiceStaffTypeEntry
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(560, 253);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupbox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmServiceStaffTypeEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmServiceStaffTypeEntry";
            this.Load += new System.EventHandler(this.frmServiceStaffTypeEntry_Load);
            this.groupbox1.ResumeLayout(false);
            this.groupbox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmServiceStaffType parentForm;
		private ServiceStaffType objServiceStaffType;
		#endregion

		//		============================== Property ==============================
		public ServiceStaffType getServiceStaffType()
		{
			objServiceStaffType = new ServiceStaffType();	
			objServiceStaffType.APosition = (Position)cboPositionName.SelectedItem;                 
			objServiceStaffType.Type = txtPositionCode.Text + txtServiceStaffCode2.Text;
			objServiceStaffType.ADescription.Thai = txtThaiDescription.Text;
			objServiceStaffType.ADescription.English = txtEngDescription.Text;
            objServiceStaffType.BizPacIncomeCode = txtIncomeCode.Text;
            objServiceStaffType.BizPacIncomeName = txtIncomeName.Text;
			return objServiceStaffType;
		}
		public void setServiceStaffType(ServiceStaffType value)
		{
			objServiceStaffType = value;
			cboPositionCode.Text = value.APosition.PositionCode;
			cboPositionName.Text = value.APosition.ToString();
			txtPositionCode.Text = value.APosition.PositionCode;
			txtServiceStaffCode2.Text = value.Type.Substring(2);
			txtThaiDescription.Text = value.ADescription.Thai;
			txtEngDescription.Text = value.ADescription.English;
            txtIncomeCode.Text = value.BizPacIncomeCode;
            txtIncomeName.Text = value.BizPacIncomeName;
		}

		//		============================== Constructor ==============================
		public frmServiceStaffTypeEntry(frmServiceStaffType parentForm):base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractSettingServiceStaffType");
		}
		//		============================== private method ==============================
		private void enableKeyField(bool enable)
		{
			txtServiceStaffCode2.Enabled = enable;
		}

		private void clearForm()
		{
			cboPositionCode.Text = "";
			txtPositionCode.Text = "";
			txtServiceStaffCode2.Text = "";
			txtThaiDescription.Text = "";
			txtEngDescription.Text = "";
            txtIncomeCode.Text = "";
            txtIncomeName.Text = "";
			InitCombo();
		}

		private bool ValidateForm1()
		{
			return ValidateTel1() && ValidateTel2()&& ValidateTel3() && ValidateTel4();
		}
		private bool ValidateForm2()
		{
			return ValidateTel3() && ValidateTel4();
		}
		private bool ValidateTel1()
		{
			if(cboPositionName.Text == "") 
			{
				Message(MessageList.Error.E0002, "ตำแหน่ง" );
				cboPositionName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateTel2()
		{
			if(txtServiceStaffCode2.Text == "") 
			{
				Message(MessageList.Error.E0002, "รหัสประเภทพนักงาน(Service Staff)" );
				txtServiceStaffCode2.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateTel3()
		{
			if(txtThaiDescription.Text == "") 
			{
				Message(MessageList.Error.E0002, "คำอธิบาย (ภาษาไทย)" );
				txtThaiDescription.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateTel4()
		{
			if(txtEngDescription.Text == "") 
			{
				Message(MessageList.Error.E0002, "คำอธิบาย(ภาษาอังกฤษ)" );
				txtEngDescription.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private void initComboDataSource()
		{
			if(action == ActionType.ADD)
			{
				ArrayList DataSourcePositionNoDriver = parentForm.FacadeServiceStaffType.DataSourcePosition;
				for(int i=0; i<DataSourcePositionNoDriver.Count; i++)
				{
					if(((Position)DataSourcePositionNoDriver[i]).APositionRole == POSITION_ROLE_TYPE.DRIVER)
					{
						DataSourcePositionNoDriver.Remove(DataSourcePositionNoDriver[i]);
						break;
					}
				}
				cboPositionName.DataSource = DataSourcePositionNoDriver;
			}
			else
			{
				cboPositionName.DataSource = parentForm.FacadeServiceStaffType.DataSourcePosition;
			}
		}

		//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			initComboDataSource();
			txtPositionCode.Enabled = false;
			cboPositionCode.Enabled = false;
			cboPositionName.Enabled = true;
			clearForm();
			enableKeyField(true);
			this.Text = "เพิ่มข้อมูลประเภทพนักงาน(Service Staff)";
		}

		public void InitEditAction(ServiceStaffType aServiceStaffType)
		{
			baseEDIT();
			initComboDataSource();
			clearForm();
			setServiceStaffType(aServiceStaffType);
			cboPositionName.Enabled = false;
			enableKeyField(false);
			this.Text = "แก้ไขข้อมูลประเภทพนักงาน(Service Staff)";

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}
		public void InitCombo()
		{
			cboPositionName.SelectedIndex = -1;
		}
		public void PositionName()
		{
			cboPositionName.Focus();
		}
		public void ServiceStaffCode()
		{
			txtServiceStaffCode2.Focus();
		}
		//		============================== Base event ==============================
		private void AddEvent()
		{
			try
			{
				if (ValidateForm1() && parentForm.AddRow(getServiceStaffType()))
				{
					clearForm();
					InitAddAction();
					cboPositionName.Focus();
				}
			}
			catch(DuplicateException ex)
			{
				Message(ex);
				txtServiceStaffCode2.Focus();
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
				if (ValidateForm2() && parentForm.UpdateRow(getServiceStaffType()))
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

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
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
		private void cboPosition_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cboPositionName.Items.Count>0 && cboPositionName.SelectedIndex != -1)
			{
				Position aPosition = (Position)cboPositionName.SelectedItem;				
				txtPositionCode.Text = aPosition.PositionCode;
				cboPositionCode.Text = aPosition.PositionCode;
				aPosition = null;					
			}
		}

		private void frmServiceStaffTypeEntry_Load(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
					InitAddAction();
					break;
			}
		}
	}
}
