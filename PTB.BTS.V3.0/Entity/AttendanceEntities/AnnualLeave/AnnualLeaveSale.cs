using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class AnnualLeaveSale : EntityBase, IKey
	{
//		==============================   Property    ==============================
		private Employee aEmployee;
		public Employee AEmployee
		{
			get{return aEmployee;}
			set{aEmployee = value;}
		}

		private decimal remainDays;
		public decimal RemainDays
		{
			get{return remainDays;}
			set{remainDays = value;}
		}
		
		private decimal sellDays;
		public decimal SellDays
		{
			get{return sellDays;}
			set{sellDays = value;}
		}

//		==============================  Constructor  ==============================
		public AnnualLeaveSale() : base()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return aEmployee.EntityKey;}
		}
	}
}
