using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

namespace DataAccess.PiDB
{
	public class SectionDB : DataAccessBase
	{
		#region - Constant -
		private const int DEPARTMENT_CODE = 0;
		private const int SECTION_CODE = 1;
		private const int ENGLISH_NAME = 2;
		private const int THAI_NAME = 3;
		private const int ENGLISH_SHORT_NAME = 4;
        private const int BIZ_PAC = 5;
		#endregion

		#region - Private -
		private Section objSection;
		private DepartmentDB dbDepartment;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public SectionDB()
		{
			dbDepartment = new DepartmentDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
            return "SELECT Department_Code, Section_Code, English_Name, Thai_Name, English_Short_Name,BizPac_Department_Code FROM Section ";
		}

		private string getSQLInsert(Section aSection, Company aCompany)
		{
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Section (Company_Code, Department_Code, Section_Code, English_Name, Thai_Name, English_Short_Name, BizPac_Department_Code, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Department_Code			
			stringBuilder.Append(GetDB(aSection.ADepartment.Code));
			stringBuilder.Append(", ");

			//Section_Code
			stringBuilder.Append(GetDB(aSection.Code));
			stringBuilder.Append(", ");

			//English_Name
			stringBuilder.Append(GetDB(aSection.AFullName.English));
			stringBuilder.Append(", ");

			//Thai_Name
			stringBuilder.Append(GetDB(aSection.AFullName.Thai));
			stringBuilder.Append(", ");

			//English_Short_Name
			stringBuilder.Append(GetDB(aSection.ShortName));
			stringBuilder.Append(", ");

            //BiZPac
            stringBuilder.Append(GetDB(aSection.BizPac));
            stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(Section aSection, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Section SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Department_Code = ");
			stringBuilder.Append(GetDB(aSection.ADepartment.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("Section_Code = ");
			stringBuilder.Append(GetDB(aSection.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("English_Name = ");
			stringBuilder.Append(GetDB(aSection.AFullName.English));
			stringBuilder.Append(", ");
	
			stringBuilder.Append("Thai_Name = ");
			stringBuilder.Append(GetDB(aSection.AFullName.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("English_Short_Name = ");
			stringBuilder.Append(GetDB(aSection.ShortName));
			stringBuilder.Append(", ");

            stringBuilder.Append("BizPac_Department_Code = ");
            stringBuilder.Append(GetDB(aSection.BizPac));
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
			return " DELETE FROM Section ";
		}

		private string getKeyCondition(Section value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.Code))
			{
				stringBuilder.Append(" AND (Section_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");	
			}
			return stringBuilder.ToString();
		}

		private string getEntityCondition(Department value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.Code))
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
		private void fillSection(ref Section value, Company aCompany, SqlDataReader dataReader)
		{
			value.Code = (string)dataReader[SECTION_CODE];
			value.AFullName.English = (string)dataReader[ENGLISH_NAME];
			value.AFullName.Thai = (string)dataReader[THAI_NAME];
			value.ShortName = (string)dataReader[ENGLISH_SHORT_NAME];
            value.BizPac = (string)dataReader[BIZ_PAC];
		}

		private void fillSectionDB(ref Section value, Company aCompany, SqlDataReader dataReader)
		{
			fillSection(ref value, aCompany, dataReader);
			value.ADepartment = dbDepartment.GetDBDepartment((string)dataReader[DEPARTMENT_CODE], aCompany);
		}

		private bool fillSectionList(ref SectionList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			DepartmentList departmentList = new DepartmentList(value.Company);
			dbDepartment.FillDepartmentList(ref departmentList);

			try
			{
				while (dataReader.Read())
				{
					result = true;
					objSection = new Section();
					objSection.ADepartment = departmentList[(string)dataReader[DEPARTMENT_CODE]];
					fillSection(ref objSection, value.Company, dataReader);
					value.Add(objSection);
				}
				objSection = null;
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();		
				dataReader = null;		
				departmentList = null;
			}
			return result;		
		}

		private bool fillSection(ref Section value, Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillSectionDB(ref value, aCompany, dataReader);
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
		internal Section GetDBSection(string sectionCode, Company aCompany)
		{
			objSection = new Section();
			objSection.Code = sectionCode;
			if(FillSection(ref objSection, aCompany))
			{
				return objSection;
			}
			else
			{
				objSection.Code = NullConstant.STRING;
				return objSection;			
			}
		}

		public Section GetSection(string sectionCode, Company aCompany)
		{
			objSection = new Section();
			objSection.Code = sectionCode;
			if(FillSection(ref objSection, aCompany))
			{
				return objSection;
			}
			else
			{
				objSection = null;
				return null;			
			}
		}

		public bool FillSection(ref Section aSection, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(aSection));

			return fillSection(ref aSection, aCompany, stringBuilder.ToString());
		}

		public bool FillSectionList(ref SectionList value)
		{ 
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillSectionList(ref value, stringBuilder.ToString());
		}

		public bool FillSectionList(ref SectionList value, Section aSection)
		{ 
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(aSection));
			stringBuilder.Append(getEntityCondition(aSection.ADepartment));
			stringBuilder.Append(getOrderby());

			return fillSectionList(ref value, stringBuilder.ToString());
		}

		public bool InsertSection(Section aSection, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(aSection, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateSection(Section aSection, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(aSection, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(aSection));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteSection(Section aSection, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(aSection));

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
						dbDepartment.Dispose();

						dbDepartment = null;
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
