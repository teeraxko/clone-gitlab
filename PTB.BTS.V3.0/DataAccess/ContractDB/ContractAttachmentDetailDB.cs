using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using DataAccess.CommonDB;

using Entity.ContractEntities;

using Entity.CommonEntity;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace DataAccess.ContractDB
{
    public class ContractAttachmentDetailDB : DataAccessBase, DataAccess.CommonDB.ITableName
    {
        #region - Constant 
        private const int ATTACHMENT_NO = 0;
        private const int CONTRACT_NO = 1;
        #endregion

        #region - Private -
        private AttachmentDetail objAttachmentDetail;
        private bool disposed = false;

        private VehicleContractDB dbVehicleContract;
        private ContractTypeDB dbContractType;
        private ContractDB dbContract;
        #endregion

        #region Constructor 
        public ContractAttachmentDetailDB()
            : base()
        {
            dbVehicleContract = new VehicleContractDB();
            dbContractType = new ContractTypeDB();
            dbContract = new ContractDB();
        }

        #endregion

        
        #region - getSQL -
        /// <summary>
        /// SQL Select command
        /// </summary>
        /// <returns></returns>
        private string getSQLSelect()
        {
            return "SELECT Attachment_No, Contract_No FROM Contract_Attachment_Detail ";
        }

        /// <summary>
        /// SQL Insert commmand
        /// </summary>
        /// <param name="aAttachmentDetail"></param>
        /// <param name="aContractAttachment"></param>
        /// <param name="aCompany"></param>
        /// <returns></returns>
        private string getSQLInsert(AttachmentDetail aAttachmentDetail, ContractAttachment aContractAttachment, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Contract_Attachment_Detail (Company_Code, Attachment_No, Contract_No, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code			
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Attachment_No
            stringBuilder.Append(GetDB(aContractAttachment.AttachmentNo.ToString()));
            stringBuilder.Append(", ");

            //Contract_No
            stringBuilder.Append(GetDB(aAttachmentDetail.ContractNo.ToString()));
            stringBuilder.Append(", ");            

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }
       
        /// <summary>
        /// Key condition (Attachment_No) command
        /// </summary>
        /// <param name="attachmentNo"></param>
        /// <returns></returns>
        private string getKeyCondition(DocumentNo attachmentNo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (attachmentNo != null)
            {
                if (IsNotNULL(attachmentNo.Year) && IsNotNULL(attachmentNo.Month) && IsNotNULL(attachmentNo.No))
                {
                    stringBuilder.Append(" AND (Attachment_No = ");
                    stringBuilder.Append(GetDB(attachmentNo.ToString()));
                    stringBuilder.Append(")");
                }
                else
                {
                    if (IsNotNULL(attachmentNo.Year))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Attachment_No, 7, 2) = ");
                        stringBuilder.Append(GetDB(attachmentNo.Year));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(attachmentNo.Month))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Attachment_No, 9, 2) = ");
                        stringBuilder.Append(GetDB(attachmentNo.Month));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(attachmentNo.No))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Attachment_No, 11, 3) = ");
                        stringBuilder.Append(GetDB(attachmentNo.No));
                        stringBuilder.Append(")");
                    }
                }
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Order by command
        /// </summary>
        /// <returns></returns>
        private string getOrderby()
        {
            return " ORDER BY Attachment_No, Contract_No ";
        }
        #endregion

        #region - Fill -
        /// <summary>
        /// Fill attachment detail
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dataReader"></param>
        private void FillContractAttachmentDetail(ref AttachmentDetail value, SqlDataReader dataReader)
        {
            value.ContractNo = new DocumentNo((string)dataReader[CONTRACT_NO]);
        }

        protected virtual AttachmentDetail getNewAttachmentDetail()
        {
            return new AttachmentDetail();
        }

        /// <summary>
        /// Fill attachment detail
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sql"></param>
        /// <param name="aCompany"></param>
        /// <returns></returns>
        private bool FillAttachmentDetailList(ref AttachmentDetailList value, string sql, Company aCompany)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    objAttachmentDetail = getNewAttachmentDetail();
                    //File Attachment Contracl Detail
                    FillContractAttachmentDetail(ref objAttachmentDetail, dataReader);
                    //Get Vehicle Contract
                    objAttachmentDetail.AVehicleContract = dbVehicleContract.GetVehicleContract(objAttachmentDetail.ContractNo, aCompany);
                    //Get Contract Object
                    objAttachmentDetail.AContract = dbContract.GetAllContract(objAttachmentDetail.ContractNo, aCompany);
                    value.Add(objAttachmentDetail);
                }
                objAttachmentDetail = null;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }
            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }
        #endregion

        //============================== Public Method ==============================
        /// <summary>
        /// Fill attachment detail
        /// </summary>
        /// <param name="value"></param>
        /// <param name="aCompany"></param>
        /// <returns></returns>
        public bool FillAttachmentDetailList(ref AttachmentDetailList value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value.AContractAttachment.AttachmentNo));
            stringBuilder.Append(getOrderby());

            return FillAttachmentDetailList(ref value, stringBuilder.ToString(), aCompany);
        }      
       
        //============================== Specific Method ==============================

        /// <summary>
        /// Insert Attachment Detail 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="contractAttachment"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public bool InsertAttachmentDetail(AttachmentDetailList value, ContractAttachment contractAttachment, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < value.Count; i++)
            {
                stringBuilder.Append(getSQLInsert(value[i], contractAttachment, value.Company));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }
      
        #region IDisposable Members
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                try
                {
                    if (disposing)
                    {
                        objAttachmentDetail = null;
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

        #region ITableName Members

        public string TableName
        {
            get { return "Contract_Attachment_Detail"; }
        }

        #endregion
    }
}
