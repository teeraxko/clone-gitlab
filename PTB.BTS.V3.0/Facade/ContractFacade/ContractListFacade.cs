using Entity.CommonEntity;
using Entity.ContractEntities;
using Facade.PiFacade;
using Flow.VehicleFlow.VehicleLeasingFlow;
using PTB.BTS.Contract.Flow;
using System.Collections.Generic;
using Entity.VehicleEntities.VehicleLeasing;

namespace Facade.ContractFacade
{
	public class ContractListFacade : CommonPIFacadeBase
	{
		#region - Private -
			private ContractFlow flowContract;
		#endregion

        #region Property
            private ContractList objContractList;
            public ContractList ObjContractList
            {
                get { return objContractList; }
            }

            private VehicleContract conditionContract;
            public VehicleContract ConditionContract
            {
                get { return conditionContract; }
                set { conditionContract = value; }
            }

            private string yy;
            public string YY
            {
                set { yy = value; }
            }

            private string mm;
            public string MM
            {
                set { mm = value; }
            }

            private string xxx;
            public string XXX
            {
                set { xxx = value; }
            } 
            #endregion

        #region Constructor
        public ContractListFacade()
        {
            flowContract = new ContractFlow();
            conditionContract = new VehicleContract(GetCompany());
        } 
        #endregion

        #region Public Method
        public bool DisplayContract()
        {
            objContractList = new ContractList(GetCompany());
            return flowContract.FillContract(ref objContractList, conditionContract, yy, mm, xxx);
        }

        //D21018-BTS Contract Modification
        public bool DisplayContract(DOCUMENT_TYPE documentType)
        {
            objContractList = new ContractList(GetCompany());
            return flowContract.FillContract(ref objContractList, conditionContract, yy, mm, xxx, documentType);
        }
        
        public bool DisplayVehicleContract()
        {
            conditionContract.ContractNo = new DocumentNo(DOCUMENT_TYPE.CONTRACT, yy, mm, xxx);
            objContractList = new ContractList(GetCompany());
            return flowContract.FillVehicleContractList(ref objContractList, conditionContract);
        }

        public bool DisplayVehicleContract(DOCUMENT_TYPE documentType)
        {
            conditionContract.ContractNo = new DocumentNo(documentType, yy, mm, xxx);
            objContractList = new ContractList(GetCompany());
            return flowContract.FillVehicleContractList(ref objContractList, conditionContract);
        }

        public bool DisplayDriverOtherContract()
        {
            bool result;

            objContractList = new ContractList(GetCompany());

            if (conditionContract.AContractType == null)
            {
                ContractType contractType = new ContractType();
                contractType.Code = "D";
                conditionContract.AContractType = contractType;
                result = flowContract.FillContractList(ref objContractList, conditionContract);

                contractType.Code = "O";
                conditionContract.AContractType = contractType;
                result |= flowContract.FillContractList(ref objContractList, conditionContract);
                contractType = null;

                return result;
            }
            else
            {
                result = flowContract.FillContractList(ref objContractList, conditionContract);
                return result;
            }
        }        

        public bool DisplayAvailableContract()
        {
            objContractList = new ContractList(GetCompany());
            //D21018 ส่ง Document Type เป็น Driver
            return flowContract.FillAvailableContractList(ref objContractList, conditionContract, yy, mm, xxx, DOCUMENT_TYPE.CONTRACT_DRIVER);
            //return flowContract.FillAvailableContractList(ref objContractList, conditionContract, yy, mm, xxx);
        }

        public bool DisplayContractVehiclePurchasing()
        {
            objContractList = new ContractList(GetCompany());
            //D21018 ออกสัญญาพนักงานขับรถ + ออกสัญญารถเช่า -> ข้อมูลออกเฉพาะสัญญารถใหม่ และที่มีใบสั่งซื้อเท่านั้น กำหนด Abbreviation เป็น C เพื่อกรองอีกชั้น
            conditionContract.AContractTypeAbbreviation = "C";
            return flowContract.FillContractVehiclePurchasing(objContractList, conditionContract);
        }

        public string GetPurchaseNoByContract(DocumentNo contractNo)
        {
            using (VehiclePurchasingContractFlow flow = new VehiclePurchasingContractFlow())
            {
                List<VehiclePurchasingContract> list = flow.GetPurchasingContractListByContract(contractNo);

                if (list.Count > 0)
                {
                    return list[0].Contract.ContractNo.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        } 
        #endregion
	}
}