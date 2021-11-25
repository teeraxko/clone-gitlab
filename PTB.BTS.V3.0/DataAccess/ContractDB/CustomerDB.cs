using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;
using Entity.ContractEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.ContractDB
{
	public class CustomerDB : DataAccessBase
	{
		#region - Constant -
		private const int CUSTOMER_CODE = 0;
		private const int CUSTOMER_GROUP_CODE = 1;
		private const int CUSTOMER_CONTRACT_GROUP_CODE = 2;
		private const int ENGLISH_NAME = 3;
		private const int THAI_NAME = 4;
		private const int CURRENT_ADDRESS_LINE = 5;
		private const int CURRENT_STREET_NAME = 6;
		private const int CURRENT_SUB_DISTRICT = 7;
		private const int CURRENT_DISTRICT = 8;
		private const int CURRENT_PROVINCE = 9;
		private const int CURRENT_POSTAL_CODE = 10;
		private const int CURRENT_TEL_NO = 11;
		private const int CURRENT_FAX_NO = 12;
		private const int SHORT_NAME = 13;
		private const int CONTACT_PERSON = 14;
		private const int AUTHORIZED_PERSON = 15;
        private const int AUTHORIZED_PERSON_POSITION = 16;
        private const int AUTHORIZED_SECOND = 17;
        private const int AUTHORIZED_POSITION_SECOND = 18;
        // 4/7/2011 montri j. reconsile with BizPac
        private const int BIZPAC_CODE = 19;
        // 7/5/2019 [Kriangkrai A.] Add field SAP Code to allow user edit/add
        private const int SAP_CODE = 20;

		#endregion

		#region - Private -	
		private Customer objCustomer;
		private CustomerGroupDB dbCustomerGroup;
		private CustomerContractGroupDB dbCustomerContractGroup;
		private bool disposed = false;
		#endregion	
			
//		============================== Constructor ==============================
		public CustomerDB() : base()
		{
			dbCustomerGroup = new CustomerGroupDB();
			dbCustomerContractGroup = new CustomerContractGroupDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
            // 7/5/2019 [Kriangkrai A.] Add field SAP Code to allow user edit/add
            return "SELECT Customer_Code,Customer_Group_Code, Customer_Contract_Group_Code, English_Name, Thai_Name, Current_Address_Line, Current_Street_Name, Current_Sub_District, Current_District, Current_Province, Current_Postal_Code, Current_Tel_No, Current_Fax_No, Short_Name, Contact_Person, Authorized_Person, Authorized_Person_Position, Authorized_Second, Authorized_Position_Second, BizPac_Code, SAP_CODE FROM Customer ";
		}

		private string getSQLInsert(Customer value, Company aCompany)
		{
            // 7/5/2019 [Kriangkrai A.] Add field SAP Code to allow user edit/add
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Customer (Company_Code,BizPac_Code, SAP_CODE, Customer_Code, Customer_Group_Code, Customer_Contract_Group_Code, English_Name, Thai_Name, Short_Name, Contact_Person, Authorized_Person, Authorized_Person_Position, Current_Address_Line, Current_Street_Name, Current_Sub_District, Current_District, Current_Province, Current_Postal_Code, Current_Tel_No, Current_Fax_No, Process_Date, Process_User, Authorized_Second, Authorized_Position_Second) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

            //BizPac_Code			
            stringBuilder.Append(GetDB(value.BizPacCode));
            stringBuilder.Append(", ");

            // 7/5/2019 [Kriangkrai A.] Add field SAP Code to allow user edit/add
            // SAP_CODE
            stringBuilder.Append(GetDB(value.SAPCode));
            stringBuilder.Append(", ");

			//Customer_Code			
			stringBuilder.Append(GetDB(value.Code));
			stringBuilder.Append(", ");

			//Customer_Group_Code
			stringBuilder.Append(GetDB(value.ACustomerGroup.Code));
			stringBuilder.Append(", ");

			//Customer_Contract_Group_Code
			stringBuilder.Append(GetDB(value.ACustomerContractGroup.Code));
			stringBuilder.Append(", ");

			//English_Name
			stringBuilder.Append(GetDB(value.AName.English));
			stringBuilder.Append(", ");
			
			//Thai_Name
			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(", ");

			//Short_Name
			stringBuilder.Append(GetDB(value.ShortName));
			stringBuilder.Append(", ");

			//Contact_Person
			stringBuilder.Append(GetDB(value.ContactPerson));
			stringBuilder.Append(", ");

			//Authorized_Person
			stringBuilder.Append(GetDB(value.AuthorizedPerson));
			stringBuilder.Append(", ");

            //Authorized_Person_Position
            stringBuilder.Append(GetDB(value.AuthorizedPersonPosition));
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

            //Authorized_Second
            stringBuilder.Append(GetDB(value.AuthorizedPerson2));
            stringBuilder.Append(", ");

            //Authorized_Position_Second
            stringBuilder.Append(GetDB(value.AuthorizedPersonPosition2));
            stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(Customer value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Customer SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");
		
			stringBuilder.Append("Customer_Code = ");
			stringBuilder.Append(GetDB(value.Code));
			stringBuilder.Append(", ");

            stringBuilder.Append("BizPac_Code = ");
            stringBuilder.Append(GetDB(value.BizPacCode));
            stringBuilder.Append(", ");

            // 7/5/2019 [Kriangkrai A.] Add field SAP Code to allow user edit/add
            stringBuilder.Append("SAP_CODE = ");
            stringBuilder.Append(GetDB(value.SAPCode));
            stringBuilder.Append(", ");

			stringBuilder.Append("Customer_Group_Code = ");
			stringBuilder.Append(GetDB(value.ACustomerGroup.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("Customer_Contract_Group_Code = ");
			stringBuilder.Append(GetDB(value.ACustomerContractGroup.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("English_Name = ");
			stringBuilder.Append(GetDB(value.AName.English));
			stringBuilder.Append(", ");

			stringBuilder.Append("Thai_Name = ");
			stringBuilder.Append(GetDB(value.AName.Thai));
			stringBuilder.Append(", ");

			stringBuilder.Append("Short_Name = ");
			stringBuilder.Append(GetDB(value.ShortName));
			stringBuilder.Append(", ");

			stringBuilder.Append("Contact_Person = ");
			stringBuilder.Append(GetDB(value.ContactPerson));
			stringBuilder.Append(", ");

			stringBuilder.Append("Authorized_Person = ");
			stringBuilder.Append(GetDB(value.AuthorizedPerson));
			stringBuilder.Append(", ");

            stringBuilder.Append("Authorized_Person_Position = ");
            stringBuilder.Append(GetDB(value.AuthorizedPersonPosition));
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

            stringBuilder.Append("Authorized_Second = ");
            stringBuilder.Append(GetDB(value.AuthorizedPerson2));
            stringBuilder.Append(", ");

            stringBuilder.Append("Authorized_Position_Second = ");
            stringBuilder.Append(GetDB(value.AuthorizedPersonPosition2));
		
			return stringBuilder.ToString();
		}

		private string getSQLDelete()
		{
			return " DELETE FROM Customer ";
		}

		private string getKeyCondition(Customer value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.Code))
			{
				stringBuilder.Append(" AND (Customer_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY English_Name ";
		}
		#endregion

		#region - Fill -
		private void fillCustomer(ref Customer value, Company aCompany, SqlDataReader dataReader)
		{
			value.Code= (string)dataReader[CUSTOMER_CODE];
			value.AName.English = (string)dataReader[ENGLISH_NAME];
			value.AName.Thai = (string)dataReader[THAI_NAME];
			value.ACurrentAddress.AddressLine = (string)dataReader[CURRENT_ADDRESS_LINE];
			value.ACurrentAddress.StreetName.Name = (string)dataReader[CURRENT_STREET_NAME];
			value.ACurrentAddress.Tambon.Name = (string)dataReader[CURRENT_SUB_DISTRICT];
			value.ACurrentAddress.District.Name = (string)dataReader[CURRENT_DISTRICT];
			value.ACurrentAddress.Province.Name = (string)dataReader[CURRENT_PROVINCE];
			value.ACurrentAddress.PostalCode = (string)dataReader[CURRENT_POSTAL_CODE];
			value.ACurrentAddress.AContactInfo.Telephone = (string)dataReader[CURRENT_TEL_NO];
			value.ACurrentAddress.AContactInfo.Fax = (string)dataReader[CURRENT_FAX_NO];
			value.ShortName = (string)dataReader[SHORT_NAME];
			value.ContactPerson = (string)dataReader[CONTACT_PERSON];
			value.AuthorizedPerson = (string)dataReader[AUTHORIZED_PERSON];
            value.AuthorizedPersonPosition = (string)dataReader[AUTHORIZED_PERSON_POSITION];
            value.AuthorizedPerson2 = (string)dataReader[AUTHORIZED_SECOND];
            value.AuthorizedPersonPosition2 = (string)dataReader[AUTHORIZED_POSITION_SECOND];
            value.BizPacCode = (string)dataReader[BIZPAC_CODE];
            // 7/5/2019 [Kriangkrai A.] Add field SAP Code to allow user edit/add
            value.SAPCode = dataReader.IsDBNull(SAP_CODE) ? string.Empty : (string)dataReader[SAP_CODE];
		}

		private void fillCustomerDB(ref Customer value, Company aCompany, SqlDataReader dataReader)
		{
			fillCustomer(ref value, aCompany, dataReader);
			value.ACustomerGroup = (CustomerGroup)dbCustomerGroup.GetDBDualField((string)dataReader[CUSTOMER_GROUP_CODE], aCompany);
			value.ACustomerContractGroup = (CustomerContractGroup)dbCustomerContractGroup.GetDBDualField((string)dataReader[CUSTOMER_CONTRACT_GROUP_CODE], aCompany);			
		}

		private bool fillCustomerList(ref CustomerList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			CustomerGroupList listCustomerGroup = new CustomerGroupList(value.Company);
			dbCustomerGroup.FillMTBList(listCustomerGroup);
			CustomerContractGroupList listCustomerContractGroupList = new CustomerContractGroupList(value.Company);
			dbCustomerContractGroup.FillMTBList(listCustomerContractGroupList);

			try
			{
				while (dataReader.Read())
				{
					result = true;
					objCustomer = new Customer();

					objCustomer.ACustomerGroup = listCustomerGroup[(string)dataReader[CUSTOMER_GROUP_CODE]];
					objCustomer.ACustomerContractGroup = listCustomerContractGroupList[(string)dataReader[CUSTOMER_CONTRACT_GROUP_CODE]];

					fillCustomer(ref objCustomer, value.Company, dataReader);
					value.Add(objCustomer);
				}
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{
				tableAccess.CloseDataReader();
				listCustomerGroup = null;
				listCustomerContractGroupList = null;
				dataReader = null;
			}
			return result;
		}	
	
		private bool fillCustomer(ref Customer aCustomer, Company aCompany,  string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillCustomerDB(ref aCustomer, aCompany, dataReader);
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
		public Customer GetCustomer(string CustomerCode, Company aCompany)
		{
			objCustomer = new Customer();
			objCustomer.Code = CustomerCode;
			if(FillCustomer(ref objCustomer, aCompany))
			{
				return objCustomer;
			}
			else
			{
				objCustomer = null;
				return null;
			}			
		}

		internal Customer GetDBCustomer(string CustomerCode, Company aCompany)
		{
			objCustomer = new Customer();
			objCustomer.Code = CustomerCode;
			if(FillCustomer(ref objCustomer, aCompany))
			{
				return objCustomer;
			}
			else
			{
				objCustomer.Code = NullConstant.STRING;
				return objCustomer;
			}			
		}
		
		public bool FillCustomer(ref Customer value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return fillCustomer(ref value, aCompany, stringBuilder.ToString());
		}

		public bool FillCustomerList(ref CustomerList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillCustomerList(ref value, stringBuilder.ToString());
		}

		public bool InsertCustomer(Customer value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}		
		}

		public bool UpdateCustomer(Customer value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteCustomer(Customer value, Company aCompany)
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
						dbCustomerGroup.Dispose();

						objCustomer = null;
						dbCustomerGroup = null;
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
