using System;

using Entity.CommonEntity;

using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.VehicleEntities
{
    public class Bidder : EntityBase, IKey
    {
        //============================== Property ==============================
        private string bidderCode = NullConstant.STRING;
        public string BidderCode
        {
            set { bidderCode = value.Trim(); }
            get { return bidderCode; }
        }
        private string bidderName = NullConstant.STRING;
        public string BidderName
        {
            set { bidderName = value.Trim(); }
            get { return bidderName; }
        }
        private string address = NullConstant.STRING;
        public string Address
        {
            set { address = value.Trim(); }
            get { return address; }
        }
        private string telNo = NullConstant.STRING;
        public string TelNo
        {
            set { telNo = value.Trim(); }
            get { return telNo; }
        }

        private string remark = NullConstant.STRING;
        public string Remark
        {
            set { remark = value.Trim(); }
            get { return remark; }
        }

        //============================== Constructor ==============================
		public Bidder() : base()
		{
		}

        public Bidder(string value)
            : base()
        {
            bidderCode = value;
        }

        //============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{return bidderCode + bidderName;}
		}

    }
}
