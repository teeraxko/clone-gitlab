//using System;
//using System.Text;
//using System.Data;
//using System.Data.SqlClient;
//
//using ictus.PIS.PI.Entity;
//using Entity.CommonEntity;
//using Entity.AttendanceEntities;
//
//using DataAccess.PiDB;
//using DataAccess.CommonDB;
//
//using SystemFramework.AppConfig;
//
//namespace DataAccess.AttendanceDB
//{
//	public class OtherBenefitSpecificConditionDB : DataAccessBase
//	{
//		#region - Constant -
//		private const int BENEFIT_CODE = 0;
//		private const int EMPLOYEE_NO = 1;
//		private const int WHOLE_RATE_STATUS = 2;
//		private const int BENEFIT_AMOUNT = 3;
//		#endregion Private
//
//		#region - Private -
//			private OtherBenefitSpecificCondition objOtherBenefitSpecificCondition;
////			private OtherBenefitDB dbOtherBenefit;
//			private EmployeeDB  dbEmployee;
//			private bool disposed = false;
//		#endregion
//
////		============================== Constructor ==============================
//		public OtherBenefitSpecificConditionDB() : base()
//		{ 
//			dbEmployee = new EmployeeDB();
//		}
//
////		==================================Private Method===============
//		#region - getSQL -
//		private string getSQLSelect()
//		{
//			return "SELECT Employee_No, Whole_Rate_Status, Benefit_Amount FROM Other_Benefit_Condition_Specific ";
//		}
//
//		private string getSQLInsert(OtherBenefitSpecificCondition value, Company aCompany)
//		{
//			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Other_Benefit_Condition_Specific(Company_Code, Employee_No, Whole_Rate_Status, Benefit_Amount, Process_Date, Process_User) ");
//			stringBuilder.Append("VALUES (");
//
//			//Company_Code
//			stringBuilder.Append(GetDB(aCompany.CompanyCode));
//			stringBuilder.Append(", ");
//
//			//Employee_No
//            stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
//			stringBuilder.Append(", ");
//
//			//Whole_Rate_Status
//			stringBuilder.Append(GetDB(value.WholeRate));
//            stringBuilder.Append(", ");
//
//			//Benefit_Amount
//			stringBuilder.Append(GetDB(value.BaseAmount));
//			stringBuilder.Append(", ");
//
//			//Process_Date
//			stringBuilder.Append(GetDateDB());
//			stringBuilder.Append(", ");
//
//			//Process_User
//			stringBuilder.Append(GetDB(UserProfile.UserID));
//			stringBuilder.Append(")");
//
//			return stringBuilder.ToString();
//		}
//
//		private string getSQLUpdate(OtherBenefitSpecificCondition value, Company aCompany)
//		{
//			StringBuilder stringBuilder = new StringBuilder("UPDATE Other_Benefit_Condition_Specific SET ");
//
//			stringBuilder.Append("Company_Code = ");
//			stringBuilder.Append(GetDB(aCompany.CompanyCode));
//			stringBuilder.Append(", ");
//
//			stringBuilder.Append("Employee_No = ");
//			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
//			stringBuilder.Append(", ");
//
//			stringBuilder.Append("Whole_Rate_Status = ");
//			stringBuilder.Append(GetDB(value.WholeRate));
//			stringBuilder.Append(", ");
//
//			stringBuilder.Append("Benefit_Amount = ");
//			stringBuilder.Append(GetDB(value.BaseAmount));
//			stringBuilder.Append(", ");
//			
//			stringBuilder.Append("Process_User = ");
//			stringBuilder.Append(GetDB(UserProfile.UserID));
//			
//			return stringBuilder.ToString();
//		}
//
//		private string getSQLDelete()
//		{
//			return "DELETE FROM Other_Benefit_Condition_Specific ";
//		}
//
//		private string getKeyCondition(Employee aEmployee)
//		{
//			StringBuilder stringBuilder = new StringBuilder();
//			if (IsNotNULL(aEmployee.EmployeeNo))
//			{
//				stringBuilder.Append(" AND (Employee_No = ");
//				stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
//				stringBuilder.Append(")");
//			}
//
//			return stringBuilder.ToString();
//		}
//
//		private string getOrderby()
//		{
//			return " ORDER BY Employee_No ";
//		}
//		#endregion
//
//		#region - Fill -
//		private void fillOtherBenefitSpecificCondition(ref OtherBenefitSpecificCondition value, Company aCompany, SqlDataReader dataReader)
//		{
//			value.AEmployee = dbEmployee.GetEmployee((string)dataReader[EMPLOYEE_NO], aCompany);
//			value.WholeRate = CTFunction.GetWholeRateType((string)dataReader[WHOLE_RATE_STATUS]);
//			value.BaseAmount = dataReader.GetDecimal(BENEFIT_AMOUNT);
//		}
//		
//		private bool fillOtherBenefitSpecificConditionData(ref OtherBenefitSpecificConditionList value, string sql)
//		{
//			bool result = false;
//			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
//			try
//			{
//				while (dataReader.Read())
//				{
//					result = true;
//					objOtherBenefitSpecificCondition = new OtherBenefitSpecificCondition();
//					fillOtherBenefitSpecificCondition(ref objOtherBenefitSpecificCondition, value.Company, dataReader);
//					value.Add(objOtherBenefitSpecificCondition);
//				}
//			}
//			catch (IndexOutOfRangeException ein)
//			{
//				throw ein;
//			}
//			finally
//			{
//				tableAccess.CloseDataReader();
//			}			
//			return result;				
//		}
//
//		private bool fillOtherBenefitSpecificCondition(ref OtherBenefitSpecificCondition value, string sql)
//		{
//			bool result;
//			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
//			try
//			{
//				if (dataReader.Read())
//				{
////					fillOtherBenefitSpecificCondition(ref value, dataReader);
//					result = true;
//				}
//				else
//				{
//					result = false;
//				}
//			}
//			catch (IndexOutOfRangeException ein)
//			{
//				throw ein;
//			}
//			finally
//			{
//				tableAccess.CloseDataReader();
//			}			
//			return result;				
//		}
//		#endregion
////		============================== Public Method ==============================
//		public bool FillOtherBenefitSpecificConditionData(ref OtherBenefitSpecificConditionList value)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
//			stringBuilder.Append(getBaseCondition(value.Company));
//			stringBuilder.Append(getOrderby());
//
//			return fillOtherBenefitSpecificConditionData(ref value, stringBuilder.ToString());
//		}
//
//		public bool FillOtherBenefitSpecificConditionData(ref OtherBenefitSpecificConditionList value, OtherBenefitSpecificCondition aOtherBenefitSpecificCondition)
//		{
//			return FillOtherBenefitSpecificConditionData(ref value, aOtherBenefitSpecificCondition.AEmployee);
//		}
//
//		public bool FillOtherBenefitSpecificConditionData(ref OtherBenefitSpecificConditionList value, Employee aEmployee)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
//			stringBuilder.Append(getBaseCondition(value.Company));
//			stringBuilder.Append(getKeyCondition(aEmployee));
//			stringBuilder.Append(getOrderby());
//
//			return fillOtherBenefitSpecificConditionData(ref value, stringBuilder.ToString());
//		}
//
//		public bool InsertOtherBenefitSpecificCondition(OtherBenefitSpecificCondition value)
//		{
//			if (tableAccess.ExecuteSQL(getSQLInsert(value, value.AEmployee.Company))>0)
//			{return true;}
//			else
//			{return false;}	
//		}
//
//		public bool UpdateOtherBenefitSpecificCondition(OtherBenefitSpecificCondition value)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, value.AEmployee.Company));
//			stringBuilder.Append(getBaseCondition(value.AEmployee.Company));
//			stringBuilder.Append(getKeyCondition(value.AEmployee));
//
//			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
//			{return true;}
//			else
//			{return false;}
//		}
//
//		public bool DeleteOtherBenefitSpecificCondition(OtherBenefitSpecificCondition value)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
//			stringBuilder.Append(getBaseCondition(value.AEmployee.Company));
//			stringBuilder.Append(getKeyCondition(value.AEmployee));
//
//			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
//			{return true;}
//			else
//			{return false;}
//		}
//
//		#region IDisposable Members
//		protected override void Dispose(bool disposing)
//		{
//			if(!this.disposed)
//			{
//				try
//				{
//					if(disposing)
//					{
//						objOtherBenefitSpecificCondition.Dispose();
//						dbEmployee.Dispose();
//						
//						objOtherBenefitSpecificCondition = null;
//						dbEmployee = null;
//					}
//					this.disposed = true;
//				}
//				finally
//				{
//					base.Dispose(disposing);
//				}
//			}
//		}
//		#endregion
//
//	}
//}
