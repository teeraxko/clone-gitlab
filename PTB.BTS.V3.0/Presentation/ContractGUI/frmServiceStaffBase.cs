using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using SystemFramework.AppMessage;
using SystemFramework.AppException;

using Entity.CommonEntity;
using Entity.ContractEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.CommonFacade;
using Facade.ContractFacade;
using Facade.PiFacade;

using Presentation.CommonGUI;
using Presentation.ContractGUI;
using Presentation.PiGUI;

namespace Presentation.ContractGUI
{
	public class frmServiceStaffBase : ChildFormBase
	{
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{components.Dispose();}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtEmpPosition;
		private System.Windows.Forms.TextBox txtEmpNo;
		private System.Windows.Forms.PictureBox pctEmployee;
		private System.Windows.Forms.TextBox txtEmpName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEmpSection;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPositionType;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtPositionType = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEmpPosition = new System.Windows.Forms.TextBox();
			this.txtEmpNo = new System.Windows.Forms.TextBox();
			this.pctEmployee = new System.Windows.Forms.PictureBox();
			this.txtEmpName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEmpSection = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtPositionType);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtEmpPosition);
			this.groupBox1.Controls.Add(this.txtEmpNo);
			this.groupBox1.Controls.Add(this.pctEmployee);
			this.groupBox1.Controls.Add(this.txtEmpName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtEmpSection);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(816, 160);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// txtPositionType
			// 
			this.txtPositionType.Enabled = false;
			this.txtPositionType.Location = new System.Drawing.Point(96, 120);
			this.txtPositionType.Name = "txtPositionType";
			this.txtPositionType.Size = new System.Drawing.Size(152, 20);
			this.txtPositionType.TabIndex = 8;
			this.txtPositionType.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 32);
			this.label4.TabIndex = 9;
			this.label4.Text = "ประเภทพนักงาน(Service Staff)";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.Location = new System.Drawing.Point(40, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "ตำแหน่ง";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtEmpPosition
			// 
			this.txtEmpPosition.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtEmpPosition.Enabled = false;
			this.txtEmpPosition.Location = new System.Drawing.Point(96, 88);
			this.txtEmpPosition.Name = "txtEmpPosition";
			this.txtEmpPosition.Size = new System.Drawing.Size(384, 20);
			this.txtEmpPosition.TabIndex = 6;
			this.txtEmpPosition.Text = "";
			// 
			// txtEmpNo
			// 
			this.txtEmpNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtEmpNo.Location = new System.Drawing.Point(96, 24);
			this.txtEmpNo.Name = "txtEmpNo";
			this.txtEmpNo.Size = new System.Drawing.Size(56, 20);
			this.txtEmpNo.TabIndex = 1;
			this.txtEmpNo.Text = "";
			// 
			// pctEmployee
			// 
			this.pctEmployee.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.pctEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pctEmployee.Location = new System.Drawing.Point(704, 24);
			this.pctEmployee.Name = "pctEmployee";
			this.pctEmployee.Size = new System.Drawing.Size(88, 104);
			this.pctEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pctEmployee.TabIndex = 7;
			this.pctEmployee.TabStop = false;
			// 
			// txtEmpName
			// 
			this.txtEmpName.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtEmpName.Enabled = false;
			this.txtEmpName.Location = new System.Drawing.Point(160, 24);
			this.txtEmpName.Name = "txtEmpName";
			this.txtEmpName.Size = new System.Drawing.Size(528, 20);
			this.txtEmpName.TabIndex = 2;
			this.txtEmpName.Text = "";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.Location = new System.Drawing.Point(48, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "ส่วนงาน";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtEmpSection
			// 
			this.txtEmpSection.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtEmpSection.Enabled = false;
			this.txtEmpSection.Location = new System.Drawing.Point(96, 56);
			this.txtEmpSection.Name = "txtEmpSection";
			this.txtEmpSection.Size = new System.Drawing.Size(384, 20);
			this.txtEmpSection.TabIndex = 4;
			this.txtEmpSection.Text = "";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "พนักงาน";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// frmServiceStaffBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(832, 181);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmServiceStaffBase";
			this.Text = "frmServiceStaffBase";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private - 
		protected ServiceStaff objServiceStaff;
		private EmployeeFacade facadeEmployee;
		#endregion - Private - 

//      ================================ Constuctor =========================================
		public frmServiceStaffBase()
		{
			InitializeComponent();
			facadeEmployee = new EmployeeFacade();
		}

//      ================================ Private Method =========================================
		private void getServiceStaff(Company value)
		{
			objServiceStaff = new ServiceStaff(value);
			objServiceStaff.EmployeeNo = txtEmpNo.Text;
		}

		private void setVehicle(ServiceStaff value)
		{
			txtEmpNo.Text = value.EmployeeNo;
			txtEmpName.Text = value.EmployeeName;
			txtEmpSection.Text = value.ASection.AFullName.Thai;
			txtEmpPosition.Text = value.APosition.AName.Thai;
			txtPositionType.Text = value.APosition.APositionType.ADescription.Thai;
		}

		private bool ValidateInputEmpNo()
		{
			if(txtEmpNo.Text == "")
			{
				Message(MessageList.Error.E0002, "รหัสพนักงาน");
				txtEmpNo.Focus();
				return false;
			}
			else
				return true;
		}

		private void EnableForm(bool enable)
		{
			txtEmpNo.Enabled = enable;
			txtEmpName.Enabled = enable;
			txtEmpSection.Enabled = enable;
			txtEmpPosition.Enabled = enable;
			txtPositionType.Enabled = enable;
		}

//      ===================================== Base Event =========================================
		protected bool ValidateEmpNo()
		{
			return ValidateInputEmpNo();
		}

		protected virtual void FormServiceStaffList(Company value)
		{
			frmEmplist dialogEmplist = new frmEmplist();

			getServiceStaff(value);
		}
	}
}
