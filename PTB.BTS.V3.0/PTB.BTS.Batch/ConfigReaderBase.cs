using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity.CommonEntity;

namespace PTB.BTS.Batch
{
    public abstract class ConfigReaderBase
    {
        abstract public List<ApplicationConfiguration> LoadConfigs(string module, string configCode);
        abstract public void AddConfig(ApplicationConfiguration config);
        abstract public void UpdateConfig(ApplicationConfiguration config);
        abstract public void DeleteConfig(ApplicationConfiguration config);
    }
}
