using System;
using System.Data;
using System.Data.SqlClient;

using DataAccess.CommonDB;
using DataAccess.AttendanceDB;

using Entity.AttendanceEntities;

using PTB.BTS.Common.Flow;

using SystemFramework.AppConfig;

namespace PTB.BTS.Report.Flow
{
	public class TrPayrollBenefitFlow : FlowBase
	{	
		private TrPayrollBenefitDB dbTrPayrollBenefit;

//		==================================== Constructor ====================================
		public TrPayrollBenefitFlow():base()
		{
			dbTrPayrollBenefit = new TrPayrollBenefitDB();
		}

//		==================================== Public Method ====================================
		public bool GeneratePayrollBenefit(DateTime paymentDate)
		{
			TableAccess tableAccess = new TableAccess();
			SqlCommand command = new SqlCommand("SGeneratePayrollBenefit");

			SqlParameter sqlParameter1 = command.Parameters.Add("@Year", SqlDbType.Int);
			sqlParameter1.Value = paymentDate.Year;

			SqlParameter sqlParameter2 = command.Parameters.Add("@Month", SqlDbType.TinyInt);
			sqlParameter2.Value = paymentDate.Month;

			SqlParameter sqlParameter3 = command.Parameters.Add("@PaymentDate", SqlDbType.DateTime);
			sqlParameter3.Value = paymentDate;

			SqlParameter sqlParameter4 = command.Parameters.Add("@UserName", SqlDbType.VarChar);
			sqlParameter4.Value = UserProfile.UserID;

			bool result = (tableAccess.ExecuteStoredProcedure(command)>0);

			tableAccess = null;
			command = null;
			sqlParameter1 = null;
			sqlParameter2 = null;

			return result;
		}

		public bool FillTrPayrollBenefitList(ref TrPayrollBenefitList value)
		{
			return dbTrPayrollBenefit.FillTrParollBenefitList(ref value);
		}
	}
}
