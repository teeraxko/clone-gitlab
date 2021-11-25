using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Facade.PiFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmPositionEntry  : EntryFormBase
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
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cboPosType;
		private System.Windows.Forms.ComboBox cboPosGroup;
		private System.Windows.Forms.TextBox txtShortName;
		private System.Windows.Forms.TextBox txtPositionCode;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.TextBox txtENName;
		private System.Windows.Forms.TextBox txtTHName;
		private System.Windows.Forms.RadioButton rdbDriver;
		private System.Windows.Forms.RadioButton rdbMechanic;
		private System.Windows.Forms.GroupBox gpbPositionRole;
		private System.Windows.Forms.RadioButton rdbOther;
		private FarPoint.Win.Input.FpDouble fpdPosAllowance;
		private System.Windows.Forms.GroupBox gpbPositionEntry;
		
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.gpbPositionEntry = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.fpdPosAllowance = new FarPoint.Win.Input.FpDouble();
			this.cboPosType = new System.Windows.Forms.ComboBox();
			this.cboPosGroup = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtENName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtShortName = new System.Windows.Forms.TextBox();
			this.txtTHName = new System.Windows.Forms.TextBox();
			this.txtPositionCode = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.rdbDriver = new System.Windows.Forms.RadioButton();
			this.rdbMechanic = new System.Windows.Forms.RadioButton();
			this.gpbPositionRole = new System.Windows.Forms.GroupBox();
			this.rdbOther = new System.Windows.Forms.RadioButton();
			this.gpbPositionEntry.SuspendLayout();
			this.gpbPositionRole.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbPositionEntry
			// 
			this.gpbPositionEntry.Controls.Add(this.label8);
			this.gpbPositionEntry.Controls.Add(this.fpdPosAllowance);
			this.gpbPositionEntry.Controls.Add(this.cboPosType);
			this.gpbPositionEntry.Controls.Add(this.cboPosGroup);
			this.gpbPositionEntry.Controls.Add(this.label7);
			this.gpbPositionEntry.Controls.Add(this.label6);
			this.gpbPositionEntry.Controls.Add(this.label5);
			this.gpbPositionEntry.Controls.Add(this.txtENName);
			this.gpbPositionEntry.Controls.Add(this.label4);
			this.gpbPositionEntry.Controls.Add(this.txtShortName);
			this.gpbPositionEntry.Controls.Add(this.txtTHName);
			this.gpbPositionEntry.Controls.Add(this.txtPositionCode);
			this.gpbPositionEntry.Controls.Add(this.label3);
			this.gpbPositionEntry.Controls.Add(this.label2);
			this.gpbPositionEntry.Controls.Add(this.label1);
			this.gpbPositionEntry.Location = new System.Drawing.Point(8, 8);
			this.gpbPositionEntry.Name = "gpbPositionEntry";
			this.gpbPositionEntry.Size = new System.Drawing.Size(496, 184);
			this.gpbPositionEntry.TabIndex = 8;
			this.gpbPositionEntry.TabStop = false;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(200, 152);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 16);
			this.label8.TabIndex = 14;
			this.label8.Text = "บาท";
			// 
			// fpdPosAllowance
			// 
			this.fpdPosAllowance.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpdPosAllowance.AllowClipboardKeys = true;
			this.fpdPosAllowance.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpdPosAllowance.DecimalPlaces = 2;
			this.fpdPosAllowance.DecimalSeparator = ".";
			this.fpdPosAllowance.FixedPoint = true;
			this.fpdPosAllowance.LeadZero = FarPoint.Win.Input.LeadZero.Hide;
			this.fpdPosAllowance.Location = new System.Drawing.Point(112, 152);
			this.fpdPosAllowance.Name = "fpdPosAllowance";
			this.fpdPosAllowance.Size = new System.Drawing.Size(75, 20);
			this.fpdPosAllowance.TabIndex = 10;
			this.fpdPosAllowance.Text = "";
			this.fpdPosAllowance.UseSeparator = true;
			// 
			// cboPosType
			// 
			this.cboPosType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPosType.Location = new System.Drawing.Point(328, 112);
			this.cboPosType.Name = "cboPosType";
			this.cboPosType.Size = new System.Drawing.Size(152, 21);
			this.cboPosType.TabIndex = 9;
			this.cboPosType.SelectedIndexChanged += new System.EventHandler(this.cboPosType_SelectedIndexChanged);
			// 
			// cboPosGroup
			// 
			this.cboPosGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPosGroup.Location = new System.Drawing.Point(112, 112);
			this.cboPosGroup.Name = "cboPosGroup";
			this.cboPosGroup.Size = new System.Drawing.Size(152, 21);
			this.cboPosGroup.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(280, 112);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 23);
			this.label7.TabIndex = 10;
			this.label7.Text = "ประเภท";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 112);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 9;
			this.label6.Text = "กลุ่ม";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "เงินประจำตำแหน่ง";
			// 
			// txtENName
			// 
			this.txtENName.Location = new System.Drawing.Point(112, 80);
			this.txtENName.MaxLength = 50;
			this.txtENName.Name = "txtENName";
			this.txtENName.Size = new System.Drawing.Size(368, 20);
			this.txtENName.TabIndex = 7;
			this.txtENName.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "ชื่อภาษาไทย";
			// 
			// txtShortName
			// 
			this.txtShortName.Location = new System.Drawing.Point(376, 16);
			this.txtShortName.MaxLength = 10;
			this.txtShortName.Name = "txtShortName";
			this.txtShortName.Size = new System.Drawing.Size(104, 20);
			this.txtShortName.TabIndex = 5;
			this.txtShortName.Text = "";
			// 
			// txtTHName
			// 
			this.txtTHName.Location = new System.Drawing.Point(112, 48);
			this.txtTHName.MaxLength = 50;
			this.txtTHName.Name = "txtTHName";
			this.txtTHName.Size = new System.Drawing.Size(368, 20);
			this.txtTHName.TabIndex = 6;
			this.txtTHName.Text = "";
			// 
			// txtPositionCode
			// 
			this.txtPositionCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPositionCode.Location = new System.Drawing.Point(112, 16);
			this.txtPositionCode.MaxLength = 2;
			this.txtPositionCode.Name = "txtPositionCode";
			this.txtPositionCode.Size = new System.Drawing.Size(40, 20);
			this.txtPositionCode.TabIndex = 4;
			this.txtPositionCode.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "ชื่อภาษาอังกฤษ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(328, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "ชื่อย่อ";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "รหัส";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(270, 264);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 24);
			this.cmdCancel.TabIndex = 12;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Location = new System.Drawing.Point(182, 264);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 24);
			this.cmdOK.TabIndex = 11;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// rdbDriver
			// 
			this.rdbDriver.Location = new System.Drawing.Point(48, 16);
			this.rdbDriver.Name = "rdbDriver";
			this.rdbDriver.TabIndex = 1;
			this.rdbDriver.Text = "พนักงานขับรถ";
			// 
			// rdbMechanic
			// 
			this.rdbMechanic.Location = new System.Drawing.Point(200, 16);
			this.rdbMechanic.Name = "rdbMechanic";
			this.rdbMechanic.TabIndex = 2;
			this.rdbMechanic.Text = "Mechanic";
			// 
			// gpbPositionRole
			// 
			this.gpbPositionRole.Controls.Add(this.rdbDriver);
			this.gpbPositionRole.Controls.Add(this.rdbMechanic);
			this.gpbPositionRole.Controls.Add(this.rdbOther);
			this.gpbPositionRole.Location = new System.Drawing.Point(8, 200);
			this.gpbPositionRole.Name = "gpbPositionRole";
			this.gpbPositionRole.Size = new System.Drawing.Size(496, 48);
			this.gpbPositionRole.TabIndex = 10;
			this.gpbPositionRole.TabStop = false;
			// 
			// rdbOther
			// 
			this.rdbOther.Location = new System.Drawing.Point(344, 16);
			this.rdbOther.Name = "rdbOther";
			this.rdbOther.TabIndex = 3;
			this.rdbOther.Text = "พนักงานอื่นๆ";
			// 
			// frmPositionEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(526, 300);
			this.Controls.Add(this.gpbPositionRole);
			this.Controls.Add(this.gpbPositionEntry);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "frmPositionEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmPositionEntry";
			this.gpbPositionEntry.ResumeLayout(false);
			this.gpbPositionRole.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmPosition parentForm;
		private Position objPosition;
		private PositionType selectedPositionType;
		#endregion - Private -

