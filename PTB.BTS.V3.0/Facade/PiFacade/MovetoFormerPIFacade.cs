using System;
using System.Data;
using System.Collections;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;

namespace Facade.PiFacade
{
	public class MovetoFormerPIFacade: CommonPIFacadeBase
	{
		#region - Private -
		private EmployeeFlow flowEmployee;
		private MovetoFormerPIFlow flowMovetoFormerPI;
		private bool disposed = false;
		#endregion

//		============================== Property ==============================
		private EmployeeList objEmployeeList;
		public EmployeeList ObjEmployeeList
		{
			get{return objEmployeeList;}
		}
//		============================== Constructor ==============================
		public MovetoFormerPIFacade() : base()
		{
			flowEmployee = new EmployeeFlow();	
			flowMovetoFormerPI = new MovetoFormerPIFlow(GetCompany());
		}

//		============================== Public Method ==============================
		
		public bool DisplayEmployeeNotAvailable()
		{
			objEmployeeList  = new EmployeeList(GetCompany());
			return flowEmployee.FillEmployeeNotAvailableList(ref objEmployeeList);
		}
	
		public bool MoveEmployee(EmployeeList value)
		{
			if( flowMovetoFormerPI.MoveEmployee(value))
			{
				for(int i=0; i<value.Count; i++)
				{
					objEmployeeList.Remove(value[i]);
				}

				return true;
			}
			else
				return false;

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
						// Dispose object here.
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
