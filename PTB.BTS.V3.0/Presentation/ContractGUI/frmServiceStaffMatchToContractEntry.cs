using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using Facade.CommonFacade;
using Facade.VehicleFacade;
using Facade.ContractFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.ContractGUI
{
	public class frmServiceStaffMatchToContractEntry : EntryFormBase
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
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtEmpPosition;
		private System.Windows.Forms.TextBox txtEmpName;
		private System.Windows.Forms.GroupBox gpbEmpDetail;
		private System.Windows.Forms.GroupBox gpbOther;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.TextBox txtHireName;
		private System.Windows.Forms.ComboBox cboServiceStaffType;
		private System.Windows.Forms.TextBox txtEmpNo;
	
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.gpbEmpDetail = new System.Windows.Forms.GroupBox();
			this.txtEmpNo = new System.Windows.Forms.TextBox();
			this.cboServiceStaffType = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtEmpPosition = new System.Windows.Forms.TextBox();
			this.txtEmpName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtHireName = new System.Windows.Forms.TextBox();
			this.gpbOther = new System.Windows.Forms.GroupBox();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.gpbEmpDetail.SuspendLayout();
			this.gpbOther.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbEmpDetail
			// 
			this.gpbEmpDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.gpbEmpDetail.Controls.Add(this.txtEmpNo);
			this.gpbEmpDetail.Controls.Add(this.cboServiceStaffType);
			this.gpbEmpDetail.Controls.Add(this.label14);
			this.gpbEmpDetail.Controls.Add(this.label13);
			this.gpbEmpDetail.Controls.Add(this.label11);
			this.gpbEmpDetail.Controls.Add(this.txtEmpPosition);
			this.gpbEmpDetail.Controls.Add(this.txtEmpName);
			this.gpbEmpDetail.Location = new System.Drawing.Point(12, 16);
			this.gpbEmpDetail.Name = "gpbEmpDetail";
			this.gpbEmpDetail.Size = new System.Drawing.Size(516, 128);
			this.gpbEmpDetail.TabIndex = 1;
			this.gpbEmpDetail.TabStop = false;
			this.gpbEmpDetail.Text = "ข้อมูลพนักงาน";
			// 
			// txtEmpNo
			// 
			this.txtEmpNo.Location = new System.Drawing.Point(112, 24);
			this.txtEmpNo.MaxLength = 5;
			this.txtEmpNo.Name = "txtEmpNo";
			this.txtEmpNo.Size = new System.Drawing.Size(56, 20);
			this.txtEmpNo.TabIndex = 1;
			this.txtEmpNo.Text = "";
			this.txtEmpNo.TextChanged += new System.EventHandler(this.txtEmpNo_TextChanged);
			this.txtEmpNo.DoubleClick += new System.EventHandler(this.txtEmpNo_DoubleClick);
			// 
			// cboServiceStaffType
			// 
			this.cboServiceStaffType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboServiceStaffType.Location = new System.Drawing.Point(112, 88);
			this.cboServiceStaffType.Name = "cboServiceStaffType";
			this.cboServiceStaffType.Size = new System.Drawing.Size(384, 21);
			this.cboServiceStaffType.TabIndex = 4;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(16, 88);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(100, 32);
			this.label14.TabIndex = 40;
			this.label14.Text = "ประเภทพนักงาน (Service Staff)";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(16, 24);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 23);
			this.label13.TabIndex = 33;
			this.label13.Text = "พนักงาน";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 56);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 23);
			this.label11.TabIndex = 38;
			this.label11.Text = "ตำแหน่ง";
			// 
			// txtEmpPosition
			// 
			this.txtEmpPosition.Enabled = false;
			this.txtEmpPosition.Location = new System.Drawing.Point(112, 56);
			this.txtEmpPosition.Name = "txtEmpPosition";
			this.txtEmpPosition.Size = new System.Drawing.Size(384, 20);
			this.txtEmpPosition.TabIndex = 3;
			this.txtEmpPosition.Text = "";
			// 
			// txtEmpName
			// 
			this.txtEmpName.Enabled = false;
			this.txtEmpName.Location = new System.Drawing.Point(176, 24);
			this.txtEmpName.Name = "txtEmpName";
			this.txtEmpName.Size = new System.Drawing.Size(320, 20);
			this.txtEmpName.TabIndex = 2;
			this.txtEmpName.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "ชื่อนายจ้าง";
			// 
			// txtHireName
			// 
			this.txtHireName.Location = new System.Drawing.Point(112, 24);
			this.txtHireName.Name = "txtHireName";
			this.txtHireName.Size = new System.Drawing.Size(384, 20);
			this.txtHireName.TabIndex = 5;
			this.txtHireName.Text = "";
			// 
			// gpbOther
			// 
			this.gpbOther.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.gpbOther.Controls.Add(this.label4);
			this.gpbOther.Controls.Add(this.txtHireName);
			this.gpbOther.Location = new System.Drawing.Point(16, 152);
			this.gpbOther.Name = "gpbOther";
			this.gpbOther.Size = new System.Drawing.Size(512, 56);
			this.gpbOther.TabIndex = 2;
			this.gpbOther.TabStop = false;
			this.gpbOther.Text = "อื่น ๆ";
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Location = new System.Drawing.Point(200, 224);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 6;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(280, 224);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 7;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmServiceStaffMatchToContractEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(544, 262);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.gpbOther);
			this.Controls.Add(this.gpbEmpDetail);
			this.Name = "frmServiceStaffMatchToContractEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmServiceStaffMatchToContractEntry_Load);
			this.gpbEmpDetail.ResumeLayout(false);
			this.gpbOther.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmServiceStaffMatchToContractDetail parentForm;
		private ServiceStaffRole objServiceStaffRole;
		#endregion - Private -

