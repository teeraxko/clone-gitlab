using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using DataAccess.CommonDB;

using ictus.Common.Entity;

namespace PTB.BTS.Vehicle.Flow
{
	public class VehicleFunction
	{
		protected VehicleFunction()
		{
		}

		public static void CalculateTotalPremium(InsuranceDocumentBase value, decimal VATRate)
		{			
			value.RevenueStampFee = 0.004m * value.PremiumAmount;
            value.VatAmount = (value.PremiumAmount + value.RevenueStampFee) * VATRate / 100m;
		}

		public static VATRate GetVATRate()
		{
			VATRateDB dbVATRate = new VATRateDB();
			VATRate vatRate = dbVATRate.GetVATRate();
			dbVATRate = null;
			return vatRate;
		}
	}
}
