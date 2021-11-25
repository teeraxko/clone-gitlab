using System;
using System.Collections.Generic;
using System.Text;

using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.General;

namespace PTB.BTS.ContractEntities.ContractChargeRate
{
    public class MinimumOTCharge : EntityBase, IKey
    {
        private bool driverOnlyStatus;
        public bool DriverOnlyStatus
        {
            get { return driverOnlyStatus; }
            set { driverOnlyStatus = value; }
        }

        private int minOTHour = 0;
        public int MinOTHour
        {
            get { return minOTHour; }
            set { minOTHour = value; }
        }

        private decimal minOTAmount = decimal.Zero;
        public decimal MinOTAmount
        {
            get { return minOTAmount; }
            set { minOTAmount = value; }
        }

        //============================== Public Method ==============================
        public override string EntityKey
        {
            get { return (driverOnlyStatus) ? "'Y'" : "'N'"; }
        }
    }
}
