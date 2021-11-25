using System;

using ictus.PIS.PI.Entity;

using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.PI.Flow
{
	public class EducationFlow : FlowBase
	{
		#region - Private -
		private EmployeeEducationDB dbEmployeeEducation;
		#endregion
		
//  ================================Constructor=====================
		public EducationFlow()
		{
			dbEmployeeEducation = new EmployeeEducationDB();
		}
//  ================================public Method=====================
		public bool FillEmployeeEducationList(ref EmployeeEducation value)
		{
			return dbEmployeeEducation.FillEmployeeEducationList(ref value);
		}
	}
}
