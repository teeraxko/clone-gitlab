using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.PiDB
{
	public class FormerEmployeeAddressDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;			
		private const int REGISTER_ADDRESS_LINE = 1;
		private const int REGISTER_STREET_NAME = 2;
		private const int REGISTER_SUB_DISTRICT = 3;
		private const int REGISTER_DISTRICT = 4;
		private const int REGISTER_PROVINCE = 5;
		private const int REGISTER_POSTAL_CODE = 6;
		private const int REGISTER_TEL_NO = 7;
		private const int REGISTER_FAX_NO = 8;
		private const int CURRENT_ADDRESS_LINE = 9;
		private const int CURRENT_STREET_NAME = 10;
		private const int CURRENT_SUB_DISTRICT = 11;
		private const int CURRENT_DISTRICT = 12;
		private const int CURRENT_PROVINCE  = 13;
		private const int CURRENT_POSTAL_CODE = 14;
		private const int CURRENT_TEL_NO = 15;
		private const int CURRENT_FAX_NO = 16;
        private const int REGISTER_MOBILE_NO = 17;
        private const int CURRENT_MOBILE_NO = 18;
		#endregion

		#region - Private -
		private EmployeeAddress objEmployeeAddress;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public FormerEmployeeAddressDB(): base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
            return "SELECT Employee_No, Register_Address_Line, Register_Street_Name, Register_Sub_District, Register_District, Register_Province, Register_Postal_Code, Register_Tel_No, Register_Fax_No, Current_Address_Line, Current_Street_Name, Current_Sub_District, Current_District, Current_Province, Current_Postal_Code, Current_Tel_No, Current_Fax_No, Register_Mobile_No, Current_Mobile_No FROM Former_Employee_Address ";
		}

		private string getSQLInsert(EmployeeAddress value)
		{
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Former_Employee_Address (Company_Code, Employee_No, Register_Address_Line, Register_Street_Name, Register_Sub_District, Register_District, Register_Province, Register_Postal_Code, Register_Tel_No, Register_Fax_No, Current_Address_Line, Current_Street_Name, Current_Sub_District, Current_District, Current_Province, Current_Postal_Code, Current_Tel_No, Current_Fax_No, Process_Date, Process_User, Register_Mobile_No, Current_Mobile_No) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(value.AEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");
			
			//Register_Address_Line
			stringBuilder.Append(GetDB(value.ARegisterAddress.AddressLine));
			stringBuilder.Append(", ");
			
			//Register_Street_Name
			stringBuilder.Append(GetDB(value.ARegisterAddress.StreetName.Name));
			stringBuilder.Append(", ");
			
			//Register_Sub_District
			stringBuilder.Append(GetDB(value.ARegisterAddress.Tambon.Name));
			stringBuilder.Append(", ");
			
			//Register_District
			stringBuilder.Append(GetDB(value.ARegisterAddress.District.Name));
			stringBuilder.Append(", ");			
			
			//Register_Province
			stringBuilder.Append(GetDB(value.ARegisterAddress.Province.Name));
			stringBuilder.Append(", ");				 
				 
			//Register_Postal_Code
			stringBuilder.Append(GetDB(value.ARegisterAddress.PostalCode));
			stringBuilder.Append(", ");			
			
			//Register_Tel_No
			stringBuilder.Append(GetDB(value.ARegisterAddress.AContactInfo.Telephone));
			stringBuilder.Append(", ");			
			
			//Register_Fax_No
			stringBuilder.Append(GetDB(value.ARegisterAddress.AContactInfo.Fax));
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
            stringBuilder.Append(", ");

            //Register_Mobile_No
            stringBuilder.Append(GetDB(value.ARegisterAddress.AContactInfo.Mobile));
            stringBuilder.Append(", ");	

            //Current_Mobile_No
            stringBuilder.Append(GetDB(value.ACurrentAddress.AContactInfo.Mobile));
            stringBuilder.Append(")");	

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(EmployeeAddress value)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Former_Employee_Address SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(value.AEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Register_Address_Line = ");
			stringBuilder.Append(GetDB(value.ARegisterAddress.AddressLine));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Register_Street_Name = ");
			stringBuilder.Append(GetDB(value.ARegisterAddress.StreetName.Name));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Register_Sub_District = ");
			stringBuilder.Append(GetDB(value.ARegisterAddress.Tambon.Name));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Register_District = ");
			stringBuilder.Append(GetDB(value.ARegisterAddress.District.Name));
			stringBuilder.Append(", ");			
			
			stringBuilder.Append("Register_Province = ");
			stringBuilder.Append(GetDB(value.ARegisterAddress.Province.Name));
			stringBuilder.Append(", ");				 
				 
			stringBuilder.Append("Register_Postal_Code = ");
			stringBuilder.Append(GetDB(value.ARegisterAddress.PostalCode));
			stringBuilder.Append(", ");			
			
			stringBuilder.Append("Register_Tel_No = ");
			stringBuilder.Append(GetDB(value.ARegisterAddress.AContactInfo.Telephone));
			stringBuilder.Append(", ");			
			
			stringBuilder.Append("Register_Fax_No = ");
			stringBuilder.Append(GetDB(value.ARegisterAddress.AContactInfo.Fax));
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
            stringBuilder.Append(", ");

            stringBuilder.Append("Register_Mobile_No = ");
            stringBuilder.Append(GetDB(value.ARegisterAddress.AContactInfo.Mobile));
            stringBuilder.Append(", ");

            stringBuilder.Append("Current_Mobile_No = ");
            stringBuilder.Append(GetDB(value.ACurrentAddress.AContactInfo.Mobile));
		
			return stringBuilder.ToString();
		}

		private string getSQLDelete()
		{
			return " DELETE FROM Former_Employee_Address ";
		}

		#endregion

		#region - Fill -
		private void fillFormerEmployeeAddress(ref EmployeeAddress value, SqlDataReader dataReader)
		{
			value.ARegisterAddress.AddressLine = (string)dataReader[REGISTER_ADDRESS_LINE];
			value.ARegisterAddress.StreetName.Name = (string)dataReader[REGISTER_STREET_NAME];
			value.ARegisterAddress.Tambon.Name = (string)dataReader[REGISTER_SUB_DISTRICT];
			value.ARegisterAddress.District.Name = (string)dataReader[REGISTER_DISTRICT];
			value.ARegisterAddress.Province.Name = (string)dataReader[REGISTER_PROVINCE];
			value.ARegisterAddress.PostalCode = (string)dataReader[REGISTER_POSTAL_CODE];
			value.ARegisterAddress.AContactInfo.Telephone = (string)dataReader[REGISTER_TEL_NO];
			value.ARegisterAddress.AContactInfo.Fax = (string)dataReader[REGISTER_FAX_NO];
			value.ACurrentAddress.AddressLine = (string)dataReader[CURRENT_ADDRESS_LINE];
			value.ACurrentAddress.StreetName.Name = (string)dataReader[CURRENT_STREET_NAME];
			value.ACurrentAddress.Tambon.Name = (string)dataReader[CURRENT_SUB_DISTRICT];
			value.ACurrentAddress.District.Name = (string)dataReader[CURRENT_DISTRICT];
			value.ACurrentAddress.Province.Name = (string)dataReader[CURRENT_PROVINCE];
			value.ACurrentAddress.PostalCode = (string)dataReader[CURRENT_POSTAL_CODE];
			value.ACurrentAddress.AContactInfo.Telephone = (string)dataReader[CURRENT_TEL_NO];
			value.ACurrentAddress.AContactInfo.Fax = (string)dataReader[CURRENT_FAX_NO];
            if (dataReader.IsDBNull(REGISTER_MOBILE_NO))
            {
                value.ARegisterAddress.AContactInfo.Mobile = string.Empty;
            }
            else
            {
                value.ARegisterAddress.AContactInfo.Mobile = (string)dataReader[REGISTER_MOBILE_NO];
            }

            if (dataReader.IsDBNull(CURRENT_MOBILE_NO))
            {
                value.ACurrentAddress.AContactInfo.Mobile = string.Empty;
            }
            else
            {
                value.ACurrentAddress.AContactInfo.Mobile = (string)dataReader[CURRENT_MOBILE_NO];
            }
		}

		private bool fillFormerEmployeeAddress(ref EmployeeAddress value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillFormerEmployeeAddress(ref value, dataReader);
					result = true;
				}
				else
				{
					result = false;
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

		#endregion

//		============================== Public Method ==============================
		public EmployeeAddress GetFormerEmployeeAddress(Employee value)
		{
			objEmployeeAddress = new EmployeeAddress();
			objEmployeeAddress.AEmployee = value;
			if(FillFormerEmployeeAddress(ref objEmployeeAddress))
			{
				return objEmployeeAddress;		
			}
			else
			{
				objEmployeeAddress = null;
				return null;
			}
		}

		public bool FillFormerEmployeeAddress(ref EmployeeAddress value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.AEmployee));
			return fillFormerEmployeeAddress(ref value, stringBuilder.ToString());
		}

		public bool InsertFormerEmployeeAddress(EmployeeAddress value)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateFormerEmployeeAddress(EmployeeAddress value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value));
			stringBuilder.Append(getBaseCondition(value.AEmployee));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteFormerEmployeeAddress(EmployeeAddress value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.AEmployee));

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
