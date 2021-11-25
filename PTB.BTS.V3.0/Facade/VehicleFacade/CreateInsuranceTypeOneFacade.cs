using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using PTB.BTS.Vehicle.Flow;

using Facade.PiFacade;

using ictus.Common.Entity;
using Entity.VehicleEntities;

using SystemFramework.AppException;

namespace Facade.VehicleFacade
{
    public class CreateInsuranceTypeOneFacade : CommonPIFacadeBase
    {
        private VehicleInsuranceTypeOneFlow flowVehicleInsuranceTypeOne;

        //============================== Property ==============================
        private InsuranceTypeOneList objInsuranceTypeOneList;
        public InsuranceTypeOneList ObjInsuranceTypeOneList
        {
            get { return objInsuranceTypeOneList; }
            set { objInsuranceTypeOneList = value; }
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
        public CreateInsuranceTypeOneFacade() : base()
        {
            flowVehicleInsuranceTypeOne = new VehicleInsuranceTypeOneFlow();
        }

        //============================== Public Method ==============================
        public bool DisplayInsuranceTypeOne(string endDate, string insuranceCompanyCode)
        {
            objInsuranceTypeOneList = new InsuranceTypeOneList(GetCompany());
            return flowVehicleInsuranceTypeOne.FillInsuranceTypeOneList(ref objInsuranceTypeOneList, endDate, insuranceCompanyCode);
        }

        public void CalculateTotalPremium(InsuranceTypeOne value, decimal VatRate)
        {
            VehicleFunction.CalculateTotalPremium(value, VatRate);
        }

        public decimal GetVatRate()
        {
            return VehicleFunction.GetVATRate().Rate;
        }

        public int CountData(InsuranceTypeOne value)
        {
            return flowVehicleInsuranceTypeOne.CountData(value, GetCompany());
        }

        public bool InsertInsuranceTypeOne(InsuranceTypeOne value)
        {
            if (objInsuranceTypeOneList.Contain(value))
            {
                throw new DuplicateException("CreateInsuranceTypeOneFacade");
            }
            else
            {
                if (flowVehicleInsuranceTypeOne.InsertInsuranceTypeOne(value, GetCompany()))
                {
                    objInsuranceTypeOneList.Add(value);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }

        public bool UpdateInsuranceTypeOne(InsuranceTypeOne value)
        {
            if (flowVehicleInsuranceTypeOne.UpdateInsuranceTypeOne(value, GetCompany()))
            {
                objInsuranceTypeOneList[value.EntityKey] = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteInsuranceTypeOne(InsuranceTypeOne value)
        {
            if (flowVehicleInsuranceTypeOne.DeleteInsuranceTypeOne(value, GetCompany()))
            {
                objInsuranceTypeOneList.Remove(value);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
