using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{
    public class PayrollPaymentControlList : ictus.Common.Entity.CompanyStuffBase
	{	
//		============================== Property ==============================
		private YearMonth aYearMonth = NullConstant.YEARMONTH;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

//		============================== Constructor ==============================
        public PayrollPaymentControlList(ictus.Common.Entity.Company value, YearMonth forYearMonth)
            : base(value)
		{
			aYearMonth = forYearMonth;
		}

//		============================== Public Method ==============================
		public void Add(PayrollPaymentControl value)
		{base.Add(value);}

		public void Remove(PayrollPaymentControl value)
		{base.Remove(value);}

		public PayrollPaymentControl this[int index]
		{
			get{return (PayrollPaymentControl) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public PayrollPaymentControl this[String key]  
		{
			get{return (PayrollPaymentControl) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
