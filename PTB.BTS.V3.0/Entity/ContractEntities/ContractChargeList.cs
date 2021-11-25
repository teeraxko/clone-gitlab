using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
    public class ContractChargeList : CompanyStuffBase
	{
//		============================== Property ==============================
        protected ContractBase aContract;
		public ContractBase AContract
		{
			get{return aContract;}
			set{aContract = value;}
		}

//		============================== Constructor ==============================
        public ContractChargeList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(ContractCharge value)
		{base.Add(value);}

		public void Remove(ContractCharge value)
		{base.Remove(value);}
	
		public ContractCharge this[int index]
		{
			get{return (ContractCharge) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public ContractCharge this[String key]  
		{
			get{return (ContractCharge) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}

        //#region ICloneable Members

        //public object Clone()
        //{
        //    ContractChargeList newList = new ContractChargeList(this.Company);

        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        ContractCharge currentObject = (ContractCharge) this.BaseGet(i);
        //        ContractCharge newObject = (ContractCharge)EntityUtilities.SetProperties(currentObject);

        //        newList.Add(newObject);
        //    }

        //    return newList;
        //}

        //#endregion
	}
}
