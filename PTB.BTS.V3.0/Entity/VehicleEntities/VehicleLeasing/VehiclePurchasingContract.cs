using System;
using System.Collections.Generic;
using System.Text;
using ictus.Framework.ASC.Entity.DNF20;
using Entity.ContractEntities;

namespace Entity.VehicleEntities.VehicleLeasing
{
    public class VehiclePurchasingContract : EntityBase
    {
        public VehiclePurchasing VehiclePurchasing { get; set; }

        public Vehicle Vehicle { get; set; }

        public Contract Contract { get; set; }

        public override string EntityKey
        {
            get { return string.Concat(VehiclePurchasing.EntityKey, Vehicle.EntityKey); }
        }
    }
}
