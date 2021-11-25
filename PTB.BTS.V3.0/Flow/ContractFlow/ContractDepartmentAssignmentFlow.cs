using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using DataAccess.ContractDB;
using Entity.AttendanceEntities;
using Entity.Constants;
using Entity.ContractEntities;
using Flow.Comparer;
using ictus.Common.Entity;
using PTB.BTS.Common.Flow;
using PTB.BTS.Contract.Flow;
using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Flow.ContractFlow
{
    public class ContractDepartmentAssignmentFlow : FlowBase
    {
        #region Declaration

        private Company currentCompany;

        //=== key condition variable ===
        private DateTime fromDate;
        private DateTime toDate;

        #endregion

        #region Constructors

        public ContractDepartmentAssignmentFlow() {}

        public ContractDepartmentAssignmentFlow(Company company) 
        {
            this.currentCompany = company;
        }

        #endregion

        #region Properties

        #endregion

        #region Only Business Rule Members (Not connect DB object)

        /// <summary>
        /// Get initialze assigned department list when create new contract base
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public List<ContractDepartmentAssignment> InitializeAssignedDepartment(ContractBase contractNew)
        {
            bool isProcess = true;

            if (contractNew == null)
            {
                isProcess = false;
            }
            else if (contractNew.APeriod == null)
            {
                isProcess = false;
            }
            else if ((contractNew.ACustomerDepartment == null) || (contractNew.ACustomerDepartment.Code == CustomerDepartmentCodeValue.DUMMY))
            {
                isProcess = false;
            }
            else if (this.currentCompany == null)
            {
                isProcess = false;
            }

            if (isProcess)
            {
                ContractDepartmentAssignment assignedDepartment = new ContractDepartmentAssignment();
                assignedDepartment.AssignDepartment = contractNew.ACustomerDepartment;
                assignedDepartment.AssignPeriod = contractNew.APeriod;
                assignedDepartment.Contract = contractNew;
                assignedDepartment.EntityState = EntityState.Added;

                List<ContractDepartmentAssignment> result = new List<ContractDepartmentAssignment>();
                result.Add(assignedDepartment);

                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Sort contract department assignment list by specific column name
        /// </summary>
        /// <param name="sortingList"></param>
        /// <param name="compareType"></param>
        public void Sort(List<ContractDepartmentAssignment> sortingList,string columnName)
        {
            if (sortingList != null)
            {
                ContractDepartmentAssignmentComparer comparer = new ContractDepartmentAssignmentComparer();
                comparer.CompareType = columnName;

                sortingList.Sort(comparer);
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
            this.AssignKeyValue(entityCondition);

            // assign variables

            ContractDepartmentAssignment assignedDepartment;
            var currentList = list.AsEnumerable<ContractDepartmentAssignment>();

            // query by condition

            if ((entityCondition.Contract != null) && (entityCondition.Contract.ContractNo != null))
            {
                currentList = currentList.Where(a => (a.Contract.ContractNo.EntityKey == entityCondition.Contract.ContractNo.EntityKey));
            }
            assignedDepartment = currentList.SingleOrDefault<ContractDepartmentAssignment>(a => ((a.AssignPeriod.From == fromDate) && (a.AssignPeriod.To == toDate) && (a.EntityState != EntityState.Deleted)));

            return assignedDepartment;
        }

        /// <summary>
        /// Create entity condition from condition properties
        /// </summary>
        /// <returns></returns>
        public ContractDepartmentAssignment CreateEntityCondition(ContractBase contractCondition,DateTime fromDateCondition,DateTime toDateCondition)
        {
            ContractDepartmentAssignment entityCondition = new ContractDepartmentAssignment();

            entityCondition.Contract = contractCondition;

            entityCondition.AssignPeriod = new TimePeriod();
            entityCondition.AssignPeriod.From = fromDateCondition;
            entityCondition.AssignPeriod.To = toDateCondition;

            return entityCondition;
        }

        /// <summary>
        /// Create entity condition from condition properties
        /// </summary>
        /// <returns></returns>
        public ContractDepartmentAssignment CreateEntityCondition(string contractNo, TimePeriod timePeriod)
        {
            using (ContractDB dbContract = new ContractDB())
            {
                ContractDepartmentAssignment entityCondition = new ContractDepartmentAssignment();

                entityCondition.Contract = dbContract.GetContract(new DocumentNo(contractNo), this.currentCompany);
                entityCondition.AssignPeriod = timePeriod;

                using (CustomerDB dbCustomer = new CustomerDB())
                {
                    entityCondition.AssignDepartment = new CustomerDepartment();
                    entityCondition.AssignDepartment.ACustomer = dbCustomer.GetCustomer(CustomerCodeValue.TIS, this.currentCompany);
                }

                return entityCondition;
            }
        }

        /// <summary>
        /// Set new contract to contract department assignment list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="contract"></param>
        public void SetContractBaseProperty(List<ContractDepartmentAssignment> list, ContractBase contract)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Contract = contract;
            }
        }

        #endregion

        #region Validate Data Members

        /// <summary>
        /// Overloading of ValidateOverlapPeriod for add new entry mode
        /// </summary>
        /// <param name="list"></param>
        /// <param name="addNewPeriod"></param>
        /// <returns></returns>
        public bool ValidateOverlapPeriod(List<ContractDepartmentAssignment> list, TimePeriod addNewPeriod)
        {
            return this.ValidateOverlapPeriod(list, addNewPeriod, null);
        }

        /// <summary>
        /// Validate for edit period is overlap for update entry mode
        /// </summary>
        /// <param name="entryPeriod"></param>
        /// <returns></returns>
        //public bool ValidateOverlapPeriod(List<ContractDepartmentAssignment> list, TimePeriod entryPeriod, int? currentEditRowIndex)
        public bool ValidateOverlapPeriod(List<ContractDepartmentAssignment> list, TimePeriod newPeriod,TimePeriod oldPeriod)
        {
            if ((list != null) && (list.Count > 0))
            {
                int index = 0;
                bool overlap = false;

                ContractDepartmentAssignment currentEntity = list[index];
                List<ContractDepartmentAssignment> processList = ContractDepartmentAssignmentDB.GetNoneDeleteList(list);

                if (processList.Count > 0)
                {
                    TimePeriod currentPeriod = processList[index].AssignPeriod;

                    while ((index < processList.Count) && (!overlap))
                    {
                        // Case not new mode or current index isn't updated, check overlap.
                        //if ((currentEditRowIndex == null) || (currentEditRowIndex < 0) || (currentEditRowIndex != index))
                        if ((oldPeriod == null) || (!TimePeriod.EqualsByPeriod(oldPeriod,newPeriod)))
                        {
                            overlap = currentPeriod.IsOverlap(newPeriod);
                        }

                        // assign new value to old variables for process in next times (if no exit loop).
                        index++;
                        if (index < processList.Count)
                        {
                            currentPeriod = processList[index].AssignPeriod;
                        }
                    }
                }

                return !overlap;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validate that all members in list are in contract period range.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool ValidateContractPeriodSubRange(List<ContractDepartmentAssignment> list,TimePeriod contractPeriod)
        {
            if ((list != null) && (list.Count > 0))
            {
                // === validate start date ===

                this.Sort(list, ContractDepartmentAssignment.DataPropertyName.ASSIGN_FROM_DATE);
                if (list[0].AssignPeriod.From != contractPeriod.From)
                {
                    return false;
                }

                // === valid end date ===

                this.Sort(list, ContractDepartmentAssignment.DataPropertyName.ASSIGN_TO_DATE);
                if (list[list.Count - 1].AssignPeriod.To != contractPeriod.To)
                {
                    return false;
                }

                return true;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Check that all day in contract period must be assigned department.
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool ValidateAssignFullContractRange(List<ContractDepartmentAssignment> listAll,TimePeriod contractPeriod)
        {
            if ((listAll != null))
            {
                List<ContractDepartmentAssignment> list = ContractDepartmentAssignmentDB.GetNoneDeleteList(listAll);

                if (list.Count > 0)
                {
                    this.Sort(list, ContractDepartmentAssignment.DataPropertyName.ASSIGN_FROM_DATE);

                    DateTime firstFromDate = list[0].AssignFromDate;
                    DateTime lastToDate = list[list.Count - 1].AssignToDate;

                    if (firstFromDate != contractPeriod.From)
                    {
                        return false;
                    }
                    if (lastToDate != contractPeriod.To)
                    {
                        return false;
                    }

                    return true;
                }
                else
                {
                    if (contractPeriod == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (contractPeriod == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region Connect DB Object Members

        /// <summary>
        /// Get contract department assignment by using contract no. condition
        /// </summary>
        /// <param name="contractNo"></param>
        /// <returns></returns>
        public List<ContractDepartmentAssignment> GetListByContract(string contractNo)
        {
            // assign entity condition properties
            ContractDepartmentAssignment entityCondition = new ContractDepartmentAssignment();
            if (!string.IsNullOrEmpty(contractNo))
            {
                entityCondition.Contract = new ContractBase();
                entityCondition.Contract.ContractNo = new DocumentNo(contractNo);
            }
            entityCondition.AssignDepartment = new CustomerDepartment();
            entityCondition.AssignDepartment.ACustomer = new Customer();
            entityCondition.AssignDepartment.ACustomer.Code = CustomerCodeValue.TIS;

            using (ContractDepartmentAssignmentDB dbContractDepartmentAssign = new ContractDepartmentAssignmentDB(this.currentCompany))
            {
                List<ContractDepartmentAssignment> result = dbContractDepartmentAssign.GetListByEntityCondition(entityCondition);

                return result;
            }
        }

        /// <summary>
        /// Get contract department assignment by using contract no. and from date and to date condition
        /// </summary>
        /// <param name="contractNo"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public List<ContractDepartmentAssignment> GetListByContractPeriod(string contractNo, TimePeriod timePeriod)
        {
            //TODO : P'Ya

            // assign entity condition properties
            ContractDepartmentAssignment entityCondition = this.CreateEntityCondition(contractNo, timePeriod);            

            using (ContractDepartmentAssignmentDB dbContractDepartmentAssign = new ContractDepartmentAssignmentDB(this.currentCompany))
            {
                List<ContractDepartmentAssignment> result = dbContractDepartmentAssign.GetListByContractPeriod(entityCondition);

                return result;
            }            
        }

        public List<ContractDepartmentAssignment> GetListByCustomerDepartment(ContractBase contract, CustomerDepartment customerDepartment)
        {
            ContractDepartmentAssignment entityCondition = new ContractDepartmentAssignment();
            entityCondition.Contract = contract;
            entityCondition.AssignDepartment = customerDepartment;

            using (ContractDepartmentAssignmentDB dbContractDepartmentAssign = new ContractDepartmentAssignmentDB(this.currentCompany))
            {
                return dbContractDepartmentAssign.GetListByCustomerDepartment(entityCondition);
            }
        }

        /// <summary>
        /// Save list of contract department assignment
        /// </summary>
        /// <param name="list"></param>
        public bool Save(List<ContractDepartmentAssignment> list)
        {
            if (this.currentCompany == null)
            {
                throw new Exception("Company object cannot be null in Save method at ContractDepartmentAssignmentFlow object.");
            }
            else if ((list == null) || (list.Count <= 0))
            {
                return false;
            }
            else
            {
                using (ContractDepartmentAssignmentDB dbAssignedDepartment = new ContractDepartmentAssignmentDB(this.currentCompany))
                {
                    dbAssignedDepartment.TableAccess.OpenTransaction();
                    try
                    {
                        if (dbAssignedDepartment.Save(list))
                        {
                            dbAssignedDepartment.TableAccess.Transaction.Commit();
                            return true;
                        }
                        else
                        {
                            dbAssignedDepartment.TableAccess.Transaction.Rollback();
                            return false;
                        }
                    }
                    catch (AppExceptionBase exBase)
                    {
                        dbAssignedDepartment.TableAccess.Transaction.Rollback();
                        throw exBase;
                    }
                    catch (Exception ex)
                    {
                        dbAssignedDepartment.TableAccess.Transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        ///// <summary>
        ///// Open transaction
        ///// </summary>
        ///// <param name="dataAccess"></param>
        //public void OpenTransaction()
        //{
        //    if (this.currentCompany == null)
        //    {
        //        throw new Exception("Company object cannot be null in OpenTransaction method at ContractDepartmentAssignmentFlow object.");
        //    }

        //    if (this.dbLayer == null)
        //    {
        //        this.dbLayer = new ContractDepartmentAssignmentDB(this.currentCompany);
        //    }
        //    this.dbLayer.TableAccess.OpenTransaction();
        //}

        ///// <summary>
        ///// Commit transaction
        ///// </summary>
        ///// <param name="dataAccess"></param>
        //public void CommitTransaction()
        //{
        //    this.dbLayer.TableAccess.Transaction.Commit();
        //}

        ///// <summary>
        ///// Rollback transaction
        ///// </summary>
        ///// <param name="dataAccess"></param>
        //public void RollbackTransaction()
        //{
        //    this.dbLayer.TableAccess.Transaction.Rollback();
        //}

        ///// <summary>
        ///// Release resource of data access layer
        ///// </summary>
        //public void ReleaseDataAccess()
        //{
        //    this.dbLayer.Dispose();
        //    this.dbLayer = null;
        //}

        #endregion

        #region Other Members

        /// <summary>
        /// Assign key properties form entity condition to global variables
        /// </summary>
        /// <param name="entityCondition"></param>
        private void AssignKeyValue(ContractDepartmentAssignment entityCondition)
        {
            this.fromDate = entityCondition.AssignPeriod.From;
            this.toDate = entityCondition.AssignPeriod.To;
        }

        #endregion
    }
}
