using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;
using DataAccess.PiDB;

namespace DataAccess.PiDB
{
	public class PositionGroupDB : DualFieldCompanyDBBase
	{
		#region - Private -	
//		private PositionGroup objPositionGroup;
		#endregion

//		============================== Constructor ==============================
		public PositionGroupDB() : base() 
		{
			tableName = "Position_Group";
			codeColumnName = "Position_Group";
			descColumnNameEng = "English_Description";
			descColumnNameThai = "Thai_Description";
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new PositionGroup();
		}
	}
}
