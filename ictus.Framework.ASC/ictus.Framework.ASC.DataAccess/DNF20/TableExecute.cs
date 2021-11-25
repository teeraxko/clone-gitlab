using System;
using System.Data;
using System.Data.SqlClient;

namespace ictus.Framework.ASC.DataAccess.DNF20
{
    public static class TableExecute
    {
        private static SqlConnection connection;
        private static SqlTransaction transaction;

        public static void Open()
        {
            if (connection == null)
            {
                connection = ConfigAccess.GetConnection();
            }
            connection.Open();
            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public static void Commit()
        {
            transaction.Commit();
            connection.Close();
        }

        public static void Rollback()
        {
            transaction.Rollback();
            connection.Close();
        }
    }
}
