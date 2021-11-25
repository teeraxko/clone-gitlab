using System;
using System.Data;

using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Flow.AttendanceFlow
{
	
	public class OTPatternFlow:FlowBase
	{
		#region Private
		private OTPatternDB dbOTPattern;
		private bool disposed = false;
		#endregion

//		================================Constructor=====================
		public OTPatternFlow() : base()
		{
			dbOTPattern = new OTPatternDB();
		}
		
//		================================public Method=====================
		public bool FillOTPattern(ref OTPattern value, Company aCompany)
		{
			return dbOTPattern.FillOTPattern(ref value, aCompany);
		}

		public bool FillOTPatternList(ref OTPatternList value)
		{
			return dbOTPattern.FillOTPatternList(ref value);
		}

		public bool InsertOTPattern(OTPattern value, Company aCompany)
		{
			return dbOTPattern.InsertOTPattern(value, aCompany);
		}

		public bool UpdateOTPattern(OTPattern value, Company aCompany)
		{
			return dbOTPattern.UpdateOTPattern(value, aCompany);
		}

		public bool DeleteOTPattern(OTPattern value, Company aCompany)
		{
			return dbOTPattern.DeleteOTPattern(value, aCompany);
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
						dbOTPattern.Dispose();

						dbOTPattern = null;
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
