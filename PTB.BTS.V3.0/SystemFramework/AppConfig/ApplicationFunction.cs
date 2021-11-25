using System;

namespace SystemFramework.AppConfig
{
	public class ApplicationFunction
	{
//		============================== Property ==============================
		private Function function;
		public Function Function
		{
			set{function = value;}
			get{return function;}
		}

		public string Name
		{
			set{function.Name = value;}
			get{return function.Name;}
		}

		public string Description
		{			
			set{function.Description = value;}
			get{return function.Description;}
		}

        public string ID
        {
            set { function.ID = value; }
            get { return function.ID; }
        }

		public bool IsSystem
		{			
			set{function.IsSystem = value;}
			get{return function.IsSystem;}
		}

//		============================== Constructor ==============================
		public ApplicationFunction()
		{
			function = new Function();
		}

		public ApplicationFunction(Function value)
		{
			function = value;
		}
	}
}
