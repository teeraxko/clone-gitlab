using System;
using Entity.VehicleEntities;
using Entity.ContractEntities;

namespace Entity.VehicleEntities.Leasing
{
    public interface IPurchasing
    {
        DocumentNo PurchaseNo
        {
            get;
            set;
        }

        DateTime IssueDate
        {
            get;
            set;
        }

        VehicleInfo VehicleInfo
        {
            get;
            set;
        }

        short Quantity
        {
            get;
            set;
        }

        Vendor Vendor
        {
            get;
            set;
        }

        decimal VehiclePrice
        {
            get;
            set;
        }

        DateTime VendorQuotationDate
        {
            get;
            set;
        }

        Entity.CommonEntity.PURCHAS_STATUS_TYPE PurchasStatus
        {
            get;
            set;
        }
    }
}
