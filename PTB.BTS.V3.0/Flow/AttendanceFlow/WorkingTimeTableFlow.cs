using System;
using System.Data;

using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Flow.AttendanceFlow
{
	public class WorkingTimeTableFlow : FlowBase
	{
		#region - Private -
			private WorkingTimeTableDB dbWorkingTimeTable;
			private bool disposed = false;

		#endregion

//		================================Constructor=====================
		public WorkingTimeTableFlow():base()
		{
			dbWorkingTimeTable = new WorkingTimeTableDB();
		}

//		================================public Method=====================
		public WorkingTimeTableList GetWorkingTimeTableList(Company value)
		{
			WorkingTimeTableList workingTimeTableList = new WorkingTimeTableList(value);
			dbWorkingTimeTable.FillWorkingTimeTableList(ref workingTimeTableList);
			return workingTimeTableList;
		}

		public WorkingTimeTable GetDupDescriptionWorkingTimeTable(string description, Company aCompany)
		{
			return dbWorkingTimeTable.GetDupDescriptionWorkingTimeTable(description, aCompany);
		}

		public bool FillWorkingTimeTableList(ref WorkingTimeTableList value)
		{
			return dbWorkingTimeTable.FillWorkingTimeTableList(ref value);
		}

		public bool InsertWorkingTimeTable(WorkingTimeTable value, Company aCompany)
		{
			return dbWorkingTimeTable.InsertWorkingTimeTable(value, aCompany);
		}
	
		public bool UpdateWorkingTimeTable(WorkingTimeTable value, Company aCompany)
		{
			return dbWorkingTimeTable.UpdateWorkingTimeTable(value, aCompany);
		}

		public bool DeleteWorkingTimeTable(WorkingTimeTable value, Company aCompany)
		{
			return dbWorkingTimeTable.DeleteWorkingTimeTable(value, aCompany);
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
						dbWorkingTimeTable.Dispose();

						dbWorkingTimeTable = null;
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
