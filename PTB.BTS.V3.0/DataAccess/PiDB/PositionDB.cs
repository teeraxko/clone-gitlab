using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using DataAccess.CommonDB;
using DataAccess.PiDB;

using Entity.CommonEntity;

using SystemFramework.AppConfig;
using SystemFramework.AppException;

using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

namespace DataAccess.PiDB
{
	public class PositionDB : DataAccessBase
	{
		#region - Constant -
			private const int POSITION_CODE = 0;
			private const int ENGLISH_NAME = 1;
			private const int THAI_NAME = 2;
			private const int SHORT_NAME = 3;
			private const int POSITION_TYPE = 4;
			private const int POSITION_ROLE = 5;
			private const int POSITION_GROUP = 6;
			private const int POSITION_ALLOWANCE = 7;		
		#endregion

		#region - Private -	
		private bool disposed = false;
		private PositionTypeDB dbPositionType;
		private PositionGroupDB dbPositionGroup;
		private Position objPosition;
		#endregion

//		============================== Constructor ==============================
		public PositionDB() : base()
		{
			dbPositionType = new PositionTypeDB();
			dbPositionGroup = new PositionGroupDB();
		}
//		============================== Private Method ==============================
		#region - gerSQL -
		private string getSQLSelect()
		{
			return "SELECT Position_Code, English_Name, Thai_Name, Short_Name, Position_Type, Position_Role, Position_Group, Position_Allowance FROM Position ";
		}

		private string getSQLInsert(Position aPosition, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Position (Company_Code, Position_Code, English_Name, Thai_Name, Short_Name, Position_Type, Position_Role, Position_Group, Position_Allowance, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Position_Code			
			stringBuilder.Append(GetDB(aPosition.PositionCode));
			stringBuilder.Append(", ");

			//English_Name
			stringBuilder.Append(GetDB(aPosition.AName.English));
			stringBuilder.Append(", ");

			//Thai_Name
			stringBuilder.Append(GetDB(aPosition.AName.Thai));
			stringBuilder.Append(", ");

			//Short_Name
			stringBuilder.Append(GetDB(aPosition.ShortName));
			stringBuilder.Append(", ");

			//Position_Type
			stringBuilder.Append(GetDB(aPosition.APositionType.Type));
			stringBuilder.Append(", ");

			//Position_Role
			stringBuilder.Append(GetDB(aPosition.APositionRole));
			stringBuilder.Append(", ");

			//Position_Group
			stringBuilder.Append(GetDB(aPosition.APositionGroup.Code));
			stringBuilder.Append(", ");
			
			//Position_Allowance
			stringBuilder.Append(GetDB(aPosition.Allowance));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(Position aPosition, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Position SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Position_Code = ");
			stringBuilder.Append(GetDB(aPosition.PositionCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("English_Name = ");
			stringBuilder.Append(GetDB(aPosition.AName.English));
			stringBuilder.Append(", ");
	
			stringBuilder.Append("Thai_Name = ");
			stringBuilder.Append(GetDB(aPosition.AName.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Short_Name = ");
			stringBuilder.Append(GetDB(aPosition.ShortName));
			stringBuilder.Append(", ");

			stringBuilder.Append("Position_Type = ");
			stringBuilder.Append(GetDB(aPosition.APositionType.Type));
			stringBuilder.Append(", ");
	
			stringBuilder.Append("Position_Role = ");
			stringBuilder.Append(GetDB(aPosition.APositionRole));
			stringBuilder.Append(", ");

			stringBuilder.Append("Position_Group = ");
			stringBuilder.Append(GetDB(aPosition.APositionGroup.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("Position_Allowance = ");
			stringBuilder.Append(GetDB(aPosition.Allowance));
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
			return " DELETE FROM Position ";
		}		

		private string getKeyCondition(Position value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.PositionCode))
			{
				stringBuilder.Append(" AND (Position_Code = ");
				stringBuilder.Append(GetDB(value.PositionCode));
				stringBuilder.Append(" ) ");
			}
			return stringBuilder.ToString();	
		}

		private string getEntityCondition(Position value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.APositionRole))
			{
				if(value.APositionRole == POSITION_ROLE_TYPE.BLANK)
				{
					stringBuilder.Append(" AND NOT(Position_Role = 'D') AND NOT(Position_Role = 'M') ");
				}
				else
				{
					stringBuilder.Append(" AND (Position_Role = ");
					stringBuilder.Append(GetDB(value.APositionRole));
					stringBuilder.Append(" ) ");
				}
			}
			return stringBuilder.ToString();	
		}
		
		private string getOrderby()
		{
			return " ORDER BY Thai_Name";
//				Position_Code";
		}
		#endregion

		#region - Fill -
		private void fillPosition(ref Position value, Company aCompany, SqlDataReader dataReader)
		{
			value.PositionCode = (string)dataReader[POSITION_CODE];
			value.AName.English = (string)dataReader[ENGLISH_NAME];
			value.AName.Thai = (string)dataReader[THAI_NAME];
			value.ShortName = (string)dataReader[SHORT_NAME];
			value.APositionType = dbPositionType.GetDBPositionType((string)dataReader[POSITION_TYPE], aCompany);
			value.APositionRole = CTFunction.GetPositionRoleType((string)dataReader[POSITION_ROLE]);
			value.APositionGroup = (PositionGroup)dbPositionGroup.GetDBDualField((string)dataReader[POSITION_GROUP], aCompany);
			value.Allowance = dataReader.GetDecimal(POSITION_ALLOWANCE);
		}

		private bool fillPositionList(ref PositionList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objPosition = new Position();
					fillPosition(ref objPosition, value.Company, dataReader);
					value.Add(objPosition);
				}
				objPosition = null;
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			return result;
		}
		
		private bool fillPosition(ref Position value, Company aCompany, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillPosition(ref value, aCompany, dataReader);
					result = true;
				}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			return result;
		}
		#endregion

//		============================== Public Method ==============================
		public Position GetPosition(string positionCode, Company aCompany)
		{
			objPosition = new Position();
			objPosition.PositionCode = positionCode;
			if(FillPosition(ref objPosition, aCompany))
			{
				return objPosition;
			}
			else 
			{
				objPosition = null;
				return null;
			}
		}

		internal Position GetDBPosition(string positionCode, Company aCompany)
		{
			objPosition = new Position();
			objPosition.PositionCode = positionCode;
			if(FillPosition(ref objPosition, aCompany))
			{
				return objPosition;
			}
			else 
			{
				objPosition.PositionCode = NullConstant.STRING;
				return objPosition;
			}
		}

		public bool FillPosition(ref Position value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(getEntityCondition(value));
			return fillPosition(ref value, aCompany, stringBuilder.ToString());
		}

		public bool FillPositionList(ref PositionList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillPositionList(ref value, stringBuilder.ToString());	
		}

		public bool FillPositionList(ref PositionList aPositionList, Position aPosition)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aPositionList.Company));
			stringBuilder.Append(getKeyCondition(aPosition));
			stringBuilder.Append(getEntityCondition(aPosition));
			stringBuilder.Append(getOrderby());

			return fillPositionList(ref aPositionList, stringBuilder.ToString());	
		}

		public bool InsertPosition(Position aPosition, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(aPosition, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdatePosition(Position value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeletePosition(Position value, Company aCompany)
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
						dbPositionType.Dispose();
						dbPositionGroup.Dispose();

						dbPositionType = null;
						dbPositionGroup = null;
						objPosition = null;
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