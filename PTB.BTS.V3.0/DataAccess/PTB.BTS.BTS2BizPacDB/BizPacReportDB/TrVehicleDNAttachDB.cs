using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using PTB.BTS.BTS2BizPacEntity;
using Entity.ContractEntities;
using SystemFramework.AppConfig;

namespace PTB.BTS.BTS2BizPacDB.BizPacReportDB
{
    public class TrVehicleDNAttachDB : DataAccessBase
    {
        //============================== Constructor ==============================
        public TrVehicleDNAttachDB()
            : base()
        {
        }

        //============================== Private Method ==============================
        private string getSQLInsert(VehicleDNAttach vehicleDNAttach)
        {
            
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Vehicle_DN_Attach (  Kind_Of_Contract, BizPac_Customer_Code, BizPac_Reference_No, Attach_Group, Customer_Department_Code, Plate_No, Contract_No, Customer_Name, Dept_Short_Name, Brand_Model_Name, Hirer_Name, Rate_Status, Monthly_Charge, Charge_Amount, VAT_Amount, Process_Date, Process_User, BizPac_Code) ");
            stringBuilder.Append(" VALUES ( ");

            //Kind_Of_Contract
            stringBuilder.Append(GetDB(vehicleDNAttach.AKindOfContract.Code));
            stringBuilder.Append(", ");

            //BizPac_Customer_Code
            stringBuilder.Append(GetDB(vehicleDNAttach.ACustomer.Code));
            stringBuilder.Append(", ");

            //BizPac_Reference_No
            stringBuilder.Append(GetDB(vehicleDNAttach.BizPacRefNo));
            stringBuilder.Append(", ");

            //Attach_Group
            stringBuilder.Append(GetDB(vehicleDNAttach.AttachGroup));
            stringBuilder.Append(", ");

            //Customer_Department_Code
            stringBuilder.Append(GetDB(vehicleDNAttach.ACustomerDepartment.Code));
            stringBuilder.Append(", ");

            //Plate_No
            stringBuilder.Append(GetDB(vehicleDNAttach.Vehicle.PlateNumber));
            stringBuilder.Append(", ");

            //Contract_No
            stringBuilder.Append(GetDB(vehicleDNAttach.ContractNo.ToString()));
            stringBuilder.Append(", ");

            //Customer_Name
            stringBuilder.Append(GetDB(vehicleDNAttach.ACustomer.ShortName));
            stringBuilder.Append(", ");

            //Dept_Short_Name
            stringBuilder.Append(GetDB(vehicleDNAttach.ACustomerDepartment.ShortName));
            stringBuilder.Append(", ");

            //Brand_Model_Name
            stringBuilder.Append(GetDB(vehicleDNAttach.BrandModelName));
            stringBuilder.Append(", ");

            //Hirer_Name
            stringBuilder.Append(GetDB(vehicleDNAttach.Hirer.Name));
            stringBuilder.Append(", ");

            //Rate_Status
            stringBuilder.Append(GetDB(vehicleDNAttach.RateStatus));
            stringBuilder.Append(", ");

            //Monthly_Charge
            stringBuilder.Append(GetDB(vehicleDNAttach.ContractCharge.UnitChargeAmount));
            stringBuilder.Append(", ");

            //Charge_Amount
            stringBuilder.Append(GetDB(vehicleDNAttach.ChargeAmount));
            stringBuilder.Append(", ");

            //VAT_Amount
            stringBuilder.Append(GetDB(vehicleDNAttach.VATAmount));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(", ");


            //BizPac_Code
            stringBuilder.Append(GetDB(vehicleDNAttach.ACustomer.BizPacCode));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLDelete()
        {
            return " DELETE FROM Tr_Vehicle_DN_Attach ";
        }

        //		============================== Public Method ==============================
        public bool InsertTrVehicleDNAttach(BTS2BizPacList vehicleDNAttachList)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < vehicleDNAttachList.Count; i++)
            {
                stringBuilder.Append(getSQLInsert((VehicleDNAttach)vehicleDNAttachList[i]));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteTrVehicleDNAttach()
        {
            return (tableAccess.ExecuteSQL(getSQLDelete()) > 0);
        }
    }
}
