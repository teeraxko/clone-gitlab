using System;

using Facade.PiFacade;
using ictus.Common.Entity;
using SystemFramework.AppException;

using PTB.BTS.Contract.Flow.ContractChargeRateFlow;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace Facade.ContractFacade.ContractChargeRateFacade
{
    public class MinimumOTChargeFacade : CommonPIFacadeBase
    {
        private MinimumOTChargeFlow flowMinimumOTCharge;

        //============================== Property ==============================
        private MinimumOTChargeList objMinimumOTChargeList;
        public MinimumOTChargeList ObjMinimumOTChargeList
        {
            get{return objMinimumOTChargeList;}
        }

        //============================== Constructor ==============================
        public MinimumOTChargeFacade()
            : base()
        {
            flowMinimumOTCharge = new MinimumOTChargeFlow();
            objMinimumOTChargeList = new MinimumOTChargeList(GetCompany());
        }

        //============================== public method ==============================
        public bool DisplayMinimumOTChage()
        {
            objMinimumOTChargeList.Clear();
            return flowMinimumOTCharge.FillMinimumOTChargeList(objMinimumOTChargeList);
        }

        public bool InsertMinimumOTCharge(MinimumOTCharge value)
        {
            if (objMinimumOTChargeList.Contain(value))
            {
                throw new DuplicateException("MinimumOTChargeFacade");
            }
            else
            {
                if (flowMinimumOTCharge.InsertMinimumOTCharge(value, GetCompany()))
                {
                    objMinimumOTChargeList.Add(value);
                    return true;
                }
                else
                {
                    return false;
                }
            }			
        }

        public bool UpdateMinimumOTCharge(MinimumOTCharge value)
        {
            if (flowMinimumOTCharge.UpdateMinimumOTCharge(value, GetCompany()))
            {
                objMinimumOTChargeList[value.EntityKey] = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteMinimumOTCharge(MinimumOTCharge value)
        {
            if (flowMinimumOTCharge.DeleteMinimumOTCharge(value, GetCompany()))
            {
                objMinimumOTChargeList.Remove(value);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
