using System;
using System.Text;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;
using SystemFramework.AppException;

namespace DataAccess.PiDB
{
	public abstract class DualFieldCompanyDBBase : DualFieldDBBase
	{
		protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return null;
		}
//		============================== Constructor ==============================
		protected DualFieldCompanyDBBase() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLInsert(DualFieldBase value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO ");
			stringBuilder.Append(tableName);
			
			stringBuilder.Append(" (Company_Code, ");

			stringBuilder.Append(codeColumnName);			
			stringBuilder.Append(" , ");


			stringBuilder.Append(descColumnNameThai);
			stringBuilder.Append(" , ");

			stringBuilder.Append(descColumnNameEng);
			stringBuilder.Append(" , ");

			stringBuilder.Append(" Process_Date, Process_User ) ");

			stringBuilder.Append(" VALUES ( ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(" , ");

			stringBuilder.Append(GetDB(value.Code));
			stringBuilder.Append(" , ");

			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(" , ");

			stringBuilder.Append(GetDB(value.AName.English));
			stringBuilder.Append(", ");
			
			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(" ) ");

			return stringBuilder.ToString();
		}
		#endregion

//		============================== Public Method ==============================
        public ictus.Common.Entity.General.DualFieldBase GetDualField(string code, Company aCompany)
		{
            ictus.Common.Entity.General.DualFieldBase dualField = getNew();
			dualField.Code = code;

			if(FillMTB(dualField, aCompany))
			{
				return dualField;
			}
			else
			{
				dualField = null;
				return null;
			}
		}

        internal ictus.Common.Entity.General.DualFieldBase GetDBDualField(string code, Company aCompany)
		{
            ictus.Common.Entity.General.DualFieldBase dualField = getNew();
			dualField.Code = code;

			if(FillMTB(dualField, aCompany))
			{
				return dualField;
			}
			else
			{
				dualField.Code = NullConstant.STRING;
				return dualField;
			}			
		}

		public bool FillMTB(object value, Company aCompany)
		{
            ictus.Common.Entity.General.DualFieldBase dualField = (ictus.Common.Entity.General.DualFieldBase)value;

			StringBuilder stringBuilder = new StringBuilder(base.getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(dualField));
			stringBuilder.Append(getEntityCondition(dualField));
			return fillDualFieldBase(ref dualField, stringBuilder.ToString());
		}

		public bool FillMTBData(CompanyStuffBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(base.getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(base.getOrderby());

			return fillDualFieldBaseData(value, stringBuilder.ToString());
		}

		public bool InsertMTB(Object value, Company aCompany)
		{
            ictus.Common.Entity.General.DualFieldBase dualField = getNew();
            ictus.Common.Entity.Description description = new ictus.Common.Entity.Description();
            description.Thai = ((ictus.Common.Entity.General.DualFieldBase)value).AName.Thai;
			dualField.AName = description;
			if(FillMTB(dualField, aCompany))
			{
				throw new DuplicateException("ª×èÍÀÒÉÒä·Â", true);
			}
            if (((ictus.Common.Entity.General.DualFieldBase)value).AName.English.Trim() != "")
			{
				dualField = getNew();
                description.English = ((ictus.Common.Entity.General.DualFieldBase)value).AName.English;
                dualField.AName = description;
				if(FillMTB(dualField, aCompany))
				{
					throw new DuplicateException("ª×èÍÀÒÉÒÍÑ§¡ÄÉ", false);
				}
			}

            if (tableAccess.ExecuteSQL(getSQLInsert((DualFieldBase)value, aCompany)) > 0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateMTB(Object value, Company aCompany)
		{
            ictus.Common.Entity.General.DualFieldBase dualField = getNew();
            ictus.Common.Entity.Description description = new ictus.Common.Entity.Description();
            description.Thai = ((ictus.Common.Entity.General.DualFieldBase)value).AName.Thai;
            dualField.AName = description;
            if (FillMTB(dualField, aCompany) && dualField.Code.Trim() != ((ictus.Common.Entity.General.DualFieldBase)value).Code.Trim())
			{
				throw new DuplicateException("ª×èÍÀÒÉÒä·Â", true);
			}

            if (((ictus.Common.Entity.General.DualFieldBase)value).AName.English != "")
			{
				dualField = getNew();
                description.English = ((ictus.Common.Entity.General.DualFieldBase)value).AName.English;
                dualField.AName = description;
                if (FillMTB(dualField, aCompany) && dualField.Code.Trim() != ((ictus.Common.Entity.General.DualFieldBase)value).Code.Trim())
				{
					throw new DuplicateException("ª×èÍÀÒÉÒÍÑ§¡ÄÉ", false);
				}
			}
            StringBuilder stringBuilder = new StringBuilder(base.getSQLUpdate((DualFieldBase)value));

			stringBuilder.Append(" , Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));

			stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition((ictus.Common.Entity.General.DualFieldBase)value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
				{return true;}
			else
				{return false;}
		}

		public bool DeleteMTB(Object value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition((DualFieldBase)value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	}
}
