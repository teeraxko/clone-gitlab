using System;
using System.Text;

using Entity.CommonEntity;
using ictus.SystemConnection.BizPac.AP;
using ictus.Common.Entity.General;
using ictus.Common.Entity.Time;
using System.Globalization;

namespace PTB.BTS.BTS2BizPacEntity
{
    public class RepairingBP : Entity.VehicleEntities.RepairingBase, IBTS2BizPacHeader, IAPHeader
    {
        //public static DateTime backDate;

        public RepairingBP()
            : base()
        {
            //YearMonth yearMonth = new YearMonth(DateTime.Today.AddMonths(-1));
            //backDate = yearMonth.MaxDateOfMonth;
        }

        #region IBTS2BizPacHeader Members
        public string DocNo
        {
            get { return repairingNo; }
        }

        public string PaidTo
        {
            get { return garage.AName.Thai; }
        }

        public string PaidToCode
        {
            get 
            {
                if (garage.Code == BizPacFixData.BIZPAC_DUMMY_GARAGE_VAT)
                {
                    if (remark2.Trim() == "")
                    {
                        return VendorCode + "(" + remark1 + ")";
                    }
                    else
                    {
                        return VendorCode + "(" + remark2 + ")";
                    }
                }
                return VendorCode; 
            
            }
        }

        public string AdditionalInfo
        {
            get { return base.taxInvoiceNo; }
        }

        public string AdditionalDate
        {
            get { return base.taxInvoiceDate.ToShortDateString(); }
        }

        public string BTSRemark
        {
            get { return garage.ShortName + " " + Garage.BizPacVendorCode + " " + Garage.BizPacExpenseCode; }
        }

        public decimal BTSAmount
        {
            get { return NetAmount; }
        }

