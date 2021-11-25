using System;

namespace SystemFramework.AppConfig
{
	public enum MODULE_PERMISSION
	{
		ACCESS,
		NO_ACCESS
	}

	public class ModulePermission : ApplicationListBase
	{
//		============================== Property ==============================
		private Module module;
		public Module Module
		{
			get{return module;}
			set{module = value;}
		}

		public string Name
		{
			set{module.Name = value;}
			get{return module.Name;}
		}

		public string Description
		{			
			set{module.Description = value;}
			get{return module.Description;}
		}

		public bool IsSystem
		{			
			set{module.IsSystem = value;}
			get{return module.IsSystem;}
		}

		private MODULE_PERMISSION permission = MODULE_PERMISSION.NO_ACCESS;
		public MODULE_PERMISSION Permission
		{
			get{return permission;}
			set{permission = value;}		
		}

		public string PermissionDB
		{
			get
			{
				switch(permission)
				{
					case MODULE_PERMISSION.ACCESS :
					{
						return "F";
					}
					case MODULE_PERMISSION.NO_ACCESS :
					{
						return "N";
					}
					default :
					{
						return "N";
					}
				}
			}
			set
			{
				switch(value)
				{
					case "F" :
					{
						permission = MODULE_PERMISSION.ACCESS;
						break;
					}
					case "N" :
					{
						permission = MODULE_PERMISSION.NO_ACCESS;
						break;
					}
					default :
					{
						permission = MODULE_PERMISSION.NO_ACCESS;
						break;
					}
				}
			}
		}

		public string PermissionString
		{
			get
			{
				switch(permission)
				{
					case MODULE_PERMISSION.ACCESS :
					{
						return "ACCESS";
					}
					case MODULE_PERMISSION.NO_ACCESS :
					{
						return "NO_ACCESS";
					}
					default :
					{
						return "NO_ACCESS";
					}
				}
			}
		}

//		============================== Constructor ==============================
		public ModulePermission() : base()
		{
		}

		public ModulePermission(Module value) : base()
		{
			module = value;
		}

//		============================== Public Method ==============================
		public void Add(FunctionPermission value)
		{base.Add(value.Name, value);}

		public void Remove(FunctionPermission value)
		{base.Remove(value.Name);}

		public FunctionPermission this[int index]
		{
			get{return((FunctionPermission) base.BaseGet(index));}
			set{base.BaseSet(index, value);}
		}

		public FunctionPermission this[String key]  
		{
			get{return((FunctionPermission)base.BaseGet(key));}
			set{base.BaseSet(key, value);}
		}

	}
}
