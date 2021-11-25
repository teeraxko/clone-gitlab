using System;
using System.Collections.Generic;
using System.Text;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.General;
using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;
using Entity.ContractEntities;

namespace PTB.BTS.ContractEntities.ContractChargeRate
{
    public class CustomerChargeAdjustment : EntityBase, IKey
    {
        #region Property
        private YearMonth forYearMonth;
        public YearMonth ForYearMonth
        {
            get { return forYearMonth; }
            set { forYearMonth = value; }
        }

        private ContractBase contract;
        public ContractBase Contract
        {
            get { return contract; }
            set { contract = value; }
        }

        private Employee employee;
        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        private decimal otAHour = decimal.Zero;
        public decimal OTAHour
        {
            get { return otAHour; }
            set { otAHour = value; }
        }

        private decimal otAAmount = decimal.Zero;
        public decimal OTAAmount
        {
            get { return otAAmount; }
            set { otAAmount = value; }
        }

        private decimal otBHour = decimal.Zero;
        public decimal OTBHour
        {
            get { return otBHour; }
            set { otBHour = value; }
        }

        private decimal otBAmount = decimal.Zero;
        public decimal OTBAmount
        {
            get { return otBAmount; }
            set { otBAmount = value; }
        }

        private decimal otCHour = decimal.Zero;
        public decimal OTCHour
        {
            get { return otCHour; }
            set { otCHour = value; }
        }

        private decimal otCAmount = decimal.Zero;
        public decimal OTCAmount
        {
            get { return otCAmount; }
            set { otCAmount = value; }
        }

        private int holiday = 0;
        public int Holiday
        {
            get { return holiday; }
            set { holiday = value; }
        }

        private decimal holidayAmount = decimal.Zero;
        public decimal HolidayAmount
        {
            get { return holidayAmount; }
            set { holidayAmount = value; }
        }

        private int taxiTimes = 0;
        public int TaxiTimes
        {
            get { return taxiTimes; }
            set { taxiTimes = value; }
        }

        private decimal taxiAmount = decimal.Zero;
        public decimal TaxiAmount
        {
            get { return taxiAmount; }
            set { taxiAmount = value; }
        }

        private int oneDayTripFarTimes = 0;
        public int OneDayTripFarTimes
        {
            get { return oneDayTripFarTimes; }
            set { oneDayTripFarTimes = value; }
        }

        private decimal oneDayTripFarAmount = decimal.Zero;
        public decimal OneDayTripFarAmount
        {
            get { return oneDayTripFarAmount; }
            set { oneDayTripFarAmount = value; }
        }

        private int oneDayTripNearTimes = 0;
        public int OneDayTripNearTimes
        {
            get { return oneDayTripNearTimes; }
            set { oneDayTripNearTimes = value; }
        }

        private decimal oneDayTripNearAmount = decimal.Zero;
        public decimal OneDayTripNearAmount
        {
            get { return oneDayTripNearAmount; }
            set { oneDayTripNearAmount = value; }
        }

        private int overnightTripTimes = 0;
        public int OvernightTripTimes
        {
            get { return overnightTripTimes; }
            set { overnightTripTimes = value; }
        }

        private decimal overnightTripAmount = decimal.Zero;
        public decimal OvernightTripAmount
        {
            get { return overnightTripAmount; }
            set { overnightTripAmount = value; }
        }

        private decimal deduct = decimal.Zero;
        public decimal Deduct
        {
            get { return deduct; }
            set { deduct = value; }
        }

        private decimal deductAmount = decimal.Zero;
        public decimal DeductAmount
        {
            get { return deductAmount; }
            set { deductAmount = value; }
        }

        private decimal otherAmount = decimal.Zero;
        public decimal OtherAmount
        {
            get { return otherAmount; }
            set { otherAmount = value; }
        }

        private string reason = NullConstant.STRING;
        public string Reason
        {
            get { return reason; }
            set { reason = value.Trim(); }
        }

        private CustomerDepartment assignDepartment = new CustomerDepartment();
        public CustomerDepartment AssignDepartment
        {
            get { return assignDepartment; }
            set { assignDepartment = value; }
        } 
        #endregion

        #region Public Method
        public override string EntityKey
        {
            get { return forYearMonth.Year.ToString() + forYearMonth.Month.ToString() + contract.EntityKey + employee.EntityKey + assignDepartment.Code; }
        } 
        #endregion
    }
}
