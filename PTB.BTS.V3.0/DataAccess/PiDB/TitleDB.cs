using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
using ictus.Common.Entity.General;

namespace DataAccess.PiDB
{
	public class TitleDB : DataAccessBase
	{
		#region - Constant -
		private const int TITLE_CODE = 0;
		private const int ENGLISH_NAME = 1;
		private const int THAI_NAME = 2;
		private const int SHORT_NAME = 3;
		#endregion

		#region - Private -
		private Title objTitle;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public TitleDB() : base()
		{
		}
		
//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Title_Code, English_Name, Thai_Name, Short_Name FROM Title ";
		}

		private string getSQLInsert(Title aTitle, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Title (Company_Code, Title_Code, English_Name, Thai_Name, Short_Name, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Title_CodeTitle_Code			
			stringBuilder.Append(GetDB(aTitle.Code));
			stringBuilder.Append(", ");

			//English_Name
			stringBuilder.Append(GetDB(aTitle.AName.English));
			stringBuilder.Append(", ");

			//Thai_Name
			stringBuilder.Append(GetDB(aTitle.AName.Thai));
			stringBuilder.Append(", ");

			//Short_Name
			stringBuilder.Append(GetDB(aTitle.ShortName));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(Title aTitle, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Title SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Title_Code = ");
			stringBuilder.Append(GetDB(aTitle.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("English_Name = ");
			stringBuilder.Append(GetDB(aTitle.AName.English));
			stringBuilder.Append(", ");
	
			stringBuilder.Append("Thai_Name = ");
			stringBuilder.Append(GetDB(aTitle.AName.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Short_Name = ");
			stringBuilder.Append(GetDB(aTitle.ShortName));
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
			return " DELETE FROM Title ";
		}

		private string getKeyCondition(Title value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.Code))
			{
				stringBuilder.Append(" AND (Title_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");			
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Title_Code ";
		}
		#endregion

		#region - Fill -
		private void fillTitle(ref Title value, SqlDataReader dataReader)
		{
			value.Code = (string)dataReader[TITLE_CODE];

            ictus.Common.Entity.Description description = new ictus.Common.Entity.Description();
            description.English = (string)dataReader[ENGLISH_NAME];
            description.Thai = (string)dataReader[THAI_NAME];
            value.AName = description;

			value.ShortName = (string)dataReader[SHORT_NAME];
		}

		private bool fillTitleData(ref TitleList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objTitle = new Title();
					fillTitle(ref objTitle, dataReader);
					value.Add(objTitle);
				}
				objTitle = null;
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

		private bool fillTitle(ref Title value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillTitle(ref value, dataReader);
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
		public Title GetTitle(string titleCode, Company aCompany)
		{
			objTitle = new Title();
			objTitle.Code = titleCode;
			if(FillTitle(ref objTitle, aCompany))
			{
				return objTitle;		
			}
			else
			{
				objTitle = null;
				return null;
			}
		}

		internal Title GetDBTitle(string titleCode, Company aCompany)
		{
			objTitle = new Title();
			objTitle.Code = titleCode;
			if(FillTitle(ref objTitle, aCompany))
			{
				return objTitle;		
			}
			else
			{
				objTitle.Code = NullConstant.STRING;
				return objTitle;
			}
		}

		public bool FillTitle(ref Title value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(getOrderby());

			return fillTitle(ref value, stringBuilder.ToString());
		}

		public bool FillTitleData(ref TitleList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillTitleData(ref value, stringBuilder.ToString());
		}

		public bool InsertTitle(Title value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateTitle(Title value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteTitle(Title value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
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
