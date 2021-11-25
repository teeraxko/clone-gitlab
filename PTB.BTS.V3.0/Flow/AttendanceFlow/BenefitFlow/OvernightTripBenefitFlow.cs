using System;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;
using Entity.ContractEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.ContractDB;

using PTB.BTS.Common.Flow;

using SystemFramework.AppException;

namespace PTB.BTS.Attendance.Benefit.Flow
{
	public class OverNightTripBenefitFlow : FlowBase
	{
		#region - Private -
			private EmployeeOvernightTripBenefitDB dbEmployeeOvernightTripBenefit;
		#endregion

		//============================== Constructor ==============================
		public OverNightTripBenefitFlow() : base()
		{
			dbEmployeeOvernightTripBenefit = new EmployeeOvernightTripBenefitDB();
		}

		#region - Private Method -
//		private WorkInfo getNextWorkInfo(DateTime value, Employee employee)
//		{
//			WorkSchedule workSchedule = new WorkSchedule();
//			workSchedule.WorkDate = value.AddDays(1);
//			if(dbEmployeeWorkSchedule.FillWorkSchedule(ref workSchedule, employee))
//			{
//				return new WorkInfo(workSchedule);
//			}
//			else
//			{
//				return null;
//			}
//		}
		#endregion

		//============================== Public Method ==============================
		public void FillOverNightTripBenefit(EmployeeBenefit value)
		{
			value.OvernightTripBenefit.PreviousMonth.Clear();
			dbEmployeeOvernightTripBenefit.FillBetweenBenefitOvernightTripList(value.OvernightTripBenefit.PreviousMonth);

			value.OvernightTripBenefit.CurrentMonth.Clear();
			dbEmployeeOvernightTripBenefit.FillAllBenefitOvernightTripList(value.OvernightTripBenefit.CurrentMonth);

			value.OvernightTripBenefit.NextMonth.Clear();
			dbEmployeeOvernightTripBenefit.FillBetweenBenefitOvernightTripList(value.OvernightTripBenefit.NextMonth);

			CalculateTotalOverNightTripBenefit(value);
		}

		public bool ValidateOverNightTripBenefit(EmployeeBenefit value)
		{
			return true;
		}

		public bool FillCustomer(BenefitOvernightTrip value, EmployeeBenefit employeeBenefit)
		{
			if(value.From.Month == employeeBenefit.ForMonth.Month && value.To.Month == employeeBenefit.ForMonth.Month)
			{
				Customer tempCustomer = employeeBenefit.WorkInfoList[value.From].AssignCustomer;
				CustomerDepartment tempCustomerDepartment = employeeBenefit.WorkInfoList[value.From].AssignCustomerDepartment;

				for(DateTime temp=value.From.AddDays(1); temp<value.To; temp=temp.AddDays(1))
				{
					if(tempCustomer.Code == employeeBenefit.WorkInfoList[value.From].AssignCustomer.Code)
					{
						if(tempCustomerDepartment.Code == employeeBenefit.WorkInfoList[value.From].AssignCustomerDepartment.Code)
						{}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}

				value.Customer = tempCustomer;
				value.CustomerDepartment = tempCustomerDepartment;
				
				return true;			
			}
			else
			{
				bool result = false;
				ServiceStaffAssignment serviceStaffAssignment = new ServiceStaffAssignment();
				TimePeriod timePeriod = new TimePeriod();
				timePeriod.From = value.From;
				timePeriod.To = value.To;

				ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
				if(dbServiceStaffAssignment.FillServiceStaffAssignment(ref serviceStaffAssignment, timePeriod, employeeBenefit.Employee))
				{
					value.Customer = serviceStaffAssignment.AContract.ACustomer;
					value.CustomerDepartment = serviceStaffAssignment.AContract.ACustomerDepartment;
					result = true;
				}
				else
				{
					result = false;
				}
				
				timePeriod = null;
				serviceStaffAssignment = null;
				dbServiceStaffAssignment = null;

				return result;
			}
		}

		public bool CalculateOverNightTripBenefit(EmployeeBenefit value)
		{
			for(int i=0; i<value.OvernightTripBenefit.CurrentMonth.Count; i++)
			{
				DateTime temp = value.OvernightTripBenefit.CurrentMonth[i].From;

//				if(value.WorkInfoList.Contain(temp.ToShortDateString()) && value.WorkInfoList[temp].AssignServiceStaffType.APosition.PositionCode == "28")
//				{
					if(!FillCustomer(value.OvernightTripBenefit.CurrentMonth[i], value))
					{
						string dateFrom = value.OvernightTripBenefit.CurrentMonth[i].From.ToShortDateString();
						string dateTo = value.OvernightTripBenefit.CurrentMonth[i].To.ToShortDateString();
						throw new NotFoundException("การจ่ายงานในช่วงเวลาตั้งแต่ " + dateFrom + " จนถึง " + dateTo, "OverNightTripBenefitFlow");
					}
					value.OvernightTripBenefit.CurrentMonth[i].Amount = value.OtherBenefitRate.OvernightTripRate;
//				}
			}
			CalculateTotalOverNightTripBenefit(value);
			return true;
		}

		public void CalculateTotalOverNightTripBenefit(EmployeeBenefit value)
		{
			value.OvernightTripBenefit.CurrentMonth.TotalTimes = 0;
			value.OvernightTripBenefit.CurrentMonth.TotalAmount = 0;

			for(int i=0; i<value.OvernightTripBenefit.CurrentMonth.Count; i++)
			{
				value.OvernightTripBenefit.CurrentMonth.TotalTimes += value.OvernightTripBenefit.CurrentMonth[i].Times;
				value.OvernightTripBenefit.CurrentMonth.TotalAmount += value.OvernightTripBenefit.CurrentMonth[i].TotalAmount;
			}
		}
	}
}