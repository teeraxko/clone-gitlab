using System;

using ictus.Common.Entity.General;

namespace Entity.VehicleEntities
{
	public class KindOfVehicle : DualFieldBase
	{
		public const string LEASING_POSITION_CAR = "1";
		public const string LEASING_FAMILY_CAR = "2";
		public const string SPARE = "Z";
//		============================== Constructor ==============================
		public KindOfVehicle(): base()
		{
		}

		public override string ToString()
		{
			return aName.English;
		}
	}
}