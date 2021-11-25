using System;
using System.Data;
using System.Collections;

using Entity.VehicleEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;

using PTB.BTS.Vehicle.Flow;
using PTB.BTS.Common.Flow;
using PTB.BTS.Contract.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;

using ictus.Common.Entity;
using ictus.Common.Entity.Time;

namespace Facade.VehicleFacade
{
	public class VehicleFacade : CommonPIFacadeBase
	{
		#region - Private -
			private VehicleFlow flowVehicle;
			private CompulsoryInsuranceFlow flowCompulsoryInsurance;
			private VehicleTaxFlow flowVehicleTax;
			private InsuranceTypeOneFlow flowInsuranceTypeOne;
			private AgeFlow flowAge;
		#endregion
		
//		============================== Property ==============================
		private VehicleList objVehicleList;
		public VehicleList ObjVehicleList
		{
			get{return objVehicleList;}
		}
		private CompulsoryInsurance objCompulsoryInsurance;
		public CompulsoryInsurance ObjCompulsoryInsurance
		{
			get{return objCompulsoryInsurance;}
		}
		private VehicleTax objVehicleTax;
		public VehicleTax ObjVehicleTax
		{
			get{return objVehicleTax;}
		}
		private InsuranceTypeOne objInsuranceTypeOne;
		public InsuranceTypeOne ObjInsuranceTypeOne
		{
			get{return objInsuranceTypeOne;}
		}

//		============================== DataSource ==============================
		#region - DataSource -
		public ArrayList DataSourceProvince
		{
			get
			{
				ProvinceFlow flowProvince = new ProvinceFlow();
				ProvinceList provinceList = new ProvinceList();
				flowProvince.FillMTBList(provinceList);
				return provinceList.GetArrayList();
			}
		}
		public string[] DataSourcePlateStatus
		{
			get
			{
				CTFunction ctFunction = new CTFunction();
				return ctFunction.PlateStatusArray;
			}
		}

		public ArrayList DataSourceModel(Brand value)
		{
			ModelFlow flowModel = new ModelFlow();
			ModelList modelList = new ModelList();
			modelList.ABrand = value;
			flowModel.FillModel(ref modelList);
			flowModel = null;
			return modelList.GetArrayList();
		}

		public ArrayList DataSourceColor
		{
			get
			{
				ColorFlow flowColor = new ColorFlow();
				ColorList colorList = new ColorList();
				flowColor.FillMTBList(colorList);
				return colorList.GetArrayList();
			}
		}
		public ArrayList DataSourceVehicleVatStatus
		{
			get
			{
				VehicleVatStatusFlow flowVehicleVatStatus = new VehicleVatStatusFlow();
				VehicleVatStatusList vehicleVatStatusList = new VehicleVatStatusList(GetCompany());
				flowVehicleVatStatus.FillMTBList(vehicleVatStatusList);
				return vehicleVatStatusList.GetArrayList();
			}
		}
		public ArrayList DataSourceKindOfVehicle
		{
			get
			{
				KindOfVehicleFlow flowKindOfVehicle = new KindOfVehicleFlow();
				KindOfVehicleList kindOfVehicleList = new KindOfVehicleList(GetCompany());

				flowKindOfVehicle.FillMTBList(kindOfVehicleList);
				return kindOfVehicleList.GetArrayList();
			}
		}

		public ArrayList DataSourceVehicleStatus
		{
			get
			{
				VehicleStatusFlow flowVehicleStatus = new VehicleStatusFlow();
				VehicleStatusList vehicleStatusList = new VehicleStatusList(GetCompany());
				flowVehicleStatus.FillMTBList(vehicleStatusList);
				flowVehicleStatus = null;

                VehicleStatus vehicleStatus = new VehicleStatus();
				vehicleStatus.Code = "2";
				vehicleStatusList.Remove(vehicleStatus);
				vehicleStatus.Code = "3";
				vehicleStatusList.Remove(vehicleStatus);

				return vehicleStatusList.GetArrayList();
			}
		}

		public ArrayList DataSourceVehicleStatusAll
		{
			get
			{
				VehicleStatusFlow flowVehicleStatus = new VehicleStatusFlow();
				VehicleStatusList vehicleStatusList = new VehicleStatusList(GetCompany());
				flowVehicleStatus.FillMTBList(vehicleStatusList);
				flowVehicleStatus = null;

				return vehicleStatusList.GetArrayList();
			}
		}

