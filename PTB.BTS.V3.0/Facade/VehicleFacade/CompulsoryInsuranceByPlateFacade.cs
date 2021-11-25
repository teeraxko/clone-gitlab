using System;
using System.Collections;

using Entity.CommonEntity;
using Entity.AttendanceEntities;
using Entity.VehicleEntities;

using PTB.BTS.Common.Flow;
using PTB.BTS.Vehicle.Flow;

using Facade.PiFacade;

using ictus.Common.Entity.Time;

namespace Facade.VehicleFacade
{
	public class CompulsoryInsuranceByPlateFacade : CommonPIFacadeBase
	{
		#region - Constant -
		#endregion

		#region - Private - 
			private CompulsoryInsuranceFlow flowCompulsoryInsurance;
			private AgeFlow flowAge;
		#endregion

		//============================== DataSource ==============================
		#region - DataSource -
		public ArrayList DataSourceInsuranceCompany
		{
			get
			{
				InsuranceCompanyFlow flowInsuranceCompany = new InsuranceCompanyFlow();
				InsuranceCompanyList insuranceCompanyList = new InsuranceCompanyList(GetCompany());
				flowInsuranceCompany.FillInsuranceCompanyList(ref insuranceCompanyList);
				flowInsuranceCompany = null;
				return insuranceCompanyList.GetArrayList();
			}
		}
		#endregion

		//============================== Property ==============================
		private CompulsoryInsuranceList compulsoryInsuranceList;
		public CompulsoryInsuranceList CompulsoryInsuranceList
		{
			get
			{
				return compulsoryInsuranceList;
			}
		}

		//============================== Constructor ==============================
		public CompulsoryInsuranceByPlateFacade()
		{
			flowAge = new AgeFlow();
			flowCompulsoryInsurance = new CompulsoryInsuranceFlow();
			compulsoryInsuranceList = new CompulsoryInsuranceList(GetCompany());
		}

		//============================== Private Method ==============================

		//============================== Public Method ==============================
		public YearMonth CalculateAge(DateTime value)
		{
			return flowAge.CalculateAge(value);
		}

		public void CalculateTotalPremium(CompulsoryInsurance value)
		{			
			VehicleFunction.CalculateTotalPremium(value, VehicleFunction.GetVATRate().Rate);
		}

		public bool CheckPolicyNo(string policyNo)
		{
			CompulsoryInsurance compulsoryInsurance = new CompulsoryInsurance();
			compulsoryInsurance.PolicyNo = policyNo;
			return flowCompulsoryInsurance.FillCompulsoryInsurance(ref compulsoryInsurance, GetCompany());
		}

		public bool ValidateCompulsoryInsurancePeriod(TimePeriod value)
		{
			TimePeriod compulsoryTimePeriod;
			for(int i=0; i<compulsoryInsuranceList.Count; i++)
			{
				compulsoryTimePeriod = compulsoryInsuranceList[i].APeriod;
				if(compulsoryTimePeriod.To > value.From && compulsoryTimePeriod.From < value.To)
				{
					return false;
				}
			}
			return true;
		}

		public bool DisplayCompulsoryInsurance(Vehicle value)
		{
			CompulsoryInsurance compulsoryInsurance = new CompulsoryInsurance();
			compulsoryInsurance.AVehicle = value;
			compulsoryInsuranceList.Clear();
			return flowCompulsoryInsurance.FillCompulsoryInsuranceList(ref compulsoryInsuranceList, compulsoryInsurance);
		}

		public Vehicle GetVehicle(string platePrefix, string plateNo)
		{
			VehicleFlow flowVehicle = new VehicleFlow();
			Vehicle vehicle = new Vehicle();
			vehicle.PlatePrefix = platePrefix;
			vehicle.PlateRunningNo = plateNo;
			bool result = flowVehicle.FillVehicleGeneral(ref vehicle, GetCompany());
			flowVehicle = null;
			if(result)
			{
				return vehicle;
			}
			else
			{
				return null;
			}
		}

		
		public CompulsoryInsurance GetLatestCompulsoryInsurance(Vehicle value)
		{
			CompulsoryInsurance compulsoryInsurance = new CompulsoryInsurance();
			compulsoryInsurance.AVehicle = value;
			if(flowCompulsoryInsurance.FillCurrentCompulsoryInsurance(ref compulsoryInsurance, GetCompany()))
			{
				return compulsoryInsurance;
			}
			else
			{
				return null;
			}			
		}

		public bool InsertCompulsoryInsurance(CompulsoryInsurance value)
		{
			if(compulsoryInsuranceList.Contain(value))
			{
				return false;
			}
			else
			{
				if(flowCompulsoryInsurance.InsertCompulsoryInsurance(value, GetCompany()))
				{
					compulsoryInsuranceList.Add(value);
					return true;
				}
				else
				{
					return false;					
				}
			}
		}

		public bool UpdateCompulsoryInsurance(CompulsoryInsurance value)
		{
			if(flowCompulsoryInsurance.UpdateCompulsoryInsurance(value, GetCompany()))
			{
				compulsoryInsuranceList[value.EntityKey] = value;
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool DeleteCompulsoryInsurance(CompulsoryInsurance value)
		{
			if(flowCompulsoryInsurance.DeleteCompulsoryInsurance(value, GetCompany()))
			{
				compulsoryInsuranceList.Remove(value);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}