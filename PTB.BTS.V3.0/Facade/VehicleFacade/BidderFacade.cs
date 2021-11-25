using System;
using System.Data;
using System.Collections;

using SystemFramework.AppException;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using PTB.BTS.Common.Flow;
using PTB.BTS.Vehicle.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using ictus.Common.Entity;
using System.Collections.Generic;
namespace Facade.VehicleFacade
{
    public class BidderFacade : CommonPIFacadeBase
    {
        #region Private Variable
        private bool disposed = false;
        #endregion

        #region Constructor
        public BidderFacade()
            : base()
        {
        } 
        #endregion

        #region Public Method
        public List<Bidder> GetAllBidder()
        {
            using (BidderFlow flow = new BidderFlow())
            {
                return flow.GetAllBidder();
            }
        }

        public void InsertBidder(Bidder value)
        {
            using (BidderFlow flow = new BidderFlow())
            {
                flow.InsertBidder(value, GetCompany());
            }
        }

        public void UpdateBidder(Bidder value)
        {
            using (BidderFlow flow = new BidderFlow())
            {
                flow.UpdateBidder(value, GetCompany());
            }
        }

        public void DeleteBidder(Bidder value)
        {
            using (BidderFlow flow = new BidderFlow())
            {
                flow.DeleteBidder(value, GetCompany());
            }
        }

        public bool ChkDupBidder(Bidder value)
        {
            using (BidderFlow flow = new BidderFlow())
            {
                return flow.ChkDupBidder(value, GetCompany());
            }
        }


        #endregion

        #region IDisposable Members
        protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion


    }
}
