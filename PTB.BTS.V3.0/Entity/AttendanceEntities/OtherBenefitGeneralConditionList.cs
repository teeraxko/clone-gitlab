//using System;
//
//using ictus.PIS.PI.Entity;
//
//namespace Entity.AttendanceEntities
//{
//	public class OtherBenefitGeneralConditionList : CompanyStuffBase
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
//		public OtherBenefitGeneralConditionList(Company company) : base(company)
//		{
//			aBenefitDescription = new MiscBenefitDescription();
//		}
//
////		============================== Public Method ==============================
//		public void Add(OtherBenefitGeneralCondition value)
//		{
//			base.Add(value);	
//		}
//	
//		public void Remove(OtherBenefitGeneralCondition value)
//		{
//			base.Remove(value);
//		}
//	
//		
//		public OtherBenefitGeneralCondition this[int index]
//		{
//			get
//			{
//				return (OtherBenefitGeneralCondition) base.BaseGet(index);
//			}
//			set
//			{
//				base.BaseSet(index, value);
//			}
//		}
//
//		public OtherBenefitGeneralCondition this[String key]  
//		{
//			get
//			{
//				return (OtherBenefitGeneralCondition) base.BaseGet(key);
//			}
//			set
//			{
//				base.BaseSet(key, value);
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
