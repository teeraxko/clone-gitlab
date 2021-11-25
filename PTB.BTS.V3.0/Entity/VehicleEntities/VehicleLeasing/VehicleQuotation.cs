using System;
using System.Collections.Generic;
using System.Text;
using Entity.ContractEntities;

namespace Entity.VehicleEntities.VehicleLeasing
{
    public class VehicleQuotation : ictus.Framework.ASC.Entity.DNF20.EntityBase
    {
        public DocumentNo QuotationNo { get; set; }

        public VehiclePurchasing Purchasing { get; set; }

        public VehicleContract VehicleContract { get; set; }

        //public Contract Contract { get; set; }

        public DateTime? ValidityDate { get; set; }

        public DateTime? IssueDate { get; set; }

        public int DeliveryDays { get; set; }

        public bool IsCustomerAccept { get; set; }

        public bool IsSecondHand { get; set; }

        public KindOfVehicle KindOfVehicle { get; set; }

        public decimal BodyCost { get; set; }

        public decimal ModifyCost { get; set; }

        public DateTime? VendorQuotationDate { get; set; }

        public string Remark { get; set; }

        public Entity.CommonEntity.QUOTATION_STATUS_TYPE QuotationStatus { get; set; }

        public override string EntityKey
        {
            get { return QuotationNo.ToString(); }
        }


        //Todsporn Modified 25/2/2020 PO. Discount 
        //add leasing No.

        public string LeasingNo { get; set; }

        public decimal Discount_Amount { get; set; }

        public decimal Discount_Total { get; set; }




        public Vehicle Vehicle
        {
            get
            {
                if (this.VehicleContract != null)
                    if ((this.VehicleContract.AVehicleRoleList != null))
                        if (this.VehicleContract.AVehicleRoleList[0].AVehicle.VehicleNo != -1)
                            return this.VehicleContract.AVehicleRoleList[0].AVehicle;
                        else
                            return null;
                    else
                        return null;
                else
                    return null;
            }
        }

    }
}
