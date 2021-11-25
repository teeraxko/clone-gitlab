using System;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;

using PTB.BTS.Attendance.Benefit.Flow;
using PTB.BTS.Common.Flow;

using SystemFramework.AppException;

namespace PTB.BTS.Attendance.Benefit.Flow
{
	public class CalOTByPatternFlow : CalOTFlowBase
	{
		#region - Private -
			private OTPatternSpecificConditionDB dbOTPatternSpecificCondition;
			private OTPatternGeneralConditionDB dbOTPatternGeneralCondition;
		#endregion

		//============================== Constructor ==============================
		public CalOTByPatternFlow() : base()
		{
			dbOTPatternSpecificCondition = new OTPatternSpecificConditionDB();
			dbOTPatternGeneralCondition = new OTPatternGeneralConditionDB();			
		}

		#region - Validate -
		private bool isValid(BenefitOTHour value)
		{
			if(value.BeforeTime.From == NullConstant.DATETIME)
			{
				return false;
			}

			if(value.AfterTime.To == NullConstant.DATETIME)
			{
				return false;
			}

			if(value.BeforeTime.To != NullConstant.DATETIME && value.AfterTime.From == NullConstant.DATETIME)
			{
				return false;
			}

			if(value.BeforeTime.To == NullConstant.DATETIME && value.AfterTime.From != NullConstant.DATETIME)
			{
				return false;
			}

			if(value.BeforeTime.To == NullConstant.DATETIME && value.AfterTime.From == NullConstant.DATETIME)
			{
				if(value.BeforeTime.From > value.AfterTime.To)
				{
					return false;
				}
			}
			else
			{
				if((value.BeforeTime.From > value.BeforeTime.To) || (value.BeforeTime.To > value.AfterTime.From) || (value.AfterTime.From > value.AfterTime.To))
				{
					return false;
				}
			}

			return true;
		}
		#endregion

		#region - fill OTPattern List -
		#region - OTPattern SpecificCondition -
		private bool fillPatternSpecificCondition(OTPatternList value, Employee employee)
		{
			return (dbOTPatternSpecificCondition.FillOTPatternSpecificConditionList(value, employee));
		}
		#endregion

		#region - OTPattern GeneralCondition -
		private bool RecFillPatternGeneralCondition(OTPatternList value, WorkInfo workInfo, PositionType positionType)
		{
			OTPatternGeneralCondition condition = new OTPatternGeneralCondition();
			condition.ACustomer = workInfo.AssignCustomer;
			condition.ACustomerDepartment = workInfo.AssignCustomerDepartment;
			condition.AServiceStaffType = workInfo.AssignServiceStaffType;
			condition.APositionType = positionType;
			bool result = (dbOTPatternGeneralCondition.FillOTPatternGeneralConditionList(value, condition));
			if(!result)
			{
				result = decreaseCondition(workInfo);
				if(result)
				{
					RecFillPatternGeneralCondition(value, workInfo, positionType);
				}
			}
			condition = null;
			return result;
		}

		private bool decreaseCondition(WorkInfo value)
		{
			if(value.AssignCustomerDepartment.Code == "ZZZ")
			{
                if (value.AssignCustomer.Code == Customer.DUMMYCODE)
				{
                    if (value.AssignServiceStaffType.Type == "ZZZ")
                    {
                        return false;
                    }
                    else
                    {
                        value.AssignServiceStaffType.Type = "ZZZ";
                    }
				}
				else
				{
                    value.AssignCustomer.Code = Customer.DUMMYCODE;
				}
			}
			else
			{
				value.AssignCustomerDepartment.Code = "ZZZ";
			}
			return true;
		}

