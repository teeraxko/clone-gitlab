using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public class OvertimeVariantTableDB : DataAccessBase
	{
		#region - Constant -
		private const int TIME_FROM = 0;
		private const int TIME_TO = 1;
		private const int IN_OUT_STATUS = 2;
		private const int EQUIVALENT_TIME_GROUP_I = 3;
		private const int EQUIVALENT_TIME_GROUP_II = 4;
		private const int EQUIVALENT_TIME_GROUP_III = 5;
		private const int CHARGE_EQUIVALENT_TIME_GROUP_I = 6;
		private const int CHARGE_EQUIVALENT_TIME_GROUP_II = 7;
		private const int CHARGE_EQUIVALENT_TIME_GROUP_III = 8;
		private const int OT_RATE_WORKING_DAY = 9;
		private const int OT_RATE_HOLIDAY = 10;
		#endregion

		#region - Private -
			private OTVariant objOtVariant;
			private bool disposed = false;
		#endregion
		
//		============================== Constructor ==============================
		public OvertimeVariantTableDB() : base()
		{
			objOtVariant = new OTVariant();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Time_From, Time_To, In_Out_Status, Equivalent_Time_Group_I, Equivalent_Time_Group_II, Equivalent_Time_Group_III, Charge_Equivalent_Time_Group_I, Charge_Equivalent_Time_Group_II, Charge_Equivalent_Time_Group_III, OT_Rate_Working_Day, OT_Rate_Holiday FROM Overtime_Variant_Table ";
		}

		private string getSQLInsert(OTVariant value,ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Overtime_Variant_Table (Company_Code, Time_From, Time_To, In_Out_Status, Equivalent_Time_Group_I, Equivalent_Time_Group_II, Equivalent_Time_Group_III, Charge_Equivalent_Time_Group_I, Charge_Equivalent_Time_Group_II, Charge_Equivalent_Time_Group_III, OT_Rate_Working_Day, OT_Rate_Holiday, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Time_From			
			stringBuilder.Append(GetDB(value.APeriod.From));
			stringBuilder.Append(", ");

			//Time_To
			stringBuilder.Append(GetDB(value.APeriod.To));
			stringBuilder.Append(", ");

			//In_Out_Status
			stringBuilder.Append(GetDB(value.InOutStatus));
			stringBuilder.Append(", ");

			//Equivalent_Time_Group_I
			stringBuilder.Append(GetDB(value.EquivalentTimeGroupI));
			stringBuilder.Append(", ");

			//Equivalent_Time_Group_II
			stringBuilder.Append(GetDB(value.EquivalentTimeGroupII));
			stringBuilder.Append(", ");

			//Equivalent_Time_Group_III
			stringBuilder.Append(GetDB(value.EquivalentTimeGroupIII));
			stringBuilder.Append(", ");

			//Charge_Equivalent_Time_Group_I
			stringBuilder.Append(GetDB(value.ChargeEquivalentTimeGroupI));
			stringBuilder.Append(", ");

			//Charge_Equivalent_Time_Group_II
			stringBuilder.Append(GetDB(value.ChargeEquivalentTimeGroupII));
			stringBuilder.Append(", ");

			//Charge_Equivalent_Time_Group_III
			stringBuilder.Append(GetDB(value.ChargeEquivalentTimeGroupIII));
			stringBuilder.Append(", ");

			//OT_Rate_Working_Day
			stringBuilder.Append(GetDB(value.OtRateWorkingDay));
			stringBuilder.Append(", ");

			//OT_Rate_Holiday
			stringBuilder.Append(GetDB(value.OtRateHoliday));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(OTVariant value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Overtime_Variant_Table SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Time_From = ");
			stringBuilder.Append(GetDB(value.APeriod.From));
			stringBuilder.Append(", ");

			stringBuilder.Append("Time_To = ");
			stringBuilder.Append(GetDB(value.APeriod.To));
			stringBuilder.Append(", ");
	
			stringBuilder.Append("In_Out_Status = ");
			stringBuilder.Append(GetDB(value.InOutStatus));
			stringBuilder.Append(", ");

			stringBuilder.Append("Equivalent_Time_Group_I = ");
			stringBuilder.Append(GetDB(value.EquivalentTimeGroupI));
			stringBuilder.Append(", ");

			stringBuilder.Append("Equivalent_Time_Group_II = ");
			stringBuilder.Append(GetDB(value.EquivalentTimeGroupII));
			stringBuilder.Append(", ");

			stringBuilder.Append("Equivalent_Time_Group_III = ");
			stringBuilder.Append(GetDB(value.EquivalentTimeGroupIII));
			stringBuilder.Append(", ");

			stringBuilder.Append("Charge_Equivalent_Time_Group_I = ");
			stringBuilder.Append(GetDB(value.ChargeEquivalentTimeGroupI));
			stringBuilder.Append(", ");

			stringBuilder.Append("Charge_Equivalent_Time_Group_II = ");
			stringBuilder.Append(GetDB(value.ChargeEquivalentTimeGroupII));
			stringBuilder.Append(", ");

			stringBuilder.Append("Charge_Equivalent_Time_Group_III = ");
			stringBuilder.Append(GetDB(value.ChargeEquivalentTimeGroupIII));
			stringBuilder.Append(", ");

			stringBuilder.Append("OT_Rate_Working_Day = ");
			stringBuilder.Append(GetDB(value.OtRateWorkingDay));
			stringBuilder.Append(", ");

			stringBuilder.Append("OT_Rate_Holiday = ");
			stringBuilder.Append(GetDB(value.OtRateHoliday));
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
			return " DELETE FROM Overtime_Variant_Table ";
		}

		private string getKeyCondition(OTVariant value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.APeriod.From))
			{
				stringBuilder.Append(" AND (Time_From = ");
				stringBuilder.Append(GetDB(value.APeriod.From));
				stringBuilder.Append(")");
			}
			if (IsNotNULL(value.APeriod.To))
			{
				stringBuilder.Append(" AND (Time_To = ");
				stringBuilder.Append(GetDB(value.APeriod.To));
				stringBuilder.Append(")");
			}

			if (IsNotNULL(value.InOutStatus))
			{
				stringBuilder.Append(" AND (In_Out_Status = ");
				stringBuilder.Append(GetDB(value.InOutStatus));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY In_Out_Status, Time_From, Time_To";
		}
		#endregion

		#region - Fill -
		private void fillOTVariant(ref OTVariant value, SqlDataReader dataReader)
		{
			value.APeriod.From = dataReader.GetDateTime(TIME_FROM);
			value.APeriod.To = dataReader.GetDateTime(TIME_TO);
			value.InOutStatus = CTFunction.GetInOutStatusType((string)dataReader[IN_OUT_STATUS]);
			value.EquivalentTimeGroupI = dataReader.GetDateTime(EQUIVALENT_TIME_GROUP_I);
			value.EquivalentTimeGroupII = dataReader.GetDateTime(EQUIVALENT_TIME_GROUP_II);
			value.EquivalentTimeGroupIII= dataReader.GetDateTime(EQUIVALENT_TIME_GROUP_III);
			value.ChargeEquivalentTimeGroupI = dataReader.GetDateTime(CHARGE_EQUIVALENT_TIME_GROUP_I);
			value.ChargeEquivalentTimeGroupII = dataReader.GetDateTime(CHARGE_EQUIVALENT_TIME_GROUP_II);
			value.ChargeEquivalentTimeGroupIII= dataReader.GetDateTime(CHARGE_EQUIVALENT_TIME_GROUP_III);
			value.OtRateWorkingDay = CTFunction.GetRateType((string)dataReader[OT_RATE_WORKING_DAY]);
			value.OtRateHoliday = CTFunction.GetRateType((string)dataReader[OT_RATE_HOLIDAY]);
		}

		private bool fillOTVariantList(ref OTVariantList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objOtVariant = new OTVariant();
					fillOTVariant(ref objOtVariant, dataReader);
					value.Add(objOtVariant);
				}
				objOtVariant = null;
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

		private bool fillOTVariant(ref OTVariant value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillOTVariant(ref value, dataReader);
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
		public bool FillOTVariant(OTVariant value, DateTime time, IN_OUT_STATUS_TYPE status, ictus.Common.Entity.Company company)
		{
			DateTime timeCondition = NullConstant.GetTime(time);
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(company));
			stringBuilder.Append(" AND (Time_From <= ");
			stringBuilder.Append(GetDB(timeCondition));
			stringBuilder.Append(") ");
			stringBuilder.Append(" AND (Time_To >= ");
			stringBuilder.Append(GetDB(timeCondition));
			stringBuilder.Append(") ");
			stringBuilder.Append(" AND (In_Out_Status = ");
			stringBuilder.Append(GetDB(status));
			stringBuilder.Append(") ");
			stringBuilder.Append(getOrderby());

			bool result = fillOTVariant(ref value, stringBuilder.ToString());

			stringBuilder = null;
			return result;
		}

		public bool FillOTVariantThatDate(OTVariant value, DateTime time, IN_OUT_STATUS_TYPE status,ictus.Common.Entity.Company company)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(company));
			stringBuilder.Append(" AND (Time_From <= ");
			stringBuilder.Append(GetDB(time));
			stringBuilder.Append(") ");
			stringBuilder.Append(" AND (Time_To >= ");
			stringBuilder.Append(GetDB(time));
			stringBuilder.Append(") ");
			stringBuilder.Append(" AND (In_Out_Status = ");
			stringBuilder.Append(GetDB(status));
			stringBuilder.Append(") ");
			stringBuilder.Append(getOrderby());

			bool result = fillOTVariant(ref value, stringBuilder.ToString());

			stringBuilder = null;
			return result;
		}


		public bool FillOTVariantList(ref OTVariantList aOTVariantList, OTVariant aOTVariant)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aOTVariantList.Company));
			stringBuilder.Append(getKeyCondition(aOTVariant));
			stringBuilder.Append(getOrderby());

			return fillOTVariantList(ref aOTVariantList, stringBuilder.ToString());
		}

		public bool FillOTVariantList(ref OTVariantList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillOTVariantList(ref value, stringBuilder.ToString());
		}

		public bool InsertOTVariant(OTVariant value,ictus.Common.Entity.Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateOTVariant(OTVariant value,ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteOTVariant(OTVariant value,ictus.Common.Entity.Company aCompany)
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
						objOtVariant = null;
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