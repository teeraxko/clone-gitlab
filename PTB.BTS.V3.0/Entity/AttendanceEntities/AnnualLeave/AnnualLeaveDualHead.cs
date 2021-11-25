using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class AnnualLeaveDualHead : EntityBase, IKey
	{
		#region - Private -
			private AnnualLeaveHead current;
			private AnnualLeaveHead previous;
		#endregion

		//==============================   Property    ==============================
		public int ForYear
		{
			get{return current.ForYear;}
		}

		public Employee Employee
		{
			get{return current.Employee;}
		}

		public AnnualLeaveHead Current
		{
			get{return current;}
		}

		public AnnualLeaveHead Previous
		{
			get{return previous;}
		}
 
		//==============================  Constructor  ==============================
		public AnnualLeaveDualHead(AnnualLeaveHead currentYear, AnnualLeaveHead previousYear)
		{
			current = currentYear;
			previous = previousYear;
		}

		public override string EntityKey
		{
			get
			{
				return Employee.EntityKey;
			}
		}
	}
}