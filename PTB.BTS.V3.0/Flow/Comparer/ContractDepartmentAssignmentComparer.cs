using System;
using System.Collections.Generic;
using System.Text;

using Entity.ContractEntities;

namespace Flow.Comparer
{
    /// <summary>
    /// Implement contract department assignment comparer for sort grid column by selected properties of entity
    /// </summary>
    public class ContractDepartmentAssignmentComparer : IComparer<ContractDepartmentAssignment>
    {
        #region Declaration

        private string compareType = ContractDepartmentAssignment.DataPropertyName.ASSIGN_FROM_DATE;

        #endregion

        #region Properties

        public string CompareType
        {
            get { return this.compareType; }
            set { this.compareType = value; }
        }

        #endregion

        #region IComparer Members

        public int Compare(ContractDepartmentAssignment first, ContractDepartmentAssignment secound)
        {
            if (this.compareType == ContractDepartmentAssignment.DataPropertyName.ASSIGN_FROM_DATE)
            {
                return this.compareToPeriodFrom(first, secound);
            }
            else if (this.compareType == ContractDepartmentAssignment.DataPropertyName.ASSIGN_TO_DATE)
            {
                return this.compareToPeriodTo(first, secound);
            }

            return 0;
        }

        #endregion

        #region Other Members

        /// <summary>
        /// Compare with from date properties
        /// </summary>
        /// <param name="first"></param>
        /// <param name="secound"></param>
        /// <returns></returns>
        private int compareToPeriodFrom(ContractDepartmentAssignment first, ContractDepartmentAssignment secound)
        {
            if ((first.AssignPeriod == null) && (secound.AssignPeriod == null))
            {
                return 0; // equal
            }
            else if (first.AssignPeriod == null)
            {
                return -1; // less than
            }
            else if (secound.AssignPeriod == null)
            {
                return 1; // greater than
            }
            else
            {
                if (first.AssignPeriod.From == secound.AssignPeriod.From)
                {
                    return 0; //equal
                }
                else if (first.AssignPeriod.From < secound.AssignPeriod.From)
                {
                    return -1; // less than
                }
                else
                {
                    return 1; // greater than
                }
            }
        }

        /// <summary>
        /// Compare with to date properties
        /// </summary>
        /// <param name="first"></param>
        /// <param name="secound"></param>
        /// <returns></returns>
        private int compareToPeriodTo(ContractDepartmentAssignment first, ContractDepartmentAssignment secound)
        {
            if ((first.AssignPeriod == null) && (secound.AssignPeriod == null))
            {
                return 0; // equal
            }
            else if (first.AssignPeriod == null)
            {
                return -1; // less than
            }
            else if (secound.AssignPeriod == null)
            {
                return 1; // greater than
            }
            else
            {
                if (first.AssignPeriod.To == secound.AssignPeriod.To)
                {
                    return 0; //equal
                }
                else if (first.AssignPeriod.To < secound.AssignPeriod.To)
                {
                    return -1; // less than
                }
                else
                {
                    return 1; // greater than
                }
            }
        }

        #endregion
    }
}
