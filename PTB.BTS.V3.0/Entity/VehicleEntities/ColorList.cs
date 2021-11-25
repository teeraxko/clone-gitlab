using System;

using Entity.CommonEntity;

namespace Entity.VehicleEntities
{
	public class ColorList : ictus.Common.Entity.General.ListBase
	{
//		============================== Constructor ==============================
		public ColorList() : base()
		{
		}

//		============================== Public Method ==============================
		public void Add(Color value)
		{base.Add(value);}

		public void Remove(Color value)  
		{base.Remove(value);}

		public Color this[int index]
		{
			get{return (Color) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public Color this[String key]  
		{
			get{return (Color) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
