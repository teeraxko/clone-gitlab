using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Entity.CommonEntity;
using Entity.ContractEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

namespace DataAccess.ContractDB
{
	public class ServiceStaffTypeDB : DataAccessBase
	{
		#region - Constant -
		private const int SERVICE_STAFF_TYPE = 0;
		private const int ENGLISH_DESCRIPTION = 1;
		private const int THAI_DESCRIPTION = 2;
		private const int BASE_POSITION_CODE = 3;
        private const int BIZPAC_INCOME_CODE = 4;
        private const int BIZPAC_INCOME_NAME = 5;
		#endregion

		#region - Private -
		private PositionDB dbPosition;
		private ServiceStaffType objServiceStaffType;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public ServiceStaffTypeDB() : base()
		{
			dbPosition = new PositionDB();
		}

//		======================== Private Method=========================
		#region - getSQL -
		private string getSQLSelect()
		{
            return "SELECT Service_Staff_Type, English_Description, Thai_Description, Base_Position_Code,  BizPac_Income_Code , BizPac_Income_Name FROM Service_Staff_Type ";
		}

		private string getSQLInsert(ServiceStaffType aServiceStaffType, Company aCompany)
		{
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Service_Staff_Type (Company_Code, Service_Staff_Type, English_Description, Thai_Description, Base_Position_Code, BizPac_Income_Code , BizPac_Income_Name, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");
			
			//Service_Staff_Type			
			stringBuilder.Append(GetDB(aServiceStaffType.Type));
			stringBuilder.Append(", ");

			//English_Description
			stringBuilder.Append(GetDB(aServiceStaffType.ADescription.English));
			stringBuilder.Append(", ");

			//Thai_Description
			stringBuilder.Append(GetDB(aServiceStaffType.ADescription.Thai));
			stringBuilder.Append(", ");

			//Base_Position_Code
			stringBuilder.Append(GetDB(aServiceStaffType.APosition.PositionCode));
			stringBuilder.Append(", ");

            //BizPac_Income_Code
            stringBuilder.Append(GetDB(aServiceStaffType.BizPacIncomeCode));
            stringBuilder.Append(", ");

            //BizPac_Income_Name
            stringBuilder.Append(GetDB(aServiceStaffType.BizPacIncomeName));
            stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(ServiceStaffType aServiceStaffType, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Service_Staff_Type SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Service_Staff_Type = ");
			stringBuilder.Append(GetDB(aServiceStaffType.Type));
			stringBuilder.Append(", ");

			stringBuilder.Append("English_Description = ");
			stringBuilder.Append(GetDB(aServiceStaffType.ADescription.English));
			stringBuilder.Append(", ");
	
			stringBuilder.Append("Thai_Description = ");
			stringBuilder.Append(GetDB(aServiceStaffType.ADescription.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Base_Position_Code = ");
			stringBuilder.Append(GetDB(aServiceStaffType.APosition.PositionCode));
			stringBuilder.Append(", ");

            stringBuilder.Append("BizPac_Income_Code = ");
            stringBuilder.Append(GetDB(aServiceStaffType.BizPacIncomeCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("BizPac_Income_Name = ");
            stringBuilder.Append(GetDB(aServiceStaffType.BizPacIncomeName));
            stringBuilder.Append(", ");

			stringBuilder.Append("Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append("Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
		
			return stringBuilder.ToString();
		}

		private string getSQLDelete()
		{
			return " DELETE FROM Service_Staff_Type ";
		}

		private string getKeyCondition(ServiceStaffType value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.Type))
			{
				stringBuilder.Append(" AND (Service_Staff_Type = ");
				stringBuilder.Append(GetDB(value.Type));
				stringBuilder.Append(")");
			}
			if (value.APosition != null && IsNotNULL(value.APosition.PositionCode))
			{
				stringBuilder.Append(" AND (Base_Position_Code = ");
				stringBuilder.Append(GetDB(value.APosition.PositionCode));
				stringBuilder.Append(")");
			}
			
			return stringBuilder.ToString();
		}

		private string getKeyCondition(Position value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value != null && IsNotNULL(value.PositionCode))
			{
				stringBuilder.Append(" AND (Base_Position_Code = ");
				stringBuilder.Append(GetDB(value.PositionCode));
				stringBuilder.Append(")");
			}
			
			return stringBuilder.ToString();
		}

		private string getExcludeKeyCondition(ServiceStaffType value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.Type))
			{
				stringBuilder.Append(" AND NOT(Service_Staff_Type = ");
				stringBuilder.Append(GetDB(value.Type));
				stringBuilder.Append(")");
			}
			if (value.APosition != null && IsNotNULL(value.APosition.PositionCode))
			{
				stringBuilder.Append(" AND NOT(Base_Position_Code = ");
				stringBuilder.Append(GetDB(value.APosition.PositionCode));
				stringBuilder.Append(")");
			}
			
			return stringBuilder.ToString();
		}

		private string getExcludeKeyCondition(Position value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value != null && IsNotNULL(value.PositionCode))
			{
				stringBuilder.Append(" AND (Base_Position_Code = ");
				stringBuilder.Append(GetDB(value.PositionCode));
				stringBuilder.Append(")");
			}
			if (IsNotNULL(value.PositionCode))
			{
				stringBuilder.Append(" AND NOT(Service_Staff_Type = ");
				stringBuilder.Append(GetDB(value.PositionCode + "Z"));
				stringBuilder.Append(")");
			}			
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY English_Description ";
		}
		#endregion

		#region - Fill -
		private void fillServiceStaffType(ref ServiceStaffType value, Company aCompany, SqlDataReader dataReader)
		{
			value.Type = (string)dataReader[SERVICE_STAFF_TYPE];
			value.ADescription.English = (string)dataReader[ENGLISH_DESCRIPTION];
			value.ADescription.Thai = (string)dataReader[THAI_DESCRIPTION];
			if (dataReader.IsDBNull(BASE_POSITION_CODE))
			{
				value.APosition.PositionCode = NullConstant.STRING;
			}
			else
			{
				value.APosition = dbPosition.GetDBPosition((string)dataReader[BASE_POSITION_CODE], aCompany);
			}
            value.BizPacIncomeCode = (string)dataReader[BIZPAC_INCOME_CODE];
            value.BizPacIncomeName = (string)dataReader[BIZPAC_INCOME_NAME];
		}

		private bool fillServiceStaffTypeList(ref ServiceStaffTypeList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objServiceStaffType = new ServiceStaffType();
					fillServiceStaffType(ref objServiceStaffType, value.Company, dataReader);
					value.Add(objServiceStaffType);
				}
				objServiceStaffType = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;
		}

