using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SystemFramework.AppConfig;

using ictus.Common.Entity;
using ictus.Framework.ASC.Entity.DNF20;

namespace DataAccess.CommonDB
{
    public abstract class PISDataAccessBase<T, U> : DataAccessBase
        where T : EntityBase, new()
        where U : ictus.Common.Entity.Company
    {
        #region Declaration

        protected Company currentCompany;

        #endregion


        #region Constructors 

        public PISDataAccessBase(){ }
        public PISDataAccessBase(Company company) 
        {
            this.currentCompany = company;
        }

        #endregion

        #region Properties

        protected abstract string TableName { get; }
        protected abstract string[] KeyFields { get; }
        protected abstract string[] OtherFields { get; }

        #endregion

        protected T GetEntity(SqlCommand command)
        {
            T result = null;

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);
            try
            {
                if (dataReader.Read())
                {
                    result = new T();
                    FillDetail(result, dataReader);
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            {
                if (command.Connection.State != ConnectionState.Closed)
                {
                    command.Connection.Close();
                }

                dataReader.Close();
                tableAccess.CloseDataReader();
            }
            return result;
        }

        protected List<T> FillList(SqlCommand command)
        {
            List<T> result = new List<T>();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);
            try
            {
                while (dataReader.Read())
                {
                    T entity = new T();
                    FillDetail(entity, dataReader);
                    result.Add(entity);
                }
            }
            catch (IndexOutOfRangeException ein)
            { 
                throw ein; 
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Closed)
                {
                    command.Connection.Close();
                }

                dataReader.Close();
                tableAccess.CloseDataReader();
            }
            return result;
        }

        protected bool FillList(List<T> list, SqlCommand command)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);
            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    T entity = new T();
                    FillDetail(entity, dataReader);
                    list.Add(entity);
                }
            }
            catch (IndexOutOfRangeException ein)
            { 
                throw ein; 
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Closed)
                {
                    command.Connection.Close();
                }

                dataReader.Close();
                tableAccess.CloseDataReader();
            }
            return result;
        }

        public T GetByID(T item, U company)
        {
            T result = GetEntity(this.GetSelectByIDCommand(item, company));
            return result;
        }

        public virtual void Insert(T entity, U company)
        {
            tableAccess.ExecuteSQL(GetInsertCommand(entity, company));
        }

        public void Update(T entity, U company)
        {
            tableAccess.ExecuteSQL(GetUpdateCommand(entity, company));
        }

        public void Delete(T entity, U company)
        {
            tableAccess.ExecuteSQL(GetDeleteCommand(entity, company));
        }

        protected virtual SqlCommand GetInsertCommand(T entity, U company)
        {
            SqlCommand result = tableAccess.CreateCommand(GetInsertCommandText());
            result.CommandType = CommandType.Text;
            AddKeyParameters(result.Parameters, entity, company);
            AddParameters(result.Parameters, entity);
            AddProcessParameters(result.Parameters);
            return result;
        }

        protected virtual SqlCommand GetUpdateCommand(T entity, U company)
        {
            SqlCommand result = tableAccess.CreateCommand(GetUpdateCommandText());
            result.CommandType = CommandType.Text;
            AddKeyParameters(result.Parameters, entity, company);
            AddParameters(result.Parameters, entity);
            AddProcessParameters(result.Parameters);
            return result;
        }

        protected virtual SqlCommand GetDeleteCommand(T entity, U company)
        {
            SqlCommand result = tableAccess.CreateCommand(GetDeleteCommandText());
            result.CommandType = CommandType.Text;
            AddKeyParameters(result.Parameters, entity, company);
            return result;
        }

        protected virtual SqlCommand GetSelectByIDCommand(T entity, U company)
        {
            SqlCommand result = tableAccess.CreateCommand(GetSelectByIDCommandText());
            result.CommandType = CommandType.Text;
            AddKeyParameters(result.Parameters, entity, company);
            return result;
        }

        protected virtual void AddProcessParameters(SqlParameterCollection parameters)
        {
            parameters.Add(tableAccess.CreateParameter("@Process_User", UserProfile.UserID));
        }

        protected abstract void AddKeyParameters(SqlParameterCollection parameters, T entity, U company);

        protected abstract void AddParameters(SqlParameterCollection parameters, T entity);

        protected abstract void FillDetail(T entity, SqlDataReader dataReader);

        protected virtual string GetInsertCommandText()
        {
            string strCommand = "INSERT INTO {0}({1}Process_User)VALUES({2}@Process_User)";
            string listField = string.Empty;
            string listParameter = string.Empty;
            foreach (string str in KeyFields)
            {
                listField = string.Concat(listField, str, ",");
                listParameter = string.Concat(listParameter, "@", str, ",");
            }

            foreach (string str in OtherFields)
            {
                listField = string.Concat(listField, str, ",");
                listParameter = string.Concat(listParameter, "@", str, ",");
            }

            return string.Format(strCommand, TableName, listField, listParameter);
        }

        protected virtual string GetUpdateCommandText()
        {
            string strCommand = "UPDATE {0} SET {1}Process_User = @Process_User, Process_Date = GETDATE() WHERE {2}1=1";

            string listField = string.Empty;
            string listKey = string.Empty;

            foreach (string str in OtherFields)
            {
                listField = string.Concat(listField, str, "= @", str, ", ");
            }

            foreach (string str in KeyFields)
            {
                listKey = string.Concat(listKey, str, "= @", str, " AND ");
            }

            return string.Format(strCommand, TableName, listField, listKey);
        }

        protected virtual string GetDeleteCommandText()
        {
            string strCommand = "DELETE FROM {0} WHERE {1}1=1";
            string listKey = string.Empty;

            foreach (string str in KeyFields)
            {
                listKey = string.Concat(listKey, str, "= @", str, " AND ");
            }

            return string.Format(strCommand, TableName, listKey);
        }

        protected virtual string GetSelectByIDCommandText()
        {
            string strCommand = "SELECT * FROM {0} WHERE {1} 1=1";
            string lst = string.Empty;

            foreach (string str in KeyFields)
            {
                lst = string.Concat(lst, string.Format("{0} = @{1} AND ", str, str));
            }

            string result = string.Format(strCommand, TableName, lst);
            return result;
        }

        #region IDisposable Members

        protected override void Dispose(bool disposing)
        {
            // Set large fields to null.
            this.currentCompany = null;

            // Call Dispose on base class.
            base.Dispose(disposing);
        }

        #endregion
    }
}
