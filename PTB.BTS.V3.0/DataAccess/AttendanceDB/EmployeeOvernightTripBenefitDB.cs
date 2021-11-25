using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;
using ictus.Common.Entity;

using Entity.CommonEntity;
using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;

using DataAccess.CommonDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public class EmployeeOvernightTripBenefitDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int TO_LOCATION = 1;
		private const int FROM_DATE = 2;
		private const int TO_DATE = 3;
		private const int BENEFIT_DATE = 4;
		private const int CUSTOMER_CODE = 5;
		private const int CUSTOMER_DEPARTMENT_CODE = 6;
		private const int BENEFIT_AMOUNT = 7;
		private const int ADVANCE_PAYMENT_STATUS = 8;
		private const int PAYMENT_STATUS = 9;
		private const int PAYMENT_DATE = 10;
		#endregion

		#region - Private -
		private OvernightTripBenefit objOvernightTripBenefit;
		private OvernightTrip objOvernightTrip;

		private TripLocationDB dbTripLocation;
		private CustomerDB dbCustomer;
		private CustomerDepartmentDB dbCustomerDepartment;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeOvernightTripBenefitDB() : base()
		{
			dbTripLocation = new TripLocationDB();
			dbCustomer = new CustomerDB();
			dbCustomerDepartment = new CustomerDepartmentDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Employee_No, To_Location, From_Date, To_Date, Benefit_Date, Customer_Code, Customer_Department_Code, Benefit_Amount, Advance_Payment_Status, Payment_Status, Payment_Date FROM Employee_Overnight_Trip_Benefit ";
		}
		
		private string getSQLInsert(EmployeeOvernightTripBenefit value, OvernightTripBenefit aOvernightTripBenefit)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Overnight_Trip_Benefit (Company_Code, Employee_No, To_Location, From_Date, To_Date, Benefit_Date, Customer_Code, Customer_Department_Code, Benefit_Amount, Advance_Payment_Status, Payment_Status, Payment_Date, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(value.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(value.Employee.EmployeeNo));
			stringBuilder.Append(", ");

			//To_Location
			stringBuilder.Append(GetDB(value.AOvernightTrip.ATripLocation.Name));
			stringBuilder.Append(", ");

			//From_Date
			stringBuilder.Append(GetDB(value.AOvernightTrip.APeriod.From));
			stringBuilder.Append(", ");

			//To_Date
			stringBuilder.Append(GetDB(value.AOvernightTrip.APeriod.To));
			stringBuilder.Append(", ");

			//Benefit_Date
			stringBuilder.Append(GetDB(aOvernightTripBenefit.BenefitDate));
			stringBuilder.Append(", ");

			//Customer_Code
			stringBuilder.Append(GetDB(value.ACustomer.Code));
			stringBuilder.Append(", ");

			//Customer_Department_Code
			stringBuilder.Append(GetDB(value.ACustomerDepartment.Code));
			stringBuilder.Append(", ");

			//Benefit_Amount
			stringBuilder.Append(GetDB(value.TotalAmount));
			stringBuilder.Append(", ");

			//Advance_Payment_Status
			stringBuilder.Append(GetDB(value.AdvancePaymentStatus));
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

		private string getSQLInsert(BenefitOvernightTrip value, Employee employee, DateTime benefitDate)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Overnight_Trip_Benefit (Company_Code, Employee_No, To_Location, From_Date, To_Date, Benefit_Date, Customer_Code, Customer_Department_Code, Benefit_Amount, Advance_Payment_Status, Payment_Status, Payment_Date, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(employee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(employee.EmployeeNo));
			stringBuilder.Append(", ");

			//To_Location
			stringBuilder.Append(GetDB(value.Location.Name));
			stringBuilder.Append(", ");

			//From_Date
			stringBuilder.Append(GetDB(value.From));
			stringBuilder.Append(", ");

			//To_Date
			stringBuilder.Append(GetDB(value.To));
			stringBuilder.Append(", ");

			//Benefit_Date
			stringBuilder.Append(GetDB(benefitDate));
			stringBuilder.Append(", ");

			//Customer_Code
			stringBuilder.Append(GetDB(value.Customer.Code));
			stringBuilder.Append(", ");

			//Customer_Department_Code
			stringBuilder.Append(GetDB(value.CustomerDepartment.Code));
			stringBuilder.Append(", ");

			//Benefit_Amount
			stringBuilder.Append(GetDB(value.Amount));
			stringBuilder.Append(", ");

			//Advance_Payment_Status
			stringBuilder.Append(GetDB(value.AdvancePaymentStatus));
			stringBuilder.Append(", ");

			//Payment_Status
			stringBuilder.Append(GetDB(value.BenefitPayment.PaymentStatus));
			stringBuilder.Append(", ");

			//Payment_Date
			if(IsNotNULL(value.BenefitPayment.PaymentDate))
			{
				stringBuilder.Append(GetDB(value.BenefitPayment.PaymentDate));
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

		private string getSQLUpdate(EmployeeOvernightTripBenefit value, OvernightTripBenefit aOvernightTripBenefit)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Overnight_Trip_Benefit SET ");

			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(value.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(value.Employee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("To_Location = ");
			stringBuilder.Append(GetDB(value.AOvernightTrip.ATripLocation.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("From_Date = ");
			stringBuilder.Append(GetDB(value.AOvernightTrip.APeriod.From));
			stringBuilder.Append(", ");

			stringBuilder.Append("To_Date = ");
			stringBuilder.Append(GetDB(value.AOvernightTrip.APeriod.To));
			stringBuilder.Append(", ");

			stringBuilder.Append("Benefit_Date = ");
			stringBuilder.Append(GetDB(aOvernightTripBenefit.BenefitDate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Customer_Code = ");
			stringBuilder.Append(GetDB(value.ACustomer.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("Customer_Department_Code = ");
			stringBuilder.Append(GetDB(value.ACustomerDepartment.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("Benefit_Amount = ");
			stringBuilder.Append(GetDB(value.TotalAmount));
			stringBuilder.Append(", ");

			stringBuilder.Append("Advance_Payment_Status = ");
			stringBuilder.Append(GetDB(value.AdvancePaymentStatus));
			stringBuilder.Append(", ");

			stringBuilder.Append("Payment_Status = ");
			stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentStatus));
			stringBuilder.Append(", ");

			stringBuilder.Append("Payment_Date = ");
			if(IsNotNULL(value.ABenefitPayment.PaymentDate))
			{
				stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentDate));
			}
			else
			{
				stringBuilder.Append(GetDB(NullConstant.DATETIME));
			}
			stringBuilder.Append(", ");

			stringBuilder.Append("Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append("Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
		
			return stringBuilder.ToString();		
		
		}

		private string getSQLDelete()
		{
			return "DELETE FROM Employee_Overnight_Trip_Benefit ";
		}

		private string getKeyCondition(OvernightTrip aOvernightTrip)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if (IsNotNULL(aOvernightTrip.ATripLocation.Name))
			{
				stringBuilder.Append(" AND (To_Location = ");
				stringBuilder.Append(GetDB(aOvernightTrip.ATripLocation.Name));
				stringBuilder.Append(")");
			}

			if (IsNotNULL(aOvernightTrip.APeriod.From))
			{
				stringBuilder.Append(" AND (From_Date = ");
				stringBuilder.Append(GetDB(aOvernightTrip.APeriod.From));
				stringBuilder.Append(")");
			}

			if (IsNotNULL(aOvernightTrip.APeriod.To))
			{
				stringBuilder.Append(" AND (To_Date = ");
				stringBuilder.Append(GetDB(aOvernightTrip.APeriod.To));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getKeyCondition(OvernightTripBenefit aOvernightTripBenefit, OvernightTrip aOvernightTrip)
		{
			StringBuilder stringBuilder = new StringBuilder(getKeyCondition(aOvernightTrip));
			if (IsNotNULL(aOvernightTripBenefit.BenefitDate))
			{
				stringBuilder.Append(" AND (Benefit_Date = ");
				stringBuilder.Append(GetDB(aOvernightTripBenefit.BenefitDate));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getKeyCondition(YearMonth yearMonth)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" AND ((MONTH(From_Date) = ");
			stringBuilder.Append(GetDB(yearMonth.Month));
			stringBuilder.Append(" AND YEAR(From_Date) = ");
			stringBuilder.Append(GetDB(yearMonth.Year));
			stringBuilder.Append(" ) OR (MONTH(To_Date) = ");
			stringBuilder.Append(GetDB(yearMonth.Month));
			stringBuilder.Append(" AND YEAR(To_Date) = ");
			stringBuilder.Append(GetDB(yearMonth.Year));
			stringBuilder.Append(" )) ");

			return stringBuilder.ToString();
		}

		private string getListCondition(YearMonth aYearMonth)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(aYearMonth))
			{
				stringBuilder.Append(" AND ");
				stringBuilder.Append(SqlFunction.GetYearMonthCondition("Benefit_Date", aYearMonth));
			}
			return stringBuilder.ToString();
		}

		private string getAllMonthCondition(YearMonth value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.Append(" AND ((");
			stringBuilder.Append(SqlFunction.GetYearMonthCondition("From_Date", value));
			stringBuilder.Append(" OR ");
			stringBuilder.Append(SqlFunction.GetYearMonthCondition("To_Date", value));
			stringBuilder.Append(")) ");

			return stringBuilder.ToString();
		}

		private string getBetweenMonthCondition(YearMonth value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.Append(" AND ((");
			stringBuilder.Append(SqlFunction.GetYearMonthCondition("From_Date", value));
			stringBuilder.Append(" AND ");
			stringBuilder.Append(SqlFunction.GetYearMonthCondition("To_Date", value));
			stringBuilder.Append(")) ");

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY From_Date, To_Date, To_Location, Benefit_Date ";
		}
		#endregion

		#region - Fill -
		private OvernightTripBenefit getOvernightTripBenefit(SqlDataReader dataReader)
		{
			objOvernightTripBenefit = new OvernightTripBenefit();
			objOvernightTripBenefit.BenefitDate = dataReader.GetDateTime(BENEFIT_DATE);
			objOvernightTripBenefit.TotalAmount = dataReader.GetDecimal(BENEFIT_AMOUNT);
			objOvernightTripBenefit.ABenefitPayment.PaymentStatus = CTFunction.GetPaymentStatusType((string)dataReader[PAYMENT_STATUS]);
			if (dataReader.IsDBNull(PAYMENT_DATE))
			{objOvernightTripBenefit.ABenefitPayment.PaymentDate = NullConstant.DATETIME;}
			else
			{objOvernightTripBenefit.ABenefitPayment.PaymentDate = dataReader.GetDateTime(PAYMENT_DATE);}
			return objOvernightTripBenefit;
		}

		private OvernightTrip getOvernightTrip(SqlDataReader dataReader)
		{
			objOvernightTrip = new OvernightTrip();
			objOvernightTrip.ATripLocation.Name = (string)dataReader[TO_LOCATION];
			objOvernightTrip.APeriod.From = dataReader.GetDateTime(FROM_DATE);
			objOvernightTrip.APeriod.To = dataReader.GetDateTime(TO_DATE);
			return objOvernightTrip;
		}

		private void fillEmployeeOvernightTripBenefit(ref EmployeeOvernightTripBenefit value, SqlDataReader dataReader)
		{
			value.ACustomer = dbCustomer.GetDBCustomer((string)dataReader[CUSTOMER_CODE], value.Employee.Company);
			value.ACustomerDepartment = dbCustomerDepartment.GetDBCustomerDepartment((string)dataReader[CUSTOMER_DEPARTMENT_CODE], (string)dataReader[CUSTOMER_CODE], value.Employee.Company); 
			value.AdvancePaymentStatus = GetBool((string)dataReader[ADVANCE_PAYMENT_STATUS]);
			value.ABenefitPayment.PaymentStatus = CTFunction.GetPaymentStatusType((string)dataReader[PAYMENT_STATUS]);

			if (dataReader.IsDBNull(PAYMENT_DATE))
			{value.ABenefitPayment.PaymentDate = NullConstant.DATETIME;}
			else
			{value.ABenefitPayment.PaymentDate = dataReader.GetDateTime(PAYMENT_DATE);}
		}

		private bool fillEmployeeOvernightTripBenefitList(ref EmployeeOvernightTripBenefitList value, string sql)
		{
			bool result = false;

			EmployeeOvernightTripBenefit employeeOvernightTripBenefit;
			OvernightTrip overnightTrip;
			OvernightTripBenefit overnightTripBenefit;

			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while(dataReader.Read())
				{
					result = true;
					overnightTrip = getOvernightTrip(dataReader);

					if(value.Contain(overnightTrip.EntityKey))
					{
						employeeOvernightTripBenefit = value[overnightTrip.EntityKey];
					}
					else
					{
						employeeOvernightTripBenefit = new EmployeeOvernightTripBenefit(value.ForYearMonth, value.Employee);
						employeeOvernightTripBenefit.AOvernightTrip = overnightTrip;
						fillEmployeeOvernightTripBenefit(ref employeeOvernightTripBenefit, dataReader);
						value.Add(employeeOvernightTripBenefit);
					}
					
					overnightTripBenefit = getOvernightTripBenefit(dataReader);
					overnightTripBenefit.AOvernightTrip = overnightTrip;

					employeeOvernightTripBenefit.Add(overnightTripBenefit);
				}
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();
	
				employeeOvernightTripBenefit = null;
				overnightTrip = null;
				overnightTripBenefit = null;

				dataReader = null;
			}
			return result;
		}

		private void fillBenefitOvernightTripList(BenefitOvernightTrip value, SqlDataReader dataReader, ictus.Common.Entity.Company company)
		{
			value.Location.Name = (string)dataReader[TO_LOCATION];
			value.Customer = dbCustomer.GetDBCustomer((string)dataReader[CUSTOMER_CODE], company);
			value.CustomerDepartment = dbCustomerDepartment.GetDBCustomerDepartment((string)dataReader[CUSTOMER_DEPARTMENT_CODE], (string)dataReader[CUSTOMER_CODE], company); 
			value.Amount = dataReader.GetDecimal(BENEFIT_AMOUNT);
			value.AdvancePaymentStatus = GetBool((string)dataReader[ADVANCE_PAYMENT_STATUS]);
			value.BenefitPayment.PaymentStatus = CTFunction.GetPaymentStatusType((string)dataReader[PAYMENT_STATUS]);
			if (dataReader.IsDBNull(PAYMENT_DATE))
			{
				value.BenefitPayment.PaymentDate = NullConstant.DATETIME;
			}
			else
			{
				value.BenefitPayment.PaymentDate = dataReader.GetDateTime(PAYMENT_DATE);
			}
		}

		private bool fillBenefitOvernightTripList(BenefitOvernightTripList value, string sql)
		{
			bool result = false;
			DateTime benefitDate;
			BenefitOvernightTrip benefitOvernightTrip;
			SqlDataReader dataReader;
			try
			{
				dataReader = tableAccess.ExecuteDataReader(sql);
				while(dataReader.Read())
				{
					result = true;
					benefitOvernightTrip = new BenefitOvernightTrip();
					benefitOvernightTrip.From = dataReader.GetDateTime(FROM_DATE);
					benefitOvernightTrip.To = dataReader.GetDateTime(TO_DATE);
					benefitDate = dataReader.GetDateTime(BENEFIT_DATE);
					if(!value.Contain(benefitDate))
					{
						fillBenefitOvernightTripList(benefitOvernightTrip, dataReader, value.Company);
						value.Add(benefitOvernightTrip);
					}
				}
				dataReader.Close();
			}
			finally
			{				
				dataReader = null;
			}
			return result;
		}

        private bool fillEmployeeOvernightTripBenefit(EmployeeOvernightTripBenefit value, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            OvernightTripBenefit overnightTripBenefit;

            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    overnightTripBenefit = getOvernightTripBenefit(dataReader);
                    value.Add(overnightTripBenefit);
                }
                overnightTripBenefit = null;
            }
            catch (IndexOutOfRangeException ein)
            {
                throw ein;
            }
            finally
            {
                tableAccess.CloseDataReader();
            }
            return result;
        }


		#endregion
//		============================== Public Method ==============================
        public bool FillEmployeeOvernightTripBenefit(EmployeeOvernightTripBenefit value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Employee));
            stringBuilder.Append(getListCondition(value.ForYearMonth));
            stringBuilder.Append(getOrderby());

            return fillEmployeeOvernightTripBenefit(value, stringBuilder.ToString());
        }

		public bool FillAllBenefitOvernightTripList(BenefitOvernightTripList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getAllMonthCondition(value.ForMonth));
			stringBuilder.Append(getOrderby());

			return fillBenefitOvernightTripList(value, stringBuilder.ToString());
		}

		public bool FillBetweenBenefitOvernightTripList(BenefitOvernightTripList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getBetweenMonthCondition(value.ForMonth));
			stringBuilder.Append(getOrderby());

			return fillBenefitOvernightTripList(value, stringBuilder.ToString());
		}

		public bool FillEmployeeOvernightTripBenefitList(ref EmployeeOvernightTripBenefitList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(value.ForYearMonth));
			stringBuilder.Append(getOrderby());

			return fillEmployeeOvernightTripBenefitList(ref value, stringBuilder.ToString());
		}

		public bool InsertEmployeeOvernightTripBenefit(EmployeeOvernightTripBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder("BEGIN ");
			for(int i=0; i<value.Count; i++)
			{				
				stringBuilder.Append(getSQLInsert(value, value[i]));
				stringBuilder.Append(";");
			}
			stringBuilder.Append(" END;");
	
			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateOvernightTripBenefit(EmployeeOvernightTripBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLUpdate(value, value[i]));
				stringBuilder.Append(getBaseCondition(value.Employee));
				stringBuilder.Append(getKeyCondition(value[i], value[i].AOvernightTrip));
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		}

		public bool DeleteOvernightTripBenefit(EmployeeOvernightTripBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(value.AOvernightTrip));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool UpdateEmployeeOvernightTripBenefitList(EmployeeOvernightTripBenefitList value)
		{
			StringBuilder stringBuilder = new StringBuilder("BEGIN ");

			stringBuilder.Append(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(value.ForYearMonth));
			stringBuilder.Append("; ");
			
			for(int i=0; i<value.Count; i++)
			{
				for(int j=0; j<value[i].Count; j++)
				{
					stringBuilder.Append(getSQLInsert(value[i], value[i][j]));
					stringBuilder.Append("; ");				
				}
			}

			stringBuilder.Append(" END;");

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0 || value.Count==0)
			{return true;}
			else
			{return false;}
		}

		public bool UpdateEmployeeOvernightTripBenefitList(BenefitOvernightTripList value)
		{
			StringBuilder stringBuilder = new StringBuilder("BEGIN ");

			stringBuilder.Append(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(value.ForMonth));
			stringBuilder.Append("; ");
			
			for(int i=0; i<value.Count; i++)
			{
				for(DateTime d=value[i].From; d<value[i].To; d=d.AddDays(1))
				{
					stringBuilder.Append(getSQLInsert(value[i], value.Employee, d));
					stringBuilder.Append("; ");				
				}
			}

			stringBuilder.Append(" END;");

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0 || value.Count==0)
			{
				return true;
			}
			else
			{
				return (value.Count==0);
			}
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

		#region - Old data -
