using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using ictus.Common.Entity.Time;
using Entity.ContractEntities;

namespace Entity.AttendanceEntities
{	
	public class EmployeeOvernightTripBenefit : EmployeeBenefitBase, IKey
	{
//		============================== Property ==============================
		private YearMonth forYearMonth = NullConstant.YEARMONTH;
		public YearMonth ForYearMonth
		{
			get{return forYearMonth;}
			set{forYearMonth = value;}
		}

		private Customer aCustomer;
		public Customer ACustomer
		{
			get{return aCustomer;}
			set{aCustomer = value;}
		}

		private CustomerDepartment aCustomerDepartment;
		public CustomerDepartment ACustomerDepartment
		{
			get{return aCustomerDepartment;}
			set{aCustomerDepartment = value;}
		}

		private OvernightTrip aOvernightTrip;
		public OvernightTrip AOvernightTrip
		{
			get{return aOvernightTrip;}
			set{aOvernightTrip = value;}
		}

		public int Times
		{
			get{return this.Count;}
		}

		public decimal TotalAmount
		{
			get
			{
				decimal totalAmount = 0;
				for(int i=0; i<this.Count; i++)
				{
					totalAmount += this[i].TotalAmount;
				}
				return totalAmount;
			}
		}

		private BenefitPayment aBenefitPayment;
		public BenefitPayment ABenefitPayment
		{
			get{return aBenefitPayment;}
			set{aBenefitPayment = value;}
		}

		private bool advancePaymentStatus;
		public bool AdvancePaymentStatus
		{
			get{return advancePaymentStatus;}
			set{advancePaymentStatus = value;}
		}

//		============================== Constructor ==============================
		public EmployeeOvernightTripBenefit(YearMonth forYearMonth, Employee employee) : base(employee)
		{
			aOvernightTrip = new OvernightTrip();
			aBenefitPayment = new BenefitPayment();
			this.forYearMonth = forYearMonth;
		}

//		============================== Public Method ==============================
		public void Add(OvernightTripBenefit value)
		{
			base.Add(value);
		}

		public void Remove(OvernightTripBenefit value)
		{
			base.Remove(value);
		}

		public OvernightTripBenefit this[int index]
		{
			get{return (OvernightTripBenefit) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public OvernightTripBenefit this[String key]  
		{
			get{return (OvernightTripBenefit) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}

		public string EntityKey
		{
			get
			{
				return aOvernightTrip.EntityKey;
			}
		}
	}
}