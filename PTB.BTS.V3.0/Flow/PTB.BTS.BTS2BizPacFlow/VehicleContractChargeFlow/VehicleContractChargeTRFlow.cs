using System;
using System.Data.SqlClient;
using DataAccess.CommonDB;
using ictus.Common.Entity;
using ictus.SystemConnection.BizPac.Core;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFlow.VehicleContractChargeFlow
{
    public class VehicleContractChargeTRFlow : VehicleContractChargeBPFlow
    {
        #region Private Variable
        private int tempRef = 0; 
        #endregion

        #region Constructor
        public VehicleContractChargeTRFlow()
            : base()
        { } 
        #endregion

        #region Protected Method
        protected override void markBizPacRef(IAccountHeader value)
        {
            value.BizPacRefNo = "Temp" + tempRef++;
            value.BizPacRefDate = DateTime.Now;
        } 
        #endregion

        #region Public Method
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
        #endregion
    }
}
