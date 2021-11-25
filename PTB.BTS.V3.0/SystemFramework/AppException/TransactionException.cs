using System;

namespace SystemFramework.AppException
{
	public class TransactionException : AppExceptionBase
	{
		public TransactionException(string fileName, string message) : base(fileName)
		{
			base.SetMessage(message);
		}
	}
}