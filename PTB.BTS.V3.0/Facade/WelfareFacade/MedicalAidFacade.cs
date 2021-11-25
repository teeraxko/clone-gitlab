using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.MedicalAidEntities;
using ictus.PIS.Welfare.Flow.MedicalAidFlows;
using ictus.Common.Entity.Health;
using ictus.PIS.PI.Entity;
using ictus.PIS.Welfare.Entity.CommonEntities;

namespace PTB.PIS.Welfare.Facade {
    public class MedicalAidFacade : FacadeBase {

        public static List<Hospital> GetListOfAllHospital() {
            return new HospitalFlow().FillAll();
        }
        public static List<Hospital> GetListOfContractHospital() {
            return new HospitalFlow().FillContractHospital();
        }
        public static Hospital GetHospitalByKey(string code) {
            return new HospitalFlow().FillByKey(code);
        }
        public static void UpdateHospital(Hospital aHospital, Status status) {
            try {
                bool isComplete = false;
                switch (status) {
                    case Status.Idle:
                        break;
                    case Status.Insert:
                        isComplete = new HospitalFlow().Insert(aHospital);
                        break;
                    case Status.Update:
                        isComplete = new HospitalFlow().Update(aHospital);
                        break;
                    case Status.Delete:
                        isComplete = new HospitalFlow().Delete(aHospital);
                        break;
                    default:
                        break;
                }
                if (!isComplete) throw new Exception("Cant Update Data");

            } catch (Exception ex) {

                throw ex;
            }
        }


        public static List<MedicalAidFor> GetListOfAllMedicalAidFor() {
            return new MedicalAidApplicationFlowBase().FillAllMedicalAidFor();
        }

        public static List<MedicalAidType> GetListOfAllMedicalAidType() {
            return new MedicalAidApplicationFlowBase().FillAllMedicalAidType();
        }

        public static List<Disease> GetListOfAllDisease() {
            return new MedicalAidApplicationFlowBase().FillAllDisease();
        }

        public static List<MedicalAidApplication> GetOfApplicationByEmp(Employee emp) {
            return new MedicalAidApplicationByEmpFlow().FillData(CurrentCompany, emp);
        }

        public static List<MedicalAidApplication> GetOfApplicationByHospitalPeriod(Hospital hospital, DateTime period) {
            return new MedicalAidApplicationByHospitalFlow().FillData(CurrentCompany, hospital, period);
        }

        public static List<MedicalAidApplication> GetOfApplicationByHospitalPeriodRefDoc(Hospital hospital, DateTime period, string referenceDocumentNo) 
        {
            List<MedicalAidApplication> items = new MedicalAidApplicationByHospitalFlow().FillData(CurrentCompany, hospital, period);
            List<MedicalAidApplication> selectItems = new List<MedicalAidApplication>();
            foreach (MedicalAidApplication app in items) {
                if (app.InvoiceNo.Trim() == referenceDocumentNo.Trim()) {
                    selectItems.Add(app);
                }
            }
            return selectItems;
        }

        public static List<string> GetOfRefDocumentNoByHospitalPeriod(Hospital hospital, DateTime period) {
            return new MedicalAidApplicationByHospitalFlow().FillDocumentNo(CurrentCompany, hospital, period);
        }


        public static void UpdateMedicalAidApplication(MedicalAidApplication app, Status status) {
            try {
                bool isComplete = false;
                switch (status) {
                    case Status.Idle:
                        break;
                    case Status.Insert:
                        isComplete = new MedicalAidApplicationFlowBase().Insert(CurrentCompany, app);
                        break;
                    case Status.Update:
                        isComplete = new MedicalAidApplicationFlowBase().Update(CurrentCompany, app);
                        break;
                    case Status.Delete:
                        isComplete = new MedicalAidApplicationFlowBase().Delete(CurrentCompany, app);
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
