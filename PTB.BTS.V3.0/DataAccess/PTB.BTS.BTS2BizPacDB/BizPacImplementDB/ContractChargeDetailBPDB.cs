using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using DataAccess.CommonDB;
using DataAccess.PiDB;

using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.VehicleEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using ictus.Common.Entity.Time;
using ictus.Common.Entity;

using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacEntity;
using DataAccess.ContractDB;

namespace PTB.BTS.BTS2BizPacDB.BizPacImplementDB
{
    public class ContractChargeDetailBPDB : DataAccessBase, IBizPacConnectDB
    {
        #region - Constant -
        private const int CONTRACT_TYPE = 0;
        private const int CONTRACT_NO = 1;
        private const int CONTRACT_DATE = 2;
        private const int KIND_OF_CONTRACT = 3;
        private const int CONTRACT_START_DATE = 4;
        private const int CONTRACT_END_DATE = 5;
        private const int CUSTOMER_CODE = 6;
        private const int CUSTOMER_DEPARTMENT = 7;
        private const int UNIT_HIRE = 8;
        private const int RATE_STATUS = 9;
        private const int CONTRACT_STATUS = 10;
        private const int CONTRACT_CANCEL_DATE = 11;
        private const int CONTRACT_CANCEL_REASON = 12;
        private const int REMARK = 13;
        private const int FOR_YEAR = 14;
        private const int FOR_MONTH = 15;
        private const int CHARGE_AMOUNT = 16;
        private const int BIZPAC_REFERENCE_NO = 17;
        private const int BIZPAC_CONNECTION_DATE = 18;

        private CONTRACTTYPEBP typeBP;
        public enum CONTRACTTYPEBP
        {
            VEHICLE,
            DRIVER,
            SERVICESTAFF
        }
        #endregion

        #region - Private -
        private ContractTypeDB dbContractType;
        private CustomerDepartmentDB dbCustomerDepartment;
        private ContractChargeDB dbContractCharge;
        #endregion

        //============================== Constructor ==============================
        public ContractChargeDetailBPDB(CONTRACTTYPEBP value) : base()
        {
            dbContractType = new ContractTypeDB();
            dbCustomerDepartment = new CustomerDepartmentDB();
            dbContractCharge = new ContractChargeDB();
            typeBP = value;
        }

        //============================== Private method==============================
        private void fillContractChargeDetailConnectBizPac(ContractBase objBP, Company company, SqlDataReader dataReader)
        {
            string contractType = (string)dataReader[CONTRACT_TYPE];
            switch (contractType)
            {
                case ContractType.CONTRACT_TYPE_VEHICLE:
                    {
                        VehicleContractDB dbVehicleContract = new VehicleContractDB();
                        objBP.ContractNo = new DocumentNo((string)dataReader[CONTRACT_NO]);
                        objBP.AContractType = (ContractType)dbContractType.GetDBDualField(contractType, company);

                        dbVehicleContract.FillVehicleContract((VehicleContract)objBP);
                        fillContractChargeDetailConnectBizPac((VehicleContractCharge)objBP, dataReader);
                        break;
                    }
                case ContractType.CONTRACT_TYPE_DRIVER:
                    {
                        ServiceStaffContractDB dbServiceStaffContract = new ServiceStaffContractDB();
                        objBP.ContractNo = new DocumentNo((string)dataReader[CONTRACT_NO]);
                        objBP.AContractType = (ContractType)dbContractType.GetDBDualField(contractType, company);

                        dbServiceStaffContract.FillServiceStaffContract((ServiceStaffContract)objBP);
                        fillContractChargeDetailConnectBizPac((DriverContractCharge)objBP, dataReader);
                        break;
                    }
                default:
                    {
                        ServiceStaffContractDB dbServiceStaffContract = new ServiceStaffContractDB();
                        objBP.ContractNo = new DocumentNo((string)dataReader[CONTRACT_NO]);
                        objBP.AContractType = (ContractType)dbContractType.GetDBDualField(contractType, company);

                        dbServiceStaffContract.FillServiceStaffContract((ServiceStaffContract)objBP);
                        fillContractChargeDetailConnectBizPac((ServiceStaffContractCharge)objBP, dataReader);
                        break;
                    }
            }
            objBP.ContractDate = dataReader.GetDateTime(CONTRACT_DATE);
            objBP.AKindOfContract = CTFunction.GetKindOfContractType((string)dataReader[KIND_OF_CONTRACT]);
            objBP.APeriod.From = dataReader.GetDateTime(CONTRACT_START_DATE);
            objBP.APeriod.To = dataReader.GetDateTime(CONTRACT_END_DATE);
            objBP.ACustomerDepartment = dbCustomerDepartment.GetDBCustomerDepartment((string)dataReader[CUSTOMER_DEPARTMENT], (string)dataReader[CUSTOMER_CODE], company);
            objBP.ACustomer = objBP.ACustomerDepartment.ACustomer;
            objBP.UnitHire = dataReader.GetByte(UNIT_HIRE);
            objBP.RateStatus = CTFunction.GetRateStatusType((string)dataReader[RATE_STATUS]);
            objBP.AContractStatus = CTFunction.GetContractstatusType((string)dataReader[CONTRACT_STATUS]);

            if (dataReader.IsDBNull(CONTRACT_CANCEL_DATE))
            {
                objBP.CancelDate = NullConstant.DATETIME;
            }
            else
            {
                objBP.CancelDate = dataReader.GetDateTime(CONTRACT_CANCEL_DATE);
            }
            objBP.ACancelReason.Name = (string)dataReader[CONTRACT_CANCEL_REASON];
            objBP.Remark = (string)dataReader[REMARK];            
        }

