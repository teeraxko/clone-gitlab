using System;
using Facade.CommonFacade;
using Entity.VehicleEntities.Leasing;
using Entity.VehicleEntities.ProfitCalculation;
using Flow.VehicleFlow.ProfitCalculation;
using Flow.VehicleEntities.Leasing;
using ictus.Common.Entity;
using System.Collections;
using Entity.VehicleEntities;
using Entity.ContractEntities;
using PTB.BTS.Contract.Flow;
using PTB.BTS.Vehicle.Flow;

namespace Facade.VehicleFacade.ProfitCalculation
{
    public class ProfitCalculationFacade : Facade.PiFacade.CommonPIFacadeBase
    {
        private ProfitCalculationFlow flowProfitCalculation;
        private QuotationFlow flowQuotation;

        //================================= Constructor ================================
        public ProfitCalculationFacade() : base()
        {
            flowProfitCalculation = new ProfitCalculationFlow();
            flowQuotation = new QuotationFlow();
        }

        //================================= Public method ================================
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

        public bool FillQuotation(Quotation quotation)
        {
            return flowQuotation.FillQuotation(quotation, new Company("12"));
        }

        public LeasingCalculation CalculateLeasing(Quotation quotation)
        {
            return LeasingCalculationFlow.Calculate(quotation.AnewVehicle.VehicleCost, quotation.LeaseTerm, quotation.LeasingCalculation.PercentOfResidual, quotation.LeasingCalculation.RateOfReturn);
        }

        public bool CalculateProfit(ProfitCal value)
        {
            return flowProfitCalculation.CalculateProfit(value);
        }
    }
}
