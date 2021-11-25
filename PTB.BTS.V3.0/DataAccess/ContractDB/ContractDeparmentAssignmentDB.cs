using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using Entity.ContractEntities;
using ictus.Common.Entity;

namespace DataAccess.ContractDB
{
    public class ContractDeparmentAssignmentDB : PISDataAccessBase<ContractDepartmentAssignment, Company>
    {
        protected override string TableName
        {
            get { throw new NotImplementedException(); }
        }

        protected override string[] KeyFields
        {
            get { throw new NotImplementedException(); }
        }

        protected override string[] OtherFields
        {
            get { throw new NotImplementedException(); }
        }

        protected override void AddKeyParameters(System.Data.SqlClient.SqlParameterCollection parameters, ContractDepartmentAssignment entity, Company company)
        {
            throw new NotImplementedException();
        }

        protected override void AddParameters(System.Data.SqlClient.SqlParameterCollection parameters, ContractDepartmentAssignment entity)
        {
            throw new NotImplementedException();
        }

        protected override void FillDetail(ContractDepartmentAssignment entity, System.Data.SqlClient.SqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }
    }
}
