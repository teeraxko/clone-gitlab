//using System;
//
//using Entity.CommonEntity;
//using ictus.PIS.PI.Entity;
//
//namespace Entity.AttendanceEntities
//{
//	public class OtherBenefitSpecificCondition : OtherBenefitConditionBase, IKey 
//	{
//		#region - Private -
//		private bool disposed = false;
//		#endregion
//
////		============================== Property ==============================
//		private Employee aEmployee;
//		public Employee AEmployee
//		{
//			get
//			{
//				return  aEmployee;
//			}
//			set
//			{ 
//				aEmployee = value;
//			}
//		}
//		
////		============================== Constructor ==============================
//		public OtherBenefitSpecificCondition() : base()
//		{}
//		
////		============================== Public Method ==============================
//		public override string EntityKey
//		{
//			get
//			{
//				return base.EntityKey + aEmployee.EntityKey ;
//			}
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
//						aEmployee.Dispose();
//
//						aEmployee = null;
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
//	}
//}