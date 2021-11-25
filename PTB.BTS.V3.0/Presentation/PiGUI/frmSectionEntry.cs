using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Facade.PiFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Presentation.PiGUI
{
	public class frmSectionEntry : EntryFormBase
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
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEngName;
		private System.Windows.Forms.TextBox txtEngShortName;
		private System.Windows.Forms.TextBox txtThaiName;
		private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.TextBox txtDepartmentCode;
		private System.Windows.Forms.ComboBox cboDepartment;
		private System.Windows.Forms.Label label5;
        private TextBox txtBizPac;
        private Label label7;
        private TextBox txtSectionCode;
        private Label label1;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBizPac = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSectionCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDepartmentCode = new System.Windows.Forms.TextBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.txtEngName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEngShortName = new System.Windows.Forms.TextBox();
            this.txtThaiName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cmdOK.Location = new System.Drawing.Point(151, 192);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 24);
            this.cmdOK.TabIndex = 9;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtBizPac);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSectionCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDepartmentCode);
            this.groupBox1.Controls.Add(this.cboDepartment);
            this.groupBox1.Controls.Add(this.txtEngName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEngShortName);
            this.groupBox1.Controls.Add(this.txtThaiName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(8, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 160);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 31);
            this.label7.TabIndex = 17;
            this.label7.Text = "ฝ่ายต้นสังกัด (BizPac)";
            // 
            // txtBizPac
            // 
            this.txtBizPac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBizPac.Location = new System.Drawing.Point(104, 59);
            this.txtBizPac.MaxLength = 4;
            this.txtBizPac.Name = "txtBizPac";
            this.txtBizPac.Size = new System.Drawing.Size(40, 20);
            this.txtBizPac.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "ฝ่ายต้นสังกัด";
            // 
            // txtSectionCode
            // 
            this.txtSectionCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSectionCode.Location = new System.Drawing.Point(201, 59);
            this.txtSectionCode.MaxLength = 4;
            this.txtSectionCode.Name = "txtSectionCode";
            this.txtSectionCode.Size = new System.Drawing.Size(56, 20);
            this.txtSectionCode.TabIndex = 2;
            this.txtSectionCode.Tag = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(163, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัส";
            // 
            // txtDepartmentCode
            // 
            this.txtDepartmentCode.Location = new System.Drawing.Point(104, 24);
            this.txtDepartmentCode.Name = "txtDepartmentCode";
            this.txtDepartmentCode.Size = new System.Drawing.Size(32, 20);
            this.txtDepartmentCode.TabIndex = 12;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Location = new System.Drawing.Point(136, 24);
            this.cboDepartment.MaxLength = 50;
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(312, 21);
            this.cboDepartment.TabIndex = 1;
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // txtEngName
            // 
            this.txtEngName.Location = new System.Drawing.Point(104, 120);
            this.txtEngName.MaxLength = 50;
            this.txtEngName.Name = "txtEngName";
            this.txtEngName.Size = new System.Drawing.Size(344, 20);
            this.txtEngName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "ชื่อภาษาไทย";
            // 
            // txtEngShortName
            // 
            this.txtEngShortName.Location = new System.Drawing.Point(344, 59);
            this.txtEngShortName.MaxLength = 10;
            this.txtEngShortName.Name = "txtEngShortName";
            this.txtEngShortName.Size = new System.Drawing.Size(104, 20);
            this.txtEngShortName.TabIndex = 3;
            // 
            // txtThaiName
            // 
            this.txtThaiName.Location = new System.Drawing.Point(104, 88);
            this.txtThaiName.MaxLength = 50;
            this.txtThaiName.Name = "txtThaiName";
            this.txtThaiName.Size = new System.Drawing.Size(344, 20);
            this.txtThaiName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "ชื่อภาษาอังกฤษ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(282, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "ชื่อย่อ";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cmdCancel.Location = new System.Drawing.Point(231, 192);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 24);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmSectionEntry
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(480, 230);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSectionEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSectionEntry";
            this.Load += new System.EventHandler(this.frmSectionEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmSection parentForm;
		private Section objSection;
		#endregion

		//		============================== Property ==============================
		public Section getSection()
		{
			objSection = new Section();
			objSection.Code= txtDepartmentCode.Text+txtSectionCode.Text;
			objSection.AShortName.English= txtEngShortName.Text;
			objSection.AFullName.Thai = txtThaiName.Text;
			objSection.AFullName.English = txtEngName.Text;
			objSection.ADepartment = (Department)cboDepartment.SelectedItem;
            objSection.BizPac = txtBizPac.Text;
			return objSection;
		}

		public void setSection(Section value)
		{
			objSection = value;
			txtSectionCode.Text = objSection.Code.Substring(2);
			txtEngShortName.Text = GUIFunction.GetString(objSection.AShortName.English);
			txtThaiName.Text = GUIFunction.GetString(objSection.AFullName.Thai);
			txtEngName.Text = GUIFunction.GetString(objSection.AFullName.English);
			txtDepartmentCode.Text = objSection.Code.Substring(0,2);
			cboDepartment.Text = value.ADepartment.ToString();
            txtBizPac.Text = objSection.BizPac;
		}
		//		============================== Constructor ==============================
		public frmSectionEntry(frmSection parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMapSection");

			try
			{		
				cboDepartment.DataSource = parentForm.FacadeSection.DataSourceDepartment;
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);

			}
			catch(Exception ex)
			{
				Message(ex);
			}
			finally
			{
			}
		}
		//		============================== private method ==============================
		private void enableKeyField(bool enable)
		{
			txtSectionCode.Enabled = enable;
			cboDepartment.Enabled = enable;
		}
		private void clearForm()
		{
			txtSectionCode.Text = "";
			txtEngShortName.Text = "";
			txtThaiName.Text = "";
			txtEngName.Text = "";
			txtDepartmentCode.Text = "";
            txtBizPac.Text = "";
			txtDepartmentCode.Enabled = false;
			InitCombo();
			
		}
		private bool Validate1()
		{
			if(txtSectionCode.Text == "")
			{
				Message(MessageList.Error.E0002, "รหัส" );
				txtSectionCode.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
        private bool ValidateBizPac()
        {
            if (txtBizPac.Text == "")
            {
                Message(MessageList.Error.E0002, "ฝ่ายต้นสังกัด (BizPac)");
                txtBizPac.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
		private bool Validate2()
		{
			if(txtEngShortName.Text == "")
			{
				Message(MessageList.Error.E0002, "ชื่อย่อ" );
				txtEngShortName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool Validate3()
		{
			if(txtThaiName.Text == "")
			{
				Message(MessageList.Error.E0002, "ชื่อภาษาไทย" );
				txtThaiName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool Validate4()
		{
			if(txtEngName.Text == "")
			{
				Message(MessageList.Error.E0002, "ชื่อภาษาอังกฤษ" );
				txtEngName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		
		private bool Validate5()
		{
			if(cboDepartment.Text == "")
			{
				Message(MessageList.Error.E0005, "ฝ่ายต้นสังกัด" );
				cboDepartment.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateForm()
		{
            return Validate5() && ValidateBizPac() && Validate1() && Validate2() && Validate3() && Validate4();
		}
		//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			clearForm();
			enableKeyField(true);
			cboDepartment.SelectedIndex = -1;
			SectionCodeFocus();
		}

		public void InitEditAction(Section aSection)
		{
			baseEDIT();
			clearForm();
			setSection(aSection);
			EngShortNameFocus();
			enableKeyField(false);

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}
		public void InitCombo()
		{
			cboDepartment.SelectedIndex = -1;
		}
		public void SectionCodeFocus()
		{
			cboDepartment.Focus();
		}
		public void EngShortNameFocus()
		{
			txtEngShortName.Focus();
		}
		//		============================== Base event ==============================
		private void AddEvent()
		{
			try
			{
				if (ValidateForm() && parentForm.AddRow(getSection()))
				{
					clearForm();
					InitAddAction();
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				txtSectionCode.Focus();
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
				if (ValidateForm() && parentForm.UpdateRow(getSection()))
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

		private void frmSectionEntry_Load(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
					InitAddAction();
					break;
			}
		}

		private void cboDepartment_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cboDepartment.Items.Count>0 && cboDepartment.SelectedIndex != -1)
			{
				Department aDepartment = (Department)cboDepartment.SelectedItem;				
				txtDepartmentCode.Text = aDepartment.Code;
				aDepartment = null;					
			}
		}

	}
}
