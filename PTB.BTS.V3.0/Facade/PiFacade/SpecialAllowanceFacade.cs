using System;
using System.Data;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

using SystemFramework.AppException;
namespace Facade.PiFacade
{

	public class SpecialAllowanceFacade : CommonPIFacadeBase
	{
		#region - Private -
		private SpecialAllowanceFlow flowSpecialAllowance;
		#endregion

        //============================== Property ==============================
		private SpecialAllowanceList objSpecialAllowanceList;
		public SpecialAllowanceList ObjSpecialAllowanceList
		{
			get{return objSpecialAllowanceList;}
		}

        //============================== Constructor ==============================
		public SpecialAllowanceFacade()
		{
			flowSpecialAllowance = new SpecialAllowanceFlow();
		}

        //============================== Public Method ==============================
		public bool DisplaySpecialAllowance()
		{
			objSpecialAllowanceList = new SpecialAllowanceList(GetCompany());
			return flowSpecialAllowance.FillSpecialAllowance(objSpecialAllowanceList);
		}

        public bool InsertSpecialAllowance(SpecialAllowance specialAllowance)
        {
            if (objSpecialAllowanceList.Contain(specialAllowance))
            {
                throw new DuplicateException("SpecialAllowanceFacade");
            }
            else
            {
                if (flowSpecialAllowance.InsertSpecialAllowance(specialAllowance, GetCompany()))
                {
                    objSpecialAllowanceList.Add(specialAllowance);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateModel(SpecialAllowance specialAllowance)
        {
            if (flowSpecialAllowance.UpdateSpecialAllowance(specialAllowance, GetCompany()))
            {
                objSpecialAllowanceList[specialAllowance.EntityKey] = specialAllowance;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteModel(SpecialAllowance specialAllowance)
        {
            if (flowSpecialAllowance.DeleteSpecialAllowance(specialAllowance, GetCompany()))
            {
                objSpecialAllowanceList.Remove(specialAllowance);
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}
