using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using DataAccess.CommonDB;
using DataAccess.VehicleDB;
using DataAccess.ContractDB;
using DataAccess.ContractDB.ContractChargeRateDB;

using Flow.ContractFlow;
using PTB.BTS.Common.Flow;
using PTB.BTS.ContractEntities.ContractChargeRate;
using SystemFramework.AppException;
using System.Text;
using DataAccess.VehicleDB.VehicleLeasingDB;
using Entity.VehicleEntities.VehicleLeasing;
using ictus.Common.Entity.General;
using Entity.AttendanceEntities;
using Entity.Constants;
using SystemFramework.AppMessage;

namespace PTB.BTS.Contract.Flow
{
    /// <summary>
    ///  Contract Attachment
    /// </summary>
	public class ContractAttachmentFlow : FlowBase
	{
		#region Declaration
	    
        private ContractDB dbContract;
        private ContractAttachmentDB dbContractAttachment;
		
        #endregion

        #region Constructor
        public ContractAttachmentFlow()
            : base()
		{
			dbContract = new ContractDB();
            dbContractAttachment = new ContractAttachmentDB();
        }
        #endregion

        #region Other Private Methods

        private void getAttachmentDetail(ref AttachmentDetailList value, ContractCharge contractCharge)
        {
            ContractChargeDetail contractChargeDetail;
            //DateTime fromDate;
            //if (contractCharge.APeriod.From < DateTime.Today)
            //{
            //    fromDate = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
            //}
            //else
            //{
            //    fromDate = new DateTime(contractCharge.APeriod.From.Year, contractCharge.APeriod.From.Month, 1);
            //}

            //DateTime fromDate = new DateTime(contractCharge.APeriod.From.Year, contractCharge.APeriod.From.Month, 1);
            //DateTime toDate = new DateTime(contractCharge.APeriod.To.Year, contractCharge.APeriod.To.Month, 25);

            //int countMonth = 0;

            //for (DateTime temp = fromDate; temp <= toDate; temp = temp.AddMonths(1))
            //{
            //    ++countMonth;
            //}

            //switch (countMonth)
            //{
            //    case 1:
            //        contractChargeDetail = new ContractChargeDetail();
            //        contractChargeDetail.YearMonth = new YearMonth(fromDate.Year, fromDate.Month);
            //        contractChargeDetail.ChargeAmount = contractCharge.FirstMonthCharge;
            //        value.Add(contractChargeDetail);
            //        break;
            //    case 2:
            //        contractChargeDetail = new ContractChargeDetail();
            //        contractChargeDetail.YearMonth = new YearMonth(fromDate.Year, fromDate.Month);
            //        contractChargeDetail.ChargeAmount = contractCharge.FirstMonthCharge;
            //        value.Add(contractChargeDetail);

            //        contractChargeDetail = new ContractChargeDetail();
            //        contractChargeDetail.YearMonth = new YearMonth(toDate.Year, toDate.Month);
            //        contractChargeDetail.ChargeAmount = contractCharge.LastMonthCharge;
            //        value.Add(contractChargeDetail);
            //        break;
            //    default:

            //        for (int i = 0; i < countMonth; i++)
            //        {
            //            if (i == 0)
            //            {
            //                contractChargeDetail = new ContractChargeDetail();
            //                contractChargeDetail.YearMonth = new YearMonth(fromDate.Year, fromDate.Month);
            //                contractChargeDetail.ChargeAmount = contractCharge.FirstMonthCharge;
            //                value.Add(contractChargeDetail);
            //            }
            //            else if (i == countMonth-1)
            //            {
            //                contractChargeDetail = new ContractChargeDetail();
            //                contractChargeDetail.YearMonth = new YearMonth(toDate.Year, toDate.Month);
            //                contractChargeDetail.ChargeAmount = contractCharge.LastMonthCharge;
            //                value.Add(contractChargeDetail);
            //            }
            //            else 
            //            {
            //                contractChargeDetail = new ContractChargeDetail();
            //                contractChargeDetail.YearMonth = new YearMonth(fromDate.Year, fromDate.Month);
            //                contractChargeDetail.ChargeAmount = contractCharge.MonthlyCharge;
            //                value.Add(contractChargeDetail);
            //            }

            //            fromDate = fromDate.AddMonths(1);
            //        }
            //        break;
            //}
        }

        #endregion

        #region Insert Method

        public bool InsertAttachment(ContractAttachment value, Company aCompany)
		{
			bool result = false;
            TableAccess tableAccess = new TableAccess();
            ContractAttachmentDetailDB dbAttachmentDetail = new ContractAttachmentDetailDB();
            dbContractAttachment.TableAccess = tableAccess;
            dbAttachmentDetail.TableAccess = tableAccess;

            try
            {
                tableAccess.OpenTransaction();
                //Attachment
                result = dbContractAttachment.InsertContractAttachment(value, aCompany);

                //ContractCharge
                if (result && value.AAttachmentDetailList != null && value.AAttachmentDetailList.Count > 0)
                {
                    result = result && dbAttachmentDetail.InsertAttachmentDetail(value.AAttachmentDetailList, value, aCompany);
                }

                if (result)
                {
                    tableAccess.Transaction.Commit();
                }
                else
                {
                    tableAccess.Transaction.Rollback();
                }


            }
            catch (SqlException ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                tableAccess.CloseConnection();
                dbAttachmentDetail = null;
                dbContractAttachment = null;
            }

			return result;
		}
		
        #endregion        

        #region Public Methods

        public DocumentNo GetContractAttachmentNo(string yy, string mm, string xxx)
		{
			return new DocumentNo(DOCUMENT_TYPE.CONTRACT_ATTACHMENT, yy, mm, xxx);
		}

        public List<ContractAttachment> GetContractAttachmentList(DocumentNo attachmentNo, Customer customer, ModelType modelType, Company aCompany)
        {
            using (ContractAttachmentDB db = new ContractAttachmentDB())
            {
                return db.FillAttachmentList(attachmentNo, customer, modelType, aCompany);
            }
        }

        public ContractAttachment RetriveContractAttachment(DocumentNo value, Company aCompany)
		{
            return dbContractAttachment.GetContractAttachment(value, aCompany);
		}

       
        #endregion
    }
}