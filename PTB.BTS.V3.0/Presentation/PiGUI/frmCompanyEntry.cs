using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using Entity.CommonEntity;

using Facade.PiFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.PiGUI
{
	public class frmCompanyEntry : EntryFormBase, IMDIChildForm
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
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtEngName;
		private System.Windows.Forms.TextBox txtEngShortName;
		private System.Windows.Forms.TextBox txtThaiName;
		private System.Windows.Forms.TextBox txtCompanyCode;
		private System.Windows.Forms.TextBox txtEngStreet;
		private System.Windows.Forms.TextBox txtEngAddress;
		private System.Windows.Forms.TextBox txtThaiStreet;
		private System.Windows.Forms.TextBox txtThaiAddress;
		private System.Windows.Forms.TextBox txtFaxNo;
		private System.Windows.Forms.TextBox txtTelNo;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.TextBox txtThaiSubDistrict;
		private System.Windows.Forms.TextBox txtThaiDistrict;
		private System.Windows.Forms.TextBox txtThaiProvince;
		private System.Windows.Forms.TextBox txtEngDistrict;
		private System.Windows.Forms.TextBox txtEngProveince;
		private System.Windows.Forms.TextBox txtEngSubDistrict;
		private FarPoint.Win.Input.FpInteger txtPostalCode;
        private Label label22;
        private Label label21;
        private TextBox txtAuthorizePerson3;
        private TextBox txtAuthorizePerson2;
        private TextBox txtAuthorizePerson1;
        private Label label20;
        private Label label19;
        private Label label18;
        private TextBox txtAuthorizePersonPosition3;
        private TextBox txtAuthorizePersonPosition2;
        private TextBox txtAuthorizePersonPosition1;
        private Label label23;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEngName = new System.Windows.Forms.TextBox();
            this.txtEngShortName = new System.Windows.Forms.TextBox();
            this.txtThaiName = new System.Windows.Forms.TextBox();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEngProveince = new System.Windows.Forms.TextBox();
            this.txtEngDistrict = new System.Windows.Forms.TextBox();
            this.txtEngSubDistrict = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEngStreet = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEngAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtThaiProvince = new System.Windows.Forms.TextBox();
            this.txtThaiDistrict = new System.Windows.Forms.TextBox();
            this.txtThaiSubDistrict = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtThaiStreet = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtThaiAddress = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtAuthorizePersonPosition3 = new System.Windows.Forms.TextBox();
            this.txtAuthorizePersonPosition2 = new System.Windows.Forms.TextBox();
            this.txtAuthorizePersonPosition1 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtAuthorizePerson3 = new System.Windows.Forms.TextBox();
            this.txtAuthorizePerson2 = new System.Windows.Forms.TextBox();
            this.txtAuthorizePerson1 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPostalCode = new FarPoint.Win.Input.FpInteger();
            this.txtFaxNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTelNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEngName);
            this.groupBox1.Controls.Add(this.txtEngShortName);
            this.groupBox1.Controls.Add(this.txtThaiName);
            this.groupBox1.Controls.Add(this.txtCompanyCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ชื่อภาษาไทย";
            // 
            // txtEngName
            // 
            this.txtEngName.Location = new System.Drawing.Point(248, 56);
            this.txtEngName.MaxLength = 50;
            this.txtEngName.Name = "txtEngName";
            this.txtEngName.Size = new System.Drawing.Size(320, 20);
            this.txtEngName.TabIndex = 4;
            // 
            // txtEngShortName
            // 
            this.txtEngShortName.Location = new System.Drawing.Point(64, 56);
            this.txtEngShortName.MaxLength = 10;
            this.txtEngShortName.Name = "txtEngShortName";
            this.txtEngShortName.Size = new System.Drawing.Size(48, 20);
            this.txtEngShortName.TabIndex = 3;
            // 
            // txtThaiName
            // 
            this.txtThaiName.Location = new System.Drawing.Point(248, 24);
            this.txtThaiName.MaxLength = 50;
            this.txtThaiName.Name = "txtThaiName";
            this.txtThaiName.Size = new System.Drawing.Size(320, 20);
            this.txtThaiName.TabIndex = 2;
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Location = new System.Drawing.Point(64, 24);
            this.txtCompanyCode.MaxLength = 2;
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(48, 20);
            this.txtCompanyCode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ชื่อย่อ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ชื่อภาษาอังกฤษ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัส";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.txtEngProveince);
            this.groupBox2.Controls.Add(this.txtEngDistrict);
            this.groupBox2.Controls.Add(this.txtEngSubDistrict);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtEngStreet);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtEngAddress);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(512, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 128);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ที่อยู่ภาษาอังกฤษ  ";
            // 
            // txtEngProveince
            // 
            this.txtEngProveince.Location = new System.Drawing.Point(344, 88);
            this.txtEngProveince.MaxLength = 30;
            this.txtEngProveince.Name = "txtEngProveince";
            this.txtEngProveince.Size = new System.Drawing.Size(152, 20);
            this.txtEngProveince.TabIndex = 14;
            // 
            // txtEngDistrict
            // 
            this.txtEngDistrict.Location = new System.Drawing.Point(88, 88);
            this.txtEngDistrict.MaxLength = 30;
            this.txtEngDistrict.Name = "txtEngDistrict";
            this.txtEngDistrict.Size = new System.Drawing.Size(168, 20);
            this.txtEngDistrict.TabIndex = 13;
            // 
            // txtEngSubDistrict
            // 
            this.txtEngSubDistrict.Location = new System.Drawing.Point(344, 56);
            this.txtEngSubDistrict.MaxLength = 30;
            this.txtEngSubDistrict.Name = "txtEngSubDistrict";
            this.txtEngSubDistrict.Size = new System.Drawing.Size(152, 20);
            this.txtEngSubDistrict.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Street";
            // 
            // txtEngStreet
            // 
            this.txtEngStreet.Location = new System.Drawing.Point(88, 56);
            this.txtEngStreet.MaxLength = 30;
            this.txtEngStreet.Name = "txtEngStreet";
            this.txtEngStreet.Size = new System.Drawing.Size(168, 20);
            this.txtEngStreet.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(264, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Province";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "District";
            // 
            // txtEngAddress
            // 
            this.txtEngAddress.Location = new System.Drawing.Point(88, 24);
            this.txtEngAddress.MaxLength = 50;
            this.txtEngAddress.Name = "txtEngAddress";
            this.txtEngAddress.Size = new System.Drawing.Size(408, 20);
            this.txtEngAddress.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Sub District";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Address";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.txtThaiProvince);
            this.groupBox3.Controls.Add(this.txtThaiDistrict);
            this.groupBox3.Controls.Add(this.txtThaiSubDistrict);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtThaiStreet);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtThaiAddress);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(16, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(488, 128);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ที่อยู่ภาษาไทย";
            // 
            // txtThaiProvince
            // 
            this.txtThaiProvince.Location = new System.Drawing.Point(312, 88);
            this.txtThaiProvince.MaxLength = 30;
            this.txtThaiProvince.Name = "txtThaiProvince";
            this.txtThaiProvince.Size = new System.Drawing.Size(168, 20);
            this.txtThaiProvince.TabIndex = 9;
            // 
            // txtThaiDistrict
            // 
            this.txtThaiDistrict.Location = new System.Drawing.Point(88, 88);
            this.txtThaiDistrict.MaxLength = 30;
            this.txtThaiDistrict.Name = "txtThaiDistrict";
            this.txtThaiDistrict.Size = new System.Drawing.Size(168, 20);
            this.txtThaiDistrict.TabIndex = 8;
            // 
            // txtThaiSubDistrict
            // 
            this.txtThaiSubDistrict.Location = new System.Drawing.Point(312, 56);
            this.txtThaiSubDistrict.MaxLength = 30;
            this.txtThaiSubDistrict.Name = "txtThaiSubDistrict";
            this.txtThaiSubDistrict.Size = new System.Drawing.Size(168, 20);
            this.txtThaiSubDistrict.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "ถนน";
            // 
            // txtThaiStreet
            // 
            this.txtThaiStreet.Location = new System.Drawing.Point(88, 56);
            this.txtThaiStreet.MaxLength = 30;
            this.txtThaiStreet.Name = "txtThaiStreet";
            this.txtThaiStreet.Size = new System.Drawing.Size(168, 20);
            this.txtThaiStreet.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "จังหวัด";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "เขต";
            // 
            // txtThaiAddress
            // 
            this.txtThaiAddress.Location = new System.Drawing.Point(88, 24);
            this.txtThaiAddress.MaxLength = 50;
            this.txtThaiAddress.Name = "txtThaiAddress";
            this.txtThaiAddress.Size = new System.Drawing.Size(392, 20);
            this.txtThaiAddress.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(264, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "แขวง";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "ที่อยู่";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox4.Controls.Add(this.txtAuthorizePersonPosition3);
            this.groupBox4.Controls.Add(this.txtAuthorizePersonPosition2);
            this.groupBox4.Controls.Add(this.txtAuthorizePersonPosition1);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.txtAuthorizePerson3);
            this.groupBox4.Controls.Add(this.txtAuthorizePerson2);
            this.groupBox4.Controls.Add(this.txtAuthorizePerson1);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.txtPostalCode);
            this.groupBox4.Controls.Add(this.txtFaxNo);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txtTelNo);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(16, 256);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1000, 192);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "อื่นๆ";
            // 
            // txtAuthorizePersonPosition3
            // 
            this.txtAuthorizePersonPosition3.Location = new System.Drawing.Point(560, 152);
            this.txtAuthorizePersonPosition3.MaxLength = 50;
            this.txtAuthorizePersonPosition3.Name = "txtAuthorizePersonPosition3";
            this.txtAuthorizePersonPosition3.Size = new System.Drawing.Size(432, 20);
            this.txtAuthorizePersonPosition3.TabIndex = 26;
            // 
            // txtAuthorizePersonPosition2
            // 
            this.txtAuthorizePersonPosition2.Location = new System.Drawing.Point(560, 120);
            this.txtAuthorizePersonPosition2.MaxLength = 50;
            this.txtAuthorizePersonPosition2.Name = "txtAuthorizePersonPosition2";
            this.txtAuthorizePersonPosition2.Size = new System.Drawing.Size(432, 20);
            this.txtAuthorizePersonPosition2.TabIndex = 25;
            // 
            // txtAuthorizePersonPosition1
            // 
            this.txtAuthorizePersonPosition1.Location = new System.Drawing.Point(560, 88);
            this.txtAuthorizePersonPosition1.MaxLength = 50;
            this.txtAuthorizePersonPosition1.Name = "txtAuthorizePersonPosition1";
            this.txtAuthorizePersonPosition1.Size = new System.Drawing.Size(432, 20);
            this.txtAuthorizePersonPosition1.TabIndex = 24;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(488, 152);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 13);
            this.label23.TabIndex = 23;
            this.label23.Text = "ตำแหน่ง";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(488, 120);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 13);
            this.label22.TabIndex = 22;
            this.label22.Text = "ตำแหน่ง";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(488, 88);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 13);
            this.label21.TabIndex = 21;
            this.label21.Text = "ตำแหน่ง";
            // 
            // txtAuthorizePerson3
            // 
            this.txtAuthorizePerson3.Location = new System.Drawing.Point(112, 152);
            this.txtAuthorizePerson3.MaxLength = 50;
            this.txtAuthorizePerson3.Name = "txtAuthorizePerson3";
            this.txtAuthorizePerson3.Size = new System.Drawing.Size(368, 20);
            this.txtAuthorizePerson3.TabIndex = 20;
            // 
            // txtAuthorizePerson2
            // 
            this.txtAuthorizePerson2.Location = new System.Drawing.Point(112, 120);
            this.txtAuthorizePerson2.MaxLength = 50;
            this.txtAuthorizePerson2.Name = "txtAuthorizePerson2";
            this.txtAuthorizePerson2.Size = new System.Drawing.Size(368, 20);
            this.txtAuthorizePerson2.TabIndex = 19;
            // 
            // txtAuthorizePerson1
            // 
            this.txtAuthorizePerson1.Location = new System.Drawing.Point(112, 88);
            this.txtAuthorizePerson1.MaxLength = 50;
            this.txtAuthorizePerson1.Name = "txtAuthorizePerson1";
            this.txtAuthorizePerson1.Size = new System.Drawing.Size(368, 20);
            this.txtAuthorizePerson1.TabIndex = 18;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 152);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(101, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "ชื่อผู้มีอำนาจลงนาม3";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 120);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(101, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "ชื่อผู้มีอำนาจลงนาม2";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 88);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "ชื่อผู้มีอำนาจลงนาม1";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.AllowClipboardKeys = true;
            this.txtPostalCode.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.txtPostalCode.Location = new System.Drawing.Point(112, 24);
            this.txtPostalCode.MaxValue = 99999;
            this.txtPostalCode.MinValue = 0;
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(75, 20);
            this.txtPostalCode.TabIndex = 15;
            this.txtPostalCode.Text = "";
            // 
            // txtFaxNo
            // 
            this.txtFaxNo.Location = new System.Drawing.Point(560, 56);
            this.txtFaxNo.MaxLength = 50;
            this.txtFaxNo.Name = "txtFaxNo";
            this.txtFaxNo.Size = new System.Drawing.Size(432, 20);
            this.txtFaxNo.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(488, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "เบอร์โทรสาร";
            // 
            // txtTelNo
            // 
            this.txtTelNo.Location = new System.Drawing.Point(112, 56);
            this.txtTelNo.MaxLength = 50;
            this.txtTelNo.Name = "txtTelNo";
            this.txtTelNo.Size = new System.Drawing.Size(368, 20);
            this.txtTelNo.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "เบอร์โทรศัพท์";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "รหัสไปรษณีย์";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdOK.Location = new System.Drawing.Point(424, 488);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 24);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(504, 488);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 24);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmCompanyEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1030, 532);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCompanyEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ข้อมูลบริษัท";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCompanyEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		#endregion

