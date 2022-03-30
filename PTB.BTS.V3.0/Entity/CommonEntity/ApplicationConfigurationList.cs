using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ictus.Common.Entity.General;

namespace Entity.CommonEntity
{
    public class ApplicationConfigurationList : ListBase
    {
        public void Add(ApplicationConfiguration value)
        { base.Add(value); }

        public void Remove(ApplicationConfiguration value)
        { base.Remove(value); }

        public ApplicationConfiguration this[int index]
        {
            get { return (ApplicationConfiguration)base.BaseGet(index); }
            set { base.BaseSet(index, value); }
        }

        public ApplicationConfiguration this[String key]
        {
            get { return (ApplicationConfiguration)base.BaseGet(key); }
            set { base.BaseSet(key, value); }
        }
    }
}
