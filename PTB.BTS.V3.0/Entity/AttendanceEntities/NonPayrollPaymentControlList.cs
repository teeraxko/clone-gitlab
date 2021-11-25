using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{
    public class NonPayrollPaymentControlList : CompanyStuffBase
	{
//		============================== Property ==============================
		private YearMonth aYearMonth = NullConstant.YEARMONTH;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

//		============================== Constructor ==============================
        public NonPayrollPaymentControlList(Company value, YearMonth forYearMonth)
            : base(value)
		{
			aYearMonth = forYearMonth;
		}

//		============================== Public Method ==============================
		public void Add(NonPayrollPaymentControl value)
		{base.Add(value);}

		public void Remove(NonPayrollPaymentControl value)
		{base.Remove(value);}

		public NonPayrollPaymentControl this[int index]
		{
			get{return (NonPayrollPaymentControl) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public NonPayrollPaymentControl this[String key]  
		{
			get{return (NonPayrollPaymentControl) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
