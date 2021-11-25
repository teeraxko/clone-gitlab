using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity;
using DataAccess.CommonDB;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.VehicleEntities.VehicleLeasing;


using SystemFramework.AppConfig;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

namespace DataAccess.VehicleDB.VehicleLeasingDB
{
    public class VehiclePurchaseContractDB : PISDataAccessBase<VehiclePurchasingContract, Company>
    {
        #region Constant
        private const string STPROC_VEH_INSERT_PURCHASING_CONTRACT = "SVehicleInsertPurchasingContract";        
        #endregion

        #region Private Method
        private List<VehiclePurchasingContract> FillPurchaseList(SqlCommand cmd)
        {
            List<VehiclePurchasingContract> result = new List<VehiclePurchasingContract>();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(cmd);

            try
            {
                while (dataReader.Read())
                {
                    VehiclePurchasingContract entity = new VehiclePurchasingContract();
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
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                }

                dataReader.Close();
                tableAccess.CloseDataReader();
            }
            return result;
        }

        private VehiclePurchasingContract Fill(SqlCommand command, Company aCompany)
        {
            VehiclePurchasingContract entity = new VehiclePurchasingContract();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);

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
        #endregion

        #region Protected Method
        protected override string TableName
        {
            get { throw new NotImplementedException(); }
        }

        protected override string[] KeyFields
        {
            get { throw new NotImplementedException(); }
        }

        protected override string[] OtherFields
        {
            get { throw new NotImplementedException(); }
        }

        protected override void AddKeyParameters(System.Data.SqlClient.SqlParameterCollection parameters, VehiclePurchasingContract entity, Company company)
        {
            parameters.Add(this.tableAccess.CreateParameter("@Purchase_No", entity.VehiclePurchasing.PurchasNo.ToString()));
        }

        protected override void AddParameters(System.Data.SqlClient.SqlParameterCollection parameters, VehiclePurchasingContract entity)
        {
            throw new NotImplementedException();
        }

        protected override void FillDetail(VehiclePurchasingContract entity, System.Data.SqlClient.SqlDataReader dataReader)
        {
            entity.VehiclePurchasing = new VehiclePurchasing();
            entity.Vehicle = new Vehicle();
            entity.Contract = new Contract();

            if (dataReader.IsDBNull(1))
            {
                entity.VehiclePurchasing = null;
            }
            else
            {
                entity.VehiclePurchasing.PurchasNo = new DocumentNo((string)(dataReader["Purchase_No"]));
            }
            if (dataReader.IsDBNull(2))
            {
                entity.Vehicle = null;
            }
            else
            {
                entity.Vehicle.VehicleNo = Convert.ToInt32(dataReader["Vehicle_No"]);
            }
            if (dataReader.IsDBNull(3))
            {
                entity.Contract = null;
            }
            else
            {
                entity.Contract.ContractNo = new DocumentNo((string)(dataReader["Contract_No"]));
            }

        }

        #endregion

        #region Public Method
        public bool InsertPurchaseContract(string purchaseNo, string vehicleNo, string contractNo, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_INSERT_PURCHASING_CONTRACT);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Company_Code", aCompany.CompanyCode));
            command.Parameters.Add(tableAccess.CreateParameter("@Purchase_No", purchaseNo));
            command.Parameters.Add(tableAccess.CreateParameter("@Vehicle_No", vehicleNo));
            command.Parameters.Add(tableAccess.CreateParameter("@Contract_No", contractNo != "" ? DBValue(contractNo) : DBNull.Value));


            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);

