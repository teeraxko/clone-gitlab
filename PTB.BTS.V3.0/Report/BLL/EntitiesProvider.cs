using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Report.BLL {
    internal class EntitiesProvider {
        public static DataTable BrandDataTable() {
            SqlConnection conn = DBCommon.GetDataConnection();
            string strSQL = "select Brand_Code,Brand_English_Name,Brand_Thai_Name from brand";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable ModelDataTable(string brandCode) {
            SqlConnection conn = DBCommon.GetDataConnection();
            string strSQL = "select Brand_Code,Model_Code,Model_English_Name,Model_Thai_Name from Model where Brand_Code = '" + brandCode + "'";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable CustomerDataTable() {
            SqlConnection conn = DBCommon.GetDataConnection();
            string strSQL = "select Customer_Code,English_Name,Thai_Name from customer where Customer_Code <> 'ZZZZZZ'";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }


        public static DataTable QuotationStatusDataTable()
        {
            SqlConnection conn = DBCommon.GetDataConnection();
            string strSQL = "select Quotation_Status from Vehicle_Quotation group by Quotation_Status";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }





        public static DataTable EmployeeSerach(string citizenID, string firstName, string lastName) {
            SqlConnection conn = DBCommon.GetDataConnection();
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT ");
            sb.Append("     Employee.Employee_No, ");
            sb.Append("     Employee.ID_Card_No, ");
            sb.Append("     Employee.Thai_Prefix, ");
            sb.Append("     Employee.Thai_Name, ");
            sb.Append("     Employee.Thai_Surname, ");
            sb.Append("     Employee.Hire_Date, ");
            sb.Append("     Working_Status.Thai_Description, ");
            sb.Append("     Employee.Termination_Date, ");
            sb.Append("     Employee.Termination_Reason ");
            sb.Append(" FROM Employee INNER JOIN Working_Status ON ");
            sb.Append("     Employee.Company_Code =  Working_Status.Company_Code AND ");
            sb.Append("     Employee.Working_Status =  Working_Status.Working_Status ");
            sb.Append(" WHERE ");
            sb.Append("     Employee.ID_Card_No LIKE @CitizenID AND ");
            sb.Append("     Employee.Thai_Name LIKE @FirstName AND ");
            sb.Append("     Employee.Thai_Surname LIKE @LastName ");
            sb.Append(" ORDER BY  Employee.Section_Code,  Employee.Employee_No ");

            Debug.WriteLine("Command : " + sb.ToString());
            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
            SqlParameter pCitizenID = new SqlParameter("@CitizenID", "%" + citizenID + "%");
            SqlParameter pFirstName = new SqlParameter("@FirstName", "%" + firstName + "%");
            SqlParameter pLastName = new SqlParameter("@LastName", "%" + lastName + "%");
            cmd.Parameters.Add(pCitizenID);
            cmd.Parameters.Add(pFirstName);
            cmd.Parameters.Add(pLastName);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];


        }

        public static bool CheckCarContract(string contractNo) {
            SqlConnection conn = DBCommon.GetDataConnection();
            StringBuilder sb = new StringBuilder();
            bool result = false;
            sb.Append(" SELECT ");
            sb.Append("     COUNT(*) ");
            sb.Append(" FROM ");
            sb.Append("     VContractCarLeasingAgreement ");
            sb.Append(" WHERE ");
            sb.Append("     Contract_No = @contractNo ");

            Debug.WriteLine("Command : " + sb.ToString());
            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
            SqlParameter pContractNo = new SqlParameter("@contractNo", contractNo);
            cmd.Parameters.Add(pContractNo);

            try {
                cmd.Connection.Open();
                int recCount = (int)cmd.ExecuteScalar();
                cmd.Connection.Close();
                result = recCount > 0;
                return result;

            } catch (Exception ex) {
                throw ex;
            }
        }

        public static bool CheckDriverContract(string contractNo) {
            SqlConnection conn = DBCommon.GetDataConnection();
            StringBuilder sb = new StringBuilder();
            bool result = false;
            sb.Append(" SELECT ");
            sb.Append("     COUNT(*) ");
            sb.Append(" FROM Contract INNER JOIN ");
            sb.Append("     VDriverContractCharge ON  Contract.Contract_No =  VDriverContractCharge.Contract_No INNER JOIN ");
            sb.Append("     VDriverContractChargeOther ON  Contract.Contract_No =  VDriverContractChargeOther.Contract_No INNER JOIN ");
            sb.Append("     VDriverTaxiTimeByCustomer ON  Contract.Customer_Code =  VDriverTaxiTimeByCustomer.Customer_Code INNER JOIN ");
            sb.Append("     VDriverWorkingTimeByCustomer ON  Contract.Customer_Code =  VDriverWorkingTimeByCustomer.Customer_Code ");
            sb.Append(" WHERE ");
            sb.Append("     Contract.Contract_No = @contractNo ");

            Debug.WriteLine("Command : " + sb.ToString());
            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
            SqlParameter pContractNo = new SqlParameter("@contractNo", contractNo);
            cmd.Parameters.Add(pContractNo);

            try {
                cmd.Connection.Open();
                int recCount = (int)cmd.ExecuteScalar();
                cmd.Connection.Close();
                result = recCount > 0;
                return result;

            } catch (Exception ex) {
                throw ex;
            }
        }


    }
}
