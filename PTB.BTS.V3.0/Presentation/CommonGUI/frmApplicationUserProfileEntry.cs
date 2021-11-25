using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Presentation.CommonGUI
{
	public class frmApplicationUserProfileEntry : EntryFormBase
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkNewPassword;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.RadioButton rdoUserRole;
		private System.Windows.Forms.RadioButton rdoPowerUserRole;
		private System.Windows.Forms.RadioButton rdoAdminRole;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.chkNewPassword = new System.Windows.Forms.CheckBox();
			this.rdoUserRole = new System.Windows.Forms.RadioButton();
			this.rdoPowerUserRole = new System.Windows.Forms.RadioButton();
			this.rdoAdminRole = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdCancel.Location = new System.Drawing.Point(180, 176);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdOK.Location = new System.Drawing.Point(100, 176);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// chkNewPassword
			// 
			this.chkNewPassword.Location = new System.Drawing.Point(216, 56);
			this.chkNewPassword.Name = "chkNewPassword";
			this.chkNewPassword.Size = new System.Drawing.Size(112, 24);
			this.chkNewPassword.TabIndex = 16;
			this.chkNewPassword.Text = "กำหนดรหัสผ่านใหม่";
			this.chkNewPassword.Visible = false;
			this.chkNewPassword.CheckedChanged += new System.EventHandler(this.chkNewPassword_CheckedChanged);
			// 
			// rdoUserRole
			// 
			this.rdoUserRole.Checked = true;
			this.rdoUserRole.Location = new System.Drawing.Point(40, 24);
			this.rdoUserRole.Name = "rdoUserRole";
			this.rdoUserRole.Size = new System.Drawing.Size(72, 24);
			this.rdoUserRole.TabIndex = 17;
			this.rdoUserRole.TabStop = true;
			this.rdoUserRole.Text = "ผู้ใช้ทั่วไป";
			// 
			// rdoPowerUserRole
			// 
			this.rdoPowerUserRole.Location = new System.Drawing.Point(136, 24);
			this.rdoPowerUserRole.Name = "rdoPowerUserRole";
			this.rdoPowerUserRole.Size = new System.Drawing.Size(72, 24);
			this.rdoPowerUserRole.TabIndex = 18;
			this.rdoPowerUserRole.Text = "ผู้ดูแลระบบ";
			// 
			// rdoAdminRole
			// 
			this.rdoAdminRole.Location = new System.Drawing.Point(232, 24);
			this.rdoAdminRole.Name = "rdoAdminRole";
			this.rdoAdminRole.Size = new System.Drawing.Size(72, 24);
			this.rdoAdminRole.TabIndex = 19;
			this.rdoAdminRole.Text = "IT Admin";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtUserName);
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.chkNewPassword);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(336, 88);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ผู้ใช้";
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(72, 24);
			this.txtUserName.MaxLength = 20;
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(128, 20);
			this.txtUserName.TabIndex = 1;
			this.txtUserName.Text = "";
			// 
			// txtPassword
			// 
			this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.txtPassword.Location = new System.Drawing.Point(72, 56);
			this.txtPassword.MaxLength = 20;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '•';
			this.txtPassword.Size = new System.Drawing.Size(128, 20);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "รหัสผ่าน";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 23);
			this.label6.TabIndex = 9;
			this.label6.Text = "ชื่อผู้ใช้";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rdoPowerUserRole);
			this.groupBox2.Controls.Add(this.rdoAdminRole);
			this.groupBox2.Controls.Add(this.rdoUserRole);
			this.groupBox2.Location = new System.Drawing.Point(8, 104);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(336, 56);
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "กลุ่มผู้ใช้";
			// 
			// frmApplicationUserProfileEntry
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(354, 215);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MinimizeBox = false;
			this.Name = "frmApplicationUserProfileEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmApplicationUserProfileEntry_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private frmApplicationUserProfile parentForm;
		private ApplicationUserProfile objApplicationUserProfile;
		#endregion

//		============================== Property ==============================
		public ApplicationUserProfile getApplicationUserProfile()
		{
			objApplicationUserProfile = new ApplicationUserProfile();
			objApplicationUserProfile.UserName = txtUserName.Text;
			objApplicationUserProfile.Password = txtPassword.Text;

			if(rdoAdminRole.Checked)
			{objApplicationUserProfile.UserRole = USER_ROLE.ADMIN;}

			else if (rdoPowerUserRole.Checked)
			{
				objApplicationUserProfile.UserRole = USER_ROLE.POWER_USER;			
			}
			else 
			{
				objApplicationUserProfile.UserRole = USER_ROLE.USER;
			}
			return objApplicationUserProfile;
		}
		public void setApplicationUserProfile(ApplicationUserProfile value)
		{
			objApplicationUserProfile = value;
			txtUserName.Text = value.UserName;
			txtPassword.Text = value.Password;
			
			if(value.UserRole == USER_ROLE.ADMIN)
			{
				rdoAdminRole.Checked = true;
			}
			else if (value.UserRole == USER_ROLE.POWER_USER)
			{
				rdoPowerUserRole.Checked = true;
			}
			else if (value.UserRole == USER_ROLE.USER)
			{
				rdoUserRole.Checked = true;
			}
			else
			{
				rdoAdminRole.Checked = false;
				rdoPowerUserRole.Checked = false;
				rdoUserRole.Checked = false;
			}
		}

//		============================== Constructor ==============================
		public frmApplicationUserProfileEntry(frmApplicationUserProfile parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
		}

//		============================== private method ==============================
		private void enableKeyField(bool enable)
		{
			txtUserName.Enabled = enable;
			txtPassword.Enabled = enable;
		}

		private void clearForm()
		{
			txtUserName.Text = "";
			txtPassword.Text = "";
			chkNewPassword.Checked = false;
			rdoUserRole.Checked = true;	
			rdoAdminRole.Visible = true;
			visibleCheck();
		}

		private bool ValidateForm()
		{
			if(txtUserName.Text == "")
			{
				txtUserName.Focus();
				Message(MessageList.Error.E0002, "ชื่อผู้ใช้" );
				return false;
			}
			return true;
		}

		private void visibleCheck()
		{
			if(UserProfile.UserROLE == USER_ROLE.POWER_USER)
			{rdoAdminRole.Visible = false;}		
		}

		private void visibleNewPassword(bool enable)
		{
			chkNewPassword.Visible = enable;
		}

//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			clearForm();
			visibleNewPassword(false);
			enableKeyField(true);
		}

		public void InitEditAction(ApplicationUserProfile aApplicationUserProfile)
		{
			baseEDIT();
			clearForm();
			visibleNewPassword(true);
			setApplicationUserProfile(aApplicationUserProfile);
			enableKeyField(false);
		}

//		============================== Base event ==============================
		private void AddEvent()
		{
			try
			{
				if (ValidateForm() && parentForm.AddRow(getApplicationUserProfile()))
				{
					clearForm();
				}
			}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(Exception ex)
			{Message(ex);}		
		}

		private void EditEvent()
		{
			try
			{
				if (ValidateForm() && parentForm.UpdateRow(getApplicationUserProfile()))
				{
					this.Hide();
				}
			}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(Exception ex)
			{Message(ex);}	
		}

//		============================== event ==============================
		private void frmApplicationUserProfileEntry_Load(object sender, System.EventArgs e)
		{

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

		private void chkNewPassword_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkNewPassword.Checked)
			{
				txtPassword.Enabled = true;
				txtPassword.Text = "password";
			}
			else
			{txtPassword.Enabled = false;}
		}
	}
}
