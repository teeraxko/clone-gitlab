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
	public class frmTitleEntry : EntryFormBase
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.TextBox txtEngName;
		private System.Windows.Forms.TextBox txtEngShortName;
		private System.Windows.Forms.TextBox txtThaiName;
		private System.Windows.Forms.TextBox txtCode;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtEngName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtEngShortName = new System.Windows.Forms.TextBox();
			this.txtThaiName = new System.Windows.Forms.TextBox();
			this.txtCode = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtEngName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtEngShortName);
			this.groupBox1.Controls.Add(this.txtThaiName);
			this.groupBox1.Controls.Add(this.txtCode);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(456, 128);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			// 
			// txtEngName
			// 
			this.txtEngName.Location = new System.Drawing.Point(120, 88);
			this.txtEngName.MaxLength = 50;
			this.txtEngName.Name = "txtEngName";
			this.txtEngName.Size = new System.Drawing.Size(320, 20);
			this.txtEngName.TabIndex = 4;
			this.txtEngName.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "ชื่อภาษาไทย";
			// 
			// txtEngShortName
			// 
			this.txtEngShortName.Location = new System.Drawing.Point(336, 24);
			this.txtEngShortName.MaxLength = 10;
			this.txtEngShortName.Name = "txtEngShortName";
			this.txtEngShortName.Size = new System.Drawing.Size(104, 20);
			this.txtEngShortName.TabIndex = 2;
			this.txtEngShortName.Text = "";
			// 
			// txtThaiName
			// 
			this.txtThaiName.Location = new System.Drawing.Point(120, 56);
			this.txtThaiName.MaxLength = 50;
			this.txtThaiName.Name = "txtThaiName";
			this.txtThaiName.Size = new System.Drawing.Size(320, 20);
			this.txtThaiName.TabIndex = 3;
			this.txtThaiName.Text = "";
			// 
			// txtCode
			// 
			this.txtCode.Location = new System.Drawing.Point(120, 24);
			this.txtCode.MaxLength = 2;
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(64, 20);
			this.txtCode.TabIndex = 1;
			this.txtCode.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "ชื่อภาษาอังกฤษ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(280, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "ชื่อย่อ";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "รหัส";
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(171, 152);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 24);
			this.cmdOK.TabIndex = 14;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(251, 152);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 24);
			this.cmdCancel.TabIndex = 15;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmTitleEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(496, 190);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmTitleEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmTitleEntry";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		public frmTitle parentForm;
		private Title objTitle;
		#endregion

//		============================== Property ==============================
		public Title getTitle()
		{
			objTitle = new Title();
			objTitle.Code= txtCode.Text;
			objTitle.AShortName.English= txtEngShortName.Text;
            ictus.Common.Entity.Description description = new ictus.Common.Entity.Description();
            description.Thai = txtThaiName.Text;
            description.English = txtEngName.Text;
            objTitle.AName = description;

			return objTitle;
		}
		public void setTitle(Title value)
		{
			objTitle = value;
			txtCode.Text = GUIFunction.GetString(value.Code);
			txtEngShortName.Text = GUIFunction.GetString(value.AShortName.English);
			txtThaiName.Text = GUIFunction.GetString(value.AName.Thai);
			txtEngName.Text = GUIFunction.GetString(value.AName.English);
		}

//		============================== Constructor ==============================
		public frmTitleEntry()
		{
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIPositionTitle");
		}

//		============================== private method ==============================
		private void enableKeyField(bool enable)
		{
			txtCode.Enabled = enable;
		}
		private void clearForm()
		{
			txtCode.Text = "";
			txtEngShortName.Text = "";
			txtThaiName.Text = "";
			txtEngName.Text = "";
		}
		private bool Validate1()
		{
			if(txtCode.Text == "")
			{
				Message(MessageList.Error.E0002, "รหัส" );
				txtCode.Focus();
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
		
		private bool ValidateForm()
		{
			return Validate1() && Validate2() && Validate3() && Validate4();
		}
//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			clearForm();
			enableKeyField(true);
		}

		public void InitEditAction(Title aTitle)
		{
			baseEDIT();
			clearForm();
			setTitle(aTitle);
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
				if (ValidateForm() && parentForm.AddRow(getTitle()))
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
				if (ValidateForm() && parentForm.UpdateRow(getTitle()))
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
	}
}
