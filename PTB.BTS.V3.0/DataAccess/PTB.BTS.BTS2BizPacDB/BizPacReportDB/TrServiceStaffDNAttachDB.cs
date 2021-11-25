using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacEntity;

namespace DataAccess.PTB.BTS.BTS2BizPacDB.BizPacReportDB
{
    public class TrServiceStaffDNAttachDB : DataAccessBase
    {
        #region Constructor
        public TrServiceStaffDNAttachDB()
            : base()
        { } 
        #endregion

        #region Private Method
        private string getSQLInsert(IStaffDNAttach staffAttach)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Service_Staff_DN_Attach ( Customer_Code, Customer_Department_Code, BizPac_Reference_No, Attach_Group, Main_Employee_No, Contract_No, Attach_Line, Customer_Name, Customer_Dept_Name, Employee_Name, Service_Staff_Type, Service_Staff_Name, Plate_No, Basic_Charge_Amount, OT_A_Hour_Allow, OT_A_Amount_Allow,  OT_A_Hour, OT_A_Amount , OT_B_Hour, OT_B_Amount, OT_C_Hour, OT_C_Amount, Holiday_Time, Holiday_Amount , Fix_OT_Amount, Taxi_Times, Taxi_Amount, Telephone_Amount,  Deduction_Amount_Per_Day , Deduction_Days, Deduction_Amount, One_Day_Trip_Far_Times, One_Day_Trip_Far_Amount, One_Day_Trip_Near_Times, One_Day_Trip_Near_Amount, Overnight_Trip_Times, Overnight_Trip_Amount, Other_Charge_Amount, Total_Amount, VAT_Amount, Grand_Total_Amount, Remark, Process_Date, Process_User, BizPac_Code) ");
            stringBuilder.Append(" VALUES ( ");

            //Customer_Code
            stringBuilder.Append(GetDB(staffAttach.CustomerCode));
            stringBuilder.Append(", ");

            //Customer_Department_Code
            stringBuilder.Append(GetDB(staffAttach.CustomerDepartmentCode));
            stringBuilder.Append(", ");

            //BizPac_Reference_No       
            stringBuilder.Append(GetDB(staffAttach.BizPacReferenceNo));
            stringBuilder.Append(", ");

            //Attach_Group
            stringBuilder.Append(GetDB(staffAttach.AttachGroup));
            stringBuilder.Append(", ");

            //Main_Employee_No
            stringBuilder.Append(GetDB(staffAttach.MainEmployeeNo));
            stringBuilder.Append(", ");

            //Contract_No
            stringBuilder.Append(GetDB(staffAttach.ContractNumber));
            stringBuilder.Append(", ");

            //Attach_Line
            stringBuilder.Append(GetDB(staffAttach.AttachLine));
            stringBuilder.Append(", ");

            //Customer_Name
            stringBuilder.Append(GetDB(staffAttach.CustomerShortName));
            stringBuilder.Append(", ");

            //Customer_Dept_Name
            stringBuilder.Append(GetDB(staffAttach.CustomerDeptName));
            stringBuilder.Append(", ");

            //Employee_Name
            stringBuilder.Append(GetDB(staffAttach.EmployeeName));
            stringBuilder.Append(", ");

            //Service_Staff_Type
            stringBuilder.Append(GetDB(staffAttach.ServiceStaffType));
            stringBuilder.Append(", ");

            //Service_Staff_Name
            stringBuilder.Append(GetDB(staffAttach.ServiceStaffName));
            stringBuilder.Append(", ");

            //Plate_No
            stringBuilder.Append(GetDB(staffAttach.PlateNo));
            stringBuilder.Append(", ");

            //Basic_Charge_Amount
            stringBuilder.Append(GetDB(staffAttach.BasicChargeAmount));
            stringBuilder.Append(", ");

            //OT_A_Hour_Allow
            stringBuilder.Append(staffAttach.OTAHourAllow.ToString());
            stringBuilder.Append(", ");

            //OT_A_Amount_Allow
            stringBuilder.Append(staffAttach.OTAAmountAllow.ToString());
            stringBuilder.Append(", ");

            //OT_A_Hour
            stringBuilder.Append(staffAttach.OTAHour.ToString());
            stringBuilder.Append(", ");

            //OT_A_Amount
            stringBuilder.Append(staffAttach.OTAAmount.ToString());
            stringBuilder.Append(", ");

