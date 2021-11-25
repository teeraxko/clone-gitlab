using System;
using System.Data;
using System.Collections;

using Entity.VehicleEntities;
using Entity.CommonEntity;
using Entity.VehicleEntities.VehicleLeasing;

using PTB.BTS.Vehicle.Flow;
using PTB.BTS.Common.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;

using ictus.Common.Entity.Time;

namespace Facade.VehicleFacade
{
	public class VehicleListFacade : CommonPIFacadeBase
	{
		#region - Private -
		private VehicleFlow flowVehicle;
		private AgeFlow flowAge;
		#endregion
//		============================== Property ==============================
		private VehicleList objVehicleList;
		public VehicleList ObjVehicleList
		{
			get{return objVehicleList;}
		}

		private Vehicle conditionVehicle;
		public Vehicle ConditionVehicle
		{
			set{conditionVehicle = value;}
			get{return conditionVehicle;}
		}

        private string conditionPurchasing;
        public string ConditionPurchasing
        {
            set { conditionPurchasing = value; }
            get { return conditionPurchasing; }
        }

//		============================== Constructor ==============================
		public VehicleListFacade(): base()
		{
			flowVehicle = new VehicleFlow();
			conditionVehicle = new Vehicle();
			flowAge = new AgeFlow();
		}
		
//		============================== Public Method ==============================
		public YearMonth CalculateAge(DateTime value)
		{			
			return flowAge.CalculateAge(value);
		}

		public bool DisplayVehicle()
		{
            objVehicleList = new VehicleList(GetCompany());

		    return flowVehicle.FillVehicleList(ref objVehicleList, conditionVehicle);
		}

        public bool DisplayVehicleByPO()
        {
            objVehicleList = new VehicleList(GetCompany());

            return flowVehicle.FillVehicleList(ref objVehicleList, conditionPurchasing);
        }

        public bool DisplayVehicleActiveList(DateTime fromDate, DateTime toDate)
        {
            objVehicleList = new VehicleList(GetCompany());

            return flowVehicle.FillVehicleActiveList(objVehicleList, fromDate, toDate);
        }

		public bool DisplayVehicleOutInsurance(DateTime startDate, DateTime endDate)
		{
			objVehicleList = new VehicleList(GetCompany());
			return flowVehicle.FillVehicleOutInsurance(ref objVehicleList, startDate, endDate, conditionVehicle);
		}

		public bool DisplayVehicleIsAssign()
		{
			objVehicleList = new VehicleList(GetCompany());
			return flowVehicle.FillVehicleIsAssign(ref objVehicleList, conditionVehicle);
		}

		public bool DisplayVehicleAvailable()
		{
			objVehicleList = new VehicleList(GetCompany());
			return flowVehicle.FillVehicleAvailableList(ref objVehicleList);
		}

        public bool DisplayVehicleIsAssign(DateTime fromDate, DateTime toDate)
        {
            objVehicleList = new VehicleList(GetCompany());
            return flowVehicle.FillVehicleIsAssignList(objVehicleList, fromDate, toDate, conditionVehicle);
        }

        public bool DisplayVehicleByCalculation()
        {
            objVehicleList = new VehicleList(GetCompany());

            return flowVehicle.FillVehicleListByCalculation(ref objVehicleList, conditionVehicle);
        }
    }
}