//		============================== Property ==============================
		public CompanyInfo getCompany()
		{
            objCompany = new CompanyInfo(txtCompanyCode.Text);

            ictus.Common.Entity.Description fullName = new ictus.Common.Entity.Description();
            fullName.English = txtEngName.Text;
            fullName.Thai = txtThaiName.Text;
            objCompany.AFullName = fullName;

            ictus.Common.Entity.Description shortName = new ictus.Common.Entity.Description();
            shortName.English = txtEngShortName.Text;
            objCompany.AShortName = shortName;
			
			objCompany.AThaiAddress.AddressLine =  txtThaiAddress.Text;
			objCompany.AThaiAddress.StreetName.Name = txtThaiStreet.Text;
			objCompany.AThaiAddress.Tambon.Name = txtThaiSubDistrict.Text;
			objCompany.AThaiAddress.District.Name = txtThaiDistrict.Text;
			objCompany.AThaiAddress.Province.Name  =txtThaiProvince.Text;
			objCompany.AThaiAddress.PostalCode = txtPostalCode.Text;
			objCompany.AEnglishAddress.AddressLine = txtEngAddress.Text;
			objCompany.AEnglishAddress.StreetName.Name = txtEngStreet.Text;
			objCompany.AEnglishAddress.Tambon.Name = txtEngSubDistrict.Text;
			objCompany.AEnglishAddress.District.Name = txtEngDistrict.Text;
			objCompany.AEnglishAddress.Province.Name = txtEngProveince.Text;
			objCompany.AThaiAddress.AContactInfo.Telephone = txtTelNo.Text;
			objCompany.AThaiAddress.AContactInfo.Fax = txtFaxNo.Text;
            objCompany.AuthorizedPerson1 = txtAuthorizePerson1.Text;
            objCompany.AuthorizedPersonPosition1 = txtAuthorizePersonPosition1.Text;
            objCompany.AuthorizedPerson2 = txtAuthorizePerson2.Text;
            objCompany.AuthorizedPersonPosition2 = txtAuthorizePersonPosition2.Text;
            objCompany.AuthorizedPerson3 = txtAuthorizePerson3.Text;
            objCompany.AuthorizedPersonPosition3 = txtAuthorizePersonPosition3.Text;

			return objCompany;
		}
		public void setCompany(CompanyInfo aCompany)
		{
			objCompany = aCompany;
			txtCompanyCode.Text = GUIFunction.GetString(aCompany.CompanyCode);
			txtEngShortName.Text = GUIFunction.GetString(aCompany.AShortName.English);
			txtThaiName.Text = GUIFunction.GetString(aCompany.AFullName.Thai);
			txtEngName.Text = GUIFunction.GetString(aCompany.AFullName.English);
			txtThaiAddress.Text = GUIFunction.GetString(aCompany.AThaiAddress.AddressLine);
			txtThaiStreet.Text = GUIFunction.GetString(aCompany.AThaiAddress.StreetName.Name);
			txtThaiSubDistrict.Text = GUIFunction.GetString(aCompany.AThaiAddress.Tambon.Name);
			txtThaiDistrict.Text = GUIFunction.GetString(aCompany.AThaiAddress.District.Name);
			txtThaiProvince.Text = GUIFunction.GetString(aCompany.AThaiAddress.Province.Name);
			txtPostalCode.Text = GUIFunction.GetString(aCompany.AThaiAddress.PostalCode);
			txtEngAddress.Text = GUIFunction.GetString(aCompany.AEnglishAddress.AddressLine);
			txtEngStreet.Text = GUIFunction.GetString(aCompany.AEnglishAddress.StreetName.Name);
			txtEngSubDistrict.Text = GUIFunction.GetString(aCompany.AEnglishAddress.Tambon.Name);
			txtEngDistrict.Text = GUIFunction.GetString(aCompany.AEnglishAddress.District.Name);
			txtEngProveince.Text = GUIFunction.GetString(aCompany.AEnglishAddress.Province.Name);
			txtTelNo.Text = GUIFunction.GetString(aCompany.AThaiAddress.AContactInfo.Telephone);
			txtFaxNo.Text = GUIFunction.GetString(aCompany.AThaiAddress.AContactInfo.Fax);
            txtAuthorizePerson1.Text = aCompany.AuthorizedPerson1;
            txtAuthorizePersonPosition1.Text = aCompany.AuthorizedPersonPosition1;
            txtAuthorizePerson2.Text = aCompany.AuthorizedPerson2;
            txtAuthorizePersonPosition2.Text = aCompany.AuthorizedPersonPosition2;
            txtAuthorizePerson3.Text = aCompany.AuthorizedPerson3;
            txtAuthorizePersonPosition3.Text = aCompany.AuthorizedPersonPosition3;

		}
