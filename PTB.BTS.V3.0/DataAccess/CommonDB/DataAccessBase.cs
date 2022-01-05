using System;
using System.Collections;
using System.Text;

using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;
using System.Data;
using System.Data.SqlClient;
using SystemFramework.AppConfig;
using System.Globalization;

namespace DataAccess.CommonDB
{
    public abstract class DataAccessBase : IDisposable
    {
        #region - Private -
        private bool disposed = false;
        #endregion

        #region Property
        protected TableAccess tableAccess;
        public TableAccess TableAccess
        {
            get
            {
                return tableAccess;
            }
            set
            {
                tableAccess = value;
            }
        }
        #endregion

        #region Constructor
        protected DataAccessBase()
        {
            tableAccess = new TableAccess();
        }

        protected DataAccessBase(TableAccess value)
        {
            tableAccess = value;
        }

        #endregion

        #region - Protected Method -
        //------------------------------------------------------------
        protected string GetDateDB()
        { return "GETDATE()"; }

        protected bool GetBool(string value)
        {
            if (value.ToUpper().Trim() == "Y")
            { return true; }
            else
            { return false; }
        }

        protected void AddProcessParameters(IDataParameterCollection parameters)
        {
            parameters.Add(new SqlParameter("@Process_Date", DateTime.Today));
            parameters.Add(new SqlParameter("@Process_User", UserProfile.UserID));
        } 
        #endregion

        #region - GetDB -
        //------------------------------ get normal type ------------------------------
        protected string GetDB(string value)
        {
            if (value != null)
            {
                return "'" + value.Replace("'", "''") + "'";
            }
            else
            {
                return value;
            }
        }

        protected string GetDB(decimal value)
        { return (value == NullConstant.DECIMAL) ? "NULL" : value.ToString(); }

        protected string GetDB(double value)
        { return (value == NullConstant.DOUBLE) ? "NULL" : value.ToString(); }

        protected string GetDB(float value)
        { return (value == NullConstant.FLOAT) ? "NULL" : value.ToString(); }

        protected string GetDB(int value)
        { return (value == NullConstant.INT) ? "NULL" : value.ToString(); }

        protected string GetDB(DateTime value)
        {
            if (value == NullConstant.DATETIME)
            {
                return " NULL ";
            }
            else
            {
                // Kriangkrai A.
                return "CONVERT(DATETIME, '" + value.Year + value.ToString("-MM-dd HH:mm:ss") + "', 102)";
                //return "CONVERT(DATETIME, '" + value.ToString("dd/MM/yyyy HH:mm:ss", new CultureInfo("en-US", false)) + "', 103)";
            }
        }

        protected string GetDB(bool value)
        { return (value) ? "'Y'" : "'N'"; }


