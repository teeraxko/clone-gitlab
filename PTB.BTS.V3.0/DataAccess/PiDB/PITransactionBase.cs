using System;

using ictus.PIS.PI.Entity;

using DataAccess.CommonDB;

namespace DataAccess.PiDB
{
	public abstract class PITransactionBase : DataAccessBase
	{
//		============================== Property ==============================
		#region - Property Change -
		protected bool employeeChange = false;
		public bool EmployeeChange
		{
			set{employeeChange = value;}
			get{return employeeChange;}
		}
		protected bool employeeParentChange = false;
		public bool EmployeeParentChange
		{
			set{employeeParentChange = value;}
			get{return employeeParentChange;}
		}
		protected bool referencePersonChange = false;
		public bool ReferencePersonChange
		{
			set{referencePersonChange = value;}
			get{return referencePersonChange;}
		}
		protected bool guarantorChange = false;
		public bool GuarantorChange
		{
			set{guarantorChange = value;}
			get{return guarantorChange;}
		}
		protected bool employeeAddressChange = false;
		public bool EmployeeAddressChange
		{
			set{employeeAddressChange = value;}
			get{return employeeAddressChange;}
		}
		protected bool employeeSpouseChange = false;
		public bool EmployeeSpouseChange
		{
			set{employeeSpouseChange = value;}
			get{return employeeSpouseChange;}
		}
		protected bool employeeWorkBackgroundChange = false;
		public bool EmployeeWorkBackgroundChange
		{
			set{employeeWorkBackgroundChange = value;}
			get{return employeeWorkBackgroundChange;}
		}
		protected bool employeeChildrenListChange = false;
		public bool EmployeeChildrenListChange
		{
			set{employeeChildrenListChange = value;}
			get{return employeeChildrenListChange;}
		}
		protected bool employeeEducationChange = false;
		public bool EmployeeEducationChange
		{
			set{employeeEducationChange = value;}
			get{return employeeEducationChange;}
		}
		protected bool salaryChange = false;
		public bool SalaryChange
		{
			set{salaryChange = value;}
			get{return salaryChange;}
		}
		protected bool employeeSpecialAllowanceChange = false;
		public bool EmployeeSpecialAllowanceChange
		{
			set{employeeSpecialAllowanceChange = value;}
			get{return employeeSpecialAllowanceChange;}
		}
		#endregion

		#region - Property -
		protected EmployeeInfo aEmployeeInfo;
		public EmployeeInfo AEmployeeInfo
		{
			get{return aEmployeeInfo;}
			set{aEmployeeInfo = value;}
		}

		protected EmployeeFather aEmployeeFather;
		public EmployeeFather AEmployeeFather
		{
			get{return aEmployeeFather;}
			set{aEmployeeFather = value;}
		}
		protected EmployeeMother aEmployeeMother;
		public EmployeeMother AEmployeeMother
		{
			get{return aEmployeeMother;}
			set{aEmployeeMother = value;}
		}
		protected ReferencePerson aReferencePerson;
		public ReferencePerson AReferencePerson
		{
			get{return aReferencePerson;}
			set{aReferencePerson=value;}
		}
		protected ReferencePerson aGuarantor;
		public ReferencePerson AGuarantor
		{
			get{return aGuarantor;}
			set{aGuarantor=value;}
		}
		protected EmployeeAddress aEmployeeAddress;
		public EmployeeAddress AEmployeeAddress
		{
			get{return aEmployeeAddress;}
			set{aEmployeeAddress=value;}
		}
		protected EmployeeSpouse aEmployeeSpouse;
		public EmployeeSpouse AEmployeeSpouse
		{
			get{return aEmployeeSpouse;}
			set{aEmployeeSpouse = value;}
		}
		protected EmployeeWorkBackground aEmployeeWorkBackground;
		public EmployeeWorkBackground AEmployeeWorkBackground
		{
			get{return aEmployeeWorkBackground;}	
			set{aEmployeeWorkBackground = value;}
		}
		protected EmployeeChildrenList aEmployeeChildrenList;
		public EmployeeChildrenList AEmployeeChildrenList
		{
			get{return aEmployeeChildrenList;}	
			set{aEmployeeChildrenList = value;}
		}
		protected EmployeeEducation aEmployeeEducation;
		public EmployeeEducation AEmployeeEducation
		{
			get{return aEmployeeEducation;}	
			set{aEmployeeEducation = value;}
		}
		protected Salary aSalary;
		public Salary ASalary
		{
			get{return aSalary;}
			set{aSalary = value;}
		}
		protected EmployeeSpecialAllowance aEmployeeSpecialAllowance;
		public EmployeeSpecialAllowance AEmployeeSpecialAllowance
		{
			get{return aEmployeeSpecialAllowance;}	
			set{aEmployeeSpecialAllowance = value;}
		}
		#endregion

//		============================== Constructor ==============================
		protected PITransactionBase() : base()
		{
		}

//		============================== Public Method ==============================
        public void ReNew(ictus.Common.Entity.Company value)
		{
			aEmployeeInfo = new EmployeeInfo(value);
			aEmployeeAddress = new EmployeeAddress();
			aEmployeeAddress.AEmployee = aEmployeeInfo;
			aEmployeeFather = new EmployeeFather();
			aEmployeeFather.AEmployee = aEmployeeInfo;
			aEmployeeMother = new EmployeeMother();
			aEmployeeMother.AEmployee = aEmployeeInfo;
			aReferencePerson = new ReferencePerson();
			aGuarantor = new ReferencePerson();
			aEmployeeSpouse = new EmployeeSpouse();
			aEmployeeSpouse.AEmployee = aEmployeeInfo;
			aSalary = new Salary();
			aEmployeeEducation = new EmployeeEducation(aEmployeeInfo);
			aEmployeeWorkBackground = new EmployeeWorkBackground(aEmployeeInfo);
			aEmployeeChildrenList = new EmployeeChildrenList(aEmployeeInfo);
			aEmployeeSpecialAllowance = new EmployeeSpecialAllowance(aEmployeeInfo);
		}

		public void changeAll(bool change)
		{
			employeeChange = change;
			employeeAddressChange = change;
			employeeParentChange = change;
			referencePersonChange = change;
			guarantorChange = change;
			employeeSpouseChange = change;
			employeeEducationChange = change;
			employeeWorkBackgroundChange = change;
			employeeChildrenListChange = change;
			employeeSpecialAllowanceChange = change;
		}

		public abstract bool FillList();
		public abstract void FillList(Employee value);
		public abstract bool InsertTransaction(TableAccess tableAccess);
		public abstract bool UpdateTransaction(TableAccess tableAccess);
		public abstract bool DeleteTransaction(TableAccess tableAccess);
	}
}