using System;

using Facade.PiFacade;

using PTB.BTS.Contract.Flow;
using PTB.BTS.Vehicle.Flow;
using PTB.BTS.Common.Flow;
using Flow.ContractFlow.ContractChargeRateFlow;

using System.Collections;

using ictus.Common.Entity.Time;
using Entity.ContractEntities;
using Entity.VehicleEntities;
using Entity.CommonEntity;
using PTB.BTS.ContractEntities.ContractChargeRate;
using Facade.CommonFacade;
using Entity.Constants;
using Entity.VehicleEntities.VehicleLeasing;
using Flow.VehicleFlow.VehicleLeasingFlow;
using SystemFramework.AppMessage;
using System.Collections.Generic;

namespace Facade.ContractFacade
{
    public class ContractFacadeBase : CommonPIFacadeBase
    {
        #region Declaration

        private ContractFlow flowContract;
        private VehicleFlow flowVehicle;
        private DocumentNoFlow flowContractRunningNo;
        private VehicleAssignmentFlow flowVehicleAssignment;
        private AgeFlow flowAge;
        private CustomerSpecialChargeConditionFlow flowCustomerSpecialChargeCondition;

        #endregion

        #region DataSource

        public ArrayList DataSourceCustomerName
        {
            get
            {
                CustomerFlow flowCustomer = new CustomerFlow();
                CustomerList CustomerList = new CustomerList(GetCompany());
                flowCustomer.FillCustomer(ref CustomerList);
                flowCustomer = null;
                return CustomerList.GetArrayList();
            }
        }

        public ArrayList DataSourceContractTypeList(string type)
        {
            ContractTypeFlow flowContractType = new ContractTypeFlow();
            ContractTypeList contractTypeList = new ContractTypeList(GetCompany());
            ContractType contractType = new ContractType();
            contractType.Code = type;
            flowContractType.FillMTB(contractType);
            contractTypeList.Add(contractType);
            flowContractType = null;
            return contractTypeList.GetArrayList();
        }

        public ArrayList DataSourceContractType
        {
            get
            {
                ContractTypeFlow flowContractType = new ContractTypeFlow();
                ContractTypeList contractTypeList = new ContractTypeList(GetCompany());
                flowContractType.FillMTBList(contractTypeList);
                flowContractType = null;
                return contractTypeList.GetArrayList();
            }
        }

        public ArrayList DataSourceContractStatus
        {
            get
            {
                ContractStatusFlow flowContractStatus = new ContractStatusFlow();
                ContractStatusList contractStatusList = new ContractStatusList(GetCompany());
                flowContractStatus.FillMTBList(contractStatusList);
                flowContractStatus = null;
                return contractStatusList.GetArrayList();
            }
        }
        public ArrayList DataSourceKindOfContract
        {
            get
            {
                KindOfContractFlow flowKindOfContract = new KindOfContractFlow();
                KindOfContractList kindOfContractList = new KindOfContractList(GetCompany());
                flowKindOfContract.FillMTBList(kindOfContractList);
                flowKindOfContract = null;
                return kindOfContractList.GetArrayList();
            }
        }
        public ArrayList DataSourceCustomerDept(Customer value)
        {
            CustomerDepartmentFlow flowCustomerDept = new CustomerDepartmentFlow();
            CustomerDepartmentList CustomerDeptList = new CustomerDepartmentList(GetCompany());
            CustomerDeptList.ACustomer = value;
            flowCustomerDept.FillCustomerDepartmentList(ref CustomerDeptList);
            flowCustomerDept = null;
            return CustomerDeptList.GetArrayList();
        }

        public string[] DatasourceKindOfRentalType
        {
            get
            {
                CTFunction ctFunction = new CTFunction();
                return ctFunction.KindOfRentalArray;
            }
        }
        #endregion

        #region DataSource FarPoint
        public KindOfVehicleList ObjKindOfVehicleList;
        public KindOfVehicleList DataSourceKindOfVehicle
        {
            get
            {
                KindOfVehicleFlow flowMTB = new KindOfVehicleFlow();
                KindOfVehicleList mtbList = new KindOfVehicleList(GetCompany());

                flowMTB.FillMTBList(mtbList);
                flowMTB = null;

                KindOfVehicle kindOfVehicle;

                for (int i = 0; i < mtbList.Count; i++)
                {
                    kindOfVehicle = (KindOfVehicle)mtbList.BaseGet(i);
                    ObjKindOfVehicleList.Add(kindOfVehicle.AName.English, kindOfVehicle);
                }
                return mtbList;
            }
        }

        #endregion - DataSource FarPoint -

        #region Constructor
        public ContractFacadeBase() : base()
        {
            ObjKindOfVehicleList = new KindOfVehicleList(GetCompany());
            flowContract = new ContractFlow();
            flowVehicle = new VehicleFlow();
            flowContractRunningNo = new DocumentNoFlow();
            flowVehicleAssignment = new VehicleAssignmentFlow();
            flowAge = new AgeFlow();
            flowCustomerSpecialChargeCondition = new CustomerSpecialChargeConditionFlow();
        }
        #endregion

        #region IDispose Members

        protected override void Dispose(bool disposing)
        {
            // === Dispose objects ===
            this.flowContract.Dispose();

            // === Release resources ===
            this.flowContract = null;

            base.Dispose(disposing);
        }

        #endregion

        #region Public Method

