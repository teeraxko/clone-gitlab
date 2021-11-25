using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.VehicleEntities.VehicleLeasing;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

namespace DataAccess.VehicleDB.VehicleLeasingDB
{
    public class VehicleQuotationDB : DataAccess.CommonDB.DataAccessBase
    {
        #region StoreProcedure

        private const string STPROC_VEH_SEARCH_QUOTATION = "SVehicleSearchQuotation";
        private const string STPROC_VEH_SEARCH_QUOTATION_PURCHASE = "SVehicleSearchQuotationPurchase";
        private const string STPROC_VEH_SEARCH_QUOTATION_BY_QUOTAION_NO = "SVehicleSearchQuotationByQuotationNo";
        private const string STPROC_VEH_SEARCH_QUOTATION_BY_PURCHASE_NO = "SVehicleSearchQuotationByPurchaseNo";
        private const string STPROC_VEH_INSERT_QUOTATION = "SVehicleInsertQuotation";
        private const string STPROC_VEH_UPDATE_QUOTATION_BY_QUOTATION_NO = "SVehicleUpdateQuotationByQuotationNo";
        private const string STPROC_VEH_DELETE_QUOTATION = "SVehicleDeleteQuotation";
        private const string STPROC_VEH_SET_NULL_QUOTATION_BY_PO = "SVehicleSetNullQuotationByPO";
        private const string STPROC_VEH_UPDATE_QUOTATION_BY_PURCHASE_NO = "SVehicleUpdateQuotationByPurchaseNo";
        private const string STPROC_VEH_UPDATE_QUOTATION_BY_CONTRACT_NO = "SVehicleUpdateQuotationByContractNo";
        #endregion

        #region Constructor

        public VehicleQuotationDB()
            : base()
        {

        }
        #endregion

        #region Public Method

        public List<VehicleQuotation> FillQuotation(Customer aCustomer, Brand aBrand, Model aModel, DocumentNo quotationNo, DateTime aIssueDate, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_QUOTATION);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Customer_Code", aCustomer != null ? DBValue(aCustomer.Code) : DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Brand_Code", aBrand != null ? DBValue(aBrand.Code) : DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Model_Code", aModel != null ? DBValue(aModel.Code) : DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", quotationNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Issue_Date", aIssueDate));

            return FillList(command, aCompany);

        }

