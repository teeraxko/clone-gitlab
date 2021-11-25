using System;

using Entity.ContractEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using DataAccess.ContractDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Contract.Flow
{
	public class CustomerFlow : FlowBase
	{
		#region - Private -
		private bool disposed = false;
		private CustomerDB dbCustomer;
		private CustomerDepartmentDB dbCustomerDepartment;
		private CustomerDepartment aCustomerDepartment;
		#endregion - Private -

		//		============================== Property ==============================
		private CustomerDepartmentList objCustomerDepartmentList;
		public CustomerDepartmentList ObjCustomerDepartmentList
		{
			get
			{
				return objCustomerDepartmentList;
			}
		}
//		============================== Constructor ==============================
		public CustomerFlow() : base()
		{			
			dbCustomer = new CustomerDB();
			dbCustomerDepartment = new CustomerDepartmentDB();
		}


//		============================== Public Method ============================
		public Customer GetCustomer(string customerCode, Company aCompany)
		{
			Customer customer = new Customer(customerCode);
			dbCustomer.FillCustomer(ref customer, aCompany);
			return customer;
		}
		
		public bool FillCustomer(ref CustomerList aCustomerList)
		{
			return dbCustomer.FillCustomerList(ref aCustomerList);
		}

		public CustomerList GetCustomerList(Company value)
		{
			CustomerList customerList = new CustomerList(value);
			dbCustomer.FillCustomerList(ref customerList);
			return customerList;
		}

		public bool InsertCustomer(ref CustomerList aCustomerList, Customer aCustomer)
		{
			aCustomerDepartment = new CustomerDepartment();
			aCustomerDepartment.ACustomer = aCustomer;
			aCustomerDepartment.Code = "ZZZ";
			aCustomerDepartment.ShortName = "";
			aCustomerDepartment.AName.English = "";
			aCustomerDepartment.AName.Thai = "";

			if (dbCustomer.InsertCustomer(aCustomer, aCustomerList.Company))
			{
				if (dbCustomerDepartment.InsertCustomerDepartment(aCustomerDepartment,aCustomerList.Company))
				{
					aCustomerList.Add(aCustomer);
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public bool UpdateCustomer(ref CustomerList aCustomerList, Customer aCustomer)
		{
			if (dbCustomer.UpdateCustomer(aCustomer, aCustomerList.Company))
			{
				aCustomerList[aCustomer.EntityKey] = aCustomer;
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool DeleteCustomer(ref CustomerList aCustomerList, Customer aCustomer)
		{
			aCustomerDepartment = new CustomerDepartment();
			objCustomerDepartmentList = new CustomerDepartmentList(aCustomerList.Company);

			objCustomerDepartmentList.ACustomer = aCustomer;

			aCustomerDepartment.ACustomer = aCustomer;
			aCustomerDepartment.Code = "ZZZ";
			aCustomerDepartment.ShortName = "";
			aCustomerDepartment.AName.English = "";
			aCustomerDepartment.AName.Thai = "";
			
			if(dbCustomerDepartment.FillCustomerDepartmentList(ref objCustomerDepartmentList))
			{
				if(objCustomerDepartmentList.Count == 1)
				{
					bool result = false;
					CustomerDepartmentDB tempCustomerDepartment = new CustomerDepartmentDB();
					tempCustomerDepartment.TableAccess = dbCustomer.TableAccess;					
					try
					{
						dbCustomer.TableAccess.OpenTransaction();
						if (tempCustomerDepartment.DeleteCustomerDepartment(aCustomerDepartment, aCustomerList.Company))
						{
							if (dbCustomer.DeleteCustomer(aCustomer, aCustomerList.Company))
							{
								aCustomerList.Remove(aCustomer);
								result = true;
							}
							else
							{
								result = false;
							}
						}
						else
						{
							result = false;
						}

						if(result)
						{
							dbCustomer.TableAccess.Transaction.Commit();
						}
						else
						{
							dbCustomer.TableAccess.Transaction.Rollback();
						}
					}
					catch(Exception ex)
					{
						dbCustomer.TableAccess.Transaction.Rollback();
						throw ex;
					}
					finally
					{
						dbCustomer.TableAccess.CloseConnection();
					}
					return result;
				}
				else
				{
					if (dbCustomer.DeleteCustomer(aCustomer, aCustomerList.Company))
					{
						aCustomerList.Remove(aCustomer);
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			else
			{
				return false;
			}

		}


//		public bool InsertCustomer(ref CustomerList aCustomerList, Customer aCustomer)
//		{
//			if (dbCustomer.InsertCustomerData(aCustomer, aCustomerList.Company))
//			{
//				aCustomerList.Add(aCustomer);
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}
//
//		public bool UpdateCustomer(ref CustomerList aCustomerList, Customer aCustomer)
//		{
//			if (dbCustomer.UpdateCustomerData(aCustomer, aCustomerList.Company))
//			{
//				aCustomerList[aCustomer.EntityKey] = aCustomer;
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}
//
//		public bool DeleteCustomer(ref CustomerList aCustomerList, Customer aCustomer)
//		{
//			if (dbCustomer.DeleteCustomerData(aCustomer, aCustomerList.Company))
//			{
//				aCustomerList.Remove(aCustomer);
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//
//		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						dbCustomer.Dispose();

						dbCustomer = null;
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
