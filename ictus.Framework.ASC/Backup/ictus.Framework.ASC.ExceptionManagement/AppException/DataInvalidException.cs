using System;
using ictus.Framework.ASC.ExceptionManagement.AppMessage;

namespace ictus.Framework.ASC.ExceptionManagement.AppException
{
    public class DataInvalidException : AppExceptionBase
    {
        public DataInvalidException(string dataInvalid, string fileName)
            : base(fileName)
        {
            //base.SetMessage(MessageList.Error.E000001, dataInvalid);
        }
    }
}
