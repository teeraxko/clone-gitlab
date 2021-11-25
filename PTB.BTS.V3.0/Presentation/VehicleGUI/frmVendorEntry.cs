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
	public class frmVendorEntry : EntryFormBase
	{
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

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtENName;
		private System.Windows.Forms.TextBox txtTHName;
		private System.Windows.Forms.TextBox txtVendorCode;
		private System.Windows.Forms.ComboBox cboSubDistrict;
		private System.Windows.Forms.ComboBox cboDistrict;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.ComboBox cboProvince;
		private System.Windows.Forms.TextBox txtTelNo;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.TextBox txtFaxNo1;
		private System.Windows.Forms.ComboBox cboStreet;
		private FarPoint.Win.Input.FpInteger fpiPostelCode;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox gpbVendor;
		private System.Windows.Forms.TextBox txtShortName;
		private System.Windows.Forms.GroupBox gpbAddress;
		private System.Windows.Forms.GroupBox gpbOther;

		private System.ComponentModel.Container components = null;		
		private void InitializeComponent()
		{
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.gpbVendor = new System.Windows.Forms.GroupBox();
			this.txtShortName = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtENName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTHName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtVendorCode = new System.Windows.Forms.TextBox();
			this.gpbAddress = new System.Windows.Forms.GroupBox();
			this.fpiPostelCode = new FarPoint.Win.Input.FpInteger();
			this.cboStreet = new System.Windows.Forms.ComboBox();
			this.cboProvince = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cboSubDistrict = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cboDistrict = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.gpbOther = new System.Windows.Forms.GroupBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtTelNo = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtFaxNo1 = new System.Windows.Forms.TextBox();
			this.gpbVendor.SuspendLayout();
			this.gpbAddress.SuspendLayout();
			this.gpbOther.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(355, 376);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 14;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(267, 376);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 13;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// gpbVendor
			// 
			this.gpbVendor.Controls.Add(this.txtShortName);
			this.gpbVendor.Controls.Add(this.label9);
			this.gpbVendor.Controls.Add(this.txtENName);
			this.gpbVendor.Controls.Add(this.label3);
			this.gpbVendor.Controls.Add(this.label4);
			this.gpbVendor.Controls.Add(this.txtTHName);
			this.gpbVendor.Controls.Add(this.label5);
			this.gpbVendor.Controls.Add(this.txtVendorCode);
			this.gpbVendor.Location = new System.Drawing.Point(16, 16);
			this.gpbVendor.Name = "gpbVendor";
			this.gpbVendor.Size = new System.Drawing.Size(664, 120);
			this.gpbVendor.TabIndex = 1;
			this.gpbVendor.TabStop = false;
			this.gpbVendor.Text = "ข้อมูลผู้จำหน่าย";
			// 
			// txtShortName
			// 
			this.txtShortName.Location = new System.Drawing.Point(416, 24);
			this.txtShortName.MaxLength = 20;
			this.txtShortName.Name = "txtShortName";
			this.txtShortName.Size = new System.Drawing.Size(232, 20);
			this.txtShortName.TabIndex = 2;
			this.txtShortName.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(336, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 23);
			this.label9.TabIndex = 5;
			this.label9.Text = "ชื่อย่อผู้จำหน่าย";
			// 
			// txtENName
			// 
			this.txtENName.Location = new System.Drawing.Point(160, 88);
			this.txtENName.MaxLength = 50;
			this.txtENName.Name = "txtENName";
			this.txtENName.Size = new System.Drawing.Size(488, 20);
			this.txtENName.TabIndex = 4;
			this.txtENName.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "ชื่อผู้จำหน่าย(ภาษาอังกฤษ)";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "รหัสผู้จำหน่าย";
			// 
			// txtTHName
			// 
			this.txtTHName.Location = new System.Drawing.Point(160, 56);
			this.txtTHName.MaxLength = 70;
			this.txtTHName.Name = "txtTHName";
			this.txtTHName.Size = new System.Drawing.Size(488, 20);
			this.txtTHName.TabIndex = 3;
			this.txtTHName.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 23);
			this.label5.TabIndex = 2;
			this.label5.Text = "ชื่อผู้จำหน่าย (ภาษาไทย)";
			// 
			// txtVendorCode
			// 
			this.txtVendorCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtVendorCode.Location = new System.Drawing.Point(160, 24);
			this.txtVendorCode.MaxLength = 5;
			this.txtVendorCode.Name = "txtVendorCode";
			this.txtVendorCode.Size = new System.Drawing.Size(80, 20);
			this.txtVendorCode.TabIndex = 1;
			this.txtVendorCode.Text = "";
			// 
			// gpbAddress
			// 
			this.gpbAddress.Controls.Add(this.fpiPostelCode);
			this.gpbAddress.Controls.Add(this.cboStreet);
			this.gpbAddress.Controls.Add(this.cboProvince);
			this.gpbAddress.Controls.Add(this.label8);
			this.gpbAddress.Controls.Add(this.cboSubDistrict);
			this.gpbAddress.Controls.Add(this.label7);
			this.gpbAddress.Controls.Add(this.cboDistrict);
			this.gpbAddress.Controls.Add(this.label6);
			this.gpbAddress.Controls.Add(this.label1);
			this.gpbAddress.Controls.Add(this.txtAddress);
			this.gpbAddress.Controls.Add(this.label2);
			this.gpbAddress.Controls.Add(this.label14);
			this.gpbAddress.Location = new System.Drawing.Point(16, 144);
			this.gpbAddress.Name = "gpbAddress";
			this.gpbAddress.Size = new System.Drawing.Size(664, 152);
			this.gpbAddress.TabIndex = 2;
			this.gpbAddress.TabStop = false;
			this.gpbAddress.Text = "ที่อยู่";
			// 
			// fpiPostelCode
			// 
			this.fpiPostelCode.AllowClipboardKeys = true;
			this.fpiPostelCode.AllowNull = true;
			this.fpiPostelCode.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiPostelCode.Location = new System.Drawing.Point(408, 120);
			this.fpiPostelCode.MaxValue = 99999;
			this.fpiPostelCode.MinValue = 0;
			this.fpiPostelCode.Name = "fpiPostelCode";
			this.fpiPostelCode.NullColor = System.Drawing.Color.Transparent;
			this.fpiPostelCode.Size = new System.Drawing.Size(72, 20);
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
			this.cboProvince.Name = "cboProvince";
			this.cboProvince.Size = new System.Drawing.Size(240, 21);
			this.cboProvince.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 120);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 23);
			this.label8.TabIndex = 9;
			this.label8.Text = "จังหวัด";
			// 
			// cboSubDistrict
			// 
			this.cboSubDistrict.Location = new System.Drawing.Point(80, 88);
			this.cboSubDistrict.Name = "cboSubDistrict";
			this.cboSubDistrict.Size = new System.Drawing.Size(240, 21);
			this.cboSubDistrict.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(376, 88);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(24, 23);
			this.label7.TabIndex = 7;
			this.label7.Text = "เขต";
			// 
			// cboDistrict
			// 
			this.cboDistrict.Location = new System.Drawing.Point(408, 88);
			this.cboDistrict.Name = "cboDistrict";
			this.cboDistrict.Size = new System.Drawing.Size(240, 21);
			this.cboDistrict.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 23);
			this.label6.TabIndex = 5;
			this.label6.Text = "แขวง";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "ถนน";
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(80, 24);
			this.txtAddress.MaxLength = 50;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(568, 20);
			this.txtAddress.TabIndex = 5;
			this.txtAddress.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "ที่อยู่";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(336, 120);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(72, 23);
			this.label14.TabIndex = 0;
			this.label14.Text = "รหัสไปรษณีย์";
			// 
			// gpbOther
			// 
			this.gpbOther.Controls.Add(this.label16);
			this.gpbOther.Controls.Add(this.txtTelNo);
			this.gpbOther.Controls.Add(this.label15);
			this.gpbOther.Controls.Add(this.txtFaxNo1);
			this.gpbOther.Location = new System.Drawing.Point(16, 304);
			this.gpbOther.Name = "gpbOther";
			this.gpbOther.Size = new System.Drawing.Size(664, 56);
			this.gpbOther.TabIndex = 3;
			this.gpbOther.TabStop = false;
			this.gpbOther.Text = "อื่น ๆ";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(360, 24);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(40, 23);
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
			this.txtTelNo.Text = "";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(16, 24);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(64, 23);
			this.label15.TabIndex = 1;
			this.label15.Text = "โทรศัพท์";
			// 
			// txtFaxNo1
			// 
			this.txtFaxNo1.Location = new System.Drawing.Point(408, 24);
			this.txtFaxNo1.MaxLength = 50;
			this.txtFaxNo1.Name = "txtFaxNo1";
			this.txtFaxNo1.Size = new System.Drawing.Size(240, 20);
			this.txtFaxNo1.TabIndex = 12;
			this.txtFaxNo1.Text = "";
			// 
			// frmVendorEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(696, 412);
			this.Controls.Add(this.gpbOther);
			this.Controls.Add(this.gpbAddress);
			this.Controls.Add(this.gpbVendor);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "frmVendorEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmVendorEntry_Load);
			this.gpbVendor.ResumeLayout(false);
			this.gpbAddress.ResumeLayout(false);
			this.gpbOther.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmVendor parentForm;
		private Vendor objVendor;
		#endregion - Private -

		//  ===================================== Property ===============================
		public Vendor getVendor()
		{
			objVendor = new Vendor();
			objVendor.Code = txtVendorCode.Text;
			objVendor.ShortName = txtShortName.Text;
			objVendor.ADescription.Thai = txtTHName.Text;
			objVendor.ADescription.English = txtENName.Text;
			objVendor.ACurrentAddress.AddressLine = txtAddress.Text;
			objVendor.ACurrentAddress.StreetName.Name = cboStreet.Text;
			objVendor.ACurrentAddress.Tambon.Name = cboSubDistrict.Text;
			objVendor.ACurrentAddress.District.Name = cboDistrict.Text;
			objVendor.ACurrentAddress.Province.Name = cboProvince.Text;
			objVendor.ACurrentAddress.PostalCode = fpiPostelCode.Text;
			objVendor.ACurrentAddress.AContactInfo.Telephone = txtTelNo.Text;
			objVendor.ACurrentAddress.AContactInfo.Fax = txtFaxNo1.Text;

			return objVendor;
		}
		public void setVendor(Vendor value)
		{
			objVendor = value;
			txtVendorCode.Text = value.Code;
			txtShortName.Text = value.ShortName;
			txtENName.Text = value.ADescription.English;
			txtTHName.Text = value.ADescription.Thai;
			txtAddress.Text = value.ACurrentAddress.AddressLine;
			cboStreet.Text = value.ACurrentAddress.StreetName.Name;
			cboSubDistrict.Text = value.ACurrentAddress.Tambon.Name;
			cboDistrict.Text = value.ACurrentAddress.District.Name;
			cboProvince.Text = value.ACurrentAddress.Province.Name;
			fpiPostelCode.Text = value.ACurrentAddress.PostalCode;
			txtTelNo.Text = value.ACurrentAddress.AContactInfo.Telephone;
			txtFaxNo1.Text = value.ACurrentAddress.AContactInfo.Fax;

		}
		//  ===================================== Constructor ============================
		public frmVendorEntry(frmVendor parentForm):base()
		{
			InitializeComponent();						
			this.parentForm = parentForm;	
			CTFunction ctFunction = new CTFunction();		
			cboProvince.DataSource = parentForm.FacadeVendor.DataSourceProvince;
			cboProvince.Text = "กรุงเทพมหานคร";
			cboStreet.DataSource = parentForm.FacadeVendor.DataSourceStreet;
			cboSubDistrict.DataSource = parentForm.FacadeVendor.DataSourceSubDistrict;
			cboDistrict.DataSource = parentForm.FacadeVendor.DataSourceDistrict;
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleVehicleVendor");
				
			if (cboStreet.Items.Count>0)
				cboStreet.SelectedIndex = -1;
			if (cboSubDistrict.Items.Count>0)
				cboSubDistrict.SelectedIndex = -1;
			if (cboDistrict.Items.Count>0)
				cboDistrict.SelectedIndex = -1;
		}

		//	============================== Private Method ================================
		#region - Validate Checking -
		private bool ValidateVendorKey()
		{
			return (txtVendorCode.Text != "");
		}	
		private bool ValidateForm()
		{
			if(ValidateVendorCode() && ValidateShortName() && ValidateTHName()
				&& ValidateENName() && ValidateAddress() && ValidateStreet() 
				&& ValidateSubDistrict() && ValidateDistrict() 
				&& ValidateProvince()&& ValidatePostelCode()
				&& ValidateTelNo() )
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private bool ValidateVendorCode()
		{
			if(txtVendorCode.Text == "") 
			{
				Message(MessageList.Error.E0002, "รหัสผู้จำหน่าย" );
				txtVendorCode.Focus();
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
				Message(MessageList.Error.E0002, "ชื่อย่อผู้จำหน่าย" );
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
				Message(MessageList.Error.E0002, "ชื่อผู้จำหน่าย (ภาษาไทย)" );
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
				Message(MessageList.Error.E0002, "ชื่อผู้จำหน่าย (ภาษาอังกฤษ)" );
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
			txtVendorCode.Enabled = enable;
		}

		private void clearForm()
		{
			txtVendorCode.Text = "";
			txtShortName.Text = "";
			txtENName.Text = "";
			txtTHName.Text = "";
			txtAddress.Text = "";
			fpiPostelCode.Text = "";
			txtTelNo.Text = "";
			txtFaxNo1.Text = "";
			cboStreet.DataSource = parentForm.FacadeVendor.DataSourceStreet;
			cboSubDistrict.DataSource = parentForm.FacadeVendor.DataSourceSubDistrict;
			cboDistrict.DataSource = parentForm.FacadeVendor.DataSourceDistrict;
			cboProvince.DataSource = parentForm.FacadeVendor.DataSourceProvince;
			cboProvince.Text = "กรุงเทพมหานคร";
			cboStreet.SelectedIndex = -1;
			cboSubDistrict.SelectedIndex = -1;
			cboDistrict.SelectedIndex = -1;
		}
					
		//============================== Public Method =================================
		private VendorFacade objVendorFacade;
		public VendorFacade ObjVendorFacade	
		{
			set	{objVendorFacade = value;}
		}				
		public void InitAddAction()	
		{
			this.title = "ผู้จำหน่าย";
			baseADD();
			clearForm();
			enableKeyField(true);
		}
		public void InitEditAction(Vendor aVendor)
		{
			this.title = "ผู้จำหน่าย";
			baseEDIT();
			clearForm();
			enableKeyField(false);
			objVendor = aVendor;
		}
		public void VendorCodeFocus()
		{
			txtVendorCode.Focus();
		}
		public void VendorShortNameFocus()
		{
			txtShortName.Focus();
		}

		//============================== Base Event ====================================
		private void AddEvent()
		{
			try
			{
				if (ValidateForm() && parentForm.AddRow(getVendor()))
				{
					clearForm();
					VendorCodeFocus();
				}
			}	
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				txtVendorCode.Focus();
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
				if (ValidateForm() && parentForm.UpdateRow(getVendor()))
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
				
				
		//================================= Event ================================
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
		private void frmVendorEntry_Load(object sender, System.EventArgs e)
		{
			if(action == ActionType.ADD)
			{
				clearForm();	
				VendorCodeFocus();
			}
			else
			{
				setVendor(objVendor);
				VendorShortNameFocus();
			}
		}

	}
}
