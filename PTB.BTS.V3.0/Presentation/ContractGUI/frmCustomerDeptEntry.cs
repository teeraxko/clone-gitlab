using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;
using Entity.ContractEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;
using Facade.ContractFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.ContractGUI
{
	public class frmCustomerDeptEntry : EntryFormBase
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.TextBox txtThaiDeptName;
		private System.Windows.Forms.TextBox txtEngDeptName;
		private System.Windows.Forms.TextBox txtCustCode;
		private System.Windows.Forms.TextBox txtCustName;
		private System.Windows.Forms.TextBox txtDeptCode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtShortName;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtThaiDeptName = new System.Windows.Forms.TextBox();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCustCode = new System.Windows.Forms.TextBox();
			this.txtCustName = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtShortName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDeptCode = new System.Windows.Forms.TextBox();
			this.txtEngDeptName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "รหัสฝ่าย";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "ชื่อฝ่าย (ภาษาไทย)";
			// 
			// txtThaiDeptName
			// 
			this.txtThaiDeptName.Location = new System.Drawing.Point(136, 120);
			this.txtThaiDeptName.MaxLength = 50;
			this.txtThaiDeptName.Name = "txtThaiDeptName";
			this.txtThaiDeptName.Size = new System.Drawing.Size(352, 20);
			this.txtThaiDeptName.TabIndex = 5;
			this.txtThaiDeptName.Text = "";
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(232, 216);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 7;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(312, 216);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 8;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "ลูกค้า";
			// 
			// txtCustCode
			// 
			this.txtCustCode.Enabled = false;
			this.txtCustCode.Location = new System.Drawing.Point(136, 24);
			this.txtCustCode.MaxLength = 5;
			this.txtCustCode.Name = "txtCustCode";
			this.txtCustCode.Size = new System.Drawing.Size(80, 20);
			this.txtCustCode.TabIndex = 1;
			this.txtCustCode.Text = "";
			// 
			// txtCustName
			// 
			this.txtCustName.Enabled = false;
			this.txtCustName.Location = new System.Drawing.Point(224, 24);
			this.txtCustName.MaxLength = 50;
			this.txtCustName.Name = "txtCustName";
			this.txtCustName.Size = new System.Drawing.Size(328, 20);
			this.txtCustName.TabIndex = 2;
			this.txtCustName.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtShortName);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtDeptCode);
			this.groupBox1.Controls.Add(this.txtEngDeptName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtThaiDeptName);
			this.groupBox1.Controls.Add(this.txtCustCode);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtCustName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(584, 192);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// txtShortName
			// 
			this.txtShortName.Location = new System.Drawing.Point(136, 88);
			this.txtShortName.MaxLength = 5;
			this.txtShortName.Name = "txtShortName";
			this.txtShortName.Size = new System.Drawing.Size(152, 20);
			this.txtShortName.TabIndex = 4;
			this.txtShortName.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 23);
			this.label5.TabIndex = 13;
			this.label5.Text = "ชื่อย่อฝ่าย";
			// 
			// txtDeptCode
			// 
			this.txtDeptCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtDeptCode.Location = new System.Drawing.Point(136, 56);
			this.txtDeptCode.MaxLength = 3;
			this.txtDeptCode.Name = "txtDeptCode";
			this.txtDeptCode.Size = new System.Drawing.Size(80, 20);
			this.txtDeptCode.TabIndex = 3;
			this.txtDeptCode.Text = "";
			// 
			// txtEngDeptName
			// 
			this.txtEngDeptName.Location = new System.Drawing.Point(136, 152);
			this.txtEngDeptName.MaxLength = 50;
			this.txtEngDeptName.Name = "txtEngDeptName";
			this.txtEngDeptName.Size = new System.Drawing.Size(352, 20);
			this.txtEngDeptName.TabIndex = 6;
			this.txtEngDeptName.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "ชื่อฝ่าย (ภาษาอังกฤษ)";
			// 
			// frmCustomerDeptEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(618, 256);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmCustomerDeptEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmCustomerDeptrationEntry";
			this.Load += new System.EventHandler(this.frmCustomerDeptEntry_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private bool isReadonly = true;
		private frmCustomerDept parentForm;
		private CustomerDepartment aCustomerDepartment;
		#endregion

		//		============================== Property ==============================
		private Customer objCustomer;
		public Customer ObjCustomer
		{
			get
			{
				return objCustomer;
			}
			set
			{
				objCustomer = value;
			}
		}
		public void setCustomer()
		{
			txtCustCode.Text = parentForm.Customer.Code;
			txtCustName.Text = parentForm.Customer.AName.English;			
		}

		public void setCustomerDept(CustomerDepartment value)
		{
			txtCustCode.Text = GUIFunction.GetString(value.ACustomer.Code);
			txtCustName.Text = value.ACustomer.AName.English;
			txtDeptCode.Text = GUIFunction.GetString(value.Code);
			txtShortName.Text = value.ShortName;
			txtThaiDeptName.Text = value.AName.Thai;
			txtEngDeptName.Text = value.AName.English;
			txtThaiDeptName.Focus();
		}
		public CustomerDepartment getCustomerDept()
		{
			CustomerDepartment objCustomerDept = new CustomerDepartment();
			objCustomerDept.ACustomer.Code = txtCustCode.Text;
			objCustomerDept.ACustomer.AName.English = txtCustName.Text;                    
			objCustomerDept.Code = txtDeptCode.Text;
			objCustomerDept.ShortName  = txtShortName.Text;
			objCustomerDept.AName.Thai = txtThaiDeptName.Text;
			objCustomerDept.AName.English = txtEngDeptName.Text;
			return objCustomerDept;
		}
	
//		============================== Constructor ==============================
		public frmCustomerDeptEntry(frmCustomerDept parentForm):base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractCustomerDepartment");
		}
