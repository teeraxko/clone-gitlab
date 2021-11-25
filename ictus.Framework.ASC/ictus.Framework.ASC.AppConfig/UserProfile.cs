using System;

namespace ictus.Framework.ASC.AppConfig
{
    public static class UserProfile
    {
        private static string userID = "ASC";
        public static string UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }
    }
}
