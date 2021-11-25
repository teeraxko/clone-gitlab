using System;
using System.IO;
using System.Collections;
using ictus.SystemConnection.BizPac.FixAsset;

namespace FixFtp_Monthly
{
    /// <summary>
    /// For FixAsset FTP
    /// </summary>
    public class BizPacMonthly : BizPacMoveFile
    {
        #region Constant
        const string FA_FMPDEP01 = "FMPDEP01.XLS";
        const string FA_FMPDEL01 = "FMPDEL01.XLS";
        const string FA_FXPASTM1 = "FXPASTM1.XLS";
        const string FA_FXPAMDM1 = "FXPAMDM1.XLS";
        const string FA_FXPCODM1 = "FXPCODM1.XLS";
        const string FA_FXPDESM1 = "FXPDESM1.XLS";
        const string FA_FXPDESM2 = "FXPDESM2.XLS";
        const string FA_FXPKNDM1 = "FXPKNDM1.XLS";
        const string FA_GBH = "GBH.XLS";
        const string FA_GBL = "GBL.XLS";


        const string FA_FMPDEP01_FTP = FTP_PATH + "FA/" + FA_FMPDEP01;
        const string FA_FMPDEL01_FTP = FTP_PATH + "FA/" + FA_FMPDEL01;
        const string FA_FXPASTM1_FTP = FTP_PATH + "FA/" + FA_FXPASTM1;
        const string FA_FXPAMDM1_FTP = FTP_PATH + "FA/" + FA_FXPAMDM1;
        const string FA_FXPCODM1_FTP = FTP_PATH + "FA/" + FA_FXPCODM1;
        const string FA_FXPDESM1_FTP = FTP_PATH + "FA/" + FA_FXPDESM1;
        const string FA_FXPDESM2_FTP = FTP_PATH + "FA/" + FA_FXPDESM2;
        const string FA_FXPKNDM1_FTP = FTP_PATH + "FA/" + FA_FXPKNDM1;
        const string FA_GBH_FTP = FTP_PATH + "FA/" + FA_GBH;
        const string FA_GBL_FTP = FTP_PATH + "FA/" + FA_GBL;

        #endregion

        protected override Hashtable GetFileFixAsset()
        {
            Hashtable hash = new Hashtable();
            hash.Add(FA_FMPDEP01_FTP, FA_FMPDEP01);
            hash.Add(FA_FMPDEL01_FTP, FA_FMPDEL01);
            hash.Add(FA_FXPASTM1_FTP, FA_FXPASTM1);
            hash.Add(FA_FXPAMDM1_FTP, FA_FXPAMDM1);
            hash.Add(FA_FXPCODM1_FTP, FA_FXPCODM1);
            hash.Add(FA_FXPDESM1_FTP, FA_FXPDESM1);
            hash.Add(FA_FXPDESM2_FTP, FA_FXPDESM2);
            hash.Add(FA_FXPKNDM1_FTP, FA_FXPKNDM1);
            hash.Add(FA_GBH_FTP, FA_GBH);
            hash.Add(FA_GBL_FTP, FA_GBL);
            return hash;
        }
    }
}
