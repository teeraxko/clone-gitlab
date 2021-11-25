using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.Common.Entity.General;

using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;
using SystemFramework.AppException;

namespace DataAccess.CommonDB
{
	public abstract class DualFieldDBBase : MTBDBBase
	{ 
		#region - Constant -
		private const int CODE = 0;
		private const int DESCRIPTION_THAI = 1;
		private const int DESCRIPTION_ENG = 2;
		#endregion

		#region - Protected -
		protected string tableName;
		protected string codeColumnName;
		protected string descColumnNameThai;
		protected string descColumnNameEng;

		protected abstract ictus.Common.Entity.General.DualFieldBase getNew();
        protected ictus.Common.Entity.General.DualFieldBase objDualFieldBase;

		protected string DummyCode;
		#endregion

//		============================== Constructor ==============================
		protected DualFieldDBBase() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		protected string getSQLSelect()
		{
			StringBuilder stringBuilder = new StringBuilder(" SELECT ");
			stringBuilder.Append(codeColumnName);
			stringBuilder.Append(" , ");
			stringBuilder.Append(descColumnNameThai);
			stringBuilder.Append(" , ");
			stringBuilder.Append(descColumnNameEng);
			stringBuilder.Append(" FROM ");
			stringBuilder.Append(tableName);

			return stringBuilder.ToString();
		}

		protected string getSQLInsert(DualFieldBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO ");
			stringBuilder.Append(tableName);
			stringBuilder.Append(" ( ");
			stringBuilder.Append(codeColumnName);	
			stringBuilder.Append(" , ");

			stringBuilder.Append(descColumnNameThai);
			stringBuilder.Append(" , ");

			stringBuilder.Append(descColumnNameEng);
			stringBuilder.Append(" , ");

			stringBuilder.Append("Process_Date");
			stringBuilder.Append(" , ");

			stringBuilder.Append("Process_User");
			stringBuilder.Append(" ) ");

			stringBuilder.Append(" VALUES ( ");
			stringBuilder.Append(GetDB(value.Code));
			stringBuilder.Append(" , ");

			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(" , ");

			stringBuilder.Append(GetDB(value.AName.English));
			stringBuilder.Append(" , ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(" ) ");

			return stringBuilder.ToString();
		}

