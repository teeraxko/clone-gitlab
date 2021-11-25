using System;
using System.Collections.Generic;
using System.Text;
using Entity.ContractEntities;

namespace Entity.VehicleEntities.VehicleLeasing
{
    public interface IVehiclePurchasing
    {
        DocumentNo PurchaseNo { get; set; }

        Contract Contract { get; set; }

        VehicleInfo VehicleInfo { get; set; }

        DateTime POIssueDate { get; set; }

        Model Model { get; set; }

        Color Color { get; set; }

        short Quantity { get; set; }

        Vendor Vendor { get; set; }

        decimal VehiclePrice { get; set; }

        DateTime VendorQuotationDate { get; set; }

        string PurchaseRemark { get; set; }

        Entity.CommonEntity.PURCHAS_STATUS_TYPE PurchasStatus { get; set; }
    }
}
