using System;

using ictus.SystemConnection.BizPac.Core;

namespace ictus.SystemConnection.BizPac.AR
{
    public interface IARHeader : IAccountHeader
    {
        string CustomerCode{get;}
        string CustomerName{get;}
    }
}
