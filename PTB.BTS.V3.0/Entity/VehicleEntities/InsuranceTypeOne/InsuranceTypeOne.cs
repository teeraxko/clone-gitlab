using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;

namespace Entity.VehicleEntities
{
    public class InsuranceTypeOne : InsuranceDocumentBase
	{
//		============================== Property ==============================
        protected string insuranceInchargeName = NullConstant.STRING;
		public string InsuranceInchargeName
		{
			set{insuranceInchargeName = value.Trim();}
			get{return insuranceInchargeName;}
		}

        protected string insuranceInchargeTelNo = NullConstant.STRING;
		public string InsuranceInchargeTelNo
		{			
			set{insuranceInchargeTelNo = value.Trim();}
			get{return insuranceInchargeTelNo;}
		}

        protected VehicleInsuranceList aVehicleInsuranceList;
		public VehicleInsuranceList AVehicleInsuranceList
		{
			set{aVehicleInsuranceList = value;}
			get{return aVehicleInsuranceList;}			
		}

//		============================== Constructor ==============================
        public InsuranceTypeOne(ictus.Common.Entity.Company value): base()
		{
			aVehicleInsuranceList = new VehicleInsuranceList(value);
		}

        public InsuranceTypeOne() : base()
        {
        }

        public int Count
        {
            get{return 0;}
        }
    }
}
