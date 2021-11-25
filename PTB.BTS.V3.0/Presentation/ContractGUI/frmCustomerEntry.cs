using System;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

using Entity.ContractEntities;

using Facade.CommonFacade;
using Facade.ContractFacade;

using Presentation.CommonGUI;

namespace Presentation.ContractGUI
{
	public class frmCustomerEntry : EntryFormBase
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtCustomerCode;
		private System.Windows.Forms.TextBox txtTHName;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.ComboBox cboCustomerGroup;
		private System.Windows.Forms.TextBox txtENName;
		private System.Windows.Forms.ComboBox cboProvince;
		private System.Windows.Forms.ComboBox cboSubDistrict;
		private System.Windows.Forms.ComboBox cboDistrict;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.TextBox txtFaxNo;
		private System.Windows.Forms.TextBox txtTelNo;
		private System.Windows.Forms.ComboBox cboStreet;
		private FarPoint.Win.Input.FpInteger fpiPostelCode;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtAuthorizedPerson;
		private System.Windows.Forms.TextBox txtShortName;
		private System.Windows.Forms.TextBox txtContactPerson;
		private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboCustomerContractGroup;
        private Label label17;
        private TextBox txtAuthorizedPersonPosition;
        private TextBox txtAuthorizedPersonPosition2;
        private Label label18;
        private TextBox txtAuthorizedPerson2;
        private Label label19;
        private TextBox txtBizPacCode;
        private Label label20;
        private TextBox txtSAPCode;
        private Label label21;
		
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTHName = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSAPCode = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtBizPacCode = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboCustomerContractGroup = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboCustomerGroup = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtENName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fpiPostelCode = new FarPoint.Win.Input.FpInteger();
            this.cboStreet = new System.Windows.Forms.ComboBox();
            this.cboProvince = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboSubDistrict = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDistrict = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtAuthorizedPersonPosition2 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtAuthorizedPerson2 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtAuthorizedPersonPosition = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAuthorizedPerson = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFaxNo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTelNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสลูกค้า";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerCode.Location = new System.Drawing.Point(128, 24);
            this.txtCustomerCode.MaxLength = 6;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(64, 20);
            this.txtCustomerCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ชื่อลูกค้า(ภาษาไทย)";
            // 
            // txtTHName
            // 
            this.txtTHName.Location = new System.Drawing.Point(128, 88);
            this.txtTHName.MaxLength = 150;
            this.txtTHName.Name = "txtTHName";
            this.txtTHName.Size = new System.Drawing.Size(584, 20);
            this.txtTHName.TabIndex = 7;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(304, 488);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 22;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(384, 488);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 23;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSAPCode);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.txtBizPacCode);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.cboCustomerContractGroup);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtShortName);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cboCustomerGroup);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtENName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTHName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCustomerCode);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 152);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลลูกค้า";
            // 
            // txtSAPCode
            // 
            this.txtSAPCode.Location = new System.Drawing.Point(332, 56);
            this.txtSAPCode.MaxLength = 8;
            this.txtSAPCode.Name = "txtSAPCode";
            this.txtSAPCode.Size = new System.Drawing.Size(77, 20);
            this.txtSAPCode.TabIndex = 5;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(273, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 13);
            this.label21.TabIndex = 11;
            this.label21.Text = "SAP Code";
            // 
            // txtBizPacCode
            // 
            this.txtBizPacCode.Location = new System.Drawing.Point(332, 24);
            this.txtBizPacCode.MaxLength = 6;
            this.txtBizPacCode.Name = "txtBizPacCode";
            this.txtBizPacCode.Size = new System.Drawing.Size(77, 20);
            this.txtBizPacCode.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(236, 28);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 13);
            this.label20.TabIndex = 9;
            this.label20.Text = "รหัสลูกค้า (BizPac)";
            // 
            // cboCustomerContractGroup
            // 
            this.cboCustomerContractGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerContractGroup.Location = new System.Drawing.Point(504, 56);
            this.cboCustomerContractGroup.Name = "cboCustomerContractGroup";
            this.cboCustomerContractGroup.Size = new System.Drawing.Size(208, 21);
            this.cboCustomerContractGroup.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(408, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "กลุ่มลูกค้าในสัญญา";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(128, 56);
            this.txtShortName.MaxLength = 20;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(112, 20);
            this.txtShortName.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(67, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "ชื่อย่อลูกค้า";
            // 
            // cboCustomerGroup
            // 
            this.cboCustomerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerGroup.Location = new System.Drawing.Point(504, 24);
            this.cboCustomerGroup.Name = "cboCustomerGroup";
            this.cboCustomerGroup.Size = new System.Drawing.Size(208, 21);
            this.cboCustomerGroup.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(451, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "กลุ่มลูกค้า";
            // 
            // txtENName
            // 
            this.txtENName.Location = new System.Drawing.Point(128, 120);
            this.txtENName.MaxLength = 150;
            this.txtENName.Name = "txtENName";
            this.txtENName.Size = new System.Drawing.Size(584, 20);
            this.txtENName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ชื่อลูกค้า(ภาษาอังกฤษ)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fpiPostelCode);
            this.groupBox2.Controls.Add(this.cboStreet);
            this.groupBox2.Controls.Add(this.cboProvince);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cboSubDistrict);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cboDistrict);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(16, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(736, 152);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ที่อยู่";
            // 
            // fpiPostelCode
            // 
            this.fpiPostelCode.AllowClipboardKeys = true;
            this.fpiPostelCode.AllowNull = true;
            this.fpiPostelCode.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiPostelCode.Location = new System.Drawing.Point(472, 120);
            this.fpiPostelCode.MaxValue = 99999;
            this.fpiPostelCode.MinValue = 0;
            this.fpiPostelCode.Name = "fpiPostelCode";
            this.fpiPostelCode.NullColor = System.Drawing.Color.Transparent;
            this.fpiPostelCode.Size = new System.Drawing.Size(75, 20);
            this.fpiPostelCode.TabIndex = 14;
            this.fpiPostelCode.Text = "";
            // 
            // cboStreet
            // 
            this.cboStreet.Location = new System.Drawing.Point(128, 56);
            this.cboStreet.MaxLength = 30;
            this.cboStreet.Name = "cboStreet";
            this.cboStreet.Size = new System.Drawing.Size(240, 21);
            this.cboStreet.TabIndex = 10;
            // 
            // cboProvince
            // 
            this.cboProvince.Location = new System.Drawing.Point(128, 120);
            this.cboProvince.MaxLength = 30;
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(240, 21);
            this.cboProvince.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(87, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "จังหวัด";
            // 
            // cboSubDistrict
            // 
            this.cboSubDistrict.Location = new System.Drawing.Point(128, 88);
            this.cboSubDistrict.MaxLength = 30;
            this.cboSubDistrict.Name = "cboSubDistrict";
            this.cboSubDistrict.Size = new System.Drawing.Size(240, 21);
            this.cboSubDistrict.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(440, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "เขต";
            // 
            // cboDistrict
            // 
            this.cboDistrict.Location = new System.Drawing.Point(472, 88);
            this.cboDistrict.MaxLength = 30;
            this.cboDistrict.Name = "cboDistrict";
            this.cboDistrict.Size = new System.Drawing.Size(240, 21);
            this.cboDistrict.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "แขวง";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "ถนน";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(128, 24);
            this.txtAddress.MaxLength = 70;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(576, 20);
            this.txtAddress.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "ที่อยู่";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(400, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "รหัสไปรษณีย์";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtAuthorizedPersonPosition2);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.txtAuthorizedPerson2);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.txtAuthorizedPersonPosition);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txtAuthorizedPerson);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtContactPerson);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtFaxNo);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtTelNo);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Location = new System.Drawing.Point(16, 320);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(736, 152);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "อื่น ๆ";
            // 
            // txtAuthorizedPersonPosition2
            // 
            this.txtAuthorizedPersonPosition2.Location = new System.Drawing.Point(472, 120);
            this.txtAuthorizedPersonPosition2.MaxLength = 80;
            this.txtAuthorizedPersonPosition2.Name = "txtAuthorizedPersonPosition2";
            this.txtAuthorizedPersonPosition2.Size = new System.Drawing.Size(224, 20);
            this.txtAuthorizedPersonPosition2.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(422, 124);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 21;
            this.label18.Text = "ตำแหน่ง";
            // 
            // txtAuthorizedPerson2
            // 
            this.txtAuthorizedPerson2.Location = new System.Drawing.Point(472, 88);
            this.txtAuthorizedPerson2.MaxLength = 80;
            this.txtAuthorizedPerson2.Name = "txtAuthorizedPerson2";
            this.txtAuthorizedPerson2.Size = new System.Drawing.Size(224, 20);
            this.txtAuthorizedPerson2.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(365, 92);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "ชื่อผู้มีอำนาจลงนาม 2";
            // 
            // txtAuthorizedPersonPosition
            // 
            this.txtAuthorizedPersonPosition.Location = new System.Drawing.Point(128, 120);
            this.txtAuthorizedPersonPosition.MaxLength = 80;
            this.txtAuthorizedPersonPosition.Name = "txtAuthorizedPersonPosition";
            this.txtAuthorizedPersonPosition.Size = new System.Drawing.Size(224, 20);
            this.txtAuthorizedPersonPosition.TabIndex = 20;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(78, 124);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "ตำแหน่ง";
            // 
            // txtAuthorizedPerson
            // 
            this.txtAuthorizedPerson.Location = new System.Drawing.Point(128, 88);
            this.txtAuthorizedPerson.MaxLength = 80;
            this.txtAuthorizedPerson.Name = "txtAuthorizedPerson";
            this.txtAuthorizedPerson.Size = new System.Drawing.Size(224, 20);
            this.txtAuthorizedPerson.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "ชื่อผู้มีอำนาจลงนาม 1";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(128, 56);
            this.txtContactPerson.MaxLength = 60;
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(584, 20);
            this.txtContactPerson.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(71, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "ชื่อผู้ติดต่อ";
            // 
            // txtFaxNo
            // 
            this.txtFaxNo.Location = new System.Drawing.Point(472, 24);
            this.txtFaxNo.MaxLength = 50;
            this.txtFaxNo.Name = "txtFaxNo";
            this.txtFaxNo.Size = new System.Drawing.Size(240, 20);
            this.txtFaxNo.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(424, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "โทรสาร";
            // 
            // txtTelNo
            // 
            this.txtTelNo.Location = new System.Drawing.Point(128, 24);
            this.txtTelNo.MaxLength = 50;
            this.txtTelNo.Name = "txtTelNo";
            this.txtTelNo.Size = new System.Drawing.Size(240, 20);
            this.txtTelNo.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(77, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "โทรศัพท์";
            // 
            // frmCustomerEntry
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(767, 533);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Name = "frmCustomerEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCustomerRegistrationEntry";
            this.Load += new System.EventHandler(this.frmCustomerEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmCustomer parentForm;
		private Customer objCustomer;
		#endregion - Private -

		//  ===================================== Property ===============================
		public Customer getCustomer()
		{
			objCustomer = new Customer();
			objCustomer.Code = txtCustomerCode.Text;
            // 4/7/2011 montri j. reconsile with BizPac
            objCustomer.BizPacCode = txtBizPacCode.Text;
            // 7/5/2019 [Kriangkrai A.] Add field SAP Code to allow user edit/add 
            objCustomer.SAPCode = txtSAPCode.Text;
			objCustomer.ShortName = txtShortName.Text;
			objCustomer.ACustomerGroup = (CustomerGroup)cboCustomerGroup.SelectedItem;
			objCustomer.ACustomerContractGroup = (CustomerContractGroup)cboCustomerContractGroup.SelectedItem;
			objCustomer.AName.Thai = txtTHName.Text;
			objCustomer.AName.English = txtENName.Text;
			objCustomer.ACurrentAddress.AddressLine = txtAddress.Text;
			objCustomer.ACurrentAddress.StreetName.Name = cboStreet.Text;
			objCustomer.ACurrentAddress.Tambon.Name = cboSubDistrict.Text;
            objCustomer.ACurrentAddress.District.Name = cboDistrict.Text;
			objCustomer.ACurrentAddress.Province.Name = cboProvince.Text;
			objCustomer.ACurrentAddress.PostalCode = fpiPostelCode.Text;
			objCustomer.ACurrentAddress.AContactInfo.Telephone = txtTelNo.Text;
			objCustomer.ACurrentAddress.AContactInfo.Fax = txtFaxNo.Text;
			objCustomer.ContactPerson = txtContactPerson.Text;
			objCustomer.AuthorizedPerson = txtAuthorizedPerson.Text;
            objCustomer.AuthorizedPersonPosition = txtAuthorizedPersonPosition.Text;
            objCustomer.AuthorizedPerson2 = txtAuthorizedPerson2.Text.Trim();
            objCustomer.AuthorizedPersonPosition2 = txtAuthorizedPersonPosition2.Text.Trim();

			return objCustomer;
		}
	
		public void setCustomer(Customer value)
		{
			objCustomer = value;

			txtCustomerCode.Text = value.Code;
            // 4/7/2011 montri j. reconsile with BizPac
            txtBizPacCode.Text = value.BizPacCode;
            // 7/5/2019 [Kriangkrai A.] Add field SAP Code to allow user edit/add 
            txtSAPCode.Text = value.SAPCode;
			txtShortName.Text = value.ShortName;
			cboCustomerGroup.Text = value.ACustomerGroup.AName.Thai;
			cboCustomerContractGroup.Text = value.ACustomerContractGroup.AName.Thai;
			txtTHName.Text = value.AName.Thai;
			txtENName.Text = value.AName.English;
			txtAddress.Text = value.ACurrentAddress.AddressLine;
			cboStreet.Text = value.ACurrentAddress.StreetName.Name;
			cboSubDistrict.Text = value.ACurrentAddress.Tambon.Name;
			cboDistrict.Text = value.ACurrentAddress.District.Name;
			cboProvince.Text = value.ACurrentAddress.Province.Name;
            fpiPostelCode.Text = value.ACurrentAddress.PostalCode;
			txtTelNo.Text = value.ACurrentAddress.AContactInfo.Telephone;
			txtFaxNo.Text = value.ACurrentAddress.AContactInfo.Fax;
			txtContactPerson.Text = value.ContactPerson;
			txtAuthorizedPerson.Text = value.AuthorizedPerson;
            txtAuthorizedPersonPosition.Text = value.AuthorizedPersonPosition;
            txtAuthorizedPerson2.Text = value.AuthorizedPerson2;
            txtAuthorizedPersonPosition2.Text = value.AuthorizedPersonPosition2;

		}
		//  ===================================== Constructor ============================
		public frmCustomerEntry(frmCustomer parentForm):base()
		{
			InitializeComponent();						
			this.parentForm = parentForm;	
			CTFunction ctFunction = new CTFunction();
			cboCustomerGroup.DataSource = parentForm.FacadeCustomer.DataSourceCustomerGroup;
			cboCustomerContractGroup.DataSource = parentForm.FacadeCustomer.DataSourceCustomerContractGroup;
			cboSubDistrict.DataSource = parentForm.FacadeCustomer.DataSourceSubDistrict;
			cboDistrict.DataSource = parentForm.FacadeCustomer.DataSourceDistrict;
			cboProvince.DataSource = parentForm.FacadeCustomer.DataSourceProvince;
			cboStreet.DataSource = parentForm.FacadeCustomer.DataSourceStreet;
			cboStreet.SelectedIndex = -1;
			cboCustomerGroup.SelectedIndex = -1;
			cboSubDistrict.SelectedIndex = -1;
			cboDistrict.SelectedIndex = -1;
			cboProvince.SelectedIndex = -1;
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractCustomerData");
		}

		//	============================== Private Method ================================
		#region - Validate Checking -
		private bool ValidateCustomerKey()
		{
			return (txtCustomerCode.Text != "");
		}	
		private bool ValidateForm()
		{
			if(ValidateCustomerCode() && ValidateInputCustomerCode() && ValidateInputMaxCustomerCode()
		        && ValidateCustomerGroup() && ValidateShortName() 	 
				&& ValidateCustomerContractGroup() && ValidateTHName() 
				&& ValidateENName() && ValidateAddress() 
				&& ValidateStreet() && ValidateSubDistrict() 
				&& ValidateDistrict() && ValidateProvince()
				&& ValidatePostelCode() && ValidateTelNo()
                && ValidateContractPerson() && ValidateAuthorizedPerson() && ValidateAuthorizedPersonPosition() && validateOTPattern())
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private bool ValidateCustomerCode()
		{
			if(txtCustomerCode.Text == "") 
			{
				Message(MessageList.Error.E0002, "รหัสลูกค้า" );
				txtCustomerCode.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateInputCustomerCode()
		{
			if(txtCustomerCode.Text == Customer.DUMMYCODE) 
			{
				Message(MessageList.Error.E0026);
				txtCustomerCode.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateInputMaxCustomerCode()
		{
			string aCustCode = txtCustomerCode.Text.Trim();
		
			int foundS1 = aCustCode.IndexOf(" ");
			while(foundS1 > 0)
			{
				aCustCode = aCustCode.Remove(foundS1, 1);
				foundS1 = aCustCode.IndexOf(" ");
			}

			if(aCustCode.Length != 6)
			{
				Message(MessageList.Error.E0002,"รหัสลูกค้าให้ครบ 6 ตัวอักษร");
				txtCustomerCode.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateCustomerGroup()
		{
			if(cboCustomerGroup.Text == "") 
			{
				Message(MessageList.Error.E0005, "กลุ่มลูกค้า" );
				cboCustomerGroup.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateCustomerContractGroup()
		{
			if(cboCustomerContractGroup.Text == "") 
			{
				Message(MessageList.Error.E0005, "กลุ่มลูกค้าในสัญญา" );
				cboCustomerContractGroup.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateShortName()
		{
			if(txtShortName.Text == "") 
			{
				Message(MessageList.Error.E0002, "ชื่อย่อลูกค้า" );
				txtShortName.Focus();
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
				Message(MessageList.Error.E0002, "ชื่อลูกค้า (ภาษาไทย)" );
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
				Message(MessageList.Error.E0002, "ชื่อลูกค้า (ภาษาอังกฤษ)" );
				txtENName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateAddress()
		{
			if(txtAddress.Text == "") 
			{
				Message(MessageList.Error.E0002, "ที่อยู่" );
				txtAddress.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateStreet()
		{
			if(cboStreet.Text == "") 
			{
				Message(MessageList.Error.E0002, "ถนน" );
				cboStreet.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateSubDistrict()
		{
			if(cboSubDistrict.Text == "") 
			{
				Message(MessageList.Error.E0002, "แขวง" );
				cboSubDistrict.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateDistrict()
		{
			if(cboDistrict.Text == "") 
			{
				Message(MessageList.Error.E0002, "เขต" );
				cboDistrict.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateProvince()
		{
			if(cboProvince.Text == "") 
			{
				Message(MessageList.Error.E0002, "จังหวัด" );
				cboProvince.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidatePostelCode()
		{
			if(fpiPostelCode.Text == "") 
			{
				Message(MessageList.Error.E0002, "รหัสไปรษณีย์" );
				fpiPostelCode.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateTelNo()
		{
			if(txtTelNo.Text == "") 
			{
				Message(MessageList.Error.E0002, "หมายเลขโทรศัพท์" );
				txtTelNo.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		
		private bool ValidateContractPerson()
		{
			if(txtContactPerson.Text == "") 
			{
				Message(MessageList.Error.E0002, "ชื่อผู้มาติดต่อ" );
				txtContactPerson.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidateAuthorizedPerson()
		{
			if(txtAuthorizedPerson.Text == "") 
			{
				Message(MessageList.Error.E0002, "ชื่อผู้มีอำนาจลงนาม" );
				txtAuthorizedPerson.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
        private bool ValidateAuthorizedPersonPosition()
        {
            if (txtAuthorizedPersonPosition.Text == "")
            {
                Message(MessageList.Error.E0002, "ตำแหน่ง");
                txtAuthorizedPersonPosition.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validateOTPattern()
        { 
            return Message(MessageList.Warning.W0002) == DialogResult.OK;
        }
		#endregion - Validate Checking -

		private void enableKeyField(bool enable)
		{
			txtCustomerCode.Enabled = enable;
		}
		private void clearForm()
		{
			txtCustomerCode.Focus();
			cboSubDistrict.DataSource = parentForm.FacadeCustomer.DataSourceSubDistrict;
			cboDistrict.DataSource = parentForm.FacadeCustomer.DataSourceDistrict;
			cboProvince.DataSource = parentForm.FacadeCustomer.DataSourceProvince;
			cboStreet.DataSource = parentForm.FacadeCustomer.DataSourceStreet;
			txtCustomerCode.Text = "";
			txtENName.Text = "";
			txtTHName.Text = "";
			txtAddress.Text = "";
			fpiPostelCode.Text = "";
			txtTelNo.Text = "";
			txtFaxNo.Text = "";
			txtShortName.Text = "";
			txtContactPerson.Text = "";
			txtAuthorizedPerson.Text = "";
            txtAuthorizedPersonPosition.Text = "";
            txtAuthorizedPerson2.Text = "";
            txtAuthorizedPersonPosition2.Text = "";
			cboProvince.Text = "Bangkok";
			cboStreet.SelectedIndex = -1;
			cboCustomerGroup.SelectedIndex = -1;
			cboCustomerContractGroup.SelectedIndex = -1;
			cboSubDistrict.SelectedIndex = -1;
			cboDistrict.SelectedIndex = -1;
            txtSAPCode.Text = "";
            txtBizPacCode.Text = "";
		}
			
		//	============================== Public Method =================================
		private CustomerFacade objCustomerFacade;
		public CustomerFacade ObjCustomerFacade	
		{
			set
			{objCustomerFacade = value;}
		}
		
		public void InitAddAction()	
		{
			this.title = "ลูกค้า";
			baseADD();
			clearForm();
			enableKeyField(true);
		}
		public void InitEditAction(Customer value)
		{
			this.title = "ลูกค้า";
			baseEDIT();
			clearForm();
			enableKeyField(false);
			objCustomer = value;

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}
		public void CustomerCodeFocus()
		{
			txtCustomerCode.Focus();
		}
		public void CustomerGroupFocus()
		{
			cboCustomerGroup.Focus();
		}
		//	============================== Base Event ====================================
		private void AddEvent()
		{
			
			try
			{  
				if (ValidateForm() && parentForm.AddRow(getCustomer()))
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
				txtCustomerCode.Focus();
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
				if (ValidateForm() && parentForm.UpdateRow(getCustomer()))
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

		private void frmCustomerEntry_Load(object sender, System.EventArgs e)
		{
			if(action == ActionType.ADD)
			{
				clearForm();
			}
			else
			{
				setCustomer(objCustomer);
			}
		}
	}
}
