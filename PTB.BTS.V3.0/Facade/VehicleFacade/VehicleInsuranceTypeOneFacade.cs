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
    public class VehicleInsuranceTypeOneFacade : CommonPIFacadeBase
    {
        private VehicleInsuranceTypeOneFlow flowVehicleInsuranceTypeOne;
        private VehicleFlow flowVehicle;

        //============================== Property ==============================
        private VehicleInsuranceList objVehicleInsuranceList;
        public VehicleInsuranceList ObjVehicleInsuranceList
        {
            get { return objVehicleInsuranceList; }
            set { objVehicleInsuranceList = value; }
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
        public VehicleInsuranceTypeOneFacade() : base()
        {
            flowVehicleInsuranceTypeOne = new VehicleInsuranceTypeOneFlow();
            flowVehicle = new VehicleFlow();
        }

        //============================== Public Method ==============================
        public bool DisplayVehicleInsurance(InsuranceTypeOne value)
        {
            objVehicleInsuranceList = new VehicleInsuranceList(GetCompany());
            value.AVehicleInsuranceList = new VehicleInsuranceList(GetCompany());

            if (flowVehicleInsuranceTypeOne.FillInsuranceTypeOneDetail(ref value))
            {
                objVehicleInsuranceList = value.AVehicleInsuranceList;
                return true;
            }
            else
            {
                objVehicleInsuranceList.Clear();
                return false;            
            }
        }

        public InsuranceTypeOne GetInsuranceTypeOne(string policyNo)
        {
            return flowVehicleInsuranceTypeOne.GetInsuranceTypeOne(policyNo, GetCompany());
        }

        public void CalculateTotalPremium(VehicleInsuranceTypeOne value, decimal VatRate)
        {
            VehicleFunction.CalculateTotalPremium(value, VatRate);
        }

        public decimal GetVatRate()
        {
            return VehicleFunction.GetVATRate().Rate;
        }

        public VehicleInfo GetVehicleInfo(string platePrefix, string plateNo)
        {
            VehicleInfo vehicleInfo = new VehicleInfo();
            vehicleInfo.PlatePrefix = platePrefix;
            vehicleInfo.PlateRunningNo = plateNo;

            if (flowVehicle.FillVehicleInfo(ref vehicleInfo, GetCompany()))
            {
                return vehicleInfo;
            }
            else
            {
                vehicleInfo = null;
                return null;
            }
        }

        public VehicleInsuranceList GetInsuranceByVehicleNo(VehicleInfo vehicleInfo)
        {
            VehicleInsuranceList result = new VehicleInsuranceList(GetCompany());

            if (flowVehicleInsuranceTypeOne.FillInsuranceTypeOneDetailList(ref result, vehicleInfo))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public bool CheckOutInsurance(Vehicle value, DateTime startDate, DateTime endDate)
        {
            bool result = true;
            VehicleFlow flowVehicle = new VehicleFlow();
            VehicleList vehicleList = new VehicleList(GetCompany());
            Vehicle vehicle = new Vehicle();
            flowVehicle.FillVehicleOutInsurance(ref vehicleList, startDate, endDate, vehicle);
            if (vehicleList.Contain(value))
            {
                result = false;
            }
            flowVehicle = null;
            vehicleList = null;
            return result;
        }

        public bool InsertInsuranceTypeOneDetail(VehicleInsuranceTypeOne value)
        {
            if (objVehicleInsuranceList.Contain(value))
            {
                throw new DuplicateException("VehicleInsuranceTypeOneFacade");
            }
            else
            {
                if (flowVehicleInsuranceTypeOne.InsertInsuranceTypeOneDetail(value, GetCompany()))
                {
                    objVehicleInsuranceList.Add(value);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateInsuranceTypeOneDetail(VehicleInsuranceTypeOne value)
        {
            if (flowVehicleInsuranceTypeOne.UpdateInsuranceTypeOneDetail(value, GetCompany()))
            {
                objVehicleInsuranceList[value.EntityKey] = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteInsuranceTypeOneDetail(VehicleInsuranceTypeOne value)
        {
            if (flowVehicleInsuranceTypeOne.DeleteInsuranceTypeOneDetail(value, GetCompany()))
            {
                objVehicleInsuranceList.Remove(value);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
