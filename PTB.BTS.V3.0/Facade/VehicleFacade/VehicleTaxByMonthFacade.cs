using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;

using PTB.BTS.Vehicle.Flow;
using PTB.BTS.Common.Flow;
using PTB.BTS.Contract.Flow;
using PTB.BTS.Report.Flow;

using Facade.CommonFacade;
using Facade.PiFacade;

using ictus.Common.Entity.Time;


namespace Facade.VehicleFacade
{
	public class VehicleTaxByMonthFacade : CommonPIFacadeBase
	{
		#region - Private -
		private VehicleTaxFlow flowVehicleTax;	
		private ContractFlow flowContract;
		private TrExpiredVehicleTaxFlow flowTrExpiredVehicleTax;
		#endregion
//		============================== Property ==============================
		private VehicleTaxList latestVehicleTaxList;
		public VehicleTaxList LatestVehicleTaxList
		{
			get{return latestVehicleTaxList;}
		}

		private VehicleTaxList currentVehicleTaxList;
		public VehicleTaxList CurrentVehicleTaxList
		{
			get{return currentVehicleTaxList;}
			set{currentVehicleTaxList = value;}
		}

//		============================== Constructor ==============================
		public VehicleTaxByMonthFacade() : base()
		{
			flowVehicleTax = new VehicleTaxFlow();
			flowContract = new ContractFlow();
			flowTrExpiredVehicleTax = new TrExpiredVehicleTaxFlow();

			latestVehicleTaxList = new VehicleTaxList(GetCompany());
			currentVehicleTaxList = new VehicleTaxList(GetCompany());
		}

//		============================== Public Method ==============================
		public bool DisplayLatestVehicleTaxList(DateTime value)
		{
			bool result = false;
			YearMonth yearMonth = new YearMonth(value);
			latestVehicleTaxList.Clear();

			if(flowVehicleTax.FillLatestVehicleTaxList(ref latestVehicleTaxList, yearMonth))
			{			
				result = true;
			}
			return result;
		}

		public bool DisplayCurrentVehicleTaxByMonth(DateTime value)
		{
			YearMonth yearMonth = new YearMonth(value);
			VehicleTax vehicleTax;
			currentVehicleTaxList.Clear();


			if(flowVehicleTax.FillLatestVehicleTaxList(ref currentVehicleTaxList, yearMonth))
			{
				for(int i=0; i<currentVehicleTaxList.Count; i++)
				{
					vehicleTax = new VehicleTax();
					vehicleTax.AVehicle = currentVehicleTaxList[i].AVehicle;

					flowVehicleTax.FillBeginVehicleTax(ref vehicleTax, currentVehicleTaxList.Company);
					currentVehicleTaxList[i].TaxAmount = vehicleTax.TaxAmount;	

					vehicleTax = new VehicleTax();
					vehicleTax = currentVehicleTaxList[i];
					flowVehicleTax.CalculateVehicleTaxAmount(ref vehicleTax);
					currentVehicleTaxList[i] = vehicleTax;															
				}	
				vehicleTax = null;
				return true;
			}
			return false;
		}

		public ContractBase GetCurrentVehicleContract(Vehicle value)
		{
			return flowContract.GetCurrentVehicleContract(value, GetCompany());
		}

		public bool InsertVehicleTaxByMonth(VehicleTax value)
		{
			return flowVehicleTax.InsertVehicleTax(value, GetCompany());
		}

		public bool PrintVehicleTaxByMonth()
		{
			if(latestVehicleTaxList != null && currentVehicleTaxList != null)
			{
				return flowTrExpiredVehicleTax.PrintVehicleTaxByMonth(latestVehicleTaxList, currentVehicleTaxList);
			}
			return false;
		}
	}
}
