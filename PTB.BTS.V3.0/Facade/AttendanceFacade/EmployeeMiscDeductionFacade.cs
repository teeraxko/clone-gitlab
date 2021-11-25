using System;
using Flow.AttendanceFlow;

namespace Facade.AttendanceFacade
{
	public class EmployeeMiscDeductionFacade : EmployeeMiscBenefitFacade
	{
		public EmployeeMiscDeductionFacade() : base()
		{
			flowEmployeeMisc = new EmployeeMiscDeductionFlow();
		}
	}
}