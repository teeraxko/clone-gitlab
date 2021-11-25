using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.PiDB
{
	public class CompanyDB : DataAccessBase
	{ 
		#region - Constant -
		private const int COMPANY_CODE = 0;
        private const int ENGLISH_SHORT_NAME = 1;
		private const int ENGLISH_NAME = 2;
		private const int THAI_NAME = 3;
		private const int ENGLISH_ADDRESS_LINE = 4;
		private const int ENGLISH_STREET_NAME = 5;
		private const int ENGLISH_SUB_DISTRICT = 6;
		private const int ENGLISH_DISTRICT = 7;
		private const int ENGLISH_PROVINCE = 8;
		private const int THAI_ADDRESS_LINE = 9;
		private const int THAI_STREET_NAME = 10;
		private const int THAI_SUB_DISTRICT = 11;
		private const int THAI_DISTRICT = 12;
		private const int THAI_PROVINCE = 13;
		private const int POSTAL_CODE = 14;
		private const int TEL_NO = 15;
		private const int FAX_NO = 16;
        private const int AUTHORIZED_PERSON1 = 17;
        private const int AUTHORIZED_PERSON_POSITION1 = 18;
        private const int AUTHORIZED_PERSON2 = 19;
        private const int AUTHORIZED_PERSON_POSITION2 = 20;
        private const int AUTHORIZED_PERSON3 = 21;
        private const int AUTHORIZED_PERSON_POSITION3 = 22;

		#endregion

		#region - Private -
		private Company objCompany;
		#endregion

//		============================== Constructor ==============================
		public CompanyDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - gerSQL -
		private string getSQLSelectCompany()
		{
			return " SELECT Company_Code, English_Short_Name FROM Company ";
		}

        private string getSQLSelectCompanyInfo()
        {
            return " SELECT Company_Code, English_Short_Name, English_Name, Thai_Name, English_Address_Line, English_Street_Name, English_Sub_District, English_District, English_Province, Thai_Address_Line, Thai_Street_Name, Thai_Sub_District, Thai_District, Thai_Province, Postal_Code, Tel_No, Fax_No, Authorize_First, Authorize_Position_First, Authorize_Second, Authorize_Position_Second, Authorize_Third, Authorize_Position_Third FROM Company ";
        }

		private string getSQLInsert(CompanyInfo value)
		{
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Company (Company_Code, English_Name, Thai_Name, English_Short_Name, English_Address_Line, English_Street_Name, English_Sub_District, English_District, English_Province, Thai_Address_Line, Thai_Street_Name, Thai_Sub_District, Thai_District, Thai_Province, Postal_Code, Tel_No, Fax_No , Authorize_First, Authorize_Position_First, Authorize_Second, Authorize_Position_Second, Authorize_Third, Authorize_Position_Third, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(value.CompanyCode));
			stringBuilder.Append(", ");

			//English_Name
			stringBuilder.Append(GetDB(value.AFullName.English));
			stringBuilder.Append(", ");

			//Thai_Name
			stringBuilder.Append(GetDB(value.AFullName.Thai));
			stringBuilder.Append(", ");

			//English_Short_Name
			stringBuilder.Append(GetDB(value.AShortName.English));
			stringBuilder.Append(", ");

			//English_Address_Line
			stringBuilder.Append(GetDB(value.AEnglishAddress.AddressLine));
			stringBuilder.Append(", ");

			//English_Street_Name
			stringBuilder.Append(GetDB(value.AEnglishAddress.StreetName.Name));
			stringBuilder.Append(", ");

			//English_Sub_District
			stringBuilder.Append(GetDB(value.AEnglishAddress.Tambon.Name));
			stringBuilder.Append(", ");

			//English_District
			stringBuilder.Append(GetDB(value.AEnglishAddress.District.Name));
			stringBuilder.Append(", ");

			//English_Province
			stringBuilder.Append(GetDB(value.AEnglishAddress.Province.Name));
			stringBuilder.Append(", ");

			//Thai_Address_Line
			stringBuilder.Append(GetDB(value.AThaiAddress.AddressLine));
			stringBuilder.Append(", ");

			//Thai_Street_Name
			stringBuilder.Append(GetDB(value.AThaiAddress.StreetName.Name));
			stringBuilder.Append(", ");

			//Thai_Sub_District
			stringBuilder.Append(GetDB(value.AThaiAddress.Tambon.Name));
			stringBuilder.Append(", ");

			//Thai_District
			stringBuilder.Append(GetDB(value.AThaiAddress.District.Name));
			stringBuilder.Append(", ");

			//Thai_Province
			stringBuilder.Append(GetDB(value.AThaiAddress.Province.Name));
			stringBuilder.Append(", ");

			//Postal_Code
			stringBuilder.Append(GetDB(value.AThaiAddress.PostalCode));
			stringBuilder.Append(", ");

			//Tel_No
			stringBuilder.Append(GetDB(value.AThaiAddress.AContactInfo.Telephone));
			stringBuilder.Append(", ");

			//Fax_No
			stringBuilder.Append(GetDB(value.AThaiAddress.AContactInfo.Fax));
			stringBuilder.Append(", ");

            //Authorize_First
            stringBuilder.Append(GetDB(value.AuthorizedPerson1));
            stringBuilder.Append(", ");

            //Authorize_Position_First
            stringBuilder.Append(GetDB(value.AuthorizedPersonPosition1));
            stringBuilder.Append(", ");

            //Authorize_Second
            stringBuilder.Append(GetDB(value.AuthorizedPerson2));
            stringBuilder.Append(", ");

            //Authorize_Position_Second
            stringBuilder.Append(GetDB(value.AuthorizedPersonPosition2));
            stringBuilder.Append(", ");

            //Authorize_Third
            stringBuilder.Append(GetDB(value.AuthorizedPerson3));
            stringBuilder.Append(", ");

            //Authorize_Position_Third
            stringBuilder.Append(GetDB(value.AuthorizedPersonPosition3));
            stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

        private string getSQLUpdate(CompanyInfo value)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Company SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(value.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" English_Name = ");
			stringBuilder.Append(GetDB(value.AFullName.English));
			stringBuilder.Append(", ");
			
			stringBuilder.Append(" Thai_Name = ");
			stringBuilder.Append(GetDB(value.AFullName.Thai));
			stringBuilder.Append(", ");
			
			stringBuilder.Append(" English_Short_Name = ");
			stringBuilder.Append(GetDB(value.AShortName.English));
			stringBuilder.Append(", ");

			stringBuilder.Append(" English_Address_Line = ");
			stringBuilder.Append(GetDB(value.AEnglishAddress.AddressLine));
			stringBuilder.Append(", ");

			stringBuilder.Append(" English_Street_Name = ");
			stringBuilder.Append(GetDB(value.AEnglishAddress.StreetName.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append(" English_Sub_District = ");
			stringBuilder.Append(GetDB(value.AEnglishAddress.Tambon.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append(" English_District = ");
			stringBuilder.Append(GetDB(value.AEnglishAddress.District.Name));
			stringBuilder.Append(", ");
			
			stringBuilder.Append(" English_Province = ");
			stringBuilder.Append(GetDB(value.AEnglishAddress.Province.Name));
			stringBuilder.Append(", ");
			
			stringBuilder.Append(" Thai_Address_Line = ");
			stringBuilder.Append(GetDB(value.AThaiAddress.AddressLine));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Thai_Street_Name = ");
			stringBuilder.Append(GetDB(value.AThaiAddress.StreetName.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Thai_Sub_District = ");
			stringBuilder.Append(GetDB(value.AThaiAddress.Tambon.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Thai_District = ");
			stringBuilder.Append(GetDB(value.AThaiAddress.District.Name));
			stringBuilder.Append(", ");
			
			stringBuilder.Append(" Thai_Province = ");
			stringBuilder.Append(GetDB(value.AThaiAddress.Province.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Postal_Code = ");
			stringBuilder.Append(GetDB(value.AThaiAddress.PostalCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Tel_No = ");
			stringBuilder.Append(GetDB(value.AThaiAddress.AContactInfo.Telephone));
			stringBuilder.Append(", ");
			
			stringBuilder.Append(" Fax_No = ");
			stringBuilder.Append(GetDB(value.AThaiAddress.AContactInfo.Fax));
			stringBuilder.Append(", ");

            stringBuilder.Append(" Authorize_First = ");
            stringBuilder.Append(GetDB(value.AuthorizedPerson1));
            stringBuilder.Append(", ");

            stringBuilder.Append(" Authorize_Position_First = ");
            stringBuilder.Append(GetDB(value.AuthorizedPersonPosition1));
            stringBuilder.Append(", ");

            stringBuilder.Append(" Authorize_Second = ");
            stringBuilder.Append(GetDB(value.AuthorizedPerson2));
            stringBuilder.Append(", ");

            stringBuilder.Append(" Authorize_Position_Second = ");
            stringBuilder.Append(GetDB(value.AuthorizedPersonPosition2));
            stringBuilder.Append(", ");

            stringBuilder.Append(" Authorize_Third = ");
            stringBuilder.Append(GetDB(value.AuthorizedPerson3));
            stringBuilder.Append(", ");

            stringBuilder.Append(" Authorize_Position_Third= ");
            stringBuilder.Append(GetDB(value.AuthorizedPersonPosition3));
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
			return "DELETE FROM Company ";
		}

		private string getKeyCondition(Company value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" WHERE (Company_Code = ");
			stringBuilder.Append(GetDB(value.CompanyCode));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Company_Code ";
		}
		#endregion

		#region - Fill -
		private void fillCompanyInfo(CompanyInfo value, SqlDataReader dataReader)
		{
            fillCompany(value, dataReader);

            value.AFullName.English = (string)dataReader[ENGLISH_NAME];
            value.AFullName.Thai = (string)dataReader[THAI_NAME];
			value.AEnglishAddress.AddressLine = (string)dataReader[ENGLISH_ADDRESS_LINE];
			value.AEnglishAddress.StreetName.Name = (string)dataReader[ENGLISH_STREET_NAME];
			value.AEnglishAddress.Tambon.Name= (string)dataReader[ENGLISH_SUB_DISTRICT];
			value.AEnglishAddress.District.Name = (string)dataReader[ENGLISH_DISTRICT];
			value.AEnglishAddress.Province.Name = (string)dataReader[ENGLISH_PROVINCE];
			value.AThaiAddress.AddressLine = (string)dataReader[THAI_ADDRESS_LINE];
			value.AThaiAddress.StreetName.Name = (string)dataReader[THAI_STREET_NAME];
			value.AThaiAddress.Tambon.Name = (string)dataReader[THAI_SUB_DISTRICT];
			value.AThaiAddress.District.Name = (string)dataReader[THAI_DISTRICT];
			value.AThaiAddress.Province.Name = (string)dataReader[THAI_PROVINCE];
			value.AThaiAddress.PostalCode = (string)dataReader[POSTAL_CODE];
			value.AThaiAddress.AContactInfo.Telephone = (string)dataReader[TEL_NO];
			value.AThaiAddress.AContactInfo.Fax = (string)dataReader[FAX_NO];
            value.AuthorizedPerson1 = (string)dataReader[AUTHORIZED_PERSON1];
            value.AuthorizedPersonPosition1 = (string)dataReader[AUTHORIZED_PERSON_POSITION1];
            value.AuthorizedPerson2 = (string)dataReader[AUTHORIZED_PERSON2];
            value.AuthorizedPersonPosition2 = (string)dataReader[AUTHORIZED_PERSON_POSITION2];
            value.AuthorizedPerson3 = (string)dataReader[AUTHORIZED_PERSON3];
            value.AuthorizedPersonPosition3 = (string)dataReader[AUTHORIZED_PERSON_POSITION3];
		}

        private void fillCompany(Company value, SqlDataReader dataReader)
        {
            value.AShortName.English = (string)dataReader[ENGLISH_SHORT_NAME];
        }

		private bool fillCompany(ref Company value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillCompany(value, dataReader);
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

        private bool fillCompanyInfo(ref CompanyInfo value, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillCompanyInfo(value, dataReader);
                    result = true;
                }
                else
                { result = false; }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }
		#endregion

//		============================== Public Method ==============================
		public Company GetCompany(string companyCode)
		{
			objCompany = new Company(companyCode);
			objCompany.CompanyCode = companyCode;
			if(FillCompany(ref objCompany))
			{
				return objCompany;		
			}
			else
			{
				objCompany = null;
				return null;
			}
		}

		public bool FillCompany(ref Company value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelectCompany());
			stringBuilder.Append(getKeyCondition(value));
			return fillCompany(ref value, stringBuilder.ToString());
		}

        public bool FillCompany(ref CompanyInfo value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelectCompanyInfo());
            stringBuilder.Append(getKeyCondition(value));
            return fillCompanyInfo(ref value, stringBuilder.ToString());
        }

		public bool InsertCompany(CompanyInfo value)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value))>0)
			{return true;}
			else
			{return false;}	
		}

        public bool UpdateCompany(CompanyInfo value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteCompany(Company value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	}
}