            //OT_B_Hour 
            stringBuilder.Append(staffAttach.OTBHour.ToString());
            stringBuilder.Append(", ");

            //OT_B_Amount
            stringBuilder.Append(staffAttach.OTBAmount.ToString());
            stringBuilder.Append(", ");

            //OT_C_Hour
            stringBuilder.Append(staffAttach.OTCHour.ToString());
            stringBuilder.Append(", ");

            //OT_C_Amount
            stringBuilder.Append(staffAttach.OTCAmount.ToString());
            stringBuilder.Append(", ");

            //Holiday_Time
            stringBuilder.Append(staffAttach.HolidayTime.ToString());
            stringBuilder.Append(", ");

            //Holiday_Amount
            stringBuilder.Append(staffAttach.HolidayAmount.ToString());
            stringBuilder.Append(", ");

            //Fix_OT_Amount
            stringBuilder.Append(staffAttach.FixOTAmount.ToString());
            stringBuilder.Append(", ");

            //Taxi_Times
            stringBuilder.Append(staffAttach.TaxiTimes.ToString());
            stringBuilder.Append(", ");

            //Taxi_Amount
            stringBuilder.Append(staffAttach.TaxiAmount.ToString());
            stringBuilder.Append(", ");

            //Telephone_Amount 
            stringBuilder.Append(staffAttach.TelephoneAmount.ToString());
            stringBuilder.Append(", ");

            //Deduction_Amount_Per_Day
            stringBuilder.Append(staffAttach.DeductionAmountPerDay.ToString());
            stringBuilder.Append(", ");

            //Deduction_Days
            stringBuilder.Append(staffAttach.DeductionDays.ToString());
            stringBuilder.Append(", ");

