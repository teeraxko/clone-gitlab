using System;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class OTPatternSpecificCondition : OTPatternConditionBase, IKey
	{
//		============================== Property ==============================
		private Employee aEmployee;
		public Employee AEmployee
		{
			set{aEmployee = value;}
			get{return aEmployee;}
		}

		private OTPatternList aOTPatternList;
		public OTPatternList AOTPatternList
		{
			get{return aOTPatternList;}
			set{aOTPatternList=value;}
		}

//		============================== Constructor ==============================
		public OTPatternSpecificCondition(Employee employee) : base()
		{
			aEmployee = employee;
			aOTPatternList = new OTPatternList(employee.Company);
		}

        public OTPatternSpecificCondition(ictus.Common.Entity.Company company)
            : base()
		{
			aOTPatternList = new OTPatternList(company);
		}

		#region IKey Members

		public override string EntityKey
		{
			get{return base.EntityKey + aEmployee.EntityKey;}
		}

		#endregion
	}
}
