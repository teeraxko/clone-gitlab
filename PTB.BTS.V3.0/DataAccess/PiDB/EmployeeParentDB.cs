using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

namespace DataAccess.PiDB
{
	public class EmployeeParentDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int FATHER_PREFIX = 1;
		private const int FATHER_NAME = 2;
		private const int FATHER_SURNAME = 3;
		private const int FATHER_BIRTH_DATE = 4;
		private const int FATHER_OCCUPATION = 5;
		private const int FATHER_ALIVE_STATUS = 6;
		private const int MOTHER_PREFIX = 7;
		private const int MOTHER_NAME = 8;
		private const int MOTHER_SURNAME = 9;
		private const int MOTHER_BIRTH_DATE = 10;
		private const int MOTHER_OCCUPATION = 11;
		private const int MOTHER_ALIVE_STATUS = 12;
		#endregion

		#region - Private -
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeParentDB(): base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Father_Prefix, Father_Name, Father_Surname, Father_Birth_Date, Father_Occupation, Father_Alive_Status, Mother_Prefix, Mother_Name, Mother_Surname, Mother_Birth_Date, Mother_Occupation, Mother_Alive_Status FROM Employee_Parent ";
		}

		private string getSQLInsert(EmployeeFather aEmployeeFather, EmployeeMother aEmployeeMother, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Employee_Parent (Company_Code, Employee_No, Father_Prefix, Father_Name, Father_Surname, Father_Birth_Date, Father_Occupation, Father_Alive_Status, Mother_Prefix, Mother_Name, Mother_Surname, Mother_Birth_Date, Mother_Occupation, Mother_Alive_Status, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");
			
			//Father_Prefix
			stringBuilder.Append(GetDB(aEmployeeFather.APrefix.Thai));
			stringBuilder.Append(", ");
			
			//Father_Name
			stringBuilder.Append(GetDB(aEmployeeFather.AName.Thai));
			stringBuilder.Append(", ");
			
			//Father_Surname
			stringBuilder.Append(GetDB(aEmployeeFather.ASurname.Thai));
			stringBuilder.Append(", ");
			
			//Father_Birth_Date
			stringBuilder.Append(GetDB(aEmployeeFather.BirthDate));
			stringBuilder.Append(", ");
			
			//Father_Occupation
			stringBuilder.Append(GetDB(aEmployeeFather.AOccupation.Name));
			stringBuilder.Append(", ");
			
			//Father_Alive_Status
			stringBuilder.Append(GetDB(aEmployeeFather.Alive));
			stringBuilder.Append(", ");
			
			//Mother_Prefix
			stringBuilder.Append(GetDB(aEmployeeMother.APrefix.Thai));
			stringBuilder.Append(", ");
			
			//Mother_Name
			stringBuilder.Append(GetDB(aEmployeeMother.AName.Thai));
			stringBuilder.Append(", ");
			
			//Mother_Surname
			stringBuilder.Append(GetDB(aEmployeeMother.ASurname.Thai));
			stringBuilder.Append(", ");
			
			//Mother_Birth_Date
			stringBuilder.Append(GetDB(aEmployeeMother.BirthDate));
			stringBuilder.Append(", ");
			
			//Mother_Occupation
			stringBuilder.Append(GetDB(aEmployeeMother.AOccupation.Name));
			stringBuilder.Append(", ");
			
			//Mother_Alive_Status
			stringBuilder.Append(GetDB(aEmployeeMother.Alive));
			stringBuilder.Append(", ");
			
			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(EmployeeFather aEmployeeFather, EmployeeMother aEmployeeMother, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Parent SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Father_Prefix = ");
			stringBuilder.Append(GetDB(aEmployeeFather.APrefix.Thai));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Father_Name = ");
			stringBuilder.Append(GetDB(aEmployeeFather.AName.Thai));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Father_Surname = ");
			stringBuilder.Append(GetDB(aEmployeeFather.ASurname.Thai));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Father_Birth_Date = ");
			stringBuilder.Append(GetDB(aEmployeeFather.BirthDate));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Father_Occupation = ");
			stringBuilder.Append(GetDB(aEmployeeFather.AOccupation.Name));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Father_Alive_Status = ");
			stringBuilder.Append(GetDB(aEmployeeFather.Alive));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Mother_Prefix = ");
			stringBuilder.Append(GetDB(aEmployeeMother.APrefix.Thai));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Mother_Name = ");
			stringBuilder.Append(GetDB(aEmployeeMother.AName.Thai));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Mother_Surname = ");
			stringBuilder.Append(GetDB(aEmployeeMother.ASurname.Thai));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Mother_Birth_Date = ");
			stringBuilder.Append(GetDB(aEmployeeMother.BirthDate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Mother_Occupation = ");
			stringBuilder.Append(GetDB(aEmployeeMother.AOccupation.Name));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Mother_Alive_Status = ");
			stringBuilder.Append(GetDB(aEmployeeMother.Alive));
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
			return " DELETE FROM Employee_Parent ";
		}
        #endregion

		#region - Fill -
		private void fillEmployeeParent(ref EmployeeFather aEmployeeFather, ref EmployeeMother aEmployeeMother, SqlDataReader dataReader)
		{
			aEmployeeFather.APrefix.Thai = (string)dataReader[FATHER_PREFIX];
			aEmployeeFather.AName.Thai = (string)dataReader[FATHER_NAME];
			aEmployeeFather.ASurname.Thai = (string)dataReader[FATHER_SURNAME];
			if (dataReader.IsDBNull(FATHER_BIRTH_DATE))
			{
				aEmployeeFather.BirthDate = NullConstant.DATETIME;
			}
			else
			{
				aEmployeeFather.BirthDate = dataReader.GetDateTime(FATHER_BIRTH_DATE);
			}
			aEmployeeFather.AOccupation.Name = (string)dataReader[FATHER_OCCUPATION];
			aEmployeeFather.Alive = GetBool((string)dataReader[FATHER_ALIVE_STATUS]);

			aEmployeeMother.APrefix.Thai = (string)dataReader[MOTHER_PREFIX];
			aEmployeeMother.AName.Thai = (string)dataReader[MOTHER_NAME];
			aEmployeeMother.ASurname.Thai = (string)dataReader[MOTHER_SURNAME];
			if (dataReader.IsDBNull(MOTHER_BIRTH_DATE))
			{
				aEmployeeMother.BirthDate = NullConstant.DATETIME;
			}
			else
			{
				aEmployeeMother.BirthDate = dataReader.GetDateTime(MOTHER_BIRTH_DATE);
			}
			aEmployeeMother.AOccupation.Name = (string)dataReader[MOTHER_OCCUPATION];
			aEmployeeMother.Alive = GetBool((string)dataReader[MOTHER_ALIVE_STATUS]);
		} 

		private bool fillEmployeeParent(ref EmployeeFather aEmployeeFather, ref EmployeeMother aEmployeeMother, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillEmployeeParent(ref aEmployeeFather, ref aEmployeeMother, dataReader);
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
			}			
			return result;				
		}
		#endregion

		private void UpdateSingleField(EmployeeFather aEmployeeFather, EmployeeMother aEmployeeMother, Employee aEmployee)
		{
			PrefixDB dbPrefix = new PrefixDB();
			Prefix prefix = new Prefix();
			prefix.Name = aEmployeeFather.APrefix.Thai;
			dbPrefix.UpdateMTB(prefix);

			prefix = new Prefix();
			prefix.Name = aEmployeeMother.APrefix.Thai;
			dbPrefix.UpdateMTB(prefix);

			prefix = null;
			dbPrefix = null;

			OccupationDB dbOccupation = new OccupationDB();
			Occupation occupation = new Occupation();
			occupation.Name = aEmployeeFather.AOccupation.Name;
			dbOccupation.UpdateMTB(occupation);
			

			occupation = new Occupation();
			occupation.Name = aEmployeeMother.AOccupation.Name;
			dbOccupation.UpdateMTB(occupation);
			occupation = null;
			dbOccupation = null;
		}
//		============================== internal Method ==============================
		#region - internal -
		internal bool MaintainEmployeeParent(EmployeeFather aEmployeeFather, EmployeeMother aEmployeeMother, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));

			stringBuilder.Append(getSQLInsert(aEmployeeFather, aEmployeeMother, aEmployee));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{
				UpdateSingleField(aEmployeeFather,aEmployeeMother,aEmployee);
				return true;}
			else
			{return false;}	
		}
		#endregion
//		============================== Public Method ==============================
		public bool FillEmployeeParent(ref EmployeeFather aEmployeeFather, ref EmployeeMother aEmployeeMother, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));

			return fillEmployeeParent(ref aEmployeeFather, ref aEmployeeMother, stringBuilder.ToString());
		}

		public bool InsertEmployeeParent(EmployeeFather aEmployeeFather, EmployeeMother aEmployeeMother, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(aEmployeeFather, aEmployeeMother, aEmployee))>0)
			{
				UpdateSingleField(aEmployeeFather,aEmployeeMother,aEmployee);
				return true;
			}
			else
			{return false;}	
		}

		public bool UpdateEmployeeParent(EmployeeFather aEmployeeFather, EmployeeMother aEmployeeMother, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(aEmployeeFather, aEmployeeMother, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployeeFather.AEmployee));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{
				UpdateSingleField(aEmployeeFather,aEmployeeMother,aEmployee);
				return true;
			}
			else
			{return false;}
		}

		public bool DeleteEmployeeParent(EmployeeFather aEmployeeFather, EmployeeMother aEmployeeMother, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));

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
