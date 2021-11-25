using System;
using System.Text;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using SystemFramework.AppException;

using ictus.Common.Entity.General; 

namespace DataAccess.VehicleDB
{
	public class ColorDB : DualFieldDBBase
	{
		//		============================== Constructor ==============================
		public ColorDB() : base()
		{
			tableName = "Color";
			codeColumnName = "Color_Code";
			descColumnNameThai = "Thai_Color_Name";
			descColumnNameEng = "English_Color_Name";	
		}

		//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Color();
		}

		protected override string getOrderby()
		{
			return " ORDER BY English_Color_Name ";
		}

		public override bool InsertMTB(object value)
		{
            ictus.Common.Entity.General.DualFieldBase dualField;
//				= getNew();
//			dualField.AName.Thai = ((DualFieldBase)value).AName.Thai;
//			if(FillMTB(dualField))
//			{
//				throw new DuplicateException("ª×èÍÀÒÉÒä·Â", true);
//			}
            if (((ictus.Common.Entity.General.DualFieldBase)value).AName.English.Trim() != "")
			{
				dualField = getNew();
                ictus.Common.Entity.Description description = new ictus.Common.Entity.Description();
                description.English = ((ictus.Common.Entity.General.DualFieldBase)value).AName.English;
                dualField.AName = description;
				if(FillMTB(dualField))
				{
					throw new DuplicateException("ª×èÍÀÒÉÒÍÑ§¡ÄÉ", false);
				}
			}

            return (tableAccess.ExecuteSQL(getSQLInsert((DualFieldBase)value)) > 0);
		}

		public override bool UpdateMTB(object value)
		{
            ictus.Common.Entity.General.DualFieldBase dualField;
//			= getNew();
//			dualField.AName.Thai = ((DualFieldBase)value).AName.Thai;
//			if(FillMTB(dualField) && dualField.Code.Trim() != ((DualFieldBase)value).Code.Trim())
//			{
//				throw new DuplicateException("ª×èÍÀÒÉÒä·Â", true);
//			}

            if (((ictus.Common.Entity.General.DualFieldBase)value).AName.English != "")
			{
				dualField = getNew();
                ictus.Common.Entity.Description description = new ictus.Common.Entity.Description();
                description.English = ((ictus.Common.Entity.General.DualFieldBase)value).AName.English;
                dualField.AName = description;
                if (FillMTB(dualField) && dualField.Code.Trim() != ((ictus.Common.Entity.General.DualFieldBase)value).Code.Trim())
				{
					throw new DuplicateException("ª×èÍÀÒÉÒÍÑ§¡ÄÉ", false);
				}
			}

            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate((DualFieldBase)value));
			stringBuilder.Append(getBaseCondition());
            stringBuilder.Append(getKeyCondition((ictus.Common.Entity.General.DualFieldBase)value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	}
}
