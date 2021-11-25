using System;

using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.VehicleEntities
{
	public class InsuranceCompany : EntityBase, IKey
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

		private Address aAddress;
		public Address AAddress
		{
			set{aAddress = value;}
			get{return aAddress;}			
		}

//		============================== Constructor ==============================
		public InsuranceCompany() : base()
		{
			aName = new Description();
			aAddress = new Address();
		}

//		============================== Public Method ==============================
		#region IKey Members

		public override string EntityKey
		{
			get
			{return code;}
		}

		#endregion

		public override string ToString()
		{
			return aName.Thai;
		}
	}
}
