using System;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;

namespace DataAccess.AttendanceDB
{	
	public class MiscBenefitDescriptionDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public MiscBenefitDescriptionDB() : base()
		{
			tableName = "Misc_Benefit_Description";
			descColumnName = "Benefit_Description";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new MiscBenefitDescription();
		}
	}
}
