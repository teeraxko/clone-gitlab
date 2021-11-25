using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

namespace Entity.ContractEntities
{
	public class ServiceStaffContract : ContractBase
	{
//		============================== Property ==============================
		protected ServiceStaffRoleList aLatestServiceStaffRoleList;
		public ServiceStaffRoleList ALatestServiceStaffRoleList
		{
			get{return aLatestServiceStaffRoleList;}
			set{aLatestServiceStaffRoleList = value;}
		}

//		==================================Constructor==================================
        public ServiceStaffContract(ictus.Common.Entity.Company company)
            : base(company)
		{
			aLatestServiceStaffRoleList = new ServiceStaffRoleList(company);
		}

		#region IKey Members

        public override string EntityKey
		{
			get
			{
				return base.EntityKey;
			}
		}

		#endregion
	}
}
