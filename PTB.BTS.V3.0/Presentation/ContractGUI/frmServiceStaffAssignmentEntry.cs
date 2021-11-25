using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

using Entity.AttendanceEntities;
using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.VehicleEntities;

using Facade.CommonFacade;
using Facade.ContractFacade;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;
using System.Collections.Generic;

namespace Presentation.ContractGUI
{
	public class frmServiceStaffAssignmentEntry : Presentation.CommonGUI.EntryFormBase
	{
		#region Designer generated code
		private System.Windows.Forms.GroupBox gpbAssignedEmployee;
		private System.Windows.Forms.TextBox txtMainServiceStaffType;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtMainPosition;
		private System.Windows.Forms.TextBox txtMainEmpName;
		private System.Windows.Forms.TextBox txtMainEmpNo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.GroupBox gpbDetailAssignment;
		private System.Windows.Forms.TextBox txtHirerName;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cboAssignmentRole;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dtpToDate;
		private System.Windows.Forms.DateTimePicker dtpFromDate;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox gpbEmpInfo;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtAssignPosition;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtAssignEmpNo;
		private System.Windows.Forms.TextBox txtAssignEmpName;
		private System.Windows.Forms.TextBox txtAssignServiceStaffType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtContractNoXXX;
		private System.Windows.Forms.TextBox txtContractNoMM;
        private System.Windows.Forms.TextBox txtContractNoYY;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txbCustomerDepartment;
		private System.Windows.Forms.TextBox txbCustomer;
		private System.Windows.Forms.DateTimePicker dtpMainToDate;
        private System.Windows.Forms.DateTimePicker dtpMainFromDate;
		private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
		private System.Windows.Forms.DateTimePicker dtpContractToDate;
		private System.Windows.Forms.DateTimePicker dtpContractFromDate;
        private Label label17;
        private Label label20;
        private Label label12;
        private Label label22;
        private TextBox txtRunningNo;
        private TextBox txtPlatePrefix;
        private Label label21;
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private void InitializeComponent()
		{
            this.gpbAssignedEmployee = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpMainToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpMainFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMainServiceStaffType = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMainPosition = new System.Windows.Forms.TextBox();
            this.txtMainEmpName = new System.Windows.Forms.TextBox();
            this.txtMainEmpNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.gpbDetailAssignment = new System.Windows.Forms.GroupBox();
            this.txtHirerName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboAssignmentRole = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gpbEmpInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAssignPosition = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAssignEmpNo = new System.Windows.Forms.TextBox();
            this.txtAssignEmpName = new System.Windows.Forms.TextBox();
            this.txtAssignServiceStaffType = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpContractToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpContractFromDate = new System.Windows.Forms.DateTimePicker();
            this.txbCustomerDepartment = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txbCustomer = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtContractNoXXX = new System.Windows.Forms.TextBox();
            this.txtContractNoMM = new System.Windows.Forms.TextBox();
            this.txtContractNoYY = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtRunningNo = new System.Windows.Forms.TextBox();
            this.txtPlatePrefix = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.gpbAssignedEmployee.SuspendLayout();
            this.gpbDetailAssignment.SuspendLayout();
            this.gpbEmpInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbAssignedEmployee
            // 
            this.gpbAssignedEmployee.Controls.Add(this.label17);
            this.gpbAssignedEmployee.Controls.Add(this.label18);
            this.gpbAssignedEmployee.Controls.Add(this.dtpMainToDate);
            this.gpbAssignedEmployee.Controls.Add(this.dtpMainFromDate);
            this.gpbAssignedEmployee.Controls.Add(this.label3);
            this.gpbAssignedEmployee.Controls.Add(this.label9);
            this.gpbAssignedEmployee.Controls.Add(this.txtMainServiceStaffType);
            this.gpbAssignedEmployee.Controls.Add(this.label10);
            this.gpbAssignedEmployee.Controls.Add(this.txtMainPosition);
            this.gpbAssignedEmployee.Controls.Add(this.txtMainEmpName);
            this.gpbAssignedEmployee.Controls.Add(this.txtMainEmpNo);
            this.gpbAssignedEmployee.Controls.Add(this.label7);
            this.gpbAssignedEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gpbAssignedEmployee.Location = new System.Drawing.Point(16, 240);
            this.gpbAssignedEmployee.Name = "gpbAssignedEmployee";
            this.gpbAssignedEmployee.Size = new System.Drawing.Size(528, 136);
            this.gpbAssignedEmployee.TabIndex = 107;
            this.gpbAssignedEmployee.TabStop = false;
            this.gpbAssignedEmployee.Text = "แทนพนักงาน";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label17.Location = new System.Drawing.Point(225, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 17);
            this.label17.TabIndex = 69;
            this.label17.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label18.Location = new System.Drawing.Point(16, 104);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "ระยะเวลาจ่ายงาน";
            // 
            // dtpMainToDate
            // 
            this.dtpMainToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpMainToDate.Enabled = false;
            this.dtpMainToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpMainToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMainToDate.Location = new System.Drawing.Point(247, 102);
            this.dtpMainToDate.Name = "dtpMainToDate";
            this.dtpMainToDate.Size = new System.Drawing.Size(104, 20);
            this.dtpMainToDate.TabIndex = 27;
            // 
            // dtpMainFromDate
            // 
            this.dtpMainFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpMainFromDate.Enabled = false;
            this.dtpMainFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpMainFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMainFromDate.Location = new System.Drawing.Point(112, 102);
            this.dtpMainFromDate.Name = "dtpMainFromDate";
            this.dtpMainFromDate.Size = new System.Drawing.Size(104, 20);
            this.dtpMainFromDate.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(16, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Service Staff";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.Location = new System.Drawing.Point(16, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "ประเภทพนักงาน";
            // 
            // txtMainServiceStaffType
            // 
            this.txtMainServiceStaffType.Enabled = false;
            this.txtMainServiceStaffType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtMainServiceStaffType.Location = new System.Drawing.Point(112, 76);
            this.txtMainServiceStaffType.Name = "txtMainServiceStaffType";
            this.txtMainServiceStaffType.Size = new System.Drawing.Size(400, 20);
            this.txtMainServiceStaffType.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.Location = new System.Drawing.Point(16, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "ตำแหน่ง";
            // 
            // txtMainPosition
            // 
            this.txtMainPosition.Enabled = false;
            this.txtMainPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtMainPosition.Location = new System.Drawing.Point(112, 50);
            this.txtMainPosition.Name = "txtMainPosition";
            this.txtMainPosition.Size = new System.Drawing.Size(400, 20);
            this.txtMainPosition.TabIndex = 11;
            // 
            // txtMainEmpName
            // 
            this.txtMainEmpName.Enabled = false;
            this.txtMainEmpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtMainEmpName.Location = new System.Drawing.Point(176, 24);
            this.txtMainEmpName.Name = "txtMainEmpName";
            this.txtMainEmpName.Size = new System.Drawing.Size(336, 20);
            this.txtMainEmpName.TabIndex = 10;
            // 
            // txtMainEmpNo
            // 
            this.txtMainEmpNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtMainEmpNo.Location = new System.Drawing.Point(112, 24);
            this.txtMainEmpNo.MaxLength = 5;
            this.txtMainEmpNo.Name = "txtMainEmpNo";
            this.txtMainEmpNo.Size = new System.Drawing.Size(56, 20);
            this.txtMainEmpNo.TabIndex = 9;
            this.txtMainEmpNo.DoubleClick += new System.EventHandler(this.txtMainEmpNo_DoubleClick);
            this.txtMainEmpNo.TextChanged += new System.EventHandler(this.txtMainEmpNo_TextChanged);
            this.txtMainEmpNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMainEmpNo_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(16, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "แทนพนักงานรหัส";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdCancel.Location = new System.Drawing.Point(284, 516);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 24);
            this.cmdCancel.TabIndex = 104;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdOK.Location = new System.Drawing.Point(201, 516);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 24);
            this.cmdOK.TabIndex = 103;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // gpbDetailAssignment
            // 
            this.gpbDetailAssignment.Controls.Add(this.txtHirerName);
            this.gpbDetailAssignment.Controls.Add(this.label8);
            this.gpbDetailAssignment.Controls.Add(this.cboAssignmentRole);
            this.gpbDetailAssignment.Controls.Add(this.label6);
            this.gpbDetailAssignment.Controls.Add(this.dtpToDate);
            this.gpbDetailAssignment.Controls.Add(this.dtpFromDate);
            this.gpbDetailAssignment.Controls.Add(this.label5);
            this.gpbDetailAssignment.Controls.Add(this.label4);
            this.gpbDetailAssignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gpbDetailAssignment.Location = new System.Drawing.Point(16, 112);
            this.gpbDetailAssignment.Name = "gpbDetailAssignment";
            this.gpbDetailAssignment.Size = new System.Drawing.Size(528, 128);
            this.gpbDetailAssignment.TabIndex = 106;
            this.gpbDetailAssignment.TabStop = false;
            this.gpbDetailAssignment.Text = "รายละเอียดใบจ่ายงาน";
            // 
            // txtHirerName
            // 
            this.txtHirerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtHirerName.Location = new System.Drawing.Point(112, 96);
            this.txtHirerName.Name = "txtHirerName";
            this.txtHirerName.Size = new System.Drawing.Size(400, 20);
            this.txtHirerName.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.Location = new System.Drawing.Point(16, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "ชื่อนายจ้าง";
            // 
            // cboAssignmentRole
            // 
            this.cboAssignmentRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAssignmentRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboAssignmentRole.Location = new System.Drawing.Point(112, 72);
            this.cboAssignmentRole.Name = "cboAssignmentRole";
            this.cboAssignmentRole.Size = new System.Drawing.Size(104, 21);
            this.cboAssignmentRole.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(16, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "สถานะ";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(112, 48);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(104, 20);
            this.dtpToDate.TabIndex = 6;
            this.dtpToDate.Leave += new System.EventHandler(this.dtpToDate_Leave);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(112, 24);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(104, 20);
            this.dtpFromDate.TabIndex = 5;
            this.dtpFromDate.Leave += new System.EventHandler(this.dtpFromDate_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(16, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "วันที่สิ้นสุด";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "วันที่เริ่มต้น";
            // 
            // gpbEmpInfo
            // 
            this.gpbEmpInfo.Controls.Add(this.label1);
            this.gpbEmpInfo.Controls.Add(this.label14);
            this.gpbEmpInfo.Controls.Add(this.label13);
            this.gpbEmpInfo.Controls.Add(this.txtAssignPosition);
            this.gpbEmpInfo.Controls.Add(this.label2);
            this.gpbEmpInfo.Controls.Add(this.txtAssignEmpNo);
            this.gpbEmpInfo.Controls.Add(this.txtAssignEmpName);
            this.gpbEmpInfo.Controls.Add(this.txtAssignServiceStaffType);
            this.gpbEmpInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gpbEmpInfo.Location = new System.Drawing.Point(16, 0);
            this.gpbEmpInfo.Name = "gpbEmpInfo";
            this.gpbEmpInfo.Size = new System.Drawing.Size(528, 112);
            this.gpbEmpInfo.TabIndex = 105;
            this.gpbEmpInfo.TabStop = false;
            this.gpbEmpInfo.Text = "ข้อมูลพนักงาน";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(16, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Service Staff";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label14.Location = new System.Drawing.Point(16, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "ประเภทพนักงาน";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.Location = new System.Drawing.Point(16, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "พนักงาน";
            // 
            // txtAssignPosition
            // 
            this.txtAssignPosition.Enabled = false;
            this.txtAssignPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtAssignPosition.Location = new System.Drawing.Point(112, 48);
            this.txtAssignPosition.Name = "txtAssignPosition";
            this.txtAssignPosition.Size = new System.Drawing.Size(400, 20);
            this.txtAssignPosition.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ตำแหน่ง";
            // 
            // txtAssignEmpNo
            // 
            this.txtAssignEmpNo.Enabled = false;
            this.txtAssignEmpNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtAssignEmpNo.Location = new System.Drawing.Point(112, 24);
            this.txtAssignEmpNo.Name = "txtAssignEmpNo";
            this.txtAssignEmpNo.Size = new System.Drawing.Size(64, 20);
            this.txtAssignEmpNo.TabIndex = 1;
            // 
            // txtAssignEmpName
            // 
            this.txtAssignEmpName.Enabled = false;
            this.txtAssignEmpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtAssignEmpName.Location = new System.Drawing.Point(184, 24);
            this.txtAssignEmpName.Name = "txtAssignEmpName";
            this.txtAssignEmpName.Size = new System.Drawing.Size(328, 20);
            this.txtAssignEmpName.TabIndex = 2;
            // 
            // txtAssignServiceStaffType
            // 
            this.txtAssignServiceStaffType.Enabled = false;
            this.txtAssignServiceStaffType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtAssignServiceStaffType.Location = new System.Drawing.Point(112, 72);
            this.txtAssignServiceStaffType.Name = "txtAssignServiceStaffType";
            this.txtAssignServiceStaffType.Size = new System.Drawing.Size(400, 20);
            this.txtAssignServiceStaffType.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txtRunningNo);
            this.groupBox1.Controls.Add(this.txtPlatePrefix);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.dtpContractToDate);
            this.groupBox1.Controls.Add(this.dtpContractFromDate);
            this.groupBox1.Controls.Add(this.txbCustomerDepartment);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txbCustomer);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtContractNoXXX);
            this.groupBox1.Controls.Add(this.txtContractNoMM);
            this.groupBox1.Controls.Add(this.txtContractNoYY);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(16, 376);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 128);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียดในสัญญา";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(112, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 17);
            this.label12.TabIndex = 156;
            this.label12.Text = "PTB - C -";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.Location = new System.Drawing.Point(225, 72);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(13, 17);
            this.label20.TabIndex = 68;
            this.label20.Text = "-";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label19.Location = new System.Drawing.Point(16, 76);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(81, 13);
            this.label19.TabIndex = 67;
            this.label19.Text = "ระยะเวลาสัญญา";
            // 
            // dtpContractToDate
            // 
            this.dtpContractToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpContractToDate.Enabled = false;
            this.dtpContractToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpContractToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpContractToDate.Location = new System.Drawing.Point(247, 72);
            this.dtpContractToDate.Name = "dtpContractToDate";
            this.dtpContractToDate.Size = new System.Drawing.Size(104, 20);
            this.dtpContractToDate.TabIndex = 65;
            // 
            // dtpContractFromDate
            // 
            this.dtpContractFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpContractFromDate.Enabled = false;
            this.dtpContractFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpContractFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpContractFromDate.Location = new System.Drawing.Point(112, 72);
            this.dtpContractFromDate.Name = "dtpContractFromDate";
            this.dtpContractFromDate.Size = new System.Drawing.Size(104, 20);
            this.dtpContractFromDate.TabIndex = 64;
            // 
            // txbCustomerDepartment
            // 
            this.txbCustomerDepartment.Enabled = false;
            this.txbCustomerDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txbCustomerDepartment.HideSelection = false;
            this.txbCustomerDepartment.Location = new System.Drawing.Point(368, 48);
            this.txbCustomerDepartment.Name = "txbCustomerDepartment";
            this.txbCustomerDepartment.Size = new System.Drawing.Size(144, 20);
            this.txbCustomerDepartment.TabIndex = 63;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label16.Location = new System.Drawing.Point(312, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 62;
            this.label16.Text = "ฝ่ายลูกค้า";
            // 
            // txbCustomer
            // 
            this.txbCustomer.Enabled = false;
            this.txbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txbCustomer.HideSelection = false;
            this.txbCustomer.Location = new System.Drawing.Point(112, 48);
            this.txbCustomer.Name = "txbCustomer";
            this.txbCustomer.Size = new System.Drawing.Size(176, 20);
            this.txbCustomer.TabIndex = 61;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.Location = new System.Drawing.Point(16, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 60;
            this.label11.Text = "ชื่อลูกค้า";
            // 
            // txtContractNoXXX
            // 
            this.txtContractNoXXX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoXXX.Enabled = false;
            this.txtContractNoXXX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtContractNoXXX.HideSelection = false;
            this.txtContractNoXXX.Location = new System.Drawing.Point(256, 24);
            this.txtContractNoXXX.MaxLength = 3;
            this.txtContractNoXXX.Name = "txtContractNoXXX";
            this.txtContractNoXXX.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoXXX.TabIndex = 59;
            this.txtContractNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtContractNoMM
            // 
            this.txtContractNoMM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoMM.Enabled = false;
            this.txtContractNoMM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtContractNoMM.HideSelection = false;
            this.txtContractNoMM.Location = new System.Drawing.Point(220, 24);
            this.txtContractNoMM.MaxLength = 2;
            this.txtContractNoMM.Name = "txtContractNoMM";
            this.txtContractNoMM.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoMM.TabIndex = 58;
            this.txtContractNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtContractNoYY
            // 
            this.txtContractNoYY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoYY.Enabled = false;
            this.txtContractNoYY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtContractNoYY.Location = new System.Drawing.Point(184, 24);
            this.txtContractNoYY.MaxLength = 2;
            this.txtContractNoYY.Name = "txtContractNoYY";
            this.txtContractNoYY.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoYY.TabIndex = 57;
            this.txtContractNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label15.Location = new System.Drawing.Point(16, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 53;
            this.label15.Text = "เลขที่สัญญา";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label22.Location = new System.Drawing.Point(152, 98);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(13, 17);
            this.label22.TabIndex = 160;
            this.label22.Text = "-";
            // 
            // txtRunningNo
            // 
            this.txtRunningNo.Enabled = false;
            this.txtRunningNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtRunningNo.Location = new System.Drawing.Point(168, 96);
            this.txtRunningNo.Name = "txtRunningNo";
            this.txtRunningNo.Size = new System.Drawing.Size(64, 20);
            this.txtRunningNo.TabIndex = 159;
            // 
            // txtPlatePrefix
            // 
            this.txtPlatePrefix.Enabled = false;
            this.txtPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPlatePrefix.Location = new System.Drawing.Point(112, 96);
            this.txtPlatePrefix.Name = "txtPlatePrefix";
            this.txtPlatePrefix.Size = new System.Drawing.Size(36, 20);
            this.txtPlatePrefix.TabIndex = 158;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label21.Location = new System.Drawing.Point(16, 100);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 13);
            this.label21.TabIndex = 157;
            this.label21.Text = "จับคู่ทะเบียนรถ";
            // 
            // frmServiceStaffAssignmentEntry
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(560, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpbAssignedEmployee);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.gpbDetailAssignment);
            this.Controls.Add(this.gpbEmpInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmServiceStaffAssignmentEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ใบจ่ายงานพนักงาน(Service Staff)";
            this.Load += new System.EventHandler(this.frmServiceStaffAssignmentEntry_Load);
            this.gpbAssignedEmployee.ResumeLayout(false);
            this.gpbAssignedEmployee.PerformLayout();
            this.gpbDetailAssignment.ResumeLayout(false);
            this.gpbDetailAssignment.PerformLayout();
            this.gpbEmpInfo.ResumeLayout(false);
            this.gpbEmpInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region Private
		private bool isReadonly = true;
		private FrmServiceStaffAssignment formParent;
		private frmServiceStaffList formSSList;

		private ServiceStaffAssignment condition;
		#endregion

        #region Property
        private ServiceStaffAssignment objServiceStaffAssignment;		
		private ServiceStaffAssignment GetServiceStaffAssignment()
		{
			objServiceStaffAssignment.APeriod.From = dtpFromDate.Value.Date;
			objServiceStaffAssignment.APeriod.To = dtpToDate.Value.Date;

			ServiceStaffContract serviceStaffContract = (ServiceStaffContract)objServiceStaffAssignment.AContract;
			ServiceStaffRole serviceStaffRole;

			for(int i=0; i<serviceStaffContract.ALatestServiceStaffRoleList.Count; i++)
			{
				serviceStaffRole = serviceStaffContract.ALatestServiceStaffRoleList[i];
                if (serviceStaffRole.AServiceStaff.EmployeeNo == objServiceStaffAssignment.AMainServiceStaff.EmployeeNo)
                {
                    objServiceStaffAssignment.EmployeeOrder = serviceStaffRole.ServiceStaffOrder;
                }
                else 
                {
                    objServiceStaffAssignment.EmployeeOrder = i+1;
                }
			}
			
			objServiceStaffAssignment.AssignmentRole = CTFunction.GetAssignmentRoleType(cboAssignmentRole.Text);
			objServiceStaffAssignment.AHirer.Name = txtHirerName.Text;

			return objServiceStaffAssignment;
		}

		private ServiceStaffAssignmentFacade facadeServiceStaffAssignment
		{
			get
			{
				return formParent.facadeServiceStaffAssignment;
			}
        }
        #endregion

        #region Constructor
        public frmServiceStaffAssignmentEntry() : base()
		{
			InitializeComponent();
			formSSList = new frmServiceStaffList();
			title = "ใบจ่ายงานพนักงาน(Service Staff)";
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractAssignmentHistoryServiceStaffAssignment");
        }
        #endregion

		#region Private Method
		#region - Assigned ServiceStaff -
		private void bindServicestaff(ServiceStaff value)
		{
			txtAssignEmpNo.Text = value.EmployeeNo;
			txtAssignEmpName.Text = value.EmployeeName;
			txtAssignPosition.Text = value.APosition.ToString();
            txtAssignServiceStaffType.Text = value.AServiceStaffType.ADescription.English;
		}
				
		private void bindServicestaff()
		{
			txtAssignEmpNo.Text = "";
			txtAssignEmpName.Text = "";
			txtAssignPosition.Text = "";
			txtAssignServiceStaffType.Text = "";
		}
		#endregion

		#region - Assigned -
		private void initCombo()
		{
			//					cboAssignmentRole.DataSource = facadeServiceStaffAssignment.DataSourceAssignmentRole;
			cboAssignmentRole.Items.Clear();
			cboAssignmentRole.Items.Add(facadeServiceStaffAssignment.DataSourceAssignmentRole[0]);
			cboAssignmentRole.Items.Add(facadeServiceStaffAssignment.DataSourceAssignmentRole[1]);
		}

		private void clearAssigned()
		{
			dtpFromDate.Value = DateTime.Today.Date;
			dtpToDate.Value = DateTime.Today.Date;
			cboAssignmentRole.SelectedIndex = -1;
			txtHirerName.Text = "";

            txtPlatePrefix.Text = "";
            txtRunningNo.Text = "";
			txtContractNoYY.Text = "";
			txtContractNoMM.Text = "";
			txtContractNoXXX.Text = "";
			txbCustomer.Text = "";
			txbCustomerDepartment.Text = "";
			dtpContractFromDate.Value = DateTime.Today;
			dtpContractToDate.Value = DateTime.Today;
		}

		private void bindAssigned(ServiceStaffAssignment value)
		{
			dtpFromDate.Value = value.APeriod.From;
			dtpToDate.Value = value.APeriod.To;
			cboAssignmentRole.Text = CTFunction.GetString(value.AssignmentRole);
			txtHirerName.Text = value.AHirer.Name;

			if(action==ActionType.EDIT && value.AContract != null)
			{
				bindContract(value.AContract);
			}
		}

		private void setEnableAssign(bool enable)
		{
			if(action == ActionType.ADD)
			{
				dtpFromDate.Enabled = true;
				cboAssignmentRole.Enabled = true;
			}
			else
			{
				dtpFromDate.Enabled = false;
				cboAssignmentRole.Enabled = false;
			}
			dtpToDate.Enabled = enable;
		}
		#endregion

		#region - Main ServiceStaff -
		private void bindMainServicestaff(ServiceStaff value)
		{
			objServiceStaffAssignment.AMainServiceStaff = value;
            txtMainEmpNo.Tag = value;
			txtMainEmpNo.Text = value.EmployeeNo;
			txtMainEmpName.Text = value.EmployeeName;
			txtMainPosition.Text = value.APosition.ToString();

            //TODO : P'Ya
            TimePeriod timePeriod = new TimePeriod();
            timePeriod.From = this.dtpFromDate.Value;
            timePeriod.To = this.dtpToDate.Value;

            if (action == ActionType.ADD && cboAssignmentRole.SelectedIndex != -1)
            {
                if (CTFunction.GetAssignmentRoleType(cboAssignmentRole.Text) == ASSIGNMENT_ROLE_TYPE.MAIN)
                {
                    value.ACurrentContract = (ServiceStaffContract)facadeServiceStaffAssignment.GetContractStaffMainByPeriod(value.EmployeeNo, timePeriod);
                }
                else
                {
                    value.ACurrentContract = (ServiceStaffContract)facadeServiceStaffAssignment.GetContractStaffSpareByPeriod(value.EmployeeNo, timePeriod);
                }
            }

            //Modify process get service staff type by call storeprocedure : Woranai 2008/11/04
            //value.AServiceStaffType = facadeServiceStaffAssignment.GetServiceStaffType(value.ACurrentContract);

			txtMainServiceStaffType.Text = value.AServiceStaffType.ADescription.English;

            List<ServiceStaffAssignment> listAssign = facadeServiceStaffAssignment.GetStaffMainAssignByPeriod(value, timePeriod);
            if (listAssign != null && listAssign.Count > 0)
			{
                dtpMainFromDate.Value = listAssign[0].APeriod.From;
                dtpMainToDate.Value = listAssign[0].APeriod.To;
			}
            listAssign = null;

            if (action == ActionType.ADD && value.ACurrentContract != null)
            {
                bindContract(value.ACurrentContract);
            }
		}

		private void bindMainServicestaff()
		{
            txtMainEmpNo.Tag = null;
			txtMainEmpName.Text = "";
			txtMainPosition.Text = "";
			txtMainServiceStaffType.Text = "";
			dtpMainFromDate.Value = DateTime.Today;
			dtpMainToDate.Value = DateTime.Today;

            txtPlatePrefix.Text = "";
            txtRunningNo.Text = "";
            txtContractNoYY.Text = "";
            txtContractNoMM.Text = "";
            txtContractNoXXX.Text = "";
            txbCustomer.Text = "";
            txbCustomerDepartment.Text = "";
            dtpContractFromDate.Value = DateTime.Today;
            dtpContractToDate.Value = DateTime.Today;
		}
		#endregion

        #region - Assign Service Staff List -
        private void callList()
        {
            try
            {
                formSSList.ShowDialog();
                if (formSSList.Selected)
                {
                    //TODO : P'Ya
                    TimePeriod timePeriod = new TimePeriod();
                    timePeriod.From = this.dtpFromDate.Value;
                    timePeriod.To = this.dtpToDate.Value;
                    ServiceStaff serviceStaff = facadeServiceStaffAssignment.GetServiceStaffMainByPeriod(formSSList.SelectedServiceStaff.EmployeeNo, timePeriod);
                    bindMainServicestaff(serviceStaff);
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
            finally
            { }
        }

        private bool getServiceStaff()
        {
            try
            {
                if (txtMainEmpNo.Tag == null || ((ServiceStaff)txtMainEmpNo.Tag).EmployeeNo != txtMainEmpNo.Text)
                {
                    //TODO : P'Ya
                    
                    TimePeriod timePeriod = new TimePeriod();
                    timePeriod.From = this.dtpFromDate.Value;
                    timePeriod.To = this.dtpToDate.Value;
                    ServiceStaff serviceStaff = facadeServiceStaffAssignment.GetServiceStaffMainByPeriod(this.txtMainEmpNo.Text, timePeriod);

                    if (serviceStaff == null)
                    {
                        bindMainServicestaff();
                        serviceStaff = null;
                        return false;
                    }
                    else
                    {
                        bindMainServicestaff(serviceStaff);
                        serviceStaff = null;
                        return true;
                    }
                }
                else
                {
                    bindMainServicestaff((ServiceStaff)txtMainEmpNo.Tag);
                    return true;
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
            finally
            { }
            return false;
        }
        #endregion

		private void bindContract(ContractBase value)
		{
			txtContractNoYY.Text = value.ContractNo.Year;
			txtContractNoMM.Text = value.ContractNo.Month;
			txtContractNoXXX.Text = value.ContractNo.No;
			txbCustomer.Text = value.ACustomer.ShortName;
			txbCustomerDepartment.Text = value.ACustomerDepartment.ShortName;
			dtpContractFromDate.Value = value.APeriod.From;
			dtpContractToDate.Value = value.APeriod.To;

            bindVehicle(value.ContractNo, txtMainEmpNo.Text);
		}

        private void bindVehicle(DocumentNo contractNo, string employeeNo)
        {
            if (!employeeNo.Equals(""))
            {
                Vehicle vehicle = facadeServiceStaffAssignment.GetVehicle(contractNo, employeeNo);

                if (vehicle != null)
                {
                    txtPlatePrefix.Text = vehicle.PlatePrefix.ToString();
                    txtRunningNo.Text = vehicle.PlateRunningNo.ToString();
                }
                else
                {
                    txtPlatePrefix.Text = "";
                    txtRunningNo.Text = "";
                } 
            }
        }

        private bool AddEvent()
        {
            if (validateAdd())
            {
                return formParent.AddRow(GetServiceStaffAssignment());
            }
            else
            {
                return false;
            }
        }

        private bool EditEvent()
        {
            if (validateEdit())
            {
                return formParent.UpdateRow(GetServiceStaffAssignment(), condition);
            }
            else
            {
                return false;
            }
        }

        private void getStaffByPeriod()
        { 
            //TODO : P'Ya
            if (this.validateGetStaffByPeriod())
            {
                TimePeriod timePeriod = new TimePeriod();
                timePeriod.From = this.dtpFromDate.Value;
                timePeriod.To = this.dtpToDate.Value;

                ServiceStaff serviceStaff = this.facadeServiceStaffAssignment.GetServiceStaffMainByPeriod(this.txtMainEmpNo.Text, timePeriod);

                if (serviceStaff == null)
                {
                    bindMainServicestaff();
                }
                else
                {
                    bindMainServicestaff(serviceStaff);
                }

                serviceStaff = null;
            }
        }

        /// <summary>
        /// Validate before get staff record to show in control
        /// </summary>
        /// <returns></returns>
        private bool validateGetStaffByPeriod()
        {
            // validate employee no
            if (string.IsNullOrEmpty(this.txtMainEmpNo.Text.Trim()))
                return false;

            // validate date from and to
            if (this.dtpFromDate.Value > this.dtpToDate.Value)
            {
                Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
                this.dtpToDate.Focus();
                return false;
            }

            return true;
        }

		#endregion

		#region Validate Method
		private bool validateAdd()
		{
            #region Validate2
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
                dtpToDate.Focus();
                return false;
            } 
            #endregion

            #region Validate3
            if (cboAssignmentRole.SelectedIndex == -1)
            {
                Message(MessageList.Error.E0005, "สถานะ");
                cboAssignmentRole.Focus();
                return false;
            } 
            #endregion

            #region Validate4
            if (txtMainEmpNo.Text.Trim() == "")
            {
                Message(MessageList.Error.E0002, "รหัสพนักงาน");
                setSelected(txtMainEmpNo);
                return false;
            } 
            #endregion

            #region Validate5
            if (txtAssignEmpNo.Text == txtMainEmpNo.Text)
            {
                Message(MessageList.Error.E0014, "แทนพนักงานรหัสเดียวกันได้");
                setSelected(txtMainEmpNo);
                return false;
            } 
            #endregion

            #region validate6
            if (!getServiceStaff())
            {
                Message(MessageList.Error.E0004, "รหัสพนักงาน");
                setSelected(txtMainEmpNo);
                return false;
            } 
            #endregion

            #region Comment Code
            //				validate7
            //				if(objServiceStaffAssignment.AMainServiceStaff.AServiceStaffType.IsSpare)
            //				{
            //					Message(MessageList.Error.E0005, "พนักงานที่ไม่ใช่ spare");
            //					setSelected(txtMainEmpNo);
            //					return false;
            //				}
            ////				validate8
            //				
            //				if(serviceStaffAssignment == null)
            //				{
            ////					not in spect 
            //					Message(MessageList.Error.E0004, "ข้อมูลการจ่ายงาน");
            //					setSelected(txtMainEmpNo);
            //					return false;
            //				}
            //				else
            //				{
            //					objServiceStaffAssignment.AContract = serviceStaffAssignment.AContract;
            //					objServiceStaffAssignment.EmployeeOrder = serviceStaffAssignment.EmployeeOrder;
            //				}
            //
            //                
            //				ServiceStaffRole serviceStaffRole = serviceStaffContract.ALatestServiceStaffRoleList[serviceStaffAssignment.EmployeeOrder.ToString()];
            ////				validate9
            ////				serviceStaffRole.AServiceStaffType
            //
            ////				validate10
            //				if(serviceStaffRole.AServiceStaff.EmployeeNo == objServiceStaffAssignment.AMainServiceStaff.EmployeeNo)
            //				{
            ////					validate10.2
            ////					serviceStaffAssignment.APeriod
            //				}
            //				else
            //				{
            ////					validate10.1
            //					Message(MessageList.Error.E0005, "พนักงานที่เป็น Main ของสัญญา");
            //					setSelected(txtMainEmpNo);
            //					return false;
            //				}

            //				validate11
            //ServiceStaffAssignmentList ssAssignmentList = new ServiceStaffAssignmentList(objServiceStaffAssignment.AAssignedServiceStaff ,facadeServiceStaffAssignment.GetCompany());
            //facadeServiceStaffAssignment.DisplayServiceStaffAssignment(ssAssignmentList);
            //ServiceStaffAssignment ssAssignment;
            //for(int i=0; i<ssAssignmentList.Count; i++)
            //{
            //    ssAssignment = ssAssignmentList[i];
            //    //					if(ssAssignment.AMainServiceStaff.EmployeeNo == txtMainEmpNo.Text)
            //    //					{
            //    if(dtpToDate.Value.Date>=ssAssignment.APeriod.From && dtpFromDate.Value.Date<=ssAssignment.APeriod.To)
            //    {
            //        ssAssignment = null;
            //        ssAssignmentList = null;
            //        Message(MessageList.Error.E0014, "จ่ายงานในช่วงเวลาดังกล่าว");
            //        return false;
            //    }					
            //    //					}
            //}
            //ssAssignment = null;
            //ssAssignmentList = null; 
            #endregion

            #region Validate11
            ServiceStaffAssignment ssAssignment = new ServiceStaffAssignment();
            ssAssignment.AAssignedServiceStaff = objServiceStaffAssignment.AAssignedServiceStaff;
            ssAssignment.APeriod.From = dtpFromDate.Value.Date;
            ssAssignment.APeriod.To = dtpToDate.Value.Date;

            if (facadeServiceStaffAssignment.FillNotAvailableServiceStaffAssignment(ssAssignment))
            {
                Message(MessageList.Error.E0014, "จ่ายงานในช่วงเวลาดังกล่าว");
                return false;
            }
            ssAssignment = null;
            
            #endregion

            #region Validate12
            //Comment for advance assign staff : woranai 2008/11/08

            //objServiceStaffAssignment.AContract = (ServiceStaffContract)facadeServiceStaffAssignment.GetServiceStaffCurrentContract(txtMainEmpNo.Text);
            //if (objServiceStaffAssignment.AContract == null)
            //{
            //    Message(MessageList.Error.E0045);
            //    setSelected(txtMainEmpNo);
            //    return false;
            //}

            //DateTime dateForm = objServiceStaffAssignment.AContract.APeriod.From.Date;
            //DateTime dateTo = objServiceStaffAssignment.AContract.APeriod.To.Date;
            //if (dtpFromDate.Value.Date < dateForm)
            //{
            //    Message(MessageList.Error.E0030);
            //    dtpFromDate.Focus();
            //    return false;
            //}
            //if (dtpToDate.Value.Date > dateTo)
            //{
            //    Message(MessageList.Error.E0030);
            //    dtpToDate.Focus();
            //    return false;
            //} 
            #endregion

            #region Validate13
            objServiceStaffAssignment.AssignmentRole = CTFunction.GetAssignmentRoleType(cboAssignmentRole.Text);
            TimePeriod timePeriod = new TimePeriod();
            timePeriod.From = this.dtpFromDate.Value;
            timePeriod.To = this.dtpToDate.Value;

            switch (objServiceStaffAssignment.AssignmentRole)
            {
                case ASSIGNMENT_ROLE_TYPE.MAIN:
                    {
                        //BEGIN: P'Ya

                        #region Validate13.1 (Comment for BTS Enhancement can create advance assign : woranai 2008/11/08)

                        //Check period of main assign staff must not dupplicate other main staff
                        ContractBase contract = facadeServiceStaffAssignment.GetContractStaffMainByPeriod(this.txtMainEmpNo.Text, timePeriod);
                        if (contract == null)
                        {
                            Message(MessageList.Error.E0012, "จ่ายงานได้", "ระบุช่วงการจ่ายงานไม่ถูกต้อง", "แก้ไขวันที่การจ่ายงาน");
                            setSelected(txtMainEmpNo);
                            return false;
                        }
                        else
                        {
                            this.objServiceStaffAssignment.AContract = contract;
                        }

                        #endregion

                        //END: P'Ya

                        if (objServiceStaffAssignment.AAssignedServiceStaff.APosition.PositionCode != objServiceStaffAssignment.AMainServiceStaff.APosition.PositionCode)
                        {
                            Message(MessageList.Error.E0005, "พนักงานที่มีตำแหน่งเดียวกัน");
                            txtMainEmpNo.Focus();
                            return false;
                        }

                        List<ServiceStaffAssignment> listAssign = facadeServiceStaffAssignment.GetStaffMainAssignByPeriod(objServiceStaffAssignment.AMainServiceStaff, timePeriod);

                        foreach (ServiceStaffAssignment item in listAssign)
                        {
                            if (item != null &&
                                item.AContract.ContractNo.ToString() == this.objServiceStaffAssignment.AContract.ContractNo.ToString())
                            {
                                Message(MessageList.Error.E0012, "จ่ายงานได้", "วันที่จ่ายงานมีการซ้อนทับกัน", "แก้ไขวันที่การจ่ายงาน");
                                dtpFromDate.Focus();
                                listAssign = null;
                                return false;
                            }
                        }

                        listAssign = null;
                        break;
                    }
                case ASSIGNMENT_ROLE_TYPE.SPARE:
                    {
                        //BEGIN: P'Ya

                        #region Validate13.2 (Comment for BTS Enhancement can create advance assign : woranai 2008/11/08)

                        //Check period of spare assign staff must assign in period of main staff and spare staff must not dupplicate other spare staff
                        ServiceStaffAssignmentList tempServiceStaffAssignmentList = new ServiceStaffAssignmentList(objServiceStaffAssignment.AMainServiceStaff, facadeServiceStaffAssignment.GetCompany());
                        if (!facadeServiceStaffAssignment.FillStaffMainAssignByPeriodList(tempServiceStaffAssignmentList, timePeriod))
                        {
                            Message(MessageList.Error.E0045);
                            setSelected(txtMainEmpNo);
                            return false;
                        }
                        else
                        {
                            if (tempServiceStaffAssignmentList.Count != 1)
                            {
                                Message(MessageList.Error.E0012, "จ่ายงานได้", "ระบุช่วงการจ่ายงานไม่ถูกต้อง", "แก้ไขวันที่การจ่ายงาน");
                                setSelected(txtMainEmpNo);
                                return false;
                            }
                            else
                            {
                                this.objServiceStaffAssignment.AContract = tempServiceStaffAssignmentList[0].AContract;
                            }
                        }

                        #endregion

                        //END: P'Ya

                        ServiceStaffAssignment v14Condition = new ServiceStaffAssignment();
                        v14Condition.AMainServiceStaff = objServiceStaffAssignment.AMainServiceStaff;
                        v14Condition.AssignmentRole = ASSIGNMENT_ROLE_TYPE.SPARE;

                        tempServiceStaffAssignmentList = new ServiceStaffAssignmentList(objServiceStaffAssignment.AMainServiceStaff, facadeServiceStaffAssignment.GetCompany());
                        if (facadeServiceStaffAssignment.FillServiceStaffAssignmentList(ref tempServiceStaffAssignmentList, v14Condition))
                        {
                            DateTime scrFormDate = dtpFromDate.Value.Date;
                            DateTime scrToDate = dtpToDate.Value.Date;
                            DateTime assignFormDate;
                            DateTime assignToDate;
                            for (int i = 0; i < tempServiceStaffAssignmentList.Count; i++)
                            {
                                assignFormDate = tempServiceStaffAssignmentList[i].APeriod.From.Date;
                                assignToDate = tempServiceStaffAssignmentList[i].APeriod.To.Date;
                                if (scrToDate >= assignFormDate && scrFormDate <= assignToDate)
                                {
                                    Message(MessageList.Error.E0031);
                                    dtpToDate.Focus();
                                    return false;
                                }
                            }
                        }
                        v14Condition = null;

                        ServiceStaffAssignment v15Condition = new ServiceStaffAssignment();
                        v15Condition.AAssignedServiceStaff = objServiceStaffAssignment.AMainServiceStaff;
                        v15Condition.AssignmentRole = ASSIGNMENT_ROLE_TYPE.MAIN;

                        tempServiceStaffAssignmentList.Clear();
                        bool result15 = false;
                        if (facadeServiceStaffAssignment.FillServiceStaffAssignmentList(ref tempServiceStaffAssignmentList, v15Condition))
                        {
                            DateTime scrFormDate = dtpFromDate.Value.Date;
                            DateTime scrToDate = dtpToDate.Value.Date;
                            DateTime assignFormDate;
                            DateTime assignToDate;
                            for (int i = 0; i < tempServiceStaffAssignmentList.Count; i++)
                            {
                                assignFormDate = tempServiceStaffAssignmentList[i].APeriod.From.Date;
                                assignToDate = tempServiceStaffAssignmentList[i].APeriod.To.Date;
                                if (assignFormDate <= scrFormDate && scrToDate <= assignToDate)
                                {
                                    result15 = true;
                                    continue;
                                }
                            }
                            if (!result15)
                            {
                                Message(MessageList.Error.E0045);
                                dtpToDate.Focus();
                                return false;
                            }
                        }
                        break;
                    }
            } 
            #endregion

            #region Validate14
            if (!facadeServiceStaffAssignment.CheckAvailable(txtAssignEmpNo.Text, dtpToDate.Value))
            {
                Message(MessageList.Error.E0014, "จ่ายงานให้พนักงานที่ลาออกไปแล้วได้");
                setSelected(txtAssignEmpNo);
                return false;
            } 
            #endregion

			return true;
        }
        #endregion

        private bool validateEdit()
		{
            #region Validate1
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
                dtpToDate.Focus();
                return false;
            } 
            #endregion

            #region Comment
            //Comment by woranai 30/3/2007
            //if(dtpToDate.Value.Date>objServiceStaffAssignment.APeriod.To.Date)
            //{
            //    Message(MessageList.Error.E0011, "วันที่สิ้นสุดหลังแก้ไข", "วันที่สิ้นสุด ก่อนแก้ไข");
            //    dtpToDate.Focus();
            //    return false;
            //} 
            #endregion

            #region Validate2
            if (dtpToDate.Value.Date > objServiceStaffAssignment.AContract.APeriod.To.Date)
            {
                Message(MessageList.Error.E0030);
                dtpToDate.Focus();
                return false;
            } 
            #endregion

            #region Validate3
            ASSIGNMENT_ROLE_TYPE assignmentRole = CTFunction.GetAssignmentRoleType(cboAssignmentRole.Text);
            if (dtpToDate.Value.Date != objServiceStaffAssignment.APeriod.To)
            {
                if (assignmentRole == ASSIGNMENT_ROLE_TYPE.MAIN && dtpToDate.Value.Date > DateTime.Today.Date)
                {
                    if (!dtpToDate.Enabled)
                    {
                        Message(MessageList.Error.E0011, "วันที่สิ้นสุดหลังแก้ไข", "วันที่ปัจจุบัน");
                        dtpToDate.Focus();
                        return false;
                    }
                }
            } 
            #endregion

            #region Validate 4
            if (dtpToDate.Value.Date != objServiceStaffAssignment.APeriod.To)
            {
                ServiceStaffAssignmentList V4Condition = new ServiceStaffAssignmentList(facadeServiceStaffAssignment.GetCompany());
                V4Condition.AServiceStaff = objServiceStaffAssignment.AAssignedServiceStaff;
                if (facadeServiceStaffAssignment.DisplayServiceStaffAssignment(V4Condition))
                {
                    V4Condition.Remove(objServiceStaffAssignment);
                    foreach (ServiceStaffAssignment assign in V4Condition)
                    {
                        if ((assign.APeriod.From <= dtpToDate.Value) && (assign.APeriod.To >= dtpFromDate.Value))
                        {
                            Message(MessageList.Error.E0014, "จ่ายงานในช่วงเวลาดังกล่าวได้");
                            dtpToDate.Focus();
                            V4Condition = null;
                            return false;
                        }
                    }
                    V4Condition = null;
                }
            } 
            #endregion

            #region Validate 4.1
            switch (objServiceStaffAssignment.AssignmentRole)
            {
                case ASSIGNMENT_ROLE_TYPE.MAIN:
                    {
                        //Not allow assign dupplicate main staff : woranai 2010/02/20
                        List<ServiceStaffAssignment> listAssign = facadeServiceStaffAssignment.GetStaffMainAssignByPeriod(objServiceStaffAssignment.AMainServiceStaff, new TimePeriod(dtpFromDate.Value.Date, dtpToDate.Value.Date));
                        listAssign.RemoveAll(delegate(ServiceStaffAssignment item) { return item.EntityKey == objServiceStaffAssignment.EntityKey; });

                        foreach (ServiceStaffAssignment item in listAssign)
                        {
                            if (item != null &&
                                item.AContract.ContractNo.ToString() == this.objServiceStaffAssignment.AContract.ContractNo.ToString())
                            {
                                Message(MessageList.Error.E0012, "จ่ายงานได้", "วันที่จ่ายงานมีการซ้อนทับกัน", "แก้ไขวันที่การจ่ายงาน");
                                dtpFromDate.Focus();
                                listAssign = null;
                                return false;
                            }
                        }
                        listAssign = null;
                        break;
                    }
                case ASSIGNMENT_ROLE_TYPE.SPARE:
                    {
                        ServiceStaffAssignment assignCondition = new ServiceStaffAssignment();
                        assignCondition.AMainServiceStaff = objServiceStaffAssignment.AMainServiceStaff;
                        assignCondition.AssignmentRole = ASSIGNMENT_ROLE_TYPE.SPARE;

                        ServiceStaffAssignmentList tempServiceStaffAssignmentList = new ServiceStaffAssignmentList(objServiceStaffAssignment.AMainServiceStaff, facadeServiceStaffAssignment.GetCompany());

                        if (facadeServiceStaffAssignment.FillServiceStaffAssignmentList(ref tempServiceStaffAssignmentList, assignCondition))
                        {
                            tempServiceStaffAssignmentList.Remove(objServiceStaffAssignment);

                            foreach (ServiceStaffAssignment item in tempServiceStaffAssignmentList)
                            {
                                if (dtpToDate.Value.Date >= item.APeriod.From.Date && dtpFromDate.Value.Date <= item.APeriod.To.Date)
                                {
                                    Message(MessageList.Error.E0031);
                                    dtpToDate.Focus();
                                    return false;
                                }
                            }
                        }
                        assignCondition = null;
                    }
                    break;
            }

            #endregion

            #region Validate 5
            ServiceStaffAssignment V5Condition = new ServiceStaffAssignment();
            V5Condition.AssignmentRole = ASSIGNMENT_ROLE_TYPE.SPARE;
            V5Condition.AMainServiceStaff = objServiceStaffAssignment.AAssignedServiceStaff;
            V5Condition.AContract = objServiceStaffAssignment.AContract;
            ServiceStaffAssignmentList serviceStaffAssignmentList = new ServiceStaffAssignmentList(facadeServiceStaffAssignment.GetCompany());
            if (facadeServiceStaffAssignment.FillServiceStaffAssignmentList(ref serviceStaffAssignmentList, V5Condition))
            {
                for (int i = 0; i < serviceStaffAssignmentList.Count; i++)
                {
                    if (serviceStaffAssignmentList[i].APeriod.To > dtpToDate.Value.Date)
                    {
                        Message(MessageList.Error.E0018, "วันที่สิ้นสุดจ่ายงาน", "วันที่สิ้นสุดที่พนักงาน spare มาทำงานแทน");
                        dtpToDate.Focus();
                        return false;
                    }
                }
            }
            V5Condition = null;
            serviceStaffAssignmentList = null;
            #endregion

            #region Validate 6
            if (!facadeServiceStaffAssignment.CheckAvailable(txtAssignEmpNo.Text, dtpToDate.Value))
            {
                Message(MessageList.Error.E0014, "จ่ายงานให้พนักงานที่ลาออกไปแล้วได้");
                setSelected(txtAssignEmpNo);
                return false;
            }  
            #endregion
            

			return true;
		}

        #region Public Method
        public void InitAddAction(FrmServiceStaffAssignment parent, ServiceStaff value)
        {
            baseADD();
            formParent = parent;
            initCombo();

            objServiceStaffAssignment = new ServiceStaffAssignment();
            objServiceStaffAssignment.AAssignedServiceStaff = value;

            bindServicestaff(value);
            clearAssigned();
            bindMainServicestaff();

            txtMainEmpNo.Text = "";
            txtMainEmpNo.Enabled = true;
            setEnableAssign(true);

            txtMainEmpNo.Enabled = true;
        }

        public void InitEditAction(FrmServiceStaffAssignment parent, ServiceStaffAssignment value)
        {
            baseEDIT();
            formParent = parent;
            initCombo();

            condition = new ServiceStaffAssignment();
            condition.AAssignedServiceStaff = new ServiceStaff(value.AAssignedServiceStaff.Company);
            condition.AAssignedServiceStaff.EmployeeNo = value.AAssignedServiceStaff.EmployeeNo;
            condition.AContract = new ContractBase();
            condition.AContract.ContractNo = new DocumentNo(value.AContract.ContractNo.ToString());
            condition.AMainServiceStaff = new ServiceStaff(value.AMainServiceStaff.Company);
            condition.AMainServiceStaff.EmployeeNo = value.AMainServiceStaff.EmployeeNo;
            condition.APeriod = new Entity.AttendanceEntities.TimePeriod();
            condition.APeriod.From = value.APeriod.From;
            condition.APeriod.To = value.APeriod.To;

            objServiceStaffAssignment = value;

            bindServicestaff(value.AAssignedServiceStaff);
            bindMainServicestaff(value.AMainServiceStaff);
            bindAssigned(value);

            if (facadeServiceStaffAssignment.IsCurrentMain(value))
            {
                setEnableAssign(true);
            }
            else
            {
                setEnableAssign(false);
            }

            txtMainEmpNo.Enabled = false;

            if (isReadonly)
            {
                cmdOK.Enabled = false;
            }
        } 
        #endregion

        #region Form Event
        private void frmServiceStaffAssignmentEntry_Load(object sender, System.EventArgs e)
        {
        }
        private void txtMainEmpNo_DoubleClick(object sender, System.EventArgs e)
        {
            callList();
        }

        private void txtMainEmpNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMainEmpNo.Text.Trim() == "")
                {
                    Message(MessageList.Error.E0002, "รหัสพนักงาน");
                    setSelected(txtMainEmpNo);
                }
                else
                {
                    if (!getServiceStaff())
                    {
                        Message(MessageList.Error.E0004, "รหัสพนักงาน");
                        setSelected(txtMainEmpNo);
                    }
                }
            }
        }

        private void txtMainEmpNo_TextChanged(object sender, System.EventArgs e)
        {
            if (txtMainEmpNo.Text.Trim().Length == txtMainEmpNo.MaxLength)
            {
                if (!getServiceStaff())
                {
                    Message(MessageList.Error.E0004, "รหัสพนักงาน");
                    setSelected(txtMainEmpNo);
                }
            }
            else
            {
                bindMainServicestaff();
            }
        }

        private void cmdOK_Click(object sender, System.EventArgs e)
        {
            bool result = false;
            switch (action)
            {
                case ActionType.ADD:
                    {
                        result = AddEvent();
                        break;
                    }
                case ActionType.EDIT:
                    {
                        result = EditEvent();
                        break;
                    }
            }
            if (result)
            {
                this.Close();
            }
        }

        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void dtpFromDate_Leave(object sender, EventArgs e)
        {
            getStaffByPeriod();
        }

        private void dtpToDate_Leave(object sender, EventArgs e)
        {
            getStaffByPeriod();
        }
	}
}