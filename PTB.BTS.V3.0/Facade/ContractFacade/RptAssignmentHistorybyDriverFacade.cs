using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;

using Facade.PiFacade;

namespace Facade.ContractFacade
{
	public class RptAssignmentHistorybyDriverFacade : CommonPIFacadeBase
	{
		#region - Private -
		protected EmployeeFlow flowEmployee;
		#endregion

//		==============================  Constructor  ==============================
		public RptAssignmentHistorybyDriverFacade() : base()
		{
			flowEmployee = new EmployeeFlow();
		}

//		============================== Public Method ==============================
		public Employee GetAllEmployee(string employeeNo)
		{
			Employee objEmployee = new Employee(GetCompany());
			objEmployee.EmployeeNo = employeeNo;

			if (flowEmployee.FillAllEmployee(ref objEmployee))
			{
				return objEmployee;
			}
			else
			{
				objEmployee = null;
				return null;
			}
		}
	}
}
