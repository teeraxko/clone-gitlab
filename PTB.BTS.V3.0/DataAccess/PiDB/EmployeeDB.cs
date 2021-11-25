using System;
using System.Data.SqlClient;
using System.Text;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.General;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;
using SystemFramework.AppException;
using System.Data;

namespace DataAccess.PiDB
{
    public class EmployeeDB : DataAccessBase
    {
        #region Private Constant
        private const int EMPLOYEE_NO = 0;
        private const int DEPARTMENT_CODE = 1;
        private const int SECTION_CODE = 2;
        private const int THAI_PREFIX = 3;
        private const int THAI_NAME = 4;
        private const int THAI_SURNAME = 5;
        private const int ENGLISH_PREFIX = 6;
        private const int ENGLISH_NAME = 7;
        private const int ENGLISH_SURNAME = 8;
        private const int POSITION_CODE = 9;
        private const int HIRE_DATE = 10;
        private const int WORKING_STATUS = 11;
        private const int TERMINATION_DATE = 12;
        private const int GENDER = 13;
        private const int BIRTH_DATE = 14;
        private const int CENTURY = 15;
        private const int TITLE_CODE = 16;
        private const int KIND_OF_STAFF = 17;
        private const int SHIFT_NO = 18;
        private const int KIND_OF_OT = 19;
        private const int TERMINATION_REASON = 20;
        private const int RACE = 21;
        private const int NATIONALITY = 22;
        private const int RELIGION = 23;
        private const int ID_CARD_NO = 24;
        private const int ID_CARD_EXPIRE_DATE = 25;
        private const int SOCIAL_SECURITY_NO = 26;
        private const int TAX_ID_NO = 27;
        private const int MILITARY_STATUS = 28;
        private const int MARITAL_STATUS = 29;
        private const int BLOOD_GROUP = 30;
        private const int DRIVER_LICENSE_NO = 31;
        private const int DRIVER_LICENSE_EXPIRE_DATE = 32;
        private const int DRIVER_LICENSE_TYPE = 33;
        private const int SS_HOSPITAL_CODE = 34;
        #endregion

        #region Private Variable
        private bool disposed = false;
        private Employee objEmployee;
        private PositionDB dbPosition;
        private SectionDB dbSection;
        private DepartmentDB dbDepartment;
        private WorkingStatusDB dbWorkingStatus;
        private TitleDB dbTitle;
        private KindOfStaffDB dbKindOfStaff;
        private MilitaryStatusDB dbMilitaryStatus;
        private MaritalStatusDB dbMaritalStatus;
        private SSHospitalDB _dbSSHospital;
        #endregion

        #region Constructor
        public EmployeeDB()
            : base()
        {
            dbPosition = new PositionDB();
            dbSection = new SectionDB();
            dbWorkingStatus = new WorkingStatusDB();
            dbTitle = new TitleDB();
            dbKindOfStaff = new KindOfStaffDB();
            dbDepartment = new DepartmentDB();
            dbMaritalStatus = new MaritalStatusDB();
            dbMilitaryStatus = new MilitaryStatusDB();
            _dbSSHospital = new SSHospitalDB();
        }
        #endregion

        #region Private Method

        #region - getSQL -
        private string getSQLSelectEmployee()
        {
            return " SELECT Employee_No, Department_Code, Section_Code, Thai_Prefix, Thai_Name, Thai_Surname, English_Prefix, English_Name, English_Surname, Position_Code, Hire_Date, Working_Status, Termination_Date, Gender, Birth_Date FROM Employee ";
        }

        private string getSQLSelectEmployeeInfo()
        {
            return " SELECT Employee_No, Department_Code, Section_Code, Thai_Prefix, Thai_Name, Thai_Surname, English_Prefix, English_Name, English_Surname, Position_Code, Hire_Date, Working_Status, Termination_Date, Gender, Birth_Date, Century, Title_Code, Kind_Of_Staff, Shift_No, Kind_Of_OT, Termination_Reason, Race, Nationality, Religion, ID_Card_No, ID_Card_Expire_Date, Social_Security_No, Tax_ID_No, Military_Status, Marital_Status, Blood_Group, Driver_License_No, Driver_License_Expire_Date, Driver_License_Type, SS_Hospital_Code, PF_From_Date, PF_To_Date FROM Employee ";
        }

        private string getSQLInsert(EmployeeInfo value)
        {
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee (Company_Code, Employee_No, Department_Code, Section_Code, Century, Thai_Prefix, Thai_Name, Thai_Surname, English_Prefix, English_Name, English_Surname, Position_Code, Title_Code, Kind_Of_Staff, Shift_No, Kind_Of_OT, Hire_Date, Working_Status, Termination_Date, Termination_Reason, Gender, Birth_Date, Race, Nationality, Religion, ID_Card_No, ID_Card_Expire_Date, Social_Security_No, Tax_ID_No, Military_Status, Marital_Status, Blood_Group, Driver_License_No, Driver_License_Expire_Date, Driver_License_Type, Process_Date, Process_User, SS_Hospital_Code, PF_From_Date, PF_To_Date) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(value.Company.CompanyCode));
            stringBuilder.Append(", ");

            //Employee_No
            stringBuilder.Append(GetDB(value.EmployeeNo));
            stringBuilder.Append(", ");

            //Department_Code
            stringBuilder.Append(GetDB(value.ASection.ADepartment.Code));
            stringBuilder.Append(", ");

            //Section_Code
            stringBuilder.Append(GetDB(value.ASection.Code));
            stringBuilder.Append(", ");

            //Century
            stringBuilder.Append(GetDB(value.Century));
            stringBuilder.Append(", ");

            //Thai_Prefix
            stringBuilder.Append(GetDB(value.APrefix.Thai));
            stringBuilder.Append(", ");

