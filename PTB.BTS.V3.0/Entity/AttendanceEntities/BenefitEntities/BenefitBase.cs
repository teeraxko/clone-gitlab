using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class BenefitBase : EntityBase, IKey
	{
		//============================== Property ==============================
		protected DateTime benefitDate;
		public DateTime BenefitDate
		{
			get{return benefitDate;}
		}

		//============================== Constructor ==============================
		public BenefitBase(DateTime value)
		{
			benefitDate = value;
		}

		//============================== Public Method ==============================
		#region IKey Members
		public override string EntityKey
		{
			get{return benefitDate.ToShortDateString();}
		}
		#endregion
	}
}