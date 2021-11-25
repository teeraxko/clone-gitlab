using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.DataAccess.LoanDB;
using System.Data;
using ictus.PIS.Welfare.Entity.LoanEntities;
using ictus.Common.Entity;
using ictus.PIS.Welfare.DataAccess;

namespace PTB.PIS.Welfare.BBL.DataAccess {
    class BBLDBLoan : BBLDBBase  {
        public BBLDBLoan() {
            this.connection = DataBase.GetDataConnection();
            this.tablename = "Employee_Loan_Head";
            this.connectDateFieldName = "Company_Payment_Date";
        }

        private Company comp;
        private List<LoanApplication> apps;

        public BBLDBLoan(DateTime connectDate, Company comp, List<LoanApplication> apps)
            : this() {
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
            paras = this.GetBBLParameters(paras);
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
