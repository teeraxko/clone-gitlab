using System;
using System.Collections;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.AttendanceEntities;

using PTB.BTS.PI.Flow;
using Flow.AttendanceFlow;
using PTB.BTS.Contract.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

namespace Facade.AttendanceFacade
{
	public class WorkingTimeConditionSpecificFacade : CommonPIFacadeBase
	{
		#region - Private -
		private WorkingTimeConditionSpecificFlow flowWorkingTimeConditionSpecific;
		private bool disposed = false;
		#endregion

//		============================== Property ==============================
		private WorkingTimeConditionSpecificList objWorkingTimeConditionSpecificList;
		public WorkingTimeConditionSpecificList ObjWorkingTimeConditionSpecificList
		{
			get{return objWorkingTimeConditionSpecificList;}
			set{objWorkingTimeConditionSpecificList = value;}
		}

		public ArrayList DataSourceWorkingTimeTable
		{
			get
			{
				WorkingTimeTableFlow flowWorkingTimeTable = new WorkingTimeTableFlow();
				WorkingTimeTableList workingTimeTableList = new WorkingTimeTableList(GetCompany());
				flowWorkingTimeTable.FillWorkingTimeTableList(ref workingTimeTableList);
				flowWorkingTimeTable = null;
				return workingTimeTableList.GetArrayList();			
			}
		}
		
//		============================== Constructor ==============================
		public WorkingTimeConditionSpecificFacade() : base()
		{
			flowWorkingTimeConditionSpecific = new WorkingTimeConditionSpecificFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayWorkingTimeConditionSpecific()
		{
			objWorkingTimeConditionSpecificList = new WorkingTimeConditionSpecificList(GetCompany());
			return flowWorkingTimeConditionSpecific.FillWorkingTimeConditionSpecificList(ref objWorkingTimeConditionSpecificList);		
		}

		public bool InsertWorkingTimeConditionSpecific(WorkingTimeConditionSpecific value)
		{	
			if (objWorkingTimeConditionSpecificList.Contain(value))
			{
				throw new DuplicateException("WorkingTimeConditionSpecificFacade");
			}
			else
			{
				if(flowWorkingTimeConditionSpecific.InsertWorkingTimeConditionSpecific(value))
				{
					objWorkingTimeConditionSpecificList.Add(value);
					return true;
				}
				else
				{return false;}
			}		
		}

		public bool UpdateWorkingTimeConditionSpecific(WorkingTimeConditionSpecific value)
		{
			if(flowWorkingTimeConditionSpecific.UpdateWorkingTimeConditionSpecific(value))
			{
				objWorkingTimeConditionSpecificList[value.EntityKey] = value;
				return true;
			}
			return false;
		}

		public bool DeleteWorkingTimeConditionSpecific(WorkingTimeConditionSpecific value)
		{
			if(flowWorkingTimeConditionSpecific.DeleteWorkingTimeConditionSpecific(value))
			{
				objWorkingTimeConditionSpecificList.Remove(value);
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
						flowWorkingTimeConditionSpecific.Dispose();
						objWorkingTimeConditionSpecificList.Dispose();

						flowWorkingTimeConditionSpecific = null;
						objWorkingTimeConditionSpecificList = null;
						
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
