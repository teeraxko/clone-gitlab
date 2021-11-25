using System;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Attendance.Benefit.Flow
{
	public class FoodBenefitFlow : FlowBase
	{
		#region - Private -
			private EmployeeFoodBenefitDB dbEmployeeFoodBenefit;
		#endregion

		//============================== Constructor ==============================
		public FoodBenefitFlow() : base()
		{
			dbEmployeeFoodBenefit = new EmployeeFoodBenefitDB();
		}

		#region - Private Method -
			public bool hasBenefitFood(WorkInfo value)
			{
				return (value.AssignServiceStaffType.Type == "282");
			}
		#endregion

		//============================== Public Method ==============================
		public void CalculateFoodBenefit(EmployeeBenefit value)
		{
			BenefitFood benefitFood;
			value.BenefitFoodList.Clear();
			
			for(int i=0; i<value.WorkInfoList.Count; i++)
			{
				if(value.WorkInfoList[i].AssignServiceStaffType.APosition.PositionCode == "28")
				{
					if(hasBenefitFood(value.WorkInfoList[i]) && value.BenefitOTHourList.Contain(value.WorkInfoList[i].BenefitDate) && value.BenefitOTHourList[value.WorkInfoList[i].BenefitDate].ValidOTHour)
					{
						benefitFood = new BenefitFood(value.WorkInfoList[i].BenefitDate);
						benefitFood.Times = 1;
						benefitFood.Amount = benefitFood.Times * value.OtherBenefitRate.FoodRate;
						value.BenefitFoodList.Add(benefitFood);
					}				
				}
			}
			CalculateTotalFoodBenefit(value);
			benefitFood = null;
		}

		public void CalculateFoodBenefit(int index, EmployeeBenefit value)
		{
			BenefitFood benefitFood;
			if(value.BenefitFoodList.Contain(value.WorkInfoList[index].BenefitDate))
			{
				value.BenefitFoodList.Remove(value.WorkInfoList[index].EntityKey);
			}
			if(hasBenefitFood(value.WorkInfoList[index]) && value.BenefitOTHourList.Contain(value.WorkInfoList[index].BenefitDate) && value.BenefitOTHourList[value.WorkInfoList[index].BenefitDate].ValidOTHour)
			{
				if(value.BenefitFoodList.Contain(value.WorkInfoList[index].BenefitDate))
				{
					benefitFood = value.BenefitFoodList[value.WorkInfoList[index].BenefitDate];
				}
				else
				{
					benefitFood = new BenefitFood(value.WorkInfoList[index].BenefitDate);
					value.BenefitFoodList.Add(benefitFood);
				}
				benefitFood.Times = 1;
				benefitFood.Amount = benefitFood.Times * value.OtherBenefitRate.FoodRate;
				CalculateTotalFoodBenefit(value);
			}
			benefitFood = null;
		}

		public void CalculateTotalFoodBenefit(EmployeeBenefit value)
		{
			value.BenefitFoodList.TotalTimes = 0;
			value.BenefitFoodList.TotalAmount = 0;

			for(int i=0; i<value.BenefitFoodList.Count; i++)
			{
				value.BenefitFoodList.TotalTimes += value.BenefitFoodList[i].Times;
				value.BenefitFoodList.TotalAmount += value.BenefitFoodList[i].Amount;
			}
		}

		public void FillFoodBenefit(EmployeeBenefit value)
		{
			BenefitFood benefitFood;
			value.BenefitFoodList.Clear();

			EmployeeFoodBenefit employeeFoodBenefit = new EmployeeFoodBenefit(value.Employee, value.ForMonth);
			if(dbEmployeeFoodBenefit.FillFoodBenefitList(ref employeeFoodBenefit))
			{
				for(int i=0; i<employeeFoodBenefit.Count; i++)
				{
					benefitFood = new BenefitFood(employeeFoodBenefit[i].BenefitDate);
					benefitFood.Amount = employeeFoodBenefit[i].TotalAmount;
					benefitFood.Times = (int)benefitFood.Amount/value.OtherBenefitRate.FoodRate;
					value.BenefitFoodList.Add(benefitFood);
				}			
			}

			CalculateTotalFoodBenefit(value);

			employeeFoodBenefit = null;
			benefitFood = null;
		}
	}
}