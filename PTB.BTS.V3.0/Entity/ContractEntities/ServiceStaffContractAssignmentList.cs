using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
    public class ServiceStaffContractAssignmentList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Property ==============================
		private ServiceStaffContract aServiceStaffContract;	
		public ServiceStaffContract AServiceStaffContract
		{
			get
			{return aServiceStaffContract;}
			set 
			{aServiceStaffContract = value;}
		}

//		============================== Constructor ==============================
        public ServiceStaffContractAssignmentList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(ServiceStaffAssignment value)
		{
			base.Add(value);
		}

		public void Remove(ServiceStaffAssignment value)
		{
			base.Remove(value);
		}

		public ServiceStaffAssignment this[int index]
		{
			get
			{
				return((ServiceStaffAssignment) base.BaseGet(index));
			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public ServiceStaffAssignment this[String key]  
		{
			get
			{
				return((ServiceStaffAssignment)base.BaseGet(key));
			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
