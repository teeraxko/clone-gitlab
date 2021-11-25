using System;

namespace Entity.VehicleEntities.Leasing
{
    public class VehicleCost
    {
        public VehicleCost()
        {
        }

        private VehiclePrice vehiclePrice;
        public VehiclePrice VehiclePrice
        {
            get { return vehiclePrice; }
            set { vehiclePrice = value; }
        }

        private DateTime vendorQuotaionDate;
        public DateTime VendorQuotaionDate
        {
            get { return vendorQuotaionDate; }
            set { vendorQuotaionDate = value; }
        }

        private decimal capitalInsurance = decimal.Zero;
        public decimal CapitalInsurance
        {
            get { return capitalInsurance; }
            set { capitalInsurance = value; }
        }

        private decimal insurancePremium = decimal.Zero;
        public decimal InsurancePremium
        {
            get { return insurancePremium; }
            set { insurancePremium = value; }
        }

        private decimal vehicleRegister = decimal.Zero;
        public decimal VehicleRegister
        {
            get { return vehicleRegister; }
            set { vehicleRegister = value; }
        }

        private decimal maintenanceCharge = decimal.Zero;
        public decimal MaintenanceCharge
        {
            get { return maintenanceCharge; }
            set { maintenanceCharge = value; }
        }

        public decimal TotalVehiclePrice
        {
            get
            {
                return vehiclePrice.TotalVehiclePrice;
            }
        }
    }
}