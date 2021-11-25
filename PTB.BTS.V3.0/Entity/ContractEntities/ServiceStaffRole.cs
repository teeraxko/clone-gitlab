using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
	public class ServiceStaffRole : EntityBase, IKey
	{
//		============================== Property ==============================
		private ServiceStaff aServiceStaff;
		public ServiceStaff AServiceStaff
		{
			get{return aServiceStaff;}
			set{aServiceStaff = value;}
		}

		private ServiceStaffType aServiceStaffType;
		public ServiceStaffType AServiceStaffType
		{
			get{return aServiceStaffType;}
			set{aServiceStaffType = value;}
		}

		private int serviceStaffOrder = NullConstant.INT;
		public int ServiceStaffOrder
		{
			get{return serviceStaffOrder;}
			set{serviceStaffOrder = value;}
		}

//		============================== Constructor ==============================
		public ServiceStaffRole() : base()
		{}

		#region IKey Members

		public override string EntityKey
		{
			get
			{return serviceStaffOrder.ToString();}
		}

		#endregion
	}
}
