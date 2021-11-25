using System;
using System.Collections;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using PTB.BTS.Vehicle.Flow;
using PTB.BTS.Contract.Flow;
using PTB.BTS.Report.Flow;

using Facade.PiFacade;

using FarPoint.Win.Spread.CellType;

using SystemFramework.AppException;

using ictus.Common.Entity.Time;

namespace Facade.VehicleFacade
{
	public class CompulsoryInsuranceByMonthFacade : CommonPIFacadeBase
	{
		#region - Constant -
		#endregion

		#region - Private - 
			private CompulsoryInsuranceFlow flowCompulsoryInsurance;
			private ContractFlow flowContract;
			private TrExpiredCompulsoryInsuranceFlow flowTrExpiredCompulsoryInsurance;
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
		
		public InsuranceCompanyList OInsuranceCompanyList;

		//============================== Constructor ==============================
		public CompulsoryInsuranceByMonthFacade()
		{
			compulsoryInsuranceList = new CompulsoryInsuranceList(GetCompany());
			flowCompulsoryInsurance = new CompulsoryInsuranceFlow();
			flowContract = new ContractFlow();
			flowTrExpiredCompulsoryInsurance = new TrExpiredCompulsoryInsuranceFlow();

			OInsuranceCompanyList = new InsuranceCompanyList(GetCompany());
		}

		//============================== DataSource ==============================
		#region - DataSource -
		public ComboBoxCellType DataSourceInsuranceCompany
		{
			get
			{
				InsuranceCompanyFlow flowInsuranceCompany = new InsuranceCompanyFlow();
				InsuranceCompanyList insuranceCompanyList = new InsuranceCompanyList(GetCompany());
				flowInsuranceCompany.FillInsuranceCompanyList(ref insuranceCompanyList);
				flowInsuranceCompany = null;

				string[] items;
				string[] itemData;

				items = new string[insuranceCompanyList.Count];
				itemData = new string[insuranceCompanyList.Count];

				InsuranceCompany insuranceCompany;

				for(int i=0; i<insuranceCompanyList.Count; i++)
				{
					insuranceCompany = insuranceCompanyList[i];

					items[i] = insuranceCompany.AName.Thai;
					itemData[i] = insuranceCompany.Code;

					OInsuranceCompanyList.Add(insuranceCompany.AName.Thai, insuranceCompany);
				}

				ComboBoxCellType comboBox = new ComboBoxCellType();
				comboBox.Items = items;
				comboBox.ItemData = itemData;

				items = null;
				itemData = null;

				return comboBox;			
			}
		}
		#endregion

		//============================== Private Method ==============================
		public bool DisplayCompulsoryInsurance(DateTime value)
		{
			bool result = false;
			YearMonth yearMonth = new YearMonth(value);
			compulsoryInsuranceList.Clear();

			if(flowCompulsoryInsurance.FillCompulsoryInsuranceList(ref compulsoryInsuranceList, yearMonth))
			{
				string status;
				CompulsoryInsuranceList tempList = new CompulsoryInsuranceList(compulsoryInsuranceList.Company);
				CompulsoryInsurance compulsoryInsurance;

				for(int i=0; i<compulsoryInsuranceList.Count; i++)
				{
					tempList.Add(compulsoryInsuranceList[i]);
				}
			
				for(int i=0; i<tempList.Count; i++)
				{
					compulsoryInsurance = new CompulsoryInsurance();
					compulsoryInsurance = tempList[i];

                    //For case Vehicle deleted. : woranai 2007/12/19
                    if (tempList[i].AVehicle.AVehicleStatus == null)
                    {
                        compulsoryInsuranceList.Remove(compulsoryInsurance);
                    }
                    else
                    {
                        status = tempList[i].AVehicle.AVehicleStatus.Code;
                        if (status == "5" || status == "6")
                        {
                            compulsoryInsuranceList.Remove(compulsoryInsurance);
                        }
                    }
				}		
				result = true;
			}
			return result;
		}

		public bool CheckPolicyNo(string policyNo)
		{
			CompulsoryInsurance compulsoryInsurance = new CompulsoryInsurance();
			compulsoryInsurance.PolicyNo = policyNo;
			return flowCompulsoryInsurance.FillCompulsoryInsurance(ref compulsoryInsurance, GetCompany());
		}

		public ContractBase GetCurrentVehicleContract(Vehicle value)
		{
			return flowContract.GetCurrentVehicleContract(value, GetCompany());
		}

		public bool InsertCompulsoryInsurance(CompulsoryInsurance value)
		{
			return flowCompulsoryInsurance.InsertCompulsoryInsurance(value, GetCompany());
		}

		public bool PrintCompulsoryInsuranceByMonth()
		{
			if(compulsoryInsuranceList != null && compulsoryInsuranceList.Count > 0)
			{
				return flowTrExpiredCompulsoryInsurance.PrintCompulsoryInsuranceByMonth(compulsoryInsuranceList);
			}
			return false;
		}
	}
}
