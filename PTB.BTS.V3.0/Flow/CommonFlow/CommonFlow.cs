using System;
using System.Text;
using System.Security.Cryptography;

using Entity.CommonEntity;
using ictus.Common.Entity.General;

using DataAccess.CommonDB;

namespace PTB.BTS.Common.Flow
{
	public class CommonFlow
	{
//		============================== Constructor ==============================
		public CommonFlow()
		{
		}

//		============================== Public Method ==============================
		public DateTime GetSystemDate()
		{
			CommonDB dbCommon = new CommonDB();
			DateTime systemDate = dbCommon.GetCurrentDate();
			dbCommon = null;
			return systemDate;
		}

		public  DateTime GetNullDate()
		{
			return NullConstant.DATETIME;
		}

        private static FiscalYear fiscalYear;
        public static FiscalYear FiscalYear
        {
            get
            {
                if(fiscalYear == null)
                {
                    using (DataAccess.CommonDB.FisCalYearDB dbFiscalYear = new DataAccess.CommonDB.FisCalYearDB())
                    {
                        fiscalYear = dbFiscalYear.GetFisCalYear();
                    }
                }

                return fiscalYear;
            }
        }

		public static string Encrypt(string value)
		{
			string result;
			MD5 md5 = new MD5CryptoServiceProvider();
			ASCIIEncoding AE = new ASCIIEncoding();

			byte[] byteValue = AE.GetBytes(value);
			byteValue = md5.ComputeHash(byteValue);
			result = AE.GetString(byteValue);

			byteValue = null;
			AE = null;
			md5 = null;

			return result;
		}
	}
}
