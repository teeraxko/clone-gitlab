using System;

using Entity.AttendanceEntities;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class AnnualLeaveControlFlow : FlowBase
	{
		#region - Private -
		private AnnualLeaveControlDB dbAnnualLeaveControl;
		#endregion - Private -

//		============================== Constructor ==============================
		public AnnualLeaveControlFlow() : base()
		{
			dbAnnualLeaveControl = new AnnualLeaveControlDB();
		}

//		============================== Public Method ==============================
		public AnnualLeaveControl GetAnnualLeaveControl(int forYear, Company aCompany)
		{
			return dbAnnualLeaveControl.GetAnnualLeaveControl(forYear, aCompany);
		}

		public bool FillAnnualLeaveControl(ref AnnualLeaveControl value, Company aCompany)
		{
			return dbAnnualLeaveControl.FillAnnualLeaveControl(ref value, aCompany);
		}

		public bool InsertAnnualLeaveControl(AnnualLeaveControl value, Company aCompany)
		{
			return dbAnnualLeaveControl.InsertAnnualLeaveControl(value, aCompany);
		}

		public bool UpdateAnnualLeaveControl(AnnualLeaveControl value, Company aCompany)
		{
			return dbAnnualLeaveControl.UpdateAnnualLeaveControl(value, aCompany);	
		}
		
		public bool DeleteAnnualLeaveControl(AnnualLeaveControl value, Company aCompany)
		{
			return dbAnnualLeaveControl.DeleteAnnualLeaveControl(value, aCompany);		
		}
	}
}
