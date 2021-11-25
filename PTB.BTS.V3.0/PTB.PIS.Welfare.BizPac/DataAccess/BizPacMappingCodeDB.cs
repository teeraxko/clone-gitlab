using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PTB.PIS.Welfare.BizPac.BizPacEntities;
using ictus.PIS.Welfare.DataAccess;

namespace PTB.PIS.Welfare.BizPac.DataAccess {
    internal class BizPacMappingCodeDB {

        public static string GetBizSectionByCompDeptSec(string compCode, string deptCode, string secCode) {
            StringBuilder str = new StringBuilder();
            str.Append(" SELECT BizPac_Department_Code ");
            str.Append(" FROM Section ");
            str.Append(" WHERE ");
            str.Append(" Company_Code = @Company_Code AND ");
            str.Append(" Department_Code = @Department_Code AND ");
            str.Append(" Section_Code = @Section_Code");
            string strSQL = str.ToString();
            IDbCommand cmd = DataBase.GetDbCommand();
            cmd.CommandText = str.ToString();

            foreach (IDbDataParameter p in BizPacMappingCodeDB.GetCompDeptSecParameters(null, compCode, deptCode, secCode)) cmd.Parameters.Add(p);
            try {
                if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value)
                    return string.Empty;
                else
                    return (string)obj;
            } catch (Exception excp) {
                throw excp;
            } finally {
                cmd.Connection.Close();
            }

        }

        public static List<BizSectionMap> FillAll(string compCode) {

            List<BizSectionMap> items = new List<BizSectionMap>();

            StringBuilder str = new StringBuilder();
            str.Append(" SELECT Department_Code,Section_Code,BizPac_Department_Code ");
            str.Append(" FROM Section ");
            str.Append(" WHERE ");
            str.Append(" Company_Code = @Company_Code ");
            string strSQL = str.ToString();
            IDbCommand cmd = DataBase.GetDbCommand();
            cmd.CommandText = str.ToString();

            IDbDataParameter pCompCode = DataBase.GetDbParameter();
            pCompCode.ParameterName = "@Company_Code";
            pCompCode.Value = compCode;

            cmd.Parameters.Add(pCompCode);
            try {
                if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
                IDataReader dr = cmd.ExecuteReader();
                BizSectionMap item = null;
                while (dr.Read()) {
                    item = new BizSectionMap(dr.GetString(0).Trim(), dr.GetString(1).Trim(), dr.GetString(2).Trim());
                    items.Add(item);
                }
                return items;
            } catch (Exception excp) {
                throw excp;
            } finally {
                cmd.Connection.Close();
            }

        }

        private static List<IDbDataParameter> GetCompDeptSecParameters(List<IDbDataParameter> paras, string compCode, string deptCode, string secCode) {

            if (paras == null) paras = new List<IDbDataParameter>();

            IDbDataParameter pCompCode = DataBase.GetDbParameter();
            pCompCode.ParameterName = "@Company_Code";
            pCompCode.Value = compCode;
            paras.Add(pCompCode);

            IDbDataParameter pDeptCode = DataBase.GetDbParameter();
            pDeptCode.ParameterName = "@Department_Code";
            pDeptCode.Value = deptCode;
            paras.Add(pDeptCode);

            IDbDataParameter pSecCode = DataBase.GetDbParameter();
            pSecCode.ParameterName = "@Section_Code";
            pSecCode.Value = secCode;
            paras.Add(pSecCode);

            return paras;
        }

    
    }
}
