using System;
using ictus.SystemConnection.BizPac.Core;

namespace ictus.SystemConnection.BizPac.AP
{
    public interface IAPHeader : IAccountHeader
    {

        string VendorCode{get;}
        string VendorName{get;}
        string VendorInvoice{get;}
        DateTime VendorDate{get;}

        bool HaveTaxInvoice { get;}
    }
}
