using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.VehicleEntities.VehicleLeasing
{
    public class VehiclePurchasing : ictus.Framework.ASC.Entity.DNF20.EntityBase
    {
        public Entity.ContractEntities.DocumentNo PurchasNo { get; set; }

        public DateTime IssueDate { get; set; }

        public Model Model { get; set; }

        public Color Color { get; set; }

        public int Quantity { get; set; }

        public Vendor Vendor { get; set; }

        public decimal VehiclePrice { get; set; }

        public DateTime? VendorQuotationDate { get; set; }

        public string Remark { get; set; }

        public Entity.CommonEntity.PURCHAS_STATUS_TYPE PurchaseStatus { get; set; }

        public bool IsNewCar { get; set; }

        //Todsporn Modified 25/2/2020 PO. Discount

        public decimal Discount_Amount { get; set; }

        public decimal Discount_Total { get; set; }

        public override string EntityKey
        {
            get { return PurchasNo.ToString(); }
        }
    }
}