		private bool fillPatternGeneralCondition(OTPatternList value, WorkInfo workInfo, PositionType positionType)
		{
			WorkInfo workInfoCondition = new WorkInfo(workInfo.BenefitDate);
			workInfoCondition.AssignCustomer = new Customer(workInfo.AssignCustomer.Code);
			workInfoCondition.AssignCustomerDepartment = new CustomerDepartment(workInfo.AssignCustomerDepartment.Code, workInfoCondition.AssignCustomer);
			workInfoCondition.AssignServiceStaffType = new ServiceStaffType(workInfo.AssignServiceStaffType.Type);
			bool result = RecFillPatternGeneralCondition(value, workInfoCondition, positionType);
			workInfoCondition = null;
			return result;			
		}
		#endregion

		private bool fillOTPatternList(OTPatternList value, WorkInfo workInfo, Employee employee)
		{
			if(fillPatternSpecificCondition(value, employee))
			{
				return true;
			}
			else
			{
				return fillPatternGeneralCondition(value, workInfo, employee.APosition.APositionType);
			}
		}
		#endregion

		#region - fill OvertimeHour -
//		private void fillOvertimeHourForHoliday(BenefitOTHour value, BenefitOTHour overtimeHour, WorkInfo workInfo)
//		{
//			TimePeriod mainTimePeriod = new TimePeriod();
//			TimePeriod timePeriod = new TimePeriod();
//
//			timePeriod.From = overtimeHour.BeforeTime.From;
//			if(overtimeHour.BeforeTime.To == NullConstant.DATETIME)
//			{
//				timePeriod.To = overtimeHour.AfterTime.To;
//			}
//			else
//			{
//				timePeriod.To = overtimeHour.BeforeTime.To;
//			}
//
//			mainTimePeriod.From = overtimeHour.BenefitDate;
//			mainTimePeriod.To = workInfo.WorkingTime.From;
//			value.BeforeTime = getTimeFormBetweenTimePeriod(timePeriod, mainTimePeriod);
//
//			mainTimePeriod.From = workInfo.WorkingTime.From;
//			mainTimePeriod.To = workInfo.BreakTime.From;
//			value.DuringTime1 = getTimeFormBetweenTimePeriod(timePeriod, mainTimePeriod);
//
//			value.BreakTime.From = overtimeHour.BreakTime.From;
//			value.BreakTime.To = overtimeHour.BreakTime.To;
//
//			mainTimePeriod.From = workInfo.BreakTime.To;
//			mainTimePeriod.To = workInfo.WorkingTime.To;
//			value.DuringTime2 = getTimeFormBetweenTimePeriod(timePeriod, mainTimePeriod);
//
//			mainTimePeriod.From = workInfo.WorkingTime.To;
//			mainTimePeriod.To = workInfo.BenefitDate.AddDays(1);
//
//			if(overtimeHour.AfterTime.From == NullConstant.DATETIME)
//			{
//				timePeriod.From = overtimeHour.BeforeTime.From;
//			}
//			else
//			{
//				timePeriod.From = overtimeHour.AfterTime.From;
//			}
//			timePeriod.To = overtimeHour.AfterTime.To;
//			value.AfterTime = getTimeFormBetweenTimePeriod(timePeriod, mainTimePeriod);
//
//			mainTimePeriod = null;
//			timePeriod = null;
//		}
//
//		private void fillOvertimeHourForWorkday(BenefitOTHour value, BenefitOTHour overtimeHour, WorkInfo workInfo)
//		{
//			TimePeriod mainTimePeriod = new TimePeriod();
//			TimePeriod timePeriod = new TimePeriod();
//
//			timePeriod.From = overtimeHour.BeforeTime.From;
//			if(overtimeHour.BeforeTime.To == NullConstant.DATETIME)
//			{
//				timePeriod.To = overtimeHour.AfterTime.To;
//			}
//			else
//			{
//				timePeriod.To = overtimeHour.BeforeTime.To;
//			}
//
//			mainTimePeriod.From = overtimeHour.BenefitDate;
//			mainTimePeriod.To = workInfo.WorkingTime.From;
//			value.BeforeTime = getTimeFormBetweenTimePeriod(timePeriod, mainTimePeriod);
//
//			mainTimePeriod.From = workInfo.WorkingTime.From;
//			mainTimePeriod.To = workInfo.BreakTime.From;
//			value.DuringTime1 = getTimeFormBetweenTimePeriod(timePeriod, mainTimePeriod);
//
//			value.BreakTime.From = overtimeHour.BreakTime.From;
//			value.BreakTime.To = overtimeHour.BreakTime.To;
//
//			mainTimePeriod.From = workInfo.BreakTime.To;
//			mainTimePeriod.To = workInfo.WorkingTime.To;
//			value.DuringTime2 = getTimeFormBetweenTimePeriod(timePeriod, mainTimePeriod);
//
//			mainTimePeriod.From = workInfo.WorkingTime.To;
//			mainTimePeriod.To = workInfo.BenefitDate.AddDays(1);
//
//			if(overtimeHour.AfterTime.From == NullConstant.DATETIME)
//			{
//				timePeriod.From = overtimeHour.BeforeTime.From;
//			}
//			else
//			{
//				timePeriod.From = overtimeHour.AfterTime.From;
//			}
//			timePeriod.To = overtimeHour.AfterTime.To;
//			value.AfterTime = getTimeFormBetweenTimePeriod(timePeriod, mainTimePeriod);
//
//			mainTimePeriod = null;
//			timePeriod = null;
//		}
		#endregion

