using System;
using System.Collections;
using System.Data;

using Entity.ContractEntities;
using Entity.AttendanceEntities;

using PTB.BTS.Contract.Flow;
using Flow.AttendanceFlow;

using Facade.CommonFacade;
using Facade.PiFacade;

using SystemFramework.AppException;

namespace Facade.ContractFacade
{
	public class CustomerDeptFacade : CommonPIFacadeBase
	{
		#region - Private -
		private CustomerDepartmentFlow flowCustomerDepartment;
		#endregion

//		============================== Property ==============================
		private CustomerDepartmentList objCustomerDepartmentList;
		public CustomerDepartmentList ObjCustomerDepartmentList
		{
			get
			{
				return objCustomerDepartmentList;
			}
		}
//		============================== DataSource ==============================
		public ArrayList DataSourceCustomer
		{
			get
			{
				CustomerFlow flowCustomer = new CustomerFlow();
				CustomerList customerList = new CustomerList(GetCompany());
				flowCustomer.FillCustomer(ref customerList);
				return customerList.GetArrayList();
			}
		}
		
//		============================== Constructor ==============================
		public CustomerDeptFacade(): base()
		{
			flowCustomerDepartment = new CustomerDepartmentFlow();
			objCustomerDepartmentList = new CustomerDepartmentList(GetCompany());
		}
		
//		============================== Public Method ==============================
		public bool DisplayCustomerDepartment(string customerCode)
		{
			objCustomerDepartmentList.Clear();
			CustomerFlow flowCustomer = new CustomerFlow();
			objCustomerDepartmentList.ACustomer = flowCustomer.GetCustomer(customerCode, GetCompany());
			flowCustomer = null;

			if (objCustomerDepartmentList.ACustomer == null)
			{
				return false;
			}
			else
			{
				CustomerDepartment aCustomerDepartment = new CustomerDepartment();
				aCustomerDepartment.ACustomer = objCustomerDepartmentList.ACustomer;
				aCustomerDepartment.Code = "ZZZ";
				aCustomerDepartment.ShortName = "";
				aCustomerDepartment.AName.English = "";
				aCustomerDepartment.AName.Thai = "";

				if(flowCustomerDepartment.FillCustomerDepartmentList(ref objCustomerDepartmentList))
				{
					objCustomerDepartmentList.Remove(aCustomerDepartment);
					return true;
				}
				else
					return false;
			}
		}

		public bool InsertCustomerDepartment(CustomerDepartment aCustomerDepartment)
		{
			if (objCustomerDepartmentList.Contain(aCustomerDepartment))
			{
				throw new DuplicateException("CustomerDepartmentFacade");
			}
			else
			{
				if (flowCustomerDepartment.InsertCustomerDepartment(ref aCustomerDepartment,GetCompany()))
				{
					objCustomerDepartmentList.Add(aCustomerDepartment);
					return true;
				}
				else
				{
					return false;
				}
			}			
		}

		public bool UpdateCustomerDepartment(CustomerDepartment aCustomerDepartment)
		{
			if (flowCustomerDepartment.UpdateCustomerDepartment(ref aCustomerDepartment,GetCompany()))
			{
				objCustomerDepartmentList[aCustomerDepartment.EntityKey] = aCustomerDepartment;
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool DeleteCustomerDepartment(CustomerDepartment aCustomerDepartment)
		{
			if(flowCustomerDepartment.DeleteCustomerDepartment(ref aCustomerDepartment,GetCompany()))
			{
				objCustomerDepartmentList.Remove(aCustomerDepartment);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
