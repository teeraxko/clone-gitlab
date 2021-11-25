using System;
using ictus.Framework.ASC.ExceptionManagement.AppMessage;


namespace ictus.Framework.ASC.ExceptionManagement.AppException
{
    public class EmpNotFoundException : AppExceptionBase
    {
        public EmpNotFoundException(string fileName)
            : base(fileName)
        {
            //base.SetMessage(MessageList.Error.E000002, "รหัสพนักงาน");
        }
    }
}
