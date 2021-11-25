using System;

using PTB.BTS.BTS2BizPacDB.BizPacImplementDB;
using PTB.BTS.BTS2BizPacEntity;
using DataAccess.CommonDB;
using ictus.Common.Entity;
using DataAccess.PTB.BTS.BTS2BizPacDB.BizPacReportDB;
using PTB.BTS.BTS2BizPacFlow.ServiceStaffDebitNoteCreateFlow;
using PTB.BTS.Attendance.BenefitChargeFlow;
using PTB.BTS.Attendance.BenefitChargeEntities;
using System.Text;
using PTB.BTS.Vehicle.Flow;

namespace PTB.BTS.BTS2BizPacFlow.ServiceStaffContractChargeFlow
{
    public class ServiceStaffContractChargeBPFlow : BTS2BizPacConnectFlow
    {
        private SDNCreaterManager SDNCreaterManager;

        //============================== Constructor ==============================
        public ServiceStaffContractChargeBPFlow()
            : base()
        {
            dbConnect = new ContractChargeDetailBPDB(ContractChargeDetailBPDB.CONTRACTTYPEBP.SERVICESTAFF);
        }

        //============================== Protected method ==============================
        VATRate vat;
        protected override bool SpecificConnect(BTS2BizPacList listBP, BTS2BizPacList resultListBTS, BTS2BizPacList resultListBP)
        {
            SDNCreaterManager = new SDNCreaterManager();
            SDNCreaterManager.RefFlow = this;
            ServiceStaffContractChargeBP serviceStaffContractChargeBP;

            for (int i = 0; i < listBP.Count; i++)
            {
                serviceStaffContractChargeBP = (ServiceStaffContractChargeBP)listBP[i];
                BenefitChargeFlow.OtherServiceStaffCharge(serviceStaffContractChargeBP);

                if (vat == null)
                {
                    vat = VehicleFunction.GetVATRate();
                }
                serviceStaffContractChargeBP.VATAmount = Math.Round(serviceStaffContractChargeBP.Amount * vat.Rate / 100m, 2);

                SDNCreaterManager.Add(serviceStaffContractChargeBP);
                resultListBTS.Add((IBTS2BizPacHeader)serviceStaffContractChargeBP);
            }

            SDNCreaterManager.FillServiceStaffDebitNote(resultListBP);
            listBP.Clear();
            return true;
        }

        protected override bool TRConnect(BTS2BizPacList listBP, TableAccess tableAccess, Company company)
        {
            bool result = false;
            TrServiceStaffDNAttachDB dbTrServiceStaffDNAttach = new TrServiceStaffDNAttachDB();
            StringBuilder insertBuilder = new StringBuilder();

            foreach (ServiceStaffContractChargeBP staffBP in listBP)
            {
                staffBP.Line = 1;
                insertBuilder.Append(dbTrServiceStaffDNAttach.SpecificInsertTrServiceStaffDNAttach(staffBP));
            }

            dbTrServiceStaffDNAttach.TableAccess = tableAccess;
            dbTrServiceStaffDNAttach.DeleteTrServiceStaffDNAttach();
            result = dbTrServiceStaffDNAttach.ExecuteSQLCommand(insertBuilder.ToString());

            insertBuilder = null;
            return result;
        }

        // [TODO] Kriangkrai A. 14/2/2018
        protected override string GenerateCSV2SAP(BTS2BizPacList listBP, DateTime connectDate)
        {
            return string.Empty;
        }
    }
}
