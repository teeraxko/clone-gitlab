using System;
using System.Data;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using PTB.BTS.PI.Flow;
using Flow.AttendanceFlow;

using Facade.PiFacade;
using Facade.CommonFacade;

namespace Facade.AttendanceFacade
{
	public class WorkingTimeTableFacade : CommonPIFacadeBase
	{
		#region  - Private - 
		private WorkingTimeTableFlow flowWorkingTimeTable;
		private bool disposed = false;
		#endregion

//		============================== Property ==============================
		private WorkingTimeTableList objWorkingTimeTableList;
		public WorkingTimeTableList ObjWorkingTimeTableList
		{
			get{return objWorkingTimeTableList;}
			set{objWorkingTimeTableList = value;}
		}

//		============================== Constructor ==============================

		public WorkingTimeTableFacade()
		{
			flowWorkingTimeTable = new WorkingTimeTableFlow();
		}
		
//		============================== Public Method ==============================
		public bool DisplayWorkingTimeTable()
		{
			objWorkingTimeTableList = new WorkingTimeTableList(GetCompany());
			return flowWorkingTimeTable.FillWorkingTimeTableList(ref objWorkingTimeTableList);
		}

		public WorkingTimeTable GetDupDescriptionWorkingTimeTable(string description)
		{
			return flowWorkingTimeTable.GetDupDescriptionWorkingTimeTable(description, objWorkingTimeTableList.Company);
		}

		public bool InsertWorkingTimeTable(WorkingTimeTable value)
		{	
			if (objWorkingTimeTableList.Contain(value))
			{
				throw new DuplicateException("WorkingTimeTableFacade");
			}
			else
			{
				if(flowWorkingTimeTable.InsertWorkingTimeTable(value, objWorkingTimeTableList.Company))
				{
					objWorkingTimeTableList.Add(value);
					return true;
				}
				return false;
			}		
		}

		public bool UpdateWorkingTimeTable(WorkingTimeTable value)
		{
			if(flowWorkingTimeTable.UpdateWorkingTimeTable(value, objWorkingTimeTableList.Company))
			{
				objWorkingTimeTableList[value.EntityKey] = value;
				return true;
			}
			return false;
		}

		public bool DeleteWorkingTimeTable(WorkingTimeTable value)
		{
			if(flowWorkingTimeTable.DeleteWorkingTimeTable(value, objWorkingTimeTableList.Company))
			{
				objWorkingTimeTableList.Remove(value);
				return true;
			}
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
						flowWorkingTimeTable.Dispose();
						objWorkingTimeTableList.Dispose();

						flowWorkingTimeTable = null;
						objWorkingTimeTableList = null;
						
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
