using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;
using Entity.CommonEntity;

namespace DataAccess.CommonDB
{
	public class ApplicationConfigurationDB : DataAccessBase
	{
        #region - Constant -

        private const int ID_COL_INDEX = 0;
        private const int MODULE_COL_INDEX = 1;
        private const int CONFIGCODE_COL_INDEX = 2;
        private const int CONFIGVALUE_COL_INDEX = 3;
        private const int VALUETYPE_COL_INDEX = 4;
        private const int DESCRIPTION_COL_INDEX = 5;
        private const int PROCESSDATE_COL_INDEX = 6;
        private const int PROCESSUSER_COL_INDEX = 7;
        #endregion

		#region - Private -	
		private ApplicationConfiguration objApplicationConfiguration;
		#endregion

//		============================== Constructor ==============================
        public ApplicationConfigurationDB()
            : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
            return "SELECT Id, Module, ConfigCode, ConfigValue, ValueType, Description, ProcessDate, ProcessUser FROM Application_Configuration ";
		}

		private string getKeyConditionModule(string moduleName)
		{
			StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(moduleName))
			{
				stringBuilder.Append(" (Module = ");
                stringBuilder.Append(GetDB(moduleName));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}

        private string getKeyConditionConfigCode(string configCode)
		{
			StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(configCode))
			{
				stringBuilder.Append(" AND (ConfigCode = ");
                stringBuilder.Append(GetDB(configCode));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
            return " ORDER BY Module, ConfigCode "; 
		}
		#endregion

		
        public bool FillApplicationConfigurationListByModule(ref ApplicationConfigurationList aApplicationConfigurationList, string moduleName)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            if (moduleName != null)
            {
                stringBuilder.Append(getKeyConditionModule(moduleName));
            }
            stringBuilder.Append(getOrderby());

            return FillApplicationConfigurationList(ref aApplicationConfigurationList, stringBuilder.ToString());
        }

        public bool FillApplicationConfigurationList(ref ApplicationConfigurationList aApplicationConfigurationList)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getOrderby());

            return FillApplicationConfigurationList(ref aApplicationConfigurationList, stringBuilder.ToString());
        }


        public bool FillApplicationConfiguration(ref ApplicationConfiguration value, string moduleName, string configCode)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
            stringBuilder.Append(getKeyConditionModule(moduleName));
            stringBuilder.Append(getKeyConditionConfigCode(configCode));            
			stringBuilder.Append(getOrderby());

            return FillApplicationConfiguration(ref value, stringBuilder.ToString());		
		}

        private bool FillApplicationConfiguration(ref ApplicationConfiguration value, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                while (dataReader.Read())
                {
                    FillApplicationConfiguration(ref value, dataReader);
                    result = true;
                    break;
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

        private void FillApplicationConfiguration(ref ApplicationConfiguration value, SqlDataReader dataReader)
        {
            value.Id = dataReader.GetInt32(ID_COL_INDEX);
            value.Module = dataReader.GetString(MODULE_COL_INDEX);
            value.ConfigCode = dataReader.GetString(CONFIGCODE_COL_INDEX);
            value.ConfigValue = dataReader.GetString(CONFIGVALUE_COL_INDEX);
            value.ValueType = dataReader.GetString(VALUETYPE_COL_INDEX);
            value.Description = dataReader.GetString(DESCRIPTION_COL_INDEX);
            value.ProcessDate = dataReader.GetDateTime(PROCESSDATE_COL_INDEX);
            value.ProcessUser = dataReader.GetString(PROCESSUSER_COL_INDEX);
        }

        private bool FillApplicationConfigurationList(ref ApplicationConfigurationList value, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                while (dataReader.Read())
                {   ApplicationConfiguration appConfig = new ApplicationConfiguration();
                    FillApplicationConfiguration(ref appConfig, dataReader);
                    value.Add(appConfig);
                }
                result = true;
            }
            catch (IndexOutOfRangeException ein)
            {
                result = false;
                throw ein;
            }
            finally
            {
                tableAccess.CloseDataReader();
            }
            return result;
        }
	}
}
