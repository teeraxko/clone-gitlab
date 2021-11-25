using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.PIS.PI.Entity;

namespace DataAccess.PiDB
{
	public class FormerEmployeeChildrenDB : DataAccessBase
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
		public FormerEmployeeChildrenDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Birth_Date, Child_Prefix, Child_Name, Child_Surname, Gender, Occupation, Medical_Apply_Status, Alive_Status FROM Former_Employee_Children ";
		}

		private string getSQLInsert(EmployeeChildren value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Former_Employee_Children (Company_Code, Employee_No, Birth_Date, Child_Prefix, Child_Name, Child_Surname, Gender, Occupation, Medical_Apply_Status, Alive_Status, Process_Date, Process_User) ");
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
			StringBuilder stringBuilder = new StringBuilder("UPDATE Former_Employee_Children SET ");
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
			return " DELETE FROM Former_Employee_Children ";
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
		private void fillFormerEmployeeChildren(ref EmployeeChildren value, SqlDataReader dataReader)
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

		private bool fillFormerEmployeeChildrenList(ref EmployeeChildrenList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objEmployeeChildren = new EmployeeChildren();
					fillFormerEmployeeChildren(ref objEmployeeChildren, dataReader);
					value.Add(objEmployeeChildren);
				}
				objEmployeeChildren = null;
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

		private bool fillFormerEmployeeChildren(ref EmployeeChildren value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillFormerEmployeeChildren(ref value, dataReader);
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

//		============================== internal Method ==============================
		#region - internal -
		internal bool MaintainFormerEmployeeChildren(EmployeeChildrenList value)
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
//		internal bool DeleteFormerEmployeeChildrenData(EmployeeChildren aEmployeeChildren, Employee aEmployee, SqlTransaction transaction)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
//			stringBuilder.Append(getBaseCondition(aEmployee));
//			stringBuilder.Append(getKeyCondition(aEmployeeChildren));
//
//			if (tableAccess.ExecuteSQL(stringBuilder.ToString(), transaction)>0)
//			{return true;}
//			else
//			{return false;}
//		}
//		internal bool InsertFormerEmployeeChildrenData(EmployeeChildren aEmployeeChildren, Employee aEmployee, SqlTransaction transaction)
//		{
//			if (tableAccess.ExecuteSQL(getSQLInsert(aEmployeeChildren, aEmployee), transaction)>0)
//			{return true;}
//			else
//			{return false;}	
//		}
//
//		internal bool UpdateFormerEmployeeChildrenData(EmployeeChildren aEmployeeChildren, Employee aEmployee, SqlTransaction transaction)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(aEmployeeChildren, aEmployee));
//			stringBuilder.Append(getBaseCondition(aEmployee));
//			stringBuilder.Append(getKeyCondition(aEmployeeChildren));
//
//			if (tableAccess.ExecuteSQL(stringBuilder.ToString(), transaction)>0)
//			{return true;}
//			else
//			{return false;}
//		}
		#endregion
//		============================== Public Method ==============================
		public EmployeeChildren GetFormerEmployeeChildren(DateTime birthDate, string childName, Employee value)
		{
			objEmployeeChildren = new EmployeeChildren();
			objEmployeeChildren.BirthDate = birthDate;
			objEmployeeChildren.AName.Thai = childName;

			if(FillFormerEmployeeChildren(ref objEmployeeChildren, value))
			{
				return objEmployeeChildren;		
			}
			else
			{
				objEmployeeChildren = null;
				return null;
			}
		}

		public bool FillFormerEmployeeChildren(ref EmployeeChildren aEmployeeChildren, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(aEmployeeChildren));
			return fillFormerEmployeeChildren(ref aEmployeeChildren, stringBuilder.ToString());
		}

		public bool FillFormerEmployeeChildrenList (ref EmployeeChildrenList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getOrderby());

			return fillFormerEmployeeChildrenList(ref value, stringBuilder.ToString());
		}

		public bool InsertFormerEmployeeChildren(EmployeeChildren aEmployeeChildren, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(aEmployeeChildren, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateFormerEmployeeChildren(EmployeeChildren aEmployeeChildren, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(aEmployeeChildren, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(aEmployeeChildren));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteFormerEmployeeChildren(EmployeeChildren aEmployeeChildren, Employee aEmployee)
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
