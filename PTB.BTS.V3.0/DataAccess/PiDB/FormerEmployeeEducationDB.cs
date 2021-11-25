using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.PiDB
{
	public class FormerEmployeeEducationDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int EDUCATION_LEVEL_NAME = 1;
		private const int INSTITUTE_NAME = 2;
		private const int FACULTY_NAME = 3;
		private const int MAJOR_NAME = 4;
		private const int GPA = 5;
		private const int YEAR_IN = 6;
		private const int YEAR_GRADUATE = 7;
		private const int EDUCATION_STATUS = 8;
		#endregion

		#region - Private -
		private Education objEducation;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public FormerEmployeeEducationDB()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Employee_No, Education_Level_Name, Institute_Name, Faculty_Name, Major_Name, GPA, Year_In, Year_Graduate, Education_Status FROM Former_Employee_Education ";
		}

		private string getSQLInsert(Education aEducation, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Former_Employee_Education (Company_Code, Employee_No, Education_Level_Name, Institute_Name, Faculty_Name, Major_Name, GPA, Year_In, Year_Graduate, Education_Status, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Education_Level_Name
			stringBuilder.Append(GetDB(aEducation.AEducationLevel.AName.Thai));
			stringBuilder.Append(", ");
			
			//Institute_Name
			stringBuilder.Append(GetDB(aEducation.AInstitute.AName.Thai));
			stringBuilder.Append(", ");
			
			//Faculty_Name
			stringBuilder.Append(GetDB(aEducation.AFaculty.AName.Thai));
			stringBuilder.Append(", ");
			
			//Major_Name
			stringBuilder.Append(GetDB(aEducation.AMajor.AName.Thai));
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
			StringBuilder stringBuilder = new StringBuilder("UPDATE Former_Employee_Education SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Education_Level_Name = ");
			stringBuilder.Append(GetDB(aEducation.AEducationLevel.AName.Thai));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Institute_Name = ");
			stringBuilder.Append(GetDB(aEducation.AInstitute.AName.Thai));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Faculty_Name = ");
			stringBuilder.Append(GetDB(aEducation.AFaculty.AName.Thai));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Major_Name = ");
			stringBuilder.Append(GetDB(aEducation.AMajor.AName.Thai));
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
			return " DELETE FROM Former_Employee_Education ";
		}

		private string getKeyCondition(Education value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.AEducationLevel.AName.Thai))
			{
				stringBuilder.Append(" AND (Education_Level_Name = ");
				stringBuilder.Append(GetDB(value.AEducationLevel.AName.Thai));
				stringBuilder.Append(")");			
			}

			if(IsNotNULL(value.AInstitute.AName.Thai))
			{
				stringBuilder.Append(" AND (Institute_Name = ");
				stringBuilder.Append(GetDB(value.AInstitute.AName.Thai));
				stringBuilder.Append(")");			
			}

			if(IsNotNULL(value.AFaculty.AName.Thai))
			{
				stringBuilder.Append(" AND (Faculty_Name = ");
				stringBuilder.Append(GetDB(value.AFaculty.AName.Thai));
				stringBuilder.Append(")");			
			}

			if(IsNotNULL(value.AMajor.AName.Thai))
			{
				stringBuilder.Append(" AND (Major_Name = ");
				stringBuilder.Append(GetDB(value.AMajor.AName.Thai));
				stringBuilder.Append(")");			
			}
			return stringBuilder.ToString();
		}
		
		private string getOrderby()
		{
			return " ORDER BY Employee_No, Education_Level_Name, Institute_Name, Faculty_Name, Major_Name ";
		}
		#endregion

		#region - Fill -
		private void fillFormerEmployeeEducation(ref Education value, SqlDataReader dataReader)
		{
            ictus.Common.Entity.Description description_Education = new ictus.Common.Entity.Description();
            description_Education.Thai = (string)dataReader[EDUCATION_LEVEL_NAME];
            value.AEducationLevel.AName = description_Education;

            ictus.Common.Entity.Description description_Institure = new ictus.Common.Entity.Description();
            description_Institure.Thai = (string)dataReader[INSTITUTE_NAME];
            value.AInstitute.AName = description_Institure;

            ictus.Common.Entity.Description description_Faculty = new ictus.Common.Entity.Description();
            description_Faculty.Thai = (string)dataReader[FACULTY_NAME];
            value.AFaculty.AName = description_Faculty;

            ictus.Common.Entity.Description description_Major = new ictus.Common.Entity.Description();
            description_Major.Thai = (string)dataReader[MAJOR_NAME];
            value.AMajor.AName = description_Major;

			value.Gpa = dataReader.GetDecimal(GPA);
			value.YearIn = dataReader.GetInt16(YEAR_IN);
			value.YearGraduate = dataReader.GetInt16(YEAR_GRADUATE);
			value.Status = CTFunction.GetEducationStatusType((string)dataReader[EDUCATION_STATUS]);
		}

		private bool fillFormerEmployeeEducationList(ref EmployeeEducation value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objEducation = new Education();
					fillFormerEmployeeEducation(ref objEducation, dataReader);
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

//		============================== internal Method ==============================
		#region - internal -
		internal bool MaintainFormerEmployeeEducation(EmployeeEducation value)
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
//		internal bool DeleteFormerEmployeeEducation(Education aEducation, Employee aEmployee, SqlTransaction transaction)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
//			stringBuilder.Append(getBaseCondition(aEmployee));
//			stringBuilder.Append(getKeyCondition(aEducation));
//
//			if (tableAccess.ExecuteSQL(stringBuilder.ToString(), transaction)>0)
//			{return true;}
//			else
//			{return false;}
//		}
//		internal bool InsertFormerEmployeeEducation(Education aEducation, Employee aEmployee, SqlTransaction transaction)
//		{
//			if (tableAccess.ExecuteSQL(getSQLInsert(aEducation, aEmployee), transaction)>0)
//			{return true;}
//			else
//			{return false;}	
//		}
//
//		internal bool UpdateFormerEmployeeEducation(Education aEducation, Employee aEmployee, SqlTransaction transaction)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(aEducation, aEmployee));
//			stringBuilder.Append(getBaseCondition(aEmployee));
//			stringBuilder.Append(getKeyCondition(aEducation));
//
//			if (tableAccess.ExecuteSQL(stringBuilder.ToString(), transaction)>0)
//			{return true;}
//			else
//			{return false;}
//		}
		#endregion
//		============================== Public Method ==============================
		public bool FillFormerEmployeeEducationList (ref EmployeeEducation value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getOrderby());

			return fillFormerEmployeeEducationList(ref value, stringBuilder.ToString());
		}

		public bool InsertFormerEmployeeEducation(Education aEducation, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(aEducation, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateFormerEmployeeEducation(Education aEducation, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(aEducation, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(aEducation));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteFormerEmployeeEducation(Education aEducation, Employee aEmployee)
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
