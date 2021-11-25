using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using Facade.CommonFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

namespace Presentation.VehicleGUI
{	
	public class frmGarageEntry : EntryFormBase
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
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtShortName;
		private System.Windows.Forms.TextBox txtGarageCode;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.ComboBox cboProvince;
		private System.Windows.Forms.ComboBox cboSubDistrict;
		private System.Windows.Forms.ComboBox cboStreet;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.TextBox txtENName;
		private System.Windows.Forms.TextBox txtTHName;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.ComboBox cboDistrict;
		private FarPoint.Win.Input.FpInteger fpiPostelCode;
		private System.Windows.Forms.TextBox txtFaxNo;
		private System.Windows.Forms.TextBox txtTelNo;
        private GroupBox groupBox3;
        private TextBox txtBizExpenseCode;
        private Label label10;
        private TextBox txtBizVendor;
        private Label label11;
        private TextBox txtBizExpenseName;
        private Label label12;
        private TextBox txtSAPCode;
        private Label label13;
		
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtENName = new System.Windows.Forms.TextBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTHName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGarageCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fpiPostelCode = new FarPoint.Win.Input.FpInteger();
            this.cboStreet = new System.Windows.Forms.ComboBox();
            this.cboProvince = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboSubDistrict = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDistrict = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtFaxNo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTelNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBizExpenseName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBizExpenseCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBizVendor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSAPCode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(313, 440);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 18;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(233, 440);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 17;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtENName);
            this.groupBox1.Controls.Add(this.txtShortName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTHName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtGarageCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 120);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียดศูนย์บริการ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "ชื่อศูนย์บริการ  (ภาษาอังกฤษ)";
            // 
            // txtENName
            // 
            this.txtENName.Location = new System.Drawing.Point(152, 88);
            this.txtENName.MaxLength = 60;
            this.txtENName.Name = "txtENName";
            this.txtENName.Size = new System.Drawing.Size(416, 20);
            this.txtENName.TabIndex = 4;
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(336, 24);
            this.txtShortName.MaxLength = 20;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(232, 20);
            this.txtShortName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "ชื่อย่อศูนย์บริการ";
            // 
            // txtTHName
            // 
            this.txtTHName.Location = new System.Drawing.Point(152, 56);
            this.txtTHName.MaxLength = 70;
            this.txtTHName.Name = "txtTHName";
            this.txtTHName.Size = new System.Drawing.Size(416, 20);
            this.txtTHName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "ชื่อศูนย์บริการ  (ภาษาไทย)";
            // 
            // txtGarageCode
            // 
            this.txtGarageCode.Location = new System.Drawing.Point(152, 24);
            this.txtGarageCode.MaxLength = 3;
            this.txtGarageCode.Name = "txtGarageCode";
            this.txtGarageCode.Size = new System.Drawing.Size(56, 20);
            this.txtGarageCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "รหัสศูนย์บริการ";
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
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(18, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 152);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ที่อยู่";
            // 
            // fpiPostelCode
            // 
            this.fpiPostelCode.AllowClipboardKeys = true;
            this.fpiPostelCode.AllowNull = true;
            this.fpiPostelCode.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiPostelCode.Location = new System.Drawing.Point(400, 120);
            this.fpiPostelCode.MaxValue = 99999;
            this.fpiPostelCode.MinValue = 0;
            this.fpiPostelCode.Name = "fpiPostelCode";
            this.fpiPostelCode.NullColor = System.Drawing.Color.Transparent;
            this.fpiPostelCode.Size = new System.Drawing.Size(88, 20);
            this.fpiPostelCode.TabIndex = 10;
            this.fpiPostelCode.Text = "";
            // 
            // cboStreet
            // 
            this.cboStreet.Location = new System.Drawing.Point(80, 56);
            this.cboStreet.Name = "cboStreet";
            this.cboStreet.Size = new System.Drawing.Size(240, 21);
            this.cboStreet.TabIndex = 6;
            // 
            // cboProvince
            // 
            this.cboProvince.Location = new System.Drawing.Point(80, 120);
            this.cboProvince.MaxLength = 30;
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(240, 21);
            this.cboProvince.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "จังหวัด";
            // 
            // cboSubDistrict
            // 
            this.cboSubDistrict.Location = new System.Drawing.Point(80, 88);
            this.cboSubDistrict.MaxLength = 30;
            this.cboSubDistrict.Name = "cboSubDistrict";
            this.cboSubDistrict.Size = new System.Drawing.Size(240, 21);
            this.cboSubDistrict.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "เขต";
            // 
            // cboDistrict
            // 
            this.cboDistrict.Location = new System.Drawing.Point(400, 88);
            this.cboDistrict.MaxLength = 30;
            this.cboDistrict.Name = "cboDistrict";
            this.cboDistrict.Size = new System.Drawing.Size(168, 21);
            this.cboDistrict.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "แขวง";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "ถนน";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(80, 24);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(488, 20);
            this.txtAddress.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "ที่อยู่";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(328, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "รหัสไปรษณีย์";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtFaxNo);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtTelNo);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Location = new System.Drawing.Point(18, 280);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(584, 56);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "อื่น ๆ";
            // 
            // txtFaxNo
            // 
            this.txtFaxNo.Location = new System.Drawing.Point(408, 24);
            this.txtFaxNo.MaxLength = 50;
            this.txtFaxNo.Name = "txtFaxNo";
            this.txtFaxNo.Size = new System.Drawing.Size(160, 20);
            this.txtFaxNo.TabIndex = 12;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(360, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "โทรสาร";
            // 
            // txtTelNo
            // 
            this.txtTelNo.Location = new System.Drawing.Point(80, 24);
            this.txtTelNo.MaxLength = 50;
            this.txtTelNo.Name = "txtTelNo";
            this.txtTelNo.Size = new System.Drawing.Size(240, 20);
            this.txtTelNo.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "โทรศัพท์";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSAPCode);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtBizExpenseName);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtBizExpenseCode);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtBizVendor);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(18, 336);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(584, 96);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BizPac and SAP";
            // 
            // txtBizExpenseName
            // 
            this.txtBizExpenseName.Location = new System.Drawing.Point(256, 56);
            this.txtBizExpenseName.MaxLength = 50;
            this.txtBizExpenseName.Name = "txtBizExpenseName";
            this.txtBizExpenseName.Size = new System.Drawing.Size(312, 20);
            this.txtBizExpenseName.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(184, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "ชื่อค่าใช้จ่าย";
            // 
            // txtBizExpenseCode
            // 
            this.txtBizExpenseCode.Location = new System.Drawing.Point(80, 56);
            this.txtBizExpenseCode.MaxLength = 6;
            this.txtBizExpenseCode.Name = "txtBizExpenseCode";
            this.txtBizExpenseCode.Size = new System.Drawing.Size(88, 20);
            this.txtBizExpenseCode.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "รหัสค่าใช้จ่าย";
            // 
            // txtBizVendor
            // 
            this.txtBizVendor.Location = new System.Drawing.Point(80, 24);
            this.txtBizVendor.MaxLength = 6;
            this.txtBizVendor.Name = "txtBizVendor";
            this.txtBizVendor.Size = new System.Drawing.Size(88, 20);
            this.txtBizVendor.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "รหัสผู้จำหน่าย";
            // 
            // txtSAPCode
            // 
            this.txtSAPCode.Location = new System.Drawing.Point(256, 24);
            this.txtSAPCode.MaxLength = 8;
            this.txtSAPCode.Name = "txtSAPCode";
            this.txtSAPCode.Size = new System.Drawing.Size(88, 20);
            this.txtSAPCode.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(191, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "SAP Code";
            // 
            // frmGarageEntry
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(620, 473);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Name = "frmGarageEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmGarageEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmGarage parentForm;
		private Garage objGarage;
		#endregion - Private -

		//  ===================================== Property ===============================
		public Garage getGarage()
		{
			objGarage = new Garage();
			objGarage.Code = txtGarageCode.Text;
			objGarage.ShortName = txtShortName.Text;
			objGarage.AName.Thai = txtTHName.Text;
			objGarage.AName.English = txtENName.Text;
			objGarage.ACurrentAddress.AddressLine = txtAddress.Text;
			objGarage.ACurrentAddress.StreetName.Name = cboStreet.Text;
			objGarage.ACurrentAddress.Tambon.Name = cboSubDistrict.Text;
			objGarage.ACurrentAddress.District.Name = cboDistrict.Text;
			objGarage.ACurrentAddress.Province.Name = cboProvince.Text;
			objGarage.ACurrentAddress.PostalCode = fpiPostelCode.Text;
			objGarage.ACurrentAddress.AContactInfo.Telephone = txtTelNo.Text;
			objGarage.ACurrentAddress.AContactInfo.Fax = txtFaxNo.Text;
            objGarage.BizPacVendorCode = txtBizVendor.Text;
            objGarage.BizPacExpenseCode = txtBizExpenseCode.Text;
            objGarage.BizPacExpenseName = txtBizExpenseName.Text;
            objGarage.SAPCode = txtSAPCode.Text;

			return objGarage;
		}

		public void setGarage(Garage value)
		{
			objGarage = value;
			txtGarageCode.Text = value.Code;
			txtShortName.Text = value.ShortName;
			txtENName.Text = value.AName.English;
			txtTHName.Text = value.AName.Thai;
			txtAddress.Text = value.ACurrentAddress.AddressLine;
			cboStreet.Text = value.ACurrentAddress.StreetName.Name;
			cboSubDistrict.Text = value.ACurrentAddress.Tambon.Name;
			cboDistrict.Text = value.ACurrentAddress.District.Name;
			cboProvince.Text = value.ACurrentAddress.Province.Name;
			fpiPostelCode.Text = value.ACurrentAddress.PostalCode;
			txtTelNo.Text = value.ACurrentAddress.AContactInfo.Telephone;
			txtFaxNo.Text = value.ACurrentAddress.AContactInfo.Fax;
            txtBizVendor.Text = value.BizPacVendorCode;
            txtBizExpenseCode.Text = value.BizPacExpenseCode;
            txtBizExpenseName.Text = value.BizPacExpenseName;
            txtSAPCode.Text = value.SAPCode;
		}

		//  ===================================== Constructor ============================
		public frmGarageEntry(frmGarage parentForm):base()
		{
			InitializeComponent();						
			this.parentForm = parentForm;	
			CTFunction ctFunction = new CTFunction();		
			cboProvince.DataSource = parentForm.FacadeGarage.DataSourceProvince;
			cboProvince.Text = "กรุงเทพมหานคร";
			cboStreet.DataSource = parentForm.FacadeGarage.DataSourceStreet;
			cboSubDistrict.DataSource = parentForm.FacadeGarage.DataSourceSubDistrict;
			cboDistrict.DataSource = parentForm.FacadeGarage.DataSourceDistrict;
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleMaintenanceGarage");

			if (cboStreet.Items.Count>0)
				cboStreet.SelectedIndex = -1;
			if (cboSubDistrict.Items.Count>0)
				cboSubDistrict.SelectedIndex = -1;
			if (cboDistrict.Items.Count>0)
				cboDistrict.SelectedIndex = -1;
		}

		//	============================== Private Method ================================
		#region - Validate Checking -
		private bool ValidateGarageKey()
		{
			return (txtGarageCode.Text != "");
		}	
		private bool ValidateForm()
		{
			if(ValidateGarageCode() && ValidateShortName() && ValidateTHName()
				&& ValidateENName() && ValidateAddress() && ValidateStreet() 
				&& ValidateSubDistrict() && ValidateDistrict() 
				&& ValidateProvince() && ValidatePostelCode()
				&& ValidateTelNo() )
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private bool ValidateGarageCode()
		{
			if(txtGarageCode.Text == "") 
			{
				Message(MessageList.Error.E0002, "รหัสศูนย์บริการ" );
				txtGarageCode.Focus();
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
				Message(MessageList.Error.E0002, "ชื่อย่อศูนย์บริการ" );
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
				Message(MessageList.Error.E0002, "ชื่อศูนย์บริการ (ภาษาไทย)" );
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
				Message(MessageList.Error.E0002, "ชื่อศูนย์บริการ (ภาษาอังกฤษ)" );
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
		
		#endregion - Validate Checking -
		
		private void enableKeyField(bool enable)
		{
			txtGarageCode.Enabled = enable;
		}

		private void clearForm()
		{
			txtGarageCode.Text = "";
			txtShortName.Text = "";
			txtENName.Text = "";
			txtTHName.Text = "";
			txtAddress.Text = "";
			fpiPostelCode.Value = 0;
			fpiPostelCode.Text = "";
			txtTelNo.Text = "";
			txtFaxNo.Text = "";
            txtBizExpenseCode.Text = "";
            txtBizVendor.Text = "";
            txtBizExpenseName.Text = "";
            txtSAPCode.Text = "";
			cboStreet.DataSource = parentForm.FacadeGarage.DataSourceStreet;
			cboSubDistrict.DataSource = parentForm.FacadeGarage.DataSourceSubDistrict;
			cboDistrict.DataSource = parentForm.FacadeGarage.DataSourceDistrict;
			cboProvince.DataSource = parentForm.FacadeGarage.DataSourceProvince;
			cboProvince.Text = "กรุงเทพมหานคร";
			cboStreet.SelectedIndex = -1;
			cboSubDistrict.SelectedIndex = -1;
    		cboDistrict.SelectedIndex = -1;
			txtGarageCode.Focus();
		}
					
		//============================== Public Method =================================
		private GarageFacade objGarageFacade;
		public GarageFacade ObjGarageFacade	
		{
			set	{objGarageFacade = value;}
		}				

		public void InitAddAction()	
		{
			this.title = "ศูนย์บริการ";
			baseADD();
			clearForm();
			enableKeyField(true);
		}

		public void InitEditAction(Garage aGarage)
		{
			this.title = "ศูนย์บริการ";
			baseEDIT();
			clearForm();
			enableKeyField(false);
			objGarage = aGarage;

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}

		public void GarageCodeFocus()
		{
			txtGarageCode.Focus();
		}

		public void GarageShortNameFocus()
		{
			txtShortName.Focus();
		}

		//============================== Base Event ====================================
		private void AddEvent()
		{
			try
			{
				if (ValidateForm() && parentForm.AddRow(getGarage()))
				{
					clearForm();
					GarageCodeFocus();
				}
			}	
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				txtGarageCode.Focus();
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
				if (ValidateForm() && parentForm.UpdateRow(getGarage()))
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

		//================================= Event =====================================		
		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
				{
					AddEvent();
					break;				
				}
				case ActionType.EDIT :
				{
					EditEvent();
					break;				
				}
			}		
		}
		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}
		private void frmGarageEntry_Load(object sender, System.EventArgs e)
		{
			if(action == ActionType.ADD)
			{
				clearForm();	
			}
			else
			{
				setGarage(objGarage);
			}
		}
	}
}
