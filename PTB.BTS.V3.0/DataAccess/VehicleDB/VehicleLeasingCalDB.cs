using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using ictus.Common.Entity;
using Entity.VehicleEntities.Leasing;
using SystemFramework.AppConfig;
using DataAccess.ContractDB;
using System.Data.SqlClient;
using Entity.ContractEntities;

namespace DataAccess.VehicleDB
{
    public class VehicleLeasingCalDB : DataAccessBase
    {
        #region - Constant -
        //Constant Main
        private const int QUOTATION_NO = 0;
        private const int CUSTOMER_CODE = 1;
        private const int ISSUE_DATE = 2;
        private const int CUSTOMER_ACCEPT = 3;
        private const int PO_NO = 4;
        private const int VEHICLE_BRAND_CODE = 5;
        private const int VEHICLE_MODEL_CODE = 6;

        //Constant Detail
        private const int VALIDITY_DATE = 7;
        private const int DELIVERY_DAY = 8;
        private const int LEASE_TERM = 9;
        private const int DRIVER_NEED = 10;
        private const int VEHICLE_SECOND_HAND_STATUS = 11;
        private const int VEHICLE_COLOR_CODE = 12;
        private const int VEHICLE_QUANTITY = 13;
        private const int COST_BODY = 14;
        private const int COST_BODY_VENDOR_QUOTATION_DATE = 15;
        private const int COST_MODIFY = 16;
        private const int COST_OTHER = 17;
        private const int COST_OTHER_DESCRIPTION = 18;
        private const int COST_CAPITAL_INSURANCE = 19;
        private const int COST_INSURANCE_PREMIUM = 20;
        private const int COST_REGISTER = 21;
        private const int COST_MAINTENANCE = 22;
        private const int CAL_VEHICLE_PRICE = 23;
        private const int CAL_PERCENT_RESIDUAL = 24;
        private const int CAL_RESIDUAL_VALUE = 25;
        private const int CAL_RATE_OF_RETURN = 26;
        private const int CAL_LESS_PV = 27;
        private const int CAL_PMT = 28;
        private const int CAL_INSURANCE_PREMIUM = 29;
        private const int CAL_REGISTER = 30;
        private const int CAL_MONTHLY_CHARGE_ACTUAL = 31;
        private const int CAL_MONTHLY_CHARGE = 32;
        private const int KIND_OF_VEHICLE = 33;

        #endregion

        private KindOfVehicleDB dbKindOfVehicle;
        private CustomerDB dbCustomer;
        private ModelDB dbModel;
        private ColorDB dbColor;

        //============================== Constructor ==============================
        public VehicleLeasingCalDB() : base()
        {
            dbKindOfVehicle = new KindOfVehicleDB();
            dbCustomer = new CustomerDB();
            dbModel = new ModelDB();
            dbColor = new ColorDB();
        }

        //============================== Private Method ==============================
        #region - getSQL -
        private string getSQLSelectQuotationMain()
        {
            return " SELECT Quotation_No, Customer_Code, Issue_Date, Customer_Accept, PO_No, Vehicle_Brand_Code, Vehicle_Model_Code FROM Vehicle_Leasing ";
        }

        private string getSQLSelectQuotationDetail()
        {
            return " SELECT Quotation_No, Customer_Code, Issue_Date, Customer_Accept, PO_No, Vehicle_Brand_Code, Vehicle_Model_Code, Validity_Date, Delivery_Day, Lease_Term, Driver_need, Vehicle_Second_Hand_Status, Vehicle_Color_Code, Vehicle_Quantity, Cost_Body, Cost_Body_Vendor_Quotation_Date, Cost_Modify, Cost_Other, Cost_Other_Description, Cost_Capital_Insurance, Cost_Insurance_Premium, Cost_Register, Cost_Maintenance, Cal_Vehicle_Price, Cal_Percent_Residual, Cal_Residual_Value, Cal_Rate_Of_Return, Cal_Less_PV, Cal_PMT, Cal_Insurance_Premium, Cal_Register, Cal_Monthly_Charge_Actual, Cal_Monthly_Charge, Kind_Of_Vehicle FROM Vehicle_Leasing ";
        }

