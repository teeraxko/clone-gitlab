using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.VehicleEntities.VehicleLeasing
{
    public interface VehicleProfitAndLost
    {
        Vehicle Vehicle
        {
            get;
        }

        decimal Rental
        {
            get;
        }

        decimal Contract
        {
            get;
        }

        decimal RentalAge
        {
            get;
        }

        decimal Remain
        {
            get;
        }

        decimal RemainingCostPV
        {
            get;
        }

        decimal ResidualValuePV
        {
            get;
        }

        decimal Sale
        {
            get;
        }

        decimal Compensate
        {
            get;
        }

        decimal Price
        {
            get;
        }

        decimal BV
        {
            get;
        }
    }
}
