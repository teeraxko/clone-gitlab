using System;
using System.Data;
using System.Data.SqlClient;

using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

using SystemFramework.AppConfig;

namespace PTB.BTS.Report.Flow
{
	public class TrNonPayrollBenefitFlow : FlowBase
	{
		public TrNonPayrollBenefitFlow():base()
		{
		}

//		==================================== Public Method ====================================
		public bool GenerateNonPayrollBenefit(DateTime yearMonth, DateTime dateTime)
		{
			TableAccess tableAccess = new TableAccess();
			SqlCommand command = new SqlCommand("SGenerateNonPayrollBenefit");

			SqlParameter sqlParameter1 = command.Parameters.Add("@Year", SqlDbType.Int);
			sqlParameter1.Value = yearMonth.Year;

			SqlParameter sqlParameter2 = command.Parameters.Add("@Month", SqlDbType.TinyInt);
			sqlParameter2.Value = yearMonth.Month;

			SqlParameter sqlParameter3 = command.Parameters.Add("@PaymentDate", SqlDbType.DateTime);
			sqlParameter3.Value = dateTime;

			SqlParameter sqlParameter4 = command.Parameters.Add("@UserName", SqlDbType.VarChar);
			sqlParameter4.Value = UserProfile.UserID;

			bool result = (tableAccess.ExecuteStoredProcedure(command)>0);

			tableAccess = null;
			command = null;
			sqlParameter1 = null;
			sqlParameter2 = null;

			return result;
		}

	}
}
