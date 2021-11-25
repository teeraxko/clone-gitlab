//using System;
//
//using Entity.CommonEntity;
//
//namespace Entity.AttendanceEntities
//{
//	public abstract class OtherBenefitConditionBase : EntityBase, IKey
//	{
//		#region - Private -
//		private bool disposed = false;
//		#endregion
//
////		============================== Private Method ==============================
//		protected WHOLE_RATE_TYPE wholeRate = WHOLE_RATE_TYPE.NULL;
//		public WHOLE_RATE_TYPE WholeRate
//		{			
//			set{wholeRate = value;}
//			get{return wholeRate;}
//		}
//
//		protected decimal baseAmount = NullConstant.DECIMAL;
//		public decimal BaseAmount
//		{
//			set{baseAmount = value;}
//			get{return baseAmount;}
//		}
//
////		============================== Constructor ==============================
//		protected OtherBenefitConditionBase() : base()
//		{
//		}
//
//		#region IDisposable Members
//		protected override void Dispose(bool disposing)
//		{
//			if(!this.disposed)
//			{
//				try
//				{
//					if(disposing)
//					{					
//					}
//					this.disposed = true;
//				}
//				finally
//				{
//					base.Dispose(disposing);
//				}
//			}
//		}
//		#endregion
//
//		#region IKey Members
//			public virtual string EntityKey
//			{
//				get
//				{
//					return null;
//				}
//			}
//		#endregion
//	}
//}