using System;

using Entity.ContractEntities;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using DataAccess.ContractDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Contract.Flow
{
	public class CustomerDepartmentFlow : FlowBase
	{
		#region - Private -
		private bool disposed = false;
		private CustomerDepartmentDB dbCustomerDepartment;
		#endregion - Private -

//		============================== Constructor ==============================
		public CustomerDepartmentFlow()
		{
			dbCustomerDepartment = new CustomerDepartmentDB();
		}

//		============================== Public Method ============================
		public CustomerDepartmentList GetCustomerDepartmentList(Customer aCustomer, Company aCompany)
		{
			CustomerDepartmentList customerDepartmentList = new CustomerDepartmentList(aCompany);
			customerDepartmentList.ACustomer = aCustomer;
			dbCustomerDepartment.FillCustomerDepartmentList(ref customerDepartmentList);
			return customerDepartmentList;
		}	
		public bool FillCustomerDepartmentList(ref CustomerDepartmentList value)
		{
			return dbCustomerDepartment.FillCustomerDepartmentList(ref value);
		}

		public bool InsertCustomerDepartment(ref CustomerDepartment aCustomerDepartment, Company aCompany)
		{
			return dbCustomerDepartment.InsertCustomerDepartment(aCustomerDepartment, aCompany);
		}

		public bool UpdateCustomerDepartment(ref CustomerDepartment aCustomerDepartment,Company aCompany)
		{
			return dbCustomerDepartment.UpdateCustomerDepartment(aCustomerDepartment,aCompany);
		}
		
		public bool DeleteCustomerDepartment(ref CustomerDepartment aCustomerDepartment, Company aCompany)
		{
			return dbCustomerDepartment.DeleteCustomerDepartment(aCustomerDepartment,aCompany);
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						dbCustomerDepartment.Dispose();

						dbCustomerDepartment = null;
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion
	}
}
