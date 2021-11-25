using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using Entity.ContractEntities;

namespace Entity.AttendanceEntities
{
	public class TaxiPositionCarCondition : EntityBase, IKey
	{
//		============================== Property ==============================
		private Customer aCustomer;
		public Customer ACustomer
		{
			set{aCustomer = value;}
			get{return aCustomer;}
		}
	
		private DateTime untilTimeIn = NullConstant.DATETIME;
		public DateTime UntilTimeIn
		{
			get{return untilTimeIn;}
			set{untilTimeIn = value;}
		}

		private DateTime sinceTimeOut = NullConstant.DATETIME;
		public DateTime SinceTimeOut
		{
			get{return sinceTimeOut;}
			set{sinceTimeOut = value;}
		}
	
//		============================== Constructor ==============================
		public TaxiPositionCarCondition() : base()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return aCustomer.EntityKey;}
		}
	}
}
