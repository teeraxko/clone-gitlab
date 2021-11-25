using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;

using Entity.CommonEntity;

namespace Entity.AttendanceEntities
{
	public class AnnualLeave : EntityBase, IKey
	{
		//==============================   Property    ==============================
		public int ForYear
		{
			get{return currentAnnualLeave.ForYear;}
		}

        public Employee Employee
		{
			get{return currentAnnualLeave.Employee;}
		}
	
		private AnnualLeaveYear currentAnnualLeave;
		public AnnualLeaveYear CurrentAnnualLeave
		{
			get{return currentAnnualLeave;}
			set{currentAnnualLeave = value;}
		}

		private AnnualLeaveYear previousAnnualLeave;
		public AnnualLeaveYear PreviousAnnualLeave
		{
			get{return previousAnnualLeave;}
			set{previousAnnualLeave = value;}
		}

		public bool Existing
		{
			get{return currentAnnualLeave.Existing;}
		}

		//==============================  Constructor  ==============================
		public AnnualLeave() : base()
		{
		}

		#region - Private Method -
			private bool contain(AnnualLeaveDay value, AnnualLeaveYear annualLeaveYear)
			{
				if(annualLeaveYear!=null && annualLeaveYear.Contain(value.LeaveDate.ToShortDateString()))
				{
					if(value.PeriodStatus==LEAVE_PERIOD_TYPE.ONE_DAY || value.PeriodStatus==annualLeaveYear[value.LeaveDate.ToShortDateString()].PeriodStatus)
					{
						return true;
					}
				}
				return false;
			}
		#endregion

		//============================== Public Method ==============================
		public bool Contain(AnnualLeaveDay value)
		{
			return contain(value, previousAnnualLeave) || contain(value, currentAnnualLeave);
		}

		public bool Contain(AnnualLeaveDayList value)
		{
			for(int i=0; i<value.Count; i++)
			{
				if(Contain(value[i]))
				{
					return true;
				}
			}
			return false;
		}

		public override string EntityKey
		{
			get{return currentAnnualLeave.Employee.EntityKey;}
		}
	}
}