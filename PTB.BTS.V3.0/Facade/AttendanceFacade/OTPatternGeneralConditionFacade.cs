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
	public class OTPatternGeneralConditionFacade : CommonPIFacadeBase
	{
		#region - Private -
		private OTPatternGeneralConditionFlow flowOTPatternGeneralCondition;
		private PositionTypeFlow flowPositionType;
		#endregion

		#region - DataSource -
		public ArrayList DataSourceCustomer
		{
			get
			{
				CustomerFlow flowCustomer = new CustomerFlow();
				CustomerList customerList = new CustomerList(GetCompany());
				flowCustomer.FillCustomer(ref customerList);
				flowCustomer = null;
				return customerList.GetArrayList();	
			}
		}

		public ArrayList DataSourceCustomerDept(Customer value)
		{
			CustomerDepartmentFlow flowCustomerDept = new CustomerDepartmentFlow();
			CustomerDepartmentList customerDeptList = new CustomerDepartmentList(GetCompany());
			customerDeptList.ACustomer = value;
			flowCustomerDept.FillCustomerDepartmentList(ref customerDeptList);
			flowCustomerDept = null;
			return customerDeptList.GetArrayList();			
		}

		public ArrayList DataSourceServiceStaffType
		{
			get
			{
				ServiceStaffTypeFlow flowServiceStaffType = new ServiceStaffTypeFlow();
				ServiceStaffTypeList serviceStaffTypeList = new ServiceStaffTypeList(GetCompany());
				flowServiceStaffType.FillServiceStaffTypeList(ref serviceStaffTypeList);
				flowServiceStaffType = null;
				return serviceStaffTypeList.GetArrayList();
			}		
		}

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
		public OTPatternGeneralConditionFacade() : base()
		{
			flowOTPatternGeneralCondition = new OTPatternGeneralConditionFlow();
			flowPositionType = new PositionTypeFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayOTPatternGeneralCondition()
		{	
			objOTPatternConditionList = new OTPatternConditionList(GetCompany());
			return flowOTPatternGeneralCondition.FillOTPatternGeneralConditionList(ref objOTPatternConditionList);
		}

		public PositionType GetPositionType(string positionType)
		{
			flowPositionType = new PositionTypeFlow();
			return flowPositionType.GetPositionType(positionType, GetCompany());
		}

		public bool InsertOTPatternGeneralCondition(OTPatternGeneralCondition value)
		{
			if (objOTPatternConditionList.Contain(value))
			{
				throw new DuplicateException("OTPatternGeneralConditionFacade");
			}
			else
			{
				if(flowOTPatternGeneralCondition.InsertOTPatternGeneralCondition(value, objOTPatternConditionList.Company))
				{
					objOTPatternConditionList.Add(value);
					return true;
				}
				else
				{return false;}
			}
		}

		public bool UpdateOTPatternGeneralCondition(OTPatternGeneralCondition value)
		{
			if (flowOTPatternGeneralCondition.UpdateOTPatternGeneralCondition(value, objOTPatternConditionList.Company))
			{
				objOTPatternConditionList[value.EntityKey] = value;
				return true;
			}
			return false;
		}
		
		public bool DeleteOTPatternGeneralCondition(OTPatternGeneralCondition value)
		{
			if(flowOTPatternGeneralCondition.DeleteOTPatternGeneralCondition(value, objOTPatternConditionList.Company))
			{
				objOTPatternConditionList.Remove(value);
				return true;
			}
			return false;
		}		
	}
}
