using System;
using System.Collections;
using FarPoint.Win.Spread.CellType;

using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities;

using PTB.BTS.Common.Flow;
using PTB.BTS.Contract.Flow;
using PTB.BTS.Vehicle.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;
using ictus.Common.Entity;

namespace Facade.VehicleFacade
{
	public abstract class VehicleRepairingFacadeBase : CommonPIFacadeBase
	{
		#region - Private -
		private AgeFlow flowAge;
		private VehicleFlow flowVehicle;
		protected DOCUMENT_TYPE documentType = DOCUMENT_TYPE.NULL;
		private ContractFlow flowContract;
		#endregion

		#region - Property -
		#endregion

		#region - DataSource -
		public ArrayList DataSourceAccidentPlace
		{
			get
			{
				PlaceFlow flowPlace = new PlaceFlow();
				PlaceList placeList = new PlaceList();
				flowPlace.FillMTBList(placeList);
				flowPlace= null;
				return placeList.GetArrayList();
			}
		}

		public ArrayList DataSourceGarage
		{
			get
			{
				GarageFlow flowGarage = new GarageFlow();
				GarageList garageList = new GarageList(GetCompany());
				flowGarage.FillGarageList(ref garageList);
				flowGarage= null;
				return garageList.GetArrayList();
			}
		}
		
		public ArrayList DataSourcePoliceStation
		{
			get
			{
				PoliceStationFlow flowPoliceStation = new PoliceStationFlow();
				PoliceStationList policeStationList = new PoliceStationList();
				flowPoliceStation.FillMTBList(policeStationList);
				flowPoliceStation= null;
				return policeStationList.GetArrayList();
			}
		}

		public ArrayList DataSourcePayment
		{
			get
			{
				PaymentTypeFlow flowPaymentType = new PaymentTypeFlow();
				PaymentTypeList paymentTypeList = new PaymentTypeList();
				flowPaymentType.FillMTBList(paymentTypeList);
				flowPaymentType= null;
				return paymentTypeList.GetArrayList();
			}
		}

		public string[] DataSourcePayer
		{
			get
			{
				CTFunction ctFunction = new CTFunction();
				return ctFunction.PayerTypeArray;
			}
		}

		private SparePartsList sparePartsList;
		public ComboBoxCellType DataSourceSparepart
		{
			get
			{
				SparePartsFlow flowMTB = new SparePartsFlow();
				SparePartsList mtbList = new SparePartsList(GetCompany());

				flowMTB.FillMTBList(mtbList);
				flowMTB = null;

				string[] items;
				string[] itemData;

				items = new string[mtbList.Count];
				itemData = new string[mtbList.Count];

				SpareParts spareParts;

				for(int i=0; i<mtbList.Count; i++)
				{					
					items[i] = ((DualFieldBase)mtbList.BaseGet(i)).AName.Thai;
					itemData[i] = ((DualFieldBase)mtbList.BaseGet(i)).Code;

					spareParts = (SpareParts)mtbList.BaseGet(i);
					sparePartsList.Add(spareParts.AName.Thai, spareParts);
				}

				ComboBoxCellType comboBox = new ComboBoxCellType();
				comboBox.Items = items;
				comboBox.ItemData = itemData;

				items = null;
				itemData = null;

				return comboBox;			
			}
		}	

			public ComboBoxCellType DataSourceExpenseStatus
			{
				get
				{
					string[] items = {"ประกันจ่าย", "พัฒนาไทยจ่าย"};
					ComboBoxCellType comboBox = new ComboBoxCellType();
					comboBox.Items = items;
					items = null;
					return comboBox;			
				}
			}		
		#endregion

		protected VehicleRepairingFlowBase flowRepairingBase;

		protected VehicleRepairingBase vehicleRepairing;
		public VehicleRepairingBase VehicleRepairing
		{
			get
			{
				return vehicleRepairing;
			}
			set
			{
				vehicleRepairing = value;
			}
		}

