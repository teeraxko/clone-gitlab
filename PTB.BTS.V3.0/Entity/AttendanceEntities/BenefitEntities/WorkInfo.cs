using System;

using Entity.ContractEntities;
using Entity.CommonEntity;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class WorkInfo : BenefitBase
	{
		//============================== Property ==============================
		private WORKINGDAY_TYPE dayType = WORKINGDAY_TYPE.NULL;
		public WORKINGDAY_TYPE DayType
		{
			get{return dayType;}	
		}

		private TimePeriod workingTime;
		public TimePeriod WorkingTime
		{
			get{return workingTime;}	
		}

		private TimePeriod breakTime;
		public TimePeriod BreakTime
		{
			get{return breakTime;}	
		}

		private ServiceStaffType assignServiceStaffType;
		public ServiceStaffType AssignServiceStaffType
		{
			get{return assignServiceStaffType;}
			set{assignServiceStaffType = value;}
		}

		private Customer assignCustomer;
		public Customer AssignCustomer
		{
			get{return assignCustomer;}
			set{assignCustomer = value;}
		}

		private CustomerDepartment assignCustomerDepartment;
		public CustomerDepartment AssignCustomerDepartment
		{
			get{return assignCustomerDepartment;}
			set{assignCustomerDepartment = value;}
		}

		private ContractBase assignContract;
		public ContractBase AssignContract
		{
			get{return assignContract;}
			set{assignContract = value;}
		}

		private OT_RATE_TYPE otVarientRate;
		public OT_RATE_TYPE OTVarientRate
		{
			get{return otVarientRate;}
			set{otVarientRate = value;}
		}

		private bool validOTStatus = true;
		public bool ValidOTStatus
		{
			get{return validOTStatus;}
			set{validOTStatus = value;}
		}

		private string remark;
		public string Remark
		{
			get{return remark;}
			set{remark = value;}
		}

		private bool validTaxiStatus = true;
		public bool ValidTaxiStatus
		{
			get{return validTaxiStatus;}
			set{validTaxiStatus = value;}
		}

		//============================== Constructor ==============================
		public WorkInfo(WorkSchedule value) : base(value.WorkDate)
		{
			dayType = value.DayType;
			workingTime = value.AWorkingTime;
			breakTime = value.ABreakTime;

			assignServiceStaffType = new ServiceStaffType("ZZZ");
			assignCustomer = new Customer(Customer.DUMMYCODE);
			assignCustomer.ACustomerGroup = new CustomerGroup("ZZ");
			assignCustomerDepartment = new CustomerDepartment("ZZZ", assignCustomer);
		}

		public WorkInfo(DateTime workDate) : base(workDate)
		{
		}

		//============================== Public Method ==============================

	}
}