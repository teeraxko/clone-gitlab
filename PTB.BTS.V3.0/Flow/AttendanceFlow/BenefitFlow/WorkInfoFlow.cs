using System;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;
using Entity.ContractEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.ContractDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace PTB.BTS.Attendance.Benefit.Flow
{
	public class WorkInfoFlow : FlowBase
	{
		#region - Private -
			private EmployeeWorkScheduleDB dbEmployeeWorkSchedule;
			private ServiceStaffAssignmentDB dbServiceStaffAssignment;
			private ServiceStaffContractDB dbServiceStaffContract;
		#endregion

		//============================== Constructor ==============================
		public WorkInfoFlow() : base()
		{
			dbEmployeeWorkSchedule = new EmployeeWorkScheduleDB();
			dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
			dbServiceStaffContract = new ServiceStaffContractDB();
		}

		#region - Private Method -
			private bool createBenefitWorkInfoList(WorkInfoList value)
			{
				value.Clear();
				return dbEmployeeWorkSchedule.FillBenefitWorkInfoList(value);
			}
			
			#region - fillAssignment -
				private void fillAssignment(WorkInfo value, ServiceStaffAssignment serviceStaffAssignment, Company company)
				{
					value.AssignContract = serviceStaffAssignment.AContract;
					value.AssignCustomer = serviceStaffAssignment.AContract.ACustomer;
					value.AssignCustomerDepartment = serviceStaffAssignment.AContract.ACustomerDepartment;
					value.AssignServiceStaffType = dbServiceStaffContract.GetServiceStaffType(serviceStaffAssignment.AContract, company);
				}
				
				private void fillAssignment(WorkInfoList value)
				{
					if(value.Employee.APosition.APositionType.Type=="S")
					{
						for(int i=0; i<value.Count; i++)
						{
							value[i].AssignServiceStaffType.Type = value.Employee.APosition.PositionCode + "Z";
						}

						ServiceStaffAssignmentList serviceStaffAssignmentList = new ServiceStaffAssignmentList(value.Company);
						serviceStaffAssignmentList.AServiceStaff = new ServiceStaff(value.Employee.EmployeeNo, value.Company);
						TimePeriod timePeriod =new TimePeriod();
						timePeriod.From = value.ForMonth.MinDateOfMonth;
						timePeriod.To = value.ForMonth.MaxDateOfMonth;

						if(dbServiceStaffAssignment.FillServiceStaffAssignmentInYearmonth(ref serviceStaffAssignmentList, timePeriod))
						{
							WorkInfo workInfo;
							DateTime startDate;
							DateTime endDate;
							for(int i=0; i<serviceStaffAssignmentList.Count; i++)
							{
								if(value.ForMonth.MinDateOfMonth>serviceStaffAssignmentList[i].APeriod.From)
								{
									startDate = value.ForMonth.MinDateOfMonth;
								}
								else
								{
									startDate = serviceStaffAssignmentList[i].APeriod.From;
								}
								if(value.ForMonth.MaxDateOfMonth<serviceStaffAssignmentList[i].APeriod.To)
								{
									endDate = value.ForMonth.MaxDateOfMonth;
								}
								else
								{
									endDate = serviceStaffAssignmentList[i].APeriod.To;
								}
								for(DateTime temp=startDate; temp<=endDate; temp=temp.AddDays(1))
								{
									workInfo = value[temp];
									fillAssignment(workInfo, serviceStaffAssignmentList[i], serviceStaffAssignmentList.Company);
								}
							}
							workInfo = null;
						}

						serviceStaffAssignmentList = null;
						timePeriod = null;
					}
				}
			#endregion

			private void adjustWorkInfo(WorkInfoList value)
			{
                #region Validate Leave
                EmployeeTimeCardDB dbEmployeeTimeCard = new EmployeeTimeCardDB();
                EmployeeTimeCard empTimeCard = new EmployeeTimeCard(value.Employee, value.ForMonth);

                if (dbEmployeeTimeCard.FillTimeCardList(ref empTimeCard))
                {
                    string[] leaveStatus = new string[] { "A1", "P1", "S1", "S2" };

                    foreach (WorkInfo entity in value)
                    {
                        TimeCard timeCard;
                        if (empTimeCard.Contain(entity.BenefitDate.ToShortDateString()))
                        {
                            timeCard = empTimeCard[entity.BenefitDate.ToShortDateString()];

                            foreach (string status in leaveStatus)
                            {
                                if (timeCard.AAfterBreakStatus.Code == status || timeCard.ABeforeBreakStatus.Code == status)
                                {
                                    entity.ValidOTStatus = false;
                                    entity.Remark = "Leave Day";
                                }
                            }
                        }
                        timeCard = null;
                    }
                }
                dbEmployeeTimeCard = null;
                empTimeCard = null;
                #endregion

                TimePeriod timePeriod;
				ServiceStaff serviceStaff = new ServiceStaff(value.Employee);
				ServiceStaffAssignmentList serviceStaffAssignmentList = new ServiceStaffAssignmentList(serviceStaff, value.Company);
				if(dbServiceStaffAssignment.FillSpareServiceStaffAssignmentListInPeriodList(ref serviceStaffAssignmentList, value.ForMonth))
				{
					for(int i=0; i<serviceStaffAssignmentList.Count; i++)
					{
						timePeriod = serviceStaffAssignmentList[i].APeriod;
						for(DateTime temp=timePeriod.From; temp<=timePeriod.To; temp=temp.AddDays(1))
						{
							if(value.Contain(temp.ToShortDateString()))
							{
								value[temp].ValidOTStatus = false;
								value[temp].Remark = serviceStaffAssignmentList[i].AAssignedServiceStaff.EmployeeNo;
							}
						}
					}
				}

				//เอาเข้าตอนเปลี่ยนเวลา
				for(int i=0; i<value.Count; i++)
				{
					if(value[i].BreakTime.To.Hour==13 && value[i].BreakTime.To.Minute==25 && value[i].WorkingTime.From.Hour==7 && value[i].WorkingTime.From.Minute==35)
					{
						value[i].BreakTime.To = getDate(value[i].BreakTime.To, 13, 0);
					}
				}
				
			}

		private DateTime getDate(DateTime date, int hour, int minute)
		{
			return new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
		}
		#endregion

		//============================== Public Method ==============================
		public bool FillWorkInfoList(WorkInfoList value)
		{
			bool result = false;
			if(createBenefitWorkInfoList(value))
			{
				fillAssignment(value);
				adjustWorkInfo(value);
				result = true;
			}
			return result;
		}
	}
}