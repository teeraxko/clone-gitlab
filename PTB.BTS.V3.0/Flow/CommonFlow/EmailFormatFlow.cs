using System;

using SystemFramework.AppConfig;

using DataAccess.CommonDB;
using Entity.CommonEntity;

namespace PTB.BTS.Common.Flow
{
	public class EmailFormatFlow
	{
		#region - Constant -
		#endregion

		#region - Private - 
		private EmailFormatDB dbEmailFormat;

		#endregion

		//============================== Property ==============================

		//============================== Constructor ==============================
        public EmailFormatFlow()
		{
            dbEmailFormat = new EmailFormatDB();
		}
		

		//============================== Public Method ==============================
		public EmailFormat GetEmailFormat(string emailCode)
		{
            EmailFormat emailFormat = new EmailFormat();
            if (dbEmailFormat.FillEmailFormatByCode(ref emailFormat, emailCode))
			{
                return emailFormat;
			}
			else
			{
                return null;
			}
		}
	}
}
