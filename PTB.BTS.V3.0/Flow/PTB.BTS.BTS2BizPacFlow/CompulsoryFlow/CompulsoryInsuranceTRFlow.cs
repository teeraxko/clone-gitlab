using System;
using ictus.SystemConnection.BizPac.Core;
using PTB.BTS.BTS2BizPacEntity;
using ictus.Common.Entity;
using DataAccess.CommonDB;
using System.Data.SqlClient;
using PTB.BTS.BTS2SAP;

namespace PTB.BTS.BTS2BizPacFlow.CompulsoryFlow
{
    public class CompulsoryInsuranceTRFlow : CompulsoryInsuranceBPFlow
    {
        //============================ Constructor ================================
        public CompulsoryInsuranceTRFlow() : base()
        {
        }

        //============================ Method ================================
        protected override void markBizPacRef(IAccountHeader value)
        { 
        }
        // Kriangkrai A. 14/2/2019 Change way to connect to SAP
        //public override bool Connect(BTS2BizPacList listBP, ref string fileName, Company company)
        //{
        //    bool result = false;
        //    BTS2BizPacList resultListBTS = new BTS2BizPacList();
        //    BTS2BizPacList resultListBP = new BTS2BizPacList();

        //    SpecificConnect(listBP, resultListBTS, resultListBP);
        //    TableAccess tableAccess = new TableAccess();

        //    try
        //    {
        //        tableAccess.OpenTransaction();

        //        result = TRConnect(resultListBTS, tableAccess, company);

        //        if (result)
        //        {
        //            tableAccess.Transaction.Commit();
        //            result = true;
        //        }
        //        else
        //        {
        //            tableAccess.Transaction.Rollback();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        tableAccess.Transaction.Rollback();
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        tableAccess.Transaction.Rollback();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        tableAccess.CloseConnection();
        //    }
            
        //    return result;
        //}

        public override bool Connect(BTS2BizPacList listBP, ref string fileName, Company company)
        {
            bool result = false;
            BTS2BizPacList resultListBTS = new BTS2BizPacList();
            BTS2BizPacList resultListBP = new BTS2BizPacList();

            SpecificConnect(listBP, resultListBTS, resultListBP);
            TableAccess tableAccess = new TableAccess();

            try
            {
                tableAccess.OpenTransaction();

                result = TRConnect(resultListBTS, tableAccess, company);

                //// Kriangkrai A. 14/2/2018 Change way to connect to SAP
                //ConnectCompulsory2SAP sapConnection = new ConnectCompulsory2SAP();
                //fileName = sapConnection.GetCompulsorySAPDataFile(resultListBP, listBP.ConnectDate);

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
            }

            return result;
        }
    }
}
