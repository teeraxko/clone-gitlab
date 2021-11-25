using System;

using PTB.BTS.Common.Flow;
using Flow.AttendanceFlow;

using DataAccess.AttendanceDB;

namespace Flow.AttendanceFlow
{
	public class DiseaseFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public DiseaseFlow() : base()
		{
			dbMTB = new DiseaseDB();
		}
	}
}
