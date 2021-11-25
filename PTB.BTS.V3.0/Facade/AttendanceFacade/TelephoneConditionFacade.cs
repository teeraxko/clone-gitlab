using System;
using System.Collections;
using System.Data;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Flow.AttendanceFlow;
using PTB.BTS.PI.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class TelephoneConditionFacade : CommonPIFacadeBase
	{
		#region - Private -
		private TelephoneConditionFlow flowTelephoneCondition;
		#endregion

		//		============================== Property ==============================
		private TelephoneConditionList objTelephoneConditionList;
		public TelephoneConditionList ObjTelephoneConditionList
		{
			get{return objTelephoneConditionList;}
		}

		//		============================== Constructor ==============================
		public TelephoneConditionFacade()
		{
			flowTelephoneCondition = new TelephoneConditionFlow();
		}

		//		============================== Public Method ==============================
		public bool DisplayTelephoneCondition()
		{	
			objTelephoneConditionList = new TelephoneConditionList(GetCompany());
			return flowTelephoneCondition.FillTelephoneConditionList(ref objTelephoneConditionList);
		}

		public bool InsertTelephoneCondition(TelephoneCondition value)
		{
			if (objTelephoneConditionList.Contain(value))
			{
				throw new DuplicateException("TelephoneConditionFacade");
			}
			else
			{
				if(flowTelephoneCondition.InsertTelephoneCondition(value))
				{
					objTelephoneConditionList.Add(value);
					return true;
				}
				else
				{return false;}
			}
		}

		public bool UpdateTelephoneCondition(TelephoneCondition value)
		{
			if (flowTelephoneCondition.UpdateTelephoneCondition(value))
			{
				objTelephoneConditionList[value.EntityKey] = value;
				return true;
			}
			return false;
		}
		
		public bool DeleteTelephoneCondition(TelephoneCondition value)
		{
			if(flowTelephoneCondition.DeleteTelephoneCondition(value))
			{
				objTelephoneConditionList.Remove(value);
				return true;
			}
			return false;
		}		
	}
}
