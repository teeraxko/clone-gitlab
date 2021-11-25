using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity.General;

namespace Entity.ContractEntities
{
    public class VehicleChargeDiffList : ListBase
    {
        //============================== Public Method ==============================
        public void Add(VehicleChargeDiff value)
        { base.Add(value); }

        public void Remove(VehicleChargeDiff value)
        { base.Remove(value); }

        public VehicleChargeDiff this[int index]
        {
            get { return (VehicleChargeDiff)base.BaseGet(index); }
            set { base.BaseSet(index, value); }
        }

        public VehicleChargeDiff this[String key]
        {
            get { return (VehicleChargeDiff)base.BaseGet(key); }
            set { base.BaseSet(key, value); }
        }
    }
}
