using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity.General;
using ictus.Common.Entity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

namespace PTB.BTS.BTS2BizPacEntity
{
    public class VehicleDNAttach : VehicleContractChargeBP
    {
        //============================== Property ==============================
        public string BrandModelName
        {
            get { return vehicle.AModel.ABrand.AName.English + " (" + vehicle.AModel.AName.English + ")"; }
        }

        private Decimal monthlyCharge = decimal.Zero;
        public Decimal MonthlyCharge
        {
            get { return monthlyCharge; }
            set { monthlyCharge = value; }
        }

        private Vehicle vehicle;
        public Vehicle Vehicle
        {
            get { return vehicle; }
            set { vehicle = value; }
        }

        private Hirer hirer;
        public Hirer Hirer
        {
            get { return hirer; }
            set { hirer = value; }
        }

        //============================== Constructor ==============================
        public VehicleDNAttach(Company company)
            : base(company)
        {
            hirer = new Hirer();
        }

        //============================== public method ==============================
        public override string EntityKey
        {
            get { return base.EntityKey; }
        }
    }
}
