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

using ictus.Common.Entity;
using System.Collections.Generic;
using ictus.Common.Entity.Time;

namespace DataAccess.AttendanceDB
{
	public class GenerateMealBenefitDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
        private const int BENEFIT_YEAR = 1;
        private const int BENEFIT_MONTH = 2;
        private const int BENEFIT_AMOUNT = 3;
		#endregion

		#region - Private -
        private EmployeeMealAllowance employeeMealAllowance;
		private EmployeeDB dbEmployee;
		#endregion
		

        public GenerateMealBenefitDB()
            : base()
		{
			dbEmployee = new EmployeeDB();
		}

		private string getSQLSelect()
		{
            return "SELECT Employee_No, Benefit_Year, Benefit_Month, Benefit_Amount FROM Employee_Meal_Benefit";
		}

        private string IsExistPaymentSQL()
        {
            return "SELECT COUNT(*) FROM Non_Payroll_Payment_Control";
        }

        private string getSQLInsert(EmployeeMealAllowance value)
		{
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Meal_Benefit (Company_Code, Employee_No, Benefit_Year, Benefit_Month, Benefit_Amount, Payment_Status, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append("12");
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");

            //Benefit_Year
            stringBuilder.Append(GetDB(value.Benefit_Year));
            stringBuilder.Append(", ");

            //Benefit_Month
            stringBuilder.Append(GetDB(value.Benefit_Month));
            stringBuilder.Append(", ");

            //MealAllowance
			stringBuilder.Append(GetDB(value.MealAllowance));
			stringBuilder.Append(", ");

            //Payment Status
            stringBuilder.Append(GetDB("N"));
            stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLDelete()
		{
            return "DELETE FROM Employee_Meal_Benefit ";
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No ";
		}


        private List<EmployeeMealAllowance> LoadDataFromDB(Company company, string sql)
		{
            List<EmployeeMealAllowance> data = new List<EmployeeMealAllowance>();
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);

			try
			{
				while (dataReader.Read())
				{
                    employeeMealAllowance = new EmployeeMealAllowance();
                    employeeMealAllowance.AEmployee = dbEmployee.GetFormerlyEmployee((string)dataReader[EMPLOYEE_NO], company);
                    employeeMealAllowance.Benefit_Year = dataReader.GetInt16(BENEFIT_YEAR);
                    employeeMealAllowance.Benefit_Month = (int)dataReader.GetByte(BENEFIT_MONTH);
                    employeeMealAllowance.MealAllowance = dataReader.GetDecimal(BENEFIT_AMOUNT);
                    data.Add(employeeMealAllowance);
				}
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();				
			}

            return data;
		}

        private string getKeyCondition(YearMonth yearMonth)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (IsNotNULL(yearMonth.Year))
            {
                stringBuilder.Append(" AND (Benefit_Year = ");
                stringBuilder.Append(GetDB(yearMonth.Year));
                stringBuilder.Append(")");
            }

            if (IsNotNULL(yearMonth.Month))
            {
                stringBuilder.Append(" AND (Benefit_Month = ");
                stringBuilder.Append(GetDB(yearMonth.Month));
                stringBuilder.Append(")");
            }

            return stringBuilder.ToString();
        }

        private string getKeyConditionForCheckPayment(YearMonth yearMonth)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (IsNotNULL(yearMonth.Year))
            {
                stringBuilder.Append(" AND (YEAR(Payment_Date) = ");
                stringBuilder.Append(GetDB(yearMonth.Year));
                stringBuilder.Append(")");
            }

            if (IsNotNULL(yearMonth.Month))
            {
                stringBuilder.Append(" AND (MONTH(Payment_Date) = ");
                stringBuilder.Append(GetDB(yearMonth.Month));
                stringBuilder.Append(")");
            }

            stringBuilder.Append(" AND (Payment_Status = ");
            stringBuilder.Append(GetDB("Y"));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private void DeleteOldDataByYearMonth(Company company, YearMonth benefitDate)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(benefitDate));

            tableAccess.ExecuteSQL(stringBuilder.ToString());
        }

        private List<EmployeeMealAllowance> CreateListOfMealAllowanceStaffByEmpList(EmployeeList empList, Company company, DateTime benefitDate)
        {
            List<EmployeeMealAllowance> data = new List<EmployeeMealAllowance>();

            OtherBenefitRateDB otherBenefitRateDB = new OtherBenefitRateDB();
            OtherBenefitRate otherBenefitRate = new OtherBenefitRate();

            otherBenefitRate = otherBenefitRateDB.GetOtherBenefitRate(company);

            for (int index = 0; index < empList.Count; index++)
            {
                EmployeeMealAllowance employeeMealAllowance = new EmployeeMealAllowance();

                employeeMealAllowance.AEmployee = empList[index];
                employeeMealAllowance.Benefit_Month = benefitDate.Month;
                employeeMealAllowance.Benefit_Year = benefitDate.Year;
                employeeMealAllowance.MealAllowance = otherBenefitRate.MealAllowance;

                data.Add(employeeMealAllowance);
            }

            return data;
        }

        public List<EmployeeMealAllowance> Get(Company company, YearMonth benefitDate)
		{
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(benefitDate));
            stringBuilder.Append(getOrderby());

            return this.LoadDataFromDB(company, stringBuilder.ToString());
		}

        public bool CheckIsExistPayment(Company company, YearMonth benefitDate)
        {
            StringBuilder stringBuilder = new StringBuilder(IsExistPaymentSQL());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyConditionForCheckPayment(benefitDate));

            int paymentCount = Convert.ToInt32(tableAccess.ExecuteScalar(stringBuilder.ToString()));

            return paymentCount > 0;
        }


        public void Save(List<EmployeeMealAllowance> data, Company company, YearMonth benefitDate)
        {
            this.DeleteOldDataByYearMonth(company, benefitDate);

            foreach (EmployeeMealAllowance row in data)
            {
                StringBuilder stringBuilder = new StringBuilder(getSQLInsert(row));

                tableAccess.ExecuteSQL(stringBuilder.ToString());
            }
        }

        public List<EmployeeMealAllowance> Calculate(Company company, DateTime benefitDate)
        {
            List<EmployeeMealAllowance> data = new List<EmployeeMealAllowance>();
            EmployeeList empList = new EmployeeList(company);

            data = this.Get(company, new YearMonth(benefitDate));

            if (data == null
                || data.Count == 0)
            {
                if (dbEmployee.FillAvailableEmployeeListForNonPayroll(ref empList, benefitDate))
                {
                    data = this.CreateListOfMealAllowanceStaffByEmpList(empList, company, benefitDate);
                }
            }

            return data;
        }

        public List<EmployeeMealAllowance> AdditionalStaffForGenerateMealBenefit(Company company, DateTime benefitDate)
        {
            List<EmployeeMealAllowance> data = new List<EmployeeMealAllowance>();
            EmployeeList empList = new EmployeeList(company);

            if (dbEmployee.FillAvailableEmployeeListForAdditionalNonPayroll(ref empList, benefitDate))
            {
                data = this.CreateListOfMealAllowanceStaffByEmpList(empList, company, benefitDate);
            }

            return data;
        }

	}
}
