using System;

using Entity.CommonEntity;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class AnnualLeaveHead : EntityBase, IKey
	{
		//==============================   Property    ==============================
		private int forYear = NullConstant.INT;
		public int ForYear
		{
			get{return forYear;}
		}

		private Employee employee;
		public Employee Employee
		{
			get{return employee;}
		}

		private decimal totalDays = 0;
		public decimal TotalDays
		{
			get{return totalDays;}
			set{totalDays = value;}
		}

		private decimal useDays = 0;
		public decimal UseDays
		{
			get{return useDays;}
			set{useDays = value;}
		}

		private decimal sellDays = 0;
		public decimal SellDays
		{
			get{return sellDays;}
			set{sellDays = value;}
		}

		public decimal RemainDays
		{
			get{return totalDays - useDays - sellDays;}
		}

		//==============================  Constructor  ==============================
		public AnnualLeaveHead(Employee value, int forYear) : base()
		{
			this.forYear = forYear;
			employee = value;
		}

		public AnnualLeaveHead() : base()
		{
		
		}

		//============================== Public Method ==============================
		public override string EntityKey
		{
			get{return employee.EntityKey;}
		}

		public bool Remain(AnnualLeaveDay value)
		{
			if(RemainDays>=1 || (RemainDays==0.5m && value.PeriodStatus != LEAVE_PERIOD_TYPE.ONE_DAY))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public AnnualLeaveHead Clone()
		{
			AnnualLeaveHead annualLeaveHead = new AnnualLeaveHead(employee, forYear);
			annualLeaveHead.TotalDays = totalDays;
			annualLeaveHead.UseDays = useDays;
			annualLeaveHead.SellDays = sellDays;
			return annualLeaveHead;
		}
	}
}