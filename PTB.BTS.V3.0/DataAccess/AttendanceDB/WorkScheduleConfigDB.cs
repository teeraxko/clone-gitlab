//using System;
//using System.Text;
//using System.Data;
//using System.Data.SqlClient;
//
//using Entity.CommonEntity;
//using DataAccess.CommonDB;
//using SystemFramework.AppConfig;
//using ictus.PIS.PI.Entity;
//
//using Entity.AttendanceEntities;
//
//namespace DataAccess.AttendanceDB
//{	
//	public class WorkScheduleConfigDB : DataAccessBase
//	{
//
//		#region - Constant -
//		private const int CONFIGURATIONID = 0;
//		private const int POSITIONCODE = 1;
//		private const int HIREDATESTATUS = 2;
//		private const int KINDOFOTSTATUS = 3;
//		private const int SATURDAYSTATUS = 4;
//		private const int SUNDAYSTATUS = 5;
//		private const int TRADITIONALHOLIDAYSTATUS = 6;
//		private const int TRADITIONALHOLIDAYPATTERNID = 7;
//		private const int HIREDATESINCE = 8;
//		private const int KINDOFOT = 9;
//		#endregion
//
//		#region Private
//		private string getSQLSelect()
//		{
//			return "SELECT Company_Code, Configuration_ID, Position_Code, Hire_Date_Status, Kind_Of_OT_Status, Saturday_Status, Sunday_Status, Traditional_Holiday_Status, Traditional_Holiday_Pattern_ID, Hire_Date_Since, Kind_Of_OT, Process_User FROM Work_Schedule_Config";
//		}
//
//		private string getSQLInsert(WorkScheduleConfig aWorkScheduleConfig, Company aCompany)
//		{
//			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Work_Schedule_Config (Company_Code, Configuration_ID, Position_Code, Hire_Date_Status, Kind_Of_OT_Status, Saturday_Status, Sunday_Status, Traditional_Holiday_Status, Traditional_Holiday_Pattern_ID, Hire_Date_Since, Kind_Of_OT, Process_Date, Process_User)");
//			stringBuilder.Append("VALUES (");
//			//			Company_Code
//			stringBuilder.Append(GetDB(aCompany.CompanyCode));
//			stringBuilder.Append(", ");
//			//			Configuration_ID
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.ConfigurationID));
//			stringBuilder.Append(", ");
//			//			Position_Code
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.PositionCode));
//			stringBuilder.Append(", ");
//			//			Hire_Date_Status 
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.HireDateStatus));
//			stringBuilder.Append(", ");
//
//			//			Kind_Of_OT_Status
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.KindOfOTStatus));
//			stringBuilder.Append(", ");
//
//			//			Saturday_Status 
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.SaturdayStatus));
//			stringBuilder.Append(", ");
//
//			//			Traditional_Holiday_Status
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.TraditionalHolidayStatus));
//			stringBuilder.Append(", ");
//
//			//			 Sunday_Status
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.SundayStatus));
//			stringBuilder.Append(", ");
//
//			//			 Traditional_Holiday_Pattern_ID
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.TraditionalHolidayPatternID));
//			stringBuilder.Append(", ");
//
//			//			  Hire_Date_Since
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.HireDateSince));
//			stringBuilder.Append(", ");
//
//			//			 Kind_Of_OT
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.KindOfOT));
//			stringBuilder.Append(", ");
//
//			//			Process_Date
//			stringBuilder.Append(GetDateDB());
//			stringBuilder.Append(", ");
//
//			//			Process_User
//			stringBuilder.Append(GetDB(UserProfile.UserID));
//			stringBuilder.Append(")");
//
//			return stringBuilder.ToString();
//		}
//
//		private string getSQLUpdate(WorkScheduleConfig aWorkScheduleConfig, Company aCompany)
//		{
//			StringBuilder stringBuilder = new StringBuilder("UPDATE Work_Schedule_Config SET ");
//
//			//			Company_Code
//			stringBuilder.Append(" Company_Code = ");
//			stringBuilder.Append(GetDB(aCompany.CompanyCode));
//			stringBuilder.Append(", ");
//			//			Configuration_ID
//			stringBuilder.Append("Configuration_ID = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.ConfigurationID));
//			stringBuilder.Append(", ");
//			//			 Position_Code 
//			stringBuilder.Append("Position_Code = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.PositionCode));
//			stringBuilder.Append(", ");
//
//			//			Hire_Date_Status 
//			stringBuilder.Append("Hire_Date_Status = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.HireDateStatus));
//			stringBuilder.Append(", ");
//
//			//			Kind_Of_OT_Status
//			stringBuilder.Append("Kind_Of_OT_Status = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.KindOfOTStatus));
//			stringBuilder.Append(", ");
//
//			//			Saturday_Status 
//			stringBuilder.Append("Saturday_Status = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.SaturdayStatus));
//			stringBuilder.Append(", ");
//
//			//			Traditional_Holiday_Status
//			stringBuilder.Append("Traditional_Holiday_Status = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.TraditionalHolidayStatus));
//			stringBuilder.Append(", ");
//
//			//			 Sunday_Status
//			stringBuilder.Append("Sunday_Status = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.SundayStatus));
//			stringBuilder.Append(", ");
//
//			//			 Traditional_Holiday_Pattern_ID
//			stringBuilder.Append("Traditional_Holiday_Pattern_ID = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.TraditionalHolidayPatternID));
//			stringBuilder.Append(", ");
//
//			//			  Hire_Date_Since
//			stringBuilder.Append("Hire_Date_Since = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.HireDateSince));
//			stringBuilder.Append(", ");
//
//			//			 Kind_Of_OT
//			stringBuilder.Append("Kind_Of_OT = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.KindOfOT));
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
//			stringBuilder.Append(getCondition(aWorkScheduleConfig, aCompany));
//
//			return stringBuilder.ToString();
//		}
//	
//
//		private string getSQLDelete(WorkScheduleConfig aWorkScheduleConfig, Company aCompany)
//		{
//			StringBuilder stringBuilder = new StringBuilder("DELETE FROM Work_Schedule_Config ");
//			stringBuilder.Append(getCondition(aWorkScheduleConfig, aCompany));
//
//			return stringBuilder.ToString();
//		}
//
//		private string getCondition(WorkScheduleConfig aWorkScheduleConfig, Company aCompany)
//		{
//			StringBuilder stringBuilder = new StringBuilder(" WHERE (Company_Code = ");
//			stringBuilder.Append(GetDB(aCompany.CompanyCode));
//			stringBuilder.Append(") AND (Configuration_ID = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.ConfigurationID));
//			stringBuilder.Append(") AND (Position_Code = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.PositionCode));
//			stringBuilder.Append(") AND (Hire_Date_Status = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.HireDateStatus));
//			stringBuilder.Append(") AND (Kind_Of_OT_Status = ");
//			stringBuilder.Append(GetDB(aWorkScheduleConfig.KindOfOTStatus));
//			stringBuilder.Append(")");
//			return stringBuilder.ToString();
//		}
//		private string getOrderby()
//		{
//			return " ORDER BY Configuration_ID, Position_Code, Hire_Date_Status, Kind_Of_OT_Status ";
//		}
//		#endregion
//
////		============================== Constructor ==============================
//		public WorkScheduleConfigDB()
//		{
//		}
//
////		private bool fillList(ref WorkScheduleConfigList aWorkScheduleConfigList,string sql)
////		{
////			bool result = false;
////			aWorkScheduleConfigList = new WorkScheduleConfigList();
////			WorkScheduleConfig workScheduleConfig;
////			SqlDataReader dataReader = tableAccess.ExecuteDataReader("SELECT  Configuration_ID, Position_Code, Hire_Date_Status, Kind_Of_OT_Status, Saturday_Status, Sunday_Status, Traditional_Holiday_Status, Traditional_Holiday_Pattern_ID, Hire_Date_Since, Kind_Of_OT FROM Work_Schedule_Config");
////			try
////			{
////				while (dataReader.Read())
////				{
////					result = true;
////					workScheduleConfig = new WorkScheduleConfig();
////					workScheduleConfig.ConfigurationID = dataReader[0].ToString();
////					workScheduleConfig.PositionCode = dataReader.GetString(POSITIONCODE);
////					workScheduleConfig.HireDateStatus = dataReader.GetString(HIREDATESTATUS);
////					workScheduleConfig.KindOfOTStatus = dataReader.GetString(KINDOFOTSTATUS);
////					workScheduleConfig.SaturdayStatus = dataReader.GetString(SATURDAYSTATUS);
////					workScheduleConfig.SundayStatus = dataReader.GetString(SUNDAYSTATUS);
////					workScheduleConfig.TraditionalHolidayStatus = dataReader.GetString(TRADITIONALHOLIDAYSTATUS);;
////					workScheduleConfig.TraditionalHolidayPatternID = dataReader.GetString(TRADITIONALHOLIDAYPATTERNID);
////					workScheduleConfig.HireDateSince = dataReader.GetDateTime(HIREDATESINCE);
////					workScheduleConfig.KindOfOT = dataReader.GetString(KINDOFOT);
////
////					aWorkScheduleConfigList.Add(workScheduleConfig);
////				}
////			}
////			catch(IndexOutOfRangeException ein)
////			{
////				throw ein;
////			}
////			finally
////			{
////				tableAccess.CloseDataReader();				
////			}
////			return result;
////		}
//	}
//}
