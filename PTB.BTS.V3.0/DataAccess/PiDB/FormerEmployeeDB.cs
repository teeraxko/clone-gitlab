using System;
using System.Data.SqlClient;
using System.Text;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;
using SystemFramework.AppException;

namespace DataAccess.PiDB
{
	public class FormerEmployeeDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int DEPARTMENT_ENGLISH_NAME = 1;
		private const int DEPARTMENT_THAI_NAME = 2;
		private const int SECTION_ENGLISH_NAME = 3;
		private const int SECTION_THAI_NAME = 4;
		private const int THAI_PREFIX = 5;
		private const int THAI_NAME = 6;
		private const int THAI_SURNAME = 7;
		private const int ENGLISH_PREFIX = 8;
		private const int ENGLISH_NAME = 9;
		private const int ENGLISH_SURNAME = 10;
		private const int POSITION_ENGLISH_NAME = 11;
		private const int POSITION_THAI_NAME = 12;
		private const int HIRE_DATE = 13;
		private const int WORKING_STATUS = 14;
		private const int TERMINATION_DATE = 15;
		private const int GENDER = 16;
        private const int BIRTH_DATE = 17;
		private const int CENTURY = 18;
		private const int TITLE_ENGLISH_NAME = 19;
		private const int TITLE_THAI_NAME = 20;
		private const int KIND_OF_STAFF = 21;
		private const int SHIFT_NO = 22;
		private const int KIND_OF_OT = 23;
		private const int TERMINATION_REASON = 24;
		private const int RACE = 25;
		private const int NATIONALITY = 26;
		private const int RELIGION = 27;
		private const int ID_CARD_NO = 28;
		private const int ID_CARD_EXPIRE_DATE = 29;
		private const int SOCIAL_SECURITY_NO  = 30;
		private const int TAX_ID_NO  = 31;
		private const int MILITARY_STATUS  = 32;
		private const int MARITAL_STATUS = 33;
		private const int BLOOD_GROUP  = 34;
		private const int DRIVER_LICENSE_NO  = 35;
		private const int DRIVER_LICENSE_EXPIRE_DATE  = 36;
		private const int DRIVER_LICENSE_TYPE = 37;
        private const int SS_HOSPITAL_CODE = 38;
		#endregion

