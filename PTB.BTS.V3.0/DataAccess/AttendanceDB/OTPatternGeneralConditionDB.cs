using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;
using Entity.ContractEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class OTPatternGeneralConditionDB: DataAccessBase
	{
		#region - Constant -
		private const int PATTERN_CODE = 0;
		private const int POSITION_TYPE = 1;
		private const int SERVICE_STAFF_TYPE = 2;
		private const int CUSTOMER_CODE = 3;
		private const int CUSTOMER_DEPARTMENT = 4;
		#endregion

		#region - Private -
		private PositionTypeDB dbPositionType;
		private ServiceStaffTypeDB dbServiceStaffType;
		private CustomerDB dbCustomer;
		private CustomerDepartmentDB dbCustomerDepartment;
		private OTPatternDB dbOTPattern;

		private OTPatternGeneralCondition objOTPatternGeneralCondition;
		private bool disposed  = false;
		#endregion

//		============================== Constructor ==============================
		public OTPatternGeneralConditionDB():base()
		{
			dbPositionType = new PositionTypeDB();
			dbServiceStaffType = new ServiceStaffTypeDB();
			dbCustomer = new CustomerDB();
			dbCustomerDepartment = new CustomerDepartmentDB();
			dbOTPattern = new OTPatternDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Pattern_Code, Position_Type, Service_Staff_Type, Customer_Code, Customer_Department FROM Overtime_Pattern_General_Condition ";
		}

		private string getSQLInsert(OTPatternGeneralCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Overtime_Pattern_General_Condition (Company_Code, Pattern_Code, Position_Type, Service_Staff_Type, Customer_Code, Customer_Department, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Pattern_Code
			stringBuilder.Append(GetDB(value.AOTPattern.PatternId));
			stringBuilder.Append(", ");

			//Position_Type
			stringBuilder.Append(GetDB(value.APositionType.Type));
			stringBuilder.Append(", ");

			//Service_Staff_Type
			stringBuilder.Append(GetDB(value.AServiceStaffType.Type));
			stringBuilder.Append(", ");

			//Customer_Code
			stringBuilder.Append(GetDB(value.ACustomerDepartment.ACustomer.Code));
			stringBuilder.Append(", ");

			//Customer_Department
			stringBuilder.Append(GetDB(value.ACustomerDepartment.Code));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(OTPatternGeneralCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Overtime_Pattern_General_Condition SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Pattern_Code = ");
			stringBuilder.Append(GetDB(value.AOTPattern.PatternId));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Position_Type = ");
			stringBuilder.Append(GetDB(value.APositionType.Type));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Service_Staff_Type = ");
			stringBuilder.Append(GetDB(value.AServiceStaffType.Type));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Customer_Code = ");
			stringBuilder.Append(GetDB(value.ACustomerDepartment.ACustomer.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Customer_Department = ");
			stringBuilder.Append(GetDB(value.ACustomerDepartment.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
			
			return stringBuilder.ToString();
		}	

		private string getSQLDelete()
		{
			return "DELETE FROM Overtime_Pattern_General_Condition ";
		}

		private string getKeyCondition(OTPatternGeneralCondition value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.AOTPattern.PatternId))
			{
				stringBuilder.Append(" AND (Pattern_Code = ");
				stringBuilder.Append(GetDB(value.AOTPattern.PatternId));
				stringBuilder.Append(" ) ");
			}

			if((value.APositionType!=null) && IsNotNULL(value.APositionType.Type))
			{
				stringBuilder.Append(" AND (Position_Type = ");
				stringBuilder.Append(GetDB(value.APositionType.Type));
				stringBuilder.Append(" ) ");
			}

			if((value.AServiceStaffType!=null) && IsNotNULL(value.AServiceStaffType.Type))
			{
				stringBuilder.Append(" AND (Service_Staff_Type = ");
				stringBuilder.Append(GetDB(value.AServiceStaffType.Type));
				stringBuilder.Append(" ) ");
			}

			if((value.ACustomer!=null) && IsNotNULL(value.ACustomer.Code))
			{
				stringBuilder.Append(" AND (Customer_Code = ");
				stringBuilder.Append(GetDB(value.ACustomerDepartment.ACustomer.Code));
				stringBuilder.Append(" ) ");
			}

			if((value.ACustomerDepartment!=null) && IsNotNULL(value.ACustomerDepartment.Code))
			{
				stringBuilder.Append(" AND (Customer_Department = ");
				stringBuilder.Append(GetDB(value.ACustomerDepartment.Code));
				stringBuilder.Append(" ) ");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Pattern_Code, Position_Type, Service_Staff_Type, Customer_Code, Customer_Department ";
		}
		#endregion

		#region - Fill -

		private void fillOTPatternGeneralCondition(ref OTPatternGeneralCondition value, Company aCompany, SqlDataReader dataReader)
		{
			value.ACustomerDepartment = dbCustomerDepartment.GetDBCustomerDepartment((string)dataReader[CUSTOMER_DEPARTMENT], (string)dataReader[CUSTOMER_CODE], aCompany);	
		}

		private void fillOTPatternGeneralConditionDB(ref OTPatternGeneralCondition value, Company aCompany, SqlDataReader dataReader)
		{
			value.AOTPattern = dbOTPattern.GetOTPattern((string)dataReader[PATTERN_CODE], aCompany);
			value.APositionType = dbPositionType.GetDBPositionType((string)dataReader[POSITION_TYPE], aCompany);
			value.AServiceStaffType = dbServiceStaffType.GetDBServiceStaffType((string)dataReader[SERVICE_STAFF_TYPE], aCompany);
			value.ACustomer = dbCustomer.GetDBCustomer((string)dataReader[CUSTOMER_CODE],aCompany);
			fillOTPatternGeneralCondition(ref value, aCompany, dataReader);
		}

		private bool fillOTPatternGeneralConditionList(ref OTPatternConditionList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			OTPatternList listOTPattern = new OTPatternList(value.Company);
			dbOTPattern.FillOTPatternList(ref listOTPattern);
			PositionTypeList listPositionType = new PositionTypeList(value.Company);
			dbPositionType.FillPositionTypeList(ref listPositionType);
			ServiceStaffTypeList listServiceStaffTypeList = new ServiceStaffTypeList(value.Company);
			dbServiceStaffType.FillServiceStaffTypeList(ref listServiceStaffTypeList);
			CustomerList listCustomer = new CustomerList(value.Company);
			dbCustomer.FillCustomerList(ref listCustomer);

			try
			{
				while (dataReader.Read())
				{
					result = true;
					objOTPatternGeneralCondition = new OTPatternGeneralCondition();
					objOTPatternGeneralCondition.AOTPattern = listOTPattern[(string)dataReader[PATTERN_CODE]];
					objOTPatternGeneralCondition.APositionType = listPositionType[(string)dataReader[POSITION_TYPE]];
					objOTPatternGeneralCondition.AServiceStaffType = listServiceStaffTypeList[(string)dataReader[SERVICE_STAFF_TYPE]];
					objOTPatternGeneralCondition.ACustomer = listCustomer[(string)dataReader[CUSTOMER_CODE]];
					fillOTPatternGeneralCondition(ref objOTPatternGeneralCondition, value.Company, dataReader);
					value.Add(objOTPatternGeneralCondition);
				}
				objOTPatternGeneralCondition = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{
				tableAccess.CloseDataReader();
				listOTPattern = null;
				listPositionType = null;
				listServiceStaffTypeList = null;
				listCustomer = null;
				dataReader = null;
			}
			return result;
		}

		private bool fillOTPatternList(OTPatternList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			OTPatternList listOTPattern = new OTPatternList(value.Company);
			dbOTPattern.FillOTPatternList(ref listOTPattern);

			try
			{
				while (dataReader.Read())
				{
					result = true;
					value.Add(listOTPattern[(string)dataReader[PATTERN_CODE]]);
				}
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{
				tableAccess.CloseDataReader();
				listOTPattern = null;
				dataReader = null;
			}
			return result;
		}
		#endregion

//		============================== Public Method ==============================
		public bool FillOTPatternGeneralConditionList(OTPatternList value, OTPatternGeneralCondition codition)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(codition));
			stringBuilder.Append(getOrderby());

			return fillOTPatternList(value, stringBuilder.ToString());
		}

		public bool FillOTPatternGeneralConditionList(ref OTPatternConditionList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillOTPatternGeneralConditionList(ref value, stringBuilder.ToString());
		}

		public bool FillOTPatternGeneralConditionList(ref OTPatternConditionList value, OTPatternGeneralCondition codition)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(codition));
			stringBuilder.Append(getOrderby());

			return fillOTPatternGeneralConditionList(ref value, stringBuilder.ToString());
		}

		public bool InsertOTPatternGeneralCondition(OTPatternGeneralCondition value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateOTPatternGeneralCondition(OTPatternGeneralCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteOTPatternGeneralCondition(OTPatternGeneralCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

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
						dbPositionType.Dispose();
						dbServiceStaffType.Dispose();
						dbCustomer.Dispose();
						dbCustomerDepartment.Dispose();

						dbPositionType = null;
						dbServiceStaffType = null;
						dbCustomer = null;
						dbCustomerDepartment = null;
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
