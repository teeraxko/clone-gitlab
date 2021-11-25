using System;

namespace SystemFramework.AppConfig
{
	public static class ApplicationProfile
	{
        public static string Version = "3.0";
        //TestEnvironment
        //public static string Version = "TEST";

        public static string DB_NAME
        {
            get { return ictus.Framework.ASC.AppConfig.ApplicationProfile.DB_NAME; }
        }

        public static string DB_USER_NAME
        {
            get { return ictus.Framework.ASC.AppConfig.ApplicationProfile.DB_USER_NAME; }
            //get { return "sa"; }
        }

        public static string DB_USER_PASSWORD
        {
            get { return ictus.Framework.ASC.AppConfig.ApplicationProfile.DB_USER_PASSWORD; }
            //get { return "p@ssw0rd"; }
        }

        public static string SERVER_NAME
        {
            get { return ictus.Framework.ASC.AppConfig.ApplicationProfile.SERVER_NAME; }
            //get { return "LOCALHOST"; }
        }

        public static string REPORT_PATH
        {
            get { return ictus.Framework.ASC.AppConfig.ApplicationProfile.REPORT_PATH; }
        }

        public static string PHOTO_PATH
        {
            get { return ictus.Framework.ASC.AppConfig.ApplicationProfile.PHOTO_PATH; }
        }
	}
}