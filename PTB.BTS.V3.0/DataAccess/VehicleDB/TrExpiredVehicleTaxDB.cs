using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.General;

namespace DataAccess.VehicleDB
{
	public class TrExpiredVehicleTaxDB : DataAccessBase
	{
//		============================== Constructor ==============================
		public TrExpiredVehicleTaxDB() : base()
		{
		}

//		============================== Private Method ==============================
		private string getSQLInsert(VehicleTax value, VehicleTax currentVehicleTax, ContractBase contractBase, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Expired_Vehicle_Tax (Company_Code, Plate_No_Prefix, Plate_No_Running_No, Brand_English_Name, Model_English_Name, Engine_CC, Customer_Short_Name, Last_Time_End_Date, Last_Time_Period, Last_Time_Total_Amount, This_Time_End_Date, This_Time_Period, This_Time_Total_Amount, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");
			//Company_Code			
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");
				
			//Plate_No_Prefix
			stringBuilder.Append(GetDB(value.AVehicle.PlatePrefix));
			stringBuilder.Append(", ");

			//Plate_No_Running_No
			stringBuilder.Append(GetDB(value.AVehicle.PlateRunningNo));
			stringBuilder.Append(", ");

			//Brand_English_Name
			stringBuilder.Append(GetDB(value.AVehicle.AModel.ABrand.AName.English));
			stringBuilder.Append(", ");

			//Model_English_Name
			stringBuilder.Append(GetDB(value.AVehicle.AModel.AName.English));
			stringBuilder.Append(", ");

			//Engine_CC
			stringBuilder.Append(GetDB(value.AVehicle.AModel.EngineCC));
			stringBuilder.Append(", ");

			//Customer_Short_Name
			if(contractBase != null && contractBase.ACustomer != null )
			{
                VehicleContract vehicleContract = (VehicleContract)contractBase;

                if (vehicleContract.AVehicleRoleList != null && vehicleContract.AVehicleRoleList.Count > 0 &&
                    vehicleContract.AVehicleRoleList[0].AKindOfVehicle != null &&
                    vehicleContract.AVehicleRoleList[0].AKindOfVehicle.Code == KindOfVehicle.LEASING_FAMILY_CAR)
                {
                    stringBuilder.Append(GetDB(string.Concat(contractBase.ACustomer.ShortName, "(FAM)")));
                    stringBuilder.Append(", ");
                }
                else
                {
                    stringBuilder.Append(GetDB(contractBase.ACustomer.ShortName));
                    stringBuilder.Append(", ");
                }
			}
			else
			{
				stringBuilder.Append(GetDB(NullConstant.STRING));
				stringBuilder.Append(", ");			
			}

			//Last_Time_End_Date
			stringBuilder.Append(GetDB(value.APeriod.From));
			stringBuilder.Append(", ");

			//Last_Time_Period
			stringBuilder.Append(GetDB(value.TaxYear - 1));
			stringBuilder.Append(", ");

			//Last_Time_Total_Amount
			stringBuilder.Append(GetDB(value.TaxAmount));
			stringBuilder.Append(", ");

			//This_Time_End_Date
			stringBuilder.Append(GetDB(value.APeriod.To));
			stringBuilder.Append(", ");

			//This_Time_Period
			stringBuilder.Append(GetDB(value.TaxYear));
			stringBuilder.Append(", ");

			//This_Time_Total_Amount
			stringBuilder.Append(GetDB(currentVehicleTax.TaxAmount));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLDelete()
		{
			return " DELETE FROM Tr_Expired_Vehicle_Tax ";
		}

//		============================== Public Method ==============================
		public bool InsertTrExpiredVehicleTax(VehicleTax latestVehicleTax, VehicleTax currentVehicleTax, ContractBase aContractBase, Company aCompany)
		{
			return (tableAccess.ExecuteSQL(getSQLInsert(latestVehicleTax, currentVehicleTax, aContractBase, aCompany))>0);
		}

		public bool DeleteTrExpiredVehicleTax(Company value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value));

			return (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
		}
	}
}
