using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.PIS.Welfare.Flow.MedicalAidFlows;
using ictus.PIS.Welfare.Entity.CommonEntities;
using PTB.BTS.PI.Flow;

namespace PTB.PIS.Welfare.Facade
{
    public class EmployeeFacade : FacadeBase
    {
        public static Employee GetEmployeeByEmpCode(string code)
        {
            try
            {
                if (code.Trim().Length > 0)
                {

                    Employee emp = new Employee(code, CurrentCompany);
                    EmployeeFlow flow = new EmployeeFlow();
                    flow.FillAvailableEmployee(emp, DateTime.Now.Date);
                    return emp;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string tempEx = ex.Message;
                return null;
            }
        }

        public static EmployeeList GetAllAvaliableEmployee()
        {
            EmployeeList emps = new EmployeeList(CurrentCompany);
            EmployeeFlow flow = new EmployeeFlow();
            flow.FillAvailableEmployeeList(emps, DateTime.Now.Date);
            return emps;
        }

        public static List<Prefix> GetAllPrefix()
        {
            return new MedicalAidApplicationFlowBase().FillAllPrefix();
        }

        public static List<Person> GetSpouse(Employee employee)
        {
            List<Person> result = new MedicalAidApplicationByEmpFlow().FillSpouse(CurrentCompany, employee);
            if (result.Count > 0)
                return result;
            else
                return null;
        }

        public static List<Person> GetChildren(Employee employee)
        {
            List<Person> result = new MedicalAidApplicationByEmpFlow().FillChildren(CurrentCompany, employee);
            if (result.Count > 0)
                return result;
            else
                return null;
        }
    }
}
