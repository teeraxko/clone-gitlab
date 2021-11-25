using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using Entity.AttendanceEntities;

namespace Entity.VehicleEntities
{
	public class VehicleTax : EntityBase, IKey
	{
//		============================== Property ==============================
		private Vehicle aVehicle;
		public Vehicle AVehicle
		{
			set{aVehicle = value;}
			get{return aVehicle;}
		}

		private TimePeriod aPeriod;
		public TimePeriod APeriod
		{
			set{aPeriod = value;}
			get{return aPeriod;}
		}

		private decimal taxAmount = NullConstant.DECIMAL;
		public decimal TaxAmount
		{
			set{taxAmount = value;}
			get{return taxAmount;}
		}

		public int TaxYear
		{
			get{return (aPeriod.To.Year - aVehicle.RegisterDate.Year)+1;}
		}


//		============================== Constructor ==============================
		public VehicleTax() : base()
		{
			aPeriod = new TimePeriod();
		}

//		============================== Public Method ==============================
		#region IKey Members
		public override string EntityKey
		{
			get
			{return aVehicle.EntityKey + aPeriod.From.Year.ToString() + aPeriod.To.Year.ToString();}
		}
		#endregion
	}
}
