using System;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class ExtraAGTBenefitDeduction : ExtraBenefit, IKey
	{
//		============================== Property ==============================
		private Employee aEmployee;
        public Employee AEmployee
		{
			get{return aEmployee;}
			set{aEmployee = value;}
		}

		private DateTime benefitDate = NullConstant.DATETIME;
		public DateTime BenefitDate
		{
			get{return benefitDate;}
			set{benefitDate = value;}
		}

//		============================== Constructor ==============================
		public ExtraAGTBenefitDeduction() : base()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return base.EntityKey + benefitDate.ToShortDateString();}
		}
	}
}
