using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;
using SystemFramework.AppException;

using ictus.Common.Entity;
using ictus.Common.Entity.General; 
using ictus.PIS.PI.Entity;

namespace DataAccess.VehicleDB
{
    public class VehicleRepairingHistoryDB : DataAccessBase, DataAccess.CommonDB.ITableName
	{
		#region - Constant -
		private const int REPAIRING_NO = 0;
		private const int REPAIRING_TYPE = 1;
		private const int REPORT_DATE = 2;
		private const int REPORT_BY_EMPLOYEE_NO = 3;
		private const int VEHICLE_NO = 4;
		private const int MILEAGE = 5;
		private const int KIND_OF_VEHICLE = 6;
		private const int VEHICLE_CONTRACT_NO = 7;
		private const int CUSTOMER_CODE = 8;
		private const int CUSTOMER_DEPARTMENT_CODE = 9;
		private const int HIRER_NAME = 10;
		private const int DRIVER_NAME = 11;
		private const int DRIVER_EMPLOYEE_NO = 12;
		private const int GARAGE_CODE = 13;
		private const int GARAGE_INCHARGE_NAME = 14;
		private const int GARAGE_INCHARGE_TEL_NO = 15;
		private const int REPAIRING_START_DATE = 16;
		private const int REPAIRING_FINISH_DATE = 17;
		private const int PAYMENT_TYPE = 18;
		private const int VAT_STATUS = 19;
		private const int MAINTENANCE_AMOUNT = 20;
		private const int VAT_AMOUNT = 21;
		private const int TOTAL_AMOUNT = 22;
        private const int TAX_INVOICE_STATUS = 23;
		private const int TAX_INVOICE_NO = 24;
		private const int TAX_INVOICE_DATE = 25;
		private const int RECEIVER_EMPLOYEE_NO = 26;
		private const int REMARK1 = 27;
		private const int REMARK2 = 28;
        private const int BIZPAC_REFERENCE_NO = 29;
		#endregion

		#region - Private -
		private EmployeeDB dbEmployee;
		private VehicleContractDB dbVehicleContract;
		private VehicleDB dbVehicle;
		private ContractDB.ContractDB dbContract;
		private CustomerDB dbCustomer;
		private CustomerDepartmentDB dbCustomerDepartment;
		private GarageDB dbGarage;
		private PaymentTypeDB dbPaymentType;
		private VehicleVatStatusDB dbVehicleVatStatus;
		private VehicleRepairingDetailDB dbVehicleRepairingDetail;
		#endregion

		//		============================== Constructor ==============================
		public VehicleRepairingHistoryDB()
		{
			dbEmployee = new EmployeeDB();
			dbVehicleContract = new VehicleContractDB();
			dbVehicle = new VehicleDB();
			dbContract = new DataAccess.ContractDB.ContractDB();
			dbCustomer = new CustomerDB();
			dbCustomerDepartment = new CustomerDepartmentDB();
			dbGarage = new GarageDB();
			dbPaymentType = new PaymentTypeDB();
			dbVehicleVatStatus = new VehicleVatStatusDB();
			dbVehicleRepairingDetail = new VehicleRepairingDetailDB();
		}

		//		============================== Private Method ==============================
		#region - getSQL -
		protected string getSQLSelect()
		{
            return " SELECT Repairing_No, Repairing_Type, Report_Date, Report_By_Employee_No, Vehicle_No, Mileage, Kind_Of_Vehicle, Vehicle_Contract_No, Customer_Code, Customer_Department_Code, Hirer_Name, Driver_Name, Driver_Employee_No, Garage_Code, Garage_Incharge_Name, Garage_Incharge_Tel_No, Repairing_Start_Date, Repairing_Finish_Date, Payment_Type, VAT_Status, Maintenance_Amount, VAT_Amount, Total_Amount, Tax_Invoice_Status, Tax_Invoice_No, Tax_Invoice_Date, Receiver_Employee_No, Remark1, Remark2, BizPac_Reference_No FROM Vehicle_Repairing_History ";
		}

