using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using SystemFramework.AppConfig;

namespace DataAccess.CommonDB
{
    public class TableAccess
    {
        #region - Private -
        private SqlConnection sqlConnection;
        private SqlDataReader dataReader;
        #endregion
        #region Property
        private SqlTransaction transaction;
        public SqlTransaction Transaction
        {
            get
            {
                return transaction;
            }
            set
            {
                transaction = value;
            }
        }
        #endregion

        #region Constructor
        public TableAccess()
        {
            StringBuilder stringBuilder = new StringBuilder("Data Source=");
            stringBuilder.Append(ApplicationProfile.SERVER_NAME);
            stringBuilder.Append("; Initial Catalog=");
            stringBuilder.Append(ApplicationProfile.DB_NAME);
            stringBuilder.Append("; User ID=");
            stringBuilder.Append(ApplicationProfile.DB_USER_NAME);
            stringBuilder.Append("; Password=");
            stringBuilder.Append(ApplicationProfile.DB_USER_PASSWORD);
            sqlConnection = new SqlConnection(stringBuilder.ToString());
        }
        #endregion

        #region Private Method

        private SqlDataReader internalExecuteDataReader(string strSQL, CommandType commandType)
        {
            SqlCommand command = new SqlCommand();
            try
            {
                OpenConnection();

                command.Connection = sqlConnection;
                command.CommandText = strSQL;
                command.CommandType = commandType;

                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);

                return dataReader;
            }
            catch (InvalidOperationException einv)
            {
                throw einv;
            }
            catch (SqlException eSQL)
            {
                throw eSQL;
            }
            finally
            {
                command = null;
            }
        }

        private SqlDataReader internalExecuteDataReader(SqlCommand command)
        {
            try
            {
                OpenConnection();
                command.Connection = sqlConnection;
                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return dataReader;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                throw invalidOperationException;
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            finally
            {
                command = null;
            }
        }

        private int internalExecuteSQL(string strSQL)
        {
            SqlCommand command = new SqlCommand();
            try
            {
                OpenConnection();
                command.CommandText = strSQL;
                command.Connection = sqlConnection;
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;
                return command.ExecuteNonQuery();
            }
            catch (InvalidOperationException einv)
            {
                throw einv;
            }
            catch (SqlException eSQL)
            {
                throw eSQL;
            }
            finally
            {
                command = null;
            }
        }

        private int internalExecuteSQL(SqlCommand command)
        {
            try
            {
                OpenConnection();
                command.Connection = sqlConnection;
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;
                return command.ExecuteNonQuery();
            }
            catch (InvalidOperationException einv)
            {
                throw einv;
            }
            catch (SqlException eSQL)
            {
                throw eSQL;
            }
            finally
            {
            }
        }

        private object internalExecuteScalar(string strSQL)
        {
            SqlCommand command = new SqlCommand();
            try
            {
                OpenConnection();
                command.CommandText = strSQL;
                command.Transaction = transaction;
                command.Connection = sqlConnection;
                object result = command.ExecuteScalar();
                return result;
            }
            catch (InvalidOperationException einv)
            {
                throw einv;
            }
            catch (SqlException eSQL)
            {
                throw eSQL;
            }
            finally
            {
                command = null;
            }
        }

        private object internalExecuteScalar(SqlCommand command)
        {
            try
            {
                OpenConnection();
                command.Connection = sqlConnection;
                command.Transaction = transaction;
                //command.CommandType = CommandType.Text;
                return command.ExecuteScalar();
            }
            catch (InvalidOperationException invalidOperationException)
            {
                throw invalidOperationException;
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            finally
            {
            }
        }

        private SqlDataReader internalExecuteReaderStoredProcedure(SqlCommand command)
        {
            try
            {
                OpenConnection();
                command.Connection = sqlConnection;
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);

                return dataReader;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                throw invalidOperationException;
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
        }

        private int internalExecuteNonQueryStoredProcedure(SqlCommand command)
        {
            try
            {
                OpenConnection();
                command.Connection = sqlConnection;
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                return command.ExecuteNonQuery();
            }
            catch (InvalidOperationException invalidOperationException)
            {
                throw invalidOperationException;
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            finally
            { 

            }
        }

        private object internalExecuteScalarStoredProcedure(SqlCommand command)
        {
            try
            {
                OpenConnection();
                command.Connection = sqlConnection;
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                return command.ExecuteScalar();
            }
            catch (InvalidOperationException invalidOperationException)
            {
                throw invalidOperationException;
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
        }
        #endregion

        #region Public Method
        public void OpenTransaction()
        {
            OpenConnection();
            transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void CommitTransaction()
        {
            transaction.Commit();
            transaction = null;
        }

        public void RollbackTransaction()
        {
            transaction.Rollback();
            transaction = null;
        }

        public void OpenConnection()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        public void CloseDataReader()
        {
            if (dataReader != null)
            {
                dataReader.Close();
            }
        }

        public SqlDataReader ExecuteDataReader(string strSQL)
        {
            return internalExecuteDataReader(strSQL, CommandType.Text);
        }

        public SqlDataReader ExecuteDataReader(SqlCommand command)
        {
            return internalExecuteDataReader(command);
        }

        public int ExecuteSQL(string strSQL)
        {
            return internalExecuteSQL(strSQL);
        }

        public int ExecuteSQL(SqlCommand command)
        {
            return internalExecuteSQL(command);
        }

        public object ExecuteScalar(string strSQL)
        {
            return internalExecuteScalar(strSQL);
        }

        public int ExecuteStoredProcedure(SqlCommand command)
        {
            return internalExecuteNonQueryStoredProcedure(command);
        }

        public object ExecuteScalarStoredProcedure(SqlCommand command)
        {
            return internalExecuteScalarStoredProcedure(command);
        }

        public SqlCommand CreateCommand(string strSQL)
        {
            return new SqlCommand(strSQL);
        }

        public SqlParameter CreateParameter(string parameterName, object value)
        {
            return new SqlParameter(parameterName, value);
        }

        public SqlDataAdapter CreateDataAdpter(SqlCommand command)
        {
            return new SqlDataAdapter(command.CommandText, command.Connection);
        }
        #endregion
    }
}