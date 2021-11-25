using System;

namespace ictus.Framework.ASC.AppConfig
{
	public class ApplicationModuleList : ApplicationListBase
	{
//		============================== Constructor ==============================
		public ApplicationModuleList() : base()
		{
		}

//		============================== Public Method ==============================
		public void Add(ApplicationModule value)
		{base.Add(value.Name, value);}

		public void Remove(ApplicationModule value)
		{base.Remove(value.Name);}

		public ApplicationModule this[int index]
		{
			get{return((ApplicationModule) base.BaseGet(index));}
			set{base.BaseSet(index, value);}
		}

		public ApplicationModule this[String key]  
		{
			get{return((ApplicationModule)base.BaseGet(key));}
			set{base.BaseSet(key, value);}
		}
	}
}
