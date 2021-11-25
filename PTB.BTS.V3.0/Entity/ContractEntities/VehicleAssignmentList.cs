using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using Entity.VehicleEntities;

namespace Entity.ContractEntities
{
    public class VehicleAssignmentList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Property ==============================
		private Vehicle aVehicle;
		public Vehicle AVehicle
		{
			get
			{return aVehicle;}
			set
			{aVehicle = value;}
		}

//		============================== Constructor ==============================
        public VehicleAssignmentList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(VehicleAssignment value)
		{base.Add(value);}

		public void Remove(VehicleAssignment value)
		{base.Remove(value);}

		public VehicleAssignment this[int index]
		{
			get{return((VehicleAssignment) base.BaseGet(index));}
			set{base.BaseSet(index, value);}
		}

		public VehicleAssignment this[String key]  
		{
			get{return((VehicleAssignment)base.BaseGet(key));}
			set{base.BaseSet(key, value);}
		}
		
	}
}
