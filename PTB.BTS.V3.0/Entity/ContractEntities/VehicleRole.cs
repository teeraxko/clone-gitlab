using System;

using Entity.VehicleEntities;
using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.ContractEntities
{
	public class VehicleRole : EntityBase, IKey
	{
//		============================== Property ==============================
		private Vehicle aVehicle;
		public Vehicle AVehicle
		{
			get{return aVehicle;}
			set{aVehicle = value;}
		}

		private KindOfVehicle aKindOfVehicle;
		public KindOfVehicle AKindOfVehicle
		{
			get{return aKindOfVehicle;}
			set{aKindOfVehicle = value;}
		}

		private Driver aDriver;
		public Driver ADriver
		{
			get{return aDriver;}
			set{aDriver = value;}		
		}

		private Hirer aHirer;
		public Hirer AHirer
		{
			get{return aHirer;}
			set{aHirer = value;}
		}
//		============================== Constructor ==============================
		public VehicleRole() : base()
		{
			aHirer = new Hirer();
		}

		#region IKey Members

		public override string EntityKey
		{
			get{return aVehicle.VehicleNo.ToString();}
		}

		#endregion
	}
}
