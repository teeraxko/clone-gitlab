using System;

using ictus.SystemConnection.BizPac.Core;
using ictus.SystemConnection.BizPac.AP;
using ictus.SystemConnection.BizPac.AR;

namespace ictus.SystemConnection.BizPac
{
    public static class ObjectCreater
    {
        public static BizPacMappingBase GetBizPacMapping(BizPacMappingBase header)
        {
            switch (Common.GetBizPacConnectType(header))
            {
                case BizPacConnectType.AP: { 
                    return new APMapping((IAPHeader)header);
                }
                case BizPacConnectType.AR: { 
                    return new ARMapping((IARHeader)header);
                }
                default: {
                    throw new Exception("Create New BizPacMappingBase");
                }
            }
        }

        public static BizPacMappingBase GetBizPacMapping(IAccountHeader header)
        {
            if (header is IAPHeader)
            {
                return new APMapping((IAPHeader)header);
            }
            else if (header is IARHeader)
            {
                return new ARMapping((IARHeader)header);
            }
            throw new Exception("Create New BizPacMappingBase");
        }
    }
}
