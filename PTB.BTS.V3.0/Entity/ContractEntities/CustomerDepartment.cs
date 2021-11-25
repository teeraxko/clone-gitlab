using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.ContractEntities
{
	public class CustomerDepartment : EntityBase, IKey
	{
//		============================== Property ==============================
		private string code = "ZZZ";
		public string Code
		{
			get{return code;}
			set{code = value;}
		}

		private Description aName;
		public Description AName
		{
			get{return aName;}
			set{aName = value;}
		}

		private string shortName = NullConstant.STRING;
		public string ShortName
		{
			get{return shortName;}
			set{shortName = value.Trim();}
		}

		private Customer aCustomer;
		public Customer ACustomer
		{
			get{return aCustomer;}
			set{aCustomer = value;}
		}

//		============================== Constructor ==============================
		public CustomerDepartment() :  base()
		{
			aName = new Description();
			aCustomer = new Customer();
		}

		public CustomerDepartment(string code, Customer customer) :  base()
		{
			this.code = code;
			aName = new Description();
			aCustomer = customer;
		}

		public override string EntityKey
		{
			get
			{
				return code + aCustomer.EntityKey;
			}
		}

		public override string  ToString()
		{
			return shortName;
		}
	}
}
