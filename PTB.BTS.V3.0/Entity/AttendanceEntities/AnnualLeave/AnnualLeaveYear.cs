using System;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class AnnualLeaveYear : EmployeeStuffBase
	{
		//==============================   Property    ==============================
		private AnnualLeaveControl leaveControl;
		public AnnualLeaveControl LeaveControl
		{
			get{return leaveControl;}
		}

		private AnnualLeaveHead leaveHead;
		public AnnualLeaveHead LeaveHead
		{
			get{return leaveHead;}
		}

		public int ForYear
		{
			get{return leaveHead.ForYear;}
		}

		public bool Existing
		{
			get{return (leaveControl!=null && leaveHead!=null);}
		}

		//==============================  Constructor  ==============================
		public AnnualLeaveYear(AnnualLeaveControl leaveControl, AnnualLeaveHead leaveHead) : base(leaveHead.Employee)
		{
			this.leaveControl = leaveControl;
			this.leaveHead = leaveHead;
		}

		//============================== Public Method ==============================
		public void Add(AnnualLeaveDay value)
		{base.Add(value);}

		public void Remove(AnnualLeaveDay value)
		{base.Remove(value);}


		public AnnualLeaveDay this[int index]
		{
			get{return (AnnualLeaveDay) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}
		public AnnualLeaveDay this[String key]  
		{
			get{return (AnnualLeaveDay) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}

		public bool Available(AnnualLeaveDay value)
		{
			if(Existing && value.ForYear==leaveHead.ForYear && leaveControl.ValidPeriod.From<=value.LeaveDate && value.LeaveDate<=leaveControl.ValidPeriod.To)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool Remain(AnnualLeaveDay value)
		{
			if(Existing && leaveHead.Remain(value))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public decimal CountByMonth(int month)
		{
			decimal result = 0;
			for(int i=0; i<this.Count; i++)
			{
				if (this[i].LeaveDate.Month == month)
				{
					result += this[i].DaysUsed;
				}
			}
			return result;
		}

		public AnnualLeaveYear Clone()
		{
			AnnualLeaveYear annualLeaveYear = new AnnualLeaveYear(leaveControl, leaveHead.Clone());
			for(int i=0; i<this.Count; i++)
			{
				annualLeaveYear.Add(this[i].Clone());
			}
			annualLeaveYear.LeaveHead.UseDays = leaveHead.UseDays;
			return annualLeaveYear;
		}
	}
}