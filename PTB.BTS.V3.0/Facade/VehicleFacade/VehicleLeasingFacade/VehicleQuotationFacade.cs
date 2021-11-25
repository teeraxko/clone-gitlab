using System;
using System.Collections.Generic;
using System.Text;

using PTB.BTS.Contract.Flow;
using PTB.BTS.Vehicle.Flow;
using PTB.BTS.Common.Flow;

using Flow.VehicleFlow.VehicleLeasingFlow;
using Flow.VehicleEntities.Leasing;

using ictus.Common.Entity;
using ictus.Common.Entity.Time;
using System.Collections;

using Entity.VehicleEntities.VehicleLeasing;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using Facade.PiFacade;
using Facade.CommonFacade;
using Facade.VehicleFacade.LeasingFacade;

namespace Facade.VehicleFacade.VehicleLeasingFacade
{
    public class VehicleQuotationFacade : CommonPIFacadeBase
    {
        #region Private
        private VehicleQuotationFlow flowVehicleQuotation;
        private AgeFlow flowAge;

        private string conditionQuotationNo;
        public string ConditionQuotationNo
        {
            set { conditionQuotationNo = value; }
            get { return conditionQuotationNo; }
        }

        #endregion 

        #region Property

        private VehicleQuotation objVehiclQuotation;
        private List<VehicleQuotation> objVehicleQuotationList;

        public VehicleQuotation ObjVehiclQuotation
        {
            get { return objVehiclQuotation; }
            set { objVehiclQuotation = value; }
        }

        public List<VehicleQuotation> ObjVehicleQuotationList
        {
            get { return objVehicleQuotationList; }
            set { objVehicleQuotationList = value; }
        }

        private VehicleList objVehicleList;
        public VehicleList ObjVehicleList
        {
            get { return objVehicleList; }
        }

      


        #endregion

        #region Constructor

        public VehicleQuotationFacade()
            : base()
        {
            flowVehicleQuotation = new VehicleQuotationFlow();
            flowAge = new AgeFlow();
        }

        #endregion

        #region Public Method

        public ArrayList DataSourceCustomer
        {
            get
            {
                CustomerList CustomerList = new CustomerList(GetCompany());
                using (CustomerFlow flowCustomer = new CustomerFlow())
                {
                    flowCustomer.FillCustomer(ref CustomerList);
                }
                return CustomerList.GetArrayList();
            }
        }

        public ArrayList DataSourceBrand
        {
            get
            {
                BrandList brandList = new BrandList();
                using (BrandFlow flowBrand = new BrandFlow())
                {
                    flowBrand.FillMTBList(brandList);
                }
                return brandList.GetArrayList();
            }
        }

        public ArrayList DataSourceModel(Brand value)
        {

            ModelList modelList = new ModelList();
            modelList.ABrand = value;
            using (ModelFlow flowModel = new ModelFlow())
            {
                flowModel.FillModel(ref modelList);
            }

            return modelList.GetArrayList();
        }

        /// <summary>
        /// Method      : Get lastest running contract no.
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        /// <param name="docType"></param>
        /// <returns>running contract no</returns>
        public DocumentNo RetriveRunningNo(Entity.CommonEntity.DOCUMENT_TYPE docType)
        {
            using (DocumentNoFlow flowContractRunningNo = new DocumentNoFlow())
            {
                return flowContractRunningNo.GetContractRunningNo(docType, GetCompany());
            }
        }



        public DocumentNo RetriveRunningNo(DocumentNo Leasing)
        {

            return Leasing;
            
        }







        public List<VehicleQuotation> SearchQuotation(Customer aCustomer, Brand aBrand, Model aModel, DocumentNo quotationNo, DateTime aIssueDate)
        {
            using (VehicleQuotationFlow flow = new VehicleQuotationFlow())
            {
                return flow.FillQuotation(aCustomer, aBrand, aModel, quotationNo, aIssueDate, GetCompany());
            }
        }

