using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;
using Entity.ContractEntities;

namespace Entity.AttendanceEntities
{
	public class TaxiFamilyCarCondition : EntityBase, IKey
	{
//		============================== Property ==============================
		private CustomerGroup aCustomerGroup;
		public CustomerGroup ACustomerGroup
		{
			set{aCustomerGroup = value;}
			get{return aCustomerGroup;}
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

		private DateTime untilTimeInForCharge = NullConstant.DATETIME;
		public DateTime UntilTimeInForCharge
		{
			get{return untilTimeInForCharge;}
			set{untilTimeInForCharge = value;}
		}

		private DateTime sinceTimeOutForCharge = NullConstant.DATETIME;
		public DateTime SinceTimeOutForCharge
		{
			get{return sinceTimeOutForCharge;}
			set{sinceTimeOutForCharge = value;}
		}


//		============================== Constructor ==============================
		public TaxiFamilyCarCondition() : base()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return aCustomerGroup.EntityKey;}
		}
	}
}
