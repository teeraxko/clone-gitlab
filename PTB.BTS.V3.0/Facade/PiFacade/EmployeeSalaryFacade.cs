using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facade.CommonFacade;
using ictus.PIS.PI.Entity;
using PTB.BTS.PI.Flow;
using System.Collections;
using Flow.PiFlow;

namespace Facade.PiFacade
{
    public class EmployeeSalaryFacade : CommonPIFacadeBase
    {
        public EmployeeList GetAllEmployeeList()
        {
            EmployeeList employeeList = new EmployeeList(GetCompany());

            using (EmployeeFlow flow = new EmployeeFlow())
            {
                if (flow.FillAllEmployeeList(employeeList))
                {
                    return employeeList;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool ImportEmployeeSalary(Hashtable salaryData)
        {
            using (EmployeeSalaryFlow flow = new EmployeeSalaryFlow())
            {
                return flow.ImportEmployeeSalary(salaryData);
            }
        }
    }
}
