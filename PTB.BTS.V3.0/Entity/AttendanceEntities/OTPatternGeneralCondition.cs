using System;

using ictus.Common.Entity.General;
using Entity.ContractEntities;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class OTPatternGeneralCondition : OTPatternConditionBase, IKey
	{
//		============================== Property ==============================
		private PositionType aPositionType;
		public PositionType APositionType
		{
			set{aPositionType = value;}
			get{return aPositionType;}
		}
	
		private ServiceStaffType aServiceStaffType;
		public ServiceStaffType AServiceStaffType
		{
			get{return aServiceStaffType;}
			set{aServiceStaffType = value;}
		}

		private Customer aCustomer;
		public Customer ACustomer
		{
			set{aCustomer = value;}
			get{return aCustomer;}
		}

		private CustomerDepartment aCustomerDepartment;
		public CustomerDepartment ACustomerDepartment
		{
			get{return aCustomerDepartment;}
			set{aCustomerDepartment = value;}
		}		

//		============================== Constructor ==============================
		public OTPatternGeneralCondition() : base()
		{
		}

		#region IKey Members

		public override string EntityKey
		{
			get{return base.EntityKey + aPositionType.EntityKey + aServiceStaffType.EntityKey + aCustomerDepartment.EntityKey;}
		}

		#endregion
	}
}
