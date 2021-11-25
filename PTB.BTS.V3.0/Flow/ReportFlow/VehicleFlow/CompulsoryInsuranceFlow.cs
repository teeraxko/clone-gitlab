using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using DataAccess.CommonDB;
using DataAccess.VehicleDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace PTB.BTS.Vehicle.Flow
{
	public class CompulsoryInsuranceFlow : FlowBase
	{
		#region - Private -	
		private CompulsoryInsuranceDB dbCompulsoryInsurance;
		#endregion
		
		//==================================== Constructor ====================================
		public CompulsoryInsuranceFlow():base()
		{
			dbCompulsoryInsurance = new CompulsoryInsuranceDB();
		}

		//==================================== Public Method ====================================
		public bool FillCompulsoryInsurance(ref CompulsoryInsurance value,Company aCompany)
		{
			return dbCompulsoryInsurance.FillCompulsoryInsurance(ref value,aCompany);
		}

		public bool FillCurrentCompulsoryInsurance(ref CompulsoryInsurance value,Company aCompany)
		{
			return dbCompulsoryInsurance.FillCurrentCompulsoryInsurance(ref value,aCompany);
		}

		public bool FillCompulsoryInsuranceList(ref CompulsoryInsuranceList value, CompulsoryInsurance compulsoryInsurance)
		{
			return dbCompulsoryInsurance.FillCompulsoryInsuranceList(ref value, compulsoryInsurance);
		}

		public bool FillCompulsoryInsuranceList(ref CompulsoryInsuranceList value, YearMonth yearMonth)
		{
			return dbCompulsoryInsurance.FillLatestCompulsoryInsuranceList(ref value, yearMonth);
		}

		public bool InsertCompulsoryInsurance(CompulsoryInsurance value,Company aCompany)
		{
			return dbCompulsoryInsurance.InsertCompulsoryInsurance(value,aCompany);
		}

		public bool InsertCompulsoryInsuranceList(CompulsoryInsuranceList value)
		{
			bool result = true;
			for(int i=0; i<value.Count; i++)
			{
				result &= dbCompulsoryInsurance.InsertCompulsoryInsurance(value[i], value.Company);
			}
			return result;
		}

		public bool UpdateCompulsoryInsurance(CompulsoryInsurance value,Company aCompany)
		{
			return dbCompulsoryInsurance.UpdateCompulsoryInsurance(value,aCompany);
		}
		
		public bool DeleteCompulsoryInsurance(CompulsoryInsurance value,Company aCompany)
		{
			return dbCompulsoryInsurance.DeleteCompulsoryInsurance(value,aCompany);
		}
	}
}

#region - Old data -
//		public bool FillLatestCompulsoryInsuranceList(ref CompulsoryInsuranceList value, Vehicle conditionVehicle)
//		{
//			bool result = false;
//			CompulsoryInsurance compulsoryInsurance;
//			VehicleDB dbVehicle = new VehicleDB();
//			VehicleList vehicleList = new VehicleList(value.Company);
//
//			if(dbVehicle.FillVehicleList(ref vehicleList, conditionVehicle))
//			{
//				for(int i=0; i<vehicleList.Count; i++)
//				{
//					compulsoryInsurance = dbCompulsoryInsurance.GetLatestCompulsoryInsurance(vehicleList[i], value.Company);
//
//					if(compulsoryInsurance != null)
//					{
//						value.Add(compulsoryInsurance);
//						result = true;
//					}
//				}
//			}
//			return result;
//		}
#endregion