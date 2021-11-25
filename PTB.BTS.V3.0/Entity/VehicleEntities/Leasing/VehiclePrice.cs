using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.VehicleEntities.Leasing
{
    public class VehiclePrice
    {
        private decimal bodyPrice = decimal.Zero;
        public decimal BodyPrice
        {
            get { return bodyPrice; }
            set { bodyPrice = value; }
        }

        private decimal modifyPrice = decimal.Zero;
        public decimal ModifyPrice
        {
            get { return modifyPrice; }
            set { modifyPrice = value; }
        }

        private decimal otherPrice = decimal.Zero;
        public decimal OtherPrice
        {
            get { return otherPrice; }
            set { otherPrice = value; }
        }

        private string otherPriceDesc = string.Empty;
        public string OtherPriceDesc
        {
            get { return otherPriceDesc; }
            set { otherPriceDesc = value; }
        }

        public decimal TotalVehiclePrice
        {
            get
            {
                return bodyPrice + modifyPrice + otherPrice;
            }
        }
    }
}