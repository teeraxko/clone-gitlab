using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;

using DataAccess.VehicleDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Vehicle.Flow
{
	public class VehicleTaxFlow : FlowBase
	{
		#region - Private -	
		private VehicleTaxDB dbVehicleTax;
		#endregion
		
//		==================================== Constructor =========================
		public VehicleTaxFlow() : base()
		{
			dbVehicleTax = new VehicleTaxDB();
		}
//		==================================== Public Method =======================
		public void CalculateVehicleTaxAmount(ref VehicleTax value)
		{			
			decimal nextYearTaxAmount = 0;
			VehicleTaxDiscountRatioFlow flowVehicleTaxDiscountRatio = new VehicleTaxDiscountRatioFlow();
			VehicleTaxDiscountRatio vehicleTaxDiscountRatio = new VehicleTaxDiscountRatio();

			vehicleTaxDiscountRatio.AModelType = value.AVehicle.AModel.AModelType;
			vehicleTaxDiscountRatio.TaxYear = value.TaxYear;			

			if(flowVehicleTaxDiscountRatio.FillVehicleTaxDiscountRatio(ref vehicleTaxDiscountRatio))
			{
				nextYearTaxAmount = value.TaxAmount*(100 - vehicleTaxDiscountRatio.DiscountPercentage)/100;
			}
			else
			{
				nextYearTaxAmount = value.TaxAmount;
			}

			value.TaxAmount = nextYearTaxAmount;

			vehicleTaxDiscountRatio = null;
		}

		public bool FillVehicleTax(ref VehicleTax value,Company aCompany)
		{
			return dbVehicleTax.FillVehicleTax(ref value, aCompany);
		}

		public bool FillCurrentVehicleTax(ref VehicleTax value, Company aCompany)
		{
			return dbVehicleTax.FillCurrentVehicleTax(ref value, aCompany);
		}

		public bool FillVehicleTaxList(ref VehicleTaxList value, VehicleTax aVehicleTax, bool isOrderBy)
		{
            return dbVehicleTax.FillVehicleTaxList(ref value, aVehicleTax, isOrderBy);
		}
		
		public bool FillBeginVehicleTax(ref VehicleTax value, Company aCompany)
		{
			return dbVehicleTax.FillBeginVehicleTax(ref value, aCompany);
		}

		public bool FillLatestVehicleTaxList(ref VehicleTaxList value, YearMonth yearMonth)
		{
			if(dbVehicleTax.FillLatestVehicleTaxList(ref value, yearMonth))
			{
				string status;
				VehicleTaxList tempList = new VehicleTaxList(value.Company);
				VehicleTax vehicleTax;

				for(int i=0; i<value.Count; i++)
				{
					tempList.Add(value[i]);
				}
			
				for(int i=0; i<tempList.Count; i++)
				{
					vehicleTax = new VehicleTax();
					vehicleTax = tempList[i];
					status = tempList[i].AVehicle.AVehicleStatus.Code;

					if(status == "4" || status == "5" || status == "6")
					{
						value.Remove(vehicleTax);			
					}
				}
				return true;
			}
			return false;
		}

		public bool FillBeginVehicleTaxList(ref VehicleTaxList value, YearMonth yearMonth)
		{
			VehicleTax vehicleTax;

			if(dbVehicleTax.FillLatestVehicleTaxList(ref value, yearMonth))
			{
				for(int i=0; i<value.Count; i++)
				{
					vehicleTax = new VehicleTax();
					vehicleTax.AVehicle = value[i].AVehicle;

					if(dbVehicleTax.FillBeginVehicleTax(ref vehicleTax, value.Company))
					{
						value[i].TaxAmount = vehicleTax.TaxAmount;				
					}						
				}	
				return true;
			}
			return false;
		}

		public bool InsertVehicleTaxList(VehicleTaxList value)
		{
			bool result = true;
			for(int i=0; i<value.Count; i++)
			{
				result &= dbVehicleTax.InsertVehicleTax(value[i], value.Company);
			}
			return result;
		}

		public bool InsertVehicleTax(VehicleTax value, Company aCompany)
		{
			return dbVehicleTax.InsertVehicleTax(value, aCompany);
		}

		public bool UpdateVehicleTax(VehicleTax value,Company aCompany)
		{
			return dbVehicleTax.UpdateVehicleTax(value,aCompany);
		}
		
		public bool DeleteVehicleTax(VehicleTax value,Company aCompany)
		{
			return dbVehicleTax.DeleteVehicleTax(value,aCompany);
		}
	}
}
