using System;

namespace Entity.VehicleEntities.Leasing
{
    public class AnewVehicle
    {

        //============================== Constructor ==============================
        public AnewVehicle()
            : base()
        {
            vehicleInfo = new VehicleInfo();
        }

        //============================== Property ==============================
        private VehicleInfo vehicleInfo;
        public VehicleInfo VehicleInfo
        {
            get { return vehicleInfo; }
            set { vehicleInfo = value; }
        }

        private VehicleCost vehicleCost;
        public VehicleCost VehicleCost
        {
            get { return vehicleCost; }
            set { vehicleCost = value; }
        }
    }
}