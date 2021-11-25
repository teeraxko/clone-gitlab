using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.ContributionEntities;
using System.Data;
using ictus.Common.Entity;
using ictus.PIS.Welfare.DataAccess.ContributionDB;
using ictus.PIS.Welfare.DataAccess;
using ictus.PIS.PI.Entity;

namespace PTB.PIS.Welfare.BizPac.DataAccess
{
    internal class EmployeeContributionBizDB : BizPacDBBase
    {
        public EmployeeContributionBizDB()
        {
            this.connection = DataBase.GetDataConnection();
            this.tablename = "Employee_Contribution";
        }
        protected enum ColIndex
        {
            Company_Code,
            Employee_No,
            Contribution_Code,
            Applied_Date,
            Applied_Amount,
            Remark, BizPac_Reference_No, BizPac_Connection_Date, Process_Date, Process_User
        }
        private Company comp;
        private List<ContributionApplication> apps;

        public EmployeeContributionBizDB(string refNo, DateTime connectDate, Company comp, List<ContributionApplication> apps)
            : this()
        {

            this.refNo = refNo;
            this.connectDate = connectDate;
            this.comp = comp;
            this.apps = apps;
        }

        protected override string GetCriteriaKey()
        {
            return EmployeeContributionDB.CriteriaKey();
        }

        private IDbCommand BuildUpdateCommand(Company comp, ContributionApplication app)
        {
            IDbCommand command = DataBase.GetDbCommand(this.connection);
            command.CommandText = this.BulidStringUpdate();
            foreach (IDbDataParameter para in this.GetUpdateParameters(comp, app)) command.Parameters.Add(para);
            return command;
        }

        private List<IDbDataParameter> GetUpdateParameters(Company comp, ContributionApplication app)
        {
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            paras = EmployeeContributionDB.GetKeyParameters(paras, comp, app);
            paras = this.GetBizParameters(paras);
            paras = this.GetProcessParameters(paras);
            return paras;
        }

        public override bool UpdateData()
        {
            bool result = false;
            try
            {
                result = true;
                this.connection.Open();
                this.transaction = this.connection.BeginTransaction();
                foreach (ContributionApplication app in this.apps)
                {
                    IDbCommand command = this.BuildUpdateCommand(this.comp, app);
                    command.Transaction = this.transaction;
                    result = result && (command.ExecuteNonQuery() == 1);
                }
                this.transaction.Commit();
                return result;
            }
            catch (Exception ex)
            {
                this.transaction.Rollback();
                throw ex;
            }
            finally
            {
                this.connection.Close();
            }
        }

        public static List<ContributionApplication> FillNoBizPacByFromDateToDAte(Company company, DateTime fromDate, DateTime toDate)
        {

            List<ContributionApplication> apps = new List<ContributionApplication>();
            StringBuilder str = new StringBuilder();
            str.Append(" SELECT * FROM Employee_Contribution ");
            str.Append(" WHERE ");
            str.Append(" Company_Code = @Company_Code AND ");
            str.Append(" (Applied_date BETWEEN @FromDate AND @ToDate) AND");
            str.Append(" BizPac_Connection_Date is NULL ");
            str.Append(" ORDER BY Applied_date ");

            IDbCommand cmd = DataBase.GetDbCommand();
            string strSQL = str.ToString();
            cmd.CommandText = strSQL;
            foreach (IDbDataParameter p in BizPacDBBase.GetCompanyFromToDateParameters(null, company, fromDate, toDate))
            {
                cmd.Parameters.Add(p);
            }
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ContributionApplication app = new ContributionApplication();
                    app.Employee = new Employee(company);
                    app.Employee.EmployeeNo = dr.GetString((int)ColIndex.Employee_No);
                    app.Contribution = ContributionDB.FillByCode(dr.GetString((int)ColIndex.Contribution_Code));
                    app.AppliedDate = dr.GetDateTime((int)ColIndex.Applied_Date);
                    app.AppliedAmount = dr.GetDecimal((int)ColIndex.Applied_Amount);
                    app.Remark = dr.GetString((int)ColIndex.Remark);
                    apps.Add(app);
                }
                return apps;

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
    }
}
