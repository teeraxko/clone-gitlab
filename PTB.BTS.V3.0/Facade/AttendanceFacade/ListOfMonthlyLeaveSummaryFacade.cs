using System;

using Entity.CommonEntity;

using PTB.BTS.Report.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class ListOfMonthlyLeaveSummaryFacade : CommonPIFacadeBase
	{
		#region - Private -
		private ListOfMonthlyLeaveSummaryFlow flowListOfMonthlyLeaveSummary;
		#endregion

//		============================== Constructor ==============================
		public ListOfMonthlyLeaveSummaryFacade() : base()
		{
			flowListOfMonthlyLeaveSummary = new ListOfMonthlyLeaveSummaryFlow();
		}

//		============================== Public Method ==============================
		public bool PrintListOfMonthlyLeaveSummary(DateTime value)
		{
			return flowListOfMonthlyLeaveSummary.PrintListOfMonthlyLeaveSummary(value, GetCompany());
		}
	}
}
