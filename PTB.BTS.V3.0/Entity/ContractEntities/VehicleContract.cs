using System;

using ictus.Common.Entity.General;
using Entity.ContractEntities;
using Entity.VehicleEntities;
using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
	public class VehicleContract : ContractBase
	{
//		============================== Property ==============================
		private DriverContract aDriverContract;
		public DriverContract ADriverContract
		{
			get{return aDriverContract;}
			set
			{aDriverContract = value;}
		}

		private VehicleRoleList aVehicleRoleList;
		public VehicleRoleList AVehicleRoleList
		{
			get{return aVehicleRoleList;}
			set
			{aVehicleRoleList = value;}
		}

        private int leaseTermMonth = 0;
        public int LeaseTermMonth
        {
            get { return leaseTermMonth; }
            set { leaseTermMonth = value; }
        }

        private KIND_OF_RENTAL_TYPE kindOfRental = KIND_OF_RENTAL_TYPE.NEWCAR;
        public KIND_OF_RENTAL_TYPE KindOfRental
        {
            get { return kindOfRental; }
            set { kindOfRental = value; }
        }

        private bool continuousStatus = false;
        public bool ContinuousStatus
        {
            get { return continuousStatus; }
            set { continuousStatus = value; }
        }
	

//		============================== Constructor ==============================
        public VehicleContract(ictus.Common.Entity.Company company)
            : base(company)
		{
			aVehicleRoleList = new VehicleRoleList(company);
		}

        public VehicleContract()
            : base()
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
