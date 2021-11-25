using System;
using SystemFramework.AppMessage;

namespace SystemFramework.AppException
{
	public class DuplicateException : AppExceptionBase
	{
		public string Text = "";
		public bool IsThai = true;

		public DuplicateException(string fileName, bool thai) : base(fileName)
		{
			IsThai = thai;
			Text = fileName;
			base.SetMessage(MessageList.Error.E0003);
		}

		public DuplicateException(string fileName) : base(fileName)
		{
			Text = fileName;
			base.SetMessage(MessageList.Error.E0003);
		}

		public DuplicateException(MessageList.Error message, string fileName) : base(fileName)
		{
			base.SetMessage(message);
			Text = fileName;
		}
	}
}