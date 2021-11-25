using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using DataAccess.CommonDB;

using Entity.CommonEntity;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

namespace DataAccess.PiDB
{
	public class PositionTypeDB : DataAccessBase
	{
		#region - Constant -
		private const int POSITION_TYPE_CODE = 0;
		private const int THAI_DESCRIPTION = 1;
		private const int ENGLISH_DESCRIPTION = 2;
		#endregion

		#region - Private -	
		private bool disposed = false;
		private PositionType objPositionType;
		#endregion

//		============================== Constructor ==============================
		public PositionTypeDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Position_Type, Thai_Description, English_Description FROM Position_Type ";
		}

		private string getKeyCondition(PositionType aPositionType)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(aPositionType.Type))
			{
				stringBuilder.Append(" AND (Position_Type = ");
				stringBuilder.Append(GetDB(aPositionType.Type));
				stringBuilder.Append(")");
			}			
			return stringBuilder.ToString();
		}
		private string getOrderby()
		{
			return " ORDER BY Position_Type ";
		}
		#endregion

		#region - Fill -
		private void fillPositionType(ref PositionType aPositionType, SqlDataReader dataReader)
		{
			aPositionType.Type = (string)dataReader[POSITION_TYPE_CODE];
			aPositionType.ADescription.Thai = (string)dataReader[THAI_DESCRIPTION];
			aPositionType.ADescription.English = (string)dataReader[ENGLISH_DESCRIPTION];
		}

		private bool fillPositionTypeList(ref PositionTypeList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objPositionType = new PositionType();
					fillPositionType(ref objPositionType, dataReader);
					value.Add(objPositionType);
				}
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;
		}

		private bool fillPositionType(ref PositionType value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillPositionType(ref value, dataReader);
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
		public PositionType GetPositionType(string positionType, Company aCompany)
		{			
			objPositionType = new PositionType();
			objPositionType.Type = positionType;
			if(FillPositionType(ref objPositionType, aCompany))
			{
				return objPositionType;
			}
			else
			{
				objPositionType = null;
				return null;			
			}
		}

		internal PositionType GetDBPositionType(string positionCode, Company aCompany)
		{			
			objPositionType = new PositionType();
			objPositionType.Type = positionCode;
			if(FillPositionType(ref objPositionType, aCompany))
			{
				return objPositionType;
			}
			else
			{
				objPositionType.Type = NullConstant.STRING;
				return objPositionType;			
			}
		}

		public bool FillPositionType(ref PositionType value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return fillPositionType(ref value, stringBuilder.ToString());
		}

		public bool FillPositionTypeList(ref PositionTypeList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillPositionTypeList(ref value, stringBuilder.ToString());	
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
						objPositionType = null;					
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
