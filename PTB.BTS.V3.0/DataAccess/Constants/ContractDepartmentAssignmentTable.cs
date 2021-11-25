using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Constants
{
    public static class ContractDepartmentAssignmentTable
    {
        public static readonly string NAME = "Contract_Department_Assignment";

        public static class ColumnName
        {
            public static readonly string COMPANY_CODE = "Company_Code";
            public static readonly string CONTRACT_NO = "Contract_No";
            public static readonly string FROM_DATE = "From_Date";
            public static readonly string TO_DATE = "To_Date";
            public static readonly string ASSIGNED_DEPARTMENT_CODE = "Assigned_Department_Code";
            public static readonly string HIRER_NAME = "Hirer_Name";
            public static readonly string DEPARTMENT_SHORT_NAME = "Department_Short_Name";
        }
    }
}
