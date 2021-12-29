using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using DataAccess.CommonDB;
using DataAccess.PiDB;

using Entity.AttendanceEntities;
using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.VehicleEntities.VehicleLeasing;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using ictus.Common.Entity;

using SystemFramework.AppConfig;

namespace DataAccess.ContractDB
{
	public class ContractDB: DataAccessBase
	{
		#region Constant
		private const int CONTRACTTYPE = 0;
		private const int CONTRACT_NO = 1;
		private const int CONTRACT_DATE = 2;
		private const int KIND_OF_CONTRACT = 3;
		private const int CONTRACT_START_DATE = 4;
		private const int CONTRACT_END_DATE = 5;
		private const int CUSTOMERCODE = 6;
		private const int CUSTOMERDEPARTMENT = 7;
		private const int UNIT_HIRE = 8;
		private const int RATE_STATUS = 9;
		private const int CONTRACT_STATUS = 10;
		private const int CONTRACT_CANCEL_DATE = 11;
		private const int CONTRACT_CANCEL_REASON = 12;
		private const int REMARK = 13;
        private const int DRIVER_DEDUCT_TYPE = 14;
        private const int DEDUCT_AMOUNT_PER_DAY = 15;
		#endregion

		#region Private
		private ContractTypeDB dbContractType;
		private CustomerDepartmentDB dbCustomerDepartment;
		private ContractChargeDB dbContractCharge;

		private ContractBase objContractBase;
		private bool disposed = false;
		#endregion

        #region Constructor
        public ContractDB()
            : base()
        {
            dbContractType = new ContractTypeDB();
            dbCustomerDepartment = new CustomerDepartmentDB();
            dbContractCharge = new ContractChargeDB();
        } 
        #endregion

        #region Private Method
        #region - getSQL -
        private string getSQLSelect()
        {
            return "SELECT Contract_Type, Contract_No, Contract_Date, Kind_Of_Contract, Contract_Start_Date, Contract_End_Date, Customer_Code, Customer_Department_Code, Unit_Hire, Rate_Status, Contract_Status, Contract_Cancel_Date, Contract_Cancel_Reason, Remark, Driver_Deduct_Type, Deduct_Amount_Per_Day FROM Contract ";
        }

        /// <summary>
        /// Select for renewal notice report
        /// </summary>
        /// <returns></returns>
        private string getSQLSelectInfo()
        {
            return "SELECT Contract.Contract_Type, Contract.Contract_No, Contract.Contract_Date, Contract.Kind_Of_Contract, Contract.Contract_Start_Date, Contract.Contract_End_Date, Contract.Customer_Code, Contract.Customer_Department_Code, Contract.Unit_Hire, Contract.Rate_Status, Contract.Contract_Status, Contract.Contract_Cancel_Date, Contract.Contract_Cancel_Reason, Contract.Remark, Contract.Driver_Deduct_Type, Contract.Deduct_Amount_Per_Day, Vehicle.Vehicle_No FROM Contract,Contract_Charge,Vehicle,Customer,Vehicle_Contract,Model ";
        }

