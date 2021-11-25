using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using DataAccess.CommonDB;
using DataAccess.VehicleDB.VehicleLeasingDB;

using Entity.VehicleEntities;
using Entity.ContractEntities;
using Entity.VehicleEntities.VehicleLeasing;

using Flow.VehicleFlow.LeasingFlow;
using Flow.ContractFlow;

using ictus.Framework.ASC.VBFuntion;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using PTB.BTS.Common.Flow;


namespace Flow.VehicleFlow.VehicleLeasingFlow
{
    public class VehicleQuotationFlow : FlowBase
    {
        #region Private
        private VehicleQuotationDB dbVehicleQuotation;
        private VehicleCalculationDB dbVehicleCalculation;
        #endregion

        #region Constructor

        public VehicleQuotationFlow()
            : base()
        {
            dbVehicleCalculation = new VehicleCalculationDB();
            dbVehicleQuotation = new VehicleQuotationDB();
        }

        #endregion

        #region Public Method

        public List<VehicleQuotation> FillQuotation(Customer aCustomer, Brand aBrand, Model aModel, DocumentNo quotationNo, DateTime aIssueDate, Company aCompany)
        {
            using (VehicleQuotationDB db = new VehicleQuotationDB())
            {
                return db.FillQuotation(aCustomer, aBrand, aModel, quotationNo, aIssueDate, aCompany);
            }
        }

        public List<VehicleQuotation> FillQuotationPurchase(DocumentNo quotationNo,DateTime aIssueDate, Company aCompany)
        {
            using (VehicleQuotationDB db = new VehicleQuotationDB())
            {
                
                return db.FillQuotationPurchase(quotationNo, aIssueDate, aCompany);
            }
        }

        public List<VehicleQuotation> GetQuotationListByQuotationNo(string quotationNo, Company aCompany)
        {
            using (VehicleQuotationDB dbVehicleQuotation = new VehicleQuotationDB())
            {
                return dbVehicleQuotation.GetQuotationListByQuotationNo(quotationNo, aCompany);
            }
        }

        public VehicleQuotation GetQuotationtByQuotationNo(string quotationNo, Company aCompany)
        {
            using (VehicleQuotationDB dbVehicleQuotation = new VehicleQuotationDB())
            {
                VehicleQuotation result = dbVehicleQuotation.GetQuotationByQuotationNo(quotationNo, aCompany);
                GetOtherInfo(result,aCompany);
                return result;
            }
        }



        public bool UpdateVehicleLeasing(VehicleCalculation vehicleCalculation, Company aCompany)
        {
            TableAccess tableAccess = new TableAccess();
            bool result = true;
            try
            {
                tableAccess.OpenTransaction();
                dbVehicleQuotation.TableAccess = tableAccess;
                dbVehicleCalculation.TableAccess = tableAccess;
                result &= dbVehicleCalculation.UpdateVehicleCalculationByQuotationNo(vehicleCalculation, aCompany);

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
            finally
            {
                tableAccess.CloseConnection();
            }

            return result;
        }





        /// <summary>
        /// Method      : Issue Contract
        ///             : Insert VehicleQuotation
        ///             : Insert VehicleCalculation
        ///             : Update VehicleCalculation
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        /// <param name="vehicleCalculation"></param>
        /// <param name="aCompany"></param>
        /// <returns>true if peocess success</returns>
        public bool InsertVehicleQuotation(VehicleCalculation vehicleCalculation, Company aCompany)
        {
            bool result = true;
            string contractNo = "";
            TableAccess tableAccess = new TableAccess();
            try
            {
                tableAccess.OpenTransaction();
                dbVehicleQuotation.TableAccess = tableAccess;
                dbVehicleCalculation.TableAccess = tableAccess;
                if (vehicleCalculation.Quotation.QuotationStatus != Entity.CommonEntity.QUOTATION_STATUS_TYPE.NEWQ)
                {
                    using (PTB.BTS.Contract.Flow.ContractFlow flow = new PTB.BTS.Contract.Flow.ContractFlow())
                    {
                        contractNo = flow.IssueContractByQuotation(vehicleCalculation, aCompany, tableAccess);

                    }
                    vehicleCalculation.Quotation.VehicleContract.ContractNo = new DocumentNo(contractNo);
                }
                
                result &= dbVehicleQuotation.InsertVehicleQuotation(vehicleCalculation.Quotation, aCompany);
                
                if (vehicleCalculation.Quotation.QuotationStatus != Entity.CommonEntity.QUOTATION_STATUS_TYPE.NEWQ)
                {
                    result &= dbVehicleCalculation.InsertVehicleCalculationByQuotation(vehicleCalculation, aCompany);
                }
                else
                {
                    result &= dbVehicleCalculation.UpdateVehicleCalculationByQuotationNo(vehicleCalculation, aCompany);
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

                dbVehicleQuotation = null;
                dbVehicleCalculation = null;
            }
            catch (SqlException ex)
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

        public bool UpdateVehicleQuotation(VehicleQuotation vehicleQuotation)
        {
            using (VehicleQuotationDB dbVehicleQuotation = new VehicleQuotationDB())
            {
                return dbVehicleQuotation.UpdateVehicleQuotation(vehicleQuotation);
            }
        }

        /// <summary>
        /// Method      : Update vehicle calculation to null quotation no.
        ///             : Delete vehicle quotation
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool DeleteVehicleQuotation(VehicleQuotation value)
        {
            bool result = true; ;
            TableAccess tableAccess = new TableAccess();
            try
            {
                tableAccess.OpenTransaction();
                dbVehicleQuotation.TableAccess = tableAccess;
                dbVehicleCalculation.TableAccess = tableAccess;

                result &= dbVehicleCalculation.UpdateVehicleCalculationToNullQuotationNo(value);
                result &= dbVehicleQuotation.DeleteVehicleQuotation(value);

                if (result)
                {
                    tableAccess.Transaction.Commit();
                    result = true;
                }
                else
                {
                    tableAccess.Transaction.Rollback();
                }

                dbVehicleQuotation = null;
                dbVehicleCalculation = null;
            }
            catch (SqlException ex)
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

        #endregion
        private void GetOtherInfo(VehicleQuotation quotation, Company comp)
        {
            if (quotation.VehicleContract.ContractNo != null)
            {
                using (VehicleContractFlow flow = new VehicleContractFlow())
                {
                    quotation.VehicleContract = flow.GetVehicleContract(quotation.VehicleContract.ContractNo, comp);
                }   
            }

            if (quotation.KindOfVehicle != null)
            {
                //Fill Kind of vehicle : woranai 2008/12/04
                using (DataAccess.VehicleDB.KindOfVehicleDB dbKindOfVehilce = new DataAccess.VehicleDB.KindOfVehicleDB())
                {
                    dbKindOfVehilce.FillMTB(quotation.KindOfVehicle, comp);
                }
            }
        }
    }
}
