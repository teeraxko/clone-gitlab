using System;

using PTB.BTS.Common.Flow;

using Facade.CommonFacade;

using SystemFramework.AppConfig;
using SystemFramework.AppException;
using Entity.CommonEntity;

namespace Facade.CommonFacade
{
	public class EmailFormatFacade
	{
		#region - Private -
		private EmailFormatFlow flowEmailFormat;
		#endregion


//		============================== Constructor ==============================
        public EmailFormatFacade()
		{
            flowEmailFormat = new EmailFormatFlow();
		}

//		============================== Public Method ==============================
        public EmailFormat GetEmailFormat(string emailCode)
		{
            return flowEmailFormat.GetEmailFormat(emailCode);
		}
	}
}