        private void fillContractChargeDetailConnectBizPac(IContractChargeDetail objBP, SqlDataReader dataReader)
        {
            objBP.YearMonth = new YearMonth(dataReader.GetInt16(FOR_YEAR), dataReader.GetByte(FOR_MONTH));
            objBP.ChargeAmount = dataReader.GetDecimal(CHARGE_AMOUNT);
        }

        private void fillVehicleContractCharge(VehicleContractChargeBP value, DocumentNo contractNo, Company company)
        {
            value.ContractCharge = dbContractCharge.GetContractCharge(contractNo, company);
        }

        private void fillDriverContractCharge(DriverContractChargeBP value, DocumentNo contractNo, Company company)
        {
            value.ContractCharge = dbContractCharge.GetContractChargeInPeriod(contractNo, value.YearMonth, company);
        }

        //============================== Private method==============================
        private string getConditionChargeBP(IContractChargeDetail value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (IsNotNULL(value.YearMonth.Year))
            {
                stringBuilder.Append(" AND (Contract_Charge_Detail.For_Year = ");
                stringBuilder.Append(GetDB(value.YearMonth.Year));
                stringBuilder.Append(")");
            }
            if (IsNotNULL(value.YearMonth.Month))
            {
                stringBuilder.Append(" AND (Contract_Charge_Detail.For_Month = ");
                stringBuilder.Append(GetDB(value.YearMonth.Month));
                stringBuilder.Append(")");
            }

            return stringBuilder.ToString();
        }