        //------------------------------ get common type ------------------------------
        protected string GetDB(IN_OUT_STATUS_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(OT_RATE_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(WORKINGDAY_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(PERIOD_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(SHIFT_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(WHOLE_RATE_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(PAYMENT_STATUS_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(BENEFIT_CODE_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(HIRE_DATE_STATUS_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(PAYROLL_SUBMIT_STATUS_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(KIND_OF_OT_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(GEAR_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(BREAK_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(POSITION_ROLE_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(PLATE_STATUS value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(GENDER_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(DRIVER_LICENSE_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(ASSIGNMENT_ROLE_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(DOCUMENT_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(EDUCATION_STATUS_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(EXPENSE_STATUS_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(REPAIRING_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(SECOND_HAND_STATUS_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(PAYER_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(RATE_STATUS_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(LEAVE_PERIOD_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(PROCESS_STATUS_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(PURCHAS_STATUS_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(PositionType value)
        { return GetDB(value.Type); }

        protected string GetDB(VehicleStatus value)
        { return GetDB(value.Code); }

        protected string GetDB(KindOfVehicle value)
        { return GetDB(value.Code); }

        protected string GetDB(ContractStatus value)
        { return GetDB(value.Code); }

        protected string GetDB(ContractType value)
        { return GetDB(value.Code); }

        protected string GetDB(KindOfContract value)
        { return GetDB(value.Code); }

        protected string GetDB(LEAVE_YEAR_STATUS_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(TAX_INVOICE_STATUS_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(DIFFERENCE_STATUS_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(KIND_OF_RENTAL_TYPE value)
        { return GetDB(CTFunction.GetString(value)); }

        protected string GetDB(DRIVER_DEDUCT_STATUS value)
        { return GetDB(CTFunction.GetString(value)); }

        //D21018 get model type id
        protected string GetDB(ModelType value)
        { 
            return GetDB(value.Model_Type); 
        }
        #endregion

        #region - IsNotNULL -
        protected bool IsNotNULL(string value)
        { return (bool)(value != NullConstant.STRING); }

        protected bool IsNotNULL(decimal value)
        { return (bool)(value != NullConstant.DECIMAL); }

        protected bool IsNotNULL(float value)
        { return (bool)(value != NullConstant.FLOAT); }

        protected bool IsNotNULL(int value)
        { return (bool)(value != NullConstant.INT); }

        protected bool IsNotNULL(DateTime value)
        { return (bool)(value != NullConstant.DATETIME); }

        protected bool IsNotNULL(YearMonth value)
        { return (bool)(value.DateTime != NullConstant.DATETIME); }


        protected bool IsNotNULL(System.Guid value)
        { return (bool)(value.CompareTo(null) != 0); }

        protected bool IsNotNULL(IN_OUT_STATUS_TYPE value)
        { return (bool)(value != IN_OUT_STATUS_TYPE.NULL); }

        protected bool IsNotNULL(OT_RATE_TYPE value)
        { return (bool)(value != OT_RATE_TYPE.NULL); }

        protected bool IsNotNULL(WORKINGDAY_TYPE value)
        { return (bool)(value != WORKINGDAY_TYPE.NULL); }

        protected bool IsNotNULL(PERIOD_TYPE value)
        { return (bool)(value != PERIOD_TYPE.NULL); }

        protected bool IsNotNULL(SHIFT_TYPE value)
        { return (bool)(value != SHIFT_TYPE.NULL); }

        protected bool IsNotNULL(WHOLE_RATE_TYPE value)
        { return (bool)(value != WHOLE_RATE_TYPE.NULL); }

        protected bool IsNotNULL(PAYMENT_STATUS_TYPE value)
        { return (bool)(value != PAYMENT_STATUS_TYPE.NULL); }

        protected bool IsNotNULL(BENEFIT_CODE_TYPE value)
        { return (bool)(value != BENEFIT_CODE_TYPE.NULL); }

        protected bool IsNotNULL(HIRE_DATE_STATUS_TYPE value)
        { return (bool)(value != HIRE_DATE_STATUS_TYPE.NULL); }

        protected bool IsNotNULL(PAYROLL_SUBMIT_STATUS_TYPE value)
        { return (bool)(value != PAYROLL_SUBMIT_STATUS_TYPE.NULL); }

        protected bool IsNotNULL(KIND_OF_OT_TYPE value)
        { return (bool)(value != KIND_OF_OT_TYPE.NULL); }

        protected bool IsNotNULL(GEAR_TYPE value)
        { return (bool)(value != GEAR_TYPE.NULL); }

        protected bool IsNotNULL(BREAK_TYPE value)
        { return (bool)(value != BREAK_TYPE.NULL); }

        protected bool IsNotNULL(POSITION_ROLE_TYPE value)
        { return (bool)(value != POSITION_ROLE_TYPE.NULL); }

        protected bool IsNotNULL(ASSIGNMENT_ROLE_TYPE value)
        { return (bool)(value != ASSIGNMENT_ROLE_TYPE.NULL); }

        protected bool IsNotNULL(DOCUMENT_TYPE value)
        { return (bool)(value != DOCUMENT_TYPE.NULL); }

        protected bool IsNotNULL(REPAIRING_TYPE value)
        { return (bool)(value != REPAIRING_TYPE.NULL); }

        protected bool IsNotNULL(RATE_STATUS_TYPE value)
        { return (bool)(value != RATE_STATUS_TYPE.NULL); }

        protected bool IsNotNULL(LEAVE_PERIOD_TYPE value)
        { return (bool)(value != LEAVE_PERIOD_TYPE.NULL); }

        protected bool IsNotNULL(PROCESS_STATUS_TYPE value)
        { return (bool)(value != PROCESS_STATUS_TYPE.NULL); }

        protected bool IsNotNULL(ListBase value)
        { return (bool)(value.Count > 0); }

        protected bool IsNotNULL(PositionType value)
        { return (bool)(value.Type != NullConstant.STRING); }

        protected bool IsNotNULL(VehicleStatus value)
        { return (bool)(value.Code != NullConstant.STRING); }

        protected bool IsNotNULL(KindOfVehicle value)
        { return (bool)(value.Code != NullConstant.STRING); }

        protected bool IsNotNULL(ContractStatus value)
        { return (bool)(value.Code != NullConstant.STRING); }

        protected bool IsNotNULL(ContractType value)
        { return (bool)(value.Code != NullConstant.STRING); }

        protected bool IsNotNULL(KindOfContract value)
        { return (bool)(value.Code != NullConstant.STRING); }

        protected bool IsNotNULL(TAX_INVOICE_STATUS_TYPE value)
        { return (bool)(value != TAX_INVOICE_STATUS_TYPE.NULL); }
        #endregion

        #region DBValue
        protected object DBValue(string value)
        {
            if (value == null)
                return DBNull.Value;
            else
                return value;
        }

        protected object DBValue(int? value)
        {
            if (value.HasValue)
                return value.Value;
            else
                return DBNull.Value;
        }

        protected object DBValue(DateTime? value)
        {
            if (value.HasValue)
                return value.Value;
            else
                return DBNull.Value;
        }

        protected object DBValue(byte? value)
        {
            if (value.HasValue)
                return value.Value;
            else
                return DBNull.Value;
        }

        protected object DBValue(decimal? value)
        {
            if (value.HasValue)
                return value.Value;
            else
                return DBNull.Value;
        }
        #endregion

        #region - getBaseCondition -
        protected virtual string getBaseCondition(Employee aEmployee)
        {
            StringBuilder stringBuilder = new StringBuilder(getBaseCondition(aEmployee.Company));
            stringBuilder.Append(" AND (Employee_No = ");
            stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        protected virtual string getBaseCondition(Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" WHERE (Company_Code = ");
            if (aCompany == null)
            {
                stringBuilder.Append(" '12' ");
            }
            else
            {
                stringBuilder.Append(GetDB(aCompany.CompanyCode));
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        protected virtual string getBaseCondition()
        {
            StringBuilder stringBuilder = new StringBuilder(" WHERE 1=1 ");
            return stringBuilder.ToString();
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }
            }
            disposed = true;
        }

        ~DataAccessBase()
        {
            Dispose(false);
        }
        #endregion
    }
}
