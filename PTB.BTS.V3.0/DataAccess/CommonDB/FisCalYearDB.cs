using System;
using System.Collections.Generic;
using System.Text;

using Entity.CommonEntity;

using DataAccess.CommonDB;
using System.Data.SqlClient;

namespace DataAccess.CommonDB
{
    public class FisCalYearDB : DataAccessBase
    {
        public FiscalYear GetFisCalYear()
		{
            FiscalYear fisCalYear = new FiscalYear();

			SqlDataReader dataReader = tableAccess.ExecuteDataReader(" SELECT Company_Code, For_Year, Start_Date, End_Date FROM Fiscal_Year ");
			try
			{
                if (dataReader.Read())
                {
                    fisCalYear.CompanyCode = (string)dataReader[0];
                    fisCalYear.ForYear = dataReader.GetInt16(1).ToString();
                    fisCalYear.StartDate = dataReader.GetDateTime(2);
                    fisCalYear.EndDate = dataReader.GetDateTime(3);
                }
                else
                {
                    fisCalYear = null;
                }
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}

            return fisCalYear;				
		}
    }
}
