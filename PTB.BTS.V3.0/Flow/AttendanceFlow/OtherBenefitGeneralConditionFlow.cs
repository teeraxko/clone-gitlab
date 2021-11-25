//using System;
//using System.Data;
//
//using ictus.PIS.PI.Entity;
//using Entity.ContractEntities;
//using Entity.AttendanceEntities;
//
//using DataAccess.PiDB;
//using DataAccess.CommonDB;
//using DataAccess.ContractDB;
//using DataAccess.AttendanceDB;
//
//using PTB.BTS.Common.Flow;
//
//namespace Flow.AttendanceFlow
//{
//
//	public class OtherBenefitGeneralConditionFlow : FlowBase
//	{
//		#region Private		
//		private OtherBenefitGeneralConditionDB otherBenefitGeneralConditionDB;
//		private bool disposed = false;
//		#endregion
//
////  ================================Constructor=====================
//
//		public OtherBenefitGeneralConditionFlow():base()
//		{
//			otherBenefitGeneralConditionDB = new OtherBenefitGeneralConditionDB();
//		}
//		
////  ================================public Method=====================
//
//		public bool FillOtherBenefitGeneralCondition(ref OtherBenefitGeneralConditionList aOtherBenefitGeneralConditionList)
//		{
//			if(otherBenefitGeneralConditionDB.FillOtherBenefitGeneralConditionData(ref aOtherBenefitGeneralConditionList))
//			{
////				for (int i = 0  ; i < aOtherBenefitGeneralConditionList.Count; i++)
////				{
////					Position p  = aOtherBenefitGeneralConditionList[i].APosition;
////					PositionDB aPositionDB = new PositionDB();
////					aPositionDB.GetPositionByCode(ref p);
////					aOtherBenefitGeneralConditionList[i].APosition = p;
////
////					Customer c = aOtherBenefitGeneralConditionList[i].ACustomer;
////					CustomerDB aCustomerDB = new CustomerDB();
////					aCustomerDB.GetCustomerByCode(ref c);
////					aOtherBenefitGeneralConditionList[i].ACustomer = c;
////				}
//				return true;
//			}
//			return false;
//	
//		}
//
//		public bool SaveOtherBenefitGeneralCondition(ref OtherBenefitGeneralConditionList aOtherBenefitGeneralConditionList, OtherBenefitGeneralCondition aOtherBenefitGeneralCondition, Company aCompany)
//		{
//			if (otherBenefitGeneralConditionDB.InsertOtherBenefitGeneralCondition(aOtherBenefitGeneralCondition, aCompany))
//			{
//				aOtherBenefitGeneralConditionList.Add(aOtherBenefitGeneralCondition);
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}
//	
//		public bool UpdateOtherBenefitGeneralCondition(ref OtherBenefitGeneralConditionList aOtherBenefitGeneralConditionList, OtherBenefitGeneralCondition aOtherBenefitGeneralCondition, Company aCompany)
//		{
//			if (otherBenefitGeneralConditionDB.UpdateOtherBenefitGeneralCondition(aOtherBenefitGeneralCondition, aCompany))
//			{
//				aOtherBenefitGeneralConditionList[aOtherBenefitGeneralCondition.EntityKey] = aOtherBenefitGeneralCondition;
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}
//
//		public bool DeleteOtherBenefitGeneralCondition(ref OtherBenefitGeneralConditionList aOtherBenefitGeneralConditionList, OtherBenefitGeneralCondition aOtherBenefitGeneralCondition,Company aCompany)
//		{
//			if (otherBenefitGeneralConditionDB.DeleteOtherBenefitGeneralCondition(aOtherBenefitGeneralCondition, aCompany))
//			{
//				aOtherBenefitGeneralConditionList.Remove(aOtherBenefitGeneralCondition);
//				return true;
//			}
//			else
//			{
//				return false;
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
//						otherBenefitGeneralConditionDB.Dispose();
//
//						otherBenefitGeneralConditionDB = null;
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
