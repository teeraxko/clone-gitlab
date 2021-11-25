using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class OTPatternSpecificConditionDB : DataAccessBase
	{
		#region - Constant -
		private const int PATTERN_CODE = 0;
		private const int EMPLOYEE_NO = 1;
		#endregion

		#region - Private -
		private EmployeeDB dbEmployee;
		private OTPatternDB dbOTPattern;
		private OTPatternSpecificCondition objOTPatternSpecificCondition;
		private bool disposed  = false;
		#endregion

//		============================== Constructor ==============================
		public OTPatternSpecificConditionDB(): base()
		{
			dbEmployee = new EmployeeDB();
			dbOTPattern = new OTPatternDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Pattern_Code, Employee_No FROM Overtime_Pattern_Specific_Condition ";
		}

		private string getSQLInsert(OTPatternSpecificCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Overtime_Pattern_Specific_Condition (Company_Code, Pattern_Code, Employee_No, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Pattern_Code
			stringBuilder.Append(GetDB(value.AOTPattern.PatternId));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(OTPatternSpecificCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Overtime_Pattern_Specific_Condition SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Pattern_Code = ");
			stringBuilder.Append(GetDB(value.AOTPattern.PatternId));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Employee_No = ");
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
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
			return "DELETE FROM Overtime_Pattern_Specific_Condition ";
		}

		private string getKeyCondition(OTPatternSpecificCondition value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.AOTPattern.PatternId))
			{
				stringBuilder.Append(" AND (Pattern_Code = ");
				stringBuilder.Append(GetDB(value.AOTPattern.PatternId));
				stringBuilder.Append(" ) ");
			}

			if(IsNotNULL(value.AEmployee.EmployeeNo))
			{
				stringBuilder.Append(" AND (Employee_No = ");
				stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
				stringBuilder.Append(" ) ");
			}

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Pattern_Code, Employee_No ";
		}
		#endregion

		#region - Fill -

		private void fillOTPatternSpecificCondition(ref OTPatternSpecificCondition value, Company aCompany, SqlDataReader dataReader)
		{
			value.AOTPattern = dbOTPattern.GetOTPattern((string)dataReader[PATTERN_CODE], aCompany);
			value.AEmployee = dbEmployee.GetFormerlyEmployee((string)dataReader[EMPLOYEE_NO], aCompany);
		}

		private bool fillOTPatternSpecificConditionList(ref OTPatternConditionList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			OTPatternList listOTPattern = new OTPatternList(value.Company);
			dbOTPattern.FillOTPatternList(ref listOTPattern);

            //TODO : Check about employee is terminate, how about it ?  : woranai
			EmployeeList listEmployee = new EmployeeList(value.Company);
			dbEmployee.FillAvailableEmployeeList(ref listEmployee);

			try
			{
				while (dataReader.Read())
				{
					result = true;
					objOTPatternSpecificCondition = new OTPatternSpecificCondition(value.Company);
					objOTPatternSpecificCondition.AOTPattern = listOTPattern[(string)dataReader[PATTERN_CODE]];
					objOTPatternSpecificCondition.AEmployee = listEmployee[(string)dataReader[EMPLOYEE_NO]];

					if(objOTPatternSpecificCondition.AEmployee != null && objOTPatternSpecificCondition.AEmployee.EmployeeNo != "")
					{
						value.Add(objOTPatternSpecificCondition);
					}
				}
				objOTPatternSpecificCondition = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			return result;
		}

		private bool fillOTPatternList(OTPatternList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			OTPatternList listOTPattern = new OTPatternList(value.Company);
			dbOTPattern.FillOTPatternList(ref listOTPattern);

			try
			{
				while (dataReader.Read())
				{
					result = true;
					value.Add(listOTPattern[(string)dataReader[PATTERN_CODE]]);
				}
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{
				tableAccess.CloseDataReader();
				listOTPattern = null;
				dataReader = null;
			}
			return result;
		}
		#endregion

//		============================== Public Method ==============================
		public bool FillOTPatternSpecificConditionList(OTPatternList value, Employee employee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(employee));
			stringBuilder.Append(getOrderby());

			return fillOTPatternList(value, stringBuilder.ToString());
		}

		public bool FillOTPatternSpecificConditionList(ref OTPatternConditionList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillOTPatternSpecificConditionList(ref value, stringBuilder.ToString());
		}

		public bool FillOTPatternSpecificConditionList(ref OTPatternConditionList value, Employee employee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(employee));			
			stringBuilder.Append(getOrderby());

			return fillOTPatternSpecificConditionList(ref value, stringBuilder.ToString());
		}

		public bool InsertOTPatternSpecificCondition(OTPatternSpecificCondition value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateOTPatternSpecificCondition(OTPatternSpecificCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteOTPatternSpecificCondition(OTPatternSpecificCondition value, Company aCompany)
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
						dbEmployee.Dispose();

						dbEmployee = null;
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
