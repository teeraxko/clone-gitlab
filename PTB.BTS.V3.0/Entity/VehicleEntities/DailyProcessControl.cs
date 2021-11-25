using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

using Entity.CommonEntity;

namespace Entity.VehicleEntities
{
	public class DailyProcessControl : EntityBase, IKey
	{
//		============================== Property ==============================
		private DateTime dailyDate = NullConstant.DATETIME;
		public DateTime DailyDate
		{			
			set{ dailyDate = value; }
			get{ return dailyDate;  }
		}

		private PROCESS_STATUS_TYPE processStatus = PROCESS_STATUS_TYPE.NULL;
		public PROCESS_STATUS_TYPE ProcessStatus
		{			
			set{ processStatus = value; }
			get{ return processStatus;  }
		}

//		============================== Constructor ==============================
		public DailyProcessControl() : base()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{
				return dailyDate.ToShortDateString();
			}
		}
	}
}
