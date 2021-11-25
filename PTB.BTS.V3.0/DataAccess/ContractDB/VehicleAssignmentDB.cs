using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Entity.ContractEntities;
using ictus.PIS.PI.Entity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.ContractDB
{
	public class VehicleAssignmentDB : DataAccessBase
	{ 
		#region - Constant -
		private const int ASSIGNED_VEHICLE_NO = 0;
		private const int FROM_DATE = 1;
		private const int TO_DATE = 2;
		private const int CONTRACT_NO = 3;
		private const int MAIN_VEHICLE_NO = 4;
		private const int ASSIGNMENT_ROLE = 5;
		private const int HIRER_NAME = 6;
		private const int ASSIGNMENT_REASON = 7;
		#endregion

		#region - Private -	
		private VehicleAssignment objVehicleAssignment;
		private ContractDB dbContract;
		private VehicleDB.VehicleDB dbVehicle;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public VehicleAssignmentDB() : base()
		{			
			dbContract = new ContractDB();
			dbVehicle = new VehicleDB.VehicleDB();
		}	

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT  Assigned_Vehicle_No, From_Date, To_Date, Contract_No, Main_Vehicle_No, Assignment_Role, Hirer_Name, Assignment_Reason FROM Vehicle_Assignment ";
		}

		private string getSQLInsert(VehicleAssignment value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Vehicle_Assignment (Company_Code, Assigned_Vehicle_No, From_Date, To_Date, Contract_No, Main_Vehicle_No, Assignment_Role, Hirer_Name, Assignment_Reason, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Assigned_Vehicle_No
			stringBuilder.Append(GetDB(value.AAssignedVehicle.VehicleNo));
			stringBuilder.Append(", ");
			
			//From_Date
			stringBuilder.Append(GetDB(value.APeriod.From));
			stringBuilder.Append(", ");
			
			//To_Date
			stringBuilder.Append(GetDB(value.APeriod.To));
			stringBuilder.Append(", ");
			
			//Contract_No
			stringBuilder.Append(GetDB(value.AContract.ContractNo.ToString()));
			stringBuilder.Append(", ");
			
			//Main_Vehicle_No
			stringBuilder.Append(GetDB(value.AMainVehicle.VehicleNo));
			stringBuilder.Append(", ");
			
			//Assignment_Role
			stringBuilder.Append(GetDB(value.AssignmentRole));
			stringBuilder.Append(", ");
			
			//Hirer_Name
			stringBuilder.Append(GetDB(value.AHirer.Name));
			stringBuilder.Append(", ");

			//Assignment_Reason
			stringBuilder.Append(GetDB(value.AAssignmentReason.Name));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(VehicleAssignment value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Vehicle_Assignment SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Assigned_Vehicle_No = ");
			stringBuilder.Append(GetDB(value.AAssignedVehicle.VehicleNo));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("From_Date = ");
			stringBuilder.Append(GetDB(value.APeriod.From));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("To_Date = ");
			stringBuilder.Append(GetDB(value.APeriod.To));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Contract_No = ");
			stringBuilder.Append(GetDB(value.AContract.ContractNo.ToString()));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Main_Vehicle_No = ");
			stringBuilder.Append(GetDB(value.AMainVehicle.VehicleNo));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Assignment_Role = ");
			stringBuilder.Append(GetDB(value.AssignmentRole));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Hirer_Name = ");
			stringBuilder.Append(GetDB(value.AHirer.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Assignment_Reason = ");
			stringBuilder.Append(GetDB(value.AAssignmentReason.Name));
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
			return " DELETE FROM Vehicle_Assignment ";
		}

		private string getKeyCondition(VehicleAssignment value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value.AAssignedVehicle != null && IsNotNULL(value.AAssignedVehicle.VehicleNo))
			{
				stringBuilder.Append(" AND (Assigned_Vehicle_No = ");
				stringBuilder.Append(GetDB(value.AAssignedVehicle.VehicleNo));
				stringBuilder.Append(")");
			}
			if(value.APeriod != null)
			{
				if (IsNotNULL(value.APeriod.From))
				{
					stringBuilder.Append(" AND (From_Date = ");
					stringBuilder.Append(GetDB(value.APeriod.From));
					stringBuilder.Append(")");
				}
				if (IsNotNULL(value.APeriod.To))
				{
					stringBuilder.Append(" AND (To_Date = ");
					stringBuilder.Append(GetDB(value.APeriod.To));
					stringBuilder.Append(")");
				}
			}
			if (value.AContract != null && value.AContract.ContractNo != null && IsNotNULL(value.AContract.ContractNo.ToString()))
			{
				stringBuilder.Append(" AND (Contract_No = ");
				stringBuilder.Append(GetDB(value.AContract.ContractNo.ToString()));
				stringBuilder.Append(")");
			}
			if (value.AMainVehicle != null && IsNotNULL(value.AMainVehicle.VehicleNo))
			{
				stringBuilder.Append(" AND (Main_Vehicle_No = ");
				stringBuilder.Append(GetDB(value.AMainVehicle.VehicleNo));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getListCondition(Vehicle value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.VehicleNo))
			{
				stringBuilder.Append(" AND (Assigned_Vehicle_No = ");
				stringBuilder.Append(GetDB(value.VehicleNo));
				stringBuilder.Append(")");			
			}
			return stringBuilder.ToString();		
		}

        private string getEntityCondition(VehicleAssignment value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value.AssignmentRole))
            {
                stringBuilder.Append(" AND (Assignment_Role = ");
                stringBuilder.Append(GetDB(value.AssignmentRole));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }
 
		private string getExcludeKeyCondition(VehicleAssignment value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if (value.AAssignedVehicle != null && IsNotNULL(value.AAssignedVehicle.VehicleNo))
			{
				stringBuilder.Append(" AND NOT(Assigned_Vehicle_No = ");
				stringBuilder.Append(GetDB(value.AAssignedVehicle.VehicleNo));
				stringBuilder.Append(")");
			}
			if(value.APeriod != null)
			{
				if (IsNotNULL(value.APeriod.From))
				{
					stringBuilder.Append(" AND NOT(From_Date = ");
					stringBuilder.Append(GetDB(value.APeriod.From));
					stringBuilder.Append(")");
				}
				if (IsNotNULL(value.APeriod.To))
				{
					stringBuilder.Append(" AND NOT(To_Date = ");
					stringBuilder.Append(GetDB(value.APeriod.To));
					stringBuilder.Append(")");
				}
			}
			if (value.AContract != null && value.AContract.ContractNo != null && IsNotNULL(value.AContract.ContractNo.ToString()))
			{
				stringBuilder.Append(" AND NOT(Contract_No = ");
				stringBuilder.Append(GetDB(value.AContract.ContractNo.ToString()));
				stringBuilder.Append(")");
			}
			if (value.AMainVehicle != null && IsNotNULL(value.AMainVehicle.VehicleNo))
			{
				stringBuilder.Append(" AND NOT(Main_Vehicle_No = ");
				stringBuilder.Append(GetDB(value.AMainVehicle.VehicleNo));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getCurrentContractCondition(int vehicleNo)
		{
			StringBuilder stringBuilder = new StringBuilder(); 
			if(IsNotNULL(vehicleNo))
			{
				stringBuilder.Append(" AND (Main_Vehicle_No = ");
				stringBuilder.Append(GetDB(vehicleNo));
				stringBuilder.Append(" ) ");
				stringBuilder.Append(" AND (Assignment_Role = 'M') AND (To_Date = (SELECT MAX(To_Date) FROM Vehicle_Assignment WHERE (Assignment_Role = 'M') ");
				stringBuilder.Append(" AND (Main_Vehicle_No = ");
				stringBuilder.Append(GetDB(vehicleNo));
				stringBuilder.Append(" ))) ");	
			}
			return stringBuilder.ToString();	
		}

		private string getExcludeAvilableCondition(VehicleAssignment value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if (value.AAssignedVehicle != null && IsNotNULL(value.AAssignedVehicle.VehicleNo))
			{
				stringBuilder.Append(" AND (Assigned_Vehicle_No = ");
				stringBuilder.Append(GetDB(value.AAssignedVehicle.VehicleNo));
				stringBuilder.Append(")");
			}
			if(value.APeriod != null)
			{
				if (IsNotNULL(value.APeriod.To))
				{
					stringBuilder.Append(" AND (From_Date <= ");
					stringBuilder.Append(GetDB(value.APeriod.To));
					stringBuilder.Append(" ) ");
				}
				if (IsNotNULL(value.APeriod.From))
				{
					stringBuilder.Append(" AND (To_Date >= ");
					stringBuilder.Append(GetDB(value.APeriod.From));
					stringBuilder.Append(" ) ");
				}
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Assigned_Vehicle_No, From_Date, To_Date, Contract_No, Main_Vehicle_No ";
		}
		#endregion

		#region - Fill -
		private void fillVehicleAssignmentDB(ref VehicleAssignment value, Company aCompany, SqlDataReader dataReader)
		{
			value.AAssignedVehicle = dbVehicle.GetDBVehicleGeneral((dataReader.GetInt32(ASSIGNED_VEHICLE_NO)), aCompany);
			value.APeriod.From = dataReader.GetDateTime(FROM_DATE);
			value.APeriod.To = dataReader.GetDateTime(TO_DATE);			
			value.AMainVehicle = dbVehicle.GetDBVehicleGeneral((dataReader.GetInt32(MAIN_VEHICLE_NO)), aCompany);
			value.AssignmentRole = CTFunction.GetAssignmentRoleType((string)dataReader[ASSIGNMENT_ROLE]);
			value.AHirer.Name = (string)dataReader[HIRER_NAME];
			value.AAssignmentReason.Name = (string)dataReader[ASSIGNMENT_REASON];
		}

		private void fillVehicleAssignment(ref VehicleAssignment value, Company aCompany, SqlDataReader dataReader)
		{
			DocumentNo documentNo = new DocumentNo((string)dataReader[CONTRACT_NO]);
			value.AContract = (VehicleContract)dbContract.GetContract(documentNo, aCompany);
			documentNo = null;
			fillVehicleAssignmentDB(ref value, aCompany, dataReader);
		}

		private void fillVehicleSpareAssignment(ref VehicleAssignment value, Company aCompany, SqlDataReader dataReader)
		{
			DocumentNo documentNo = new DocumentNo((string)dataReader[CONTRACT_NO]);
			value.AContract = (VehicleContract)dbContract.GetAllContract(documentNo, aCompany);
			documentNo = null;
			fillVehicleAssignmentDB(ref value, aCompany, dataReader);
		}

		private bool fillVehicleAssignmentList(ref VehicleAssignmentList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					if((string)dataReader[CONTRACT_NO] != "PTB-C-0000000")
					{
						result = true;
						objVehicleAssignment = new VehicleAssignment();
						fillVehicleAssignment(ref objVehicleAssignment, value.Company, dataReader);
						value.Add(objVehicleAssignment);					
					}
				}
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;
		}	

		private bool fillVehicleSpareAssignmentList(ref VehicleAssignmentList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objVehicleAssignment = new VehicleAssignment();
					fillVehicleSpareAssignment(ref objVehicleAssignment, value.Company, dataReader);
					value.Add(objVehicleAssignment);
				}
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;
		}	
	
		private bool fillVehicleAssignment(ref VehicleAssignment value, Company aCompany,  string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{	
					if((string)dataReader[CONTRACT_NO] != "PTB-C-0000000")
					{
						fillVehicleAssignment(ref value, aCompany, dataReader);
						result = true;
					}
				}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;
		}

		private bool fillVehicleSpareAssignment(ref VehicleAssignment value, Company aCompany,  string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{	
					fillVehicleSpareAssignment(ref value, aCompany, dataReader);
					result = true;					
				}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;
		}


        /// <summary>
        /// Select VehicleAssignment from Vehicle_Assignment where condition in conditionVehicleAssin properties.
        /// </summary>
        /// <param name="conditionVehicleAssign"></param>
        /// <param name="aCompany"></param>
        /// <returns></returns>
        private VehicleAssignment selectOneVehicleAssignment(VehicleAssignment conditionVehicleAssign, Company aCompany)
        {
            VehicleAssignment vehicleAssign = new VehicleAssignment();

            using (SqlCommand command = this.tableAccess.CreateCommand("SSelectVehicleAssignment"))
            {
                command.CommandType = CommandType.StoredProcedure;

                string assignmentRole = (conditionVehicleAssign.AssignmentRole == Entity.CommonEntity.ASSIGNMENT_ROLE_TYPE.MAIN) ? AssignmentBase.AssignmentRoleValue.MAIN : AssignmentBase.AssignmentRoleValue.SPARE;

                command.Parameters.Add(this.tableAccess.CreateParameter("@Company_Code", aCompany.CompanyCode));
                command.Parameters.Add(this.tableAccess.CreateParameter("@Main_Vehicle_No", conditionVehicleAssign.AMainVehicle.VehicleNo));
                command.Parameters.Add(this.tableAccess.CreateParameter("@StartAssignDate", conditionVehicleAssign.APeriod.From));
                command.Parameters.Add(this.tableAccess.CreateParameter("@ToAssignDate", conditionVehicleAssign.APeriod.To));
                command.Parameters.Add(this.tableAccess.CreateParameter("@Assignment_Role", assignmentRole));

                SqlDataReader reader = this.tableAccess.ExecuteDataReader(command);
                if (reader.Read())
                {
                    this.fillVehicleAssignment(ref vehicleAssign, aCompany, reader);
                }
                else
                {
                    vehicleAssign = null;
                }

                // field to object properties only select one record.
                if (reader.Read())
                {
                    vehicleAssign = null;
                }
                

                reader.Close();
                reader.Dispose();
                reader = null;

                return vehicleAssign;
            }
        }

		private bool fillCurrentContract(ref VehicleContract value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					value.ContractNo = new DocumentNo((string)dataReader[CONTRACT_NO]);
					if(dbContract.FillContract(value, value.AVehicleRoleList.Company))
					{
						result = true;
					}
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
		public VehicleAssignment GetVehicleAssignmentOnTime(Vehicle aVehicle, DateTime formDate, DateTime toDate, Company aCompany)
		{
			DateTime tempFormDate = new DateTime(formDate.Year, formDate.Month, formDate.Day);
			DateTime tempToDate = new DateTime(toDate.Year, toDate.Month, toDate.Day);
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));

			stringBuilder.Append(" AND (Assigned_Vehicle_No = ");
			stringBuilder.Append(GetDB(aVehicle.VehicleNo));
			stringBuilder.Append(") ");

			stringBuilder.Append(" AND (From_Date <= ");
			stringBuilder.Append(GetDB(tempFormDate));
			stringBuilder.Append(") ");

			stringBuilder.Append(" AND (To_Date >= ");
			stringBuilder.Append(GetDB(tempToDate));
			stringBuilder.Append(") ");

			VehicleAssignment vehicleAssignment = new VehicleAssignment();

			if(fillVehicleSpareAssignment(ref vehicleAssignment, aCompany, stringBuilder.ToString()))
			{				
				return vehicleAssignment;
			}
			else
			{
				return null;
			}
		}

		public VehicleAssignment GetCurrentVehicleAssignment(int assignVehicleNo, Company aCompany)
		{
            objVehicleAssignment = new VehicleAssignment();

            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getCurrentContractCondition(assignVehicleNo));

            if (fillVehicleAssignment(ref objVehicleAssignment, aCompany, stringBuilder.ToString()))
            {
                return objVehicleAssignment;
            }
            else
            {
                objVehicleAssignment = null;
                return null;
            }
		}


        /// <summary>
        /// Get vehicle assignment from condition in conditionVehicleAssing
        /// </summary>
        /// <param name="conditionVehicleAssign"></param>
        /// <param name="aCompany"></param>
        /// <returns></returns>
        public VehicleAssignment GetCurrentVehicleAssignment(VehicleAssignment conditionVehicleAssign,Company aCompany)
        {
            return this.selectOneVehicleAssignment(conditionVehicleAssign, aCompany);
        }

        public VehicleAssignment GetMaxAssignedByContract(DocumentNo contractNo, Company company)
        {
            objVehicleAssignment = new VehicleAssignment();

            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(" AND (Contract_No = ");
            stringBuilder.Append(GetDB(contractNo.ToString()));
            stringBuilder.Append(") AND (Assignment_Role = 'M') ");

            if (fillVehicleAssignment(ref objVehicleAssignment, company, stringBuilder.ToString()))
            {
                return objVehicleAssignment;
            }
            else
            {
                objVehicleAssignment = null;
                return null;
            }	
        }

        public bool FillVehicleAssignment(ref VehicleAssignment value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));

            return fillVehicleAssignment(ref value, aCompany, stringBuilder.ToString());
        }

		public bool FillVehicleAssignmentList(ref VehicleAssignmentList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getListCondition(value.AVehicle));
			stringBuilder.Append(getOrderby());

			return fillVehicleAssignmentList(ref value, stringBuilder.ToString());
		}

		public bool FillVehicleAssignmentList(ref VehicleAssignmentList aVehicleAssignmentList, VehicleAssignment aVehicleAssignment)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aVehicleAssignmentList.Company));
			stringBuilder.Append(getKeyCondition(aVehicleAssignment));
			stringBuilder.Append(getOrderby());

			return fillVehicleAssignmentList(ref aVehicleAssignmentList, stringBuilder.ToString());
		}

		public bool FillVehicleSpareAssignmentList(ref VehicleAssignmentList aVehicleAssignmentList, VehicleAssignment aVehicleAssignment)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aVehicleAssignmentList.Company));
			stringBuilder.Append(getKeyCondition(aVehicleAssignment));
			stringBuilder.Append(getOrderby());

			return fillVehicleSpareAssignmentList(ref aVehicleAssignmentList, stringBuilder.ToString());
		}

        public bool FillVehicleSpareAssignmentByRoleList(VehicleAssignmentList listAssignment, VehicleAssignment assignment)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(listAssignment.Company));
            stringBuilder.Append(getKeyCondition(assignment));
            stringBuilder.Append(getEntityCondition(assignment));
            stringBuilder.Append(getOrderby());

            return fillVehicleSpareAssignmentList(ref listAssignment, stringBuilder.ToString());
        }

		public bool FillExcludeAvailableVehicleSpareAssignment(ref VehicleAssignment value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getExcludeAvilableCondition(value));

			return fillVehicleSpareAssignment(ref value, aCompany, stringBuilder.ToString());
		}

        public bool FillVehicleMainAssignmentList(VehicleAssignmentList mainAssignList, int vehicleNo)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(mainAssignList.Company));
            if (IsNotNULL(vehicleNo))
            {
                stringBuilder.Append(" AND (Main_Vehicle_No = ");
                stringBuilder.Append(GetDB(vehicleNo));
                stringBuilder.Append(")");
            }
            stringBuilder.Append(" AND (Main_Vehicle_No <> Assigned_Vehicle_No) ");
            stringBuilder.Append(getOrderby());

            return fillVehicleAssignmentList(ref mainAssignList, stringBuilder.ToString());
        }

		public bool InsertVehicleAssignment(VehicleAssignment value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateVehicleAssignment(VehicleAssignment value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteVehicleAssignment(VehicleAssignment value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

        //============================== Specific Method ==============================
        public bool FillSpecificVehicleAssignmentSellingPlan(VehicleAssignmentList list, ictus.Common.Entity.Time.YearMonth yearMonth)
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT Assigned_Vehicle_No, From_Date, To_Date, Contract_No, Main_Vehicle_No, Assignment_Role, Hirer_Name, Assignment_Reason FROM Vehicle_Assignment mainTable");
			stringBuilder.Append(getBaseCondition(list.Company));
            //stringBuilder.Append(" AND (Assignment_Role = 'M')");
            //stringBuilder.Append(" AND (To_Date = (SELECT MAX(tempTable.To_Date) FROM Vehicle_Assignment tempTable WHERE (tempTable.Assignment_Role = 'M') AND (tempTable.Assigned_Vehicle_No = mainTable.Assigned_Vehicle_No)))");
            stringBuilder.Append(" AND (To_Date = (SELECT MAX(tempTable.To_Date) FROM Vehicle_Assignment tempTable WHERE (tempTable.Assigned_Vehicle_No = mainTable.Assigned_Vehicle_No)))");
            stringBuilder.Append(" AND (Assigned_Vehicle_No NOT IN (SELECT Vehicle_No FROM Vehicle_Selling_Plan WHERE Estimate_Year = ");
            stringBuilder.Append(GetDB(yearMonth.Year));
            stringBuilder.Append(" AND Estimate_Month = ");
            stringBuilder.Append(GetDB(yearMonth.Month));
            stringBuilder.Append(")) ");
            stringBuilder.Append("AND (YEAR(To_Date) = ");
            stringBuilder.Append(GetDB(yearMonth.Year));
            stringBuilder.Append(") AND (MONTH(To_Date) = ");
            stringBuilder.Append(GetDB(yearMonth.Month));
            stringBuilder.Append(")");

            return fillVehicleAssignmentList(ref list, stringBuilder.ToString());
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
