using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;

using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class EmployeeAttendanceFacadeBase : CommonPIFacadeBase
	{
		#region - Private -
			protected EmployeeFlow flowEmployee;
			private AgeFlow flowAge;
		#endregion
		
		#region - Property -
			protected Employee employee;
			public Employee	Employee
			{
				get{return employee;}
				set{employee = value;}
			}

			public bool ExistingEmployee
			{
				get
				{
					return (employee!=null && employee.EmployeeNo!="");
				}
			}
		#endregion

		//==============================  Constructor  ==============================
		public EmployeeAttendanceFacadeBase() : base()
		{
			flowEmployee = new EmployeeFlow();
			flowAge = new AgeFlow();
			employee = new Employee(GetCompany());
		}

		//============================== Public Method ==============================
		public virtual bool DisplayEmployee(string employeeNo)
		{
			employee.EmployeeNo = employeeNo;
			bool result = flowEmployee.FillAllEmployee(ref employee);
			if(!result)
			{
				employee = null;
			}
			return result;
		}

		public YearMonth CalculateAge(DateTime value)
		{
			return flowAge.CalculateAge(value);
		}
	}
}