		public ArrayList DataSourceVendor
		{
			get
			{
				VendorFlow flowVendor = new VendorFlow();
				VendorList vendorList = new VendorList(GetCompany());
				flowVendor.FillVendorList(ref vendorList);
				flowVendor = null;
				return vendorList.GetArrayList();
			}
		}
		public ArrayList DataSourceBrand
		{
			get
			{
				BrandFlow flowBrand = new BrandFlow();
				BrandList brandList = new BrandList();
				flowBrand.FillMTBList(brandList);
				return brandList.GetArrayList();
			}
		}
		#endregion

//		============================== Constructor ==============================
		public VehicleFacade() : base()
		{
			flowVehicle = new VehicleFlow();	
			objCompulsoryInsurance = new CompulsoryInsurance();
			flowCompulsoryInsurance = new CompulsoryInsuranceFlow();
			objVehicleTax = new VehicleTax();
			flowVehicleTax = new VehicleTaxFlow();
			objInsuranceTypeOne = new InsuranceTypeOne(GetCompany());
			flowInsuranceTypeOne = new InsuranceTypeOneFlow();
			objVehicleList = new VehicleList(GetCompany());
			flowAge = new AgeFlow();
		}

//		============================== Private Method ==============================
		public YearMonth CalculateAge(DateTime value)
		{
			return flowAge.CalculateAge(value);
		}

		private bool checkDuplicate(VehicleInfo value)
		{
			Vehicle vehicle = new Vehicle();
			vehicle.PlatePrefix = value.PlatePrefix;
			vehicle.PlateRunningNo = value.PlateRunningNo;
			bool result = flowVehicle.FillVehicleGeneral(ref vehicle, GetCompany());

			if(vehicle.VehicleNo == value.VehicleNo)
			{
				result = false;
			}
			vehicle = null;
			return result;
		}

//		============================== Public Method ==============================
		public KindOfVehicle FillKindOfVehicleZ()
		{
			KindOfVehicleFlow flowKindOfVehicle = new KindOfVehicleFlow();
			KindOfVehicleList kindOfVehicleList = new KindOfVehicleList(GetCompany());

			flowKindOfVehicle.FillMTBList(kindOfVehicleList);
			flowKindOfVehicle = null;

			return (KindOfVehicle)kindOfVehicleList["Z"];
		}

		public VehicleInfo GetVehicleInfo(int vehicleNo)
		{
			return flowVehicle.GetVehicleInfo(vehicleNo, GetCompany());
		}

		public bool DisplayVehicleInfo(ref VehicleInfo value)
		{
			return flowVehicle.FillVehicleInfo(ref value, GetCompany());
		}

		public bool DisplayVehicleGeneral(ref Vehicle value)
		{
			return flowVehicle.FillVehicleGeneral(ref value, GetCompany());
		}

		public bool FillCurrentCompulsoryInsurance(ref CompulsoryInsurance value)
		{
			return flowCompulsoryInsurance.FillCurrentCompulsoryInsurance(ref  value, GetCompany());
		}

		public bool FillCurrentVehicleTax(ref VehicleTax value)
		{
			return flowVehicleTax.FillCurrentVehicleTax(ref value, GetCompany());
		}

		public VehicleInsuranceTypeOne GetInsuranceTypeOneDetail(VehicleInfo value, string policyNo)
		{
			VehicleInsuranceTypeOne vehicleInsuranceTypeOne	 = new VehicleInsuranceTypeOne();
			vehicleInsuranceTypeOne.AVehicleInfo = value;
			vehicleInsuranceTypeOne.PolicyNo = policyNo;
			if(flowInsuranceTypeOne.FillInsuranceTypeOneDetail(ref vehicleInsuranceTypeOne, GetCompany()))
			{
				return vehicleInsuranceTypeOne;
			}
			else
			{
				vehicleInsuranceTypeOne = null;
				return null;
			}
		}

		public InsuranceTypeOne GetLatestInsuranceTypeOne(VehicleInfo value)
		{
			return flowInsuranceTypeOne.GetLatestInsuranceTypeOne(value, GetCompany());
		}

		public ContractBase GetCurrentVehicleContract(VehicleInfo value)
		{
			ContractFlow flowContract = new ContractFlow();
			return flowContract.GetCurrentVehicleContract(value, GetCompany());
		}

		public bool InsertVehicle(VehicleInfo value)
		{
			return flowVehicle.InsertVehicle(value, GetCompany());
		}

		public bool UpdateVehicleInfo(VehicleInfo value)
		{
			if (checkDuplicate(value))
			{
				return false;
			}
			else
			{
				return flowVehicle.UpdateVehicleForVehicle(value, GetCompany());
			}
		}

		public bool DeleteVehicle(Vehicle value)
		{
			return flowVehicle.DeleteVehicle(value, GetCompany());
		}

		public static Vehicle GetVehicleByPlateNo(string platePrefix, string plateNo)
		{
			bool result = false;
			VehicleFlow flowVehicle = new VehicleFlow();
			Vehicle vehicle = new Vehicle();
			vehicle.PlatePrefix = platePrefix;
			vehicle.PlateRunningNo = plateNo;

			if(flowVehicle.FillVehicleGeneral(ref vehicle, new VehicleFacade().GetCompany()))
			{
				result = true;
			}
			flowVehicle = null;

			if(result)
			{
				return vehicle;
			}
			else
			{
				vehicle = null;
				return null;
			}
		}
	}
}
