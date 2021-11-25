using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.AttendanceEntities;
using Entity.ContractEntities;

using Flow.AttendanceFlow;
using PTB.BTS.Contract.Flow;
using PTB.BTS.PI.Flow;
using PTB.BTS.Attendance.OtherBenefit.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class GenerateOtherBenefitFacade : CommonPIFacadeBase
	{
		#region - Private -
		private bool disposed = false;
		private OtherBenefitFlow flowOtherBenefit;
		private EmployeeExtraBenefitFlow flowEmployeeExtraBenefit;
		private ServiceStaffAssignmentFlow flowServiceStaffAssignment;
		private OtherBenefitRateFlow flowOtherBenefitRate;
		private EmployeeFlow flowEmployee;
		#endregion

//		============================== Property ==============================
		private EmployeeExtraBenefitList objEmployeeExtraBenefitList;
		public EmployeeExtraBenefitList ObjEmployeeExtraBenefitList
		{
			get{return objEmployeeExtraBenefitList;}
		}

		public EmployeeExtraBenefitList ObjTimeCardEmployeeBenefitList
		{
			get{return flowOtherBenefit.ObjEmployeeExtraBenefitList;}
		}

		private ServiceStaffAssignmentList objServiceStaffAssignmentList;
		public ServiceStaffAssignmentList ObjServiceStaffAssignmentList
		{
			get{return objServiceStaffAssignmentList;}
		}

		private ServiceStaffAssignmentList objServiceStaffAssignmentConditionList;
		public ServiceStaffAssignmentList ObjServiceStaffAssignmentConditionList
		{
			get{return objServiceStaffAssignmentConditionList;}
		}

		private EmployeeList objEmployeeList;
		public EmployeeList ObjEmployeeList
		{
			get{return objEmployeeList;}
		}
//		============================== Constructor ==============================
		public GenerateOtherBenefitFacade() : base()
		{
			flowOtherBenefit = new OtherBenefitFlow();
			flowEmployeeExtraBenefit = new EmployeeExtraBenefitFlow();
			flowServiceStaffAssignment = new ServiceStaffAssignmentFlow();
			flowEmployee = new EmployeeFlow();
			flowOtherBenefitRate = new OtherBenefitRateFlow();
		}

//		============================== Public Method ==============================
		public bool GenerateOtherBenefit(EmployeeExtraBenefitList value, YearMonth yearMonth)
		{
			return flowOtherBenefit.GenerateOtherBenefit(value, yearMonth);
		}

		public bool DisplayEmployeeExtraBenefit(YearMonth yearMonth)
		{
			objEmployeeExtraBenefitList = new EmployeeExtraBenefitList(GetCompany());
			return flowEmployeeExtraBenefit.FillEmployeeExtraBenefitList(ref objEmployeeExtraBenefitList, yearMonth);
		}

		public bool FillServiceStaffAssignmentInPeriodList(YearMonth yearMonth)
		{
			objServiceStaffAssignmentList = new ServiceStaffAssignmentList(GetCompany());
			return flowServiceStaffAssignment.FillServiceStaffAssignmentInPeriodList(ref objServiceStaffAssignmentList, yearMonth);
		}

		public bool GetServiceStaffAssignmentInPeriodList(Employee aEmployee, YearMonth yearMonth)
		{
			ServiceStaff serviceStaff = new ServiceStaff(aEmployee);
			objServiceStaffAssignmentConditionList = new ServiceStaffAssignmentList(serviceStaff, GetCompany());
			return flowServiceStaffAssignment.FillServiceStaffAssignmentInPeriodList(ref objServiceStaffAssignmentConditionList, yearMonth);
		}

		public bool FillEmployeeList()
		{
			objEmployeeList = new EmployeeList(GetCompany());
			return flowEmployee.FillAllEmployeeList(objEmployeeList);
		}

		public bool CalculateOtherBenefit(YearMonth yearMonth)
		{
			objServiceStaffAssignmentList = new ServiceStaffAssignmentList(GetCompany());

			if (flowServiceStaffAssignment.FillServiceStaffAssignmentInPeriodList(ref objServiceStaffAssignmentList, yearMonth))
			{
				return flowOtherBenefit.CalculateOtherBenefit(objServiceStaffAssignmentList, yearMonth);				
			}
			return false;
		}

		public bool FillOtherBenefitRete(ref OtherBenefitRate value)
		{
			return flowOtherBenefitRate.FillOtherBenefitRate(ref value, GetCompany());		  
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						flowOtherBenefit.Dispose();
						flowEmployeeExtraBenefit.Dispose();
						flowEmployee.Dispose();
						flowOtherBenefitRate.Dispose();
						objEmployeeExtraBenefitList.Dispose();
						objServiceStaffAssignmentList.Dispose();

						flowOtherBenefit = null;
						flowEmployeeExtraBenefit = null;
						flowServiceStaffAssignment = null;
						flowOtherBenefitRate = null;
						flowEmployee = null;
						objEmployeeExtraBenefitList = null;
						objServiceStaffAssignmentList = null;
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion
	}
}
