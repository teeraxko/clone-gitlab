using System;
using System.Data;
using System.Data.SqlClient;

using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Report.Flow
{
	public class TimeCardForChargeFlow : FlowBase
	{
        #region Private Variable
        private bool disposed = false; 
        #endregion

        #region Constructor
        public TimeCardForChargeFlow()
            : base()
        {
        }
        #endregion

        #region Public Method
        public bool GenerateTimeCardCharge(DateTime value)
        {
            TableAccess tableAccess = new TableAccess();
            SqlCommand command = new SqlCommand("SGenerateTimeCardCharge");
            //command process more than 30 sec : woranai 2008/07/08
            command.CommandTimeout = 40;

            SqlParameter sqlParameter1 = command.Parameters.Add("@Year", SqlDbType.Int);
            sqlParameter1.Value = value.Year;

            SqlParameter sqlParameter2 = command.Parameters.Add("@Month", SqlDbType.TinyInt);
            sqlParameter2.Value = value.Month;

            bool result = false;

            try
            {
                result = (tableAccess.ExecuteStoredProcedure(command) > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Dispose();
                command = null;

                tableAccess.CloseConnection();
                tableAccess = null;

                sqlParameter1 = null;
                sqlParameter2 = null;
            }

            return result;
        } 
        #endregion

        #region IDisposable Members
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                try
                {
                    if (disposing)
                    {}

                    this.disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion
	}
}
