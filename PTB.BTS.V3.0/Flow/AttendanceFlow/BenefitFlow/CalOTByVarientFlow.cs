using System;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;

using SystemFramework.AppException;

namespace PTB.BTS.Attendance.Benefit.Flow
{
	public class CalOTByVarientFlow : CalOTFlowBase
	{
		#region - Private -
			private OvertimeVariantTableDB dbOvertimeVariantTable;			
		#endregion

		//============================== Constructor ==============================
		public CalOTByVarientFlow() : base()
		{
			dbOvertimeVariantTable = new OvertimeVariantTableDB();			
		}

		#region - Private Method -
			#region - Clear Rate -
			private void clearRate(OTRate value)
			{
				value.OtAHour = 0;
				value.OtBHour = 0;
				value.OtCHour = 0;
			}
			#endregion

			#region - Calculate DuringTime -
				private void calculateDuringTime(BenefitOTHour value, WorkInfo workInfo)
				{
					if(workInfo.DayType == WORKINGDAY_TYPE.HOLIDAY)
					{
						if(between(value.BeforeTime.From, workInfo.WorkingTime) || between(value.AfterTime.To, workInfo.WorkingTime))
						{
							value.OTRate.OtBHour += 9;
						}
                        else if (between(workInfo.WorkingTime.From, value.BeforeTime) || between(workInfo.WorkingTime.To, value.AfterTime))
                        {
                            value.OTRate.OtBHour += 9;
                        }
					}
				}
			#endregion

			#region - Find Equivalent Time -
				protected virtual DateTime getEquivalentTime(OTVariant otVariant, Customer customer, DateTime date)
				{
					if(customer != null)
					{
						switch(customer.ACustomerGroup.Code)
						{
							case "G1" :
							{
								return getTime(date ,otVariant.EquivalentTimeGroupI);
							}
							case "G2" :
							{
								return getTime(date ,otVariant.EquivalentTimeGroupII);
							}
							case "G3" :
							{
								return getTime(date ,otVariant.EquivalentTimeGroupIII);
							}
							default :
							{
								throw new NotFoundException("การกำหนดรูปแบบค่าล่วงเวลา - Family Car", "CalOTByVarientFlow");
							}
						}
					}
					else
					{
						throw new NotFoundException("การกำหนดรูปแบบค่าล่วงเวลา - Family Car", "CalOTByVarientFlow");
					}
				}

				private OT_RATE_TYPE getOTVarientRate(OTVariant otVariant, WorkInfo workInfo)
				{
					if(workInfo.DayType == WORKINGDAY_TYPE.HOLIDAY)
					{
						return otVariant.OtRateHoliday;
					}
					else
					{
						return otVariant.OtRateWorkingDay;
					}
				}

				private void fillEquivalent(BenefitOTHour value, WorkInfo workInfo, WorkInfo nextWorkInfo, Employee employee)
				{
					OTVariant otVariant = new OTVariant();

					if(dbOvertimeVariantTable.FillOTVariantThatDate(otVariant, getTime(value.BeforeTime.From), IN_OUT_STATUS_TYPE.IN, employee.Company))
					{
						value.BeforeTime.From = getEquivalentTime(otVariant, workInfo.AssignCustomer, value.BeforeTime.From);
						workInfo.OTVarientRate = getOTVarientRate(otVariant, workInfo);
					}
					else
					{
						otVariant = null;
						throw new NotFoundException("การกำหนดรูปแบบค่าล่วงเวลา - Family Car", "CalOTByVarientFlow");
					}

					otVariant = new OTVariant();
					if(dbOvertimeVariantTable.FillOTVariantThatDate(otVariant, getTime(value.AfterTime.To), IN_OUT_STATUS_TYPE.OUT, employee.Company))
					{
						DateTime temp = getEquivalentTime(otVariant, workInfo.AssignCustomer, value.AfterTime.To);
						if(value.BeforeTime.From<temp)
						{
							value.AfterTime.To = temp;
						}
						else
						{
							value.AfterTime.To = temp.AddDays(1);
						}
						if(value.BeforeTime.From.Day != value.AfterTime.To.Day)
						{
							if(nextWorkInfo == null)
							{
								nextWorkInfo = getNextWorkInfo(value.BenefitDate, employee);
								if(nextWorkInfo == null)
								{
									throw new NotFoundException("ตารางเวลาทำงานของเดือนถัดไป", "CalOTByPatternFlow");
								}
							}
							nextWorkInfo.OTVarientRate = getOTVarientRate(otVariant, nextWorkInfo);
						}						
					}
					else
					{
						otVariant = null;
						throw new NotFoundException("การกำหนดรูปแบบค่าล่วงเวลา - Family Car", "CalOTByVarientFlow");
					}
				}
			#endregion

