using System;

namespace YST_DLV
{
    class YST_Ftp : ictus.SystemConnection.BizPac .Ftp
    {
        protected override string ftpURL
        {
            get { return @"ftp://bizpacftp:password@172.30.2.200:20125/YST/Import/"; }
        }

        protected override System.Text.Encoding StreamEncode
        {
            get
            {
                return System.Text.Encoding.Default;
            }
        }
    }
}
