using System;

namespace ictus.Framework.ASC.AppConfig
{
	public class Function : ApplicationBase
	{
//		============================== Property ==============================
        protected string id = "";
        public string ID
        {
            get { return id; }
            set { id = value; }
        }	

//		============================== Constructor ==============================
		public Function() : base()
		{
		}
	}
}
