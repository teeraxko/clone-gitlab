using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Facade.PiFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmDepartmentEntry : EntryFormBase
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtENName;
		private System.Windows.Forms.TextBox txtENShort;
		private System.Windows.Forms.TextBox txtTHName;
		private System.Windows.Forms.TextBox txtDeptCode;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtENName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtENShort = new System.Windows.Forms.TextBox();
			this.txtTHName = new System.Windows.Forms.TextBox();
			this.txtDeptCode = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtENName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtENShort);
			this.groupBox1.Controls.Add(this.txtTHName);
			this.groupBox1.Controls.Add(this.txtDeptCode);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(440, 120);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// txtENName
			// 
			this.txtENName.Location = new System.Drawing.Point(96, 88);
			this.txtENName.MaxLength = 50;
			this.txtENName.Name = "txtENName";
			this.txtENName.Size = new System.Drawing.Size(320, 20);
			this.txtENName.TabIndex = 4;
			this.txtENName.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "ชื่อภาษาไทย";
			// 
			// txtENShort
			// 
			this.txtENShort.Location = new System.Drawing.Point(312, 24);
			this.txtENShort.MaxLength = 10;
			this.txtENShort.Name = "txtENShort";
			this.txtENShort.TabIndex = 2;
			this.txtENShort.Text = "";
			// 
			// txtTHName
			// 
			this.txtTHName.Location = new System.Drawing.Point(96, 56);
			this.txtTHName.MaxLength = 50;
			this.txtTHName.Name = "txtTHName";
			this.txtTHName.Size = new System.Drawing.Size(320, 20);
			this.txtTHName.TabIndex = 3;
			this.txtTHName.Text = "";
			// 
			// txtDeptCode
			// 
			this.txtDeptCode.Location = new System.Drawing.Point(96, 24);
			this.txtDeptCode.MaxLength = 2;
			this.txtDeptCode.Name = "txtDeptCode";
			this.txtDeptCode.Size = new System.Drawing.Size(64, 20);
			this.txtDeptCode.TabIndex = 1;
			this.txtDeptCode.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "ชื่อภาษาอังกฤษ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(264, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
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
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(248, 136);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 24);
			this.cmdCancel.TabIndex = 6;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(160, 136);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 24);
			this.cmdOK.TabIndex = 5;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmDepartmentEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(472, 174);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmDepartmentEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ข้อมูลฝ่าย";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		#region - Private -
		private bool isReadonly = true;
		private frmDepartment parentForm;
		private Department objDepartment;
		#endregion - Private -

		//  ===================================== Property ===============================
		public Department getDepartment()
		{
			objDepartment = new Department(parentForm.FacadeDepartment.GetCompany());	
			objDepartment.Code = txtDeptCode.Text;
	        objDepartment.ShortName = txtENShort.Text;
			objDepartment.AFullName.English = txtENName.Text;
			objDepartment.AFullName.Thai = txtTHName.Text;

			return objDepartment;
		}
		public void setDepartment(Department value)
		{
			objDepartment = value;
			txtDeptCode.Text = GUIFunction.GetString(value.Code);
			txtENShort.Text = GUIFunction.GetString(value.AShortName.English);
			txtENName.Text = GUIFunction.GetString(value.AFullName.English);
			txtTHName.Text = GUIFunction.GetString(value.AFullName.Thai);
		}
		//  ===================================== Constructor ============================
		public frmDepartmentEntry(frmDepartment parentForm):base()
		{
			InitializeComponent();						
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMapDepartment");
		}
        //	============================== Private Method ================================
		private void enableKeyField(bool enable)
		{
			txtDeptCode.Enabled = enable;
		}
		private bool ValidateDepartmentKey()
		{
			return (txtDeptCode.Text != "");
		}

		private bool ValidateForm()
		{
			if(ValidateCode() && ValidateENShort() && ValidateTHName() && ValidateENName())
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private bool ValidateCode()
		{
			if(txtDeptCode.Text == "") 
			{
				Message(MessageList.Error.E0002, "รหัส" );
				txtDeptCode.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateENShort()
		{
			if(txtENShort.Text == "") 
			{
				Message(MessageList.Error.E0002, "ชื่อย่อ" );
				txtENShort.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateTHName()
		{
			if(txtTHName.Text == "") 
			{
				Message(MessageList.Error.E0002, "ชื่อภาษาไทย" );
				txtTHName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateENName()
		{
			if(txtENName.Text == "") 
			{
				Message(MessageList.Error.E0002, "ชื่อภาษาอังกฤษ" );
				txtENName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private void clearForm()
		{
			txtDeptCode.Text = "";
			txtENName.Text = "";
			txtENShort.Text = "";
			txtTHName.Text = "";
		}
		
    	//	============================== Public Method =================================
		private DepartmentFacade objDepartmentFacade;
		public DepartmentFacade ObjDepartmentFacade
		{
			set
			{objDepartmentFacade = value;}
		}
		
		public void InitAddAction()
		{
			baseADD();
			clearForm();
			enableKeyField(true);
		}
		public void InitEditAction(Department aDepartment)
		{
			baseEDIT();
			clearForm();
			setDepartment(aDepartment);
			enableKeyField(false);

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}
		public void DeptCode()
		{
			txtDeptCode.Focus();
		}
		public void EngShortFocus()
		{
			txtENShort.Focus();
		}
		//	============================== Base Event ====================================
		private void AddEvent()
		{
			try
			{
				if (ValidateForm() && parentForm.AddRow(getDepartment()))
				{
					clearForm();
					DeptCode();
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
				if (ValidateForm() && parentForm.UpdateRow(getDepartment()))
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
		
		
		//  ================================= Event ================================

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

	}
}
