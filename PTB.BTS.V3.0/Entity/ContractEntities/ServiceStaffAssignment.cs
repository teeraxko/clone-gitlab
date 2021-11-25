using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using Entity.CommonEntity;

namespace Entity.ContractEntities 
{
	public class ServiceStaffAssignment : AssignmentBase, IKey
	{
//		============================== Property ==============================
		private ServiceStaff aAssignedServiceStaff;
		public ServiceStaff AAssignedServiceStaff
		{
			get
			{return aAssignedServiceStaff;}
			set
			{aAssignedServiceStaff = value;}
		}
		private ServiceStaff aMainServiceStaff;
		public ServiceStaff AMainServiceStaff
		{
			get
			{return aMainServiceStaff;}
			set
			{aMainServiceStaff = value;}
		}
		private ASSIGNMENT_ROLE_TYPE assignmentRole = ASSIGNMENT_ROLE_TYPE.NULL;
		public ASSIGNMENT_ROLE_TYPE AssignmentRole
		{
			get
			{return assignmentRole;}
			set
			{assignmentRole = value;}
		}
		private int employeeOrder = NullConstant.INT;
		public int EmployeeOrder
		{
			get
			{return employeeOrder;}
			set
			{employeeOrder = value;}
		}

//		============================== Constructor ==============================
		public ServiceStaffAssignment() : base()
		{
		}

		public ServiceStaffAssignment(ServiceStaff value) : base()
		{
			aAssignedServiceStaff = value;
		}

		#region IKey Members

		public override string EntityKey
		{
			get
			{
				return base.EntityKey + aAssignedServiceStaff.EntityKey + aMainServiceStaff.EntityKey;
			}
		}

		#endregion
	}
}
