using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.LoanEntities;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using PTB.PIS.Welfare.BizPac.Transformers;
using PTB.PIS.Welfare.BizPac.DataAccess;
using PTB.PIS.Welfare.BizPac.BizPacEntities;
using PTB.BTS.PI.Flow;
using PTB.BTS.BTS2SAP;

namespace PTB.PIS.Welfare.BizPac.BizPacFlows
{
    internal class LoanApplicationBizFlow
    {
        public List<LoanApplication> FillNoBizPacByFromDateToDAte(Company company, DateTime fromDate, DateTime toDate)
        {
            List<LoanApplication> apps = EmployeeLoanBizDB.FillNoBizByCompFromDateToDate(company, fromDate, toDate);
            foreach (LoanApplication app in apps)
            {
                Employee emp = new Employee(app.Employee.EmployeeNo, company);
                EmployeeFlow flow = new EmployeeFlow();
                flow.FillAvailableEmployee(emp, DateTime.Now);
                app.Employee = emp;
            }
            return apps;
        }

        // Kriangkrai A.
        public ConnectBizPacResult UpdateBiz(Company comp, List<LoanApplication> apps, DateTime paymentDate)
        {
            ConnectBizPacResult result = new ConnectBizPacResult();

            DateTime connectDateTime = DateTime.Now;
            result.ConnectDateTime = connectDateTime;

            Transformer transformer = new LoanAppGLTransformer(connectDateTime, apps, paymentDate);
            bool transformCompleted = transformer.Transform();

            // if write text file completed > update bizpac field in database.
            if (transformCompleted)
            {
                try
                {
                    BizPacDBBase bizTable = new EmployeeLoanBizDB(transformer.ListOfRefNo[0], connectDateTime, comp, apps);
                    //return 
                    bizTable.UpdateData();

                    //result.FileName = transformer.BizPacFile.FileName.ToString();
                    result.FileName = transformer.BizPacFile;
                    result.ListOfRefNo = transformer.ListOfRefNo;

                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                //throw new Exception("cant write CSV file for loan");
                throw new Exception("cant write XLSX file for loan");
            }
        }

        // Kriangkrai A.
        public bool CancelConnect(Company comp, List<ConnectBizPacDetail> details)
        {
            try
            {
                BizPacDBBase bizTable = new EmployeeLoanBizDB();
                return bizTable.CancelConnect(comp, details);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Kriangkrai A. Not use this function because back to use old db framework
        //public bool CancelConnect(Company comp, List<ConnectBizPacDetail> details)
        //{
        //    try
        //    {
        //        BizPacDBBase bizTable = new EmployeeLoanBizDB();
        //        SAPConnectionBase sapConnectBase = new SAPConnectionBase();

        //        foreach (ConnectBizPacDetail item in details)
        //        {
        //            sapConnectBase.CancelConnect2SAP(item.RefNo);
        //        }

        //        return bizTable.CancelConnect(comp, details);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public List<ConnectBizPacDetail> GetConnectHistory(Company company, DateTime fromDate, DateTime toDate)
        {
            try
            {
                BizPacDBBase bizTable = new EmployeeLoanBizDB();
                return bizTable.GetConnectHistoryList(company, fromDate, toDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ConnectBizPacDetail> GetConnectHistory(Company company, string refNo)
        {
            try
            {
                BizPacDBBase bizTable = new EmployeeLoanBizDB();
                return bizTable.GetConnectHistoryList(company, refNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