            //Thai_Name
            stringBuilder.Append(GetDB(value.AName.Thai));
            stringBuilder.Append(", ");

            //Thai_Surname
            stringBuilder.Append(GetDB(value.ASurname.Thai));
            stringBuilder.Append(", ");

            //English_Prefix
            stringBuilder.Append(GetDB(value.APrefix.English));
            stringBuilder.Append(", ");

            //English_Name
            stringBuilder.Append(GetDB(value.AName.English));
            stringBuilder.Append(", ");

            //English_Surname
            stringBuilder.Append(GetDB(value.ASurname.English));
            stringBuilder.Append(", ");

            //Position_Code
            stringBuilder.Append(GetDB(value.APosition.PositionCode));
            stringBuilder.Append(", ");

            //Title_Code
            stringBuilder.Append(GetDB(value.ATitle.Code));
            stringBuilder.Append(", ");

            //Kind_Of_Staff
            stringBuilder.Append(GetDB(value.AKindOfStaff.Code));
            stringBuilder.Append(", ");

            //Shift_No
            stringBuilder.Append(GetDB(value.ShiftNo));
            stringBuilder.Append(", ");

            //Kind_Of_OT
            stringBuilder.Append(GetDB(value.KindOfOT));
            stringBuilder.Append(", ");

            //Hire_Date
            stringBuilder.Append(GetDB(value.HireDate));
            stringBuilder.Append(", ");

            //Working_Status
            stringBuilder.Append(GetDB(value.AWorkingStatus.Code));
            stringBuilder.Append(", ");

            //Termination_Date
            stringBuilder.Append(GetDB(value.TerminationDate));
            stringBuilder.Append(", ");

            //Termination_Reason
            stringBuilder.Append(GetDB(value.TerminationReason));
            stringBuilder.Append(", ");

            //Gender
            stringBuilder.Append(GetDB(value.Gender));
            stringBuilder.Append(", ");

            //Birth_Date
            stringBuilder.Append(GetDB(value.BirthDate));
            stringBuilder.Append(", ");

            //Race
            stringBuilder.Append(GetDB(value.Race.Name));
            stringBuilder.Append(", ");

            //Nationality
            stringBuilder.Append(GetDB(value.Nationality.Name));
            stringBuilder.Append(", ");

            //Religion
            stringBuilder.Append(GetDB(value.Religion.Name));
            stringBuilder.Append(", ");

            //ID_Card_No
            stringBuilder.Append(GetDB(value.IdCardNo));
            stringBuilder.Append(", ");

            //ID_Card_Expire_Date
            stringBuilder.Append(GetDB(value.IdCardExpireDate));
            stringBuilder.Append(", ");

            //Social_Security_No
            stringBuilder.Append(GetDB(value.SocialSecurityNo));
            stringBuilder.Append(", ");

            //Tax_ID_No
            stringBuilder.Append(GetDB(value.TaxIDNo));
            stringBuilder.Append(", ");

            //Military_Status
            stringBuilder.Append(GetDB(value.MilitaryStatus.Code));
            stringBuilder.Append(", ");

            //Marital_Status
            stringBuilder.Append(GetDB(value.MaritalStatus.Code));
            stringBuilder.Append(", ");

            //Blood_Group
            stringBuilder.Append(GetDB(value.BloodGrop.Name));
            stringBuilder.Append(", ");

            //Driver_License_No
            stringBuilder.Append(GetDB(value.DriverLicenseNo));
            stringBuilder.Append(", ");

            //Driver_License_Expire_Date
            stringBuilder.Append(GetDB(value.DriverLicenseExpireDate));
            stringBuilder.Append(", ");

            //Driver_License_Type
            stringBuilder.Append(GetDB(value.DriverLicenseType));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(", ");

            //SS_Hospital_Code
            stringBuilder.Append(GetDB(value.SSHospital.Code));
            stringBuilder.Append(", ");

            //PF_From_Date
            if (value.PFFromDate.HasValue)
            {
                stringBuilder.Append(GetDB(value.PFFromDate.Value));
            }
            else
            {
                stringBuilder.Append("NULL");
            }
            stringBuilder.Append(", ");

