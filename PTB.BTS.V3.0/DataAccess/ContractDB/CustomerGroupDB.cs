using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.ContractEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

namespace DataAccess.ContractDB
{
	public class CustomerGroupDB : DualFieldCompanyDBBase
	{
//		============================== Constructor ==============================
		public CustomerGroupDB(): base()
		{
			tableName = "Customer_Group";
			codeColumnName = "Customer_Group_Code";
			descColumnNameEng = "English_Description";
			descColumnNameThai = "Thai_Description";
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new CustomerGroup();
		}
	}
}
