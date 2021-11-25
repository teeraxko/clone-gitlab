using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using Entity.VehicleEntities.Leasing;
using ictus.Common.Entity;
using System.Data.SqlClient;
using ictus.Common.Entity.Time;

namespace DataAccess.VehicleDB
{
    public class VehicleSellingPlanDB : DataAccessBase
    {
        enum ColIndex
        {
            VEHICLE_NO, 
            ESTIMATE_YEAR, 
            ESTIMATE_MONTH, 
            SELLING_DATE, 
            ESTIMATE_SELLING, 
            BV_DATE,
            BV, 
            VEHICLE_YEAR
        }

        private VehicleDB dbVehicle;

        //============================== Constructor ==============================
        public VehicleSellingPlanDB()
            : base()
        {
            dbVehicle = new VehicleDB();
        }

        //============================== Private Method ==============================
        #region - getSQL -
        private string getSQLSelect()
        {
            return " SELECT Vehicle_No, Estimate_Year, Estimate_Month, Selling_Date, Estimate_Selling, BV_Date, BV, Vehicle_Year FROM Vehicle_Selling_Plan ";
        }

        private string getSQLInsert(VehicleSellingPlan entity, YearMonth yearMonth, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Vehicle_Selling_Plan (Company_Code, Vehicle_No, Estimate_Year, Estimate_Month, Selling_Date, Estimate_Selling, BV_Date, BV, Vehicle_Year, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(company.CompanyCode));
            stringBuilder.Append(", ");

            //Vehicle_No			
            stringBuilder.Append(GetDB(entity.VehicleInfo.VehicleNo));
            stringBuilder.Append(", ");

            //Estimate_Year
            stringBuilder.Append(GetDB(yearMonth.Year));
            stringBuilder.Append(", ");

            //Estimate_Month
            stringBuilder.Append(GetDB(yearMonth.Month));
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

            //Estimate_Selling
            stringBuilder.Append(GetDB(entity.EstimateSelling));
            stringBuilder.Append(", ");

            //BV_Date
            if (entity.BVDate.HasValue)
            {
                stringBuilder.Append(GetDB(entity.BVDate.Value));
            }
            else
            {
                stringBuilder.Append("NULL");
            }
            stringBuilder.Append(", ");

            //BV
            stringBuilder.Append(GetDB(entity.BV));
            stringBuilder.Append(", ");

            //Vehicle_Year
            stringBuilder.Append(GetDB(entity.VehicleYear));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(SystemFramework.AppConfig.UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(VehicleSellingPlan entity, YearMonth yearMonth, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Vehicle_Selling_Plan SET ");

            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(company.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_No = ");
            stringBuilder.Append(GetDB(entity.VehicleInfo.VehicleNo));
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

            stringBuilder.Append("Estimate_Selling = ");
            stringBuilder.Append(GetDB(entity.EstimateSelling));
            stringBuilder.Append(", ");

            stringBuilder.Append("BV_Date = ");
            if (entity.BVDate.HasValue)
            {
                stringBuilder.Append(GetDB(entity.BVDate.Value));
            }
            else
            {
                stringBuilder.Append("NULL");
            }
            stringBuilder.Append(", ");

            stringBuilder.Append("BV = ");
            stringBuilder.Append(GetDB(entity.BV));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_Year = ");
            stringBuilder.Append(GetDB(entity.VehicleYear));
            stringBuilder.Append(", ");

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

        private string getKeyCondition(VehicleSellingPlan entity)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (entity.VehicleInfo != null && IsNotNULL(entity.VehicleInfo.VehicleNo))
            {
                stringBuilder.Append(" AND (Vehicle_No = ");
                stringBuilder.Append(GetDB(entity.VehicleInfo.VehicleNo));
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
            return " ORDER BY Vehicle_No, Estimate_Year, Estimate_Month";
        }
        #endregion

        #region - Fill -
        private void Fill(VehicleSellingPlan entity, Company company, SqlDataReader dataReader)
        {
            entity.VehicleInfo = dbVehicle.GetDBVehicleInfo(dataReader.GetInt32((int)ColIndex.VEHICLE_NO), company);

            if (dataReader.IsDBNull((int)ColIndex.SELLING_DATE))
            {
                entity.SellingDate = null;    
            }
            else
            {
                entity.SellingDate = dataReader.GetDateTime((int)ColIndex.SELLING_DATE);
            }

            entity.EstimateSelling = dataReader.GetDecimal((int)ColIndex.ESTIMATE_SELLING);

            if (dataReader.IsDBNull((int)ColIndex.BV_DATE))
            {
                entity.BVDate = null;
            }
            else
            {
                entity.BVDate = dataReader.GetDateTime((int)ColIndex.SELLING_DATE);
            }

            entity.BV = dataReader.GetDecimal((int)ColIndex.BV);
            entity.VehicleYear = dataReader.GetByte((int)ColIndex.VEHICLE_YEAR);
        }

        private bool FillList(VehicleSellingPlanList list, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            VehicleSellingPlan entity;

            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    entity = new VehicleSellingPlan();
                    Fill(entity, list.Company, dataReader);
                    list.Add(entity);
                }
                entity = null;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }
        #endregion

        //============================== Public Method ==============================
        public bool FillList(VehicleSellingPlanList list)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(list.Company));
            stringBuilder.Append(getListCondition(list.EstimateYearMonth));
            stringBuilder.Append(getOrderby());

            return FillList(list, stringBuilder.ToString());
        }

        public bool Maintenance(VehicleSellingPlan entity, YearMonth yearMonth, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(entity));
            stringBuilder.Append(getListCondition(yearMonth));

            if (entity.BVDate.HasValue)
            {
                stringBuilder.Append(getSQLInsert(entity, yearMonth, company));
            }            

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public void Delete(VehicleSellingPlan entity, YearMonth yearMonth, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(entity));
            stringBuilder.Append(getListCondition(yearMonth));

            tableAccess.ExecuteSQL(stringBuilder.ToString());
        }
    }
}
