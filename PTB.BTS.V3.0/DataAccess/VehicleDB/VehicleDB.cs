using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.VehicleEntities.VehicleLeasing;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.VehicleDB
{
	public class VehicleDB : DataAccessBase
	{
		#region Constant
		private const int VEHICLE_NO = 0;
		private const int COMPANY_CODE = 1;
		private const int PLATE_NO_PREFIX = 2;
		private const int PLATE_NO_RUNNING_NO = 3;
		private const int KIND_OF_VEHICLE = 4;
		private const int BRAND_CODE = 5;
		private const int MODEL_CODE = 6;
		private const int VEHICLE_STATUS = 7;
		private const int COLOR_CODE = 8;
		private const int BUY_DATE= 9;
		private const int REGISTER_DATE = 10;
        private const int PLATE_STATUS = 11;
        private const int CHASSIS_NO = 12;
        private const int VEHICLE_VAT_STATUS = 13;
        private const int PROVINCE = 14;
		private const int ENGINE_NO = 15;
		private const int VENDOR_CODE = 16;		
		private const int SECOND_HAND_STATUS = 17;
		private const int VEHICLE_AMOUNT = 18;
		private const int OPTION_AMOUNT = 19;
		private const int LATEST_MILEAGE = 20;
		private const int LATEST_MILEAGE_UPDATE_DATE = 21;
		private const int OPERATION_FEE = 22;
		private const int REMARK = 23;
		private const int TERMINATIONDATE = 24;
		#endregion

		#region Private variable
		private Vehicle objVehicle;
		private ColorDB dbColor;
		private VendorDB dbVendor;
		private ModelDB dbModel;
		private VehicleVatStatusDB dbVehicleVatStatus;

		private bool disposed = false;
		#endregion

        #region Constructor
        public VehicleDB()
            : base()
        {
            dbColor = new ColorDB();
            dbVendor = new VendorDB();
            dbModel = new ModelDB();
            dbVehicleVatStatus = new VehicleVatStatusDB();
        } 
        #endregion

        #region Private Method
        #region - getSQL -
        private string getSQLSelectVehicle()
        {
            return " SELECT Vehicle.Vehicle_No, Vehicle.Company_Code, Vehicle.Plate_No_Prefix, Vehicle.Plate_No_Running_No, Vehicle.Kind_Of_Vehicle, Vehicle.Brand_Code, Vehicle.Model_Code, Vehicle.Vehicle_Status, Vehicle.Color_Code, Vehicle.Buy_Date, Vehicle.Register_Date, Vehicle.Plate_Status, Vehicle.Chassis_No, Vehicle.Vehicle_VAT_Status FROM Vehicle ";
        }

        private string getSQLSelectVehicleInfo()
        {
            return " SELECT Vehicle_No, Company_Code, Plate_No_Prefix, Plate_No_Running_No, Kind_Of_Vehicle, Brand_Code, Model_Code, Vehicle_Status, Color_Code, Buy_Date, Register_Date, Plate_Status, Chassis_No, Vehicle_VAT_Status, Province, Engine_No, Vendor_Code, Second_Hand_Status, Vehicle_Amount, Option_Amount, Latest_Mileage, Latest_Mileage_Update_Date, Operation_Fee, Remark, Termination_Date FROM Vehicle ";
        }

        private string getSQLSelectVehicleInfoByPO()
        {
            return " SELECT V.Vehicle_No, V.Company_Code, V.Plate_No_Prefix, V.Plate_No_Running_No, V.Kind_Of_Vehicle, V.Brand_Code, V.Model_Code, V.Vehicle_Status, V.Color_Code, V.Buy_Date, V.Register_Date, V.Plate_Status, V.Chassis_No, V.Vehicle_VAT_Status, V.Province, V.Engine_No, V.Vendor_Code, V.Second_Hand_Status, V.Vehicle_Amount, V.Option_Amount, V.Latest_Mileage, V.Latest_Mileage_Update_Date, V.Operation_Fee, V.Remark, V.Termination_Date, VP.Issue_Date, VP.Vendor_Quotation_Date, VP.Vendor_Code FROM Vehicle V INNER JOIN Vehicle_Purchasing_Contract VPC ON V.Vehicle_No = VPC.Vehicle_No INNER JOIN Vehicle_Purchasing VP ON VP.Purchase_No = VPC.Purchase_No ";
        }

        private string getSQLInsert(VehicleInfo value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Vehicle (Company_Code, Plate_No_Prefix, Plate_No_Running_No, Province, Plate_Status, Engine_No, Chassis_No, Vendor_Code, Brand_Code, Model_Code, Kind_Of_Vehicle, Second_Hand_Status, Vehicle_VAT_Status, Vehicle_Status, Color_Code, Buy_Date, Register_Date, Vehicle_Amount, Option_Amount, Latest_Mileage, Latest_Mileage_Update_Date, Operation_Fee, Remark, Termination_Date, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code			
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Plate_No_Prefix
            stringBuilder.Append(GetDB(value.PlatePrefix));
            stringBuilder.Append(", ");

            //Plate_No_Running_No
            stringBuilder.Append(GetDB(value.PlateRunningNo));
            stringBuilder.Append(", ");

            //Province
            stringBuilder.Append(GetDB(value.PlateProvince.Name));
            stringBuilder.Append(", ");

            //Plate_Status
            stringBuilder.Append(GetDB(value.PlateStatus));
            stringBuilder.Append(", ");

            //Engine_No
            stringBuilder.Append(GetDB(value.EngineNo));
            stringBuilder.Append(", ");

            //Chassis_No
            stringBuilder.Append(GetDB(value.ChassisNo));
            stringBuilder.Append(", ");

            //Vendor_Code
            stringBuilder.Append(GetDB(value.AVendor.Code));
            stringBuilder.Append(", ");

            //Brand_Code
            stringBuilder.Append(GetDB(value.AModel.ABrand.Code));
            stringBuilder.Append(", ");

            //Model_Code
            stringBuilder.Append(GetDB(value.AModel.Code));
            stringBuilder.Append(", ");

            //Kind_Of_Vehicle
            stringBuilder.Append(GetDB(value.AKindOfVehicle));
            stringBuilder.Append(", ");

            //Second_Hand_Status
            stringBuilder.Append(GetDB(value.IsSecondHand));
            stringBuilder.Append(", ");

            //Vehicle_VAT_Status
            stringBuilder.Append(GetDB(value.VatStatus.Code));
            stringBuilder.Append(", ");

            //Vehicle_Status
            stringBuilder.Append(GetDB(value.AVehicleStatus));
            stringBuilder.Append(", ");

            //Color_Code
            stringBuilder.Append(GetDB(value.AColor.Code));
            stringBuilder.Append(", ");

            //Buy_Date
            stringBuilder.Append(GetDB(value.BuyDate));
            stringBuilder.Append(", ");

            //Register_Date
            stringBuilder.Append(GetDB(value.RegisterDate));
            stringBuilder.Append(", ");

            //Vehicle_Amount
            stringBuilder.Append(GetDB(value.VehicleAmount));
            stringBuilder.Append(", ");

            //Option_Amount
            stringBuilder.Append(GetDB(value.OptionAmount));
            stringBuilder.Append(", ");

            //Latest_Mileage
            stringBuilder.Append(GetDB(value.LatestMileage));
            stringBuilder.Append(", ");

            //Latest_Mileage_Update_Date
            stringBuilder.Append(GetDB(value.LatestMileageUpdateDate));
            stringBuilder.Append(", ");

            //Operation_Fee
            stringBuilder.Append(GetDB(value.OperationFee));
            stringBuilder.Append(", ");

            //Remark
            stringBuilder.Append(GetDB(value.Remark));
            stringBuilder.Append(", ");

            //Termination_Date
            stringBuilder.Append(GetDB(value.TerminationDate));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdateInfo(VehicleInfo value, KindOfVehicle kindOfVehicle, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" UPDATE Vehicle SET ");

            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Plate_No_Prefix = ");
            stringBuilder.Append(GetDB(value.PlatePrefix));
            stringBuilder.Append(", ");

            stringBuilder.Append("Plate_No_Running_No = ");
            stringBuilder.Append(GetDB(value.PlateRunningNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Province = ");
            stringBuilder.Append(GetDB(value.PlateProvince.Name));
            stringBuilder.Append(", ");

            stringBuilder.Append("Plate_Status = ");
            stringBuilder.Append(GetDB(value.PlateStatus));
            stringBuilder.Append(", ");

            stringBuilder.Append("Engine_No = ");
            stringBuilder.Append(GetDB(value.EngineNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Chassis_No = ");
            stringBuilder.Append(GetDB(value.ChassisNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vendor_Code = ");
            stringBuilder.Append(GetDB(value.AVendor.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Brand_Code = ");
            stringBuilder.Append(GetDB(value.AModel.ABrand.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Model_Code = ");
            stringBuilder.Append(GetDB(value.AModel.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Kind_Of_Vehicle = ");
            stringBuilder.Append(GetDB(kindOfVehicle));
            stringBuilder.Append(", ");

            stringBuilder.Append("Second_Hand_Status = ");
            stringBuilder.Append(GetDB(value.IsSecondHand));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_VAT_Status = ");
            stringBuilder.Append(GetDB(value.VatStatus.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_Status = ");
            stringBuilder.Append(GetDB(value.AVehicleStatus));
            stringBuilder.Append(", ");

            stringBuilder.Append("Color_Code = ");
            stringBuilder.Append(GetDB(value.AColor.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Buy_Date = ");
            stringBuilder.Append(GetDB(value.BuyDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Register_Date = ");
            stringBuilder.Append(GetDB(value.RegisterDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_Amount = ");
            stringBuilder.Append(GetDB(value.VehicleAmount));
            stringBuilder.Append(", ");

            stringBuilder.Append("Option_Amount = ");
            stringBuilder.Append(GetDB(value.OptionAmount));
            stringBuilder.Append(", ");

            stringBuilder.Append("Latest_Mileage = ");
            stringBuilder.Append(GetDB(value.LatestMileage));
            stringBuilder.Append(", ");

            stringBuilder.Append("Latest_Mileage_Update_Date = ");
            stringBuilder.Append(GetDB(value.LatestMileageUpdateDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Operation_Fee = ");
            stringBuilder.Append(GetDB(value.OperationFee));
            stringBuilder.Append(", ");

            stringBuilder.Append("Remark = ");
            stringBuilder.Append(GetDB(value.Remark));
            stringBuilder.Append(", ");

            stringBuilder.Append("Termination_Date = ");
            stringBuilder.Append(GetDB(value.TerminationDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_Date = ");
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_User = ");
            stringBuilder.Append(GetDB(UserProfile.UserID));

            return stringBuilder.ToString();
        }

        private string getSQLUpdateGeneral(Vehicle value, KindOfVehicle kindOfVehicle, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" UPDATE Vehicle SET ");

            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Plate_No_Prefix = ");
            stringBuilder.Append(GetDB(value.PlatePrefix));
            stringBuilder.Append(", ");

            stringBuilder.Append("Plate_No_Running_No = ");
            stringBuilder.Append(GetDB(value.PlateRunningNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Brand_Code = ");
            stringBuilder.Append(GetDB(value.AModel.ABrand.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Model_Code = ");
            stringBuilder.Append(GetDB(value.AModel.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Kind_Of_Vehicle = ");
            stringBuilder.Append(GetDB(kindOfVehicle));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_Status = ");
            stringBuilder.Append(GetDB(value.AVehicleStatus));
            stringBuilder.Append(", ");

            stringBuilder.Append("Color_Code = ");
            stringBuilder.Append(GetDB(value.AColor.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Buy_Date = ");
            stringBuilder.Append(GetDB(value.BuyDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Register_Date = ");
            stringBuilder.Append(GetDB(value.RegisterDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_Date = ");
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_User = ");
            stringBuilder.Append(GetDB(UserProfile.UserID));

            return stringBuilder.ToString();
        }

        private string getSQLDelete()
        {
            return " DELETE FROM Vehicle ";
        }

        private string getKeyCondition(Vehicle value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value.VehicleNo))
            {
                stringBuilder.Append(" AND (Vehicle_No = ");
                stringBuilder.Append(GetDB(value.VehicleNo));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getEntityCondition(Vehicle value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value.PlateRunningNo))
            {
                stringBuilder.Append(" AND (Plate_No_Running_No = ");
                stringBuilder.Append(GetDB(value.PlateRunningNo));
                stringBuilder.Append(")");
            }
            if (IsNotNULL(value.PlatePrefix))
            {
                stringBuilder.Append(" AND (Plate_No_Prefix = ");
                stringBuilder.Append(GetDB(value.PlatePrefix));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getEntityConditionPONUll(Vehicle value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value.PlateRunningNo))
            {
                stringBuilder.Append(" AND (Plate_No_Running_No like ");
                stringBuilder.Append("'" + value.PlateRunningNo + "%'");
                stringBuilder.Append(")");
            }
            else
            {
                stringBuilder.Append(" AND (Plate_No_Running_No <> '' ");
                stringBuilder.Append(")");
            }

            if (IsNotNULL(value.PlatePrefix))
            {
                stringBuilder.Append(" AND (Plate_No_Prefix like ");
                stringBuilder.Append("'" + value.PlatePrefix + "%'");
                stringBuilder.Append(")");
            }
            else
            {
                stringBuilder.Append(" AND (Plate_No_Prefix <> '' ");
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getEntityConditionPOPlate()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" AND (V.Plate_No_Running_No <> '' ");
            stringBuilder.Append(")");
            stringBuilder.Append(" AND (V.Plate_No_Prefix <> '' ");
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private string getEntityConditionPONo(string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (value != "")
            {
                value = value + "%";
                stringBuilder.Append(" WHERE (VP.Purchase_No like ");
                stringBuilder.Append(GetDB(value));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getEntityConditionSelling()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" AND (Vehicle_Status <> '4' ");
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private string getIsAssignCondition()
        {
            return " AND (Kind_Of_Vehicle <> 'Z') AND (Vehicle_No IN (SELECT Assigned_Vehicle_No FROM Vehicle_Assignment WHERE Assignment_Role = 'M')) ";
        }

        private string getMainAssignInPeriodCondition(DateTime fromDate, DateTime toDate)
        {
            //TODO : Ya

            return string.Empty;
        }

        private string getAvailableCondition()
        {
            return " AND (Vehicle_Status IN ('1', '2', '3')) ";
        }

        private string getOrderby()
        {
            return " ORDER BY Plate_No_Running_No, Plate_No_Prefix ";
        }

        private void AddParameters(SqlParameterCollection parameters, VehicleInfo vehicle, Company company)
        {
            parameters.Add(this.tableAccess.CreateParameter("@Company_Code", company.CompanyCode));
            parameters.Add(this.tableAccess.CreateParameter("@Plate_No_Prefix", vehicle.PlatePrefix));
            parameters.Add(this.tableAccess.CreateParameter("@Plate_No_Running_No", vehicle.PlateRunningNo));
            parameters.Add(this.tableAccess.CreateParameter("@Province", vehicle.PlateProvince.Name));
            parameters.Add(this.tableAccess.CreateParameter("@Plate_Status", CTFunction.GetString(vehicle.PlateStatus)));
            parameters.Add(this.tableAccess.CreateParameter("@Engine_No", vehicle.EngineNo));
            parameters.Add(this.tableAccess.CreateParameter("@Chassis_No", vehicle.ChassisNo));
            parameters.Add(this.tableAccess.CreateParameter("@Vendor_Code", vehicle.AVendor.Code));
            parameters.Add(this.tableAccess.CreateParameter("@Brand_Code", vehicle.AModel.ABrand.Code));
            parameters.Add(this.tableAccess.CreateParameter("@Model_Code", vehicle.AModel.Code));
            parameters.Add(this.tableAccess.CreateParameter("@Kind_Of_Vehicle", vehicle.AKindOfVehicle.Code));
            parameters.Add(this.tableAccess.CreateParameter("@Second_Hand_Status", CTFunction.GetString(vehicle.IsSecondHand)));
            parameters.Add(this.tableAccess.CreateParameter("@Vehicle_VAT_Status", vehicle.VatStatus.Code));
            parameters.Add(this.tableAccess.CreateParameter("@Vehicle_Status", vehicle.AVehicleStatus.Code));
            parameters.Add(this.tableAccess.CreateParameter("@Color_Code", vehicle.AColor.Code));
            parameters.Add(this.tableAccess.CreateParameter("@Buy_Date", vehicle.BuyDate));
            parameters.Add(this.tableAccess.CreateParameter("@Register_Date", vehicle.RegisterDate));
            parameters.Add(this.tableAccess.CreateParameter("@Vehicle_Amount", vehicle.VehicleAmount));
            parameters.Add(this.tableAccess.CreateParameter("@Option_Amount", vehicle.OptionAmount));
            parameters.Add(this.tableAccess.CreateParameter("@Latest_Mileage", vehicle.LatestMileage));
            parameters.Add(this.tableAccess.CreateParameter("@Latest_Mileage_Update_Date", vehicle.LatestMileageUpdateDate));
            parameters.Add(this.tableAccess.CreateParameter("@Operation_Fee", vehicle.OperationFee));
            parameters.Add(this.tableAccess.CreateParameter("@Remark", vehicle.Remark));
            parameters.Add(this.tableAccess.CreateParameter("@Termination_Date", vehicle.TerminationDate));
            parameters.Add(this.tableAccess.CreateParameter("@Process_Date", DateTime.Today));
            parameters.Add(this.tableAccess.CreateParameter("@Process_User", UserProfile.UserID));
        }

        private void AddKeyParameters(SqlParameterCollection parameters, int vehicleNo)
        {
            parameters.Add(this.tableAccess.CreateParameter("@Vehicle_No", vehicleNo));
        }

        #endregion

        #region - Fill -
        private void fillVehicleInfo(VehicleInfo value, Company aCompany, SqlDataReader dataReader)
        {
            fillVehicleDB(value, aCompany, dataReader);

            value.PlateProvince.Name = (string)dataReader[PROVINCE];
            value.EngineNo = (string)dataReader[ENGINE_NO];
            value.AVendor = dbVendor.GetDBVendor((string)dataReader[VENDOR_CODE], aCompany);
            value.IsSecondHand = CTFunction.GetSecondHandStatusType((string)dataReader[SECOND_HAND_STATUS]);
            value.VehicleAmount = dataReader.GetDecimal(VEHICLE_AMOUNT);
            value.OptionAmount = dataReader.GetDecimal(OPTION_AMOUNT);
            value.LatestMileage = dataReader.GetInt32(LATEST_MILEAGE);

            if (dataReader.IsDBNull(LATEST_MILEAGE_UPDATE_DATE))
            {
                value.LatestMileageUpdateDate = NullConstant.DATETIME;
            }
            else
            {
                value.LatestMileageUpdateDate = dataReader.GetDateTime(LATEST_MILEAGE_UPDATE_DATE);
            }

            value.OperationFee = dataReader.GetDecimal(OPERATION_FEE);
            value.Remark = (string)dataReader[REMARK];

            if (dataReader.IsDBNull(TERMINATIONDATE))
            {
                value.TerminationDate = NullConstant.DATETIME;
            }
            else
            {
                value.TerminationDate = dataReader.GetDateTime(TERMINATIONDATE);
            }
        }

        private void fillVehicle(Vehicle value, Company aCompany, SqlDataReader dataReader)
        {
            value.VehicleNo = dataReader.GetInt32(VEHICLE_NO);
            value.PlatePrefix = (string)dataReader[PLATE_NO_PREFIX];
            value.PlateRunningNo = (string)dataReader[PLATE_NO_RUNNING_NO];
            value.AKindOfVehicle = CTFunction.GetKindOfVehicleType((string)dataReader[KIND_OF_VEHICLE]);
            value.AModel = dbModel.GetDBModel((string)dataReader[MODEL_CODE], (string)dataReader[BRAND_CODE]);
            value.AVehicleStatus = CTFunction.GetVehicleStatasType((string)dataReader[VEHICLE_STATUS]);
            value.BuyDate = dataReader.GetDateTime(BUY_DATE);
            value.RegisterDate = dataReader.GetDateTime(REGISTER_DATE);
            value.PlateStatus = CTFunction.GetPlatestatusType((string)dataReader[PLATE_STATUS]);
            value.ChassisNo = (string)dataReader[CHASSIS_NO];
            value.VatStatus = (VehicleVatStatus)dbVehicleVatStatus.GetMTB((string)dataReader[VEHICLE_VAT_STATUS]);
        }

        private void fillVehicleDB(Vehicle value, Company aCompany, SqlDataReader dataReader)
        {
            fillVehicle(value, aCompany, dataReader);
            value.AColor = (Color)dbColor.GetMTB((string)dataReader[COLOR_CODE]);
        }

        private bool fillVehicleList(ref VehicleList value, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);

            ColorList colorlist = new ColorList();
            dbColor.FillMTBList(colorlist);

            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    objVehicle = new Vehicle();
                    objVehicle.AColor = colorlist[(string)dataReader[COLOR_CODE]];
                    fillVehicle(objVehicle, value.Company, dataReader);

                    if (!value.Contain(objVehicle))
                    {
                        value.Add(objVehicle);
                    }
                }
                objVehicle = null;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            {
                tableAccess.CloseDataReader();
                dataReader = null;
                colorlist = null;
            }
            return result;
        }

        private bool fillVehicle(ref Vehicle value, Company aCompany, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillVehicleDB(value, aCompany, dataReader);
                    result = true;
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

        private bool fillVehicleInfo(ref VehicleInfo value, Company aCompany, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillVehicleInfo(value, aCompany, dataReader);
                    result = true;
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

        private bool fillVehicleList(VehicleList value, SqlCommand cmd)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(cmd);

            ColorList colorlist = new ColorList();
            dbColor.FillMTBList(colorlist);

            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    objVehicle = new Vehicle();
                    objVehicle.AColor = colorlist[(string)dataReader[COLOR_CODE]];
                    fillVehicle(objVehicle, value.Company, dataReader);

                    if (!value.Contain(objVehicle))
                    {
                        value.Add(objVehicle);
                    }
                }
                objVehicle = null;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            {
                tableAccess.CloseDataReader();
                dataReader = null;
                colorlist = null;
            }
            return result;
        }

        #endregion 

        #endregion

        #region Public Method
        public Vehicle GetVehicleGeneral(int vehicleNo, Company aCompany)
        {
            objVehicle = new Vehicle();
            objVehicle.VehicleNo = vehicleNo;
            if (FillVehicleGeneral(ref objVehicle, aCompany))
            {
                return objVehicle;
            }
            else
            {
                objVehicle = null;
                return null;
            }
        }

        public VehicleInfo GetVehicleInfo(int vehicleNo, Company aCompany)
        {
            VehicleInfo objVehicleInfo = new VehicleInfo();
            objVehicleInfo.VehicleNo = vehicleNo;
            if (FillVehicleInfo(ref objVehicleInfo, aCompany))
            {
                return objVehicleInfo;
            }
            else
            {
                objVehicleInfo = null;
                return null;
            }
        }

        public VehicleInfo GetVehicleInfoSelling(int vehicleNo, Company aCompany)
        {
            VehicleInfo objVehicleInfo = new VehicleInfo();
            objVehicleInfo.VehicleNo = vehicleNo;
            if (FillVehicleInfoSelling(ref objVehicleInfo, aCompany))
            {
                return objVehicleInfo;
            }
            else
            {
                objVehicleInfo = null;
                return null;
            }
        }

        internal Vehicle GetDBVehicleGeneral(int vehicleNo, Company aCompany)
        {
            objVehicle = new Vehicle();
            objVehicle.VehicleNo = vehicleNo;
            if (FillVehicleGeneral(ref objVehicle, aCompany))
            {
                return objVehicle;
            }
            else
            {
                objVehicle.VehicleNo = NullConstant.INT;
                return objVehicle;
            }
        }

        internal VehicleInfo GetDBVehicleInfo(int vehicleNo, Company aCompany)
        {
            VehicleInfo objVehicleInfo = new VehicleInfo();
            objVehicleInfo.VehicleNo = vehicleNo;
            if (FillVehicleInfo(ref objVehicleInfo, aCompany))
            {
                return objVehicleInfo;
            }
            else
            {
                objVehicleInfo.VehicleNo = NullConstant.INT;
                return objVehicleInfo;
            }
        }

        public bool FillVehicleGeneral(ref Vehicle value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectVehicle());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));
            stringBuilder.Append(getEntityCondition(value));

            return fillVehicle(ref value, aCompany, stringBuilder.ToString());
        }

        public bool FillVehicleInfo(ref VehicleInfo value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectVehicleInfo());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));
            stringBuilder.Append(getEntityCondition(value));

            return fillVehicleInfo(ref value, aCompany, stringBuilder.ToString());
        }

        public bool FillVehicleInfoSelling(ref VehicleInfo value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectVehicleInfo());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));
            stringBuilder.Append(getEntityConditionSelling());

            return fillVehicleInfo(ref value, aCompany, stringBuilder.ToString());
        }

        public bool FillVehicleList(ref VehicleList value, Vehicle aVehicle)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectVehicle());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(aVehicle));
            stringBuilder.Append(getEntityCondition(aVehicle));
            stringBuilder.Append(getOrderby());

            return fillVehicleList(ref value, stringBuilder.ToString());
        }

        public bool FillVehicleListCalculation(ref VehicleList value, Vehicle aVehicle)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectVehicle());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(aVehicle));
            stringBuilder.Append(getEntityConditionPONUll(aVehicle));
            stringBuilder.Append(getOrderby());

            return fillVehicleList(ref value, stringBuilder.ToString());
        }

        public bool FillVehicleList(ref VehicleList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectVehicle());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getOrderby());

            return fillVehicleList(ref value, stringBuilder.ToString());
        }

        public bool FillVehicleList(ref VehicleList value,string purchaseNo)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectVehicleInfoByPO());
            //stringBuilder.Append(getEntityConditionPOPlate());
            stringBuilder.Append(getEntityConditionPONo(purchaseNo));
            stringBuilder.Append(getOrderby());

            return fillVehicleList(ref value, stringBuilder.ToString());

        }

        public bool FillVehicleActiveList(ref VehicleList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectVehicle());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(" AND (Vehicle_Status = '1') AND (Kind_Of_Vehicle = 'Z') AND (Vehicle_No NOT IN (SELECT Assigned_Vehicle_No FROM Vehicle_Assignment) OR Vehicle_No IN (SELECT Assigned_Vehicle_No FROM Vehicle_Assignment WHERE To_Date < GETDATE())) ");
            stringBuilder.Append(getOrderby());

            return fillVehicleList(ref value, stringBuilder.ToString());
        }

        public bool FillVehicleActiveList(VehicleList vehicleList, DateTime fromDate, DateTime toDate)
        {
            // create SqlCommand
            SqlCommand cmd = this.tableAccess.CreateCommand(string.Empty);
            cmd.CommandText = "SSelectAllVehicleSpareByPeriod";
            cmd.CommandType = CommandType.StoredProcedure;

            // add SqlParameter
            cmd.Parameters.Add(this.tableAccess.CreateParameter("@FromDate", fromDate));
            cmd.Parameters.Add(this.tableAccess.CreateParameter("@ToDate", toDate));

            return this.fillVehicleList(vehicleList, cmd);
        }

        public bool FillVehicleActive(Vehicle value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectVehicle());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(" AND (Vehicle_Status = '1') AND (Kind_Of_Vehicle = 'Z') AND (Vehicle_No NOT IN (SELECT Assigned_Vehicle_No FROM Vehicle_Assignment) OR Vehicle_No IN (SELECT Assigned_Vehicle_No FROM Vehicle_Assignment WHERE To_Date < GETDATE())) ");
            if (IsNotNULL(value.VehicleNo))
            {
                stringBuilder.Append(" AND (Vehicle.Vehicle_No = ");
                stringBuilder.Append(GetDB(value.VehicleNo));
                stringBuilder.Append(" ) ");
            }

            return fillVehicle(ref value, aCompany, stringBuilder.ToString());
        }

        public bool FillVehicleOutInsurance(ref VehicleList value, DateTime startDate, DateTime endDate, Vehicle conditionVehicle)
        {

            StringBuilder stringBuilder = new StringBuilder(getSQLSelectVehicle());
            stringBuilder.Append(" LEFT OUTER JOIN Insurance_Type_One_Detail ON Vehicle.Company_Code = Insurance_Type_One_Detail.Company_Code AND Vehicle.Vehicle_No = Insurance_Type_One_Detail.Vehicle_No LEFT OUTER JOIN Insurance_Type_One ON Insurance_Type_One_Detail.Company_Code = Insurance_Type_One.Company_Code AND Insurance_Type_One_Detail.Policy_No = Insurance_Type_One.Policy_No ");
            stringBuilder.Append(" WHERE (Vehicle.Company_Code = ");
            stringBuilder.Append(GetDB(value.Company.CompanyCode));
            stringBuilder.Append(" ) AND (Insurance_Type_One.End_Date <= ");
            stringBuilder.Append(GetDB(startDate));
            stringBuilder.Append(" ) ");
            if (IsNotNULL(conditionVehicle.PlateRunningNo))
            {
                stringBuilder.Append(" AND (Vehicle.Plate_No_Running_No = ");
                stringBuilder.Append(GetDB(conditionVehicle.PlateRunningNo));
                stringBuilder.Append(")");
            }

            if (IsNotNULL(conditionVehicle.PlatePrefix))
            {
                stringBuilder.Append(" AND (Vehicle.Plate_No_Prefix = ");
                stringBuilder.Append(GetDB(conditionVehicle.PlatePrefix));
                stringBuilder.Append(")");
            }
            stringBuilder.Append(" OR  (Vehicle.Company_Code = ");
            stringBuilder.Append(GetDB(value.Company.CompanyCode));
            stringBuilder.Append(" ) AND (Insurance_Type_One.Start_Date >= ");
            stringBuilder.Append(GetDB(endDate));
            stringBuilder.Append(" ) ");
            if (IsNotNULL(conditionVehicle.PlateRunningNo))
            {
                stringBuilder.Append(" AND (Vehicle.Plate_No_Running_No = ");
                stringBuilder.Append(GetDB(conditionVehicle.PlateRunningNo));
                stringBuilder.Append(")");
            }

            if (IsNotNULL(conditionVehicle.PlatePrefix))
            {
                stringBuilder.Append(" AND (Vehicle.Plate_No_Prefix = ");
                stringBuilder.Append(GetDB(conditionVehicle.PlatePrefix));
                stringBuilder.Append(")");
            }
            stringBuilder.Append(" OR (Insurance_Type_One.End_Date IS NULL) AND (Insurance_Type_One.Start_Date IS NULL) ");
            if (IsNotNULL(conditionVehicle.PlateRunningNo))
            {
                stringBuilder.Append(" AND (Vehicle.Plate_No_Running_No = ");
                stringBuilder.Append(GetDB(conditionVehicle.PlateRunningNo));
                stringBuilder.Append(")");
            }

            if (IsNotNULL(conditionVehicle.PlatePrefix))
            {
                stringBuilder.Append(" AND (Vehicle.Plate_No_Prefix = ");
                stringBuilder.Append(GetDB(conditionVehicle.PlatePrefix));
                stringBuilder.Append(")");
            }
            stringBuilder.Append(" AND (Vehicle.Vehicle_Status IN ('1', '2', '3')) ");
            stringBuilder.Append(" ORDER BY Vehicle.Plate_No_Prefix, Vehicle.Plate_No_Running_No ");
            return fillVehicleList(ref value, stringBuilder.ToString());
        }

        public bool FillVehicleIsAssignList(ref VehicleList value, Vehicle aVehicle)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectVehicle());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(aVehicle));
            stringBuilder.Append(getEntityCondition(aVehicle));
            stringBuilder.Append(getIsAssignCondition());
            stringBuilder.Append(getOrderby());

            return fillVehicleList(ref value, stringBuilder.ToString());
        }

        /// <summary>
        /// Create by Sathaphon
        /// </summary>
        /// <param name="value"></param>
        /// <param name="platePrefix"></param>
        /// <param name="plateRunningNo"></param>
        /// <param name="quotationType"></param>
        /// <returns>Vehicle for create quotation</returns>
        public bool FillVehicleForCreateQuotation(VehicleList value, string platePrefix, string plateRunningNo, int quotationType)
        {
            // create SqlCommand
            SqlCommand cmd = this.tableAccess.CreateCommand(string.Empty);
            cmd.CommandText = "sSelectVehicleForCreateQuotation";
            cmd.CommandType = CommandType.StoredProcedure;

            // assign default to parameter
            string companyCode = (value.Company == null) ? "12" : value.Company.CompanyCode;

            // add SqlParameter
            cmd.Parameters.Add(this.tableAccess.CreateParameter("@Company_Code", companyCode));
            cmd.Parameters.Add(this.tableAccess.CreateParameter("@Plate_No_Running_No", string.Format("{0}%",plateRunningNo.Trim())));
            cmd.Parameters.Add(this.tableAccess.CreateParameter("@Plate_No_Prefix", string.Format("{0}%", platePrefix.Trim())));
            cmd.Parameters.Add(this.tableAccess.CreateParameter("@QuotationType", quotationType));
 
            return this.fillVehicleList(value, cmd);
        }


        public bool FillVehicleIsAssignList(VehicleList value, DateTime fromDate, DateTime toDate, Vehicle vehicle)
        {
            //TODO : Ya

            // create SqlCommand
            SqlCommand cmd = this.tableAccess.CreateCommand(string.Empty);
            cmd.CommandText = "SSelectMainAssignVehicle";
            cmd.CommandType = CommandType.StoredProcedure;

            // assign default to parameter
            string companyCode = (value.Company == null) ? "12" : value.Company.CompanyCode;

            // add SqlParameter
            cmd.Parameters.Add(this.tableAccess.CreateParameter("@Company_Code", companyCode));
            cmd.Parameters.Add(this.tableAccess.CreateParameter("@Vehicle_No", vehicle.VehicleNo));
            cmd.Parameters.Add(this.tableAccess.CreateParameter("@Plate_No_Running_No", vehicle.PlateRunningNo));
            cmd.Parameters.Add(this.tableAccess.CreateParameter("@Plate_No_Prefix", vehicle.PlatePrefix));
            cmd.Parameters.Add(this.tableAccess.CreateParameter("@StartAssignDate", fromDate));
            cmd.Parameters.Add(this.tableAccess.CreateParameter("@ToAssignDate", toDate));

            return this.fillVehicleList(value, cmd);
        }

        public bool FillVehicleIsAssign(ref Vehicle value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectVehicle());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));
            stringBuilder.Append(getEntityCondition(value));
            stringBuilder.Append(getIsAssignCondition());

            return fillVehicle(ref value, aCompany, stringBuilder.ToString());
        }

        public bool FillVehicleAvailableList(ref VehicleList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectVehicle());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getAvailableCondition());
            stringBuilder.Append(getOrderby());

            return fillVehicleList(ref value, stringBuilder.ToString());
        }

        public int InsertVehicle(VehicleInfo aVehicleInfo, Company aCompany)
        {
            object obj = (tableAccess.ExecuteScalar(getSQLInsert(aVehicleInfo, aCompany)));
            int vehicleNo = 0;
            if (obj != null)
            {
                vehicleNo = (int)obj;
            }
            return vehicleNo;
        }

        public bool UpdateVehicleInfo(VehicleInfo aVehicleInfo, KindOfVehicle kindOfVehicle, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdateInfo(aVehicleInfo, kindOfVehicle, aCompany));
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(aVehicleInfo));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool UpdateVehicleGeneral(Vehicle aVehicle, KindOfVehicle kindOfVehicle, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdateGeneral(aVehicle, kindOfVehicle, aCompany));
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(aVehicle));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool DeleteVehicle(Vehicle aVehicle, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(aVehicle));
            stringBuilder.Append(getEntityCondition(aVehicle));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        //============================== Specific Method ==============================
        public string GetVehiclePlateNo(int vehicleNo, Company company)
        {
            string vehiclePlateNo = "";

            StringBuilder stringBuilder = new StringBuilder(" SELECT Vehicle.Plate_No_Prefix, Vehicle.Plate_No_Running_No FROM Vehicle ");
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(" AND (Vehicle.Vehicle_No = ");
            stringBuilder.Append(GetDB(vehicleNo));
            stringBuilder.Append(")");

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
            try
            {
                if (dataReader.Read())
                {
                    vehiclePlateNo = (string)dataReader[0] + "-" + (string)dataReader[1];
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }
            finally
            { tableAccess.CloseDataReader(); }

            return vehiclePlateNo;
        }

        public bool UpdateKindOfVehicle(Vehicle vehicle, KindOfVehicle kind, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(" UPDATE Vehicle SET ");
            stringBuilder.Append("Kind_Of_Vehicle = ");
            stringBuilder.Append(GetDB(kind));
            stringBuilder.Append(", ");
            stringBuilder.Append("Process_Date = ");
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");
            stringBuilder.Append("Process_User = ");
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(vehicle));

            return tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0;
        }

        public bool UpdateVehicleForDaily(Vehicle vehicle, VehicleStatus status, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(" UPDATE Vehicle SET ");
            stringBuilder.Append("Vehicle_Status = ");
            stringBuilder.Append(GetDB(status));
            stringBuilder.Append(", ");
            stringBuilder.Append("Process_Date = ");
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");
            stringBuilder.Append("Process_User = ");
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(vehicle));

            return tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0;
        }

        /// <summary>
        /// Created from D08014_PGMS_07_DailyProcess prog. spec.
        /// </summary>
        public void UpdateSellingVehicle(Company aCompany)
        {
            // create SqlCommand
            SqlCommand command = this.tableAccess.CreateCommand(string.Empty);
            command.CommandText = "SUpdateSellingVehicle";
            command.CommandType = CommandType.StoredProcedure;

            // add stored procedure parameters
            command.Parameters.Add(this.tableAccess.CreateParameter("@Company_Code", aCompany.CompanyCode));

            // execute command
            this.tableAccess.ExecuteStoredProcedure(command);
        }

        #endregion

        /// <summary>
        /// Insert new vehicle and return vehicle no.
        /// </summary>
        /// <param name="aVehicleInfo"></param>
        /// <param name="aCompany"></param>
        /// <returns>if true return vehicle no. else 0</returns>
        public int InsertVehicleInfo(VehicleInfo vehicle, Company company)
        {
            SqlCommand cmd = this.tableAccess.CreateCommand("SInsertVehicle");
            cmd.CommandType = CommandType.StoredProcedure;
            AddParameters(cmd.Parameters, vehicle, company); 

            object obj = (tableAccess.ExecuteScalarStoredProcedure(cmd));
            int vehicleNo = 0;
            if (obj != null)
            {
                vehicleNo = (int)obj;
            }
            return vehicleNo;
        }

        public bool DeleteVehicleByPurchasing(int vehicleNo)
        {
            SqlCommand cmd = this.tableAccess.CreateCommand("SDeleteVehicleByPurchasing");
            cmd.CommandType = CommandType.StoredProcedure;
            AddKeyParameters(cmd.Parameters, vehicleNo);

            bool result = (tableAccess.ExecuteStoredProcedure(cmd) < 0);
            return result;
        }

        /// <summary>
        /// Get maximum lease term for maintenace car report
        /// </summary>
        /// <returns></returns>
        public int GetVehicleContractLeaseTerm(string customerCode,string brandCode,int registerDate)
        {
            int leaseTerm = 0;
            SqlCommand command = this.tableAccess.CreateCommand("SSearchVehicleContractLeaseTerm");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(this.tableAccess.CreateParameter("@Customer_Code", customerCode == " " ? DBNull.Value : DBValue(customerCode)));
            command.Parameters.Add(this.tableAccess.CreateParameter("@Brand_Code", brandCode == " " ? DBNull.Value : DBValue(brandCode)));
            command.Parameters.Add(this.tableAccess.CreateParameter("@Register_date", registerDate == 0 ? DBNull.Value : DBValue(registerDate)));

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);
            try
            {
                while (dataReader.Read())
                {

                    if (dataReader.IsDBNull(0))
                    {
                        leaseTerm = 0;
                    }
                    else
                    {
                        leaseTerm = Convert.ToInt32(dataReader["Lease_Term"]);

                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Closed)
                {
                    command.Connection.Close();
                }

                dataReader.Close();
                tableAccess.CloseDataReader();
            }
            return leaseTerm;
        }

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
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
