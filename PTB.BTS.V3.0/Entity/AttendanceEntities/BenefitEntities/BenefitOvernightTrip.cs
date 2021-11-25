using System;

using Entity.AttendanceEntities;
using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;
using Entity.ContractEntities;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class BenefitOvernightTrip : EntityBase, IKey
	{
		//==============================   Property  ==============================
		private TimePeriod period;
		public DateTime From
		{
			get{return period.From;}
			set{period.From = value;}
		}

		public DateTime To
		{
			get{return period.To;}
			set{period.To = value;}
		}

		private Customer customer;
		public Customer Customer
		{
			get{return customer;}
			set{customer = value;}
		}

		private CustomerDepartment customerDepartment;
		public CustomerDepartment CustomerDepartment
		{
			get{return customerDepartment;}
			set{customerDepartment = value;}
		}

		private TripLocation location;
		public TripLocation Location
		{
			get{return location;}
			set{location = value;}
		}

		public int Times
		{
			get
			{
				int times = 0;
				for(DateTime temp = period.From; temp < period.To; temp = temp.AddDays(1))
				{
					times++;
				}
				return times;
			}
		}

		private decimal amount = NullConstant.DECIMAL;
		public decimal Amount
		{
			get{return amount;}
			set{amount = value;}
		}

		public decimal TotalAmount
		{
			get{return amount * Times;}
		}
		
		private bool advancePaymentStatus;
		public bool AdvancePaymentStatus
		{
			get{return advancePaymentStatus;}
			set{advancePaymentStatus = value;}
		}

		private BenefitPayment benefitPayment;
		public BenefitPayment BenefitPayment
		{
			get{return benefitPayment;}
			set{benefitPayment = value;}
		}


		//============================== Constructor ==============================
		public BenefitOvernightTrip() : base()
		{
			period = new TimePeriod();
			location = new TripLocation();
			benefitPayment = new BenefitPayment();
		}

		public bool Contain(DateTime value)
		{
			return (period.From.Date <= value.Date && value.Date < period.To.Date);
		}

		public override string EntityKey
		{
			get
			{
				return period.From.ToShortTimeString() + period.To.ToShortTimeString();
			}
		}
	}
}