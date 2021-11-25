using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Entity.CommonEntity;
using Entity.ContractEntities;
using ictus.PIS.PI.Entity;
using Entity.VehicleEntities;
using Entity.VehicleEntities.VehicleLeasing;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.ContractDB
{
    public class VehicleContractDB : DataAccessBase
    {
        #region - Constant -
        private const int CONTRACT_NO = 0;
        private const int VEHICLE_NO = 1;
        private const int KIND_OF_VEHICLE = 2;
        private const int KIND_OF_RANTAL = 3;
        private const int LEASE_TERM = 4;
        private const int CONTINUOUS_STATUS = 5;
        #endregion

        #region - Private -
        private VehicleDB.VehicleDB dbVehicle;
        private VehicleContract objVehicleContract;
        private bool disposed = false;
        #endregion

        //		============================== Constructor ==============================
        public VehicleContractDB()
            : base()
        {
            dbVehicle = new VehicleDB.VehicleDB();
        }

        //		============================== Private Method ==============================
        #region - getSQL -
        private string getSQLSelect()
        {
            return "SELECT Contract_No, Vehicle_No, Kind_Of_Vehicle, Kind_Of_Rental, Lease_Term, Continuous_Status FROM Vehicle_Contract ";
        }

        private string getSQLInsert(VehicleContract vehicleContract, VehicleRole aVehicleRole, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Vehicle_Contract (Company_Code, Contract_No, Vehicle_No, Kind_Of_Vehicle, Kind_Of_Rental, Lease_Term, Process_Date, Process_User, Continuous_Status) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Contract_No
            stringBuilder.Append(GetDB(vehicleContract.ContractNo.ToString()));
            stringBuilder.Append(", ");

            //Vehicle_No
            stringBuilder.Append(GetDB(aVehicleRole.AVehicle.VehicleNo));
            stringBuilder.Append(", ");

            //Kind_Of_Vehicle
            stringBuilder.Append(GetDB(aVehicleRole.AKindOfVehicle));
            stringBuilder.Append(", ");

            //Kind_Of_Rental
            stringBuilder.Append(GetDB(vehicleContract.KindOfRental));
            stringBuilder.Append(", ");

            //Lease_Term
            stringBuilder.Append(GetDB(vehicleContract.LeaseTermMonth));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(", ");

            //Continuous_Status
            stringBuilder.Append(GetDB(vehicleContract.ContinuousStatus));
            stringBuilder.Append(") ");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(VehicleContract vehicleContract, VehicleRole aVehicleRole, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Vehicle_Contract SET ");
            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Contract_No = ");
            stringBuilder.Append(GetDB(vehicleContract.ContractNo.ToString()));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_No = ");
            stringBuilder.Append(GetDB(aVehicleRole.AVehicle.VehicleNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Kind_Of_Vehicle = ");
            stringBuilder.Append(GetDB(aVehicleRole.AKindOfVehicle));
            stringBuilder.Append(", ");

            stringBuilder.Append("Kind_Of_Rental = ");
            stringBuilder.Append(GetDB(vehicleContract.KindOfRental));
            stringBuilder.Append(", ");

            stringBuilder.Append("Lease_Term = ");
            stringBuilder.Append(GetDB(vehicleContract.LeaseTermMonth));
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_Date = ");
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_User = ");
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(", ");

            stringBuilder.Append("Continuous_Status = ");
            stringBuilder.Append(GetDB(vehicleContract.ContinuousStatus));

            return stringBuilder.ToString();
        }

        private string getSQLDelete()
        {
            return " DELETE FROM Vehicle_Contract ";
        }

        private string getKeyCondition(VehicleContract value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (value != null && value.ContractNo != null && IsNotNULL(value.ContractNo.ToString()))
            {
                stringBuilder.Append(" AND (Contract_No = ");
                stringBuilder.Append(GetDB(value.ContractNo.ToString()));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getKeyCondition(Vehicle value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (value != null && IsNotNULL(value.VehicleNo))
            {
                stringBuilder.Append(" AND (Vehicle_No = ");
                stringBuilder.Append(GetDB(value.VehicleNo));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private void AddKeyParameters(SqlParameterCollection parameters, VehiclePurchasing vehiclePurchasing)
        {
            parameters.Add(this.tableAccess.CreateParameter("@Purchase_No", vehiclePurchasing.PurchasNo.ToString()));
        }

        #endregion

        #region - Fill -
        private void fillVehicleContract(ref VehicleRole value, Company aCompany, SqlDataReader dataReader)
        {
            value.AVehicle = dbVehicle.GetDBVehicleGeneral(dataReader.GetInt32(VEHICLE_NO), aCompany);
            value.AKindOfVehicle = CTFunction.GetKindOfVehicleType((string)dataReader[KIND_OF_VEHICLE]);
        }

        private bool fillVehicleContract(VehicleContract value, string sql)
        {
            VehicleRole objVehicleRole;
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    objVehicleRole = new VehicleRole();

                    value.LeaseTermMonth = dataReader.GetByte(LEASE_TERM);
                    value.KindOfRental = CTFunction.GetKindOfRantalType((string)dataReader[KIND_OF_RANTAL]);
                    value.ContinuousStatus = dataReader[CONTINUOUS_STATUS].ToString() == "Y";

                    fillVehicleContract(ref objVehicleRole, value.AVehicleRoleList.Company, dataReader);
                    value.AVehicleRoleList.Add(objVehicleRole);
                }
                objVehicleRole = null;
            }
            catch (IndexOutOfRangeException ein) { throw ein; }
            finally { tableAccess.CloseDataReader(); }
            return result;
        }

        #endregion

        //		============================== Public Method ==============================
        public VehicleContract GetVehicleContract(DocumentNo value, Company aCompany)
        {
            objVehicleContract = new VehicleContract(aCompany);
            objVehicleContract.ContractNo = value;
            if (FillVehicleContract(objVehicleContract))
            {
                return objVehicleContract;
            }
            else
            {
                objVehicleContract = null;
                return null;
            }
        }

        public bool FillVehicleContract(VehicleContract value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.AVehicleRoleList.Company));
            stringBuilder.Append(getKeyCondition(value));

            return fillVehicleContract(value, stringBuilder.ToString());
        }

        public bool FillVehicleContract(VehicleContract aVehicleContract, Vehicle aVehicle)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aVehicleContract.AVehicleRoleList.Company));
            stringBuilder.Append(getKeyCondition(aVehicleContract));
            stringBuilder.Append(getKeyCondition(aVehicle));

            return fillVehicleContract(aVehicleContract, stringBuilder.ToString());
        }

        public bool InsertVehicleContract(VehicleContract value)
        {
            VehicleRoleList vehicleRoleList = value.AVehicleRoleList;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < vehicleRoleList.Count; i++)
            {
                stringBuilder.Append(getSQLInsert(value, vehicleRoleList[i], vehicleRoleList.Company));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool UpdateVehicleContract(VehicleContract value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < value.AVehicleRoleList.Count; i++)
            {
                stringBuilder.Append(getSQLUpdate(value, value.AVehicleRoleList[i], value.AVehicleRoleList.Company));
                stringBuilder.Append(getBaseCondition(value.AVehicleRoleList.Company));
                stringBuilder.Append(getKeyCondition(value));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteVehicleContract(VehicleContract value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(value.AVehicleRoleList.Company));
            stringBuilder.Append(getKeyCondition(value));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteVehicleContractByPurchasing(VehiclePurchasing vehiclePurchasing)
        {
            SqlCommand cmd = this.tableAccess.CreateCommand("SDeleteVehicleContractByPurchasing");
            cmd.CommandType = CommandType.StoredProcedure;
            AddKeyParameters(cmd.Parameters, vehiclePurchasing);

            bool result = (tableAccess.ExecuteStoredProcedure(cmd) < 0);
            return result;
        }

        #region IDisposable Members
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                try
                {
                    if (disposing)
                    {

                    }
                    this.disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

    }
}
