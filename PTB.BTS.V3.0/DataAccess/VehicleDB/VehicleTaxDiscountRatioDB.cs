using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.VehicleDB
{
	public class VehicleTaxDiscountRatioDB : DataAccessBase
	{
		#region - Constant -	
		private const int MODEL_TYPE = 0;
		private const int TAX_YEAR = 1;
		private const int DISCOUNT_PERCENTAGE = 2;
		#endregion

		#region - Private -
		private ModelTypeDB dbModelType;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public VehicleTaxDiscountRatioDB() : base()
		{
			dbModelType = new ModelTypeDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Model_Type, Tax_Year, Discount_Percentage FROM Vehicle_Tax_Discount_Ratio ";
		}

		private string getSQLInsert(VehicleTaxDiscountRatio value)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Vehicle_Tax_Discount_Ratio (Model_Type, Tax_Year, Discount_Percentage, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Model_Type			
			stringBuilder.Append(GetDB(value.AModelType.Code));
			stringBuilder.Append(", ");

			//Tax_Year			
			stringBuilder.Append(GetDB(value.TaxYear));
			stringBuilder.Append(", ");

			//Discount_Percentage
			stringBuilder.Append(GetDB(value.DiscountPercentage));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(VehicleTaxDiscountRatio value)
		{
			StringBuilder stringBuilder = new StringBuilder(" UPDATE Vehicle_Tax_Discount_Ratio SET ");
			stringBuilder.Append("Model_Type = ");
			stringBuilder.Append(GetDB(value.AModelType.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("Tax_Year = ");
			stringBuilder.Append(GetDB(value.TaxYear));
			stringBuilder.Append(", ");

			stringBuilder.Append("Discount_Percentage = ");
			stringBuilder.Append(GetDB(value.DiscountPercentage));
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
			return " DELETE FROM Vehicle ";
		}

		private string getKeyCondition(VehicleTaxDiscountRatio value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value.AModelType != null && IsNotNULL(value.AModelType.Code))
			{
				stringBuilder.Append(" AND (Model_Type = ");
				stringBuilder.Append(GetDB(value.AModelType.Code));
				stringBuilder.Append(")");
			}

			if(IsNotNULL(value.TaxYear))
			{
				stringBuilder.Append(" AND (Tax_Year = ");
				stringBuilder.Append(GetDB(value.TaxYear));
				stringBuilder.Append(")");			
			}			
			return stringBuilder.ToString();
		}
		#endregion

		#region - Fill -
		private void fillVehicleTaxDiscountRatio(ref VehicleTaxDiscountRatio value, SqlDataReader dataReader)
		{
			value.AModelType = (ModelType)dbModelType.GetMTB((string)dataReader[MODEL_TYPE]);
			value.TaxYear = dataReader.GetByte(TAX_YEAR);
			value.DiscountPercentage = dataReader.GetByte(DISCOUNT_PERCENTAGE);
		}

		private bool fillVehicleTaxDiscountRatio(ref VehicleTaxDiscountRatio value,  string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillVehicleTaxDiscountRatio(ref value, dataReader);
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
		#endregion

//		============================== Public Method ==============================
		public bool FillVehicleTaxDiscountRatio(ref VehicleTaxDiscountRatio value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition(value));

			return fillVehicleTaxDiscountRatio(ref value, stringBuilder.ToString());
		}

		public bool InsertVehicleTaxDiscountRatio(VehicleTaxDiscountRatio value)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateVehicleTaxDiscountRatio(VehicleTaxDiscountRatio value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value));
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteVehicleTaxDiscountRatio(VehicleTaxDiscountRatio value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition());
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