        private string getSQLInsert(ContractBase value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Contract (Company_Code,   Contract_No, Contract_Date, Contract_Type, Kind_Of_Contract, Contract_Start_Date, Contract_End_Date, Customer_Code, Customer_Department_Code, Unit_Hire, Rate_Status, Contract_Status, Contract_Cancel_Date, Contract_Cancel_Reason, Remark, Driver_Deduct_Type, Deduct_Amount_Per_Day, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code			
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Contract_No
            stringBuilder.Append(GetDB(value.ContractNo.ToString()));
            stringBuilder.Append(", ");

            //Contract_Date
            stringBuilder.Append(GetDB(value.ContractDate.Date));
            stringBuilder.Append(", ");

            //Contract_Type
            stringBuilder.Append(GetDB(value.AContractType));
            stringBuilder.Append(", ");

            //Kind_Of_Contract
            stringBuilder.Append(GetDB(value.AKindOfContract));
            stringBuilder.Append(", ");

            //Contract_Start_Date
            stringBuilder.Append(GetDB(value.APeriod.From));
            stringBuilder.Append(", ");

            //Contract_End_Date
            stringBuilder.Append(GetDB(value.APeriod.To));
            stringBuilder.Append(", ");

            //Customer_Code
            stringBuilder.Append(GetDB(value.ACustomerDepartment.ACustomer.Code));
            stringBuilder.Append(", ");

            //Customer_Department_Code
            stringBuilder.Append(GetDB(value.ACustomerDepartment.Code));
            stringBuilder.Append(", ");

            //Unit_Hire
            stringBuilder.Append(GetDB(value.UnitHire));
            stringBuilder.Append(", ");

            //Rate_Status
            stringBuilder.Append(GetDB(value.RateStatus));
            stringBuilder.Append(", ");

            //Contract_Status
            stringBuilder.Append(GetDB(value.AContractStatus));
            stringBuilder.Append(", ");

            //Contract_Cancel_Date
            stringBuilder.Append(GetDB(value.CancelDate));
            stringBuilder.Append(", ");

            //Contract_Cancel_Reason
            stringBuilder.Append(GetDB(value.ACancelReason.Name));
            stringBuilder.Append(", ");

            //Remark
            stringBuilder.Append(GetDB(value.Remark));
            stringBuilder.Append(", ");

            //Driver_Deduct_Type
            stringBuilder.Append(GetDB(value.DriverDeductCharge.DriverDeductStatus));
            stringBuilder.Append(", ");

            //Deduct_Amount_Per_Day
            stringBuilder.Append(GetDB(value.DriverDeductCharge.DeductAmount));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(ContractBase value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" UPDATE Contract SET ");

            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Contract_No = ");
            stringBuilder.Append(GetDB(value.ContractNo.ToString()));
            stringBuilder.Append(", ");

            stringBuilder.Append("Contract_Type = ");
            stringBuilder.Append(GetDB(value.AContractType));
            stringBuilder.Append(", ");

            stringBuilder.Append("Kind_Of_Contract = ");
            stringBuilder.Append(GetDB(value.AKindOfContract));
            stringBuilder.Append(", ");

            stringBuilder.Append("Contract_Start_Date = ");
            stringBuilder.Append(GetDB(value.APeriod.From));
            stringBuilder.Append(", ");

            stringBuilder.Append("Contract_End_Date = ");
            stringBuilder.Append(GetDB(value.APeriod.To));
            stringBuilder.Append(", ");

            stringBuilder.Append("Customer_Code = ");
            stringBuilder.Append(GetDB(value.ACustomerDepartment.ACustomer.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Customer_Department_Code = ");
            stringBuilder.Append(GetDB(value.ACustomerDepartment.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Unit_Hire = ");
            stringBuilder.Append(GetDB(value.UnitHire));
            stringBuilder.Append(", ");

            stringBuilder.Append("Rate_Status = ");
            stringBuilder.Append(GetDB(value.RateStatus));
            stringBuilder.Append(", ");

            stringBuilder.Append("Contract_Status = ");
            stringBuilder.Append(GetDB(value.AContractStatus));
            stringBuilder.Append(", ");

            stringBuilder.Append("Contract_Cancel_Date = ");
            stringBuilder.Append(GetDB(value.CancelDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Contract_Cancel_Reason = ");
            stringBuilder.Append(GetDB(value.ACancelReason.Name));
            stringBuilder.Append(", ");

            stringBuilder.Append("Remark = ");
            stringBuilder.Append(GetDB(value.Remark));
            stringBuilder.Append(", ");

            stringBuilder.Append("Driver_Deduct_Type = ");
            stringBuilder.Append(GetDB(value.DriverDeductCharge.DriverDeductStatus));
            stringBuilder.Append(", ");

            stringBuilder.Append("Deduct_Amount_Per_Day = ");
            stringBuilder.Append(GetDB(value.DriverDeductCharge.DeductAmount));
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
            return " DELETE FROM Contract ";
        }

        private string getKeyCondition(DocumentNo value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (value != null)
            {
                if (IsNotNULL(value.Year) && IsNotNULL(value.Month) && IsNotNULL(value.No))
                {
                    //D21018-BTS Contract Modification
                    string type = (value.ToString()).Substring(4,1);
                    string no = (value.ToString()).Substring(6, 7);
                    if (type == "D")
                    {
                        stringBuilder.Append(" AND (Contract_No = ");
                        stringBuilder.Append(GetDB(value.ToString()));
                        stringBuilder.Append(" OR Contract_No = ");
                        stringBuilder.Append(string.Format("'PTB-C-{0}'",no));
                        stringBuilder.Append(")");
                    }
                    else 
                    {
                        stringBuilder.Append(" AND (Contract_No = ");
                        stringBuilder.Append(GetDB(value.ToString()));
                        stringBuilder.Append(")");
                    }                    
                }
                else
                {
                    if (IsNotNULL(value.Year))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Contract_No, 7, 2) = ");
                        stringBuilder.Append(GetDB(value.Year));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(value.Month))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Contract_No, 9, 2) = ");
                        stringBuilder.Append(GetDB(value.Month));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(value.No))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Contract_No, 11, 3) = ");
                        stringBuilder.Append(GetDB(value.No));
                        stringBuilder.Append(")");
                    }
                }
            }
            return stringBuilder.ToString();
        }

        private string getKeyCondition(ContractConditionList value)
        {
            if (value.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder(" AND ( ");
                for (int i = 0; i < value.Count; i++)
                {
                    if (i != 0)
                    {
                        stringBuilder.Append(" OR ");
                    }
                    stringBuilder.Append("(Contract_Status = ");
                    stringBuilder.Append(GetDB(value[i].ContractStatus));
                    stringBuilder.Append(")");
                }
                stringBuilder.Append(")");
                return stringBuilder.ToString();
            }
            else
            {
                return "";
            }
        }

        private string getKeyCondition(ContractBase value)
        {
            StringBuilder stringBuilder = new StringBuilder(getKeyCondition(value.ContractNo));

            if (value.ACustomerDepartment != null && value.ACustomerDepartment.ACustomer != null && IsNotNULL(value.ACustomerDepartment.ACustomer.Code))
            {
                stringBuilder.Append(" AND (Customer_Code = ");
                stringBuilder.Append(GetDB(value.ACustomerDepartment.ACustomer.Code));
                stringBuilder.Append(")");
            }

            if (value.AContractType != null && IsNotNULL(value.AContractType))
            {
                stringBuilder.Append(" AND (Contract_Type = ");
                stringBuilder.Append(GetDB(value.AContractType));
                stringBuilder.Append(")");
            }

            if (value.AContractStatus != null && IsNotNULL(value.AContractStatus))
            {
                stringBuilder.Append(" AND (Contract_Status = ");
                stringBuilder.Append(GetDB(value.AContractStatus));
                stringBuilder.Append(")");
            }

            //D21018
            if (value.AContractTypeAbbreviation != null && IsNotNULL(value.AContractTypeAbbreviation))
            {
                stringBuilder.Append(" AND (SUBSTRING(Contract_No, 5, 1) = ");
                stringBuilder.Append(GetDB(value.AContractTypeAbbreviation));
                stringBuilder.Append(")");
            }

            return stringBuilder.ToString();
        }

        private string getEntityCondition(ContractBase value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (value.APeriod != null)
            {
                if (IsNotNULL(value.APeriod.From))
                {
                    stringBuilder.Append(" AND (Contract_Start_Date = ");
                    stringBuilder.Append(GetDB(value.APeriod.From));
                    stringBuilder.Append(")");
                }
                if (IsNotNULL(value.APeriod.To))
                {
                    stringBuilder.Append(" AND (Contract_End_Date = ");
                    stringBuilder.Append(GetDB(value.APeriod.To));
                    stringBuilder.Append(")");
                }
            }
            return stringBuilder.ToString();
        }

        private string getExcludeKeyCondition(ContractBase value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (value.ContractNo != null)
            {
                if (IsNotNULL(value.ContractNo.Year) && IsNotNULL(value.ContractNo.Month) && IsNotNULL(value.ContractNo.No))
                {
                    stringBuilder.Append(" AND NOT(Contract_No = ");
                    stringBuilder.Append(GetDB(value.ContractNo.ToString()));
                    stringBuilder.Append(")");
                }
                else
                {
                    if (IsNotNULL(value.ContractNo.Year))
                    {
                        stringBuilder.Append(" AND NOT(SUBSTRING(Contract_No, 7, 2) = ");
                        stringBuilder.Append(GetDB(value.ContractNo.Year));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(value.ContractNo.Month))
                    {
                        stringBuilder.Append(" AND NOT(SUBSTRING(Contract_No, 9, 2) = ");
                        stringBuilder.Append(GetDB(value.ContractNo.Month));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(value.ContractNo.No))
                    {
                        stringBuilder.Append(" AND NOT(SUBSTRING(Contract_No, 11, 3) = ");
                        stringBuilder.Append(GetDB(value.ContractNo.No));
                        stringBuilder.Append(")");
                    }
                }
            }

            if (value.ACustomerDepartment != null && value.ACustomerDepartment.ACustomer != null && IsNotNULL(value.ACustomerDepartment.ACustomer.Code))
            {
                stringBuilder.Append(" AND NOT(Customer_Code = ");
                stringBuilder.Append(GetDB(value.ACustomerDepartment.ACustomer.Code));
                stringBuilder.Append(")");
            }

            if (IsNotNULL(value.AContractType))
            {
                stringBuilder.Append(" AND NOT(Contract_Type = ");
                stringBuilder.Append(GetDB(value.AContractType));
                stringBuilder.Append(")");
            }

            if (IsNotNULL(value.AContractStatus) && IsNotNULL(value.AContractStatus))
            {
                stringBuilder.Append(" AND NOT(Contract_Status = ");
                stringBuilder.Append(GetDB(value.AContractStatus));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getExcludeVehicleContractCondition(ContractBase value)
        {
            StringBuilder stringBuilder = new StringBuilder(getKeyCondition(value.ContractNo));

            if (value.ACustomerDepartment != null && value.ACustomerDepartment.ACustomer != null && IsNotNULL(value.ACustomerDepartment.ACustomer.Code))
            {
                stringBuilder.Append(" AND (Customer_Code = ");
                stringBuilder.Append(GetDB(value.ACustomerDepartment.ACustomer.Code));
                stringBuilder.Append(")");
            }

            if (value.AContractType != null && IsNotNULL(value.AContractType))
            {
                stringBuilder.Append(" AND (Contract_Type = ");
                stringBuilder.Append(GetDB(value.AContractType));
                stringBuilder.Append(")");
            }

            if (value.AContractStatus != null && IsNotNULL(value.AContractStatus))
            {
                stringBuilder.Append(" AND NOT(Contract_Status = ");
                stringBuilder.Append(GetDB(value.AContractStatus));
                stringBuilder.Append(")");
            }

            //D21018-BTS Contract Modification
            if (value.AContractTypeAbbreviation != null && IsNotNULL(value.AContractTypeAbbreviation))
            {
                stringBuilder.Append(" AND (SUBSTRING(Contract_No, 5, 1) = ");
                stringBuilder.Append(GetDB(value.AContractTypeAbbreviation));
                stringBuilder.Append(")");
            }

            return stringBuilder.ToString();
        }

        private string getAvailableCondition()
        {
            return " AND (Contract.Contract_No NOT IN (SELECT VD_Contract_Match.Service_Staff_Contract_No FROM VD_Contract_Match)) AND  (Contract.Contract_No NOT IN (SELECT Service_Staff_Contract.Contract_No FROM Service_Staff_Contract)) ";
        }

        private string getCurrentVehicleContract(Vehicle value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (IsNotNULL(value.VehicleNo))
            {
                stringBuilder.Append(" AND (Contract_End_Date >= ");
                stringBuilder.Append(GetDB(DateTime.Today));
                stringBuilder.Append(" ) AND (Contract_No IN (SELECT Contract_No FROM Vehicle_Contract WHERE Vehicle_No = ");
                stringBuilder.Append(GetDB(value.VehicleNo));
                stringBuilder.Append(" )) AND (Contract_End_Date = (SELECT MAX(Contract.Contract_End_Date) FROM Contract INNER JOIN Vehicle_Contract ON Contract.Company_Code = Vehicle_Contract.Company_Code AND Contract.Contract_No = Vehicle_Contract.Contract_No WHERE (Contract.Contract_Status = '2') AND (Contract.Contract_No <> 'PTB-C-0000000') AND (Vehicle_Contract.Vehicle_No = ");
                stringBuilder.Append(GetDB(value.VehicleNo));
                stringBuilder.Append(" ))) ");
            }
            return stringBuilder.ToString();
        }

        private string getOrderby()
        {
            return " ORDER BY Contract_No ";
        }

        /// <summary>
        /// Order by for Renewal notice report
        /// </summary>
        /// <returns></returns>
        private string getOrderbyInfo()
        {
            return " ORDER BY Contract.Contract_No ";
        }

        private string getContractExpireByYearMonth(ContractBase condition)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (condition.AContractType != null && IsNotNULL(condition.AContractType))
            {
                stringBuilder.Append(" AND (Contract_Type = ");
                stringBuilder.Append(GetDB(condition.AContractType));
                stringBuilder.Append(")");
            }

            if (condition.APeriod != null)
            {
                if (IsNotNULL(condition.APeriod.To))
                {
                    stringBuilder.Append(" AND (MONTH(Contract_End_Date) = ");
                    stringBuilder.Append(GetDB(condition.APeriod.To.Month));
                    stringBuilder.Append(") AND (YEAR(Contract_End_Date) = ");
                    stringBuilder.Append(GetDB(condition.APeriod.To.Year));
                    stringBuilder.Append(")");
                }
            }
            return stringBuilder.ToString();
        }

        private string getContractExpireByYearMonthExistsPurchasingContract(ContractBase condition)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("WHERE Contract.Contract_No = Vehicle_Contract.Contract_No and Contract.Contract_No = Contract_Charge.Contract_No and Contract.Customer_Code = Customer.Customer_Code and Vehicle_Contract.Vehicle_No = Vehicle.Vehicle_No	and vehicle.model_code = model.model_code and vehicle.brand_code = model.brand_code");
            stringBuilder.Append(" and Contract.Contract_Status = '2'");
            if (condition.AContractType != null && IsNotNULL(condition.AContractType))
            {
                stringBuilder.Append(" AND (Contract.Contract_Type = ");
                stringBuilder.Append(GetDB(condition.AContractType));
                stringBuilder.Append(")");
            }

            if (condition.AKindOfContract != null && IsNotNULL(condition.AKindOfContract))
            {
                stringBuilder.Append(" AND (Contract.Kind_Of_Contract = ");
                stringBuilder.Append(GetDB(condition.AKindOfContract));
                stringBuilder.Append(")");
            }

            if (condition.APeriod != null)
            {
                //Add by Aof 02/12/08
                if (IsNotNULL(condition.APeriod.From))
                {
                    stringBuilder.Append(" AND (Contract.Contract_End_Date >= ");
                    stringBuilder.Append(GetDB(condition.APeriod.From.Date));
                    stringBuilder.Append(")");
                }
                //end add by aof
                if (IsNotNULL(condition.APeriod.To))
                {
                    stringBuilder.Append(" AND (Contract.Contract_End_Date <= ");
                    stringBuilder.Append(GetDB(condition.APeriod.To.Date));
                    stringBuilder.Append(")");
                }
            }
            return stringBuilder.ToString();
        }

        private string getContractVehilcePurchasing()
        {
            return " AND EXISTS (SELECT Vehicle_Purchasing_Contract.Contract_No FROM Vehicle_Purchasing_Contract WHERE Contract.Contract_No = Vehicle_Purchasing_Contract.Contract_No) ";
        }

        private void AddKeyParameters(SqlParameterCollection parameters, DocumentNo contractNo)
        {
            parameters.Add(this.tableAccess.CreateParameter("@Contract_No", contractNo.ToString()));
        }

        #endregion

        #region - Fill -
        private void fillContract(ref ContractBase value, Company aCompany, SqlDataReader dataReader)
        {
            string contractType = (string)dataReader[CONTRACTTYPE];
            switch (contractType)
            {
                case ContractType.CONTRACT_TYPE_VEHICLE:
                    {
                        VehicleContractDB dbVehicleContract = new VehicleContractDB();
                        value = new VehicleContract(aCompany);
                        value.ContractNo = new DocumentNo((string)dataReader[CONTRACT_NO]);
                        value.AContractType = (ContractType)dbContractType.GetDBDualField(contractType, aCompany);
                        dbVehicleContract.FillVehicleContract((VehicleContract)value);
                        break;
                    }
                case ContractType.CONTRACT_TYPE_DRIVER:
                    {
                        ServiceStaffContractDB dbServiceStaffContract = new ServiceStaffContractDB();
                        value = new DriverContract(aCompany);
                        value.ContractNo = new DocumentNo((string)dataReader[CONTRACT_NO]);
                        value.AContractType = (ContractType)dbContractType.GetDBDualField(contractType, aCompany);
                        dbServiceStaffContract.FillServiceStaffContract((ServiceStaffContract)value);
                        break;
                    }
                default:
                    {
                        ServiceStaffContractDB dbServiceStaffContract = new ServiceStaffContractDB();
                        value = new ServiceStaffContract(aCompany);
                        value.ContractNo = new DocumentNo((string)dataReader[CONTRACT_NO]);
                        value.AContractType = (ContractType)dbContractType.GetDBDualField(contractType, aCompany);
                        dbServiceStaffContract.FillServiceStaffContract((ServiceStaffContract)value);
                        break;
                    }
            }
            value.ContractDate = dataReader.GetDateTime(CONTRACT_DATE);
            value.AKindOfContract = CTFunction.GetKindOfContractType((string)dataReader[KIND_OF_CONTRACT]);
            value.APeriod.From = dataReader.GetDateTime(CONTRACT_START_DATE);
            value.APeriod.To = dataReader.GetDateTime(CONTRACT_END_DATE);
            value.ACustomerDepartment = dbCustomerDepartment.GetDBCustomerDepartment((string)dataReader[CUSTOMERDEPARTMENT], (string)dataReader[CUSTOMERCODE], aCompany);
            value.ACustomer = value.ACustomerDepartment.ACustomer;
            value.UnitHire = dataReader.GetByte(UNIT_HIRE);
            value.RateStatus = CTFunction.GetRateStatusType((string)dataReader[RATE_STATUS]);
            value.AContractStatus = CTFunction.GetContractstatusType((string)dataReader[CONTRACT_STATUS]);

            if (dataReader.IsDBNull(CONTRACT_CANCEL_DATE))
            {
                value.CancelDate = NullConstant.DATETIME;
            }
            else
            {
                value.CancelDate = dataReader.GetDateTime(CONTRACT_CANCEL_DATE);
            }
            value.ACancelReason.Name = (string)dataReader[CONTRACT_CANCEL_REASON];
            value.Remark = (string)dataReader[REMARK];
            value.DriverDeductCharge.DriverDeductStatus = CTFunction.GetDriverDeductStatusType((string)dataReader[DRIVER_DEDUCT_TYPE]);
            value.DriverDeductCharge.DeductAmount = dataReader.GetInt16(DEDUCT_AMOUNT_PER_DAY);

            value.AContractChargeList.AContract = value;
            ContractChargeList contractChargeList = value.AContractChargeList;
            dbContractCharge.FillContractChargeList(ref contractChargeList);
            value.AContractChargeList = contractChargeList;
            contractChargeList = null;
        }

        private bool fillContractList(ref ContractList value, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                while (dataReader.Read())
                {
                    if ((string)dataReader[CONTRACT_NO] != "PTB-C-0000000")
                    {
                        result = true;
                        fillContract(ref objContractBase, value.Company, dataReader);
                        value.Add(objContractBase);
                    }
                }
            }
            catch (IndexOutOfRangeException ein)
            {
                throw ein;
            }
            finally
            {
                tableAccess.CloseDataReader();
            }
            return result;
        }

