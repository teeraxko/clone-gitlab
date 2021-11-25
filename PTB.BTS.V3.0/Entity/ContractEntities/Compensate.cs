using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.ContractEntities
{
    public class Compensate : EntityBase, IKey
    {
        private decimal compensateRate = decimal.Zero;
        public decimal CompensateRate
        {
            get { return compensateRate; }
            set { compensateRate = value; }
        }

        public override string EntityKey
        {
            get { return compensateRate.ToString(); }
        }
    }
}
