using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class AnnualLeaveHeadList : ictus.Common.Entity.CompanyStuffBase
	{
		//==============================   Property    ==============================
		private AnnualLeaveControl leaveControl;
		public AnnualLeaveControl LeaveControl
		{
			get{return leaveControl;}
		}

		public int ForYear
		{
			get{return leaveControl.ForYear;}
		}

		//==============================  Constructor  ==============================
        public AnnualLeaveHeadList(AnnualLeaveControl value, ictus.Common.Entity.Company company)
            : base(company)
		{
			leaveControl = value;
		}

		//============================== Public Method ==============================
		public void Add(AnnualLeaveHead value)
		{base.Add(value);}

		public void Remove(AnnualLeaveHead value)
		{base.Remove(value);}

		public AnnualLeaveHead this[int index]
		{
			get{return (AnnualLeaveHead) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}
		public AnnualLeaveHead this[String key]  
		{
			get{return (AnnualLeaveHead) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}