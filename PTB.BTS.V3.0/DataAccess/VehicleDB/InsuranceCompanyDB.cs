using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;


using ictus.Common.Entity;
namespace DataAccess.VehicleDB
{
	public class InsuranceCompanyDB : DataAccessBase
	{
		#region - Constant -		
		private const int INSURANCE_COMPANY_CODE = 0;
		private const int ENGLISH_NAME = 1;
		private const int THAI_NAME = 2;
		private const int CURRENT_ADDRESS_LINE = 3;
		private const int CURRENT_STREET_NAME = 4;
		private const int CURRENT_SUB_DISTRICT = 5;
		private const int CURRENT_DISTRICT = 6;
		private const int CURRENT_PROVINCE = 7;
		private const int CURRENT_POSTAL_CODE = 8;
		private const int CURRENT_TEL_NO = 9;
		private const int CURRENT_FAX_NO = 10;
		#endregion

		#region - Private -
		private InsuranceCompany objInsuranceCompany;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public InsuranceCompanyDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT  Insurance_Company_Code, English_Name, Thai_Name, Current_Address_Line, Current_Street_Name, Current_Sub_District, Current_District, Current_Province, Current_Postal_Code, Current_Tel_No, Current_Fax_No FROM Insurance_Company ";
		}

		private string getSQLInsert(InsuranceCompany value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Insurance_Company (Company_Code, Insurance_Company_Code, English_Name, Thai_Name, Current_Address_Line, Current_Street_Name, Current_Sub_District, Current_District, Current_Province, Current_Postal_Code, Current_Tel_No, Current_Fax_No, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");
		
			//Insurance_Company_Code
			stringBuilder.Append(GetDB(value.Code));
			stringBuilder.Append(", ");

			//English_Name
			stringBuilder.Append(GetDB(value.AName.English));
			stringBuilder.Append(", ");

			//Thai_Name
			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(", ");

			//Current_Address_Line
			stringBuilder.Append(GetDB(value.AAddress.AddressLine));
			stringBuilder.Append(", ");

			//Current_Street_Name
			stringBuilder.Append(GetDB(value.AAddress.StreetName.Name));
			stringBuilder.Append(", ");

			//Current_Sub_District
			stringBuilder.Append(GetDB(value.AAddress.Tambon.Name));
			stringBuilder.Append(", ");

			//Current_District
			stringBuilder.Append(GetDB(value.AAddress.District.Name));
			stringBuilder.Append(", ");

			//Current_Province
			stringBuilder.Append(GetDB(value.AAddress.Province.Name));
			stringBuilder.Append(", ");

			//Current_Postal_Code
			stringBuilder.Append(GetDB(value.AAddress.PostalCode));
			stringBuilder.Append(", ");

			//Current_Tel_No
			stringBuilder.Append(GetDB(value.AAddress.AContactInfo.Telephone));
			stringBuilder.Append(", ");

			//Current_Fax_No
			stringBuilder.Append(GetDB(value.AAddress.AContactInfo.Fax));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(InsuranceCompany value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Insurance_Company SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");
		
			stringBuilder.Append("Insurance_Company_Code = ");
			stringBuilder.Append(GetDB(value.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("English_Name = ");
			stringBuilder.Append(GetDB(value.AName.English));
			stringBuilder.Append(", ");

			stringBuilder.Append("Thai_Name = ");
			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Address_Line = ");
			stringBuilder.Append(GetDB(value.AAddress.AddressLine));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Street_Name = ");
			stringBuilder.Append(GetDB(value.AAddress.StreetName.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Sub_District = ");
			stringBuilder.Append(GetDB(value.AAddress.Tambon.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_District = ");
			stringBuilder.Append(GetDB(value.AAddress.District.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Province = ");
			stringBuilder.Append(GetDB(value.AAddress.Province.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Postal_Code = ");
			stringBuilder.Append(GetDB(value.AAddress.PostalCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Tel_No = ");
			stringBuilder.Append(GetDB(value.AAddress.AContactInfo.Telephone));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Fax_No = ");
			stringBuilder.Append(GetDB(value.AAddress.AContactInfo.Fax));
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
			return " DELETE FROM Insurance_Company ";
		}

		private string getKeyCondition(InsuranceCompany value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.Code))
			{
				stringBuilder.Append(" AND (Insurance_Company_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Insurance_Company_Code ";
		}
		#endregion

		#region - Fill -
		private void fillInsuranceCompany(ref InsuranceCompany value, SqlDataReader dataReader)
		{
			value.Code = (string)dataReader[INSURANCE_COMPANY_CODE];
			value.AName.English = (string)dataReader[ENGLISH_NAME];
			value.AName.Thai = (string)dataReader[THAI_NAME];
			value.AAddress.AddressLine = (string)dataReader[CURRENT_ADDRESS_LINE]; 
			value.AAddress.StreetName.Name = (string)dataReader[CURRENT_STREET_NAME];
			value.AAddress.Tambon.Name = (string)dataReader[CURRENT_SUB_DISTRICT];
			value.AAddress.District.Name = (string)dataReader[CURRENT_DISTRICT];
			value.AAddress.Province.Name = (string)dataReader[CURRENT_PROVINCE];
			value.AAddress.PostalCode = (string)dataReader[CURRENT_POSTAL_CODE];
			value.AAddress.AContactInfo.Telephone = (string)dataReader[CURRENT_TEL_NO];
			value.AAddress.AContactInfo.Fax = (string)dataReader[CURRENT_FAX_NO];
		}

		private bool fillInsuranceCompany(ref InsuranceCompany value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillInsuranceCompany(ref value, dataReader);
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

		private bool fillInsuranceCompany(ref InsuranceCompanyList value, string sql)
		{
			bool result = false;
			InsuranceCompany insuranceCompany;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					insuranceCompany = new InsuranceCompany();
					fillInsuranceCompany(ref insuranceCompany, dataReader);
					value.Add(insuranceCompany);
				}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}			
			
			return result;				
		}
		#endregion

//		============================== Public Method ==============================
		public InsuranceCompany GetInsuranceCompany(string insuranceCompanyCode, Company aCompany)
		{
			objInsuranceCompany = new InsuranceCompany();
			objInsuranceCompany.Code = insuranceCompanyCode;
			if(FillInsuranceCompany(ref objInsuranceCompany, aCompany))
			{
				return objInsuranceCompany;
			}
			else
			{
				objInsuranceCompany.Code = null;
				return objInsuranceCompany;
			}
		}

		internal InsuranceCompany GetDBInsuranceCompany(string insuranceCompanyCode, Company aCompany)
		{
			objInsuranceCompany = new InsuranceCompany();
			objInsuranceCompany.Code = insuranceCompanyCode;
			if(FillInsuranceCompany(ref objInsuranceCompany, aCompany))
			{
				return objInsuranceCompany;
			}
			else
			{
				return null;
			}
		}

		public bool FillInsuranceCompany(ref InsuranceCompany value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return fillInsuranceCompany(ref value, stringBuilder.ToString());
		}

		public bool FillInsuranceCompanyList(ref InsuranceCompanyList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));

			return fillInsuranceCompany(ref value, stringBuilder.ToString());
		} 

		public bool InsertInsuranceCompany(InsuranceCompany value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateInsuranceCompany(InsuranceCompany value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteInsuranceCompany(InsuranceCompany value, Company aCompany)
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
