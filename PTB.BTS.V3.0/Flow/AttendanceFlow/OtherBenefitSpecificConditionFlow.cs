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
//	public class OtherBenefitSpecificConditionFlow:FlowBase
//	{	
//		#region Private
//		private OtherBenefitSpecificConditionDB otherBenefitSpecificConditionDB;
//		private bool disposed = false;
//		#endregion
//
////  =================================Contructor==========================
//		public OtherBenefitSpecificConditionFlow():base()
//		{
//			otherBenefitSpecificConditionDB = new OtherBenefitSpecificConditionDB();
//		}
//
//
////  =================================Public Method==========================
//
//		public bool FillOtherBenefitSpecificCondition(ref OtherBenefitSpecificConditionList aOtherBenefitSpecificConditionList)
//		{
//			if( otherBenefitSpecificConditionDB.FillOtherBenefitSpecificConditionData(ref aOtherBenefitSpecificConditionList))
//			{
//				for (int i = 0  ; i < aOtherBenefitSpecificConditionList.Count ; i++)
//				{
//					Employee emp  = aOtherBenefitSpecificConditionList[i].AEmployee;
//					EmployeeDB aEmployeeDB = new EmployeeDB();
//					aEmployeeDB.FillEmployee(ref emp);
//					aOtherBenefitSpecificConditionList[i].AEmployee = emp;
//				
//				}
//			}
//			return true;
//		}
//
//		public bool InsertOtherBenefitSpecificCondition(ref OtherBenefitSpecificConditionList aOtherBenefitSpecificConditionList, OtherBenefitSpecificCondition aOtherBenefitSpecificCondition)
//		{
//			if (otherBenefitSpecificConditionDB.InsertOtherBenefitSpecificCondition(aOtherBenefitSpecificCondition))
//			{
//				aOtherBenefitSpecificConditionList.Add(aOtherBenefitSpecificCondition);
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}
//
//		public bool UpdateOtherBenefitSpecificCondition(ref OtherBenefitSpecificConditionList aOtherBenefitSpecificConditionList, OtherBenefitSpecificCondition aOtherBenefitSpecificCondition)
//		{
//			if (otherBenefitSpecificConditionDB.UpdateOtherBenefitSpecificCondition(aOtherBenefitSpecificCondition))
//			{
//				aOtherBenefitSpecificConditionList[aOtherBenefitSpecificCondition.EntityKey] = aOtherBenefitSpecificCondition;
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}
//
//		public bool DeleteOtherBenefitSpecificCondition(ref OtherBenefitSpecificConditionList aOtherBenefitSpecificConditionList, OtherBenefitSpecificCondition aOtherBenefitSpecificCondition)
//		{
//			
//			if (otherBenefitSpecificConditionDB.DeleteOtherBenefitSpecificCondition(aOtherBenefitSpecificCondition))
//			{
//				aOtherBenefitSpecificConditionList.Remove(aOtherBenefitSpecificCondition);
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
//						otherBenefitSpecificConditionDB.Dispose();
//
//						otherBenefitSpecificConditionDB = null;
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
//
//	
//	}
//}
