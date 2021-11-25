using System;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

namespace Entity.VehicleEntities
{
	public class Accident : RepairingInfoBase, IKey
	{
//		============================== Property ==============================
		protected DateTime happenTime = NullConstant.DATETIME;
		public DateTime HappenTime
		{
			set{happenTime = value;}
			get{return happenTime;}
		}

        protected string detailOfAccident1 = NullConstant.STRING;
		public string DetailOfAccident1
		{			
			set{detailOfAccident1 = value.Trim();}
			get{return detailOfAccident1;}
		}

        protected string detailOfAccident2 = NullConstant.STRING;
		public string DetailOfAccident2
		{
			set{detailOfAccident2 = value.Trim();}
			get{return detailOfAccident2;}			
		}

        protected string detailOfAccident3 = NullConstant.STRING;
		public string DetailOfAccident3
		{
			set{detailOfAccident3 = value.Trim();}
			get{return detailOfAccident3;}			
		}

        protected string detailOfAccident4 = NullConstant.STRING;
		public string DetailOfAccident4
		{
			set{detailOfAccident4 = value.Trim();}
			get{return detailOfAccident4;}			
		}

        protected Place accidentPlace;
		public Place AccidentPlace
		{
			set{accidentPlace = value;}
			get{return accidentPlace;}			
		}

        protected PoliceStation aPoliceStation;
		public PoliceStation APoliceStation
		{
			set{aPoliceStation = value;}
			get{return aPoliceStation;}
		}

        protected string policemanName = NullConstant.STRING;
		public string PolicemanName
		{			
			set{policemanName = value.Trim();}
			get{return policemanName;}
		}

        protected bool hasClaimnant;
		public bool HasClaimnant
		{
			set{hasClaimnant = value;}
			get{return hasClaimnant;}			
		}

        protected bool frontGlassBroken;
		public bool FrontGlassBroken
		{
			set{frontGlassBroken = value;}
			get{return frontGlassBroken;}			
		}

        protected bool hasExcess;
		public bool HasExcess
		{
			set{hasExcess = value;}
			get{return hasExcess;}			
		}

        protected decimal actualExcessAmount = decimal.Zero;
        public decimal ActualExcessAmount
        {
            set { actualExcessAmount = value; }
            get { return actualExcessAmount; }
        }

        protected decimal excessTotalAmount = decimal.Zero;
		public decimal ExcessTotalAmount
		{
			set{excessTotalAmount = value;}
			get{return excessTotalAmount;}			
		}

        protected decimal excessPaidAmount = decimal.Zero;
		public decimal ExcessPaidAmount
		{
			set{excessPaidAmount = value;}
			get{return excessPaidAmount;}			
		}

        protected decimal excessRemainAmount = decimal.Zero;
		public decimal ExcessRemainAmount
		{
			set{excessRemainAmount = value;}
			get{return excessRemainAmount;}			
		}

        protected decimal damagePercentage = decimal.Zero;
		public decimal DamagePercentage
		{
			set{damagePercentage = value;}
			get{return damagePercentage;}			
		}

        protected PAYER_TYPE aPayer = PAYER_TYPE.NULL;
		public PAYER_TYPE APayer
		{
			set{aPayer = value;}
			get{return aPayer;}			
		}

        protected DriverExcessDeduction aDriverExcessDeduction;
		public DriverExcessDeduction ADriverExcessDeduction
		{
			set{aDriverExcessDeduction = value;}
			get{return aDriverExcessDeduction;}			
		}

        protected bool paidToInsurance;
		public bool PaidToInsurance
		{
			set{paidToInsurance = value;}
			get{return paidToInsurance;}			
		}

        protected DateTime paidToInsuranceDate = NullConstant.DATETIME;
		public DateTime PaidToInsuranceDate
		{
			set{paidToInsuranceDate = value;}
			get{return paidToInsuranceDate;}			
		}

        protected bool paidToCompanyStatus;
		public bool PaidToCompanyStatus
		{
			set{paidToCompanyStatus = value;}
			get{return paidToCompanyStatus;}			
		}

        protected DateTime paidToCompanyDate = NullConstant.DATETIME;
		public DateTime PaidToCompanyDate
		{
			set{paidToCompanyDate = value;}
			get{return paidToCompanyDate;}			
		}

        protected string insuranceClaimNo = NullConstant.STRING;
		public string InsuranceClaimNo
		{
			set{insuranceClaimNo = value.Trim();}
			get{return insuranceClaimNo;}			
		}

        protected string insuranceReceiptNo = NullConstant.STRING;
		public string InsuranceReceiptNo
		{
            set { insuranceReceiptNo = value.Trim(); }
			get {   return insuranceReceiptNo;  }			
		}

        protected DateTime insuranceReceiptDate = NullConstant.DATETIME;
		public DateTime InsuranceReceiptDate
		{
			set {insuranceReceiptDate = value;}
			get {return insuranceReceiptDate;}			
		}

        protected bool billByInsuranceStatus;
        public bool BillByInsuranceStatus
        {
            set { billByInsuranceStatus = value; }
            get { return billByInsuranceStatus; }
        }

        protected string payToInsuranceBizPacReferenceNo = NullConstant.STRING;
        public string PayToInsuranceBizPacReferenceNo
        {
            set { payToInsuranceBizPacReferenceNo = value.Trim(); }
            get { return payToInsuranceBizPacReferenceNo; }
        }

        protected DateTime payToInsuranceBizPacConnectionDate = NullConstant.DATETIME;
        public DateTime PayToInsuranceBizPacConnectionDate
        {
            set { payToInsuranceBizPacConnectionDate = value; }
            get { return payToInsuranceBizPacConnectionDate; }
        }

        protected string payToCompanyBizPacReferenceNo = NullConstant.STRING;
        public string PayToCompanyBizPacReferenceNo
        {
            set { payToCompanyBizPacReferenceNo = value.Trim(); }
            get { return payToCompanyBizPacReferenceNo; }
        }

        protected DateTime payToCompanyBizPacConnectionDate = NullConstant.DATETIME;
        public DateTime PayToCompanyBizPacConnectionDate
        {
            set { payToCompanyBizPacConnectionDate = value; }
            get { return payToCompanyBizPacConnectionDate; }
        }

        protected string latestAccidentUpdateUser = NullConstant.STRING;
        public string LatestAccidentUpdateUser
        {
            set { latestAccidentUpdateUser = value.Trim(); }
            get { return latestAccidentUpdateUser; }
        }

        protected DateTime latestAccidentUpdateDate = NullConstant.DATETIME;
        public DateTime LatestAccidentUpdateDate
        {
            set { latestAccidentUpdateDate = value; }
            get { return latestAccidentUpdateDate; }
        }

        protected InsuranceCompany aInsuranceCompany;
        public virtual InsuranceCompany AInsuranceCompany
        {
            set { aInsuranceCompany = value; }
            get { return aInsuranceCompany; }
        }

//		============================== Constructor ==============================
        public Accident(ictus.Common.Entity.Company value)
            : base(value)
		{
			aDriverExcessDeduction = new DriverExcessDeduction(value);
			aDriverExcessDeduction.AAccident = this;
			aPoliceStation = new PoliceStation();
			accidentPlace = new Place();
		}
	}
}
