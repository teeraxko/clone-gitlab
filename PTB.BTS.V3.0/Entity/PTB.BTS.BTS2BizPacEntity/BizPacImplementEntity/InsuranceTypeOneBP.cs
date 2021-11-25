using System;

using ictus.SystemConnection.BizPac.AP;
using ictus.Common.Entity.General;
using ictus.SystemConnection.BizPac.Core;
using Entity.PTB.BTS.BTS2BizPacEntity;
using System.Collections;
using System.Globalization;

namespace PTB.BTS.BTS2BizPacEntity
{
    public class InsuranceTypeOneBP : Entity.VehicleEntities.InsuranceTypeOne, IBTS2BizPacHeader, IAPHeader
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
            get { return BizPacRemark1; }
            //get { return "Insurance for " + base.aPeriod.From.ToShortDateString() + " - " + base.aPeriod.To.ToShortDateString(); }
        }

        public decimal BTSAmount
        {
            get { return base.Amount; }
        }

        public int BTSCheck
        {
            get { return 1; }
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

        public string BizPacRemark1
        {
            get
            {
                //DocDate input from user : woranai 30/05/2007
                //return "Vehicle Insurance Premium in " + BTS2BizPacCommon.StringMonthYear;
                //return "Vehicle Insurance Premium in " + BTS2BizPacCommon.GetStringMonthYear(_docDateControl);

                //Allow user to input date detail in item : Woranai B. 2009/08/27
                return "Vehicle Insurance Premium in " + BTS2BizPacCommon.GetStringMonthYear(DocDateDetail.Date);

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

        private decimal month1Amount = decimal.Zero;
        public decimal Month1Amount
        {
            get { return month1Amount; }
            set { month1Amount = value; }
        }

        private decimal month2Amount = decimal.Zero;
        public decimal Month2Amount
        {
            get { return month2Amount; }
            set { month2Amount = value; }
        }

        private decimal month3Amount = decimal.Zero;
        public decimal Month3Amount
        {
            get { return month3Amount; }
            set { month3Amount = value; }
        }

        private decimal month4Amount = decimal.Zero;
        public decimal Month4Amount
        {
            get { return month4Amount; }
            set { month4Amount = value; }
        }

        private decimal month5Amount = decimal.Zero;
        public decimal Month5Amount
        {
            get { return month5Amount; }
            set { month5Amount = value; }
        }

        private decimal month6Amount = decimal.Zero;
        public decimal Month6Amount
        {
            get { return month6Amount; }
            set { month6Amount = value; }
        }

        private decimal month7Amount = decimal.Zero;
        public decimal Month7Amount
        {
            get { return month7Amount; }
            set { month7Amount = value; }
        }

        private decimal month8Amount = decimal.Zero;
        public decimal Month8Amount
        {
            get { return month8Amount; }
            set { month8Amount = value; }
        }

        private decimal month9Amount = decimal.Zero;
        public decimal Month9Amount
        {
            get { return month9Amount; }
            set { month9Amount = value; }
        }

        private decimal month10Amount = decimal.Zero;
        public decimal Month10Amount
        {
            get { return month10Amount; }
            set { month10Amount = value; }
        }

        private decimal month11Amount = decimal.Zero;
        public decimal Month11Amount
        {
            get { return month11Amount; }
            set { month11Amount = value; }
        }

        private decimal month12Amount = decimal.Zero;
        public decimal Month12Amount
        {
            get { return month12Amount; }
            set { month12Amount = value; }
        }

        private DateTime _docDateControl = DateTime.Today;
        public DateTime DocDateControl
        {
            set { _docDateControl = value; }
        }

        public DateTime DocDateDetail { get; set; }
    }
}
