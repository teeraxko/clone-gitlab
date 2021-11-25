using System;
using System.Data;
using System.Data.SqlClient;

using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;
namespace PTB.BTS.Report.Flow
{ 
	public class TimeCardForPaymentFlow : FlowBase
	{
        #region Private Variable
        private bool disposed = false;
        #endregion

        #region Constructor
        public TimeCardForPaymentFlow()
            : base()
        { } 
        #endregion

        #region Public Method
        public bool GenerateTimeCardPayment(DateTime value)
        {
            TableAccess tableAccess = new TableAccess();
            SqlCommand command = new SqlCommand("SGenerateTimeCardPayment");
            //command process more than 30 sec : woranai 2008/07/08
            //command process more than 40 sec for 2 users : kriangar 2017/12/15
            command.CommandTimeout = 90;

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
                tableAccess.CloseConnection();
                tableAccess = null;

                command.Dispose();
                command = null;

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
                    { }

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
