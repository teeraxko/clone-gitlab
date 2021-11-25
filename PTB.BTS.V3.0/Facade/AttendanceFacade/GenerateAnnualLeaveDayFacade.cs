using System;

using Entity.AttendanceEntities;

using Flow.AttendanceFlow;
using PTB.BTS.Report.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class GenerateAnnualLeaveDayFacade : CommonPIFacadeBase
	{
		#region - Private -
			private GenerateAnnualLeaveDayFlow flowGenerateAnnualLeaveDay;
			private TrNewAnnualLeaveDaysFlow flowNewAnnualLeaveDays;
		#endregion

		private AnnualLeaveDualHeadList annualLeaveDualHeadList;
		public AnnualLeaveDualHeadList AnnualLeaveDualHeadList
		{
			get{return annualLeaveDualHeadList;}
		}

		public DateTime ValidTimeFrom
		{
			set{annualLeaveDualHeadList.LeaveControl.ValidPeriod.From = value;}
		}

		public DateTime ValidTimeTo
		{
			set{annualLeaveDualHeadList.LeaveControl.ValidPeriod.To = value;}
		}

		//==============================  Constructor  ==============================
		public GenerateAnnualLeaveDayFacade() : base()
		{
			flowGenerateAnnualLeaveDay = new GenerateAnnualLeaveDayFlow();
		}

		//============================== Public Method ==============================
		public bool FillAnnualLeaveHeadList(int forYear)
		{
			AnnualLeaveControl annualLeaveControl = flowGenerateAnnualLeaveDay.GetAnnualLeaveControl(forYear, GetCompany());
			annualLeaveDualHeadList = new AnnualLeaveDualHeadList(annualLeaveControl, GetCompany());

			return flowGenerateAnnualLeaveDay.FillAnnualLeaveHeadList(annualLeaveDualHeadList);
		}

		public bool InsertAnnualLeaveDualHeadList()
		{
			return flowGenerateAnnualLeaveDay.InsertAnnualLeaveDualHeadList(annualLeaveDualHeadList);
		}

		public bool PrintTrNewAnnualLeaveDays()
		{
			bool result = false;
			flowNewAnnualLeaveDays = new TrNewAnnualLeaveDaysFlow();

			if(annualLeaveDualHeadList != null && annualLeaveDualHeadList.Count != 0)
			{
				result = flowNewAnnualLeaveDays.PrintTrNewAnnualLeaveDays(annualLeaveDualHeadList);
			}
			return result;
		}
	}
}
