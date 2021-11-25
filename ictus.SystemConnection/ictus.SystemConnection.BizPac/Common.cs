using System;

using ictus.SystemConnection.BizPac.Core;
using ictus.SystemConnection.BizPac.AP;
using ictus.SystemConnection.BizPac.AR;

namespace ictus.SystemConnection.BizPac
{
    public static class Common
    {
        public static BizPacConnectType GetBizPacConnectType(BizPacMappingBase header)
        {
            if (header is APMapping)
            {
                return BizPacConnectType.AP;
            }
            else if (header is ARMapping)
            {
                return BizPacConnectType.AR;
            }
            else
            {
                return BizPacConnectType.Error;
            }
        }
    }
}
