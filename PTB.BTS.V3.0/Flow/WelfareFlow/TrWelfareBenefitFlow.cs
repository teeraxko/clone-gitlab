using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.CommonDB;
using System.Data.SqlClient;
using SystemFramework.AppConfig;
using System.Data;
using PTB.BTS.Common.Flow;

namespace Flow.WelfareFlow
{
    public class TrWelfareBenefitFlow : FlowBase
    {
        public TrWelfareBenefitFlow()
            : base()
        { }

        public bool GenerateWelfarePayrollBenefit(DateTime forMonth, DateTime validDate, DateTime paymentDate)
        {
            TableAccess tableAccess = new TableAccess();
            SqlCommand command = new SqlCommand("SGenerateWelfareBenefit");

            SqlParameter sqlParameter1 = command.Parameters.Add("@ForMonth", SqlDbType.DateTime);
            sqlParameter1.Value = forMonth;

            SqlParameter sqlParameter2 = command.Parameters.Add("@ValidDate", SqlDbType.DateTime);
            sqlParameter2.Value = validDate;

            SqlParameter sqlParameter3 = command.Parameters.Add("@PaymentDate", SqlDbType.DateTime);
            sqlParameter3.Value = paymentDate;

            SqlParameter sqlParameter4 = command.Parameters.Add("@UserName", SqlDbType.Char);
            sqlParameter4.Value = UserProfile.UserID;

            bool result = (tableAccess.ExecuteStoredProcedure(command) > 0);

            tableAccess = null;
            command = null;
            sqlParameter1 = null;
            sqlParameter2 = null;

            return result;
        }
    }
}
