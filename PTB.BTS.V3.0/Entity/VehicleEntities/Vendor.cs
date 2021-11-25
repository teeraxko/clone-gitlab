using System;

using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.VehicleEntities
{
	public class Vendor : EntityBase, IKey
	{
//		============================== Property ==============================
		private string code = NullConstant.STRING;
		public string Code
		{
			set{code = value;}
			get{return code;}
		}

        private Description aDescription;
        public Description ADescription
		{			
			set{aDescription = value;}
			get{return aDescription;}
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

//		============================== Constructor ==============================
		public Vendor() : base()
		{
			aDescription = new Description();
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
			return aDescription.Thai;
		}
	}
}