		#region - calculate OT -
			#region - Adjust Hour Function -
				private decimal checkMax(decimal value, OTPattern otPattern)
				{
					if(otPattern.IsMaxHourLimit && value>otPattern.MaxHourLimit)
					{
						return otPattern.MaxHourLimit;
					}
					else
					{
						return value;
					}
				}

				private decimal checkMin(decimal value, OTPattern otPattern)
				{
					if(otPattern.IsMinHourLimit && value<otPattern.MinHourLimit)
					{
						return otPattern.MinHourLimit;
					}
					else
					{
						return value;
					}
				}

//				private decimal checkDeduct(decimal value, OTPattern otPattern)
//				{
//					if(otPattern.AdditionalMinute>0)
//					{
//						int valueMinute = ((int)decimal.Floor(value)) * 60 + (int)(decimal.Remainder(value, 1) * 100);
//						if(valueMinute<otPattern.AdditionalMinute)
//						{
//							return 0;
//						}
//						else
//						{
//							valueMinute = valueMinute - otPattern.AdditionalMinute;
//							int hour = valueMinute/60;
//							decimal minute = (valueMinute%60)/100m;
//							return hour + minute;
//						}
//					}
//					else
//					{
//						return value;
//					}
//				}

				private void adjustOTHour(BenefitOTHour value, OTPattern otPattern)
				{
					if(otPattern.IsFixedHour)
					{
						switch(otPattern.OTRate)
						{
							case OT_RATE_TYPE.A :
							{
								value.OTRate.OtAHour = otPattern.FixedHour;
								break;
							}
							case OT_RATE_TYPE.B :
							{
								value.OTRate.OtBHour = otPattern.FixedHour;
								break;
							}
							case OT_RATE_TYPE.C :
							{
								value.OTRate.OtCHour = otPattern.FixedHour;
								break;
							}
						}
					}
					else
					{
						switch(otPattern.OTRate)
						{
							case OT_RATE_TYPE.A :
							{
//								value.OTRate.OtAHour = checkDeduct(value.OTRate.OtAHour, otPattern);
								value.OTRate.OtAHour = checkMax(value.OTRate.OtAHour, otPattern);
								value.OTRate.OtAHour = checkMin(value.OTRate.OtAHour, otPattern);
								break;
							}
							case OT_RATE_TYPE.B :
							{
//								value.OTRate.OtBHour = checkDeduct(value.OTRate.OtBHour, otPattern);
								value.OTRate.OtBHour = checkMax(value.OTRate.OtBHour, otPattern);
								value.OTRate.OtBHour = checkMin(value.OTRate.OtBHour, otPattern);
								break;
							}
							case OT_RATE_TYPE.C :
							{
//								value.OTRate.OtCHour = checkDeduct(value.OTRate.OtCHour, otPattern);
								value.OTRate.OtCHour = checkMax(value.OTRate.OtCHour, otPattern);
								value.OTRate.OtCHour = checkMin(value.OTRate.OtCHour, otPattern);
								break;
							}
						}
					}
				}
			#endregion

