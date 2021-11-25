using System;
using System.Collections.Generic;
using System.Text;

namespace SystemFramework.AppConfig
{
    public static class ApplicationVersion
    {
        //public static string Version = "1.305";
        public static string Version
        {
            get { return ApplicationProfile.Version; }
        }
    }
}
