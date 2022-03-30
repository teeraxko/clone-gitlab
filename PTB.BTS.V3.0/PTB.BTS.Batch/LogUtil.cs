using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTB.BTS.Batch
{
    public static class LogUtil
    {
        private static log4net.ILog log;

        public static log4net.ILog Logger
        {
            get { return log; }
        }

        public static void InitialLog()
        {
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}
