using System;
using PTB.BTS.Attendance.BenefitChargeEntities;
using DataAccess.AttendanceDB;
using Entity.AttendanceEntities;
using Entity.ContractEntities;
using PTB.BTS.ContractEntities.ContractChargeRate;
using SystemFramework.AppException;
using DataAccess.ContractDB.ContractChargeRateDB;
using ictus.Common.Entity.General;
using Flow.AttendanceFlow.CommonBenefitFlow;
using DataAccess.ContractDB;
using ictus.Common.Entity;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public class OTChargeFlow : BenefitChargeBase
    {
        #region Private Variable
        private EmployeeOvertimeHourDB dbEmployeeOvertimeHour;
        private ChargeRateByContractDB dbChargeRateByContract;
        private ChargeRateByServiceStaffTypeDB dbChargeRateByServiceStaffType;

        private decimal otA = decimal.Zero;
        private decimal otC = decimal.Zero;
        private int otADay = 0;

        protected MinimumOTChargeList minOTChargeList;
        protected ChargeRate chargeRate;
        protected decimal otB = decimal.Zero;
        protected int holiday = 0;
        #endregion

        #region Constructor
        public OTChargeFlow(ServiceStaffChargeBase serviceStaffCharge)
            : base(serviceStaffCharge)
        {
            dbEmployeeOvertimeHour = new EmployeeOvertimeHourDB();
            dbChargeRateByContract = new ChargeRateByContractDB();
            dbChargeRateByServiceStaffType = new ChargeRateByServiceStaffTypeDB();
            chargeRate = new ChargeRate();
        } 
        #endregion

        #region Private Method
        private bool isDriverOnly(ContractBase contract)
        {
            using (VDContractMatchDB dbVDContractMatch = new VDContractMatchDB())
            {
                return (dbVDContractMatch.FillVDContractMatch(contract.ContractNo, AssignmentList.Company) == -1);
            }
        } 
        #endregion

        #region Public Method
        public override bool FillBenefit(IBenefitCharge benefitCharge)
        {
            bool result = serviceStaffCharge.FillBenefit(benefitCharge);

            if (result)
            {
                #region Min OT Charge
                if (minOTChargeList == null)
                {
                    minOTChargeList = new MinimumOTChargeList(AssignmentList.Company);

                    using (DataAccess.ContractDB.ContractChargeRateDB.MinimumOTChargeDB dbMinimumOTCharge = new DataAccess.ContractDB.ContractChargeRateDB.MinimumOTChargeDB())
                    {
                        if (dbMinimumOTCharge.FillMinimumOTChargeList(minOTChargeList))
                        {
                            if (minOTChargeList.Count != 2)
                            {
                                AppExceptionBase appExceptionBase = new AppExceptionBase("DriverOTChargeFlow : VDContractMatch");
                                appExceptionBase.SetMessage("กรุณากำหนดอัตราค่าล่วงเวลาขั้นต่ำสำหรับพนักงานบริการ");
                                throw appExceptionBase;
                            }
                        }
                    }
                }
                #endregion

                #region - EmployeeOvertimeHour -
                EmployeeOvertimeHour employeeOvertimeHour;
                otA = decimal.Zero;
                otB = decimal.Zero;
                otC = decimal.Zero;
                otADay = 0;
                holiday = 0;

                foreach (ServiceStaffAssignment staffAssign in AssignmentList)
                {
                    employeeOvertimeHour = new EmployeeOvertimeHour(staffAssign.AAssignedServiceStaff, AssignmentList.YearMonth);

                    //======================== Retrieve EmployeeOvertimeHour ========================
                    if (dbEmployeeOvertimeHour.FillEmployeeOvertimeHour(ref employeeOvertimeHour))
                    {
                        OvertimeHour overtimeHour;

                        TimePeriod timePeriod = getTimePeriodInYearMonth(staffAssign.APeriod, AssignmentList.YearMonth);

                        for (DateTime forDate = timePeriod.From; forDate <= timePeriod.To; forDate = forDate.AddDays(1))
                        {
                            //For multiple department assignment
                            if (ValidateMultipleDepartment(benefitCharge, forDate) &&
                                employeeOvertimeHour.Contain(forDate.ToShortDateString()))
                            {
                                overtimeHour = employeeOvertimeHour[forDate.ToShortDateString()];

                                if (overtimeHour.AOTRateForCharge.OtBHour != decimal.Zero)
                                {
                                    calOTBWorkSchedule(overtimeHour);
                                }

                                if (overtimeHour.AOTRateForCharge.OtAHour != decimal.Zero)
                                {
                                    otA = CommonAttendanceFlow.AddTime(otA, overtimeHour.AOTRateForCharge.OtAHour);
                                    otADay++;
                                }
                                otC = CommonAttendanceFlow.AddTime(otC, overtimeHour.AOTRateForCharge.OtCHour);
                            }
                        }

                        overtimeHour = null;
                        timePeriod = null;
                    }

                    employeeOvertimeHour = null;


                    #region - validate ServiceStaffType -
                    //======================== Validate ServiceStaffType ========================
                    //if (serviceStaffType.Type == NullConstant.STRING)
                    //{
                    //    serviceStaffType = serviceStaffAssignment.AAssignedServiceStaff.AServiceStaffType;
                    //}
                    //else if (serviceStaffType.Type != serviceStaffAssignment.AAssignedServiceStaff.AServiceStaffType.Type)
                    //{
                    //    AppExceptionBase appExceptionBase = new AppExceptionBase("OTChargeFlow : ServiceStaffType");
                    //    appExceptionBase.SetMessage("ประเภทพนักงานไม่ถูกต้อง");
                    //    throw appExceptionBase;
                    //}
                    #endregion
                }
                #endregion

                #region - Charge Rate -
                ChargeRateByContract chargeRateByContract = new ChargeRateByContract();
                chargeRateByContract.ContractBase = AssignmentList.Contract;

                ChargeRateByServiceStaffType chargeRateByServiceStaffType;

                if (dbChargeRateByContract.FillChargeRateByContract(chargeRateByContract, AssignmentList.Company))
                {
                    chargeRate = chargeRateByContract.ChargeRate;
                    benefitCharge.ChargeRate = chargeRate;
                }
                else
                {
                    if (((ServiceStaffContract)AssignmentList.Contract).ALatestServiceStaffRoleList.Count > 0)
                    {
                        chargeRateByServiceStaffType = new ChargeRateByServiceStaffType();
                        chargeRateByServiceStaffType.ServiceStaffType = ((ServiceStaffContract)AssignmentList.Contract).ALatestServiceStaffRoleList[0].AServiceStaffType;
                        if (AssignmentList.Contract.AContractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
                        {
                            chargeRateByServiceStaffType.DriverOnlyStatus = isDriverOnly(AssignmentList.Contract);
                        }
                        chargeRateByServiceStaffType.Customer = AssignmentList.Contract.ACustomer;

                        if (dbChargeRateByServiceStaffType.FillChargeRateByServiceStaffType(chargeRateByServiceStaffType, AssignmentList.Company))
                        {
                            chargeRate = chargeRateByServiceStaffType.ChargeRate;
                            benefitCharge.ChargeRate = chargeRate;
                        }
                        else
                        {
                            chargeRateByServiceStaffType = new ChargeRateByServiceStaffType();
                            chargeRateByServiceStaffType.ServiceStaffType = ((ServiceStaffContract)AssignmentList.Contract).ALatestServiceStaffRoleList[0].AServiceStaffType;
                            if (AssignmentList.Contract.AContractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
                            {
                                chargeRateByServiceStaffType.DriverOnlyStatus = isDriverOnly(AssignmentList.Contract);
                            }
                            chargeRateByServiceStaffType.Customer = new Customer(Customer.DUMMYCODE);

                            if (dbChargeRateByServiceStaffType.FillChargeRateByServiceStaffType(chargeRateByServiceStaffType, AssignmentList.Company))
                            {
                                chargeRate = chargeRateByServiceStaffType.ChargeRate;
                                benefitCharge.ChargeRate = chargeRate;
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
                benefitCharge.OTADay += otADay;
                benefitCharge.Holiday += holiday;
                benefitCharge.OTACharge += otA;
                benefitCharge.OTBCharge += otB;
                benefitCharge.OTCCharge += otC;
                benefitCharge.OTARate = chargeRate.OTARate;
                benefitCharge.OTBRate = chargeRate.OTBRate;
                benefitCharge.OTCRate = chargeRate.OTCRate;
                benefitCharge.HolidayAmount += holiday * MinHolidayCharge;

                getVehiclePlateNo(benefitCharge);
                #endregion
            }

            return result;
        } 
        #endregion

        #region Protected Method
        protected virtual void getVehiclePlateNo(IBenefitCharge benefitCharge)
        {
        }

        protected virtual void calOTBWorkSchedule(OvertimeHour value)
        {
            otB = CommonAttendanceFlow.AddTime(otB, value.AOTRateForCharge.OtBHour);
        }

        protected virtual decimal MinHolidayCharge
        {
            get { return decimal.Zero; }
        } 
        #endregion
    }
}
