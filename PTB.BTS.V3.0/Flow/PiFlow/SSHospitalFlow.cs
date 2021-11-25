using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.Common.Flow;
using DataAccess.PiDB;

namespace Flow.PiFlow
{
    public class SSHospitalFlow : MTBFlowBase
    {
        public SSHospitalFlow()
            : base()
		{
            dbMTB = new SSHospitalDB();
		}
    }
}
