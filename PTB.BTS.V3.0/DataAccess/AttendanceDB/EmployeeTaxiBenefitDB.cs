using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public class EmployeeTaxiBenefitDB: DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int BENEFIT_DATE = 1;
		private const int BENEFIT_AMOUNT = 2;	
		private const int TIME = 3;
		private const int BENEFIT_TOTAL_AMOUNT = 4;
		private const int BENEFIT_AMOUNT_FOR_CHARGE = 5;
		private const int TIMES_FOR_CHARGE = 6;
		private const int BENEFIT_TOTAL_AMOUNT_FOR_CHARGE = 7;
		private const int PAYMENT_STATUS = 8;
		private const int PAYMENT_DATE = 9;

		#endregion

		#region - Private -
		private TaxiBenefit objTaxiBenefit; 
		private bool disposed  = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeTaxiBenefitDB(): base()
		{}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Benefit_Date, Benefit_Amount, Times, Benefit_Total_Amount, Benefit_Amount_For_Charge, Times_For_Charge, Benefit_Total_Amount_For_Charge, Payment_Status, Payment_Date FROM Employee_Taxi_Benefit ";
		}

		private string getSQLInsert(TaxiBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Taxi_Benefit(Company_Code, Employee_No, Benefit_Date, Benefit_Amount, Times, Benefit_Total_Amount, Benefit_Amount_For_Charge, Times_For_Charge, Benefit_Total_Amount_For_Charge, Payment_Status, Payment_Date, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Benefit_Date
			stringBuilder.Append(GetDB(value.BenefitDate));
			stringBuilder.Append(", ");		

			//Benefit_Amount
			stringBuilder.Append(GetDB(value.BaseAmount));
			stringBuilder.Append(", ");

			//Time
			stringBuilder.Append(GetDB(value.Times));
			stringBuilder.Append(", ");

			//Benefit_Total_Amount
			stringBuilder.Append(GetDB(value.TotalAmount));
			stringBuilder.Append(", ");

			//Benefit_Amount_For_Charge
			stringBuilder.Append(GetDB(value.BenefitAmountForCharge));
			stringBuilder.Append(", ");

			//Times_For_Charge
			stringBuilder.Append(GetDB(value.TimesForCharge));
			stringBuilder.Append(", ");
			
			//Benefit_Total_Amount_For_Charge
			stringBuilder.Append(GetDB(value.BenefitTotalAmountForCharge));
			stringBuilder.Append(", ");
			
			//Payment_Status
			stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentStatus));
			stringBuilder.Append(", ");

			//Payment_Date
			if(IsNotNULL(value.ABenefitPayment.PaymentDate))
			{
				stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentDate));
			}
			else
			{
				stringBuilder.Append(GetDB(NullConstant.DATETIME));
			}
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(TaxiBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Taxi_Benefit SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Benefit_Date = ");
			stringBuilder.Append(GetDB(value.BenefitDate));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Benefit_Amount = ");
			stringBuilder.Append(GetDB(value.BaseAmount));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Times = ");
			stringBuilder.Append(GetDB(value.Times));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Benefit_Total_Amount = ");
			stringBuilder.Append(GetDB(value.TotalAmount));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Benefit_Amount_For_Charge = ");
			stringBuilder.Append(GetDB(value.BenefitAmountForCharge));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Times_For_Charge = ");
			stringBuilder.Append(GetDB(value.TimesForCharge));
			stringBuilder.Append(", ");
			
			stringBuilder.Append(" Benefit_Total_Amount_For_Charge = ");
			stringBuilder.Append(GetDB(value.BenefitTotalAmountForCharge));
			stringBuilder.Append(", ");
			
			stringBuilder.Append(" Payment_Status = ");
			stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentStatus));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Payment_Date = ");
			if(IsNotNULL(value.ABenefitPayment.PaymentDate))
			{
				stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentDate));
			}
			else
			{
				stringBuilder.Append(GetDB(NullConstant.DATETIME));
			}
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
			
			return stringBuilder.ToString();
		}	

		private string getSQLDelete()
		{
			return " DELETE FROM Employee_Taxi_Benefit ";
		}

		private string getKeyCondition(TaxiBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.BenefitDate))
			{
				stringBuilder.Append(" AND (Benefit_Date = ");
				stringBuilder.Append(GetDB(value.BenefitDate));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}

		private string getListCondition(EmployeeTaxiBenefit value)
		{
			return " AND " + SqlFunction.GetYearMonthCondition("Benefit_Date", value.AYearMonth);
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No, Benefit_Date ";
		}
		#endregion

		#region - fill -
		private void fillTaxiBenefit(ref TaxiBenefit value, SqlDataReader dataReader)
		{
			value.BenefitDate = dataReader.GetDateTime(BENEFIT_DATE);
			value.BaseAmount = dataReader.GetDecimal(BENEFIT_AMOUNT);
			value.Times = dataReader.GetByte(TIME);
			value.TotalAmount = dataReader.GetDecimal(BENEFIT_TOTAL_AMOUNT);
			value.BenefitAmountForCharge = dataReader.GetDecimal(BENEFIT_AMOUNT_FOR_CHARGE);
			value.TimesForCharge = dataReader.GetByte(TIMES_FOR_CHARGE);
			value.BenefitTotalAmountForCharge = dataReader.GetDecimal(BENEFIT_TOTAL_AMOUNT_FOR_CHARGE); 

			if(dataReader.IsDBNull(PAYMENT_STATUS))
			{
				value.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NULL;
			}
			else
			{
				value.ABenefitPayment.PaymentStatus = CTFunction.GetPaymentStatusType((string)dataReader[PAYMENT_STATUS]);
			}
			if (dataReader.IsDBNull(PAYMENT_DATE))
			{
				value.ABenefitPayment.PaymentDate = NullConstant.DATETIME;
			}
			else
			{
				value.ABenefitPayment.PaymentDate = dataReader.GetDateTime(PAYMENT_DATE);
			}
		}

		private bool fillTaxiBenefitList(ref EmployeeTaxiBenefit value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objTaxiBenefit = new TaxiBenefit();
					fillTaxiBenefit(ref objTaxiBenefit, dataReader);
					value.Add(objTaxiBenefit);
				}
				objTaxiBenefit = null;
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();				
			}
			return result;
		}

        private bool fillTaxiBenefit(TaxiBenefit value, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillTaxiBenefit(ref value, dataReader);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }
            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

		#endregion

		//		============================== Public Method ==============================
        public bool FillTaxiBenefit(TaxiBenefit taxiBenefit, Employee employee)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(employee));
            stringBuilder.Append(getKeyCondition(taxiBenefit));

            return fillTaxiBenefit(taxiBenefit, stringBuilder.ToString());
        }

		public bool FillTaxiBenefitList(ref EmployeeTaxiBenefit value, TaxiBenefit aTaxiBenefit)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(aTaxiBenefit));
			stringBuilder.Append(getOrderby());

			return fillTaxiBenefitList(ref value, stringBuilder.ToString());
		}

		public bool FillTaxiBenefitList(ref EmployeeTaxiBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value));
			stringBuilder.Append(getOrderby());

			return fillTaxiBenefitList(ref value, stringBuilder.ToString());
		}

		public bool InsertTaxiBenefit(TaxiBenefit value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateTaxiBenefit(TaxiBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteTaxiBenefit(TaxiBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool InsertEmployeeTaxiBenefit(EmployeeTaxiBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder("BEGIN ");
			for(int i=0; i<value.Count; i++)
			{				
				stringBuilder.Append(getSQLInsert(value[i], value.Employee));
				stringBuilder.Append(";");
			}
			stringBuilder.Append(" END;");
	
			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateEmployeeTaxiBenefit(EmployeeTaxiBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder("BEGIN ");

			stringBuilder.Append(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value));

			for(int i=0; i<value.Count; i++)
			{				
				stringBuilder.Append(getSQLInsert(value[i], value.Employee));
				stringBuilder.Append(";");
			}
			stringBuilder.Append(" END;");
	
			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0 || value.Count==0)
			{return true;}
			else
			{return false;}	
		}

		public bool DeleteEmployeeTaxiBenefit(EmployeeTaxiBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
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
