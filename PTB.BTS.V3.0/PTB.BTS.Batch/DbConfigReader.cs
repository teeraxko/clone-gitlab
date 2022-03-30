using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity.CommonEntity;
using Facade.CommonFacade;

namespace PTB.BTS.Batch
{
    public class DbConfigReader : ConfigReaderBase
    {
        ApplicationConfigurationFacade facadeApplicationConfig = null;
        public DbConfigReader()
        {
            facadeApplicationConfig = new ApplicationConfigurationFacade();
        }

        public override List<ApplicationConfiguration> LoadConfigs(string module, string configCode)
        {
            
            facadeApplicationConfig.LoadApplicationConfiguration();
            List<ApplicationConfiguration> list = facadeApplicationConfig.ObjApplicationConfigurationList.GetArrayList().Cast<ApplicationConfiguration>().ToList();
            return list;
        }

        public override void AddConfig(ApplicationConfiguration config)
        {
            throw new NotImplementedException();
        }

        public override void UpdateConfig(ApplicationConfiguration config)
        {
            throw new NotImplementedException();
        }

        public override void DeleteConfig(ApplicationConfiguration config)
        {
            throw new NotImplementedException();
        }
    }
}
