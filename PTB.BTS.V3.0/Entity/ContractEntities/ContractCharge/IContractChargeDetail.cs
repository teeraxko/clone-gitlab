using System;

using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

namespace Entity.ContractEntities
{
    public interface IContractChargeDetail : IKey
    {
        YearMonth YearMonth { get; set; }
        decimal ChargeAmount { get; set; }
    }
}
