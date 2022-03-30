using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;
using Entity.CommonEntity;

namespace DataAccess.CommonDB
{
    public class EmailFormatDB : DataAccessBase
	{
        #region - Constant -

        private const int ID_COL_INDEX = 0;
        private const int EMAILCODE_COL_INDEX = 1;
        private const int SUBJECT_COL_INDEX = 2;
        private const int BODY_COL_INDEX = 3;
        private const int FOOTER_COL_INDEX = 4;
        private const int PROCESSUSER_COL_INDEX = 5;
        private const int PROCESSDATE_COL_INDEX = 6;        
        #endregion

		#region - Private -	
		private EmailFormat objEmailFormat;
		#endregion

//		============================== Constructor ==============================
        public EmailFormatDB()
            : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
            return "SELECT Id ,EmailCode ,Subject ,Body ,Footer ,ProcessUser ,ProcessDate FROM EmailFormat ";
		}

		private string getKeyConditionEmailCode(string emailCode)
		{
			StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(emailCode))
			{
				stringBuilder.Append(" AND (EmailCode = ");
                stringBuilder.Append(GetDB(emailCode));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}
       
		private string getOrderby()
		{
            return " ORDER BY EmailCode "; 
		}
		#endregion

		        
        public bool FillEmailFormatByCode(ref EmailFormat aEmailFormat, string emailCode)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
            stringBuilder.Append(getKeyConditionEmailCode(emailCode));
			stringBuilder.Append(getOrderby());

            return FillEmailFormat(ref aEmailFormat, stringBuilder.ToString());		
		}

        private bool FillEmailFormat(ref EmailFormat value, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    FillEmailFormat(ref value, dataReader);
                    result = true;
                }
            }
            catch (IndexOutOfRangeException ein)
            {
                throw ein;
            }
            finally
            {
                tableAccess.CloseDataReader();
            }
            return result;
        }

        private void FillEmailFormat(ref EmailFormat value, SqlDataReader dataReader)
        {
            value.Id = dataReader.GetInt32(ID_COL_INDEX);
            value.EmailCode = dataReader.GetString(EMAILCODE_COL_INDEX);
            value.Subject = dataReader.GetString(SUBJECT_COL_INDEX);
            value.Body = dataReader.GetString(BODY_COL_INDEX);
            value.Footer = dataReader.GetString(FOOTER_COL_INDEX);
            value.ProcessUser = dataReader.GetString(PROCESSUSER_COL_INDEX);
            value.ProcessDate = dataReader.GetDateTime(PROCESSDATE_COL_INDEX);            
        }        
	}
}
