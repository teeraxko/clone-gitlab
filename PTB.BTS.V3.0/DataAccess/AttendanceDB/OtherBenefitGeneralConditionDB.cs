//using System;
//using System.Text;
//using System.Data;
//using System.Data.SqlClient;
//
//using ictus.PIS.PI.Entity;
//using Entity.ContractEntities;
//using Entity.AttendanceEntities;
//
//using DataAccess.CommonDB;
//using DataAccess.PiDB;
//using DataAccess.ContractDB;
//
//using SystemFramework.AppConfig;
//
//namespace DataAccess.AttendanceDB
//{
//	public class OtherBenefitGeneralConditionDB : DataAccessBase
//	{
//		#region - Constant -
//		private const int POSITION_CODE = 0;
//		private const int CUSTOMER_CODE = 1;
//		private const int WHOLE_RATE_STATUS = 2;
//		private const int BENEFIT_AMOUNT = 3;
//		#endregion
//
//		#region - Private -
//			private bool disposed = false;
//			private PositionDB dbPosition;
//			private CustomerDB dbCustomer;
//
//			private OtherBenefitGeneralCondition objOtherBenefitGeneralCondition;
//		#endregion
//
////		============================== Constructor ==============================
//		public OtherBenefitGeneralConditionDB() : base()
//		{
//			dbPosition = new PositionDB();
//			dbCustomer = new CustomerDB();
//		}
//
////		================================Private Method===================
//		#region - getSQL -
//		private string getSQLSelect()
//		{
//			return "SELECT Position_Code, Customer_Code, Whole_Rate_Status, Benefit_Amount FROM Other_Benefit_Condition_General";
//		}
//
//		private string getSQLInsert(OtherBenefitGeneralCondition value, Company aCompany)
//		{
//			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Other_Benefit_Condition_General (Company_Code, Position_Code, Customer_Code, Whole_Rate_Status, Benefit_Amount, Process_Date, Process_User)");
//			stringBuilder.Append("VALUES (");
//			//			Company_Code
//			stringBuilder.Append(GetDB(aCompany.CompanyCode));
//			stringBuilder.Append(", ");
//
//			//			Position_Code
//			stringBuilder.Append(GetDB(value.APosition.PositionCode));
//			stringBuilder.Append(", ");
//
//			//			Customer_Code
//			stringBuilder.Append(GetDB(value.ACustomer.Code));
//			stringBuilder.Append(", ");
//
//			//			Whole_Rate_Status
//			stringBuilder.Append(GetDB(value.WholeRate));
//			stringBuilder.Append(", ");
//
//			//			Benefit_Amount
//			stringBuilder.Append(GetDB(value.BaseAmount));
//			stringBuilder.Append(", ");
//
//			//			Process_Date
//			stringBuilder.Append(GetDateDB());
//			stringBuilder.Append(", ");
//			//			Process_User
//			stringBuilder.Append(GetDB(UserProfile.UserID));
//			stringBuilder.Append(")");
//
//			return stringBuilder.ToString();
//		}
//
//		private string getSQLUpdate(OtherBenefitGeneralCondition value, Company aCompany)
//		{
//			StringBuilder stringBuilder = new StringBuilder("UPDATE Other_Benefit_Condition_General SET ");
//
//			//			Company_Code
//			stringBuilder.Append("Company_Code = ");
//			stringBuilder.Append(GetDB(aCompany.CompanyCode));
//			stringBuilder.Append(", ");
//
//			//			Position_Code
//			stringBuilder.Append("Position_Code = ");
//			stringBuilder.Append(GetDB(value.APosition.PositionCode));
//			stringBuilder.Append(", ");
//
//			//			Customer_Code
//			stringBuilder.Append("Customer_Code = ");
//			stringBuilder.Append(GetDB(value.ACustomer.Code));
//			stringBuilder.Append(", ");
//
//			//			Whole_Rate_Status
//			stringBuilder.Append("Whole_Rate_Status = ");
//			stringBuilder.Append(GetDB(value.WholeRate));
//			stringBuilder.Append(", ");
//
//			//			Benefit_Amount
//			stringBuilder.Append("Benefit_Amount = ");
//			stringBuilder.Append(GetDB(value.BaseAmount));
//			stringBuilder.Append(", ");
//
//			//			Process_Date
//			stringBuilder.Append("Process_Date = ");
//			stringBuilder.Append(GetDateDB());
//			stringBuilder.Append(", ");
//			//			Process_User
//			stringBuilder.Append("Process_User = ");
//			stringBuilder.Append(GetDB(UserProfile.UserID));
//			
//			return stringBuilder.ToString();
//		}	
//
//		private string getSQLDelete()
//		{
//			return "DELETE FROM Other_Benefit_Condition_General ";
//		}
//
//		private string getKeyCondition(Position aPosition, Customer aCustomer)
//		{
//			StringBuilder stringBuilder = new StringBuilder();
//			
//			if (IsNotNULL(aPosition.PositionCode))
//			{
//				stringBuilder.Append(" AND (Position_Code = ");
//				stringBuilder.Append(GetDB(aPosition.PositionCode));
//				stringBuilder.Append(")");
//			}
//			
//			if (IsNotNULL(aCustomer.Code))
//			{
//				stringBuilder.Append(" AND (Customer_Code = ");
//				stringBuilder.Append(GetDB(aCustomer.Code));
//				stringBuilder.Append(")");
//			}
//			
//
//			return stringBuilder.ToString();
//		}
//		private string getOrderby()
//		{
//			return " ORDER BY Position_Code, Customer_Code ";
//		}
//		#endregion
//
//		#region - Fill -
//		private void fillOtherBenefitGeneralCondition(ref OtherBenefitGeneralCondition aOtherBenefitGeneralCondition, Company aCompany, SqlDataReader dataReader)
//		{
//			aOtherBenefitGeneralCondition.APosition = dbPosition.GetDBPosition((string)dataReader[POSITION_CODE], aCompany);
//			aOtherBenefitGeneralCondition.ACustomer = dbCustomer.GetDBCustomer((string)dataReader[CUSTOMER_CODE], aCompany);
//			aOtherBenefitGeneralCondition.WholeRate = CTFunction.GetWholeRateType((string)dataReader[WHOLE_RATE_STATUS]);		
//			aOtherBenefitGeneralCondition.BaseAmount  = dataReader.GetDecimal(BENEFIT_AMOUNT);
//		}
//
//		private bool fillOtherBenefitGeneralConditionData(ref OtherBenefitGeneralConditionList aOtherBenefitGeneralConditionList, string sql)
//		{
//			bool result = false;
//			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);	
//			try
//			{
//				while (dataReader.Read())
//				{
//					result = true;
//					objOtherBenefitGeneralCondition = new OtherBenefitGeneralCondition();
//					fillOtherBenefitGeneralCondition(ref objOtherBenefitGeneralCondition, aOtherBenefitGeneralConditionList.Company, dataReader);					
//					aOtherBenefitGeneralConditionList.Add(objOtherBenefitGeneralCondition);
//				}
//			}
//			catch(IndexOutOfRangeException ein)
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
//		public bool FillOtherBenefitGeneralConditionData(ref OtherBenefitGeneralConditionList value)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
//			stringBuilder.Append(getBaseCondition(value.Company));
//			stringBuilder.Append(getOrderby());
//
//			return fillOtherBenefitGeneralConditionData(ref value, stringBuilder.ToString());
//		}
//
//		public bool InsertOtherBenefitGeneralCondition(OtherBenefitGeneralCondition value, Company aCompany)
//		{
//			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
//			{return true;}
//			else
//			{return false;}	
//		}
//
//		public bool UpdateOtherBenefitGeneralCondition(OtherBenefitGeneralCondition value, Company aCompany)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
//			stringBuilder.Append(getBaseCondition(aCompany));
//			stringBuilder.Append(getKeyCondition(value.APosition, value.ACustomer));
//
//			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
//			{return true;}
//			else
//			{return false;}
//		}
//
//		public bool DeleteOtherBenefitGeneralCondition(OtherBenefitGeneralCondition value, Company aCompany)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
//			stringBuilder.Append(getBaseCondition(aCompany));
//			stringBuilder.Append(getKeyCondition(value.APosition, value.ACustomer));
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
//						dbPosition.Dispose();
//						dbCustomer.Dispose();
//						objOtherBenefitGeneralCondition.Dispose();
//					
//						dbPosition = null;
//						dbCustomer = null;
//						objOtherBenefitGeneralCondition = null;
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