using System;
using ictus.Framework.ASC.ExceptionManagement.AppMessage;

namespace ictus.Framework.ASC.ExceptionManagement.AppException
{
    public class DuplicateException : AppExceptionBase
    {
        public string Text = "";
        public bool IsThai = true;

        public DuplicateException(string fileName, bool thai)
            : base(fileName)
        {
            IsThai = thai;
            Text = fileName;
            //base.SetMessage(MessageList.Error.E000003);

            //�ͧ��� E000003 = ����¡�ù��㹰ҹ���������� ��سҡ�͡�����������ա����"
            //�ͧ���� E000003 = "(��{0}��к����� !";
        }

        public DuplicateException(string fileName)
            : base(fileName)
        {
            Text = fileName;
            //base.SetMessage(MessageList.Error.E000003);
        }

        //public DuplicateException(MessageList.Error message, string fileName)
        //    : base(fileName)
        //{
        //    base.SetMessage(message);
        //    Text = fileName;
        //}
    }
}
