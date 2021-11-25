using System;
using System.Data;
using System.Collections;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using PTB.BTS.Vehicle.Flow;
using PTB.BTS.Common.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;

namespace Facade.VehicleFacade
{
	
	public class InsuranceTypeOnePolicyListFacade : CommonPIFacadeBase
	{
		#region - Private -
		private InsuranceTypeOneFlow flowInsuranceTypeOne;
		#endregion

		//		============================== Property ==============================
		private InsuranceTypeOneList objInsuranceTypeOneList;
		public InsuranceTypeOneList ObjInsuranceTypeOneList
		{
			get
			{
				return objInsuranceTypeOneList;
			}
		}
		private InsuranceTypeOne conditionInsuranceTypeOne;
		public InsuranceTypeOne ConditionInsuranceTypeOne
		{
			set
			{
				conditionInsuranceTypeOne = value;
			}
			get
			{
				return conditionInsuranceTypeOne;
			}
		}
	
		//		============================== Constructor ==============================
		public InsuranceTypeOnePolicyListFacade() : base()
		{
			flowInsuranceTypeOne = new InsuranceTypeOneFlow();
			conditionInsuranceTypeOne = new InsuranceTypeOne(GetCompany());
		}
		
		//		============================== Public Method ==============================
		public bool DisplayInsuranceTypeOne()
		{
			objInsuranceTypeOneList = new InsuranceTypeOneList(GetCompany());
			return flowInsuranceTypeOne.FillInsuranceTypeOneList(ref objInsuranceTypeOneList, conditionInsuranceTypeOne);
		}

		public bool DisplayExpireInsuranceTypeOne(DateTime expireDate)
		{
			objInsuranceTypeOneList = new InsuranceTypeOneList(GetCompany());
			return flowInsuranceTypeOne.FillExpireInsuranceTypeOneList(ref objInsuranceTypeOneList, expireDate);
		}
	}
}
