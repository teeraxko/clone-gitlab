using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class EmployeeTimeCardFlow : FlowBase
	{
		#region - Private -	
		private EmployeeTimeCardDB dbEmployeeTimeCard;
		private bool disposed = false;

		#endregion

//		====================================Constructor================
		public EmployeeTimeCardFlow() : base()
		{
			dbEmployeeTimeCard = new EmployeeTimeCardDB();
		}

//		====================================Public Method================
		public bool FillEmployeeTimeCard(ref EmployeeTimeCard value)
		{
			return dbEmployeeTimeCard.FillTimeCardList(ref value);
		}

		public bool FillTimeCard(ref TimeCard value, Employee aEmployee)
		{
			return dbEmployeeTimeCard.FillTimeCard(ref value, aEmployee);
		}

		public bool FillTimeCardBenefitList(ref EmployeeTimeCard value)
		{
			return dbEmployeeTimeCard.FillTimeCardBenefitList(ref value);
		}

		public bool InsertEmployeeTimeCard(TimeCard value, Employee aEmployee)
		{
			return dbEmployeeTimeCard.InsertTimeCard(value, aEmployee);
		}

		public bool UpdateEmployeeTimeCard(TimeCard value, Employee aEmployee)
		{
			return dbEmployeeTimeCard.UpdateTimeCard(value, aEmployee);		
		}
		
		public bool DeleteEmployeeTimeCard(TimeCard value, Employee aEmployee)
		{
			return dbEmployeeTimeCard.DeleteTimeCard(value, aEmployee);	
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
						dbEmployeeTimeCard.Dispose();

						dbEmployeeTimeCard = null;
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