            //PF_To_Date
            if (value.PFToDate.HasValue)
            {
                stringBuilder.Append(GetDB(value.PFToDate.Value));
            }
            else
            {
                stringBuilder.Append("NULL");
            }
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(EmployeeInfo value)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Employee SET ");
            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(value.Company.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Employee_No = ");
            stringBuilder.Append(GetDB(value.EmployeeNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Department_Code = ");
            stringBuilder.Append(GetDB(value.ASection.ADepartment.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Section_Code = ");
            stringBuilder.Append(GetDB(value.ASection.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Century = ");
            stringBuilder.Append(GetDB(value.Century));
            stringBuilder.Append(", ");

            stringBuilder.Append("Thai_Prefix = ");
            stringBuilder.Append(GetDB(value.APrefix.Thai));
            stringBuilder.Append(", ");

            stringBuilder.Append("Thai_Name = ");
            stringBuilder.Append(GetDB(value.AName.Thai));
            stringBuilder.Append(", ");

            stringBuilder.Append("Thai_Surname = ");
            stringBuilder.Append(GetDB(value.ASurname.Thai));
            stringBuilder.Append(", ");

            stringBuilder.Append("English_Prefix = ");
            stringBuilder.Append(GetDB(value.APrefix.English));
            stringBuilder.Append(", ");

            stringBuilder.Append("English_Name = ");
            stringBuilder.Append(GetDB(value.AName.English));
            stringBuilder.Append(", ");

            stringBuilder.Append("English_Surname = ");
            stringBuilder.Append(GetDB(value.ASurname.English));
            stringBuilder.Append(", ");

            stringBuilder.Append("Position_Code = ");
            stringBuilder.Append(GetDB(value.APosition.PositionCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Title_Code = ");
            stringBuilder.Append(GetDB(value.ATitle.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Kind_Of_Staff = ");
            stringBuilder.Append(GetDB(value.AKindOfStaff.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Shift_No = ");
            stringBuilder.Append(GetDB(value.ShiftNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Kind_Of_OT = ");
            stringBuilder.Append(GetDB(value.KindOfOT));
            stringBuilder.Append(", ");

            stringBuilder.Append("Hire_Date = ");
            stringBuilder.Append(GetDB(value.HireDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Working_Status = ");
            stringBuilder.Append(GetDB(value.AWorkingStatus.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Termination_Date = ");
            stringBuilder.Append(GetDB(value.TerminationDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Termination_Reason = ");
            stringBuilder.Append(GetDB(value.TerminationReason));
            stringBuilder.Append(", ");

            stringBuilder.Append("Gender = ");
            stringBuilder.Append(GetDB(value.Gender));
            stringBuilder.Append(", ");

            stringBuilder.Append("Birth_Date = ");
            stringBuilder.Append(GetDB(value.BirthDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Race = ");
            stringBuilder.Append(GetDB(value.Race.Name));
            stringBuilder.Append(", ");

            stringBuilder.Append("Nationality = ");
            stringBuilder.Append(GetDB(value.Nationality.Name));
            stringBuilder.Append(", ");

            stringBuilder.Append("Religion = ");
            stringBuilder.Append(GetDB(value.Religion.Name));
            stringBuilder.Append(", ");

            stringBuilder.Append("ID_Card_No = ");
            stringBuilder.Append(GetDB(value.IdCardNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("ID_Card_Expire_Date = ");
            stringBuilder.Append(GetDB(value.IdCardExpireDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Social_Security_No = ");
            stringBuilder.Append(GetDB(value.SocialSecurityNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Tax_ID_No = ");
            stringBuilder.Append(GetDB(value.TaxIDNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Military_Status = ");
            stringBuilder.Append(GetDB(value.MilitaryStatus.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Marital_Status = ");
            stringBuilder.Append(GetDB(value.MaritalStatus.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Blood_Group = ");
            stringBuilder.Append(GetDB(value.BloodGrop.Name));
            stringBuilder.Append(", ");

            stringBuilder.Append("Driver_License_No = ");
            stringBuilder.Append(GetDB(value.DriverLicenseNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Driver_License_Expire_Date = ");
            stringBuilder.Append(GetDB(value.DriverLicenseExpireDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Driver_License_Type = ");
            stringBuilder.Append(GetDB(value.DriverLicenseType));
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_Date = ");
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_User = ");
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(", ");

            stringBuilder.Append("SS_Hospital_Code = ");
            stringBuilder.Append(GetDB(value.SSHospital.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("PF_From_Date = ");
            if (value.PFFromDate.HasValue)
            {
                stringBuilder.Append(GetDB(value.PFFromDate.Value));
            }
            else
            {
                stringBuilder.Append("NULL");
            }
            stringBuilder.Append(", ");

            stringBuilder.Append("PF_To_Date = ");
            if (value.PFToDate.HasValue)
            {
                stringBuilder.Append(GetDB(value.PFToDate.Value));
            }
            else
            {
                stringBuilder.Append("NULL");
            }

            return stringBuilder.ToString();
        }

        private string getSQLDelete()
        {
            return " DELETE FROM Employee ";
        }

        private string getKeyCondition(Employee value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if ((value != null) && (IsNotNULL(value.EmployeeNo)))
            {
                stringBuilder.Append(" AND (Employee_No = ");
                stringBuilder.Append(GetDB(value.EmployeeNo));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getEntityCondition(Position aPosition)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(aPosition.PositionCode))
            {
                stringBuilder.Append(" AND (Position_Code = ");
                stringBuilder.Append(GetDB(aPosition.PositionCode));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getEmployeeNotAvailable()
        {
            return " AND ((Working_Status IN ('06', '07', '08', '10')) AND (Termination_Date <= GETDATE())) ";
        }

        private string getEmployeeAvailable()
        {
            return " AND ((Working_Status NOT IN ('06', '07', '08', '10')) OR (Termination_Date > GETDATE())) ";
        }

        private string getEmployeeNotAvailable(DateTime dateTime)
        {
            return " AND ((Working_Status IN ('06', '07', '08', '10')) AND (Termination_Date <= " + GetDB(dateTime) + " )) ";
        }

        private string getEmployeeAvailable(DateTime dateTime)
        {
            return " AND ((Working_Status NOT IN ('06', '07', '08', '10')) OR (Termination_Date > " + GetDB(dateTime) + " )) ";
        }

        private string getEmployeeAvailableForNonPayroll(DateTime dateTime)
        {
            return " AND (Working_Status IN ('01')) "
                + " AND ((Termination_Date IS NULL) "
                + " OR "
                + " ((YEAR(Termination_Date) > YEAR(" + GetDB(dateTime) + ")) "
                + "     OR ((MONTH(Termination_Date) > MONTH(" + GetDB(dateTime) + ")) "
                + "         AND (YEAR(Termination_Date) = YEAR(" + GetDB(dateTime) + ")) "
                + "         ) "
                + "  ) "
                + " ) "
                + " AND (Hire_Date < DATEADD(month,DATEDIFF(month, 0, " + GetDB(dateTime) + "), 0)) "
                + " AND (Position_Code IN ('27', '28')) ";
        }

        private string getEmployeeAvailableForAdditionalNonPayroll(DateTime dateTime)
        {
            return " AND (Working_Status IN ('01')) ";
            // + " AND (Position_Code IN ('27', '28')) ";
        }

        private string getOrderby()
        {
            return " ORDER BY Century, Employee_No";
        }

        private string getOrderbyEmployeeNo()
        {
            return " ORDER BY Employee_No";
        }

        private string getVExportEmployeeprofile()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("SELECT * ");
            stringBuilder.Append("FROM VExportEmployeeprofile ");

            return stringBuilder.ToString();
        }

        private string getVExportUpdateEmployeeprofile()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("SELECT * ");
            stringBuilder.Append("FROM VExportUpdateEmployeeprofile ");

            return stringBuilder.ToString();
        }

        private string getVExportResignEmployeeprofile()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("SELECT * ");
            stringBuilder.Append("FROM VExportResignEmployeeprofile ");

            return stringBuilder.ToString();
        }
        #endregion

        #region - Fill -
        private void fillEmployeeInfo(EmployeeInfo value, SqlDataReader dataReader)
        {
            fillEmployeeDB(value, dataReader);

            value.ATitle = dbTitle.GetDBTitle((string)dataReader[TITLE_CODE], value.Company);
            value.AKindOfStaff = (KindOfStaff)dbKindOfStaff.GetDBDualField((string)dataReader[KIND_OF_STAFF], value.Company);
            value.ShiftNo = CTFunction.GetShiftType((string)dataReader[SHIFT_NO]);
            value.KindOfOT = CTFunction.GetKindOfOTType((string)dataReader[KIND_OF_OT]);
            value.TerminationReason = (string)dataReader[TERMINATION_REASON];
            value.Race.Name = (string)dataReader[RACE];
            value.Nationality.Name = (string)dataReader[NATIONALITY];
            value.Religion.Name = (string)dataReader[RELIGION];
            value.IdCardNo = (string)dataReader[ID_CARD_NO];
            value.IdCardExpireDate = dataReader.GetDateTime(ID_CARD_EXPIRE_DATE);
            value.SocialSecurityNo = (string)dataReader[SOCIAL_SECURITY_NO];
            value.TaxIDNo = (string)dataReader[TAX_ID_NO];
            value.MilitaryStatus = (MilitaryStatus)dbMilitaryStatus.GetMTB((string)dataReader[MILITARY_STATUS]);
            value.MaritalStatus = (MaritalStatus)dbMaritalStatus.GetMTB((string)dataReader[MARITAL_STATUS]);
            value.BloodGrop.Name = (string)dataReader[BLOOD_GROUP];
            value.DriverLicenseNo = (string)dataReader[DRIVER_LICENSE_NO];

            if (dataReader.IsDBNull(DRIVER_LICENSE_EXPIRE_DATE))
            {
                value.DriverLicenseExpireDate = NullConstant.DATETIME;
            }
            else
            {
                value.DriverLicenseExpireDate = dataReader.GetDateTime(DRIVER_LICENSE_EXPIRE_DATE);
            }

            value.DriverLicenseType = CTFunction.GetDriverLicenceType((string)dataReader[DRIVER_LICENSE_TYPE]);

            if (dataReader.IsDBNull(SS_HOSPITAL_CODE))
            {
                value.SSHospital = null;
            }
            else
            {
                value.SSHospital = (SSHospital)_dbSSHospital.GetMTB((string)dataReader[SS_HOSPITAL_CODE]);
            }

            if (dataReader["PF_From_Date"] != DBNull.Value)
            {
                value.PFFromDate = (DateTime)dataReader["PF_From_Date"];
            }
            else
            {
                value.PFFromDate = null;
            }

            if (dataReader["PF_To_Date"] != DBNull.Value)
            {
                value.PFToDate = (DateTime)dataReader["PF_To_Date"];
            }
            else
            {
                value.PFToDate = null;
            }
        }

        private void fillEmployee(Employee value, SqlDataReader dataReader)
        {
            value.EmployeeNo = (string)dataReader[EMPLOYEE_NO];
            value.APrefix.Thai = (string)dataReader[THAI_PREFIX];
            value.AName.Thai = (string)dataReader[THAI_NAME];
            value.ASurname.Thai = (string)dataReader[THAI_SURNAME];
            value.APrefix.English = (string)dataReader[ENGLISH_PREFIX];
            value.AName.English = (string)dataReader[ENGLISH_NAME];
            value.ASurname.English = (string)dataReader[ENGLISH_SURNAME];
            value.HireDate = dataReader.GetDateTime(HIRE_DATE);

            if (dataReader.IsDBNull(TERMINATION_DATE))
            {
                value.TerminationDate = NullConstant.DATETIME;
            }
            else
            {
                value.TerminationDate = dataReader.GetDateTime(TERMINATION_DATE);
            }

            value.Gender = CTFunction.GetGenderType((string)dataReader[GENDER]);
            value.BirthDate = dataReader.GetDateTime(BIRTH_DATE);
        }

        private void fillEmployeeDB(Employee value, SqlDataReader dataReader)
        {
            fillEmployee(value, dataReader);
            value.ASection = dbSection.GetDBSection((string)dataReader[SECTION_CODE], value.Company);
            value.APosition = dbPosition.GetDBPosition((string)dataReader[POSITION_CODE], value.Company);
            value.AWorkingStatus = (WorkingStatus)dbWorkingStatus.GetDBDualField((string)dataReader[WORKING_STATUS], value.Company);
        }

        private bool fillEmployeeInfo(ref EmployeeInfo value, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillEmployeeInfo(value, dataReader);
                    result = true;
                }
                else
                {
                    throw new EmpNotFoundException(value.EmployeeNo);
                }
            }
            catch (IndexOutOfRangeException ein)
            {
                throw ein;
            }
            finally
            {
                tableAccess.CloseDataReader();

                dataReader = null;
            }
            return result;
        }

        private bool fillEmployee(ref Employee value, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillEmployeeDB(value, dataReader);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (IndexOutOfRangeException ein)
            {
                throw ein;
            }
            finally
            {
                tableAccess.CloseDataReader();

                dataReader = null;
            }
            return result;
        }

        private bool fillEmployeeList(ref EmployeeList value, string sql)
        {
            bool result = false;
            SectionList sectionList = new SectionList(value.Company);
            dbSection.FillSectionList(ref sectionList);
            PositionList positionList = new PositionList(value.Company);
            dbPosition.FillPositionList(ref positionList);
            WorkingStatusList workingStatusList = new WorkingStatusList(value.Company);
            dbWorkingStatus.FillMTBList(workingStatusList);

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);

            try
            {
                while (dataReader.Read())
                {
                    result = true;

                    objEmployee = new Employee(value.Company);
                    objEmployee.ASection = sectionList[(string)dataReader[SECTION_CODE]];
                    objEmployee.APosition = positionList[(string)dataReader[POSITION_CODE]];
                    objEmployee.AWorkingStatus = workingStatusList[(string)dataReader[WORKING_STATUS]];
                    fillEmployee(objEmployee, dataReader);
                    value.Add(objEmployee);
                }
            }
            catch (IndexOutOfRangeException ein)
            {
                throw ein;
            }
            finally
            {
                tableAccess.CloseDataReader();

                dataReader = null;
                sectionList = null;
                positionList = null;
                workingStatusList = null;
            }
            return result;
        }

        private bool fillEmployeeList(EmployeeList value, string sql)
        {
            bool result = false;
            SectionList sectionList = new SectionList(value.Company);
            dbSection.FillSectionList(ref sectionList);
            PositionList positionList = new PositionList(value.Company);
            dbPosition.FillPositionList(ref positionList);
            WorkingStatusList workingStatusList = new WorkingStatusList(value.Company);
            dbWorkingStatus.FillMTBList(workingStatusList);

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);

            try
            {
                while (dataReader.Read())
                {
                    result = true;

                    objEmployee = new Employee(value.Company);
                    objEmployee.ASection = sectionList[(string)dataReader[SECTION_CODE]];
                    objEmployee.APosition = positionList[(string)dataReader[POSITION_CODE]];
                    objEmployee.AWorkingStatus = workingStatusList[(string)dataReader[WORKING_STATUS]];
                    fillEmployee(objEmployee, dataReader);
                    value.Add(objEmployee);
                }
            }
            catch (IndexOutOfRangeException ein)
            {
                throw ein;
            }
            finally
            {
                tableAccess.CloseDataReader();

                dataReader = null;
                sectionList = null;
                positionList = null;
                workingStatusList = null;
            }
            return result;
        }

        private void nullEmpNotFoundException(EmpNotFoundException ex)
        {
            ex = null;
        }

        private void UpdateSingleField(EmployeeInfo value)
        {
            PrefixDB dbPrefix = new PrefixDB();
            Prefix prefix = new Prefix();
            prefix.Name = value.APrefix.Thai;
            dbPrefix.UpdateMTB(prefix);

            prefix = new Prefix();
            prefix.Name = value.APrefix.English;
            dbPrefix.UpdateMTB(prefix);

            prefix = null;
            dbPrefix = null;


            NationalityDB dbNationality = new NationalityDB();
            dbNationality.UpdateMTB(value.Nationality);

            RaceDB dbRace = new RaceDB();
            dbRace.UpdateMTB(value.Race);

            ReligionDB dbReligion = new ReligionDB();
            dbReligion.UpdateMTB(value.Religion);

            BloodGroupDB dbBloodGroup = new BloodGroupDB();
            dbBloodGroup.UpdateMTB(value.BloodGrop);

        }
        #endregion

        #endregion

        #region Public Method
        public Employee GetAvailableEmployee(string employeeNo, DateTime effectiveDate, Company aCompany)
        {
            objEmployee = new Employee(employeeNo, aCompany);
            if (FillAvailableEmployee(objEmployee, effectiveDate))
            { return objEmployee; }
            else
            {
                objEmployee = null;
                return null;
            }
        }

        public Employee GetAllEmployee(string employeeNo, Company value)
        {
            objEmployee = new Employee(employeeNo, value);
            if (FillAllEmployee(ref objEmployee))
            { return objEmployee; }
            else
            {
                objEmployee = null;
                return null;
            }
        }

        public EmployeeInfo GetAllEmployeeInfo(string employeeNo, Company value)
        {
            EmployeeInfo objEmployeeInfo = new EmployeeInfo(employeeNo, value);
            if (FillAllEmployeeInfo(ref objEmployeeInfo))
            { return objEmployeeInfo; }
            else
            {
                objEmployeeInfo = null;
                return null;
            }
        }

        public Employee GetFormerlyEmployee(string employeeNo, Company company)
        {
            FormerEmployeeDB formerEmployeeDB;
            Employee employee = new Employee(employeeNo, company);
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployee());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(employee));
            try
            {
                if (!fillEmployee(ref employee, stringBuilder.ToString()))
                {
                    formerEmployeeDB = new FormerEmployeeDB();
                    formerEmployeeDB.FillFormerEmployee(ref employee);
                }
            }
            catch (EmpNotFoundException ex)
            {
                formerEmployeeDB = new FormerEmployeeDB();
                try
                {
                    formerEmployeeDB.FillFormerEmployee(ref employee);
                    nullEmpNotFoundException(ex);
                }
                catch (EmpNotFoundException exFormer)
                {
                    throw exFormer;
                }
            }
            formerEmployeeDB = null;
            stringBuilder = null;
            return employee;
        }

        public bool FillAvailableEmployee(Employee value, DateTime effectiveDate)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployee());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value));
            stringBuilder.Append(getEmployeeAvailable(effectiveDate));
            return fillEmployee(ref value, stringBuilder.ToString());
        }

        public bool FillAllEmployee(ref Employee value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployee());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value));
            return fillEmployee(ref value, stringBuilder.ToString());
        }

        public bool FillAllEmployeeInfo(ref EmployeeInfo value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployeeInfo());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value));
            return fillEmployeeInfo(ref value, stringBuilder.ToString());
        }

        public bool FillAvailableEmployeeList(ref EmployeeList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployee());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getEmployeeAvailable());
            stringBuilder.Append(getOrderby());
            return fillEmployeeList(ref value, stringBuilder.ToString());
        }

        public bool FillAllEmployeeList(EmployeeList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployee());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getOrderby());
            return fillEmployeeList(value, stringBuilder.ToString());
        }

        public bool FillAvailableEmployeeList(EmployeeList value, DateTime effectiveDate)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployee());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getEmployeeAvailable(effectiveDate));
            stringBuilder.Append(getOrderby());
            return fillEmployeeList(ref value, stringBuilder.ToString());
        }

        public bool FillAllEmployeeList(ref EmployeeList value, Employee aEmployee)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployee());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(aEmployee));
            stringBuilder.Append(getEntityCondition(aEmployee.APosition));
            stringBuilder.Append(getOrderby());

            return fillEmployeeList(ref value, stringBuilder.ToString());
        }

        public bool FillAvailableEmployeeList(ref EmployeeList value, Employee aEmployee)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployee());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(aEmployee));
            stringBuilder.Append(getEntityCondition(aEmployee.APosition));
            stringBuilder.Append(getEmployeeAvailable());
            stringBuilder.Append(getOrderby());

            return fillEmployeeList(ref value, stringBuilder.ToString());
        }

        public bool FillEmployeeNotAvailableList(ref EmployeeList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployee());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getEmployeeNotAvailable());
            stringBuilder.Append(getOrderby());

            return fillEmployeeList(ref value, stringBuilder.ToString());
        }

        public bool InsertEmployee(EmployeeInfo value)
        {
            if (tableAccess.ExecuteSQL(getSQLInsert(value)) > 0)
            {
                UpdateSingleField(value);
                return true;
            }
            else
            { return false; }
        }

        public bool UpdateEmployee(EmployeeInfo value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value));
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            {
                UpdateSingleField(value);
                return true;
            }
            else
            { return false; }
        }

        public bool DeleteEmployee(Employee value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool FillAvailableEmployeeListForNonPayroll(ref EmployeeList value, DateTime effectiveDate)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployee());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getEmployeeAvailableForNonPayroll(effectiveDate));
            stringBuilder.Append(getOrderbyEmployeeNo());
            return fillEmployeeList(ref value, stringBuilder.ToString());
        }

        public bool FillAvailableEmployeeListForAdditionalNonPayroll(ref EmployeeList value, DateTime effectiveDate)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployee());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getEmployeeAvailableForAdditionalNonPayroll(effectiveDate));
            stringBuilder.Append(getOrderbyEmployeeNo());
            return fillEmployeeList(ref value, stringBuilder.ToString());
        }

        // 10/10/2019 Kringkrai A.
        private DataTable FillVExportEmployeeprofile(string sql)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable exportData = new DataTable();
            SqlDataReader dataReader;
            DataTable DT = new DataTable();

            try
            {
                dataReader = tableAccess.ExecuteDataReader(sql);

                ds.EnforceConstraints = false;

                DataTable DTSchema = dataReader.GetSchemaTable();

                if (DTSchema != null)
                {
                    if (DTSchema.Rows.Count > 0)
                    {
                        for (int i = 0; i < DTSchema.Rows.Count; i++)
                        {
                            //Create new column for each row in schema table
                            //Set properties that are causing errors and add it to our datatable
                            //Rows in schema table are filled with information of columns in our actual table
                            DataColumn Col = new DataColumn(DTSchema.Rows[i]["ColumnName"].ToString(), (Type)DTSchema.Rows[i]["DataType"]);
                            Col.AllowDBNull = true;
                            Col.Unique = false;
                            Col.AutoIncrement = false;
                            DT.Columns.Add(Col);
                        }
                    }
                }

                while (dataReader.Read())
                {
                    //Read data and fill it to our datatable
                    DataRow Row = DT.NewRow();
                    for (int i = 0; i < DT.Columns.Count; i++)
                    {
                        Row[i] = dataReader[i];
                    }
                    DT.Rows.Add(Row);
                }
                
                

                // Set DataTable Data Type
                //exportData = dataReader.GetSchemaTable();

                //exportData.Load(dataReader);
            }
            catch (IndexOutOfRangeException ein)
            {
                throw ein;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tableAccess.CloseDataReader();

                dataReader = null;
            }

            //return exportData;
            return DT;
        }

