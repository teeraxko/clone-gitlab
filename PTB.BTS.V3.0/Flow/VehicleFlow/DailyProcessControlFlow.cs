using System;

using ictus.PIS.PI.Entity;
using Entity.VehicleEntities;

using DataAccess.VehicleDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace PTB.BTS.Vehicle.Flow
{
	public class DailyProcessControlFlow : FlowBase
	{
		#region - Private -
		private DailyProcessControlDB dbDailyProcessControl;
		#endregion

//		============================== Constructor ==============================
		public DailyProcessControlFlow() : base()
		{
			dbDailyProcessControl = new DailyProcessControlDB();
		}

//		============================== Public Method ==============================
		public bool FillDailyProcessControl(ref DailyProcessControl value, Company aCompany)
		{
			return dbDailyProcessControl.FillDailyProcessControl(ref value, aCompany);
		}

		public bool FillDailyProcessControlList(ref DailyProcessControlList value)
		{
			return dbDailyProcessControl.FillDailyProcessControlList(ref value);
		}

		public bool InsertDailyProcessControl(DailyProcessControl value, Company aCompany)
		{
			return dbDailyProcessControl.InsertDailyProcessControl(value, aCompany);
		}

		public bool UpdateDailyProcessControl(DailyProcessControl value, Company aCompany)
		{
			return dbDailyProcessControl.UpdateDailyProcessControl(value, aCompany);
		}

		public bool DeleteDailyProcessControl(DailyProcessControl value, Company aCompany)
		{
			return dbDailyProcessControl.DeleteDailyProcessControl(value, aCompany);
		}
	}
}
