using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.AttendanceEntities;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity;

namespace Entity.VehicleEntities
{
    public class RepairingBase : EntityBase, IKey
    {
        //============================== Constructor ==============================
        public RepairingBase() : base()
        {
            repairPeriod = new TimePeriod();
            vatStatus = new VehicleVatStatus();
        }

        //============================== Property ==============================
        protected string repairingNo;
        public string RepairingNo
        {
            get { return repairingNo; }
            set { repairingNo = value; }
        }

        protected REPAIRING_TYPE repairingType = REPAIRING_TYPE.NULL;
        public REPAIRING_TYPE RepairingType
        {
            get { return repairingType; }
            set { repairingType = value; }
        }

        protected DateTime reportDate = NullConstant.DATETIME;
        public DateTime ReportDate
        {
            get { return reportDate; }
            set { reportDate = value; }
        }

        protected VehicleInfo vehicleInfo;
        public VehicleInfo VehicleInfo
        {
            set { vehicleInfo = value; }
            get { return vehicleInfo; }
        }

        protected KindOfVehicle kindOfVehicle;
        public KindOfVehicle KindOfVehicle
        {
            get { return kindOfVehicle; }
            set { kindOfVehicle = value; }
        }

        protected Garage garage;
        public Garage Garage
        {
            get { return garage; }
            set { garage = value; }
        }

        protected TimePeriod repairPeriod;
        public TimePeriod RepairPeriod
        {
            get { return repairPeriod; }
            set { repairPeriod = value; }
        }

        protected PaymentType repairingPaymentType;
        public PaymentType RepairingPaymentType
        {
            get { return repairingPaymentType; }
            set { repairingPaymentType = value; }
        }

        protected VehicleVatStatus vatStatus;
        public VehicleVatStatus VatStatus
        {
            get { return vatStatus; }
            set { vatStatus = value; }
        }

        protected decimal maintenanceAmount = NullConstant.DECIMAL;
        public decimal MaintenanceAmount
        {
            get { return maintenanceAmount; }
            set { maintenanceAmount = value; }
        }

        protected decimal vatAmount = NullConstant.DECIMAL;
        public decimal VatAmount
        {
            get { return vatAmount; }
            set { vatAmount = value; }
        }

        protected decimal totalAmount = NullConstant.DECIMAL;
        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }

        protected TAX_INVOICE_STATUS_TYPE taxInvoiceStatus = TAX_INVOICE_STATUS_TYPE.NULL;
        public TAX_INVOICE_STATUS_TYPE TaxInvoiceStatus
        {
            get { return taxInvoiceStatus; }
            set { taxInvoiceStatus = value; }
        }

        protected string taxInvoiceNo = NullConstant.STRING;
        public string TaxInvoiceNo
        {
            get { return taxInvoiceNo; }
            set { taxInvoiceNo = value; }
        }

        protected DateTime taxInvoiceDate = NullConstant.DATETIME;
        public DateTime TaxInvoiceDate
        {
            get { return taxInvoiceDate; }
            set { taxInvoiceDate = value; }
        }

        protected string remark1 = NullConstant.STRING;
        public string Remark1
        {
            get { return remark1; }
            set { remark1 = value; }
        }

        protected string remark2 = NullConstant.STRING;
        public string Remark2
        {
            get { return remark2; }
            set { remark2 = value; }
        }

        //============================== Public method ==============================
        public override string EntityKey
        {
            get { return repairingNo.ToString(); }
        }
    }
}
