using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.VehicleDB
{
	public class VehicleTaxDB : DataAccessBase
	{
		#region - Constant -		
		private const int VEHICLE_NO = 0;
		private const int START_DATE = 1;
		private const int END_DATE = 2;
		private const int TAX_AMOUNT = 3;
		#endregion

		#region - Private -
		private VehicleDB dbVehicle;
		private VehicleTax objVehicleTax;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public VehicleTaxDB() : base()
		{
			dbVehicle = new VehicleDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Vehicle_No, Start_Date, End_Date, Tax_Amount FROM Vehicle_Tax ";
		}

        private string getSQLInsert(VehicleTax value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Vehicle_Tax (Company_Code, Vehicle_No, Start_Date, End_Date, Tax_Amount, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Vehicle_No
			stringBuilder.Append(GetDB(value.AVehicle.VehicleNo));
			stringBuilder.Append(", ");
			
			//Start_Date
			stringBuilder.Append(GetDB(value.APeriod.From));
			stringBuilder.Append(", ");
				
			//End_Date
			stringBuilder.Append(GetDB(value.APeriod.To));
			stringBuilder.Append(", ");
			
			//Tax_Amount
			stringBuilder.Append(GetDB(value.TaxAmount));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

        private string getSQLUpdate(VehicleTax value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Vehicle_Tax SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Vehicle_No = ");
			stringBuilder.Append(GetDB(value.AVehicle.VehicleNo));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Start_Date = ");
			stringBuilder.Append(GetDB(value.APeriod.From));
			stringBuilder.Append(", ");
				
			stringBuilder.Append("End_Date = ");
			stringBuilder.Append(GetDB(value.APeriod.To));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Tax_Amount = ");
			stringBuilder.Append(GetDB(value.TaxAmount));
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
			return " DELETE FROM Vehicle_Tax ";
		}

		private string getKeyCondition(VehicleTax value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value.AVehicle != null && IsNotNULL(value.AVehicle.VehicleNo))
			{
				stringBuilder.Append(" AND (Vehicle_No = ");
				stringBuilder.Append(GetDB(value.AVehicle.VehicleNo));
				stringBuilder.Append(")");
			}
			if (value.APeriod != null && IsNotNULL(value.APeriod.From))
			{
				stringBuilder.Append(" AND (Start_Date = ");
				stringBuilder.Append(GetDB(value.APeriod.From));
				stringBuilder.Append(")");
			}
			if (value.APeriod != null && IsNotNULL(value.APeriod.To))
			{
				stringBuilder.Append(" AND (End_Date = ");
				stringBuilder.Append(GetDB(value.APeriod.To));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getCurrentVehicleTaxCondition(VehicleTax value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value.AVehicle != null && IsNotNULL(value.AVehicle.VehicleNo))
			{
				stringBuilder.Append(" AND (End_Date = (SELECT MAX(End_Date) FROM Vehicle_Tax WHERE Vehicle_No = ");
				stringBuilder.Append(GetDB(value.AVehicle.VehicleNo));
				stringBuilder.Append(" )) ");
			}
			return stringBuilder.ToString();
		}

		private string getBeginVehicleTaxCondition(VehicleTax value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value.AVehicle != null && IsNotNULL(value.AVehicle.VehicleNo))
			{
				stringBuilder.Append(" AND (Vehicle_No = ");
				stringBuilder.Append(GetDB(value.AVehicle.VehicleNo));
				stringBuilder.Append(" ) ");
			}
			if (value.AVehicle != null && IsNotNULL(value.AVehicle.RegisterDate))
			{
				stringBuilder.Append(" AND (YEAR(Start_Date) = ");
				stringBuilder.Append(GetDB(value.AVehicle.RegisterDate.Year));
				stringBuilder.Append(" ) ");
			}
			return stringBuilder.ToString();		
		}

		private string getOrderby()
		{
			return " ORDER BY Vehicle_No, Start_Date, End_Date ";
		}
		#endregion

		#region - Fill -
        private void fillVehicleTax(ref VehicleTax value, ictus.Common.Entity.Company aCompany, SqlDataReader dataReader)
		{
			value.AVehicle = dbVehicle.GetDBVehicleGeneral(dataReader.GetInt32(VEHICLE_NO),aCompany);
			value.APeriod.From = dataReader.GetDateTime(START_DATE);
			value.APeriod.To = dataReader.GetDateTime(END_DATE);
			value.TaxAmount = dataReader.GetDecimal(TAX_AMOUNT);
		}

        private bool fillVehicleTax(ref VehicleTax value, ictus.Common.Entity.Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillVehicleTax(ref value, aCompany, dataReader);
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

		private bool fillVehicleTaxList(ref VehicleTaxList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objVehicleTax = new VehicleTax();
					fillVehicleTax(ref objVehicleTax, value.Company, dataReader);
					value.Add(objVehicleTax);	
				}
				objVehicleTax = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;		
		}
		#endregion

//		============================== Public Method ==============================
        public bool FillVehicleTax(ref VehicleTax value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return fillVehicleTax(ref value, aCompany, stringBuilder.ToString());
		}

        public bool FillVehicleTaxList(ref VehicleTaxList value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));

			return fillVehicleTaxList(ref value, stringBuilder.ToString());
		}

		public bool FillVehicleTaxList(ref VehicleTaxList value, VehicleTax aVehicleTax, bool isOrderBy)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(aVehicleTax));
            if (isOrderBy)
                stringBuilder.Append(getOrderby());

			return fillVehicleTaxList(ref value, stringBuilder.ToString());
		}

        public bool FillCurrentVehicleTax(ref VehicleTax value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getCurrentVehicleTaxCondition(value));

			return fillVehicleTax(ref value, aCompany, stringBuilder.ToString());
		} 

		public bool FillLatestVehicleTaxList(ref VehicleTaxList value, YearMonth condition)
		{
			StringBuilder stringBuilder = new StringBuilder(" SELECT Vehicle_Tax.Vehicle_No, Vehicle_Tax.Start_Date, Vehicle_Tax.End_Date, Vehicle_Tax.Tax_Amount ");
			stringBuilder.Append(" FROM Vehicle_Tax INNER JOIN ");
			stringBuilder.Append(" (SELECT Vehicle_No, MAX(End_Date) AS Max_End_Date FROM Vehicle_Tax ");
			stringBuilder.Append(" GROUP BY Vehicle_No) Max_Vehicle_Tax ON Vehicle_Tax.Vehicle_No = Max_Vehicle_Tax.Vehicle_No AND Vehicle_Tax.End_Date = Max_Vehicle_Tax.Max_End_Date ");
			stringBuilder.Append(" WHERE (YEAR(Vehicle_Tax.End_Date) = " + condition.Year.ToString() + " ) AND (MONTH(Vehicle_Tax.End_Date) = " + condition.Month.ToString() + " ) ");

			return fillVehicleTaxList(ref value, stringBuilder.ToString());
		}

        public bool FillBeginVehicleTax(ref VehicleTax value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getBeginVehicleTaxCondition(value));

			return fillVehicleTax(ref value, aCompany, stringBuilder.ToString());	
		}

        public bool InsertVehicleTax(VehicleTax value, ictus.Common.Entity.Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

        public bool UpdateVehicleTax(VehicleTax value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteVehicleTax(VehicleTax value, ictus.Common.Entity.Company aCompany)
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
