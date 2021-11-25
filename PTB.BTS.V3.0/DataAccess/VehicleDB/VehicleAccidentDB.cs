using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.VehicleDB
{
    public class VehicleAccidentDB : DataAccessBase, ITableName
	{
		#region - Constant -
		private const int ACCIDENT_NO = 0;
		private const int VEHICLE_NO = 1;
		private const int ACCIDENT_DATE = 2;
		private const int DETAIL_OF_ACCIDENT_LINE1 = 3;
		private const int DETAIL_OF_ACCIDENT_LINE2 = 4;
		private const int DETAIL_OF_ACCIDENT_LINE3 = 5;
		private const int DETAIL_OF_ACCIDENT_LINE4 = 6;
		private const int ACCIDENT_PLACE = 7;
		private const int POLICE_STATION = 8;
		private const int POLICEMAN_NAME = 9;
		private const int CLAIMNANT_STATUS = 10;
		private const int FRONT_GLASS_BROKEN_STATUS = 11;
		private const int EXCESS_STATUS = 12;
		private const int EXCESS_TOTAL_AMOUNT = 13;
		private const int EXCESS_PAID_AMOUNT = 14;
		private const int EXCESS_REMAIN_AMOUNT = 15;
        private const int ACTUAL_EXCESS_AMOUNT = 16;
		private const int DAMAGE_PERCENTAGE = 17;
		private const int PAYER_TYPE = 18;
		private const int PAY_TO_INSURANCE_STATUS = 19;
		private const int PAY_TO_INSURANCE_DATE = 20;
        private const int INSURANCE_CLAIM_NO = 21;
        private const int INSURANCE_RECEIPT_NO = 22;
        private const int INSURANCE_RECEIPT_DATE = 23;
        private const int BILL_BY_INSURANCE_STATUS = 24;
        private const int PAY_TO_INSURANCE_BIZPAC_REFERENCE_NO = 25;
        private const int PAY_TO_INSURANCE_BIZPAC_CONNECTION_DATE = 26;
		private const int PAY_TO_COMPANY_STATUS = 27;
		private const int PAY_TO_COMPANY_DATE = 28;
        private const int PAY_TO_COMPANY_BIZPAC_REFERENCE_NO = 29;
        private const int PAY_TO_COMPANY_BIZPAC_CONNECTION_DATE = 30;
        private const int LATEST_ACCIDENT_UPDATE_DATE = 31;
        private const int LATEST_ACCIDENT_UPDATE_USER = 32;
        private const int INSURANCE_COMPANY_CODE = 33;
		#endregion

		#region - Private -
		private VehicleDB dbVehicle;
		private DriverExcessDeductionDB dbDriverExcessDeduction;
		private VehicleRepairingHistoryDB dbVehicleRepairingHistory;
        private InsuranceCompanyDB dbInsuranceCompany;
		#endregion

		//============================== Constructor ==============================
		public VehicleAccidentDB() : base()
		{
			dbVehicle = new VehicleDB();
			dbDriverExcessDeduction = new DriverExcessDeductionDB();
			dbVehicleRepairingHistory = new VehicleRepairingHistoryDB();
            dbInsuranceCompany = new InsuranceCompanyDB();
		}

		//============================== Private Method ==============================
		#region - getSQL -
		protected string getSQLSelect()
		{
            return " SELECT Accident_No, Vehicle_No, Accident_Date, Detail_Of_Accident_Line1, Detail_Of_Accident_Line2, Detail_Of_Accident_Line3, Detail_Of_Accident_Line4, Accident_Place, Police_Station, Policeman_Name, Claimnant_Status, Front_Glass_Broken_Status, Excess_Status, Excess_Total_Amount, Excess_Paid_Amount, Excess_Remain_Amount, Actual_Excess_Amount, Damage_Percentage, Payer_Type, Pay_To_Insurance_Status, Pay_To_Insurance_Date, Insurance_Claim_No, Insurance_Receipt_No, Insurance_Receipt_Date, Bill_By_Insurance_Status, Pay_To_Insurance_BizPac_Reference_No, Pay_To_Insurance_BizPac_Connection_Date, Pay_To_Company_Status, Pay_To_Company_Date, Pay_To_Company_BizPac_Reference_No, Pay_To_Company_BizPac_Connection_Date, Latest_Accident_Update_Date, Latest_Accident_Update_User, Insurance_Company_Code FROM Vehicle_Accident ";
		}

		private string getSQLInsert(Accident value)
		{
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Vehicle_Accident (Company_Code, Accident_No, Vehicle_No, Accident_Date, Detail_Of_Accident_Line1, Detail_Of_Accident_Line2, Detail_Of_Accident_Line3, Detail_Of_Accident_Line4, Accident_Place, Police_Station, Policeman_Name, Claimnant_Status, Front_Glass_Broken_Status, Excess_Status, Excess_Total_Amount, Excess_Paid_Amount, Excess_Remain_Amount, Actual_Excess_Amount, Damage_Percentage, Payer_Type, Insurance_Company_Code, Pay_To_Insurance_Status, Pay_To_Insurance_Date, Insurance_Claim_No, Insurance_Receipt_No, Insurance_Receipt_Date, Bill_By_Insurance_Status, Pay_To_Insurance_BizPac_Reference_No, Pay_To_Insurance_BizPac_Connection_Date, Pay_To_Company_Status, Pay_To_Company_Date, Pay_To_Company_BizPac_Reference_No, Pay_To_Company_BizPac_Connection_Date, Latest_Accident_Update_Date, Latest_Accident_Update_User, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code			
			stringBuilder.Append(GetDB(value.ADriverExcessDeduction.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Accident_No
			stringBuilder.Append(GetDB(value.RepairingNo));
			stringBuilder.Append(", ");

			//Vehicle_No
			stringBuilder.Append(GetDB(value.VehicleInfo.VehicleNo));
			stringBuilder.Append(", ");

			//Accident_Date
			stringBuilder.Append(GetDB(value.HappenTime));
			stringBuilder.Append(", ");
			
			//Detail_Of_Accident_Line1
			stringBuilder.Append(GetDB(value.DetailOfAccident1));
			stringBuilder.Append(", ");
			
			//Detail_Of_Accident_Line2
			stringBuilder.Append(GetDB(value.DetailOfAccident2));
			stringBuilder.Append(", ");
			
			//Detail_Of_Accident_Line3
			stringBuilder.Append(GetDB(value.DetailOfAccident3));
			stringBuilder.Append(", ");
			
			//Detail_Of_Accident_Line4
			stringBuilder.Append(GetDB(value.DetailOfAccident4));
			stringBuilder.Append(", ");
			
			//Accident_Place
			stringBuilder.Append(GetDB(value.AccidentPlace.Name));
			stringBuilder.Append(", ");

			//Police_Station
			stringBuilder.Append(GetDB(value.APoliceStation.Name));
			stringBuilder.Append(", ");
			
			//Policeman_Name
			stringBuilder.Append(GetDB(value.PolicemanName));
			stringBuilder.Append(", ");
			
			//Claimnant_Status
			stringBuilder.Append(GetDB(value.HasClaimnant));
			stringBuilder.Append(", ");
			
			//Front_Glass_Broken_Status
			stringBuilder.Append(GetDB(value.FrontGlassBroken));
			stringBuilder.Append(", ");
			
			//Excess_Status
			stringBuilder.Append(GetDB(value.HasExcess));
			stringBuilder.Append(", ");
			
			//Excess_Total_Amount
			stringBuilder.Append(GetDB(value.ExcessTotalAmount));
			stringBuilder.Append(", ");
			
			//Excess_Paid_Amount
			stringBuilder.Append(GetDB(value.ExcessPaidAmount));
			stringBuilder.Append(", ");
			
			//Excess_Remain_Amount
			stringBuilder.Append(GetDB(value.ExcessRemainAmount));
			stringBuilder.Append(", ");

            //Actual_Excess_Amount
            stringBuilder.Append(GetDB(value.ActualExcessAmount));
            stringBuilder.Append(", ");

			//Damage_Percentage
			stringBuilder.Append(GetDB(value.DamagePercentage));
			stringBuilder.Append(", ");
			
			//Payer_Type
			stringBuilder.Append(GetDB(value.APayer));
			stringBuilder.Append(", ");

            //Insurance_Company_Code
            if (value.AInsuranceCompany == null || value.AInsuranceCompany.Code == "")
            {
                stringBuilder.Append(GetDB(""));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(value.AInsuranceCompany.Code));
                stringBuilder.Append(", ");
            }

			//Pay_To_Insurance_Status
			stringBuilder.Append(GetDB(value.PaidToInsurance));
			stringBuilder.Append(", ");
			
			//Pay_To_Insurance_Date
			stringBuilder.Append(GetDB(value.PaidToInsuranceDate));
			stringBuilder.Append(", ");
			
            //Insurance_Claim_No
            stringBuilder.Append(GetDB(value.InsuranceClaimNo));
			stringBuilder.Append(", ");
            
            //Insurance_Receipt_No
            stringBuilder.Append(GetDB(value.InsuranceReceiptNo));
			stringBuilder.Append(", ");
            
            //Insurance_Receipt_Date
            stringBuilder.Append(GetDB(value.InsuranceReceiptDate));
			stringBuilder.Append(", ");

            //Bill_By_Insurance_Status
            stringBuilder.Append(GetDB(value.BillByInsuranceStatus));
			stringBuilder.Append(", ");

            //Pay_To_Insurance_BizPac_Reference_No
            stringBuilder.Append(GetDB(value.PayToInsuranceBizPacReferenceNo));
			stringBuilder.Append(", ");

            //Pay_To_Insurance_BizPac_Connection_Date
            stringBuilder.Append(GetDB(value.PayToInsuranceBizPacConnectionDate));
			stringBuilder.Append(", ");

            //Pay_To_Company_Status
            stringBuilder.Append(GetDB(value.PaidToCompanyStatus));
			stringBuilder.Append(", ");

            //Pay_To_Company_Date
            stringBuilder.Append(GetDB(value.PaidToCompanyDate));
			stringBuilder.Append(", ");

            //Pay_To_Company_BizPac_Reference_No 
            stringBuilder.Append(GetDB(value.PayToCompanyBizPacReferenceNo));
			stringBuilder.Append(", ");

            //Pay_To_Company_BizPac_Connection_Date
            stringBuilder.Append(GetDB(value.PayToCompanyBizPacConnectionDate));
			stringBuilder.Append(", ");

            //Latest_Accident_Update_Date
            stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

            //Latest_Accident_Update_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(Accident value, bool isAccident)
		{
			StringBuilder stringBuilder = new StringBuilder(" UPDATE Vehicle_Accident SET ");

			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(value.ADriverExcessDeduction.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Accident_No = ");
			stringBuilder.Append(GetDB(value.RepairingNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Vehicle_No = ");
			stringBuilder.Append(GetDB(value.VehicleInfo.VehicleNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Accident_Date = ");
			stringBuilder.Append(GetDB(value.HappenTime));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Detail_Of_Accident_Line1 = ");
			stringBuilder.Append(GetDB(value.DetailOfAccident1));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Detail_Of_Accident_Line2 = ");
			stringBuilder.Append(GetDB(value.DetailOfAccident2));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Detail_Of_Accident_Line3 = ");
			stringBuilder.Append(GetDB(value.DetailOfAccident3));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Detail_Of_Accident_Line4 = ");
			stringBuilder.Append(GetDB(value.DetailOfAccident4));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Accident_Place = ");
			stringBuilder.Append(GetDB(value.AccidentPlace.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Police_Station = ");
			stringBuilder.Append(GetDB(value.APoliceStation.Name));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Policeman_Name = ");
			stringBuilder.Append(GetDB(value.PolicemanName));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Claimnant_Status = ");
			stringBuilder.Append(GetDB(value.HasClaimnant));
			stringBuilder.Append(", ");

			stringBuilder.Append("Front_Glass_Broken_Status = ");
			stringBuilder.Append(GetDB(value.FrontGlassBroken));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Excess_Status = ");
			stringBuilder.Append(GetDB(value.HasExcess));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Excess_Total_Amount = ");
			stringBuilder.Append(GetDB(value.ExcessTotalAmount));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Excess_Paid_Amount = ");
			stringBuilder.Append(GetDB(value.ExcessPaidAmount));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Excess_Remain_Amount = ");
			stringBuilder.Append(GetDB(value.ExcessRemainAmount));
			stringBuilder.Append(", ");

            stringBuilder.Append("Actual_Excess_Amount = ");
            stringBuilder.Append(GetDB(value.ActualExcessAmount));
            stringBuilder.Append(", ");

			stringBuilder.Append("Damage_Percentage = ");
			stringBuilder.Append(GetDB(value.DamagePercentage));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Payer_Type = ");
			stringBuilder.Append(GetDB(value.APayer));
			stringBuilder.Append(", ");

            if (value.AInsuranceCompany == null || value.AInsuranceCompany.Code == "")
            {
                stringBuilder.Append("Insurance_Company_Code = ");
                stringBuilder.Append(GetDB(""));
                stringBuilder.Append(", ");
            }
            else 
            {
                stringBuilder.Append("Insurance_Company_Code = ");
                stringBuilder.Append(GetDB(value.AInsuranceCompany.Code));
                stringBuilder.Append(", ");
            }            
			
			stringBuilder.Append("Pay_To_Insurance_Status = ");
			stringBuilder.Append(GetDB(value.PaidToInsurance));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Pay_To_Insurance_Date = ");
			stringBuilder.Append(GetDB(value.PaidToInsuranceDate));
			stringBuilder.Append(", ");

            stringBuilder.Append("Insurance_Claim_No = ");
            stringBuilder.Append(GetDB(value.InsuranceClaimNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Insurance_Receipt_No = ");
            stringBuilder.Append(GetDB(value.InsuranceReceiptNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Insurance_Receipt_Date = ");
            stringBuilder.Append(GetDB(value.InsuranceReceiptDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Bill_By_Insurance_Status = ");
            stringBuilder.Append(GetDB(value.BillByInsuranceStatus));
            stringBuilder.Append(", ");

            stringBuilder.Append("Pay_To_Insurance_BizPac_Reference_No = ");
            stringBuilder.Append(GetDB(value.PayToInsuranceBizPacReferenceNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Pay_To_Insurance_BizPac_Connection_Date = ");
            stringBuilder.Append(GetDB(value.PayToInsuranceBizPacConnectionDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Pay_To_Company_Status = ");
            stringBuilder.Append(GetDB(value.PaidToCompanyStatus));
            stringBuilder.Append(", ");

            stringBuilder.Append("Pay_To_Company_Date = ");
            stringBuilder.Append(GetDB(value.PaidToCompanyDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Pay_To_Company_BizPac_Reference_No = ");
            stringBuilder.Append(GetDB(value.PayToCompanyBizPacReferenceNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Pay_To_Company_BizPac_Connection_Date = ");
            stringBuilder.Append(GetDB(value.PayToCompanyBizPacConnectionDate));
            stringBuilder.Append(", ");

            if (isAccident)
            {
                stringBuilder.Append("Latest_Accident_Update_Date = ");
                stringBuilder.Append(GetDateDB());
                stringBuilder.Append(", ");

                stringBuilder.Append("Latest_Accident_Update_User = ");
                stringBuilder.Append(GetDB(UserProfile.UserID));
                stringBuilder.Append(", ");
            }            

			stringBuilder.Append("Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append("Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
		
			return stringBuilder.ToString();
		}

		private string getSQLDelete()
		{
			return " DELETE FROM Vehicle_Accident ";
		}

		private string getKeyCondition(Accident value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.RepairingNo))
			{
				stringBuilder.Append(" AND (Accident_No = ");
				stringBuilder.Append(GetDB(value.RepairingNo));
				stringBuilder.Append(")");
			}
			if (value.VehicleInfo != null && IsNotNULL(value.VehicleInfo.VehicleNo))
			{
				stringBuilder.Append(" AND (Vehicle_No = ");
				stringBuilder.Append(GetDB(value.VehicleInfo.VehicleNo));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}
		
		private string getKeyCondition(Vehicle value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value != null && IsNotNULL(value.VehicleNo))
			{
				stringBuilder.Append(" AND (Vehicle_No = ");
				stringBuilder.Append(GetDB(value.VehicleNo));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

        protected string getOrderby()
		{
			return " ORDER BY Accident_No ";
		} 
		#endregion

		#region - Fill -
        protected virtual Accident getNewAccident(Company aCompany)
        {
            return new Accident(aCompany);
        }

        protected void fillVehicleAccident(Accident value, Company aCompany, SqlDataReader dataReader)
		{
			value.RepairingNo = (string)dataReader[ACCIDENT_NO];
			value.VehicleInfo = dbVehicle.GetDBVehicleInfo(dataReader.GetInt32(VEHICLE_NO), aCompany);
			value.HappenTime = dataReader.GetDateTime(ACCIDENT_DATE);
			value.DetailOfAccident1 = (string)dataReader[DETAIL_OF_ACCIDENT_LINE1];
			value.DetailOfAccident2 = (string)dataReader[DETAIL_OF_ACCIDENT_LINE2];
			value.DetailOfAccident3 = (string)dataReader[DETAIL_OF_ACCIDENT_LINE3];
			value.DetailOfAccident4 = (string)dataReader[DETAIL_OF_ACCIDENT_LINE4];
			value.AccidentPlace.Name = (string)dataReader[ACCIDENT_PLACE];
			value.APoliceStation.Name = (string)dataReader[POLICE_STATION];
			value.PolicemanName = (string)dataReader[POLICEMAN_NAME];
			value.HasClaimnant = GetBool((string)dataReader[CLAIMNANT_STATUS]);
			value.FrontGlassBroken = GetBool((string)dataReader[FRONT_GLASS_BROKEN_STATUS]);
			value.HasExcess = GetBool((string)dataReader[EXCESS_STATUS]);
			value.ExcessTotalAmount = dataReader.GetDecimal(EXCESS_TOTAL_AMOUNT);
			value.ExcessPaidAmount = dataReader.GetDecimal(EXCESS_PAID_AMOUNT);
			value.ExcessRemainAmount = dataReader.GetDecimal(EXCESS_REMAIN_AMOUNT);
            value.ActualExcessAmount = dataReader.GetDecimal(ACTUAL_EXCESS_AMOUNT);
			value.DamagePercentage = dataReader.GetByte(DAMAGE_PERCENTAGE);
			value.APayer = CTFunction.GetPayerType((string)dataReader[PAYER_TYPE]);
			
			value.PaidToInsurance = GetBool((string)dataReader[PAY_TO_INSURANCE_STATUS]);
			if(!dataReader.IsDBNull(PAY_TO_INSURANCE_DATE))
			{
				value.PaidToInsuranceDate = dataReader.GetDateTime(PAY_TO_INSURANCE_DATE);
			}

            value.InsuranceClaimNo = (string)dataReader[INSURANCE_CLAIM_NO];
            value.InsuranceReceiptNo = (string)dataReader[INSURANCE_RECEIPT_NO];
            if (!dataReader.IsDBNull(INSURANCE_RECEIPT_DATE))
            {
                value.InsuranceReceiptDate = dataReader.GetDateTime(INSURANCE_RECEIPT_DATE);
            }
            value.BillByInsuranceStatus = GetBool((string)dataReader[BILL_BY_INSURANCE_STATUS]);

            value.PayToInsuranceBizPacReferenceNo = (string)dataReader[PAY_TO_INSURANCE_BIZPAC_REFERENCE_NO];
            if (!dataReader.IsDBNull(PAY_TO_INSURANCE_BIZPAC_CONNECTION_DATE))
            {
                value.PayToInsuranceBizPacConnectionDate = dataReader.GetDateTime(PAY_TO_INSURANCE_BIZPAC_CONNECTION_DATE);
            }

            value.PaidToCompanyStatus = GetBool((string)dataReader[PAY_TO_COMPANY_STATUS]);
            if (!dataReader.IsDBNull(PAY_TO_COMPANY_DATE))
            {
                value.PaidToCompanyDate = dataReader.GetDateTime(PAY_TO_COMPANY_DATE);
            }

            value.PayToCompanyBizPacReferenceNo = (string)dataReader[PAY_TO_COMPANY_BIZPAC_REFERENCE_NO];
            if (!dataReader.IsDBNull(PAY_TO_COMPANY_BIZPAC_CONNECTION_DATE))
            {
                value.PayToCompanyBizPacConnectionDate = dataReader.GetDateTime(PAY_TO_COMPANY_BIZPAC_CONNECTION_DATE);
            }

            if (!dataReader.IsDBNull(LATEST_ACCIDENT_UPDATE_DATE))
            {
                value.LatestAccidentUpdateDate = dataReader.GetDateTime(LATEST_ACCIDENT_UPDATE_DATE);
            }
            value.LatestAccidentUpdateUser = (string)dataReader[LATEST_ACCIDENT_UPDATE_USER];
            value.AInsuranceCompany = dbInsuranceCompany.GetDBInsuranceCompany((string)dataReader[INSURANCE_COMPANY_CODE], aCompany);

            dbVehicleRepairingHistory.FillVehicleRepairingHistory((RepairingInfoBase)value);
			DriverExcessDeduction driverExcessDeduction = value.ADriverExcessDeduction;
			dbDriverExcessDeduction.FillDriverExcessDeduction(ref driverExcessDeduction);
			driverExcessDeduction.ADriver = value.ADriver;			
			value.ADriverExcessDeduction = driverExcessDeduction;		
		}

		private bool fillVehicleAccidentList(ref VehicleAccident value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				Accident accident;
				while (dataReader.Read())
				{
					result = true;
                    accident = getNewAccident(value.Company);
					fillVehicleAccident(accident, value.Company, dataReader);
					value.Add(accident);
				}
				accident = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			return result;
		}

        private bool fillAccident(ref Accident value, ictus.Common.Entity.Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillVehicleAccident(value, aCompany, dataReader);
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

		//============================== Public Method ==============================
		public bool FillAccident(ref Accident value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.ADriverExcessDeduction.Company));
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(getOrderby());
			
			return fillAccident(ref value, value.ADriverExcessDeduction.Company, stringBuilder.ToString());
		}

		public bool FillVehicleAccidentList(ref VehicleAccident value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(value.AVehicleInfo));
			stringBuilder.Append(getOrderby());

			return fillVehicleAccidentList(ref value, stringBuilder.ToString());
		}

        public bool FillVehicleAccidentByYearList(VehicleAccident value, string forYear)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));

            if (forYear != "")
            {
                stringBuilder.Append(" AND (YEAR(Insurance_Receipt_Date) = ");
                stringBuilder.Append(GetDB(forYear));
                stringBuilder.Append(")");
            }
            else
            {
                stringBuilder.Append(" AND (Insurance_Claim_No = '') ");
            }
            stringBuilder.Append(" AND (Excess_Status = 'Y') AND (Pay_To_Company_BizPac_Reference_No = '') ");
            stringBuilder.Append(getOrderby());

            return fillVehicleAccidentList(ref value, stringBuilder.ToString());
        }

		public bool InsertVehicleAccident(Accident value)
		{
			return (tableAccess.ExecuteSQL(getSQLInsert(value))>0);
		}

		public bool UpdateVehicleAccident(Accident value, bool isAccident)
		{
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, isAccident));
			stringBuilder.Append(getBaseCondition(value.ADriverExcessDeduction.Company));
			stringBuilder.Append(getKeyCondition(value));

			return (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
		}

		public bool DeleteVehicleAccident(Accident value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.ADriverExcessDeduction.Company));
			stringBuilder.Append(getKeyCondition(value));

			bool result = (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);

			stringBuilder = null;
			return result;
		}


        #region ITableName Members

        public string TableName
        {
            get { return "Vehicle_Accident"; }
        }

        #endregion
    }
}