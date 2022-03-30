using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Reflection;
using System.Configuration;

namespace PTB.BTS.Batch
{
    class Program
    {
        
        [STAThread]
        static void Main(string[] args)
        {
            LogUtil.InitialLog();            
            batchProcess(args);
        }

        static void batchProcess(string[] args)
        {
            if (args.Length == 0)
            {
                LogUtil.Logger.InfoFormat("Invalid parameter : {0}.", String.Join(",", args));
                return;
            }

            string batchName = args[0];

            try
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                BatchProcessBase process;

                process = (BatchProcessBase)Assembly.GetExecutingAssembly().CreateInstance(ConfigurationManager.AppSettings[batchName]);
                //process.Updating += new EventHandler<BatchEventArgs>(BatchUpdating);
                LogUtil.Logger.InfoFormat("Batch {0} started.", batchName);
                process.Execute(args);
                LogUtil.Logger.InfoFormat("Batch {0} completed.", batchName);

            }
            catch (Exception ex)
            {
                LogUtil.Logger.ErrorFormat("Batch {0} fail:", batchName);
                LogUtil.Logger.Error(ex);
            }
        }
    }
}
