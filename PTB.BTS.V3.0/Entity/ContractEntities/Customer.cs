using System;
using System.Collections.Generic;

using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
	public class Customer : EntityBase, IKey
	{
        public const string DUMMYCODE = "ZZZZZZ";
//		============================== Property ==============================

		protected string code = NullConstant.STRING;
		public string Code
		{
			get{return code;}
			set{code = value;}
		}
// 4/7/2011 montri j. reconsile with BizPac
        public string BizPacCode { get; set; }

        // 7/5/2019 [Kriangkrai A.] Add field SAP Code to allow user edit/add
        public string SAPCode { get; set; }

		protected Description aName;
		public Description AName
		{
			get{return aName;}
			set{aName = value;}
		}

		protected string shortName = NullConstant.STRING;
		public string ShortName
		{
			get{return shortName;}
			set{shortName = value.Trim();}
		}

		protected string contactPerson = NullConstant.STRING;
		public string ContactPerson
		{
			get{return contactPerson;}
			set{contactPerson = value.Trim();}
		}

		protected string authorizedPerson = NullConstant.STRING;
		public string AuthorizedPerson
		{
			get{return authorizedPerson;}
			set{authorizedPerson = value.Trim();}
		}

        protected string authorizedPersonPosition = NullConstant.STRING;
        public string AuthorizedPersonPosition
        {
            get { return authorizedPersonPosition; }
            set { authorizedPersonPosition = value.Trim(); }
        }

        public string AuthorizedPersonPosition2 { get; set; }

        public string AuthorizedPerson2 { get; set; }

		private Address aCurrentAddress;
		public Address ACurrentAddress
		{
			get{return aCurrentAddress;}
			set{aCurrentAddress = value;}
		}

		private CustomerGroup aCustomerGroup;
		public CustomerGroup ACustomerGroup
		{
			get{return aCustomerGroup;}
			set{aCustomerGroup = value;}
		}
		private CustomerContractGroup aCustomerContractGroup;
		public CustomerContractGroup ACustomerContractGroup
		{
			get{return aCustomerContractGroup;}
			set{aCustomerContractGroup = value;}
		}
		
//		============================== Constructor ==============================
		public Customer() : base()
		{
			aName = new Description();
			aCurrentAddress = new Address();
		}

		public Customer(string customerCode) : base()
		{
			aName = new Description();
			aCurrentAddress = new Address();
			code = customerCode;
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{
				return code;
			}
		}

		public override string  ToString()
		{
            if (shortName == "" & aName.English == "")
            {
                return "";
            }
            else
            {
                return shortName + " / " + aName.English;
            }

        }
    }
}