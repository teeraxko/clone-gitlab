using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.VehicleEntities.VehicleLeasing;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;


namespace DataAccess.VehicleDB.VehicleLeasingDB
{
    public class VehicleCalculationDB : DataAccess.CommonDB.DataAccessBase
    {
        #region Constant
        private const int CUSTOMER_CODE = 0;
        private const int CUSTOMER_SNAME = 1;
        private const int BRAND_CODE = 2;
        private const int BRAND_ENAME = 3;
        private const int ISSUE_DATE = 8;
        private const int CALCULATION_NO = 9;
        private const int QUOTATION_NO = 10;
        #endregion

        #region StoreProcedure

        private const string STPROC_VEH_SEARCH_CALCULATION = "SVehicleSearchCalculation";
        private const string STPROC_VEH_SEARCH_CALCULATION_BY_PLATE_NO = "SVehicleSearchCalculationByPlateNo";
        private const string STPROC_VEH_SEARCH_CALCULATION_LIST_BY_PLATE_NO = "SVehicleSearchCalculationListByPlateNo";
        private const string STPROC_VEH_UPDATE_CALCULATION = "SVehicleUpdateCalculation";
        private const string STPROC_VEH_SEARCH_CALCULATION_BY_CALCULATION_NO = "SVehicleSearchCalculationByCalculationNo";
        private const string STPROC_VEH_SEARCH_CALCULATION_BY_QUOTATION_NO = "SVehicleSearchCalculationByQuotationNo";
        private const string STPROC_VEH_SEARCH_CALCULATION_BY_QUOTATION_LIST = "SVehicleSearchCalculationByQuotationList";
        private const string STPROC_VEH_UPDATE_CALCULATION_BY_QUOTATION_NO = "SVehicleUpdateCalculationByQuotationNo";
        private const string STPROC_VEH_UPDATE_CALCULATION_TONULL_QUOTATION_NO = "SVehicleUpdateCalculationToNullQuotationNo";
        private const string STPROC_VEH_SEARCH_CALCULATION_QUOTATION = "SVehicleSearchCalculationQuotation";
        #endregion

        #region Constructor

        public VehicleCalculationDB()  : base()
        {}

        #endregion

        #region Private Method

        //============================== Private Method ==============================
        #region - getSQL -
        private string getSQLSelectAll()
        {
            return " SELECT * FROM Vehicle_Calculation ";
        }

        private string getSQLSelect()
        {
            return " SELECT Company_Code,Customer_Code,Brand_Code,Model_Code,Color_Code,Quotation_No,Process_Date  FROM Vehicle_Calculation ";
        }

        private string getSQLSelectSearchCondition()
        {
            return " SELECT Customer.Customer_Code AS Customer_Code, Customer.Short_Name AS Customer_SName, Brand.Brand_Code AS Brand_Code, Brand.Brand_English_Name AS Brand_EName, Model.Model_Code AS Model_Code, Model.Model_English_Name AS Model_EName, Color.Color_Code AS Color_Code, Color.English_Color_Name AS Color_EName,Vehicle_Calculation.Issue_Date AS Issue_Date, Vehicle_Calculation.Calculation_No AS Calculation_No, Vehicle_Calculation.Quotation_No AS Quotation_No, Vehicle_Calculation.*";
        }

        private string getSQLSelectSearchTable()
        {
            return " FROM Vehicle_Calculation INNER JOIN Customer ON Vehicle_Calculation.Customer_Code = Customer.Customer_Code INNER JOIN Model ON Vehicle_Calculation.Model_Code = Model.Model_Code INNER JOIN Brand ON Model.Brand_Code = Brand.Brand_Code INNER JOIN Color ON Vehicle_Calculation.Color_Code = Color.Color_Code";
        }