//		============================== private method ==============================
		private void enableKeyField(bool enable)
		{
			txtDeptCode.Enabled = enable;
		}

		private void clearForm()
		{
			txtDeptCode.Text = "";
			txtThaiDeptName.Text = "";
			txtShortName.Text = "";
			txtEngDeptName.Text = "";
			txtDeptCode.Focus();
		}
		
		private bool ValidateForm()
		{
			return validate0() && validate1() && validate2() && validate3()&& validate4();
		}
		private bool validate0()
		{
			if ((txtDeptCode.Text == "ZZZ"))
			{
				Message(MessageList.Error.E0026);
				txtDeptCode.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate1()
		{
			if (txtDeptCode.Text == "")
			{
				Message(MessageList.Error.E0002, "รหัสฝ่าย");
				txtDeptCode.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate2()
		{
			if (txtShortName.Text == "")
			{
				Message(MessageList.Error.E0002, "ชื่อย่อฝ่าย");
				txtShortName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate3()
		{
			if (txtThaiDeptName.Text == "")
			{
				Message(MessageList.Error.E0002, "ชื่อฝ่าย(ภาษาไทย)");
				txtThaiDeptName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate4()
		{
			if (txtEngDeptName.Text == "")
			{
				Message(MessageList.Error.E0002, "ชื่อฝ่าย(ภาษาอังกฤษ)");
				txtEngDeptName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate5()
		{
			if (txtDeptCode.Text == "ZZZ")
			{
				Message(MessageList.Error.E0013, "เพิ่มรหัสฝ่ายนี้ได้","เป็นรหัสของระบบ");
				txtDeptCode.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			clearForm();
			setCustomer();	
			enableKeyField(true);
			this.Text = "เพิ่มข้อมูลฝ่ายลูกค้า";
		}

		public void InitEditAction(CustomerDepartment value)
		{
			baseEDIT();
			clearForm();
			setCustomer();
			aCustomerDepartment = value;
			enableKeyField(false);
			this.Text = "แก้ไขข้อมูลฝ่ายลูกค้า";

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}
		public void CustomerDeptCodeFocus()
		{
			txtDeptCode.Focus();
		}
		public void CustomerDeptShortNameFocus()
		{
			txtShortName.Focus();
		}
//		============================== Base event ==============================
		private void AddEvent()
		{
			try
			{
				
				if (ValidateForm() && parentForm.AddRow(getCustomerDept()))
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
				txtDeptCode.Focus();
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
				
				if (ValidateForm() && parentForm.UpdateRow(getCustomerDept()))
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
//		================================= event ================================
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

		private void frmCustomerDeptEntry_Load(object sender, System.EventArgs e)
		{
			if(action == ActionType.ADD)
			{
				 clearForm();
			}
			else
		    {
		    	 setCustomerDept(aCustomerDepartment);
		    }
		}
	}	
}