		private string getSQLInsert(RepairingInfoBase value)
		{
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Vehicle_Repairing_History (Company_Code, Repairing_No, Repairing_Type, Report_Date, Report_By_Employee_No, Vehicle_No, Mileage, Kind_Of_Vehicle, Vehicle_Contract_No, Customer_Code, Customer_Department_Code, Hirer_Name, Driver_Name, Driver_Employee_No, Garage_Code, Garage_Incharge_Name, Garage_Incharge_Tel_No, Repairing_Start_Date, Repairing_Finish_Date, Payment_Type, VAT_Status, Maintenance_Amount, VAT_Amount, Total_Amount, Tax_Invoice_Status, Tax_Invoice_No, Tax_Invoice_Date, Receiver_Employee_No, Remark1, Remark2, BizPac_Reference_No, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");
			//Company_Code			
			stringBuilder.Append(GetDB(value.ARepairSparePartsList.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Repairing_No			
			stringBuilder.Append(GetDB(value.RepairingNo));
			stringBuilder.Append(", ");

			//Repairing_Type
			stringBuilder.Append(GetDB(value.RepairingType));
			stringBuilder.Append(", ");
			
			//Report_Date
			stringBuilder.Append(GetDB(value.ReportDate));
			stringBuilder.Append(", ");
			
			//Report_By_Employee_No
			stringBuilder.Append(GetDB(value.AReporter.EmployeeNo));
			stringBuilder.Append(", ");
			
			//Vehicle_No
			stringBuilder.Append(GetDB(value.VehicleInfo.VehicleNo));
			stringBuilder.Append(", ");
			
			//Mileage
			stringBuilder.Append(GetDB(value.Mileage));
			stringBuilder.Append(", ");

			//Kind_Of_Vehicle
			stringBuilder.Append(GetDB(value.KindOfVehicle));
			stringBuilder.Append(", ");
			
			if(value.AVehicleContract == null)
			{
				//Vehicle_Contract_No
				stringBuilder.Append("'', ");
			}
			else
			{
				//Vehicle_Contract_No
				stringBuilder.Append(GetDB(value.AVehicleContract.ContractNo.ToString()));
				stringBuilder.Append(", ");
			}

			if(value.ACustomer == null)
			{
				//Customer_Code
				stringBuilder.Append("'', ");
			}
			else
			{
				//Customer_Code
				stringBuilder.Append(GetDB(value.ACustomer.Code));
				stringBuilder.Append(", ");
			}

			if(value.ACustomerDepartment == null)
			{
				//Customer_Department_Code
				stringBuilder.Append("'', ");
			}
			else
			{
				//Customer_Department_Code
				stringBuilder.Append(GetDB(value.ACustomerDepartment.Code));
				stringBuilder.Append(", ");			
			}

			//Hirer_Name
			stringBuilder.Append(GetDB(value.AHirer.Name));
			stringBuilder.Append(", ");

			//Driver_Name
			stringBuilder.Append(GetDB(value.DriverName));
			stringBuilder.Append(", ");

			if(value.ADriver == null )
			{
				//Driver_Employee_No
				stringBuilder.Append("'', ");
			}
			else
			{
				//Driver_Employee_No
				stringBuilder.Append(GetDB(value.ADriver.EmployeeNo));
				stringBuilder.Append(", ");
			}

			if(value.Garage == null)
			{
				//Garage_Code
				stringBuilder.Append("NULL");
				stringBuilder.Append(", ");
				
				//Garage_Incharge_Name
				stringBuilder.Append(GetDB(""));
				stringBuilder.Append(", ");
				
				//Garage_Incharge_Tel_No
				stringBuilder.Append(GetDB(""));
				stringBuilder.Append(", ");
			}
			else
			{
				//Garage_Code
				stringBuilder.Append(GetDB(value.Garage.Code));
				stringBuilder.Append(", ");
				
				//Garage_Incharge_Name
				stringBuilder.Append(GetDB(value.GarageInchargeName));
				stringBuilder.Append(", ");
				
				//Garage_Incharge_Tel_No
				stringBuilder.Append(GetDB(value.GarageTelNo));
				stringBuilder.Append(", ");			
			}

			//Repairing_Start_Date
			stringBuilder.Append(GetDB(value.RepairPeriod.From));
			stringBuilder.Append(", ");
			
			//Repairing_Finish_Date
			stringBuilder.Append(GetDB(value.RepairPeriod.To));
			stringBuilder.Append(", ");
			
			if(value.RepairingPaymentType == null)
			{
				//Payment_Type
				stringBuilder.Append("NULL");
				stringBuilder.Append(", ");	
			}
			else
			{
				//Payment_Type
				stringBuilder.Append(GetDB(value.RepairingPaymentType.Code));
				stringBuilder.Append(", ");			
			}

			//VAT_Status
			stringBuilder.Append(GetDB(value.VatStatus.Code));
			stringBuilder.Append(", ");
			
			if(IsNotNULL(value.MaintenanceAmount))
			{
				//Maintenance_Amount
				stringBuilder.Append(GetDB(value.MaintenanceAmount));
				stringBuilder.Append(", ");
			}
			else
			{
				stringBuilder.Append(GetDB(0));		
				stringBuilder.Append(", ");		
			}

			if(IsNotNULL(value.MaintenanceAmount))
			{
				//VAT_Amount
				stringBuilder.Append(GetDB(value.VatAmount));
				stringBuilder.Append(", ");
			}
			else
			{
				stringBuilder.Append(GetDB(0));		
				stringBuilder.Append(", ");		
			}

			if(IsNotNULL(value.MaintenanceAmount))
			{
				//Total_Amount
				stringBuilder.Append(GetDB(value.TotalAmount));
				stringBuilder.Append(", ");
			}
			else
			{
				stringBuilder.Append(GetDB(0));		
				stringBuilder.Append(", ");		
			}

            //Tax_Invoice_Status
            stringBuilder.Append(GetDB(value.TaxInvoiceStatus));
            stringBuilder.Append(", ");

			//Tax_Invoice_No
			stringBuilder.Append(GetDB(value.TaxInvoiceNo));
			stringBuilder.Append(", ");
			
			if(IsNotNULL(value.TaxInvoiceDate))
			{
				//Tax_Invoice_Date
				stringBuilder.Append(GetDB(value.TaxInvoiceDate));
				stringBuilder.Append(", ");
			}
			else
			{
				//Tax_Invoice_Date
				stringBuilder.Append("NULL, ");
			}

			//Receiver_Employee_No
			stringBuilder.Append(GetDB(value.AReceiver.EmployeeNo));
			stringBuilder.Append(", ");
			
			//Remark1
			stringBuilder.Append(GetDB(value.Remark1));
			stringBuilder.Append(", ");
			
			//Remark2
			stringBuilder.Append(GetDB(value.Remark2));
			stringBuilder.Append(", ");

            //BizPac_Reference_No
            stringBuilder.Append(GetDB(value.BPRefNo));
            stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(") ");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(RepairingInfoBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(" UPDATE Vehicle_Repairing_History SET ");

			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(value.ARepairSparePartsList.Company.CompanyCode));

			stringBuilder.Append(", ");
			stringBuilder.Append("Repairing_No = ");
			stringBuilder.Append(GetDB(value.RepairingNo));

			stringBuilder.Append(", ");
			stringBuilder.Append("Repairing_Type = ");
			stringBuilder.Append(GetDB(value.RepairingType));

			stringBuilder.Append(", ");			
			stringBuilder.Append("Report_Date = ");
			stringBuilder.Append(GetDB(value.ReportDate));

			stringBuilder.Append(", ");			
			stringBuilder.Append("Report_By_Employee_No = ");
			stringBuilder.Append(GetDB(value.AReporter.EmployeeNo));

			stringBuilder.Append(", ");			
			stringBuilder.Append("Vehicle_No = ");
			stringBuilder.Append(GetDB(value.VehicleInfo.VehicleNo));

			stringBuilder.Append(", ");			
			stringBuilder.Append("Mileage = ");
			stringBuilder.Append(GetDB(value.Mileage));

			stringBuilder.Append(", ");			
			stringBuilder.Append("Kind_Of_Vehicle = ");
			stringBuilder.Append(GetDB(value.KindOfVehicle));

			if(value.AVehicleContract == null)
			{
				stringBuilder.Append(", Vehicle_Contract_No = ''");
			}
			else
			{
				stringBuilder.Append(", ");			
				stringBuilder.Append("Vehicle_Contract_No = ");
				stringBuilder.Append(GetDB(value.AVehicleContract.ContractNo.ToString()));
			}

			if(value.ACustomer == null)
			{
				stringBuilder.Append(", Customer_Code = ''");
			}
			else
			{
				stringBuilder.Append(", ");			
				stringBuilder.Append("Customer_Code = ");
				stringBuilder.Append(GetDB(value.ACustomer.Code));
			}

			if(value.ACustomerDepartment == null)
			{
				stringBuilder.Append(", Customer_Department_Code = ''");
			}
			else
			{
				stringBuilder.Append(", ");			
				stringBuilder.Append("Customer_Department_Code = ");
				stringBuilder.Append(GetDB(value.ACustomerDepartment.Code));
			}


			stringBuilder.Append(", ");			
			stringBuilder.Append("Hirer_Name = ");
			stringBuilder.Append(GetDB(value.AHirer.Name));

			stringBuilder.Append(", ");
			stringBuilder.Append("Driver_Name = ");
			stringBuilder.Append(GetDB(value.DriverName));

			if(value.ADriver == null)
			{
				stringBuilder.Append(", Driver_Employee_No = ''");
			}
			else
			{
				stringBuilder.Append(", ");
				stringBuilder.Append("Driver_Employee_No = ");
				stringBuilder.Append(GetDB(value.ADriver.EmployeeNo));
			}
			
			if(value.Garage == null)
			{
				stringBuilder.Append(", Garage_Code = NULL");

				stringBuilder.Append(", Garage_Incharge_Name = ''");

				stringBuilder.Append(", Garage_Incharge_Tel_No = ''");
			}
			else
			{
				stringBuilder.Append(", ");	
				stringBuilder.Append("Garage_Code = ");
				stringBuilder.Append(GetDB(value.Garage.Code));

				stringBuilder.Append(", ");				
				stringBuilder.Append("Garage_Incharge_Name = ");
				stringBuilder.Append(GetDB(value.GarageInchargeName));

				stringBuilder.Append(", ");				
				stringBuilder.Append("Garage_Incharge_Tel_No = ");
				stringBuilder.Append(GetDB(value.GarageTelNo));
			}

			if(IsNotNULL(value.RepairPeriod.From))
			{
				stringBuilder.Append(", ");	
				stringBuilder.Append("Repairing_Start_Date = ");
				stringBuilder.Append(GetDB(value.RepairPeriod.From));
			}
			else
			{
				stringBuilder.Append(", Repairing_Start_Date = NULL");
			}

			if(IsNotNULL(value.RepairPeriod.To))
			{
				stringBuilder.Append(", ");				
				stringBuilder.Append("Repairing_Finish_Date = ");
				stringBuilder.Append(GetDB(value.RepairPeriod.To));
			}
			else
			{
				stringBuilder.Append(", Repairing_Finish_Date = NULL");
			}

			if(value.RepairingPaymentType == null)
			{
				stringBuilder.Append(", Payment_Type = NULL");
			}
			else
			{
				stringBuilder.Append(", ");	
				stringBuilder.Append("Payment_Type = ");
				stringBuilder.Append(GetDB(value.RepairingPaymentType.Code));
			}

			stringBuilder.Append(", ");			
			stringBuilder.Append("VAT_Status = ");
			stringBuilder.Append(GetDB(value.VatStatus.Code));

			if(IsNotNULL(value.MaintenanceAmount))
			{
				stringBuilder.Append(", ");			
				stringBuilder.Append("Maintenance_Amount = ");
				stringBuilder.Append(GetDB(value.MaintenanceAmount));
			}
			else
			{
				stringBuilder.Append(", ");			
				stringBuilder.Append("Maintenance_Amount = ");
				stringBuilder.Append(GetDB(0));		
			}

			if(IsNotNULL(value.VatAmount))
			{
				stringBuilder.Append(", ");			
				stringBuilder.Append("VAT_Amount = ");
				stringBuilder.Append(GetDB(value.VatAmount));	
			}
			else
			{
				stringBuilder.Append(", ");			
				stringBuilder.Append("VAT_Amount = ");
				stringBuilder.Append(GetDB(0));		
			}

            stringBuilder.Append(", ");	
            stringBuilder.Append("Tax_Invoice_Status = ");
            stringBuilder.Append(GetDB(value.TaxInvoiceStatus));

			if(IsNotNULL(value.TotalAmount))
			{
				stringBuilder.Append(", ");			
				stringBuilder.Append("Total_Amount = ");
				stringBuilder.Append(GetDB(value.TotalAmount));			
			}
			else
			{
				stringBuilder.Append(", ");			
				stringBuilder.Append("Total_Amount = ");
				stringBuilder.Append(GetDB(0));		
			}

			stringBuilder.Append(", ");			
			stringBuilder.Append("Tax_Invoice_No = ");
			stringBuilder.Append(GetDB(value.TaxInvoiceNo));

			
			if(IsNotNULL(value.TaxInvoiceDate))
			{
				stringBuilder.Append(", ");
				stringBuilder.Append("Tax_Invoice_Date = ");
				stringBuilder.Append(GetDB(value.TaxInvoiceDate));
			}
			else
			{
				stringBuilder.Append(", Tax_Invoice_Date = NULL");
			}

			stringBuilder.Append(", ");
			stringBuilder.Append("Receiver_Employee_No = ");
			stringBuilder.Append(GetDB(value.AReceiver.EmployeeNo));

			stringBuilder.Append(", ");			
			stringBuilder.Append("Remark1 = ");
			stringBuilder.Append(GetDB(value.Remark1));

			stringBuilder.Append(", ");			
			stringBuilder.Append("Remark2 = ");
			stringBuilder.Append(GetDB(value.Remark2));

            stringBuilder.Append(", ");
            stringBuilder.Append("BizPac_Reference_No = ");
            stringBuilder.Append(GetDB(value.BPRefNo));

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
			return " DELETE FROM Vehicle_Repairing_History ";
		}

		protected string getKeyCondition(RepairingInfoBase value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.RepairingNo))
			{
				stringBuilder.Append(" AND (Repairing_No = ");
				stringBuilder.Append(GetDB(value.RepairingNo));
				stringBuilder.Append(")");
			}
			if (value.VehicleInfo != null && IsNotNULL(value.VehicleInfo.VehicleNo))
			{
				stringBuilder.Append(" AND (Vehicle_No = ");
				stringBuilder.Append(GetDB(value.VehicleInfo.VehicleNo));
				stringBuilder.Append(")");
			}
			if (IsNotNULL(value.RepairingType))
			{
				stringBuilder.Append(" AND (Repairing_Type = ");
				stringBuilder.Append(GetDB(value.RepairingType));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getKeyCondition(Vehicle value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" AND (Vehicle_No = ");
			stringBuilder.Append(GetDB(value.VehicleNo));
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}
		#endregion

		#region - Fill -
		private void nullEmpNotFoundException(EmpNotFoundException ex)
		{
			ex = null;
		}

        protected virtual RepairingBase getNewMaintenance(Company aCompany)
        {
            return new Maintenance(aCompany);
        }

        protected void fillVehicleRepairingHistory(RepairingBase value, Company aCompany, SqlDataReader dataReader)
        {
            value.RepairingNo = (string)dataReader[REPAIRING_NO];
            value.RepairingType = CTFunction.GetRepairingType((string)dataReader[REPAIRING_TYPE]);
            value.ReportDate = dataReader.GetDateTime(REPORT_DATE);
            value.VehicleInfo = dbVehicle.GetDBVehicleInfo(dataReader.GetInt32(VEHICLE_NO), aCompany);
            value.KindOfVehicle = CTFunction.GetKindOfVehicleType((string)dataReader[KIND_OF_VEHICLE]);

            if (dataReader.IsDBNull(GARAGE_CODE))
            {
                Garage garage = new Garage();
                garage.Code = NullConstant.STRING;
                value.Garage = garage;
                garage = null;
            }
            else
            {
                value.Garage = dbGarage.getDBGarage((string)dataReader[GARAGE_CODE], aCompany);
            }

            if (dataReader.IsDBNull(REPAIRING_START_DATE))
            {
                value.RepairPeriod.From = NullConstant.DATETIME;
            }
            else
            {
                value.RepairPeriod.From = dataReader.GetDateTime(REPAIRING_START_DATE);
            }

            if (dataReader.IsDBNull(REPAIRING_FINISH_DATE))
            {
                value.RepairPeriod.To = NullConstant.DATETIME;
            }
            else
            {
                value.RepairPeriod.To = dataReader.GetDateTime(REPAIRING_FINISH_DATE);
            }

            if (dataReader.IsDBNull(PAYMENT_TYPE))
            {
                PaymentType paymentType = new PaymentType();
                paymentType.Code = NullConstant.STRING;
                value.RepairingPaymentType = paymentType;
                paymentType = null;
            }
            else
            {
                value.RepairingPaymentType = (PaymentType)dbPaymentType.GetMTB((string)dataReader[PAYMENT_TYPE]);
            }

            if (dataReader.IsDBNull(VAT_STATUS))
            {
                VehicleVatStatus vehicleVatStatus = new VehicleVatStatus();
                vehicleVatStatus.Code = NullConstant.STRING;
                value.VatStatus = vehicleVatStatus;
                vehicleVatStatus = null;
            }
            else
            {
                value.VatStatus = (VehicleVatStatus)dbVehicleVatStatus.GetMTB((string)dataReader[VAT_STATUS]);
            }

            value.MaintenanceAmount = dataReader.GetDecimal(MAINTENANCE_AMOUNT);
            value.VatAmount = dataReader.GetDecimal(VAT_AMOUNT);
            value.TotalAmount = dataReader.GetDecimal(TOTAL_AMOUNT);
            value.TaxInvoiceStatus = CTFunction.GetTaxInvoiceStatusType((string)dataReader[TAX_INVOICE_STATUS]);
            value.TaxInvoiceNo = (string)dataReader[TAX_INVOICE_NO];

            if (dataReader.IsDBNull(TAX_INVOICE_DATE))
            {
                value.TaxInvoiceDate = NullConstant.DATETIME;
            }
            else
            {
                value.TaxInvoiceDate = dataReader.GetDateTime(TAX_INVOICE_DATE);
            }

            value.Remark1 = (string)dataReader[REMARK1];
            value.Remark2 = (string)dataReader[REMARK2];
        }

		private void fillVehicleInfoRepairingHistory(RepairingInfoBase value, Company aCompany, SqlDataReader dataReader)
		{
            fillVehicleRepairingHistory(value, aCompany, dataReader);

			string customerCode;
			string customerDepartmentCode;
			
			value.AReporter = dbEmployee.GetFormerlyEmployee((string)dataReader[REPORT_BY_EMPLOYEE_NO], aCompany);
			value.Mileage  = dataReader.GetInt32(MILEAGE);
			DocumentNo documentNo = new DocumentNo((string)dataReader[VEHICLE_CONTRACT_NO]);
			value.AVehicleContract = (VehicleContract)dbContract.GetContract(documentNo,aCompany);
			documentNo = null;

			customerDepartmentCode = ((string)dataReader[CUSTOMER_DEPARTMENT_CODE]).Trim();
			customerCode = ((string)dataReader[CUSTOMER_CODE]).Trim();

			if(customerCode != "")
			{
                if (customerDepartmentCode == "ZZZ" || customerDepartmentCode == "")
				{				
					value.ACustomer = dbCustomer.GetDBCustomer(customerCode, aCompany);
				}
				else
				{
					value.ACustomerDepartment = dbCustomerDepartment.GetDBCustomerDepartment(customerDepartmentCode, customerCode, aCompany);
                    value.ACustomer = value.ACustomerDepartment.ACustomer;
				}			
			}
			value.AHirer.Name = (string)dataReader[HIRER_NAME];
			value.DriverName = (string)dataReader[DRIVER_NAME];

			string driverNo = (string)dataReader[DRIVER_EMPLOYEE_NO];
			if(driverNo.Trim() != "")
			{
				value.ADriver = (Employee)dbEmployee.GetFormerlyEmployee(driverNo, aCompany);
			}
			
			value.GarageInchargeName  = (string)dataReader[GARAGE_INCHARGE_NAME];
			value.GarageTelNo  = (string)dataReader[GARAGE_INCHARGE_TEL_NO];
			value.AReceiver = dbEmployee.GetFormerlyEmployee((string)dataReader[RECEIVER_EMPLOYEE_NO], aCompany);
            value.BPRefNo = (string)dataReader[BIZPAC_REFERENCE_NO];

			dbVehicleRepairingDetail.FillVehicleRepairingDetail(value);
		}

		private void fillVehicleRepairingHistoryForDaily(RepairingInfoBase value, Company aCompany, SqlDataReader dataReader)
		{
            //index : 0 = Repairing_No 1 = Vehicle_No 2 = Repairing_Finish_Date 
			value.RepairingNo  = (string)dataReader[0];
			value.VehicleInfo  = dbVehicle.GetDBVehicleInfo(dataReader.GetInt32(1),aCompany);

			if(dataReader.IsDBNull(2))
			{
				value.RepairPeriod.To = NullConstant.DATETIME;
			}
			else
			{
				value.RepairPeriod.To  = dataReader.GetDateTime(2);
			}	
		}

		private bool fillVehicleRepairingHistory(ref RepairingInfoBase value, Company aCompany,  string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillVehicleInfoRepairingHistory(value, aCompany, dataReader);
					result = true;
				}
				else
				{result = false;}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}			
			return result;				
		}