			#region - Calculate OT -
				private void calculateOT(OTRate value, DateTime form, DateTime to, WorkInfo workInfo)
				{
					decimal hour = diffTime(form, to);
					if(hour>0)
					{
						switch(workInfo.OTVarientRate)
						{
							case OT_RATE_TYPE.A :
							{
								value.OtAHour = addTime(value.OtAHour ,hour);
								break;
							}
							case OT_RATE_TYPE.B :
							{
								value.OtBHour = addTime(value.OtBHour ,hour);
								break;
							}
							case OT_RATE_TYPE.C :
							{
								value.OtCHour = addTime(value.OtCHour ,hour);
								break;
							}
						}						
					}
				}

				private void calculateOT(BenefitOTHour value, WorkInfo workInfo)
				{
					//BeforeTime
					if(validateTime(value.BeforeTime.From, value.BeforeTime.To))
					{
						calculateOT(value.OTRate, value.BeforeTime.From, value.BeforeTime.To, workInfo);
					}

					//AfterTime
					if(validateTime(value.AfterTime.From, value.AfterTime.To))
					{
						calculateOT(value.OTRate, value.AfterTime.From, value.AfterTime.To, workInfo);
					}
				}

				private void calculateEquivalentOT(BenefitOTHour value, WorkInfo workInfo, WorkInfo nextWorkInfo)
				{
					BenefitOTHour overtimeHour = new BenefitOTHour(value.BenefitDate);
					if(value.BeforeTime.From.Day == value.AfterTime.To.Day)
					{
						overtimeHour.OTRate = value.OTRate;
						fillOvertimeHour(overtimeHour, value, workInfo);
						calculateOT(overtimeHour, workInfo);
					}
					else
					{
						BenefitOTHour firstDayBenefitOTHour = new BenefitOTHour(value.BenefitDate);
						firstDayBenefitOTHour.BeforeTime.From = value.BeforeTime.From;
						firstDayBenefitOTHour.AfterTime.To = getTime(value.AfterTime.To, NullConstant.DATETIME);

						overtimeHour.OTRate = value.OTRate;
						fillOvertimeHour(overtimeHour, firstDayBenefitOTHour, workInfo);
						calculateOT(overtimeHour, workInfo);

						BenefitOTHour overtimeHour2 = new BenefitOTHour(value.BenefitDate);
						BenefitOTHour secondDayBenefitOTHour = new BenefitOTHour(value.BenefitDate);
						secondDayBenefitOTHour.BeforeTime.From = getTime(value.AfterTime.To, NullConstant.DATETIME);
						secondDayBenefitOTHour.AfterTime.To = value.AfterTime.To;

						overtimeHour2.OTRate = value.OTRate;
						fillOvertimeHour(overtimeHour2, secondDayBenefitOTHour, nextWorkInfo);
						calculateOT(overtimeHour2, nextWorkInfo);
					}
				}
			#endregion
		#endregion

		//============================== Public Method ==============================
		public void CalculateOT(BenefitOTHour value, WorkInfo workInfo, WorkInfo nextWorkInfo, Employee employee)
		{
			clearRate(value.OTRate);
			if(!value.ValidOTHour)
			{
				return;
			}

			calculateDuringTime(value, workInfo);

			BenefitOTHour overtimeHour = new BenefitOTHour(value.BenefitDate);
			overtimeHour.OTRate = value.OTRate;
			overtimeHour.BeforeTime.From = value.BeforeTime.From;
			overtimeHour.AfterTime.To = value.AfterTime.To;
			if(nextWorkInfo == null)
			{
				nextWorkInfo = getNextWorkInfo(workInfo.BenefitDate, employee);
			}
			fillEquivalent(overtimeHour, workInfo, nextWorkInfo, employee);
			calculateEquivalentOT(overtimeHour, workInfo, nextWorkInfo);
		}
	}
}