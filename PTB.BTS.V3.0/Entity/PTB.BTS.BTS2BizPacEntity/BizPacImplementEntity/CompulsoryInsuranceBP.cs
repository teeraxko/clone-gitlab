using System;

using ictus.SystemConnection.BizPac.AP;
using ictus.SystemConnection.BizPac.Core;
using Entity.PTB.BTS.BTS2BizPacEntity;
using System.Globalization;
using ictus.Common.Entity.Time;

namespace PTB.BTS.BTS2BizPacEntity
{
    public class CompulsoryInsuranceBP : Entity.VehicleEntities.CompulsoryInsurance, IBTS2BizPacHeader, IAPHeader
    {
        #region IBTS2BizPacHeader Members

        public string DocNo
        {
            get { return policyNo; }
        }

        public string PaidTo
        {
            get { return aInsuranceCompany.AName.English; }
        }

        public string PaidToCode
        {
            get { return VendorCode; }
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
            get { return base.aVehicle.PlateNumber; }
        }

        public decimal BTSAmount
        {
            get { return base.Amount; }
        }

        public int BTSCheck
        {
            get 
            {
                YearMonth yearMonth = new YearMonth(DateTime.Today);
                DateTime endDate = yearMonth.MaxDateOfMonth;

                if (this.APeriod.From <= endDate && endDate <= this.APeriod.To)
                { 
                    return 1; 
                }
                else
                {
                    return 0; 
                }
            }
        }
        #endregion

        #region IAccountHeader Members

        public decimal BaseAmount
        {
            get { return base.premiumAmount + base.revenueStampFee; }
        }

        public int BizPacCount
        {
            get { return 2; }
        }

        private string bizPacRefNo = string.Empty;
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

        //public string BizPacRemark1
        //{
        //    get
        //    {
        //        //return "Compulsory Insurance Premium in " + BTS2BizPacCommon.StringMonthYear;
        //        //return "Compulsory Insurance Premium in " + BTS2BizPacCommon.GetStringMonthYear(_docDateControl);

        //        //Allow user to input date detail in item : Woranai B. 2009/08/17
        //        return "Compulsory Insurance Premium in " + BTS2BizPacCommon.GetStringMonthYear(DocDateDetail.Date);
        //    }
        //}

        // 6/2/2018 Kriangkrai A. Change transfer data to SAP
        public string BizPacRemark1
        {
            get
            {
                return "Compulsory Ins. Premium {0}" + BTS2BizPacCommon.GetStringMonthYear(DocDateDetail.Date);
            }
        }

        public string BusinessPlace
        {
            get { return BizPacFixData.BUSINESS_PLACE; }
        }

        public string DocumentType
        {
            get { return BizPacFixData.DOCUMENT_TYPE_AP; }
        }

        public DateTime DueDate
        {
            get { return BizPacFixData.END_DATE_OF_MONTH; }
        }

        public DateTime DocDate
        {
            //DocDate input from user : woranai 30/05/2007
            //get { return bizPacRefDate; }
            get { return _docDateControl; }
        }

        private BTS2BizPacDetailList details;
        public BTS2BizPacDetailList Details
        {
            get { return details; }
            set { details = value; }
        }

        public IAccountDetail GetDetail(int index)
        {
            return details[index];
        }

        public string InvoiceType
        {
            get { return "G"; }
        }

        public decimal NetAmount
        {
            get { return base.Amount; }
        }

        public decimal VATAmount
        {
            get { return base.vatAmount; }
        }

        public string VATCalcType
        {
            get { return BizPacFixData.VAT_CALC_TYPE; }
        }

        public string VATCode
        {
            get { return BizPacFixData.VAT_CODE_AP; }
        }

        public string VATType
        {
            get { return BizPacFixData.VAT_TYPE; }
        }

        #endregion

        #region IAPHeader Members

        public bool HaveTaxInvoice
        {
            get { return true; }
        }

        public string VendorCode
        {
            get { return base.aInsuranceCompany.Code; }
        }

        public DateTime VendorDate
        {
            get { return base.taxInvoiceDate; }
        }

        public string VendorInvoice
        {
            get { return base.taxInvoiceNo; }
        }

        public string VendorName
        {
            get { return base.aInsuranceCompany.AName.English; }
        }

        #endregion

        private int year1Days = 0;
        public int Year1Days
        {
            get { return year1Days; }
            set { year1Days = value; }
        }

        private decimal year1Amount = decimal.Zero;
        public decimal Year1Amount
        {
            set { year1Amount = value; }
            get { return year1Amount; }
        }

        private int year2Days = 0;
        public int Year2Days
        {
            set { year2Days = value; }
            get { return year2Days; }
        }

        private decimal year2Amount = decimal.Zero;
        public decimal Year2Amount
        {
            set { year2Amount = value; }
            get { return year2Amount; }
        }

        private DateTime _docDateControl = DateTime.Today;
        public DateTime DocDateControl
        {
            set { _docDateControl = value; }
        }

        public DateTime DocDateDetail { get; set; }

        // 6/2/2018 Kriangkrai A.
        public DateTime PostingDate { get; set; }
    }
}
