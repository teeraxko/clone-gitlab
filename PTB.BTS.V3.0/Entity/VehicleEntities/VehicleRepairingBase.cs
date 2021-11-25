using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

namespace Entity.VehicleEntities
{
    public abstract class VehicleRepairingBase : CompanyStuffBase
	{
//		============================== Property ==============================
		protected VehicleInfo aVehicleInfo;
		public VehicleInfo AVehicleInfo
		{
			set{aVehicleInfo = value;}
			get{return aVehicleInfo;}
		}

//		============================== Constructor ==============================
        protected VehicleRepairingBase(Company aCompany)
            : base(aCompany)
		{
		}

		//============================== Public Method ==============================
		public void Add(RepairingInfoBase value)
		{base.Add(value);}

        public void Remove(RepairingInfoBase value)
		{base.Remove(value);}

        public RepairingInfoBase this[int index]
		{
            get { return ((RepairingInfoBase)base.BaseGet(index)); }
			set{base.BaseSet(index, value);}
		}

        public RepairingInfoBase this[String key]  
		{
            get { return ((RepairingInfoBase)base.BaseGet(key)); }
			set{base.BaseSet(key, value);}
		}
	}
}
