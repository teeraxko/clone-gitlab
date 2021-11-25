using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
    public class ServiceStaffRoleList : ictus.Common.Entity.CompanyStuffBase
	{
        public ServiceStaffRoleList(ictus.Common.Entity.Company value)
            : base(value)
		{}

//		============================== Public Method ==============================
		public void Add(ServiceStaffRole value)
		{base.Add(value);}

		public void Remove(ServiceStaffRole value)
		{base.Remove(value);}

		public ServiceStaffRole this[int index]
		{
			get{return((ServiceStaffRole) base.BaseGet(index));}
			set{base.BaseSet(index, value);}
		}

		public ServiceStaffRole this[String key]  
		{
			get{return((ServiceStaffRole)base.BaseGet(key));}
			set{base.BaseSet(key, value);}
		}

        //#region ICloneable Members

        //public object Clone()
        //{
        //    ServiceStaffRoleList newList = new ServiceStaffRoleList(this.Company);

        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        ServiceStaffRole currentObject = (ServiceStaffRole)this.BaseGet(i);
        //        ServiceStaffRole newObject = (ServiceStaffRole)EntityUtilities.SetProperties(currentObject);

        //        newList.Add(newObject);
        //    }

        //    return newList;
        //}

        //#endregion
	}
}
