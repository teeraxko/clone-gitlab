using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.PiDB
{
	public class EmployeeEducationDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int EDUCATION_LEVEL_CODE = 1;
		private const int INSTITUTE_CODE = 2;
		private const int FACULTY_CODE = 3;
		private const int MAJOR_CODE = 4;
		private const int GPA = 5;
		private const int YEAR_IN = 6;
		private const int YEAR_GRADUATE = 7;
		private const int EDUCATION_STATUS = 8;
		#endregion

		#region - Private -
		private Education objEducation;
		private EducationLevelDB dbEducationLevel;
		private InstituteDB dbInstitute;
		private MajorDB dbMajor;
		private FacultyDB dbFaculty;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeEducationDB(): base()
		{
			dbEducationLevel = new EducationLevelDB();
			dbInstitute = new InstituteDB();
			dbFaculty = new FacultyDB();
			dbMajor = new MajorDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Education_Level_Code, Institute_Code, Faculty_Code, Major_Code, GPA, Year_In, Year_Graduate, Education_Status FROM Employee_Education ";
		}

		private string getSQLInsert(Education aEducation, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Employee_Education (Company_Code, Employee_No, Education_Level_Code, Institute_Code, Faculty_Code, Major_Code, GPA, Year_In, Year_Graduate, Education_Status, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Education_Level_Code
			stringBuilder.Append(GetDB(aEducation.AEducationLevel.Code));
			stringBuilder.Append(", ");
			
			//Institute_Code
			stringBuilder.Append(GetDB(aEducation.AInstitute.Code));
			stringBuilder.Append(", ");
			
			//Faculty_Code
			stringBuilder.Append(GetDB(aEducation.AFaculty.Code));
			stringBuilder.Append(", ");
			
			//Major_Code
			stringBuilder.Append(GetDB(aEducation.AMajor.Code));
			stringBuilder.Append(", ");
			
			//GPA
			stringBuilder.Append(GetDB(aEducation.Gpa));
			stringBuilder.Append(", ");
			
			//Year_In
			stringBuilder.Append(GetDB(aEducation.YearIn));
			stringBuilder.Append(", ");
			
			//Year_Graduate
			stringBuilder.Append(GetDB(aEducation.YearGraduate));
			stringBuilder.Append(", ");
			
			//Education_Status			
			stringBuilder.Append(GetDB(aEducation.Status));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(Education aEducation, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(" UPDATE Employee_Education SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Education_Level_Code = ");
			stringBuilder.Append(GetDB(aEducation.AEducationLevel.Code));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Institute_Code = ");
			stringBuilder.Append(GetDB(aEducation.AInstitute.Code));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Faculty_Code = ");
			stringBuilder.Append(GetDB(aEducation.AFaculty.Code));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Major_Code = ");
			stringBuilder.Append(GetDB(aEducation.AMajor.Code));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("GPA = ");
			stringBuilder.Append(GetDB(aEducation.Gpa));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Year_In = ");
			stringBuilder.Append(GetDB(aEducation.YearIn));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Year_Graduate = ");
			stringBuilder.Append(GetDB(aEducation.YearGraduate));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Education_Status = ");
			stringBuilder.Append(GetDB(aEducation.Status));
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
			return " DELETE FROM Employee_Education ";
		}

		private string getKeyCondition(Education value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.AEducationLevel.Code))
			{
				stringBuilder.Append(" AND (Education_Level_Code = ");
				stringBuilder.Append(GetDB(value.AEducationLevel.Code));
				stringBuilder.Append(")");			
			}

			if(IsNotNULL(value.AInstitute.Code))
			{
				stringBuilder.Append(" AND (Institute_Code = ");
				stringBuilder.Append(GetDB(value.AInstitute.Code));
				stringBuilder.Append(")");			
			}

			if(IsNotNULL(value.AFaculty.Code))
			{
				stringBuilder.Append(" AND (Faculty_Code = ");
				stringBuilder.Append(GetDB(value.AFaculty.Code));
				stringBuilder.Append(")");			
			}

			if(IsNotNULL(value.AMajor.Code))
			{
				stringBuilder.Append(" AND (Major_Code = ");
				stringBuilder.Append(GetDB(value.AMajor.Code));
				stringBuilder.Append(")");			
			}
			return stringBuilder.ToString();
		}
		
		private string getOrderby()
		{
			return " ORDER BY Education_Level_Code, Institute_Code, Faculty_Code, Major_Code ";
		}
		#endregion

		#region - Fill -
		private void fillEmployeeEducation(ref Education value, SqlDataReader dataReader)
		{
			value.AEducationLevel = (EducationLevel)dbEducationLevel.GetMTB((string)dataReader[EDUCATION_LEVEL_CODE]);
			value.AInstitute = (Institute)dbInstitute.GetMTB((string)dataReader[INSTITUTE_CODE]);
			value.AFaculty = (Faculty)dbFaculty.GetMTB((string)dataReader[FACULTY_CODE]);
			value.AMajor = (Major)dbMajor.GetMTB((string)dataReader[MAJOR_CODE]);
			value.Gpa = dataReader.GetDecimal(GPA);
			value.YearIn = dataReader.GetInt16(YEAR_IN);
			value.YearGraduate = dataReader.GetInt16(YEAR_GRADUATE);
			value.Status = CTFunction.GetEducationStatusType((string)dataReader[EDUCATION_STATUS]);
		}

		private bool fillEmployeeEducationList(ref EmployeeEducation value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objEducation = new Education();
					fillEmployeeEducation(ref objEducation, dataReader);
					value.Add(objEducation);
				}
				objEducation = null;
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

		private void UpdateSingleField(Education aEducation)
		{
			EducationLevelDB dbEducationlevel = new EducationLevelDB();
			dbEducationLevel.UpdateMTB(aEducation.AEducationLevel.AName.Thai);

			InstituteDB dbInstitute = new InstituteDB();
			dbInstitute.UpdateMTB(aEducation.AInstitute.AName.Thai);

			FacultyDB dbFaculty = new FacultyDB();
			dbFaculty.UpdateMTB(aEducation.AFaculty.AName.Thai);

			MajorDB dbMajor = new MajorDB();
			dbMajor.UpdateMTB(aEducation.AMajor.AName.Thai);
		}
//		============================== internal Method ==============================
		#region - internal -
		internal bool MaintainEmployeeEducation(EmployeeEducation value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));

			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLInsert(value[i], value.Employee));		
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		}

		internal bool DeleteEmployeeEducation(EmployeeEducation value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		#endregion
//		============================== Public Method ==============================
		public bool FillEmployeeEducationList (ref EmployeeEducation value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getOrderby());

			return fillEmployeeEducationList(ref value, stringBuilder.ToString());
		}

		public bool InsertEmployeeEducation(Education aEducation, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(aEducation, aEmployee))>0)
			{
				UpdateSingleField(aEducation);
				return true;
			}
			else
			{return false;}	
		}

		public bool UpdateEmployeeEducation(Education aEducation, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(aEducation, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(aEducation));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{
				UpdateSingleField(aEducation);
				return true;
			}
			else
			{return false;}
		}

		public bool DeleteEmployeeEducation(Education aEducation, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(aEducation));

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
	}
}
