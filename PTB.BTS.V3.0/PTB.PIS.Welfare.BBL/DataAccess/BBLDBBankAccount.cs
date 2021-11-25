using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PTB.PIS.Welfare.BBL.Eitities;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.PIS.Welfare.DataAccess;

namespace PTB.PIS.Welfare.BBL.DataAccess {
    class BBLDBBankAccount {
        public static BankAccount FillByEmp(Company comp, Employee emp) {
            string strSQL = "select Bank_Account_No from Employee_Salary where Company_Code = @Company_Code and Employee_No = @Employee_No";
            IDbCommand cmd = DataBase.GetDbCommand();
            cmd.CommandText = strSQL;

            IDbDataParameter pCompany_Code = DataBase.GetDbParameter();
            pCompany_Code.ParameterName = "@Company_Code";
            pCompany_Code.Value = Common.CurrentCompany.CompanyCode;
            cmd.Parameters.Add(pCompany_Code);

            IDbDataParameter pEmployee_No = DataBase.GetDbParameter();
            pEmployee_No.ParameterName = "@Employee_No";
            pEmployee_No.Value = emp.EmployeeNo;
            cmd.Parameters.Add(pEmployee_No);
            
            try {
                if (cmd.Connection.State != ConnectionState.Open) {
                    cmd.Connection.Open();
                }
                IDataReader dr = cmd.ExecuteReader();
                BankAccount bankAccount = null;
                while (dr.Read()) {
                    bankAccount = new BankAccount();
                    bankAccount.Code = dr.GetString(0);
                }
                return bankAccount;
            } catch (Exception excp) {
                throw excp;
            } finally {
                cmd.Connection.Close();
            }
        }
    }
}
