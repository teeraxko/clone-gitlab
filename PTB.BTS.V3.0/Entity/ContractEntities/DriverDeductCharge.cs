using System;
using System.Collections.Generic;
using System.Text;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
    public class DriverDeductCharge:ICloneable
    {
        private DRIVER_DEDUCT_STATUS _driverDeductStatus = DRIVER_DEDUCT_STATUS.OTHER;
        public DRIVER_DEDUCT_STATUS DriverDeductStatus
        {
            get { return _driverDeductStatus; }
            set { _driverDeductStatus = value; }
        }

        private int _deductAmount = 0;
        public int DeductAmount
        {
            get { return _deductAmount; }
            set { _deductAmount = value; }
        }

        #region ICloneable Members

        public object Clone()
        {
            DriverDeductCharge newObject = new DriverDeductCharge();

            newObject.DriverDeductStatus = this._driverDeductStatus;
            newObject.DeductAmount = this._deductAmount;

            return newObject;
        }

        #endregion
    }
}
