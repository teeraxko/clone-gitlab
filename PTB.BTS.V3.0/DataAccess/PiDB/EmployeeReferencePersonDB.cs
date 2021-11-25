using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.General;

namespace DataAccess.PiDB
{
	public class EmployeeReferencePersonDB : DataAccessBase
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
		public EmployeeReferencePersonDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Person_Name, Gender, Birth_Date, Occupation, Relationship, Current_Address_Line, Current_Street_Name, Current_Sub_District, Current_District, Current_Province, Current_Postal_Code, Current_Tel_No, Current_Fax_No FROM Employee_Reference_Person ";
		}

		private string getSQLInsert(ReferencePerson value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Employee_Reference_Person (Company_Code, Employee_No, Person_Name, Gender, Birth_Date, Occupation, Relationship, Current_Address_Line, Current_Street_Name, Current_Sub_District, Current_District, Current_Province, Current_Postal_Code, Current_Tel_No, Current_Fax_No, Process_Date, Process_User) ");
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
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Reference_Person SET ");
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
			return " DELETE FROM Employee_Reference_Person ";
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
		private void fillEmployeeReferencePerson(ref ReferencePerson value, SqlDataReader dataReader)
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

		private bool fillEmployeeReferencePersonList(ref EmployeeReferencePerson value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objReferencePerson = new ReferencePerson();
					fillEmployeeReferencePerson(ref objReferencePerson, dataReader);
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

		private bool fillEmployeeReferencePerson(ref ReferencePerson value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillEmployeeReferencePerson(ref value, dataReader);
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

		private void UpdateSingleField(ReferencePerson value)
		{
			OccupationDB dbOccupation = new OccupationDB();
			Occupation occupation = new Occupation();
			occupation.Name = value.AOccupation.Name;
			dbOccupation.UpdateMTB(occupation);

			RelationshipDB dbRelation = new RelationshipDB();
			Relationship relationship = new Relationship();
			relationship.Name = value.ARelationship.Name;
			dbRelation.UpdateMTB(relationship);

			StreetDB dbStreet = new StreetDB();
			Street street = new Street();
			street.Name = value.ACurrentAddress.StreetName.Name;
			dbStreet.UpdateMTB(street);

			SubDistrictDB dbSubDistrict = new SubDistrictDB();
			SubDistrict subDistrict = new SubDistrict();
			subDistrict.Name = value.ACurrentAddress.Tambon.Name;
			dbSubDistrict.UpdateMTB(subDistrict);

			DistrictDB dbDistrict = new DistrictDB();
			District district = new District();
			district.Name = value.ACurrentAddress.District.Name;
			dbDistrict.UpdateMTB(district);

			ProvinceDB dbProvince = new ProvinceDB();
			Province province = new Province();
			province.Name = value.ACurrentAddress.Province.Name;
			dbProvince.UpdateMTB(province);
		}
//		============================== internal Method ==============================
		#region - internal -
		internal bool MaintainEmployeeReferencePerson(ReferencePerson newReferencePerson, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));

			stringBuilder.Append(getSQLInsert(newReferencePerson, aEmployee));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{
				UpdateSingleField(newReferencePerson);
				return true;}
			else
			{return false;}	
		}
		#endregion
//		============================== Public Method ==============================
		public ReferencePerson GetReferencePerson(string personName, Employee aEmployee)
		{
			objReferencePerson = new ReferencePerson();
			objReferencePerson.AName.Thai = personName;

			if(FillEmployeeReferencePerson(ref objReferencePerson, aEmployee))
			{
				return objReferencePerson;		
			}
			else
			{
				objReferencePerson = null;
				return null;
			}
		}

		public bool FillEmployeeReferencePerson(ref ReferencePerson value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));
			return fillEmployeeReferencePerson(ref value, stringBuilder.ToString());
		}

		public bool FillEmployeeReferencePersonList (ref EmployeeReferencePerson value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getOrderby());

			return fillEmployeeReferencePersonList(ref value, stringBuilder.ToString());
		}

		public bool InsertEmployeeReferencePerson(ReferencePerson value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{
				UpdateSingleField(value);
				return true;
			}
			else
			{return false;}	
		}

		public bool UpdateEmployeeReferencePerson(ReferencePerson value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
//			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{
				UpdateSingleField(value);
				return true;
			}
			else
			{return false;}
		}

		public bool DeleteEmployeeReferencePerson(ReferencePerson value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
//			stringBuilder.Append(getKeyCondition(value));

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
