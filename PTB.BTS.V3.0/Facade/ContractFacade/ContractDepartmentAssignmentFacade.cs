using System;
using System.Collections.Generic;
using System.Text;

using Entity.AttendanceEntities;
using Entity.ContractEntities;
using Facade.PiFacade;
using Flow.ContractFlow;
using ictus.Common.Entity;

namespace Facade.ContractFacade
{
    public class ContractDepartmentAssignmentFacade : CommonPIFacadeBase
    {
        #region Declaration

        private ContractDepartmentAssignmentFlow flow;

        #endregion

        #region Constructors

        public ContractDepartmentAssignmentFacade()
        {
            this.flow = new ContractDepartmentAssignmentFlow();
        }

        #endregion

        #region FacadeBase Members

        /// <summary>
        /// Polymorphism method to do something on dispose object
        /// </summary>
        protected override void OnDisposeObject()
        {
            base.OnDisposeObject();

            this.flow.Dispose();
            this.flow = null;
        }

        #endregion

        #region Static Members

        /// <summary>
        /// Set new contract to contract department assignment list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="contract"></param>
        public static void SetContractBaseProperty(List<ContractDepartmentAssignment> list, ContractBase contract)
        {
            using (ContractDepartmentAssignmentFlow flow = new ContractDepartmentAssignmentFlow())
            {
                flow.SetContractBaseProperty(list, contract);
            }
        }

        #endregion

        #region None Static Members

        /// <summary>
        /// Get contract department assignment by using contract no. condition
        /// </summary>
        /// <param name="contractNo"></param>
        /// <returns></returns>
        public List<ContractDepartmentAssignment> GetListByContract(string contractNo)
        {
            Company currentCompany = this.GetCompany();

            using (ContractDepartmentAssignmentFlow flow = new ContractDepartmentAssignmentFlow(currentCompany))
            {
                List<ContractDepartmentAssignment> result = flow.GetListByContract(contractNo);

                return result;
            }
        }

        /// <summary>
        /// Get initialze assigned department list when create new contract base
        /// </summary>
        /// <param name="contractNew"></param>
        /// <returns></returns>
        public List<ContractDepartmentAssignment> InitializeAssignedDepartment(ContractBase contractNew)
        {
            using (ContractDepartmentAssignmentFlow flow = new ContractDepartmentAssignmentFlow(this.GetCompany()))
            {
                List<ContractDepartmentAssignment> result = flow.InitializeAssignedDepartment(contractNew);

                return result;
            }
        }

        /// <summary>
        /// Sort contract department assignment list by specific column name
        /// </summary>
        /// <param name="sortingList"></param>
        /// <param name="compareType"></param>
        public void Sort(List<ContractDepartmentAssignment> sortingList, string columnName)
        {
            using (ContractDepartmentAssignmentFlow flow = new ContractDepartmentAssignmentFlow())
            {
                flow.Sort(sortingList, columnName);
            }
        }

        /// <summary>
        /// Validate that all members in list are in contract period range.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool ValidateContractPeriodSubRange(List<ContractDepartmentAssignment> list,TimePeriod contractPeriod)
        {
            using (ContractDepartmentAssignmentFlow flow = new ContractDepartmentAssignmentFlow())
            {
                return flow.ValidateContractPeriodSubRange(list,contractPeriod);
            }
        }

        /// <summary>
        /// Validate for edit period is overlap for add entry mode
        /// </summary>
        /// <param name="list"></param>
        /// <param name="newPeriod"></param>
        /// <param name="oldPeriod"></param>
        /// <returns></returns>
        public bool ValidateOverlapPeriod(List<ContractDepartmentAssignment> list, TimePeriod addNewPeriod)
        {
            using (ContractDepartmentAssignmentFlow flow = new ContractDepartmentAssignmentFlow())
            {
                return flow.ValidateOverlapPeriod(list, addNewPeriod);
            }
        }

        /// <summary>
        /// Validate for edit period is overlap for update entry mode
        /// </summary>
        /// <param name="entryPeriod"></param>
        /// <returns></returns>
        //public bool ValidateOverlapPeriod(List<ContractDepartmentAssignment> list, TimePeriod entryPeriod, int currentEditRowIndex)
        public bool ValidateOverlapPeriod(List<ContractDepartmentAssignment> list, TimePeriod newPeriod, TimePeriod oldPeriod)
        {
            using (ContractDepartmentAssignmentFlow flow = new ContractDepartmentAssignmentFlow())
            {
                return flow.ValidateOverlapPeriod(list, newPeriod, oldPeriod);
            }
        }

        /// <summary>
        /// Search object form list by search entity condition
        /// </summary>
        /// <param name="list"></param>
        /// <param name="entityCondition"></param>
        /// <returns></returns>
        public ContractDepartmentAssignment GetSingleOrDefaultByKey(List<ContractDepartmentAssignment> list, ContractDepartmentAssignment entityCondition)
        {
            using (ContractDepartmentAssignmentFlow flow = new ContractDepartmentAssignmentFlow(this.GetCompany()))
            {
                return flow.GetSingleOrDefaultByKey(list, entityCondition);
            }
        }

        /// <summary>
        /// Save list of contract department assignment
        /// </summary>
        /// <param name="list"></param>
        public bool Save(List<ContractDepartmentAssignment> list)
        {
            using (ContractDepartmentAssignmentFlow flow = new ContractDepartmentAssignmentFlow(this.GetCompany()))
            {
                bool result = flow.Save(list);

                return result;
            }
        }

        /// <summary>
        /// Create entity condition from condition properties
        /// </summary>
        /// <returns></returns>
        public ContractDepartmentAssignment CreateEntityCondition(ContractBase contractCondition, DateTime fromDateCondition, DateTime toDateCondition)
        {
            using (ContractDepartmentAssignmentFlow flow = new ContractDepartmentAssignmentFlow())
            {
                return flow.CreateEntityCondition(contractCondition, fromDateCondition, toDateCondition);
            }
        }

        /// <summary>
        /// Check that all day in contract period must be assigned department.
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool ValidateAssignFullContractRange(List<ContractDepartmentAssignment> list, TimePeriod contractPeriod)
        {
            return this.flow.ValidateAssignFullContractRange(list,contractPeriod);
        }

        #endregion
    }
}
