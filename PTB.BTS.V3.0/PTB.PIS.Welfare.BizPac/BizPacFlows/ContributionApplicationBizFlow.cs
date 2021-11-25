using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.ContributionEntities;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using PTB.PIS.Welfare.BizPac.Transformers;
using PTB.PIS.Welfare.BizPac.DataAccess;
using PTB.PIS.Welfare.BizPac.BizPacEntities;
using PTB.BTS.PI.Flow;
using PTB.BTS.BTS2SAP;


namespace PTB.PIS.Welfare.BizPac.BizPacFlows
{
    internal class ContributionApplicationBizFlow
    {
        public ContributionApplicationBizFlow()
        {

        }
        public List<ContributionApplication> FillNoBizPacByFromDateToDAte(Company company, DateTime fromDate, DateTime toDate)
        {
            List<ContributionApplication> apps = EmployeeContributionBizDB.FillNoBizPacByFromDateToDAte(company, fromDate, toDate);
            foreach (ContributionApplication app in apps)
            {
                Employee emp = new Employee(app.Employee.EmployeeNo, company);
                EmployeeFlow flow = new EmployeeFlow();
                flow.FillAvailableEmployee(emp, DateTime.Now);
                app.Employee = emp;
            }
            return apps;
        }

        // Kriangkrai A.
        // For not pay to Acc.
        // for SAP use same function thie function will not use
        //public ConnectBizPacResult UpdateBiz(Company comp, List<ContributionApplication> apps)
        //{
        //    ConnectBizPacResult result = new ConnectBizPacResult();

        //    DateTime connectDateTime = DateTime.Now;
        //    result.ConnectDateTime = connectDateTime;

        //    Transformer transformer = new ContributionAppGLTransformer(connectDateTime, apps);
        //    bool transformCompleted = transformer.Transform();

        //    // if write text file completed > update bizpac field in database.
        //    if (transformCompleted)
        //    {
        //        try
        //        {
        //            BizPacDBBase bizTable = new EmployeeContributionBizDB(transformer.ListOfRefNo[0], connectDateTime, comp, apps);
        //            bizTable.UpdateData();

        //            //result.FileName = transformer.BizPacFile.FileName.ToString();
        //            result.FileName = string.Empty;
        //            result.ListOfRefNo = transformer.ListOfRefNo;

        //            return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    else
        //        throw new Exception("cant write CSV file for contribution");
        //}

        // Kriangrkai A.
        //public bool CancelConnect(Company comp, List<ConnectBizPacDetail> details)
        //{
        //    try
        //    {
        //        BizPacDBBase bizTable = new EmployeeContributionBizDB();
        //        return bizTable.CancelConnect(comp, details);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public bool CancelConnect(Company comp, List<ConnectBizPacDetail> details)
        {
            try
            {
                BizPacDBBase bizTable = new EmployeeContributionBizDB();
                SAPConnectionBase sapConnectBase = new SAPConnectionBase();

                //foreach (ConnectBizPacDetail item in details)
                //{
                //    sapConnectBase.CancelConnect2SAP(item.RefNo);
                //}

                return bizTable.CancelConnect(comp, details);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        public List<ConnectBizPacDetail> GetConnectHistory(Company company, DateTime fromDate, DateTime toDate)
        {
            try
            {
                BizPacDBBase bizTable = new EmployeeContributionBizDB();
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
                BizPacDBBase bizTable = new EmployeeContributionBizDB();
                return bizTable.GetConnectHistoryList(company, refNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Kriangkrai A.
        // For not pay to Acc.
        public ConnectBizPacResult UpdateBiz(Company company, List<ContributionApplication> apps, DateTime paymentDate)
        {
            ConnectBizPacResult result = new ConnectBizPacResult();

            DateTime connectDateTime = DateTime.Now;
            result.ConnectDateTime = connectDateTime;

            Transformer transformer = new ContributionAppGLTransformer(connectDateTime, apps, paymentDate);
            bool transformCompleted = transformer.Transform();

            // if write text file completed > update bizpac field in database.
            if (transformCompleted)
            {
                try
                {
                    BizPacDBBase bizTable = new EmployeeContributionBizDB(transformer.ListOfRefNo[0], connectDateTime, company, apps);
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
                //throw new Exception("cant write CSV file for contribution");
                throw new Exception("cant write XLSX file for contribution");
            }
        }
    }
}
