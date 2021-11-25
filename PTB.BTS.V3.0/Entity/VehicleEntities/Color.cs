using System;
using ictus.Common.Entity.General;

namespace Entity.VehicleEntities
{
	public class Color : DualFieldBase
	{
//		============================== Constructor ==============================
		public Color() : base()
		{
		}

		public override string ToString()
		{
			return aName.English;
		}
	}
}
