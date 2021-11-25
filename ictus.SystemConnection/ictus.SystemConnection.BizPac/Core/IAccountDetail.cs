using System;

using ictus.Common.Entity.General;

namespace ictus.SystemConnection.BizPac.Core
{
    public interface IAccountDetail : IKey
    {
        int SeqNo { get;}
        string MiscItemCode { get;}
        string ItemDescription { get;}
        decimal Quantity { get;}
        decimal Price { get;}
        decimal Amount { get;}
        string BusinessUnit { get;}
        string BizPacRemark2 { get;}
    }
}
