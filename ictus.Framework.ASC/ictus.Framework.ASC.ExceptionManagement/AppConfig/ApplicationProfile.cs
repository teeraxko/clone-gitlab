using System;

namespace ictus.Framework.ASC.ExceptionManagement.AppConfig
{
	public static class ApplicationProfile
	{
        public static string Version = "1.305";

        public static string DB_NAME
        {
            get { return ictus.Framework.ASC.AppConfig.ApplicationProfile.DB_NAME; }
        }

        public static string DB_USER_NAME
        {
            get { return ictus.Framework.ASC.AppConfig.ApplicationProfile.DB_USER_NAME; }
        }

        public static string DB_USER_PASSWORD
        {
            get { return ictus.Framework.ASC.AppConfig.ApplicationProfile.DB_USER_PASSWORD; }
        }

        public static string SERVER_NAME
        {
            get { return ictus.Framework.ASC.AppConfig.ApplicationProfile.SERVER_NAME; }
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