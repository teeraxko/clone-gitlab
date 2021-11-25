using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class EmployeeWorkScheduleFlow: FlowBase
	{
		#region - Private -	
		private EmployeeWorkScheduleDB dbEmployeeWorkSchedule;
		private bool disposed = false;

		#endregion

//		====================================Constructor================
		public EmployeeWorkScheduleFlow():base()
		{		
			dbEmployeeWorkSchedule = new EmployeeWorkScheduleDB();
		}

//		====================================Public Method================
		public WorkSchedule GetWorkSchedule(Employee aEmployee, DateTime forDate)
		{
			return dbEmployeeWorkSchedule.GetWorkSchedule(aEmployee, forDate);
		}

		public bool FillWorkSchedule(ref WorkSchedule value, Employee aEmployee)
		{
			return dbEmployeeWorkSchedule.FillWorkSchedule(ref value, aEmployee);
		}

		public bool FillEmployeeWorkSchedule(ref EmployeeWorkSchedule value)
		{
			return dbEmployeeWorkSchedule.FillWorkScheduleList(ref value);
		}

		public bool InsertEmployeeWorkSchedule(WorkSchedule value, Employee aEmployee)
		{
			return dbEmployeeWorkSchedule.InsertWorkSchedule(value, aEmployee);
		}

		public bool UpdateEmployeeWorkSchedule(WorkSchedule value, Employee aEmployee)
		{
			return dbEmployeeWorkSchedule.UpdateWorkSchedule(value, aEmployee);		
		}
		
		public bool DeleteEmployeeWorkSchedule(WorkSchedule value, Employee aEmployee)
		{
			return dbEmployeeWorkSchedule.DeleteWorkSchedule(value, aEmployee);	
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
						dbEmployeeWorkSchedule.Dispose();

						dbEmployeeWorkSchedule = null;
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
