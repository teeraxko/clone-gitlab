using System;
using System.Data;
using System.Collections;

using Entity.VehicleEntities;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using PTB.BTS.Common.Flow;
using PTB.BTS.Vehicle.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using ictus.Common.Entity.Time;

namespace Facade.VehicleFacade
{
	public class VehicleTaxByPlateFacade : CommonPIFacadeBase
	{
		#region - Private -
		private AgeFlow flowAge;
		private VehicleTaxFlow flowVehicleTax;
		#endregion - Private -
		
//		============================== Property ==============================
		private VehicleTaxList objVehicleTaxList;
		public VehicleTaxList ObjVehicleTaxList
		{
			get{return objVehicleTaxList;}
		}

//		============================ Constructor ==============================
		public VehicleTaxByPlateFacade()
		{
			flowAge = new AgeFlow();
			flowVehicleTax = new VehicleTaxFlow();
			objVehicleTaxList = new VehicleTaxList(GetCompany());
		}

//      ============================= Calculate Holding Time ====================
		public YearMonth CalculateAge(DateTime value)
		{			
			return flowAge.CalculateAge(value);
		}

//		============================== Public Method ============================
		public bool DisplayVehicleTax(Vehicle value)
		{
			VehicleTax vehicleTax = new VehicleTax();
			vehicleTax.AVehicle = value;
			objVehicleTaxList.Clear();
			return flowVehicleTax.FillVehicleTaxList(ref objVehicleTaxList, vehicleTax, false);
		}

		public bool FillVehicleTax(VehicleTax value)
		{
			return flowVehicleTax.FillVehicleTax(ref value, GetCompany());
		}

		public bool FillBeginVehicleTax(ref VehicleTax value)
		{
			return flowVehicleTax.FillBeginVehicleTax(ref value, GetCompany());
		}

		public bool ValidateVehicleTaxPeriod(TimePeriod value)
		{
			TimePeriod vehicleTaxTimePeriod;
			for(int i=0; i<objVehicleTaxList.Count; i++)
			{
				vehicleTaxTimePeriod = objVehicleTaxList[i].APeriod;
				if(vehicleTaxTimePeriod.To > value.From && vehicleTaxTimePeriod.From < value.To)
				{
					return false;
				}
			}
			return true;
		}

		public VehicleTax GetCurrentVehicleTax(Vehicle value)
		{
			VehicleTax vehicleTax = new VehicleTax();
			vehicleTax.AVehicle = value;													
			if(flowVehicleTax.FillCurrentVehicleTax(ref vehicleTax, GetCompany()))
			{
				return vehicleTax;
			}
			vehicleTax = null;
			return null;
		}

		public Vehicle GetVehicle(string platePrefix, string plateNo)
		{
			VehicleFlow flowVehicle = new VehicleFlow();
			Vehicle vehicle = new Vehicle();
			vehicle.PlatePrefix = platePrefix;
			vehicle.PlateRunningNo = plateNo;
			bool result = flowVehicle.FillVehicleGeneral(ref vehicle, GetCompany());
			flowVehicle = null;
			if(result)
			{
				return vehicle;
			}
			else
			{return null;}
		}

		public void CalculateVehicleTaxAmount(ref VehicleTax value)
		{			
			flowVehicleTax.CalculateVehicleTaxAmount(ref value);
		}

		public bool InsertVehicleTax(VehicleTax value)
		{
			if(objVehicleTaxList.Contain(value))
			{
				return false;
			}
			else
			{
				if(flowVehicleTax.InsertVehicleTax(value, GetCompany()))
				{
					objVehicleTaxList.Add(value);
					return true;
				}
				else
				{return false;}
			}
		}

		public bool UpdateVehicleTax(VehicleTax value)
		{
			if(flowVehicleTax.UpdateVehicleTax(value, GetCompany()))
			{
				objVehicleTaxList[value.EntityKey] = value;
				return true;
			}
			else
			{return false;}
		}

		public bool DeleteVehicleTax(VehicleTax value)
		{
			if(flowVehicleTax.DeleteVehicleTax(value, GetCompany()))
			{
				objVehicleTaxList.Remove(value);
				return true;
			}
			else
			{return false;}
		}
	}
}
