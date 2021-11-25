using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

using SystemFramework.AppConfig;
using SystemFramework.AppException;

namespace DataAccess.AttendanceDB
{
	public class TrPayrollBenefitDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int OT_A_HOUR = 1;
		private const int OT_B_HOUR = 2;
		private const int OT_C_HOUR = 3;
		private const int EXTRA_AMOUNT = 4;
		private const int DEDUCTION_AMOUNT = 5;
		private const int PAYMENT_DATE = 6;
		#endregion

		#region - Private -
		private bool disposed = false;
		private TrPayrollBenefit objTrParollBenefit;
		#endregion

//		============================== Constructor ==============================
		public TrPayrollBenefitDB() : base()
		{
		}

		//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Employee_No, OT_A_Hour, OT_B_Hour, OT_C_Hour, Extra_Amount, Deduction_Amount, Payment_Date FROM Tr_Payroll_Benefit ";
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No ";
		}
		#endregion

		#region - Fill -
		private void fillTrParollBenefit(ref TrPayrollBenefit value, SqlDataReader dataReader)
		{
			value.OTAHour = dataReader.GetDecimal(OT_A_HOUR);
			value.OTBHour = dataReader.GetDecimal(OT_B_HOUR);
			value.OTCHour = dataReader.GetDecimal(OT_C_HOUR);
			value.ExtraAmount = dataReader.GetDecimal(EXTRA_AMOUNT);
			value.DeductionAmount = dataReader.GetDecimal(DEDUCTION_AMOUNT);
			value.PaymentDate = dataReader.GetDateTime(PAYMENT_DATE);			
		}

		private bool fillTrParollBenefitList(ref TrPayrollBenefitList value, string sql)
		{
			bool result = false;
			EmployeeDB dbEmployee = new EmployeeDB();
			EmployeeList listEmployee = new EmployeeList(value.Company);
			dbEmployee.FillAllEmployeeList(listEmployee);

			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);		
			try
			{
				while (dataReader.Read())
				{
					result = true;

					objTrParollBenefit = new TrPayrollBenefit();
					objTrParollBenefit.AEmployee = listEmployee[(string)dataReader[EMPLOYEE_NO]];
					fillTrParollBenefit(ref objTrParollBenefit, dataReader);
					value.Add(objTrParollBenefit);
				}
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();

				listEmployee = null;
				dbEmployee = null;
			}
			return result;		
		}
		#endregion

		//		============================== Public Method =============================
		public bool FillTrParollBenefitList(ref TrPayrollBenefitList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());
			return fillTrParollBenefitList(ref value, stringBuilder.ToString());
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion
	}
}
