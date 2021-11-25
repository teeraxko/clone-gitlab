using System;
using System.Runtime.Serialization;
using SystemFramework.AppMessage;

namespace SystemFramework.AppException
{
	public class AppExceptionBase : ApplicationException
	{
		public AppExceptionBase(string fileName) : base(fileName)
		{
		}

		public void SetMessage(string message)
		{
			customMessage = message;
		}

		public void SetMessage(MessageList.Error messageList)
		{
			customMessage = MessageList.GetMessage(messageList);
		}

		public void SetMessage(MessageList.Error messageList, string strOp1)
		{
			string str = MessageList.GetMessage(messageList);
			customMessage = string.Format(str, strOp1);
		}

		public void SetMessage(MessageList.Error messageList, string strOp1, string strOp2)
		{
			string str = MessageList.GetMessage(messageList);
			customMessage= string.Format(str, strOp1, strOp2);
		}
		
		public void SetMessage(MessageList.Question messageList, string strOp1, string strOp2, string strOp3)
		{
			string str = MessageList.GetMessage(messageList);
			customMessage = string.Format(str, strOp1, strOp2, strOp3);
		}

		protected string customMessage;
		public string CustomMessage
		{
			get{
				return customMessage;
			}
		}

		private DateTime exceptionDate = DateTime.Now;
		public DateTime ExceptionDate
		{
			get
			{
				return exceptionDate;
			}
		}

		private string machineName = Environment.MachineName;
		public string MachineName
		{
			get
			{
				return machineName;
			}
		}

	}
}