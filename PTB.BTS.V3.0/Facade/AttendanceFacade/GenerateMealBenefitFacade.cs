using System;
using System.Collections;
using System.Data;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Flow.AttendanceFlow;
using PTB.BTS.PI.Flow;

using Facade.PiFacade;
using System.Collections.Generic;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;

namespace Facade.AttendanceFacade
{
	public class GenerateMealBenefitFacade : CommonPIFacadeBase
	{
        private GenerateMealBenefitFlow flowMealAllowanceCondition;
        public List<EmployeeMealAllowance> data = new List<EmployeeMealAllowance>();
        public List<EmployeeMealAllowance> additionalStaff = new List<EmployeeMealAllowance>();
        public List<Employee> NewEmployeeList = new List<Employee>();
        public bool IsExistPayment = false;

        public GenerateMealBenefitFacade()
		{
            this.flowMealAllowanceCondition = new GenerateMealBenefitFlow();
		}

        public void Calculate(Company company, DateTime benefitDate)
        {
            this.data = this.flowMealAllowanceCondition.Calculate(company, benefitDate);
        }

        public void AdditionalStaffForGenerateMealBenefit(Company company, DateTime benefitDate)
        {
            this.additionalStaff = this.flowMealAllowanceCondition.AdditionalStaffForGenerateMealBenefit(company, benefitDate);
        }

        public void CheckIsExistPayment(Company company, YearMonth benefitDate)
        {
            this.IsExistPayment = this.flowMealAllowanceCondition.CheckIsExistPayment(company, benefitDate);
        }

        public void Save(Company company, YearMonth benefitDate)
        {
            this.flowMealAllowanceCondition.Save(data, company, benefitDate);
        }

        public List<EmployeeMealAllowance> Get(Company company, YearMonth benefitDate)
        {
            return this.flowMealAllowanceCondition.Get(company, benefitDate);
        }
	}
}
