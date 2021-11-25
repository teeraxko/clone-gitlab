using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using DataAccess.CommonDB;
using DataAccess.VehicleDB;
using DataAccess.ContractDB;
using DataAccess.VehicleDB.VehicleLeasingDB;

using Entity.VehicleEntities;
using Entity.ContractEntities;
using Entity.VehicleEntities.VehicleLeasing;

using Flow.VehicleFlow;
using Flow.VehicleFlow.LeasingFlow;

using ictus.Framework.ASC.VBFuntion;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.General;

using PTB.BTS.Common.Flow;


namespace Flow.VehicleFlow.VehicleLeasingFlow
{
    public class VehiclePurchasingFlow : FlowBase
    {


        #region Constructor
        public VehiclePurchasingFlow()
            : base()
        { 

        } 
        #endregion

        #region Private Method

        private VehicleInfo GetVehicleInfo(VehiclePurchasing vehiclePurchasing, VehicleCalculation vehicleCalculation)
        {
            VehicleInfo vehicleInfo = new VehicleInfo();
            vehicleInfo.AKindOfVehicle = new KindOfVehicle();
            vehicleInfo.VatStatus = new VehicleVatStatus();
            vehicleInfo.AVehicleStatus = new VehicleStatus();
            vehicleInfo.AVendor = new Vendor();
            vehicleInfo.AModel = new Model();
            vehicleInfo.AColor = new Color();
            vehicleInfo.AModel.ABrand = new Brand();
            vehicleInfo.VatStatus = new VehicleVatStatus();

            vehicleInfo.PlatePrefix = "";
            vehicleInfo.PlateRunningNo = "";
            vehicleInfo.PlateProvince = new Province();
            vehicleInfo.PlateStatus = Entity.CommonEntity.PLATE_STATUS.R;
            vehicleInfo.EngineNo = "";
            vehicleInfo.ChassisNo = "";
            vehicleInfo.AVendor.Code = vehiclePurchasing.Vendor.Code;
            vehicleInfo.AModel.ABrand.Code = vehiclePurchasing.Model.ABrand.Code;
            vehicleInfo.AModel.Code = vehiclePurchasing.Model.Code;

            if (vehiclePurchasing.IsNewCar)
            {
                vehicleInfo.AKindOfVehicle = vehicleCalculation.Quotation.KindOfVehicle;
            }
            else
            {
                vehicleInfo.AKindOfVehicle.Code = KindOfVehicle.SPARE;
            }

            vehicleInfo.IsSecondHand = Entity.CommonEntity.SECOND_HAND_STATUS_TYPE.SECOND_HAND_NO;
            vehicleInfo.VatStatus.Code = "N";
            vehicleInfo.AVehicleStatus.Code = "1";
            vehicleInfo.AColor.Code = vehiclePurchasing.Color.Code;
            vehicleInfo.BuyDate = DateTime.Today.Date;
            vehicleInfo.RegisterDate = DateTime.Today.Date;
            vehicleInfo.VehicleAmount = vehiclePurchasing.VehiclePrice;
            vehicleInfo.OptionAmount = 0;
            vehicleInfo.LatestMileage = 0;
            vehicleInfo.LatestMileageUpdateDate = DateTime.Today.Date;
            vehicleInfo.OperationFee = 0;
            vehicleInfo.Remark = "";
            vehicleInfo.TerminationDate = NullConstant.DATETIME;

            return vehicleInfo;
        }


        #endregion

        #region Public Method
        public VehiclePurchasing GetPurchaseByContract(Contract contract)
        {
            using (VehiclePurchaseDB db = new VehiclePurchaseDB())
            {
                return db.GetPurchaseByContract(contract);
            }
        }

        public List<VehiclePurchasing> FillPurchasing(DocumentNo purchaseNo, DateTime aIssueDate, Company aCompany)
        {
            using (VehiclePurchaseDB db = new VehiclePurchaseDB())
            {
                return db.FillPurchasing(purchaseNo, aIssueDate, aCompany);
            }
        }

        public List<VehiclePurchasing> FillPurchasingByVehicle(DocumentNo purchaseNo, Company aCompany)
        {
            using (VehiclePurchaseDB db = new VehiclePurchaseDB())
            {
                return db.FillPurchasingByVehicle(purchaseNo, aCompany);
            }
        }

