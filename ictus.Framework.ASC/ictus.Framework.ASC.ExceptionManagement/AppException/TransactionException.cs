using System;

namespace ictus.Framework.ASC.ExceptionManagement.AppException
{
    public class TransactionException : AppExceptionBase
    {
        public TransactionException(string fileName, string message)
            : base(fileName)
        {
            base.SetMessage(message);
        }
    }
}
