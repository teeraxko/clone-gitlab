using System;

namespace ictus.Framework.ASC.AppConfig
{
	public class ApplicationBase
	{
//		============================== Property ==============================
		protected string name = "";
		public string Name
		{
			set{name = value;}
			get{return name;}
		}

		protected string description = "";
		public string Description
		{			
			set{description = value;}
			get{return description;}
		}

		private bool isSystem;
		public bool IsSystem
		{			
			set{isSystem = value;}
			get{return isSystem;}
		}

//		============================== Constructor ==============================
		public ApplicationBase()
		{
		}
	}
}
