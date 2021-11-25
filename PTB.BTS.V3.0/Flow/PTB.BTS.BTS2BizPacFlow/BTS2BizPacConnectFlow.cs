using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

using ictus.SystemConnection.BizPac;
using ictus.SystemConnection.BizPac.Core;
using ictus.SystemConnection.BizPac.AP;

using PTB.BTS.BTS2BizPacDB;
using PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.Contract.Flow;
using DataAccess.CommonDB;
using ictus.Common.Entity;
using Entity.AttendanceEntities;
using Entity.ContractEntities;
using SystemFramework.AppException;
using PTB.BTS.BTS2SAP;
using System.Globalization;
using System.Threading;

namespace PTB.BTS.BTS2BizPacFlow
{
    public abstract class BTS2BizPacConnectFlow : PTB.BTS.Common.Flow.FlowBase
    {
        protected BizPacConnectTableDB dbBizPacConnectTable;
        protected BizPacConnectBase connectBP;
        protected IBizPacConnectDB dbConnect;
        protected abstract bool SpecificConnect(BTS2BizPacList listBP, BTS2BizPacList resultListBTS, BTS2BizPacList resultListBP);
        protected abstract bool TRConnect(BTS2BizPacList listBP, TableAccess tableAccess, Company company);
        protected abstract string GenerateCSV2SAP(BTS2BizPacList listBP, DateTime connectDate);
        public CultureInfo currentCultureInfo;
        // [TODO] Kriangkrai A.
        //protected abstract string GenerateCSV2SAP(BTS2BizPacList listBP, DateTime connectDate, TableAccess transaction);

        //================================ Constructor =========================
        public BTS2BizPacConnectFlow()
            : base()
        {
            dbBizPacConnectTable = new BizPacConnectTableDB();
            connectBP = new BizPacCSVConnect();
        }

        #region - SpecificConnect -
        protected DocumentNoFlow flowDocumentNo;

        protected virtual void markBizPacRef(IAccountHeader value)
        {
            if (flowDocumentNo == null)
            {
                flowDocumentNo = new DocumentNoFlow();
            }
            value.BizPacRefNo = flowDocumentNo.GetBizPacRefNo();
            value.BizPacRefDate = DateTime.Now;
        }

        public void MarkBizPacRef(IAccountHeader value)
        {
            markBizPacRef(value);
        }

        protected void copyBizPacRef(IAccountHeader from, IAccountHeader to)
        {
            to.BizPacRefNo = from.BizPacRefNo;
            to.BizPacRefDate = from.BizPacRefDate;
        }

