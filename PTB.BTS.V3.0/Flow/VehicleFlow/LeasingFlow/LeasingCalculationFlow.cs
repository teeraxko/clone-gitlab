using System;
using Entity.VehicleEntities.Leasing;
using ictus.Framework.ASC.VBFuntion;

namespace Flow.VehicleEntities.Leasing
{
    public static class LeasingCalculationFlow
    {
        private static decimal round2digits(decimal value)
        {
            decimal tempVal = value * 100;
            decimal remain = decimal.Remainder(tempVal, 1);
            if (remain >= 0.5m)
            {
                return decimal.Ceiling(tempVal)/100;
            }
            else
            {
                return decimal.Floor(tempVal) / 100;
            }
        }

        public static LeasingCalculation Calculate(VehicleCost vehicleCost, short LeaseTerm, decimal percentOfResidual, decimal rateOfReturn)
        {
            LeasingCalculation calculationResult = new LeasingCalculation();
            calculationResult.InsuranceCharge = round2digits(vehicleCost.InsurancePremium / 12);
            calculationResult.RegisterCharge = round2digits(vehicleCost.VehicleRegister / 12);
            calculationResult.MaintenanceCharge = vehicleCost.MaintenanceCharge;
            calculationResult.PercentOfResidual = percentOfResidual;
            calculationResult.RateOfReturn = rateOfReturn;

            decimal rate = rateOfReturn / 1200;
            calculationResult.ResidualValue = vehicleCost.TotalVehiclePrice * calculationResult.PercentOfResidual / 100;

            calculationResult.PV = round2digits( Financial.NegativePV(rate, LeaseTerm, 0m, calculationResult.ResidualValue));
            calculationResult.PMT = round2digits(Financial.NegativePMT(rate, LeaseTerm, vehicleCost.TotalVehiclePrice - calculationResult.PV));

            int round = (int)Math.Round(calculationResult.MonthlyCharge/1000);
            calculationResult.MonthlyRoundCharge = round * 1000;

            return calculationResult;
        }
    }
}