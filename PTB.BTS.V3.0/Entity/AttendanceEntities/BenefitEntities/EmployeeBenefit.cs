using System;

using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class EmployeeBenefit : EntityBase
	{
		//============================== Property ==============================
		private Employee employee;
		public Employee Employee
		{
			get{return employee;}
		}

		private YearMonth forMonth;
		public YearMonth ForMonth
		{
			get{return forMonth;}
		}

		private WorkInfoList workInfoList;
		public WorkInfoList WorkInfoList
		{
			get{return workInfoList;}
		}

		private BenefitOTHourList benefitOTHourList;
		public BenefitOTHourList BenefitOTHourList
		{
			get{return benefitOTHourList;}
		}

		private BenefitTaxiList benefitTaxiList;
		public BenefitTaxiList BenefitTaxiList
		{
			get{return benefitTaxiList;}
		}

		private BenefitTaxiList benefitTaxiListForCharge;
		public BenefitTaxiList BenefitTaxiListForCharge
		{
			get{return benefitTaxiListForCharge;}
		}

		private BenefitFoodList benefitFoodList;
		public BenefitFoodList BenefitFoodList
		{
			get{return benefitFoodList;}
		}

		private OtherBenefitRate otherBenefitRate;
		public OtherBenefitRate OtherBenefitRate
		{
			get{return otherBenefitRate;}
			set{otherBenefitRate=value;}
		}

		private EmployeeOneDayTripBenefit oneDayTripBenefit;
		public EmployeeOneDayTripBenefit OneDayTripBenefit
		{
			get{return oneDayTripBenefit;}
			set{oneDayTripBenefit = value;}
		}

		private BenefitOvernightTripForMonth overnightTripBenefit;
		public BenefitOvernightTripForMonth OvernightTripBenefit
		{
			get{return overnightTripBenefit;}
			set{overnightTripBenefit = value;}
		}

		//==============================  Constructor  ==============================
		public EmployeeBenefit(Employee value, DateTime forMonth) :  base()
		{
			employee = value;
			this.forMonth = new YearMonth(forMonth);

			workInfoList = new WorkInfoList(value, this.ForMonth);
			benefitOTHourList = new BenefitOTHourList(value, this.ForMonth);
			benefitTaxiList = new BenefitTaxiList(value, this.ForMonth);
			benefitTaxiListForCharge = new BenefitTaxiList(value, this.ForMonth);
			benefitFoodList = new BenefitFoodList(value, this.ForMonth);

			otherBenefitRate = new OtherBenefitRate();

			oneDayTripBenefit = new EmployeeOneDayTripBenefit(value, this.ForMonth);
			overnightTripBenefit = new BenefitOvernightTripForMonth(value, forMonth);
		}

        public override string EntityKey
        {
            get { return employee.EntityKey; }
        }
    }
}