        public List<VehicleQuotation> SearchQuotationPurchase(DocumentNo quotationNo, DateTime aIssueDate)
        {
            using (VehicleQuotationFlow flow = new VehicleQuotationFlow())
            {
                return flow.FillQuotationPurchase(quotationNo, aIssueDate, GetCompany());
            }
        }

        public List<VehicleQuotation> GetQuotationListByQuotation(string quotationNo)
        {
            using (VehicleQuotationFlow flow = new VehicleQuotationFlow())
            {
                return flow.GetQuotationListByQuotationNo(quotationNo, GetCompany());
            }
        }

        public List<VehicleCalculation> GetVehicleSearchConditionByPlateNo(string plateNoPrefix, string plateNoRunning)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
                return flow.GetVehicleSearchConditionByPlateNo(plateNoPrefix, plateNoRunning, GetCompany());
        }

        public VehicleQuotation GetQuotationtByQuotationNo(string quotationNo)
        {
            using (VehicleQuotationFlow flow = new VehicleQuotationFlow())
            {
                return flow.GetQuotationtByQuotationNo(quotationNo, GetCompany());
            }
        }


   




        //public VehicleCalculation GetVehicleCalculationByPlateNo(string plateNoPrefix, string plateNoRunning)
        //{
        //    using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
        //    {
        //        return flow.GetVehicleCalculationByPlateNo(plateNoPrefix, plateNoRunning, GetCompany());
        //    }
        //}

        //public VehicleInfo GetVehicleInfo(int vehicleNo)
        //{
        //    using (VehicleFlow flowVehicle = new VehicleFlow())
        //    {
        //        return flowVehicle.GetVehicleInfo(vehicleNo, GetCompany());
        //    }

        //}

        public bool InsertVehicleQuotation(VehicleCalculation vehicleCalculation)
        {
            using (VehicleQuotationFlow flow = new VehicleQuotationFlow())
            {
                return flow.InsertVehicleQuotation(vehicleCalculation, GetCompany());
            }
        }

        public bool UpdateVehicleQuotation(VehicleQuotation vehicleQuotation)
        {
            using (VehicleQuotationFlow flow = new VehicleQuotationFlow())
            {
                return flow.UpdateVehicleQuotation(vehicleQuotation);
            }
        }

        public bool UpdateVehicleLeasing(VehicleCalculation vehicleCalculation)
        {
            using (VehicleQuotationFlow flow = new VehicleQuotationFlow())
            {
                return flow.UpdateVehicleLeasing(vehicleCalculation, GetCompany());
            }
        }




        public bool DeleteVehicleQuotation(VehicleQuotation value)
        {
            using (VehicleQuotationFlow flow = new VehicleQuotationFlow())
                if (flow.DeleteVehicleQuotation(value))
                {
                    return true;
                }
            return false;

        }
     
        /// <summary>
        /// Method      : Calculate age
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        /// <param name="value"></param>
        /// <returns>age year month</returns>
        public YearMonth CalculateAge(DateTime value)
        {
            return flowAge.CalculateAge(value);
        }

        /// <summary>
        /// Method      : Get the vehicle information to show for selected
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        /// <returns>true if can get the vwhicle information</returns>
        public bool FillVehicleForCreateQuotation(string prefix, string num, int quotationType)
        {
            objVehicleList = new VehicleList(GetCompany());
            using (VehicleFlow flowVehicle = new VehicleFlow())
            {
                return flowVehicle.FillVehicleForCreateQuotation(objVehicleList, prefix, num, quotationType);
            }
        }

        /// <summary>
        /// Get current vehicle contract by vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>ContractBase</returns>
        public ContractBase GetCurrentVehicleContract(Vehicle vehicle)
        {
            using (ContractFlow flow = new ContractFlow())
            {
                return flow.GetCurrentVehicleContract(vehicle, GetCompany());
            }
        }

        #endregion
    }
}
