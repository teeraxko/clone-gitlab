using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using Entity.VehicleEntities.Leasing;
using ictus.Common.Entity;
using SystemFramework.AppConfig;
using System.Data.SqlClient;
using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.VehicleEntities.VehicleLeasing;

namespace DataAccess.VehicleDB
{
    public class VehiclePurchasingDB : DataAccessBase
    {
        private const int PURCHAS_NO = 0;
        private const int ISSUE_DATE = 1;
        private const int VENDOR_CODE = 2;
        private const int VEHICLE_PRICE = 3;
        private const int PURCHAS_STATUS = 4;

        private VendorDB dbVendor;

        //============================== Constructor ==============================
        public VehiclePurchasingDB()
            : base()
        {
            dbVendor = new VendorDB();
        }

        //============================== Constructor ==============================
        #region - getSQL -
        private string getSQLSelect()
        {
            return " SELECT Purchas_No, Issue_Date, Vendor_Code, Vehicle_Price, Purchas_Status FROM Vehicle_Purchasing ";
        }

        private string getSQLInsert(IPurchasing value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Vehicle_Purchasing (Company_Code, Purchas_No, Issue_Date, Vehicle_Brand_Code, Vehicle_Model_Code, Vehicle_Color_Code, Vehicle_Quantity, Vendor_Code, Vehicle_Price, Vendor_Quotation_Date, Purchas_Status, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");
           
            //Purchas_No
            stringBuilder.Append(GetDB(value.PurchaseNo.ToString()));
            stringBuilder.Append(", ");

            //Issue_Date
            stringBuilder.Append(GetDB(value.IssueDate));
            stringBuilder.Append(", ");

            //Vehicle_Brand_Code
            if (value.VehicleInfo.AModel != null && value.VehicleInfo.AModel.ABrand != null)
            {
                stringBuilder.Append(GetDB(value.VehicleInfo.AModel.ABrand.Code));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
                stringBuilder.Append(", ");
            }            

            //Vehicle_Model_Code
            if (value.VehicleInfo.AModel != null)
            {
                stringBuilder.Append(GetDB(value.VehicleInfo.AModel.Code));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
                stringBuilder.Append(", ");            
            }

            //Vehicle_Color_Code
            if (value.VehicleInfo.AColor != null)
            {
                stringBuilder.Append(GetDB(value.VehicleInfo.AColor.Code));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
                stringBuilder.Append(", ");  
            }

            //Vehicle_Quantity
            stringBuilder.Append(GetDB(value.Quantity));
            stringBuilder.Append(", ");

            //Vendor_Code
            if (value.Vendor != null)
            {
                stringBuilder.Append(GetDB(value.Vendor.Code));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
                stringBuilder.Append(", ");
            }

            //Vehicle_Price
            stringBuilder.Append(GetDB(value.VehiclePrice));
            stringBuilder.Append(", ");

            //Vendor_Quotation_Date
            stringBuilder.Append(GetDB(value.VendorQuotationDate));
            stringBuilder.Append(", ");

            //Purchas_Status
            stringBuilder.Append(GetDB(value.PurchasStatus));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(IPurchasing value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Vehicle_Purchasing SET ");
            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Purchas_No = ");
            stringBuilder.Append(GetDB(value.PurchaseNo.ToString()));
            stringBuilder.Append(", ");

            stringBuilder.Append("Issue_Date = ");
            stringBuilder.Append(GetDB(value.IssueDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_Brand_Code = ");
            if (value.VehicleInfo.AModel != null && value.VehicleInfo.AModel.ABrand != null)
            {
                stringBuilder.Append(GetDB(value.VehicleInfo.AModel.ABrand.Code));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
                stringBuilder.Append(", ");
            }            

            stringBuilder.Append("Vehicle_Model_Code = ");
            if (value.VehicleInfo.AModel != null)
            {
                stringBuilder.Append(GetDB(value.VehicleInfo.AModel.Code));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
                stringBuilder.Append(", ");
            }


            stringBuilder.Append("Vehicle_Color_Code = ");
            if (value.VehicleInfo.AColor != null)
            {
                stringBuilder.Append(GetDB(value.VehicleInfo.AColor.Code));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
                stringBuilder.Append(", ");
            }

            stringBuilder.Append("Vehicle_Quantity = ");
            stringBuilder.Append(GetDB(value.Quantity));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vendor_Code = ");
            if (value.Vendor != null)
            {
                stringBuilder.Append(GetDB(value.Vendor.Code));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
                stringBuilder.Append(", ");
            }

            stringBuilder.Append("Vehicle_Price = ");
            stringBuilder.Append(GetDB(value.VehiclePrice));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vendor_Quotation_Date = ");
            stringBuilder.Append(GetDB(value.VendorQuotationDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Purchas_Status = ");
            stringBuilder.Append(GetDB(value.PurchasStatus));
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_Date = ");
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_User = ");
            stringBuilder.Append(GetDB(UserProfile.UserID));

            return stringBuilder.ToString();
        }

        private string getSQLUpdateIssueDate(DateTime issueDate)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Vehicle_Purchasing SET ");

            stringBuilder.Append("Issue_Date = ");
            stringBuilder.Append(GetDB(issueDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_Date = ");
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_User = ");
            stringBuilder.Append(GetDB(UserProfile.UserID));

            return stringBuilder.ToString();
        }

        private string getSQLUpdatePOStatus(PURCHAS_STATUS_TYPE poStatus)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Vehicle_Purchasing SET ");

            stringBuilder.Append("Purchas_Status = ");
            stringBuilder.Append(GetDB(poStatus));
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
            return " DELETE FROM Vehicle_Purchasing ";
        }

        private string getKeyCondition(DocumentNo poNo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (poNo != null && poNo.ToString() != "")
            {
                stringBuilder.Append(" AND (Purchas_No = ");
                stringBuilder.Append(GetDB(poNo.ToString()));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        #endregion

        #region - Fill -
        private void fillPO(IPurchasing purchasing, Company company, SqlDataReader dataReader)
        {
            purchasing.PurchaseNo = new DocumentNo((string)dataReader[PURCHAS_NO]);
            purchasing.IssueDate = dataReader.GetDateTime(ISSUE_DATE);
            purchasing.Vendor = dbVendor.GetDBVendor((string)dataReader[VENDOR_CODE], company);
            purchasing.PurchasStatus = CTFunction.GetPurchasStatusType((string)dataReader[PURCHAS_STATUS]);
        }

        private bool fillPO(IPurchasing purchasing, Company aCompany, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillPO(purchasing, aCompany, dataReader);
                    result = true;
                }
                else
                { result = false; }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }
        #endregion

        //============================== Public Method ==============================
        public bool FillPO(IPurchasing purchasing, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(purchasing.PurchaseNo));

            return fillPO(purchasing, company, stringBuilder.ToString());
        }

        public bool InsertPO(IPurchasing purchasing, Company aCompany)
        {
            return (tableAccess.ExecuteSQL(getSQLInsert(purchasing, aCompany)) > 0);
        }

        public bool UpdatePO(IPurchasing purchasing, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(purchasing, aCompany));
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(purchasing.PurchaseNo));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool UpdatePOIssueDate(DocumentNo poNo, DateTime issueDate, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdateIssueDate(issueDate));
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(poNo));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool UpdatePOStatus(IPurchasing purchasing, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdatePOStatus(purchasing.PurchasStatus));
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(purchasing.PurchaseNo));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeletePO(IPurchasing purchasing, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(purchasing.PurchaseNo));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }
    }
}
