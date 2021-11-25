using System;
using System.Collections;
using System.Data;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using PTB.BTS.PI.Flow;
using Flow.AttendanceFlow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class TraditionalHolidayFacade : CommonPIFacadeBase
	{
		#region - Private -
		private TraditionalHolidayFlow flowTraditonalHolidayFlow;
		private bool disposed = false;
		#endregion
		
//		============================== Property ==============================
		private TraditionalHolidayList objTraditionalHolidayList;
		public TraditionalHolidayList ObjTraditionalHolidayList
		{
			get{return objTraditionalHolidayList;}
		}

		public ArrayList DataSourceTraditionalHolidayPattern
		{
			get
			{
				TraditionalHolidayPatternFlow flowTraditionalHolidayPattern = new TraditionalHolidayPatternFlow();
				TraditionalHolidayPatternList traditionalHolidayPatternList = new TraditionalHolidayPatternList(GetCompany());
				flowTraditionalHolidayPattern.FillMTBData(traditionalHolidayPatternList);
				return traditionalHolidayPatternList.GetArrayList();			
			}
		}

//		============================== Constructor ==============================
		public TraditionalHolidayFacade() : base()
		{
			flowTraditonalHolidayFlow = new TraditionalHolidayFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayTraditionalHoliday(TraditionalHolidayPattern value, YearMonth yearMonth)
		{			
			objTraditionalHolidayList = new TraditionalHolidayList(GetCompany());
			objTraditionalHolidayList.ATraditionalHolidayPattern = value;
			objTraditionalHolidayList.AYearMonth = yearMonth;

			return flowTraditonalHolidayFlow.FillTraditionalHolidayList(ref objTraditionalHolidayList);		
		}

		public bool FillCheckDupTraditionalHoliday(ref TraditionalHoliday value, TraditionalHolidayPattern aTraditionalHolidayPattern, DateTime dateTime)
		{
			YearMonth yearMonth = new YearMonth(dateTime);
			return flowTraditonalHolidayFlow.FillTraditionalHoliday(ref value, aTraditionalHolidayPattern, yearMonth, objTraditionalHolidayList.Company);
		}

		public bool InsertTraditionalHoliday(TraditionalHoliday value)
		{			
			if (objTraditionalHolidayList.Contain(value))
			{
				throw new DuplicateException("TraditonalHolidayFacade");
			}
			else
			{
				if(flowTraditonalHolidayFlow.InsertTraditionalHoliday(objTraditionalHolidayList, value))
				{
					objTraditionalHolidayList.Add(value);
					return true;
				}
				else
				{return false;}
			}
		}

		public bool UpdateTraditionalHoliday(TraditionalHoliday value)
		{
			if (flowTraditonalHolidayFlow.UpdateTraditionalHoliday(objTraditionalHolidayList, value))
			{
				objTraditionalHolidayList[value.EntityKey] = value;
				return true;
			}
			else
			{return false;}
		}
		
		public bool DeleteTraditionalHoliday(TraditionalHoliday value)
		{
			if(flowTraditonalHolidayFlow.DeleteTraditionalHoliday(objTraditionalHolidayList, value))
			{
				objTraditionalHolidayList.Remove(value);
				return true;
			}
			else
			{return false;}
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
						flowTraditonalHolidayFlow.Dispose();
						objTraditionalHolidayList.Dispose();

						flowTraditonalHolidayFlow = null;
						objTraditionalHolidayList = null;

						
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