        public DayMonthYearStructure CalAge(DateTime start, DateTime end)
        {
            return flowAge.DaysDiff(start, end.AddDays(1));
        }

        public ContractBase RetriveContract(DocumentNo value)
        {
            return flowContract.RetriveContract(value, GetCompany());
        }

        public DocumentNo RetriveContractRunningNo()
        {
            return flowContractRunningNo.GetContractRunningNo(DOCUMENT_TYPE.CONTRACT, GetCompany());
        }

        public Vehicle GetVehicleGeneral(int vehicleNo)
        {
            return flowVehicle.GetVehicleGeneral(vehicleNo, GetCompany());
        }

        public bool FillExcludeAvailableVehicleSpareAssignment(ref VehicleAssignment value)
        {
            return flowVehicleAssignment.FillExcludeAvailableVehicleSpareAssignment(ref value, GetCompany());
        }

        public bool FillVehicleActive(Vehicle value)
        {
            return flowVehicle.FillVehicleActive(value, GetCompany());
        }

        public ContractChargeDetailList GetContractChargeDetailNoneBPNoList(ContractBase contract)
        {
            ContractChargeDetailList listChargeDetail = new ContractChargeDetailList(GetCompany());
            listChargeDetail.AContract = contract;

            if (Flow.ContractFlow.ContractChargeDetailFlow.FillContractChargeDetailNoneBPNoList(listChargeDetail))
            {
                return listChargeDetail;
            }
            else
            {
                listChargeDetail = null;
                return null;
            }
        }

        public int GetDeductChargeRate(ContractBase contract, Customer customer, DRIVER_DEDUCT_STATUS deductStatus)
        {
            ChargeRate chargeRate = flowContract.GetChargeRate(contract, customer, deductStatus, GetCompany());
            if (chargeRate == null)
            {
                return 0;
            }
            else
            {
                return chargeRate.AbsenceDeduction;
            }
        }

        public DriverDeductCharge GetDriverDeductCharge(ContractBase contract)
        {
            return flowContract.GetDriverDeductCharge(contract, GetCompany());
        }

        public DocumentNo GetSpecificVDMatchByContract(ContractType contractType, DocumentNo contractNo)
        {
            using (VDContractMatchFlow flow = new VDContractMatchFlow())
            {
                return flow.GetSpecificVDMatchByContract(contractType, contractNo, GetCompany());
            }
        }

        public AssignmentBase GetMaxAssignedByContract(string contractType, DocumentNo contractNo)
        {
            if (contractType == ContractType.CONTRACT_TYPE_VEHICLE)
            {
                using (VehicleAssignmentFlow flow = new VehicleAssignmentFlow())
                {
                    return flow.GetMaxAssignedByContract(contractNo, GetCompany());
                }
            }
            else
            {
                using (ServiceStaffAssignmentFlow flow = new ServiceStaffAssignmentFlow())
                {
                    return flow.GetMaxAssignedByContract(contractNo, GetCompany());                    
                }
            }
        }

        public bool ModeInsertContract(ContractBase value)
        {
            CommonFlow flowCommon = new CommonFlow();
            value.ContractDate = flowCommon.GetSystemDate();
            value.CancelDate = flowCommon.GetNullDate();
            if (flowContract.InsertContract(value, GetCompany()))
            { return true; }
            else
            { return false; }
        }

        public bool ModeUpdateContract(ContractBase value)
        {
            CommonFlow flowCommon = new CommonFlow();
            if (value.AContractStatus.Code == "1")
                value.CancelDate = flowCommon.GetNullDate();
            if (value.AContractStatus.Code == "2")
                value.CancelDate = flowCommon.GetNullDate();
            if (value.AContractStatus.Code == "3")
                value.CancelDate = flowCommon.GetSystemDate();

            if (flowContract.UpdateContract(value, GetCompany()))
            { return true; }
            else
            { return false; }
        }

        public bool ModeUpdateSpecificContract(DriverContract driverContract, VehicleContract vehicleContract)
        {
            return flowContract.UpdateSpecificContract(driverContract, vehicleContract, GetCompany());
        }

        public bool ModeDeleteContract(ContractBase value)
        {
            if (flowContract.DeleteContract(value, GetCompany()))
            {
                return true;
            }
            return false;
        }

        public List<VehiclePurchasingContract> GetPurchaseContractByContract(DocumentNo contractNo)
        {
            using (VehiclePurchasingContractFlow flow = new VehiclePurchasingContractFlow())
            {
                return flow.GetPurchasingContractListByContract(contractNo);
            }
        }

        /// <summary>
        /// Check match between contract department and assigned department,
        /// in case the contract has only on assigned department
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public bool ValidateMatchDepartment(ContractBase contract)
        {
            return flowContract.ValidateMatchDepartment(contract, GetCompany());
        }

        /// <summary>
        /// Validate contract that can assign department
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="contractMode"></param>
        /// <returns></returns>
        public bool ValidateAssignDepartmentPermission(ContractBase contract)
        {
            return flowContract.ValidateAssignDepartmentPermission(contract);
        }

        public System.Collections.Generic.List<VehiclePurchasingContract> GetPurchasingContractListByContract(DocumentNo contractNo)
        {
            using (VehiclePurchasingContractFlow flow = new VehiclePurchasingContractFlow())
            {
                return flow.GetPurchasingContractListByContract(contractNo);
            }
        }
        #endregion

    }
}
