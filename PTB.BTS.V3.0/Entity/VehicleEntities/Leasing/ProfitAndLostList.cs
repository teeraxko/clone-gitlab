using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.VehicleEntities.Leasing
{
    public class ProfitAndLostList : ictus.Common.Entity.General.ListBase
    {
        //============================== Property ==============================
        private DateTime bvDate;
        public DateTime BVDate
        {
            get { return bvDate; }
            set { bvDate = value; }
        }

        private decimal percentCompensate;
        public decimal PercentCompensate
        {
            get { return percentCompensate; }
            set { percentCompensate = value; }
        }
	
        //============================== Public Method ==============================
        public void Add(IProfitAndLost value)
        { base.Add(value); }

        public void Remove(IProfitAndLost value)
        { base.Remove(value); }

        public IProfitAndLost this[int index]
        {
            get
            { return (IProfitAndLost)base.BaseGet(index); }
            set
            { base.BaseSet(index, value); }
        }

        public IProfitAndLost this[String key]
        {
            get
            { return (IProfitAndLost)base.BaseGet(key); }
            set
            { base.BaseSet(key, value); }
        }
    }
}
