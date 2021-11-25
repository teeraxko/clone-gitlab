using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.PiDB
{
	public class FormerEmployeeGuarantorDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int PERSON_NAME = 1;
		private const int GENDER = 2;
		private const int BIRTH_DATE = 3;
		private const int OCCUPATION = 4;
		private const int RELATIONSHIP = 5;
		private const int CURRENT_ADDRESS_LINE = 6;
		private const int CURRENT_STREET_NAME = 7;
		private const int CURRENT_SUB_DISTRICT  = 8;
		private const int CURRENT_DISTRICT = 9;
		private const int CURRENT_PROVINCE = 10;
		private const int CURRENT_POSTAL_CODE = 11;
		private const int CURRENT_TEL_NO = 12;
		private const int CURRENT_FAX_NO = 13;
		#endregion

		#region - Private -
		private ReferencePerson objReferencePerson;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public FormerEmployeeGuarantorDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Person_Name, Gender, Birth_Date, Occupation, Relationship, Current_Address_Line, Current_Street_Name, Current_Sub_District, Current_District, Current_Province, Current_Postal_Code, Current_Tel_No, Current_Fax_No FROM Former_Employee_Guarantor ";
		}

		private string getSQLInsert(ReferencePerson value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Former_Employee_Guarantor (Company_Code, Employee_No, Person_Name, Gender, Birth_Date, Occupation, Relationship, Current_Address_Line, Current_Street_Name, Current_Sub_District, Current_District, Current_Province, Current_Postal_Code, Current_Tel_No, Current_Fax_No, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Person_Name		
			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(", ");
			
			//Gender
			stringBuilder.Append(GetDB(value.Gender));
			stringBuilder.Append(", ");
			
			//Birth_Date
			stringBuilder.Append(GetDB(value.BirthDate));
			stringBuilder.Append(", ");
			
			//Occupation
			stringBuilder.Append(GetDB(value.AOccupation.Name));
			stringBuilder.Append(", ");
			
			//Relationship
			stringBuilder.Append(GetDB(value.ARelationship.Name));
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

		private string getSQLUpdate(ReferencePerson value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Former_Employee_Guarantor SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Person_Name = ");
			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Gender = ");
			stringBuilder.Append(GetDB(value.Gender));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Birth_Date = ");
			stringBuilder.Append(GetDB(value.BirthDate));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Occupation = ");
			stringBuilder.Append(GetDB(value.AOccupation.Name));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Relationship = ");
			stringBuilder.Append(GetDB(value.ARelationship.Name));
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
			return " DELETE FROM Former_Employee_Guarantor ";
		}

		private string getKeyCondition(ReferencePerson value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.AName.Thai))
			{
				stringBuilder.Append(" AND (Person_Name = ");
				stringBuilder.Append(GetDB(value.AName.Thai));
				stringBuilder.Append(")");			
			}

			return stringBuilder.ToString();
		}
		
		private string getOrderby()
		{
			return " ORDER BY Employee_No, Person_Name ";
		}
		#endregion

		#region - Fill -
		private void fillFormerEmployeeGuarantor(ref ReferencePerson value, SqlDataReader dataReader)
		{
			value.AName.Thai = (string)dataReader[PERSON_NAME];
			value.Gender = CTFunction.GetGenderType((string)dataReader[GENDER]);

			if (dataReader.IsDBNull(BIRTH_DATE))
			{
				value.BirthDate = NullConstant.DATETIME;
			}
			else
			{
				value.BirthDate = dataReader.GetDateTime(BIRTH_DATE);
			}
			
			value.AOccupation.Name = (string)dataReader[OCCUPATION];
			value.ARelationship.Name = (string)dataReader[RELATIONSHIP];
			value.ACurrentAddress.AddressLine = (string)dataReader[CURRENT_ADDRESS_LINE];
			value.ACurrentAddress.StreetName.Name = (string)dataReader[CURRENT_STREET_NAME];
			value.ACurrentAddress.Tambon.Name = (string)dataReader[CURRENT_SUB_DISTRICT];
			value.ACurrentAddress.District.Name = (string)dataReader[CURRENT_DISTRICT];
			value.ACurrentAddress.Province.Name = (string)dataReader[CURRENT_PROVINCE];
			value.ACurrentAddress.PostalCode = (string)dataReader[CURRENT_POSTAL_CODE];
			value.ACurrentAddress.AContactInfo.Telephone = (string)dataReader[CURRENT_TEL_NO];
			value.ACurrentAddress.AContactInfo.Fax = (string)dataReader[CURRENT_FAX_NO];
		}

		private bool fillFormerEmployeeGuarantorList(ref EmployeeReferencePerson value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objReferencePerson = new ReferencePerson();
					fillFormerEmployeeGuarantor(ref objReferencePerson, dataReader);
					value.Add(objReferencePerson);
				}
				objReferencePerson = null;
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();				
			}
			return result;		
		}

		private bool fillFormerEmployeeGuarantor(ref ReferencePerson value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillFormerEmployeeGuarantor(ref value, dataReader);
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

//		============================== internal Method ==============================
		#region - internal -
//		internal bool InsertFormerEmployeeGuarantor(ReferencePerson value, Employee aEmployee)
//		{
//			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
//			{return true;}
//			else
//			{return false;}	
//		}
//
//		internal bool UpdateFormerEmployeeGuarantor(ReferencePerson value, Employee aEmployee)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
//			stringBuilder.Append(getBaseCondition(aEmployee));
//			stringBuilder.Append(getKeyCondition(value));
//
//			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
//			{return true;}
//			else
//			{return false;}
//		}

		internal bool DeleteFormerEmployeeGuarantor(ReferencePerson value, Employee aEmployee, SqlTransaction transaction)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
		#endregion
//		============================== Public Method ==============================
		public ReferencePerson GetFormerEmployeeGuarantor(string personName, Employee aEmployee)
		{
			objReferencePerson = new ReferencePerson();
			objReferencePerson.AName.Thai = personName;

			if(FillFormerEmployeeGuarantor(ref objReferencePerson, aEmployee))
			{
				return objReferencePerson;		
			}
			else
			{
				objReferencePerson = null;
				return null;
			}
		}

		public bool FillFormerEmployeeGuarantor(ref ReferencePerson aReferencePerson, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(aReferencePerson));
			return fillFormerEmployeeGuarantor(ref aReferencePerson, stringBuilder.ToString());
		}

		public bool FillFormerEmployeeGuarantorList (ref EmployeeReferencePerson value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getOrderby());

			return fillFormerEmployeeGuarantorList(ref value, stringBuilder.ToString());
		}

		public bool InsertFormerEmployeeGuarantor(ReferencePerson value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateFormerEmployeeGuarantor(ReferencePerson value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteFormerEmployeeGuarantor(ReferencePerson value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
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
