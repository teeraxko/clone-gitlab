using System;
using System.Data;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;

namespace Facade.PiFacade
{
	public class FormerEmployeeFacade : CommonPIFacadeBase
	{
		#region - Private -
		private FormerEmployeeFlow flowFormerEmployee;
		#endregion

//		============================== Property ==============================
		private EmployeeList objEmployeeList;
		public EmployeeList ObjEmployeeList
		{
			get
			{
				return objEmployeeList;
			}
		}
//		============================== Constructor ==============================
		public FormerEmployeeFacade()
		{
			flowFormerEmployee = new FormerEmployeeFlow();
		}
//		============================== Public Method ==============================
		public bool DisplayFormerEmployee()
		{
			objEmployeeList = new EmployeeList(GetCompany());
			return flowFormerEmployee.FillFormerEmployee(objEmployeeList);
		}

	}
}
