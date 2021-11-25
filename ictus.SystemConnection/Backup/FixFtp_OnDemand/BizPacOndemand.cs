using System;
using System.IO;
using System.Collections;
using ictus.SystemConnection.BizPac.FixAsset;

namespace FixFtp_OnDemand
{
    /// <summary>
    /// For FixAsset FTP
    /// </summary>
    public class BizPacOndemand : BizPacMoveFile
    {
        #region Constant
        const string ACP_APC01P = "APC01P.XLS";
        const string FA_MNPTRHM0 = "MNPTRHM0.XLS";
        const string FA_MNPTRDM0 = "MNPTRDM0.XLS";
        const string GL_GBH = "GBH.XLS";
        const string GL_GBL = "GBL.XLS";

        const string ACP_APC01P_FTP = FTP_PATH + "ACP/" + ACP_APC01P;
        const string FA_MNPTRHM0_FTP = FTP_PATH + "FA/" + FA_MNPTRHM0;
        const string FA_MNPTRDM0_FTP = FTP_PATH + "FA/" + FA_MNPTRDM0;
        const string GL_GBH_FTP = FTP_PATH + "GL/" + GL_GBH;
        const string GL_GBL_FTP = FTP_PATH + "GL/" + GL_GBL; 
        #endregion

        protected override Hashtable GetFileFixAsset()
        {
            Hashtable hash = new Hashtable();
            hash.Add(ACP_APC01P_FTP, ACP_APC01P);
            hash.Add(FA_MNPTRHM0_FTP, FA_MNPTRHM0);
            hash.Add(FA_MNPTRDM0_FTP, FA_MNPTRDM0);
            hash.Add(GL_GBH_FTP, GL_GBH);
            hash.Add(GL_GBL_FTP, GL_GBL);
            return hash;
        }
    }
}
