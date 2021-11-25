using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;
using System.Collections.Generic;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;
using System.Data.SqlClient;

namespace Flow.AttendanceFlow
{
	public class GenerateMealBenefitFlow : FlowBase
	{
		#region - Private -
        private GenerateMealBenefitDB dbMealAllowanceCondition;
		#endregion - Private -

//		============================== Constructor ==============================
        public GenerateMealBenefitFlow()
            : base()
		{
            this.dbMealAllowanceCondition = new GenerateMealBenefitDB();
		}

        public List<EmployeeMealAllowance> Calculate(Company company, DateTime benefitDate)
        {
            return this.dbMealAllowanceCondition.Calculate(company, benefitDate);
        }

        public bool CheckIsExistPayment(Company company, YearMonth benefitDate)
        {
            return this.dbMealAllowanceCondition.CheckIsExistPayment(company, benefitDate);
        }

        public List<EmployeeMealAllowance> Get(Company company, YearMonth benefitDate)
        {
            return this.dbMealAllowanceCondition.Get(company, benefitDate);
        }

        public List<EmployeeMealAllowance> AdditionalStaffForGenerateMealBenefit(Company company, DateTime benefitDate)
        {
            return this.dbMealAllowanceCondition.AdditionalStaffForGenerateMealBenefit(company, benefitDate);
        }

        public void Save(List<EmployeeMealAllowance> data, Company company, YearMonth benefitDate)
        {
            TableAccess tableAccess = new TableAccess();

            try
            {
                tableAccess.OpenTransaction();
                this.dbMealAllowanceCondition.Save(data, company, benefitDate);

                tableAccess.CommitTransaction();
            }
            catch (SqlException ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                tableAccess.CloseConnection();
            }
        }
	}
}
