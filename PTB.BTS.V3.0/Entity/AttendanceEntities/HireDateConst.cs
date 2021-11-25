using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class HireDateConst : EntityBase
	{
		#region - Private -
			private static System.Threading.Mutex mutex = new System.Threading.Mutex();
		#endregion
		
//		============================== Property ==============================
		private DateTime hireDate = NullConstant.DATETIME;
		public DateTime HireDate
		{
			get	
			{
				return hireDate;
			}
			set
			{
				hireDate = value;
			}
		}

		private static HireDateConst instance;
		public static HireDateConst GetInstance
		{
			get
			{
				mutex.WaitOne();
				if(instance == null)
				{
					instance = new HireDateConst();
				}
				mutex.ReleaseMutex();
				return instance;
			}
		}
		
		private HireDateConst(): base()
		{
		}

        public override string EntityKey
        {
            get { return null; }
        }
    }
}
