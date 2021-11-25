using System;
using System.Data.SqlClient;

using ictus.Common.Entity;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacDB
{
    public interface IBizPacConnectDB : DataAccess.CommonDB.ITableName
    {
        string RefNoFieldName { get; }
        string RefDateFiledName { get; }
        string GetSQLSelectBP { get; }
        string GetSpecificSelectConditionBP { get; }
        string GetKeyConditionBP(IBTS2BizPacHeader value);
        string GetBaseConditionBP(Company company);
        string GetOrderByBP { get;}
        bool FillIBPList(BTS2BizPacList listBP, Company company, SqlDataReader dataReader);
    }
}
