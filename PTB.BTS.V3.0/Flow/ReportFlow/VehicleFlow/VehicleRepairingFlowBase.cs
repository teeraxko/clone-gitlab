using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.VehicleEntities;
using Entity.ContractEntities;

using PTB.BTS.Common.Flow;

using DataAccess.VehicleDB;
using DataAccess.ContractDB;

namespace PTB.BTS.Vehicle.Flow
{
	public abstract class VehicleRepairingFlowBase : FlowBase
	{
		protected VehicleRepairingHistoryDB dbVehicleRepairingHistory;
		//==============================  Constructor  ==============================
		public VehicleRepairingFlowBase() : base()
		{
			dbVehicleRepairingHistory = new VehicleRepairingHistoryDB();
		}

		//============================== Public Method ==============================
		public int GetMaxMileage(VehicleInfo value, DateTime date, Company aCompany, RepairingBase condition)
		{
			if(condition==null)
			{
				return dbVehicleRepairingHistory.GetMaxMileage(value, date, aCompany);
			}
			else
			{
				return dbVehicleRepairingHistory.GetMaxMileageExclude(value, date, aCompany, condition);
			}
		}

        public VehicleAssignment GetVehicleAssignmentOnTime(Entity.VehicleEntities.Vehicle aVehicle, DateTime formDate, DateTime toDate, Company aCompany)
		{
			VehicleAssignmentDB dbVehicleAssignment = new VehicleAssignmentDB();
			VehicleAssignment vehicleAssignment = dbVehicleAssignment.GetVehicleAssignmentOnTime(aVehicle, formDate, toDate, aCompany);
			dbVehicleAssignment = null;

			return vehicleAssignment;		
		}

        protected DateTime getMaxRepairDate(RepairingInfoBase value)
        {
            VehicleRepairingHistoryDB dbTempVehicleRepairingHistory = new VehicleRepairingHistoryDB();
            DateTime maxRepairDate = dbTempVehicleRepairingHistory.GetVehicleRepairingHistoryMaxRepairFinish(value);
            dbTempVehicleRepairingHistory = null;

            return maxRepairDate;
        }

        public void FillVehicleRepairingHistory(ref VehicleMaintenance value, Entity.VehicleEntities.Vehicle vehicle)
        {
            dbVehicleRepairingHistory.FillVehicleRepairingHistory(ref value, vehicle);
        }

        public bool FillVehicleRepairingHistory(VehicleMaintenance value, Entity.VehicleEntities.Vehicle vehicle)
        {
            return dbVehicleRepairingHistory.FillVehicleRepairingHistory(value, vehicle);
        }

        public bool FillVehicleRepairingHistory(VehicleMaintenance value, string docNo, string taxNo)
        {
            return dbVehicleRepairingHistory.FillVehicleRepairingHistory(value, docNo, taxNo);
        }
	}
}