        private bool fillContract(ref ContractBase value, Company aCompany, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    if ((string)dataReader[CONTRACT_NO] != "PTB-C-0000000")
                    {
                        fillContract(ref value, aCompany, dataReader);
                        result = true;
                    }
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

        private bool fillAllContract(ref ContractBase value, Company aCompany, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillContract(ref value, aCompany, dataReader);
                    result = true;
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }
        #endregion
        
        #endregion

        #region Public Method
        public ContractBase GetContract(DocumentNo contractNo, Company aCompany)
        {
            if (IsNotNULL(contractNo.No.Trim()))
            {
                StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
                stringBuilder.Append(getBaseCondition(aCompany));
                stringBuilder.Append(getKeyCondition(contractNo));

                if (fillContract(ref objContractBase, aCompany, stringBuilder.ToString()))
                {
                    return objContractBase;
                }
                else
                {
                    objContractBase = null;
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public ContractBase GetAllContract(DocumentNo contractNo, Company aCompany)
        {
            if (IsNotNULL(contractNo.No.Trim()))
            {
                StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
                stringBuilder.Append(getBaseCondition(aCompany));
                stringBuilder.Append(getKeyCondition(contractNo));

                if (fillAllContract(ref objContractBase, aCompany, stringBuilder.ToString()))
                {
                    return objContractBase;
                }
                else
                {
                    objContractBase = null;
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool FillContract(ContractBase value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value.ContractNo));

            return fillContract(ref value, aCompany, stringBuilder.ToString());
        }

        public bool FillContractList(ref ContractList aContractList)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aContractList.Company));
            stringBuilder.Append(getOrderby());

            return fillContractList(ref aContractList, stringBuilder.ToString());
        }

        public bool FillContractList(ref ContractList aContractList, ContractBase condition)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aContractList.Company));
            if (condition != null)
            {
                stringBuilder.Append(getKeyCondition(condition));
                stringBuilder.Append(getEntityCondition(condition));
            }
            stringBuilder.Append(getOrderby());

