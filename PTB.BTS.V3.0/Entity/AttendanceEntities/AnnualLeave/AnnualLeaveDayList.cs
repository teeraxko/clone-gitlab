using System;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class AnnualLeaveDayList : EmployeeStuffBase
	{
		//==============================   Property    ==============================

		//==============================  Constructor  ==============================
		public AnnualLeaveDayList(Employee value) : base(value)
		{
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
	}
}