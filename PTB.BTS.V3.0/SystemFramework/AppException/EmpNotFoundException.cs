using System;
using SystemFramework.AppMessage;

namespace SystemFramework.AppException
{
	public class EmpNotFoundException : AppExceptionBase
	{
		public EmpNotFoundException(string fileName) : base(fileName)
		{
			base.SetMessage(MessageList.Error.E0004,"รหัสพนักงาน");
		}
	}
}