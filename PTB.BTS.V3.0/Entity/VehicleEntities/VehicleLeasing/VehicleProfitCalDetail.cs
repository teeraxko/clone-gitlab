using System;
using System.Collections.Generic;
using System.Text;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.VehicleEntities.VehicleLeasing
{
    public class VehicleProfitCalDetail : EntityBase
    {
        private int? groupCode;
        public int? GroupCode
        {
            get { return groupCode; }
            set { groupCode = value; }
        }

        private int? line;
        public int? Line
        {
            get { return line; }
            set { line = value; }
        }

        private string item;
        public string Item
        {
            get { return item; }
            set { item = value; }
        }

        private decimal year1 = decimal.Zero;
        public decimal Year1
        {
            get { return year1; }
            set { year1 = value; }
        }

        private decimal year2 = decimal.Zero;
        public decimal Year2
        {
            get { return year2; }
            set { year2 = value; }
        }

        private decimal year3 = decimal.Zero;
        public decimal Year3
        {
            get { return year3; }
            set { year3 = value; }
        }

        private decimal year4 = decimal.Zero;
        public decimal Year4
        {
            get { return year4; }
            set { year4 = value; }
        }

        private decimal year5 = decimal.Zero;
        public decimal Year5
        {
            get { return year5; }
            set { year5 = value; }
        }

        public override string EntityKey
        {
            get { return line.ToString(); }
        }
    }
}
