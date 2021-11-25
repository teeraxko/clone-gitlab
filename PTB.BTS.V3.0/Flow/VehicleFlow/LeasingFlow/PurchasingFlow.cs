using System;
using Entity.VehicleEntities.Leasing;
using PTB.BTS.Common.Flow;
using DataAccess.VehicleDB;
using ictus.Common.Entity;
using DataAccess.CommonDB;
using System.Data.SqlClient;

namespace Flow.VehicleEntities.Leasing
{
    public class PurchasingFlow : FlowBase
    {
        VehiclePurchasingDB dbVehiclePurchasing;

        //============================== Constructor ==============================
        public PurchasingFlow()
            : base()
        {
            dbVehiclePurchasing = new VehiclePurchasingDB();
        }

        //============================== Public Method ==============================
        public bool FillPO(IPurchasing iPurchasing, Company company)
        {
            return dbVehiclePurchasing.FillPO(iPurchasing, company);
        }

        public bool InsertPO(IPurchasing purchasing, Company company)
        {
            bool result = true;
            TableAccess tableAccess = new TableAccess();
            VehicleLeasingCalDB dbVehicleLeasing = new VehicleLeasingCalDB();

            try
            {
                tableAccess.OpenTransaction();
                dbVehicleLeasing.TableAccess = tableAccess;
                dbVehiclePurchasing.TableAccess = tableAccess;

                result &= dbVehiclePurchasing.InsertPO(purchasing, company);

                ((Quotation)purchasing).PONo = purchasing.PurchaseNo.ToString();
                result &= dbVehicleLeasing.UpdateQuotation((Quotation)purchasing, company);

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

        public bool UpdatePO(IPurchasing iPurchasing, Company company)
        {
            return dbVehiclePurchasing.UpdatePO(iPurchasing, company);
        }

        public bool UpdatePOIssueDate(Entity.ContractEntities.DocumentNo poNo, DateTime issueDate, Company company)
        {
            return dbVehiclePurchasing.UpdatePOIssueDate(poNo, issueDate, company);
        }

        public bool DeleteQuotationPO(IPurchasing purchasing, Company company)
        {
            bool result = true;
            TableAccess tableAccess = new TableAccess();
            VehicleLeasingCalDB dbVehicleLeasing = new VehicleLeasingCalDB();

            try
            {
                tableAccess.OpenTransaction();
                dbVehicleLeasing.TableAccess = tableAccess;
                dbVehiclePurchasing.TableAccess = tableAccess;

                result &= dbVehiclePurchasing.UpdatePOStatus(purchasing, company);

                ((Quotation)purchasing).PONo = "";
                result &= dbVehicleLeasing.UpdateQuotation((Quotation)purchasing, company);

                purchasing.PurchaseNo = null;

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