        public List<VehicleQuotation> FillQuotationPurchase(DocumentNo quotationNo, DateTime aIssueDate, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_QUOTATION_PURCHASE);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", quotationNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Issue_Date", aIssueDate));

            return FillList(command, aCompany);
        }

        public VehicleQuotation GetQuotationByPurchaseNo(DocumentNo purchaseNo, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_QUOTATION_BY_PURCHASE_NO);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Purchase_No", purchaseNo.ToString()));
            
            return Fill(command, aCompany);
        }

        private List<VehicleQuotation> FillList(SqlCommand command, Company aCompany)
        {
            List<VehicleQuotation> result = new List<VehicleQuotation>();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);

            using (ContractDB.CustomerDB dbCus = new ContractDB.CustomerDB())
            using (ModelDB dbMod = new ModelDB())

                try
                {
                    while (dataReader.Read())
                    {
                        VehicleQuotation entity = new VehicleQuotation();
                        FillDetail(entity, dataReader);

                        result.Add(entity);
                    }
                }
                catch (IndexOutOfRangeException ein)
                {
                    throw ein;
                }
                finally
                {
                    if (command.Connection.State != ConnectionState.Closed)
                    {
                        command.Connection.Close();
                    }

                    dataReader.Close();
                    tableAccess.CloseDataReader();
                }
            return result;
        }

        private VehicleQuotation Fill(SqlCommand command, Company aCompany)
        {
            VehicleQuotation entity = new VehicleQuotation();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);

            using (ContractDB.CustomerDB dbCus = new ContractDB.CustomerDB())
            using (ModelDB dbMod = new ModelDB())

                try
                {
                    while (dataReader.Read())
                    {
                        FillDetail(entity, dataReader);
                    }
                }
                catch (IndexOutOfRangeException ein)
                {
                    throw ein;
                }
                finally
                {
                    if (command.Connection.State != ConnectionState.Closed)
                    {
                        command.Connection.Close();
                    }

                    dataReader.Close();
                    tableAccess.CloseDataReader();
                }
            return entity;
        }

        public List<VehicleQuotation> GetQuotationListByQuotationNo(string quotationNo, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_QUOTATION_BY_QUOTAION_NO);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", quotationNo));

            return FillList(command, aCompany);
        }

        public VehicleQuotation GetQuotationByQuotationNo(string quotationNo, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_QUOTATION_BY_QUOTAION_NO);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", quotationNo));

            return Fill(command, aCompany);
        }

        /// <summary>
        /// Method      : Fill calculation detail to object
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="dataReader"></param>
        private void FillDetail(VehicleQuotation entity, SqlDataReader dataReader)
        {
            entity.Purchasing = new VehiclePurchasing();
            entity.VehicleContract = new VehicleContract();
            entity.KindOfVehicle = new KindOfVehicle();

            if (dataReader.IsDBNull(1))
            {
                entity.QuotationNo = null;
            }
            else
            {
                entity.QuotationNo = new DocumentNo((string)(dataReader["Quotation_No"]));
            }
            if (dataReader.IsDBNull(2))
            {
                entity.Purchasing.PurchasNo = null;
            }
            else
            {
                entity.Purchasing.PurchasNo = new DocumentNo((string)(dataReader["Purchase_No"]));
            }
            if (dataReader.IsDBNull(3))
            {
                entity.VehicleContract.ContractNo = null;
            }
            else
            {
                entity.VehicleContract.ContractNo = new DocumentNo((string)(dataReader["Contract_No"]));
            }
            entity.ValidityDate = (DateTime)dataReader["Validity_Date"];
            entity.IssueDate = (DateTime)dataReader["Issue_Date"];
            entity.DeliveryDays = dataReader.GetByte(6);
            entity.IsCustomerAccept = (string)dataReader["Customer_Accept"] == "Y" ? true : false;
            entity.IsSecondHand = (string)dataReader["Second_Hand_Status"] == "Y" ? true : false;
            entity.KindOfVehicle.Code = (string)dataReader["Kind_Of_Vehicle"] == "1" ? "1" : "2";
            entity.BodyCost = (decimal)dataReader["Body_Cost"];
            entity.ModifyCost = (decimal)dataReader["Modify_Cost"];
            entity.VendorQuotationDate = (DateTime)dataReader["Vendor_Quotation_Date"];
            entity.Remark = (string)dataReader["Remark"];
            if ((string)dataReader["Quotation_Status"] == "N")
            {
                entity.QuotationStatus = QUOTATION_STATUS_TYPE.NEWQ;
            }
            else if ((string)dataReader["Quotation_Status"] == "R")
            {
                entity.QuotationStatus = QUOTATION_STATUS_TYPE.RENEWALQ;
            }
            else if ((string)dataReader["Quotation_Status"] == "U")
            {
                entity.QuotationStatus = QUOTATION_STATUS_TYPE.USEDQ;
            }
            else { entity.QuotationStatus = QUOTATION_STATUS_TYPE.NEWQ; }



        }

        /// <summary>
        /// Method      : Insert new quotation
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        /// <param name="vehicleQuotation"></param>
        /// <param name="aCompany"></param>
        /// <returns>true if process success</returns>
        public bool InsertVehicleQuotation(VehicleQuotation vehicleQuotation, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_INSERT_QUOTATION);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Company_Code", aCompany.CompanyCode));
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", vehicleQuotation.QuotationNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Purchase_No", vehicleQuotation.Purchasing.PurchasNo != null ? DBValue(vehicleQuotation.Purchasing.PurchasNo.ToString()) : DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Contract_No", vehicleQuotation.VehicleContract.ContractNo != null ? DBValue(vehicleQuotation.VehicleContract.ContractNo.ToString()) : DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Validity_Date", vehicleQuotation.ValidityDate.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Issue_Date", vehicleQuotation.IssueDate.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Delivery_Day", vehicleQuotation.DeliveryDays));
            command.Parameters.Add(tableAccess.CreateParameter("@Customer_Accept", vehicleQuotation.IsCustomerAccept == true ? "Y" : "N"));
            command.Parameters.Add(tableAccess.CreateParameter("@Second_Hand_Status", vehicleQuotation.IsSecondHand == true ? "Y" : "N"));
            command.Parameters.Add(tableAccess.CreateParameter("@Kind_Of_Vehicle", vehicleQuotation.KindOfVehicle.Code));
            command.Parameters.Add(tableAccess.CreateParameter("@Body_Cost", vehicleQuotation.BodyCost));
            command.Parameters.Add(tableAccess.CreateParameter("@Modify_Cost", vehicleQuotation.ModifyCost));
            command.Parameters.Add(tableAccess.CreateParameter("@Vendor_Quotation_Date", vehicleQuotation.VendorQuotationDate.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Remark", vehicleQuotation.Remark));
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_Status", vehicleQuotation.QuotationStatus.ToString()));

            command.Parameters.Add(tableAccess.CreateParameter("@Process_User", UserProfile.UserID));

            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);

            return result;

        }

        public bool UpdateVehicleQuotation(VehicleQuotation vehicleQuotation)
        {

            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_UPDATE_QUOTATION_BY_QUOTATION_NO);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", vehicleQuotation.QuotationNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Validity_Date", vehicleQuotation.ValidityDate.Value.Date));
            command.Parameters.Add(tableAccess.CreateParameter("@Issue_Date", vehicleQuotation.IssueDate.Value.Date));
            command.Parameters.Add(tableAccess.CreateParameter("@Delivery_Day", vehicleQuotation.DeliveryDays));
            command.Parameters.Add(tableAccess.CreateParameter("@Customer_Accept", vehicleQuotation.IsCustomerAccept == true ? "Y" : "N"));
            command.Parameters.Add(tableAccess.CreateParameter("@Second_Hand_Status", vehicleQuotation.IsSecondHand == true ? "Y" : "N"));
            command.Parameters.Add(tableAccess.CreateParameter("@Kind_Of_Vehicle", vehicleQuotation.KindOfVehicle.Code));
            command.Parameters.Add(tableAccess.CreateParameter("@Vendor_Quotation_Date", vehicleQuotation.ValidityDate.Value.Date));
            command.Parameters.Add(tableAccess.CreateParameter("@Remark", vehicleQuotation.Remark.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_Status", vehicleQuotation.QuotationStatus.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Process_User", UserProfile.UserID));




            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);

            return result;

        }

        /// <summary>
        /// Method      : Update quotation by PO
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        /// <param name="purchaseNo"></param>
        /// <param name="quotationNo"></param>
        /// <returns></returns>
        public bool UpdateQuotation(DocumentNo purchaseNo, DocumentNo quotationNo)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_UPDATE_QUOTATION_BY_PURCHASE_NO);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Purchase_No", purchaseNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", quotationNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Process_User", UserProfile.UserID));

            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);

            return result;
        }

        public bool UpdateQuotationContract(string contractNo, DocumentNo quotationNo)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_UPDATE_QUOTATION_BY_CONTRACT_NO);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Contract_No", contractNo));
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", quotationNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Process_User", UserProfile.UserID));

            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);

            return result;
        }

        public bool DeleteVehicleQuotation(VehicleQuotation value)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_DELETE_QUOTATION);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", value.QuotationNo.ToString()));

            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);

            return result;
        }
        public bool DeletePurchasingInQuotation(DocumentNo purchaseNo)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SET_NULL_QUOTATION_BY_PO);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Purchase_No", purchaseNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Process_User", UserProfile.UserID));

            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);

            return result;
        }

        /// <summary>
        /// Clear contract in quotation
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public bool DeleteContractQuotation(ContractBase contract)
        {
            // create sql statement
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("UPDATE Vehicle_Quotation SET ");
            sqlBuilder.Append("Contract_No = NULL ");
            sqlBuilder.Append("WHERE Contract_No = @Contract_No");

            // create sql command
            SqlCommand updateCommand = this.tableAccess.CreateCommand(sqlBuilder.ToString());
            updateCommand.CommandType = CommandType.Text;

            // add sql parameters
            updateCommand.Parameters.Add(this.tableAccess.CreateParameter("@Contract_No", contract.ContractNo.EntityKey));

            return (this.tableAccess.ExecuteSQL(updateCommand) >= 0);
        }

        #endregion
    }
}
