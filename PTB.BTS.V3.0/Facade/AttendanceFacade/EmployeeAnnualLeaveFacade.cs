using System;
using System.Collections;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Flow.AttendanceFlow;

using Facade.CommonFacade;

namespace Facade.AttendanceFacade
{
	public class EmployeeAnnualLeaveFacade : EmployeeAttendanceFacadeBase
	{
		#region - Private -
			private EmployeeAnnualLeaveFlow flowEmployeeAnnualLeave;
			private LeaveReasonFlow flowLeaveReason;			
		#endregion

		public const string Mix = "ทั้งสองปี";

		private AnnualLeave annualLeave;
		public AnnualLeave AnnualLeave
		{
			get{return annualLeave;}
		}

		public ArrayList DataSourceLeaveReason
		{
			get
			{
				LeaveReasonList leaveReasonList = new LeaveReasonList();
				flowLeaveReason.FillMTBList(leaveReasonList);
				return leaveReasonList.GetArrayList();
			}
		}

		public ArrayList DataSourceLeaveYearStatus()
		{
			ArrayList leaveYearStatusArray = new ArrayList();
			int forYear = annualLeave.CurrentAnnualLeave.ForYear;
			if(annualLeave.PreviousAnnualLeave==null)
			{
				leaveYearStatusArray.Add(forYear.ToString());
			}
			else
			{
				if(annualLeave.PreviousAnnualLeave.LeaveHead.RemainDays>0 && annualLeave.CurrentAnnualLeave.LeaveHead.RemainDays>0)
				{
					leaveYearStatusArray.Add(Mix);
				}
				if(annualLeave.PreviousAnnualLeave.LeaveHead.RemainDays>0)
				{
					leaveYearStatusArray.Add((forYear-1).ToString());
				}
				if(annualLeave.CurrentAnnualLeave.LeaveHead.RemainDays>0)
				{
					leaveYearStatusArray.Add(forYear.ToString());
				}
			}
			return leaveYearStatusArray;
		}

		//============================== Constructor ==============================
		public EmployeeAnnualLeaveFacade() : base()
		{
			flowEmployeeAnnualLeave = new EmployeeAnnualLeaveFlow();
			flowLeaveReason = new LeaveReasonFlow();
		}

		//============================== Public Method ==============================
		public bool IsHoliday(DateTime leaveDate)
		{
			return flowEmployeeAnnualLeave.IsHoliday(annualLeave.Employee, leaveDate);
		}

		public bool IsLeave(DateTime leaveDate, LEAVE_PERIOD_TYPE period)
		{
			return flowEmployeeAnnualLeave.IsLeave(annualLeave.Employee, leaveDate, period);
		}
		
		public bool FillEmployeeYearAnnualLeave(DateTime forYear)
		{
			annualLeave = new AnnualLeave();
			return flowEmployeeAnnualLeave.FillEmployeeAnnualLeave(annualLeave, new YearMonth(forYear), Employee);
		}

		public bool InsertAnnualLeave(AnnualLeaveDayList value, DateTime forYear)
		{
			AnnualLeaveDayList tempAnnualLeaveDayList = new AnnualLeaveDayList(value.Employee);
			for(int i=0; i<value.Count; i++)
			{
				tempAnnualLeaveDayList.Add(value[i]);
			}

			value.Clear();

			for(int i=0; i<tempAnnualLeaveDayList.Count; i++)
			{
				if(!IsHoliday(tempAnnualLeaveDayList[i].LeaveDate))
				{
					value.Add(tempAnnualLeaveDayList[i]);
				}	
			}
			
			return flowEmployeeAnnualLeave.InsertAnnualLeave(value, annualLeave, new YearMonth(forYear));
//			if(value.Count==0)
//			{
//				return false;
//			}
//			else
//			{
//				return flowEmployeeAnnualLeave.InsertAnnualLeave(value, annualLeave, new YearMonth(forYear));
//			}
		}

		public bool UpdateAnnualLeave(AnnualLeaveDay value, DateTime forYear)
		{
			return flowEmployeeAnnualLeave.UpdateAnnualLeave(value, annualLeave, new YearMonth(forYear));
		}

		public bool DeleteAnnualLeave(AnnualLeaveDay value, DateTime forYear)
		{
			return flowEmployeeAnnualLeave.DeleteAnnualLeave(value, annualLeave, new YearMonth(forYear));
		}
	}
}