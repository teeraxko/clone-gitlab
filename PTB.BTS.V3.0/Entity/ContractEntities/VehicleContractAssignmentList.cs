using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
    public class VehicleContractAssignmentList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Property ==============================
		private VehicleContract aVehicleContract;	
		public VehicleContract AVehicleContract
		{
			get
			{return aVehicleContract;}
			set 
			{aVehicleContract = value;}
		}

//		============================== Constructor ==============================
        public VehicleContractAssignmentList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(VehicleAssignment value)
		{
			base.Add(value);
		}

		public void Remove(VehicleAssignment value)
		{
			base.Remove(value);
		}

		public VehicleAssignment this[int index]
		{
			get
			{
				return((VehicleAssignment) base.BaseGet(index));
			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public VehicleAssignment this[String key]  
		{
			get
			{
				return((VehicleAssignment)base.BaseGet(key));
			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
