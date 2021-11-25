using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.VehicleDB
{
	public class InsuranceTypeOneDetailDB : DataAccessBase
	{
		#region - Constant -
		private const int POLICY_NO = 0;
		private const int VEHICLE_NO = 1;
		private const int ORDER_NO = 2;
		private const int AFFILIATE_DATE = 3;
		private const int SUM_ASSURED = 4;
		private const int PREMIUM_AMOUNT = 5;
		private const int VAT_AMOUNT = 6;
		private const int REVENUE_STAMP_FEE = 7;
		#endregion

		#region - Private -
		private VehicleDB dbVehicle;
		private VehicleInsuranceTypeOne objVehicleInsuranceTypeOne;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public InsuranceTypeOneDetailDB() : base()
		{
			dbVehicle = new VehicleDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Policy_No, Vehicle_No, Oreder_No, Affiliate_Date, Sum_Assured, Premium_Amount, VAT_Amount, Revenue_Stamp_Fee FROM Insurance_Type_One_Detail ";
		}

		private string getSQLInsert(VehicleInsuranceTypeOne value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Insurance_Type_One_Detail (Company_Code, Policy_No, Vehicle_No, Oreder_No, Affiliate_Date, Sum_Assured, Premium_Amount, VAT_Amount, Revenue_Stamp_Fee, Process_Date, Process_User) VALUES ( ");
			
			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Policy_No
			stringBuilder.Append(GetDB(value.PolicyNo));
			stringBuilder.Append(", ");

			//Vehicle_No
			stringBuilder.Append(GetDB(value.AVehicleInfo.VehicleNo));
			stringBuilder.Append(", ");

			//Oreder_No
			stringBuilder.Append(GetDB(value.OrderNo));
			stringBuilder.Append(", ");

			//Affiliate_Date
			stringBuilder.Append(GetDB(value.AffiliateDate));
			stringBuilder.Append(", ");

			//Sum_Assured
			stringBuilder.Append(GetDB(value.SumAssured));
			stringBuilder.Append(", ");

			//Premium_Amount
			stringBuilder.Append(GetDB(value.PremiumAmount));
			stringBuilder.Append(", ");

			//VAT_Amount
			stringBuilder.Append(GetDB(value.VatAmount));
			stringBuilder.Append(", ");

			//Revenue_Stamp_Fee
			stringBuilder.Append(GetDB(value.RevenueStampFee));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(VehicleInsuranceTypeOne value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Insurance_Type_One_Detail SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Policy_No = ");
			stringBuilder.Append(GetDB(value.PolicyNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Vehicle_No = ");
			stringBuilder.Append(GetDB(value.AVehicleInfo.VehicleNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Oreder_No = ");
			stringBuilder.Append(GetDB(value.OrderNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Affiliate_Date = ");
			stringBuilder.Append(GetDB(value.AffiliateDate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Sum_Assured = ");
			stringBuilder.Append(GetDB(value.SumAssured));
			stringBuilder.Append(", ");

			stringBuilder.Append("Premium_Amount = ");
			stringBuilder.Append(GetDB(value.PremiumAmount));
			stringBuilder.Append(", ");

			stringBuilder.Append("VAT_Amount = ");
			stringBuilder.Append(GetDB(value.VatAmount));
			stringBuilder.Append(", ");

			stringBuilder.Append("Revenue_Stamp_Fee = ");
			stringBuilder.Append(GetDB(value.RevenueStampFee));
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
			return " DELETE FROM Insurance_Type_One_Detail ";
		}

		private string getKeyCondition(VehicleInsuranceTypeOne value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.PolicyNo))
			{
				stringBuilder.Append(" AND (Policy_No = ");
				stringBuilder.Append(GetDB(value.PolicyNo));
				stringBuilder.Append(")");
			}
			if (value.AVehicleInfo != null && IsNotNULL(value.AVehicleInfo.VehicleNo))
			{
				stringBuilder.Append(" AND (Vehicle_No = ");
				stringBuilder.Append(GetDB(value.AVehicleInfo.VehicleNo));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getKeyCondition(InsuranceDocumentBase value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.PolicyNo))
			{
				stringBuilder.Append(" AND (Policy_No = ");
				stringBuilder.Append(GetDB(value.PolicyNo));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

        private string getKeyCondition(VehicleInfo value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (value != null)
            {
                stringBuilder.Append(" AND (Vehicle_No = ");
                stringBuilder.Append(GetDB(value.VehicleNo));
                stringBuilder.Append(") ORDER BY Affiliate_Date ASC");
            }

            return stringBuilder.ToString();
        }

		private string getOrderby()
		{
			return " ORDER BY Oreder_No";
//			Plate_No_Running_No, Plate_No_Prefix ";
		}
	
		#endregion

		#region - Fill -
		private void fillInsuranceTypeOneDetail(ref VehicleInsuranceTypeOne value, Company aCompany, SqlDataReader dataReader)
		{
			value.PolicyNo = (string)dataReader[POLICY_NO];
			value.AVehicleInfo = dbVehicle.GetDBVehicleInfo(dataReader.GetInt32(VEHICLE_NO), aCompany);
			value.OrderNo = dataReader.GetInt16(ORDER_NO);
			value.AffiliateDate = dataReader.GetDateTime(AFFILIATE_DATE);
			value.SumAssured = dataReader.GetDecimal(SUM_ASSURED);
			value.PremiumAmount = dataReader.GetDecimal(PREMIUM_AMOUNT); 
			value.VatAmount = dataReader.GetDecimal(VAT_AMOUNT);
			value.RevenueStampFee = dataReader.GetDecimal(REVENUE_STAMP_FEE);		
		}

		private bool fillInsuranceTypeOneDetailList(ref VehicleInsuranceList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objVehicleInsuranceTypeOne = new VehicleInsuranceTypeOne();
					fillInsuranceTypeOneDetail(ref objVehicleInsuranceTypeOne, value.Company, dataReader);
					value.Add(objVehicleInsuranceTypeOne);
				}
				objVehicleInsuranceTypeOne = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;		
		}

		private bool fillInsuranceTypeOneDetail(ref VehicleInsuranceTypeOne value, Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillInsuranceTypeOneDetail(ref value, aCompany, dataReader);
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
		public bool FillInsuranceTypeOneDetail(ref VehicleInsuranceTypeOne value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return fillInsuranceTypeOneDetail(ref value, aCompany, stringBuilder.ToString());
		}

		public bool FillInsuranceTypeOneDetail(ref InsuranceTypeOne value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.AVehicleInsuranceList.Company));
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(getOrderby());			

			VehicleInsuranceList vehicleInsuranceList = value.AVehicleInsuranceList;
			return fillInsuranceTypeOneDetailList(ref vehicleInsuranceList, stringBuilder.ToString());
		} 

		public bool FillInsuranceTypeOneDetailList(ref VehicleInsuranceList value, VehicleInsuranceTypeOne aVehicleInsuranceTypeOne)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(aVehicleInsuranceTypeOne));
			stringBuilder.Append(getOrderby());		

			return fillInsuranceTypeOneDetailList(ref value, stringBuilder.ToString());
		}

        public bool FillInsuranceTypeOneDetailList(ref VehicleInsuranceList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value.AInsuranceDocument));
            stringBuilder.Append(getOrderby());

            return fillInsuranceTypeOneDetailList(ref value, stringBuilder.ToString());
        }

        public bool FillInsuranceTypeOneDetailList(ref VehicleInsuranceList value, VehicleInfo vehicleInfo)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition());
            stringBuilder.Append(getKeyCondition(vehicleInfo));

            return fillInsuranceTypeOneDetailList(ref value, stringBuilder.ToString());
        }

        public int CountData(InsuranceTypeOne value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT COUNT(*) FROM Insurance_Type_One_Detail ");
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));

            return (int)tableAccess.ExecuteScalar(stringBuilder.ToString());
        }

        public bool InsertInsuranceTypeOneDetail(VehicleInsuranceTypeOne value, Company aCompany)
        {
            if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany)) > 0)
            { return true; }
            else
            { return false; }
        }

		public bool InsertInsuranceTypeOneDetail(InsuranceTypeOne value)
		{
			if(value.AVehicleInsuranceList.Count==0)
				return true;

			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i<value.AVehicleInsuranceList.Count; i++)
			{
				stringBuilder.Append(getSQLInsert(value.AVehicleInsuranceList[i], value.AVehicleInsuranceList.Company));
			}
			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool UpdateInsuranceTypeOneDetail(VehicleInsuranceTypeOne value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteInsuranceTypeOneDetail(VehicleInsuranceTypeOne value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public void DeleteInsuranceTypeOneDetail(InsuranceTypeOne value)
		{
			VehicleInsuranceTypeOne vehicleInsuranceTypeOne = new VehicleInsuranceTypeOne();
			vehicleInsuranceTypeOne.PolicyNo = value.PolicyNo;
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.AVehicleInsuranceList.Company));
			stringBuilder.Append(getKeyCondition(vehicleInsuranceTypeOne));
			tableAccess.ExecuteSQL(stringBuilder.ToString());

			vehicleInsuranceTypeOne = null;
			stringBuilder = null;
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