        public DataTable FillNewEmployeeToExport(DateTime dateFrom, DateTime dateTo)
        {
            StringBuilder stringBuilder = new StringBuilder(getVExportEmployeeprofile());

            stringBuilder.Append("WHERE Hire_Date >= " + GetDB(dateFrom) + "AND Hire_Date <= " + GetDB(dateTo));

            return FillVExportEmployeeprofile(stringBuilder.ToString());
        }

        public DataTable FillUpdateEmployeeToExport(DateTime dateFrom, DateTime dateTo)
        {
            StringBuilder stringBuilder = new StringBuilder(getVExportUpdateEmployeeprofile());

            stringBuilder.Append("WHERE Process_Date >= " + GetDB(dateFrom) + "AND Process_Date <= " + GetDB(dateTo));

            return FillVExportEmployeeprofile(stringBuilder.ToString());
        }

        public DataTable FillResignEmployeeToExport(DateTime dateFrom, DateTime dateTo)
        {
            StringBuilder stringBuilder = new StringBuilder(getVExportResignEmployeeprofile());

            stringBuilder.Append("WHERE Termination_Date >= " + GetDB(dateFrom) + "AND Termination_Date <= " + GetDB(dateTo));

            return FillVExportEmployeeprofile(stringBuilder.ToString());
        }