        private string getSQLInsert(Quotation value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Vehicle_Leasing (Company_Code, Quotation_No, Customer_Code, Issue_Date, Validity_Date, Delivery_Day, Lease_Term, Driver_need, Customer_Accept, PO_No, Vehicle_Brand_Code, Vehicle_Model_Code, Vehicle_Second_Hand_Status, Vehicle_Color_Code, Vehicle_Quantity, Kind_Of_Vehicle, Cost_Body, Cost_Body_Vendor_Quotation_Date, Cost_Modify, Cost_Other, Cost_Other_Description, Cost_Capital_Insurance, Cost_Insurance_Premium, Cost_Register, Cost_Maintenance, Cal_Vehicle_Price, Cal_Percent_Residual, Cal_Residual_Value, Cal_Rate_Of_Return, Cal_Less_PV, Cal_PMT, Cal_Insurance_Premium, Cal_Register, Cal_Monthly_Charge_Actual, Cal_Monthly_Charge, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Quotation_No
            stringBuilder.Append(GetDB(value.QuotationNo.ToString()));
            stringBuilder.Append(", ");

            //Customer_Code
            if (value.Customer != null)
            {
                stringBuilder.Append(GetDB(value.Customer.Code));
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
            }
            stringBuilder.Append(", ");

            //Issue_Date
            stringBuilder.Append(GetDB(value.LastIssueDate));
            stringBuilder.Append(", ");

            //Validity_Date
            stringBuilder.Append(GetDB(value.ValidityDate));
            stringBuilder.Append(", ");

            //Delivery_Day
            stringBuilder.Append(GetDB(value.DeliveryDays));
            stringBuilder.Append(", ");

            //Lease_Term
            stringBuilder.Append(GetDB(value.LeaseTerm));
            stringBuilder.Append(", ");

            //Driver_need
            stringBuilder.Append(GetDB(value.IsDriverNeed));
            stringBuilder.Append(", ");

            //Customer_Accept
            stringBuilder.Append(GetDB(value.IsCustomerAccept));
            stringBuilder.Append(", ");

            //PO_No
            stringBuilder.Append(GetDB(value.PONo));
            stringBuilder.Append(", ");

            //Vehicle_Brand_Code
            if (value.AnewVehicle.VehicleInfo.AModel != null && value.AnewVehicle.VehicleInfo.AModel.ABrand != null)
            {
                stringBuilder.Append(GetDB(value.AnewVehicle.VehicleInfo.AModel.ABrand.Code));
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
            }
            stringBuilder.Append(", ");

            //Vehicle_Model_Code
            if (value.AnewVehicle.VehicleInfo.AModel != null)
            {
                stringBuilder.Append(GetDB(value.AnewVehicle.VehicleInfo.AModel.Code));
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
            }
            stringBuilder.Append(", ");

            //Vehicle_Second_Hand_Status
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleInfo.IsSecondHand));
            stringBuilder.Append(", ");

            //Vehicle_Color_Code
            if (value.AnewVehicle.VehicleInfo.AColor != null)
            {
                stringBuilder.Append(GetDB(value.AnewVehicle.VehicleInfo.AColor.Code));
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
            }
            stringBuilder.Append(", ");

            //Vehicle_Quantity
            stringBuilder.Append(GetDB(value.Quantity));
            stringBuilder.Append(", ");

            //Kind_Of_Vehicle
            if (value.KindOfVehicle != null)
            {
                stringBuilder.Append(GetDB(value.KindOfVehicle.Code));
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
            }
            stringBuilder.Append(", ");

