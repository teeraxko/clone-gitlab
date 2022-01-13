using Entity.CommonEntity;
using Entity.ContractEntities;
using Facade.PiFacade;
using Flow.VehicleFlow.VehicleLeasingFlow;
using PTB.BTS.Contract.Flow;
using System.Collections.Generic;
using Entity.VehicleEntities.VehicleLeasing;

namespace Facade.ContractFacade
{
	public class ContractAttachmentListFacade : CommonPIFacadeBase
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
            public ContractAttachmentListFacade()
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

        
        #endregion
	}
}