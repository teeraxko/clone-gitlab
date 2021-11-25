using System;
using System.Collections.Generic;
using System.Text;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.General;

namespace Entity.VehicleEntities.ProfitCalculation
{
    public class ProfitCalDetail : EntityBase, IKey
    {
        private int groupCode = NullConstant.INT;
        public int GroupCode
        {
            get { return groupCode; }
            set { groupCode = value; }
        }

        private int line = NullConstant.INT;
        public int Line
        {
            get { return line; }
            set { line = value; }
        }

        private string item = NullConstant.STRING;
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

        //================================ Public method ================================
        public override string EntityKey
        {
            get { return line.ToString(); }
        }
    }
}
