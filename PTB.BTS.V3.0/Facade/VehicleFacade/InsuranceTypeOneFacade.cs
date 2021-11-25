using System;
using System.Collections;
using System.Data;

using ictus.PIS.PI.Entity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using PTB.BTS.Vehicle.Flow;
using PTB.BTS.Common.Flow;
using PTB.BTS.Contract.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;

namespace Facade.VehicleFacade
{
	public class InsuranceTypeOneFacade : CommonPIFacadeBase
	{
		#region - Private -
		private InsuranceTypeOneFlow flowInsuranceTypeOne;
		private ContractFlow flowContract;
        private VehicleFlow flowVehicle;
		#endregion

//		============================== Property ==============================
		private InsuranceTypeOne objInsuranceTypeOne;
		public InsuranceTypeOne ObjInsuranceTypeOne
		{
			get{return objInsuranceTypeOne;}
			set{objInsuranceTypeOne = value;}
		}

		private InsuranceTypeOne objMoveInsuranceTypeOne;
		public InsuranceTypeOne ObjMoveInsuranceTypeOne
		{
			get{return objMoveInsuranceTypeOne;}
			set{objMoveInsuranceTypeOne = value;}
		}

//		============================== DataSource ==============================
		public ArrayList DataSourceInsuranceCompName
		{
			get
			{
				InsuranceCompanyFlow flowInsuranceCompany = new InsuranceCompanyFlow();
				InsuranceCompanyList insuranceCompanyList = new InsuranceCompanyList(GetCompany());
				flowInsuranceCompany.FillInsuranceCompanyList(ref insuranceCompanyList);
				return insuranceCompanyList.GetArrayList();
			}
		}

//		============================== Constructor ==============================
		public InsuranceTypeOneFacade()
		{
			flowInsuranceTypeOne = new InsuranceTypeOneFlow();
			objInsuranceTypeOne = new InsuranceTypeOne(GetCompany());
			objMoveInsuranceTypeOne = new InsuranceTypeOne(GetCompany());
			flowContract = new ContractFlow();
            flowVehicle = new VehicleFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayInsuranceTypeOne(string policyNo)
		{
			objInsuranceTypeOne = new InsuranceTypeOne(GetCompany());
			objInsuranceTypeOne.AVehicleInsuranceList = new VehicleInsuranceList(GetCompany());
			objInsuranceTypeOne.PolicyNo = policyNo;
			bool result = flowInsuranceTypeOne.FillInsuranceTypeOne(ref objInsuranceTypeOne);
			if(result)
			{
				result &= flowInsuranceTypeOne.FillInsuranceTypeOneDetail(ref objInsuranceTypeOne);
			}
			return result;
		}
		
		public bool DisplayMoveInsuranceTypeOne(string policyNo)
		{
			objMoveInsuranceTypeOne = new InsuranceTypeOne(GetCompany());
			objMoveInsuranceTypeOne.AVehicleInsuranceList = new VehicleInsuranceList(GetCompany());
			objMoveInsuranceTypeOne.PolicyNo = policyNo;
			bool result = flowInsuranceTypeOne.FillInsuranceTypeOne(ref objMoveInsuranceTypeOne);
			if(result)
			{
				flowInsuranceTypeOne.FillInsuranceTypeOneDetail(ref objMoveInsuranceTypeOne);
			}
			return result;
		}

		public void CalculateTotalPremium(VehicleInsuranceTypeOne value)
		{			
			VehicleFunction.CalculateTotalPremium(value, VehicleFunction.GetVATRate().Rate);
		}

		public ContractBase GetCurrentVehicleContract(Vehicle value)
		{
			return flowContract.GetCurrentVehicleContract(value, GetCompany());
		}

        public VehicleInfo GetVehicleInfo(int vehicleNo)
        {
            return flowVehicle.GetVehicleInfo(vehicleNo, GetCompany());
        }
		
		public bool InsertInsuranceTypeOne()
		{
			return flowInsuranceTypeOne.InsertInsuranceTypeOne(objInsuranceTypeOne);
		}

		public bool InsertInsuranceTypeOne(VehicleInsuranceTypeOne value)
		{
			if(flowInsuranceTypeOne.InsertInsuranceTypeOneDetail(value, GetCompany()))
			{
				objInsuranceTypeOne.AVehicleInsuranceList.Add(value);
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public bool UpdateInsuranceTypeOne()
		{
			return flowInsuranceTypeOne.UpdateInsuranceTypeOne(objInsuranceTypeOne, GetCompany());
		}

		public bool UpdateInsuranceTypeOne(VehicleInsuranceTypeOne value)
		{
			if(flowInsuranceTypeOne.UpdateInsuranceTypeOneDetail(value, GetCompany()))
			{
				objInsuranceTypeOne.AVehicleInsuranceList[value.EntityKey] = value;
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public bool DeleteInsuranceTypeOne()
		{
			return flowInsuranceTypeOne.DeleteInsuranceTypeOne(objInsuranceTypeOne, GetCompany());
		}

		public bool DeleteInsuranceTypeOne(VehicleInsuranceTypeOne value)
		{
			if(flowInsuranceTypeOne.DeleteInsuranceTypeOneDetail(value, GetCompany()))
			{
				objInsuranceTypeOne.AVehicleInsuranceList.Remove(value);
				return true;
			}
			else
			{
				return false;
			}
		}

		public VehicleInfo GetVehicleInfo(string platePrefix, string plateRunningNo)
		{
			VehicleFlow vehicleFlow = new VehicleFlow();
            VehicleInfo vehicleInfo = new VehicleInfo();
            vehicleInfo.PlatePrefix = platePrefix;
            vehicleInfo.PlateRunningNo = plateRunningNo;

            if (!vehicleFlow.FillVehicleInfo(ref vehicleInfo, GetCompany()))
			{
                vehicleInfo = null;
			}
			vehicleFlow = null;
            return vehicleInfo;
		}

		public bool CheckDuplicate(VehicleInsuranceTypeOne value)
		{
			return objInsuranceTypeOne.AVehicleInsuranceList.Contain(value);
		}

		public bool CheckOutInsurance(Vehicle value, DateTime startDate, DateTime endDate)
		{
			bool result = true;
			VehicleFlow flowVehicle = new VehicleFlow();
			VehicleList vehicleList = new VehicleList(GetCompany());
			Vehicle vehicle = new Vehicle();
            flowVehicle.FillVehicleOutInsurance(ref vehicleList, startDate, endDate, vehicle);
			if(vehicleList.Contain(value))
			{
				result = false;
			}
			flowVehicle = null;
			vehicleList = null;
			return result;
		}

		public bool ValidOrder(int value)
		{
			for(int i=0; i<objInsuranceTypeOne.AVehicleInsuranceList.Count; i++)
			{
				if(objInsuranceTypeOne.AVehicleInsuranceList[i].OrderNo == value)
				{
					return false;
				}
			}
			return true;
		}
	}
}