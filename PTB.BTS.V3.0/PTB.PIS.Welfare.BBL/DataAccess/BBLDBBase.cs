using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ictus.Common.Entity;
using ictus.PIS.Welfare.DataAccess;
using SystemFramework.AppConfig;

namespace PTB.PIS.Welfare.BBL.DataAccess {
    internal abstract class BBLDBBase {
        protected string tablename;
        protected string connectDateFieldName;
        protected IDbConnection connection;
        protected DateTime connectDate;
        protected IDbTransaction transaction;
        protected string BulidStringUpdate() {
            StringBuilder sb = new StringBuilder();
            sb.Append(" UPDATE ");
            sb.Append(string.Format(" {0} SET ", this.tablename));
            sb.Append(string.Format(" {0} = @connectDate, ",this.connectDateFieldName));
            sb.Append(" Process_Date = @Process_Date, ");
            sb.Append(" Process_User = @Process_User ");
            sb.Append(this.GetCriteriaKey());
            return sb.ToString();
        }

        protected abstract string GetCriteriaKey();

        public abstract bool UpdateData();
        
        protected List<IDbDataParameter> GetProcessParameters(List<IDbDataParameter> paras) {
            if (paras == null) paras = new List<IDbDataParameter>();

            IDbDataParameter pProcess_Date = DataBase.GetDbParameter();
            pProcess_Date.ParameterName = "@Process_Date";
            pProcess_Date.Value = DateTime.Now;
            paras.Add(pProcess_Date);

            IDbDataParameter pProcess_User = DataBase.GetDbParameter();
            pProcess_User.ParameterName = "@Process_User";
            pProcess_User.Value = UserProfile.UserID;
            paras.Add(pProcess_User);

            return paras;
        }

        protected List<IDbDataParameter> GetBBLParameters(List<IDbDataParameter> paras) {
            if (paras == null) paras = new List<IDbDataParameter>();

            IDbDataParameter pConnectDate = DataBase.GetDbParameter();
            pConnectDate.ParameterName = "@connectDate";
            pConnectDate.Value = this.connectDate;
            paras.Add(pConnectDate);

            return paras;
        }

 
    }
}