//		============================== Constructor ==============================
		public frmCompanyEntry(): base()
		{
			InitializeComponent();
			objCompany = new CompanyInfo("12");
			facadeCompany = new CompanyFacade();
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMapCompany");
		}

//		============================== private method ==============================
		private void enableKeyField(bool enable)
		{
			txtCompanyCode.Enabled = enable;
		}
		private void clearForm()
		{
			txtCompanyCode.Text  ="";
			txtEngShortName.Text = "";
			txtThaiName.Text = "";
			txtEngName.Text = "";
			txtThaiAddress.Text = "";
			txtThaiStreet.Text = "";
			txtThaiSubDistrict.Text = "";
			txtThaiDistrict.Text = "";
			txtThaiProvince.Text = "";
			txtPostalCode.Text = "";
			txtEngAddress.Text = "";
			txtEngStreet.Text = "";
			txtEngSubDistrict.Text = "";
			txtEngDistrict.Text = "";
			txtEngProveince.Text = "";
			txtTelNo.Text = "";
			txtFaxNo.Text = "";
            txtAuthorizePerson1.Text = "";
            txtAuthorizePersonPosition1.Text = "";
            txtAuthorizePerson2.Text = "";
            txtAuthorizePersonPosition2.Text = "";
            txtAuthorizePerson3.Text = "";
            txtAuthorizePersonPosition3.Text = "";

		}

		#region - validate -
		private bool validate1()
		{
			if (txtEngShortName.Text == "")
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
		private bool validate2()
		{
			if (txtThaiName.Text == "")
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
		private bool validate3()
		{
			if (txtEngName.Text == "")
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
		private bool validate4()
		{
			if (txtThaiAddress.Text == "")
			{
				Message(MessageList.Error.E0002, "ที่อยู่" );
				txtThaiAddress.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate5()
		{
			if (txtThaiStreet.Text == "")
			{
				Message(MessageList.Error.E0002, "ถนน" );
				txtThaiStreet.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate6()
		{
			if (txtThaiSubDistrict.Text == "")
			{
				Message(MessageList.Error.E0002, "แขวง" );
				txtThaiSubDistrict.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate7()
		{
			if (txtThaiDistrict.Text == "")
			{
				Message(MessageList.Error.E0002, "เขต" );
				txtThaiDistrict.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate8()
		{
			if (txtThaiProvince.Text == "")
			{
				Message(MessageList.Error.E0002, "จังหวัด" );
				txtThaiProvince.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate9()
		{
			if (txtEngAddress.Text == "")
			{
				Message(MessageList.Error.E0002, "Address" );
				txtEngAddress.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate10()
		{
			if (txtEngStreet.Text == "")
			{
				Message(MessageList.Error.E0002, "Street" );
				txtEngStreet.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate11()
		{
			if (txtEngSubDistrict.Text == "")
			{
				Message(MessageList.Error.E0002, "SubDistrict" );
				txtEngSubDistrict.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate12()
		{
			if (txtEngDistrict.Text == "")
			{
				Message(MessageList.Error.E0002, "District" );
				txtEngDistrict.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate13()
		{
			if (txtEngProveince.Text == "")
			{
				Message(MessageList.Error.E0002, "Proveince" );
				txtEngProveince.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate14()
		{
			if (txtPostalCode.Text == "")
			{
				Message(MessageList.Error.E0002, "รหัสไปรษณีย์" );
				txtPostalCode.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate15()
		{
			if (txtTelNo.Text == "")
			{
				Message(MessageList.Error.E0002, "เบอร์โทรศัพท์" );
				txtTelNo.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate16()
		{
			if (txtFaxNo.Text == "")
			{
				Message(MessageList.Error.E0002, "เบอร์โทรสาร" );
				txtFaxNo.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
        private bool validate17()
        {
            if (txtAuthorizePerson1.Text == "")
            {
                Message(MessageList.Error.E0002, "ชื่อผู้มีอำนาจลงนาม1");
                txtAuthorizePerson1.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validate18()
        {
            if (txtAuthorizePersonPosition1.Text == "")
            {
                Message(MessageList.Error.E0002, "ตำแหน่ง");
                txtAuthorizePersonPosition1.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validate19()
        {
            if (txtAuthorizePerson2.Text == "")
            {
                Message(MessageList.Error.E0002, "ชื่อผู้มีอำนาจลงนาม2");
                txtAuthorizePerson2.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validate20()
        {
            if (txtAuthorizePersonPosition2.Text == "")
            {
                Message(MessageList.Error.E0002, "ตำแหน่ง");
                txtAuthorizePersonPosition2.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validate21()
        {
            if (txtAuthorizePerson3.Text == "")
            {
                Message(MessageList.Error.E0002, "ชื่อผู้มีอำนาจลงนาม3");
                txtAuthorizePerson3.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validate22()
        {
            if (txtAuthorizePersonPosition3.Text == "")
            {
                Message(MessageList.Error.E0002, "ตำแหน่ง");
                txtAuthorizePersonPosition3.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }


		private bool validateForm()
		{
            return validate1() && validate2() && validate3() && validate4() && validate5() && validate6() && validate7() && validate8() && validate9() && validate10() && validate11() && validate12() && validate13() && validate14() && validate15() && validate16() && validate17() && validate18() && validate19() && validate20() && validate21() && validate22();
		}

		#endregion

//		============================== Base Event ==============================
		public void InitForm()
		{
			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(true);
			mdiParent.EnablePrintCommand(true);
			MainMenuNewStatus = false;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = true;
			MainMenuPrintStatus = true;

			try
			{
				if (facadeCompany.FillCompany(ref objCompany))
				{
					baseEDIT();
					clearForm();
					setCompany(objCompany);
					enableKeyField(false);
				}
				else
				{
					baseADD();
					clearForm();
					enableKeyField(true);
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

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}
		public void RefreshForm()
		{
			InitForm();
		}

		private void AddEvent()
		{
			try
			{
				if(validateForm())
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					if(facadeCompany.InsertCompany(getCompany()))
					{
						enableKeyField(true);
						this.Cursor = System.Windows.Forms.Cursors.Arrow;
						InitForm();
					}
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
				if(validateForm())
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					if(facadeCompany.UpdateCompany(getCompany()))
					{
						enableKeyField(false);
						this.Cursor = System.Windows.Forms.Cursors.Arrow;
					}
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

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			this.Hide();
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

		private void frmCompanyEntry_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

        #region IMDIChildForm Members

        public int MasterCount()
        {
            return 0;
        }

        public string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMapCompany");
        }

        #endregion
    }
}
