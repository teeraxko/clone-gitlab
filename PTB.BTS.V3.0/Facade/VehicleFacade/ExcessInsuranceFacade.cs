using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using ictus.Common.Entity;
using Entity.VehicleEntities;

using PTB.BTS.Vehicle.Flow;

using Facade.PiFacade;

using SystemFramework.AppException;

namespace Facade.VehicleFacade
{
    public class ExcessInsuranceFacade : CommonPIFacadeBase
    {
        private VehicleAccidentFlow flowVehicleAccident;

        private VehicleAccident vehicleAccident;
        public VehicleAccident VehicleAccident
        {
            get { return vehicleAccident; }
        }	

        //============================== DataSource ==============================
        public ArrayList DataSourceInsuranceCompName
        {
            get
            {
                InsuranceCompanyFlow flowInsuranceCompany = new InsuranceCompanyFlow();
                InsuranceCompanyList insuranceCompanyList = new InsuranceCompanyList(GetCompany());
                flowInsuranceCompany.FillInsuranceCompanyList(ref insuranceCompanyList);
                return insuranceCompanyList.GetArrayList();
            }
        }

        //============================== Constructor ==============================
        public ExcessInsuranceFacade() : base()
        {
            flowVehicleAccident = new VehicleAccidentFlow();
        }

        //============================== Public Method ==============================
        public bool DisplayAccident(string forYear)
        {
            vehicleAccident = new VehicleAccident(GetCompany());
            return flowVehicleAccident.FillVehicleAccidentByYearList(vehicleAccident, forYear);
        }

        public bool UpdateTotalExcessAmount(Accident accident)
        {
            return flowVehicleAccident.UpdateAccident(accident, false) ;
        }
    }
}