        public VehiclePurchasing FillPurchasingByPurchaseNo(string purchaseNo, Company company)
        {
            using (VehiclePurchaseDB db = new VehiclePurchaseDB())
            {
                return db.FillPurchasingByPurchaseNo(purchaseNo, company);
            }
        }

        public VehicleQuotation GetQuotationByPurchaseNo(DocumentNo purchaseNo, Company aCompany)
        {
            using (VehicleQuotationDB db = new VehicleQuotationDB())
            {
                return db.GetQuotationByPurchaseNo(purchaseNo, aCompany);
            }
        }

        public DocumentNo GetContractNoByPO(string purchaseNo)
        {
            using (VehiclePurchaseDB db = new VehiclePurchaseDB())
            {
                return db.GetContractNoByPO(purchaseNo);
            }
        }

        public bool InsertPurchasing(VehiclePurchasing vehiclePurchasing, DocumentNo quotationNo, Company aCompany)
        {
            bool result = true;
            string contractNo = "";
            int vehicleNo = 0;
            TableAccess tableAccess = new TableAccess();

            #region Variable
            VehiclePurchaseDB dbVehiclePurchasing = new VehiclePurchaseDB();
            VehicleQuotationDB dbVehicleQuotation = new VehicleQuotationDB();
            VehicleDB dbVehicle = new VehicleDB();
            VehicleContractDB dbVehicleContract = new VehicleContractDB();
            VehicleCalculationDB dbVehicleCalculation = new VehicleCalculationDB();
            VehiclePurchaseContractDB dbPurchaseContract = new VehiclePurchaseContractDB();
            PTB.BTS.Contract.Flow.ContractFlow flowContract = new PTB.BTS.Contract.Flow.ContractFlow();

            #endregion

            VehicleInfo vehicleInfo = new VehicleInfo();
            VehicleCalculation vehicleCalculation = new VehicleCalculation();

            try
            {
                ///========= get vehicle calculation ======
                if (quotationNo != null)
                {
                    vehicleCalculation = dbVehicleCalculation.GetVehicleSearchConditionByQuotationNo(quotationNo, aCompany);
                    if (vehicleCalculation.Quotation.QuotationNo != null)
                    {
                        vehicleCalculation.Quotation = dbVehicleQuotation.GetQuotationByQuotationNo(vehicleCalculation.Quotation.QuotationNo.ToString(), aCompany);
                        vehicleCalculation.Quotation.Purchasing = vehiclePurchasing;
                    }
                }

                //Get vehicle detail
                vehicleInfo = GetVehicleInfo(vehiclePurchasing, vehicleCalculation);

                tableAccess.OpenTransaction();

                dbVehiclePurchasing.TableAccess = tableAccess;
                dbVehicleQuotation.TableAccess = tableAccess;
                dbVehicle.TableAccess = tableAccess;
                dbPurchaseContract.TableAccess = tableAccess;

                result &= dbVehiclePurchasing.InsertPurchasing(vehiclePurchasing, aCompany);

                if (quotationNo != null)
                {
                    result &= dbVehicleQuotation.UpdateQuotation(vehiclePurchasing.PurchasNo, quotationNo);
                }

                for (int i = 0; i < vehiclePurchasing.Quantity; i++)
                {
                    vehicleNo = dbVehicle.InsertVehicleInfo(vehicleInfo, aCompany);

                    if (vehiclePurchasing.IsNewCar == true)
                    {
                        vehicleCalculation.Quotation.VehicleContract = new VehicleContract();
                        vehicleCalculation.Quotation.VehicleContract.AVehicleRoleList = new VehicleRoleList(aCompany);
                        VehicleRole vehicleRole = new VehicleRole();
                        vehicleRole.AVehicle = new Vehicle();
                        vehicleRole.AVehicle.VehicleNo = vehicleNo;
                        vehicleCalculation.Quotation.VehicleContract.AVehicleRoleList.Add(vehicleRole);

                        contractNo = flowContract.IssueContractByPurchaseOrder(vehicleCalculation, aCompany, tableAccess);
                        result &= dbPurchaseContract.InsertPurchaseContract(vehiclePurchasing.PurchasNo.ToString(), vehicleRole.AVehicle.VehicleNo.ToString(), contractNo, aCompany);
                    }
                    else
                    {
                        vehicleCalculation.Quotation = new VehicleQuotation();
                        vehicleCalculation.Quotation.VehicleContract = new VehicleContract();
                        vehicleCalculation.Quotation.VehicleContract.AVehicleRoleList = new VehicleRoleList(aCompany);
                        VehicleRole vehicleRole = new VehicleRole();
                        vehicleRole.AVehicle = new Vehicle();
                        vehicleRole.AVehicle.VehicleNo = vehicleNo;
                        vehicleCalculation.Quotation.VehicleContract.AVehicleRoleList.Add(vehicleRole);

                        contractNo = "";
                        result &= dbPurchaseContract.InsertPurchaseContract(vehiclePurchasing.PurchasNo.ToString(), vehicleRole.AVehicle.VehicleNo.ToString(), contractNo, aCompany);
                    }
                }

                if (contractNo != "" && quotationNo != null)
                {
                    result &= dbVehicleQuotation.UpdateQuotationContract(contractNo, quotationNo);
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
                dbVehiclePurchasing = null;
                dbVehicleQuotation = null;
                dbVehicle = null;
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
        
        public bool UpdatePurchasing(VehiclePurchasing vehiclePurchasing, DocumentNo quotationNo, Company aCompany)
        {
            #region Variable
            bool result = true, isNewPO = false;
            string contractNo = "";
            int vehicleNo = 0;

            TableAccess tableAccess = new TableAccess();
            VehiclePurchaseDB dbVehiclePurchasing = new VehiclePurchaseDB();
            VehicleQuotationDB dbVehicleQuotation = new VehicleQuotationDB();
            VehicleDB dbVehicle = new VehicleDB();
            VehicleContractDB dbVehicleContract = new VehicleContractDB();
            VehicleCalculationDB dbVehicleCalculation = new VehicleCalculationDB();
            VehiclePurchaseContractDB dbPurchaseContract = new VehiclePurchaseContractDB();
            PTB.BTS.Contract.Flow.ContractFlow flowContract = new PTB.BTS.Contract.Flow.ContractFlow();

            #endregion

            VehicleInfo vehicleInfo = new VehicleInfo();
            VehicleCalculation vehicleCalculation = new VehicleCalculation();

            try
            {
                ///========= get vehicle calculation ======
                if (quotationNo != null)
                {
                    vehicleCalculation = dbVehicleCalculation.GetVehicleSearchConditionByQuotationNo(quotationNo, aCompany);
                    if (vehicleCalculation.Quotation.QuotationNo != null)
                    {
                        vehicleCalculation.Quotation = dbVehicleQuotation.GetQuotationByQuotationNo(vehicleCalculation.Quotation.QuotationNo.ToString(), aCompany);
                        vehicleCalculation.Quotation.Purchasing = vehiclePurchasing;
                    }
                    vehicleInfo = GetVehicleInfo(vehiclePurchasing, vehicleCalculation);
                }

                //Check purchase order is re-create
                isNewPO = dbPurchaseContract.GetPurchasingContractListByPurchasing(vehiclePurchasing, aCompany).Count == 0;

                ///========================================
                tableAccess.OpenTransaction();
                dbVehiclePurchasing.TableAccess = tableAccess;
                dbVehicleQuotation.TableAccess = tableAccess;
                dbVehicle.TableAccess = tableAccess;
                dbPurchaseContract.TableAccess = tableAccess;

                result &= dbVehiclePurchasing.UpdatePurchasing(vehiclePurchasing);

                if (quotationNo != null)
                {
                    result &= dbVehicleQuotation.UpdateQuotation(vehiclePurchasing.PurchasNo, quotationNo);
                }

                if (isNewPO)
                {
                    for (int i = 0; i < vehiclePurchasing.Quantity; i++)
                    {
                        if (vehiclePurchasing.IsNewCar == true)
                        {
                            vehicleNo = dbVehicle.InsertVehicleInfo(vehicleInfo, aCompany);

                            vehicleCalculation.Quotation.VehicleContract = new VehicleContract();
                            vehicleCalculation.Quotation.VehicleContract.AVehicleRoleList = new VehicleRoleList(aCompany);
                            VehicleRole vehicleRole = new VehicleRole();
                            vehicleRole.AVehicle = new Vehicle();
                            vehicleRole.AVehicle.VehicleNo = vehicleNo;
                            vehicleCalculation.Quotation.VehicleContract.AVehicleRoleList.Add(vehicleRole);

                            contractNo = flowContract.IssueContractByPurchaseOrder(vehicleCalculation, aCompany, tableAccess);

                            result &= dbPurchaseContract.InsertPurchaseContract(vehiclePurchasing.PurchasNo.ToString(), vehicleRole.AVehicle.VehicleNo.ToString(), contractNo, aCompany);
                        }
                    }
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
                dbVehiclePurchasing = null;
                dbVehicleQuotation = null;
                dbVehicle = null;
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

        public bool CancelPurchaseOrder(VehiclePurchasing vehiclePurchasing, Company aCompany)
        {
            bool result = true;
            List<VehiclePurchasingContract> vehiclePurchasingContractList = new List<VehiclePurchasingContract>();
            VehiclePurchasingContract vehiclePurchasingContract = new VehiclePurchasingContract();

            TableAccess tableAccess = new TableAccess();
            VehiclePurchaseDB dbVehiclePurchasing = new VehiclePurchaseDB();
            VehicleQuotationDB dbVehicleQuotation = new VehicleQuotationDB();
            VehiclePurchaseContractDB dbVehiclePurchaseContract = new VehiclePurchaseContractDB();
            VehicleDB dbVehicle = new VehicleDB();
            VehicleContractDB dbVehicleContract = new VehicleContractDB();
            ContractDB dbContract = new ContractDB();
            VehiclePurchaseContractDB dbPurchaseContract = new VehiclePurchaseContractDB();

            vehiclePurchasing = dbVehiclePurchasing.GetPurchasingByPurchaseNo(vehiclePurchasing.PurchasNo.ToString(), aCompany);

            vehiclePurchasingContractList = dbPurchaseContract.GetPurchasingContractListByPurchasing(vehiclePurchasing, aCompany);
            try
            {
                tableAccess.OpenTransaction();
                dbVehiclePurchasing.TableAccess = tableAccess;
                dbVehicleQuotation.TableAccess = tableAccess;
                dbVehicle.TableAccess = tableAccess;
                dbVehicleContract.TableAccess = tableAccess;
                dbContract.TableAccess = tableAccess;
                dbPurchaseContract.TableAccess = tableAccess;

                //Update purchase status
                vehiclePurchasing.PurchaseStatus = Entity.CommonEntity.PURCHAS_STATUS_TYPE.CANCEL;
                result &= dbVehiclePurchasing.CancelPurchaseOrder(vehiclePurchasing);

                if (vehiclePurchasing.IsNewCar == true)
                {
                    //Set null Purchasing in Quotation
                    result &= dbVehicleQuotation.DeletePurchasingInQuotation(vehiclePurchasing.PurchasNo);

                    //delete vehicle_contract
                    result &= dbVehicleContract.DeleteVehicleContractByPurchasing(vehiclePurchasing);

                    //delete purchasing_contract
                    result &= dbPurchaseContract.DeletePurchasingContractByPurchasing(vehiclePurchasing, aCompany);

                    for (int i = 0; i < vehiclePurchasingContractList.Count; i++)
                    {
                        //delete vehicle
                        if (vehiclePurchasingContractList[i].Vehicle.VehicleNo != NullConstant.INT)
                        {
                            result &= dbVehicle.DeleteVehicleByPurchasing(vehiclePurchasingContractList[i].Vehicle.VehicleNo);
                        }
                        //delete contract
                        if (vehiclePurchasingContractList[i].Contract.ContractNo != null)
                        {
                            result &= dbContract.DeleteContractChargeByPurchasing(vehiclePurchasingContractList[i].Contract.ContractNo);
                            result &= dbContract.DeleteContractByPurchasing(vehiclePurchasingContractList[i].Contract.ContractNo);
                        }
                    }
                }
                else
                {
                    //delete vehicle_contract
                    result &= dbVehicleContract.DeleteVehicleContractByPurchasing(vehiclePurchasing);
                    
                    //delete purchasing_contract
                    result &= dbPurchaseContract.DeletePurchasingContractByPurchasing(vehiclePurchasing, aCompany);
                    
                    //delete vehicle
                    for (int i = 0; i < vehiclePurchasingContractList.Count; i++)
                    {
                        if (vehiclePurchasingContractList[i].Vehicle.VehicleNo != NullConstant.INT)
                        {
                            result &= dbVehicle.DeleteVehicleByPurchasing(vehiclePurchasingContractList[i].Vehicle.VehicleNo);
                        }
                    }
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
                dbVehiclePurchasing = null;
                dbVehicleQuotation = null;
                dbVehicle = null;
                dbVehicleContract = null;
                dbContract.TableAccess = null;
                dbPurchaseContract = null;

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
    }
}
