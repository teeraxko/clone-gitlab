using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using ictus.Common.Entity.General;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.CommonDB
{
	public abstract class SingleFieldDBBase : MTBDBBase
	{ 
		#region - Constant -
			protected const int DESCRIPTION = 0;
		#endregion

		#region - Protected -
			protected string tableName;
			protected string descColumnName;

        protected abstract ictus.Common.Entity.General.SingleFieldBase getNew();
        protected ictus.Common.Entity.General.SingleFieldBase objSingleField;
			
		#endregion

//		============================== Constructor ==============================
		protected SingleFieldDBBase() : base()
		{
		}

//		============================== Private Method ==============================

		#region - getSQL -
		protected string getSQLSelect()
		{
			StringBuilder stringBuilder = new StringBuilder(" SELECT ");
			stringBuilder.Append(descColumnName);
			stringBuilder.Append(" FROM ");
			stringBuilder.Append(tableName);

			return stringBuilder.ToString();
		}

		protected string getSQLInsert(SingleFieldBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO ");
			stringBuilder.Append(tableName);
			stringBuilder.Append(" ( ");

			stringBuilder.Append(descColumnName);
			stringBuilder.Append(" , Process_Date, Process_User) ");

			stringBuilder.Append(" VALUES ( ");
			stringBuilder.Append(GetDB(value.Name));
			stringBuilder.Append(" , ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(" , ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(" ) ");			

			return stringBuilder.ToString();
		}

		protected string getSQLUpdate(SingleFieldBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(" UPDATE ");
			stringBuilder.Append(tableName);
			stringBuilder.Append(" SET ");

			stringBuilder.Append(descColumnName);
			stringBuilder.Append(" = ");
			stringBuilder.Append(GetDB(value.Name));
			stringBuilder.Append(" , ");

			stringBuilder.Append(" Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(" , ");
			
			stringBuilder.Append(" Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));

			return stringBuilder.ToString();
		}

		protected string getSQLDelete()
		{
			StringBuilder stringBuilder = new StringBuilder(" DELETE FROM ");
			stringBuilder.Append(tableName);
			return stringBuilder.ToString();
		}

		protected string getKeyCondition(SingleFieldBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(" WHERE ( ");
			stringBuilder.Append(descColumnName);
			stringBuilder.Append(" = ");
			stringBuilder.Append(GetDB(value.Name));
			stringBuilder.Append(" )");
			return stringBuilder.ToString();
		}

		protected string getOrderby()
		{
			StringBuilder stringBuilder = new StringBuilder(" ORDER BY ");
			stringBuilder.Append(descColumnName);

			return stringBuilder.ToString();
		}
		#endregion

		#region - Fill -
        protected virtual void fillSingleFieldBase(ref ictus.Common.Entity.General.SingleFieldBase value, SqlDataReader dataReader)
		{
			value.Name = (string)dataReader[DESCRIPTION];
		}

		private bool fillSingleFieldBaseData(ictus.Common.Entity.General.ListBase value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objSingleField = getNew();
					fillSingleFieldBase(ref objSingleField, dataReader);
					value.Add(objSingleField);
				}
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

//		============================== Public Method ==============================
		public override object GetMTB(string code)
		{
            ictus.Common.Entity.General.SingleFieldBase singleField = getNew();
			singleField.Name = code;
			return singleField;
		}

		public override bool FillMTB(object value)
		{
			return false;
		}
        
		public override bool FillMTBList(ictus.Common.Entity.General.ListBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getOrderby());
			return fillSingleFieldBaseData(value, stringBuilder.ToString());
		}

		public override bool InsertMTB(object value)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert((SingleFieldBase)value))>0)
			{return true;}
			else
			{return false;}	
		}

		public override bool UpdateMTB(object value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(getSQLDelete());
			stringBuilder.Append(getKeyCondition((SingleFieldBase)value));
			stringBuilder.Append(" ");
			stringBuilder.Append(getSQLInsert((SingleFieldBase)value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public override bool DeleteMTB(object value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getKeyCondition((SingleFieldBase)value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	}
}
