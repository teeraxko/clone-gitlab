using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;
using Entity.ContractEntities;

namespace Entity.AttendanceEntities
{
	public class WorkingTimeConditionSpecific : EntityBase, IKey
	{
//		============================== Property ==============================
		private Employee aEmployee;
		public Employee AEmployee
		{
			set{aEmployee = value;}
			get{return aEmployee;}
		}

		private WorkingTimeTable aWorkingTimeTable;
		public WorkingTimeTable AWorkingTimeTable
		{
			set{aWorkingTimeTable = value;}
			get{return aWorkingTimeTable;}
		}
		
//		============================== Constructor ==============================
		public WorkingTimeConditionSpecific(): base()
		{
		}

		public override string EntityKey
		{
			get{return aEmployee.EntityKey;}
		}
	}
}
