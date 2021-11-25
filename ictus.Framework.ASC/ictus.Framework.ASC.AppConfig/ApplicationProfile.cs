using System;

namespace ictus.Framework.ASC.AppConfig
{
    public static class ApplicationProfile
    {        

        /************* Prod. Config ***************/
        //public static string SERVER_NAME = "PTBSVR01";
        //public static string DB_NAME = "BTSDB";
        //public static string DB_USER_NAME = "sa";
        //public static string DB_USER_PASSWORD = "PTBXXX";

        //public static string REPORT_PATH = @"\\PTBSVR01\BTS\Report\";
        //public static string PHOTO_PATH = @"\\PTBSVR01\BTS\PHOTO\";
        //public static string FTP_URL = @"ftp://bizpacftp:password@172.30.2.164:21/PTB/Import/";//New BizPac file FTP : woranai 2008/05/26

        /************* End Prod. Config ***************/

        /************* UAT Config ***************/
        //public static string SERVER_NAME = "172.30.2.207"; //PDBAPP01-TEST
        //public static string DB_NAME = "BTSDB_UAT";
        //public static string DB_USER_NAME = "sa";
        //public static string DB_USER_PASSWORD = "pdbdevadmin";
        //public static string REPORT_PATH = @"\\172.30.2.206\BTSReport\";
        //public static string PHOTO_PATH = @"\\172.30.2.206\BTS\Photo\";
        //public static string FTP_URL = @"ftp://bizpacftp:password@172.30.2.164:21/PTB/TestImport/";

        /************* End UAT Config ***************/

        /************* Dev Config ***************/
        public static string SERVER_NAME = "172.30.2.207"; //PDBAPP01-TEST
        public static string DB_NAME = "BTSDB_DEV";
        public static string DB_USER_NAME = "sa";
        public static string DB_USER_PASSWORD = "pdbdevadmin";
        public static string REPORT_PATH = @"\\172.30.2.206\BTSReport\";
        public static string PHOTO_PATH = @"\\172.30.2.206\BTS\Photo\";
        public static string FTP_URL = @"ftp://bizpacftp:password@172.30.2.164:21/PTB/TestImport/";

        /************* End Dev. Config ***************/
        
    }
}
