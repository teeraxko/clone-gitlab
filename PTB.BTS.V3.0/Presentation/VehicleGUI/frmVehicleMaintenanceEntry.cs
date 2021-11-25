using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarPoint.Win.Spread.CellType;

using Entity.VehicleEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmVehicleMaintenanceEntry : Presentation.VehicleGUI.frmVehicleRepairingEntryBase
	{
		#region Designer generated code
		private System.ComponentModel.IContainer components = null;
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmVehicleMaintenanceEntry));
			((System.ComponentModel.ISupportInitialize)(this.fpsPayment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsPayment_Sheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsRepairList_Sheet1)).BeginInit();
			// 
			// txtPlatePrefix
			// 
			this.txtPlatePrefix.Name = "txtPlatePrefix";
			// 
			// txtUserName
			// 
			this.txtUserName.Name = "txtUserName";
			// 
			// tabVehicleAccident
			// 
			this.tabVehicleAccident.Name = "tabVehicleAccident";
			// 
			// fpsPayment
			// 
			this.fpsPayment.Location = new System.Drawing.Point(16, 80);
			this.fpsPayment.Name = "fpsPayment";
			this.fpsPayment.Size = new System.Drawing.Size(344, 200);
			// 
			// cboAccidentPlace
			// 
			this.cboAccidentPlace.Name = "cboAccidentPlace";
			this.cboAccidentPlace.Size = new System.Drawing.Size(472, 24);
			// 
			// cboPoliceStation
			// 
			this.cboPoliceStation.Name = "cboPoliceStation";
			this.cboPoliceStation.Size = new System.Drawing.Size(256, 24);
			// 
			// dtpAccidentDate
			// 
			this.dtpAccidentDate.Name = "dtpAccidentDate";
			// 
			// chkAccessStatus
			// 
			this.chkAccessStatus.Name = "chkAccessStatus";
			// 
			// cboPayerType
			// 
			this.cboPayerType.Name = "cboPayerType";
			this.cboPayerType.Size = new System.Drawing.Size(176, 24);
			// 
			// fpsPayment_Sheet1
			// 
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsPayment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsPayment_Sheet1.ColumnCount = 5;
			this.fpsPayment_Sheet1.RowCount = 0;
			this.fpsPayment_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ปี";
			this.fpsPayment_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "เดือน";
			this.fpsPayment_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "จำนวนเงิน";
			this.fpsPayment_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "จ่ายแล้ว";
			this.fpsPayment_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsPayment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// chkPTBDriver
			// 
			this.chkPTBDriver.Name = "chkPTBDriver";
			// 
			// fpdPaid
			// 
			this.fpdPaid.Name = "fpdPaid";
			// 
			// dtpPaidDate
			// 
			this.dtpPaidDate.Name = "dtpPaidDate";
			// 
			// tabAccident
			// 
			this.tabAccident.Name = "tabAccident";
			// 
			// tabMaintain
			// 
			this.tabMaintain.Name = "tabMaintain";
			// 
			// cmbGarage
			// 
			this.cmbGarage.Name = "cmbGarage";
			this.cmbGarage.Size = new System.Drawing.Size(392, 24);
			// 
			// dtpRepairTo
			// 
			this.dtpRepairTo.Name = "dtpRepairTo";
			// 
			// dtpRepairForm
			// 
			this.dtpRepairForm.Name = "dtpRepairForm";
			this.dtpRepairForm.ValueChanged += new System.EventHandler(this.dtpRepairForm_ValueChanged);
			// 
			// txbReceiverNo
			// 
			this.txbReceiverNo.Name = "txbReceiverNo";
			// 
			// fpdExcessTotalAmount
			// 
			this.fpdExcessTotalAmount.Name = "fpdExcessTotalAmount";
			// 
			// chkHasRepair
			// 
			this.chkHasRepair.Name = "chkHasRepair";
			// 
			// fpsRepairList_Sheet1
			// 
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsRepairList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsRepairList_Sheet1.ColumnCount = 4;
			this.fpsRepairList_Sheet1.RowCount = 0;
			this.fpsRepairList_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "อะไหล่";
			this.fpsRepairList_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "รายละเอียด";
			this.fpsRepairList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "สถานะค่าใช้จ่าย";
			this.fpsRepairList_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsRepairList_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsRepairList_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsRepairList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// frmVehicleMaintenanceEntry
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1016, 632);
			this.Name = "frmVehicleMaintenanceEntry";
			this.Text = "ซ่อมบำรุง";
			this.Load += new System.EventHandler(this.frmVehicleMaintenanceEntry_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsPayment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsPayment_Sheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsRepairList_Sheet1)).EndInit();

		}

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
		#endregion

		#region - Private - 
			private Maintenance objMaintenance;
		#endregion

		//==============================  Constructor  ==============================
		public frmVehicleMaintenanceEntry() : base()
		{
			InitializeComponent();
			strGarage = "ศูนย์บริการ";
			tabVehicleAccident.TabPages.Remove(tabAccident);
			programType = PROGRAM_TYPE.MAINTAIN;
			setFpsRepairList();
			setPermission(UserProfile.IsReadOnly("miVehicle", "miVehicleMaintenanceHistory"));
		}

		#region - validate - 
		protected override int getMaxMileage()
		{
			if(action == ActionType.ADD)
			{
				return formParent.FacadeRepairing.GetMaxMileage(dtpRepairForm.Value, null);
			}
			else
			{
				objMaintenance.RepairingNo = ((DocumentNo)txtDocumentType.Tag).ToString();
				return formParent.FacadeRepairing.GetMaxMileage(dtpRepairForm.Value, objMaintenance);
			}
		}

		protected override bool validateAccident()
		{
			return true;
		}

		protected override bool validateMaintain()
		{
			if(Convert.ToDecimal(fpiMileage.Value) == 0)
			{
				Message(MessageList.Error.E0002, "เลขไมล์");
				fpiMileage.Focus();
				return false;
			}

			int maxMileage = getMaxMileage();
			if(Convert.ToInt32(fpiMileage.Value)<maxMileage)
			{
                if (Message(MessageList.Warning.W0003) == DialogResult.Cancel)
                { 
                    fpiMileage.Focus();
				    return false;
                }				
			}

			return base.validateMaintain();
		}
		#endregion

		#region - Get Object -
		protected override void fillHeader()
		{
			base.fillHeader();
			objRepairing.RepairingType = REPAIRING_TYPE.MAINTENANCER;
		}

		protected override void fillAccident()
		{}

		protected override void fillObjRepairing()
		{
			objRepairing = new Maintenance(formParent.FacadeRepairing.GetCompany());
			chkHasRepair.Checked = true;
			fillHeader();
			fillMaintenance();
		}
		#endregion

		#region - Set Object -
        protected override void setAccident(RepairingInfoBase value)
		{}

		protected override void setHeader()
		{
			txtUserName.Text = FormParent.FacadeRepairing.GetHirerName(FormParent.FacadeRepairing.VehicleRepairing.AVehicleInfo, dtpRepairForm.Value.Date, dtpRepairTo.Value.Date);
		}
		#endregion

		//==============================  Base Event   ==============================
		
		//============================== Public Method ==============================
