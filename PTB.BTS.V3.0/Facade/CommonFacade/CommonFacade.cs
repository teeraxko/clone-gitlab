using System;

using PTB.BTS.Common.Flow;

namespace Facade.CommonFacade
{
	public class CommonFacade  
	{
		#region - Private - 
		private CommonFlow flowCommon;
		#endregion
		
//		============================== Constructor ==============================
		public CommonFacade() : base()
		{
			flowCommon = new CommonFlow();
		}

//		============================== Public Method ==============================
		public DateTime GetSystemDate()
		{
			return flowCommon.GetSystemDate();
		}
	}
}
