using System;

using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class WorkingTimeConditionSpecificFlow : FlowBase
	{
		#region - Private -
		private WorkingTimeConditionSpecificDB dbWorkingTimeConditionSpecific;
		private bool disposed = false;
		#endregion

//		================================Constructor======================
		public WorkingTimeConditionSpecificFlow() : base()
		{
			dbWorkingTimeConditionSpecific = new WorkingTimeConditionSpecificDB();
		}

//		================================public Method=====================
		public bool FillWorkingTimeConditionSpecificList(ref WorkingTimeConditionSpecificList value)
		{
			return dbWorkingTimeConditionSpecific.FillWorkingTimeConditionSpecificList(ref value);
		}

		public bool FillWorkingTimeConditionSpecific(ref WorkingTimeConditionSpecific value)
		{
			return dbWorkingTimeConditionSpecific.FillWorkingTimeConditionSpecific(ref value);
		}

		public bool InsertWorkingTimeConditionSpecific(WorkingTimeConditionSpecific value)
		{
			return dbWorkingTimeConditionSpecific.InsertWorkingTimeConditionSpecific(value);
		}
	
		public bool UpdateWorkingTimeConditionSpecific(WorkingTimeConditionSpecific value)
		{
			return dbWorkingTimeConditionSpecific.UpdateWorkingTimeConditionSpecific(value);
		}

		public bool DeleteWorkingTimeConditionSpecific(WorkingTimeConditionSpecific value)
		{
			return dbWorkingTimeConditionSpecific.DeleteWorkingTimeConditionSpecific(value);
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						dbWorkingTimeConditionSpecific.Dispose();

						dbWorkingTimeConditionSpecific = null;
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
