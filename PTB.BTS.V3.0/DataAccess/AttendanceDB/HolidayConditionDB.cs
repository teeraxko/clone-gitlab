using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;
using Entity.ContractEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class HolidayConditionDB : DataAccessBase
	{
		#region - Constant -
		private const int POSITION_TYPE = 0;
		private const int SERVICE_STAFF_TYPE = 1;
		private const int CUSTOMER_CODE = 2;
		private const int CUSTOMER_DEPARTMENT_CODE = 3;
		private const int SATURDAY_STATUS = 4;
		private const int SUNDAY_STATUS = 5;
		private const int TRADITIONAL_HOLIDAY_PATTERN_CODE = 6;
		#endregion

		#region - Private -
		private PositionTypeDB dbPositionType;
		private ServiceStaffTypeDB dbServiceStaffType;
		private CustomerDB dbCustomer;
		private CustomerDepartmentDB dbCustomerDepartment;
		private TraditionalHolidayPatternDB dbTraditionalHolidayPattern;

		private HolidayCondition objHolidayCondition;
		private bool disposed  = false;
		#endregion

		//		============================== Constructor ==============================
		public HolidayConditionDB() : base()
		{
			dbPositionType = new PositionTypeDB();
			dbServiceStaffType = new ServiceStaffTypeDB();
			dbCustomer = new CustomerDB();
			dbCustomerDepartment = new CustomerDepartmentDB();
			dbTraditionalHolidayPattern = new TraditionalHolidayPatternDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Position_Type, Service_Staff_Type, Customer_Code, Customer_Department_Code, Saturday_Status, Sunday_Status, Traditional_Holiday_Pattern_Code FROM Holiday_Condition ";
		}

		private string getSQLInsert(HolidayCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Holiday_Condition (Company_Code, Position_Type, Service_Staff_Type, Customer_Code, Customer_Department_Code, Saturday_Status, Sunday_Status, Traditional_Holiday_Pattern_Code, Process_Date, Process_User) ");
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
            
			//Saturday_Status
			stringBuilder.Append(GetDB(value.SaturdayBreak));
			stringBuilder.Append(", ");

			//Sunday_Status
			stringBuilder.Append(GetDB(value.SundayBreak));
			stringBuilder.Append(", ");

			//Traditional_Holiday_Pattern_Code
			if(value.ATraditionalHolidayPattern != null)
			{
				stringBuilder.Append(GetDB(value.ATraditionalHolidayPattern.Code));
				stringBuilder.Append(", ");
			}
			else
			{
				stringBuilder.Append(GetDB(NullConstant.STRING));
				stringBuilder.Append(", ");
			}

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(HolidayCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Holiday_Condition SET ");

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

			stringBuilder.Append(" Saturday_Status = ");
			stringBuilder.Append(GetDB(value.SaturdayBreak));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Sunday_Status = ");
			stringBuilder.Append(GetDB(value.SundayBreak));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Traditional_Holiday_Pattern_Code = ");
			if(value.ATraditionalHolidayPattern != null)
			{				
				stringBuilder.Append(GetDB(value.ATraditionalHolidayPattern.Code));
				stringBuilder.Append(", ");
			}
			else
			{
				stringBuilder.Append(GetDB(NullConstant.STRING));
				stringBuilder.Append(", ");
			}

			stringBuilder.Append(" Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
			
			return stringBuilder.ToString();
		}	

		private string getSQLDelete()
		{
			return "DELETE FROM Holiday_Condition ";
		}

		private string getKeyCondition(HolidayCondition value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			
			if(IsNotNULL(value.APositionType.Type))
			{
				stringBuilder.Append(" AND (Position_Type = ");
				stringBuilder.Append(GetDB(value.APositionType.Type));
				stringBuilder.Append(")");
			}

			if(IsNotNULL(value.AServiceStaffType.Type))
			{
				stringBuilder.Append(" AND (Service_Staff_Type = ");
				stringBuilder.Append(GetDB(value.AServiceStaffType.Type));
				stringBuilder.Append(")");
			}

			if(IsNotNULL(value.ACustomerDepartment.ACustomer.Code))
			{
				stringBuilder.Append(" AND (Customer_Code = ");
				stringBuilder.Append(GetDB(value.ACustomerDepartment.ACustomer.Code));
				stringBuilder.Append(")");
			}

			if(IsNotNULL(value.ACustomerDepartment.Code))
			{
				stringBuilder.Append(" AND (Customer_Department_Code = ");
				stringBuilder.Append(GetDB(value.ACustomerDepartment.Code));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Position_Type, Service_Staff_Type, Customer_Code, Customer_Department_Code ";
		}
		#endregion

		#region - fill -
		private void fillHolidayCondition(ref HolidayCondition aHolidayCondition, Company aCompany, SqlDataReader dataReader)
		{
			aHolidayCondition.APositionType = dbPositionType.GetDBPositionType((string)dataReader[POSITION_TYPE], aCompany);
			aHolidayCondition.AServiceStaffType = dbServiceStaffType.GetDBServiceStaffType((string)dataReader[SERVICE_STAFF_TYPE], aCompany);
			aHolidayCondition.ACustomerDepartment = dbCustomerDepartment.GetDBCustomerDepartment((string)dataReader[CUSTOMER_DEPARTMENT_CODE], (string)dataReader[CUSTOMER_CODE], aCompany);
			aHolidayCondition.SaturdayBreak = GetBool((string)dataReader[SATURDAY_STATUS]);
			aHolidayCondition.SundayBreak = GetBool((string)dataReader[SUNDAY_STATUS]);
			aHolidayCondition.ATraditionalHolidayPattern = (TraditionalHolidayPattern)dbTraditionalHolidayPattern.GetDBDualField((string)dataReader[TRADITIONAL_HOLIDAY_PATTERN_CODE], aCompany);
		}

		private bool fillHolidayConditionList(ref HolidayConditionList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objHolidayCondition = new HolidayCondition();
					fillHolidayCondition(ref objHolidayCondition, value.Company, dataReader);
					value.Add(objHolidayCondition);
				}
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

		private bool fillHolidayCondition(ref HolidayCondition value, Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillHolidayCondition(ref value, aCompany, dataReader);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;
		}

		#endregion

//		============================== Public Method ==============================
		public HolidayCondition GetHolidayCondition(PositionType positionType, ServiceStaffType serviceStaffType, ContractBase contract, Company aCompany)
		{
			objHolidayCondition = new HolidayCondition();
			objHolidayCondition.APositionType = positionType;
			objHolidayCondition.AServiceStaffType = serviceStaffType;
			objHolidayCondition.ACustomerDepartment = contract.ACustomerDepartment;

			if(FillHolidayCondition(ref objHolidayCondition, aCompany))
			{
				return objHolidayCondition;
			}
			else
			{
				objHolidayCondition = null;
				return null;
			}
		}

		public bool FillHolidayCondition(ref HolidayCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return fillHolidayCondition(ref value, aCompany, stringBuilder.ToString());
		}

		public bool FillHolidayConditionList(ref HolidayConditionList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillHolidayConditionList(ref value, stringBuilder.ToString());
		}

		public bool FillHolidayConditionList(ref HolidayConditionList value, HolidayCondition aHolidayCondition)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(aHolidayCondition));
			stringBuilder.Append(getOrderby());

			return fillHolidayConditionList(ref value, stringBuilder.ToString());
		}

		public bool InsertHolidayCondition(HolidayCondition value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateHolidayCondition(HolidayCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteHolidayCondition(HolidayCondition value, Company aCompany)
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
						dbPositionType.Dispose();
						dbServiceStaffType.Dispose();
						dbCustomer.Dispose();
						dbCustomerDepartment.Dispose();

						dbPositionType = null;
						dbServiceStaffType = null;
						dbCustomer = null;
						dbCustomerDepartment = null;
						objHolidayCondition = null;
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
