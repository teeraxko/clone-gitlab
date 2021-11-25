using System;
using System.Collections;
using System.Data;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;
using Entity.ContractEntities;

using Flow.AttendanceFlow;
using PTB.BTS.PI.Flow;
using PTB.BTS.Contract.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class OTPatternSpecificConditionFacade : CommonPIFacadeBase
	{
		#region - Private -
		private OTPatternSpecificConditionFlow flowOTPatternSpecificCondition;
		private EmployeeFlow flowEmployee;
		#endregion

		#region - Data source -
		public ArrayList DataSourceOTPattern
		{
			get
			{
				OTPatternFlow flowOTPattern = new OTPatternFlow();
				OTPatternList otPatternList = new OTPatternList(GetCompany());
				flowOTPattern.FillOTPatternList(ref otPatternList);
				flowOTPattern = null;
				return otPatternList.GetArrayList();			
			}		
		}
		#endregion

//		============================== Property ==============================
		private OTPatternConditionList objOTPatternConditionList;
		public OTPatternConditionList ObjOTPatternConditionList
		{
			get{return objOTPatternConditionList;}
		}

//		============================== Constructor ==============================
		public OTPatternSpecificConditionFacade() : base()
		{
			flowOTPatternSpecificCondition = new OTPatternSpecificConditionFlow();
			flowEmployee = new EmployeeFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayOTPatternSpecificCondition()
		{	
			objOTPatternConditionList = new OTPatternConditionList(GetCompany());
			return flowOTPatternSpecificCondition.FillOTPatternSpecificConditionList(ref objOTPatternConditionList);
		}

		public bool InsertOTPatternSpecificCondition(OTPatternSpecificCondition value)
		{
			if (objOTPatternConditionList.Contain(value))
			{
				throw new DuplicateException("OTPatternSpecificConditionFacade");
			}
			else
			{
				if(flowOTPatternSpecificCondition.InsertOTPatternSpecificCondition(value, objOTPatternConditionList.Company))
				{
					objOTPatternConditionList.Add(value);
					return true;
				}
				else
				{return false;}
			}
		}

		public bool UpdateOTPatternSpecificCondition(OTPatternSpecificCondition value)
		{
			if (flowOTPatternSpecificCondition.UpdateOTPatternSpecificCondition(value, objOTPatternConditionList.Company))
			{
				objOTPatternConditionList[value.EntityKey] = value;
				return true;
			}
			return false;
		}
		
		public bool DeleteOTPatternSpecificCondition(OTPatternSpecificCondition value)
		{
			if(flowOTPatternSpecificCondition.DeleteOTPatternSpecificCondition(value, objOTPatternConditionList.Company))
			{
				objOTPatternConditionList.Remove(value);
				return true;
			}
			return false;
		}		
	}
}
