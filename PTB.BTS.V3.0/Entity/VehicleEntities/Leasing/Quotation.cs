using System;
using Entity.ContractEntities;
using Entity.CommonEntity;

namespace Entity.VehicleEntities.Leasing
{
    public class Quotation : ictus.Framework.ASC.Entity.DNF20.EntityBase, ictus.Common.Entity.General.IKey, IPurchasing 
    {
        //============================== Constructor ==============================
        public Quotation()
            : base()
        {
            anewVehicle = new AnewVehicle();
        }

        //============================== Property ==============================
        private DocumentNo quotationNo;
        public DocumentNo QuotationNo
        {
            get { return quotationNo; }
            set { quotationNo = value; }
        }

        private AnewVehicle anewVehicle;
        public AnewVehicle AnewVehicle
        {
            get { return anewVehicle; }
            set { anewVehicle = value; }
        }

        private LeasingCalculation leasingCalculation;
        public LeasingCalculation LeasingCalculation
        {
            get { return leasingCalculation; }
            set { leasingCalculation = value; }
        }

        private DateTime lastIssueDate;
        public DateTime LastIssueDate
        {
            get { return lastIssueDate; }
            set { lastIssueDate = value; }
        }

        private DateTime validityDate;
        public DateTime ValidityDate
        {
            get { return validityDate; }
            set { validityDate = value; }
        }

        private short deliveryDays = 0;
        public short DeliveryDays
        {
            get { return deliveryDays; }
            set { deliveryDays = value; }
        }

        private Customer customer;
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private short leaseTerm = 0;
        public short LeaseTerm
        {
            get { return leaseTerm; }
            set { leaseTerm = value; }
        }

        private short quantity = 0;
        public short Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private string poNo = string.Empty;
        public string PONo
        {
            get { return poNo; }
            set { poNo = value.Trim(); }
        }

        private bool isCustomerAccept;
        public bool IsCustomerAccept
        {
            get { return isCustomerAccept; }
            set { isCustomerAccept = value; }
        }

        public KindOfVehicle KindOfVehicle
        {
            get { return anewVehicle.VehicleInfo.AKindOfVehicle; }
            set { anewVehicle.VehicleInfo.AKindOfVehicle = value; }
        }

        private bool driverNeed;
        public bool IsDriverNeed
        {
            get { return driverNeed; }
            set { driverNeed = value; }
        }

        //============================== Public method ==============================
        public override string EntityKey
        {
            get { return this.QuotationNo.ToString(); }
        }



        #region IPurchasing Members        
        private DocumentNo purchaseNo;
        DocumentNo IPurchasing.PurchaseNo
        {
            get { return purchaseNo; }
            set { purchaseNo = value; }
        }

        private DateTime issueDate;
        DateTime IPurchasing.IssueDate
        {
            get { return issueDate; }
            set { issueDate = value; }
        }

        VehicleInfo IPurchasing.VehicleInfo
        {
            get { return anewVehicle.VehicleInfo; }
            set { anewVehicle.VehicleInfo = value; }
        }

        short IPurchasing.Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private Vendor vendor;
        Vendor IPurchasing.Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }

        decimal IPurchasing.VehiclePrice
        {
            get { return anewVehicle.VehicleCost.VehiclePrice.BodyPrice; }
            set { anewVehicle.VehicleCost.VehiclePrice.BodyPrice = value; }
        }

        DateTime IPurchasing.VendorQuotationDate
        {
            get { return anewVehicle.VehicleCost.VendorQuotaionDate; }
            set { anewVehicle.VehicleCost.VendorQuotaionDate = value; }
        }

        private PURCHAS_STATUS_TYPE purchasStatus = PURCHAS_STATUS_TYPE.APPROVE;
        PURCHAS_STATUS_TYPE IPurchasing.PurchasStatus
        {
            get{return purchasStatus;}
            set{purchasStatus = value;}
        }
        #endregion
    }
}