using System;

using DataAccess.AttendanceDB;

namespace Flow.AttendanceFlow
{
	public class EmployeeMiscDeductionFlow : EmployeeMiscBenefitFlow
	{
		public EmployeeMiscDeductionFlow() : base()
		{
			dbEmployeeMisc = new EmployeeMiscDeductionDB();
		}
	}
}