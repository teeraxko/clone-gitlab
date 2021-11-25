using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.DataAccess.LoanDB;
using ictus.Common.Entity;
using ictus.PIS.Welfare.Entity.LoanEntities;
using System.Data;
using ictus.PIS.PI.Entity;
using ictus.PIS.Welfare.DataAccess;

namespace PTB.PIS.Welfare.BizPac.DataAccess {
    internal class EmployeeLoanBizDB : BizPacDBBase {
        public EmployeeLoanBizDB() {
            this.connection = DataBase.GetDataConnection();
            this.tablename = "Employee_Loan_Head";
        }
        private enum ColIndex {
            Company_Code,
            Employee_No,
            Loan_Code,
            Applied_Date,
            Start_Date,
            End_Date,
            Company_Payment_Date,
            Interest_Rate,
            Capital_Amount,
            Paid_Amount,
            Offset_Amount,
            Offset_Date,
            Balance_Amount,
            Payment_Month_Period,
            BizPac_Reference_No,
            BizPac_Connection_Date,
            Process_Date, Process_User

        }

        public static List<LoanApplication> FillNoBizByCompFromDateToDate(Company comp, DateTime fromDate, DateTime toDate) {
            List<LoanApplication> items = new List<LoanApplication>();

            StringBuilder str = new StringBuilder();
            str.Append(" SELECT *  ");
            str.Append(" FROM Employee_Loan_Head ");
            str.Append(" WHERE ");
            str.Append(" Company_Code = @Company_Code AND ");
            str.Append(" (Applied_date BETWEEN @FromDate AND @ToDate) AND ");
            str.Append(" BizPac_Connection_Date is NULL AND Paid_Amount = 0 ");
            str.Append(" ORDER BY Applied_date ");
            
            string strSQL = str.ToString();
            IDbCommand cmd = DataBase.GetDbCommand();
            cmd.CommandText = strSQL;
            foreach (IDbDataParameter p in BizPacDBBase.GetCompanyFromToDateParameters(null, comp, fromDate, toDate)) cmd.Parameters.Add(p);
            try {
                if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    LoanApplication item = new LoanApplication();
                    Employee emp = new Employee(comp);
                    emp.EmployeeNo = dr.GetString((int)ColIndex.Employee_No);
                    item.Employee = emp;
                    item.LoanReson = LoanResonDB.FillByCode(dr.GetString((int)ColIndex.Loan_Code));
                    item.AppliedDate = dr.GetDateTime((int)ColIndex.Applied_Date);
                    item.StartDate = dr.GetDateTime((int)ColIndex.Start_Date);
                    item.EndDate = dr.GetDateTime((int)ColIndex.End_Date);
                    item.InterestRate = dr.GetDecimal((int)ColIndex.Interest_Rate);
                    item.CapitalAmount = dr.GetDecimal((int)ColIndex.Capital_Amount);
                    item.PaidAmount = dr.GetDecimal((int)ColIndex.Paid_Amount);
                    item.OffsetAmount = dr.GetDecimal((int)ColIndex.Offset_Amount);
                    item.OffsetDate = dr[(int)ColIndex.Offset_Date] == DBNull.Value ? new DateTime() : dr.GetDateTime((int)ColIndex.Offset_Date);
                    item.BalanceAmount = dr.GetDecimal((int)ColIndex.Balance_Amount);
                    item.Period = dr.GetByte((int)ColIndex.Payment_Month_Period);
                    items.Add(item);
                }
                return items;
            } catch (Exception excp) {
                throw excp;
            } finally {
                cmd.Connection.Close();
            }
        }


        private Company comp;
        private List<LoanApplication> apps;

        public EmployeeLoanBizDB(string refNo, DateTime connectDate, Company comp, List<LoanApplication> apps):this() {
            
            this.refNo = refNo;
            this.connectDate = connectDate;
            this.comp = comp;
            this.apps = apps;
        }

        protected override string GetCriteriaKey() {
            return LoanEmployeeDB.CriteriaKey();
        }

        private IDbCommand BuildUpdateCommand(Company comp, LoanApplication app) {
            IDbCommand command = DataBase.GetDbCommand(this.connection);
            command.CommandText = this.BulidStringUpdate();
            foreach (IDbDataParameter para in this.GetUpdateParameters(comp, app)) command.Parameters.Add(para);
            return command;
        }

        private List<IDbDataParameter> GetUpdateParameters(Company comp, LoanApplication app) {
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            paras = LoanEmployeeDB.GetKeyParameters(paras, comp, app);
            paras = this.GetBizParameters(paras);
            paras = this.GetProcessParameters(paras);
            return paras;
        }

        public override bool UpdateData() {
            bool result = false;
            try {
                result = true;
                this.connection.Open();
                this.transaction = this.connection.BeginTransaction();
                foreach (LoanApplication app in this.apps) {
                    IDbCommand command = this.BuildUpdateCommand(this.comp, app);
                    command.Transaction = this.transaction;
                    result = result && (command.ExecuteNonQuery() == 1);
                }
                this.transaction.Commit();
                return result;
            } catch (Exception ex) {
                this.transaction.Rollback();
                throw ex;
            } finally {
                this.connection.Close();
            }
        }

    }
}
