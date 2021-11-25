using System;

using PTB.BTS.Common.Flow;
using ictus.Common.Entity;

using DataAccess.ContractDB.ContractChargeRateDB;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace Flow.ContractFlow.ContractChargeRateFlow
{
    public class ChargeRateByServiceStaffTypeFlow : FlowBase
    {
        #region Private Variable
        private ChargeRateByServiceStaffTypeDB dbChargeRateByServiceStaffType; 
        #endregion

        #region Constructor
        public ChargeRateByServiceStaffTypeFlow()
            : base()
        {
            dbChargeRateByServiceStaffType = new ChargeRateByServiceStaffTypeDB();
        }

        #endregion

        #region Public Method
        public bool FillChargeRateByServiceStaffType(ChargeRateByServiceStaffType value, Company company)
        {
            return dbChargeRateByServiceStaffType.FillChargeRateByServiceStaffType(value, company);
        }

        public bool FillChargeRateByServiceStaffTypeList(ChargeRateByServiceStaffTypeList value)
        {
            return dbChargeRateByServiceStaffType.FillChargeRateByServiceStaffTypeList(value);
        }

        public bool InsertChargeRateByServiceStaffType(ChargeRateByServiceStaffType value, Company company)
        {
            return dbChargeRateByServiceStaffType.InsertChargeRateByServiceStaffType(value, company);
        }

        public bool UpdateChargeRateByServiceStaffType(ChargeRateByServiceStaffType value, Company company)
        {
            return dbChargeRateByServiceStaffType.UpdateChargeRateByServiceStaffType(value, company);
        }

        public bool DeleteChargeRateByServiceStaffType(ChargeRateByServiceStaffType value, Company company)
        {
            return dbChargeRateByServiceStaffType.DeleteChargeRateByServiceStaffType(value, company);
        } 
        #endregion
    }
}