//		===================================== Property ===============================
		public Position getPosition()
		{
			objPosition = new Position();
			objPosition.PositionCode = txtPositionCode.Text;
			objPosition.ShortName = txtShortName.Text;
			objPosition.AName.English =	txtENName.Text;
			objPosition.AName.Thai = txtTHName.Text;
			objPosition.APositionGroup = (PositionGroup)cboPosGroup.SelectedItem;
			objPosition.APositionType = (PositionType)cboPosType.SelectedItem;
			objPosition.Allowance = Convert.ToDecimal(fpdPosAllowance.Value);
			if(objPosition.APositionType.Type == "S")
			{
				if(rdbDriver.Checked)
					objPosition.APositionRole = POSITION_ROLE_TYPE.DRIVER;
				if(rdbMechanic.Checked)
					objPosition.APositionRole = POSITION_ROLE_TYPE.MACHANIC;
				if(rdbOther.Checked)
					objPosition.APositionRole = POSITION_ROLE_TYPE.BLANK;
			}
			else
			{
				objPosition.APositionRole = POSITION_ROLE_TYPE.BLANK;
			}
			return objPosition;
		}
	
		public void setPosition(Position value)
		{
			objPosition = value;

			txtPositionCode.Text = GUIFunction.GetString(value.PositionCode);
			txtShortName.Text = GUIFunction.GetString(value.ShortName);
			txtTHName.Text = GUIFunction.GetString(value.AName.Thai);
			txtENName.Text = GUIFunction.GetString(value.AName.English);
			cboPosType.Text = CTFunction.GetString(value.APositionType);
			cboPosGroup.Text = value.APositionGroup.AName.Thai;
			fpdPosAllowance.Text = GUIFunction.GetString(value.Allowance);
			if(objPosition.APositionType.Type == "S")
			{
				if(value.APositionRole == POSITION_ROLE_TYPE.DRIVER)
					rdbDriver.Checked = true;
				if(value.APositionRole == POSITION_ROLE_TYPE.MACHANIC)
					rdbMechanic.Checked = true;
				if(value.APositionRole == POSITION_ROLE_TYPE.BLANK)
					rdbOther.Checked = true;
			}
		}

