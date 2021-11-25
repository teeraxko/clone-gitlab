using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.VehicleEntities.Leasing
{
    public class VehicleSellingPlan : ictus.Framework.ASC.Entity.DNF20.EntityBase, ictus.Common.Entity.General.IKey
    {
        private VehicleInfo _vehicleInfo = new VehicleInfo();
        public VehicleInfo VehicleInfo
        {
            get { return _vehicleInfo; }
            set { _vehicleInfo = value; }
        }

        private DateTime? _sellingDate;
        public DateTime? SellingDate
        {
            get { return _sellingDate; }
            set { _sellingDate = value; }
        }

        private decimal _estimateSelling = decimal.Zero;
        public decimal EstimateSelling
        {
            get { return _estimateSelling; }
            set { _estimateSelling = value; }
        }

        private DateTime? _bvDate;
        public DateTime? BVDate
        {
            get { return _bvDate; }
            set { _bvDate = value; }
        }

        private decimal _bv = decimal.Zero;
        public decimal BV
        {
            get { return _bv; }
            set { _bv = value; }
        }

        private int _vehicleYear = 0;
        public int VehicleYear
        {
            get { return _vehicleYear; }
            set { _vehicleYear = value; }
        }

        //============================== Public method ==============================
        public override string EntityKey
        {
            get { return VehicleInfo.VehicleNo.ToString(); }
        }
    }
}
