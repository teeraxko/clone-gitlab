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
    public class VehiclePurchaseDB : PISDataAccessBase<VehiclePurchasing, Company>
    {
        #region - Private -
        private DualFieldDBBase dbColor;
        #endregion

        #region StoreProcedure

        private const string STPROC_VEH_SEARCH_PURCHASING = "SVehicleSearchPurchasing";
        private const string STPROC_VEH_SEARCH_PURCHASING_BY_VEHICLE = "SVehicleSearchPurchasingByVehicle";
        private const string STPROC_VEH_INSERT_PURCHASING = "SVehicleInsertPurchasing";
        private const string STPROC_VEH_SEARCH_CONTRACT_NO = "SVehicleSearchContractNo";
        private const string STPROC_VEH_UPDATE_PURCHASING = "SVehicleUpdatePurchasing";
        private const string STPROC_VEH_UPDATE_PURCHASING_CANCEL = "SVehicleUpdatePurchasingCancel";
        private const string STPROC_VEH_INSERT_PURCHASING_CONTRACT = "SVehicleInsertPurchasingContract";
        private const string STPROC_VEH_SEARCH_PURCHASING_BY_PURCHASE_NO = "SVehicleSearchPruchasingByPurchaseNo";

        #endregion
        
        //============================== Constructor =================================
        public VehiclePurchaseDB()
            : base()
        {
            dbColor = new ColorDB();
        }

        #region Protected Method
        protected override string TableName
        {
            get { return "Vehicle_Purchasing"; }
        }

        protected override string[] KeyFields
        {
            get { return new string[] { "Company_Code", "Purchase_No" }; }
        }

        protected override string[] OtherFields
        {
            get { throw new NotImplementedException(); }
        }

        protected override void AddKeyParameters(System.Data.SqlClient.SqlParameterCollection parameters, VehiclePurchasing entity, Company company)
        {
            parameters.Add(tableAccess.CreateParameter("Company_Code", company.CompanyCode));
            parameters.Add(tableAccess.CreateParameter("Purchase_No", entity.PurchasNo));
        }

        protected override void AddParameters(System.Data.SqlClient.SqlParameterCollection parameters, VehiclePurchasing entity)
        {
            throw new NotImplementedException();
        }

        protected override void FillDetail(VehiclePurchasing entity, SqlDataReader dataReader)
        {
            entity.Vendor = new Vendor();
            entity.Model = new Model();
            entity.Model.ABrand = new Brand();
            entity.Color = new Color();

            if (dataReader.IsDBNull(1))
            {
                entity.PurchasNo = null;
            }
            else
            {
                entity.PurchasNo = new DocumentNo((string)(dataReader["Purchase_No"]));
            }

            entity.IssueDate = (DateTime)dataReader["Issue_Date"];
            entity.Model.ABrand.Code = (string)dataReader["Brand_Code"];
            entity.Model.Code = (string)dataReader["Model_Code"];
            entity.Color.Code = (string)dataReader["Color_Code"];
            entity.Quantity = (byte)dataReader["Quantity"];
            entity.Vendor.Code = (string)dataReader["Vendor_Code"];
            entity.VehiclePrice = (decimal)dataReader["Vehicle_Price"];
            entity.VendorQuotationDate = (DateTime)dataReader["Vendor_Quotation_Date"];


            if ((string)dataReader["Purchas_Status"] == "A")
            {
                entity.PurchaseStatus = PURCHAS_STATUS_TYPE.APPROVE;
            }
            else { entity.PurchaseStatus = PURCHAS_STATUS_TYPE.CANCEL; }

            entity.IsNewCar = dataReader.GetBoolean(12);

            entity.Remark = (string)dataReader["Remark"];

            //Todsporn Modified 25/2/2020 PO. Discount
            entity.Discount_Amount = (decimal)dataReader["Discount_Amount"];
            entity.Discount_Total = (decimal)dataReader["Discount_Total"];

            //D21018 Fix error casting
            entity.Discount_Amount = dataReader["Discount_Amount"] == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["Discount_Amount"]);
            entity.Discount_Total = dataReader["Discount_Total"] == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["Discount_Total"]);
        } 
        #endregion

        #region Public Method
        public VehiclePurchasing GetPurchaseByContract(Contract contract)
        {
            return null;
        }        
        #endregion

        //============================== Protected Method ============================
        public List<VehiclePurchasing> FillPurchasing(DocumentNo purchaseNo, DateTime aIssueDate, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_PURCHASING);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Purchase_No", purchaseNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Issue_Date", aIssueDate));
            return FillList(command, aCompany);
        }

        public List<VehiclePurchasing> FillPurchasingByVehicle(DocumentNo purchaseNo, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_PURCHASING_BY_VEHICLE);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Purchase_No", purchaseNo.ToString()));

            return FillList(command, aCompany);
        }

        public VehiclePurchasing FillPurchasingByPurchaseNo(string purchaseNo,Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_PURCHASING_BY_PURCHASE_NO);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Purchase_No", purchaseNo));

            return Fill(command, aCompany);
        }

        private List<VehiclePurchasing> FillList(SqlCommand command, Company aCompany)
        {
            List<VehiclePurchasing> result = new List<VehiclePurchasing>();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);

            using (ModelDB dbMod = new ModelDB())
            using (VendorDB dbVendor = new VendorDB())

                try
                {
                    while (dataReader.Read())
                    {
                        VehiclePurchasing entity = new VehiclePurchasing();
                        FillDetail(entity, dataReader);

                        entity.Model = dbMod.GetModel(entity.Model.Code, entity.Model.ABrand.Code);
                        entity.Color = (Color)dbColor.GetMTB(entity.Color.Code);
                        entity.Vendor = dbVendor.GetDBVendor(entity.Vendor.Code, aCompany);

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

        private VehiclePurchasing Fill(SqlCommand command, Company aCompany)
        {
            VehiclePurchasing result = new VehiclePurchasing();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);

            using (ModelDB dbMod = new ModelDB())
            using (VendorDB dbVendor = new VendorDB())

                try
                {
                    while (dataReader.Read())
                    {
                        VehiclePurchasing entity = new VehiclePurchasing();
                        FillDetail(entity, dataReader);
                        
                        entity.Model = dbMod.GetModel(entity.Model.Code, entity.Model.ABrand.Code);
                        entity.Color = (Color)dbColor.GetMTB(entity.Color.Code);
                        entity.Vendor = dbVendor.GetDBVendor(entity.Vendor.Code, aCompany);
                        result = entity;
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

        public VehiclePurchasing GetPurchasingByPurchaseNo(string purchaseNo, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_PURCHASING_BY_PURCHASE_NO);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Purchase_No", purchaseNo));

            return Fill(command, aCompany);
        }

        public DocumentNo GetContractNoByPO(string purchaseNo)
        {
            DocumentNo contractNo = null;
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_CONTRACT_NO);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Purchase_No", purchaseNo));

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);

            try
            {
                while (dataReader.Read())
                {

                    if (dataReader.IsDBNull(0))
                    {
                        contractNo = null;
                    }
                    else
                    {
                        contractNo = new DocumentNo((string)(dataReader["Contract_No"]));

                    }
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
            return contractNo;
        }

        public bool InsertPurchasing(VehiclePurchasing vehiclePurchasing, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_INSERT_PURCHASING);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Company_Code", aCompany.CompanyCode));
            command.Parameters.Add(tableAccess.CreateParameter("@Purchase_No", vehiclePurchasing.PurchasNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Brand_Code", vehiclePurchasing.Model.ABrand.Code));
            command.Parameters.Add(tableAccess.CreateParameter("@Model_Code", vehiclePurchasing.Model.Code));
            command.Parameters.Add(tableAccess.CreateParameter("@Color_Code", vehiclePurchasing.Color.Code));
            command.Parameters.Add(tableAccess.CreateParameter("@Quantity", vehiclePurchasing.Quantity));
            command.Parameters.Add(tableAccess.CreateParameter("@Vendor_Code", vehiclePurchasing.Vendor.Code));
            command.Parameters.Add(tableAccess.CreateParameter("@Vehicle_Price", vehiclePurchasing.VehiclePrice));
            command.Parameters.Add(tableAccess.CreateParameter("@Vendor_Quotation_Date", vehiclePurchasing.VendorQuotationDate.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Purchas_Status", vehiclePurchasing.PurchaseStatus == PURCHAS_STATUS_TYPE.APPROVE ? "A" : "C"));
            command.Parameters.Add(tableAccess.CreateParameter("@Remark", vehiclePurchasing.Remark));
            command.Parameters.Add(tableAccess.CreateParameter("@Is_New_Car", vehiclePurchasing.IsNewCar));
            
            command.Parameters.Add(tableAccess.CreateParameter("@Process_User", UserProfile.UserID));

            command.Parameters.Add(tableAccess.CreateParameter("@Discount_Amount", vehiclePurchasing.Discount_Amount));
            command.Parameters.Add(tableAccess.CreateParameter("@Discount_Total", vehiclePurchasing.Discount_Total));



            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);

            return result;

        }

        public bool UpdatePurchasing(VehiclePurchasing vehiclePurchasing)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_UPDATE_PURCHASING);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Purchase_No", vehiclePurchasing.PurchasNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Brand_Code", vehiclePurchasing.Model.ABrand.Code));
            command.Parameters.Add(tableAccess.CreateParameter("@Model_Code", vehiclePurchasing.Model.Code));
            command.Parameters.Add(tableAccess.CreateParameter("@Color_Code", vehiclePurchasing.Color.Code));
            command.Parameters.Add(tableAccess.CreateParameter("@Quantity", vehiclePurchasing.Quantity));
            command.Parameters.Add(tableAccess.CreateParameter("@Vendor_Code", vehiclePurchasing.Vendor.Code));
            command.Parameters.Add(tableAccess.CreateParameter("@Vehicle_Price", vehiclePurchasing.VehiclePrice));
            command.Parameters.Add(tableAccess.CreateParameter("@Vendor_Quotation_Date", vehiclePurchasing.VendorQuotationDate.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Purchas_Status", vehiclePurchasing.PurchaseStatus == PURCHAS_STATUS_TYPE.APPROVE ? "A" : "C"));
            command.Parameters.Add(tableAccess.CreateParameter("@Remark", vehiclePurchasing.Remark));
            command.Parameters.Add(tableAccess.CreateParameter("@Is_New_Car", vehiclePurchasing.IsNewCar));

            command.Parameters.Add(tableAccess.CreateParameter("@Process_User", UserProfile.UserID));

            
            //Todsporn Modified 25/2/2020 PO. Discount
            command.Parameters.Add(tableAccess.CreateParameter("@Discount_Amount", vehiclePurchasing.Discount_Amount));
            command.Parameters.Add(tableAccess.CreateParameter("@Discount_Total", vehiclePurchasing.Discount_Total));

            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);

            return result;

        }



        public bool CancelPurchaseOrder(VehiclePurchasing vehiclePurchasing)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_UPDATE_PURCHASING_CANCEL);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Purchase_No", vehiclePurchasing.PurchasNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Purchas_Status", vehiclePurchasing.PurchaseStatus == PURCHAS_STATUS_TYPE.APPROVE ? "A" : "C"));

            command.Parameters.Add(tableAccess.CreateParameter("@Process_User", UserProfile.UserID));

            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);

            return result;
        }

    }
}
