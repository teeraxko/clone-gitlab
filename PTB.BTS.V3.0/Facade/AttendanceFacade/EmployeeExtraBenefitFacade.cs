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
	public class EmployeeExtraBenefitFacade : EmployeeAttendanceFacadeBase
	{
		#region - Private -
		private EmployeeExtraBenefitFlow flowEmployeeExtraBenefit;
		#endregion

//		============================== Property ==============================
		private EmployeeExtraBenefit objEmployeeExtraBenefit;
		public EmployeeExtraBenefit ObjEmployeeExtraBenefit
		{
			get{return objEmployeeExtraBenefit;}
			set{objEmployeeExtraBenefit = value;}
		}

//		============================== Constructor ==============================
		public EmployeeExtraBenefitFacade() : base()
		{
			flowEmployeeExtraBenefit = new EmployeeExtraBenefitFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayEmployeeExtraBenefit(DateTime forDate)
		{
			objEmployeeExtraBenefit = new EmployeeExtraBenefit(Employee);
			ExtraBenefit extraBenefit = new ExtraBenefit();
			YearMonth yearMonth = new YearMonth(forDate.Year, -1);
			extraBenefit.AYearMonth = yearMonth;
			return flowEmployeeExtraBenefit.FillEmployeeExtraBenefit(ref objEmployeeExtraBenefit, extraBenefit);		
		}

		public bool InsertExtraBenefit(ExtraBenefit value)
		{
			if (objEmployeeExtraBenefit.Contain(value))
			{
				throw new DuplicateException("EmployeeExtraBenefitFacade");
			}
			else
			{
				if (flowEmployeeExtraBenefit.InsertExtraBenefit(value, objEmployeeExtraBenefit.Employee))
				{
					objEmployeeExtraBenefit.Add(value);
					return true;
				}
				return false;
			}
		}

		public bool UpdateExtraBenefit(ExtraBenefit value)
		{
			if (flowEmployeeExtraBenefit.UpdateExtraBenefit(value, objEmployeeExtraBenefit.Employee))
			{
				objEmployeeExtraBenefit[value.EntityKey] = value;
				return true;
			}
			return false;	
		}
		
		public bool DeleteExtraBenefit(ExtraBenefit value)
		{
			if (flowEmployeeExtraBenefit.DeleteExtraBenefit(value, objEmployeeExtraBenefit.Employee))
			{
				objEmployeeExtraBenefit.Remove(value);
				return true;
			}
			return false;		
		}
	}
}
