using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using PTB.BTS.Vehicle.Flow;

namespace Facade.VehicleFacade
{
	public class VehicleMaintenanceFacade : VehicleRepairingFacadeBase
	{
		private VehicleMaintenanceFlow flowVehicleMaintenance;

		//============================== Constructor ==============================
		public VehicleMaintenanceFacade() : base()
		{
			vehicleRepairing = new VehicleMaintenance(GetCompany());

			flowRepairingBase = new VehicleMaintenanceFlow();
			flowVehicleMaintenance = (VehicleMaintenanceFlow)flowRepairingBase;
			
			documentType = DOCUMENT_TYPE.MAINTENANCE;
		}

		public override bool Display()
		{
			return flowVehicleMaintenance.FillVehicleMaintenance((VehicleMaintenance)vehicleRepairing);
		}

		public override bool InsertRepairing(RepairingBase value)
		{
			if(vehicleRepairing.Contain(value.EntityKey))
			{
				return false;
			}
			else
			{
				if(flowVehicleMaintenance.InsertMaintenance((Maintenance)value))
				{
					vehicleRepairing.Add((Maintenance)value);
					return true;
				}
				else
				{
					return false;					
				}			
			}
		}

		public override bool UpdateRepairing(RepairingBase value)
		{
			if(flowVehicleMaintenance.UpdateMaintenance((Maintenance)value))
			{
				vehicleRepairing[value.EntityKey] = (Maintenance)value;
				return true;
			}
			else
			{
				return false;					
			}
		}

		public override bool DeleteRepairing(RepairingBase value)
		{
			if(flowVehicleMaintenance.DeleteMaintenance((Maintenance)value))
			{
				vehicleRepairing.Remove(value);
				return true;
			}
			else
			{
				return false;					
			}
		}
	}
}