using System;
using System.Collections.Generic;

using ictus.Common.Entity.General;

namespace ictus.SystemConnection.BizPac.Core
{
    public abstract class BizPacConnectBase
    {
        public abstract string Connect(ListBase listData);
        public abstract bool Connect(string fileName, List<string> lines);
        public abstract bool ReConnect(string fileName, BizPacMappingBase data);
        public abstract bool CancelConnect(string fileName);
    }
}
