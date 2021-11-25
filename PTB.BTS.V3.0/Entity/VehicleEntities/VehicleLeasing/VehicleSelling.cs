using System;
using System.Collections.Generic;
using System.Text;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.VehicleEntities.VehicleLeasing
{
    public class VehicleSelling : EntityBase
    {
        public Vehicle Vehicle { get; set; }

        public DateTime? SellingDate { get; set; }

        public decimal SellingPrice { get; set; }

        public Bidder Bidder { get; set; }

        public DateTime? BVDate { get; set; }

        public decimal BV { get; set; }

        public override string EntityKey
        {
            get { return Vehicle.EntityKey; }
        }
    }
}