		#region - Private -	
		private bool disposed = false;
		private Employee objEmployee;
		private WorkingStatusDB dbWorkingStatus;
		private KindOfStaffDB dbKindOfStaff;
		private MilitaryStatusDB dbMilitaryStatus;
		private MaritalStatusDB dbMaritalStatus;
        private SSHospitalDB _dbSSHospital;
		#endregion

//		============================== Constructor ==============================
		public FormerEmployeeDB()
		{
			dbWorkingStatus = new WorkingStatusDB();
			dbKindOfStaff = new KindOfStaffDB();
			dbMilitaryStatus = new MilitaryStatusDB();
			dbMaritalStatus = new MaritalStatusDB();
            _dbSSHospital = new SSHospitalDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelectFormerInfo()
		{
            return " SELECT Employee_No, Department_English_Name, Department_Thai_Name, Section_English_Name, Section_Thai_Name, Thai_Prefix, Thai_Name, Thai_Surname, English_Prefix, English_Name, English_Surname, Position_English_Name, Position_Thai_Name, Hire_Date, Working_Status, Termination_Date, Gender, Birth_date, Century, Title_English_Name, Title_Thai_Name, Kind_Of_Staff, Shift_No, Kind_Of_OT, Termination_Reason, Race, Nationality, Religion, ID_Card_No, ID_Card_Expire_Date, Social_Security_No, Tax_ID_No, Military_Status, Marital_Status, Blood_Group, Driver_License_No, Driver_License_Expire_Date, Driver_License_Type, SS_Hospital_Code, PF_From_Date, PF_To_Date FROM Former_Employee ";
		}

		private string getSQLSelectFormer()
		{
			return " SELECT Employee_No, Department_English_Name, Department_Thai_Name, Section_English_Name, Section_Thai_Name, Thai_Prefix, Thai_Name, Thai_Surname, English_Prefix, English_Name, English_Surname, Position_English_Name, Position_Thai_Name, Hire_Date, Working_Status, Termination_Date, Gender, Birth_Date FROM Former_Employee ";
		}

		private string getSQLInsert(EmployeeInfo value)
		{
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Former_Employee (Company_Code, Employee_No, Department_English_Name, Department_Thai_Name, Section_English_Name, Section_Thai_Name, Century, Thai_Prefix, Thai_Name, Thai_Surname, English_Prefix, English_Name, English_Surname, Position_English_Name, Position_Thai_Name, Title_English_Name, Title_Thai_Name, Kind_Of_Staff, Shift_No, Kind_Of_OT, Hire_Date, Working_Status, Termination_Date, Termination_Reason, Gender, Race, Nationality, Religion, ID_Card_No, ID_Card_Expire_Date, Social_Security_No, Tax_ID_No, Military_Status, Marital_Status, Blood_Group, Driver_License_No, Driver_License_Expire_Date, Driver_License_Type, Birth_Date, Process_Date, Process_User, SS_Hospital_Code, PF_From_Date, PF_To_Date) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(value.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(value.EmployeeNo));
			stringBuilder.Append(", ");
		
			//Department_English_Name
			stringBuilder.Append(GetDB(value.ASection.ADepartment.AFullName.English));
			stringBuilder.Append(", ");

			//Department_Thai_Name
			stringBuilder.Append(GetDB(value.ASection.ADepartment.AFullName.Thai));
			stringBuilder.Append(", ");
			
			//Section_English_Name
			stringBuilder.Append(GetDB(value.ASection.AFullName.English));
			stringBuilder.Append(", ");

			//Section_Thai_Name
			stringBuilder.Append(GetDB(value.ASection.AFullName.Thai));
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
	
			//Position_English_Name
			stringBuilder.Append(GetDB(value.APosition.AName.English));
			stringBuilder.Append(", ");

			//Position_Thai_Name
			stringBuilder.Append(GetDB(value.APosition.AName.Thai));
			stringBuilder.Append(", ");
			
			//Title_English_Name
			stringBuilder.Append(GetDB(value.ATitle.AName.English));
			stringBuilder.Append(", ");

			//Title_Thai_Name
			stringBuilder.Append(GetDB(value.ATitle.AName.Thai));
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

            //Birth_date
            stringBuilder.Append(GetDB(value.BirthDate));
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
			StringBuilder stringBuilder = new StringBuilder("UPDATE Former_Employee SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(value.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(value.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Department_English_Name = ");
			stringBuilder.Append(GetDB(value.ASection.ADepartment.AFullName.English));
			stringBuilder.Append(", ");

			stringBuilder.Append("Department_Thai_Name = ");
			stringBuilder.Append(GetDB(value.ASection.ADepartment.AFullName.Thai));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Section_English_Name = ");
			stringBuilder.Append(GetDB(value.ASection.AFullName.English));
			stringBuilder.Append(", ");

			stringBuilder.Append("Section_Thai_Name = ");
			stringBuilder.Append(GetDB(value.ASection.AFullName.Thai));
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

			stringBuilder.Append("Position_English_Name = ");
			stringBuilder.Append(GetDB(value.APosition.AName.English));
			stringBuilder.Append(", ");

			stringBuilder.Append("Position_Thai_Name = ");
			stringBuilder.Append(GetDB(value.APosition.AName.Thai));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Title_English_Name = ");
			stringBuilder.Append(GetDB(value.ATitle.AName.English));
			stringBuilder.Append(", ");

			stringBuilder.Append("Title_Thai_Name = ");
			stringBuilder.Append(GetDB(value.ATitle.AName.Thai));
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

            stringBuilder.Append("Birth_Date = ");
            stringBuilder.Append(GetDB(value.BirthDate));
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
			return " DELETE FROM Former_Employee ";
		}

		private string getKeyCondition(Employee value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.EmployeeNo))
			{
				stringBuilder.Append(" AND (Employee_No = ");
				stringBuilder.Append(GetDB(value.EmployeeNo));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No";
		}
		#endregion

