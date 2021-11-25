using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.VehicleEntities.Leasing
{
    public interface IProfitAndLost : ictus.Common.Entity.General.IKey
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
