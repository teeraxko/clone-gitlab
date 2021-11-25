using System;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;
using Entity.CommonEntity;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

using SystemFramework.AppException;

using ictus.Common.Entity.General;
using System.Data.SqlClient;

namespace PTB.BTS.Attendance.Benefit.Flow
{
	public class EmployeeBenefitFlow : FlowBase
	{
		#region - Private -
			private WorkInfoFlow flowWorkInfo;
			private OTBenefitFlow flowOTBenefit;
			private FoodBenefitFlow flowFoodBenefit;
			private TaxiBenefitFlow flowTaxiBenefit;
			private OneDayTripBenefitFlow flowOneDayTripBenefit;
			private OverNightTripBenefitFlow flowOverNightTripBenefit;

			private OtherBenefitRateDB dbOtherBenefitRate;
		#endregion
		
		//============================== Constructor ==============================
		public EmployeeBenefitFlow() : base()
		{
			flowWorkInfo = new WorkInfoFlow();
			flowOTBenefit = new OTBenefitFlow();
			flowFoodBenefit = new FoodBenefitFlow();
			flowTaxiBenefit = new TaxiBenefitFlowEdit();
			flowOneDayTripBenefit = new OneDayTripBenefitFlow();
			flowOverNightTripBenefit = new OverNightTripBenefitFlow();

			dbOtherBenefitRate = new OtherBenefitRateDB();
		}

		#region - Private Method -
		private void changeWorkingtimeFormOTHour(EmployeeBenefit value)
		{
			WorkInfo workInfo;
			BenefitOTHour benefitOTHour;
			for(int i=0; i<value.BenefitOTHourList.Count; i++)
			{
				benefitOTHour = value.BenefitOTHourList[i];
				if(benefitOTHour.DuringTime1.From != NullConstant.DATETIME && benefitOTHour.DuringTime2.To != NullConstant.DATETIME)
				{
					workInfo = value.WorkInfoList[benefitOTHour.BenefitDate];
					workInfo.WorkingTime.From = benefitOTHour.DuringTime1.From;
					workInfo.WorkingTime.To = benefitOTHour.DuringTime2.To;				
				}
			}
			workInfo = null;
			benefitOTHour = null;
		}

		private bool isExitingOvertimeHour(BenefitOTHour value)
		{
			if(value.BeforeTime.From != NullConstant.DATETIME || value.BeforeTime.To != NullConstant.DATETIME)
			{
				return true;
			}
			if(value.BreakTime.From != NullConstant.DATETIME || value.BreakTime.To != NullConstant.DATETIME)
			{
				return true;
			}
			if(value.AfterTime.From != NullConstant.DATETIME || value.AfterTime.To != NullConstant.DATETIME)
			{
				return true;
			}
			return false;
		}

