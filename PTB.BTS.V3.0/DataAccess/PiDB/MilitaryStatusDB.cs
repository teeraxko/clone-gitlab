using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

namespace DataAccess.PiDB
{
	public class MilitaryStatusDB : DualFieldDBBase
	{
//		============================== Constructor ==============================
		public MilitaryStatusDB() : base()
		{
			tableName = "Military_Status";
			codeColumnName = "Military_Status";
			descColumnNameThai = "Thai_Description";
			descColumnNameEng = "English_Description";
	
//			DummyCode = "Z";
		} 

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new MilitaryStatus();
		}
	}
}
