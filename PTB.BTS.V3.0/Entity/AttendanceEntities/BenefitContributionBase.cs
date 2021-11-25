using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public abstract class BenefitContributionBase : EntityBase, IKey
	{
//		============================== Property ==============================
		protected MiscBenefitDescription aBenefitDescription;
		public MiscBenefitDescription ABenefitDescription
		{
			get{return aBenefitDescription;}
			set{aBenefitDescription = value;}
		}

		protected decimal totalAmount = NullConstant.DECIMAL;
		public decimal TotalAmount
		{
			get{return totalAmount;}
			set{totalAmount = value;}
		}

//		============================== Constructor ==============================
		protected BenefitContributionBase(): base()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return null;}
		}
	}
}
