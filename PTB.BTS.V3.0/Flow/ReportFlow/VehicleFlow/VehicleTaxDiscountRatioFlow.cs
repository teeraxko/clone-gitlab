using System;

using Entity.VehicleEntities;

using DataAccess.VehicleDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Vehicle.Flow
{
	public class VehicleTaxDiscountRatioFlow : FlowBase
	{
		#region - Private -	
		private VehicleTaxDiscountRatioDB dbVehicleTaxDiscountRatio;
		#endregion

//		==================================== Constructor =========================
		public VehicleTaxDiscountRatioFlow() : base()
		{
			dbVehicleTaxDiscountRatio = new VehicleTaxDiscountRatioDB();
		}

//		==================================== Public Method =======================
		public bool FillVehicleTaxDiscountRatio(ref VehicleTaxDiscountRatio value)
		{
			return dbVehicleTaxDiscountRatio.FillVehicleTaxDiscountRatio(ref value);
		}

		public bool InsertVehicleTaxDiscountRatio(VehicleTaxDiscountRatio value)
		{
			return dbVehicleTaxDiscountRatio.InsertVehicleTaxDiscountRatio(value);
		}

		public bool UpdateVehicleTaxDiscountRatio(VehicleTaxDiscountRatio value)
		{
			return dbVehicleTaxDiscountRatio.UpdateVehicleTaxDiscountRatio(value);
		}
		
		public bool DeleteVehicleTaxDiscountRatio(VehicleTaxDiscountRatio value)
		{
			return dbVehicleTaxDiscountRatio.DeleteVehicleTaxDiscountRatio(value);
		}
	}
}
