using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ictus.Common.Entity;
using ictus.PIS.Welfare.DataAccess;
using PTB.PIS.Welfare.BizPac.BizPacEntities;
using SystemFramework.AppConfig;

namespace PTB.PIS.Welfare.BizPac.DataAccess
{
    internal abstract class BizPacDBBase
    {
        protected string tablename;
        protected IDbConnection connection;
        protected string refNo;
        protected DateTime connectDate;
        protected IDbTransaction transaction;
        protected string BulidStringUpdate()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" UPDATE ");
            sb.Append(string.Format(" {0} SET ", this.tablename));
            sb.Append(" BizPac_Reference_No = @BizPac_Reference_No, ");
            sb.Append(" BizPac_Connection_Date = @BizPac_Connection_Date, ");
            sb.Append(" Process_Date = @Process_Date, ");
            sb.Append(" Process_User = @Process_User ");
            sb.Append(this.GetCriteriaKey());
            return sb.ToString();
        }

        protected string BulidStringCancel()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" UPDATE ");
            sb.Append(string.Format(" {0} SET ", this.tablename));
            sb.Append(" BizPac_Reference_No = '', ");
            sb.Append(" BizPac_Connection_Date = NULL, ");
            sb.Append(" Process_Date = @Process_Date, ");
            sb.Append(" Process_User = @Process_User ");
            sb.Append(" WHERE ");
            sb.Append(" Company_Code = @Company_Code AND ");
            sb.Append(" BizPac_Reference_No = @BizPac_Reference_No AND ");
            sb.Append(" BizPac_Connection_Date = @BizPac_Connection_Date ");
            //sb.Append(this.GetCriteriaKey());
            return sb.ToString();
        }

        protected abstract string GetCriteriaKey();
        public abstract bool UpdateData();
        protected List<IDbDataParameter> GetProcessParameters(List<IDbDataParameter> paras)
        {
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

        protected List<IDbDataParameter> GetBizParameters(List<IDbDataParameter> paras)
        {
            if (paras == null) paras = new List<IDbDataParameter>();

            IDbDataParameter prefNo = DataBase.GetDbParameter();
            prefNo.ParameterName = "@BizPac_Reference_No";
            prefNo.Value = this.refNo;
            paras.Add(prefNo);

            IDbDataParameter pConnectDate = DataBase.GetDbParameter();
            pConnectDate.ParameterName = "@BizPac_Connection_Date";
            pConnectDate.Value = this.connectDate;
            paras.Add(pConnectDate);

            return paras;
        }

        public static List<IDbDataParameter> GetCompanyFromToDateParameters(List<IDbDataParameter> paras, Company comapny, DateTime fromDate, DateTime toDate)
        {

            if (paras == null) paras = new List<IDbDataParameter>();

            IDbDataParameter pCompanyCode = DataBase.GetDbParameter();
            pCompanyCode.ParameterName = "@Company_Code";
            pCompanyCode.Value = comapny.CompanyCode;
            paras.Add(pCompanyCode);

            IDbDataParameter pFromDate = DataBase.GetDbParameter();
            pFromDate.ParameterName = "@FromDate";
            pFromDate.Value = fromDate;
            paras.Add(pFromDate);

            IDbDataParameter pToDate = DataBase.GetDbParameter();
            pToDate.ParameterName = "@ToDate";
            pToDate.Value = toDate;
            paras.Add(pToDate);



            return paras;
        }

        protected List<IDbDataParameter> GetCancelParameters(List<IDbDataParameter> paras, Company comp, ConnectBizPacDetail connectDetail)
        {
            if (paras == null) paras = new List<IDbDataParameter>();

            IDbDataParameter pCompanyCode = DataBase.GetDbParameter();
            pCompanyCode.ParameterName = "@Company_Code";
            pCompanyCode.Value = comp.CompanyCode;
            paras.Add(pCompanyCode);

            IDbDataParameter pRefNo = DataBase.GetDbParameter();
            pRefNo.ParameterName = "@BizPac_Reference_No";
            pRefNo.Value = connectDetail.RefNo;
            paras.Add(pRefNo);

            IDbDataParameter pConnectDateTime = DataBase.GetDbParameter();
            pConnectDateTime.ParameterName = "@BizPac_Connection_Date";
            pConnectDateTime.Value = connectDetail.ConnectDateTime;
            paras.Add(pConnectDateTime);

            paras = this.GetProcessParameters(paras);

            return paras;
        }

        private IDbCommand CommandCancel(Company comp, ConnectBizPacDetail connectDetail)
        {
            IDbCommand command = DataBase.GetDbCommand(this.connection);
            command.CommandText = this.BulidStringCancel();
            foreach (IDbDataParameter para in this.GetCancelParameters(null, comp, connectDetail)) command.Parameters.Add(para);
            return command;
        }

        //[Kriangkrai A.] 18/02/2019 add this to set sql command for cancel transfer
        protected string BulidStringCancelSAP(List<ConnectBizPacDetail> connectDetail)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" UPDATE [TR_SAP_Transaction] ");
            sb.Append("SET IsDelete = 1, ");
            sb.Append("Cancel_Date = CURRENT_TIMESTAMP, ");
            sb.Append("Cancel_User = '");
            sb.Append(UserProfile.UserID.ToString().Trim());
            sb.Append("' WHERE Reference_No IN (");

            for (int i = 0; i < connectDetail.Count; i++ )
            {
                ConnectBizPacDetail detail = connectDetail[i];
                sb.Append("'");
                sb.Append(detail.RefNo);
                sb.Append("'");

                if (i < (connectDetail.Count - 1))
                {
                    sb.Append(",");
                }
            }

            sb.Append(")");

            return sb.ToString();
        }

        private IDbCommand CommandCancelSAP(List<ConnectBizPacDetail> connectDetail)
        {
            IDbCommand command = DataBase.GetDbCommand(this.connection);
            command.CommandText = this.BulidStringCancelSAP(connectDetail);

            return command;
        }

        // End change

        //Kriangkrai A. modify this to set get sql for cancel transfer
        public bool CancelConnect(Company comp, List<ConnectBizPacDetail> connectDetails)
        {
            bool result = false;
            try
            {
                result = true;
                this.connection.Open();
                this.transaction = this.connection.BeginTransaction();
                foreach (ConnectBizPacDetail connectDetail in connectDetails)
                {
                    IDbCommand command = this.CommandCancel(comp, connectDetail);
                    command.Transaction = this.transaction;

                    result = (result && (command.ExecuteNonQuery() > 0));
                }

                //Kriangkrai A.
                IDbCommand deleteSAPCommand = this.CommandCancelSAP(connectDetails);
                deleteSAPCommand.Transaction = this.transaction;

                result = (result && (deleteSAPCommand.ExecuteNonQuery() > 0));

                this.transaction.Commit();
                // // Kriangkrai A.
                //return result;
                result = true;
            }
            catch (Exception ex)
            {
                this.transaction.Rollback();
                result = false; // Kriangkrai A.
                throw ex;
            }
            finally
            {
                this.connection.Close();
            }

            return result;  // Kriangkrai A.
        }

        public List<ConnectBizPacDetail> GetConnectHistoryList(Company company, DateTime fromDate, DateTime toDate)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" SELECT BizPac_Reference_No,MAX(BizPac_Connection_Date)ConnectDate ");
            str.Append(string.Format(" FROM {0} ", this.tablename));
            str.Append(" WHERE ");
            str.Append(" Company_Code = @Company_Code AND ");
            str.Append(" (BizPac_Connection_Date BETWEEN @FromDate AND @ToDate) ");
            str.Append(" GROUP BY BizPac_Reference_No ");
            str.Append(" ORDER BY 1,2 ");
            IDbCommand cmd = DataBase.GetDbCommand();
            string strSQL = str.ToString();
            cmd.CommandText = strSQL;
            foreach (IDbDataParameter p in BizPacDBBase.GetCompanyFromToDateParameters(null, company, fromDate, toDate)) cmd.Parameters.Add(p);
            try
            {
                if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
                IDataReader dr = cmd.ExecuteReader();
                List<ConnectBizPacDetail> details = this.BuildConnectBizPacDetailList(dr);
                return details;
            }
            catch (Exception excp)
            {
                throw excp;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public List<ConnectBizPacDetail> GetConnectHistoryList(Company company, string refNo)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" SELECT BizPac_Reference_No,MAX(BizPac_Connection_Date)ConnectDate ");
            str.Append(string.Format(" FROM {0} ", this.tablename));
            str.Append(" WHERE ");
            str.Append(" Company_Code = @Company_Code AND ");
            str.Append(" BizPac_Reference_No LIKE @BizPac_Reference_No AND ");
            str.Append(" not(BizPac_Connection_Date is null) ");
            str.Append(" GROUP BY BizPac_Reference_No ");
            str.Append(" ORDER BY 1,2 ");

            IDbCommand cmd = DataBase.GetDbCommand();
            string strSQL = str.ToString();
            cmd.CommandText = strSQL;

            IDbDataParameter pCompanyCode = DataBase.GetDbParameter();
            pCompanyCode.ParameterName = "@Company_Code";
            pCompanyCode.Value = company.CompanyCode;
            cmd.Parameters.Add(pCompanyCode);

            IDbDataParameter pRefNo = DataBase.GetDbParameter();
            pRefNo.ParameterName = "@BizPac_Reference_No";
            pRefNo.Value = string.Format("%{0}%", refNo);
            cmd.Parameters.Add(pRefNo);

            try
            {
                if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
                IDataReader dr = cmd.ExecuteReader();
                List<ConnectBizPacDetail> details = this.BuildConnectBizPacDetailList(dr);
                return details;
            }
            catch (Exception excp)
            {
                throw excp;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }


        private List<ConnectBizPacDetail> BuildConnectBizPacDetailList(IDataReader dr)
        {
            try
            {
                List<ConnectBizPacDetail> details = new List<ConnectBizPacDetail>();
                while (dr.Read())
                {
                    ConnectBizPacDetail detail = new ConnectBizPacDetail();
                    detail.RefNo = dr.GetString(0);
                    detail.ConnectDateTime = dr.GetDateTime(1);
                    details.Add(detail);
                }
                return details;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}