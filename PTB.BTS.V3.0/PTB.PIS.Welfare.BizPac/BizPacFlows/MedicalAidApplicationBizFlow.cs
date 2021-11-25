using System;
using System.Collections.Generic;
using System.Text;
using ictus.PIS.Welfare.Entity.MedicalAidEntities;
using ictus.Common.Entity;
using ictus.PIS.PI.Entity;
using PTB.PIS.Welfare.BizPac.Transformers;
using PTB.PIS.Welfare.BizPac.DataAccess;
using PTB.PIS.Welfare.BizPac.BizPacEntities;
using PTB.BTS.PI.Flow;
using PTB.BTS.BTS2SAP;

namespace PTB.PIS.Welfare.BizPac.BizPacFlows
{
    internal class MedicalAidApplicationBizFlow
    {

        public List<MedicalAidApplication> FillNoBizPacByFromDateToDAte(Company company, DateTime fromDate, DateTime toDate, bool isAtt)
        {
            List<MedicalAidApplication> apps = EmployeeMedicalAidBizDB.FillNoBizByCompFromDateToDate(company, fromDate, toDate, isAtt);
            foreach (MedicalAidApplication app in apps)
            {
                Employee emp = new Employee(app.AEmployee.EmployeeNo, company);
                EmployeeFlow flow = new EmployeeFlow();
                flow.FillAvailableEmployee(emp, DateTime.Now);
                app.AEmployee = emp;
            }
            return apps;
        }

        // For no Att
        // Kriangkrai A.
        public ConnectBizPacResult UpdateBiz(Company comp, List<MedicalAidApplication> apps, DateTime paymentDate)
        {
            ConnectBizPacResult result = new ConnectBizPacResult();

            DateTime connectDateTime = DateTime.Now;
            result.ConnectDateTime = connectDateTime;
            try
            {
                Transformer transformer = new MedicalAidAppGLTransformer(connectDateTime, apps, paymentDate);
                bool transformCompleted = transformer.Transform();

                result.FileName = transformer.BizPacFile;
                // if write text file completed > update bizpac field in database.
                if (transformCompleted)
                {
                    BizPacDBBase bizTable = new EmployeeMedicalAidBizDB(transformer.ListOfRefNo[0], connectDateTime, comp, apps);
                    bizTable.UpdateData();

                    //result.FileName = transformer.BizPacFile.FileName.ToString();
                    result.FileName = transformer.BizPacFile;
                    result.ListOfRefNo = transformer.ListOfRefNo;

                    return result;
                    //return transformer.ListOfRefNo;

                }
                else
                {
                    //throw new Exception("Cant write CSV file for medical aid");
                    throw new Exception("Cant write XLSX file for medical aid");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // For Att
        public ConnectBizPacResult UpdateBizAtt(Company comp, List<MedicalAidApplication> apps, DateTime postingDate)
        {
            try
            {
                ConnectBizPacResult result = new ConnectBizPacResult();
                DateTime connectDateTime = DateTime.Now;
                result.ConnectDateTime = connectDateTime;

                // Kriangkrai A. 18/2/2018 Modify to transfer to SAP and allow user select posting date from screen
                Transformer transformer = new MedicalAidAPTransformer(connectDateTime, apps, postingDate);
                transformer.Transform();

                //result.FileName = transformer.BizPacFile.FileName.ToString();
                result.FileName = transformer.BizPacFile;

                result.ListOfRefNo = transformer.ListOfRefNo;

                return result;
            }
            catch (Exception ex)
            {
                //string tempEx = ex.Message;
                //throw new Exception("Cant write CSV file for medical aid");
                throw new Exception("Cant write XLSX file for medical aid "+ ex.Message);
            }
        }

        // Kriangkrai A.
        public bool CancelConnect(Company comp, List<ConnectBizPacDetail> details)
        {
            try
            {
                BizPacDBBase bizTable = new EmployeeMedicalAidBizDB();
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
        //        BizPacDBBase bizTable = new EmployeeMedicalAidBizDB();
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
                BizPacDBBase bizTable = new EmployeeMedicalAidBizDB();
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
                BizPacDBBase bizTable = new EmployeeMedicalAidBizDB();
                return bizTable.GetConnectHistoryList(company, refNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
