using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

namespace Entity.VehicleEntities
{
    public class VehicleInsuranceList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Property ==============================
        protected InsuranceDocumentBase aInsuranceDocument;
		public InsuranceDocumentBase AInsuranceDocument
		{
			set{aInsuranceDocument = value;}
			get{return aInsuranceDocument;}
		}
//		============================== Constructor ==============================
        public VehicleInsuranceList(ictus.Common.Entity.Company company)
            : base(company)
		{
		}

//		============================== Public Method ==============================
		public void Add(VehicleInsuranceTypeOne value)
		{base.Add(value);}

		public void Remove(VehicleInsuranceTypeOne value)  
		{base.Remove(value);}

		public VehicleInsuranceTypeOne this[int index]
		{
			get
			{return (VehicleInsuranceTypeOne) base.BaseGet(index);}
			set
			{base.BaseSet(index, value);}
		}

		public VehicleInsuranceTypeOne this[String key]  
		{
			get
			{return (VehicleInsuranceTypeOne) base.BaseGet(key);}
			set
			{base.BaseSet(key, value);}
		}
	}
}
