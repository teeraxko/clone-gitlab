using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity.General;
using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

namespace DataAccess.PiDB
{
	public class EmployeeSpouseDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int SPOUSE_PREFIX = 1;
		private const int SPOUSE_NAME = 2; 
		private const int SPOUSE_SURNAME = 3; 
		private const int BIRTH_DATE = 4;
		private const int OCCUPATION = 5; 
		private const int MEDICAL_APPLY_STATUS = 6; 
		private const int ALIVE_STATUS = 7; 
		private const int HOME_ADDRESS_LINE = 8; 
		private const int HOME_STREET_NAME = 9; 
		private const int HOME_SUB_DISTRICT = 10; 
		private const int HOME_DISTRICT = 11; 
		private const int HOME_PROVINCE = 12; 
		private const int HOME_POSTAL_CODE = 13; 
		private const int HOME_TEL_NO = 14; 
		private const int HOME_FAX_NO = 15;
		private const int OFFICE_ADDRESS_LINE = 16; 
		private const int OFFICE_STREET_NAME = 17; 
		private const int OFFICE_SUB_DISTRICT = 18; 
		private const int OFFICE_DISTRICT = 19; 
		private const int OFFICE_PROVINCE = 20; 
		private const int OFFICE_POSTAL_CODE = 21; 
		private const int OFFICE_TEL_NO = 22; 
		private const int OFFICE_FAX_NO = 23;
		#endregion

