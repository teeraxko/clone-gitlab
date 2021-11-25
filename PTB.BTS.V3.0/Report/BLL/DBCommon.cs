using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SystemFramework.AppConfig;

namespace Report.BLL {
    internal class DBCommon {
        public static SqlConnection GetDataConnection() {
            StringBuilder stringBuilder = new StringBuilder("Data Source=");
            stringBuilder.Append(ApplicationProfile.SERVER_NAME);
            stringBuilder.Append("; Initial Catalog=");
            stringBuilder.Append(ApplicationProfile.DB_NAME);
            stringBuilder.Append("; User ID=");
            stringBuilder.Append(ApplicationProfile.DB_USER_NAME);
            stringBuilder.Append("; Password=");
            stringBuilder.Append(ApplicationProfile.DB_USER_PASSWORD);
            return new SqlConnection(stringBuilder.ToString());
        }

    }
}
