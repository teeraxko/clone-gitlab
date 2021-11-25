using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public class HolidayConditionSpecificDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int SATURDAY_STATUS = 1;
		private const int SUNDAY_STATUS = 2;
		private const int TRADITIONAL_HOLIDAY_PATTERN_CODE = 3;
		#endregion

		#region - Private -
		private TraditionalHolidayPatternDB dbTraditionalHolidayPattern;
		private HolidayConditionSpecific objHolidayConditionSpecific;
		private EmployeeDB dbEmployee;
		private bool disposed  = false;
		#endregion

//		============================== Constructor ==============================
		public HolidayConditionSpecificDB() : base()
		{
			dbTraditionalHolidayPattern = new TraditionalHolidayPatternDB();
			dbEmployee = new EmployeeDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Employee_No, Saturday_Status, Sunday_Status, Traditional_Holiday_Pattern_Code FROM Holiday_Condition_Specific ";
		}

        private string getSQLInsert(HolidayConditionSpecific value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Holiday_Condition_Specific (Company_Code, Employee_No, Saturday_Status, Sunday_Status, Traditional_Holiday_Pattern_Code, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
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

        private string getSQLUpdate(HolidayConditionSpecific value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Holiday_Condition_Specific SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Employee_No = ");
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
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
			return "DELETE FROM Holiday_Condition_Specific ";
		}

		private string getKeyCondition(HolidayConditionSpecific value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			
			if(IsNotNULL(value.AEmployee.EmployeeNo))
			{
				stringBuilder.Append(" AND (Employee_No = ");
				stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No ";
		}
		#endregion

		#region - fill -
        private void fillHolidayConditionSpecific(ref HolidayConditionSpecific value, ictus.Common.Entity.Company aCompany, SqlDataReader dataReader)
		{
			value.AEmployee = dbEmployee.GetFormerlyEmployee((string)dataReader[EMPLOYEE_NO], aCompany);
			value.SaturdayBreak = GetBool((string)dataReader[SATURDAY_STATUS]);
			value.SundayBreak = GetBool((string)dataReader[SUNDAY_STATUS]);
			value.ATraditionalHolidayPattern = (TraditionalHolidayPattern)dbTraditionalHolidayPattern.GetDBDualField((string)dataReader[TRADITIONAL_HOLIDAY_PATTERN_CODE], aCompany);
		}

		private bool fillHolidayConditionSpecificList(ref HolidayConditionSpecificList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objHolidayConditionSpecific = new HolidayConditionSpecific();
					fillHolidayConditionSpecific(ref objHolidayConditionSpecific, value.Company, dataReader);
					value.Add(objHolidayConditionSpecific);
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

        private bool fillHolidayConditionSpecific(ref HolidayConditionSpecific value, ictus.Common.Entity.Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillHolidayConditionSpecific(ref value, aCompany, dataReader);
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
		public HolidayConditionSpecific GetHolidayConditionSpecific(Employee aEmployee)
		{
			objHolidayConditionSpecific = new HolidayConditionSpecific();
			objHolidayConditionSpecific.AEmployee = aEmployee;

			if(FillHolidayConditionSpecific(ref objHolidayConditionSpecific, aEmployee.Company))
			{
				return objHolidayConditionSpecific;
			}
			else
			{
				objHolidayConditionSpecific = null;
				return null;
			}
		}

        public bool FillHolidayConditionSpecific(ref HolidayConditionSpecific value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return fillHolidayConditionSpecific(ref value, aCompany, stringBuilder.ToString());
		}

		public bool FillHolidayConditionSpecificList(ref HolidayConditionSpecificList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillHolidayConditionSpecificList(ref value, stringBuilder.ToString());
		}

        public bool InsertHolidayConditionSpecific(HolidayConditionSpecific value, ictus.Common.Entity.Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

        public bool UpdateHolidayConditionSpecific(HolidayConditionSpecific value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

        public bool DeleteHolidayConditionSpecific(HolidayConditionSpecific value, ictus.Common.Entity.Company aCompany)
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
						dbTraditionalHolidayPattern.Dispose();

						dbTraditionalHolidayPattern = null;
						objHolidayConditionSpecific = null;
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
