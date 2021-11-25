using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.BTS2BizPacFlow.BizPacImplementFlow;
using PTB.BTS.BTS2BizPacEntity;
using ictus.Common.Entity;
using DataAccess.CommonDB;
using System.Data.SqlClient;
using ictus.SystemConnection.BizPac.Core;

namespace PTB.BTS.BTS2BizPacFlow.VehicleExcessFlow
{
    public class VehicleExcessTRFlow : VehicleExcessBPFlow
    {
        //============================ Constructor ================================
        public VehicleExcessTRFlow()
            : base()
        {}

        //============================ Method ================================
        protected override void markBizPacRef(IAccountHeader value)
        { }

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
