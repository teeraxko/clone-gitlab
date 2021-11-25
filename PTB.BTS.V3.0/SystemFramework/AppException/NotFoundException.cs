using System;
using SystemFramework.AppMessage;

namespace SystemFramework.AppException
{
	public class NotFoundException : AppExceptionBase
	{
		public NotFoundException(string notFound, string fileName) : base(fileName)
		{
			base.SetMessage(MessageList.Error.E0004, notFound);
		}
	}
}