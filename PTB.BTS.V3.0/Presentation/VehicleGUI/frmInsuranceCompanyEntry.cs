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
	public class frmInsuranceCompanyEntry : EntryFormBase
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
		private System.Windows.Forms.TextBox txtENName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTHName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox txtFaxNo;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cboStreet;
		private System.Windows.Forms.ComboBox cboProvince;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cboSubDistrict;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cboDistrict;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtInsuranceCompCode;
		private System.Windows.Forms.RichTextBox rchTelNo;
		private FarPoint.Win.Input.FpInteger fpiPostelCode;
		
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtENName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTHName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInsuranceCompCode = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rchTelNo = new System.Windows.Forms.RichTextBox();
            this.txtFaxNo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
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
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtENName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTHName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtInsuranceCompCode);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 128);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลบริษัทประกันภัย";
            // 
            // txtENName
            // 
            this.txtENName.Location = new System.Drawing.Point(184, 88);
            this.txtENName.MaxLength = 200;
            this.txtENName.Name = "txtENName";
            this.txtENName.Size = new System.Drawing.Size(464, 20);
            this.txtENName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "ชื่อบริษัทประกันภัย  (ภาษาอังกฤษ)";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสบริษัทประกันภัย";
            // 
            // txtTHName
            // 
            this.txtTHName.Location = new System.Drawing.Point(184, 56);
            this.txtTHName.MaxLength = 200;
            this.txtTHName.Name = "txtTHName";
            this.txtTHName.Size = new System.Drawing.Size(464, 20);
            this.txtTHName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "ชื่อบริษัทประกันภัย  (ภาษาไทย)";
            // 
            // txtInsuranceCompCode
            // 
            this.txtInsuranceCompCode.Location = new System.Drawing.Point(184, 24);
            this.txtInsuranceCompCode.MaxLength = 6;
            this.txtInsuranceCompCode.Name = "txtInsuranceCompCode";
            this.txtInsuranceCompCode.Size = new System.Drawing.Size(80, 20);
            this.txtInsuranceCompCode.TabIndex = 1;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(352, 440);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rchTelNo);
            this.groupBox4.Controls.Add(this.txtFaxNo);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Location = new System.Drawing.Point(16, 288);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(664, 144);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "อื่น ๆ";
            // 
            // rchTelNo
            // 
            this.rchTelNo.Location = new System.Drawing.Point(80, 24);
            this.rchTelNo.Name = "rchTelNo";
            this.rchTelNo.Size = new System.Drawing.Size(264, 104);
            this.rchTelNo.TabIndex = 10;
            this.rchTelNo.Text = "";
            // 
            // txtFaxNo
            // 
            this.txtFaxNo.Location = new System.Drawing.Point(408, 24);
            this.txtFaxNo.MaxLength = 50;
            this.txtFaxNo.Name = "txtFaxNo";
            this.txtFaxNo.Size = new System.Drawing.Size(240, 20);
            this.txtFaxNo.TabIndex = 11;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(360, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 23);
            this.label16.TabIndex = 4;
            this.label16.Text = "แฟกซ์";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(16, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 23);
            this.label15.TabIndex = 1;
            this.label15.Text = "โทรศัพท์";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(272, 440);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(16, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(664, 152);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ที่อยู่";
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
            this.fpiPostelCode.Size = new System.Drawing.Size(88, 20);
            this.fpiPostelCode.TabIndex = 9;
            this.fpiPostelCode.Text = "";
            // 
            // cboStreet
            // 
            this.cboStreet.Location = new System.Drawing.Point(80, 56);
            this.cboStreet.MaxLength = 30;
            this.cboStreet.Name = "cboStreet";
            this.cboStreet.Size = new System.Drawing.Size(240, 21);
            this.cboStreet.TabIndex = 5;
            // 
            // cboProvince
            // 
            this.cboProvince.Location = new System.Drawing.Point(80, 120);
            this.cboProvince.MaxLength = 30;
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(240, 21);
            this.cboProvince.TabIndex = 8;
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
            this.cboSubDistrict.MaxLength = 30;
            this.cboSubDistrict.Name = "cboSubDistrict";
            this.cboSubDistrict.Size = new System.Drawing.Size(240, 21);
            this.cboSubDistrict.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(360, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "เขต";
            // 
            // cboDistrict
            // 
            this.cboDistrict.Location = new System.Drawing.Point(408, 88);
            this.cboDistrict.MaxLength = 30;
            this.cboDistrict.Name = "cboDistrict";
            this.cboDistrict.Size = new System.Drawing.Size(240, 21);
            this.cboDistrict.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "แขวง";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "ถนน";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(80, 24);
            this.txtAddress.MaxLength = 150;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(568, 20);
            this.txtAddress.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "ที่อยู่";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(336, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 23);
            this.label14.TabIndex = 0;
            this.label14.Text = "รหัสไปรษณีย์";
            // 
            // frmInsuranceCompanyEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(696, 472);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox2);
            this.MinimizeBox = false;
            this.Name = "frmInsuranceCompanyEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmInsuranceCompanyEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmInsuranceCompany parentForm;
		private InsuranceCompany objInsuranceCompany;
		#endregion - Private -

		//  ===================================== Property ===============================
		public InsuranceCompany getInsuranceCompany()
		{
			objInsuranceCompany = new InsuranceCompany();
			objInsuranceCompany.Code = txtInsuranceCompCode.Text;
			objInsuranceCompany.AName.Thai = txtTHName.Text;
			objInsuranceCompany.AName.English = txtENName.Text;
			objInsuranceCompany.AAddress.AddressLine = txtAddress.Text;
			objInsuranceCompany.AAddress.StreetName.Name = cboStreet.Text;
			objInsuranceCompany.AAddress.Tambon.Name = cboSubDistrict.Text;
			objInsuranceCompany.AAddress.District.Name = cboDistrict.Text;
			objInsuranceCompany.AAddress.Province.Name = cboProvince.Text;
			objInsuranceCompany.AAddress.PostalCode = fpiPostelCode.Text;
			objInsuranceCompany.AAddress.AContactInfo.Telephone = rchTelNo.Text;
			objInsuranceCompany.AAddress.AContactInfo.Fax = txtFaxNo.Text;

			return objInsuranceCompany;
		}
		public void setInsuranceCompany(InsuranceCompany value)
		{
			objInsuranceCompany = value;
			txtInsuranceCompCode.Text = value.Code;
			txtENName.Text = value.AName.English;
			txtTHName.Text = value.AName.Thai;
			txtAddress.Text = value.AAddress.AddressLine;
			cboStreet.Text = value.AAddress.StreetName.Name;
			cboSubDistrict.Text = value.AAddress.Tambon.Name;
			cboDistrict.Text = value.AAddress.District.Name;
			cboProvince.Text = value.AAddress.Province.Name;
			fpiPostelCode.Text = value.AAddress.PostalCode;
			rchTelNo.Text = value.AAddress.AContactInfo.Telephone;
			txtFaxNo.Text = value.AAddress.AContactInfo.Fax;

		}
		//  ===================================== Constructor ============================
		public frmInsuranceCompanyEntry(frmInsuranceCompany parentForm):base()
		{
			InitializeComponent();						
			this.parentForm = parentForm;	
			CTFunction ctFunction = new CTFunction();		
			cboProvince.DataSource = parentForm.FacadeInsuranceCompany.DataSourceProvince;
			cboProvince.Text = "กรุงเทพมหานคร";
			cboStreet.DataSource = parentForm.FacadeInsuranceCompany.DataSourceStreet;
			cboSubDistrict.DataSource = parentForm.FacadeInsuranceCompany.DataSourceSubDistrict;
			cboDistrict.DataSource = parentForm.FacadeInsuranceCompany.DataSourceDistrict;
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentInsurance");
				
			if (cboStreet.Items.Count>0)
				cboStreet.SelectedIndex = -1;
			if (cboSubDistrict.Items.Count>0)
				cboSubDistrict.SelectedIndex = -1;
			if (cboDistrict.Items.Count>0)
				cboDistrict.SelectedIndex = -1;
		}
		//	============================== Private Method ================================
		#region - Validate Checking -
		private bool ValidateInsuranceCompanyKey()
		{
			return (txtInsuranceCompCode.Text != "");
		}	
		private bool ValidateForm()
		{
			if(ValidateInsuranceCompanyCode() && ValidateTHName()
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
		private bool ValidateInsuranceCompanyCode()
		{
			if(txtInsuranceCompCode.Text == "") 
			{
				Message(MessageList.Error.E0002, "รหัสบริษัทประกันภัย" );
				txtInsuranceCompCode.Focus();
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
				Message(MessageList.Error.E0002, "ชื่อบริษัทประกันภัย (ภาษาไทย)" );
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
				Message(MessageList.Error.E0002, "ชื่อบริษัทประกันภัย (ภาษาอังกฤษ)" );
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
			if(rchTelNo.Text == "") 
			{
				Message(MessageList.Error.E0002, "หมายเลขโทรศัพท์" );
				rchTelNo.Focus();
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
			txtInsuranceCompCode.Enabled = enable;
		}

		private void clearForm()
		{
			txtInsuranceCompCode.Text = "";
			txtENName.Text = "";
			txtTHName.Text = "";
			txtAddress.Text = "";
			fpiPostelCode.Text = "";
			rchTelNo.Text = "";
			txtFaxNo.Text = "";
			cboStreet.DataSource = parentForm.FacadeInsuranceCompany.DataSourceStreet;
			cboSubDistrict.DataSource = parentForm.FacadeInsuranceCompany.DataSourceSubDistrict;
			cboDistrict.DataSource = parentForm.FacadeInsuranceCompany.DataSourceDistrict;
			cboProvince.DataSource = parentForm.FacadeInsuranceCompany.DataSourceProvince;
			cboProvince.Text = "กรุงเทพมหานคร";
			cboStreet.SelectedIndex = -1;
			cboSubDistrict.SelectedIndex = -1;
			cboDistrict.SelectedIndex = -1;
		}
					
		//============================== Public Method =================================
		private InsuranceCompanyFacade objInsuranceCompanyFacade;
		public InsuranceCompanyFacade ObjInsuranceCompanyFacade	
		{
			set	{objInsuranceCompanyFacade = value;}
		}				
		public void InitAddAction()	
		{
			this.title = "บริษัทประกันภัย";
			baseADD();
			clearForm();
			enableKeyField(true);
		}
		public void InitEditAction(InsuranceCompany aInsuranceCompany)
		{
			this.title = "บริษัทประกันภัย";
			baseEDIT();
			clearForm();
			enableKeyField(false);
			objInsuranceCompany = aInsuranceCompany;
			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}
		public void InsuranceCompanyCodeFocus()
		{
			txtInsuranceCompCode.Focus();
		}
		public void InsuranceCompanyTHNameFocus()
		{
			txtTHName.Focus();
		}

		//============================== Base Event ====================================
		private void AddEvent()
		{
			try
			{
				if (ValidateForm() && parentForm.AddRow(getInsuranceCompany()))
				{
					clearForm();
					InsuranceCompanyCodeFocus();
				}
			}	
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				txtInsuranceCompCode.Focus();
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
				if (ValidateForm() && parentForm.UpdateRow(getInsuranceCompany()))
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
			this.Close();
		}
		private void frmInsuranceCompanyEntry_Load(object sender, System.EventArgs e)
		{
			if(action == ActionType.ADD)
			{
				clearForm();	
			}
			else
			{
				setInsuranceCompany(objInsuranceCompany);
			}
		
		}
	}
}
