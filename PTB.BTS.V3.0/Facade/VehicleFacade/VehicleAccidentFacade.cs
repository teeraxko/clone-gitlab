using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

using PTB.BTS.Vehicle.Flow;

namespace Facade.VehicleFacade
{
	public class VehicleAccidentFacade : VehicleRepairingFacadeBase
	{
		private VehicleAccidentFlow flowVehicleAccident;

		//============================== Constructor ==============================
		public VehicleAccidentFacade() : base()
		{
			vehicleRepairing = new VehicleAccident(GetCompany());

			flowRepairingBase = new VehicleAccidentFlow();
			flowVehicleAccident = (VehicleAccidentFlow)flowRepairingBase;

			documentType = DOCUMENT_TYPE.ACCIDENT;
		}

		public override bool Display()
		{
			return flowVehicleAccident.FillVehicleAccident((VehicleAccident)vehicleRepairing);
		}

		public bool IsDuplicateWithOtherAccident(Employee employee, YearMonth yearMonth, string accidentNo)
		{
			return flowVehicleAccident.IsDuplicateWithOtherAccident(employee, yearMonth, accidentNo);
		}

		public override bool InsertRepairing(RepairingBase value)
		{
			if(vehicleRepairing.Contain(value.EntityKey))
			{
				return false;
			}
			else
			{
				if(flowVehicleAccident.InsertAccident((Accident)value))
				{
					vehicleRepairing.Add((Accident)value);
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
            if (flowVehicleAccident.UpdateAccident((Accident)value, true))
			{
				vehicleRepairing[value.EntityKey] = (Accident)value;
				return true;
			}
			else
			{
				return false;					
			}
		}

		public override bool DeleteRepairing(RepairingBase value)
		{
			if(flowVehicleAccident.DeleteAccident((Accident)value))
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
