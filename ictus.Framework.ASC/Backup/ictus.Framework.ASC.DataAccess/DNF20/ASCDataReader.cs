using System;
using System.Data;
using System.Data.SqlClient;

namespace ictus.Framework.ASC.DataAccess.DNF20
{
    public class ASCDataReader : IDataReader
    {
        private SqlDataReader dataReader;
        public ASCDataReader(IDataReader value)
        {
            dataReader = (SqlDataReader)value;
        }

        #region IDataReader Members
        void IDataReader.Close()
        {
            dataReader.Close();
        }

        int IDataReader.Depth
        {
            get { return dataReader.Depth; }
        }

        DataTable IDataReader.GetSchemaTable()
        {
            return dataReader.GetSchemaTable();
        }

        bool IDataReader.IsClosed
        {
            get { return dataReader.IsClosed; }
        }

        bool IDataReader.NextResult()
        {
            return dataReader.NextResult();
        }

        bool IDataReader.Read()
        {
            return dataReader.Read();
        }

        int IDataReader.RecordsAffected
        {
            get { return dataReader.RecordsAffected; }
        }
        #endregion

        #region IDisposable Members
        void IDisposable.Dispose()
        {
            dataReader.Dispose();
        }
        #endregion

        #region IDataRecord Members
        int IDataRecord.FieldCount
        {
            get { return dataReader.FieldCount; }
        }

        bool IDataRecord.GetBoolean(int i)
        {
            return dataReader.GetBoolean(i);
        }

        byte IDataRecord.GetByte(int i)
        {
            return dataReader.GetByte(i);
        }

        long IDataRecord.GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return dataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        char IDataRecord.GetChar(int i)
        {
            return dataReader.GetChar(i);
        }

        long IDataRecord.GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return dataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        IDataReader IDataRecord.GetData(int i)
        {
            return dataReader.GetData(i);
        }

        string IDataRecord.GetDataTypeName(int i)
        {
            return dataReader.GetDataTypeName(i);
        }

        DateTime IDataRecord.GetDateTime(int i)
        {
            return dataReader.GetDateTime(i);
        }

        decimal IDataRecord.GetDecimal(int i)
        {
            return dataReader.GetDecimal(i);
        }

        double IDataRecord.GetDouble(int i)
        {
            return dataReader.GetDouble(i);
        }

        Type IDataRecord.GetFieldType(int i)
        {
            return dataReader.GetFieldType(i);
        }

        float IDataRecord.GetFloat(int i)
        {
            return dataReader.GetFloat(i);
        }

        Guid IDataRecord.GetGuid(int i)
        {
            return dataReader.GetGuid(i);
        }

        short IDataRecord.GetInt16(int i)
        {
            return dataReader.GetInt16(i);
        }

        int IDataRecord.GetInt32(int i)
        {
            return dataReader.GetInt32(i);
        }

        long IDataRecord.GetInt64(int i)
        {
            return dataReader.GetInt64(i);
        }

        string IDataRecord.GetName(int i)
        {
            return dataReader.GetName(i);
        }

        int IDataRecord.GetOrdinal(string name)
        {
            return dataReader.GetOrdinal(name);
        }

        string IDataRecord.GetString(int i)
        {
            return dataReader.GetString(i);
        }

        object IDataRecord.GetValue(int i)
        {
            return dataReader.GetValue(i);
        }

        int IDataRecord.GetValues(object[] values)
        {
            return dataReader.GetValues(values);
        }

        bool IDataRecord.IsDBNull(int i)
        {
            return dataReader.IsDBNull(i);
        }

        object IDataRecord.this[string name]
        {
            get { return dataReader[name]; }
        }

        object IDataRecord.this[int i]
        {
            get { return dataReader[i]; }
        }
        #endregion
    }
}
