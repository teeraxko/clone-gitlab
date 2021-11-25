using System;

using ictus.PIS.PI.Entity;
using Entity.ContractEntities;

namespace Entity.VehicleEntities
{
    public class DriverExcessDeduction : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Property ==============================
		private Accident aAccident;
		public Accident AAccident
		{
			set{aAccident = value;}
			get{return aAccident;}
		}

		private Employee aDriver;
		public Employee ADriver
		{			
			set{aDriver = value;}
			get{return aDriver;}
		}

//		============================== Constructor ==============================
        public DriverExcessDeduction(ictus.Common.Entity.Company company)
            : base(company)
		{}

//		============================== Public Method ==============================
		public void Add(ExcessDeduction value)
		{base.Add(value);}

		public void Remove(ExcessDeduction value)  
		{base.Remove(value);}

		public ExcessDeduction this[int index]
		{
			get
			{return (ExcessDeduction) base.BaseGet(index);}
			set
			{base.BaseSet(index, value);}
		}

		public ExcessDeduction this[String key]  
		{
			get
			{return (ExcessDeduction) base.BaseGet(key);}
			set
			{base.BaseSet(key, value);}
		}
	}
}
