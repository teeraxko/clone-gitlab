using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;
using DataAccess.VehicleDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Vehicle.Flow
{
    public class VehicleFlow : FlowBase
    {
        #region - Private -
        private VehicleDB dbVehicle;
        #endregion

        //		================================ Constructor ================================
        public VehicleFlow()
            : base()
        {
            dbVehicle = new VehicleDB();
        }

        //		================================ Private Method ================================
        private bool updateProvince(VehicleInfo value)
        {
            bool result = true;
            ProvinceDB dbProvince = new ProvinceDB();
            Province province = new Province();
            province.Name = value.PlateProvince.Name;
            result = dbProvince.UpdateMTB(province);
            dbProvince = null;
            province = null;

            return result;
        }

        //		================================ Public Method ================================
        public Entity.VehicleEntities.Vehicle GetVehicleGeneral(int vehicleNo, Company value)
        {
            return dbVehicle.GetVehicleGeneral(vehicleNo, value);
        }

        public bool FillVehicleGeneral(ref Entity.VehicleEntities.Vehicle value, Company aCompany)
        {
            return dbVehicle.FillVehicleGeneral(ref value, aCompany);
        }

        public VehicleInfo GetVehicleInfo(int vehicleNo, Company value)
        {
            return dbVehicle.GetVehicleInfo(vehicleNo, value);
        }

        public bool FillVehicleInfo(ref VehicleInfo value, Company aCompany)
        {
            return dbVehicle.FillVehicleInfo(ref value, aCompany);
        }

        public bool FillVehicleList(ref VehicleList aVehicleList)
        {
            return dbVehicle.FillVehicleList(ref aVehicleList);
        }

        public bool FillVehicleList(ref VehicleList aVehicleList, Entity.VehicleEntities.Vehicle aVehicle)
        {
            return dbVehicle.FillVehicleList(ref aVehicleList, aVehicle);
        }

        public bool FillVehicleList(ref VehicleList aVehicleList, string purchaseNo)
        {
            return dbVehicle.FillVehicleList(ref aVehicleList, purchaseNo);
        }

        public bool FillVehicleActiveList(ref VehicleList aVehicleList)
        {
            return dbVehicle.FillVehicleActiveList(ref aVehicleList);
        }

        public bool FillVehicleActiveList(VehicleList vehicleList, DateTime fromDate, DateTime toDate)
        {
            return dbVehicle.FillVehicleActiveList(vehicleList, fromDate, toDate);
        }

        public bool FillVehicleActive(Entity.VehicleEntities.Vehicle value, Company aCompany)
        {
            return dbVehicle.FillVehicleActive(value, aCompany);
        }

        public bool FillVehicleOutInsurance(ref VehicleList value, DateTime startDate, DateTime endDate, Entity.VehicleEntities.Vehicle conditionVehicle)
        {
            return dbVehicle.FillVehicleOutInsurance(ref value, startDate, endDate, conditionVehicle);
        }

        public bool FillVehicleIsAssign(ref VehicleList value, Entity.VehicleEntities.Vehicle aVehicle)
        {
            return dbVehicle.FillVehicleIsAssignList(ref value, aVehicle);
        }

        public bool FillVehicleIsAssign(ref Entity.VehicleEntities.Vehicle value, Company aCompany)
        {
            return dbVehicle.FillVehicleIsAssign(ref value, aCompany);
        }

        public bool FillVehicleIsAssignList(VehicleList vehicleList, DateTime fromDate, DateTime toDate, Entity.VehicleEntities.Vehicle vehicle)
        {
            return dbVehicle.FillVehicleIsAssignList(vehicleList, fromDate, toDate, vehicle);
        }

        public bool FillVehicleAvailableList(ref VehicleList value)
        {
            return dbVehicle.FillVehicleAvailableList(ref value);
        }

        public bool FillVehicleForCreateQuotation(VehicleList value, string platePrefix, string plateRunningNo, int quotationType)
        {
            return dbVehicle.FillVehicleForCreateQuotation(value, platePrefix, plateRunningNo, quotationType);
        }


        public bool InsertVehicle(VehicleInfo value, Company aCompany)
        {
            int vehicleNo = dbVehicle.InsertVehicle(value, aCompany);

            if (vehicleNo != 0)
            {
                return updateProvince(value);
            }
            return false;
        }

        public bool UpdateVehicleForVehicle(VehicleInfo value, Company aCompany)
        {
            if (dbVehicle.UpdateVehicleInfo(value, value.AKindOfVehicle, aCompany))
            {
                return updateProvince(value);
            }
            return false;
        }

        public bool UpdateVehicleInfo(VehicleInfo value, Company aCompany)
        {
            return dbVehicle.UpdateVehicleInfo(value, value.AKindOfVehicle, aCompany);
        }

        public bool UpdateVehicleGeneral(Entity.VehicleEntities.Vehicle value, Company aCompany)
        {
            return dbVehicle.UpdateVehicleGeneral(value, value.AKindOfVehicle, aCompany);
        }

        public bool DeleteVehicle(Entity.VehicleEntities.Vehicle value, Company aCompany)
        {
            Entity.VehicleEntities.Vehicle vehicle = new Entity.VehicleEntities.Vehicle();
            vehicle.VehicleNo = value.VehicleNo;
            bool result = dbVehicle.DeleteVehicle(vehicle, aCompany);
            vehicle = null;

            return result;
        }


        public bool FillVehicleListByCalculation(ref VehicleList aVehicleList, Entity.VehicleEntities.Vehicle aVehicle)
        {
            return dbVehicle.FillVehicleListCalculation(ref aVehicleList, aVehicle);
        }

        /// <summary>
        /// Get maximum lease term for maintenace car report
        /// </summary>
        /// <returns></returns>
        public int GetVehicleContractLeaseTerm(string customerCode, string brandCode, int registerDate)
        {
            return dbVehicle.GetVehicleContractLeaseTerm(customerCode,brandCode,registerDate);
        }
    }
}