			private void fillOT(BenefitOTHour value, DateTime form, DateTime to, WorkInfo workInfo, OTPattern otPattern)
			{
				decimal hour = 0;

				hour = diffTime(form, to);
				if(hour>0)
				{
					switch(otPattern.OTRate)
					{
						case OT_RATE_TYPE.A :
						{
							value.OTRate.OtAHour = addTime(value.OTRate.OtAHour ,hour);
							break;
						}
						case OT_RATE_TYPE.B :
						{
							value.OTRate.OtBHour = addTime(value.OTRate.OtBHour ,hour);
							break;
						}
						case OT_RATE_TYPE.C :
						{
							value.OTRate.OtCHour = addTime(value.OTRate.OtCHour ,hour);
							break;
						}
					}						
				}
			}

			private void calculatePeriodOT(BenefitOTHour value, WorkInfo workInfo, WorkInfo nextWorkInfo, OTPattern otPattern, PERIOD_TYPE periodType, Employee employee)
			{
				switch(periodType)
				{
					case PERIOD_TYPE.BEFORE_WORKINGTIME :
					{
						if(workInfo.DayType == otPattern.DayType)
						{
							if(validateTime(value.BeforeTime.From, value.BeforeTime.To))
							{
								fillOT(value, value.BeforeTime.From, value.BeforeTime.To, workInfo, otPattern);									
							}
							adjustOTHour(value, otPattern);
						}
						break;
					}
					case PERIOD_TYPE.WORKINGTIME :
					{
						bool valid = false;
						if(workInfo.DayType == otPattern.DayType)
						{
//							if(validateTime(value.DuringTime1.From, workInfo.BreakTime.From))
//							{
//								fillOT(value, value.DuringTime1.From, workInfo.BreakTime.From, workInfo, otPattern);
//							}
							if(validateTime(value.DuringTime1.From, value.DuringTime1.To))
							{
								fillOT(value, value.DuringTime1.From, value.DuringTime1.To, workInfo, otPattern);
								valid = true;
							}
//							if(validateTime(workInfo.BreakTime.To, value.DuringTime2.To))
//							{
//								fillOT(value, workInfo.BreakTime.To, value.DuringTime2.To, workInfo, otPattern);
//							}
							if(validateTime(value.DuringTime2.From, value.DuringTime2.To))
							{
								fillOT(value, value.DuringTime2.From, value.DuringTime2.To, workInfo, otPattern);
								valid = true;
							}

							if(valid)
							{
								adjustOTHour(value, otPattern);
							}							
						}
						break;
					}
					case PERIOD_TYPE.BREAK_TIME :
					{
						if(workInfo.AssignServiceStaffType.APosition.PositionCode != "28" && value.BreakTime.From == NullConstant.DATETIME && value.BreakTime.To == NullConstant.DATETIME)
						{
							break;
						}

						if(workInfo.DayType == otPattern.DayType)
						{
							if(value.BreakTime.From != NullConstant.DATETIME && value.BreakTime.To != NullConstant.DATETIME)
							{
								decimal hour = diffTime(value.BreakTime.From, value.BreakTime.To);
								if(hour>1 && workInfo.DayType==WORKINGDAY_TYPE.HOLIDAY)
								{
									switch(otPattern.OTRate)
									{
										case OT_RATE_TYPE.A :
										{
											value.OTRate.OtAHour = addTime(value.OTRate.OtAHour ,1);
											value.OTRate.OtCHour = addTime(value.OTRate.OtCHour ,hour - 1);
											break;
										}
										case OT_RATE_TYPE.B :
										{
											value.OTRate.OtBHour = addTime(value.OTRate.OtBHour ,1);
											value.OTRate.OtCHour = addTime(value.OTRate.OtCHour ,hour - 1);
											break;
										}
										case OT_RATE_TYPE.C :
										{
											value.OTRate.OtCHour = addTime(value.OTRate.OtCHour ,1);
											value.OTRate.OtCHour = addTime(value.OTRate.OtCHour ,hour - 1);
											break;
										}
									}
								}
								else
								{
									fillOT(value, value.BreakTime.From, value.BreakTime.To, workInfo, otPattern);
								}
							}
							else
							{
								if(workInfo.DayType == WORKINGDAY_TYPE.HOLIDAY && value.DuringTime1.From!= NullConstant.DATETIME && value.DuringTime2.To!=NullConstant.DATETIME)
								{
									BenefitOTHour benefitOTHour = new BenefitOTHour(value.BenefitDate);	
									benefitOTHour.OTRate = value.OTRate;
									benefitOTHour.BeforeTime.From = value.BeforeTime.From;
									benefitOTHour.AfterTime.To = value.AfterTime.To;
									if(benefitOTHour.BreakTime.From==NullConstant.DATETIME)
									{
										benefitOTHour.BreakTime.From = workInfo.BreakTime.From;
									}
									else
									{
										benefitOTHour.BreakTime.From = value.BreakTime.From;
									}

									if(benefitOTHour.BreakTime.To==NullConstant.DATETIME)
									{
										benefitOTHour.BreakTime.To = workInfo.BreakTime.To;
									}
									else
									{
										benefitOTHour.BreakTime.To = value.BreakTime.To;
									}

									calculatePeriodOT(benefitOTHour, workInfo, nextWorkInfo, otPattern, periodType, employee);
									benefitOTHour = null;
								}
							}
							adjustOTHour(value, otPattern);
						}

						break;
					}
					case PERIOD_TYPE.AFTER_WORKINGTIME :
					{
						if(validateTime(value.AfterTime.From, value.AfterTime.To))
						{
							if(value.AfterTime.From.Date == value.AfterTime.To.Date)
//								|| value.AfterTime.To == value.BenefitDate.AddDays(1) || value.AfterTime.From == value.BenefitDate.AddDays(1))
							{
								if(workInfo.DayType == otPattern.DayType)
								{
									if(otPattern.AdditionalMinute>0)
									{										
										DateTime temp = workInfo.WorkingTime.To.AddMinutes(otPattern.AdditionalMinute);
										if(temp > value.AfterTime.To)
										{
											return;
										}
										if(temp > value.AfterTime.From)
										{
											fillOT(value, temp, value.AfterTime.To, workInfo, otPattern);
										}
										else
										{
											fillOT(value, value.AfterTime.From, value.AfterTime.To, workInfo, otPattern);
										}
									}
									else
									{
										fillOT(value, value.AfterTime.From, value.AfterTime.To, workInfo, otPattern);
									}
								}
							}
							else
							{
								if(nextWorkInfo == null)
								{
                                    nextWorkInfo = getNextWorkInfo(value.BenefitDate, employee);
                                    //Cal rate next month is holiday : woranai
                                    //nextWorkInfo = getNextWorkInfo(value.BenefitDate.AddDays(1), employee);
									if(nextWorkInfo == null)
									{
										throw new NotFoundException("ไม่พบตารางเวลาทำงานของเดือนถัดไป", "CalOTByPatternFlow");
									}
								}

								BenefitOTHour preOvertimeHour = new BenefitOTHour(value.BenefitDate);
								preOvertimeHour.OTRate = value.OTRate;
								preOvertimeHour.AfterTime = new TimePeriod();
								preOvertimeHour.AfterTime.From = value.AfterTime.From;
								preOvertimeHour.AfterTime.To = new DateTime(value.BenefitDate.Year, value.BenefitDate.Month, value.BenefitDate.Day);
								preOvertimeHour.AfterTime.To = preOvertimeHour.AfterTime.To.AddDays(1);

								BenefitOTHour postOvertimeHour = new BenefitOTHour(value.BenefitDate);
								postOvertimeHour.OTRate = value.OTRate;
								postOvertimeHour.AfterTime = new TimePeriod();
								postOvertimeHour.AfterTime.From = preOvertimeHour.AfterTime.To;
								postOvertimeHour.AfterTime.To = value.AfterTime.To.AddDays(1);

								if(workInfo.DayType == otPattern.DayType)
								{
									if(otPattern.AdditionalMinute>0)
									{										
//										DateTime temp = preOvertimeHour.AfterTime.From.AddMinutes(otPattern.AdditionalMinute);
										DateTime temp = workInfo.WorkingTime.To.AddMinutes(otPattern.AdditionalMinute);
										if(temp > preOvertimeHour.AfterTime.From)
										{
											fillOT(preOvertimeHour, temp, preOvertimeHour.AfterTime.To, workInfo, otPattern);
										}
										else
										{
											fillOT(preOvertimeHour, preOvertimeHour.AfterTime.From, preOvertimeHour.AfterTime.To, workInfo, otPattern);
										}
									}
									else
									{
										fillOT(preOvertimeHour, preOvertimeHour.AfterTime.From, preOvertimeHour.AfterTime.To, workInfo, otPattern);
									}
								}

								if(nextWorkInfo.DayType == otPattern.DayType)
								{
									fillOT(postOvertimeHour, postOvertimeHour.AfterTime.From, postOvertimeHour.AfterTime.To, nextWorkInfo, otPattern);
								}

								preOvertimeHour = null;
								postOvertimeHour = null;
							}
						}
						adjustOTHour(value, otPattern);
						break;
					}
					default :
					{
						calculatePeriodOT(value, workInfo, nextWorkInfo, otPattern, PERIOD_TYPE.BEFORE_WORKINGTIME, employee);
						calculatePeriodOT(value, workInfo, nextWorkInfo, otPattern, PERIOD_TYPE.WORKINGTIME, employee);
						calculatePeriodOT(value, workInfo, nextWorkInfo, otPattern, PERIOD_TYPE.BREAK_TIME, employee);
						calculatePeriodOT(value, workInfo, nextWorkInfo, otPattern, PERIOD_TYPE.AFTER_WORKINGTIME, employee);
						adjustOTHour(value, otPattern);
						break;
					}
				}
			}
		#endregion

