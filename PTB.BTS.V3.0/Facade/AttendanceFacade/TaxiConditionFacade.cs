using System;
using System.Data;
using System.Collections;

using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;
using Entity.ContractEntities;

using PTB.BTS.PI.Flow;
using Flow.AttendanceFlow;
using PTB.BTS.Contract.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;

namespace Facade.AttendanceFacade
{
	public class TaxiConditionFacade : CommonPIFacadeBase
	{
		#region - Private -
		private TaxiFamilyCarConditionFlow flowTaxiFamilyCarCondition;
		private TaxiPositionCarConditionFlow flowTaxiPositionCarCondition;
		#endregion

//		============================== Property ==============================
		private TaxiFamilyCarConditionList objTaxiFamilyCarConditionList;
		public TaxiFamilyCarConditionList ObjTaxiFamilyCarConditionList
		{
			get{return objTaxiFamilyCarConditionList;}
		}

		private TaxiPositionCarConditionList objTaxiPositionCarConditionList;
		public TaxiPositionCarConditionList ObjTaxiPositionCarConditionList
		{
			get{return objTaxiPositionCarConditionList;}
		}

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

		public ArrayList DataSourceCustomerGroup
		{
			get
			{
				CustomerGroupFlow flowCustomerGroup = new CustomerGroupFlow();
				CustomerGroupList customerGroupList = new CustomerGroupList(GetCompany());
				flowCustomerGroup.FillMTBData(customerGroupList);
				flowCustomerGroup = null;
				return customerGroupList.GetArrayList();
			}
		}
		#endregion

//		============================== Constructor ==============================
		public TaxiConditionFacade() : base()
		{
			flowTaxiFamilyCarCondition = new TaxiFamilyCarConditionFlow();
			flowTaxiPositionCarCondition = new TaxiPositionCarConditionFlow();
		}

//		============================== Public Method ==============================
		#region - FamilyCar -
		public bool DisPlayTaxiFamilyCar()
		{
			objTaxiFamilyCarConditionList = new TaxiFamilyCarConditionList(GetCompany());
			return flowTaxiFamilyCarCondition.FillTaxiFamilyCarConditionList(ref objTaxiFamilyCarConditionList);
		}

		public bool InsertTaxi(TaxiFamilyCarCondition value)
		{
			if (objTaxiFamilyCarConditionList.Contain(value))
			{
				throw new DuplicateException("TaxiConditionFacade");
			}
			else
			{
				if (flowTaxiFamilyCarCondition.InsertTaxiFamilyCarCondition(value, objTaxiFamilyCarConditionList.Company))
				{
					objTaxiFamilyCarConditionList.Add(value);
					return true;
				}
				else
				{return false;}
			}			
		}

		public bool UpdateTaxi(TaxiFamilyCarCondition value)
		{
			if (flowTaxiFamilyCarCondition.UpdateTaxiFamilyCarCondition(value, objTaxiFamilyCarConditionList.Company))
			{
				objTaxiFamilyCarConditionList[value.EntityKey] = value;
				return true;
			}
			else
			{return false;}
		}

		public bool DeleteTaxi(TaxiFamilyCarCondition value)
		{
			if(flowTaxiFamilyCarCondition.DeleteTaxiFamilyCarCondition(value, objTaxiFamilyCarConditionList.Company))
			{
				objTaxiFamilyCarConditionList.Remove(value);
				return true;
			}
			else
			{return false;}
		}
		#endregion

		#region - PositionCar -
		public bool DisplayTaxiPositionCar()
		{
			objTaxiPositionCarConditionList = new TaxiPositionCarConditionList(GetCompany());
			return flowTaxiPositionCarCondition.FillTaxiPositionCarConditionList(ref objTaxiPositionCarConditionList);
		}

		public bool InsertTaxi(TaxiPositionCarCondition value)
		{
			if (objTaxiPositionCarConditionList.Contain(value))
			{
				throw new DuplicateException("TaxiConditionFacade");
			}
			else
			{
				if (flowTaxiPositionCarCondition.InsertTaxiPositionCarCondition(value, objTaxiPositionCarConditionList.Company))
				{
					objTaxiPositionCarConditionList.Add(value);
					return true;
				}
				else
				{return false;}
			}			
		}

		public bool UpdateTaxi(TaxiPositionCarCondition value)
		{
			if (flowTaxiPositionCarCondition.UpdateTaxiPositionCarCondition(value, objTaxiPositionCarConditionList.Company))
			{
				objTaxiPositionCarConditionList[value.EntityKey] = value;
				return true;
			}
			else
			{return false;}
		}

		public bool DeleteTaxi(TaxiPositionCarCondition value)
		{
			if(flowTaxiPositionCarCondition.DeleteTaxiPositionCarCondition(value, objTaxiPositionCarConditionList.Company))
			{
				objTaxiPositionCarConditionList.Remove(value);
				return true;
			}
			else
			{return false;}
		}
		#endregion
	}
}
