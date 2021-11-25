using System;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
	public class DriverContract : ServiceStaffContract
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

//		==================================Constructor==================================
        public DriverContract(ictus.Common.Entity.Company aCompany)
            : base(aCompany)
		{
		}

		#region IKey Members

        public override string EntityKey
		{
			get
			{
				return base.EntityKey;
			}
		}

		#endregion

	}
}
