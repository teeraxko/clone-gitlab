using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Presentation.CommonGUI
{
    public class DBCommon
    {
        public static SqlConnection GetDataConnection()
        {
            StringBuilder stringBuilder = new StringBuilder("Data Source=");
            stringBuilder.Append(SystemFramework.AppConfig.ApplicationProfile.SERVER_NAME);
            stringBuilder.Append("; Initial Catalog=");
            stringBuilder.Append(SystemFramework.AppConfig.ApplicationProfile.DB_NAME);
            stringBuilder.Append("; User ID=");
            stringBuilder.Append(SystemFramework.AppConfig.ApplicationProfile.DB_USER_NAME);
            stringBuilder.Append("; Password=");
            stringBuilder.Append(SystemFramework.AppConfig.ApplicationProfile.DB_USER_PASSWORD);
            return new SqlConnection(stringBuilder.ToString());
        }

    }
}