            return fillContractList(ref aContractList, stringBuilder.ToString());
        }

        public bool FillContractList(ref ContractList aContractList, ContractBase condition, ContractConditionList conditionList)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aContractList.Company));
            stringBuilder.Append(getKeyCondition(condition));
            stringBuilder.Append(getKeyCondition(conditionList));
            stringBuilder.Append(getOrderby());

            return fillContractList(ref aContractList, stringBuilder.ToString());
        }

        public bool FillExcludeContractList(ref ContractList aContractList, ContractBase aContractBase)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aContractList.Company));
            stringBuilder.Append(getExcludeKeyCondition(aContractBase));

            return fillContractList(ref aContractList, stringBuilder.ToString());
        }

        public bool FillExcludeVehicleContractList(ref ContractList aContractList, ContractBase aContractBase)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aContractList.Company));
            stringBuilder.Append(getExcludeVehicleContractCondition(aContractBase));

            return fillContractList(ref aContractList, stringBuilder.ToString());
        }

        public bool FillAvailableContractList(ref ContractList aContractList, ContractBase condition)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aContractList.Company));
            if (condition != null)
            {
                stringBuilder.Append(getKeyCondition(condition));
                stringBuilder.Append(getEntityCondition(condition));
            }
            stringBuilder.Append(getAvailableCondition());
            stringBuilder.Append(getOrderby());

            return fillContractList(ref aContractList, stringBuilder.ToString());
        }

        public bool FillCurrentVehicleContract(ref ContractBase value, Vehicle aVehicle, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getCurrentVehicleContract(aVehicle));
            stringBuilder.Append(getOrderby());

            return fillContract(ref value, aCompany, stringBuilder.ToString());
        }

        public bool FillContractForDaily(ContractList contractList, DateTime forDate, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(" AND (Contract_Status = '2') AND (Contract_End_Date < ");
            stringBuilder.Append(GetDB(forDate));
            stringBuilder.Append(")");
            stringBuilder.Append(getOrderby());

            return fillContractList(ref contractList, stringBuilder.ToString());
        }

        public bool InsertContract(ContractBase value, Company aCompany)
        {
            return (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany)) > 0);
        }

        public bool UpdateContract(ContractBase value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value.ContractNo));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteContract(ContractBase value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value.ContractNo));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteContractByPurchasing(DocumentNo contractNo)
        {
            SqlCommand cmd = this.tableAccess.CreateCommand("SDeleteContractByPurchasing");
            cmd.CommandType = CommandType.StoredProcedure;
            AddKeyParameters(cmd.Parameters, contractNo);

            bool result = (tableAccess.ExecuteStoredProcedure(cmd) < 0);
            return result;
        }

        public bool DeleteContractChargeByPurchasing(DocumentNo contractNo)
        {
            SqlCommand cmd = this.tableAccess.CreateCommand("SDeleteContractChargeByPurchasing");
            cmd.CommandType = CommandType.StoredProcedure;
            AddKeyParameters(cmd.Parameters, contractNo);

            bool result = (tableAccess.ExecuteStoredProcedure(cmd) < 0);
            return result;
        }
        

        /// <summary>
        /// To select data don't have main and spare staff assignment between period date
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <param name="timePeriod"></param>
        /// <param name="aCompany"></param>
        /// <returns></returns>
        public ContractBase GetContractStaffSpareByPeriod(string employeeNo, TimePeriod timePeriod,Company aCompany)
        {
            SqlCommand command = this.tableAccess.CreateCommand("SSelectContractStaffSpareByPeriod");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(this.tableAccess.CreateParameter("@Company_Code", aCompany.CompanyCode));
            command.Parameters.Add(this.tableAccess.CreateParameter("@Employee_No", employeeNo));
            command.Parameters.Add(this.tableAccess.CreateParameter("@FromDate", timePeriod.From));
            command.Parameters.Add(this.tableAccess.CreateParameter("@ToDate", timePeriod.To));

            SqlDataReader reader = this.tableAccess.ExecuteDataReader(command);
            if (reader.Read())
                this.fillContract(ref this.objContractBase, aCompany, reader);
            else
                this.objContractBase = null;

            return this.objContractBase;
        }

        /// <summary>
        /// To select data don't have main and spare staff assignment between period date for assign new main staff
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <param name="timePeriod"></param>
        /// <param name="aCompany"></param>
        /// <returns></returns>
        public ContractBase GetContractStaffMainPeriod(string employeeNo, TimePeriod timePeriod, Company aCompany)
        {
            SqlCommand command = this.tableAccess.CreateCommand("SSelectContractStaffMainByPeriod");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(this.tableAccess.CreateParameter("@Company_Code", aCompany.CompanyCode));
            command.Parameters.Add(this.tableAccess.CreateParameter("@Employee_No", employeeNo));
            command.Parameters.Add(this.tableAccess.CreateParameter("@FromDate", timePeriod.From));
            command.Parameters.Add(this.tableAccess.CreateParameter("@ToDate", timePeriod.To));

            SqlDataReader reader = this.tableAccess.ExecuteDataReader(command);
            if (reader.Read())
                this.fillContract(ref this.objContractBase, aCompany, reader);
            else
                this.objContractBase = null;

            return this.objContractBase;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractList"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public bool FillContractExpireByYearMonth(ContractList contractList, ContractBase condition)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(contractList.Company));
            if (condition != null)
            {
                stringBuilder.Append(getContractExpireByYearMonth(condition));
            }
            stringBuilder.Append(getOrderby());

            return fillContractList(ref contractList, stringBuilder.ToString());
        
        }

        public bool FillContractExpireByYearMonthExistsPurchasing(ContractList contractList, ContractBase condition)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectInfo());
            //stringBuilder.Append(getBaseCondition(contractList.Company));
            if (condition != null)
            {
                stringBuilder.Append(getContractExpireByYearMonthExistsPurchasingContract(condition));
            }
            stringBuilder.Append(getOrderbyInfo());

            return fillContractList(ref contractList, stringBuilder.ToString());

        }

        /// <summary>
        /// Fill vehicle contract purchasing
        /// </summary>
        /// <param name="contractList"></param>
        /// <param name="condition"></param>
        /// <returns>bool</returns>
        public bool FillContractVehiclePurchasing(ContractList contractList, ContractBase condition)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(contractList.Company));
            stringBuilder.Append(getKeyCondition(condition));
            stringBuilder.Append(getContractVehilcePurchasing());

            return fillContractList(ref contractList, stringBuilder.ToString());
        }
        #endregion

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						dbContractType.Dispose();
						dbCustomerDepartment.Dispose();
					
						dbContractType = null;
						dbCustomerDepartment = null;
						objContractBase = null;
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