		private bool fillVehicleRepairingHistory(ref VehicleMaintenance value, Company aCompany,  string sql)
		{
			bool result = false;			
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				Maintenance maintenance;
				while (dataReader.Read())
				{
					result = true;
                    maintenance = (Maintenance)getNewMaintenance(aCompany);
					fillVehicleInfoRepairingHistory((RepairingInfoBase)maintenance, value.Company, dataReader);
					value.Add(maintenance);
				}
				maintenance = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			return result;		
		}

		private bool fillVehicleRepairingHistoryForDaily(ref VehicleMaintenance value,  string sql)
		{
			bool result = false;			
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				Maintenance maintenance;
				while (dataReader.Read())
				{
					result = true;
                    maintenance = (Maintenance)getNewMaintenance(value.Company);
					fillVehicleRepairingHistoryForDaily((RepairingInfoBase)maintenance, value.Company, dataReader);
					value.Add(maintenance);
				}
				maintenance = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			return result;		
		}

		#endregion

		//		============================== Public Method ==============================
		public bool FillVehicleRepairingHistory(RepairingInfoBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.ARepairSparePartsList.Company));
			stringBuilder.Append(getKeyCondition(value));

			return fillVehicleRepairingHistory(ref value, value.ARepairSparePartsList.Company, stringBuilder.ToString());
		}

		public bool FillVehicleRepairingHistoryList(ref VehicleMaintenance value, RepairingInfoBase condition)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(condition));

			return fillVehicleRepairingHistory(ref value, value.Company, stringBuilder.ToString());
		}

        public bool fillVehicleRepairingHistoryForDaily(ref VehicleMaintenance value)
		{
            StringBuilder stringBuilder = new StringBuilder(" SELECT VM.Repairing_No, VM.Vehicle_No, VM.Repairing_Finish_Date FROM Vehicle_Repairing_History VM ");
            stringBuilder.Append(" INNER JOIN (SELECT VD.Vehicle_no, MAX(VD.Repairing_Finish_Date) AS Max_Finish_Date ");
            stringBuilder.Append(" FROM Vehicle_Repairing_History VD INNER JOIN Vehicle V ON VD.Vehicle_No = V.Vehicle_No ");
            stringBuilder.Append(" WHERE  V.Vehicle_Status IN ('2', '3') ");
            stringBuilder.Append(" GROUP BY VD.Vehicle_no) Max_Repairing ");
		    stringBuilder.Append(" ON VM.Vehicle_No = Max_Repairing.vehicle_no ");
            stringBuilder.Append(" AND VM.Repairing_Finish_Date = Max_Repairing.Max_Finish_Date WHERE VM.Company_Code = ");
			stringBuilder.Append(GetDB(value.Company.CompanyCode));

			return fillVehicleRepairingHistoryForDaily(ref value, stringBuilder.ToString());
		}

		public DateTime GetVehicleRepairingHistoryMaxRepairFinish(RepairingInfoBase value)
		{
			StringBuilder stringBuilder = new StringBuilder("SELECT MAX(Repairing_Finish_Date) AS MaxFinishDate FROM Vehicle_Repairing_History WHERE Vehicle_No = ");
			stringBuilder.Append(value.VehicleInfo.VehicleNo);
			stringBuilder.Append(" AND Repairing_No <> ");
			stringBuilder.Append(GetDB(value.RepairingNo));

			DateTime maxRepairingFinishDate;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
			try
			{
				if (dataReader.Read() && !dataReader.IsDBNull(0))
				{
					maxRepairingFinishDate = dataReader.GetDateTime(0);
				}
				else
				{
					maxRepairingFinishDate =  NullConstant.DATETIME;
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

			stringBuilder = null;
			return maxRepairingFinishDate;	
		}

		public int GetMaxMileage(VehicleInfo value, DateTime date, Company aCompany)
		{
			DateTime tempDate = new DateTime(date.Year, date.Month, date.Day);
			StringBuilder stringBuilder = new StringBuilder(" SELECT MAX(Mileage) AS MaxMileage ");
			stringBuilder.Append(" FROM Vehicle_Repairing_History ");
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(" AND (Repairing_Start_Date <=  ");
			stringBuilder.Append(GetDB(tempDate));
			stringBuilder.Append(") ");

			int maxMileage = 0;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
			try
			{
				if (dataReader.Read() && !dataReader.IsDBNull(0))
				{
					maxMileage = dataReader.GetInt32(0);
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

			stringBuilder = null;
			return maxMileage;	
		}

		public int GetMaxMileageExclude(VehicleInfo value, DateTime date, Company aCompany, RepairingBase condition)
		{
			DateTime tempDate = new DateTime(date.Year, date.Month, date.Day);
			StringBuilder stringBuilder = new StringBuilder(" SELECT MAX(Mileage) AS MaxMileage ");
			stringBuilder.Append(" FROM Vehicle_Repairing_History ");
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));
			if(condition!=null && IsNotNULL(condition.RepairingNo))
			{
				stringBuilder.Append(" AND (Repairing_No <> ");
				stringBuilder.Append(GetDB(condition.RepairingNo));
				stringBuilder.Append(") ");
			}
			stringBuilder.Append(" AND (Repairing_Start_Date <=  ");
			stringBuilder.Append(GetDB(tempDate));
			stringBuilder.Append(") ");

			int maxMileage = 0;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
			try
			{
				if (dataReader.Read() && !dataReader.IsDBNull(0))
				{
					maxMileage = dataReader.GetInt32(0);
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

			stringBuilder = null;
			return maxMileage;	
		}

        public bool FillVehicleRepairingHistory(VehicleMaintenance value, Vehicle vehicle)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(vehicle));            

            return fillVehicleRepairingHistory(ref value, value.Company, stringBuilder.ToString());
        }

        public void FillVehicleRepairingHistory(ref VehicleMaintenance value, Vehicle vehicle)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(vehicle));
            stringBuilder.Append(" ORDER BY Repairing_Start_Date,Repairing_Finish_Date ");

            fillVehicleRepairingHistory(ref value, value.Company, stringBuilder.ToString());
        }

        public string GetBizPacVehicleRepairingHistory(string repairingNo, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(" SELECT BizPac_Reference_No FROM Vehicle_Repairing_History ");
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(" AND (Repairing_No = ");
		    stringBuilder.Append(GetDB(repairingNo));
			stringBuilder.Append(") ");

            string bpNo = string.Empty;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
            try
            {
                if (dataReader.Read() && !dataReader.IsDBNull(0))
                {bpNo = (string)dataReader[0];}
            }
            catch (IndexOutOfRangeException ein)
            {throw ein;}
            finally
            {tableAccess.CloseDataReader();}

            stringBuilder = null;
            return bpNo.Trim();	
        }

        public bool FillVehicleRepairingHistory(VehicleMaintenance value, string docNo, string taxNo)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(" AND (Repairing_No <> ");
            stringBuilder.Append(GetDB(docNo));
            stringBuilder.Append(") AND (Tax_Invoice_No = ");
            stringBuilder.Append(GetDB(taxNo));
            stringBuilder.Append(")");

            return fillVehicleRepairingHistory(ref value, value.Company, stringBuilder.ToString());
        }

		public bool InsertVehicleRepairingHistory(RepairingInfoBase value)
		{			 
			return (tableAccess.ExecuteSQL(getSQLInsert(value))>0);
		}

        public bool UpdateVehicleRepairingHistory(RepairingInfoBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value));
			stringBuilder.Append(getBaseCondition(value.ARepairSparePartsList.Company));
			stringBuilder.Append(getKeyCondition(value));

			bool result = (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
			stringBuilder = null;
			return result;
		}

        public bool DeleteVehicleRepairingHistory(RepairingInfoBase value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.ARepairSparePartsList.Company));
			stringBuilder.Append(getKeyCondition(value));
			
			bool result = (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
			stringBuilder = null;
			return result;
		}

        #region ITableName Members

        public string TableName
        {
            get { return "Vehicle_Repairing_History"; }
        }

        #endregion
    }
}
