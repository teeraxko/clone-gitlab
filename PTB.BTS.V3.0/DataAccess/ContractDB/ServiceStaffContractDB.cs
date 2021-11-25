using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Entity.ContractEntities;
using ictus.PIS.PI.Entity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.ContractDB
{
	public class ServiceStaffContractDB : DataAccessBase
	{
		#region - Private -	
		private ServiceStaffDB dbServiceStaff;
		private ServiceStaffTypeDB dbServiceStaffType;
		#endregion
	
		#region - Constant -
		private const int CONTRACT_NO = 0;
		private const int EMPLOYEE_ORDER = 1;
		private const int SERVICE_STAFF_TYPE = 2;
		private const int CURRENT_EMPLOYEE_NO = 3;
		#endregion

//		============================== Constructor ==============================
		public ServiceStaffContractDB() : base()
		{
			dbServiceStaff = new ServiceStaffDB();
			dbServiceStaffType = new ServiceStaffTypeDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Contract_No, Employee_Order, Service_Staff_Type, Current_Employee_No FROM Service_Staff_Contract ";
		}

		private string getSQLInsert(ServiceStaffContract aServiceStaffContract, ServiceStaffRole aServiceStaffRole)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Service_Staff_Contract (Company_Code, Contract_No, Employee_Order, Service_Staff_Type, Current_Employee_No, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aServiceStaffContract.ALatestServiceStaffRoleList.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Contract_No
			stringBuilder.Append(GetDB(aServiceStaffContract.ContractNo.ToString()));
			stringBuilder.Append(", ");

			//Employee_Order
			stringBuilder.Append(GetDB(aServiceStaffRole.ServiceStaffOrder));
			stringBuilder.Append(", ");

			//Service_Staff_Type
			stringBuilder.Append(GetDB(aServiceStaffRole.AServiceStaffType.Type));
			stringBuilder.Append(", ");
			
			//Current_Employee_No
			stringBuilder.Append(GetDB(aServiceStaffRole.AServiceStaff.EmployeeNo));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(ServiceStaffRole value)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Service_Staff_Contract SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(value.AServiceStaff.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Contract_No = ");
			stringBuilder.Append(GetDB(value.AServiceStaff.ACurrentContract.ContractNo.ToString()));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_Order = ");
			stringBuilder.Append(GetDB(value.ServiceStaffOrder));
			stringBuilder.Append(", ");

			stringBuilder.Append("Service_Staff_Type = ");
			stringBuilder.Append(GetDB(value.AServiceStaffType.Type));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Employee_No = ");
			stringBuilder.Append(GetDB(value.AServiceStaff.EmployeeNo));
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
			return " DELETE FROM Service_Staff_Contract ";
		}

		private string getKeyCondition(ContractBase  value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value != null && value.ContractNo != null && IsNotNULL(value.ContractNo.ToString()))
			{
				stringBuilder.Append(" AND (Contract_No = ");
				stringBuilder.Append(GetDB(value.ContractNo.ToString()));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getEntityCondition(ServiceStaffRole value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value.AServiceStaff.ACurrentContract!=null && value.AServiceStaff.ACurrentContract.ContractNo != null)
			{
				stringBuilder.Append(" AND (Contract_No = ");
				stringBuilder.Append(GetDB(value.AServiceStaff.ACurrentContract.ContractNo.ToString()));
				stringBuilder.Append(")");
			}
			if(IsNotNULL(value.ServiceStaffOrder))
			{
				stringBuilder.Append(" AND (Employee_Order = ");
				stringBuilder.Append(GetDB(value.ServiceStaffOrder));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getEntityCondition(ServiceStaff  value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.EmployeeNo))
			{
				stringBuilder.Append(" AND (Current_Employee_No = ");
				stringBuilder.Append(GetDB(value.EmployeeNo));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
        }

        private string getEntityCondition(int empOrder)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(empOrder))
            {
                stringBuilder.Append(" AND (Employee_Order = ");
                stringBuilder.Append(GetDB(empOrder));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }
		#endregion

		#region - Fill -
		private void fillServiceStaffContract(ref ServiceStaffRole value, Company aCompany, SqlDataReader dataReader)
		{
			value.ServiceStaffOrder = dataReader.GetByte(EMPLOYEE_ORDER);
			value.AServiceStaffType = dbServiceStaffType.GetDBServiceStaffType((string)dataReader[SERVICE_STAFF_TYPE], aCompany);
			value.AServiceStaff = (ServiceStaff)dbServiceStaff.GetDBAllStaff((string)dataReader[CURRENT_EMPLOYEE_NO], aCompany);
		}

		private bool fillServiceStaffContract(ref ServiceStaffContract value, string sql)
		{
			ServiceStaffRole objServiceStaffRole;
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objServiceStaffRole = new ServiceStaffRole();
					fillServiceStaffContract(ref objServiceStaffRole, value.ALatestServiceStaffRoleList.Company, dataReader);
					value.ALatestServiceStaffRoleList.Add(objServiceStaffRole);
				}
				objServiceStaffRole = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;
		}	

		#endregion

//		============================== Public Method ==============================
		public ServiceStaffType GetServiceStaffType(ContractBase value, Company company)
		{
			ServiceStaffType serviceStaffType = new ServiceStaffType();
			serviceStaffType.Type = "ZZZ";
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(company));
			stringBuilder.Append(getKeyCondition(value));
			
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
			try
			{
				while (dataReader.Read())
				{
					serviceStaffType = dbServiceStaffType.GetDBServiceStaffType((string)dataReader[SERVICE_STAFF_TYPE], company);
				}
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			
			stringBuilder = null;
			return serviceStaffType;
		}

		public bool FillServiceStaffContract(ServiceStaffContract value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.ALatestServiceStaffRoleList.Company));
			stringBuilder.Append(getKeyCondition(value));

			bool result = fillServiceStaffContract(ref value, stringBuilder.ToString());

			if(result)
			{
				ServiceStaff serviceStaff;
				for(int i=0; i<value.ALatestServiceStaffRoleList.Count; i++)
				{
					serviceStaff = value.ALatestServiceStaffRoleList[i].AServiceStaff;
					if(serviceStaff.ACurrentContract != null && serviceStaff.ACurrentContract.ContractNo != null)
					{																												 
						if(serviceStaff.ACurrentContract.ContractNo.ToString() == value.ContractNo.ToString())
						{
							serviceStaff.ACurrentContract = value;
						}
						else
						{
							ContractDB dbContract = new ContractDB();
							dbContract.FillContract(serviceStaff.ACurrentContract, value.ALatestServiceStaffRoleList.Company);
							dbContract = null;
						}
					}
				}
			}
			return result;
		}

        public bool FillServiceStaffContractByEmployeeOrder(ref ServiceStaffContract value, int empOrder)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.AContractChargeList.Company));
            stringBuilder.Append(getKeyCondition(value));
            stringBuilder.Append(getEntityCondition(empOrder));

            return fillServiceStaffContract(ref value, stringBuilder.ToString());
        }

        public bool FillServiceStaffContractByEmployeeNo(ref ServiceStaffContract value, ServiceStaff serviceStaff)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.AContractChargeList.Company));
            stringBuilder.Append(getKeyCondition(value));
            stringBuilder.Append(getEntityCondition(serviceStaff));

            return fillServiceStaffContract(ref value, stringBuilder.ToString());
        }

		public bool InsertServiceStaffContract(ServiceStaffContract value)
		{
			ServiceStaffRoleList serviceStaffRoleList = value.ALatestServiceStaffRoleList;
			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i < serviceStaffRoleList.Count; i++)
			{
				stringBuilder.Append(getSQLInsert(value, serviceStaffRoleList[i]));
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool UpdateServiceStaffContract(ServiceStaffContract value)
		{
			if(DeleteServiceStaffContract(value))
			{return InsertServiceStaffContract(value);}
			else
			{return false;}
		}

		public bool UpdateServiceStaffContract(ServiceStaffRole value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value));
			stringBuilder.Append(getBaseCondition(value.AServiceStaff.Company));
			stringBuilder.Append(getEntityCondition(value));

			if(tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{
				stringBuilder = null;
				return true;
			}
			else
			{
				stringBuilder = null;
				return false;
			}
		}

		public bool DeleteServiceStaffContract(ServiceStaffContract value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.ALatestServiceStaffRoleList.Company));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteServiceStaffContract(ServiceStaffContract aServiceStaffContract, ServiceStaff aServiceStaff)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aServiceStaffContract.ALatestServiceStaffRoleList.Company));
			stringBuilder.Append(getKeyCondition(aServiceStaffContract));
			stringBuilder.Append(getEntityCondition(aServiceStaff));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool MaintainServiceStaffContract(ServiceStaffContract value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.ALatestServiceStaffRoleList.Company));
			stringBuilder.Append(getKeyCondition(value));

			for(int i=0; i < value.ALatestServiceStaffRoleList.Count; i++)
			{
				stringBuilder.Append(getSQLInsert(value, value.ALatestServiceStaffRoleList[i]));
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	}
}