//using System;
//using System.Data;
//using System.Collections;

//using ictus.PIS.PI.Entity;
//using ictus.Common.Entity;
//using ictus.Common.Entity.Time;
//using ictus.Common.Entity.General;

//using Entity.CommonEntity;
//using Entity.ContractEntities;
//using Entity.VehicleEntities;

//using PTB.BTS.Common.Flow;
//using PTB.BTS.Contract.Flow;
//using PTB.BTS.Vehicle.Flow;

//using Facade.PiFacade;
//using Facade.CommonFacade;

//using FarPoint.Win.Spread.CellType;

//namespace Facade.ContractFacade
//{
//    public class ContractFacade : CommonPIFacadeBase    
//    {
//        #region - Private -
//        private ContractFlow flowContract;
//        private VehicleFlow flowVehicle;
//        private DocumentNoFlow flowContractRunningNo;
//        private VehicleAssignmentFlow flowVehicleAssignment;
//        private AgeFlow flowAge;
//        #endregion
		
//        #region - DataSource -
//        public ArrayList DataSourceCustomerName
//        {
//            get
//            {
//                CustomerFlow flowCustomer = new CustomerFlow();
//                CustomerList CustomerList = new CustomerList(GetCompany());
//                flowCustomer.FillCustomer(ref CustomerList);
//                flowCustomer = null;
//                return CustomerList.GetArrayList();	
//            }
//        }

//        public ArrayList DataSourceContractTypeList(string type)
//        {
//            ContractTypeFlow flowContractType = new ContractTypeFlow();
//            ContractTypeList contractTypeList = new ContractTypeList(GetCompany());
//            ContractType contractType = new ContractType();
//            contractType.Code = type;
//            flowContractType.FillMTB(contractType);
//            contractTypeList.Add(contractType);
//            flowContractType = null;
//            return contractTypeList.GetArrayList();
//        }
		
//        public ArrayList DataSourceContractType
//        {
//            get
//            {
//                ContractTypeFlow flowContractType = new ContractTypeFlow();
//                ContractTypeList contractTypeList = new ContractTypeList(GetCompany());
//                flowContractType.FillMTBList(contractTypeList);
//                flowContractType = null;
//                return contractTypeList.GetArrayList();
//            }
//        }

//        public ArrayList DataSourceContractStatus
//        {
//            get
//            {
//                ContractStatusFlow flowContractStatus = new ContractStatusFlow();
//                ContractStatusList contractStatusList = new ContractStatusList(GetCompany());
//                flowContractStatus.FillMTBList(contractStatusList);
//                flowContractStatus = null;
//                return contractStatusList.GetArrayList();
//            }
//        }
//        public ArrayList DataSourceKindOfContract
//        {
//            get
//            {
//                KindOfContractFlow flowKindOfContract = new KindOfContractFlow();
//                KindOfContractList kindOfContractList = new KindOfContractList(GetCompany());
//                flowKindOfContract.FillMTBList(kindOfContractList);
//                flowKindOfContract = null;
//                return kindOfContractList.GetArrayList();
//            }
//        }
//        public ArrayList DataSourceCustomerDept(Customer value)
//        {
//            CustomerDepartmentFlow flowCustomerDept = new CustomerDepartmentFlow();
//            CustomerDepartmentList CustomerDeptList = new CustomerDepartmentList(GetCompany());
//            CustomerDeptList.ACustomer = value;
//            flowCustomerDept.FillCustomerDepartmentList(ref CustomerDeptList);
//            flowCustomerDept = null;
//            return CustomerDeptList.GetArrayList();			
//        }
//        #endregion

//        #region - DataSource FarPoint -
//        public KindOfVehicleList ObjKindOfVehicleList;
//        public ComboBoxCellType DataSourceKindOfVehicle
//        {
//            get
//            {
//                KindOfVehicleFlow flowMTB = new KindOfVehicleFlow();
//                KindOfVehicleList mtbList = new KindOfVehicleList(GetCompany());

//                flowMTB.FillMTBList(mtbList);
//                flowMTB = null;

//                string[] items;
//                string[] itemData;

//                items = new string[mtbList.Count];
//                itemData = new string[mtbList.Count];