//		public override void InitAddAction(Vehicle value)
//		{			
//			value.ACurrentContract = formParent.FacadeRepairing.GetVehicleContract(value, DateTime.Today);
//			base.InitAddAction(value);
//		}

        protected override void enableExcessForDriverPaid(RepairingInfoBase value)
		{}

		//==============================     event     ==============================
		private void frmVehicleMaintenanceEntry_Load(object sender, System.EventArgs e)
		{
			objRepairing = new Maintenance(formParent.FacadeRepairing.GetCompany());
			objMaintenance = (Maintenance)objRepairing;

			enableMaintain(true);
            enablechkVat(true);
            enableVatStatus();

			getVehicleAssignment((VehicleInfo)txtPlatePrefix.Tag);
			setContact(objRepairing);


		}

		protected override void getVehicleAssignment(VehicleInfo value)
		{
			VehicleAssignment vehicleAssignment = formParent.FacadeRepairing.GetVehicleAssignmentOnTime(value, dtpRepairForm.Value, dtpRepairForm.Value);
			if(vehicleAssignment==null)
			{
				objRepairing.AVehicleContract = null;
				if(action == ActionType.ADD)
				{
					objRepairing.AHirer = new Hirer();
				}				
			}
			else
			{
				objRepairing.AVehicleContract = (VehicleContract)vehicleAssignment.AContract;
				objRepairing.AHirer = vehicleAssignment.AHirer;
			}
			vehicleAssignment = null;			
		}

		private void dtpRepairForm_ValueChanged(object sender, System.EventArgs e)
		{
			getVehicleAssignment((VehicleInfo)txtPlatePrefix.Tag);
			setContact(objRepairing);
		}
	}
}