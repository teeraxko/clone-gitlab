using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.AttendanceEntities;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class WorkingTimeConditionFlow: FlowBase
	{		
		#region - Private -
		private WorkingTimeConditionDB dbWorkingTimeCondition;
		private bool disposed = false;
		#endregion

        #region Constructor
        public WorkingTimeConditionFlow()
            : base()
        {
            dbWorkingTimeCondition = new WorkingTimeConditionDB();
        } 
        #endregion

        #region Public Method
        public bool FillWorkingTimeCondition(WorkingTimeCondition value, Company company)
        {
            return dbWorkingTimeCondition.FillWorkingTimeCondition(ref value, company);
        }

        public bool FillWorkingTimeConditionList(ref WorkingTimeConditionList value)
        {
            return dbWorkingTimeCondition.FillWorkingTimeConditionList(ref value);
        }

        public bool FillWorkingTimeConditionList(ref WorkingTimeConditionList value, WorkingTimeTable aWorkingTimeTable)
        {
            return dbWorkingTimeCondition.FillWorkingTimeConditionList(ref value, aWorkingTimeTable);
        }

        public bool InsertWorkingTimeCondition(WorkingTimeCondition value, Company aCompany)
        {
            return dbWorkingTimeCondition.InsertWorkingTimeCondition(value, aCompany);
        }

        public bool UpdateWorkingTimeCondition(WorkingTimeCondition value, Company aCompany)
        {
            return dbWorkingTimeCondition.UpdateWorkingTimeCondition(value, aCompany);
        }

        public bool DeleteWorkingTimeCondition(WorkingTimeCondition value, Company aCompany)
        {
            return dbWorkingTimeCondition.DeleteWorkingTimeCondition(value, aCompany);
        } 
        #endregion

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						dbWorkingTimeCondition.Dispose();

						dbWorkingTimeCondition = null;
					}
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
