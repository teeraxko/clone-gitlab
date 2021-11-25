using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Facade.CommonFacade;

using Presentation.VehicleGUI;

using SystemFramework.AppException;
using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmLogIn : FormBase
	{
		#region - Constant -
			enum Mode
			{
				LogIn,
				ChangePassword
			}
		#endregion

		#region - Private - 
			private Mode mode = Mode.LogIn;
			private LogInFacade facadelogIn;
		#endregion
        private System.Windows.Forms.Timer timer1;

		//============================== Property ==============================
		private bool changePasswordOnly = false;
		public bool ChangePasswordOnly
		{
			set
			{
				changePasswordOnly = value;

				mode = Mode.ChangePassword;
				txbUserName.Text = UserProfile.UserID;
				txbUserName.Enabled = false;
				btnOption.Visible = false;
			}
		}

		//============================== Constructor ==============================
		#region Windows Form Designer generated code
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
		private System.Windows.Forms.ErrorProvider erpLogIn;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.Label lblPassword;
		private ASC.Control.ASCTextBox txbUserName;
        private ASC.Control.ASCTextBox txbPassword;
		private System.Windows.Forms.PictureBox ptbLogin;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnOption;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblNewPassword;
		private System.Windows.Forms.Label lblConfirmPassword;
        private ASC.Control.ASCTextBox txbNewPassword;
        private ASC.Control.ASCTextBox txbConfirmPassword;
		private System.ComponentModel.IContainer components;

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogIn));
            this.lblUserName = new System.Windows.Forms.Label();
            this.ptbLogin = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txbUserName = new ASC.Control.ASCTextBox(this.components);
            this.txbPassword = new ASC.Control.ASCTextBox(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOption = new System.Windows.Forms.Button();
            this.txbNewPassword = new ASC.Control.ASCTextBox(this.components);
            this.txbConfirmPassword = new ASC.Control.ASCTextBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.erpLogIn = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogin)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpLogIn)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblUserName.Location = new System.Drawing.Point(80, 24);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(57, 16);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "รหัสผู้ใช้ : ";
            // 
            // ptbLogin
            // 
            this.ptbLogin.Image = ((System.Drawing.Image)(resources.GetObject("ptbLogin.Image")));
            this.ptbLogin.Location = new System.Drawing.Point(8, 16);
            this.ptbLogin.Name = "ptbLogin";
            this.ptbLogin.Size = new System.Drawing.Size(60, 70);
            this.ptbLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ptbLogin.TabIndex = 1;
            this.ptbLogin.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.Location = new System.Drawing.Point(192, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPassword.Location = new System.Drawing.Point(80, 56);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 16);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "รหัสผ่าน : ";
            // 
            // txbUserName
            // 
            this.txbUserName.BackColor = System.Drawing.SystemColors.Info;
            this.txbUserName.Location = new System.Drawing.Point(198, 24);
            this.txbUserName.MaxLength = 20;
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(170, 20);
            this.txbUserName.TabIndex = 1;
            this.txbUserName.Enter += new System.EventHandler(this.txbUserName_Enter);
            this.txbUserName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txbUserName_MouseDown);
            this.txbUserName.TextChanged += new System.EventHandler(this.txbUserName_TextChanged);
            // 
            // txbPassword
            // 
            this.txbPassword.BackColor = System.Drawing.SystemColors.Info;
            this.txbPassword.Location = new System.Drawing.Point(198, 56);
            this.txbPassword.MaxLength = 20;
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(170, 20);
            this.txbPassword.TabIndex = 2;
            this.txbPassword.Enter += new System.EventHandler(this.txbPassword_Enter);
            this.txbPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txbPassword_MouseDown);
            this.txbPassword.TextChanged += new System.EventHandler(this.txbPassword_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnOK.Location = new System.Drawing.Point(112, 152);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "ตกลง";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnOption
            // 
            this.btnOption.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnOption.Location = new System.Drawing.Point(272, 152);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(96, 23);
            this.btnOption.TabIndex = 7;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // txbNewPassword
            // 
            this.txbNewPassword.BackColor = System.Drawing.SystemColors.Info;
            this.txbNewPassword.Location = new System.Drawing.Point(198, 88);
            this.txbNewPassword.MaxLength = 20;
            this.txbNewPassword.Name = "txbNewPassword";
            this.txbNewPassword.PasswordChar = '*';
            this.txbNewPassword.Size = new System.Drawing.Size(170, 20);
            this.txbNewPassword.TabIndex = 3;
            this.txbNewPassword.Visible = false;
            this.txbNewPassword.Enter += new System.EventHandler(this.txbNewPassword_Enter);
            this.txbNewPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txbNewPassword_MouseDown);
            this.txbNewPassword.TextChanged += new System.EventHandler(this.txbNewPassword_TextChanged);
            // 
            // txbConfirmPassword
            // 
            this.txbConfirmPassword.BackColor = System.Drawing.SystemColors.Info;
            this.txbConfirmPassword.Location = new System.Drawing.Point(198, 120);
            this.txbConfirmPassword.MaxLength = 20;
            this.txbConfirmPassword.Name = "txbConfirmPassword";
            this.txbConfirmPassword.PasswordChar = '*';
            this.txbConfirmPassword.Size = new System.Drawing.Size(170, 20);
            this.txbConfirmPassword.TabIndex = 4;
            this.txbConfirmPassword.Visible = false;
            this.txbConfirmPassword.Enter += new System.EventHandler(this.txbConfirmPassword_Enter);
            this.txbConfirmPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txbConfirmPassword_MouseDown);
            this.txbConfirmPassword.TextChanged += new System.EventHandler(this.txbConfirmPassword_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.lblConfirmPassword);
            this.groupBox1.Controls.Add(this.lblNewPassword);
            this.groupBox1.Controls.Add(this.ptbLogin);
            this.groupBox1.Controls.Add(this.txbUserName);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.txbPassword);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.txbConfirmPassword);
            this.groupBox1.Controls.Add(this.txbNewPassword);
            this.groupBox1.Controls.Add(this.btnOption);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 184);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(80, 120);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(103, 16);
            this.lblConfirmPassword.TabIndex = 11;
            this.lblConfirmPassword.Text = "ยืนยันรหัสผ่านใหม่ : ";
            this.lblConfirmPassword.Visible = false;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblNewPassword.Location = new System.Drawing.Point(80, 88);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(77, 16);
            this.lblNewPassword.TabIndex = 10;
            this.lblNewPassword.Text = "รหัสผ่านใหม่ : ";
            this.lblNewPassword.Visible = false;
            // 
            // erpLogIn
            // 
            this.erpLogIn.ContainerControl = this;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmLogIn
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(416, 192);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogIn";
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Window;
            this.Load += new System.EventHandler(this.frmLogIN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpLogIn)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmLogIn());
		}

		public frmLogIn()
		{
			InitializeComponent();
			facadelogIn = new LogInFacade();
		}

		//============================== Private Method ==============================
		#region - Private Method -
		private void setSelectedText(TextBox control)
		{
			control.SelectionStart = 0;
			control.SelectionLength = control.Text.Length;
		}

		private void clearOption()
		{
			txbNewPassword.Text = "";
			erpLogIn.SetError(txbNewPassword, "");
			txbConfirmPassword.Text = "";
			erpLogIn.SetError(txbConfirmPassword, "");
		}

		private void changeMode(Mode value)
		{
			if(value == Mode.LogIn)
			{
				Height = 160;
				lblPassword.Text = "รหัสผ่าน : ";
				btnOption.Text = "เปลี่ยนรหัส >>";
				visibleChangePassword(false);
			}
			else
			{
				Height = 225;
				lblPassword.Text = "รหัสผ่านเดิม : ";
				btnOption.Text = "เข้าสู่ระบบ <<";
				visibleChangePassword(true);
				clearOption();
			}
		}

		private void visibleChangePassword(bool value)
		{
			lblNewPassword.Visible = value;
			lblConfirmPassword.Visible = value;
			txbNewPassword.Visible = value;
			txbConfirmPassword.Visible = value;
		}

		private bool isValidLogIn()
		{
			erpLogIn.SetError(txbUserName, "");
			erpLogIn.SetError(txbPassword, "");

			if(txbUserName.Text.Trim()=="")
			{
				erpLogIn.SetError(txbUserName, "กรุณากรอกรหัสผู้ใช้");
				txbUserName.Focus();
				return false;
			}
			else
			{
				if(txbPassword.Text.Trim()=="")
				{
					erpLogIn.SetError(txbPassword, "กรุณากรอกรหัสผ่าน");
					txbPassword.Focus();
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		private bool isValidChangePassword()
		{
			if(isValidLogIn())
			{
				txbNewPassword.Text = txbNewPassword.Text.Trim();
				txbConfirmPassword.Text = txbConfirmPassword.Text.Trim();
				erpLogIn.SetError(txbNewPassword, "");
				erpLogIn.SetError(txbConfirmPassword, "");

				if(txbNewPassword.Text == "")
				{
					erpLogIn.SetError(txbNewPassword, "กรุณากรอกรหัสผ่านที่ต้องการเปลี่ยน");
					txbNewPassword.Focus();
					return false;
				}
				else
				{
					if(txbConfirmPassword.Text == "")
					{
						txbConfirmPassword.Focus();
						erpLogIn.SetError(txbConfirmPassword, "กรุณายืนยันรหัสผ่านใหม่ที่ต้องการเปลี่ยน");
						return false;
					}
					else
					{
						if(txbNewPassword.Text == txbConfirmPassword.Text)
						{
							if(txbPassword.Text == txbNewPassword.Text)
							{
								txbNewPassword.Focus();
								setSelectedText(txbNewPassword);
								errorMessage("รหัสผ่านใหม่ ซ้ำกับ รหัสผ่านเดิม");
								return false;
							}
							else
							{
								return true;
							}
						}
						else
						{
							txbConfirmPassword.Focus();
							setSelectedText(txbConfirmPassword);
							errorMessage("รหัสผ่านใหม่ ไม่ตรงกับ รหัสผ่านยืนยัน");
							return false;
						}
					}
				}
			}
			else
			{
				return false;
			}
		}

		private void validateBlankTextbox(TextBox control)
		{
			if(control.Text == "")
			{
				erpLogIn.SetError(control, "กรุณากรอก");
			}
			else
			{
				erpLogIn.SetError(control, "");
			}		
		}
		#endregion
	
		private void LogIN()
		{
			if(isValidLogIn())
			{
				txbUserName.Focus();
				try
				{
					ApplicationUserProfile userProfile = facadelogIn.GetUserProfile();
					if(userProfile == null)
					{
						txbPassword.Focus();
						setSelectedText(txbPassword);
						errorMessage("รหัสผ่านไม่ถูกต้อง\nกรุณากรอกใหม่อีกครัง");					
					}
					else
					{
						frmMain objfrmMain = new frmMain();
						UserProfile.UserID = userProfile.UserName;
						UserProfile.UserROLE = userProfile.UserRole;

						ApplicationUserPermission userPermission = facadelogIn.GetUserPermission(userProfile);
						UserProfile.AppUserPermission = userPermission;

						objfrmMain.LoadMenu(userPermission);						

						frmDailyProcess formDailyProcess = new frmDailyProcess();
						formDailyProcess.MdiParent = objfrmMain;

						this.Hide();
						objfrmMain.Show();
						formDailyProcess.Show();
						
						bool result = formDailyProcess.UpdateDailyProcess(false);

						if(result)
						{
							this.Hide();
							facadelogIn = null;
						}	
						else
						{
							this.Show();
							objfrmMain.Close();
						}
						
						formDailyProcess.Close();
						formDailyProcess = null;
						userPermission = null;
					}
					userProfile = null;
				}
				catch(DataInvalidException ex)
				{
					txbPassword.Focus();
					setSelectedText(txbPassword);
					errorMessage("รหัสผ่านไม่ถูกต้อง\nกรุณากรอกใหม่อีกครัง");
					setNull(ex);
				}
				finally
				{}
			}
		}

		private void setNull(DataInvalidException ex)
		{
			ex = null;
		}

		private void ChangePassword()
		{
			if(isValidChangePassword())
			{
				if(facadelogIn.ChangePassword(txbNewPassword.Text))
				{
					infoMessage("ระบบได้ทำการเปลี่ยนรหัสผ่านเรียบร้อยแล้ว");
				}
				if(changePasswordOnly)
				{
					this.Close();
				}
				else
				{
					mode = Mode.LogIn;
					changeMode(mode);

					txbPassword.Text = "";
					erpLogIn.SetError(txbPassword, "");
					txbPassword.Focus();			
				}
			}
		}

		//============================== Base Event ==============================
		private void AcceptEvent()
		{
			try
			{
				facadelogIn.UserName = txbUserName.Text;
				facadelogIn.Password = txbPassword.Text;
				if(mode == Mode.LogIn)
				{
					LogIN();
				}
				else
				{
					ChangePassword();
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
			finally
			{}
		}

		private void CancelEvent()
		{
			if(changePasswordOnly)
			{
				this.Hide();
			}
			else
			{
				Application.Exit();
			}
		}

		private void OptionEvent()
		{
			if(mode == Mode.LogIn)
			{
				mode = Mode.ChangePassword;
			}
			else
			{
				mode = Mode.LogIn;
			}
			changeMode(mode);
		}

		//============================== Event ==============================
		private void frmLogIN_Load(object sender, System.EventArgs e)
		{
			this.Opacity = 0;
			changeMode(mode);
		}

		#region - Event -
			private void btnOK_Click(object sender, System.EventArgs e)
			{
				AcceptEvent();
			}
			
			private void btnCancel_Click(object sender, System.EventArgs e)
			{
				CancelEvent();

//				Message(new Exception());
			}

			private void btnOption_Click(object sender, System.EventArgs e)
			{
				OptionEvent();
			}

			private void txbUserName_TextChanged(object sender, System.EventArgs e)
			{
				validateBlankTextbox(txbUserName);
			}

			private void txbPassword_TextChanged(object sender, System.EventArgs e)
			{
				validateBlankTextbox(txbPassword);
			}

			private void txbNewPassword_TextChanged(object sender, System.EventArgs e)
			{
				validateBlankTextbox(txbNewPassword);
			}

			private void txbConfirmPassword_TextChanged(object sender, System.EventArgs e)
			{
				validateBlankTextbox(txbConfirmPassword);
			}
			
			private void txbUserName_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				setSelectedText(txbUserName);
			}

			private void txbPassword_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				setSelectedText(txbPassword);
			}

			private void txbNewPassword_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				setSelectedText(txbNewPassword);
			}
			
			private void txbConfirmPassword_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				setSelectedText(txbConfirmPassword);
			}
			
			private void txbUserName_Enter(object sender, System.EventArgs e)
			{
				setSelectedText(txbUserName);
			}

			private void txbPassword_Enter(object sender, System.EventArgs e)
			{
				setSelectedText(txbPassword);
			}

			private void txbNewPassword_Enter(object sender, System.EventArgs e)
			{
				setSelectedText(txbNewPassword);
			}

			private void txbConfirmPassword_Enter(object sender, System.EventArgs e)
			{
				setSelectedText(txbConfirmPassword);
			}
		#endregion

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.Opacity += 0.1;
			if(this.Opacity == 1)
			{
				timer1.Enabled = false;
			}
		}

	}
}