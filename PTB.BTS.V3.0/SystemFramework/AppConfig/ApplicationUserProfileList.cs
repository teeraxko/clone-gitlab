using System;

namespace SystemFramework.AppConfig
{
	public class ApplicationUserProfileList : ApplicationListBase
	{
//		============================== Constructor ==============================
		public ApplicationUserProfileList() : base()
		{}

//		============================== Public Method ==============================
		public void Add(ApplicationUserProfile value)
		{base.Add(value.UserName, value);}
	
		public ApplicationUserProfile this[int index]
		{
			get{return((ApplicationUserProfile) base.BaseGet(index));}
			set{base.BaseSet(index, value);}
		}

		public ApplicationUserProfile this[String key]  
		{
			get{return((ApplicationUserProfile)base.BaseGet(key));}
			set{base.BaseSet(key, value);}
		}
	}
}