		//============================== Constructor ==============================
		protected VehicleRepairingFacadeBase() : base()
		{
			flowAge = new AgeFlow();
			flowVehicle = new VehicleFlow();
			flowContract = new ContractFlow();

			sparePartsList = new SparePartsList(GetCompany());
		}

		#region - Private Method - 
		#endregion

		//============================== Public Method ==============================
		#region - public Method -
			public int GetMaxMileage(DateTime date, RepairingBase condition)
			{
				return flowRepairingBase.GetMaxMileage(vehicleRepairing.AVehicleInfo, date, GetCompany(), condition);
			}

			public bool ValidateServiceStaft(string employeeNo)
			{
				ServiceStaffFlow flowServiceStaff = new ServiceStaffFlow();
				bool result = (flowServiceStaff.GetFormerlyServiceStaff(employeeNo, GetCompany()) != null);
				flowServiceStaff = null;
				return result;
			}

			public VehicleAssignment GetVehicleAssignmentOnTime(VehicleInfo aVehicleInfo, DateTime formDate, DateTime toDate)
			{
				return flowRepairingBase.GetVehicleAssignmentOnTime(aVehicleInfo, formDate, toDate, GetCompany());
			}

			public YearMonth CalculateAge(DateTime value)
			{
				return flowAge.CalculateAge(value);
			}

			public DocumentNo GetDocumentNo()
			{
				DocumentNoFlow flowDocumentNo = new DocumentNoFlow();
				DocumentNo documentNo = flowDocumentNo.GetContractRunningNo(documentType, GetCompany());
				flowDocumentNo = null;
				return documentNo;
			}

			public SpareParts GetSpareParts(string name)
			{
				return sparePartsList[name];
			}

			public VATRate GetVATRate()
			{
				return VehicleFunction.GetVATRate();
			}

			public VehicleInfo GetVehicleInfo(int vehicleNo)
			{
				return flowVehicle.GetVehicleInfo(vehicleNo, GetCompany());
			}

			public bool FillVehicle(string platePrefix, string plateNo)
			{
				VehicleInfo vehicleInfo = new VehicleInfo();
				vehicleInfo.PlatePrefix = platePrefix;
				vehicleInfo.PlateRunningNo = plateNo;
				if(flowVehicle.FillVehicleInfo(ref vehicleInfo, GetCompany()))
				{
					vehicleRepairing.AVehicleInfo = vehicleInfo;
					vehicleInfo = null;
					return true;
				}
				else
				{
					vehicleInfo = null;
					return false;
				}
			}
			
			public string GetHirerName(VehicleInfo aVehicleInfo, DateTime formDate, DateTime toDate)
			{
				string hirerName;

				VehicleAssignment vehicleAssignment = flowRepairingBase.GetVehicleAssignmentOnTime(aVehicleInfo, formDate, toDate, GetCompany());
				if(vehicleAssignment != null)
				{
					hirerName = vehicleAssignment.AHirer.Name;
					vehicleAssignment = null;
				}
				else
				{
					hirerName = "";
				}
				return hirerName;
			}

		public VehicleContract GetCurrentVehicleContract(VehicleInfo value)
		{
			return (VehicleContract)flowContract.GetCurrentVehicleContract(value, GetCompany());		
		}

        public bool FillVehicleRepairingHistory(VehicleMaintenance value, Vehicle vehicle)
        {
            return flowRepairingBase.FillVehicleRepairingHistory(value, vehicle);
        }

        public bool FillVehicleRepairingHistory(VehicleMaintenance value, string docNo, string taxNo)
        {
            return flowRepairingBase.FillVehicleRepairingHistory(value, docNo, taxNo);
        }
		#endregion

		public abstract bool Display();
		public abstract bool InsertRepairing(RepairingBase value);
        public abstract bool UpdateRepairing(RepairingBase value);
		public abstract bool DeleteRepairing(RepairingBase value);
	}
}