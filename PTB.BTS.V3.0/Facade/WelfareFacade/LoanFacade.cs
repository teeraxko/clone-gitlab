using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.LoanEntities;
using ictus.PIS.Welfare.Flow.LoanFlows;
using ictus.PIS.PI.Entity;

namespace PTB.PIS.Welfare.Facade
{
    public class LoanFacade : FacadeBase
    {
        public static void UpdateLoanReson(LoanReson loanReson, Status status)
        {
            try
            {
                bool isComplete = false;
                switch (status)
                {
                    case Status.Idle:
                        break;
                    case Status.Insert:
                        isComplete = new LoanResonFlow().Insert(loanReson);
                        break;
                    case Status.Update:
                        isComplete = new LoanResonFlow().Update(loanReson);
                        break;
                    case Status.Delete:
                        isComplete = new LoanResonFlow().Delete(loanReson);
                        break;
                    default:
                        break;
                }
                if (!isComplete) throw new Exception("Cant Update Data");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<LoanReson> GetAllLoanReson()
        {
            try
            {
                return new LoanResonFlow().FillAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<LoanApplication> GetLoanApplicationByEmployee(Employee employee)
        {
            try
            {
                return new LoanApplicationFlow().FillData(CurrentCompany, employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<LoanInstallmentDetail> GetDetailByApp(LoanApplication app)
        {
            try
            {
                return new LoanApplicationFlow().GetInstallmentByApp(CurrentCompany, app);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void UpdateLoanApplication(LoanApplication app, List<LoanInstallmentDetail> details, Status status)
        {
            try
            {
                bool isComplete = false;
                switch (status)
                {
                    case Status.Idle:
                        break;
                    case Status.Insert:
                        isComplete = new LoanApplicationFlow().Insert(CurrentCompany, app, details);
                        break;
                    case Status.Update:
                        isComplete = new LoanApplicationFlow().Update(CurrentCompany, app, details);
                        break;
                    case Status.Delete:
                        isComplete = new LoanApplicationFlow().Delete(CurrentCompany, app);
                        break;
                    default:
                        break;
                }
                if (!isComplete) throw new Exception("Cant Update Data");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void OffsetLoanApplication(LoanApplication app, List<LoanInstallmentDetail> details)
        {
            bool isComplete = false;
            try
            {
                isComplete = new LoanApplicationFlow().Offset(CurrentCompany, app, details);
                if (!isComplete) throw new Exception("Cant Offset Data");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return isComplete;
        }

        public static List<LoanInstallmentDetail> GetNewLoanInstallmentDetail(LoanApplication app)
        {
            try
            {
                return new LoanApplicationFlow().GenerateInstallment(app);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EmployeeInfo GetEmployeeInfo(string employeeNo)
        {
            return new PTB.BTS.PI.Flow.EmployeeFlow().GetEmployeeInfo(employeeNo, CurrentCompany);
        }
    }
}
