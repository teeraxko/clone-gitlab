using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class EmployeeOvertimeAmount : EmployeeStuffBase
	{
//		============================== Property ==============================
		private OvertimeAmountList aOvertimeAmountList;
		public OvertimeAmountList AOvertimeAmountList
		{
			get
			{return aOvertimeAmountList;}
			set
			{aOvertimeAmountList = value;}
		}
//		==================================Constructor==================================
		public EmployeeOvertimeAmount(Employee aEmployee) : base(aEmployee)
		{
			
		}

	//	============================== Public Method ==============================
		public void Add(OvertimeAmount value)
		{
			base.Add(value);
		}

		public void Remove(OvertimeAmount value)  
		{
			base.Remove(value);
		}

		public OvertimeAmount this[int index]
		{
			get
			{
				return (OvertimeAmount) base.BaseGet(index);
			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public OvertimeAmount this[String key]  
		{
			get
			{
				return (OvertimeAmount) base.BaseGet(key);
			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
