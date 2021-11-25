using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity.General;

namespace Entity.VehicleEntities.ProfitCalculation
{
    public class ProfitCalDetailList : ListBase
    {
        //============================== Public Method ==============================
        public void Add(ProfitCalDetail value)
        { base.Add(value); }

        public void Remove(ProfitCalDetail value)
        { base.Remove(value); }

        public ProfitCalDetail this[int index]
        {
            get
            { return (ProfitCalDetail)base.BaseGet(index); }
            set
            { base.BaseSet(index, value); }
        }

        public ProfitCalDetail this[String key]
        {
            get
            { return (ProfitCalDetail)base.BaseGet(key); }
            set
            { base.BaseSet(key, value); }
        }
    }
}
