using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;
using ictus.Common.Entity;

namespace DataAccess.ContractDB
{
	public class VDContractMatchDB : DataAccessBase
	{
		#region - Constant -
		private const int VEHICLE_CONTRACT_NO = 0;
		private const int VEHICLE_NO = 1;
		private const int SERVICE_STAFF_CONTRACT_NO = 2;
		private const int EMPLOYEE_ORDER = 3;
		#endregion

		#region - Private -	
		private ContractDB dbContract;
		private VehicleDB.VehicleDB dbVehicle;
		private bool disposed = false;
		#endregion	

//		============================== Constructor ==============================
		public VDContractMatchDB() : base()
		{
			dbContract = new ContractDB();
			dbVehicle = new DataAccess.VehicleDB.VehicleDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Vehicle_Contract_No, Vehicle_No, Service_Staff_Contract_No, Employee_Order FROM VD_Contract_Match ";
		}

		private string getSQLInsert(VehicleContract aVehicleContract, Vehicle aVehicle, ServiceStaffRole aServiceStaffRole)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO VD_Contract_Match (Company_Code, Vehicle_Contract_No, Vehicle_No, Service_Staff_Contract_No, Employee_Order, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aVehicleContract.AVehicleRoleList.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Vehicle_Contract_No
			stringBuilder.Append(GetDB(aVehicleContract.ContractNo.ToString()));
			stringBuilder.Append(", ");
			
			//Vehicle_No
			stringBuilder.Append(GetDB(aVehicle.VehicleNo));
			stringBuilder.Append(", ");
			
			//Service_Staff_Contract_No
			stringBuilder.Append(GetDB(aVehicleContract.ADriverContract.ContractNo.ToString()));
			stringBuilder.Append(", ");
			
			//Employee_Order
			stringBuilder.Append(GetDB(aServiceStaffRole.ServiceStaffOrder));
			stringBuilder.Append(", ");
			
			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(VehicleContract aVehicleContract, Vehicle aVehicle, ServiceStaffRole aServiceStaffRole)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE VD_Contract_Match SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aVehicleContract.AVehicleRoleList.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Vehicle_Contract_No = ");
			stringBuilder.Append(GetDB(aVehicleContract.ContractNo.ToString()));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Vehicle_No = ");
			stringBuilder.Append(GetDB(aVehicle.VehicleNo));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Service_Staff_Contract_No = ");
			stringBuilder.Append(GetDB(aVehicleContract.ADriverContract.ContractNo.ToString()));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Employee_Order = ");
			stringBuilder.Append(GetDB(aServiceStaffRole.ServiceStaffOrder));
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
			return " DELETE FROM VD_Contract_Match ";
		}

		private string getKeyCondition(DocumentNo value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value != null)
			{
				if(IsNotNULL(value.Year) && IsNotNULL(value.Month) && IsNotNULL(value.No))
				{
					stringBuilder.Append(" AND (Vehicle_Contract_No = ");
					stringBuilder.Append(GetDB(value.ToString()));
					stringBuilder.Append(")");
				}
				else
				{
					if(IsNotNULL(value.Year))
					{
						stringBuilder.Append(" AND (SUBSTRING(Vehicle_Contract_No, 7, 2) = ");
						stringBuilder.Append(GetDB(value.Year));
						stringBuilder.Append(")");					
					}

					if(IsNotNULL(value.Month))
					{
						stringBuilder.Append(" AND (SUBSTRING(Vehicle_Contract_No, 9, 2) = ");
						stringBuilder.Append(GetDB(value.Month));
						stringBuilder.Append(")");					
					}

					if(IsNotNULL(value.No))
					{
						stringBuilder.Append(" AND (SUBSTRING(Vehicle_Contract_No, 11, 3) = ");
						stringBuilder.Append(GetDB(value.No));
						stringBuilder.Append(")");
					}
				}
			}
			return stringBuilder.ToString();
		}

		private string getKeyCondition(ContractBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(getKeyCondition(value.ContractNo));		
			return stringBuilder.ToString();
		}	

