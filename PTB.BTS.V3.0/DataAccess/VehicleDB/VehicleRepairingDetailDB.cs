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
	public class VehicleRepairingDetailDB : DataAccessBase
	{
		#region - Constant -
		private const int REPAIRING_NO = 0;
		private const int SPARE_PARTS_CODE = 1;
		private const int DESCRIPTION = 2;
		private const int EXPENSE_STATUS = 3;
		#endregion

		#region - Privete -
		private SparePartsDB dbSpareParts;
		#endregion

//		============================== Constructor ==============================
		public VehicleRepairingDetailDB()
		{
			dbSpareParts = new SparePartsDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT  Repairing_No, Spare_Parts_Code, Description, Expense_Status FROM Vehicle_Repairing_Detail ";
		}

		private string getSQLInsert(RepairingSpareParts value, RepairingInfoBase condition)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Vehicle_Repairing_Detail (Company_Code, Repairing_No, Spare_Parts_Code, Description, Expense_Status, Process_Date, Process_User) " );
			stringBuilder.Append(" VALUES ( ");

			//Company_Code			
			stringBuilder.Append(GetDB(condition.ARepairSparePartsList.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Repairing_No
			stringBuilder.Append(GetDB(condition.RepairingNo));
			stringBuilder.Append(", ");
			
			//Spare_Parts_Code
			stringBuilder.Append(GetDB(value.ASpareParts.Code));
			stringBuilder.Append(", ");

			//Description
			stringBuilder.Append(GetDB(value.Description));
			stringBuilder.Append(", ");
			
			//Expense_Status
			stringBuilder.Append(GetDB(value.ExpenseStatus));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(RepairingSpareParts value, RepairingInfoBase condition)
		{
			StringBuilder stringBuilder = new StringBuilder(" UPDATE Vehicle_Repairing_Detail SET ");

			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(condition.ARepairSparePartsList.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Repairing_No = ");
			stringBuilder.Append(GetDB(condition.RepairingNo));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Spare_Parts_Code = ");
			stringBuilder.Append(GetDB(value.ASpareParts.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("Description = ");
			stringBuilder.Append(GetDB(value.Description));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Expense_Status = ");
			stringBuilder.Append(GetDB(value.ExpenseStatus));
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
			return " DELETE FROM Vehicle_Repairing_Detail ";
		}

		private string getKeyCondition(RepairingBase value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" AND (Repairing_No = ");
			stringBuilder.Append(GetDB(value.RepairingNo));
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Spare_Parts_Code ";
		}
		#endregion

		#region - Fill -
		private void fillVehicleRepairingHistory(ref RepairingSpareParts value, Company aCompany, SqlDataReader dataReader)
		{
			value.ASpareParts = (SpareParts)dbSpareParts.GetDBDualField((string)dataReader[SPARE_PARTS_CODE], aCompany);
			value.Description = (string)dataReader[DESCRIPTION];
			value.ExpenseStatus = CTFunction.GetExpenseStatusType((string)dataReader[EXPENSE_STATUS]);
		}

		private bool fillVehicleRepairingHistory(ref RepairingSparePartsList value, string sql)
		{
			bool result = false;
			RepairingSpareParts repairingSpareParts;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					repairingSpareParts = new RepairingSpareParts();
					fillVehicleRepairingHistory(ref repairingSpareParts, value.Company, dataReader);
					value.Add(repairingSpareParts);
				}
				repairingSpareParts = null;
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
		#endregion

//		============================== Public Method ==============================
		public bool FillVehicleRepairingDetail(RepairingInfoBase value)
		{
			RepairingSparePartsList repairSparePartsList = value.ARepairSparePartsList;

			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(repairSparePartsList.Company));
			stringBuilder.Append(getKeyCondition(value));
			
			bool result = fillVehicleRepairingHistory(ref repairSparePartsList, stringBuilder.ToString());
			
			value.ARepairSparePartsList = repairSparePartsList;
			repairSparePartsList = null;
			stringBuilder = null;
			return result;
		}

		public bool InsertVehicleRepairingDetail(RepairingInfoBase value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i < value.ARepairSparePartsList.Count; i++)
			{
				stringBuilder.Append(getSQLInsert(value.ARepairSparePartsList[i], value));
			}
			bool result = (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
			stringBuilder = null;
			return result;
		}

        public bool DeleteVehicleRepairingDetail(RepairingInfoBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.ARepairSparePartsList.Company));
			stringBuilder.Append(getKeyCondition(value));
			bool result = (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
			stringBuilder = null;
			return result;
		}
	}
}