//		private bool fillEmployeeOvernightTripBenefitList(ref EmployeeOvernightTripBenefitList value, string sql)
//		{
//			bool result = false;
//
//			OvernightTrip overnightTrip;
//			OvernightTripBenefit overnightTripBenefit;
//
//			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
//			try
//			{
//				if (dataReader.Read())
//				{
//					objEmployeeOvernightTripBenefit = new EmployeeOvernightTripBenefit(value.ForYearMonth, value.Employee);
//
//					while (dataReader.Read())
//					{
//						result = true;
//						overnightTrip = getOvernightTrip(dataReader);
//						overnightTripBenefit = getOvernightTripBenefit(dataReader);
//
//						if(value.Count == 0)
//						{
//							objEmployeeOvernightTripBenefit.AOvernightTrip = overnightTrip;
//							objEmployeeOvernightTripBenefit.Add(overnightTripBenefit);
//						}
//						else
//						{
//							if (objEmployeeOvernightTripBenefit.AOvernightTrip.Equals(overnightTrip))
//							{
//								objEmployeeOvernightTripBenefit.Add(overnightTripBenefit);
//							}
//							else
//							{
//								value.Add(objEmployeeOvernightTripBenefit);
//
//								objEmployeeOvernightTripBenefit = new EmployeeOvernightTripBenefit(value.ForYearMonth, value.Employee);
//								objEmployeeOvernightTripBenefit.AOvernightTrip = overnightTrip;							
//								objEmployeeOvernightTripBenefit.Add(overnightTripBenefit);
//							}
//						}
//						fillEmployeeOvernightTripBenefit(ref objEmployeeOvernightTripBenefit, value.Company, dataReader);
//					}
//					objEmployeeOvernightTripBenefit = null;
//				}
//			}
//			catch(IndexOutOfRangeException ein)
//			{
//				throw ein;
//			}
//			finally
//			{
//				tableAccess.CloseDataReader();				
//			}
//			return result;
//		}

		//		private string getCondition(YearMonth aYearMonth, Employee aEmployee)
		//		{
		//			StringBuilder stringBuilder = new StringBuilder(getBaseCondition(aEmployee));
		//
		//			if (IsNotNULL(aYearMonth))
		//			{
		//				stringBuilder.Append(" AND ");
		//				stringBuilder.Append("(");
		//				stringBuilder.Append(SqlFunction.GetYearMonthCondition("From_Date",  aYearMonth));
		//				stringBuilder.Append(" OR ");
		//				stringBuilder.Append(SqlFunction.GetYearMonthCondition("To_Date", aYearMonth));
		//				stringBuilder.Append(")");
		//			}
		//
		//			return stringBuilder.ToString();
		//		}