        #endregion

        #region IDisposable Members
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                try
                {
                    if (disposing)
                    {
                        dbPosition.Dispose();

                        dbPosition = null;
                        objEmployee = null;
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

        #region for newEmplist
        //		public bool FillAllEmpList(EmployeeList value, Employee condition)
        //		{
        //			bool result = false;
        //			StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployeeInfo());
        //			stringBuilder.Append(getBaseCondition(value.Company));
        //			stringBuilder.Append(getOrderby());
        //
        //			SqlDataReader dataReader;
        //			Employee employee;
        //			SectionList sectionList = new SectionList(value.Company);
        //			dbSection.FillSectionList(ref sectionList);
        //			PositionList positionList = new PositionList(value.Company);
        //			dbPosition.FillPositionList(ref positionList);
        //			TitleList titleList = new TitleList(value.Company);
        //			dbTitle.FillTitleData(ref titleList);
        //			KindOfStaffList kindOfStaffList = new KindOfStaffList(value.Company);
        //			dbKindOfStaff.FillMTBList(kindOfStaffList);
        //			WorkingStatusList workingStatusList = new WorkingStatusList(value.Company);
        //			dbWorkingStatus.FillMTBList(workingStatusList);
        //			MilitaryStatusList militaryStatusList = new MilitaryStatusList();
        //			dbMilitaryStatus.FillMTBList(militaryStatusList);
        //			MaritalStatusList maritalStatusList = new MaritalStatusList();
        //			dbMaritalStatus.FillMTBList(maritalStatusList);
        //
        //			try
        //			{
        //				dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
        //				while (dataReader.Read())
        //				{
        //					result = true;
        //					employee = new Employee(value.Company);
        //					employee.EmployeeNo = (string)dataReader[EMPLOYEE_NO];
        //					employee.ASection = sectionList[(string)dataReader[SECTION_CODE]];
        //					//				employee.Century = dataReader.GetByte(CENTURY);
        //					employee.APrefix.Thai = (string)dataReader[THAI_PREFIX];
        //					employee.AName.Thai = (string)dataReader[THAI_NAME];
        //					employee.ASurname.Thai = (string)dataReader[THAI_SURNAME];
        //					employee.APrefix.English = (string)dataReader[ENGLISH_PREFIX];
        //					employee.AName.English = (string)dataReader[ENGLISH_NAME];
        //					employee.ASurname.English = (string)dataReader[ENGLISH_SURNAME];
        //					employee.APosition = positionList[(string)dataReader[POSITION_CODE]];
        ////					employee.ATitle = titleList[(string)dataReader[TITLE_CODE]];
        ////					employee.AKindOfStaff = kindOfStaffList[(string)dataReader[KIND_OF_STAFF]];
        ////					employee.ShiftNo = CTFunction.GetShiftType((string)dataReader[SHIFT_NO]);
        ////					employee.KindOfOT = CTFunction.GetKindOfOTType((string)dataReader[KIND_OF_OT]);
        //					employee.HireDate = dataReader.GetDateTime(HIRE_DATE);
        //					employee.AWorkingStatus = workingStatusList[(string)dataReader[WORKING_STATUS]];
        //					if(!dataReader.IsDBNull(TERMINATION_DATE))
        //					{
        //						employee.TerminationDate = dataReader.GetDateTime(TERMINATION_DATE);
        //					}
        ////					employee.TerminationReason = (string)dataReader[TERMINATION_REASON];
        //					employee.Gender = CTFunction.GetGenderType((string)dataReader[GENDER]);
        //					employee.BirthDate = dataReader.GetDateTime(BIRTH_DATE);
        ////					employee.Race.Name = (string)dataReader[RACE];
        ////					employee.Nationality.Name = (string)dataReader[NATIONALITY];
        ////					employee.Religion.Name = (string)dataReader[RELIGION];
        ////					employee.IdCardExpireDate = dataReader.GetDateTime(ID_CARD_EXPIRE_DATE);
        ////					employee.IdCardNo = (string)dataReader[ID_CARD_NO];
        ////					employee.SocialSecurityNo = (string)dataReader[SOCIAL_SECURITY_NO];
        ////					employee.TaxIDNo = (string)dataReader[TAX_ID_NO];
        ////					employee.MilitaryStatus = militaryStatusList[(string)dataReader[MILITARY_STATUS]];
        ////					employee.MaritalStatus = maritalStatusList[(string)dataReader[MARITAL_STATUS]];
        ////					employee.BloodGrop.Name = (string)dataReader[BLOOD_GROUP];
        ////					employee.DriverLicenseNo = (string)dataReader[DRIVER_LICENSE_NO];
        ////					if(!dataReader.IsDBNull(DRIVER_LICENSE_EXPIRE_DATE))
        ////					{
        ////						employee.DriverLicenseExpireDate = dataReader.GetDateTime(DRIVER_LICENSE_EXPIRE_DATE);
        ////					}
        ////					employee.DriverLicenseType = CTFunction.GetDriverLicenceType((string)dataReader[DRIVER_LICENSE_TYPE]);
        //					value.Add(employee);
        //				}
        //			}
        //			catch (IndexOutOfRangeException ein)
        //			{
        //				throw ein;
        //			}
        //			finally
        //			{
        //				tableAccess.CloseDataReader();
        //				dataReader = null;
        //
        //				employee = null;
        //				sectionList = null;
        //				positionList = null;
        //				titleList = null;
        //				kindOfStaffList = null;
        //				workingStatusList = null;
        //				militaryStatusList = null;
        //				maritalStatusList = null;
        //				stringBuilder = null;
        //			}
        //			return result;
        //		}

        //		public bool FillEmpList(EmployeeList value, Employee condition)
        //		{
        //			bool result = false;
        //			StringBuilder stringBuilder = new StringBuilder(getSQLSelectEmployeeInfo());
        //			stringBuilder.Append(getBaseCondition(value.Company));
        //			stringBuilder.Append(getEmployeeAvailable());
        //			stringBuilder.Append(getOrderby());
        //
        //			SqlDataReader dataReader;
        //			Employee employee;
        //			SectionList sectionList = new SectionList(value.Company);
        //			dbSection.FillSectionList(ref sectionList);
        //			PositionList positionList = new PositionList(value.Company);
        //			dbPosition.FillPositionList(ref positionList);
        //			TitleList titleList = new TitleList(value.Company);
        //			dbTitle.FillTitleData(ref titleList);
        //			KindOfStaffList kindOfStaffList = new KindOfStaffList(value.Company);
        //			dbKindOfStaff.FillMTBList(kindOfStaffList);
        //			WorkingStatusList workingStatusList = new WorkingStatusList(value.Company);
        //			dbWorkingStatus.FillMTBList(workingStatusList);
        //			MilitaryStatusList militaryStatusList = new MilitaryStatusList();
        //			dbMilitaryStatus.FillMTBList(militaryStatusList);
        //			MaritalStatusList maritalStatusList = new MaritalStatusList();
        //			dbMaritalStatus.FillMTBList(maritalStatusList);
        //
        //			try
        //			{
        //				dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
        //				while (dataReader.Read())
        //				{
        //					result = true;
        //					employee = new Employee(value.Company);
        //					employee.EmployeeNo = (string)dataReader[EMPLOYEE_NO];
        //					employee.ASection = sectionList[(string)dataReader[SECTION_CODE]];
        //					employee.APrefix.Thai = (string)dataReader[THAI_PREFIX];
        //					employee.AName.Thai = (string)dataReader[THAI_NAME];
        //					employee.ASurname.Thai = (string)dataReader[THAI_SURNAME];
        //					employee.APrefix.English = (string)dataReader[ENGLISH_PREFIX];
        //					employee.AName.English = (string)dataReader[ENGLISH_NAME];
        //					employee.ASurname.English = (string)dataReader[ENGLISH_SURNAME];
        //					employee.APosition = positionList[(string)dataReader[POSITION_CODE]];
        ////					employee.ATitle = titleList[(string)dataReader[TITLE_CODE]];
        ////					employee.AKindOfStaff = kindOfStaffList[(string)dataReader[KIND_OF_STAFF]];
        ////					employee.ShiftNo = CTFunction.GetShiftType((string)dataReader[SHIFT_NO]);
        ////					employee.KindOfOT = CTFunction.GetKindOfOTType((string)dataReader[KIND_OF_OT]);
        //					employee.HireDate = dataReader.GetDateTime(HIRE_DATE);
        //					employee.AWorkingStatus = workingStatusList[(string)dataReader[WORKING_STATUS]];
        //					if(!dataReader.IsDBNull(TERMINATION_DATE))
        //					{
        //						employee.TerminationDate = dataReader.GetDateTime(TERMINATION_DATE);
        //					}
        ////					employee.TerminationReason = (string)dataReader[TERMINATION_REASON];
        //					employee.Gender = CTFunction.GetGenderType((string)dataReader[GENDER]);
        //					employee.BirthDate = dataReader.GetDateTime(BIRTH_DATE);
        ////					employee.Race.Name = (string)dataReader[RACE];
        ////					employee.Nationality.Name = (string)dataReader[NATIONALITY];
        ////					employee.Religion.Name = (string)dataReader[RELIGION];
        ////					employee.IdCardExpireDate = dataReader.GetDateTime(ID_CARD_EXPIRE_DATE);
        ////					employee.IdCardNo = (string)dataReader[ID_CARD_NO];
        ////					employee.SocialSecurityNo = (string)dataReader[SOCIAL_SECURITY_NO];
        ////					employee.TaxIDNo = (string)dataReader[TAX_ID_NO];
        ////					employee.MilitaryStatus = militaryStatusList[(string)dataReader[MILITARY_STATUS]];
        ////					employee.MaritalStatus = maritalStatusList[(string)dataReader[MARITAL_STATUS]];
        ////					employee.BloodGrop.Name = (string)dataReader[BLOOD_GROUP];
        ////					employee.DriverLicenseNo = (string)dataReader[DRIVER_LICENSE_NO];
        ////					if(!dataReader.IsDBNull(DRIVER_LICENSE_EXPIRE_DATE))
        ////					{
        ////						employee.DriverLicenseExpireDate = dataReader.GetDateTime(DRIVER_LICENSE_EXPIRE_DATE);
        ////					}
        ////					employee.DriverLicenseType = CTFunction.GetDriverLicenceType((string)dataReader[DRIVER_LICENSE_TYPE]);
        //					value.Add(employee);
        //				}
        //			}
        //			catch (IndexOutOfRangeException ein)
        //			{
        //				throw ein;
        //			}
        //			finally
        //			{
        //				tableAccess.CloseDataReader();
        //				dataReader = null;
        //
        //				employee = null;
        //				sectionList = null;
        //				positionList = null;
        //				titleList = null;
        //				kindOfStaffList = null;
        //				workingStatusList = null;
        //				militaryStatusList = null;
        //				maritalStatusList = null;
        //				stringBuilder = null;
        //			}
        //			return result;
        //		}
        #endregion
    }
}