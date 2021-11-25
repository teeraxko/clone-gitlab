using System;
using System.Collections.Generic;
using System.Text;

using Entity.AttendanceEntities;
using Entity.Constants;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.General;

namespace Entity.ContractEntities
{
    /// <summary>
    /// Assignment collection in contract
    /// </summary>
    public class ContractDepartmentAssignment : EntityBase, IKey
    {
        #region Declaration

        public static class DataPropertyName
        {
            public static readonly string DEPARTMENT_SHORT_NAME = "DepartmentShortName";
            public static readonly string DEPARTMENT_CODE = "DepartmentCode";
            public static readonly string ASSIGN_FROM_DATE = "AssignFromDate";
            public static readonly string ASSIGN_TO_DATE = "AssignToDate";
            public static readonly string HIRER_NAME = "HirerName";
        }

        #endregion

        #region Property

        public string HirerName { get; set; }

        public ContractBase Contract { get; set; }
        public CustomerDepartment AssignDepartment { get; set; }
        public TimePeriod AssignPeriod { get; set; }
        public EntityState EntityState { get; set; }        

        // Derived properties

        public string DepartmentCode
        {
            get
            {
                if (this.AssignDepartment != null)
                {
                    return this.AssignDepartment.Code;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string DepartmentShortName
        {
            get
            {
                if (this.AssignDepartment != null)
                {
                    return this.AssignDepartment.ShortName;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public DateTime AssignFromDate
        {
            get
            {
                if (this.AssignPeriod != null)
                {
                    return this.AssignPeriod.From;
                }
                else
                {
                    return NullConstant.DATETIME;
                }
            }
        }
        public DateTime AssignToDate
        {
            get
            {
                if (this.AssignPeriod != null)
                {
                    return this.AssignPeriod.To;
                }
                else
                {
                    return NullConstant.DATETIME;
                }
            }
        }

        #endregion

        #region Constructors

        public ContractDepartmentAssignment()
        {
            this.HirerName = string.Empty;
            this.EntityState = EntityState.Unchanged;
        }

        #endregion

        #region Public Method

        public override string EntityKey
        {
            get { return string.Concat(Contract.EntityKey, AssignPeriod.EntityKey); }
        }

        public static bool EqualByKey(ContractDepartmentAssignment assigned1,ContractDepartmentAssignment assigned2)
        {
            if (!ContractBase.EqualsByKey(assigned1.Contract, assigned2.Contract))
            {
                return false;
            }
            else if (!TimePeriod.EqualsByPeriod(assigned1.AssignPeriod, assigned2.AssignPeriod))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region Other Methods

        #endregion
    }
}
