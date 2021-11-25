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
	public class EmployeeBenefitAdjustmentFacade : CommonPIFacadeBase
	{
		#region - Private -
		private EmployeeBenefitAdjustmentFlow flowEmployeeBenefitAdjustment;
		private OtherBenefitRateFlow flowOtherBenefitRate;
		#endregion

//		============================== Property ==============================
		private EmployeeBenefitAdjustment objEmployeeBenefitAdjustment;
		public EmployeeBenefitAdjustment ObjEmployeeBenefitAdjustment
		{
			get{return objEmployeeBenefitAdjustment;}
			set{objEmployeeBenefitAdjustment = value;}
		}

		private OtherBenefitRate objOtherBenefitRate;
		public OtherBenefitRate ObjOtherBenefitRate
		{
			get{return objOtherBenefitRate;}
			set{objOtherBenefitRate = value;}
		}

//		============================== Constructor ==============================
		public EmployeeBenefitAdjustmentFacade() : base()
		{
			flowEmployeeBenefitAdjustment = new EmployeeBenefitAdjustmentFlow();
			flowOtherBenefitRate = new OtherBenefitRateFlow();
		}

		public bool DisplayEmployeeBenefitAdjustment(DateTime forDate)
		{
			YearMonth yearMonth = new YearMonth(forDate);
			objEmployeeBenefitAdjustment = new EmployeeBenefitAdjustment(GetCompany(), yearMonth);

			objOtherBenefitRate = new OtherBenefitRate();
			flowOtherBenefitRate.FillOtherBenefitRate(ref objOtherBenefitRate, objEmployeeBenefitAdjustment.Company);

			return flowEmployeeBenefitAdjustment.FillEmployeeBenefitAdjustment(ref objEmployeeBenefitAdjustment);		
		}

		public bool InsertBenefitAdjustment(BenefitAdjustment value)
		{
			if (objEmployeeBenefitAdjustment.Contain(value))
			{
				throw new DuplicateException("EmployeeBenefitAdjustmentFacade");
			}
			else
			{
				if (flowEmployeeBenefitAdjustment.InsertBenefitAdjustment(value, objEmployeeBenefitAdjustment.Company))
				{
					objEmployeeBenefitAdjustment.Add(value);
					return true;
				}
				return false;
			}
		}

		public bool UpdateBenefitAdjustment(BenefitAdjustment value)
		{
			if (flowEmployeeBenefitAdjustment.UpdateBenefitAdjustment(value, objEmployeeBenefitAdjustment.Company))
			{
				objEmployeeBenefitAdjustment[value.EntityKey] = value;
				return true;
			}
			return false;	
		}
		
		public bool DeleteBenefitAdjustment(BenefitAdjustment value)
		{
			if (flowEmployeeBenefitAdjustment.DeleteBenefitAdjustment(value, objEmployeeBenefitAdjustment.Company))
			{
				objEmployeeBenefitAdjustment.Remove(value);
				return true;
			}
			return false;		
		}
	}
}