		//============================== Public Method ==============================
		public void CalculateOT(BenefitOTHour value, WorkInfo workInfo, WorkInfo nextWorkInfo, Employee employee)
		{
			if(isValid(value))
			{
				OTPatternList otPatternList = new OTPatternList(employee.Company);
				if(fillOTPatternList(otPatternList, workInfo, employee))
				{
					BenefitOTHour overtimeHour = new BenefitOTHour(value.BenefitDate);
					overtimeHour.OTRate = value.OTRate;

					fillOvertimeHour(overtimeHour, value, workInfo);
//					if(workInfo.DayType == WORKINGDAY_TYPE.HOLIDAY)
//					{
//						fillOvertimeHourForHoliday(overtimeHour, value, workInfo);
//					}
//					else
//					{
//						fillOvertimeHourForWorkday(overtimeHour, value, workInfo);
//					}

					for(int i=0; i<otPatternList.Count; i++)
					{
						calculatePeriodOT(overtimeHour, workInfo, nextWorkInfo, otPatternList[i], otPatternList[i].OTPeriod, employee);
					}
				}
				else
				{
					otPatternList = null;
					throw new NotFoundException("การกำหนดรูปแบบค่าล่วงเวลา", "CalOTByPatternFlow");
				}
				otPatternList = null;				
			}
		}
	}
}