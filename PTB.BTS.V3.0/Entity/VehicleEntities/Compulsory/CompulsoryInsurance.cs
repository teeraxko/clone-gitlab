using System;

using ictus.Common.Entity.General;

namespace Entity.VehicleEntities
{
	public class CompulsoryInsurance : InsuranceDocumentBase, IKey
	{
//		============================== Property ==============================
        protected Vehicle aVehicle;
		public Vehicle AVehicle
		{
			set{aVehicle = value;}
			get{return aVehicle;}
		}

		public decimal CompulsoryInsuranceAmount
		{
			get{return premiumAmount + vatAmount + revenueStampFee;}			
		}

//		============================== Constructor ==============================
		public CompulsoryInsurance() : base()
		{
		}

//		============================== Public Method ==============================
		#region IKey Members
		public override string EntityKey
		{
			get
			{return base.policyNo;}
		}
		#endregion
	}
}
