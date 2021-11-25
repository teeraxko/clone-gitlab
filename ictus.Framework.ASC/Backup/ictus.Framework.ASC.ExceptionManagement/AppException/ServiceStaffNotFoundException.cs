using System;
using ictus.Framework.ASC.ExceptionManagement.AppMessage;

namespace ictus.Framework.ASC.ExceptionManagement.AppException
{
    public class ServiceStaffNotFoundException : AppExceptionBase
    {
        public ServiceStaffNotFoundException(string fileName)
            : base(fileName)
        {
            //base.SetMessage(MessageList.Error.E000002, "รหัสพนักงานบริการ");
        }
    }
}
