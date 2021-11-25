using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class TelephoneCondition : EntityBase, IKey
	{
//		============================== Property ==============================
		private Employee aEmployee;
		public Employee AEmployee
		{
			get{return aEmployee;}
			set{aEmployee = value;}
		}

		private int telephoneRate = NullConstant.INT;
		public int TelephoneRate
		{
			get{return telephoneRate;}
			set{telephoneRate = value;}
		}
		
//		============================== Constructor ==============================
		public TelephoneCondition() : base()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return aEmployee.EntityKey;}
		}
	}
}
