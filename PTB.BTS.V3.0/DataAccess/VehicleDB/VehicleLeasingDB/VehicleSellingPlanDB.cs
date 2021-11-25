using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using DataAccess.CommonDB;

using ictus.Common.Entity;
using ictus.Common.Entity.Time;

using Entity.VehicleEntities;
using Entity.VehicleEntities.VehicleLeasing;

using SystemFramework.AppConfig;

namespace DataAccess.VehicleDB.VehicleLeasingDB
{
    public class VehicleSellingPlanDB : DataAccessBase
    {
        enum ColIndex
        {
            VEHICLE_NO,
            SELLING_DATE,
            SELLING_PRICE,
            BIDDER_CODE,
            BV_DATE,
            BV
        }

        private VehicleDB dbVehicle;
        private ColorDB dbColor;
        private VendorDB dbVendor;
        private ModelDB dbModel;
        private VehicleVatStatusDB dbVehicleVatStatus;
        //============================== Constructor ==============================
        public VehicleSellingPlanDB()
            : base()
        {
            dbVehicle = new VehicleDB();
            dbColor = new ColorDB();
            dbVendor = new VendorDB();
            dbModel = new ModelDB();
            dbVehicleVatStatus = new VehicleVatStatusDB();
        }

        //============================== Private Method ==============================
        #region - getSQL -
        private string getSQLSelect()
        {
            return " SELECT Vehicle_No, Selling_Date, Selling_Price, Bidder_Code, BV_Date, BV FROM Vehicle_Selling_Plan ";
        }

