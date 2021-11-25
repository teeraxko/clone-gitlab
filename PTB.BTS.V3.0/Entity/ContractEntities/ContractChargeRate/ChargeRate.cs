using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity.General;

namespace PTB.BTS.ContractEntities.ContractChargeRate
{
    public class ChargeRate
    {
        private decimal otARate = decimal.Zero;
        public decimal OTARate
        {
            get{return otARate;}
            set{otARate = value;}
        }

        private decimal otBRate = decimal.Zero;
        public decimal OTBRate
        {
            get { return otBRate; }
            set { otBRate = value; }
        }

        private decimal otCRate = decimal.Zero;
        public decimal OTCRate
        {
            get { return otCRate; }
            set { otCRate = value; }
        }

        private int basicChargeAmount = 0;
        public int BasicChargeAmount
        {
            get { return basicChargeAmount; }
            set { basicChargeAmount = value; }
        }

        private int absenceDeduction = 0;
        public int AbsenceDeduction
        {
            get { return absenceDeduction; }
            set { absenceDeduction = value; }
        }

        private int oneDayTripRateFar = 0;
        public int OneDayTripRateFar
        {
            get { return oneDayTripRateFar; }
            set { oneDayTripRateFar = value; }
        }

        private int oneDayTripRateNear = 0;
        public int OneDayTripRateNear
        {
            get { return oneDayTripRateNear; }
            set { oneDayTripRateNear = value; }
        }

        private int overnightTripRate = 0;
        public int OvernightTripRate
        {
            get { return overnightTripRate; }
            set { overnightTripRate = value; }
        }

        private int taxiRate = 0;
        public int TaxiRate
        {
            get { return taxiRate; }
            set { taxiRate = value; }
        }

        private int minLeaveDays = 0;
        public int MinLeaveDays
        {
            get { return minLeaveDays; }
            set { minLeaveDays = value; }
        }

        private decimal minHolidayAmount = decimal.Zero;
        public decimal MinHolidayAmount
        {
            get { return minHolidayAmount; }
            set { minHolidayAmount = value; }
        }
    }
}