        private string getSQLKeySearchCondition(Customer aCustomer, Brand aBrand, Model aModel, Color aColor)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(aCustomer.Code))
            {
                stringBuilder.Append(" WHERE (Vehicle_Calculation.Customer_Code = ");
                stringBuilder.Append(GetDB(aCustomer.Code));
                stringBuilder.Append(")");
            }
            if (IsNotNULL(aBrand.Code))
            {
                stringBuilder.Append(" AND (Brand.Brand_Code = ");
                stringBuilder.Append(GetDB(aBrand.Code));
                stringBuilder.Append(")");
            }
            if (IsNotNULL(aModel.Code))
            {
                stringBuilder.Append(" AND (Vehicle_Calculation.Model_Code = ");
                stringBuilder.Append(GetDB(aModel.Code));
                stringBuilder.Append(")");
            }
            if (IsNotNULL(aColor.Code))
            {
                stringBuilder.Append(" AND (Vehicle_Calculation.Color_Code = ");
                stringBuilder.Append(GetDB(aColor.Code));
                stringBuilder.Append(")");
            }

            return stringBuilder.ToString();
        }

        private string getSQLKeySearchConditionOrder()
        {
            return " ORDER BY Vehicle_Calculation.Issue_Date";
        }

        private string getSQLInsert(VehicleCalculation value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" INSERT INTO Vehicle_Calculation (Company_Code, Calculation_No, Customer_Code, Brand_code, Model_Code, Color_Code, Issue_Date, Body_Cost, Modify_Cost, Percent_Residual, Residual_Value, Lease_Term, Rate_Of_Return_Estimate, Rate_Of_Return_Actual, Interest_Rate, Depreciation, Capital_Insurance, Insurance_Premium, Register, Maintenance, Maintenance_Spare_Car, Less_PV, PMT, Monthly_Charge_Actual, Monthly_Charge, Process_Date, Process_User ,discount_amount,discount_total) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Calculation_No
            stringBuilder.Append(GetDB(value.CalculationNo.ToString()));
            stringBuilder.Append(", ");

            //Customer_Code			
            stringBuilder.Append(GetDB(value.Customer.Code));
            stringBuilder.Append(", ");

            //Brand_COde
            stringBuilder.Append(GetDB(value.Model.ABrand.Code));
            stringBuilder.Append(", ");

            //Model_Code
            stringBuilder.Append(GetDB(value.Model.Code));
            stringBuilder.Append(", ");

            //Delete color from calculation : woranai 2009/02/18
            //stringBuilder.Append(GetDB(value.Color.Code));
            //Color_Code
            stringBuilder.Append("NULL");
            stringBuilder.Append(", ");


            //Issue_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Body_Cost
            stringBuilder.Append(GetDB(value.BodyCost));
            stringBuilder.Append(", ");

            //Modify_Cost
            stringBuilder.Append(GetDB(value.ModifyCost));
            stringBuilder.Append(", ");

            //Percent_Residaul
            stringBuilder.Append(GetDB(value.LeasingCalculation.PercentResidual));
            stringBuilder.Append(", ");

            //Residual_Value
            stringBuilder.Append(GetDB(value.LeasingCalculation.ResidualValue));
            stringBuilder.Append(", ");

            //Lease_Term
            stringBuilder.Append(GetDB(value.LeasingCalculation.LeaseTerm));
            stringBuilder.Append(", ");

            //Rate_Of_Return_Estimate
            stringBuilder.Append(GetDB(value.LeasingCalculation.RateOfReturnEstimate));
            stringBuilder.Append(", ");

            //Rate_Of_Return_Actual
            stringBuilder.Append(GetDB(value.LeasingCalculation.RateOfReturnActual));
            stringBuilder.Append(", ");

            //Interest_Rate
            stringBuilder.Append(GetDB(value.LeasingCalculation.InterestRate));
            stringBuilder.Append(", ");

            //Depreciation
            stringBuilder.Append(GetDB(value.Depreciation));
            stringBuilder.Append(", ");

            //Capital_Insurance
            stringBuilder.Append(GetDB(value.LeasingCalculation.CapitalInsurance));
            stringBuilder.Append(", ");

            //Insurance_Premium
            stringBuilder.Append(GetDB(value.LeasingCalculation.InsurancePremium));
            stringBuilder.Append(", ");

            //Register
            stringBuilder.Append(GetDB(value.LeasingCalculation.TaxRegister));
            stringBuilder.Append(", ");

            //Maintenence
            stringBuilder.Append(GetDB(value.LeasingCalculation.Maintenance));
            stringBuilder.Append(", ");

            //Maintenence
            stringBuilder.Append(GetDB(value.LeasingCalculation.MaintenanceActual));
            stringBuilder.Append(", ");

            //Less_PV
            stringBuilder.Append(GetDB(value.LeasingCalculation.PV));
            stringBuilder.Append(", ");

            //PMT
            stringBuilder.Append(GetDB(value.LeasingCalculation.PMT));
            stringBuilder.Append(", ");

            //Monthly_Charge_Actual
            stringBuilder.Append(GetDB(value.LeasingCalculation.MonthlyChargeActual));
            stringBuilder.Append(", ");

            //Monthly_Charge
            stringBuilder.Append(GetDB(value.LeasingCalculation.MonthlyCharge));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");


            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(", ");


            //Todsporn Modified 25/2/2020 PO. Discount


          



            //discount_amount
            stringBuilder.Append(GetDB(value.DiscountAmount));
            stringBuilder.Append(", ");

            //discount_total
            stringBuilder.Append(GetDB(value.DiscountTotal));
            stringBuilder.Append(")");







            return stringBuilder.ToString();
        }

        private string getSQLInsertByQuotation(VehicleCalculation value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" SELECT NewID()");
            stringBuilder.Append(" GO ");
            stringBuilder.Append(" INSERT INTO Vehicle_Calculation (Company_Code, Calculation_No, Customer_Code, Quotation_No,Brand_code, Model_Code, Color_Code, Issue_Date, Body_Cost, Modify_Cost, Percent_Residual, Residual_Value, Lease_Term, Rate_Of_Return_Estimate, Rate_Of_Return_Actual, Interest_Rate, Depreciation, Capital_Insurance, Insurance_Premium, Register, Maintenance, Maintenance_Spare_Car, Less_PV, PMT, Monthly_Charge_Actual, Monthly_Charge, Process_Date, Process_User ,Leasing_No ,Discount_Amount,Discount_Total) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Calculation is generated by system (GUID)
            stringBuilder.Append("NewID()");
            stringBuilder.Append(", ");

            //Customer_Code			
            stringBuilder.Append(GetDB(value.Customer.Code));
            stringBuilder.Append(", ");

            //Quotation_No
            if (value.Quotation == null)
            {
                stringBuilder.Append(GetDB(""));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(value.Quotation.QuotationNo.ToString()));
                stringBuilder.Append(", ");
            }

            //Brand_COde
            stringBuilder.Append(GetDB(value.Model.ABrand.Code));
            stringBuilder.Append(", ");

            //Model_Code
            stringBuilder.Append(GetDB(value.Model.Code));
            stringBuilder.Append(", ");

            //Delete color from calculation : woranai 2009/02/18
            //stringBuilder.Append(GetDB(value.Color.Code));
            //Color_Code
            stringBuilder.Append("NULL");
            stringBuilder.Append(", ");

            //Issue_Date
            //stringBuilder.Append(GetDB(value.IssueDate.Date));
            //stringBuilder.Append(", ");
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Body_Cost
            stringBuilder.Append(GetDB(value.BodyCost));
            stringBuilder.Append(", ");

            //Modify_Cost
            stringBuilder.Append(GetDB(value.ModifyCost));
            stringBuilder.Append(", ");

            //Percent_Residaul
            stringBuilder.Append(GetDB(value.LeasingCalculation.PercentResidual));
            stringBuilder.Append(", ");

            //Residual_Value
            stringBuilder.Append(GetDB(value.LeasingCalculation.ResidualValue));
            stringBuilder.Append(", ");

            //Lease_Term
            stringBuilder.Append(GetDB(value.LeasingCalculation.LeaseTerm));
            stringBuilder.Append(", ");

            //Rate_Of_Return_Estimate
            stringBuilder.Append(GetDB(value.LeasingCalculation.RateOfReturnEstimate));
            stringBuilder.Append(", ");

            //Rate_Of_Return_Actual
            stringBuilder.Append(GetDB(value.LeasingCalculation.RateOfReturnActual));
            stringBuilder.Append(", ");

            //Interest_Rate
            stringBuilder.Append(GetDB(value.LeasingCalculation.InterestRate));
            stringBuilder.Append(", ");

            //Depreciation
            stringBuilder.Append(GetDB(value.Depreciation));
            stringBuilder.Append(", ");

            //Capital_Insurance
            stringBuilder.Append(GetDB(value.LeasingCalculation.CapitalInsurance));
            stringBuilder.Append(", ");

            //Insurance_Premium
            stringBuilder.Append(GetDB(value.LeasingCalculation.InsurancePremium));
            stringBuilder.Append(", ");

            //Register
            stringBuilder.Append(GetDB(value.LeasingCalculation.TaxRegister));
            stringBuilder.Append(", ");

            //Maintenence
            stringBuilder.Append(GetDB(value.LeasingCalculation.Maintenance));
            stringBuilder.Append(", ");

            //Maintenence
            stringBuilder.Append(GetDB(value.LeasingCalculation.MaintenanceActual));
            stringBuilder.Append(", ");

            //Less_PV
            stringBuilder.Append(GetDB(value.LeasingCalculation.PV));
            stringBuilder.Append(", ");

            //PMT
            stringBuilder.Append(GetDB(value.LeasingCalculation.PMT));
            stringBuilder.Append(", ");

            //Monthly_Charge_Actual
            stringBuilder.Append(GetDB(value.LeasingCalculation.MonthlyChargeActual));
            stringBuilder.Append(", ");

            //Monthly_Charge
            stringBuilder.Append(GetDB(value.LeasingCalculation.MonthlyCharge));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(", ");




            //Leasing 
            //Todsporn Modified 25/2/2020 PO. Discount
            if (value.LeasingNo == null)
            {
                stringBuilder.Append(GetDB(""));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(value.LeasingNo.ToString()));
                stringBuilder.Append(", ");
            }



            //Discount_Amount
            stringBuilder.Append(GetDB(value.DiscountAmount));
            stringBuilder.Append(", ");

            //Discount_Total
            stringBuilder.Append(GetDB(value.DiscountTotal));
            stringBuilder.Append(")");


            return stringBuilder.ToString();
        }

        private string getSQLUpdate(VehicleCalculation value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Vehicle_Calculation SET ");
            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Customer_Code = ");
            stringBuilder.Append(GetDB(value.Customer.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Brand_Code = ");
            stringBuilder.Append(GetDB(value.Model.ABrand.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Model_Code = ");
            stringBuilder.Append(GetDB(value.Model.Code));
            stringBuilder.Append(", ");

            //Delete color from calculation : woranai 2009/02/18
            //stringBuilder.Append(GetDB(value.Color.Code));

            stringBuilder.Append("Color_Code = ");
            stringBuilder.Append("NULL");
            stringBuilder.Append(", ");

            stringBuilder.Append("Body_Cost = ");
            stringBuilder.Append(GetDB(value.BodyCost));
            stringBuilder.Append(", ");

            stringBuilder.Append("Modify_Cost = ");
            stringBuilder.Append(GetDB(value.ModifyCost));
            stringBuilder.Append(", ");

            stringBuilder.Append("Percent_Residual = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.PercentResidual));
            stringBuilder.Append(", ");

            stringBuilder.Append("Residual_Value = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.ResidualValue));
            stringBuilder.Append(", ");

            stringBuilder.Append("Lease_Term = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.LeaseTerm));
            stringBuilder.Append(", ");

            stringBuilder.Append("Rate_Of_Return_Estimate = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.RateOfReturnEstimate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Rate_Of_Return_Actual = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.RateOfReturnActual));
            stringBuilder.Append(", ");

            stringBuilder.Append("Interest_Rate = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.InterestRate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Depreciation = ");
            stringBuilder.Append(GetDB(value.Depreciation));
            stringBuilder.Append(", ");

            stringBuilder.Append("Capital_Insurance = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.CapitalInsurance));
            stringBuilder.Append(", ");

            stringBuilder.Append("Insurance_Premium = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.InsurancePremium));
            stringBuilder.Append(", ");

            stringBuilder.Append("Register = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.TaxRegister));
            stringBuilder.Append(", ");

            stringBuilder.Append("Maintenance = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.Maintenance));
            stringBuilder.Append(", ");

            stringBuilder.Append("Less_PV = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.PV));
            stringBuilder.Append(", ");

            stringBuilder.Append("PMT = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.PMT));
            stringBuilder.Append(", ");

            stringBuilder.Append("Monthly_Charge_Actual = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.MonthlyChargeActual));
            stringBuilder.Append(", ");

            stringBuilder.Append("Monthly_Charge = ");
            stringBuilder.Append(GetDB(value.LeasingCalculation.MonthlyCharge));
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
            return " DELETE FROM Vehicle_Calculation ";
        }

        private string getSQLKeyCondition(VehicleCalculation value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value.CalculationNo))
            {
                stringBuilder.Append(" AND (Calculation_No = ");
                stringBuilder.Append(GetDB(value.CalculationNo.ToString()));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getSQLKeyUpdateCondition(VehicleCalculation value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value.CalculationNo))
            {
                stringBuilder.Append(" WHERE (Calculation_No = ");
                stringBuilder.Append(GetDB(value.CalculationNo.ToString()));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        #endregion

        /// <summary>
        /// Function    : Fill detail of value to new object calculation
        /// Author      : Thawatchai B.
        /// Create Date : 10/10/08
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="dataReader"></param>
        private void FillDetail(VehicleCalculation entity, SqlDataReader dataReader)
        {
            entity.Customer = new Customer();
            entity.Model = new Model();
            entity.Model.ABrand = new Brand();
            entity.LeasingCalculation = new VehicleLeasingCalculation();
            entity.Quotation = new VehicleQuotation();
         


            entity.Customer.Code = (string)dataReader["Customer_Code"];
            entity.Model.ABrand.Code = (string)dataReader["Brand_Code"];
            entity.Model.Code = (string)dataReader["Model_Code"];

            //Delete color from calculation : woranai 2009/02/18
            //entity.Color.Code = (string)dataReader["Color_Code"];

            if (dataReader.IsDBNull(3))
            {
                entity.Quotation.QuotationNo = null;
            }
            else
            {
                entity.Quotation.QuotationNo = new DocumentNo((string)(dataReader["Quotation_No"]));
            }


            if (dataReader.IsDBNull(28))
            {
                entity.LeasingNo = null;
            }
            else
            {
                entity.LeasingNo = (string)(dataReader["Leasing_No"]);
            }



            entity.IssueDate = dataReader.GetDateTime(7);
            entity.CalculationNo = dataReader.GetGuid(1);
            entity.BodyCost = (decimal)dataReader["Body_Cost"];
            entity.ModifyCost = (decimal)dataReader["Modify_Cost"];
            entity.LeasingCalculation.PercentResidual = (decimal)dataReader["Percent_Residual"];
            entity.LeasingCalculation.ResidualValue = (decimal)dataReader["Residual_Value"];
            entity.LeasingCalculation.LeaseTerm = int.Parse(dataReader["Lease_Term"].ToString());
            entity.LeasingCalculation.RateOfReturnEstimate = (decimal)dataReader["Rate_Of_Return_Estimate"];
            entity.LeasingCalculation.RateOfReturnActual = (decimal)dataReader["Rate_Of_Return_Actual"];
            entity.LeasingCalculation.InterestRate = (decimal)dataReader["Interest_Rate"];
            entity.Depreciation = (decimal)dataReader["Depreciation"];
            entity.LeasingCalculation.CapitalInsurance = (decimal)dataReader["Capital_Insurance"];
            entity.LeasingCalculation.InsurancePremium = (decimal)dataReader["Insurance_Premium"];
            entity.LeasingCalculation.TaxRegister = (decimal)dataReader["Register"];
            entity.LeasingCalculation.Maintenance = (decimal)dataReader["Maintenance"];
            entity.LeasingCalculation.MaintenanceActual = (decimal)dataReader["Maintenance_Spare_Car"];
            entity.LeasingCalculation.PV = (decimal)dataReader["Less_PV"];
            entity.LeasingCalculation.PMT = (decimal)dataReader["PMT"];
            entity.LeasingCalculation.MonthlyChargeActual = (decimal)dataReader["Monthly_Charge_Actual"];
            entity.LeasingCalculation.MonthlyCharge = (decimal)dataReader["Monthly_Charge"];


            if (dataReader.IsDBNull(29))
            {
                entity.DiscountAmount = 0;
                entity.DiscountTotal = 0;

            }
            else
            {
                entity.DiscountAmount = (decimal)dataReader["Discount_Amount"];
                entity.DiscountTotal = (decimal)dataReader["Discount_Total"];
            }


       


        }


        /// <summary>
        /// Function    : Fill value to new object calculation
        /// Author      : Thawatchai B.
        /// Create Date : 10/10/08
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aCompany"></param>
        /// <returns></returns>
        private VehicleCalculation Fill(SqlCommand command, Company aCompany)
        {
            VehicleCalculation entity = new VehicleCalculation();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);


            try
            {
                while (dataReader.Read())
                {
                    FillDetail(entity, dataReader);

                    using (ContractDB.CustomerDB dbCus = new ContractDB.CustomerDB())
                    {
                        entity.Customer = dbCus.GetCustomer(entity.Customer.Code, aCompany);
                    }

                    using (ModelDB dbMod = new ModelDB())
                    {
                        entity.Model = dbMod.GetModel(entity.Model.Code, entity.Model.ABrand.Code);
                    }

                    //Delete color from calculation : woranai 2009/02/18
                    //entity.Color = (Color)dbColor.GetMTB(entity.Color.Code);
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
            return entity;
        }

        /// <summary>
        /// Function    : Fill list of value to new object calculation
        /// Author      : Thawatchai B.
        /// Create Date : 10/10/08
        /// </summary>
        /// <param name="command"></param>
        /// <param name="aCompany"></param>
        /// <returns></returns>
        private List<VehicleCalculation> FillList(SqlCommand command, Company aCompany)
        {
            List<VehicleCalculation> result = new List<VehicleCalculation>();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(command);

            try
            {
                while (dataReader.Read())
                {
                    VehicleCalculation entity = new VehicleCalculation();
                    FillDetail(entity, dataReader);

                    using (ContractDB.CustomerDB dbCus = new ContractDB.CustomerDB())
                    {
                        entity.Customer = dbCus.GetCustomer(entity.Customer.Code, aCompany);
                    }

                    using (ModelDB dbMod = new ModelDB())
                    {
                        entity.Model = dbMod.GetModel(entity.Model.Code, entity.Model.ABrand.Code);
                    }

                    //Delete color from calculation : woranai 2009/02/18
                    //entity.Color = (Color)dbColor.GetMTB(entity.Color.Code);

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
        #endregion

        #region Public Method
        public List<VehicleCalculation> GetListVehicleCalculation()
        {
            List<VehicleCalculation> listCalculation = new List<VehicleCalculation>();
            return listCalculation;
        }

        public List<VehicleCalculation> GetVehicleSearchCalculation(Customer aCustomer, Brand aBrand, Model aModel, string quotationNo, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_CALCULATION);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Customer_Code", aCustomer != null ? DBValue(aCustomer.Code) : DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Brand_Code", aBrand != null ? DBValue(aBrand.Code) : DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Model_Code", aModel != null ? DBValue(aModel.Code) : DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Color_Code", DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", quotationNo));

            return FillList(command, aCompany);

        }

        public List<VehicleCalculation> GetVehicleSearchCalculationQuotation(Customer aCustomer, Brand aBrand, Model aModel, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_CALCULATION_QUOTATION);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Customer_Code", aCustomer != null ? DBValue(aCustomer.Code) : DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Brand_Code", aBrand != null ? DBValue(aBrand.Code) : DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Model_Code", aModel != null ? DBValue(aModel.Code) : DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Color_Code", DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", DBNull.Value));

            return FillList(command, aCompany);

        }

        public List<VehicleCalculation> GetVehicleSearchConditionByPlateNo(string plateNoPrefix, string plateNoRunning, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_CALCULATION_LIST_BY_PLATE_NO);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Plate_No_Prefix", plateNoPrefix));
            command.Parameters.Add(tableAccess.CreateParameter("@Plate_No_Running_No", plateNoRunning));

            return FillList(command, aCompany);
        }

        public VehicleCalculation GetVehicleCalculationByPlateNo(string plateNoPrefix, string plateNoRunning, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_CALCULATION_BY_PLATE_NO);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Plate_No_Prefix", plateNoPrefix));
            command.Parameters.Add(tableAccess.CreateParameter("@Plate_No_Running_No", plateNoRunning));

            return Fill(command, aCompany);
        }

        public List<VehicleCalculation> GetVehicleSearchConditionListByQuotationNo(DocumentNo documentNo, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_CALCULATION_BY_QUOTATION_NO);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", documentNo.ToString()));

            return FillList(command, aCompany);
        }

        public VehicleCalculation GetVehicleSearchConditionByQuotationNo(DocumentNo documentNo, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_CALCULATION_BY_QUOTATION_NO);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", documentNo.ToString()));

            return Fill(command, aCompany);
        }

        public VehicleCalculation GetVehicleConditionByQuotationNo(DocumentNo documentNo, Customer aCustomer, Brand aBrand, Model aModel, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_CALCULATION_BY_QUOTATION_LIST);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", documentNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Customer_Code", aCustomer != null ? DBValue(aCustomer.Code) : DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Brand_Code", aBrand != null ? DBValue(aBrand.Code) : DBNull.Value));
            command.Parameters.Add(tableAccess.CreateParameter("@Model_Code", aModel != null ? DBValue(aModel.Code) : DBNull.Value));

            return Fill(command, aCompany);
        }

        public List<VehicleCalculation> GetVehicleUpdateCondition(VehicleCalculation vehicleCalculation, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_UPDATE_CALCULATION);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Calculation_No", vehicleCalculation.CalculationNo.ToString()));

            return FillList(command, aCompany);

        }

        public VehicleCalculation GetVehicleCalculationByCalculationNo(VehicleCalculation vehicleCalculation, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_SEARCH_CALCULATION_BY_CALCULATION_NO);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableAccess.CreateParameter("@Calculation_No", vehicleCalculation.CalculationNo.ToString()));

            return Fill(command, aCompany);

        }


        public bool InsertVehicleCalculation(VehicleCalculation value, Company aCompany)
        {
            if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany)) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool InsertVehicleCalculationByQuotation(VehicleCalculation value, Company aCompany)
        {
            if (tableAccess.ExecuteSQL(getSQLInsertByQuotation(value, aCompany)) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool DeleteVehicleCalculation(VehicleCalculation value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getSQLKeyCondition(value));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool UpdateVehicleCalculation(VehicleCalculation value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
            stringBuilder.Append(getSQLKeyUpdateCondition(value));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool UpdateVehicleCalculationByQuotationNo(VehicleCalculation vehicleCalculation, Company aCompany)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_UPDATE_CALCULATION_BY_QUOTATION_NO);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", vehicleCalculation.Quotation.QuotationNo.ToString()));
            //Todsporn Modified 25/2/2020 PO. Discount
            command.Parameters.Add(tableAccess.CreateParameter("@Leasing_No", vehicleCalculation.LeasingNo.ToString()));

            command.Parameters.Add(tableAccess.CreateParameter("@Calculation_No", vehicleCalculation.CalculationNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Process_User", UserProfile.UserID));

            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);
            return result;
        }

        /// <summary>
        /// Function    : Set null quotation no. when delete leasing calculation.
        /// Author      : Thawatchai B.
        /// Create date : 10/10/08
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool UpdateVehicleCalculationToNullQuotationNo(VehicleQuotation value)
        {
            SqlCommand command = tableAccess.CreateCommand(STPROC_VEH_UPDATE_CALCULATION_TONULL_QUOTATION_NO);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(tableAccess.CreateParameter("@Quotation_No", value.QuotationNo.ToString()));
            command.Parameters.Add(tableAccess.CreateParameter("@Process_User", UserProfile.UserID));

            bool result = (tableAccess.ExecuteStoredProcedure(command) < 0);
            return result;
        } 
        #endregion
    }
}