using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.ContractEntities
{
	public class ServiceStaff : Employee, IKey
	{
//		============================== Property ==============================
		private ServiceStaffType aServiceStaffType;
		public ServiceStaffType AServiceStaffType
		{
			get
			{return aServiceStaffType;}
			set
			{aServiceStaffType = value;}
		}

		protected ContractBase aCurrentContract;
		public ServiceStaffContract ACurrentContract
		{
			get
			{return (ServiceStaffContract)aCurrentContract;}
			set
			{aCurrentContract = value;}
		}

//		============================== Constructor ==============================
		public ServiceStaff(ictus.Common.Entity.Company value) : base(value)
		{
		}

        public ServiceStaff(string serviceStaffNo, ictus.Common.Entity.Company aCompany)
            : base(serviceStaffNo, aCompany)
		{
		}

		public ServiceStaff(Employee value) : base(value.Company)
		{
			this.EmployeeNo = value.EmployeeNo;
            this.AName = value.AName;

			this.APosition = value.APosition;
            this.APrefix = value.APrefix;
			this.ASection = value.ASection;
            this.ASurname = value.ASurname;
            this.AWorkingStatus = value.AWorkingStatus;
			this.BirthDate = value.BirthDate;
			this.Gender = value.Gender;
			this.HireDate = value.HireDate;
		}

		public new string EntityKey
		{
			get
			{return employeeNo;}
		}
	}
}
