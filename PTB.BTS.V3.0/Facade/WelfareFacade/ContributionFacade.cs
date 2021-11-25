using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.ContributionEntities;
using ictus.PIS.Welfare.Flow;
using ictus.PIS.Welfare.Flow.ContributionFlows;
using ictus.PIS.PI.Entity;

namespace PTB.PIS.Welfare.Facade {
    public class ContributionFacade : FacadeBase{
        public static void UpdateContribution(Contribution aContribution, Status status) {
            try {
                bool isComplete = false;
                switch (status) {
                    case Status.Idle:
                        break;
                    case Status.Insert:
                        isComplete = new ContributionFlow().Insert(aContribution);
                        break;
                    case Status.Update:
                        isComplete = new ContributionFlow().Update(aContribution);
                        break;
                    case Status.Delete:
                        isComplete = new ContributionFlow().Delete(aContribution);
                        break;
                    default:
                        break;
                }
                if (!isComplete) throw new Exception("Cant Update Data");

            } catch (Exception ex)  {
                
                throw ex;
            }
        }
        
        public static List<Contribution> GetAllContributionList() {
            try {
                return new ContributionFlow().FillAll();

            } catch (Exception ex) {

                throw ex;
            }
        }


        public static List<ContributionApplication> FillContributionApplicationByEmployee(Employee emp) {
            return new ContributionApplicationFlow().FillByEmployee(CurrentCompany, emp);
        }

        public static void UpdateContributionApplication(ContributionApplication app, Status status) {
            try {
                bool isComplete = false;
                switch (status) {
                    case Status.Idle:
                        break;
                    case Status.Insert:
                        isComplete = new ContributionApplicationFlow().Insert(CurrentCompany, app);
                        break;
                    case Status.Update:
                        isComplete = new ContributionApplicationFlow().Update(CurrentCompany, app);
                        break;
                    case Status.Delete:
                        isComplete = new ContributionApplicationFlow().Delete(CurrentCompany, app);
                        break;
                    default:
                        break;
                }
                if (!isComplete) throw new Exception("Cant Update Data");

            } catch (Exception ex) {

                throw ex;
            }
        }


    }
}
