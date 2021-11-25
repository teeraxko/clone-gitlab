using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using DataAccess.CommonDB;
using DataAccess.PiDB;

using Entity.CommonEntity;
using Entity.ContractEntities;

using SystemFramework.AppConfig;
using SystemFramework.AppException;

using ictus.Common.Entity;
using Entity.AttendanceEntities;

namespace DataAccess.ContractDB
{
	public class ServiceStaffDB: DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int CENTURY = 1;
		private const int THAI_PREFIX = 2;
		private const int THAI_NAME = 3;
		private const int THAI_SERNAME = 4;
		private const int ENGLISH_PREFIX = 5;
		private const int ENGLISH_NAME = 6;
		private const int ENGLISH_SURNAME = 7;
		private const int POSITION_CODE = 8;
		private const int SHIFT_NO = 9;
		private const int KIND_OF_OT = 10;
		private const int HIRE_DATE = 11;
		private const int WORKING_STATUS = 12;
		private const int TERMINATION_DATE = 13;
		private const int SERVICE_STAFF_TYPE = 14;
		private const int CURRENT_CONTRACT_NO = 15;
		#endregion

		#region - Private -	
		private ServiceStaffTypeDB dbServiceStaffType;
		private PositionDB dbPosition;
		private WorkingStatusDB dbWorkingStatus;

		private ServiceStaff objServiceStaff;
		private bool disposed = false;
		#endregion

        #region Constructor
        public ServiceStaffDB()
            : base()
        {
            dbPosition = new PositionDB();
            dbServiceStaffType = new ServiceStaffTypeDB();
            dbWorkingStatus = new WorkingStatusDB();
        } 
        #endregion

