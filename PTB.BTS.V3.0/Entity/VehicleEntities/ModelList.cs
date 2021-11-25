using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

namespace Entity.VehicleEntities
{
	public class ModelList : ictus.Common.Entity.General.ListBase
	{
//		============================== Property ==============================
		private Brand aBrand;
		public Brand ABrand
		{
			set{aBrand = value;}
			get{return aBrand;}
		}
//		============================== Constructor ==============================
		public ModelList() : base()
		{
			aBrand = new Brand();
		}

//		============================== Public Method ==============================
		public void Add(Model value)
		{
			base.Add(value);
		}

		public void Remove(Model value)  
		{
			base.Remove(value);
		}

		public Model this[int index]
		{
			get
			{
				return (Model) base.BaseGet(index);

			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public Model this[String key]  
		{
			get
			{
				return (Model) base.BaseGet(key);

			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
