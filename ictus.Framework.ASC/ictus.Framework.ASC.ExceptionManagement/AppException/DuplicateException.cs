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

            //ของเก่า E000003 = มีรายการนี้ในฐานข้อมูลแล้ว กรุณากรอกข้อมูลใหม่อีกครั้ง"
            //ของใหม่ E000003 = "(มี{0}ในระบบแล้ว !";
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