		private bool fillServiceStaffType(ref ServiceStaffType aServiceStaffType, Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillServiceStaffType(ref aServiceStaffType, aCompany, dataReader);
					result = true;
				}
				else
				{result = false;}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;
		}
		#endregion
//		============================== Public Method ==============================
		public ServiceStaffType GetServiceStaffType(string serviceStaffTypeCode, Company aCompany)
		{
			objServiceStaffType = new ServiceStaffType();
			objServiceStaffType.Type = serviceStaffTypeCode;;
			if(FillServiceStaffType(ref objServiceStaffType, aCompany))
			{
				return objServiceStaffType;
			}
			else
			{
				objServiceStaffType = null;
				return null;
			}
		}

		internal ServiceStaffType GetDBServiceStaffType(string serviceStaffType, Company aCompany)
		{
			objServiceStaffType = new ServiceStaffType();
			objServiceStaffType.Type = serviceStaffType;;
			if(FillServiceStaffType(ref objServiceStaffType, aCompany))
			{
				return objServiceStaffType;
			}
			else
			{
				objServiceStaffType.Type = NullConstant.STRING;
				return objServiceStaffType;
			}
		}
		
		public ServiceStaffType GetServiceStaffType(ServiceStaffType aServiceStaffType, Company aCompany)
		{
			return GetServiceStaffType(aServiceStaffType.Type, aCompany);
		}

		public bool FillServiceStaffType(ref ServiceStaffType aServiceStaffType, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(aServiceStaffType));
			return fillServiceStaffType(ref aServiceStaffType, aCompany, stringBuilder.ToString());
		}

		public bool FillServiceStaffTypeList(ref ServiceStaffTypeList value, ServiceStaffType aServiceStaffType)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(aServiceStaffType));
			stringBuilder.Append(getOrderby());

			return fillServiceStaffTypeList(ref value, stringBuilder.ToString());
		}

		public bool FillServiceStaffTypeList(ref ServiceStaffTypeList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillServiceStaffTypeList(ref value, stringBuilder.ToString());
		}

		public bool FillExcludeServiceStaffTypeList(ref ServiceStaffTypeList aServiceStaffTypeList, ServiceStaffType aServiceStaffType)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aServiceStaffTypeList.Company));
			stringBuilder.Append(getExcludeKeyCondition(aServiceStaffType));
			stringBuilder.Append(getOrderby());

			return fillServiceStaffTypeList(ref aServiceStaffTypeList, stringBuilder.ToString());
		}

		public bool InsertServiceStaffType(ServiceStaffType value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateServiceStaffType(ServiceStaffType value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteServiceStaffType(ServiceStaffType value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteServiceStaffType(Position value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteExcludeServiceStaffType(Position value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getExcludeKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						dbPosition.Dispose();
						dbPosition = null;
						objServiceStaffType = null;
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion


	}
}