            //Cost_Body
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.VehiclePrice.BodyPrice));
            stringBuilder.Append(", ");

            //Cost_Body_Vendor_Quotation_Date
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.VendorQuotaionDate));
            stringBuilder.Append(", ");

            //Cost_Modify
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.VehiclePrice.ModifyPrice));
            stringBuilder.Append(", ");

            //Cost_Other
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.VehiclePrice.OtherPrice));
            stringBuilder.Append(", ");

            //Cost_Other_Description
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.VehiclePrice.OtherPriceDesc));
            stringBuilder.Append(", ");

            //Cost_Capital_Insurance
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.CapitalInsurance));
            stringBuilder.Append(", ");

            //Cost_Insurance_Premium
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.InsurancePremium));
            stringBuilder.Append(", ");

            //Cost_Register
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.VehicleRegister));
            stringBuilder.Append(", ");

            //Cost_Maintenance
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.MaintenanceCharge));
            stringBuilder.Append(", ");

            //Cal_Vehicle_Price
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.TotalVehiclePrice));
            stringBuilder.Append(", ");

            //Cal_Percent_Residual
            stringBuilder.Append(GetDB(value.LeasingCalculation.PercentOfResidual));
            stringBuilder.Append(", ");

            //Cal_Residual_Value
            stringBuilder.Append(GetDB(value.LeasingCalculation.ResidualValue));
            stringBuilder.Append(", ");

            //Cal_Rate_Of_Return
            stringBuilder.Append(GetDB(value.LeasingCalculation.RateOfReturn));
            stringBuilder.Append(", ");

            //Cal_Less_PV
            stringBuilder.Append(GetDB(value.LeasingCalculation.PV));
            stringBuilder.Append(", ");

            //Cal_PMT
            stringBuilder.Append(GetDB(value.LeasingCalculation.PMT));
            stringBuilder.Append(", ");

            //Cal_Insurance_Premium
            stringBuilder.Append(GetDB(value.LeasingCalculation.InsuranceCharge));
            stringBuilder.Append(", ");

            //Cal_Register
            stringBuilder.Append(GetDB(value.LeasingCalculation.RegisterCharge));
            stringBuilder.Append(", ");

            //Cal_Monthly_Charge_Actual
            stringBuilder.Append(GetDB(value.LeasingCalculation.MonthlyCharge));
            stringBuilder.Append(", ");

            //Cal_Monthly_Charge
            stringBuilder.Append(GetDB(value.LeasingCalculation.MonthlyRoundCharge));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(Quotation value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Vehicle_Leasing SET ");
            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Quotation_No = ");
            stringBuilder.Append(GetDB(value.QuotationNo.ToString()));
            stringBuilder.Append(", ");

            stringBuilder.Append("Customer_Code = ");
            if (value.Customer != null)
            {
                stringBuilder.Append(GetDB(value.Customer.Code));
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
            }
            stringBuilder.Append(", ");

            stringBuilder.Append("Issue_Date = ");
            stringBuilder.Append(GetDB(value.LastIssueDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Validity_Date = ");
            stringBuilder.Append(GetDB(value.ValidityDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Delivery_Day = ");
            stringBuilder.Append(GetDB(value.DeliveryDays));
            stringBuilder.Append(", ");

            stringBuilder.Append("Lease_Term = ");
            stringBuilder.Append(GetDB(value.LeaseTerm));
            stringBuilder.Append(", ");

            stringBuilder.Append("Driver_need = ");
            stringBuilder.Append(GetDB(value.IsDriverNeed));
            stringBuilder.Append(", ");

            stringBuilder.Append("Customer_Accept = ");
            stringBuilder.Append(GetDB(value.IsCustomerAccept));
            stringBuilder.Append(", ");

            stringBuilder.Append("PO_No = ");
            stringBuilder.Append(GetDB(value.PONo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_Brand_Code = ");
            if (value.AnewVehicle.VehicleInfo.AModel != null && value.AnewVehicle.VehicleInfo.AModel.ABrand != null)
            {
                stringBuilder.Append(GetDB(value.AnewVehicle.VehicleInfo.AModel.ABrand.Code));
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
            }
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_Model_Code = ");
            if (value.AnewVehicle.VehicleInfo.AModel != null)
            {
                stringBuilder.Append(GetDB(value.AnewVehicle.VehicleInfo.AModel.Code));
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
            }
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_Second_Hand_Status = ");
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleInfo.IsSecondHand));
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_Color_Code = ");
            if (value.AnewVehicle.VehicleInfo.AColor != null)
            {
                stringBuilder.Append(GetDB(value.AnewVehicle.VehicleInfo.AColor.Code));
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
            }
            stringBuilder.Append(", ");

            stringBuilder.Append("Vehicle_Quantity = ");
            stringBuilder.Append(GetDB(value.Quantity));
            stringBuilder.Append(", ");

            stringBuilder.Append("Kind_Of_Vehicle = ");
            if (value.KindOfVehicle != null)
            {
                stringBuilder.Append(GetDB(value.KindOfVehicle.Code));
            }
            else
            {
                stringBuilder.Append(GetDB(" "));
            }
            stringBuilder.Append(", ");

            stringBuilder.Append("Cost_Body = ");
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.VehiclePrice.BodyPrice));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cost_Body_Vendor_Quotation_Date = ");
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.VendorQuotaionDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cost_Modify = ");
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.VehiclePrice.ModifyPrice));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cost_Other = ");
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.VehiclePrice.OtherPrice));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cost_Other_Description = ");
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.VehiclePrice.OtherPriceDesc));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cost_Capital_Insurance = ");
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.CapitalInsurance));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cost_Insurance_Premium = ");
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.InsurancePremium));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cost_Register = ");
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.VehicleRegister));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cost_Maintenance = ");
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.MaintenanceCharge));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cal_Vehicle_Price = ");
            stringBuilder.Append(GetDB(value.AnewVehicle.VehicleCost.TotalVehiclePrice));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cal_Percent_Residual = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.PercentOfResidual));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cal_Residual_Value = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.ResidualValue));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cal_Rate_Of_Return = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.RateOfReturn));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cal_Less_PV = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.PV));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cal_PMT = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.PMT));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cal_Insurance_Premium = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.InsuranceCharge));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cal_Register = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.RegisterCharge));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cal_Monthly_Charge_Actual = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.MonthlyCharge));
            stringBuilder.Append(", ");

            stringBuilder.Append("Cal_Monthly_Charge = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.MonthlyRoundCharge));
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
            StringBuilder stringBuilder = new StringBuilder("UPDATE Vehicle_Leasing SET ");

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

        private string getSQLDelete()
        {
            return " DELETE FROM Vehicle_Leasing ";
        }

        private string getKeyCondition(DocumentNo quotationNo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (quotationNo != null)
            {
                if (IsNotNULL(quotationNo.Year) && IsNotNULL(quotationNo.Month) && IsNotNULL(quotationNo.No))
                {
                    stringBuilder.Append(" AND (Quotation_No = ");
                    stringBuilder.Append(GetDB(quotationNo.ToString()));
                    stringBuilder.Append(")");
                }
                else
                {
                    if (IsNotNULL(quotationNo.Year))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Quotation_No, 7, 2) = ");
                        stringBuilder.Append(GetDB(quotationNo.Year));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(quotationNo.Month))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Quotation_No, 9, 2) = ");
                        stringBuilder.Append(GetDB(quotationNo.Month));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(quotationNo.No))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Quotation_No, 11, 3) = ");
                        stringBuilder.Append(GetDB(quotationNo.No));
                        stringBuilder.Append(")");
                    }
                }
            }
            return stringBuilder.ToString();
        }

        private string getListCondition(DateTime formIssueDate)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" AND (YEAR(Issue_Date) >= ");
            stringBuilder.Append(GetDB(formIssueDate.Year));
            stringBuilder.Append(") ");
            return stringBuilder.ToString();
        }

        private string getOrderby()
        {
            return " ORDER BY Quotation_No ";
        }

        #endregion

        #region - Fill -
        private void fillQuotationMain(Quotation value, Company company, SqlDataReader dataReader)
        {
            value.QuotationNo = new DocumentNo((string)dataReader[QUOTATION_NO]);
            value.Customer = dbCustomer.GetDBCustomer((string)dataReader[CUSTOMER_CODE], company);
            value.LastIssueDate = dataReader.GetDateTime(ISSUE_DATE);
            value.IsCustomerAccept = GetBool((string)dataReader[CUSTOMER_ACCEPT]);
            value.PONo = (string)dataReader[PO_NO];
            value.AnewVehicle.VehicleInfo.AModel = dbModel.GetDBModel((string)dataReader[VEHICLE_MODEL_CODE], (string)dataReader[VEHICLE_BRAND_CODE]);
        }

        private void fillQuotationDetail(Quotation value, Company company, SqlDataReader dataReader)
        {
            value.ValidityDate = dataReader.GetDateTime(VALIDITY_DATE);
            value.DeliveryDays = dataReader.GetByte(DELIVERY_DAY);
            value.LeaseTerm = dataReader.GetByte(LEASE_TERM);
            value.IsDriverNeed = GetBool((string)dataReader[DRIVER_NEED]);
            value.AnewVehicle.VehicleInfo.IsSecondHand = CTFunction.GetSecondHandStatusType((string)dataReader[VEHICLE_SECOND_HAND_STATUS]);
            value.AnewVehicle.VehicleInfo.AColor = (Entity.VehicleEntities.Color)dbColor.GetMTB((string)dataReader[VEHICLE_COLOR_CODE]);
            value.Quantity = dataReader.GetByte(VEHICLE_QUANTITY);
            value.KindOfVehicle = (Entity.VehicleEntities.KindOfVehicle)dbKindOfVehicle.GetDBDualField((string)dataReader[KIND_OF_VEHICLE], company);

            value.AnewVehicle.VehicleCost = new VehicleCost();
            value.AnewVehicle.VehicleCost.VendorQuotaionDate = dataReader.GetDateTime(COST_BODY_VENDOR_QUOTATION_DATE);
            value.AnewVehicle.VehicleCost.CapitalInsurance = dataReader.GetDecimal(COST_CAPITAL_INSURANCE);
            value.AnewVehicle.VehicleCost.InsurancePremium = dataReader.GetDecimal(COST_INSURANCE_PREMIUM);
            value.AnewVehicle.VehicleCost.VehicleRegister = dataReader.GetDecimal(COST_REGISTER);
            value.AnewVehicle.VehicleCost.MaintenanceCharge = dataReader.GetDecimal(COST_MAINTENANCE);

            value.AnewVehicle.VehicleCost.VehiclePrice = new VehiclePrice();
            value.AnewVehicle.VehicleCost.VehiclePrice.BodyPrice = dataReader.GetDecimal(COST_BODY);
            value.AnewVehicle.VehicleCost.VehiclePrice.ModifyPrice = dataReader.GetDecimal(COST_MODIFY);
            value.AnewVehicle.VehicleCost.VehiclePrice.OtherPrice = dataReader.GetDecimal(COST_OTHER);
            value.AnewVehicle.VehicleCost.VehiclePrice.OtherPriceDesc = (string)dataReader[COST_OTHER_DESCRIPTION];            

            value.LeasingCalculation = new LeasingCalculation();
            value.LeasingCalculation.MaintenanceCharge = value.AnewVehicle.VehicleCost.MaintenanceCharge;
            value.LeasingCalculation.PercentOfResidual = dataReader.GetDecimal(CAL_PERCENT_RESIDUAL);
            value.LeasingCalculation.ResidualValue = dataReader.GetDecimal(CAL_RESIDUAL_VALUE);
            value.LeasingCalculation.RateOfReturn = dataReader.GetDecimal(CAL_RATE_OF_RETURN);
            value.LeasingCalculation.PV = dataReader.GetDecimal(CAL_LESS_PV);
            value.LeasingCalculation.PMT = dataReader.GetDecimal(CAL_PMT);
            value.LeasingCalculation.InsuranceCharge = dataReader.GetDecimal(CAL_INSURANCE_PREMIUM);
            value.LeasingCalculation.RegisterCharge = dataReader.GetDecimal(CAL_REGISTER);
            value.LeasingCalculation.MonthlyRoundCharge = dataReader.GetDecimal(CAL_MONTHLY_CHARGE);
        }

        private bool fillQuotationDetail(Quotation value, Company aCompany, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillQuotationDetail(value, aCompany, dataReader);
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

        private bool fillQuotationMainList(QuotationList value, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                Quotation quotation;
                while (dataReader.Read())
                {
                    result = true;
                    quotation = new Quotation();
                    fillQuotationMain(quotation, value.Company, dataReader);
                    value.Add(quotation);
                }
                quotation = null;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

        private bool fillQuotation(Quotation value, Company company, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillQuotationMain(value, company, dataReader);
                    fillQuotationDetail(value, company, dataReader);
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
        public bool FillQuotationMainList(QuotationList quotationList, DateTime fromIssueDate)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectQuotationMain());
            stringBuilder.Append(getBaseCondition(quotationList.Company));
            stringBuilder.Append(getListCondition(fromIssueDate));
            stringBuilder.Append(getOrderby());

            return fillQuotationMainList(quotationList, stringBuilder.ToString());
        }

        public bool FillQuotationMainList(QuotationList quotationList, Quotation quotation)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectQuotationMain());
            stringBuilder.Append(getBaseCondition(quotationList.Company));
            stringBuilder.Append(getKeyCondition(quotation.QuotationNo));
            stringBuilder.Append(getListCondition(quotation.LastIssueDate));
            stringBuilder.Append(getOrderby());

            return fillQuotationMainList(quotationList, stringBuilder.ToString());
        }

        public bool FillQuotationDetail(Quotation quotation, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectQuotationDetail());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(quotation.QuotationNo));

            return fillQuotationDetail(quotation, company, stringBuilder.ToString());
        }

        public bool FillQuotation(Quotation quotation, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectQuotationDetail());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(quotation.QuotationNo));

            return fillQuotation(quotation, company, stringBuilder.ToString());
        }

        public bool InsertQuotation(Quotation quotation, Company aCompany)
        {
            return (tableAccess.ExecuteSQL(getSQLInsert(quotation, aCompany)) > 0);
        }

        public bool UpdateQuotation(Quotation quotation, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(quotation, aCompany));
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(quotation.QuotationNo));

           return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool UpdateQuotationIssueDate(DocumentNo quotationNo, DateTime issueDate, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdateIssueDate(issueDate));
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(quotationNo));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteQuotation(Quotation quotation, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(quotation.QuotationNo));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }
    }
}
