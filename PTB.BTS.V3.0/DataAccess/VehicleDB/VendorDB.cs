using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.VehicleDB
{
	public class VendorDB : DataAccessBase
	{
		#region - Constant -	
		private const int VENDOR_CODE = 0; 
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
		private const int SHORT_NAME = 11;
		#endregion

		#region - Private -
		private Vendor objVendor;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public VendorDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{

            //Todsporn Modified 1/6/2020 SQL upgrade 2019
            return " SELECT Vendor_Code, Vendor.English_Name , Vendor.English_Name,Current_Address_Line, Current_Street_Name, Current_Sub_District, Current_District, Current_Province, Current_Postal_Code, Current_Tel_No, Current_Fax_No, Short_Name FROM Vendor ";
		}

		private string getSQLInsert(Vendor value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Vendor (Company_Code, Vendor_Code, English_Name, Thai_Name, Short_Name, Current_Address_Line, Current_Street_Name, Current_Sub_District, Current_District, Current_Province, Current_Postal_Code, Current_Tel_No, Current_Fax_No, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");
			//Company_Code			
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Vendor_Code
			stringBuilder.Append(GetDB(value.Code));
			stringBuilder.Append(", ");
 
			//English_Name
			stringBuilder.Append(GetDB(value.ADescription.English));
			stringBuilder.Append(", ");
			
			//Thai_Name
			stringBuilder.Append(GetDB(value.ADescription.Thai));
			stringBuilder.Append(", ");

			//Short_Name
			stringBuilder.Append(GetDB(value.ShortName));
			stringBuilder.Append(", ");
			
			//Current_Address_Line
			stringBuilder.Append(GetDB(value.ACurrentAddress.AddressLine));
			stringBuilder.Append(", ");
			
			//Current_Street_Name
			stringBuilder.Append(GetDB(value.ACurrentAddress.StreetName.Name));
			stringBuilder.Append(", ");
			
			//Current_Sub_District
			stringBuilder.Append(GetDB(value.ACurrentAddress.Tambon.Name));
			stringBuilder.Append(", ");
			
			//Current_District
			stringBuilder.Append(GetDB(value.ACurrentAddress.District.Name));
			stringBuilder.Append(", ");
			
			//Current_Province
			stringBuilder.Append(GetDB(value.ACurrentAddress.Province.Name));
			stringBuilder.Append(", ");

			//Current_Postal_Code
			stringBuilder.Append(GetDB(value.ACurrentAddress.PostalCode));
			stringBuilder.Append(", ");
			
			//Current_Tel_No
			stringBuilder.Append(GetDB(value.ACurrentAddress.AContactInfo.Telephone));
			stringBuilder.Append(", ");
			
			//Current_Fax_No
			stringBuilder.Append(GetDB(value.ACurrentAddress.AContactInfo.Fax));
			stringBuilder.Append(", ");
			
			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(Vendor value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" UPDATE Vendor SET ");
						
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");
		
			stringBuilder.Append("Vendor_Code = ");
			stringBuilder.Append(GetDB(value.Code));
			stringBuilder.Append(", ");
 
			stringBuilder.Append("English_Name = ");
			stringBuilder.Append(GetDB(value.ADescription.English));
			stringBuilder.Append(", ");

			stringBuilder.Append("Thai_Name = ");
			stringBuilder.Append(GetDB(value.ADescription.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Short_Name = ");
			stringBuilder.Append(GetDB(value.ShortName));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Address_Line = ");
			stringBuilder.Append(GetDB(value.ACurrentAddress.AddressLine));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Street_Name = ");
			stringBuilder.Append(GetDB(value.ACurrentAddress.StreetName.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Sub_District = ");
			stringBuilder.Append(GetDB(value.ACurrentAddress.Tambon.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_District = ");
			stringBuilder.Append(GetDB(value.ACurrentAddress.District.Name));
			stringBuilder.Append(", ");
				
			stringBuilder.Append("Current_Province = ");
			stringBuilder.Append(GetDB(value.ACurrentAddress.Province.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Postal_Code = ");
			stringBuilder.Append(GetDB(value.ACurrentAddress.PostalCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Tel_No = ");
			stringBuilder.Append(GetDB(value.ACurrentAddress.AContactInfo.Telephone));
			stringBuilder.Append(", ");

			stringBuilder.Append("Current_Fax_No = ");
			stringBuilder.Append(GetDB(value.ACurrentAddress.AContactInfo.Fax));
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
			return " DELETE FROM Vendor ";
		}

		private string getKeyCondition(Vendor value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.Code))
			{
				stringBuilder.Append(" AND (Vendor_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{

            //Todsporn Modified 1/6/2020 SQL upgrade 2019
            return " ORDER BY Vendor.English_Name ";
		}
		#endregion

		#region - Fill -
		private void fillVendor(ref Vendor value, SqlDataReader dataReader)
		{
			value.Code = (string)dataReader[VENDOR_CODE];
			value.ADescription.English = (string)dataReader[ENGLISH_NAME];
			value.ADescription.Thai = (string)dataReader[THAI_NAME];
			value.ACurrentAddress.AddressLine = (string)dataReader[CURRENT_ADDRESS_LINE];
			value.ACurrentAddress.StreetName.Name = (string)dataReader[CURRENT_STREET_NAME];
			value.ACurrentAddress.Tambon.Name = (string)dataReader[CURRENT_SUB_DISTRICT];
			value.ACurrentAddress.District.Name = (string)dataReader[CURRENT_DISTRICT];
			value.ACurrentAddress.Province.Name = (string)dataReader[CURRENT_PROVINCE];
			value.ACurrentAddress.PostalCode = (string)dataReader[CURRENT_POSTAL_CODE];
			value.ACurrentAddress.AContactInfo.Telephone = (string)dataReader[CURRENT_TEL_NO];
			value.ACurrentAddress.AContactInfo.Fax = (string)dataReader[CURRENT_FAX_NO];
			value.ShortName = (string)dataReader[SHORT_NAME];
		}

		private bool fillVendorList(ref VendorList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objVendor = new Vendor();
					fillVendor(ref objVendor, dataReader);
					value.Add(objVendor);
				}
				objVendor = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;		
		}

		private bool fillVendor(ref Vendor value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillVendor(ref value, dataReader);
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
		public Vendor GetVendor(string vendorCode, Company aCompany)
		{
			objVendor = new Vendor();
			objVendor.Code = vendorCode;
			if(FillVendor(ref objVendor, aCompany))
			{return objVendor;}
			else
			{
				objVendor = null;
				return null;
			}
		}

		public Vendor GetDBVendor(string vendorCode, Company aCompany)
		{
			objVendor = new Vendor();
			objVendor.Code = vendorCode;
			if(FillVendor(ref objVendor, aCompany))
			{return objVendor;}
			else
			{
				objVendor.Code = NullConstant.STRING;
				return objVendor;
			}
		}

		public bool FillVendor(ref Vendor value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return fillVendor(ref value, stringBuilder.ToString());
		}

		public bool FillVendorList(ref VendorList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillVendorList(ref value, stringBuilder.ToString());
		}

		public bool InsertVendor(Vendor value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateVendor(Vendor value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteVendor(Vendor value, Company aCompany)
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
						objVendor = null;
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
