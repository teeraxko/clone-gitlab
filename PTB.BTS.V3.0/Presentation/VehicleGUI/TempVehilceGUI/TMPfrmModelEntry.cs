using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using Facade.CommonFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class TMPfrmModelEntry : EntryFormBase
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
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.TextBox txtModelCode;
		private System.Windows.Forms.TextBox txtThaiModelName;
		private System.Windows.Forms.TextBox txtBrandName;
		private System.Windows.Forms.ComboBox cboBreakType;
		private System.Windows.Forms.TextBox txtEngModelName;
		private System.Windows.Forms.ComboBox cboGearType;
		private System.Windows.Forms.ComboBox cboGasolineType;
		private System.Windows.Forms.TextBox txtBrandCode;
		private FarPoint.Win.Input.FpInteger txtEngineCC;
		private FarPoint.Win.Input.FpInteger txtNoOfSeat;
		private System.Windows.Forms.ComboBox cboModelType;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtModelCode = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtThaiModelName = new System.Windows.Forms.TextBox();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtBrandName = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboBreakType = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtEngModelName = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cboModelType = new System.Windows.Forms.ComboBox();
			this.cboGearType = new System.Windows.Forms.ComboBox();
			this.cboGasolineType = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtBrandCode = new System.Windows.Forms.TextBox();
			this.txtEngineCC = new FarPoint.Win.Input.FpInteger();
			this.txtNoOfSeat = new FarPoint.Win.Input.FpInteger();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "รหัสรุ่น";
			// 
			// txtModelCode
			// 
			this.txtModelCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtModelCode.Location = new System.Drawing.Point(120, 56);
			this.txtModelCode.MaxLength = 5;
			this.txtModelCode.Name = "txtModelCode";
			this.txtModelCode.Size = new System.Drawing.Size(64, 20);
			this.txtModelCode.TabIndex = 3;
			this.txtModelCode.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "ชื่อรุ่น(ภาษาไทย)";
			// 
			// txtThaiModelName
			// 
			this.txtThaiModelName.Location = new System.Drawing.Point(120, 88);
			this.txtThaiModelName.MaxLength = 50;
			this.txtThaiModelName.Name = "txtThaiModelName";
			this.txtThaiModelName.Size = new System.Drawing.Size(352, 20);
			this.txtThaiModelName.TabIndex = 4;
			this.txtThaiModelName.Text = "";
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(185, 280);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 12;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(265, 280);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 13;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "ยี่ห้อรถ";
			// 
			// txtBrandName
			// 
			this.txtBrandName.Enabled = false;
			this.txtBrandName.Location = new System.Drawing.Point(192, 24);
			this.txtBrandName.MaxLength = 50;
			this.txtBrandName.Name = "txtBrandName";
			this.txtBrandName.Size = new System.Drawing.Size(280, 20);
			this.txtBrandName.TabIndex = 2;
			this.txtBrandName.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cboBreakType);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.txtEngModelName);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.cboModelType);
			this.groupBox1.Controls.Add(this.cboGearType);
			this.groupBox1.Controls.Add(this.cboGasolineType);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtBrandCode);
			this.groupBox1.Controls.Add(this.txtThaiModelName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtBrandName);
			this.groupBox1.Controls.Add(this.txtModelCode);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtEngineCC);
			this.groupBox1.Controls.Add(this.txtNoOfSeat);
			this.groupBox1.Location = new System.Drawing.Point(17, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(480, 256);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// cboBreakType
			// 
			this.cboBreakType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBreakType.Location = new System.Drawing.Point(120, 184);
			this.cboBreakType.Name = "cboBreakType";
			this.cboBreakType.Size = new System.Drawing.Size(104, 21);
			this.cboBreakType.TabIndex = 8;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 184);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(80, 23);
			this.label10.TabIndex = 23;
			this.label10.Text = "ประเภทเบรค";
			// 
			// txtEngModelName
			// 
			this.txtEngModelName.Location = new System.Drawing.Point(120, 120);
			this.txtEngModelName.MaxLength = 50;
			this.txtEngModelName.Name = "txtEngModelName";
			this.txtEngModelName.Size = new System.Drawing.Size(352, 20);
			this.txtEngModelName.TabIndex = 5;
			this.txtEngModelName.Text = "";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(8, 120);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(90, 16);
			this.label9.TabIndex = 21;
			this.label9.Text = "ชื่อรุ่น(ภาษาอังกฤษ)";
			// 
			// cboModelType
			// 
			this.cboModelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboModelType.Items.AddRange(new object[] {
															  ""});
			this.cboModelType.Location = new System.Drawing.Point(120, 152);
			this.cboModelType.Name = "cboModelType";
			this.cboModelType.Size = new System.Drawing.Size(104, 21);
			this.cboModelType.TabIndex = 6;
			// 
			// cboGearType
			// 
			this.cboGearType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGearType.Location = new System.Drawing.Point(352, 152);
			this.cboGearType.Name = "cboGearType";
			this.cboGearType.Size = new System.Drawing.Size(121, 21);
			this.cboGearType.TabIndex = 7;
			// 
			// cboGasolineType
			// 
			this.cboGasolineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGasolineType.Location = new System.Drawing.Point(352, 184);
			this.cboGasolineType.Name = "cboGasolineType";
			this.cboGasolineType.Size = new System.Drawing.Size(121, 21);
			this.cboGasolineType.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(280, 216);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 23);
			this.label8.TabIndex = 14;
			this.label8.Text = "จำนวนที่นั่ง";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 152);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 23);
			this.label7.TabIndex = 13;
			this.label7.Text = "ประเภทรุ่น";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(256, 184);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 23);
			this.label6.TabIndex = 12;
			this.label6.Text = "ประเภทเชื้อเพลิง";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(272, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 11;
			this.label5.Text = "ประเภทเกียร์";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 216);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 10;
			this.label4.Text = "ซีซี.";
			// 
			// txtBrandCode
			// 
			this.txtBrandCode.Enabled = false;
			this.txtBrandCode.Location = new System.Drawing.Point(120, 24);
			this.txtBrandCode.MaxLength = 2;
			this.txtBrandCode.Name = "txtBrandCode";
			this.txtBrandCode.Size = new System.Drawing.Size(64, 20);
			this.txtBrandCode.TabIndex = 1;
			this.txtBrandCode.Text = "";
			// 
			// txtEngineCC
			// 
			this.txtEngineCC.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.txtEngineCC.AllowClipboardKeys = true;
			this.txtEngineCC.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.txtEngineCC.Location = new System.Drawing.Point(120, 216);
			this.txtEngineCC.MaxValue = 9999;
			this.txtEngineCC.MinValue = 0;
			this.txtEngineCC.Name = "txtEngineCC";
			this.txtEngineCC.Size = new System.Drawing.Size(104, 20);
			this.txtEngineCC.TabIndex = 10;
			this.txtEngineCC.Text = "";
			// 
			// txtNoOfSeat
			// 
			this.txtNoOfSeat.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.txtNoOfSeat.AllowClipboardKeys = true;
			this.txtNoOfSeat.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.txtNoOfSeat.Location = new System.Drawing.Point(352, 216);
			this.txtNoOfSeat.MaxValue = 255;
			this.txtNoOfSeat.MinValue = 0;
			this.txtNoOfSeat.Name = "txtNoOfSeat";
			this.txtNoOfSeat.Size = new System.Drawing.Size(120, 20);
			this.txtNoOfSeat.TabIndex = 11;
			this.txtNoOfSeat.Text = "";
			// 
			// frmModelEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(514, 318);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmModelEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmModelEntry";
			this.Load += new System.EventHandler(this.frmModelEntry_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private bool isReadonly = true;
		private TMPfrmModel parentForm;
		#endregion

//		============================== Property ==============================
		public void setBrand()
		{
			txtBrandCode.Text = parentForm.Brand.Code;
			txtBrandName.Text = parentForm.Brand.AName.English;		
		}
		public void setModel(Model value)
		{
			txtModelCode.Text = value.Code;
			txtThaiModelName.Text = value.AName.Thai;
			txtEngModelName.Text = value.AName.English;
			cboModelType.Text = value.AModelType.AName.Thai;
			cboGearType.Text = GUIFunction.GetString(value.GearType);
			cboBreakType.Text = GUIFunction.GetString(value.BreakType);
			cboGasolineType.Text = value.AGasolineType.AName.Thai;
			txtEngineCC.Text = GUIFunction.GetString(value.EngineCC);
			txtNoOfSeat.Text = GUIFunction.GetString(value.NoOfSeat);
		}
		public Model getModel()
		{
			Model objModel = new Model();
			objModel.ABrand.Code = txtBrandCode.Text;
			objModel.Code = txtModelCode.Text;
			objModel.AName.Thai = txtThaiModelName.Text;
			objModel.AName.English = txtEngModelName.Text;
			objModel.AModelType = (ModelType)cboModelType.SelectedItem;
			objModel.GearType = CTFunction.GetGearType(cboGearType.Text);
			objModel.BreakType = CTFunction.GetBreakType(cboBreakType.Text);
			objModel.AGasolineType = (GasolineType)cboGasolineType.SelectedItem;
			objModel.EngineCC = Convert.ToInt32(txtEngineCC.Text);
			objModel.NoOfSeat = Convert.ToInt32(txtNoOfSeat.Text);
			return objModel;
		}
//		============================== Constructor ==============================
		public TMPfrmModelEntry(TMPfrmModel parentForm):base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleVehicleModel");

			try
			{			
				cboModelType.DataSource = parentForm.FacadeModel.DataSourceModelType;
				cboGearType.DataSource = parentForm.FacadeModel.DataSourceGearType;
				cboGasolineType.DataSource = parentForm.FacadeModel.DataSourceGasolineType;
				cboBreakType.DataSource = parentForm.FacadeModel.DataSourceBreakType;
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);

			}
			catch(Exception ex)
			{
				Message(ex);
			}
			finally
			{
			}

		}
