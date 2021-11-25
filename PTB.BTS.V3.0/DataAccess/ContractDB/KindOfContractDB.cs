using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.ContractEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

namespace DataAccess.ContractDB
{
	public class KindOfContractDB : DualFieldCompanyDBBase
	{
//		============================== Constructor ==============================
		public KindOfContractDB(): base()
		{
			tableName = "Kind_Of_Contract";
			codeColumnName = "Kind_Of_Contract";
			descColumnNameEng = "English_Description";
			descColumnNameThai = "Thai_Description";
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new KindOfContract();
		}
	}
}
