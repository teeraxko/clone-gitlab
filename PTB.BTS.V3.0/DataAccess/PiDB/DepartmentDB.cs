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
	public class DepartmentDB : DataAccessBase
	{
		#region - Constant -
		private const int DEPARTMENT_CODE = 0;
		private const int ENGLISH_NAME = 1;
		private const int THAI_NAME = 2;
		private const int ENGLISH_SHORT_NAME = 3;
		#endregion

		#region - Private -
		private Department objDepartment;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public DepartmentDB(): base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Department_Code, English_Name, Thai_Name, English_Short_Name FROM Department ";
		}

		private string getSQLInsert(Department aDepartment, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Department (Company_Code, Department_Code, English_Name, Thai_Name, English_Short_Name, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Department_Code			
			stringBuilder.Append(GetDB(aDepartment.Code));
			stringBuilder.Append(", ");

			//English_Name
			stringBuilder.Append(GetDB(aDepartment.AFullName.English));
			stringBuilder.Append(", ");

			//Thai_Name
			stringBuilder.Append(GetDB(aDepartment.AFullName.Thai));
			stringBuilder.Append(", ");

			//English_Short_Name
			stringBuilder.Append(GetDB(aDepartment.ShortName));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(Department aDepartment, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Department SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Department_Code = ");
			stringBuilder.Append(GetDB(aDepartment.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("English_Name = ");
			stringBuilder.Append(GetDB(aDepartment.AFullName.English));
			stringBuilder.Append(", ");
	
			stringBuilder.Append("Thai_Name = ");
			stringBuilder.Append(GetDB(aDepartment.AFullName.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("English_Short_Name = ");
			stringBuilder.Append(GetDB(aDepartment.ShortName));
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
			return " DELETE FROM Department ";
		}

		private string getKeyCondition(Department value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.Code))
			{
				stringBuilder.Append(" AND (Department_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");			
			}

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Thai_Name ";
		}
		#endregion

		#region - Fill -
		private void fillDepartment(ref Department value, SqlDataReader dataReader)
		{
			value.Code = (string)dataReader[DEPARTMENT_CODE];
			value.AFullName.English = (string)dataReader[ENGLISH_NAME];
			value.AFullName.Thai = (string)dataReader[THAI_NAME];
			value.ShortName = (string)dataReader[ENGLISH_SHORT_NAME];
		}

		private bool fillDepartmentList(ref DepartmentList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objDepartment = new Department();
					objDepartment.ACompany = value.Company;
					fillDepartment(ref objDepartment, dataReader);
					value.Add(objDepartment);
				}
				objDepartment = null;
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

		private bool fillDepartment(ref Department value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillDepartment(ref value, dataReader);
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
//		============================== Public Method ==============================
		internal Department GetDBDepartment(string departmentCode, Company aCompany)
		{
			objDepartment = new Department();
			objDepartment.Code = departmentCode;
			objDepartment.ACompany = aCompany;
			if(FillDepartment(ref objDepartment))
			{
				return objDepartment;		
			}
			else
			{
				objDepartment.Code = NullConstant.STRING;
				return objDepartment;
			}
		}

		public Department GetDepartment(string departmentCode, Company aCompany)
		{
			objDepartment = new Department();
			objDepartment.Code = departmentCode;
			objDepartment.ACompany = aCompany;
			if(FillDepartment(ref objDepartment))
			{
				return objDepartment;		
			}
			else
			{
				objDepartment = null;
				return null;
			}
		}

		public bool FillDepartment(ref Department value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.ACompany));
			stringBuilder.Append(getKeyCondition(value));
			return fillDepartment(ref value, stringBuilder.ToString());
		}

		public bool FillDepartmentList(ref DepartmentList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillDepartmentList(ref value, stringBuilder.ToString());
		}

		public bool InsertDepartment(Department aDepartment, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(aDepartment, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateDepartment(Department aDepartment, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(aDepartment, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(aDepartment));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteDepartment(Department aDepartment, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(aDepartment));

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
