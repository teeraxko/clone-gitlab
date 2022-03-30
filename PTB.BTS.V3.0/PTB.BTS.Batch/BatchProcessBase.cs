using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTB.BTS.Batch
{
    public abstract class BatchProcessBase
    {
        private string sessionId;
        private string userId;

        protected string UserId
        {
            get
            {
                return this.userId;
            }
        }

        protected string DBConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["DatabaseConnection"];
            }
        }
        protected BatchProcessBase(string batchName)
        {
            if (String.IsNullOrEmpty(batchName))
            {
                throw new InvalidOperationException("Invalid batch name");
            }

            this.sessionId = String.Format("{0}_{1}", batchName, DateTime.Today.ToString("yyyyMMddHHmmss"));
            this.userId = batchName;
            //bizContext = new TTMSEntities();
        }

        public abstract void Execute(params object[] args);
    }


}
