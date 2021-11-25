using System;

using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Flow.AttendanceFlow
{
	public class OTVariantFlow : FlowBase
	{
		#region - Private -
			private OvertimeVariantTableDB dbOvertimeVariantTable;
			private bool disposed = false;

		#endregion
		
//  ================================Constructor=====================

		public OTVariantFlow():base()
		{
			dbOvertimeVariantTable = new OvertimeVariantTableDB();
		}

//  ================================public Method=====================

		public bool FillOTVariantList(ref OTVariantList value)
		{
			return dbOvertimeVariantTable.FillOTVariantList(ref value);
		}

		public bool InsertOTVariant(OTVariant value, Company aCompany)
		{
			return dbOvertimeVariantTable.InsertOTVariant(value, aCompany);
		}

		public bool UpdateOTVariant(OTVariant value, Company aCompany)
		{
			return dbOvertimeVariantTable.UpdateOTVariant(value, aCompany);
		}

		public bool DeleteOTVariant(OTVariant value, Company aCompany)
		{
			return dbOvertimeVariantTable.DeleteOTVariant(value, aCompany);
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
						dbOvertimeVariantTable.Dispose();

						dbOvertimeVariantTable = null;
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