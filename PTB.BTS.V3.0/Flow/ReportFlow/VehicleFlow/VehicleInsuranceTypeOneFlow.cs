using System;
using System.Collections.Generic;
using System.Text;

using PTB.BTS.Common.Flow;

using DataAccess.VehicleDB;

using Entity.VehicleEntities;

using ictus.Common.Entity;

namespace PTB.BTS.Vehicle.Flow
{
    public class VehicleInsuranceTypeOneFlow : CommonFlow
    {
        #region - Private -
        private InsuranceTypeOneDB dbInsuranceTypeOne;
        private InsuranceTypeOneDetailDB dbInsuranceTypeOneDetail;
        #endregion

        //====================================Constructor================
        public VehicleInsuranceTypeOneFlow() : base()
        {
            dbInsuranceTypeOne = new InsuranceTypeOneDB();
            dbInsuranceTypeOneDetail = new InsuranceTypeOneDetailDB();
        }

        //====================================Public Method================
        #region - InsuranceTypeOne -
        public InsuranceTypeOne GetInsuranceTypeOne(string policyNo, Company aCompany)
        {
            return dbInsuranceTypeOne.GetInsuranceTypeOne(policyNo, aCompany);
        }

        public bool FillInsuranceTypeOneList(ref InsuranceTypeOneList value, string endDate, string companyInsuranceCode)
        {
            return dbInsuranceTypeOne.FillInsuranceTypeOneList(ref value, endDate, companyInsuranceCode);
        }

        public bool InsertInsuranceTypeOne(InsuranceTypeOne value, Company aCompany)
        {
            return dbInsuranceTypeOne.InsertInsuranceTypeOne(value, aCompany);
        }

        public bool UpdateInsuranceTypeOne(InsuranceTypeOne value, Company aCompany)
        {
            return dbInsuranceTypeOne.UpdateInsuranceTypeOne(value, aCompany);
        }

        public bool DeleteInsuranceTypeOne(InsuranceTypeOne value, Company aCompany)
        {
            return dbInsuranceTypeOne.DeleteInsuranceTypeOne(value, aCompany);
        }

        #endregion

        #region - InsuranceTypeOneDetail -
        public bool FillInsuranceTypeOneDetail(ref InsuranceTypeOne value)
        {
            return dbInsuranceTypeOneDetail.FillInsuranceTypeOneDetail(ref value);
        }

        public bool FillInsuranceTypeOneDetailList(ref VehicleInsuranceList value)
        {
            return dbInsuranceTypeOneDetail.FillInsuranceTypeOneDetailList(ref value);
        }

        public bool FillInsuranceTypeOneDetailList(ref VehicleInsuranceList value, VehicleInfo vehicleInfo)
        {
            return dbInsuranceTypeOneDetail.FillInsuranceTypeOneDetailList(ref value, vehicleInfo);
        }

        public int CountData(InsuranceTypeOne value, Company aCompany)
        {
            return dbInsuranceTypeOneDetail.CountData(value, aCompany);
        }

        public bool InsertInsuranceTypeOneDetail(VehicleInsuranceTypeOne value, Company aCompany)
        {
            return dbInsuranceTypeOneDetail.InsertInsuranceTypeOneDetail(value, aCompany);
        }

        public bool UpdateInsuranceTypeOneDetail(VehicleInsuranceTypeOne value, Company aCompany)
        {
            return dbInsuranceTypeOneDetail.UpdateInsuranceTypeOneDetail(value, aCompany);
        }

        public bool DeleteInsuranceTypeOneDetail(VehicleInsuranceTypeOne value, Company aCompany)
        {
            return dbInsuranceTypeOneDetail.DeleteInsuranceTypeOneDetail(value, aCompany);
        }
        #endregion
    }
}
