using System;

using SystemFramework.AppConfig;

using DataAccess.CommonDB;
using Entity.CommonEntity;

namespace PTB.BTS.Common.Flow
{
	public class ApplicationConfigurationFlow
	{
		#region - Constant -
		#endregion

		#region - Private - 
		private ApplicationConfigurationDB dbApplicationConfiguration;

		#endregion

		//============================== Property ==============================

		//============================== Constructor ==============================
        public ApplicationConfigurationFlow()
		{
            dbApplicationConfiguration = new ApplicationConfigurationDB();		
		}
		

		//============================== Public Method ==============================
		public ApplicationConfiguration GetApplicationConfig(string module, string configCode)
		{
            ApplicationConfiguration appConfig = new ApplicationConfiguration();
            if (dbApplicationConfiguration.FillApplicationConfiguration(ref appConfig, module, configCode))
			{
                return appConfig;
			}
			else
			{
                return null;
			}
		}

        public ApplicationConfigurationList GetApplicationConfig(string module)
        {
            ApplicationConfigurationList appConfigList = new ApplicationConfigurationList();
            if (dbApplicationConfiguration.FillApplicationConfigurationListByModule(ref appConfigList, module))
			{
                return appConfigList;
			}
			else
			{
                return null;
			}                        
        }

        public ApplicationConfigurationList GetApplicationConfig()
        {
            ApplicationConfigurationList appConfigList = new ApplicationConfigurationList();
            if (dbApplicationConfiguration.FillApplicationConfigurationList(ref appConfigList))
            {
                return appConfigList;
            }
            else
            {
                return null;
            }
        }
	
	}
}
