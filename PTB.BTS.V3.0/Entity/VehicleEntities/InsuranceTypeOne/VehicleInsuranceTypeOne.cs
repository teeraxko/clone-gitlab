using System;

using ictus.Common.Entity.General;

namespace Entity.VehicleEntities
{
	public class VehicleInsuranceTypeOne : InsuranceDocumentBase, IKey
	{
//		============================== Property ==============================
        protected int orderNo = NullConstant.INT;
		public int OrderNo
		{
			set{orderNo = value;}
			get{return orderNo;}			
		}

        protected VehicleInfo aVehicleInfo;
        public VehicleInfo AVehicleInfo
		{
			set{aVehicleInfo = value;}
			get{return aVehicleInfo;}			
		}

        protected string insuranceInchargeName = NullConstant.STRING;
		public string InsuranceInchargeName
		{
			set{insuranceInchargeName = value;}
			get{return insuranceInchargeName;}
		}

        protected string insuranceInchargeTelNo = NullConstant.STRING;
		public string InsuranceInchargeTelNo
		{			
			set{insuranceInchargeTelNo = value;}
			get{return insuranceInchargeTelNo;}
		}

        protected DateTime affiliateDate = NullConstant.DATETIME;
		public DateTime AffiliateDate
		{
			set{affiliateDate = value;}
			get{return affiliateDate;}			
		}

        protected decimal sumAssured = NullConstant.DECIMAL;
		public decimal SumAssured
		{			
			set{sumAssured = value;}
			get{return sumAssured;}
		}

//		============================== Constructor ==============================
		public VehicleInsuranceTypeOne() : base()
		{
		}

		#region IKey Members

		public override string EntityKey
		{
			get
			{return aVehicleInfo.VehicleNo.ToString();}
		}

		#endregion
	}
}