//		#region
//		//		============================== BATCH SQL COMMAND ==============================
//		private string getSQLInsert(EmployeeOvernightTripBenefit aEmployeeOvernightTripBenefit)
//		{
//			string temp;
//			StringBuilder stringBuilder = new StringBuilder("BEGIN ");
//			for(int i=0; i<aEmployeeOvernightTripBenefit.Count; i++)
//			{
//				temp = getSQLInsert(aEmployeeOvernightTripBenefit[i], aEmployeeOvernightTripBenefit.AOvernightTrip, aEmployeeOvernightTripBenefit.Employee, aEmployeeOvernightTripBenefit.Company);
//				stringBuilder.Append(temp);
//				stringBuilder.Append(";");
//			}
//			stringBuilder.Append(" END;");
//
//			return stringBuilder.ToString();
//		}
//
//		private string getSQLUpdate(EmployeeOvernightTripBenefit aEmployeeOvernightTripBenefit)
//		{
//			string temp;
//			StringBuilder stringBuilder = new StringBuilder("BEGIN ");
//			for(int i=0; i<aEmployeeOvernightTripBenefit.Count; i++)
//			{
//				temp = getSQLUpdate(aEmployeeOvernightTripBenefit[i], aEmployeeOvernightTripBenefit.AOvernightTrip, aEmployeeOvernightTripBenefit.Employee, aEmployeeOvernightTripBenefit.Company);
//				stringBuilder.Append(temp);
//				stringBuilder.Append(getCondition(aEmployeeOvernightTripBenefit[i], aEmployeeOvernightTripBenefit.AOvernightTrip, aEmployeeOvernightTripBenefit.Employee));
//				stringBuilder.Append(";");
//			}
//			stringBuilder.Append(" END;");
//
//			return stringBuilder.ToString();
//		}
//		//		============================== Execute COMMAND ==============================
//		private OvernightTrip getOvernightTrip(SqlDataReader dataReader)
//		{
//			aOvernightTrip = new OvernightTrip();
//			aOvernightTrip.ATripLocation = (TripLocation)dbTripLocation.GetMTB((string)dataReader[TO_LOCATION]);
//			aOvernightTrip.APeriod.From = dataReader.GetDateTime(FROM_DATE);
//			aOvernightTrip.APeriod.To = dataReader.GetDateTime(TO_DATE);
//			return aOvernightTrip;
//		}
//
//		private OvernightTripBenefit getOvernightTripBenefit(SqlDataReader dataReader)
//		{
//			aOvernightTripBenefit = new OvernightTripBenefit();
//			aOvernightTripBenefit.BenefitDate = dataReader.GetDateTime(BENEFIT_DATE);
//			aOvernightTripBenefit.TotalAmount = dataReader.GetDecimal(BENEFIT_AMOUNT);
//			aOvernightTripBenefit.ABenefitPayment.PaymentStatus = CTFunction.GetPaymentStatusType((string)dataReader[PAYMENT_STATUS]);
//
//			if(dataReader.IsDBNull(PAYMENT_DATE))
//			{
//				aOvernightTripBenefit.ABenefitPayment.PaymentDate = NullConstant.DATETIME;
//			}
//			else
//			{
//				aOvernightTripBenefit.ABenefitPayment.PaymentDate = dataReader.GetDateTime(PAYMENT_DATE);	
//			}
//
//			return aOvernightTripBenefit;
//		}
//		#endregion
//
//		#region - Fill -
//		private bool fillEmployeeOvernightTripBenefitList(ref EmployeeOvernightTripBenefitList value, string sql)
//		{
//			bool result = false;
//			Employee aEmployee = value.Employee;
//
//			OvernightTrip overnightTrip;
//			OvernightTripBenefit overnightTripBenefit;
//
//			EmployeeOvernightTripBenefit aEmployeeOvernightTripBenefit;
//
//			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
//			try
//			{
//				if (dataReader.Read())
//				{
//					result = true;
//
//					overnightTrip = getOvernightTrip(dataReader);
//					overnightTripBenefit = getOvernightTripBenefit(dataReader);
//
//					aEmployeeOvernightTripBenefit = new EmployeeOvernightTripBenefit(value.ForYearMonth, aEmployee);
//					aEmployeeOvernightTripBenefit.AOvernightTrip = overnightTrip;
//					aEmployeeOvernightTripBenefit.Add(overnightTripBenefit);
//
//					while(dataReader.Read())
//					{
//						overnightTrip = getOvernightTrip(dataReader);
//						overnightTripBenefit = getOvernightTripBenefit(dataReader);
//						if (aEmployeeOvernightTripBenefit.AOvernightTrip.Equals(overnightTrip))
//						{
//							aEmployeeOvernightTripBenefit.Add(overnightTripBenefit);
//						}
//						else
//						{
//							value.Add(aEmployeeOvernightTripBenefit);
//
//							aEmployeeOvernightTripBenefit = new EmployeeOvernightTripBenefit(value.ForYearMonth, aEmployee);
//							aEmployeeOvernightTripBenefit.AOvernightTrip = overnightTrip;
//							
//							aEmployeeOvernightTripBenefit.Add(overnightTripBenefit);
//						}
//					}
//					value.Add(aEmployeeOvernightTripBenefit);
//				}
//				else
//				{
//					result = false;
//				}
//			}
//			catch (IndexOutOfRangeException ein)
//			{
//				throw ein;
//			}
//			finally
//			{
//				tableAccess.CloseDataReader();
//			}			
//			return result;				
//		}
//
//		#endregion
		#endregion
	}
}
