using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.Common.Flow;
using Entity.ContractEntities;
using DataAccess.ContractDB;

namespace Flow.ContractFlow
{
    public class CustomerContractAssignmentFlow : FlowBase
    {
        public List<CustomerContractAssignment> GetByCustomerContract(Contract contract, Customer customer)
        {
            using (CustomerContractAssignmentDB db = new CustomerContractAssignmentDB())
            {
                return db.GetByCustomerContract(contract, customer);
            }
        }
    }
}
