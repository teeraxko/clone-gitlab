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
	public class EmployeeChildrenDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int BIRTH_DATE = 1;
		private const int CHILD_PREFIX = 2;
		private const int CHILD_NAME = 3;
		private const int CHILD_SURNAME = 4;
		private const int GENDER = 5;
		private const int OCCUPATION = 6;
		private const int MEDICAL_APPLY_STATUS = 7;
		private const int ALIVE_STATUS = 8;
		#endregion

		#region - Private -
		private EmployeeChildren objEmployeeChildren;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeChildrenDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Birth_Date, Child_Prefix, Child_Name, Child_Surname, Gender, Occupation, Medical_Apply_Status, Alive_Status FROM Employee_Children ";
		}

		private string getSQLInsert(EmployeeChildren value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Employee_Children (Company_Code, Employee_No, Birth_Date, Child_Prefix, Child_Name, Child_Surname, Gender, Occupation, Medical_Apply_Status, Alive_Status, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Birth_Date
			stringBuilder.Append(GetDB(value.BirthDate));
			stringBuilder.Append(", ");

			//Child_Prefix
			stringBuilder.Append(GetDB(value.APrefix.Thai));
			stringBuilder.Append(", ");

			//Child_Name
			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(", ");

			//Child_Surname
			stringBuilder.Append(GetDB(value.ASurname.Thai));
			stringBuilder.Append(", ");

			//Gender
			stringBuilder.Append(GetDB(value.Gender));
			stringBuilder.Append(", ");

			//Occupation
			stringBuilder.Append(GetDB(value.AOccupation.Name));
			stringBuilder.Append(", ");

			//Medical_Apply_Status
			stringBuilder.Append(GetDB(value.ApplyMedical));
			stringBuilder.Append(", ");

			//Alive_Status
			stringBuilder.Append(GetDB(value.Alive));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(EmployeeChildren value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Children SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Birth_Date = ");
			stringBuilder.Append(GetDB(value.BirthDate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Child_Prefix = ");
			stringBuilder.Append(GetDB(value.APrefix.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Child_Name = ");
			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Child_Surname = ");
			stringBuilder.Append(GetDB(value.ASurname.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Gender = ");
			stringBuilder.Append(GetDB(value.Gender));
			stringBuilder.Append(", ");

			stringBuilder.Append("Occupation = ");
			stringBuilder.Append(GetDB(value.AOccupation.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Medical_Apply_Status = ");
			stringBuilder.Append(GetDB(value.ApplyMedical));
			stringBuilder.Append(", ");

			stringBuilder.Append("Alive_Status = ");
			stringBuilder.Append(GetDB(value.Alive));
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
			return " DELETE FROM Employee_Children ";
		}

		private string getKeyCondition(EmployeeChildren value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.BirthDate))
			{
				stringBuilder.Append(" AND (Birth_Date = ");
				stringBuilder.Append(GetDB(value.BirthDate));
				stringBuilder.Append(")");			
			}

			if(IsNotNULL(value.AName.Thai))
			{
				stringBuilder.Append(" AND (Child_Name = ");
				stringBuilder.Append(GetDB(value.AName.Thai));
				stringBuilder.Append(")");			
			}

			return stringBuilder.ToString();
		}
		
		private string getOrderby()
		{
			return " ORDER BY Birth_Date, Child_Name ";
		}
		#endregion

		#region - Fill -
		private void fillEmployeeChildren(ref EmployeeChildren value, SqlDataReader dataReader)
		{
			value.BirthDate = dataReader.GetDateTime(BIRTH_DATE);
			value.APrefix.Thai = (string)dataReader[CHILD_PREFIX];
			value.AName.Thai = (string)dataReader[CHILD_NAME];
			value.ASurname.Thai= (string)dataReader[CHILD_SURNAME];
			value.Gender = CTFunction.GetGenderType((string)dataReader[GENDER]);
			value.AOccupation.Name = (string)dataReader[OCCUPATION];
			value.ApplyMedical = GetBool((string)dataReader[MEDICAL_APPLY_STATUS]);
			value.Alive = GetBool((string)dataReader[ALIVE_STATUS]);
		}

		private bool fillEmployeeChildrenList(ref EmployeeChildrenList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objEmployeeChildren = new EmployeeChildren();
					fillEmployeeChildren(ref objEmployeeChildren, dataReader);
					value.Add(objEmployeeChildren);
				}
				objEmployeeChildren = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;		
		}

		private bool fillEmployeeChildren(ref EmployeeChildren value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillEmployeeChildren(ref value, dataReader);
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

		private void UpdateSingleField(EmployeeChildren value)
		{
			PrefixDB dbPrefix = new PrefixDB();
			dbPrefix.UpdateMTB(value.APrefix.Thai);
		 
			OccupationDB dbOccupation = new OccupationDB();
			dbOccupation.UpdateMTB(value.AOccupation.Name);

		}

//		============================== internal Method ==============================
		#region - internal -
		internal bool MaintainEmployeeChildren(EmployeeChildrenList value)
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
		
		internal bool DeleteEmployeeChildren(EmployeeChildrenList value)
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
		public EmployeeChildren GetEmployeeChildren(DateTime birthDate, string childName, Employee value)
		{
			objEmployeeChildren = new EmployeeChildren();
			objEmployeeChildren.BirthDate = birthDate;
			objEmployeeChildren.AName.Thai = childName;

			if(FillEmployeeChildren(ref objEmployeeChildren, value))
			{
				return objEmployeeChildren;		
			}
			else
			{
				objEmployeeChildren = null;
				return null;
			}
		}

		public bool FillEmployeeChildren(ref EmployeeChildren aEmployeeChildren, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(aEmployeeChildren));
			return fillEmployeeChildren(ref aEmployeeChildren, stringBuilder.ToString());
		}

		public bool FillEmployeeChildrenList (ref EmployeeChildrenList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getOrderby());

			return fillEmployeeChildrenList(ref value, stringBuilder.ToString());
		}

		public bool InsertEmployeeChildren(EmployeeChildren aEmployeeChildren, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(aEmployeeChildren, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateEmployeeChildren(EmployeeChildren aEmployeeChildren, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(aEmployeeChildren, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(aEmployeeChildren));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteEmployeeChildren(EmployeeChildren aEmployeeChildren, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(aEmployeeChildren));

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
