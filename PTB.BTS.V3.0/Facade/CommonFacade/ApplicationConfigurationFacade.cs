using System;

using PTB.BTS.Common.Flow;

using Facade.CommonFacade;

using SystemFramework.AppConfig;
using SystemFramework.AppException;
using Entity.CommonEntity;

namespace Facade.CommonFacade
{
	public class ApplicationConfigurationFacade
	{
		#region - Private -
		private ApplicationConfigurationFlow flowApplicationConfiguration;
        //private CommonFlow flowCommon;
        //private ApplicationUserProfile objApplicationUserProfile;
		#endregion

//		============================== Property ==============================
		private ApplicationConfigurationList objApplicationConfigurationList;
        public ApplicationConfigurationList ObjApplicationConfigurationList
		{
            get { return objApplicationConfigurationList; }
		}

		

//		============================== Constructor ==============================
        public ApplicationConfigurationFacade()
		{
            flowApplicationConfiguration = new ApplicationConfigurationFlow();
		}

//		============================== Public Method ==============================
        public void LoadApplicationConfiguration()
		{
            objApplicationConfigurationList = flowApplicationConfiguration.GetApplicationConfig();
		}
	}
}
