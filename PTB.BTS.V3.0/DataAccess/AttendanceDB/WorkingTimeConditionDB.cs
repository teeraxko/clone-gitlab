using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;
using Entity.ContractEntities;

using DataAccess.CommonDB;
using DataAccess.ContractDB;
using DataAccess.PiDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class WorkingTimeConditionDB : DataAccessBase
	{
		#region - Constant -
		private const int POSITION_TYPE = 0;
		private const int SERVICE_STAFF_TYPE = 1;
		private const int CUSTOMER_CODE = 2;
		private const int CUSTOMER_DEPARTMENT_CODE = 3;
		private const int TABLE_ID = 4;
		#endregion

		#region - Private -
		private PositionTypeDB dbPositionType;
		private ServiceStaffTypeDB dbServiceStaffType;
		private CustomerDepartmentDB dbCustomerDepartment;
		private WorkingTimeTableDB dbWorkingTimeTable;

		private WorkingTimeCondition objWorkingTimeCondition;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public WorkingTimeConditionDB()
		{
			dbPositionType = new PositionTypeDB();
			dbServiceStaffType = new ServiceStaffTypeDB();
			dbCustomerDepartment = new CustomerDepartmentDB();
			dbWorkingTimeTable = new WorkingTimeTableDB();
		}

//		============================== Private Method ==============================
		#region -getSQL-
		private string getSQLSelect()
		{
			return "SELECT Position_Type, Service_Staff_Type, Customer_Code, Customer_Department_Code, Table_ID FROM Working_Time_Condition ";
		}

		private string getSQLInsert(WorkingTimeCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Working_Time_Condition (Company_Code, Position_Type, Service_Staff_Type, Customer_Code, Customer_Department_Code, Table_ID, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Position_Type
			stringBuilder.Append(GetDB(value.APositionType.Type));
			stringBuilder.Append(", ");

			//Service_Staff_Type
			stringBuilder.Append(GetDB(value.AServiceStaffType.Type));
			stringBuilder.Append(", ");

			//Customer_Code
			stringBuilder.Append(GetDB(value.ACustomerDepartment.ACustomer.Code));
			stringBuilder.Append(", ");

			//Customer_Department_Code
			stringBuilder.Append(GetDB(value.ACustomerDepartment.Code));
			stringBuilder.Append(", ");

			//Table_ID
			stringBuilder.Append(GetDB(value.AWorkingTimeTable.TableID));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(WorkingTimeCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Working_Time_Condition SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Position_Type = ");
			stringBuilder.Append(GetDB(value.APositionType.Type));
			stringBuilder.Append(", ");
			
			stringBuilder.Append(" Service_Staff_Type = ");
			stringBuilder.Append(GetDB(value.AServiceStaffType.Type));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Customer_Code = ");
			stringBuilder.Append(GetDB(value.ACustomerDepartment.ACustomer.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Customer_Department_Code = ");
			stringBuilder.Append(GetDB(value.ACustomerDepartment.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Table_ID = ");
			stringBuilder.Append(GetDB(value.AWorkingTimeTable.TableID));
			stringBuilder.Append(", ");
			
			stringBuilder.Append(" Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");
			
			stringBuilder.Append(" Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
			
			return stringBuilder.ToString();
		}
	
		private string getSQLDelete()
		{
			return "DELETE FROM Working_Time_Condition ";
		}

		private string getKeyCondition(PositionType aPositionType, ServiceStaffType aServiceStaffType, Customer aCustomer, CustomerDepartment aCustomerDepartment)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if (IsNotNULL(aPositionType))
			{
				stringBuilder.Append(" AND (Position_Type = ");
				stringBuilder.Append(GetDB(aPositionType));
				stringBuilder.Append(")");
			}

			if (IsNotNULL(aServiceStaffType.Type))
			{
				stringBuilder.Append(" AND (Service_Staff_Type = ");
				stringBuilder.Append(GetDB(aServiceStaffType.Type));
				stringBuilder.Append(")");
			}

			if ((aCustomer!=null) && IsNotNULL(aCustomer.Code))
			{
				stringBuilder.Append(" AND (Customer_Code = ");
				stringBuilder.Append(GetDB(aCustomer.Code));
				stringBuilder.Append(")");
			}

			if ((aCustomerDepartment!=null) && IsNotNULL(aCustomerDepartment.Code))
			{
				stringBuilder.Append(" AND (Customer_Department_Code = ");
				stringBuilder.Append(GetDB(aCustomerDepartment.Code));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();		
		}

		private string getEntityCondition(WorkingTimeTable value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if (IsNotNULL(value.TableID))
			{
				stringBuilder.Append(" AND (Table_ID = ");
				stringBuilder.Append(GetDB(value.TableID));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Position_Type, Service_Staff_Type, Customer_Code, Customer_Department_Code ";
		}
		#endregion

		#region - Fill -
		private void fillWorkingTimeCondition(ref WorkingTimeCondition value, Company aCompany, SqlDataReader dataReader)
		{
			value.APositionType = dbPositionType.GetDBPositionType((string)dataReader[POSITION_TYPE], aCompany);
			value.AServiceStaffType = dbServiceStaffType.GetDBServiceStaffType((string)dataReader[SERVICE_STAFF_TYPE], aCompany);
			value.AWorkingTimeTable = dbWorkingTimeTable.GetDBWorkingTimeTable((string)dataReader[TABLE_ID], aCompany);
		}

		private void fillWorkingTimeConditionDB(ref WorkingTimeCondition value, Company aCompany, SqlDataReader dataReader)
		{
			value.ACustomerDepartment = dbCustomerDepartment.GetDBCustomerDepartment((string)dataReader[CUSTOMER_DEPARTMENT_CODE], (string)dataReader[CUSTOMER_CODE] ,aCompany);	
			fillWorkingTimeCondition(ref value, aCompany, dataReader);
		}

		private bool fillWorkingTimeConditionList(ref WorkingTimeConditionList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			PositionTypeList listPositionType = new PositionTypeList(value.Company);
			dbPositionType.FillPositionTypeList(ref listPositionType);
			ServiceStaffTypeList listServiceStaffType = new ServiceStaffTypeList(value.Company);
			dbServiceStaffType.FillServiceStaffTypeList(ref listServiceStaffType);
			WorkingTimeTableList listWorkingTimeTable = new WorkingTimeTableList(value.Company);
			dbWorkingTimeTable.FillWorkingTimeTableList(ref listWorkingTimeTable);

			try
			{
				while (dataReader.Read())
				{
					result = true;
					objWorkingTimeCondition = new WorkingTimeCondition();
					objWorkingTimeCondition.APositionType = listPositionType[(string)dataReader[POSITION_TYPE]];
					objWorkingTimeCondition.AServiceStaffType = listServiceStaffType[(string)dataReader[SERVICE_STAFF_TYPE]];
					objWorkingTimeCondition.AWorkingTimeTable = listWorkingTimeTable[(string)dataReader[TABLE_ID]];
					objWorkingTimeCondition.ACustomerDepartment = dbCustomerDepartment.GetDBCustomerDepartment((string)dataReader[CUSTOMER_DEPARTMENT_CODE], (string)dataReader[CUSTOMER_CODE] ,value.Company);	
					fillWorkingTimeCondition(ref objWorkingTimeCondition, value.Company, dataReader);					
					value.Add(objWorkingTimeCondition);
				}
				objWorkingTimeCondition = null;
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();				
			}
			return result;
		}

		private bool fillWorkingTimeCondition(ref WorkingTimeCondition value, Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillWorkingTimeConditionDB(ref value, aCompany, dataReader);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();
			}
			return result;
		}
		#endregion
//		============================== Public Method ==============================
		public WorkingTimeCondition GetWorkingTimeCondition(OfficeStaff value, Company aCompany)
		{
			value.APosition.APositionType.Type = "O";
			objWorkingTimeCondition = new WorkingTimeCondition();

			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value.APosition.APositionType, null, null, null));

			if(fillWorkingTimeCondition(ref objWorkingTimeCondition, aCompany, stringBuilder.ToString()))
			{
				return objWorkingTimeCondition;
			}
			else
			{
				objWorkingTimeCondition = null;
				return null;
			}
		}

		public WorkingTimeCondition GetWorkingTimeCondition(ServiceStaff value, Company aCompany)
		{
			value.APosition.APositionType.Type = "S";
			objWorkingTimeCondition = new WorkingTimeCondition();

			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value.APosition.APositionType, value.AServiceStaffType, value.ACurrentContract.ACustomerDepartment.ACustomer, value.ACurrentContract.ACustomerDepartment));

			if(fillWorkingTimeCondition(ref objWorkingTimeCondition, aCompany, stringBuilder.ToString()))
			{
				return objWorkingTimeCondition;
			}
			else
			{
				objWorkingTimeCondition = null;
				return null;
			}												
		}

		public WorkingTimeCondition GetWorkingTimeCondition(PositionType positionType, ServiceStaffType serviceStaffType, ContractBase contract, Company company)
		{
			objWorkingTimeCondition = new WorkingTimeCondition();

			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(company));
			stringBuilder.Append(getKeyCondition(positionType, serviceStaffType, contract.ACustomer, contract.ACustomerDepartment));

			if(fillWorkingTimeCondition(ref objWorkingTimeCondition, company, stringBuilder.ToString()))
			{
				return objWorkingTimeCondition;
			}
			else
			{
				objWorkingTimeCondition = null;
				return null;
			}												
		}

		public bool FillWorkingTimeCondition(ref WorkingTimeCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value.APositionType, value.AServiceStaffType, value.ACustomerDepartment.ACustomer, value.ACustomerDepartment));

			return fillWorkingTimeCondition(ref value, aCompany, stringBuilder.ToString());
		}

		public bool FillWorkingTimeConditionList(ref WorkingTimeConditionList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillWorkingTimeConditionList(ref value, stringBuilder.ToString());
		}

		public bool FillWorkingTimeConditionList(ref WorkingTimeConditionList value, WorkingTimeCondition aWorkingTimeCondition)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(aWorkingTimeCondition.APositionType, aWorkingTimeCondition.AServiceStaffType, aWorkingTimeCondition.ACustomerDepartment.ACustomer, aWorkingTimeCondition.ACustomerDepartment));
			stringBuilder.Append(getEntityCondition(aWorkingTimeCondition.AWorkingTimeTable));
			stringBuilder.Append(getOrderby());

			return fillWorkingTimeConditionList(ref value, stringBuilder.ToString());
		}

		public bool FillWorkingTimeConditionList(ref WorkingTimeConditionList value, WorkingTimeTable aWorkingTimeTable)
		{
			objWorkingTimeCondition = new WorkingTimeCondition();
			objWorkingTimeCondition.AWorkingTimeTable = aWorkingTimeTable;
			return FillWorkingTimeConditionList(ref value, objWorkingTimeCondition);
		}

		public bool InsertWorkingTimeCondition(WorkingTimeCondition value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateWorkingTimeCondition(WorkingTimeCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value.APositionType, value.AServiceStaffType, value.ACustomerDepartment.ACustomer, value.ACustomerDepartment));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteWorkingTimeCondition(WorkingTimeCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value.APositionType, value.AServiceStaffType, value.ACustomerDepartment.ACustomer, value.ACustomerDepartment));
			stringBuilder.Append(getEntityCondition(value.AWorkingTimeTable));

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
						dbPositionType.Dispose();
						dbServiceStaffType.Dispose();
						dbCustomerDepartment.Dispose();
						dbWorkingTimeTable.Dispose();
					
						dbPositionType = null;
						dbServiceStaffType = null;
						dbCustomerDepartment = null;
						dbWorkingTimeTable = null;
						objWorkingTimeCondition = null;
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