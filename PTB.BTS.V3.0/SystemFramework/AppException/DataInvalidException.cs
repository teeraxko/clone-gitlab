using System;
using SystemFramework.AppMessage;

namespace SystemFramework.AppException
{
	public class DataInvalidException : AppExceptionBase
	{
		public DataInvalidException(string dataInvalid, string fileName) : base(fileName)
		{
			base.SetMessage(MessageList.Error.E0019, dataInvalid);
		}
	}
}