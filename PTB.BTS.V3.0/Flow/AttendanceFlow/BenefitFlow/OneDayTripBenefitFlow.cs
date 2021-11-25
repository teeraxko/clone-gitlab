using System;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;
using Entity.CommonEntity;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Attendance.Benefit.Flow
{
	public class OneDayTripBenefitFlow : FlowBase
	{
		#region - Private -
			private EmployeeOneDayTripBenefitDB dbEmployeeOneDayTripBenefit;
		#endregion

		//============================== Constructor ==============================
		public OneDayTripBenefitFlow() : base()
		{
			dbEmployeeOneDayTripBenefit = new EmployeeOneDayTripBenefitDB();
		}

		#region - Private Method -
		#endregion

		//============================== Public Method ==============================
		public void FillOneDayTripBenefit(EmployeeBenefit value)
		{
			EmployeeOneDayTripBenefit employeeOneDayTripBenefit = value.OneDayTripBenefit;
			employeeOneDayTripBenefit.Clear();
			dbEmployeeOneDayTripBenefit.FillOneDayTripBenefitList(ref employeeOneDayTripBenefit);

			for(int i=0; i<employeeOneDayTripBenefit.Count; i++)
			{
				if(employeeOneDayTripBenefit[i].BenefitAmount == value.OtherBenefitRate.OneDayTripRateNear)
				{
					employeeOneDayTripBenefit[i].Distance = DISTANCE_TYPE.NEAR;
				}
				else
				{
					employeeOneDayTripBenefit[i].Distance = DISTANCE_TYPE.FAR;
				}
			}

			CalculateTotalOneDayTripBenefit(value);
			employeeOneDayTripBenefit = null;
		}

		public void CalculateOneDayTripBenefit(EmployeeBenefit value)
		{
			for(int i=0; i<value.OneDayTripBenefit.Count; i++)
			{
//				if(value.WorkInfoList[value.OneDayTripBenefit[i].BenefitDate].AssignServiceStaffType.APosition.PositionCode == "28")
//				{
					if(value.OneDayTripBenefit[i].Distance == DISTANCE_TYPE.FAR)
					{
						value.OneDayTripBenefit[i].BenefitAmount = value.OtherBenefitRate.OneDayTripRateFar;
					}
					else
					{
						value.OneDayTripBenefit[i].BenefitAmount = value.OtherBenefitRate.OneDayTripRateNear;
					}
					value.OneDayTripBenefit[i].TotalAmount = value.OneDayTripBenefit[i].Times * value.OneDayTripBenefit[i].BenefitAmount;
//				}
			}
			CalculateTotalOneDayTripBenefit(value);
		}

		public void CalculateTotalOneDayTripBenefit(EmployeeBenefit value)
		{
			value.OneDayTripBenefit.TotalTimes = 0;
			value.OneDayTripBenefit.TotalAmount = 0;

			for(int i=0; i<value.OneDayTripBenefit.Count; i++)
			{
				value.OneDayTripBenefit.TotalTimes += value.OneDayTripBenefit[i].Times;
				value.OneDayTripBenefit.TotalAmount += value.OneDayTripBenefit[i].TotalAmount;
			}
		}
	}
}