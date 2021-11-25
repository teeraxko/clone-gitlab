using System;

namespace SystemFramework.AppConfig
{
	public class ApplicationModule : ApplicationListBase
	{
//		============================== Property ==============================
		private Module module;
		public Module Module
		{
			set{module = value;}
			get{return module;}
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

//		============================== Constructor ==============================
		public ApplicationModule() : base()
		{
			module = new Module();
		}
		
		public ApplicationModule(Module value) : base()
		{
			module = value;
		}
//		============================== Public Method ==============================
		public void Add(ApplicationFunction value)
		{base.Add(value.Name, value);}

		public void Remove(ApplicationFunction value)
		{base.Remove(value.Name);}

		public ApplicationFunction this[int index]
		{
			get{return((ApplicationFunction) base.BaseGet(index));}
			set{base.BaseSet(index, value);}
		}

		public ApplicationFunction this[String key]  
		{
			get{return((ApplicationFunction)base.BaseGet(key));}
			set{base.BaseSet(key, value);}
		}
	}
}
