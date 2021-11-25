using System;
using DataAccess.ContractDB;
using Entity.ContractEntities;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;
using PTB.BTS.Attendance.BenefitChargeEntities;
using SystemFramework.AppException;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public class AssignmentChargeFlow : ServiceStaffChargeBase
    {
        private ServiceStaffAssignmentDB dbServiceStaffAssignment;

        //============================== Constructor ==============================
        public AssignmentChargeFlow(ContractBase contract, YearMonth yearMonth, Company company) : base()
        {
            dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
        }

        //============================== Property ==============================
        private AssignmentList assignmentList;
        public override AssignmentList AssignmentList 
        {
            get { return assignmentList; }
            set { assignmentList = value; }
        }

        //============================== Public method ==============================
        public override bool FillBenefit(IBenefitCharge benefitCharge)
        {
            bool result = false;

            if (dbServiceStaffAssignment.FillSpecificServiceStaffAssignmentInYearMonthList(assignmentList))
            {
                DateTime tempFromDate = DateTime.Today;

                foreach (ServiceStaffAssignment serviceStaffAssignment in assignmentList)
                {
                    for (int i = 0; i < assignmentList.Count; i++)
                    {
                        if (serviceStaffAssignment.AssignmentRole == Entity.CommonEntity.ASSIGNMENT_ROLE_TYPE.MAIN)
                        {
                            result = true;
                            if (benefitCharge.ServiceStaff == null)
                            {
                                benefitCharge.ServiceStaff = serviceStaffAssignment.AAssignedServiceStaff;
                                benefitCharge.ServiceStaff.AServiceStaffType = ((ServiceStaffContract)AssignmentList.Contract).ALatestServiceStaffRoleList[0].AServiceStaffType;
                                benefitCharge.ChargeRemark = serviceStaffAssignment.AHirer == null ? string.Empty : serviceStaffAssignment.AHirer.Name;
                                tempFromDate = serviceStaffAssignment.APeriod.From;
                            }
                            else if (tempFromDate < serviceStaffAssignment.APeriod.From)
                            {
                                benefitCharge.ServiceStaff = serviceStaffAssignment.AAssignedServiceStaff;
                                benefitCharge.ServiceStaff.AServiceStaffType = ((ServiceStaffContract)AssignmentList.Contract).ALatestServiceStaffRoleList[0].AServiceStaffType;
                                benefitCharge.ChargeRemark = serviceStaffAssignment.AHirer == null ? string.Empty : serviceStaffAssignment.AHirer.Name;
                                tempFromDate = serviceStaffAssignment.APeriod.From;
                            }
                        }
                    }                    
                }

                if (!result)
                {
                    AppExceptionBase appExceptionBase = new AppExceptionBase("AssignmentChargeFlow : ServiceStaffAssignment");
                    appExceptionBase.SetMessage("ไม่พบพนักงานที่เป็น Main ในสัญญา " + assignmentList.Contract.ContractNo.ToString() + " เดือน/ปี " + assignmentList.YearMonth.Month.ToString() + "/" + assignmentList.YearMonth.Year.ToString());
                    throw appExceptionBase;
                }
            }
            else
            {
                AppExceptionBase appExceptionBase = new AppExceptionBase("AssignmentChargeFlow : ServiceStaffAssignment");
                appExceptionBase.SetMessage("ไม่พบการจ่ายงานของสัญญา " + assignmentList.Contract.ContractNo.ToString() + " เดือน/ปี " + assignmentList.YearMonth.Month.ToString() + "/" + assignmentList.YearMonth.Year.ToString());
                throw appExceptionBase;
            }
            
            return result;
        }
    }
}
