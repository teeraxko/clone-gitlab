using System;

using Entity.CommonEntity;
using Entity.ContractEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

namespace DataAccess.ContractDB
{
	public class ContractStatusDB : DualFieldCompanyDBBase
	{
//		============================== Constructor ==============================
		public ContractStatusDB() : base()
		{
			tableName = "Contract_Status";
			codeColumnName = "Contract_Status";
			descColumnNameEng = "English_Description";
			descColumnNameThai = "Thai_Description";
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new ContractStatus();
		}
	}
}
