using System;
using System.Collections;
using System.Data;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.AttendanceEntities;
using Entity.ContractEntities;

using Flow.AttendanceFlow;
using PTB.BTS.PI.Flow;
using PTB.BTS.Contract.Flow;
using PTB.BTS.Common.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class EmployeeTelephoneBenefitFacade : EmployeeAttendanceFacadeBase
	{
		#region - Private -
		private EmployeeTelephoneBenefitFlow flowEmployeeTelephoneBenefit;
		#endregion

//		============================== Property ==============================
		private EmployeeTelephoneBenefit objEmployeeTelephoneBenefit;
		public EmployeeTelephoneBenefit ObjEmployeeTelephoneBenefit
		{
			get{return objEmployeeTelephoneBenefit;}
			set{objEmployeeTelephoneBenefit = value;}
		}

//		============================== Constructor ==============================
		public EmployeeTelephoneBenefitFacade()
		{
			flowEmployeeTelephoneBenefit = new EmployeeTelephoneBenefitFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayTelephoneBenefit(DateTime forDate)
		{	
			objEmployeeTelephoneBenefit = new EmployeeTelephoneBenefit(Employee);
			TelephoneBenefit telephoneBenefit = new TelephoneBenefit();
			YearMonth yearMonth = new YearMonth(forDate.Year, -1);
			telephoneBenefit.AYearMonth = yearMonth;
			return flowEmployeeTelephoneBenefit.FillTelephoneBenefitList(ref objEmployeeTelephoneBenefit, telephoneBenefit);
		}

		public bool InsertTelephoneBenefit(TelephoneBenefit value)
		{
			if (objEmployeeTelephoneBenefit.Contain(value))
			{
				throw new DuplicateException("EmployeeTelephoneBenefitFacade");
			}
			else
			{
				if(flowEmployeeTelephoneBenefit.InsertTelephoneBenefit(value, objEmployeeTelephoneBenefit.Employee))
				{
					objEmployeeTelephoneBenefit.Add(value);
					return true;
				}
				else
				{return false;}
			}
		}

		public bool UpdateTelephoneBenefit(TelephoneBenefit value)
		{
			if (flowEmployeeTelephoneBenefit.UpdateTelephoneBenefit(value, objEmployeeTelephoneBenefit.Employee))
			{
				objEmployeeTelephoneBenefit[value.EntityKey] = value;
				return true;
			}
			return false;
		}
		
		public bool DeleteTelephoneBenefit(TelephoneBenefit value)
		{
			if(flowEmployeeTelephoneBenefit.DeleteTelephoneBenefit(value, objEmployeeTelephoneBenefit.Employee))
			{
				objEmployeeTelephoneBenefit.Remove(value);
				return true;
			}
			return false;
		}		
	}
}
