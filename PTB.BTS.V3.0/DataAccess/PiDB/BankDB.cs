using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

namespace DataAccess.PiDB
{
	public class BankDB : DualFieldDBBase
	{
//		============================== Constructor ==============================
		public BankDB() : base()
		{
			tableName = "Bank";
			codeColumnName = "Bank_Code";
			descColumnNameThai = "Thai_Bank_Name";
			descColumnNameEng = "English_Bank_Name";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Bank();
		}
	}
}
