using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.VehicleEntities
{
	public class VehicleTaxDiscountRatio : EntityBase, IKey
	{
//		============================== Property ==============================
		private int taxYear = NullConstant.INT;
		public int TaxYear
		{
			set{taxYear = value;}
			get{return taxYear;}
		}

		private int discountPercentage = NullConstant.INT;
		public int DiscountPercentage
		{
			set{discountPercentage = value;}
			get{return discountPercentage;}
		}

		private ModelType aModelType;
		public ModelType AModelType
		{
			set{aModelType = value;}
			get{return aModelType;}
		}

//		===============================Constructor=========================
		public VehicleTaxDiscountRatio() : base()
		{}

		#region IKey Members

		public override string EntityKey
		{
			get
			{
				// TODO:  Add VehicleTaxDiscountRatio.EntityKey getter implementation
				return null;
			}
		}

		#endregion
	}
}
