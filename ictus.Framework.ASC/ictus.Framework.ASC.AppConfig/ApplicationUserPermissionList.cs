using System;

namespace ictus.Framework.ASC.AppConfig
{
	public class ApplicationUserPermissionList : ApplicationListBase
	{
//		============================== Constructor ==============================
		public ApplicationUserPermissionList() : base()
		{
		}

//		============================== Public Method ==============================
		public void Add(ApplicationUserPermission value)
		{base.Add(value.AUser.UserName, value);}

		public void Remove(ApplicationUserPermission value)
		{base.Remove(value.AUser.UserName);}
	
		public ApplicationUserPermission this[int index]
		{
			get{return((ApplicationUserPermission) base.BaseGet(index));}
			set{base.BaseSet(index, value);}
		}

		public ApplicationUserPermission this[String key]  
		{
			get{return((ApplicationUserPermission)base.BaseGet(key));}
			set{base.BaseSet(key, value);}
		}

	}
}