            return result;

        }

        public bool DeletePurchasingContractByPurchasing(VehiclePurchasing vehiclePurchasing, Company aCompany)
        {
            SqlCommand cmd = this.tableAccess.CreateCommand("SDeletePurchasingContractByPurchasing");
            cmd.CommandType = CommandType.StoredProcedure;

            VehiclePurchasingContract vehiclePurchasingContract = new VehiclePurchasingContract();
            vehiclePurchasingContract.VehiclePurchasing = vehiclePurchasing;
            AddKeyParameters(cmd.Parameters, vehiclePurchasingContract, aCompany);

            bool result = (tableAccess.ExecuteStoredProcedure(cmd) < 0);
            return result;
        }

        public VehiclePurchasingContract GetPurchasingContractByPurchasing(VehiclePurchasing vehiclePurchasing, Company aCompany)
        {
            SqlCommand cmd = this.tableAccess.CreateCommand("SSearchPurchasingContractByPurchasing");
            cmd.CommandType = CommandType.StoredProcedure;

            VehiclePurchasingContract vehiclePurchasingContract = new VehiclePurchasingContract();
            vehiclePurchasingContract.VehiclePurchasing = vehiclePurchasing;
            AddKeyParameters(cmd.Parameters, vehiclePurchasingContract, aCompany);

            return Fill(cmd, aCompany);
        }

        public List<VehiclePurchasingContract> GetPurchasingContractListByPurchasing(VehiclePurchasing vehiclePurchasing, Company aCompany)
        {
            SqlCommand cmd = this.tableAccess.CreateCommand("SSearchPurchasingContractByPurchasing");
            cmd.CommandType = CommandType.StoredProcedure;

            VehiclePurchasingContract vehiclePurchasingContract = new VehiclePurchasingContract();
            vehiclePurchasingContract.VehiclePurchasing = vehiclePurchasing;
            AddKeyParameters(cmd.Parameters, vehiclePurchasingContract, aCompany);

            return FillPurchaseList(cmd);
        }

        public List<VehiclePurchasingContract> GetPurchasingContractListByContract(DocumentNo contractNo)
        {
            SqlCommand cmd = this.tableAccess.CreateCommand("SSelectAllPurchasingContractByContract");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(this.tableAccess.CreateParameter("@Contract_No", contractNo.ToString()));
            
            return FillPurchaseList(cmd);
        }

        /// <summary>
        /// Get purchasing car was selled.
        /// </summary>
        /// <param name="vehiclePurchasing"></param>
        /// <returns></returns>
        public List<VehiclePurchasingContract> GetPurchasingContractListByVehicleSelling(VehiclePurchasing vehiclePurchasing)
        {
            Vehicle vehicle = new Vehicle();

            SqlCommand cmd = this.tableAccess.CreateCommand("SSelectPurchasingContractByVehicleSelling");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(this.tableAccess.CreateParameter("@Purchase_No", vehiclePurchasing.PurchasNo.ToString()));
            
            return FillPurchaseList(cmd);
        }

        /// <summary>
        /// Get purchasing car was not equal contract status condition.
        /// </summary>
        /// <param name="vehiclePurchasing"></param>
        /// <returns></returns>
        public List<VehiclePurchasingContract> GetPurchasingContractByContractStatus(VehiclePurchasing vehiclePurchasing, ContractStatus contractStatus)
        {
            SqlCommand cmd = this.tableAccess.CreateCommand("SSelectPurchasingContractByContractStatus");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(this.tableAccess.CreateParameter("@Purchase_No", vehiclePurchasing.PurchasNo.ToString()));
            cmd.Parameters.Add(this.tableAccess.CreateParameter("@Contract_Status", contractStatus.Code));

            return FillPurchaseList(cmd);
        }

        /// <summary>
        /// Clear contract in purchase order
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public bool DeleteContractPurchasing(ContractBase contract)
        {
            // create sql statement
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("DELETE FROM Vehicle_Purchasing_Contract ");
            sqlBuilder.Append("WHERE Contract_No = @Contract_No");

            // create sql command
            SqlCommand deleteCommand = this.tableAccess.CreateCommand(sqlBuilder.ToString());
            deleteCommand.CommandType = CommandType.Text;

            // add sql parameters
            deleteCommand.Parameters.Add(this.tableAccess.CreateParameter("@Contract_No", contract.ContractNo.EntityKey));

            // execute sql stement
            int deletedCount = this.tableAccess.ExecuteSQL(deleteCommand);

            return (deletedCount >= 0);
        } 
        #endregion
    }
}