//		=================================== Constructor ============================
		public frmServiceStaffMatchToContractEntry(frmServiceStaffMatchToContractDetail parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractDocumentServiceStaffMatchToContract");
		}

//		===================================== Property ===============================
		private ServiceStaff aServiceStaff;
		public ServiceStaff AServiceStaff
		{
			set
			{
				aServiceStaff = value;
				txtEmpNo.Text = value.EmployeeNo;
				txtEmpName.Text = value.EmployeeName;
				txtEmpPosition.Text = value.APosition.AName.Thai;
			}	
		}

		private ServiceStaffAssignment objServiceStaffAssignment;
		public ServiceStaffAssignment ObjServiceStaffAssignment
		{
			get
			{
				objServiceStaffAssignment = new ServiceStaffAssignment();
				objServiceStaffAssignment.AAssignedServiceStaff = aServiceStaff;
				objServiceStaffAssignment.AMainServiceStaff = aServiceStaff;
				objServiceStaffAssignment.APeriod.From = parentForm.ObjServiceStaffContract.APeriod.From;
				objServiceStaffAssignment.APeriod.To = parentForm.ObjServiceStaffContract.APeriod.To;
				objServiceStaffAssignment.AContract = parentForm.ObjServiceStaffContract;
				objServiceStaffAssignment.AssignmentRole = ASSIGNMENT_ROLE_TYPE.MAIN;
				objServiceStaffAssignment.AHirer.Name = txtHireName.Text;
				return objServiceStaffAssignment;
			}
			set
			{
				objServiceStaffAssignment = value;
				txtHireName.Text = value.AHirer.Name;
			}
		}