        public int BTSCheck
        {
            get 
            {
                if (base.garage.BizPacVendorCode.Trim() == "")
                {
                    return 0; 
                }
                else
                {
                    if (taxInvoiceStatus == TAX_INVOICE_STATUS_TYPE.YES || taxInvoiceStatus == TAX_INVOICE_STATUS_TYPE.NO)
                    {
                        return 1; 
                    }
                    else
                    {
                        if (this.Garage.BizPacVendorCode == "99")
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }                
            }
        }
        #endregion

        #region IAccountHeader Members
        private string bizPacRefNo = NullConstant.STRING;
        public string BizPacRefNo
        {
            get
            {
                return bizPacRefNo;
            }
            set
            {
                bizPacRefNo = value.Trim();
            }
        }

        private DateTime bizPacRefDate;
        public DateTime BizPacRefDate
        {
            get
            {
                return bizPacRefDate;
            }
            set
            {
                bizPacRefDate = value;
            }
        }

        public int BizPacCount
        {
            get { return 1; }
        }

        public string BusinessPlace
        {
            get { return BizPacFixData.BUSINESS_PLACE; }
        }

        protected string subBizPacRemark1
        {
            get
            {
                // Kriangkrai A. 14/2/2018
                //StringBuilder stringBuilder = new StringBuilder(garage.BizPacExpenseName);
                StringBuilder stringBuilder = new StringBuilder("Spare parts&maintenance");
                stringBuilder.Append(" for ");
                if (singleStatus)
                {
                    stringBuilder.Append(vehicleInfo.PlateNumber);

                    // Kriangkrai A. 14/2/2018
                    //stringBuilder.Append(" ");
                    //stringBuilder.Append(DateTime.Now.ToString("MMM yyyy", CultureInfo.CreateSpecificCulture("en-US")));
                }
                else
                {
                    stringBuilder.Append(maxPlateNo);

                    // Kriangkrai A. 14/2/2018
                    //stringBuilder.Append(maxPlateNo + " And Other");
                    //stringBuilder.Append(" ");
                    //stringBuilder.Append(DateTime.Now.ToString("MMM yyyy", CultureInfo.CreateSpecificCulture("en-US")));
                }
                return stringBuilder.ToString();
            }
        }

        public string BizPacRemark1
        {
            get 
            {
                StringBuilder stringBuilder = new StringBuilder(subBizPacRemark1);
                //Kriangkrai A. 14/2/2018
                //stringBuilder.Append(" in ");
                stringBuilder.Append(" ");
                stringBuilder.Append(BTS2BizPacCommon.GetStringMonthYear(taxInvoiceDate));
 
                return stringBuilder.ToString();            
            }
        }

        public DateTime DocDate
        {
            get { return BizPacRefDate; }
            //get { return BizPacFixData.END_DATE_OF_MONTH; }
        }

        public string DocumentType
        {
            get { return BizPacFixData.DOCUMENT_TYPE_AP; }
        }

        public DateTime DueDate
        {
            get { return BizPacFixData.END_DATE_OF_MONTH; }
        }

        public ictus.SystemConnection.BizPac.Core.IAccountDetail GetDetail(int index)
        {
            BTS2BizPacDetailAP detailAP = new BTS2BizPacDetailAP();
            detailAP.SeqNo = 1;
            detailAP.MiscItemCode = this.Garage.BizPacExpenseCode;
            detailAP.ItemDescription = subBizPacRemark1;
            detailAP.Quantity = 0;
            detailAP.Price = 0;
            detailAP.Amount = BaseAmount;
            detailAP.BusinessUnit = "01";
            return detailAP;
        }

        public string InvoiceType
        {
            get 
            { 
                switch (taxInvoiceStatus)
                {
                    case TAX_INVOICE_STATUS_TYPE.YES : 
                    {
                        return "G";
                    }
                    case TAX_INVOICE_STATUS_TYPE.NO:
                    { 
                        return "S";
                    }
                    default :
                    {
                        return "G";
                    }
                }
            }
        }

        public decimal BaseAmount
        {
            get { return maintenanceAmount; }
        }

        public decimal NetAmount
        {
            get { return totalAmount; }
        }

        public decimal VATAmount
        {
            get { return vatAmount; }
        }

        public string VATCalcType
        {
            get { return BizPacFixData.VAT_CALC_TYPE; }
        }

        public string VATCode
        {
            get 
            {
                if (taxInvoiceStatus == TAX_INVOICE_STATUS_TYPE.YES || taxInvoiceStatus == TAX_INVOICE_STATUS_TYPE.NO)
                { return BizPacFixData.VAT_CODE_AP; }
                else
                { return BizPacFixData.NO_VAT_CODE_AP; }
            }
        }

        public string VATType
        {
            get 
            {
                if (taxInvoiceStatus == TAX_INVOICE_STATUS_TYPE.YES || taxInvoiceStatus == TAX_INVOICE_STATUS_TYPE.NO)
                { return BizPacFixData.VAT_TYPE; }
                else
                { return BizPacFixData.NO_VAT_TYPE; }
            }
        }

        #endregion

        #region IAPHeader Members

        public string VendorCode
        {
            get { return garage.BizPacVendorCode; }
        }

        public DateTime VendorDate
        {
            get { return taxInvoiceDate; }
        }

        public string VendorInvoice
        {
            get { return taxInvoiceNo; }
        }

        public string VendorName
        {
            get
            {
                if (garage.Code == BizPacFixData.BIZPAC_DUMMY_GARAGE_VAT)
                {
                    return remark2;
                }
                else if(garage.Code == BizPacFixData.BIZPAC_DUMMY_GARAGE_NONVAT)
                {
                    if (singleStatus)
                    {
                        return remark2;
                    }
                    else
                    {
                        return maxVender;
                    }
                }
                else
                {
                    return garage.AName.English;
                }
            }
        }

        public bool HaveTaxInvoice 
        {
            get
            {
                if (taxInvoiceStatus == TAX_INVOICE_STATUS_TYPE.YES || taxInvoiceStatus == TAX_INVOICE_STATUS_TYPE.NO)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
        }

        #endregion

        private bool singleStatus = true;
        private decimal maxAmount = 0;
        private string maxPlateNo = string.Empty;
        private string maxVender = string.Empty;

        public void Add(RepairingBP value)
        {
            singleStatus = false;
            maintenanceAmount += value.BaseAmount;
            vatAmount += value.VatAmount;
            totalAmount += value.TotalAmount;

            if (value.TotalAmount > maxAmount)
            {
                maxAmount = value.TotalAmount;
                maxPlateNo = value.vehicleInfo.PlateNumber;
                maxVender = value.remark2;
            }
        }

        //case เงินสด ส่ง BizRefNo และวันที่สิ้นเดือน
        public RepairingBP Clone(string VendorInvoice, DateTime vendorDate)
        {
            taxInvoiceNo = VendorInvoice;
            taxInvoiceDate = vendorDate;
            return Clone();
        }

        public RepairingBP Clone()
        {
            RepairingBP repairingBP = new RepairingBP();
            repairingBP.bizPacRefDate = this.bizPacRefDate;
            repairingBP.bizPacRefNo = this.bizPacRefNo;
            repairingBP.garage = this.garage;
            repairingBP.kindOfVehicle = this.kindOfVehicle;
            repairingBP.maintenanceAmount = this.maintenanceAmount;
            repairingBP.maxAmount = this.maxAmount;
            repairingBP.maxPlateNo = this.maxPlateNo;
            repairingBP.remark1 = this.remark1;
            repairingBP.remark2 = this.remark2;
            repairingBP.repairingNo = this.repairingNo;
            repairingBP.repairingPaymentType = this.repairingPaymentType;
            repairingBP.repairingType = this.repairingType;
            repairingBP.repairPeriod = this.repairPeriod;
            repairingBP.reportDate = this.reportDate;
            repairingBP.taxInvoiceDate = this.taxInvoiceDate;
            repairingBP.taxInvoiceNo = this.taxInvoiceNo;
            repairingBP.taxInvoiceStatus = this.taxInvoiceStatus;
            repairingBP.totalAmount = this.totalAmount;
            repairingBP.vatAmount = this.vatAmount;
            repairingBP.vatStatus = this.vatStatus;
            repairingBP.vehicleInfo = this.vehicleInfo;

            return repairingBP;
        }
    }
}
