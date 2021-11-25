using System;

using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;

using Facade.PiFacade;

using Entity.CommonEntity;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace Facade.AttendanceFacade
{
	public class EmployeeHeadFacadeBase : CommonPIFacadeBase
	{
		#region - Private -
		private EmployeeFlow flowEmployee;
		#endregion

//		============================== Property ==============================
		protected Employee objEmployee;
		public Employee	ObjEmployee
		{
			get{return objEmployee;}
			set{objEmployee = value;}
		}

//		============================== Constructor ==============================
		public EmployeeHeadFacadeBase() : base()
		{
			objEmployee = new Employee(GetCompany());
			flowEmployee = new EmployeeFlow();
		}

//		============================== Public Method ==============================
		public YearMonth CalculateAge(DateTime birthDate)
		{
			AgeFlow flowAge = new AgeFlow();
			return flowAge.CalculateAge(birthDate);
		}

		public bool DisplayEmployee(string employeeNo)
		{
			objEmployee.EmployeeNo = employeeNo;
			return flowEmployee.FillAvailableEmployee(objEmployee, DateTime.Today);
		}
	}
}