        private string getSQLInsert(VehicleSelling entity, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Vehicle_Selling_Plan (Company_Code, Vehicle_No, Selling_Date, Selling_Price, BV_Date, BV, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(company.CompanyCode));
            stringBuilder.Append(", ");

            //Vehicle_No			
            stringBuilder.Append(GetDB(entity.Vehicle.VehicleNo));
            stringBuilder.Append(", ");

            //Selling_Date
            if (entity.SellingDate.HasValue)
            {
                stringBuilder.Append(GetDB(entity.SellingDate.Value));
            }
            else
            {
                stringBuilder.Append("NULL");
            }
            stringBuilder.Append(", ");

            //Selling_Price			
            stringBuilder.Append(GetDB(entity.SellingPrice));
            stringBuilder.Append(", ");

            //BV_Date
            if (entity.BVDate.HasValue)
            {
                stringBuilder.Append(GetDB(entity.BVDate.Value.Date));
            }
            else
            {
                stringBuilder.Append("NULL");
            }
            stringBuilder.Append(", ");

            //BV
            stringBuilder.Append(GetDB(entity.BV));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(SystemFramework.AppConfig.UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(VehicleSelling entity, YearMonth yearMonth, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Vehicle_Selling_Plan SET ");

            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(company.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_No = ");
            stringBuilder.Append(GetDB(entity.Vehicle.VehicleNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Estimate_Year = ");
            stringBuilder.Append(GetDB(yearMonth.Year));
            stringBuilder.Append(", ");

            stringBuilder.Append("Estimate_Month = ");
            stringBuilder.Append(GetDB(yearMonth.Month));
            stringBuilder.Append(", ");

            stringBuilder.Append("Selling_Date = ");
            if (entity.SellingDate.HasValue)
            {
                stringBuilder.Append(GetDB(entity.SellingDate.Value));
            }
            else
            {
                stringBuilder.Append("NULL");
            }
            stringBuilder.Append(", ");

            //stringBuilder.Append("Estimate_Selling = ");
            //stringBuilder.Append(GetDB(entity.EstimateSelling));
            //stringBuilder.Append(", ");

            //stringBuilder.Append("BV_Date = ");
            //if (entity.BVDate.HasValue)
            //{
            //    stringBuilder.Append(GetDB(entity.BVDate.Value));
            //}
            //else
            //{
            //    stringBuilder.Append("NULL");
            //}
            //stringBuilder.Append(", ");

            stringBuilder.Append("BV = ");
            stringBuilder.Append(GetDB(entity.BV));
            stringBuilder.Append(", ");

            //stringBuilder.Append("Vehicle_Year = ");
            //stringBuilder.Append(GetDB(entity.VehicleYear));
            //stringBuilder.Append(", ");

            stringBuilder.Append("Process_Date = ");
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_User = ");
            stringBuilder.Append(GetDB(SystemFramework.AppConfig.UserProfile.UserID));

            return stringBuilder.ToString();
        }

        private string getSQLDelete()
        {
            return " DELETE FROM Vehicle_Selling_Plan ";
        }

        private string getKeyCondition(int vehicleNo)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (vehicleNo != ictus.Common.Entity.General.NullConstant.INT)
            {
                stringBuilder.Append(" AND (Vehicle_No = ");
                stringBuilder.Append(GetDB(vehicleNo));
                stringBuilder.Append(")");
            }

            return stringBuilder.ToString();
        }

        private string getDateCondition(VehicleSelling entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(entity.SellingDate.Value.Date))
            {
                stringBuilder.Append(" AND (Selling_Date <= ");
                stringBuilder.Append(GetDB(entity.SellingDate.Value.Date));
                stringBuilder.Append(")");
            }

            return stringBuilder.ToString();
        }

        private string getListCondition(YearMonth yearMonth)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(yearMonth.Year))
            {
                stringBuilder.Append(" AND (Estimate_Year = ");
                stringBuilder.Append(GetDB(yearMonth.Year));
                stringBuilder.Append(")");
            }
            if (IsNotNULL(yearMonth.Month))
            {
                stringBuilder.Append(" AND (Estimate_Month = ");
                stringBuilder.Append(GetDB(yearMonth.Month));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getOrderby()
        {
            return " ORDER BY Vehicle_No ";
        }
        #endregion

        #region - Fill -
        private void Fill(VehicleSelling entity, Company company, SqlDataReader dataReader)
        {
            entity.Vehicle = dbVehicle.GetVehicleInfoSelling(dataReader.GetInt32((int)ColIndex.VEHICLE_NO), company);

            if (dataReader.IsDBNull((int)ColIndex.SELLING_DATE))
            {
                entity.SellingDate = null;
            }
            else
            {
                entity.SellingDate = dataReader.GetDateTime((int)ColIndex.SELLING_DATE);
            }

            entity.SellingPrice = dataReader.GetDecimal((int)ColIndex.SELLING_PRICE);

            if (dataReader.IsDBNull((int)ColIndex.BV_DATE))
            {
                entity.BVDate = null;
            }
            else
            {
                entity.BVDate = dataReader.GetDateTime((int)ColIndex.BV_DATE);
            }

            entity.BV = dataReader.GetDecimal((int)ColIndex.BV);
            Bidder bidder = new Bidder();
            if (dataReader.IsDBNull(3))
            {
                bidder = null;
            }
            else
            {
                bidder.BidderCode = (string)dataReader["Bidder_Code"];
            }
            entity.Bidder = bidder;
        }

        private List<VehicleSelling> FillList(SqlCommand command, Company company)
        {
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);
            VehicleSelling entity;
            List<VehicleSelling> list = new List<VehicleSelling>();

            try
            {
                while (dataReader.Read())
                {
                    entity = new VehicleSelling();
                    Fill(entity, company, dataReader);
                    if (entity.Vehicle != null)
                    {
                        list.Add(entity);
                    }
                }
                entity = null;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return list;

        }

        private List<VehicleInfo> FillListVehicleInfo(SqlCommand command, Company aCompany)
        {
            List<VehicleInfo> result = new List<VehicleInfo>();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);

                try
                {
                    while (dataReader.Read())
                    {
                        VehicleInfo entity = new VehicleInfo();
                        FillDetail(entity, dataReader,aCompany);

                        result.Add(entity);
                    }
                }
                catch (IndexOutOfRangeException ein)
                {
                    throw ein;
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
            return result;
        }

        private void FillDetail(VehicleInfo entity, SqlDataReader dataReader,Company aCompany)
        {
            entity.AKindOfVehicle = new KindOfVehicle();
            entity.AModel = new Model();
            entity.AModel.ABrand = new Brand();
            entity.AVehicleStatus = new VehicleStatus();
            entity.AColor = new Color();
            entity.AVendor = new Vendor();

            entity.VehicleNo = dataReader.GetInt32(0);
            entity.PlatePrefix = (string)dataReader["Plate_No_Prefix"];
            entity.PlateRunningNo = (string)dataReader["Plate_No_Running_No"];
            entity.AKindOfVehicle = CTFunction.GetKindOfVehicleType((string)dataReader["Kind_Of_Vehicle"]);
            entity.AModel = dbModel.GetDBModel((string)dataReader["Model_Code"], (string)dataReader["Brand_Code"]);
            entity.AVehicleStatus = CTFunction.GetVehicleStatasType((string)dataReader["Vehicle_Status"]);
            entity.BuyDate = dataReader.GetDateTime(16);
            entity.RegisterDate = dataReader.GetDateTime(17);
            entity.PlateStatus = CTFunction.GetPlatestatusType((string)dataReader["Plate_Status"]);
            entity.ChassisNo = (string)dataReader["Chassis_No"];
            entity.VatStatus = (VehicleVatStatus)dbVehicleVatStatus.GetMTB((string)dataReader["Vehicle_VAT_Status"]);
            entity.AColor = (Color)dbColor.GetMTB((string)dataReader["Color_Code"]);
            entity.PlateProvince.Name = (string)dataReader["Province"];
            entity.EngineNo = (string)dataReader["Engine_No"];
            entity.AVendor = dbVendor.GetDBVendor((string)dataReader["Vendor_Code"], aCompany);
            entity.IsSecondHand = CTFunction.GetSecondHandStatusType((string)dataReader["Second_Hand_Status"]);
            entity.VehicleAmount = dataReader.GetDecimal(18);
            entity.OptionAmount = dataReader.GetDecimal(19);
            entity.LatestMileage = dataReader.GetInt32(20);
        }

        private VehicleSelling FillVehicle(string sql,Company aCompany)
        {
            VehicleSelling entity = new VehicleSelling();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);

            try
            {
                while (dataReader.Read())
                {
                    Fill(entity, aCompany, dataReader);
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return entity;
        }
        #endregion

        //============================== Public Method =============================
        public VehicleSelling FillVehicleSelling(int vehicleNo, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(vehicleNo));

            return FillVehicle(stringBuilder.ToString(),aCompany);
        }
        public List<VehicleInfo> GetVehicleInfoByVehicleSelling(VehicleSelling vehicleSelling, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand("SSearchVehicleInfoBySellingPlan");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Selling_Date", vehicleSelling.SellingDate.Value.Date));

            return FillListVehicleInfo(command, aCompany);
        }

        public bool Maintenance(VehicleSelling entity, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(entity.Vehicle.VehicleNo));

            if (entity.BVDate.HasValue)
            {
                stringBuilder.Append(getSQLInsert(entity, company));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteVehicleSelling(VehicleSelling entity, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(entity.Vehicle.VehicleNo));

            bool result = (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
            return result;
        }

        public bool InsertVehicleSelling(VehicleSelling vehicleSelling, Company company)
        {
            SqlCommand command = tableAccess.CreateCommand("SInsertVehicleSellingPlan");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Company_Code", company.CompanyCode));
            command.Parameters.Add(tableAccess.CreateParameter("@Vehicle_No", vehicleSelling.Vehicle.VehicleNo));
            command.Parameters.Add(tableAccess.CreateParameter("@Selling_Price", vehicleSelling.SellingPrice));
            command.Parameters.Add(tableAccess.CreateParameter("@BV_Date", vehicleSelling.BVDate.Value.Date));
            command.Parameters.Add(tableAccess.CreateParameter("@BV", vehicleSelling.BV));

            command.Parameters.Add(tableAccess.CreateParameter("@Process_User", UserProfile.UserID));

            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);

            return result;
        }

        public bool UpdateVehicleSelling(VehicleSelling entity, Company company)
        {
            SqlCommand command = tableAccess.CreateCommand("SUpdateVehicleSellingPlan");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Vehicle_No", entity.Vehicle.VehicleNo));
            command.Parameters.Add(tableAccess.CreateParameter("@Selling_Date", entity.SellingDate.Value.Date));
            command.Parameters.Add(tableAccess.CreateParameter("@Selling_Price", entity.SellingPrice));
            command.Parameters.Add(tableAccess.CreateParameter("@Bidder_Code", entity.Bidder.BidderCode));
            command.Parameters.Add(tableAccess.CreateParameter("@BV_Date", entity.BVDate.Value.Date));
            command.Parameters.Add(tableAccess.CreateParameter("@BV", entity.BV));

            command.Parameters.Add(tableAccess.CreateParameter("@Process_User", UserProfile.UserID));

            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);

            return result;
        }
    }
}
