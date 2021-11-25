using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using ictus.Common.Entity;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.VehicleDB
{
	public class TrExpiredCompulsoryInsuranceDB : DataAccessBase
	{
//		============================== Constructor ==============================
		public TrExpiredCompulsoryInsuranceDB() : base()
		{
		}

//		============================== Private Method ==============================
        private string getSQLInsert(CompulsoryInsurance value, ContractBase aContractBase, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Expired_Compulsory_Insurance (Company_Code, Plate_No_Prefix, Plate_No_Running_No, End_Date, Brand_English_Name, Model_English_Name, Engine_CC, Customer_Short_Name, Total_Amount, Process_Date, Process_User) ");
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

			//End_Date
			stringBuilder.Append(GetDB(value.APeriod.To));
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
            if (aContractBase != null && aContractBase.ACustomer != null)
			{
                VehicleContract vehicleContract = (VehicleContract)aContractBase;

                if (vehicleContract.AVehicleRoleList != null && vehicleContract.AVehicleRoleList.Count > 0 &&
                    vehicleContract.AVehicleRoleList[0].AKindOfVehicle != null &&
                    vehicleContract.AVehicleRoleList[0].AKindOfVehicle.Code == KindOfVehicle.LEASING_FAMILY_CAR)
                {
                    stringBuilder.Append(GetDB(string.Concat(aContractBase.ACustomer.ShortName, "(FAM)")));
                    stringBuilder.Append(", ");
                }
                else
                {
                    stringBuilder.Append(GetDB(aContractBase.ACustomer.ShortName));
                    stringBuilder.Append(", ");
                }
			}
			else
			{
				stringBuilder.Append(GetDB(NullConstant.STRING));
				stringBuilder.Append(", ");			
			}

			//Total_Amount
			stringBuilder.Append(GetDB(value.CompulsoryInsuranceAmount));
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
			return " DELETE FROM Tr_Expired_Compulsory_Insurance ";
		}

//		============================== Public Method ==============================
		public bool InsertTrExpiredCompulsoryInsurance(CompulsoryInsurance aCompulsoryInsurance, ContractBase aContractBase, Company aCompany)
		{
            return (tableAccess.ExecuteSQL(getSQLInsert(aCompulsoryInsurance, aContractBase, aCompany)) > 0);
		}

		public bool DeleteTrExpiredCompulsoryInsurance(Company value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value));

			return (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
		}

	}
}
