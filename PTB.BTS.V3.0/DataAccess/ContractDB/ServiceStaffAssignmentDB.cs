using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Entity.ContractEntities;
using Entity.AttendanceEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
using System.Collections.Generic;

namespace DataAccess.ContractDB
{
	public class ServiceStaffAssignmentDB : DataAccessBase
	{
		#region - Constant -
		private const int ASSIGNED_EMPLOYEE_NO = 0;
		private const int FROM_DATE = 1;
		private const int TO_DATE = 2;
		private const int MAIN_EMPLOYEE_NO = 3;
		private const int CONTRACT_NO = 4;
		private const int EMPLOYEE_ORDER = 5;
		private const int ASSIGNMENT_ROLE = 6;
		private const int HIRER_NAME = 7;
		#endregion

		#region - Private -	
		private ServiceStaffAssignment _serviceStaffAssignment;
		private ServiceStaffDB _dbServiceStaff;
		private ContractDB _dbContract;
		#endregion

        #region Constructor
        public ServiceStaffAssignmentDB()
            : base()
        {
            _dbServiceStaff = new ServiceStaffDB();
            _dbContract = new ContractDB();
        }

        #endregion

        #region Private Method
        #region - getSQL -
        private string getSQLSelect()
        {
            return "SELECT Assigned_Employee_No, From_Date, To_Date, Main_Employee_No, Contract_No, Employee_Order, Assignment_Role, Hirer_Name FROM Service_Staff_Assignment ";
        }

