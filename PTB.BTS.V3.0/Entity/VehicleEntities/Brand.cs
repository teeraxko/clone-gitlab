using System;

using ictus.Common.Entity.General;

namespace Entity.VehicleEntities
{
	public class Brand : DualFieldBase
	{
//		============================== Constructor ==============================
		public Brand() : base()
		{
		}

		public override string ToString()
		{
			return aName.English;
		}
	}
}
