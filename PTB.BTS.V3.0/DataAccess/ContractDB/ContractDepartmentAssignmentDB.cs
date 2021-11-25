using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using DataAccess.CommonDB;
using DataAccess.Constants;
using DataAccess.PiDB;
using Entity.Constants;
using Entity.ContractEntities;
using Entity.AttendanceEntities;
using ictus.Common.Entity;
using SystemFramework.AppException;

namespace DataAccess.ContractDB
{
    public class ContractDepartmentAssignmentDB : PISDataAccessBase<ContractDepartmentAssignment, Company>
    {
        #region Declaration

        private const string STORED_SELECT = "SSelectContractDepartmentAssignment";
        private const string STORED_SELECT_BY_PERIOD = "SSelectContractDepartmentAssignmentByPeriod";
        private const string STORED_INSERT = "SInsertContractDepartmentAssignment";
        private const string STORED_SELECTBYCUSTDEPT = "SSelectContractDepartmentAssignmentByCustDept";
        private const string STORED_UPDATE_BY_MAX_TODATE = "SUpdateContractDepartmentAssignmentByMaxToDate";

        #endregion

        #region Constructors

        public ContractDepartmentAssignmentDB(Company company) : base(company) { }

        #endregion

        #region PISDataAccessBase Abstract Members

        protected override string TableName
        {
            get 
            { 
                return ContractDepartmentAssignmentTable.NAME; 
            }
        }

        protected override string[] KeyFields
        {
            get 
            {
                string[] fields = new string[] { 
                                            ContractDepartmentAssignmentTable.ColumnName.COMPANY_CODE, 
                                            ContractDepartmentAssignmentTable.ColumnName.CONTRACT_NO,
                                            ContractDepartmentAssignmentTable.ColumnName.FROM_DATE,
                                            ContractDepartmentAssignmentTable.ColumnName.TO_DATE 
                                       };
                return fields;
            }
        }

        protected override string[] OtherFields
        {
            get 
            {
                string[] fields = new string[] { 
                                            ContractDepartmentAssignmentTable.ColumnName.ASSIGNED_DEPARTMENT_CODE, 
                                            ContractDepartmentAssignmentTable.ColumnName.HIRER_NAME
                                       };
                return fields;
            }
        }

