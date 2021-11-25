using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
    public class VehicleRoleList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public VehicleRoleList(ictus.Common.Entity.Company value)
            : base(value)
		{}

//		============================== Public Method ==============================
		public void Add(VehicleRole value)
		{base.Add(value);}

		public void Remove(VehicleRole value)
		{base.Remove(value);}

		public VehicleRole this[int index]
		{
			get{return((VehicleRole) base.BaseGet(index));}
			set{base.BaseSet(index, value);}
		}

		public VehicleRole this[String key]  
		{
			get{return((VehicleRole)base.BaseGet(key));}
			set{base.BaseSet(key, value);}
		}

        //#region ICloneable Members

        //public object Clone()
        //{
        //    VehicleRoleList newList = new VehicleRoleList(this.Company);

        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        VehicleRole currentObject = (VehicleRole)this.BaseGet(i);
        //        VehicleRole newObject = (VehicleRole)EntityUtilities.SetProperties(currentObject);

        //        newList.Add(newObject);
        //    }

        //    return newList;
        //}

        //#endregion
	}
}