		private void fillEmployeeOvertimeHour(EmployeeOvertimeHour value, EmployeeBenefit employeeBenefit)
		{
			OvertimeHour overtimeHour;
			for(int i=0; i<employeeBenefit.BenefitOTHourList.Count; i++)
			{
				if(isExitingOvertimeHour(employeeBenefit.BenefitOTHourList[i]))
				{
					overtimeHour = new OvertimeHour(employeeBenefit.BenefitOTHourList[i].BenefitDate);
					overtimeHour.AAfterTimePeriod = employeeBenefit.BenefitOTHourList[i].AfterTime;
					overtimeHour.ABeforeTimePeriod = employeeBenefit.BenefitOTHourList[i].BeforeTime;
					overtimeHour.ABreakTimePeriod = employeeBenefit.BenefitOTHourList[i].BreakTime;
					overtimeHour.ADuringTimePeriod.From = employeeBenefit.WorkInfoList[overtimeHour.OtDate].WorkingTime.From;
					overtimeHour.ADuringTimePeriod.To = employeeBenefit.WorkInfoList[overtimeHour.OtDate].WorkingTime.To;
					
					overtimeHour.AOTRate = new OTRate();					
					if(employeeBenefit.BenefitOTHourList[i].OTRate.OtAHour==NullConstant.DECIMAL)
					{
						overtimeHour.AOTRate.OtAHour = 0;
					}
					else
					{
						overtimeHour.AOTRate.OtAHour = employeeBenefit.BenefitOTHourList[i].OTRate.OtAHour;
					}
					if(employeeBenefit.BenefitOTHourList[i].OTRate.OtBHour==NullConstant.DECIMAL)
					{
						overtimeHour.AOTRate.OtBHour = 0;
					}
					else
					{
						overtimeHour.AOTRate.OtBHour = employeeBenefit.BenefitOTHourList[i].OTRate.OtBHour;
					}
					if(employeeBenefit.BenefitOTHourList[i].OTRate.OtCHour==NullConstant.DECIMAL)
					{
						overtimeHour.AOTRate.OtCHour = 0;
					}
					else
					{
						overtimeHour.AOTRate.OtCHour = employeeBenefit.BenefitOTHourList[i].OTRate.OtCHour;
					}

					overtimeHour.AOTRateForCharge = new OTRate();
					if(employeeBenefit.BenefitOTHourList[i].OTRateForCharge.OtAHour==NullConstant.DECIMAL)
					{
						overtimeHour.AOTRateForCharge.OtAHour = 0;
					}
					else
					{
						overtimeHour.AOTRateForCharge.OtAHour = employeeBenefit.BenefitOTHourList[i].OTRateForCharge.OtAHour;
					}
					if(employeeBenefit.BenefitOTHourList[i].OTRateForCharge.OtBHour==NullConstant.DECIMAL)
					{
						overtimeHour.AOTRateForCharge.OtBHour = 0;
					}
					else
					{
						overtimeHour.AOTRateForCharge.OtBHour = employeeBenefit.BenefitOTHourList[i].OTRateForCharge.OtBHour;
					}
					if(employeeBenefit.BenefitOTHourList[i].OTRateForCharge.OtCHour==NullConstant.DECIMAL)
					{
						overtimeHour.AOTRateForCharge.OtCHour = 0;
					}
					else
					{
						overtimeHour.AOTRateForCharge.OtCHour = employeeBenefit.BenefitOTHourList[i].OTRateForCharge.OtCHour;
					}

					overtimeHour.OtReason = employeeBenefit.BenefitOTHourList[i].Reason;
					value.Add(overtimeHour);				
				}
			}	
			overtimeHour = null;
		}

		private void fillEmployeeFoodBenefit(EmployeeFoodBenefit value, EmployeeBenefit employeeBenefit)
		{
			FoodBenefit foodBenefit;
			for(int i=0; i<employeeBenefit.BenefitFoodList.Count; i++)
			{
				foodBenefit = new FoodBenefit();
				foodBenefit.BenefitDate = employeeBenefit.BenefitFoodList[i].BenefitDate;
				if(employeeBenefit.BenefitFoodList[i].Amount==NullConstant.DECIMAL)
				{
					foodBenefit.TotalAmount = 0;
				}
				else
				{
					foodBenefit.TotalAmount = employeeBenefit.BenefitFoodList[i].Amount;
				}				
				foodBenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;
				foodBenefit.ABenefitPayment.PaymentDate = employeeBenefit.BenefitFoodList[i].BenefitDate;
				value.Add(foodBenefit);
			}	
			foodBenefit = null;
		}

		private void fillEmployeeTaxiBenefit(EmployeeTaxiBenefit value, EmployeeBenefit employeeBenefit)
		{
			TaxiBenefit taxiBenefit;
			for(int i=0; i<employeeBenefit.BenefitTaxiList.Count; i++)
			{
				taxiBenefit = new TaxiBenefit();
				taxiBenefit.BenefitDate = employeeBenefit.BenefitTaxiList[i].BenefitDate; 
				if(employeeBenefit.BenefitTaxiList[i].Amount==NullConstant.DECIMAL)
				{
					taxiBenefit.BaseAmount = 0;
				}
				else
				{
					taxiBenefit.BaseAmount = employeeBenefit.BenefitTaxiList[i].Amount;
				}
				taxiBenefit.Times = (byte)employeeBenefit.BenefitTaxiList[i].Times;
				if(taxiBenefit.Times<0)
				{
					taxiBenefit.Times = 0;
				}
				if(employeeBenefit.BenefitTaxiList[i].TotalAmount==NullConstant.DECIMAL)
				{
					taxiBenefit.TotalAmount = 0;
				}
				else
				{
					taxiBenefit.TotalAmount = employeeBenefit.BenefitTaxiList[i].TotalAmount;
				}
				value.Add(taxiBenefit);
			}
			taxiBenefit = null;
		}