		#region - Fill -
		private void fillFormerEmployeeInfo(EmployeeInfo value, SqlDataReader dataReader)
		{
			fillFormerEmployee(value, dataReader);

            ictus.Common.Entity.Description description = new ictus.Common.Entity.Description();
            description.English = (string)dataReader[TITLE_ENGLISH_NAME];
            description.Thai = (string)dataReader[TITLE_THAI_NAME];
			value.ATitle.AName = description;
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
            if (dataReader.IsDBNull(BIRTH_DATE))
            {
                value.BirthDate = NullConstant.DATETIME;
            }
            else
            {
                value.BirthDate = dataReader.GetDateTime(BIRTH_DATE);
            }

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

		private void fillFormerEmployee(Employee value, SqlDataReader dataReader)
		{
			value.EmployeeNo = (string)dataReader[EMPLOYEE_NO];
			value.ASection.ADepartment.AFullName.English = (string)dataReader[DEPARTMENT_ENGLISH_NAME];
			value.ASection.ADepartment.AFullName.Thai = (string)dataReader[DEPARTMENT_THAI_NAME];
			value.ASection.AFullName.English = (string)dataReader[SECTION_ENGLISH_NAME];
			value.ASection.AFullName.Thai = (string)dataReader[SECTION_THAI_NAME];
			value.APrefix.Thai = (string)dataReader[THAI_PREFIX];
			value.AName.Thai = (string)dataReader[THAI_NAME];
			value.ASurname.Thai = (string)dataReader[THAI_SURNAME];
			value.APrefix.English = (string)dataReader[ENGLISH_PREFIX];
			value.AName.English = (string)dataReader[ENGLISH_NAME];
			value.ASurname.English = (string)dataReader[ENGLISH_SURNAME];
			value.APosition.AName.English = (string)dataReader[POSITION_ENGLISH_NAME];
			value.APosition.AName.Thai = (string)dataReader[POSITION_THAI_NAME];
			value.HireDate = dataReader.GetDateTime(HIRE_DATE);
			value.AWorkingStatus = (WorkingStatus)dbWorkingStatus.GetDBDualField((string)dataReader[WORKING_STATUS], value.Company);
			value.TerminationDate = dataReader.GetDateTime(TERMINATION_DATE);
			value.Gender = CTFunction.GetGenderType((string)dataReader[GENDER]);
            if (dataReader.IsDBNull(BIRTH_DATE))
            {
                value.BirthDate = NullConstant.DATETIME;
            }
            else
            {
                value.BirthDate = dataReader.GetDateTime(BIRTH_DATE);
            }
		}

		private bool fillFormerEmployeeInfo(ref EmployeeInfo value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillFormerEmployeeInfo(value, dataReader);
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


		private bool fillFormerEmployee(ref Employee value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillFormerEmployee(value, dataReader);
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

		private bool fillFormerEmployeeList(ref EmployeeList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objEmployee = new Employee(value.Company);
					fillFormerEmployee(objEmployee, dataReader);
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
			}
			return result;
		}
		#endregion

//		============================== Public Method ==============================
		public bool FillFormerEmployeeInfo(ref EmployeeInfo value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelectFormerInfo());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(value));
			return fillFormerEmployeeInfo(ref value, stringBuilder.ToString());
		}

		public bool FillFormerEmployee(ref Employee value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelectFormer());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(value));
			return fillFormerEmployee(ref value, stringBuilder.ToString());
		}

		public bool FillFormerEmployeeList(ref EmployeeList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelectFormer());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillFormerEmployeeList(ref value, stringBuilder.ToString());
		}

		public bool FillFormerEmployeeList(ref EmployeeList aEmployeeList, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelectFormer());
			stringBuilder.Append(getBaseCondition(aEmployeeList.Company));
			stringBuilder.Append(getKeyCondition(aEmployee));
			stringBuilder.Append(getOrderby());

			return fillFormerEmployeeList(ref aEmployeeList, stringBuilder.ToString());	
		}

		public bool InsertFormerEmployee(EmployeeInfo value)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateFormerEmployee(EmployeeInfo value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value));
			stringBuilder.Append(getBaseCondition(value));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteFormerEmployee(Employee value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value));
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
	}
}