		#region - Private -
		private EmployeeSpouse objEmployeeSpouse;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeSpouseDB(): base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Spouse_Prefix, Spouse_Name, Spouse_Surname, Birth_Date, Occupation, Medical_Apply_Status, Alive_Status, Home_Address_Line, Home_Street_Name, Home_Sub_District, Home_District, Home_Province, Home_Postal_Code, Home_Tel_No, Home_Fax_No, Office_Address_Line, Office_Street_Name, Office_Sub_District, Office_District, Office_Province, Office_Postal_Code, Office_Tel_No, Office_Fax_No FROM Employee_Spouse ";
		}

		private string getSQLInsert(EmployeeSpouse value)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Spouse (Company_Code, Employee_No, Spouse_Prefix, Spouse_Name, Spouse_Surname, Birth_Date, Occupation, Medical_Apply_Status, Alive_Status, Home_Address_Line, Home_Street_Name, Home_Sub_District, Home_District, Home_Province, Home_Postal_Code, Home_Tel_No, Home_Fax_No, Office_Address_Line, Office_Street_Name, Office_Sub_District, Office_District, Office_Province, Office_Postal_Code, Office_Tel_No, Office_Fax_No, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(value.AEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Spouse_Prefix
			stringBuilder.Append(GetDB(value.APrefix.Thai));
			stringBuilder.Append(", ");

			//Spouse_Name
			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(", ");

			//Spouse_Surname
			stringBuilder.Append(GetDB(value.ASurname.Thai));
			stringBuilder.Append(", ");

			//Birth_Date
			stringBuilder.Append(GetDB(value.BirthDate));
			stringBuilder.Append(", ");

			//Occupation
			stringBuilder.Append(GetDB(value.AOccupation.Name));
			stringBuilder.Append(", ");

			//Medical_Apply_Status
			stringBuilder.Append(GetDB(value.ApplyMedical));
			stringBuilder.Append(", ");

			//Alive_Status
			stringBuilder.Append(GetDB(value.Alive));
			stringBuilder.Append(", ");

			//Home_Address_Line
			stringBuilder.Append(GetDB(value.AHomeAddress.AddressLine));
			stringBuilder.Append(", ");

			//Home_Street_Name
			stringBuilder.Append(GetDB(value.AHomeAddress.StreetName.Name));
			stringBuilder.Append(", ");

			//Home_Sub_District
			stringBuilder.Append(GetDB(value.AHomeAddress.Tambon.Name));
			stringBuilder.Append(", ");

			//Home_District
			stringBuilder.Append(GetDB(value.AHomeAddress.District.Name));
			stringBuilder.Append(", ");

			//Home_Province
			stringBuilder.Append(GetDB(value.AHomeAddress.Province.Name));
			stringBuilder.Append(", ");

			//Home_Postal_Code
			stringBuilder.Append(GetDB(value.AHomeAddress.PostalCode));
			stringBuilder.Append(", ");

			//Home_Tel_No
			stringBuilder.Append(GetDB(value.AHomeAddress.AContactInfo.Telephone));
			stringBuilder.Append(", ");

			//Home_Fax_No
			stringBuilder.Append(GetDB(value.AHomeAddress.AContactInfo.Fax));
			stringBuilder.Append(", ");

			//Office_Address_Line
			stringBuilder.Append(GetDB(value.AOfficeAddress.AddressLine));
			stringBuilder.Append(", ");

			//Office_Street_Name
			stringBuilder.Append(GetDB(value.AOfficeAddress.StreetName.Name));
			stringBuilder.Append(", ");

			//Office_Sub_District
			stringBuilder.Append(GetDB(value.AOfficeAddress.Tambon.Name));
			stringBuilder.Append(", ");

			//Office_District
			stringBuilder.Append(GetDB(value.AOfficeAddress.District.Name));
			stringBuilder.Append(", ");

			//Office_Province
			stringBuilder.Append(GetDB(value.AOfficeAddress.Province.Name));
			stringBuilder.Append(", ");

			//Office_Postal_Code
			stringBuilder.Append(GetDB(value.AOfficeAddress.PostalCode));
			stringBuilder.Append(", ");

			//Office_Tel_No
			stringBuilder.Append(GetDB(value.AOfficeAddress.AContactInfo.Telephone));
			stringBuilder.Append(", ");

			//Office_Fax_No
			stringBuilder.Append(GetDB(value.AOfficeAddress.AContactInfo.Fax));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(EmployeeSpouse value)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Spouse SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(value.AEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Spouse_Prefix = ");
			stringBuilder.Append(GetDB(value.APrefix.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Spouse_Name = ");
			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Spouse_Surname = ");
			stringBuilder.Append(GetDB(value.ASurname.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Birth_Date = ");
			stringBuilder.Append(GetDB(value.BirthDate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Occupation = ");
			stringBuilder.Append(GetDB(value.AOccupation.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Medical_Apply_Status = ");
			stringBuilder.Append(GetDB(value.ApplyMedical));
			stringBuilder.Append(", ");

			stringBuilder.Append("Alive_Status = ");
			stringBuilder.Append(GetDB(value.Alive));
			stringBuilder.Append(", ");

			stringBuilder.Append("Home_Address_Line = ");
			stringBuilder.Append(GetDB(value.AHomeAddress.AddressLine));
			stringBuilder.Append(", ");

			stringBuilder.Append("Home_Street_Name = ");
			stringBuilder.Append(GetDB(value.AHomeAddress.StreetName.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Home_Sub_District = ");
			stringBuilder.Append(GetDB(value.AHomeAddress.Tambon.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Home_District = ");
			stringBuilder.Append(GetDB(value.AHomeAddress.District.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Home_Province = ");
			stringBuilder.Append(GetDB(value.AHomeAddress.Province.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Home_Postal_Code = ");
			stringBuilder.Append(GetDB(value.AHomeAddress.PostalCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Home_Tel_No = ");
			stringBuilder.Append(GetDB(value.AHomeAddress.AContactInfo.Telephone));
			stringBuilder.Append(", ");

			stringBuilder.Append("Home_Fax_No = ");
			stringBuilder.Append(GetDB(value.AHomeAddress.AContactInfo.Fax));
			stringBuilder.Append(", ");

			stringBuilder.Append("Office_Address_Line = ");
			stringBuilder.Append(GetDB(value.AOfficeAddress.AddressLine));
			stringBuilder.Append(", ");

			stringBuilder.Append("Office_Street_Name = ");
			stringBuilder.Append(GetDB(value.AOfficeAddress.StreetName.Name));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Office_Sub_District = ");
			stringBuilder.Append(GetDB(value.AOfficeAddress.Tambon.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Office_District = ");
			stringBuilder.Append(GetDB(value.AOfficeAddress.District.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Office_Province = ");
			stringBuilder.Append(GetDB(value.AOfficeAddress.Province.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Office_Postal_Code = ");
			stringBuilder.Append(GetDB(value.AOfficeAddress.PostalCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Office_Tel_No = ");
			stringBuilder.Append(GetDB(value.AOfficeAddress.AContactInfo.Telephone));
			stringBuilder.Append(", ");

			stringBuilder.Append("Office_Fax_No = ");
			stringBuilder.Append(GetDB(value.AOfficeAddress.AContactInfo.Fax));
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
			return " DELETE FROM Employee_Spouse ";
		}
		
		private string getOrderby()
		{
			return " ORDER BY Employee_No ";
		}
		#endregion

		#region - Fill -
		private void fillEmployeeSpouse(ref EmployeeSpouse value, SqlDataReader dataReader)
		{
			value.APrefix.Thai = (string)dataReader[SPOUSE_PREFIX];
			value.AName.Thai = (string)dataReader[SPOUSE_NAME];
			value.ASurname.Thai = (string)dataReader[SPOUSE_SURNAME];
			if (dataReader.IsDBNull(BIRTH_DATE))
			{
				value.BirthDate = NullConstant.DATETIME;
			}
			else
			{
				value.BirthDate = dataReader.GetDateTime(BIRTH_DATE);
			}
			value.AOccupation.Name = (string)dataReader[OCCUPATION];
			value.ApplyMedical = GetBool((string)dataReader[MEDICAL_APPLY_STATUS]);
			value.Alive = GetBool((string)dataReader[ALIVE_STATUS]);
			value.AHomeAddress.AddressLine = (string)dataReader[HOME_ADDRESS_LINE];
			value.AHomeAddress.StreetName.Name = (string)dataReader[HOME_STREET_NAME];
			value.AHomeAddress.Tambon.Name = (string)dataReader[HOME_SUB_DISTRICT];
			value.AHomeAddress.District.Name = (string)dataReader[HOME_DISTRICT];
			value.AHomeAddress.Province.Name = (string)dataReader[HOME_PROVINCE];
			value.AHomeAddress.PostalCode = (string)dataReader[HOME_POSTAL_CODE];
			value.AHomeAddress.AContactInfo.Telephone = (string)dataReader[HOME_TEL_NO];
			value.AHomeAddress.AContactInfo.Fax = (string)dataReader[HOME_FAX_NO];
			value.AOfficeAddress.AddressLine = (string)dataReader[OFFICE_ADDRESS_LINE];
			value.AOfficeAddress.StreetName.Name = (string)dataReader[OFFICE_STREET_NAME];
			value.AOfficeAddress.Tambon.Name = (string)dataReader[OFFICE_SUB_DISTRICT];
			value.AOfficeAddress.District.Name = (string)dataReader[OFFICE_DISTRICT];
			value.AOfficeAddress.Province.Name = (string)dataReader[OFFICE_PROVINCE];
			value.AOfficeAddress.PostalCode = (string)dataReader[OFFICE_POSTAL_CODE];
			value.AOfficeAddress.AContactInfo.Telephone = (string)dataReader[OFFICE_TEL_NO];
			value.AOfficeAddress.AContactInfo.Fax = (string)dataReader[OFFICE_FAX_NO];
		}

		private bool fillEmployeeSpouse(ref EmployeeSpouse value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillEmployeeSpouse(ref value, dataReader);
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

		private void UpdateSingleField(EmployeeSpouse value)
		{
			PrefixDB dbPrefix = new PrefixDB();
			Prefix prefix = new Prefix();
			prefix.Name = value.APrefix.Thai;
			dbPrefix.UpdateMTB(prefix);

			OccupationDB dbOccupation = new OccupationDB();
			Occupation occupation = new Occupation();
			occupation.Name = value.AOccupation.Name;
			dbOccupation.UpdateMTB(occupation);

			StreetDB dbStreet = new StreetDB();
			Street street = new Street();
			street.Name = value.AHomeAddress.StreetName.Name;
			dbStreet.UpdateMTB(street);
	
			street = new Street();
			street.Name = value.AOfficeAddress.StreetName.Name;
			dbStreet.UpdateMTB(street);

			SubDistrictDB dbSubDistrict = new SubDistrictDB();
			SubDistrict subDistrict = new SubDistrict();
			subDistrict.Name = value.AHomeAddress.Tambon.Name;
			dbSubDistrict.UpdateMTB(subDistrict);

			subDistrict = new SubDistrict();
			subDistrict.Name = value.AOfficeAddress.Tambon.Name;
			dbSubDistrict.UpdateMTB(subDistrict);

			DistrictDB dbDistrict = new DistrictDB();
			District district = new District();
			district.Name = value.AHomeAddress.District.Name;
			dbDistrict.UpdateMTB(district);

			district = new District();
			district.Name = value.AOfficeAddress.District.Name;
			dbDistrict.UpdateMTB(district);

			ProvinceDB dbProvince = new ProvinceDB();
			Province province = new Province();
			province.Name = value.AHomeAddress.Province.Name;
			dbProvince.UpdateMTB(province);

			province = new Province();
			province.Name  = value.AOfficeAddress.Province.Name;
			dbProvince.UpdateMTB(province);

		}
//		============================== internal Method ==============================
		#region - internal -
		internal bool MaintainEmployeeSpouse(EmployeeSpouse value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.AEmployee));

			stringBuilder.Append(getSQLInsert(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{
				UpdateSingleField(value);
				return true;}
			else
			{return false;}	
		}
		#endregion
//		============================== Public Method ==============================
		public EmployeeSpouse GetEmployeeSpouse(Employee value)
		{
			objEmployeeSpouse = new EmployeeSpouse();
			if(FillEmployeeSpouse(ref objEmployeeSpouse))
			{
				return objEmployeeSpouse;		
			}
			else
			{
				objEmployeeSpouse = null;
				return null;
			}
		}

		public bool FillEmployeeSpouse(ref EmployeeSpouse aEmployeeSpouse)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployeeSpouse.AEmployee));
			return fillEmployeeSpouse(ref aEmployeeSpouse, stringBuilder.ToString());
		}

		public bool InsertEmployeeSpouse(EmployeeSpouse value)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value))>0)
			{
				UpdateSingleField(value);
				return true;
			}
			else
			{return false;}	
		}

		public bool UpdateEmployeeSpouse(EmployeeSpouse value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value));
			stringBuilder.Append(getBaseCondition(value.AEmployee));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{
				UpdateSingleField(value);
				return true;
			}
			else
			{return false;}
		}

		public bool DeleteEmployeeSpouse(EmployeeSpouse value)
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
