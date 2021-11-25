using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

namespace Entity.VehicleEntities
{
    public class BidderList : CompanyStuffBase
    {
        //============================== Constructor ==============================
        public BidderList(Company company)
            : base(company)
		{}

		//============================== Public Method ==============================
        public void Add(Bidder value)
        { base.Add(value); }

        public void Remove(Bidder value)
        { base.Remove(value); }

        public Bidder this[int index]
        {
            get { return (Bidder)base.BaseGet(index); }
            set { base.BaseSet(index, value); }
        }

        public Bidder this[String key]
        {
            get { return (Bidder)base.BaseGet(key); }
            set { base.BaseSet(key, value); }
        }
    }
}