//                KindOfVehicle kindOfVehicle;

//                for(int i=0; i<mtbList.Count; i++)
//                {
//                    items[i] = ((DualFieldBase)mtbList.BaseGet(i)).AName.English;
//                    itemData[i] = ((DualFieldBase)mtbList.BaseGet(i)).Code;

//                    kindOfVehicle = (KindOfVehicle)mtbList.BaseGet(i);
//                    ObjKindOfVehicleList.Add(kindOfVehicle.AName.English, kindOfVehicle);
//                }

//                ComboBoxCellType comboBox = new ComboBoxCellType();
//                comboBox.Items = items;
//                comboBox.ItemData = itemData;


//                items = null;
//                itemData = null;

//                return comboBox;			
//            }
//        }

//        #endregion - DataSource FarPoint -
		
////		============================== Constructor ==============================
//        public ContractFacade()
//        {
//            ObjKindOfVehicleList = new KindOfVehicleList(GetCompany());
//            flowContract = new ContractFlow();
//            flowVehicle = new VehicleFlow();
//            flowContractRunningNo = new DocumentNoFlow();
//            flowVehicleAssignment = new VehicleAssignmentFlow();
//            flowAge = new AgeFlow();
//        }

////		============================== Public Method ==============================		
//        public DayMonthYearStructure CalAge(DateTime start, DateTime end)
//        {
//            return flowAge.DaysDiff(start, end.AddDays(1));
//        }

//        public ContractBase RetriveContract(DocumentNo value)
//        {
//            return flowContract.RetriveContract(value, GetCompany());
//        }

//        public DocumentNo RetriveContractRunningNo()
//        {
//           return flowContractRunningNo.GetContractRunningNo(DOCUMENT_TYPE.CONTRACT, GetCompany());
//        }

//        public Vehicle GetVehicleGeneral(int vehicleNo)
//        {
//            return flowVehicle.GetVehicleGeneral(vehicleNo, GetCompany());
//        }

//        public bool FillExcludeAvailableVehicleSpareAssignment(ref VehicleAssignment value)
//        {
//            return flowVehicleAssignment.FillExcludeAvailableVehicleSpareAssignment(ref value, GetCompany());
//        }

//        public bool FillVehicleActive(Vehicle value)
//        {
//            return flowVehicle.FillVehicleActive(value, GetCompany());		
//        }

//        public bool ModeInsertContract(ContractBase value)
//        {
	
//            CommonFlow flowCommon = new CommonFlow();
//            value.ContractDate = flowCommon.GetSystemDate();
//            value.CancelDate = flowCommon.GetNullDate();
//            if (flowContract.InsertContract(value, GetCompany()))
//            {return true;}
//            else		
//            {return false;}
//        }

//        public bool ModeUpdateContract(ContractBase value)
//        {
//            CommonFlow flowCommon = new CommonFlow();
//            if(value.AContractStatus.Code == "1")
//                value.CancelDate = flowCommon.GetNullDate();
//            if(value.AContractStatus.Code == "2")
//                value.CancelDate = flowCommon.GetNullDate();
//            if(value.AContractStatus.Code == "3")
//                value.CancelDate = flowCommon.GetSystemDate();

//            if (flowContract.UpdateContract(value, GetCompany()))
//            {return true;}
//            else		
//            {return false;}
//        }

//        public bool ModeDeleteContract(ContractBase value)
//        {
//            if (flowContract.DeleteContract(value, GetCompany()))
//            {
//                return true;
//            }
//            return false;
//        }

//        // ModeUpdateContract in CASE : Change from Vehicle Contract to others. 
//        public bool ModeUpdateContractChangeVehicleContract(ContractBase value)
//        {
//            CommonFlow flowCommon = new CommonFlow();

//            VehicleContract aVehicleContract = (VehicleContract)value;

//            if(value.AContractStatus.Code == "1")
//                value.CancelDate = flowCommon.GetNullDate();

//            if (flowContract.UpdateContractChangeVehicleContract(aVehicleContract, GetCompany()))
//            {
//                return true;
//            }		
//            return false;
//        }
//    }
//}





