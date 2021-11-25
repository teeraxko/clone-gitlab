using System;

using PTB.BTS.Common.Flow;

using DataAccess.CommonDB;

namespace PTB.BTS.Common.Flow
{
	public class FacultyFlow : MTBFlowBase
	{
		public FacultyFlow() : base()
		{
			dbMTB = new FacultyDB();
		}
	}
}
