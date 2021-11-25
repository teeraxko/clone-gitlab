using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.VehicleEntities;

using Facade.PiFacade;
using Facade.CommonFacade;

using PTB.BTS.Vehicle.Flow;

using SystemFramework.AppException;

namespace Facade.VehicleFacade
{
	public class DailyProcessFacade : CommonPIFacadeBase
	{
		#region - Private -
		private Company aCompany;
		private DailyProcessFlow flowDailyProcess;
		private DailyProcessControlFlow flowDailyProcessControl;
		#endregion

//		============================== Constructor ==============================
		public DailyProcessFacade() : base()
		{
			flowDailyProcess = new DailyProcessFlow();
			flowDailyProcessControl = new DailyProcessControlFlow();
			aCompany = GetCompany();
		}

//		==============================Public method ==============================
		public bool UpdateDailyProcess(DateTime forDate)
		{
			return flowDailyProcess.UpdateDailyProcess(forDate, aCompany);
		}

		public bool FillDailyProcessControl(ref DailyProcessControl value)
		{
			return flowDailyProcessControl.FillDailyProcessControl(ref value, aCompany);
		}

		public bool InsertDailyProcessControl(DailyProcessControl value)
		{
			return flowDailyProcessControl.InsertDailyProcessControl(value, aCompany);
		}

		public bool UpdateDailyProcessControl(DailyProcessControl value)
		{
			return flowDailyProcessControl.UpdateDailyProcessControl(value, aCompany);
		}
	}
}
