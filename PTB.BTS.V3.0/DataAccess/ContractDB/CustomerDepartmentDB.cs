using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using ictus.Common.Entity;

using Entity.CommonEntity;
using Entity.ContractEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.ContractDB
{
	public class CustomerDepartmentDB : DataAccessBase
	{
		#region - Constant -
		private const int CUSTOMER_CODE = 0;
		private const int DEPARTMENT_CODE = 1;
		private const int ENGLISH_NAME = 2;
		private const int THAI_NAME = 3;
		private const int SHORT_NAME = 4;
		#endregion

		#region - Private -		
		private CustomerDB dbCustomer;
		private CustomerDepartment objCustomerDepartment;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public CustomerDepartmentDB() : base()
		{
			dbCustomer = new CustomerDB();
		}
		
//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Customer_Code, Department_Code, English_Name, Thai_Name, Short_Name FROM Customer_Department ";
		}

		private string getSQLInsert(CustomerDepartment value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Customer_Department (Company_Code, Customer_Code, Department_Code, English_Name, Thai_Name, Short_Name, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Customer_Code			
			stringBuilder.Append(GetDB(value.ACustomer.Code));
			stringBuilder.Append(", ");

			//Department_Code
			stringBuilder.Append(GetDB(value.Code));
			stringBuilder.Append(", ");

			//English_Name
			stringBuilder.Append(GetDB(value.AName.English));
			stringBuilder.Append(", ");

			//Thai_Name
			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(", ");

			//Short_Name
			stringBuilder.Append(GetDB(value.ShortName));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(CustomerDepartment value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Customer_Department SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");
	
			stringBuilder.Append("Customer_Code = ");
			stringBuilder.Append(GetDB(value.ACustomer.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("Department_Code = ");
			stringBuilder.Append(GetDB(value.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("English_Name = ");
			stringBuilder.Append(GetDB(value.AName.English));
			stringBuilder.Append(", ");

			stringBuilder.Append("Thai_Name = ");
			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Short_Name = ");
			stringBuilder.Append(GetDB(value.ShortName));
			stringBuilder.Append(", ");

			stringBuilder.Append("Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append("Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
		
			return stringBuilder.ToString();
		}

		private string getSQLDelete()
		{
			return " DELETE FROM Customer_Department ";
		}

		private string getKeyCondition(CustomerDepartment value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value.ACustomer != null && IsNotNULL(value.ACustomer.Code))
			{
				stringBuilder.Append(" AND (Customer_Code = ");
				stringBuilder.Append(GetDB(value.ACustomer.Code));
				stringBuilder.Append(")");
			}
			
			if (IsNotNULL(value.Code))
			{
				stringBuilder.Append(" AND (Department_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");
			}
			
			return stringBuilder.ToString();
		}

		private string getListCondition(Customer value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.Code))
			{
				stringBuilder.Append(" AND (Customer_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");
			}
			
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Short_Name ";
		}
		#endregion

		#region - Fill -
		private void fillCustomerDepartment(ref CustomerDepartment value, Company aCompany, SqlDataReader dataReader)
		{
			value.ACustomer = dbCustomer.GetDBCustomer((string)dataReader[CUSTOMER_CODE], aCompany);
			value.Code= (string)dataReader[DEPARTMENT_CODE];
			value.AName.English = (string)dataReader[ENGLISH_NAME];
			value.AName.Thai = (string)dataReader[THAI_NAME];
			value.ShortName = (string)dataReader[SHORT_NAME];
		}

		private void fillCustomerDepartmentDB(ref CustomerDepartment value, Company aCompany, SqlDataReader dataReader)
		{
			value.ACustomer = dbCustomer.GetDBCustomer((string)dataReader[CUSTOMER_CODE], aCompany);
			fillCustomerDepartment(ref value, aCompany, dataReader);
		}

		private bool fillCustomerDepartmentList(ref CustomerDepartmentList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			CustomerList listCustomer = new CustomerList(value.Company);
			dbCustomer.FillCustomerList(ref listCustomer);

			try
			{
				while (dataReader.Read())
				{
					result = true;
					objCustomerDepartment = new CustomerDepartment();

					fillCustomerDepartment(ref objCustomerDepartment, value.Company, dataReader);
					value.Add(objCustomerDepartment);
				}
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{
				tableAccess.CloseDataReader();
				listCustomer = null;
				dataReader = null;
			}
			return result;
		}	

		private bool fillCustomerDepartment(ref CustomerDepartment aCustomerDepartment, Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillCustomerDepartmentDB(ref aCustomerDepartment, aCompany, dataReader);
					result = true;
				}
				else
				{result = false;}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;
		}
		#endregion

//		============================== Public Method ==============================
		public CustomerDepartment GetCustomerDepartment(string customerDepartmentCode, string customerCode, Company aCompany)
		{
			objCustomerDepartment = new CustomerDepartment();
			Customer objCustomer = new Customer(customerCode);
			objCustomerDepartment.Code = customerDepartmentCode;
			objCustomerDepartment.ACustomer = objCustomer;
			objCustomer = null;

			if(FillCustomerDepartment(ref objCustomerDepartment, aCompany))
			{
				return objCustomerDepartment;
			}
			else
			{
				objCustomerDepartment = null;
				return null;
			}
		}

		internal CustomerDepartment GetDBCustomerDepartment(string customerDepartmentCode, string customerCode, Company aCompany)
		{
			objCustomerDepartment = new CustomerDepartment();
			Customer objCustomer = new Customer(customerCode);
			objCustomerDepartment.Code = customerDepartmentCode;
			objCustomerDepartment.ACustomer = objCustomer;
			objCustomer = null;

			if(FillCustomerDepartment(ref objCustomerDepartment, aCompany))
			{
				return objCustomerDepartment;
			}
			else
			{
				objCustomerDepartment.Code = NullConstant.STRING;
				return objCustomerDepartment;
			}
		}

		public bool FillCustomerDepartment(ref CustomerDepartment value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));
			return fillCustomerDepartment(ref value, aCompany, stringBuilder.ToString());
		}

		public bool FillCustomerDepartmentList(ref CustomerDepartmentList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getListCondition(value.ACustomer));
			stringBuilder.Append(getOrderby());

			return fillCustomerDepartmentList(ref value, stringBuilder.ToString());
		}

		public bool InsertCustomerDepartment(CustomerDepartment value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateCustomerDepartment(CustomerDepartment value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteCustomerDepartment(CustomerDepartment value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
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
						dbCustomer.Dispose();
						dbCustomer = null;
						objCustomerDepartment = null;
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