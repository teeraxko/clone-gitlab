using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Presentation.CommonGUI
{
    internal class EntitiesProvider {
        public static DataTable BrandDataTable() {
            SqlConnection conn = DBCommon.GetDataConnection();
            string strSQL = "SELECT Brand_Code,Brand_English_Name,Brand_Thai_Name FROM brand ORDER BY Brand_English_Name";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable ModelDataTable(string brandCode) {
            SqlConnection conn = DBCommon.GetDataConnection();
            string strSQL = "SELECT Brand_Code,Model_Code,Model_English_Name,Model_Thai_Name FROM Model where Brand_Code = '" + brandCode + "' ORDER BY Model_English_Name";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable CustomerDataTable() {
            SqlConnection conn = DBCommon.GetDataConnection();
            string strSQL = "SELECT Customer_Code,English_Name,Thai_Name from customer WHERE Customer_Code <> 'ZZZZZZ' ORDER BY English_Name";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable ColorDataTable()
        {
            SqlConnection conn = DBCommon.GetDataConnection();
            string strSQL = "SELECT Color_Code,English_Color_Name,Thai_Color_Name FROM Color WHERE Color_Code <> 'ZZZZZZ' ORDER BY English_Color_Name";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];

        }
    }
}

