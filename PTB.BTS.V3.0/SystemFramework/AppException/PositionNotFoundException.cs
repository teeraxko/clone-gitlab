using System;
using SystemFramework.AppMessage;

namespace SystemFramework.AppException
{
	public class PositionNotFoundException : AppExceptionBase
	{
		public PositionNotFoundException(string fileName) : base(fileName)
		{
			base.SetMessage(MessageList.Error.E0004,"ข้อมูลตำแหน่ง");
		}
	}
}