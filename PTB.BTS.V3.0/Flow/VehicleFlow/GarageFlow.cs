using System;

using Entity.VehicleEntities;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using DataAccess.VehicleDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Vehicle.Flow
{
	public class GarageFlow : FlowBase
	{
		#region - Private -	
		private GarageDB dbGarage;
		#endregion
		
		//  ================================Constructor=====================
		public GarageFlow():base()
		{
			dbGarage = new GarageDB();
		}
		
		//  ================================public Method=====================
		public bool FillGarageList(ref GarageList aGarageList)
		{
			return dbGarage.FillGarageList(ref aGarageList);
		}

		public bool InsertGarage(Garage value, Company aCompany)
		{
			return dbGarage.InsertGarage(value, aCompany);
		}

		public bool UpdateGarage(Garage value, Company aCompany)
		{
			return dbGarage.UpdateGarage(value, aCompany);
		}

		public bool DeleteGarage(Garage value, Company aCompany)
		{
			return dbGarage.DeleteGarage(value, aCompany);
		}

	}
}
