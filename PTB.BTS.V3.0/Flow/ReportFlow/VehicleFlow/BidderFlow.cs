using System;

using Entity.VehicleEntities;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using DataAccess.VehicleDB;

using PTB.BTS.Common.Flow;
using System.Collections.Generic;

namespace PTB.BTS.Vehicle.Flow
{
    public class BidderFlow : FlowBase
    {
        private BidderDB dbBidder;

        #region Constructor
        public BidderFlow()
            : base()
        {
            dbBidder = new BidderDB();
        } 
        #endregion

        #region Public Method
        public List<Bidder> GetAllBidder()
        {
            using (BidderDB dbBidder = new BidderDB())
            {
                return dbBidder.GetAll();
            }
        }

        public Bidder GetBidderByBidderCode(Bidder bidder, Company company)
        {
            using (BidderDB dbBidder = new BidderDB())
            {
                return dbBidder.GetBidderByBidderCode(bidder, company);
            }
        }

        public void InsertBidder(Bidder value, Company aCompany)
        {
            using (BidderDB dbBidder = new BidderDB())
            {
                dbBidder.Insert(value, aCompany);
            }
        }

        public void UpdateBidder(Bidder value, Company aCompany)
        {
            using (BidderDB dbBidder = new BidderDB())
            {
                dbBidder.Update(value, aCompany);
            }
        }

        public void DeleteBidder(Bidder value, Company aCompany)
        {
            using (BidderDB dbBidder = new BidderDB())
            {
                dbBidder.Delete(value, aCompany);
            }
        }

        public bool ChkDupBidder(Bidder value, Company company)
        {
            Bidder valueTmp = new Bidder();
            using (BidderDB dbBidder = new BidderDB())
            {
                valueTmp = dbBidder.GetBidderByBidderCode(value, company);
                if (valueTmp.BidderCode != "")
                    return false;
                else
                    return true;
            }
        }
        #endregion


    }
}
