using System;
using System.Data.SqlClient;

using PTB.BTS.Common.Flow;
using PTB.BTS.Attendance.OtherBenefit.Flow;

using Entity.CommonEntity;
using Entity.AttendanceEntities;
using Entity.ContractEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;

using DataAccess.CommonDB;
using DataAccess.AttendanceDB;
using DataAccess.ContractDB;

namespace PTB.BTS.Attendance.OtherBenefit.Flow
{
	public class OtherBenefitFlow : FlowBase
	{
		#region - Private -
		private bool disposed = false;
		private TelephoneBenefitFlow flowTelephoneBenefit;
		private ExtraBenefitFlow flowExtraBenefit;
		private ExtraAGTBenefitDeductionFlow flowExtraAGTBenefitDeduction;
		private ExtraAGTBenefitFlow flowExtraAGTBenefit;

		private EmployeeTimeCardDB dbEmployeeTimeCard;
		private OtherBenefitRateDB dbOtherBenefitRate;
		#endregion

		private EmployeeExtraBenefitList objEmployeeExtraBenefitList;
		public EmployeeExtraBenefitList ObjEmployeeExtraBenefitList
		{
			get{return objEmployeeExtraBenefitList;}
		}

//		============================== Constructor ==============================
		public OtherBenefitFlow() : base()
		{
			flowTelephoneBenefit = new TelephoneBenefitFlow();
			flowExtraBenefit = new ExtraBenefitFlow();
			flowExtraAGTBenefitDeduction = new ExtraAGTBenefitDeductionFlow();
			flowExtraAGTBenefit = new ExtraAGTBenefitFlow();

			dbEmployeeTimeCard = new EmployeeTimeCardDB();
			dbOtherBenefitRate = new OtherBenefitRateDB();
		}

//		============================== Private Method ==============================
		private ExtraBenefit generateTimecardBenefit(ServiceStaff value, YearMonth yearMonth, OtherBenefitRate benefitRate)
		{
			EmployeeTimeCard employeeTimeCard = new EmployeeTimeCard(value, yearMonth);
			ExtraBenefit extraBenefit = new ExtraBenefit();

			if(dbEmployeeTimeCard.FillTimeCardBenefitList(ref employeeTimeCard))
			{
				string leaveDate = string.Empty;

				for (int j=0; j<employeeTimeCard.Count; j++)
				{
					string afterSts = employeeTimeCard[j].AAfterBreakStatus.Code.ToString();
					string breakSts = employeeTimeCard[j].ABeforeBreakStatus.Code.ToString();

                    //Add new status F1 (Forget) to attendance status : woranai 2010/03/08
					if(!afterSts.Equals("WK") || !afterSts.Equals("L1") || !afterSts.Equals("L2")
                        || !afterSts.Equals("H1") || !afterSts.Equals("") || !afterSts.Equals("F1") ||
						!breakSts.Equals("WK") || !breakSts.Equals("L1") || !breakSts.Equals("L2")
                        || !breakSts.Equals("H1") || !breakSts.Equals("") || !breakSts.Equals("F1"))
					{
						if(!leaveDate.Equals(string.Empty))
						{
							leaveDate += ", ";
						}
						leaveDate += employeeTimeCard[j].CardDate.Day.ToString();
					}		
	
					extraBenefit.Remark = "ลาวันที่ " + leaveDate;
					extraBenefit.TotalAmount = decimal.Zero;
					extraBenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;
				}
			}
			else
			{
				extraBenefit.TotalAmount = benefitRate.ExtraRate;
				extraBenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.YES;
			}

			extraBenefit.AYearMonth = yearMonth;
			employeeTimeCard = null;

			return extraBenefit;
		}

//		============================== Public Method ==============================
		public bool GenerateOtherBenefit(EmployeeExtraBenefitList value, YearMonth yearMonth)
		{
			bool result = true;		

			result &= flowTelephoneBenefit.GenTelephoneBenefit(yearMonth, value.Company);
			result &= flowExtraBenefit.GenExtraBenefit(value, yearMonth);
			result &= flowExtraAGTBenefit.GenExtraAGTBenefit();
			result &= flowExtraAGTBenefitDeduction.GenExtraAGTBenefitDeduction();

			return result;
		}
		
		public bool GenPayrollBenefitProcess(YearMonth yearMonth, Company aCompany)
		{
			EmployeeExtraBenefitDB dbEmployeeExtraBenefit = new EmployeeExtraBenefitDB();
			ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
			EmployeeExtraBenefitList listEmployeeExtraBenefit = new EmployeeExtraBenefitList(aCompany);

			if (dbEmployeeExtraBenefit.FillEmployeeExtraBenefitList(ref listEmployeeExtraBenefit, yearMonth))
			{
				return flowExtraBenefit.GenExtraBenefit(listEmployeeExtraBenefit, yearMonth);
			}
			else
			{
				ServiceStaffAssignmentList listServiceStaffAssignment = new ServiceStaffAssignmentList(aCompany);
				if (dbServiceStaffAssignment.FillServiceStaffAssignmentInPeriodList(ref listServiceStaffAssignment, yearMonth))
				{
					if (CalculateOtherBenefit(listServiceStaffAssignment, yearMonth))
					{
						return flowExtraBenefit.GenExtraBenefit(objEmployeeExtraBenefitList, yearMonth);
					}
				}
			}
			return false;
		}

		public bool CalculateOtherBenefit(ServiceStaffAssignmentList value, YearMonth yearMonth)
		{
			bool result = false;

			EmployeeExtraBenefit employeeExtraBenefit;
			objEmployeeExtraBenefitList = new EmployeeExtraBenefitList(value.Company);
						
			OtherBenefitRate otherBenefitRate = new OtherBenefitRate();
			dbOtherBenefitRate.FillOtherBenefitRate(ref otherBenefitRate, value.Company);

			for (int i=0; i<value.Count; i++)
			{
//				if (i.Equals(0) || !value[i].AAssignedServiceStaff.EmployeeNo.Equals(value[i-1].AAssignedServiceStaff.EmployeeNo))
				if (!objEmployeeExtraBenefitList.Contain(value[i].AAssignedServiceStaff))
				{
//					if (value[i].AAssignedServiceStaff.AServiceStaffType.Type.Equals("282"))
					if(((ServiceStaffContract)value[i].AContract).ALatestServiceStaffRoleList[0].AServiceStaffType.Type.Equals("282"))
					{
						employeeExtraBenefit = new EmployeeExtraBenefit(value[i].AAssignedServiceStaff);
						employeeExtraBenefit.Add(generateTimecardBenefit(value[i].AAssignedServiceStaff, yearMonth, otherBenefitRate));

						objEmployeeExtraBenefitList.Add(employeeExtraBenefit);
						result = true;
					}
				}								
			}
			employeeExtraBenefit = null;

			return result;
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
						flowTelephoneBenefit.Dispose();
						flowExtraBenefit.Dispose();
						flowExtraAGTBenefitDeduction.Dispose();
						flowExtraAGTBenefit.Dispose();
						dbEmployeeTimeCard.Dispose();
						dbOtherBenefitRate.Dispose();

						flowTelephoneBenefit = null;
						flowExtraBenefit = null;
						flowExtraAGTBenefitDeduction = null;
						flowExtraAGTBenefit = null;
						dbEmployeeTimeCard = null;
						dbOtherBenefitRate = null;
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