		private string getEntityCondition(VehicleContract value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value != null && value.ADriverContract != null && value.ADriverContract.ContractNo != null && IsNotNULL(value.ADriverContract.ContractNo.ToString()))
			{
				stringBuilder.Append(" AND (Service_Staff_Contract_No = ");
				stringBuilder.Append(GetDB(value.ADriverContract.ContractNo.ToString()));
				stringBuilder.Append(")");
			}			
			return stringBuilder.ToString();
		}

        private string getEntityCondition(DocumentNo driverContractNo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (driverContractNo != null && IsNotNULL(driverContractNo.ToString()))
            {
                stringBuilder.Append(" AND (Service_Staff_Contract_No = ");
                stringBuilder.Append(GetDB(driverContractNo.ToString()));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getKeyCondition(int vehicleNo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(vehicleNo))
            {
                stringBuilder.Append(" AND (Vehicle_No = ");
                stringBuilder.Append(GetDB(vehicleNo));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getEntityCondition(int employeeOrder)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(employeeOrder))
            {
                stringBuilder.Append(" AND (Employee_Order = ");
                stringBuilder.Append(GetDB(employeeOrder));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }
	
		private string getOrderby() 
		{
			return " ORDER BY Vehicle_Contract_No ";
		}
		#endregion

		#region - Fill -
		private bool fillVDContractMatch(ref VehicleContract value, string sql)
		{
			bool result = false;
			int vehicleNo;
			byte employeeOrder;
			Driver driver = new Driver(value.AVehicleRoleList.Company);
			DocumentNo documentNo;

			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{					
					if(!result)
					{
						documentNo = new DocumentNo((string)dataReader[VEHICLE_CONTRACT_NO]);
						value = (VehicleContract)dbContract.GetContract(documentNo, value.AVehicleRoleList.Company);

						documentNo = new DocumentNo((string)dataReader[SERVICE_STAFF_CONTRACT_NO]);
						value.ADriverContract = (DriverContract)dbContract.GetContract(documentNo, value.AVehicleRoleList.Company);
						result = true;
					}
					vehicleNo = dataReader.GetInt32(VEHICLE_NO);
					employeeOrder = dataReader.GetByte(EMPLOYEE_ORDER);

					value.ADriverContract.ALatestServiceStaffRoleList[employeeOrder.ToString()].ServiceStaffOrder = employeeOrder;
					driver.EmployeeNo = value.ADriverContract.ALatestServiceStaffRoleList[employeeOrder.ToString()].AServiceStaff.EmployeeNo;
					value.AVehicleRoleList[vehicleNo.ToString()].ADriver = driver;
				}
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			return result;
		}

		private bool fillVDContractMatchList(ref ContractList value, string sql)
		{
			bool result = false;

			DocumentNo documentNo;
			Driver driver;
			VehicleContract vehicleContract;

			int vehicleNo;
			byte employeeOrder;
			string driverContractNo;
			string vehicleContractNo;

			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					vehicleContractNo = (string)dataReader[VEHICLE_CONTRACT_NO];
					vehicleNo = dataReader.GetInt32(VEHICLE_NO);
					driverContractNo = (string)dataReader[SERVICE_STAFF_CONTRACT_NO];
					employeeOrder = dataReader.GetByte(EMPLOYEE_ORDER);

					if(value.Contain(vehicleContractNo))
					{
						vehicleContract = (VehicleContract)value[vehicleContractNo];
						documentNo = new DocumentNo(driverContractNo);
						vehicleContract.ADriverContract = (DriverContract)dbContract.GetContract(documentNo, value.Company);
					}
					else
					{
						documentNo = new DocumentNo(vehicleContractNo);
						vehicleContract = (VehicleContract)dbContract.GetContract(documentNo, value.Company);
						documentNo = new DocumentNo(driverContractNo);
						vehicleContract.ADriverContract = (DriverContract)dbContract.GetContract(documentNo, value.Company);
						value.Add(vehicleContract);
					}

					driver = new Driver(value.Company);
					vehicleContract.ADriverContract.ALatestServiceStaffRoleList[employeeOrder.ToString()].ServiceStaffOrder = employeeOrder;
					driver.EmployeeNo = vehicleContract.ADriverContract.ALatestServiceStaffRoleList[employeeOrder.ToString()].AServiceStaff.EmployeeNo;
					driver.AName = vehicleContract.ADriverContract.ALatestServiceStaffRoleList[employeeOrder.ToString()].AServiceStaff.AName;
					driver.ASurname = vehicleContract.ADriverContract.ALatestServiceStaffRoleList[employeeOrder.ToString()].AServiceStaff.ASurname;
					vehicleContract.AVehicleRoleList[vehicleNo.ToString()].ADriver = driver;
				}
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			return result;
		}
		#endregion

//		============================== Public Method ==============================
		public bool FillVDContractMatch(ref VehicleContract value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.AVehicleRoleList.Company));
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(getEntityCondition(value));

			return fillVDContractMatch(ref value, stringBuilder.ToString()); 
		}

        public bool FillVDContractMatchByVehicle(ref VehicleContract vehicleContract, int vehicleNo)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(vehicleContract.AVehicleRoleList.Company));
            stringBuilder.Append(getKeyCondition(vehicleContract));
            stringBuilder.Append(getKeyCondition(vehicleNo));

            return fillVDContractMatch(ref vehicleContract, stringBuilder.ToString());
        }

        public bool FillVDContractMatchByEmployeeOrder(ref VehicleContract vehicleContract, int employeeOrder)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(vehicleContract.AVehicleRoleList.Company));
            stringBuilder.Append(getEntityCondition(vehicleContract));
            stringBuilder.Append(getEntityCondition(employeeOrder));

            return fillVDContractMatch(ref vehicleContract, stringBuilder.ToString());
        }

		public bool FillVDContractMatchList(ref ContractList value, ContractBase condition)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(condition));
			stringBuilder.Append(getOrderby());

			return fillVDContractMatchList(ref value, stringBuilder.ToString());	
		}

		public bool InsertVDContractMatch(VehicleContract value)
		{
			Vehicle vehicle;
			int order;

			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i < value.AVehicleRoleList.Count; i++)
			{
				order = i + 1;

				if(value.ADriverContract.ALatestServiceStaffRoleList[order.ToString()] != null)
				{
					vehicle = value.AVehicleRoleList[i].AVehicle;
					stringBuilder.Append(getSQLInsert(value, vehicle, value.ADriverContract.ALatestServiceStaffRoleList[order.ToString()]));
				}
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool UpdateVDContractMatch(VehicleContract value)
		{
			Vehicle vehicle;
			int order;

			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i < value.AVehicleRoleList.Count; i++)
			{
				vehicle = value.AVehicleRoleList[i].AVehicle;
				order = i + 1;
				stringBuilder.Append(getSQLUpdate(value, vehicle, value.ADriverContract.ALatestServiceStaffRoleList[order.ToString()]));
				stringBuilder.Append(getBaseCondition(value.AVehicleRoleList.Company));
				stringBuilder.Append(getKeyCondition(value));
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteVDContractMatch(VehicleContract value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.AVehicleRoleList.Company));
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

        //============================== Specific Public Method ==============================
        public int FillVDContractMatch(DocumentNo driverContractNo, Company company)
        {
            int vehicleNo = -1;

            StringBuilder stringBuilder = new StringBuilder(" SELECT Vehicle_No FROM VD_Contract_Match ");
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getEntityCondition(driverContractNo));

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
            try
            {
                if (dataReader.Read())
                {
                    vehicleNo = dataReader.GetInt32(0);
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }
            finally
            { tableAccess.CloseDataReader(); }

            return vehicleNo;
        }

        public DocumentNo GetSpecificVDMatchByContract(ContractType contractType, DocumentNo contractNo, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT Vehicle_Contract_No, Service_Staff_Contract_No FROM VD_Contract_Match");
            stringBuilder.Append(getBaseCondition(company));

            if (contractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
            {
                stringBuilder.Append(getKeyCondition(contractNo));            
            }
            else
            {
                stringBuilder.Append(getEntityCondition(contractNo));            
            }

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
            DocumentNo docNo = null;

            try
            {
                if (dataReader.Read())
                {
                    if (contractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
                    {
                        docNo = new DocumentNo(dataReader.GetString(1));
                    }
                    else
                    {
                        docNo = new DocumentNo(dataReader.GetString(0));
                    }
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }
            finally
            { tableAccess.CloseDataReader(); }

            return docNo;
        }
	}
}