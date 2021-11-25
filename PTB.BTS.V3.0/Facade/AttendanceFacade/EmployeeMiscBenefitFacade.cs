using System;
using System.Collections;
using System.Data;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Flow.AttendanceFlow;
using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class EmployeeMiscBenefitFacade : EmployeeAttendanceFacadeBase
	{
		#region - Private -
		protected EmployeeMiscBenefitFlow flowEmployeeMisc;
		#endregion

//		============================== Property ==============================
		private EmployeeMiscBenefit objEmployeeMiscBenefit;
		public EmployeeMiscBenefit ObjEmployeeMiscBenefit
		{
			get{return objEmployeeMiscBenefit;}
			set{objEmployeeMiscBenefit = value;}
		}

//		============================== Constructor ==============================
		public EmployeeMiscBenefitFacade() : base()
		{
			flowEmployeeMisc = new EmployeeMiscBenefitFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayMiscellaneousBenefit(DateTime forDate)
		{	
			objEmployeeMiscBenefit = new EmployeeMiscBenefit(Employee);
			YearMonth yearMonth = new YearMonth(forDate);
			MiscBenefit miscBenefit = new MiscBenefit();
			miscBenefit.AYearMonth = yearMonth;

			return flowEmployeeMisc.FillMiscellaneousBenefitList(ref objEmployeeMiscBenefit, miscBenefit);
		}

		public bool InsertMiscellaneousBenefit(MiscBenefit value)
		{
			if (objEmployeeMiscBenefit.Contain(value))
			{
				throw new DuplicateException("EmployeeMiscBenefitFacade");
			}
			else
			{
				if(flowEmployeeMisc.InsertMiscellaneousBenefit(value, objEmployeeMiscBenefit.Employee))
				{
					objEmployeeMiscBenefit.Add(value);
					return true;
				}
				else
				{return false;}
			}
		}

		public bool UpdateMiscellaneousBenefit(MiscBenefit value)
		{
			if (flowEmployeeMisc.UpdateMiscellaneousBenefit(value, objEmployeeMiscBenefit.Employee))
			{
				objEmployeeMiscBenefit[value.EntityKey] = value;
				return true;
			}
			return false;
		}
		
		public bool DeleteMiscellaneousBenefit(MiscBenefit value)
		{
			if(flowEmployeeMisc.DeleteMiscellaneousBenefit(value, objEmployeeMiscBenefit.Employee))
			{
				objEmployeeMiscBenefit.Remove(value);
				return true;
			}
			return false;
		}		
	}
}
