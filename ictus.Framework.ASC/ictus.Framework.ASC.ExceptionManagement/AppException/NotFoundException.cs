using System;
using ictus.Framework.ASC.ExceptionManagement.AppMessage;

namespace ictus.Framework.ASC.ExceptionManagement.AppException
{
    public class NotFoundException : AppExceptionBase
    {
        public NotFoundException(string notFound, string fileName)
            : base(fileName)
        {
            //base.SetMessage(MessageList.Error.E000002, notFound);
        }
    }
}
