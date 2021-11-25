using System;
using Entity.ContractEntities;
using ictus.PIS.PI.Entity;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace PTB.BTS.Attendance.BenefitChargeEntities
{
    public interface IBenefitCharge
    {
        decimal Basic { get; }
        int OTADay { get; set; }
        decimal OTARate { get; set; }
        decimal OTACharge { get; set; }
        decimal OTAAmount { get; }
        decimal OTBRate { get; set; }
        decimal OTBCharge { get; set; }
        decimal OTBAmount { get; }
        decimal OTCRate { get; set; }
        decimal OTCCharge { get; set; }
        decimal OTCAmount { get; }
        int Holiday { get; set; }
        decimal HolidayAmount { get; set; }
        int Taxi { get; set; }
        decimal TaxiAmount { get; set; }
        int TripNear { get; set; }
        int TripFar { get; set; }
        decimal TripNearAmount { get; set; }
        decimal TripFarAmount { get; set; }
        int NightTrip { get; set; }
        decimal NightTripAmount { get; set; }
        decimal Other { get; set; }
        decimal Amount { get; }
        decimal VAT { get; }
        decimal Total { get; }
        string Remark { get; set; }
        decimal DeducTime { get; set; }
        decimal DeducAmountPerDay { get; set; }
        decimal DeducAmount { get; set; }
        decimal TelephoneAmount { get; set; }
        decimal SpecialAmount { get; set; }
        ServiceStaff ServiceStaff { get; set; }
        ChargeRate ChargeRate { get; set; }
        int Line { get; set; }
        string ChargeRemark { get; set; }

        decimal OTAHourAdjust { get; set; }
        decimal OTAAmountAdjust { get; set; }
        decimal OTBHourAdjust { get; set; }
        decimal OTBAmountAdjust { get; set; }
        decimal OTCHourAdjust { get; set; }
        decimal OTCAmountAdjust { get; set; }
        int HolidayAdjust { get; set; }
        decimal HolidayAmountAdjust { get; set; }
        int TaxiAdjust { get; set; }
        decimal TaxiAmountAdjust { get; set; }
        int TripNearAdjust { get; set; }
        int TripFarAdjust { get; set; }
        decimal TripNearAmountAdjust { get; set; }
        decimal TripFarAmountAdjust { get; set; }
        int NightTripAdjust { get; set; }
        decimal NightTripAmountAdjust { get; set; }
        decimal DeducAdjust { get; set; }
        decimal DeducAmountAdjust { get; set; }
    }
}
