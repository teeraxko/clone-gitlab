using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using Entity.AttendanceEntities;

namespace Entity.VehicleEntities
{
	public abstract class InsuranceDocumentBase : EntityBase, IKey
	{
//		============================== Property ==============================
		protected string policyNo = NullConstant.STRING;
		public virtual string PolicyNo
		{
			set{policyNo = value;}
			get{return policyNo;}
		}

		protected TimePeriod aPeriod;
		public virtual TimePeriod APeriod
		{			
			set{aPeriod = value;}
			get{return aPeriod;}
		}

		protected InsuranceCompany aInsuranceCompany;
        public virtual InsuranceCompany AInsuranceCompany
		{
			set{aInsuranceCompany = value;}
			get{return aInsuranceCompany;}			
		}

		protected decimal premiumAmount = NullConstant.DECIMAL;
        public virtual decimal PremiumAmount
		{
			set{premiumAmount = decimal.Round(value,2);}
			get{return premiumAmount;}			
		}

		protected decimal vatAmount = NullConstant.DECIMAL;
        public virtual decimal VatAmount
		{
			set{vatAmount = decimal.Round(value,2);}
			get{return vatAmount;}			
		}

		protected decimal revenueStampFee = NullConstant.DECIMAL;
        public virtual decimal RevenueStampFee
		{
			set
			{
				revenueStampFee = (decimal)Math.Ceiling(decimal.ToDouble(value));
			}
			get{return revenueStampFee;}			
		}

        public virtual decimal Amount
		{
			get
			{
				return premiumAmount + vatAmount + revenueStampFee;
			}
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

//		============================== Constructor ==============================
		public InsuranceDocumentBase() : base()
		{
			aPeriod = new TimePeriod();
		}

//		============================== Public Method ==============================
		#region IKey Members

		public override string EntityKey
		{
			get
			{return policyNo;}
		}

		#endregion
	}
}
