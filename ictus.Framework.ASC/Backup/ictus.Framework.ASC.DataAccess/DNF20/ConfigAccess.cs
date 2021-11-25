using System;
using System.Text;
using System.Data.SqlClient;

using ictus.Framework.ASC.AppConfig;

namespace ictus.Framework.ASC.DataAccess
{
    public static class ConfigAccess
    {
        private static string connectionString = "";
        private static string ConnectionString
        {
            get
            {
                if (connectionString == "")
                {
                    StringBuilder stringBuilder = new StringBuilder("Data Source=");
                    stringBuilder.Append(ApplicationProfile.SERVER_NAME);
                    stringBuilder.Append("; Initial Catalog=");
                    stringBuilder.Append(ApplicationProfile.DB_NAME);
                    stringBuilder.Append("; User ID=");
                    stringBuilder.Append(ApplicationProfile.DB_USER_NAME);
                    stringBuilder.Append("; Password=");
                    stringBuilder.Append(ApplicationProfile.DB_USER_PASSWORD);
                    connectionString = stringBuilder.ToString();
                    stringBuilder = null;
                }

                return connectionString;
            }
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }
    }
}
