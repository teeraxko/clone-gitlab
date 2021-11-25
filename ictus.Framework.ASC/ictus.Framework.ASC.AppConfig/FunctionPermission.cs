using System;

namespace ictus.Framework.ASC.AppConfig
{
	public enum FUNCTION_PERMISSION
	{
		NO_ACCESS,
		READ_ONLY,
		FULL_CONTROL
	}

	public class FunctionPermission
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
            get { return function.ID; }
        }

		public bool IsSystem
		{			
			set{function.IsSystem = value;}
			get{return function.IsSystem;}
		}

		private FUNCTION_PERMISSION permission = FUNCTION_PERMISSION.NO_ACCESS;
		public FUNCTION_PERMISSION Permission
		{
			set{permission = value;}
			get{return permission;}
		}

		public string PermissionDB
		{
			get
			{
				switch(permission)
				{
					case FUNCTION_PERMISSION.FULL_CONTROL :
					{
						return "F";
					}
					case FUNCTION_PERMISSION.READ_ONLY :
					{
						return "R";
					}
					case FUNCTION_PERMISSION.NO_ACCESS :
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
						permission = FUNCTION_PERMISSION.FULL_CONTROL;
						break;
					}
					case "R" :
					{
						permission = FUNCTION_PERMISSION.READ_ONLY;
						break;
					}
					case "N" :
					{
						permission = FUNCTION_PERMISSION.NO_ACCESS;
						break;
					}
					default :
					{
						permission = FUNCTION_PERMISSION.NO_ACCESS;
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
					case FUNCTION_PERMISSION.FULL_CONTROL :
					{
						return "Full Control";
					}
					case FUNCTION_PERMISSION.READ_ONLY :
					{
						return "Read Only";
					}
					case FUNCTION_PERMISSION.NO_ACCESS :
					{
						return "No Access";
					}
					default :
					{
						return "No Access";
					}
				}
			}
			set	
			{
				switch(value)
				{
					case "Full Control" :
					{
						permission = FUNCTION_PERMISSION.FULL_CONTROL;
						break;
					}
					case "Read Only" :
					{
						permission = FUNCTION_PERMISSION.READ_ONLY;
						break;
					}
					case "No Access" :
					{
						permission = FUNCTION_PERMISSION.NO_ACCESS;
						break;
					}
					default :
					{
						permission = FUNCTION_PERMISSION.NO_ACCESS;
						break;
					}
				}
			}
		}

//		============================== Constructor ==============================
		public FunctionPermission() : base()
		{
			function = new Function();
		}

		public FunctionPermission(Function value) : base()
		{
			function = value;
		}
	}
}
