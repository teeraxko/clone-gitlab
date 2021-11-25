using System;
using SystemFramework.AppMessage;

namespace SystemFramework.AppException
{
	public class ServiceStaffNotFoundException : AppExceptionBase
	{
		public ServiceStaffNotFoundException(string fileName) : base(fileName)
		{
			base.SetMessage(MessageList.Error.E0004,"รหัสพนักงานบริการ");
		}
	}
}