using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Entity.CommonEntity;

using Facade.CommonFacade;

namespace Presentation.PiGUI.UserControl
{
	public class UCTAddress : System.Windows.Forms.UserControl
	{
		public UCTAddress()
		{
			InitializeComponent();

		}
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

		#region Component Designer generated code

		private System.Windows.Forms.Label label129;
		public System.Windows.Forms.ComboBox cboStreet;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.Label label104;
		public System.Windows.Forms.ComboBox cboProvince;
		public System.Windows.Forms.ComboBox cboDistrict;
		public System.Windows.Forms.ComboBox cboSubDistrict;
		private System.Windows.Forms.Label label106;
		private System.Windows.Forms.Label label107;
		private System.Windows.Forms.Label label108;
		private System.Windows.Forms.TextBox txtTelNo;
		private System.Windows.Forms.Label label110;
		private System.Windows.Forms.Label label111;
		private System.Windows.Forms.Label label112;
		private System.Windows.Forms.TextBox txtFaxNo;
		private FarPoint.Win.Input.FpInteger fpiPostalCode;
		private System.Windows.Forms.TextBox txtMobileNo;
		private System.Windows.Forms.Label lblMobile;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.label129 = new System.Windows.Forms.Label();
			this.cboStreet = new System.Windows.Forms.ComboBox();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.label104 = new System.Windows.Forms.Label();
			this.cboProvince = new System.Windows.Forms.ComboBox();
			this.cboDistrict = new System.Windows.Forms.ComboBox();
			this.cboSubDistrict = new System.Windows.Forms.ComboBox();
			this.label106 = new System.Windows.Forms.Label();
			this.label107 = new System.Windows.Forms.Label();
			this.label108 = new System.Windows.Forms.Label();
			this.txtTelNo = new System.Windows.Forms.TextBox();
			this.label110 = new System.Windows.Forms.Label();
			this.fpiPostalCode = new FarPoint.Win.Input.FpInteger();
			this.label111 = new System.Windows.Forms.Label();
			this.label112 = new System.Windows.Forms.Label();
			this.txtFaxNo = new System.Windows.Forms.TextBox();
			this.txtMobileNo = new System.Windows.Forms.TextBox();
			this.lblMobile = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label129
			// 
			this.label129.AutoSize = true;
			this.label129.Location = new System.Drawing.Point(376, 10);
			this.label129.Name = "label129";
			this.label129.Size = new System.Drawing.Size(24, 16);
			this.label129.TabIndex = 75;
			this.label129.Text = "ถนน";
			this.label129.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboStreet
			// 
			this.cboStreet.Location = new System.Drawing.Point(408, 8);
			this.cboStreet.MaxLength = 30;
			this.cboStreet.Name = "cboStreet";
			this.cboStreet.Size = new System.Drawing.Size(136, 21);
			this.cboStreet.TabIndex = 2;
			this.cboStreet.TextChanged += new System.EventHandler(this.cboStreet_TextChanged);
			this.cboStreet.SelectedIndexChanged += new System.EventHandler(this.cboStreet_SelectedIndexChanged);
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(56, 8);
			this.txtAddress.MaxLength = 50;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(280, 20);
			this.txtAddress.TabIndex = 1;
			this.txtAddress.Text = "";
			this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
			// 
			// label104
			// 
			this.label104.AutoSize = true;
			this.label104.Location = new System.Drawing.Point(24, 10);
			this.label104.Name = "label104";
			this.label104.Size = new System.Drawing.Size(22, 16);
			this.label104.TabIndex = 49;
			this.label104.Text = "ที่อยู่";
			this.label104.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboProvince
			// 
			this.cboProvince.Location = new System.Drawing.Point(56, 40);
			this.cboProvince.MaxLength = 30;
			this.cboProvince.Name = "cboProvince";
			this.cboProvince.Size = new System.Drawing.Size(136, 21);
			this.cboProvince.TabIndex = 5;
			this.cboProvince.TextChanged += new System.EventHandler(this.cboProvince_TextChanged);
			this.cboProvince.SelectedIndexChanged += new System.EventHandler(this.cboProvince_SelectedIndexChanged);
			// 
			// cboDistrict
			// 
			this.cboDistrict.Location = new System.Drawing.Point(784, 8);
			this.cboDistrict.MaxLength = 30;
			this.cboDistrict.Name = "cboDistrict";
			this.cboDistrict.Size = new System.Drawing.Size(128, 21);
			this.cboDistrict.TabIndex = 4;
			this.cboDistrict.TextChanged += new System.EventHandler(this.cboDistrict_TextChanged);
			this.cboDistrict.SelectedIndexChanged += new System.EventHandler(this.cboDistrict_SelectedIndexChanged);
			// 
			// cboSubDistrict
			// 
			this.cboSubDistrict.Location = new System.Drawing.Point(600, 8);
			this.cboSubDistrict.MaxLength = 30;
			this.cboSubDistrict.Name = "cboSubDistrict";
			this.cboSubDistrict.Size = new System.Drawing.Size(136, 21);
			this.cboSubDistrict.TabIndex = 3;
			this.cboSubDistrict.TextChanged += new System.EventHandler(this.cboSubDistrict_TextChanged);
			this.cboSubDistrict.SelectedIndexChanged += new System.EventHandler(this.cboSubDistrict_SelectedIndexChanged);
			// 
			// label106
			// 
			this.label106.AutoSize = true;
			this.label106.Location = new System.Drawing.Point(562, 10);
			this.label106.Name = "label106";
			this.label106.Size = new System.Drawing.Size(27, 16);
			this.label106.TabIndex = 53;
			this.label106.Text = "แขวง";
			this.label106.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label107
			// 
			this.label107.AutoSize = true;
			this.label107.Location = new System.Drawing.Point(753, 10);
			this.label107.Name = "label107";
			this.label107.Size = new System.Drawing.Size(20, 16);
			this.label107.TabIndex = 52;
			this.label107.Text = "เขต";
			this.label107.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label108
			// 
			this.label108.AutoSize = true;
			this.label108.Location = new System.Drawing.Point(16, 42);
			this.label108.Name = "label108";
			this.label108.Size = new System.Drawing.Size(33, 16);
			this.label108.TabIndex = 51;
			this.label108.Text = "จังหวัด";
			this.label108.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTelNo
			// 
			this.txtTelNo.Location = new System.Drawing.Point(408, 40);
			this.txtTelNo.MaxLength = 50;
			this.txtTelNo.Name = "txtTelNo";
			this.txtTelNo.Size = new System.Drawing.Size(104, 20);
			this.txtTelNo.TabIndex = 7;
			this.txtTelNo.Text = "";
			this.txtTelNo.TextChanged += new System.EventHandler(this.txtTelNo_TextChanged);
			// 
			// label110
			// 
			this.label110.AutoSize = true;
			this.label110.Location = new System.Drawing.Point(360, 40);
			this.label110.Name = "label110";
			this.label110.Size = new System.Drawing.Size(41, 16);
			this.label110.TabIndex = 59;
			this.label110.Text = "โทรศัพท์";
			this.label110.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// fpiPostalCode
			// 
			this.fpiPostalCode.AllowClipboardKeys = true;
			this.fpiPostalCode.AllowNull = true;
			this.fpiPostalCode.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiPostalCode.Location = new System.Drawing.Point(272, 40);
			this.fpiPostalCode.MaxValue = 99999;
			this.fpiPostalCode.MinValue = 0;
			this.fpiPostalCode.Name = "fpiPostalCode";
			this.fpiPostalCode.NullColor = System.Drawing.SystemColors.ControlLightLight;
			this.fpiPostalCode.Size = new System.Drawing.Size(72, 20);
			this.fpiPostalCode.TabIndex = 6;
			this.fpiPostalCode.Text = "";
			this.fpiPostalCode.TextChanged += new System.EventHandler(this.fpiPostalCode_TextChanged);
			// 
			// label111
			// 
			this.label111.AutoSize = true;
			this.label111.Location = new System.Drawing.Point(552, 40);
			this.label111.Name = "label111";
			this.label111.Size = new System.Drawing.Size(37, 16);
			this.label111.TabIndex = 67;
			this.label111.Text = "โทรสาร";
			this.label111.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label112
			// 
			this.label112.AutoSize = true;
			this.label112.Location = new System.Drawing.Point(208, 42);
			this.label112.Name = "label112";
			this.label112.Size = new System.Drawing.Size(62, 16);
			this.label112.TabIndex = 54;
			this.label112.Text = "รหัสไปรษณีย์";
			this.label112.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtFaxNo
			// 
			this.txtFaxNo.Location = new System.Drawing.Point(600, 40);
			this.txtFaxNo.MaxLength = 50;
			this.txtFaxNo.Name = "txtFaxNo";
			this.txtFaxNo.Size = new System.Drawing.Size(104, 20);
			this.txtFaxNo.TabIndex = 8;
			this.txtFaxNo.Text = "";
			this.txtFaxNo.TextChanged += new System.EventHandler(this.txtFaxNo_TextChanged);
			// 
			// txtMobileNo
			// 
			this.txtMobileNo.Location = new System.Drawing.Point(784, 40);
			this.txtMobileNo.MaxLength = 50;
			this.txtMobileNo.Name = "txtMobileNo";
			this.txtMobileNo.Size = new System.Drawing.Size(104, 20);
			this.txtMobileNo.TabIndex = 76;
			this.txtMobileNo.Text = "";
			this.txtMobileNo.Visible = false;
			this.txtMobileNo.TextChanged += new System.EventHandler(this.txtMobileNo_TextChanged);
			// 
			// lblMobile
			// 
			this.lblMobile.AutoSize = true;
			this.lblMobile.Location = new System.Drawing.Point(744, 42);
			this.lblMobile.Name = "lblMobile";
			this.lblMobile.Size = new System.Drawing.Size(29, 16);
			this.lblMobile.TabIndex = 77;
			this.lblMobile.Text = "มือถือ";
			this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblMobile.Visible = false;
			// 
			// UCTAddress
			// 
			this.Controls.Add(this.txtMobileNo);
			this.Controls.Add(this.lblMobile);
			this.Controls.Add(this.cboStreet);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.label104);
			this.Controls.Add(this.cboProvince);
			this.Controls.Add(this.cboDistrict);
			this.Controls.Add(this.cboSubDistrict);
			this.Controls.Add(this.label106);
			this.Controls.Add(this.label107);
			this.Controls.Add(this.label108);
			this.Controls.Add(this.txtTelNo);
			this.Controls.Add(this.label110);
			this.Controls.Add(this.fpiPostalCode);
			this.Controls.Add(this.label111);
			this.Controls.Add(this.label112);
			this.Controls.Add(this.txtFaxNo);
			this.Controls.Add(this.label129);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.Name = "UCTAddress";
			this.Size = new System.Drawing.Size(920, 72);
			this.Load += new System.EventHandler(this.UCTAddress_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void UCTAddress_Load(object sender, System.EventArgs e)
		{
		
		}

		//   ================================ Property =====================
		private bool addressChange = false;
		public string AddressLine
		{
			get
			{return txtAddress.Text;}
			set
			{txtAddress.Text = value;}
		}

		private bool streetChange = false;
		public string Street
		{
			get{return cboStreet.Text;}
			set{cboStreet.Text = value;}
		}
		public ArrayList StreetDatasource
		{
			set
			{
				setDataSource(cboStreet, value);
			}
		}

		private bool subDistrictChange = false;
		public string SubDistrict
		{
			get{return cboSubDistrict.Text;}
			set{cboSubDistrict.Text = value;}
		}

		public ArrayList SubDistrictDatasource
		{
			set
			{
				setDataSource(cboSubDistrict, value);
			}
		}

		private bool districtChange = false;
		public string District
		{
			get{return cboDistrict.Text;}
			set{cboDistrict.Text = value;}
		}
		public ArrayList DistrictDatasource
		{
			set
			{
				setDataSource(cboDistrict, value);
			}
		}

		private bool provinceChange = false;
		public string Province
		{
			get{return cboProvince.Text;}
			set{cboProvince.Text = value;}
		}
		public ArrayList ProvinceDatasource
		{
			set
			{
				setDataSource(cboProvince, value);
			}
		}

		private bool postalCodeChange = false;
		public string PostalCode
		{
			get{return fpiPostalCode.Text;}
			set{fpiPostalCode.Text = value;}
		}

		private bool telephoneChange = false;
		public string Telephone
		{
			get{return txtTelNo.Text;}
			set{txtTelNo.Text = value;}
		}

		private bool mobileChange = false;
		public string Mobile
		{
			get{return txtMobileNo.Text;}
			set{txtMobileNo.Text = value;}
		}

		private bool faxNoChange = false;
		public string FaxNo
		{
			get{return txtFaxNo.Text;}
			set{txtFaxNo.Text = value;}
		}

        /// <summary>
        /// Set value to show mobile text on screen
        /// </summary>
		public bool HasMobile
		{
			set
			{
				lblMobile.Visible = value;
				txtMobileNo.Visible = value;
			}
		}

		private void setDataSource(ComboBox control, ArrayList dataSource)
		{
			control.Items.Clear();
			for(int i=0; i<dataSource.Count; i++)
			{
				control.Items.Add(dataSource[i]);
			}
		}

		public void Clear()
		{
			cboStreet.SelectedIndex = -1;
			cboDistrict.SelectedIndex = -1;
			cboProvince.SelectedIndex = -1;
			cboSubDistrict.SelectedIndex = -1;
			cboStreet.Text = "";
			cboDistrict.Text = "";
			cboProvince.Text = "";
			cboSubDistrict.Text = "";
			txtAddress.Text = "";
			txtFaxNo.Text = "";
			txtTelNo.Text = "";
			txtMobileNo.Text = "";
			fpiPostalCode.Text = "";
		}

		public void SetChangeAll(bool value)
		{
			addressChange = value;
			streetChange = value;
			subDistrictChange  =value;
			districtChange  = value;
			provinceChange = value;
			postalCodeChange = value;
			telephoneChange = value;
			mobileChange = value;
			faxNoChange =  value;
		}

		public bool HasChangeAddress()
		{
			return addressChange || streetChange || subDistrictChange ||districtChange || provinceChange ||postalCodeChange || telephoneChange || mobileChange ||faxNoChange;
		}

		private void txtAddress_TextChanged(object sender, System.EventArgs e)
		{
			addressChange = true;
		}

		private void cboStreet_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			streetChange = true;
		}

		private void cboSubDistrict_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			subDistrictChange  =true;
		}

		private void cboDistrict_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			districtChange  = true;
		}

		private void cboProvince_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			provinceChange = true;
		}

		private void txtTelNo_TextChanged(object sender, System.EventArgs e)
		{
			telephoneChange = true;
		}

		private void txtFaxNo_TextChanged(object sender, System.EventArgs e)
		{
			faxNoChange =  true;
		}

		private void fpiPostalCode_TextChanged(object sender, System.EventArgs e)
		{
			postalCodeChange = true;
		}

		private void cboStreet_TextChanged(object sender, System.EventArgs e)
		{
			streetChange = true;
		}

		private void cboSubDistrict_TextChanged(object sender, System.EventArgs e)
		{
			subDistrictChange  =true;
		}

		private void cboDistrict_TextChanged(object sender, System.EventArgs e)
		{
			districtChange = true;
		}

		private void cboProvince_TextChanged(object sender, System.EventArgs e)
		{
			provinceChange = true;
		}

		private void txtMobileNo_TextChanged(object sender, System.EventArgs e)
		{
			mobileChange = true;
		}

	}
}
