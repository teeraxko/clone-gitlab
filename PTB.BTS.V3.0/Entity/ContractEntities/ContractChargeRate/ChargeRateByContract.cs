using System;
using System.Text;
using Entity.ContractEntities;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.General;

namespace PTB.BTS.ContractEntities.ContractChargeRate
{
    public class ChargeRateByContract : EntityBase, IKey
    {
        private ChargeRate chargeRate;
        public ChargeRate ChargeRate
        {
            get { return chargeRate; }
            set { chargeRate = value; }
        }

        private ContractBase contractBase;
        public ContractBase ContractBase
        {
            get { return contractBase; }
            set { contractBase = value; }
        }

        //============================== Public Method ==============================
        public ChargeRateByContract()
            : base()
        {
            chargeRate = new ChargeRate();
        }

        //============================== Public Method ==============================
        public override string EntityKey
        {
            get { return contractBase.EntityKey; }
        }
    }
}