//		===================================== Constructor ============================
		public frmPositionEntry(frmPosition parentForm):base()
		{
			InitializeComponent();						
			this.parentForm = parentForm;	
			CTFunction ctFunction = new CTFunction();
			selectedPositionType = new PositionType();
			cboPosGroup.DataSource = parentForm.FacadePosition.DataSourcePositionGroup;
			cboPosType.DataSource = parentForm.FacadePosition.DataSourcePositionType;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIPositionPosition");
		}

//		============================== Private Method ================================
		#region - Validate Checking -	
		private bool ValidateForm()
		{
			return	ValidateCode() && ValidateShortName() && ValidateTHName() && 
					ValidateENName() && ValidatePosGroup() && ValidatePosType();
		}
		private bool ValidateCode()
		{
			if(txtPositionCode.Text == "") 
			{
				Message(MessageList.Error.E0002, "รหัสตำแหน่ง" );
				txtPositionCode.Focus();
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
				Message(MessageList.Error.E0002, "ชื่อย่อ" );
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
				Message(MessageList.Error.E0002, "ชื่อภาษาไทย" );
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
				Message(MessageList.Error.E0002, "ชื่อภาษาอังกฤษ" );
				txtENName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		
		private bool ValidatePosGroup()
		{
			if(cboPosGroup.Text == "") 
			{
				Message(MessageList.Error.E0005, "กลุ่ม" );
				cboPosGroup.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool ValidatePosType()
		{
			if(cboPosType.Text == "") 
			{
				Message(MessageList.Error.E0005, "ประเภท" );
				cboPosType.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool ValidateDupCode()
		{
			Position position = new Position();
			position.PositionCode = txtPositionCode.Text;
			if(parentForm.FacadePosition.FillPosition(position))
			{
				Message(MessageList.Error.E0003, "มีรายการนี้ในฐานข้อมูลแล้ว" );
				txtPositionCode.Focus();
				return false;
			}
			return true;		
		}

		private void MessageValidate()
		{
			if(rdbDriver.Checked)
			{
				Message(MessageList.Error.E0014,"เพิ่มพนักงานขับรถในฐานข้อมูลได้อีก");
				txtPositionCode.Focus();
			}
			else if (rdbMechanic.Checked)
			{
				Message(MessageList.Error.E0014,"เพิ่ม Mechanic ในฐานข้อมูลได้อีก");
				txtPositionCode.Focus();
			}
		}
		#endregion - Validate Checking -
		
		#region - Enable Control -
		private void enableKeyField(bool enable)
		{
			txtPositionCode.Enabled = enable;
		}
		private void enableGPBPositionRole(bool enable)
		{
			gpbPositionRole.Enabled = enable;
		}
		#endregion - Enable Control -

		private void SelectedPositionRole()
		{
			selectedPositionType = (PositionType)cboPosType.SelectedItem;
			if(selectedPositionType.Type == "S")
			{
				enableGPBPositionRole(true);
			}
			else
			{
				enableGPBPositionRole(false);
			}
		}

		private void clearForm()
		{
			rdbOther.Checked = true;
			enableGPBPositionRole(false);
			cboPosGroup.SelectedIndex = 0;
			cboPosType.SelectedIndex = 0;
			fpdPosAllowance.Value = 0;
			fpdPosAllowance.Text = "";
			txtPositionCode.Text = "";
			txtShortName.Text = "";
			txtTHName.Text = "";
			txtENName.Text = "";	
		}
			
//		============================== Public Method =================================
		private PositionFacade objPositionFacade;
		public PositionFacade ObjPositionFacade
		{
			set{objPositionFacade = value;}
		}
		
		public void InitAddAction()
		{
			this.title = "ตำแหน่ง";
			baseADD();
			clearForm();
			enableKeyField(true);
			enableGPBPositionRole(false);
			txtPositionCode.Focus();
		}
		public void InitEditAction(Position aPosition)
		{
			this.title = "ตำแหน่ง";
			baseEDIT();
			clearForm();
			setPosition(aPosition);
			enableKeyField(false);
			txtShortName.Focus();

			if(aPosition.APositionType.Type == "O")
			{
				enableGPBPositionRole(false);
			}
			else
			{
				enableGPBPositionRole(true);
			}

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}

//		============================== Base Event ====================================
		private void AddEvent()
		{
			try
			{
				if (ValidateForm() && ValidateDupCode())
				{
					if(parentForm.AddRow(getPosition()))
					{
						clearForm();
					}
					else
					{
						MessageValidate();
					}	
				}
			}	
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
	  }

		private void EditEvent()
		{
			try
			{
				if (ValidateForm())
				{
					if(parentForm.UpdateRow(getPosition()))
					{
						this.Hide();
					}
					else
					{
						MessageValidate();
					}
				}
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}	
		}
		
		
//		================================= Event ================================
		private void cboPosType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SelectedPositionRole();
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
