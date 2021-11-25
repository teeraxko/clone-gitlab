using System;
using System.Data;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

using SystemFramework.AppException;

namespace Facade.PiFacade
{
	public class DepartmentFacade : CommonPIFacadeBase
	{
		#region - Private -
		private DepartmentFlow flowDepartment;
		private bool disposed = false;
		#endregion

		//		============================== Property ==============================
		private DepartmentList objDepartmentList;
		public DepartmentList ObjDepartmentList
		{
			get
			{
				return objDepartmentList;
			}
		}

		//		============================== Constructor ==============================
		public DepartmentFacade()
		{
			flowDepartment = new DepartmentFlow();
		}

		//		============================== Public Method ==============================
		public bool DisplayDepartment()
		{
			objDepartmentList = new DepartmentList(GetCompany());
			return flowDepartment.FillDepartment(ref objDepartmentList);
		}

		public bool InsertDepartment(Department aDepartment)
		{
			if (objDepartmentList.Contain(aDepartment))
			{
				throw new DuplicateException("");
			}
			else
			{
				return flowDepartment.InsertDepartment(ref objDepartmentList, aDepartment);
			}
		}
		public bool UpdateDepartment(Department aDepartment)
		{
			return flowDepartment.UpdateDepartment(ref objDepartmentList, aDepartment);
		}

		public bool DeleteDepartment(Department aDepartment)
		{
			return flowDepartment.DeleteDepartment(ref objDepartmentList, aDepartment);
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						flowDepartment.Dispose();
						objDepartmentList.Dispose();

						flowDepartment = null;
						objDepartmentList = null;
						
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion

	}
}
