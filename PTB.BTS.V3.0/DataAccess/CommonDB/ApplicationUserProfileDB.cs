using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.CommonDB
{
	public class ApplicationUserProfileDB : DataAccessBase
	{
		#region - Constant -
		private const int USER_NAME = 0;
		private const int USER_PASSWORD = 1;
		private const int USER_ROLE = 2;
		#endregion

		#region - Private -	
		private ApplicationUserProfile objApplicationUserProfile;
		#endregion

//		============================== Constructor ==============================
		public ApplicationUserProfileDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT User_Name, User_Password, User_Role FROM Application_User_Profile ";
		}

		private string getSQLInsert(ApplicationUserProfile value)
		{
			StringBuilder stringBuilder = new StringBuilder(@"INSERT INTO Application_User_Profile (User_Name, User_Password, User_Role, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//User_Name
			stringBuilder.Append(GetDB(value.UserName));
			stringBuilder.Append(", ");

			//User_Password
			stringBuilder.Append("@User_Password, ");

			//User_Role
			stringBuilder.Append(GetDB(value.UserRoleDB));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(ApplicationUserProfile value)
		{
			StringBuilder stringBuilder = new StringBuilder(@"UPDATE Application_User_Profile SET ");
//			stringBuilder.Append("User_Name = ");
//			stringBuilder.Append(GetDB(value.UserName));
//			stringBuilder.Append(", ");

			stringBuilder.Append(" User_Password = @User_Password");
			stringBuilder.Append(", ");
			
			stringBuilder.Append("User_Role = ");
			stringBuilder.Append(GetDB(value.UserRoleDB));
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
			return " DELETE FROM Application_User_Profile ";
		}

		private string getKeyCondition(ApplicationUserProfile value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.UserName))
			{
				stringBuilder.Append(" AND (User_Name = ");
				stringBuilder.Append(GetDB(value.UserName));
				stringBuilder.Append(" ) ");
			}
			return stringBuilder.ToString();
		}

		private string getEntityCondition(ApplicationUserProfile value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.Password))
			{
				stringBuilder.Append(" AND (User_Password LIKE ");
				stringBuilder.Append(GetDB(value.Password));
				stringBuilder.Append(" ) ");
			}
			return stringBuilder.ToString();
		}

		private string getExcludeEntityCondition(ApplicationUserProfile value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.UserRoleDB))
			{
				stringBuilder.Append(" AND NOT(User_Role = ");
				stringBuilder.Append(GetDB(value.UserRoleDB));
				stringBuilder.Append(" ) ");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY User_Role desc, User_Name ";
		}
		#endregion

		#region - Fill -
		private void fillApplicationUserProfile(ref ApplicationUserProfile value, SqlDataReader dataReader)
		{
			value.UserName = (string)dataReader[USER_NAME];
			value.Password = (string) dataReader.GetValue(USER_PASSWORD);
			value.UserRoleDB = (string)dataReader[USER_ROLE];
		}

		private bool fillApplicationUserProfileList(ref ApplicationUserProfileList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objApplicationUserProfile = new ApplicationUserProfile();
					fillApplicationUserProfile(ref objApplicationUserProfile, dataReader);
					value.Add(objApplicationUserProfile);
				}
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			return result;
		}	

		private bool fillApplicationUserProfile(ref ApplicationUserProfile value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{			
		            fillApplicationUserProfile(ref value, dataReader);
					result = true;
				}
				else
				{result = false;}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;			
		}
		#endregion

//		============================== Public Method ==============================	
		public bool FillApplicationUserProfileList(ref ApplicationUserProfileList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getOrderby());

			return fillApplicationUserProfileList(ref value, stringBuilder.ToString());
		}

		public bool FillExcludeApplicationUserProfileList(ref ApplicationUserProfileList value, ApplicationUserProfile aApplicationUserProfile)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getExcludeEntityCondition(aApplicationUserProfile));
			stringBuilder.Append(getOrderby());

			return fillApplicationUserProfileList(ref value, stringBuilder.ToString());
		}

		public bool FillApplicationUserProfile(ref ApplicationUserProfile value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(getEntityCondition(value));
			return fillApplicationUserProfile(ref value, stringBuilder.ToString());
		}

		public bool InsertApplicationUserProfile(ApplicationUserProfile value)
		{
			SqlCommand command = new SqlCommand(getSQLInsert(value));
			SqlParameter parameter = new SqlParameter("@User_Password", System.Data.SqlDbType.VarChar, 20, "User_Password");
			parameter.Value = value.Password;
			command.Parameters.Add(parameter);

			if (tableAccess.ExecuteSQL(command)>0)
			{return true;}
			else
			{return false;}
		}

		public bool UpdateApplicationUserProfile(ApplicationUserProfile value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value));
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition(value));

			SqlCommand command = new SqlCommand(stringBuilder.ToString());
			SqlParameter parameter = new SqlParameter("@User_Password", System.Data.SqlDbType.VarChar, 20, "User_Password");
			parameter.Value = value.Password;
			command.Parameters.Add(parameter);

			if (tableAccess.ExecuteSQL(command)>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteApplicationUserProfile(ApplicationUserProfile value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	
	}
}
