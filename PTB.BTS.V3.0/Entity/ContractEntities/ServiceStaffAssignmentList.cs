using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
    public class ServiceStaffAssignmentList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Property ==============================
		protected ServiceStaff aServiceStaff;	
		public ServiceStaff AServiceStaff
		{
			get
			{return aServiceStaff;}
			set 
			{aServiceStaff = value;}
		}

//		============================== Constructor ==============================
        public ServiceStaffAssignmentList(ictus.Common.Entity.Company aCompany)
            : base(aCompany)
		{
		}

        public ServiceStaffAssignmentList(ServiceStaff value, ictus.Common.Entity.Company aCompany)
            : base(aCompany)
		{
			aServiceStaff = value;
		}

//		============================== Public Method ==============================
		public void Add(ServiceStaffAssignment value)
		{base.Add(value);}

		public void Remove(ServiceStaffAssignment value)
		{base.Remove(value);}

		public ServiceStaffAssignment this[int index]
		{
			get{return((ServiceStaffAssignment) base.BaseGet(index));}
			set{base.BaseSet(index, value);}
		}

		public ServiceStaffAssignment this[String key]  
		{
			get{return((ServiceStaffAssignment)base.BaseGet(key));}
			set{base.BaseSet(key, value);}
		}

	}
}
