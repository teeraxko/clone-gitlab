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
	public class EmployeeExtraAGTBenefitFacade : CommonPIFacadeBase
	{
		#region - Private -
		private EmployeeExtraAGTBenefitFlow flowEmployeeExtraAGTBenefit;
		private EmployeeExtraAGTBenefitDeductionFlow flowEmployeeExtraAGTBenefitDeduction;
		#endregion

//		============================== Property ==============================
		private EmployeeExtraAGTBenefitDeduction objEmployeeExtraAGTBenefitDeduction;
		public EmployeeExtraAGTBenefitDeduction ObjEmployeeExtraAGTBenefitDeduction
		{
			get{return objEmployeeExtraAGTBenefitDeduction;}
//			set{objEmployeeExtraAGTBenefitDeduction = value;}
		}

		private ExtraAGTBenefit objExtraAGTBenefit;
		public ExtraAGTBenefit ObjExtraAGTBenefit
		{
			get{return objExtraAGTBenefit;}
		}

//		============================== Constructor ==============================
		public EmployeeExtraAGTBenefitFacade() : base()
		{
			flowEmployeeExtraAGTBenefit = new EmployeeExtraAGTBenefitFlow();
			flowEmployeeExtraAGTBenefitDeduction = new EmployeeExtraAGTBenefitDeductionFlow();
		}

//		============================== Public Method ==============================
		public YearMonth CalculateAge(DateTime birthDate)
		{
			AgeFlow flowAge = new AgeFlow();
			return flowAge.CalculateAge(birthDate);
		}

		public bool DisplayEmployeeExtraAGTBenefit(Employee aEmployee, DateTime forDate)
		{			
			objExtraAGTBenefit = new ExtraAGTBenefit();
			YearMonth yearMonth = new YearMonth(forDate);
			objExtraAGTBenefit.AYearMonth = yearMonth;

			return flowEmployeeExtraAGTBenefit.FillExtraAGTBenefit(ref objExtraAGTBenefit, aEmployee);
		}

		public bool DisplayEmployeeExtraAGTBenefitDeduction(Employee aEmployee, DateTime forDate)
		{
			ExtraAGTBenefitDeduction extraAGTBenefitDeduction = new ExtraAGTBenefitDeduction();
			YearMonth yearMonth = new YearMonth(forDate);
			objEmployeeExtraAGTBenefitDeduction = new EmployeeExtraAGTBenefitDeduction(aEmployee);
			extraAGTBenefitDeduction.AYearMonth = yearMonth;

			return flowEmployeeExtraAGTBenefitDeduction.FillEmployeeExtraAGTBenefitDeduction(ref objEmployeeExtraAGTBenefitDeduction, extraAGTBenefitDeduction);
		}
	}
}
