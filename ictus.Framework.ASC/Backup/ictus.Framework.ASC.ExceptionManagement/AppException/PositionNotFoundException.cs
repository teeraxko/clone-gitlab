using System;
using ictus.Framework.ASC.ExceptionManagement.AppMessage;
namespace ictus.Framework.ASC.ExceptionManagement.AppException
{
    public class PositionNotFoundException : AppExceptionBase
    {
        public PositionNotFoundException(string fileName)
            : base(fileName)
        {
            //base.SetMessage(MessageList.Error.E000002, "ข้อมูลตำแหน่ง");
        }
    }
}
