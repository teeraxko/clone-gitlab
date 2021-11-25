using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using Entity.VehicleEntities;

namespace Entity.ContractEntities
{
	public class Driver : ServiceStaff, IKey
	{
//		============================== Property ==============================
		private Vehicle aCurrentVehicle;
		public Vehicle ACurrentVehicle
		{
			get
			{return aCurrentVehicle;}
			set
			{aCurrentVehicle = value;}
		}
//		============================== Constructor ==============================
        public Driver(ictus.Common.Entity.Company value)
            : base(value)
		{
			aCurrentVehicle = new Vehicle();
		}

		#region IKey Members

		public new string EntityKey
		{
			get{return aCurrentVehicle.EntityKey + aCurrentContract.EntityKey;}
		}

		#endregion
	}
}
