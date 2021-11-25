using System;

namespace SystemFramework.AppException
{
	public class ExceptionInfo
	{
		public ExceptionInfo()
		{
		}

		private static string className;
		public static string ClassName
		{
			get
			{
				return className;
			}
			set
			{
				className = value;
			}
		}

		private static string functionName;
		public static string FunctionName
		{
			get
			{
				return functionName;
			}
			set
			{
				functionName = value;
			}
		}
	}
}