		private void fillEmployeeTaxiBenefitForCharge(EmployeeTaxiBenefit value, EmployeeBenefit employeeBenefit)
		{
			TaxiBenefit taxiBenefit;
			BenefitTaxi benefitTaxi;
			for(int i=0; i<employeeBenefit.BenefitTaxiListForCharge.Count; i++)
			{
				benefitTaxi = employeeBenefit.BenefitTaxiListForCharge[i];
				if(value.Contain(benefitTaxi.EntityKey))
				{
					taxiBenefit = value[benefitTaxi.EntityKey];
				}
				else
				{
					taxiBenefit = new TaxiBenefit();
					taxiBenefit.BenefitDate = benefitTaxi.BenefitDate;

					value.Add(taxiBenefit);
				}

				if(benefitTaxi.Amount==NullConstant.DECIMAL)
				{
					taxiBenefit.BenefitAmountForCharge = 0;
				}
				else
				{
					taxiBenefit.BenefitAmountForCharge = benefitTaxi.Amount;
				}

				taxiBenefit.TimesForCharge = (byte)benefitTaxi.Times;
				if(taxiBenefit.TimesForCharge<0)
				{
					taxiBenefit.TimesForCharge = 0;
				}

				if(benefitTaxi.TotalAmount==NullConstant.DECIMAL)
				{
					taxiBenefit.BenefitTotalAmountForCharge = 0;
				}
				else
				{
					taxiBenefit.BenefitTotalAmountForCharge = benefitTaxi.TotalAmount;
				}
			}
			taxiBenefit = null;
			benefitTaxi = null;
		}

		private void fillEmployeeOneDayTripBenefit(EmployeeOneDayTripBenefit value)
		{
			for(int i=0; i<value.Count; i++)
			{
				if(value[i].TotalAmount<0)
				{					
					value[i].TotalAmount = 0;
				}

				if(value[i].BenefitAmount<0)
				{
					value[i].BenefitAmount = 0;
				}
			}
		}

		private void fillEmployeeOverNightTripBenefit(EmployeeBenefit value)
		{
			for(int i=0; i<value.OvernightTripBenefit.CurrentMonth.Count; i++)
			{
				if(!flowOverNightTripBenefit.FillCustomer(value.OvernightTripBenefit.CurrentMonth[i], value))
				{
					DateTime dateFrom = value.OvernightTripBenefit.CurrentMonth[i].From;
					DateTime dateTo = value.OvernightTripBenefit.CurrentMonth[i].To;
					throw new NotFoundException("การจ่ายงานในช่วงเวลาตั้งแต่ " + dateFrom + " จนถึง " + dateTo, "EmployeeBenefitFlow");
				}
				if(value.OvernightTripBenefit.CurrentMonth[i].Amount<0)
				{
					value.OvernightTripBenefit.CurrentMonth[i].Amount = 0;
				}
			}
		}

		private bool fillOtherBenefitRate(EmployeeBenefit value)
		{
			OtherBenefitRate otherBenefitRate = value.OtherBenefitRate;
			return dbOtherBenefitRate.FillOtherBenefitRate(ref otherBenefitRate, value.Employee.Company);
		}
		#endregion

		//============================== Public Method ==============================
		public bool FillEmployeeBenefit(EmployeeBenefit value)
		{
			bool result;
			if(flowWorkInfo.FillWorkInfoList(value.WorkInfoList))
			{
				result = true;

				flowOTBenefit.FillOTHourList(value);
				changeWorkingtimeFormOTHour(value);

				if(fillOtherBenefitRate(value))
				{
					flowFoodBenefit.FillFoodBenefit(value);
					flowTaxiBenefit.FillTaxiBenefit(value);
					flowOneDayTripBenefit.FillOneDayTripBenefit(value);
					flowOverNightTripBenefit.FillOverNightTripBenefit(value);
				}
			}
			else
			{
				result = false;
			}
			
			return result;
		}

		public bool FillCustomer(BenefitOvernightTrip value, EmployeeBenefit employeeBenefit)
		{
			return flowOverNightTripBenefit.FillCustomer(value, employeeBenefit);
		}

		public void FillWorkSchedule(EmployeeBenefit value)
		{
			flowWorkInfo.FillWorkInfoList(value.WorkInfoList);
		}

		public bool CalculateBenefit(EmployeeBenefit value)
		{
			bool result = true;
			flowOTBenefit.CalculateOT(value);
//			if(value.Employee.APosition.PositionCode == "28")
//			{
				flowFoodBenefit.CalculateFoodBenefit(value);
				flowTaxiBenefit.CalculateTaxiBenefit(value);
				flowOneDayTripBenefit.CalculateOneDayTripBenefit(value);
				result = result && flowOverNightTripBenefit.CalculateOverNightTripBenefit(value);
//			}
//			else
//			{
//				value.BenefitFoodList.Clear();
//				value.BenefitTaxiList.Clear();
//			}
			return result;
		}

