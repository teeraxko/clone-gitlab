using System;

using ictus.SystemConnection.BizPac.Core;
using ictus.Common.Entity.General;

namespace PTB.BTS.BTS2BizPacEntity
{
    public interface IBTS2BizPacHeader : IAccountHeader, IKey
    {
        string DocNo { get; }
        string PaidTo { get; }
        string PaidToCode { get; }
        string AdditionalInfo { get; }
        string AdditionalDate { get; }
        string BTSRemark { get; }
        decimal BTSAmount { get; }
        int BTSCheck { get; }
    }
}
