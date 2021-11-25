using System;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Attendance.Benefit.Flow
{
    public class TaxiBenefitFlow : FlowBase
    {
        #region - Constant -
        class TaxiTimeInfo
        {
            public TimePeriod TaxiTime;
            public TimePeriod TaxiTimeForCharge;
            public ServiceStaffType ServiceStaffType;
            public Customer Customer;

            public TaxiTimeInfo()
            {
                TaxiTime = new TimePeriod();
                TaxiTimeForCharge = new TimePeriod();
            }
        }
        #endregion

        #region - Private -
        private EmployeeTaxiBenefitDB dbEmployeeTaxiBenefit;
        #endregion

        //============================== Constructor ==============================
        public TaxiBenefitFlow()
            : base()
        {
            dbEmployeeTaxiBenefit = new EmployeeTaxiBenefitDB();
        }

        #region - Private Method -
        private bool validAMTaxi(DateTime value, BenefitOvernightTripList overnightTripList)
        {
            for (int i = 0; i < overnightTripList.Count; i++)
            {
                for (DateTime temp = overnightTripList[i].From.AddDays(1); temp <= overnightTripList[i].To; temp = temp.AddDays(1))
                {
                    if (value == temp)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool validPMTaxi(DateTime value, BenefitOvernightTripList overnightTripList)
        {
            for (int i = 0; i < overnightTripList.Count; i++)
            {
                for (DateTime temp = overnightTripList[i].From; temp < overnightTripList[i].To; temp = temp.AddDays(1))
                {
                    if (value == temp)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void calculateTaxiBenefit(EmployeeBenefit value, BenefitTaxiList benefitTaxiList, BenefitOTHour otHour, TaxiTimeInfo taxiTimeInfo, int taxiRate)
        {
            BenefitTaxi benefitTaxi;
            if (taxiTimeInfo.TaxiTime.From != NullConstant.DATETIME && taxiTimeInfo.TaxiTime.To != NullConstant.DATETIME)
            {
                if (validAMTaxi(otHour.BenefitDate, value.OvernightTripBenefit.CurrentMonth) && (NullConstant.GetTime(otHour.BeforeTime.From) <= NullConstant.GetTime(taxiTimeInfo.TaxiTime.From)))
                {
                    benefitTaxi = new BenefitTaxi(otHour.BenefitDate);
                    benefitTaxi.Times = 1;
                    benefitTaxi.Amount = taxiRate;
                    benefitTaxi.TotalAmount = benefitTaxi.Times * benefitTaxi.Amount;
                    benefitTaxiList.Add(benefitTaxi);
                }

                if (NullConstant.GetTime(taxiTimeInfo.TaxiTime.To) <= NullConstant.GetTime(otHour.AfterTime.To) || (NullConstant.GetTime(taxiTimeInfo.TaxiTime.To) > NullConstant.GetTime(otHour.AfterTime.To) && NullConstant.GetTime(otHour.AfterTime.To) < NullConstant.GetTime(otHour.BeforeTime.From)))
                {
                    if (validPMTaxi(otHour.BenefitDate, value.OvernightTripBenefit.CurrentMonth) && (NullConstant.GetTime(otHour.AfterTime.To) <= NullConstant.GetTime(taxiTimeInfo.TaxiTime.From) || NullConstant.GetTime(taxiTimeInfo.TaxiTime.To) <= NullConstant.GetTime(otHour.AfterTime.To)))
                    {
                        if (benefitTaxiList.Contain(otHour.BenefitDate.ToShortDateString()))
                        {
                            benefitTaxi = benefitTaxiList[otHour.BenefitDate.ToShortDateString()];
                            benefitTaxi.Times++;
                            benefitTaxi.TotalAmount = benefitTaxi.Times * benefitTaxi.Amount;
                        }
                        else
                        {
                            benefitTaxi = new BenefitTaxi(otHour.BenefitDate);
                            benefitTaxi.Times = 1;
                            benefitTaxi.Amount = taxiRate;
                            benefitTaxi.TotalAmount = benefitTaxi.Times * benefitTaxi.Amount;
                            benefitTaxiList.Add(benefitTaxi);
                        }
                    }
                }
            }
            //else
            //{
            //    benefitTaxi = new BenefitTaxi(otHour.BenefitDate);
            //    //benefitTaxi.Times = 1;
            //    //benefitTaxi.Amount = taxiRate;
            //    //benefitTaxi.TotalAmount = benefitTaxi.Times * benefitTaxi.Amount;
            //    benefitTaxiList.Add(benefitTaxi);
            //}
        }

        private void calculateTaxiBenefitForCharge(EmployeeBenefit value, BenefitOTHour otHour, TaxiTimeInfo taxiTimeInfo, WorkInfo workInfo)
        {
            if (workInfo.AssignServiceStaffType.Type == "282")
            {
                //Family
                TaxiTimeInfo taxiTimeInfoForCharge = new TaxiTimeInfo();
                taxiTimeInfoForCharge.Customer = taxiTimeInfo.Customer;
                taxiTimeInfoForCharge.ServiceStaffType = taxiTimeInfo.ServiceStaffType;
                taxiTimeInfoForCharge.TaxiTime = taxiTimeInfo.TaxiTimeForCharge;
                calculateTaxiBenefit(value, value.BenefitTaxiListForCharge, otHour, taxiTimeInfoForCharge, value.OtherBenefitRate.TaxiRateForCharge);
                taxiTimeInfoForCharge = null;
            }
            else
            {
                for (int i = 0; i < value.BenefitTaxiList.Count; i++)
                {
                    value.BenefitTaxiListForCharge.Add(value.BenefitTaxiList[i]);
                }
            }
        }

        private bool fillTaxiTimeInfo(TaxiTimeInfo taxiTimeInfo, Customer customer, Company company)
        {
            bool result = false;
            TaxiPositionCarConditionDB dbTaxiPositionCarCondition = new TaxiPositionCarConditionDB();
            TaxiPositionCarCondition taxiPositionCarCondition = new TaxiPositionCarCondition();
            taxiPositionCarCondition.ACustomer = customer;
            if (dbTaxiPositionCarCondition.FillTaxiPositionCarCondition(ref taxiPositionCarCondition, company))
            {
                result = true;
                taxiTimeInfo.TaxiTime.From = taxiPositionCarCondition.UntilTimeIn;
                taxiTimeInfo.TaxiTime.To = taxiPositionCarCondition.SinceTimeOut;
            }
            taxiPositionCarCondition = null;
            dbTaxiPositionCarCondition = null;
            return result;
        }

        private bool fillTaxiTimeInfo(TaxiTimeInfo taxiTimeInfo, CustomerGroup customerGroup, Company company)
        {
            bool result = false;
            TaxiFamilyCarConditionDB dbTaxiFamilyCarCondition = new TaxiFamilyCarConditionDB();
            TaxiFamilyCarCondition taxiFamilyCarCondition = new TaxiFamilyCarCondition();
            taxiFamilyCarCondition.ACustomerGroup = customerGroup;
            if (dbTaxiFamilyCarCondition.FillTaxiFamilyCarCondition(ref taxiFamilyCarCondition, company))
            {
                result = true;
                taxiTimeInfo.TaxiTime.From = taxiFamilyCarCondition.UntilTimeIn;
                taxiTimeInfo.TaxiTime.To = taxiFamilyCarCondition.SinceTimeOut;

                taxiTimeInfo.TaxiTimeForCharge.From = taxiFamilyCarCondition.UntilTimeInForCharge;
                taxiTimeInfo.TaxiTimeForCharge.To = taxiFamilyCarCondition.SinceTimeOutForCharge;
            }
            taxiFamilyCarCondition = null;
            return result;
        }

        private bool fillTaxiTimeInfo(ref TaxiTimeInfo taxiTimeInfo, WorkInfo workInfo, Company company)
        {
            if (taxiTimeInfo == null)
            {
                taxiTimeInfo = new TaxiTimeInfo();
                taxiTimeInfo.ServiceStaffType = workInfo.AssignServiceStaffType;
                taxiTimeInfo.Customer = workInfo.AssignCustomer;

                if (workInfo.AssignServiceStaffType.Type == "282")
                {
                    //Family

                    return fillTaxiTimeInfo(taxiTimeInfo, workInfo.AssignCustomer.ACustomerGroup, company);
                }
                else
                {
                    //Position
                    return fillTaxiTimeInfo(taxiTimeInfo, workInfo.AssignCustomer, company);
                }
            }
            else
            {
                if (taxiTimeInfo.ServiceStaffType.Type == workInfo.AssignServiceStaffType.Type)
                {
                    if (taxiTimeInfo.ServiceStaffType.Type == "282")
                    {
                        if (taxiTimeInfo.Customer.ACustomerGroup.Code == workInfo.AssignCustomer.ACustomerGroup.Code)
                        {
                            return true;
                        }
                        else
                        {
                            taxiTimeInfo = null;
                            return fillTaxiTimeInfo(ref taxiTimeInfo, workInfo, company);
                        }
                    }
                    else
                    {
                        if (taxiTimeInfo.Customer.Code == workInfo.AssignCustomer.Code)
                        {
                            return true;
                        }
                        else
                        {
                            taxiTimeInfo = null;
                            return fillTaxiTimeInfo(ref taxiTimeInfo, workInfo, company);
                        }
                    }
                }
                else
                {
                    taxiTimeInfo = null;
                    return fillTaxiTimeInfo(ref taxiTimeInfo, workInfo, company);
                }
            }
        }
        #endregion

        //============================== Public Method ==============================
        protected virtual bool validTaxi(WorkInfo value)
        {
            return true;
        }

        public void CalculateTaxiBenefit(EmployeeBenefit value)
        {
            TaxiTimeInfo taxiTimeInfo = null;
            value.BenefitTaxiList.Clear();
            value.BenefitTaxiListForCharge.Clear();
            for (int i = 0; i < value.BenefitOTHourList.Count; i++)
            {
                if (value.WorkInfoList[i].AssignServiceStaffType.APosition.PositionCode == "28")
                {
                    if (value.BenefitOTHourList[i].ValidOTHour && validTaxi(value.WorkInfoList[i]))
                    {
                        fillTaxiTimeInfo(ref taxiTimeInfo, value.WorkInfoList[value.BenefitOTHourList[i].BenefitDate], value.Employee.Company);
                        calculateTaxiBenefit(value, value.BenefitTaxiList, value.BenefitOTHourList[i], taxiTimeInfo, value.OtherBenefitRate.TaxiRate);
                        calculateTaxiBenefitForCharge(value, value.BenefitOTHourList[i], taxiTimeInfo, value.WorkInfoList[value.BenefitOTHourList[i].BenefitDate]);
                    }
                }
            }
            CalculateTotalTaxiBenefit(value);
        }

        public void CalculateTaxiBenefit(int index, EmployeeBenefit value)
        {
            TaxiTimeInfo taxiTimeInfo = null;
            if (value.BenefitTaxiList.Contain(value.BenefitOTHourList[index].BenefitDate))
            {
                value.BenefitTaxiList.Remove(value.BenefitOTHourList[index].EntityKey);
            }

            if (value.BenefitTaxiListForCharge.Contain(value.BenefitOTHourList[index].EntityKey))
            {
                value.BenefitTaxiListForCharge.Remove(value.BenefitOTHourList[index].EntityKey);
            }

            if (value.BenefitOTHourList[index].ValidOTHour && validTaxi(value.WorkInfoList[index]))
            {
                fillTaxiTimeInfo(ref taxiTimeInfo, value.WorkInfoList[value.BenefitOTHourList[index].BenefitDate], value.Employee.Company);
                calculateTaxiBenefit(value, value.BenefitTaxiList, value.BenefitOTHourList[index], taxiTimeInfo, value.OtherBenefitRate.TaxiRate);
                calculateTaxiBenefitForCharge(value, value.BenefitOTHourList[index], taxiTimeInfo, value.WorkInfoList[value.BenefitOTHourList[index].BenefitDate]);
                CalculateTotalTaxiBenefit(value);
            }
        }

        public void CalculateTotalTaxiBenefit(EmployeeBenefit value)
        {
            value.BenefitTaxiList.TotalTimes = 0;
            value.BenefitTaxiList.TotalAmount = 0;

            for (int i = 0; i < value.BenefitTaxiList.Count; i++)
            {
                value.BenefitTaxiList.TotalTimes += value.BenefitTaxiList[i].Times;
                value.BenefitTaxiList.TotalAmount += value.BenefitTaxiList[i].TotalAmount;
            }
        }

        public void FillTaxiBenefit(EmployeeBenefit value)
        {
            BenefitTaxi benefitTaxi;
            value.BenefitTaxiList.Clear();

            EmployeeTaxiBenefit employeeTaxiBenefit = new EmployeeTaxiBenefit(value.Employee, value.ForMonth);

            if (dbEmployeeTaxiBenefit.FillTaxiBenefitList(ref employeeTaxiBenefit))
            {
                for (int i = 0; i < employeeTaxiBenefit.Count; i++)
                {
                    benefitTaxi = new BenefitTaxi(employeeTaxiBenefit[i].BenefitDate);
                    benefitTaxi.Times = employeeTaxiBenefit[i].Times;
                    benefitTaxi.Amount = employeeTaxiBenefit[i].BaseAmount;
                    benefitTaxi.TotalAmount = employeeTaxiBenefit[i].TotalAmount;
                    value.BenefitTaxiList.Add(benefitTaxi);
                }
            }

            CalculateTotalTaxiBenefit(value);

            employeeTaxiBenefit = null;
            benefitTaxi = null;
        }
    }
}