            //Deduction_Amount
            stringBuilder.Append(staffAttach.DeductionAmount.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Far_Times
            stringBuilder.Append(staffAttach.OneDayTripFarTimes.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Far_Amount 
            stringBuilder.Append(staffAttach.OneDayTripFarAmount.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Near_Times
            stringBuilder.Append(staffAttach.OneDayTripNearTimes.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Near_Amount
            stringBuilder.Append(staffAttach.OneDayTripNearAmount.ToString());
            stringBuilder.Append(", ");

            //Overnight_Trip_Times 
            stringBuilder.Append(staffAttach.OvernightTripTimes.ToString());
            stringBuilder.Append(", ");

            //Overnight_Trip_Amount
            stringBuilder.Append(staffAttach.OvernightTripAmount.ToString());
            stringBuilder.Append(", ");

            //Other_Charge_Amount
            stringBuilder.Append(staffAttach.OtherChargeAmount.ToString());
            stringBuilder.Append(", ");

            //Total_Amount
            stringBuilder.Append(staffAttach.TotalAmount.ToString());
            stringBuilder.Append(", ");

            //VAT_Amount
            stringBuilder.Append(staffAttach.VATAmount.ToString());
            stringBuilder.Append(", ");

            //Grand_Total_Amount
            stringBuilder.Append(staffAttach.GrandTotalAmount.ToString());
            stringBuilder.Append(", ");

            //Remark
            stringBuilder.Append(GetDB(staffAttach.AttachRemark));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(", ");

            //BizPac_Code
            stringBuilder.Append(GetDB(staffAttach.CustBizPacCode));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLSpecificInsert(DriverContractChargeBP driverBP)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Service_Staff_DN_Attach ( Customer_Code, Customer_Department_Code, BizPac_Reference_No, Attach_Group, Main_Employee_No, Contract_No, Attach_Line, Customer_Name, Customer_Dept_Name, Employee_Name, Service_Staff_Type, Service_Staff_Name, Plate_No, Basic_Charge_Amount, OT_A_Hour_Allow, OT_A_Amount_Allow,  OT_A_Hour, OT_A_Amount , OT_B_Hour, OT_B_Amount, OT_C_Hour, OT_C_Amount, Holiday_Time, Holiday_Amount , Fix_OT_Amount, Taxi_Times, Taxi_Amount, Telephone_Amount,  Deduction_Amount_Per_Day , Deduction_Days, Deduction_Amount, One_Day_Trip_Far_Times, One_Day_Trip_Far_Amount, One_Day_Trip_Near_Times, One_Day_Trip_Near_Amount, Overnight_Trip_Times, Overnight_Trip_Amount, Other_Charge_Amount, Total_Amount, VAT_Amount, Grand_Total_Amount, Remark, Process_Date, Process_User, BizPac_Code) ");
            stringBuilder.Append(" VALUES ( ");

            //Customer_Code
            stringBuilder.Append(GetDB(driverBP.ACustomer.Code));
            stringBuilder.Append(", ");

            //Customer_Department_Code
            stringBuilder.Append(GetDB(driverBP.CustomerDepartmentCode));
            stringBuilder.Append(", ");

            //BizPac_Reference_No       
            stringBuilder.Append(GetDB(driverBP.BizPacReferenceNo));
            stringBuilder.Append(", ");

            //Attach_Group
            stringBuilder.Append(GetDB(driverBP.AttachGroup));
            stringBuilder.Append(", ");

            //Main_Employee_No
            stringBuilder.Append(GetDB(driverBP.MainEmployeeNo));
            stringBuilder.Append(", ");

            //Contract_No
            stringBuilder.Append(GetDB(driverBP.ContractNumber));
            stringBuilder.Append(", ");

            //Attach_Line
            stringBuilder.Append(GetDB(driverBP.AttachLine));
            stringBuilder.Append(", ");

            //Customer_Name
            stringBuilder.Append(GetDB(driverBP.CustomerShortName));
            stringBuilder.Append(", ");

            //Customer_Dept_Name
            stringBuilder.Append(GetDB(driverBP.CustomerDeptName));
            stringBuilder.Append(", ");

            //Employee_Name
            stringBuilder.Append(GetDB(driverBP.EmployeeName));
            stringBuilder.Append(", ");

            //Service_Staff_Type
            stringBuilder.Append(GetDB(driverBP.ServiceStaffType));
            stringBuilder.Append(", ");

            //Service_Staff_Name
            stringBuilder.Append(GetDB(driverBP.ServiceStaffName));
            stringBuilder.Append(", ");

            //Plate_No
            stringBuilder.Append(GetDB(driverBP.PlateNo));
            stringBuilder.Append(", ");

            //Basic_Charge_Amount
            stringBuilder.Append(GetDB(driverBP.SpecialAmount));
            stringBuilder.Append(", ");

            //OT_A_Hour_Allow
            stringBuilder.Append(GetDB(0));
            stringBuilder.Append(", ");

            //OT_A_Amount_Allow
            stringBuilder.Append(GetDB(0));
            stringBuilder.Append(", ");

            //OT_A_Hour
            stringBuilder.Append(driverBP.OTAHourAdjust.ToString());
            stringBuilder.Append(", ");

            //OT_A_Amount
            stringBuilder.Append(driverBP.OTAAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //OT_B_Hour 
            stringBuilder.Append(driverBP.OTBHourAdjust.ToString());
            stringBuilder.Append(", ");

            //OT_B_Amount
            stringBuilder.Append(driverBP.OTBAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //OT_C_Hour
            stringBuilder.Append(driverBP.OTCHourAdjust.ToString());
            stringBuilder.Append(", ");

            //OT_C_Amount
            stringBuilder.Append(driverBP.OTCAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //Holiday_Time
            stringBuilder.Append(driverBP.HolidayAdjust.ToString());
            stringBuilder.Append(", ");

            //Holiday_Amount
            stringBuilder.Append(driverBP.HolidayAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //Fix_OT_Amount
            stringBuilder.Append(driverBP.FixOTAmount.ToString());
            stringBuilder.Append(", ");

            //Taxi_Times
            stringBuilder.Append(driverBP.TaxiAdjust.ToString());
            stringBuilder.Append(", ");

            //Taxi_Amount
            stringBuilder.Append(driverBP.TaxiAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //Telephone_Amount 
            stringBuilder.Append(GetDB(0));
            stringBuilder.Append(", ");

            //Deduction_Amount_Per_Day
            stringBuilder.Append(GetDB(0));
            stringBuilder.Append(", ");

            //Deduction_Days
            stringBuilder.Append(driverBP.DeducAdjust.ToString());
            stringBuilder.Append(", ");

            //Deduction_Amount
            stringBuilder.Append(driverBP.DeducAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Far_Times
            stringBuilder.Append(driverBP.TripFarAdjust.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Far_Amount 
            stringBuilder.Append(driverBP.TripFarAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Near_Times
            stringBuilder.Append(driverBP.TripNearAdjust.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Near_Amount
            stringBuilder.Append(driverBP.TripNearAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //Overnight_Trip_Times 
            stringBuilder.Append(driverBP.NightTripAdjust.ToString());
            stringBuilder.Append(", ");

            //Overnight_Trip_Amount
            stringBuilder.Append(driverBP.NightTripAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //Other_Charge_Amount
            stringBuilder.Append(driverBP.OtherChargeAmount.ToString());
            stringBuilder.Append(", ");

            //Total_Amount
            stringBuilder.Append(driverBP.TotalAmount.ToString());
            stringBuilder.Append(", ");

            //VAT_Amount
            stringBuilder.Append(driverBP.VATAmount.ToString());
            stringBuilder.Append(", ");

            //Grand_Total_Amount
            stringBuilder.Append(driverBP.GrandTotalAmount.ToString());
            stringBuilder.Append(", ");

            //Remark
            stringBuilder.Append(GetDB(driverBP.ChargeRemark));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(", ");

            //BizPac_Code
            stringBuilder.Append(GetDB(driverBP.CustBizPacCode));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLSpecificInsert(ServiceStaffContractChargeBP staffBP)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Service_Staff_DN_Attach ( Customer_Code, Customer_Department_Code, BizPac_Reference_No, Attach_Group, Main_Employee_No, Contract_No, Attach_Line, Customer_Name, Customer_Dept_Name, Employee_Name, Service_Staff_Type, Service_Staff_Name, Plate_No, Basic_Charge_Amount, OT_A_Hour_Allow, OT_A_Amount_Allow,  OT_A_Hour, OT_A_Amount , OT_B_Hour, OT_B_Amount, OT_C_Hour, OT_C_Amount, Holiday_Time, Holiday_Amount , Fix_OT_Amount, Taxi_Times, Taxi_Amount, Telephone_Amount,  Deduction_Amount_Per_Day , Deduction_Days, Deduction_Amount, One_Day_Trip_Far_Times, One_Day_Trip_Far_Amount, One_Day_Trip_Near_Times, One_Day_Trip_Near_Amount, Overnight_Trip_Times, Overnight_Trip_Amount, Other_Charge_Amount, Total_Amount, VAT_Amount, Grand_Total_Amount, Remark, Process_Date, Process_User, BizPac_Code) ");
            stringBuilder.Append(" VALUES ( ");

            //Customer_Code
            stringBuilder.Append(GetDB(staffBP.ACustomer.Code));
            stringBuilder.Append(", ");

            //Customer_Department_Code
            stringBuilder.Append(GetDB(staffBP.CustomerDepartmentCode));
            stringBuilder.Append(", ");

            //BizPac_Reference_No       
            stringBuilder.Append(GetDB(staffBP.BizPacReferenceNo));
            stringBuilder.Append(", ");

            //Attach_Group
            stringBuilder.Append(GetDB(staffBP.AttachGroup));
            stringBuilder.Append(", ");

            //Main_Employee_No
            stringBuilder.Append(GetDB(staffBP.MainEmployeeNo));
            stringBuilder.Append(", ");

            //Contract_No
            stringBuilder.Append(GetDB(staffBP.ContractNumber));
            stringBuilder.Append(", ");

            //Attach_Line
            stringBuilder.Append(GetDB(staffBP.AttachLine));
            stringBuilder.Append(", ");

            //Customer_Name
            stringBuilder.Append(GetDB(staffBP.CustomerShortName));
            stringBuilder.Append(", ");

            //Customer_Dept_Name
            stringBuilder.Append(GetDB(staffBP.CustomerDeptName));
            stringBuilder.Append(", ");

            //Employee_Name
            stringBuilder.Append(GetDB(staffBP.EmployeeName));
            stringBuilder.Append(", ");

            //Service_Staff_Type
            stringBuilder.Append(GetDB(staffBP.ServiceStaffType));
            stringBuilder.Append(", ");

            //Service_Staff_Name
            stringBuilder.Append(GetDB(staffBP.ServiceStaffName));
            stringBuilder.Append(", ");

            //Plate_No
            stringBuilder.Append(GetDB(staffBP.PlateNo));
            stringBuilder.Append(", ");

            //Basic_Charge_Amount
            stringBuilder.Append(GetDB(staffBP.BasicChargeAmount));
            stringBuilder.Append(", ");

            //OT_A_Hour_Allow
            stringBuilder.Append(staffBP.OTAHourAllow.ToString());
            stringBuilder.Append(", ");

            //OT_A_Amount_Allow
            stringBuilder.Append(staffBP.OTAAmountAllow.ToString());
            stringBuilder.Append(", ");

            //OT_A_Hour
            stringBuilder.Append(staffBP.OTAHourAdjust.ToString());
            stringBuilder.Append(", ");

            //OT_A_Amount
            stringBuilder.Append(staffBP.OTAAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //OT_B_Hour 
            stringBuilder.Append(staffBP.OTBHourAdjust.ToString());
            stringBuilder.Append(", ");

            //OT_B_Amount
            stringBuilder.Append(staffBP.OTBAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //OT_C_Hour
            stringBuilder.Append(staffBP.OTCHourAdjust.ToString());
            stringBuilder.Append(", ");

            //OT_C_Amount
            stringBuilder.Append(staffBP.OTCAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //Holiday_Time
            stringBuilder.Append(staffBP.HolidayAdjust.ToString());
            stringBuilder.Append(", ");

            //Holiday_Amount
            stringBuilder.Append(staffBP.HolidayAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //Fix_OT_Amount
            stringBuilder.Append(staffBP.FixOTAmount.ToString());
            stringBuilder.Append(", ");

            //Taxi_Times
            stringBuilder.Append(staffBP.TaxiAdjust.ToString());
            stringBuilder.Append(", ");

            //Taxi_Amount
            stringBuilder.Append(staffBP.TaxiAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //Telephone_Amount 
            stringBuilder.Append(staffBP.TelephoneAmount.ToString());
            stringBuilder.Append(", ");

            //Deduction_Amount_Per_Day
            stringBuilder.Append(staffBP.DeductionAmountPerDay.ToString());
            stringBuilder.Append(", ");

            //Deduction_Days
            stringBuilder.Append(staffBP.DeducAdjust.ToString());
            stringBuilder.Append(", ");

            //Deduction_Amount
            stringBuilder.Append(staffBP.DeducAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Far_Times
            stringBuilder.Append(staffBP.TripFarAdjust.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Far_Amount 
            stringBuilder.Append(staffBP.TripFarAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Near_Times
            stringBuilder.Append(staffBP.TripNearAdjust.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Near_Amount
            stringBuilder.Append(staffBP.TripNearAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //Overnight_Trip_Times 
            stringBuilder.Append(staffBP.NightTripAdjust.ToString());
            stringBuilder.Append(", ");

            //Overnight_Trip_Amount
            stringBuilder.Append(staffBP.NightTripAmountAdjust.ToString());
            stringBuilder.Append(", ");

            //Other_Charge_Amount
            stringBuilder.Append(staffBP.OtherChargeAmount.ToString());
            stringBuilder.Append(", ");

            //Total_Amount
            stringBuilder.Append(staffBP.TotalAmount.ToString());
            stringBuilder.Append(", ");

            //VAT_Amount
            stringBuilder.Append(staffBP.VATAmount.ToString());
            stringBuilder.Append(", ");

            //Grand_Total_Amount
            stringBuilder.Append(staffBP.GrandTotalAmount.ToString());
            stringBuilder.Append(", ");

            //Remark
            stringBuilder.Append(GetDB(staffBP.ChargeRemark));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(", ");

            //BizPac_Code
            stringBuilder.Append(GetDB(staffBP.CustBizPacCode));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLDelete()
        {
            StringBuilder stringBuilder = new StringBuilder(" DELETE FROM Tr_Service_Staff_DN_Attach WHERE (Process_User = ");
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(") ");
            return stringBuilder.ToString();
        } 
        #endregion

        #region Public Method
        public bool DeleteTrServiceStaffDNAttach()
        {
            return (tableAccess.ExecuteSQL(getSQLDelete()) > 0);
        }

        public string InsertTrServiceStaffDNAttach(IStaffDNAttach iStaffAttach)
        {
            return getSQLInsert(iStaffAttach);
        }

        public string SpecificInsertTrServiceStaffDNAttach(DriverContractChargeBP driverBP)
        {
            return getSQLSpecificInsert(driverBP);
        }

        public string SpecificInsertTrServiceStaffDNAttach(ServiceStaffContractChargeBP staffBP)
        {
            return getSQLSpecificInsert(staffBP);
        }

        public bool ExecuteSQLCommand(string strCommand)
        {
            return (tableAccess.ExecuteSQL(strCommand) > 0);
        } 
        #endregion
    }
}