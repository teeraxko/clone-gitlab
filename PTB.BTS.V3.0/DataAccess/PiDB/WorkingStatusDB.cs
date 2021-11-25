using System;
using System.Text;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

namespace DataAccess.PiDB
{
	public class WorkingStatusDB : DualFieldCompanyDBBase
	{
//		============================== Constructor ==============================
		public WorkingStatusDB() : base()
		{ 
			tableName = "Working_Status";
			codeColumnName = "Working_Status";
			descColumnNameThai = "Thai_Description";
			descColumnNameEng = "English_Description";	
		}

//		============================== Protected Method ==============================
		protected override string getOrderby()
		{
			StringBuilder stringBuilder = new StringBuilder(" ORDER BY ");
			stringBuilder.Append(descColumnNameThai);
			return stringBuilder.ToString();
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new WorkingStatus();
		}
	}
}
