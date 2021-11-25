//using System;
//
//using Entity.CommonEntity;
//
//using ictus.PIS.PI.Entity;
//using Entity.ContractEntities;
//
//namespace Entity.AttendanceEntities 	
//{
//	public class OtherBenefitGeneralCondition : OtherBenefitConditionBase,IKey	
//	{
//		#region - Private -
//		private bool disposed = false;
//		#endregion
//
////		============================== Property ==============================
//		private Position aPosition;
//		public Position APosition
//		{			
//			set{ aPosition = value;}
//			get{return  aPosition;}
//		}
//
//		private Customer aCustomer;
//		public Customer ACustomer
//		{			
//			set{aCustomer = value;}
//			get{return aCustomer;}
//		}
//
////		============================== Constructor ==============================
//		public OtherBenefitGeneralCondition() : base()
//		{
//			aPosition = new Position();
//			aCustomer = new Customer();
//		}
//
////		============================== Public Method ==============================
//		public override string EntityKey
//		{
//			get
//			{
//				return aPosition.EntityKey + aCustomer.EntityKey;
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
//						aPosition.Dispose();
//						aCustomer.Dispose();
//
//						aPosition = null;
//						aCustomer = null;
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
