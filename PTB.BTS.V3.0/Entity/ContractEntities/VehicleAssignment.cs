using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
	public class VehicleAssignment : AssignmentBase,IKey
	{
//		============================== Property ==============================
		private Vehicle aAssignedVehicle;
		public Vehicle AAssignedVehicle
		{
			get{return aAssignedVehicle;}
			set{aAssignedVehicle = value;}
		}

		private Vehicle aMainVehicle;
		public Vehicle AMainVehicle
		{
			get{return aMainVehicle;}
			set{aMainVehicle = value;}
		}

		private ASSIGNMENT_ROLE_TYPE assignmentRole = ASSIGNMENT_ROLE_TYPE.NULL;
		public ASSIGNMENT_ROLE_TYPE AssignmentRole
		{
			get{return assignmentRole;}
			set{assignmentRole = value;}
		}

		private AssignmentReason aAssignmentReason;
		public AssignmentReason AAssignmentReason
		{
			get{return aAssignmentReason;}
			set{aAssignmentReason = value;}
		}

//		============================== Constructor ==============================
		public VehicleAssignment(): base()
		{
			aAssignmentReason = new AssignmentReason();
		}

		#region IKey Members

		public override string EntityKey
		{
			get
			{
				return base.EntityKey + aAssignedVehicle.EntityKey + aMainVehicle.EntityKey;
			}
		}

		#endregion
	}
}