		protected string getSQLUpdate(DualFieldBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(" UPDATE ");
			stringBuilder.Append(tableName);
			stringBuilder.Append(" SET ");

			stringBuilder.Append(codeColumnName);
			stringBuilder.Append(" = ");
			stringBuilder.Append(GetDB(value.Code));
			stringBuilder.Append(" , ");	

			stringBuilder.Append(descColumnNameThai);
			stringBuilder.Append(" = ");
			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(" , ");

			stringBuilder.Append(descColumnNameEng);
			stringBuilder.Append(" = ");
			stringBuilder.Append(GetDB(value.AName.English));
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

        protected string getKeyCondition(ictus.Common.Entity.General.DualFieldBase value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(value.Code != "")
			{
				stringBuilder.Append(" AND ( ");
				stringBuilder.Append(codeColumnName);
				stringBuilder.Append(" = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(" ) ");
			}
			return stringBuilder.ToString();
		}

        protected string getEntityCondition(ictus.Common.Entity.General.DualFieldBase value)
		{
			StringBuilder stringBuilder = new StringBuilder();

            if (value.AName != null)
            {
                if (value.AName.Thai != "")
                {
                    stringBuilder.Append(" AND ( ");
                    stringBuilder.Append(descColumnNameThai);
                    stringBuilder.Append(" = ");
                    stringBuilder.Append(GetDB(value.AName.Thai));
                    stringBuilder.Append(" ) ");
                }
                if (value.AName.English != "")
                {
                    stringBuilder.Append(" AND ( ");
                    stringBuilder.Append(descColumnNameEng);
                    stringBuilder.Append(" = ");
                    stringBuilder.Append(GetDB(value.AName.English));
                    stringBuilder.Append(" ) ");
                }
            }            
			
			return stringBuilder.ToString();
		}

		protected virtual string getOrderby()
		{
			StringBuilder stringBuilder = new StringBuilder(" ORDER BY ");
			stringBuilder.Append(codeColumnName);
			return stringBuilder.ToString();
		}
		#endregion

		#region - Fill -
        private void fillDualFieldBase(ref ictus.Common.Entity.General.DualFieldBase value, SqlDataReader dataReader)
		{
			value.Code = ((string)dataReader[CODE]).Trim();
            ictus.Common.Entity.Description description = new ictus.Common.Entity.Description();
            description.Thai = (string)dataReader[DESCRIPTION_THAI];
            description.English = (string)dataReader[DESCRIPTION_ENG];
            value.AName = description;
		}

		protected bool fillDualFieldBaseData(ictus.Common.Entity.General.ListBase value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objDualFieldBase = getNew();
					fillDualFieldBase(ref objDualFieldBase, dataReader);
					value.Add(objDualFieldBase);
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

        protected bool fillDualFieldBase(ref ictus.Common.Entity.General.DualFieldBase value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillDualFieldBase(ref value, dataReader);
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
		public override object GetMTB(string code)
		{
            ictus.Common.Entity.General.DualFieldBase dualField = getNew();
			dualField.Code = code;
			FillMTB(dualField);
			return dualField;
		}

		public override bool FillMTB(object value)
		{
            ictus.Common.Entity.General.DualFieldBase dualField = (ictus.Common.Entity.General.DualFieldBase)value;
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition(dualField));
			stringBuilder.Append(getEntityCondition(dualField));
			return fillDualFieldBase(ref dualField, stringBuilder.ToString());
		}

		public override bool FillMTBList(ictus.Common.Entity.General.ListBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getOrderby());
			return fillDualFieldBaseData(value, stringBuilder.ToString());
		}

		public override bool InsertMTB(object value)
		{
            ictus.Common.Entity.General.DualFieldBase dualField = getNew();
            ictus.Common.Entity.Description description = new ictus.Common.Entity.Description();
            description.Thai = ((DualFieldBase)value).AName.Thai;
			dualField.AName = description;
			if(FillMTB(dualField))
			{
				throw new DuplicateException("ª×èÍÀÒÉÒä·Â", true);
			}
            if (((ictus.Common.Entity.General.DualFieldBase)value).AName.English.Trim() != "")
			{
				dualField = getNew();
                description.Thai = ((ictus.Common.Entity.General.DualFieldBase)value).AName.English;
                dualField.AName = description;
				if(FillMTB(dualField))
				{
					throw new DuplicateException("ª×èÍÀÒÉÒÍÑ§¡ÄÉ", false);
				}
			}

			return (tableAccess.ExecuteSQL(getSQLInsert((DualFieldBase)value))>0);
		}

		public override bool UpdateMTB(object value)
		{
            ictus.Common.Entity.General.DualFieldBase dualField = getNew();
            ictus.Common.Entity.Description description = new ictus.Common.Entity.Description();
            description.Thai = ((ictus.Common.Entity.General.DualFieldBase)value).AName.Thai;
            dualField.AName = description;
            if (FillMTB(dualField) && dualField.Code.Trim() != ((ictus.Common.Entity.General.DualFieldBase)value).Code.Trim())
			{
				throw new DuplicateException("ª×èÍÀÒÉÒä·Â", true);
			}

            if (((ictus.Common.Entity.General.DualFieldBase)value).AName.English != "")
			{
				dualField = getNew();
                description.Thai = ((ictus.Common.Entity.General.DualFieldBase)value).AName.English;
                dualField.AName = description;
                if (FillMTB(dualField) && dualField.Code.Trim() != ((ictus.Common.Entity.General.DualFieldBase)value).Code.Trim())
				{
					throw new DuplicateException("ª×èÍÀÒÉÒÍÑ§¡ÄÉ", false);
				}
			}

			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate((DualFieldBase)value));
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition((DualFieldBase)value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public override bool DeleteMTB(object value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition((DualFieldBase)value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	}
}
