using System;
using System.Collections;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Flow.AttendanceFlow;
using PTB.BTS.Common.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class EmployeeFoodBenefitFacade : EmployeeAttendanceFacadeBase
	{
		#region - Private -
		private EmployeeFoodBenefitFlow flowEmployeeFoodBenefit;
		#endregion

//		============================== Property ==============================
		private EmployeeFoodBenefit objEmployeeFoodBenefit;
		public EmployeeFoodBenefit ObjEmployeeFoodBenefit
		{
			get{return objEmployeeFoodBenefit;}
			set{objEmployeeFoodBenefit = value;}
		}

//		============================== Constructor ==============================
		public EmployeeFoodBenefitFacade() : base()
		{
			flowEmployeeFoodBenefit = new EmployeeFoodBenefitFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayEmployeeFoodBenefit(DateTime forDate)
		{
			YearMonth yearMonth = new YearMonth(forDate);
			objEmployeeFoodBenefit = new EmployeeFoodBenefit(Employee, yearMonth);
			return flowEmployeeFoodBenefit.FillFoodBenefitList(ref objEmployeeFoodBenefit);		
		}

		public bool InsertFoodBenefit(FoodBenefit value)
		{
			if (objEmployeeFoodBenefit.Contain(value))
			{
				throw new DuplicateException("EmployeeFoodBenefitFacade");
			}
			else
			{
				if (flowEmployeeFoodBenefit.InsertFoodBenefit(value, objEmployeeFoodBenefit.Employee))
				{
					objEmployeeFoodBenefit.Add(value);
					return true;
				}
				return false;
			}
		}

		public bool UpdateFoodBenefit(FoodBenefit value)
		{
			if (flowEmployeeFoodBenefit.UpdateFoodBenefit(value, objEmployeeFoodBenefit.Employee))
			{
				objEmployeeFoodBenefit[value.EntityKey] = value;
				return true;
			}
			return false;	
		}
		
		public bool DeleteFoodBenefit(FoodBenefit value)
		{
			if (flowEmployeeFoodBenefit.DeleteFoodBenefit(value, objEmployeeFoodBenefit.Employee))
			{
				objEmployeeFoodBenefit.Remove(value);
				return true;
			}
			return false;		
		}
	}
}
