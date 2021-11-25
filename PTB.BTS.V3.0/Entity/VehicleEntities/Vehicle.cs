using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using Entity.ContractEntities;
using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

namespace Entity.VehicleEntities
{
	public class Vehicle : EntityBase, IKey
	{
		//		============================== Property ==============================
		protected int vehicleNo = NullConstant.INT;
		public int VehicleNo
		{
			set{vehicleNo = value;}
			get{return vehicleNo;}
		}

		protected string platePrefix = NullConstant.STRING; 
		public string PlatePrefix
		{			
			set{platePrefix = value.Trim();}
			get{return platePrefix;}
		}

		protected string plateRunningNo = NullConstant.STRING;
		public string PlateRunningNo
		{
			set{plateRunningNo = value.Trim();}
			get{return plateRunningNo;}	
		}


		protected KindOfVehicle aKindOfVehicle;
		public KindOfVehicle AKindOfVehicle
		{
			set{aKindOfVehicle = value;}
			get{return aKindOfVehicle;}		 	
		}

		protected Model aModel;
		public Model AModel
		{			
			set{aModel = value;}
			get{return aModel;}
		}

        protected VehicleVatStatus vatStatus;
        public VehicleVatStatus VatStatus
        {
            set { vatStatus = value; }
            get { return vatStatus; }
        }

		protected VehicleStatus aVehicleStatus;
		public VehicleStatus AVehicleStatus
		{
			set{aVehicleStatus = value;}
			get{return aVehicleStatus;}			
		}
		
		protected Color aColor;
		public Color AColor
		{			
			set{aColor = value;}
			get{return aColor;}
		}
		
		protected DateTime buyDate = NullConstant.DATETIME;
		public DateTime BuyDate
		{			
			set{buyDate = value;}
			get{return buyDate;}
		}

		protected DateTime registerDate = NullConstant.DATETIME;
		public DateTime RegisterDate
		{			
			set{registerDate = value;}
			get{return registerDate;}
		}

		public string PlateNo
		{
			get{return plateRunningNo + "-" + platePrefix ;}
		}
		public string PlateNumber
		{
			get{return platePrefix + "-" + plateRunningNo ;}
		}

        protected PLATE_STATUS plateStatus = PLATE_STATUS.NULL;
        public PLATE_STATUS PlateStatus
        {
            set { plateStatus = value; }
            get { return plateStatus; }
        }

        protected string chassisNo = NullConstant.STRING;
        public string ChassisNo
        {
            set { chassisNo = value.Trim(); }
            get { return chassisNo; }
        }

		//		============================== Constructor ==============================
		public Vehicle() : base()
		{
		}

		//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return vehicleNo.ToString();}
		}
	}
}

