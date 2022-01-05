using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.CommonDB;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Entity.VehicleEntities;
using Entity.ContractEntities;
using DataAccess.VehicleDB;
using ictus.Common.Entity;
using SystemFramework.AppConfig;

namespace DataAccess.ContractDB
{
    public class ContractAttachmentDB : DataAccessBase
    {
        #region Constant
        private const int ATTACHMENT_NO = 0;
        private const int CUSTOMER_CODE = 1;
        private const int VEHICLEMODELTYPE = 2;
        private const int REMARK = 3;        
        #endregion

        private AttachmentList objAttachmentList;
        private ContractAttachment objContractAttachment;
        private CustomerDB dbCustomer;
        private ModelTypeDB dbModelType;
        private ContractAttachmentDetailDB dbContractAttachmentDetail;
//      ============================== Constructor ==============================
        public ContractAttachmentDB()
            : base()
		{
            dbCustomer = new CustomerDB();
            dbModelType = new ModelTypeDB();
            dbContractAttachmentDetail = new ContractAttachmentDetailDB();
		}

        private string getSQLSelect()
        {
            return "SELECT Attachment_No, Customer_Code, VehicleModelType, Remark FROM Contract_Attachment_Head ";
        }

        private string getOrderby()
        {
            return " ORDER BY Attachment_No ";
        }

        private string getKeyCondition(DocumentNo value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (value != null)
            {
                if (IsNotNULL(value.Year) && IsNotNULL(value.Month) && IsNotNULL(value.No))
                {
                    stringBuilder.Append(" AND (Attachment_No = ");
                    stringBuilder.Append(GetDB(value.ToString()));
                    stringBuilder.Append(")");
                }
                else
                {
                    if (IsNotNULL(value.Year))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Attachment_No, 7, 2) = ");
                        stringBuilder.Append(GetDB(value.Year));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(value.Month))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Attachment_No, 9, 2) = ");
                        stringBuilder.Append(GetDB(value.Month));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(value.No))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Attachment_No, 11, 3) = ");
                        stringBuilder.Append(GetDB(value.No));
                        stringBuilder.Append(")");
                    }
                }
            }
            return stringBuilder.ToString();
        }

        private string getSQLInsert(ContractAttachment value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Contract_Attachment_Head (Company_Code,   Attachment_No, Customer_Code, VehicleModelType, Remark, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code			
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Attachment_No
            stringBuilder.Append(GetDB(value.AttachmentNo.ToString()));
            stringBuilder.Append(", ");

            //Customer
            stringBuilder.Append(GetDB(value.ACustomer.EntityKey));
            stringBuilder.Append(", ");

            //VehicleModelType
            stringBuilder.Append(GetDB(value.AModelType.EntityKey));
            stringBuilder.Append(", ");

            //Remark
            stringBuilder.Append(GetDB(value.Remark == null ? "" : value.Remark));
            stringBuilder.Append(", ");            

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        public List<ContractAttachment> FillAttachmentList(DocumentNo attachmentNo, Customer customer, ModelType modelType, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(attachmentNo));

            if (customer != null)
            {
                stringBuilder.Append(" AND (Customer_Code = ");
                stringBuilder.Append(GetDB(customer.EntityKey));
                stringBuilder.Append(")");
            }

            if (modelType != null)
            {
                stringBuilder.Append(" AND (VehicleModelType = ");
                stringBuilder.Append(GetDB(modelType.EntityKey));
                stringBuilder.Append(")");
            }

            stringBuilder.Append(getOrderby());

            return FillAttachmentList(aCompany,stringBuilder.ToString());
        }

        private List<ContractAttachment> FillAttachmentList(Company aCompany, string sql)
        {
            List<ContractAttachment> value = new List<ContractAttachment>();
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                while (dataReader.Read())
                {
                    objContractAttachment = new ContractAttachment(aCompany);
                    FillContractAttachment(ref objContractAttachment, aCompany, dataReader);
                    value.Add(objContractAttachment);
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
            return value;
        }

        private bool FillContractAttachment(ref ContractAttachment value, Company aCompany, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    FillContractAttachment(ref value, aCompany, dataReader);
                    result = true;
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

        private void FillContractAttachment(ref ContractAttachment value, Company aCompany, SqlDataReader dataReader)
        {

            value.AttachmentNo = new DocumentNo((string)dataReader[ATTACHMENT_NO]);
            value.ACustomer = dbCustomer.GetCustomer((string)dataReader[CUSTOMER_CODE], aCompany);
            value.AModelType = (ModelType)dbModelType.GetMTB((string)dataReader[VEHICLEMODELTYPE]);
            value.Remark = dataReader.GetString(REMARK);
            AttachmentDetailList attachmentDetailList = new AttachmentDetailList(aCompany);
            attachmentDetailList.AContractAttachment = value;

            dbContractAttachmentDetail.FillAttachmentDetailList(ref attachmentDetailList, aCompany);
            value.AAttachmentDetailList = attachmentDetailList;
        }

        public ContractAttachment GetContractAttachment(DocumentNo attachmentNo, Company aCompany)
        {
            if (IsNotNULL(attachmentNo.No.Trim()))
            {
                StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
                stringBuilder.Append(getBaseCondition(aCompany));
                stringBuilder.Append(getKeyCondition(attachmentNo));

                objContractAttachment = new ContractAttachment(aCompany);

                if (FillContractAttachment(ref objContractAttachment, aCompany, stringBuilder.ToString()))
                {
                    return objContractAttachment;
                }
                else
                {
                    objContractAttachment = null;
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool InsertContractAttachment(ContractAttachment value, Company aCompany)
        {
            return (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany)) > 0);
        }
    }
}