//		============================== Private Method ====================================
		#region - Validate - 		
		private bool validateServiceStaff(string employeeNo)
		{
			ServiceStaff serviceStaff = parentForm.FacadeServiceStaffMatchToContract.GetAllServiceStaff(employeeNo);

			if(serviceStaff == null)
			{
				Message(MessageList.Error.E0004, "รหัสพนักงาน(ServiceStaff)");
				setSelected(txtEmpNo);
				serviceStaff = null;
				return false; 
			}

			string workStatus = serviceStaff.AWorkingStatus.Code;
			if((workStatus == "06" || workStatus == "07" || workStatus == "08") & (serviceStaff.TerminationDate <= parentForm.ObjServiceStaffContract.APeriod.To))
			{
				Message(MessageList.Error.E0014, "ระบุพนักงานที่ลาออกแล้วเข้าสัญญาได้");
				setSelected(txtEmpNo);
				serviceStaff = null;
				return false; 
			}

            if (parentForm.ObjServiceStaffContract.AContractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
			{
				if(serviceStaff.APosition.APositionRole != POSITION_ROLE_TYPE.DRIVER)
				{
					Message(MessageList.Error.E0002, "รหัสพนักงานที่มีตำแหน่งตรงกับประเภทสัญญา");
					setSelected(txtEmpNo);
					return false;
				}			
			}
			else 
			{
				if(serviceStaff.APosition.APositionRole == POSITION_ROLE_TYPE.DRIVER)
				{
					Message(MessageList.Error.E0002, "รหัสพนักงานที่มีตำแหน่งตรงกับประเภทสัญญา");
					setSelected(txtEmpNo);
					return false;				
				}			
			}

			AServiceStaff = serviceStaff;
			serviceStaff = null;
			return true;				
		}

		private bool validateInputEmpNo()
		{
			if(txtEmpNo.Text == "")
			{
				Message(MessageList.Error.E0002, "รหัสพนักงาน");
				setSelected(txtEmpNo);
				return false; 
			}
			return true;
		}

		private bool validateServiceStaffContract()
		{
			for(int i=0;i<parentForm.ObjServiceStaffContract.ALatestServiceStaffRoleList.Count; i++)
			{
				if(parentForm.ObjServiceStaffContract.ALatestServiceStaffRoleList[i].AServiceStaff.EntityKey == aServiceStaff.EntityKey)
				{
					Message(MessageList.Error.E0003, "มีรายการนี้ในฐานข้อมูลแล้วกรุณากรอกใหม่อีกครั้ง");
					setSelected(txtEmpNo);
					return false; 
				}			
			}
			return true;		
		}

		private bool validateAvailableServiceStaff()
		{
			if(parentForm.FacadeServiceStaffMatchToContract.FillNotAvailableServiceStaffAssignment(ObjServiceStaffAssignment))
			{	
				Message(MessageList.Error.E0013, "ระบุพนักงานคนนี้ในสัญญาได้","พนักงานคนนี้ถูกใช้งานในช่วงเวลาดังกล่าว");
				setSelected(txtEmpNo);
				return false;
			}
			return true;
		}

		private bool validateInputHireName()
		{
			if(txtHireName.Text == "")
			{
				Message(MessageList.Error.E0002, "ชื่อนายจ้าง" );
				txtHireName.Focus();
				return false;
			}
			return true;
		}

		private bool validateInputServiceStaffType()
		{
			if(cboServiceStaffType.Text == "")
			{
				Message(MessageList.Error.E0002, "ประเภทพนักงาน Service Staff" );
				cboServiceStaffType.Focus();
				return false;
			}
			return true;
		}		

		private bool validateUnitHirer()
		{
			if(parentForm.ObjServiceStaffContract.ALatestServiceStaffRoleList.Count >= parentForm.ObjServiceStaffContract.UnitHire)
			{
				Message(MessageList.Error.E0011, "จำนวนพนักงาน","จำนวนพนักงานในสัญญา");
				cmdCancel.Focus();
				return false;			
			}
			return true;		
		}

		private bool validateServiceStaffType(ServiceStaffType value)
		{
			if(value.IsSpare)
			{
				Message(MessageList.Error.E0043);
				cboServiceStaffType.Focus();
				return false;
			}
			return true;		
		}
		#endregion - Validate - 

		private void enableAddEvent(bool enable)
		{
			txtEmpNo.Enabled = enable;
			txtHireName.Enabled = enable;
			cboServiceStaffType.Enabled = enable;
		}

		private void enableEditEvent(bool enable)
		{
			txtEmpNo.Enabled = !enable;
			txtHireName.Enabled = enable;
			cboServiceStaffType.Enabled = enable;		
		}

		private void clearForm()
		{
			txtEmpNo.Text = "";
			txtEmpName.Text = "";
			txtEmpPosition.Text = "";
			txtHireName.Text = "";
			
			if(cboServiceStaffType.Items.Count >0)
			{
				cboServiceStaffType.SelectedIndex = -1;
				cboServiceStaffType.SelectedIndex = -1;
			}
			cboServiceStaffType.Text = "";
			txtEmpNo.Focus();
		}

		private void formEmployeeList()
		{
			frmServiceStaffList dialogServiceStaffList = new frmServiceStaffList();
			dialogServiceStaffList.ConditionTimePeriod = parentForm.ObjServiceStaffContract.APeriod;

            if (parentForm.ObjServiceStaffContract.AContractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
			{
				dialogServiceStaffList.IsDriver = true;
			}
            else if (parentForm.ObjServiceStaffContract.AContractType.Code == ContractType.CONTRACT_TYPE_OTHER)
			{
				dialogServiceStaffList.IsNotDriver = true;
			}
			dialogServiceStaffList.ShowDialog();			

			if(dialogServiceStaffList.Selected)
			{
				AServiceStaff = (ServiceStaff)dialogServiceStaffList.SelectedServiceStaff;
				setDatasourceServiceStaffType(aServiceStaff);
			}
		}

		private void setDatasourceServiceStaffType(ServiceStaff value)
		{
			cboServiceStaffType.DataSource = parentForm.FacadeServiceStaffMatchToContract.DataSourceServiceStaffType(value.APosition);
			cboServiceStaffType.Text = value.AServiceStaffType.ADescription.English;
		}

//		============================== Base Event ====================================
		private void addEvent()
		{			
			try
			{  
				if (validateInputEmpNo() && validateServiceStaff(txtEmpNo.Text) && validateUnitHirer() && validateInputServiceStaffType() && validateServiceStaffContract() && validateAvailableServiceStaff())
				{
					aServiceStaff.AServiceStaffType = (ServiceStaffType)cboServiceStaffType.SelectedItem;

					if(validateServiceStaffType(aServiceStaff.AServiceStaffType))
					{
						if(parentForm.AddRow(aServiceStaff, ObjServiceStaffAssignment))
						{
							clearForm();
						}
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

		private void editEvent()
		{
			try
			{		
				aServiceStaff.AServiceStaffType = (ServiceStaffType)cboServiceStaffType.SelectedItem;					
				objServiceStaffRole.AServiceStaffType = (ServiceStaffType)cboServiceStaffType.SelectedItem;
				objServiceStaffRole.AServiceStaff = aServiceStaff;
				objServiceStaffAssignment.AHirer.Name = txtHireName.Text;

				if (validateInputServiceStaffType() && validateServiceStaffType(aServiceStaff.AServiceStaffType))
				{
					if(parentForm.UpdateRow(objServiceStaffRole, objServiceStaffAssignment, aServiceStaff))
					{
						this.Hide();
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
	
//		================================== Public Method ===========================
		public void InitAddAction()	
		{	
			this.title = "ระบุพนักงานในสัญญา";
			baseADD();
			clearForm();
			enableAddEvent(true);
		}

		public void InitEditAction(ServiceStaffRole aServiceStaffRole, ServiceStaffAssignment aServiceStaffAssignment)
		{
			this.title = "ระบุพนักงานในสัญญา";
			baseEDIT();
			clearForm();

			objServiceStaffRole = new ServiceStaffRole();
			objServiceStaffRole = aServiceStaffRole;
			ObjServiceStaffAssignment = aServiceStaffAssignment;
			AServiceStaff = aServiceStaffRole.AServiceStaff;
			setDatasourceServiceStaffType(aServiceStaff);

			cboServiceStaffType.Text = aServiceStaffRole.AServiceStaffType.ADescription.English;
			enableEditEvent(true);

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}

//		===================================== Event ===============================
		private void frmServiceStaffMatchToContractEntry_Load(object sender, System.EventArgs e)
		{
			if(action == ActionType.ADD)
			{
				clearForm();	
			}		
		}

		private void txtEmpNo_TextChanged(object sender, System.EventArgs e)
		{
			if(txtEmpNo.Text.Length == 5)
			{
				if(validateServiceStaff(txtEmpNo.Text))
				{
					setDatasourceServiceStaffType(aServiceStaff);
				}
			}		
		}

		private void txtEmpNo_DoubleClick(object sender, System.EventArgs e)
		{
			formEmployeeList();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				 case ActionType.ADD :
					 addEvent();
					 break;
				 case ActionType.EDIT :
					 editEvent();
					 break;
			 }
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}		
	}
}