        //protected void clearMarkBizPacRef(BTS2BizPacList list)
        //{
        //    BTS2BizPacList tempResult = new BTS2BizPacList();
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i].BizPacRefNo == "" || list[i].BizPacRefNo == null)
        //        {
        //            tempResult.Add(list[i]);
        //        }
        //    }

        //    list.Clear();

        //    for (int i = 0; i < tempResult.Count; i++)
        //    {
        //        list.Add(tempResult[i]);
        //    }
        //    tempResult = null;
        //}

        protected virtual void markBizPacRefByTaxInvoice(BTS2BizPacList list, BTS2BizPacList btsResults, BTS2BizPacList bizpacResults)
        {
            IBTS2BizPacHeader data;
            for (int i = 0; i < list.Count; i++)
            {
                data = list[i];
                if (((IAPHeader)data).HaveTaxInvoice)
                {
                    markBizPacRef(data);
                    btsResults.Add(data);
                    bizpacResults.Add(data);
                }
            }            

            BTS2BizPacList tempResult = new BTS2BizPacList();
            for (int i = 0; i < list.Count; i++)
            {
                data = list[i];
                if (!((IAPHeader)data).HaveTaxInvoice)
                {
                    tempResult.Add(list[i]);
                }
            }
            list.Clear();
            for (int i = 0; i < tempResult.Count; i++)
            {
                list.Add(tempResult[i]);
            }
            tempResult = null;
            data = null;
        }

        protected int GetDays(TimePeriod period, ictus.Common.Entity.Time.YearMonth yearMonth)
        {
            if (period.From <= yearMonth.MinDateOfMonth)
            {
                if (yearMonth.MaxDateOfMonth <= period.To)
                {
                    return yearMonth.DaysInMonth;
                }
                else
                {
                    return period.To.Day;
                }
            }
            else
            {
                if (yearMonth.MaxDateOfMonth <= period.To)
                {
                    return yearMonth.DaysInMonth - period.From.Day + 1;
                }
                else
                {
                    return period.To.Day - period.From.Day + 1;
                }
            }
        }

        protected TimePeriod GetAssignPeriod(TimePeriod conditionPeriod, ictus.Common.Entity.Time.YearMonth yearMonth)
        {
            TimePeriod timePeriod = new TimePeriod();

            if (conditionPeriod.From.Date < yearMonth.MinDateOfMonth.Date)
            {
                timePeriod.From = yearMonth.MinDateOfMonth.Date;
            }
            else
            {
                timePeriod.From = conditionPeriod.From.Date;
            }

            if (conditionPeriod.To.Date > yearMonth.MaxDateOfMonth.Date)
            {
                timePeriod.To = yearMonth.MaxDateOfMonth.Date;
            }
            else
            {
                timePeriod.To = conditionPeriod.To.Date;
            }

            return timePeriod;
        }
        #endregion
        //============================= Public method =============================
        public bool FillBPList(BTS2BizPacList listBP, Company company)
        {
            return dbBizPacConnectTable.FillBPList(dbConnect, listBP, company);
        }

        public bool FillCancelBPList(BTS2BizPacList listBP, TimePeriod period, Company company)
        {
            return dbBizPacConnectTable.FillCancelBPList(dbConnect, listBP, period, company);
        }

        public bool FillRerunBPList(BTS2BizPacList listBP, DateTime connectDate, Company company)
        {
            return dbBizPacConnectTable.FillRerunBPList(dbConnect, listBP, connectDate, company);
        }

        public bool BizPacRerun(BTS2BizPacList listBP, Customer customer, DateTime connectDate, Company company)
        {
            if (dbBizPacConnectTable.FillRerunBPList(dbConnect, listBP, connectDate, company))
            {
                string fileName = string.Empty;

                if (customer != null && customer.Code != Customer.DUMMYCODE)
                {
                    BTS2BizPacList bpList = new BTS2BizPacList();
                    foreach (IBTS2BizPacHeader bpHeader in listBP)
                    {
                        if (bpHeader.PaidToCode == customer.Code)
                        {
                            bpList.Add(bpHeader);
                        }
                    }

                    if (bpList.Count > 0)
                    {
                        return Connect(bpList, ref fileName, company);
                    }
                    else
                    {
                        AppExceptionBase appEx = new AppExceptionBase("BTS2BizPacConnectFlow");
                        appEx.SetMessage("ไม่พบข้อมูลประจำเดือน");
                        throw appEx; 
                    }
                }

                return Connect(listBP, ref fileName, company);
            }
            else
            {
                AppExceptionBase appEx = new AppExceptionBase("BTS2BizPacConnectFlow");
                appEx.SetMessage("ไม่พบข้อมูลประจำเดือน");
                throw appEx;   
            }
        }

        public virtual bool Connect(BTS2BizPacList listBP, ref string fileName, Company company)
        {
            bool result = false;
            BTS2BizPacList resultListBTS = new BTS2BizPacList();
            BTS2BizPacList resultListBP = new BTS2BizPacList();

            if (SpecificConnect(listBP, resultListBTS, resultListBP))
            {
                TableAccess tableAccess = new TableAccess();

                StringBuilder stringBuilder = new StringBuilder();

                //-----
                for (int i = 0; i < resultListBTS.Count; i++)
                {
                    stringBuilder.Append(dbBizPacConnectTable.Connect(dbConnect, resultListBTS[i], company));
                }

                try
                {
                    currentCultureInfo = Thread.CurrentThread.CurrentCulture;

                    tableAccess.OpenTransaction();

                    result = TRConnect(resultListBTS, tableAccess, company);

                    dbBizPacConnectTable.TableAccess = tableAccess;

                    if (resultListBTS.Count > 0 && dbBizPacConnectTable.ExecuteCommand(stringBuilder.ToString()))
                    {
                        // Kriangkrai A. 13/2/2019 Change way to connect to SAP
                        //// Generate CSV file
                        //string resultFileName = connectBP.Connect(resultListBP);

                        string resultFileName = GenerateCSV2SAP(resultListBP, listBP.ConnectDate);

                        // Kriangkrai A. 4/2/2019 No need to transfer file via FTP
                        //string resultFileName = GenerateCSV2SAP(resultListBP, listBP.ConnectDate, tableAccess);
                        //connectBP.Connect(resultFileName); // Transfer file via FTP

                        result &= (resultFileName != "");
                        fileName = resultFileName;
                    }

                    if (result)
                    {
                        tableAccess.Transaction.Commit();
                        result = true;
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
                    tableAccess.Transaction = null;
                    tableAccess = null;
                    
                    stringBuilder = null;

                    Thread.CurrentThread.CurrentCulture = currentCultureInfo;
                }
            }
            resultListBTS = null;
            resultListBP = null;

            return result;
        }

        public bool Cancel(BTS2BizPacList listBP, Company company)
        {
            bool result = false;
            bool resultSAP = false;

            TableAccess tableAccess = new TableAccess();
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilderSAP = new StringBuilder();

            for (int i = 0; i < listBP.Count; i++)
            {
                stringBuilder.Append(dbBizPacConnectTable.Cancel(dbConnect, listBP[i], company));
                //[Napat C.] 18/02/2019 add this to set IsDelete after cancel transfer
                stringBuilderSAP.Append(dbBizPacConnectTable.CancelSAP(dbConnect, listBP[i], company));
            }

            try
            {
                tableAccess.OpenTransaction();

                dbBizPacConnectTable.TableAccess = tableAccess;

                //[Napat C.] 18/02/2019 add this to set IsDelete after cancel transfer
                resultSAP = dbBizPacConnectTable.ExecuteCommand(stringBuilderSAP.ToString());
                //resultSAP = true;
                if (resultSAP)
                {
                    //bool bizpacRefNo = dbBizPacConnectTable.FillBPList(dbConnect, listBP, company);
                    //for (int i = 0; i < listBP.Count; i++)
                    //{
                    //    var details = listBP[i];
                    //    (new SAPConnectionBase()).CancelConnect2SAP(details.AdditionalInfo);
                    //}
                    result = dbBizPacConnectTable.ExecuteCommand(stringBuilder.ToString());

                    if (result)
                    {
                        tableAccess.Transaction.Commit();
                        result = true;
                        resultSAP = true;
                    }
                    else 
                    {
                        tableAccess.Transaction.Rollback();
                    }
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
                stringBuilder = null;
            }

            return result;
        }
    }
}
