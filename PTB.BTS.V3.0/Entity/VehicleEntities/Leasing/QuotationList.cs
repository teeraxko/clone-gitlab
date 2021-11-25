using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity;

namespace Entity.VehicleEntities.Leasing
{
    public class QuotationList : CompanyStuffBase
    {
        //============================== Constructor ==============================
        public QuotationList(Company aCompany)
            : base(aCompany)
        { }

        //============================== Public Method ==============================
        public void Add(Quotation value) { base.Add(value); }

        public void Remove(Quotation value) { base.Remove(value); }

        public Quotation this[int index]
        {
            get { return ((Quotation)base.BaseGet(index)); }
            set { base.BaseSet(index, value); }
        }

        public Quotation this[String key]
        {
            get { return ((Quotation)base.BaseGet(key)); }
            set { base.BaseSet(key, value); }
        }
    }
}