        #region Private Method
        #region - getSQL -
        private string getSQLSelect()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(" SELECT Service_Staff.Employee_No, Employee.Century, Employee.Thai_Prefix, Employee.Thai_Name, Employee.Thai_Surname, Employee.English_Prefix, Employee.English_Name, Employee.English_Surname, Employee.Position_Code, Employee.Shift_No, Employee.Kind_Of_OT, Employee.Hire_Date, Employee.Working_Status, Employee.Termination_Date, Service_Staff.Service_Staff_Type, Service_Staff.Current_Contract_No ");
            stringBuilder.Append(" FROM Service_Staff RIGHT OUTER JOIN Employee ON Service_Staff.Company_Code = Employee.Company_Code AND Service_Staff.Employee_No = Employee.Employee_No ");
            return stringBuilder.ToString();
        }

        private string getSQLInsert(ServiceStaff value)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Service_Staff (Company_Code, Employee_No, Service_Staff_Type, Current_Contract_No, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(value.Company.CompanyCode));
            stringBuilder.Append(", ");

            //Employee_No			
            stringBuilder.Append(GetDB(value.EmployeeNo));
            stringBuilder.Append(", ");

            //Service_Staff_Type
            stringBuilder.Append(GetDB(value.AServiceStaffType.Type));
            stringBuilder.Append(", ");

            //Current_Contract_No
            if (value.ACurrentContract != null && value.ACurrentContract.ContractNo != null)
            {
                stringBuilder.Append(GetDB(value.ACurrentContract.ContractNo.ToString()));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(NullConstant.STRING));
                stringBuilder.Append(", ");
            }

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(ServiceStaff value, ServiceStaffType aServiceStaffType)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Service_Staff SET ");
            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(value.Company.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Employee_No = ");
            stringBuilder.Append(GetDB(value.EmployeeNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Service_Staff_Type = ");
            stringBuilder.Append(GetDB(aServiceStaffType.Type));
            stringBuilder.Append(", ");

            stringBuilder.Append("Current_Contract_No = ");
            if (value.ACurrentContract != null && value.ACurrentContract.ContractNo != null)
            {
                stringBuilder.Append(GetDB(value.ACurrentContract.ContractNo.ToString()));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(NullConstant.STRING));
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
            return " DELETE FROM Service_Staff ";
        }

        protected sealed override string getBaseCondition(Company value)
        {
            StringBuilder stringBuilder = new StringBuilder(" WHERE (Service_Staff.Company_Code = ");
            if (IsNotNULL(value.CompanyCode))
            {
                stringBuilder.Append(GetDB(value.CompanyCode));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getKeyCondition(ServiceStaff value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value.EmployeeNo))
            {
                stringBuilder.Append(" AND (Service_Staff.Employee_No = ");
                stringBuilder.Append(GetDB(value.EmployeeNo));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getEntityCondition(ServiceStaffType value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value.Type))
            {
                stringBuilder.Append(" AND (Service_Staff.Service_Staff_Type = ");
                stringBuilder.Append(GetDB(value.Type));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();

        }

        private string getEntityCondition(ServiceStaffType aServiceStaffType, ServiceStaffContract aServiceStaffContract, Customer aCustomer, CustomerDepartment aCustomerDepartment)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(aServiceStaffType.Type))
            {
                stringBuilder.Append(" AND (Service_Staff.Service_Staff_Type = ");
                stringBuilder.Append(GetDB(aServiceStaffType.Type));
                stringBuilder.Append(")");
            }
            if (aServiceStaffContract.ContractNo != null && IsNotNULL(aServiceStaffContract.ContractNo.ToString()))
            {
                stringBuilder.Append(" AND (Service_Staff.Current_Contract_No = ");
                stringBuilder.Append(GetDB(aServiceStaffContract.ContractNo.ToString()));
                stringBuilder.Append(")");
            }
            if (IsNotNULL(aCustomer.Code))
            {
                stringBuilder.Append(" AND (Contract.Customer_Code = ");
                stringBuilder.Append(GetDB(aCustomer.Code));
                stringBuilder.Append(")");
            }
            if (IsNotNULL(aCustomerDepartment.Code))
            {
                stringBuilder.Append(" AND (Contract.Customer_Department = ");
                stringBuilder.Append(GetDB(aCustomerDepartment.Code));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getEntityCondition(Position value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value.PositionCode))
            {
                stringBuilder.Append(" AND (Employee.Position_Code = ");
                stringBuilder.Append(GetDB(value.PositionCode));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getStaffAvailable()
        {
            return " AND ((Employee.Working_Status NOT IN ('06', '07', '08', '10')) OR (Employee.Termination_Date > GETDATE())) ";
        }

        private string getStaffAvailable(DateTime value)
        {
            StringBuilder stringBuilder = new StringBuilder(" AND ((Employee.Working_Status NOT IN ('06', '07', '08', '10')) ");
            if (IsNotNULL(value))
            {
                stringBuilder.Append(" OR (Employee.Termination_Date > ");
                stringBuilder.Append(GetDB(value));
                stringBuilder.Append(" ) ");
            }
            stringBuilder.Append(" ) ");
            return stringBuilder.ToString();
        }

        private string getOrderby()
        {
            return " ORDER BY Employee.Century, Service_Staff.Employee_No";
        }
        #endregion

        #region - Fill -
        private void fillStaff(ref ServiceStaff value, SqlDataReader dataReader)
        {
            if (dataReader.IsDBNull(EMPLOYEE_NO))
            {
                value.EmployeeNo = NullConstant.STRING;
            }
            else
            {
                value.EmployeeNo = (string)dataReader[EMPLOYEE_NO];
                value.APrefix.Thai = (string)dataReader[THAI_PREFIX];
                value.AName.Thai = (string)dataReader[THAI_NAME];
                value.ASurname.Thai = (string)dataReader[THAI_SERNAME];
                value.APrefix.English = (string)dataReader[ENGLISH_PREFIX];
                value.AName.English = (string)dataReader[ENGLISH_NAME];
                value.ASurname.English = (string)dataReader[ENGLISH_SURNAME];
                value.APosition = dbPosition.GetDBPosition((string)dataReader[POSITION_CODE], value.Company);
                value.HireDate = dataReader.GetDateTime(HIRE_DATE);
                value.AWorkingStatus = (WorkingStatus)dbWorkingStatus.GetDBDualField((string)dataReader[WORKING_STATUS], value.Company);

                if (dataReader.IsDBNull(TERMINATION_DATE))
                {
                    value.TerminationDate = NullConstant.DATETIME;
                }
                else
                {
                    value.TerminationDate = dataReader.GetDateTime(TERMINATION_DATE);
                }

                value.AServiceStaffType = dbServiceStaffType.GetDBServiceStaffType((string)dataReader[SERVICE_STAFF_TYPE], value.Company);
                string contractNo = (dataReader.IsDBNull(CURRENT_CONTRACT_NO)) ? string.Empty : (string)dataReader[CURRENT_CONTRACT_NO];
                if (contractNo.Trim() != "")
                {
                    value.ACurrentContract = new ServiceStaffContract(value.Company);
                    value.ACurrentContract.ContractNo = new DocumentNo((string)dataReader[CURRENT_CONTRACT_NO]);
                }
                else
                {
                    value.ACurrentContract = null;
                }
            }
        }

        private void fillStaffDB(ref ServiceStaff value, SqlDataReader dataReader)
        {
            fillStaff(ref value, dataReader);

            if (!dataReader.IsDBNull(EMPLOYEE_NO))
            {
                value.APosition = dbPosition.GetDBPosition((string)dataReader[POSITION_CODE], value.Company);
                value.AWorkingStatus = (WorkingStatus)dbWorkingStatus.GetDBDualField((string)dataReader[WORKING_STATUS], value.Company);
                value.AServiceStaffType = dbServiceStaffType.GetDBServiceStaffType((string)dataReader[SERVICE_STAFF_TYPE], value.Company);
            }
        }

        private bool fillStaff(ref ServiceStaff value, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillStaffDB(ref value, dataReader);
                    result = true;
                }
                else
                {
                    return false;
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

        private bool fillStaffList(ref EmployeeList value, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            PositionList listPosition = new PositionList(value.Company);
            dbPosition.FillPositionList(ref listPosition);
            WorkingStatusList listWorkingStatusList = new WorkingStatusList(value.Company);
            dbWorkingStatus.FillMTBList(listWorkingStatusList);
            ServiceStaffTypeList listServiceStaffType = new ServiceStaffTypeList(value.Company);
            dbServiceStaffType.FillServiceStaffTypeList(ref listServiceStaffType);

            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    objServiceStaff = new ServiceStaff(value.Company);

                    if (!dataReader.IsDBNull(EMPLOYEE_NO))
                    {
                        objServiceStaff.APosition = listPosition[(string)dataReader[POSITION_CODE]];
                        objServiceStaff.AWorkingStatus = listWorkingStatusList[(string)dataReader[WORKING_STATUS]];
                        objServiceStaff.AServiceStaffType = listServiceStaffType[(string)dataReader[SERVICE_STAFF_TYPE]];
                    }
                    fillStaff(ref objServiceStaff, dataReader);

                    value.Add(objServiceStaff);
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            {
                tableAccess.CloseDataReader();
                listPosition = null;
                listWorkingStatusList = null;
                listServiceStaffType = null;
                dataReader = null;
            }
            return result;
        }

        private bool fillStaffCommand(ServiceStaff serviceStaff, SqlCommand command)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);

            try
            {
                if (dataReader.Read())
                {
                    fillStaffDB(ref serviceStaff, dataReader);
                    result = true;
                }
                else
                {
                    return false;
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

        private bool fillStaffCommandList(EmployeeList employeeList, SqlCommand command)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);

            PositionList listPosition = new PositionList(employeeList.Company);
            dbPosition.FillPositionList(ref listPosition);

            WorkingStatusList listWorkingStatusList = new WorkingStatusList(employeeList.Company);
            dbWorkingStatus.FillMTBList(listWorkingStatusList);

            ServiceStaffTypeList listServiceStaffType = new ServiceStaffTypeList(employeeList.Company);
            dbServiceStaffType.FillServiceStaffTypeList(ref listServiceStaffType);

            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    objServiceStaff = new ServiceStaff(employeeList.Company);

                    if (!dataReader.IsDBNull(EMPLOYEE_NO))
                    {
                        objServiceStaff.APosition = listPosition[(string)dataReader[POSITION_CODE]];
                        objServiceStaff.AWorkingStatus = listWorkingStatusList[(string)dataReader[WORKING_STATUS]];
                        objServiceStaff.AServiceStaffType = listServiceStaffType[(string)dataReader[SERVICE_STAFF_TYPE]];
                    }
                    fillStaff(ref objServiceStaff, dataReader);

                    employeeList.Add(objServiceStaff);
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            {
                tableAccess.CloseDataReader();
                listPosition = null;
                listWorkingStatusList = null;
                listServiceStaffType = null;
                dataReader = null;
            }
            return result;
        }

        #endregion 
        #endregion

        #region Internal Method
        internal Employee GetDBAvailableStaff(string employeeNo, Company aCompany)
        {
            objServiceStaff = new ServiceStaff(employeeNo, aCompany);
            if (FillAvailableStaff(ref objServiceStaff))
            { return objServiceStaff; }

            else
            {
                objServiceStaff.EmployeeNo = NullConstant.STRING;
                return objServiceStaff;
            }
        }

        internal Employee GetDBAllStaff(string employeeNo, Company aCompany)
        {
            objServiceStaff = new ServiceStaff(employeeNo, aCompany);
            if (FillAllStaff(ref objServiceStaff))
            { return objServiceStaff; }

            else
            {
                objServiceStaff.EmployeeNo = NullConstant.STRING;
                return objServiceStaff;
            }
        } 
        #endregion

        #region Public Method
        public Employee GetAvailableStaff(string employeeNo, Company aCompany)
        {
            objServiceStaff = new ServiceStaff(employeeNo, aCompany);
            if (FillAvailableStaff(ref objServiceStaff))
            { return objServiceStaff; }

            else
            {
                objServiceStaff = null;
                return null;
            }
        }

        public ServiceStaff GetAllStaff(string employeeNo, Company aCompany)
        {
            objServiceStaff = new ServiceStaff(employeeNo, aCompany);
            if (FillAllStaff(ref objServiceStaff))
            { return objServiceStaff; }

            else
            {
                objServiceStaff = null;
                return null;
            }
        }

        public ServiceStaff GetFormerlyServiceStaff(string employeeNo, Company company)
        {
            EmployeeDB dbEmployee;
            Employee employee;
            ServiceStaff serviceStaff;

            try
            {
                dbEmployee = new EmployeeDB();
                employee = dbEmployee.GetFormerlyEmployee(employeeNo, company);
                dbEmployee = null;
                serviceStaff = new ServiceStaff(employee);

                string sql = "SELECT Service_Staff_Type, Current_Contract_No FROM Service_Staff WHERE (Employee_No  = '" + serviceStaff.EmployeeNo + "') AND (Company_Code = '" + serviceStaff.Company.CompanyCode + "')";
                SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);

                if (dataReader.Read())
                {
                    serviceStaff.AServiceStaffType = dbServiceStaffType.GetDBServiceStaffType((string)dataReader[0], serviceStaff.Company);
                    string contractNo = (string)dataReader[1];
                    if (contractNo.Trim() != "")
                    {
                        serviceStaff.ACurrentContract = new ServiceStaffContract(serviceStaff.Company);
                        serviceStaff.ACurrentContract.ContractNo = new DocumentNo((string)dataReader[1]);
                    }
                    else
                    {
                        serviceStaff.ACurrentContract = null;
                    }
                }
                else
                {
                    throw new EmpNotFoundException("ServiceStaffDB");
                }

                return serviceStaff;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }
            finally
            {
                tableAccess.CloseDataReader();
            }
        }

        public bool FillAvailableStaff(ref ServiceStaff value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value));
            stringBuilder.Append(getStaffAvailable());
            return fillStaff(ref value, stringBuilder.ToString());
        }

        public bool FillAllStaff(ref ServiceStaff value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value));
            return fillStaff(ref value, stringBuilder.ToString());
        }

        public bool FillAvailableStaffList(ref EmployeeList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getStaffAvailable());
            stringBuilder.Append(getOrderby());

            return fillStaffList(ref value, stringBuilder.ToString());
        }

        public bool FillAvailableStaffList(ref EmployeeList value, ServiceStaffType aServiceStaffType)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getEntityCondition(aServiceStaffType));
            stringBuilder.Append(getStaffAvailable());
            stringBuilder.Append(getOrderby());

            return fillStaffList(ref value, stringBuilder.ToString());
        }

        public bool FillAvailableStaffList(ref EmployeeList value, ServiceStaffType aServiceStaffType, DateTime effecttiveDate)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getEntityCondition(aServiceStaffType));
            stringBuilder.Append(getStaffAvailable(effecttiveDate));
            stringBuilder.Append(getOrderby());

            return fillStaffList(ref value, stringBuilder.ToString());
        }

        public bool FillAvailableStaff(ref ServiceStaff value, DateTime forDate)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value));
            stringBuilder.Append(getStaffAvailable(forDate));
            return fillStaff(ref value, stringBuilder.ToString());
        }

        public bool InsertServiceStaff(ServiceStaff value)
        {
            if (tableAccess.ExecuteSQL(getSQLInsert(value)) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool UpdateServiceStaff(ServiceStaff value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, value.AServiceStaffType));
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool UpdateServiceStaff(ServiceStaff aServiceStaff, ServiceStaffType aServiceStaffType)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(aServiceStaff, aServiceStaffType));
            stringBuilder.Append(getBaseCondition(aServiceStaff.Company));
            stringBuilder.Append(getKeyCondition(aServiceStaff));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool DeleteServiceStaff(ServiceStaff value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// This function same as function FillServiceStaffMainByPeriod but select only driver spare.
        /// </summary>
        /// <param name="employeeList"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public bool FillDriverSpareByPeriod(EmployeeList employeeList, TimePeriod timePeriod)
        {
            //TODO : P'Ya
            SqlCommand selectCommand = this.tableAccess.CreateCommand(string.Empty);
            selectCommand.CommandText = "SSelectAllDriverSpareByPeriod";
            selectCommand.CommandType = CommandType.StoredProcedure;

            selectCommand.Parameters.Add(this.tableAccess.CreateParameter("@Company_Code", employeeList.Company.CompanyCode));
            selectCommand.Parameters.Add(this.tableAccess.CreateParameter("@Employee_No", Convert.DBNull));
            selectCommand.Parameters.Add(this.tableAccess.CreateParameter("@FromDate", timePeriod.From));
            selectCommand.Parameters.Add(this.tableAccess.CreateParameter("@ToDate", timePeriod.To));

            return this.fillStaffCommandList(employeeList, selectCommand);
        }

        /// <summary>
        /// To select current staff detail.This stored procedure select only record in period 
        /// per staff who is main role on assign period date.
        /// </summary>
        /// <param name="serviceStaff"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public bool FillServiceStaffMainByPeriod(ServiceStaff serviceStaff, TimePeriod timePeriod)
        {
            //TODO : P'Ya

            SqlCommand selectCommand = this.tableAccess.CreateCommand(string.Empty);
            selectCommand.CommandText = "SSelectServiceStaffMainByPeriod";
            selectCommand.CommandType = CommandType.StoredProcedure;

            string employeeNo = (serviceStaff == null) ? null : serviceStaff.EmployeeNo;
            selectCommand.Parameters.Add(this.tableAccess.CreateParameter("@Company_Code", serviceStaff.Company.CompanyCode));
            selectCommand.Parameters.Add(this.tableAccess.CreateParameter("@Employee_No", employeeNo));
            selectCommand.Parameters.Add(this.tableAccess.CreateParameter("@FromDate", timePeriod.From));
            selectCommand.Parameters.Add(this.tableAccess.CreateParameter("@ToDate", timePeriod.To));

            return this.fillStaffCommand(serviceStaff, selectCommand);
        }
        #endregion

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						dbPosition.Dispose();
						dbServiceStaffType.Dispose();

						dbPosition = null;
						dbServiceStaffType = null;
						objServiceStaff = null;
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

		#region - Service Staff New -
//			public bool FillStaffList(ref EmployeeList value, ServiceStaffType aServiceStaffType)
//			{
//				bool result = false;
//				ServiceStaff serviceStaff;
//
//				StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
//				stringBuilder.Append(getBaseCondition(value.Company));
//				stringBuilder.Append(getEntityCondition(aServiceStaffType));
//				stringBuilder.Append(getStaffAvailable());
//				stringBuilder.Append(getOrderby());
//				
//				SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
//				try
//				{
//					while (dataReader.Read())
//					{
//						result = true;
//						serviceStaff = new ServiceStaff(value.Company);
//						serviceStaff.EmployeeNo = (string)dataReader[EMPLOYEE_NO];
//						serviceStaff.APrefix.Thai = (string)dataReader[THAI_PREFIX];
//						serviceStaff.AName.Thai = (string)dataReader[THAI_NAME];
//						serviceStaff.ASurname.Thai = (string)dataReader[THAI_SERNAME];
//						serviceStaff.APrefix.English = (string)dataReader[ENGLISH_PREFIX];
//						serviceStaff.AName.English = (string)dataReader[ENGLISH_NAME];
//						serviceStaff.ASurname.English = (string)dataReader[ENGLISH_SURNAME];
//						serviceStaff.KindOfOT = CTFunction.GetKindOfOTType((string)dataReader[KIND_OF_OT]);
//						serviceStaff.HireDate = dataReader.GetDateTime(HIRE_DATE);
//
//						string contractNo = (string)dataReader[CURRENT_CONTRACT_NO];
//						if(contractNo.Trim() != "")
//						{
//							value.ACurrentContract = new ServiceStaffContract(value.Company);
//							value.ACurrentContract.ContractNo = new DocumentNo((string)dataReader[CURRENT_CONTRACT_NO]);
//						}
//						else
//						{
//							value.ACurrentContract = null;
//						}
//
////						value.APosition = dbPosition.GetDBPosition((string)dataReader[POSITION_CODE], value.Company);
////						value.AServiceStaffType = dbServiceStaffType.GetDBServiceStaffType((string)dataReader[SERVICE_STAFF_TYPE], value.Company);
//
//
//
//						value.Add(objServiceStaff);
//					}
//				}
//				catch (IndexOutOfRangeException ein)
//				{
//					throw ein;
//				}
//				finally
//				{
//					tableAccess.CloseDataReader();
//					stringBuilder = null;
//				}
//
//				return result;
//			}
		#endregion

	}
}