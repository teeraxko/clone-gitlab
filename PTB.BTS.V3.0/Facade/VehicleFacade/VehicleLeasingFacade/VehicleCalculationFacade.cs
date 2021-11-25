using System;
using System.Collections.Generic;
using System.Text;

using PTB.BTS.Contract.Flow;
using PTB.BTS.Vehicle.Flow;

using Flow.VehicleFlow.VehicleLeasingFlow;
using Flow.VehicleEntities.Leasing;

using ictus.Common.Entity;
using System.Collections;

using Entity.VehicleEntities.VehicleLeasing;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using Facade.PiFacade;
using Facade.CommonFacade;

namespace Facade.VehicleFacade.VehicleLeasingFacade
{
    public class VehicleCalculationFacade : CommonPIFacadeBase
    {
        #region Private
        private VehicleCalculationFlow flowVehicleCalculation;
        #endregion 

        #region Property

        private VehicleCalculation objVehicleCalculation;
        private List<VehicleCalculation> objVehicleCalculationList;
        public VehicleCalculation ObjVehicleCalculation
        {
            get { return objVehicleCalculation; }
            set { objVehicleCalculation = value; }
        }
        public List<VehicleCalculation> ObjVehicleCalculationList
        {
            get { return objVehicleCalculationList; }
            set { objVehicleCalculationList = value; }
        }

        #endregion

        #region Constructor

        public VehicleCalculationFacade()
            : base()
        {
            flowVehicleCalculation = new VehicleCalculationFlow();
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

        public List<VehicleCalculation> GetVehicleSearchCalculation(Customer aCustomer, Brand aBrand, Model aModel,string quotationNo)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                return flow.GetVehicleSearchCalculation(aCustomer, aBrand, aModel,quotationNo,GetCompany());
            }
        }

        public List<VehicleCalculation> GetVehicleSearchCalculationQuotation(Customer aCustomer, Brand aBrand, Model aModel)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                return flow.GetVehicleSearchCalculationQuotation(aCustomer, aBrand, aModel, GetCompany());
            }
        }

        public List<VehicleCalculation> GetVehicleSearchConditionByPlateNo(string plateNoPrefix, string plateNoRunning)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                return flow.GetVehicleSearchConditionByPlateNo(plateNoPrefix, plateNoRunning, GetCompany());
            }
        }

        public List<VehicleCalculation> GetVehicleSearchConditionListByQuotationNo(DocumentNo documentNo)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                return flow.GetVehicleSearchConditionListByQuotationNo(documentNo, GetCompany());
            }
        }

        public VehicleCalculation GetVehicleSearchConditionByQuotationNo(DocumentNo documentNo)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                return flow.GetVehicleSearchConditionByQuotationNo(documentNo, GetCompany());
            }
        }

        public List<VehicleCalculation> GetVehicleUpdateCondition(VehicleCalculation vehicleCalculation)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                return flow.GetVehicleUpdateCondition(vehicleCalculation, GetCompany());
            }
        }

        public VehicleCalculation GetVehicleCalculationByCalculationNo(VehicleCalculation vehicleCalculation)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                return flow.GetVehicleCalculationByCalculationNo(vehicleCalculation, GetCompany());
            }
        }

        public VehicleCalculation GetVehicleConditionByQuotationNo(DocumentNo documentNo, Customer aCustomer, Brand aBrand, Model aModel)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                return flow.GetVehicleConditionByQuotationNo(documentNo, aCustomer, aBrand, aModel, GetCompany());
            }
        }

        public bool InsertVehicleCalculation(VehicleCalculation vehicleCalculation)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                return flow.InsertVehicleCalculation(vehicleCalculation, GetCompany());
            }
        }

        public bool DeleteVehicleCalculation(VehicleCalculation value)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                if (flow.DeleteVehicleCalculation(value, GetCompany()))
                {
                    return true;
                }
            }
            return false;
        }

        public bool UpdateVehicleCalculation(VehicleCalculation vehicleCalculation)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                return flow.UpdateVehicleCalculation(vehicleCalculation, GetCompany());
            }
        }

        /// <summary>
        /// Function    : Send parameter in to calculate monthly charge
        /// Author      : Thawatchai B.
        /// Create date : 08/10/08
        /// </summary>
        /// <param name="vehicleCalculation"></param>
        /// <returns>calculated monthly charge</returns>
        public VehicleLeasingCalculation CalculateMonthlyCharge(VehicleCalculation vehicleCalculation)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                return flow.Calculate(vehicleCalculation);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool CalculateProfit(VehicleCalculation value, VehicleInfo vehicleInfo)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                return flowVehicleCalculation.CalculateProfit(value, GetCompany(), vehicleInfo);
            }
        }

        public VehicleInfo GetVehicleInfoByQuotation(DocumentNo quotationNo)
        {
            using (VehicleCalculationFlow flow = new VehicleCalculationFlow())
            {
                return flowVehicleCalculation.GetVehicleInfoByQuotation(quotationNo, GetCompany());
            }
        }

        public Customer GetCustomer(string customerCode)
        {
            using (CustomerFlow flow = new CustomerFlow())
            {
                return flow.GetCustomer(customerCode, GetCompany());
            }
        }

        public Model GetModel(string modelCode, string brandCode)
        {
            using (ModelFlow flow = new ModelFlow())
            {
                return flow.GetModel(modelCode, brandCode);
            }
        }
        #endregion

    }
}