        protected override void AddKeyParameters(System.Data.SqlClient.SqlParameterCollection parameters, ContractDepartmentAssignment entity, Company company)
        {
            parameters.Add(tableAccess.CreateParameter("@"+ ContractDepartmentAssignmentTable.ColumnName.COMPANY_CODE, company.CompanyCode));
            parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.CONTRACT_NO, entity.Contract.ContractNo.EntityKey));
            parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.FROM_DATE, entity.AssignPeriod.From));
            parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.TO_DATE, entity.AssignPeriod.To));
        }

        protected override void AddParameters(System.Data.SqlClient.SqlParameterCollection parameters, ContractDepartmentAssignment entity)
        {
            parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.ASSIGNED_DEPARTMENT_CODE, entity.AssignDepartment.Code));
            parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.HIRER_NAME, entity.HirerName));
        }

        protected override void FillDetail(ContractDepartmentAssignment entity, System.Data.SqlClient.SqlDataReader dataReader)
        {
            entity.HirerName = dataReader[ContractDepartmentAssignmentTable.ColumnName.HIRER_NAME].ToString();

            entity.AssignPeriod = new TimePeriod();
            entity.AssignPeriod.From = Convert.ToDateTime(dataReader[ContractDepartmentAssignmentTable.ColumnName.FROM_DATE]);
            entity.AssignPeriod.To = Convert.ToDateTime(dataReader[ContractDepartmentAssignmentTable.ColumnName.TO_DATE]);

            // fill assosiation properties
            entity.Contract = this.getContractBaseByKey(dataReader[ContractDepartmentAssignmentTable.ColumnName.CONTRACT_NO].ToString());
            entity.AssignDepartment = this.getCustomerDepartmentByKey(dataReader[ContractDepartmentAssignmentTable.ColumnName.ASSIGNED_DEPARTMENT_CODE].ToString(), CustomerCodeValue.TIS);
            entity.AssignDepartment.ShortName = dataReader[ContractDepartmentAssignmentTable.ColumnName.DEPARTMENT_SHORT_NAME].ToString();
        }

        #endregion

        #region Get Assosiated Object Methods

        /// <summary>
        /// Retrive contract object by passing primary key
        /// </summary>s
        /// <param name="contractNo"></param>
        /// <returns></returns>
        private ContractBase getContractBaseByKey(string contractNo)
        {
            ContractBase contract = new ContractBase();
            contract.ContractNo = new DocumentNo(contractNo);

            return contract;
        }

        /// <summary>
        /// Retrive department of customer object by passing primary key
        /// </summary>
        /// <param name="customerDepartmentCode"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private CustomerDepartment getCustomerDepartmentByKey(string customerDepartmentCode, string customerCode)
        {
            CustomerDepartment customerDepartment = new CustomerDepartment();

            customerDepartment.Code = customerDepartmentCode;
            customerDepartment.ACustomer = new Customer();
            customerDepartment.ACustomer.Code = customerCode;

            return customerDepartment;
        }

        #endregion

        #region Other Public Methods

        /// <summary>
        /// Get contract department assignment list by using condition in entity properties
        /// </summary>
        /// <param name="entityCondition"></param>
        /// <returns></returns>
        public List<ContractDepartmentAssignment> GetListByEntityCondition(ContractDepartmentAssignment entityCondition)
        {
            using (SqlCommand command = this.tableAccess.CreateCommand(STORED_SELECT))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // find contract no condition
                object contractNo;
                if ((entityCondition.Contract == null) || (entityCondition.Contract.ContractNo == null))
                {
                    contractNo = Convert.DBNull;
                }
                else
                {
                    contractNo = entityCondition.Contract.ContractNo.EntityKey;
                }

                // find customer cod condition
                object customerCode;
                if (entityCondition.AssignDepartment == null)
                {
                    customerCode = Convert.DBNull;
                }
                else if (entityCondition.AssignDepartment.ACustomer == null)
                {
                    customerCode = Convert.DBNull;
                }
                else
                {
                    customerCode = entityCondition.AssignDepartment.ACustomer.Code;
                }

                // add SqlParamter
                command.Parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.COMPANY_CODE, this.currentCompany.CompanyCode));
                command.Parameters.Add(tableAccess.CreateParameter("@" + CustomerDepartmentTable.ColumnName.CUSTOMER_CODE, customerCode));
                command.Parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.CONTRACT_NO, contractNo));

                List<ContractDepartmentAssignment> result = base.FillList(command);

                return result;
            }
        }

        /// <summary>
        /// Get contract department assignment by using contract no. and from date and to date condition
        /// </summary>
        /// <param name="contractNo"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public List<ContractDepartmentAssignment> GetListByContractPeriod(ContractDepartmentAssignment entityCondition)
        {
            using (SqlCommand command = this.tableAccess.CreateCommand(STORED_SELECT_BY_PERIOD))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // add SqlParamter
                command.Parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.COMPANY_CODE, this.currentCompany.CompanyCode));
                command.Parameters.Add(tableAccess.CreateParameter("@" + CustomerDepartmentTable.ColumnName.CUSTOMER_CODE, entityCondition.AssignDepartment.ACustomer.Code));
                command.Parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.CONTRACT_NO, entityCondition.Contract.ContractNo.EntityKey));
                command.Parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.FROM_DATE, entityCondition.AssignPeriod.From));
                command.Parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.TO_DATE, entityCondition.AssignPeriod.To));

                List<ContractDepartmentAssignment> result = base.FillList(command);

                return result;
            }
        }

        /// <summary>
        /// Override insert method base class
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="company"></param>
        public override void Insert(ContractDepartmentAssignment entity,Company company)
        {
            using (SqlCommand command = this.tableAccess.CreateCommand(STORED_INSERT))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // add SqlParamter
                this.AddKeyParameters(command.Parameters, entity, company);
                this.AddParameters(command.Parameters, entity);
                base.AddProcessParameters(command.Parameters);

                this.tableAccess.ExecuteStoredProcedure(command);
            }
        }

        /// <summary>
        /// Save list of contract department assignment by using current object transaction
        /// </summary>
        /// <param name="list"></param>
        public bool Save(List<ContractDepartmentAssignment> list)
        {
            return this.Save(list, null);
        }

        /// <summary>
        /// Save list of contract department assignment by pass table access for using same transaction
        /// </summary>
        /// <param name="list"></param>
        public bool Save(List<ContractDepartmentAssignment> list,TableAccess outerTableAccess)
        {
            if (outerTableAccess != null)
            {
                this.tableAccess = outerTableAccess;
            }

            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    ContractDepartmentAssignment entity = list[i];

                    switch (entity.EntityState)
                    {
                        case EntityState.Added:

                            this.Insert(entity, this.currentCompany);

                            break;

                        case EntityState.Modified:

                            this.Update(entity, this.currentCompany);

                            break;

                        case EntityState.Deleted:

                            this.Delete(entity, this.currentCompany);

                            break;
                    }
                }

                return true;
            }
            catch (SqlException exSql)
            {
                AppExceptionBase exBase = new AppExceptionBase("DataAccess.ContractDB.ContractDepartmentAssignmentDB");
                exBase.SetMessage(exSql.Message);
                throw exBase;
            }
            catch (Exception ex)
            {
                AppExceptionBase exBase = new AppExceptionBase("DataAccess.ContractDB.ContractDepartmentAssignmentDB");
                exBase.SetMessage(ex.Message);
                throw exBase;
            }
        }

        public List<ContractDepartmentAssignment> GetListByCustomerDepartment(ContractDepartmentAssignment entity)
        {
            using (SqlCommand command = this.tableAccess.CreateCommand(STORED_SELECTBYCUSTDEPT))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // add SqlParamter
                command.Parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.COMPANY_CODE, this.currentCompany.CompanyCode));
                command.Parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.CONTRACT_NO, entity.Contract.ContractNo.EntityKey));
                command.Parameters.Add(tableAccess.CreateParameter("@" + ContractDepartmentAssignmentTable.ColumnName.ASSIGNED_DEPARTMENT_CODE, entity.AssignDepartment.Code));

                return base.FillList(command);
            }
        }

        /// <summary>
        /// Update contract assignment when amend contract end date
        /// </summary>
        /// <param name="contractNo"></param>
        /// <param name="toDate"></param>
        public void UpdateByMaxToDate(DocumentNo contractNo, DateTime toDate)
        {
            using (SqlCommand command = this.tableAccess.CreateCommand(STORED_UPDATE_BY_MAX_TODATE))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // add SqlParamter
                command.Parameters.Add(tableAccess.CreateParameter(string.Concat("@", ContractDepartmentAssignmentTable.ColumnName.CONTRACT_NO), contractNo.ToString()));
                command.Parameters.Add(tableAccess.CreateParameter(string.Concat("@", ContractDepartmentAssignmentTable.ColumnName.TO_DATE), toDate.Date));
                base.AddProcessParameters(command.Parameters);

                this.tableAccess.ExecuteStoredProcedure(command);
            }
        }

        #endregion

        #region LINQ Members

        /// <summary>
        /// Query only none delete entity
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<ContractDepartmentAssignment> GetNoneDeleteList(List<ContractDepartmentAssignment> list)
        {
            var queryList = from a in list.AsEnumerable<ContractDepartmentAssignment>()
                            where a.EntityState != EntityState.Deleted
                            select a;

            List<ContractDepartmentAssignment> processList = queryList.ToList<ContractDepartmentAssignment>();

            return processList;
        }

        #endregion
    }
}
