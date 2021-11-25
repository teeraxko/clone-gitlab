using System;
using PTB.BTS.Common.Flow;
using DataAccess.VehicleDB;
using Entity.VehicleEntities.Leasing;
using ictus.Common.Entity;
using DataAccess.CommonDB;
using System.Data.SqlClient;

namespace Flow.VehicleEntities.Leasing
{
    public class QuotationFlow : FlowBase
    {
        VehicleLeasingCalDB dbVehicleLeasing;

        //============================== Constructor ==============================
        public QuotationFlow() : base()
        {
            dbVehicleLeasing = new VehicleLeasingCalDB();
        }

        //============================== Public Method ==============================
        public bool FillQuotationMainList(QuotationList quotationList, DateTime fromIssueDate)
        {
            return dbVehicleLeasing.FillQuotationMainList(quotationList, fromIssueDate);
        }

        public bool FillQuotationMainList(QuotationList quotationList, Quotation quotation)
        {
            return dbVehicleLeasing.FillQuotationMainList(quotationList, quotation);
        }

        public bool FillQuotationDetail(Quotation quotation, Company company)
        {
            return dbVehicleLeasing.FillQuotationDetail(quotation, company);
        }

        public bool FillQuotation(Quotation quotation, Company company)
        {
            return dbVehicleLeasing.FillQuotation(quotation, company);
        }

        public bool InsertQuotation(Quotation quotation, Company company)
        {
            return dbVehicleLeasing.InsertQuotation(quotation, company);
        }

        public bool UpdateQuotation(Quotation quotation, Company company)
        {
            return dbVehicleLeasing.UpdateQuotation(quotation, company);
        }

        public bool UpdateQuotationIssueDate(Entity.ContractEntities.DocumentNo quotationNo, DateTime issueDate, Company company)
        {
            return dbVehicleLeasing.UpdateQuotationIssueDate(quotationNo, issueDate, company);
        }

        public bool DeleteQuotation(Quotation quotation, Company company)
        {
            bool result = true;
            TableAccess tableAccess = new TableAccess();
            VehiclePurchasingDB dbVehiclePO = new VehiclePurchasingDB();

            try
            {
                tableAccess.OpenTransaction();
                dbVehicleLeasing.TableAccess = tableAccess;
                dbVehiclePO.TableAccess = tableAccess;

                if (quotation.PONo != "")
                {
                    ((IPurchasing)quotation).PurchaseNo = new Entity.ContractEntities.DocumentNo(quotation.PONo);
                    result &= dbVehiclePO.DeletePO(quotation, company);
                }

                if (result)
                {
                    result &= dbVehicleLeasing.DeleteQuotation(quotation, company);
                }

                if (result)
                {
                    tableAccess.Transaction.Commit();
                    result = true;
                }
                else
                {
                    tableAccess.Transaction.Rollback();
                }
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

            return result;
        }
    }
}
