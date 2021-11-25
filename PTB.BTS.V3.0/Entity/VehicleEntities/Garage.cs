using System;

using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.VehicleEntities
{
	public class Garage : EntityBase, IKey
	{
//		============================== Property ==============================
		private string code = NullConstant.STRING;
		public string Code
		{
			set{code = value;}
			get{return code;}
		}

		private Description aName;
		public Description AName
		{			
			set{aName = value;}
			get{return aName;}
		}
		
		private string shortName = NullConstant.STRING;
		public string ShortName
		{
			get{return shortName;}
			set{shortName = value.Trim();}
		}

		private Address aCurrentAddress;
		public Address ACurrentAddress
		{			
			set{aCurrentAddress = value;}
			get{return aCurrentAddress;}
		}

        private string bizPacVendorCode = NullConstant.STRING;
        public string BizPacVendorCode
        {
            set { bizPacVendorCode = value; }
            get { return bizPacVendorCode.Trim(); }
        }

        private string bizPacExpenseCode = NullConstant.STRING;
        public string BizPacExpenseCode
        {
            set { bizPacExpenseCode = value; }
            get { return bizPacExpenseCode.Trim(); }
        }

        private string bizPacExpenseName = NullConstant.STRING;
        public string BizPacExpenseName
        {
            set { bizPacExpenseName = value; }
            get { return bizPacExpenseName.Trim(); }
        }

        private string sapCode = NullConstant.STRING;
        public string SAPCode
        {
            set { sapCode = value; }
            get { return sapCode.Trim(); }
        }
//		============================== Constructor ==============================
		public Garage() : base()
		{
			aName = new Description();
			aCurrentAddress = new Address();
		}
//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{
				return code;
			}
		}
		public override string ToString()
		{
			return aName.Thai;
		}
	}
}