        private string getConditionContractBP(ContractBase value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (value != null && value.ContractNo != null)
            {
                stringBuilder.Append(" AND (Contract_Charge_Detail.Contract_No = ");
                stringBuilder.Append(GetDB(value.ContractNo.ToString()));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        //============================== Public method==============================
        #region IBizPacConnectDB Members

        public string TableName
        {
            get { return "Contract_Charge_Detail"; }
        }

        public string RefNoFieldName
        {
            get { return "BizPac_Reference_No"; }
        }

        public string RefDateFiledName
        {
            get { return "BizPac_Connection_Date"; }
        }

        public string GetSQLSelectBP
        {
            get { return "SELECT Contract.Contract_Type, Contract.Contract_No, Contract.Contract_Date, Contract.Kind_Of_Contract, Contract.Contract_Start_Date, Contract.Contract_End_Date, Contract.Customer_Code, Contract.Customer_Department_Code, Contract.Unit_Hire, Contract.Rate_Status, Contract.Contract_Status, Contract.Contract_Cancel_Date, Contract.Contract_Cancel_Reason, Contract.Remark, Contract_Charge_Detail.For_Year, Contract_Charge_Detail.For_Month, Contract_Charge_Detail.Charge_Amount FROM Contract INNER JOIN Contract_Charge_Detail ON Contract.Company_Code = Contract_Charge_Detail.Company_Code AND Contract_Charge_Detail.Contract_No = Contract.Contract_No "; }
        }

        public bool FillIBPList(BTS2BizPacList listBP, Company company, SqlDataReader dataReader)
        {
            bool result = false;
            IBTS2BizPacHeader iBizPac;

            while (dataReader.Read())
            {
                if ((string)dataReader[CONTRACT_NO] != "PTB-C-0000000")
                {
                    result = true;

                    string contractType = (string)dataReader[CONTRACT_TYPE];
                    switch (contractType)
                    {
                        case ContractType.CONTRACT_TYPE_VEHICLE:
                            {
                                iBizPac = new VehicleContractChargeBP(company);
                                fillContractChargeDetailConnectBizPac((VehicleContractChargeBP)iBizPac, company, dataReader);
                                fillVehicleContractCharge((VehicleContractChargeBP)iBizPac, new DocumentNo((string)dataReader[CONTRACT_NO]), company);
                                break;
                            }
                        case ContractType.CONTRACT_TYPE_DRIVER:
                            {
                                iBizPac = new DriverContractChargeBP(company);
                                fillContractChargeDetailConnectBizPac((DriverContractChargeBP)iBizPac, company, dataReader);
                                fillDriverContractCharge((DriverContractChargeBP)iBizPac, new DocumentNo((string)dataReader[CONTRACT_NO]), company); 
                                break;
                            }
                        default:
                            {
                                iBizPac = new ServiceStaffContractChargeBP(company);
                                fillContractChargeDetailConnectBizPac((ServiceStaffContractChargeBP)iBizPac, company, dataReader);
                                break;
                            }
                    }
                    listBP.Add(iBizPac);
                }
            }
            iBizPac = null;
            return result;
        }

        public string GetSpecificSelectConditionBP
        {
            get 
            {
                DateTime dateCondition = DateTime.Today.AddMonths(-1);

                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(" AND (Contract.Contract_Status IN ('2', '4')) AND (Contract.Contract_No <> 'PTB-C-0000000') AND (Contract_Charge_Detail.Charge_Amount <> 0) AND (Contract.Contract_Type = ");
                
                //For IMCT, select data before beginnig of month
                //stringBuilder.Append(" AND ([Customer_Code] = '000014') AND (Contract.Contract_Status IN ('2', '4')) AND (Contract.Contract_No <> 'PTB-C-0000000') AND (Contract_Charge_Detail.Charge_Amount <> 0) AND (Contract.Contract_Type = ");

                switch (typeBP)
                {
                    case CONTRACTTYPEBP.VEHICLE:
                        stringBuilder.Append(" 'V') AND ((Contract_Charge_Detail.For_Year < ");
                        stringBuilder.Append(GetDB(DateTime.Today.Year));
                        stringBuilder.Append(" ) OR ((Contract_Charge_Detail.For_Year = ");
                        stringBuilder.Append(GetDB(DateTime.Today.Year));
                        stringBuilder.Append(" ) AND (Contract_Charge_Detail.For_Month <= ");
                        stringBuilder.Append(GetDB(DateTime.Today.Month));
                        stringBuilder.Append(" ))) ");
                        break;
                    case CONTRACTTYPEBP.DRIVER:
                        stringBuilder.Append(" 'D') AND ((Contract_Charge_Detail.For_Year < ");
                        stringBuilder.Append(GetDB(DateTime.Today.Year));
                        stringBuilder.Append(" ) OR ((Contract_Charge_Detail.For_Year = ");
                        stringBuilder.Append(GetDB(DateTime.Today.Year));
                        stringBuilder.Append(" ) AND (Contract_Charge_Detail.For_Month < ");

                        //For IMCT, select data before beginnig of month
                        //stringBuilder.Append(" ) AND (Contract_Charge_Detail.For_Month <= "); //IMCT

                        stringBuilder.Append(GetDB(DateTime.Today.Month));
                        stringBuilder.Append(" ))) ");
                        break;
                    case CONTRACTTYPEBP.SERVICESTAFF:
                        stringBuilder.Append(" 'O') AND ((Contract_Charge_Detail.For_Year < ");
                        stringBuilder.Append(GetDB(DateTime.Today.Year));
                        stringBuilder.Append(" ) OR ((Contract_Charge_Detail.For_Year = ");
                        stringBuilder.Append(GetDB(DateTime.Today.Year));
                        stringBuilder.Append(" ) AND (Contract_Charge_Detail.For_Month < ");
                        stringBuilder.Append(GetDB(DateTime.Today.Month));
                        stringBuilder.Append(" ))) ");
                        break;
                }

                return stringBuilder.ToString();
            }
        }

        public string GetKeyConditionBP(IBTS2BizPacHeader condition)
        {
            StringBuilder stringBuilder = new StringBuilder();

            switch (typeBP)
            {
                case CONTRACTTYPEBP.VEHICLE:
                    VehicleContractChargeBP vehicleBP = (VehicleContractChargeBP)condition;
                    stringBuilder.Append(getConditionChargeBP(vehicleBP));
                    stringBuilder.Append(getConditionContractBP(vehicleBP));
                    break;
                case CONTRACTTYPEBP.DRIVER:
                    DriverContractChargeBP driverBP = (DriverContractChargeBP)condition;
                    stringBuilder.Append(getConditionChargeBP(driverBP));
                    stringBuilder.Append(getConditionContractBP(driverBP));
                    break;
                case CONTRACTTYPEBP.SERVICESTAFF:
                    ServiceStaffContractChargeBP staffBP = (ServiceStaffContractChargeBP)condition;
                    stringBuilder.Append(getConditionChargeBP(staffBP));
                    stringBuilder.Append(getConditionContractBP(staffBP));
                    break;
            }
            return stringBuilder.ToString();
        }

        public string GetBaseConditionBP(Company company)
        {
			StringBuilder stringBuilder = new StringBuilder(" WHERE (Contract.Company_Code = ");
            if (company == null)
            {
                stringBuilder.Append(" '12' ");                    
            }
            else                
            {
                stringBuilder.Append(GetDB(company.CompanyCode));
            }
			stringBuilder.Append(")");
			return stringBuilder.ToString();
        }

        public string GetOrderByBP
        {
            get { return " ORDER BY Contract.Contract_No " ; }
        }

        #endregion
    }
}
