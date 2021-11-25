using System;
using System.Collections.Generic;
using System.Text;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.General;
using Entity.AttendanceEntities;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
    public class VehicleChargeDiff : EntityBase, IKey
    {
        //============================== Constructor ==============================
        public VehicleChargeDiff()
            : base()
        {
            assignPrevious = new TimePeriod();
            assignCurrent = new TimePeriod();
        }

        //============================== Property ==============================
        private int vehicleNo = NullConstant.INT;
        public int VehicleNo
        {
            get { return vehicleNo; }
            set { vehicleNo = value; }
        }

        private string customerCode = string.Empty;
        public string CustomerCode
        {
            get { return customerCode; }
            set { customerCode = value.Trim(); }
        }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { description = value.Trim(); }
        }

        private decimal chargePrevious = decimal.Zero;
        public decimal ChargePrevious
        {
            get { return chargePrevious; }
            set { chargePrevious = value; }
        }

        private decimal chargeCurrent = decimal.Zero;
        public decimal ChargeCurrent
        {
            get { return chargeCurrent; }
            set { chargeCurrent = value; }
        }

        public decimal ChargeDiff
        {
            get { return ChargeCurrent - ChargePrevious; }
        }
            
        private TimePeriod assignPrevious;
        public TimePeriod AssignPrevious
        {
            get { return assignPrevious; }
            set { assignPrevious = value; }
        }

        private int assignmentPreviousCount = 0;
        public int AssignmentPreviousCount
        {
            get { return assignmentPreviousCount; }
            set { assignmentPreviousCount = value; }
        }	

        private TimePeriod assignCurrent;
        public TimePeriod AssignCurrent
        {
            get { return assignCurrent; }
            set { assignCurrent = value; }
        }

        private int assignmentCurrentCount = 0;
        public int AssignmentCurrentCount
        {
            get { return assignmentCurrentCount; }
            set { assignmentCurrentCount = value; }
        }

        private DIFFERENCE_STATUS_TYPE differenceStatus = DIFFERENCE_STATUS_TYPE.NO;
        public DIFFERENCE_STATUS_TYPE DifferenceStatus
        {
            get { return differenceStatus; }
            set { differenceStatus = value; }
        }
        #region IKey Members

        public override string EntityKey
        {
            get { return vehicleNo.ToString() + customerCode; }
        }
       

        #endregion
    }
}
