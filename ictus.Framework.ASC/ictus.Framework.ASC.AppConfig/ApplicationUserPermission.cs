using System;

namespace ictus.Framework.ASC.AppConfig
{
	public class ApplicationUserPermission : ApplicationListBase
	{
//		============================== Property ==============================
		private ApplicationUserProfile aUser;
		public ApplicationUserProfile AUser
		{
			set{aUser = value;}
			get{return aUser;}
		}

//		============================== Constructor ==============================
		public ApplicationUserPermission() : base()
		{
		}

		public ApplicationUserPermission(ApplicationUserProfile value) : base()
		{
			aUser = value;
		}

//		============================== Public Method ==============================
		public void Add(ModulePermission value)
		{base.Add(value.Name, value);}

		public void Remove(ModulePermission value)
		{base.Remove(value.Name);}

		public ModulePermission this[int index]
		{
			get{return((ModulePermission) base.BaseGet(index));}
			set{base.BaseSet(index, value);}
		}

		public ModulePermission this[String key]  
		{
			get{return((ModulePermission)base.BaseGet(key));}
			set{base.BaseSet(key, value);}
		}
	}
}
