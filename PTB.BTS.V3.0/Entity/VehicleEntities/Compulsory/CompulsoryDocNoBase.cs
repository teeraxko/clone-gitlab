using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.VehicleEntities
{
    public abstract class CompulsoryDocNoBase
    {
        protected string yearString;

        protected CompulsoryDocNoBase()
        {
            yearString = DateTime.Today.ToString("yy");
        }

        public abstract string DefaultPrefix {get;}
        public abstract string DefaultFullPrefix{get;}
        public abstract string DefaultEndorsement{get;}

        public abstract string GetTaxInvoiceNo(CompulsoryFragment value);
        public abstract string GetTaxInvoiceNo(string prefix, string number, string endorsement);
        public abstract string GetCompulsoryNo(CompulsoryFragment value);
        public abstract string GetCompulsoryNo(string prefix, string number, string endorsement);
        public abstract CompulsoryFragment GetCompulsoryFragment(string compulsoryNo);
    }
}
