using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using Entity.ContractEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.ContractDB
{
	public class DocumentNoDB : DataAccessBase
	{
		#region - Constant -
			private const string SQL_SELECT = "SELECT Document_Type, Current_No, For_Year, For_Month FROM Document_Running_No ";
			private const int DOCUMENT_TYPE_CODE = 0;
			private const int CURRENT_NO = 1;
			private const int FOR_YEAR = 2;
			private const int FOR_MONTH = 3;
		#endregion

//		============================== Constructor ==============================
		public DocumentNoDB() : base()
		{}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return SQL_SELECT;
		}

        private string getSQLInsert(DOCUMENT_TYPE value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Document_Running_No (Company_Code, Document_Type, For_Year, For_Month, Current_No, Process_Date, Process_User) VALUES ( ");

			//Company_Code			
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Document_Type			
			stringBuilder.Append(GetDB(value));
			stringBuilder.Append(", ");

			//For_Year, For_Month, Current_No
			stringBuilder.Append(" YEAR(GETDATE()), MONTH(GETDATE()), 1, ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(DOCUMENT_TYPE value)
		{
			StringBuilder stringBuilder = new StringBuilder(" UPDATE Document_Running_No SET ");

			stringBuilder.Append(" Document_Type = ");
			stringBuilder.Append(GetDB(value));
			stringBuilder.Append(" , ");

			stringBuilder.Append("Current_No = Current_No + 1, ");

			stringBuilder.Append(" Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(" , ");

			stringBuilder.Append(" Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));

			return stringBuilder.ToString();
		}

		private string getKeyCondition(DOCUMENT_TYPE value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" AND (Document_Type = ");
			stringBuilder.Append(GetDB(value));
			stringBuilder.Append(" ) AND (For_Year = YEAR(GETDATE())) AND (For_Month = MONTH(GETDATE())) ");

			return stringBuilder.ToString();
//			return getBaseCondition(aCompany) + " AND (For_Year = YEAR(GETDATE())) AND (For_Month = MONTH(GETDATE())) AND Document_Type = " + GetDB(value) ;
		}
		#endregion

//		============================== Public Method ==============================
        public DocumentNo GetContractRunningNo(DOCUMENT_TYPE value, ictus.Common.Entity.Company aCompany)
		{
			int year = 0;
			int month = 0;
			int xxx = 0;			
			
			try
			{
				StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
				stringBuilder.Append(getBaseCondition(aCompany));
				stringBuilder.Append(getKeyCondition(value));

				if (tableAccess.ExecuteScalar(stringBuilder.ToString()) == null)
				{

                    if (value.ToString() != "LEASING_VEHICLE" )
                    {
                        tableAccess.ExecuteSQL(getSQLInsert(value, aCompany));
                    }




				}
				else
				{

                    if (value.ToString() != "LEASING_VEHICLE")
                    {
                        stringBuilder = new StringBuilder(getSQLUpdate(value));
                        stringBuilder.Append(getBaseCondition(aCompany));
                        stringBuilder.Append(getKeyCondition(value));

                        tableAccess.ExecuteSQL(stringBuilder.ToString());
                    }


			
				}
				
				stringBuilder = new StringBuilder(getSQLSelect());
				stringBuilder.Append(getBaseCondition(aCompany));
				stringBuilder.Append(getKeyCondition(value));
				
				SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
				
				if(dataReader.Read())
				{
                    if (value.ToString() != "QUOTATION_VEHICLE")
                    {

                        xxx = dataReader.GetInt16(CURRENT_NO);


                    }
                    else
                    {
                     
                        xxx = dataReader.GetInt16(CURRENT_NO);
                        xxx = xxx + 1;
                        
                    }

					year = dataReader.GetInt32(FOR_YEAR);
					month = dataReader.GetByte(FOR_MONTH);
				}
				else
				{
//					throw "";
				}
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();
			}

			return new DocumentNo(value, year, month, xxx);
		}
	}
}