        private string getSQLInsert(ServiceStaffAssignment value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Service_Staff_Assignment (Company_Code, Assigned_Employee_No, From_Date, To_Date, Main_Employee_No, Contract_No, Employee_Order, Assignment_Role, Hirer_Name, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Assigned_Employee_No
            stringBuilder.Append(GetDB(value.AAssignedServiceStaff.EmployeeNo));
            stringBuilder.Append(", ");

            //From_Date
            stringBuilder.Append(GetDB(value.APeriod.From));
            stringBuilder.Append(", ");

            //To_Date
            stringBuilder.Append(GetDB(value.APeriod.To));
            stringBuilder.Append(", ");

            //Main_Employee_No
            stringBuilder.Append(GetDB(value.AMainServiceStaff.EmployeeNo));
            stringBuilder.Append(", ");

            //Contract_No
            stringBuilder.Append(GetDB(value.AContract.ContractNo.ToString()));
            stringBuilder.Append(", ");

            //Employee_Order
            stringBuilder.Append(GetDB(value.EmployeeOrder));
            stringBuilder.Append(", ");

            //Assignment_Role
            stringBuilder.Append(GetDB(value.AssignmentRole));
            stringBuilder.Append(", ");

            //Hirer_Name
            stringBuilder.Append(GetDB(value.AHirer.Name));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(ServiceStaffAssignment value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Service_Staff_Assignment SET ");

            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Assigned_Employee_No = ");
            stringBuilder.Append(GetDB(value.AAssignedServiceStaff.EmployeeNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("From_Date = ");
            stringBuilder.Append(GetDB(value.APeriod.From));
            stringBuilder.Append(", ");

            stringBuilder.Append("To_Date = ");
            stringBuilder.Append(GetDB(value.APeriod.To));
            stringBuilder.Append(", ");

            stringBuilder.Append("Main_Employee_No = ");
            stringBuilder.Append(GetDB(value.AMainServiceStaff.EmployeeNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Contract_No = ");
            stringBuilder.Append(GetDB(value.AContract.ContractNo.ToString()));
            stringBuilder.Append(", ");

            stringBuilder.Append("Employee_Order = ");
            stringBuilder.Append(GetDB(value.EmployeeOrder));
            stringBuilder.Append(", ");

            stringBuilder.Append("Assignment_Role = ");
            stringBuilder.Append(GetDB(value.AssignmentRole));
            stringBuilder.Append(", ");

            stringBuilder.Append("Hirer_Name = ");
            stringBuilder.Append(GetDB(value.AHirer.Name));
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
            return " DELETE FROM Service_Staff_Assignment ";
        }

        private string getKeyCondition(ServiceStaffAssignment value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (value.AAssignedServiceStaff != null && IsNotNULL(value.AAssignedServiceStaff.EmployeeNo))
            {
                stringBuilder.Append(" AND (Assigned_Employee_No = ");
                stringBuilder.Append(GetDB(value.AAssignedServiceStaff.EmployeeNo));
                stringBuilder.Append(")");
            }
            if (value.APeriod != null)
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
            if (value.AMainServiceStaff != null && IsNotNULL(value.AMainServiceStaff.EmployeeNo))
            {
                stringBuilder.Append(" AND (Main_Employee_No = ");
                stringBuilder.Append(GetDB(value.AMainServiceStaff.EmployeeNo));
                stringBuilder.Append(")");
            }
            if (value.AContract != null && value.AContract.ContractNo != null && IsNotNULL(value.AContract.ContractNo.ToString()))
            {
                stringBuilder.Append(" AND (Contract_No = ");
                stringBuilder.Append(GetDB(value.AContract.ContractNo.ToString()));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getKeyCondition(ContractBase contract)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (contract != null && contract.ContractNo != null && IsNotNULL(contract.ContractNo.ToString()))
            {
                stringBuilder.Append(" AND (Contract_No = ");
                stringBuilder.Append(GetDB(contract.ContractNo.ToString()));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getPeriodCondition(TimePeriod value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (IsNotNULL(value.From))
            {
                stringBuilder.Append(" AND (From_Date = ");
                stringBuilder.Append(GetDB(value.From));
                stringBuilder.Append(")");
            }
            if (IsNotNULL(value.To))
            {
                stringBuilder.Append(" AND (To_Date = ");
                stringBuilder.Append(GetDB(value.To));
                stringBuilder.Append(")");
            }

            return stringBuilder.ToString();
        }

        private string getExcludeKeyCondition(ServiceStaffAssignment value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if ((value.AAssignedServiceStaff != null) && (IsNotNULL(value.AAssignedServiceStaff.EmployeeNo)))
            {
                stringBuilder.Append(" AND NOT(Assigned_Employee_No = ");
                stringBuilder.Append(GetDB(value.AAssignedServiceStaff.EmployeeNo));
                stringBuilder.Append(")");
            }
            if (value.APeriod != null)
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
            if ((value.AMainServiceStaff != null) && (IsNotNULL(value.AMainServiceStaff.EmployeeNo)))
            {
                stringBuilder.Append(" AND NOT(Main_Employee_No = ");
                stringBuilder.Append(GetDB(value.AMainServiceStaff.EmployeeNo));
                stringBuilder.Append(")");
            }
            if (value.AContract != null && value.AContract.ContractNo != null && IsNotNULL(value.AContract.ContractNo.ToString()))
            {
                stringBuilder.Append(" AND NOT(Contract_No = ");
                stringBuilder.Append(GetDB(value.AContract.ContractNo.ToString()));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string GetMaxAssignedByContract(DocumentNo contractNo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (contractNo != null && IsNotNULL(contractNo.ToString()))
            {
                stringBuilder.Append(" AND (Contract_No = ");
                stringBuilder.Append(GetDB(contractNo.ToString()));
                stringBuilder.Append(" ) ");

                stringBuilder.Append(" AND (Assignment_Role = 'M') AND (To_Date = (SELECT MAX(To_Date) FROM Service_Staff_Assignment WHERE (Assignment_Role = 'M') ");

                stringBuilder.Append(" AND (Contract_No = ");
                stringBuilder.Append(GetDB(contractNo.ToString()));
                stringBuilder.Append(" ))) ");
            }
            return stringBuilder.ToString();
        }

        private string getEntityCondition(ServiceStaffAssignment value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value.AssignmentRole))
            {
                stringBuilder.Append(" AND (Assignment_Role = ");
                stringBuilder.Append(GetDB(value.AssignmentRole));
                stringBuilder.Append(")");
            }
            if (IsNotNULL(value.EmployeeOrder))
            {
                stringBuilder.Append(" AND (Employee_Order = ");
                stringBuilder.Append(GetDB(value.EmployeeOrder));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getCurrentServiceStaffAssignmentCondition(ServiceStaffAssignment value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value.AAssignedServiceStaff.EmployeeNo))
            {
                stringBuilder.Append(" AND (Assigned_Employee_No = ");
                stringBuilder.Append(GetDB(value.AAssignedServiceStaff.EmployeeNo));
                stringBuilder.Append(" ) ");

                stringBuilder.Append(" AND (To_Date = (SELECT MAX(To_Date) FROM Service_Staff_Assignment WHERE (Assigned_Employee_No = ");

                stringBuilder.Append(GetDB(value.AAssignedServiceStaff.EmployeeNo));
                stringBuilder.Append(" ))) ");
            }
            return stringBuilder.ToString();
        }

        private string getListCondition(ServiceStaff value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (value != null && IsNotNULL(value.EmployeeNo))
            {
                stringBuilder.Append(" AND (Assigned_Employee_No = ");
                stringBuilder.Append(GetDB(value.EmployeeNo));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getKeyConditionInTimePeriod(TimePeriod value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (value != null)
            {
                stringBuilder.Append(" AND ((To_Date > ");
                stringBuilder.Append(GetDB(value.To));
                stringBuilder.Append(" ) AND (From_Date < ");
                stringBuilder.Append(GetDB(value.From));
                stringBuilder.Append(" )) ");
            }
            return stringBuilder.ToString();
        }

        private string getNotAvailableCondition(TimePeriod value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (value != null)
            {
                stringBuilder.Append(" AND ((To_Date >= ");
                stringBuilder.Append(GetDB(value.From));
                stringBuilder.Append(" ) AND (From_Date <= ");
                stringBuilder.Append(GetDB(value.To));
                stringBuilder.Append(" )) ");
            }
            return stringBuilder.ToString();
        }

        private string getPeriodCondition(ServiceStaff aServiceStaff, YearMonth yearMonth)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (aServiceStaff != null && IsNotNULL(aServiceStaff.EmployeeNo))
            {
                stringBuilder.Append(" AND (Assigned_Employee_No = ");
                stringBuilder.Append(GetDB(aServiceStaff.EmployeeNo));
                stringBuilder.Append(" ) ");
            }
            stringBuilder.Append(" AND ((MONTH(From_Date) = ");
            stringBuilder.Append(GetDB(yearMonth.Month));
            stringBuilder.Append(" AND YEAR(From_Date) = ");
            stringBuilder.Append(GetDB(yearMonth.Year));
            stringBuilder.Append(" ) OR (MONTH(To_Date) = ");
            stringBuilder.Append(GetDB(yearMonth.Month));
            stringBuilder.Append(" AND YEAR(To_Date) = ");
            stringBuilder.Append(GetDB(yearMonth.Year));
            stringBuilder.Append(" )) ");

            return stringBuilder.ToString();
        }

        private string getConditionForTheYearMonth(string fieldName, DateTime value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" ( ");
            stringBuilder.Append(" Month( ");
            stringBuilder.Append(fieldName);
            stringBuilder.Append(" )= ");
            stringBuilder.Append(value.Month.ToString());
            stringBuilder.Append(" AND ");
            stringBuilder.Append(" Year( ");
            stringBuilder.Append(fieldName);
            stringBuilder.Append(" )= ");
            stringBuilder.Append(value.Year.ToString());
            stringBuilder.Append(" ) ");

            return stringBuilder.ToString();
        }

        private string getOrderby()
        {
            return " ORDER BY Assigned_Employee_No, From_Date, To_Date, Main_Employee_No, Contract_No ";
        }

        #endregion

        #region - Fill -
        private void fillServiceStaffAssignment(ref ServiceStaffAssignment aServiceStaffAssignment, Company aCompany, SqlDataReader dataReader)
        {
            aServiceStaffAssignment.AAssignedServiceStaff = (ServiceStaff)_dbServiceStaff.GetFormerlyServiceStaff((string)dataReader[ASSIGNED_EMPLOYEE_NO], aCompany);
            aServiceStaffAssignment.APeriod.From = dataReader.GetDateTime(FROM_DATE);
            aServiceStaffAssignment.APeriod.To = dataReader.GetDateTime(TO_DATE);
            aServiceStaffAssignment.AMainServiceStaff = (ServiceStaff)_dbServiceStaff.GetFormerlyServiceStaff((string)dataReader[MAIN_EMPLOYEE_NO], aCompany);
            DocumentNo documentNo = new DocumentNo((string)dataReader[CONTRACT_NO]);
            aServiceStaffAssignment.AContract = _dbContract.GetContract(documentNo, aCompany);
            aServiceStaffAssignment.EmployeeOrder = dataReader.GetByte(EMPLOYEE_ORDER);
            aServiceStaffAssignment.AssignmentRole = CTFunction.GetAssignmentRoleType((string)dataReader[ASSIGNMENT_ROLE]);
            aServiceStaffAssignment.AHirer.Name = (string)dataReader[HIRER_NAME];
        }

        private bool fillServiceStaffAssignmentList(ref ServiceStaffAssignmentList value, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    _serviceStaffAssignment = new ServiceStaffAssignment();
                    fillServiceStaffAssignment(ref _serviceStaffAssignment, value.Company, dataReader);
                    value.Add(_serviceStaffAssignment);
                }
                _serviceStaffAssignment = null;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

        private bool fillServiceStaffAssignmentList(ServiceStaffAssignmentList value, SqlDataReader nonereadDataReader)
        {
            bool result = false;
            
            while (nonereadDataReader.Read())
            {
                if (!result) result = true;
                _serviceStaffAssignment = new ServiceStaffAssignment();
                fillServiceStaffAssignment(ref _serviceStaffAssignment, value.Company, nonereadDataReader);
                value.Add(_serviceStaffAssignment);
            }
            _serviceStaffAssignment = null;

            return result;
        }

        private bool fillServiceStaffAssignment(ref ServiceStaffAssignment value, Company aCompany, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillServiceStaffAssignment(ref value, aCompany, dataReader);
                    result = true;
                }
                else
                { result = false; }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

        private bool fillServiceStaffCurrentContract(ref ServiceStaffContract value, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    value.ContractNo = new DocumentNo((string)dataReader[CONTRACT_NO]);
                    result = true;
                }
                else
                { result = false; }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }
        #endregion 
        #endregion

        #region Public Method

        public ServiceStaffAssignment GetMaxAssignedByContract(DocumentNo contractNo, Company company)
        {

            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(GetMaxAssignedByContract(contractNo));

            _serviceStaffAssignment = new ServiceStaffAssignment();
            if (fillServiceStaffAssignment(ref _serviceStaffAssignment, company, stringBuilder.ToString()))
            {
                return _serviceStaffAssignment;
            }
            else
            {
                _serviceStaffAssignment = null;
                return null;
            }
        }

        public bool FillServiceStaffAssignment(ref ServiceStaffAssignment value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));

            return fillServiceStaffAssignment(ref value, aCompany, stringBuilder.ToString());
        }

        public bool FillServiceStaffAssignmentList(ref ServiceStaffAssignmentList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getListCondition(value.AServiceStaff));
            stringBuilder.Append(getOrderby());

            return fillServiceStaffAssignmentList(ref value, stringBuilder.ToString());
        }

        public bool FillServiceStaffAssignment(ref ServiceStaffAssignment value, TimePeriod aTimePeriod, Employee employee)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            ServiceStaff serviceStaff = new ServiceStaff(employee);
            stringBuilder.Append(getBaseCondition(employee.Company));
            stringBuilder.Append(" AND (Assigned_Employee_No = ");
            stringBuilder.Append(GetDB(employee.EmployeeNo));
            stringBuilder.Append(") ");
            stringBuilder.Append(getNotAvailableCondition(aTimePeriod));
            stringBuilder.Append(getOrderby());

            return fillServiceStaffAssignment(ref value, employee.Company, stringBuilder.ToString());
        }

        public bool FillServiceStaffAssignmentList(ref ServiceStaffAssignmentList value, TimePeriod aTimePeriod)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyConditionInTimePeriod(aTimePeriod));
            stringBuilder.Append(getOrderby());

            return fillServiceStaffAssignmentList(ref value, stringBuilder.ToString());
        }

        public bool FillServiceStaffAssignmentList(ref ServiceStaffAssignmentList aServiceStaffAssignmentList, ServiceStaffAssignment aServiceStaffAssignment)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aServiceStaffAssignmentList.Company));
            stringBuilder.Append(getKeyCondition(aServiceStaffAssignment));
            stringBuilder.Append(getEntityCondition(aServiceStaffAssignment));
            stringBuilder.Append(getOrderby());

