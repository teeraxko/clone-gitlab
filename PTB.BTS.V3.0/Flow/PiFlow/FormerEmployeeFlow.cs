using System;

using ictus.PIS.PI.Entity;

using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.PI.Flow
{
	public class FormerEmployeeFlow : FlowBase
	{
		#region - Private -
		private FormerEmployeeDB dbFormerEmployee;
		#endregion
		
//		================================Constructor=====================
		public FormerEmployeeFlow()
		{
			dbFormerEmployee = new FormerEmployeeDB();
		}

//		================================public Method=====================
		public bool FillFormerEmployee(EmployeeList aEmployeeList)
		{
			return dbFormerEmployee.FillFormerEmployeeList(ref aEmployeeList);
		}

		public bool InsertFormerEmployee(EmployeeInfo value)
		{
			return dbFormerEmployee.InsertFormerEmployee(value);
		}
	}
}

