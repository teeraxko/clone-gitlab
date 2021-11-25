using System;

using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class AnnualLeaveDualHeadList : CompanyStuffBase
	{
		//==============================   Property    ==============================
		public int ForYear
		{
			get{return leaveControl.ForYear;}
		}

		private AnnualLeaveControl leaveControl;
		public AnnualLeaveControl LeaveControl
		{
			get{return leaveControl;}
		}

		//==============================  Constructor  ==============================
        public AnnualLeaveDualHeadList(AnnualLeaveControl value, Company company)
            : base(company)
		{
			leaveControl = value;
		}

		//============================== Public Method ==============================
		public void Add(AnnualLeaveDualHead value)
		{base.Add(value);}

		public void Remove(AnnualLeaveDualHead value)
		{base.Remove(value);}

		public AnnualLeaveDualHead this[int index]
		{
			get{return (AnnualLeaveDualHead) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}
		public AnnualLeaveDualHead this[String key]  
		{
			get{return (AnnualLeaveDualHead) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}