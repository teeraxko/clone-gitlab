using System;
using DataAccess.ContractDB.ContractChargeRateDB;
using Entity.ContractEntities;
using Flow.AttendanceFlow.CommonBenefitFlow;
using ictus.Common.Entity.Time;
using PTB.BTS.Attendance.BenefitChargeEntities;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public class CustomerAdjustmentChargeFlow : BenefitChargeBase
    {
        #region Private Variable
        private CustomerChargeAdjustmentDB dbCustomerChargeAdjustment; 
        #endregion

        #region Constructor
        public CustomerAdjustmentChargeFlow(ServiceStaffChargeBase serviceStaffCharge)
            : base(serviceStaffCharge)
        {
            dbCustomerChargeAdjustment = new CustomerChargeAdjustmentDB();
        } 
        #endregion

        #region Public Method
        public override bool FillBenefit(IBenefitCharge benefitCharge)
        {
            bool result = serviceStaffCharge.FillBenefit(benefitCharge);

            if (result)
            {
                bool status = false;
                CustomerChargeAdjustmentList listCustomerChargeAdjustment = new CustomerChargeAdjustmentList(AssignmentList.Company);

                //For multiple department assignment
                if (AssignmentList.Contract.IsAssignCustomerDepartment)
                {
                    status = dbCustomerChargeAdjustment.FillCustomerChargeAdjustmentList(listCustomerChargeAdjustment, AssignmentList.Contract, GetYearMonth, AssignmentList.Contract.ACustomerDepartment);
                }
                else
                { 
                    status = dbCustomerChargeAdjustment.FillCustomerChargeAdjustmentList(listCustomerChargeAdjustment, AssignmentList.Contract, GetYearMonth);
                }

                if (status)
                {
                    foreach (CustomerChargeAdjustment customerChargeAdjustment in listCustomerChargeAdjustment)
                    {
                        if (customerChargeAdjustment.OTAHour < 0)
                        {
                            benefitCharge.OTAHourAdjust = CommonAttendanceFlow.DiffTime(benefitCharge.OTAHourAdjust, customerChargeAdjustment.OTAHour);
                        }
                        else
                        {
                            benefitCharge.OTAHourAdjust = CommonAttendanceFlow.AddTime(benefitCharge.OTAHourAdjust, customerChargeAdjustment.OTAHour);
                        }
                        benefitCharge.OTAAmountAdjust += customerChargeAdjustment.OTAAmount;

                        if (customerChargeAdjustment.OTBHour < 0)
                        {
                            benefitCharge.OTBHourAdjust = CommonAttendanceFlow.DiffTime(benefitCharge.OTBHourAdjust, customerChargeAdjustment.OTBHour);
                        }
                        else
                        {
                            benefitCharge.OTBHourAdjust = CommonAttendanceFlow.AddTime(benefitCharge.OTBHourAdjust, customerChargeAdjustment.OTBHour);
                        }
                        benefitCharge.OTBAmountAdjust += customerChargeAdjustment.OTBAmount;

                        if (customerChargeAdjustment.OTCHour < 0)
                        {
                            benefitCharge.OTCHourAdjust = CommonAttendanceFlow.DiffTime(benefitCharge.OTCHourAdjust, customerChargeAdjustment.OTCHour);
                        }
                        else
                        {
                            benefitCharge.OTCHourAdjust = CommonAttendanceFlow.AddTime(benefitCharge.OTCHourAdjust, customerChargeAdjustment.OTCHour);
                        }
                        benefitCharge.OTCAmountAdjust += customerChargeAdjustment.OTCAmount;

                        benefitCharge.HolidayAdjust += customerChargeAdjustment.Holiday;
                        benefitCharge.HolidayAmountAdjust += customerChargeAdjustment.HolidayAmount;
                        benefitCharge.TaxiAdjust += customerChargeAdjustment.TaxiTimes;
                        benefitCharge.TaxiAmountAdjust += customerChargeAdjustment.TaxiAmount;
                        benefitCharge.TripFarAdjust += customerChargeAdjustment.OneDayTripFarTimes;
                        benefitCharge.TripFarAmountAdjust += customerChargeAdjustment.OneDayTripFarAmount;
                        benefitCharge.TripNearAdjust += customerChargeAdjustment.OneDayTripNearTimes;
                        benefitCharge.TripNearAmountAdjust += customerChargeAdjustment.OneDayTripNearAmount;
                        benefitCharge.NightTripAdjust += customerChargeAdjustment.OvernightTripTimes;
                        benefitCharge.NightTripAmountAdjust += customerChargeAdjustment.OvernightTripAmount;
                        benefitCharge.DeducAdjust += customerChargeAdjustment.Deduct;
                        benefitCharge.DeducAmountAdjust += GetDeductAmount(customerChargeAdjustment.DeductAmount);
                        benefitCharge.Other += customerChargeAdjustment.OtherAmount;

                        if (customerChargeAdjustment.Reason != "")
                        {
                            benefitCharge.ChargeRemark = customerChargeAdjustment.Employee.AName.English.ToUpper() + " : " + customerChargeAdjustment.Reason;
                        }

                        benefitCharge.Line = 2;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// For other staff customer adjustment on select date
        /// </summary>
        public virtual YearMonth GetYearMonth
        {
            get { return AssignmentList.YearMonth; }
        }

        public virtual decimal GetDeductAmount(decimal deductAmount)
        {
            if (deductAmount != decimal.Zero)
            {
                bool isNegate = false;

                if (deductAmount < 0)
                {
                    isNegate = true;
                    deductAmount = decimal.Negate(deductAmount);
                }

                decimal sumRemainder = decimal.Remainder(deductAmount, 1);
                if (sumRemainder == 0.5m)
                {
                    deductAmount = deductAmount + 0.5m;
                }
                else
                {
                    deductAmount = Math.Round(deductAmount);
                }

                if (isNegate)
                {
                    deductAmount = decimal.Negate(deductAmount);
                }
            }

            return deductAmount;
        } 
        #endregion
    }
}