		public bool CalculateBenefit(int index, EmployeeBenefit value)
		{
			bool result = true;
			flowOTBenefit.CalculateOT(value.BenefitOTHourList[index], value);
			if(value.Employee.APosition.PositionCode == "28")
			{
				flowFoodBenefit.CalculateFoodBenefit(index, value);
				flowTaxiBenefit.CalculateTaxiBenefit(index, value);
				flowOneDayTripBenefit.CalculateOneDayTripBenefit(value);
				result = result && flowOverNightTripBenefit.CalculateOverNightTripBenefit(value);
			}
			else
			{
				value.BenefitFoodList.Clear();
				value.BenefitTaxiList.Clear();
			}
			return result;
		}

		public bool UpdateEmployeeBenefit(EmployeeBenefit value)
		{
			bool result = true;

//			if(!CalculateBenefit(value))
//			{
//				return false;
//			}
			
			EmployeeOvertimeHour employeeOvertimeHour = new EmployeeOvertimeHour(value.Employee, value.ForMonth);
			fillEmployeeOvertimeHour(employeeOvertimeHour, value);

			EmployeeFoodBenefit employeeFoodBenefit = new EmployeeFoodBenefit(value.Employee, value.ForMonth);
			fillEmployeeFoodBenefit(employeeFoodBenefit, value);

            EmployeeTaxiBenefit employeeTaxiBenefit = new EmployeeTaxiBenefit(value.Employee, value.ForMonth);
			fillEmployeeTaxiBenefit(employeeTaxiBenefit, value);
			fillEmployeeTaxiBenefitForCharge(employeeTaxiBenefit, value);

			fillEmployeeOneDayTripBenefit(value.OneDayTripBenefit);

			fillEmployeeOverNightTripBenefit(value);

			EmployeeOvertimeHourDB tdbEmployeeOvertimeHour = new EmployeeOvertimeHourDB();
			EmployeeFoodBenefitDB tdbEmployeeFoodBenefit = new EmployeeFoodBenefitDB();
			tdbEmployeeFoodBenefit.TableAccess = tdbEmployeeOvertimeHour.TableAccess;
			EmployeeTaxiBenefitDB tdbEmployeeTaxiBenefit = new EmployeeTaxiBenefitDB();
			tdbEmployeeTaxiBenefit.TableAccess = tdbEmployeeOvertimeHour.TableAccess;
			EmployeeOneDayTripBenefitDB tdbEmployeeOneDayTripBenefit = new EmployeeOneDayTripBenefitDB();
			tdbEmployeeOneDayTripBenefit.TableAccess = tdbEmployeeOvertimeHour.TableAccess;
			EmployeeOvernightTripBenefitDB tdbEmployeeOvernightTripBenefit = new EmployeeOvernightTripBenefitDB();
			tdbEmployeeOvernightTripBenefit.TableAccess = tdbEmployeeOvertimeHour.TableAccess;

			try
			{
				tdbEmployeeOvertimeHour.TableAccess.OpenTransaction();

				result = result && tdbEmployeeOvertimeHour.UpdateEmployeeOvertimeHour(employeeOvertimeHour);
				result = result && tdbEmployeeFoodBenefit.UpdateEmployeeFoodBenefit(employeeFoodBenefit);
				result = result && tdbEmployeeTaxiBenefit.UpdateEmployeeTaxiBenefit(employeeTaxiBenefit);
				result = result && tdbEmployeeOneDayTripBenefit.UpdateEmployeeOneDayTripBenefit(value.OneDayTripBenefit);
				result = result && tdbEmployeeOvernightTripBenefit.UpdateEmployeeOvernightTripBenefitList(value.OvernightTripBenefit.CurrentMonth);

				if(result)
				{
					tdbEmployeeOvertimeHour.TableAccess.Transaction.Commit();
				}
				else
				{
					tdbEmployeeOvertimeHour.TableAccess.Transaction.Rollback();
				}
			}
            catch (SqlException ex)
            {
                tdbEmployeeOvertimeHour.TableAccess.Transaction.Rollback();
                throw ex;
            }
			catch(Exception ex)
			{
				tdbEmployeeOvertimeHour.TableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				tdbEmployeeOvertimeHour.TableAccess.CloseConnection();

				tdbEmployeeOvertimeHour = null;
				tdbEmployeeFoodBenefit = null;
				tdbEmployeeTaxiBenefit = null;
				tdbEmployeeOneDayTripBenefit = null;
				tdbEmployeeOvernightTripBenefit = null;

				employeeOvertimeHour = null;
				employeeFoodBenefit = null;
				employeeTaxiBenefit = null;
			}

			return result;
		}
	}
}