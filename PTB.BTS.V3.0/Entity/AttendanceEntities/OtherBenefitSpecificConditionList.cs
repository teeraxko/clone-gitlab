//using System;
//
//using ictus.PIS.PI.Entity;
//
//namespace Entity.AttendanceEntities
//{
//	public class OtherBenefitSpecificConditionList : CompanyStuffBase
//	{
//		#region - Private -
//		private bool disposed = false;
//		#endregion
//
////		============================== Property ==============================
//		private MiscBenefitDescription aBenefitDescription;
//		public MiscBenefitDescription ABenefitDescription
//		{			
//			set{ aBenefitDescription = value;}
//			get{return  aBenefitDescription;}
//		}
//
////		============================== Constructor ==============================
//		public OtherBenefitSpecificConditionList(Company company) : base(company)
//     	{
//			aBenefitDescription = new MiscBenefitDescription();			
//    	}
//
////		============================== Public Method ==============================
//		public void Add(OtherBenefitSpecificCondition value)
//		{base.Add(value);}
//
//		public void Remove(OtherBenefitSpecificCondition value)
//		{base.Remove(value);}
//		
//		public OtherBenefitSpecificCondition this[int index]
//		{
//			get{return (OtherBenefitSpecificCondition) base.BaseGet(index);}
//			set{base.BaseSet(index, value);}
//		}
//
//		public OtherBenefitSpecificCondition this[String key]  
//		{
//			get{return (OtherBenefitSpecificCondition) base.BaseGet(key);}
//			set{base.BaseSet(key, value);}
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
//	}
//}
