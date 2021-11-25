using System;
using DataAccess.AttendanceDB;
using DataAccess.ContractDB;
using DataAccess.ContractDB.ContractChargeRateDB;
using Entity.AttendanceEntities;
using Entity.ContractEntities;
using PTB.BTS.Attendance.BenefitChargeEntities;
using PTB.BTS.ContractEntities.ContractChargeRate;
using SystemFramework.AppException;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public class DeductChargeFlow : BenefitChargeBase
    {
        #region Private Variable
        private EmployeeTimeCardDB dbEmployeeTimeCard;
        private ChargeRateByContractDB dbChargeRateByContract;
        private ChargeRateByServiceStaffTypeDB dbChargeRateByServiceStaffType;
        private ServiceStaffAssignmentDB dbServiceStaffAssignment;
        #endregion

        #region Constructor
        public DeductChargeFlow(ServiceStaffChargeBase serviceStaffCharge)
            : base(serviceStaffCharge)
        {
            dbEmployeeTimeCard = new EmployeeTimeCardDB();
            dbChargeRateByContract = new ChargeRateByContractDB();
            dbChargeRateByServiceStaffType = new ChargeRateByServiceStaffTypeDB();
            dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
        } 
        #endregion

        #region Public Method
        public override bool FillBenefit(IBenefitCharge benefitCharge)
        {
            bool result = serviceStaffCharge.FillBenefit(benefitCharge);
            if (result)
            {
                int deductTime = 0;

                foreach (ServiceStaffAssignment staffAssign in AssignmentList)
                {
                    EmployeeTimeCard employeeTimeCard = new EmployeeTimeCard(staffAssign.AAssignedServiceStaff, AssignmentList.YearMonth);

                    if (ValidateEmployeeTimeCard(staffAssign, employeeTimeCard))
                    {
                        TimePeriod timePeriod = getTimePeriodInYearMonth(staffAssign.APeriod, AssignmentList.YearMonth);

                        for (DateTime forDate = timePeriod.From; forDate <= timePeriod.To; forDate = forDate.AddDays(1))
                        {
                            //For case multiple department assignment
                            if (ValidateMultipleDepartment(benefitCharge, forDate) && 
                                ValidateStaffAssignment(staffAssign, employeeTimeCard, forDate))
                            {
                                deductTime++;
                            }
                        }
                    }
                }

                #region - Charge Rate -
                ChargeRate chargeRate = new ChargeRate();
                ChargeRateByContract chargeRateByContract = new ChargeRateByContract();
                chargeRateByContract.ContractBase = AssignmentList.Contract;

                ChargeRateByServiceStaffType chargeRateByServiceStaffType;

                if (dbChargeRateByContract.FillChargeRateByContract(chargeRateByContract, AssignmentList.Company))
                {
                    chargeRate = chargeRateByContract.ChargeRate;
                }
                else
                {
                    if (((ServiceStaffContract)AssignmentList.Contract).ALatestServiceStaffRoleList.Count > 0)
                    {
                        chargeRateByServiceStaffType = new ChargeRateByServiceStaffType();
                        chargeRateByServiceStaffType.ServiceStaffType = ((ServiceStaffContract)AssignmentList.Contract).ALatestServiceStaffRoleList[0].AServiceStaffType;
                        chargeRateByServiceStaffType.Customer = AssignmentList.Contract.ACustomer;
                        using (VDContractMatchDB dbVDContractMatch = new VDContractMatchDB())
                        {
                            chargeRateByServiceStaffType.DriverOnlyStatus = (dbVDContractMatch.FillVDContractMatch(AssignmentList.Contract.ContractNo, AssignmentList.Company) == -1);
                        }

                        if (dbChargeRateByServiceStaffType.FillChargeRateByServiceStaffType(chargeRateByServiceStaffType, AssignmentList.Company))
                        {
                            chargeRate = chargeRateByServiceStaffType.ChargeRate;
                        }
                        else
                        {
                            chargeRateByServiceStaffType = new ChargeRateByServiceStaffType();
                            chargeRateByServiceStaffType.ServiceStaffType = ((ServiceStaffContract)AssignmentList.Contract).ALatestServiceStaffRoleList[0].AServiceStaffType;
                            chargeRateByServiceStaffType.Customer = new Customer(Customer.DUMMYCODE);
                            if (AssignmentList.Contract.AContractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
                            {
                                using (VDContractMatchDB dbVDContractMatch = new VDContractMatchDB())
                                {
                                    chargeRateByServiceStaffType.DriverOnlyStatus = (dbVDContractMatch.FillVDContractMatch(AssignmentList.Contract.ContractNo, AssignmentList.Company) == -1);
                                }
                            }

                            if (dbChargeRateByServiceStaffType.FillChargeRateByServiceStaffType(chargeRateByServiceStaffType, AssignmentList.Company))
                            {
                                chargeRate = chargeRateByServiceStaffType.ChargeRate;
                            }
                            else
                            {
                                AppExceptionBase appExceptionBase = new AppExceptionBase("OTChargeFlow : ChargeRate");
                                appExceptionBase.SetMessage("ไม่พบค่าบริการสำหรับลูกค้า");
                                throw appExceptionBase;
                            }
                        }
                    }
                }

                chargeRateByContract = null;
                chargeRateByServiceStaffType = null;
                #endregion

                #region - Calculate Charge -
                benefitCharge.DeducTime += deductTime;
                benefitCharge.DeducAmountPerDay = chargeRate.AbsenceDeduction;
                benefitCharge.DeducAmount = deductTime * chargeRate.AbsenceDeduction;
                #endregion
            }

            return result;
        } 
        #endregion

        #region Private Method
        private bool ValidateEmployeeTimeCard(ServiceStaffAssignment staffAssign, EmployeeTimeCard employeeTimeCard)
        {
            return staffAssign.AssignmentRole == Entity.CommonEntity.ASSIGNMENT_ROLE_TYPE.MAIN 
                && dbEmployeeTimeCard.FillTimeCardBenefitList(ref employeeTimeCard);
        }

        private bool ValidateStaffAssignment(ServiceStaffAssignment staffAssign, EmployeeTimeCard employeeTimeCard, DateTime forDate)
        {
            return employeeTimeCard.Contain(forDate.ToShortDateString())
                && !dbServiceStaffAssignment.FillSpecificServiceStaffAssignment(staffAssign.AAssignedServiceStaff, forDate);
        }
        #endregion
    }
}
