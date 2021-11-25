using System;

using Entity.VehicleEntities;

using PTB.BTS.Common.Flow;

using DataAccess.VehicleDB;

namespace PTB.BTS.Vehicle.Flow
{
	public class BrandFlow : MTBFlowBase
	{
		public BrandFlow() : base()
		{
			dbMTB = new BrandDB();
		}

		public Brand GetBrand(string brandCode)
		{
			return (Brand)dbMTB.GetMTB(brandCode);
		}
	}
}