//		============================== private method ==============================
		private void enableKeyField(bool enable)
		{
			txtBrandCode.Enabled = enable;
			txtModelCode.Enabled = enable;
		}

		private void clearForm()
		{
			txtModelCode.Text = "";
			txtThaiModelName.Text = "";
			txtEngModelName.Text = "";
			txtEngineCC.Text = "0";
			txtNoOfSeat.Text = "0";
			InitCombo();
			txtModelCode.Focus();
		}
		
		private bool ValidateForm()
		{
			return validate1() && validate2() && validate3() && validate4()&& validate5() && validate6()&& validate7()&& validate8()&& validate9();
		}

		private bool validate1()
		{
			if (txtModelCode.Text == "")
			{
				Message(MessageList.Error.E0002,"รหัสรุ่น");
				txtModelCode.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate2()
		{
			if (txtThaiModelName.Text == "")
			{
				Message(MessageList.Error.E0002,"ชื่อรุ่น(ภาษาไทย)");
				txtThaiModelName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate3()
		{
			if (txtEngModelName.Text == "")
			{
				Message(MessageList.Error.E0002,"ชื่อรุ่น(ภาษาอังกฤษ)");
				txtEngModelName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate4()
		{
			if (cboModelType.Text == "")
			{
				Message(MessageList.Error.E0005,"ประเภทรุ่น");
				cboModelType.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate5()
		{
			if (cboGearType.Text == "")
			{
				Message(MessageList.Error.E0005,"ประเภทเกียร์");
				cboGearType.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate6()
		{
			if (cboBreakType.Text == "")
			{
				Message(MessageList.Error.E0005,"ประเภทเบรค");
				cboBreakType.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate7()
		{
			if (cboGasolineType.Text == "")
			{
				Message(MessageList.Error.E0005,"ประเภทเชื้อเพลิง");
				cboGasolineType.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate8()
		{
			if (txtEngineCC.Text == "0")
			{
				Message(MessageList.Error.E0002,"ซีซี");
				txtEngineCC.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate9()
		{
			if (txtNoOfSeat.Text == "0")
			{
				Message(MessageList.Error.E0002,"จำนวนที่นั่ง");
				txtNoOfSeat.Focus();
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

			setBrand();
			enableKeyField(true);
			txtBrandCode.Enabled = false;
			this.Text = "เพิ่มข้อมูลรุ่นรถ";
		}

		public void InitEditAction(Model aModel)
		{
			baseEDIT();
			clearForm();
			setBrand();
			setModel(aModel);
			enableKeyField(false);
			this.Text = "แก้ไขข้อมูลรุ่นรถ";

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}
		public void InitCombo()
		{
			cboModelType.SelectedIndex = -1;
			cboGearType.SelectedIndex = -1;
			cboBreakType.SelectedIndex = -1;
			cboGasolineType.SelectedIndex = -1;
		}
		public void ThaiModelName()
		{
			txtThaiModelName.Focus();
		}
		
//		============================== Base event ==============================
		private void AddEvent()
		{
			try
			{
				
				if (ValidateForm() && parentForm.AddRow(getModel()))
				{
					clearForm();
					InitAddAction();
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				txtModelCode.Focus();
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
				
				if (ValidateForm() && parentForm.UpdateRow(getModel()))
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
		private void frmModelEntry_Load(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
					InitAddAction();
					break;
			}
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

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

	}
}