            return fillServiceStaffAssignmentList(ref aServiceStaffAssignmentList, stringBuilder.ToString());
        }

        public bool FillExcludeServiceStaffAssignmentList(ref ServiceStaffAssignmentList aServiceStaffAssignmentList, ServiceStaffAssignment aServiceStaffAssignment)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aServiceStaffAssignmentList.Company));
            stringBuilder.Append(getExcludeKeyCondition(aServiceStaffAssignment));
            stringBuilder.Append(getOrderby());

            return fillServiceStaffAssignmentList(ref aServiceStaffAssignmentList, stringBuilder.ToString());
        }

        public bool FillCurrentServiceStaffAssignment(ref ServiceStaffAssignment value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getCurrentServiceStaffAssignmentCondition(value));

            return fillServiceStaffAssignment(ref value, aCompany, stringBuilder.ToString());
        }

        public bool FillNotAvailableServiceStaffAssignmentList(ref ServiceStaffAssignmentList value, TimePeriod aTimePeriod)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getNotAvailableCondition(aTimePeriod));
            stringBuilder.Append(getOrderby());

            return fillServiceStaffAssignmentList(ref value, stringBuilder.ToString());
        }

        public bool FillNotAvailableServiceStaffAssignment(ref ServiceStaffAssignment value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getListCondition(value.AAssignedServiceStaff));
            stringBuilder.Append(getNotAvailableCondition(value.APeriod));

            return fillServiceStaffAssignment(ref value, aCompany, stringBuilder.ToString());
        }

        public bool FillServiceStaffAssignmentInYearmonth(ref ServiceStaffAssignmentList value, TimePeriod timePeriod)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getListCondition(value.AServiceStaff));
            stringBuilder.Append(" AND ");

            stringBuilder.Append(" ( ");
            stringBuilder.Append(" (From_Date <= ");
            stringBuilder.Append(GetDB(timePeriod.From));
            stringBuilder.Append(") AND (To_Date >= ");
            stringBuilder.Append(GetDB(timePeriod.To));
            stringBuilder.Append(")");

            stringBuilder.Append(" OR ");

            stringBuilder.Append(getConditionForTheYearMonth("From_Date", timePeriod.From));

            stringBuilder.Append(" OR ");

            stringBuilder.Append(getConditionForTheYearMonth("To_Date", timePeriod.From));

            stringBuilder.Append(")");

            return fillServiceStaffAssignmentList(ref value, stringBuilder.ToString());
        }

        public bool FillServiceStaffAssignmentInYearmonth(ref ServiceStaffAssignmentList value, YearMonth yearMonth)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getListCondition(value.AServiceStaff));
            stringBuilder.Append(" AND ");

            stringBuilder.Append(" ( ");
            stringBuilder.Append(" (From_Date <= ");
            stringBuilder.Append(GetDB(yearMonth.MinDateOfMonth));
            stringBuilder.Append(") AND (To_Date >= ");
            stringBuilder.Append(GetDB(yearMonth.MaxDateOfMonth));
            stringBuilder.Append(")");

            stringBuilder.Append(" OR ");

            stringBuilder.Append(getConditionForTheYearMonth("From_Date", yearMonth.MinDateOfMonth));

            stringBuilder.Append(" OR ");

            stringBuilder.Append(getConditionForTheYearMonth("To_Date", yearMonth.MaxDateOfMonth));

            stringBuilder.Append(")");

            return fillServiceStaffAssignmentList(ref value, stringBuilder.ToString());
        }

        public bool FillServiceStaffAssignmentMainInYearmonth(ServiceStaffAssignmentList value, ContractBase contract, YearMonth yearMonth)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(contract));
            stringBuilder.Append(getListCondition(value.AServiceStaff));

            stringBuilder.Append(" AND ");
            stringBuilder.Append(" ( ");
            stringBuilder.Append(" (From_Date <= ");
            stringBuilder.Append(GetDB(yearMonth.MinDateOfMonth));
            stringBuilder.Append(") AND (To_Date >= ");
            stringBuilder.Append(GetDB(yearMonth.MaxDateOfMonth));
            stringBuilder.Append(")");
            stringBuilder.Append(" OR ");
            stringBuilder.Append(getConditionForTheYearMonth("From_Date", yearMonth.MinDateOfMonth));
            stringBuilder.Append(" OR ");
            stringBuilder.Append(getConditionForTheYearMonth("To_Date", yearMonth.MaxDateOfMonth));
            stringBuilder.Append(") AND (Assignment_Role = 'M') ");
            stringBuilder.Append(getOrderby());

            return fillServiceStaffAssignmentList(ref value, stringBuilder.ToString());
        }

        public bool FillServiceStaffAssignmentInPeriodList(ref ServiceStaffAssignmentList value, YearMonth yearMonth)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));

            if (value.AServiceStaff != null && IsNotNULL(value.AServiceStaff.EmployeeNo))
            {
                stringBuilder.Append(getListCondition(value.AServiceStaff));
            }

            stringBuilder.Append(" AND ");
            stringBuilder.Append(" ( ");
            stringBuilder.Append(" (From_Date <= ");
            stringBuilder.Append(GetDB(yearMonth.MinDateOfMonth));
            stringBuilder.Append(") AND (To_Date >= ");
            stringBuilder.Append(GetDB(yearMonth.MaxDateOfMonth));
            stringBuilder.Append(")");
            stringBuilder.Append(" OR ");
            stringBuilder.Append(getConditionForTheYearMonth("From_Date", yearMonth.MinDateOfMonth));
            stringBuilder.Append(" OR ");
            stringBuilder.Append(getConditionForTheYearMonth("To_Date", yearMonth.MaxDateOfMonth));
            stringBuilder.Append(") AND (Assignment_Role = 'M') ");
            stringBuilder.Append(getOrderby());

            return fillServiceStaffAssignmentList(ref value, stringBuilder.ToString());
        }

        public bool FillSpareServiceStaffAssignmentListInPeriodList(ref ServiceStaffAssignmentList value, YearMonth yearMonth)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(" AND (Main_Employee_No = ");
            stringBuilder.Append(GetDB(value.AServiceStaff.EmployeeNo));
            stringBuilder.Append(")");
            stringBuilder.Append(" AND ");
            stringBuilder.Append(" ( ");
            stringBuilder.Append(" (From_Date <= ");
            stringBuilder.Append(GetDB(yearMonth.MinDateOfMonth));
            stringBuilder.Append(") AND (To_Date >= ");
            stringBuilder.Append(GetDB(yearMonth.MaxDateOfMonth));
            stringBuilder.Append(")");
            stringBuilder.Append(" OR ");
            stringBuilder.Append(getConditionForTheYearMonth("From_Date", yearMonth.MinDateOfMonth));
            stringBuilder.Append(" OR ");
            stringBuilder.Append(getConditionForTheYearMonth("To_Date", yearMonth.MaxDateOfMonth));
            stringBuilder.Append(") AND (Assignment_Role = 'S') ");
            stringBuilder.Append(getOrderby());

            return fillServiceStaffAssignmentList(ref value, stringBuilder.ToString());
        }

        public bool FillServiceStaffAssignmentInDateList(ref ServiceStaffAssignmentList value, DateTime forDate)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));

            stringBuilder.Append(" AND ");
            stringBuilder.Append(" (To_Date = ");
            stringBuilder.Append(GetDB(forDate));
            stringBuilder.Append(" ) ");
            stringBuilder.Append(" AND (Assignment_Role = 'M') ");
            stringBuilder.Append(getOrderby());

            return fillServiceStaffAssignmentList(ref value, stringBuilder.ToString());
        }

        public bool FillSSAssignmentMainList(ServiceStaffAssignmentList listSS, string mainEmpNo)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(listSS.Company));

            if (mainEmpNo != "")
            {
                stringBuilder.Append(" AND (Main_Employee_No = ");
                stringBuilder.Append(GetDB(mainEmpNo));
                stringBuilder.Append(")");
            }
            stringBuilder.Append(" AND (Main_Employee_No <> Assigned_Employee_No) ");
            stringBuilder.Append(getOrderby());

            return fillServiceStaffAssignmentList(ref listSS, stringBuilder.ToString());
        }

        public ServiceStaffAssignment GetMainAssignmentInDate(ContractBase contract, DateTime date, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(contract));
            stringBuilder.Append(" AND (From_Date <= ");
            stringBuilder.Append(GetDB(date));
            stringBuilder.Append(") AND (To_Date >= ");
            stringBuilder.Append(GetDB(date));
            stringBuilder.Append(")");
            stringBuilder.Append(" AND (Assignment_Role = 'M') ");

            ServiceStaffAssignment assignment = new ServiceStaffAssignment();

            if (fillServiceStaffAssignment(ref assignment, company, stringBuilder.ToString()))
            {
                return assignment;
            }
            else
            {
                assignment = null;
                return null;
            }
        }

        public bool InsertServiceStaffAssignment(ServiceStaffAssignment value, Company aCompany)
        {
            if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany)) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool UpdateServiceStaffAssignment(ServiceStaffAssignment value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool UpdateServiceStaffAssignment(ServiceStaffAssignment value, ServiceStaffAssignment condition)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, value.AAssignedServiceStaff.Company));
            stringBuilder.Append(getBaseCondition(value.AAssignedServiceStaff.Company));
            stringBuilder.Append(getKeyCondition(condition));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool DeleteServiceStaffAssignment(ServiceStaffAssignment value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// To select data of main assign staff on period
        /// </summary>
        /// <param name="staffAssignList"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public bool FillStaffMainAssignByPeriodList(ServiceStaffAssignmentList staffAssignList, TimePeriod timePeriod,Company aCompany)
        {
            //TODO : P'Ya
            SqlCommand command = this.tableAccess.CreateCommand("SSelectAllStaffMainAssignByPeriod");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(this.tableAccess.CreateParameter("@Company_Code", aCompany.CompanyCode));
            command.Parameters.Add(this.tableAccess.CreateParameter("@Employee_No", staffAssignList.AServiceStaff.EmployeeNo));
            command.Parameters.Add(this.tableAccess.CreateParameter("@FromDate", timePeriod.From));
            command.Parameters.Add(this.tableAccess.CreateParameter("@ToDate", timePeriod.To));

            SqlDataReader reader = this.tableAccess.ExecuteDataReader(command);
            
            bool found = this.fillServiceStaffAssignmentList(staffAssignList, reader);

            this.tableAccess.CloseDataReader();

            return found;
        }

        /// <summary>
        /// To select data of service staff assignment who is main role on assign period date.
        /// </summary>
        /// <param name="staff"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public List<ServiceStaffAssignment> GetStaffMainAssignByPeriod(ServiceStaff staff, TimePeriod timePeriod,Company aCompany)
        {
            SqlCommand command = this.tableAccess.CreateCommand("SSelectStaffMainAssignByPeriod");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(this.tableAccess.CreateParameter("@Company_Code", aCompany.CompanyCode));
            command.Parameters.Add(this.tableAccess.CreateParameter("@Employee_No", staff.EmployeeNo));
            command.Parameters.Add(this.tableAccess.CreateParameter("@FromDate", timePeriod.From));
            command.Parameters.Add(this.tableAccess.CreateParameter("@ToDate", timePeriod.To));

            List<ServiceStaffAssignment> listAssign = new List<ServiceStaffAssignment>();
            ServiceStaffAssignment serviceStaffAssignment;
            SqlDataReader reader = this.tableAccess.ExecuteDataReader(command);

            while (reader.Read())
            {
                serviceStaffAssignment = new ServiceStaffAssignment();
                this.fillServiceStaffAssignment(ref serviceStaffAssignment, aCompany, reader);
                listAssign.Add(serviceStaffAssignment);
            }

            serviceStaffAssignment = null;
 
            this.tableAccess.CloseDataReader();

            return listAssign;
        }

        /// <summary>
        /// To select service staff assignment detail by specific date and other condition
        /// </summary>
        /// <param name="assignedEmployee"></param>
        /// <param name="dateCondition"></param>
        /// <returns></returns>
        public ServiceStaffAssignment GetStaffAssignByDate(Employee assignedEmployee,DateTime dateCondition)
        {
            string errorMessage = string.Empty;
            if (assignedEmployee == null)
            {
                errorMessage = "the assigned employee argument is null";
            } 
            else if (assignedEmployee.Company == null) {
                errorMessage = "the company of assigned employee argument is null.";
            }

            if (errorMessage == string.Empty)
            {
                SqlCommand command = this.tableAccess.CreateCommand("SSelectStaffAssignByDate");
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(this.tableAccess.CreateParameter("@Company_Code", assignedEmployee.Company.CompanyCode));
                command.Parameters.Add(this.tableAccess.CreateParameter("@Assigned_Employee_No", assignedEmployee.EmployeeNo));
                command.Parameters.Add(this.tableAccess.CreateParameter("@Date", dateCondition));

                ServiceStaffAssignment serviceStaffAssignment;
                SqlDataReader reader = this.tableAccess.ExecuteDataReader(command);
                if (reader.Read())
                {
                    serviceStaffAssignment = new ServiceStaffAssignment();
                    this.fillServiceStaffAssignment(ref serviceStaffAssignment, assignedEmployee.Company, reader);
                }
                else
                {
                    serviceStaffAssignment = null;
                }
                this.tableAccess.CloseDataReader();

                return serviceStaffAssignment;
            }
            else
            {
                throw new Exception("ServiceStaffAssignmentDB.GetStaffMainAssignByPeriod(Employee assignedEmployee,DateTime dateCondition throw exception that " + errorMessage);
            }
        }
        #endregion

        #region Public Specific Method
        public bool FillSpecificServiceStaffAssignmentInYearMonthList(AssignmentList listAssignment)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT Assigned_Employee_No, From_Date, To_Date, Assignment_Role, Hirer_Name FROM Service_Staff_Assignment ");
            stringBuilder.Append(getBaseCondition(listAssignment.Company));
            stringBuilder.Append(getKeyCondition(listAssignment.Contract));

            stringBuilder.Append(" AND ((From_Date <= ");
            stringBuilder.Append(GetDB(listAssignment.YearMonth.MinDateOfMonth));
            stringBuilder.Append(") AND (To_Date >= ");
            stringBuilder.Append(GetDB(listAssignment.YearMonth.MaxDateOfMonth));
            stringBuilder.Append(" ) OR ");
            stringBuilder.Append(getConditionForTheYearMonth("From_Date", listAssignment.YearMonth.MinDateOfMonth));
            stringBuilder.Append(" OR ");
            stringBuilder.Append(getConditionForTheYearMonth("To_Date", listAssignment.YearMonth.MaxDateOfMonth));
            stringBuilder.Append(" ) ");
            stringBuilder.Append(getOrderby());

            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    _serviceStaffAssignment = new ServiceStaffAssignment();
                    _serviceStaffAssignment.AAssignedServiceStaff = (ServiceStaff)_dbServiceStaff.GetFormerlyServiceStaff((string)dataReader[0], listAssignment.Company);
                    _serviceStaffAssignment.APeriod.From = dataReader.GetDateTime(1);
                    _serviceStaffAssignment.APeriod.To = dataReader.GetDateTime(2);
                    _serviceStaffAssignment.AMainServiceStaff = _serviceStaffAssignment.AAssignedServiceStaff;
                    _serviceStaffAssignment.AContract = listAssignment.Contract;
                    _serviceStaffAssignment.AssignmentRole = CTFunction.GetAssignmentRoleType((string)dataReader[3]);
                    _serviceStaffAssignment.AHirer.Name = (string)dataReader["Hirer_Name"];
                    listAssignment.Add(_serviceStaffAssignment);
                }
                _serviceStaffAssignment = null;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

        public bool FillSpecificServiceStaffAssignment(Employee employee, DateTime forDate)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(employee.Company));

            stringBuilder.Append(" AND (Main_Employee_No = ");
            stringBuilder.Append(GetDB(employee.EmployeeNo));
            stringBuilder.Append(" ) ");
            stringBuilder.Append(" AND (Assigned_Employee_No <> ");
            stringBuilder.Append(GetDB(employee.EmployeeNo));
            stringBuilder.Append(" ) ");
            stringBuilder.Append(" AND ((To_Date >= ");
            stringBuilder.Append(GetDB(forDate));
            stringBuilder.Append(" ) AND (From_Date <= ");
            stringBuilder.Append(GetDB(forDate));
            stringBuilder.Append(" ) AND (Assignment_Role <> 'M')) ");
            // Comment by woranai : 03/04/2007
            //stringBuilder.Append(" )) ");

            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());

            try
            {
                result = dataReader.Read();
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;            
        }

        public bool FillSpecificAssignExpire(ServiceStaffAssignmentList SSList, DateTime forDate)
        {
            StringBuilder strBuild = new StringBuilder("SELECT	SA.Assigned_Employee_No, SA.From_Date, SA.To_Date, SA.Main_Employee_No, SA.Contract_No, SA.Employee_Order, SA.Assignment_Role, SA.Hirer_Name ");
            strBuild.Append(" FROM Service_Staff SS LEFT OUTER JOIN ");
            strBuild.Append(" (SELECT MAX(To_Date) AS MaxAssignDate, Assigned_Employee_No, Contract_No ");
            strBuild.Append(" FROM Service_Staff_Assignment ");
		    strBuild.Append(" WHERE (Assignment_Role = 'M') ");
            strBuild.Append(" GROUP BY Assigned_Employee_No, Contract_No ");
            strBuild.Append(" HAVING MAX(To_Date) <= ");
            strBuild.Append(GetDB(forDate));
            strBuild.Append(" ) MA ");
            strBuild.Append(" ON SS.Employee_No = MA.Assigned_Employee_No LEFT OUTER JOIN Service_Staff_Assignment SA ");
	        strBuild.Append(" ON  SS.Employee_No = SA.Assigned_Employee_No AND SA.Contract_No = MA.Contract_No AND SA.To_Date = MA.MaxAssignDate ");
            strBuild.Append(" WHERE	SS.Service_Staff_Type NOT LIKE '%Z' AND SS.Current_Contract_No = MA.Contract_No ");

            return fillServiceStaffAssignmentList(ref SSList, strBuild.ToString());
        }
        #endregion

        #region Funcition is not use for BTS Phase III : woranai 2008/11/26
        //public ServiceStaffContract GetServiceStaffCurrentContractOfAssigned(string employeeNo, Company value)
        //{
        //    ServiceStaffContract objServiceStaffContract = new ServiceStaffContract(value);

        //    StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
        //    stringBuilder.Append(getBaseCondition(value));
        //    stringBuilder.Append(getAssignedServiceStaffContractCondition(employeeNo));

        //    if (fillServiceStaffCurrentContract(ref objServiceStaffContract, stringBuilder.ToString()))
        //    {
        //        return objServiceStaffContract;
        //    }
        //    else
        //    {
        //        objServiceStaffContract = null;
        //        return null;
        //    }
        //}
        #endregion

    }
}
