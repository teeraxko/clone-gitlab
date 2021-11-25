using System;

namespace ictus.Framework.ASC.AppConfig
{
    public static class ApplicationProfile
    {
        public static string DB_NAME = "BTSDB";
        public static string DB_USER_NAME = "BTS";
        public static string DB_USER_PASSWORD = "BTS";

        public static string SERVER_NAME = @"ICTDEVDB01\SECURED";
        public static string REPORT_PATH = @"\\ictdev01\ptb\Report\";
        public static string PHOTO_PATH = @"\\ictdev01\ptb\Photo\";
        public static string FTP_URL = @"ftp://bizpacftp:password@172.30.2.164:21/PTB/TestImport/";

        //public static string SERVER_NAME = "PTBSVR1";
        //public static string REPORT_PATH = @"\\PTBSVR1\BTS\Report\";
        //public static string PHOTO_PATH = @"\\PTBSVR1\BTS\PHOTO\";
        //public static string FTP_URL = @"ftp://bizpacftp:password@172.30.2.164:21/PTB/Import/";//New BizPac file FTP : woranai 2008/05/26
        //public static string FTP_URL = @"ftp://bizpacftp:password@172.30.2.200:20125/PTB/Import/";
    }
}
