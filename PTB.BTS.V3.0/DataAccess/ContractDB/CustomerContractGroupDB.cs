using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.ContractEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

namespace DataAccess.ContractDB
{
	public class CustomerContractGroupDB : DualFieldCompanyDBBase
	{
//		============================== Constructor ==============================
		public CustomerContractGroupDB(): base()
		{
			tableName = "Customer_Contract_Group";
			codeColumnName = "Customer_Contract_Group_Code";
			descColumnNameEng = "English_Description";
			descColumnNameThai = "Thai_Description";
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new CustomerContractGroup();
		}
	}
}
