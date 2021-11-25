using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataAccess.CommonDB;
using PTB.BTS.Common.Flow;
using Flow.AttendanceFlow;
using ictus.PIS.PI.Entity;

using ictus.Common.Entity;

namespace PTB.BTS.Report.Flow
{
    public class NoAccidentRewardFlow : FlowBase {
        public bool GenerateTimeCardCharge(int forYear, DateTime fromDate, DateTime toDate, DateTime paymentDate, int reward) {
            
            TableAccess tableAccess = new TableAccess();
            SqlCommand command = new SqlCommand("SGenerateNoAccidentReward");
            command.Parameters.Add(new SqlParameter("@forYear",forYear));
            command.Parameters.Add(new SqlParameter("@fromDate", fromDate));
            command.Parameters.Add(new SqlParameter("@toDate", toDate));
            command.Parameters.Add(new SqlParameter("@paymentDate", paymentDate));
            command.Parameters.Add(new SqlParameter("@reward", reward));
            bool result = (tableAccess.ExecuteStoredProcedure(command) > 0);

            return result;
        }

        public int GetReward() {
            string strSQL = "SELECT No_Accident_Reward_Rate FROM Other_Benefit_Rate";
            TableAccess tableAccess = new TableAccess();
            return Convert.ToInt32(tableAccess.ExecuteScalar(strSQL)); 
        }

        public DateTime GetPaymentDate(int paymentYear, Company aCompany) {
            GenerateOtherBenefitFlow gFlow = new GenerateOtherBenefitFlow();
            return gFlow.RetriveDate(new DateTime(paymentYear, 7, 21), aCompany, -1);
        }


    }
}
