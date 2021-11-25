using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;
using Entity.ContractEntities;

namespace Entity.AttendanceEntities
{

	public class WorkingTimeCondition : EntityBase, IKey
	{
//		============================== Property ==============================
		private WorkingTimeTable aWorkingTimeTable;
		public WorkingTimeTable AWorkingTimeTable
		{
			set{aWorkingTimeTable = value;}
			get{return aWorkingTimeTable;}
		}

		private PositionType aPositionType;
		public PositionType APositionType
		{
			set{aPositionType = value;}
			get{return aPositionType;}
		}

		private ServiceStaffType aServiceStaffType;
		public ServiceStaffType AServiceStaffType
		{
			set{aServiceStaffType = value;}
			get{return aServiceStaffType;}
		}

		private CustomerDepartment aCustomerDepartment;
		public CustomerDepartment ACustomerDepartment
		{
			get{return aCustomerDepartment;}
			set{aCustomerDepartment = value;}
		}

//		============================== Constructor ==============================
		public WorkingTimeCondition():base()
		{
		}

//		============================== Public Method ==============================
 		public override string EntityKey
		{
			get
			{				
				return aPositionType.EntityKey + aServiceStaffType.EntityKey + aCustomerDepartment.EntityKey;
			}
		}
	}
}
