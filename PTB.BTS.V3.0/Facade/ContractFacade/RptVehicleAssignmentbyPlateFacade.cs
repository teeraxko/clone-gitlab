using System;

using Entity.VehicleEntities;

using PTB.BTS.Vehicle.Flow;

using Facade.PiFacade;

namespace Facade.ContractFacade
{
	public class RptVehicleAssignmentbyPlateFacade : CommonPIFacadeBase
	{
		#region - Private -
		private bool disposed = false;
		#endregion - Private -

//		============================== Constructor ==============================
		public RptVehicleAssignmentbyPlateFacade() : base()
		{
		}

//		============================== Public Method ============================
		public Vehicle GetVehicle(string platePrefix, string plateNo)
		{
			bool result = false;
			VehicleFlow flowVehicle = new VehicleFlow();
			Vehicle vehicle = new Vehicle();
			vehicle.PlatePrefix = platePrefix;
			vehicle.PlateRunningNo = plateNo;

			if(flowVehicle.FillVehicleGeneral(ref vehicle, GetCompany()))
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

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						// Dispose object here.
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion
	}
}
