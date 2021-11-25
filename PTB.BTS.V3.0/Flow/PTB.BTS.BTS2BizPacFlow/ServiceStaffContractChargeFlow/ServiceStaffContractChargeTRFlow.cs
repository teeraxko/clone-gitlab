using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity;
using PTB.BTS.BTS2BizPacEntity;
using ictus.SystemConnection.BizPac.Core;
using DataAccess.CommonDB;
using System.Data.SqlClient;

namespace PTB.BTS.BTS2BizPacFlow.ServiceStaffContractChargeFlow
{
    public class ServiceStaffContractChargeTRFlow : ServiceStaffContractChargeBPFlow
    {
        //============================ Constructor ================================
        public ServiceStaffContractChargeTRFlow()
            : base()
        {

        }

        //============================ Method ================================
        private int tempRef = 0;
        protected override void markBizPacRef(IAccountHeader value)
        {
            value.BizPacRefNo = "Temp" + tempRef++;
            value.BizPacRefDate = DateTime.Now;
        }

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
