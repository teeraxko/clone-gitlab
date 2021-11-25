using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.ContractEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

namespace DataAccess.ContractDB
{
	public class ContractTypeDB : DualFieldCompanyDBBase
	{
//		============================== Constructor ==============================
		public ContractTypeDB(): base()
		{
			tableName = "Contract_Type";
			codeColumnName = "Contract_Type";
			descColumnNameEng = "English_Description";
			descColumnNameThai = "Thai_Description";
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new ContractType();
		}
	}
}