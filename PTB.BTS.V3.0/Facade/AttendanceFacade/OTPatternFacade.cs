using System;
using System.Data;

using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using PTB.BTS.PI.Flow;
using Flow.AttendanceFlow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;

namespace Facade.AttendanceFacade
{
	public class OTPatternFacade : CommonPIFacadeBase
	{
		#region - Private -
		private OTPatternFlow flowOtPattern;
		private bool disposed = false;
		#endregion
//		============================== Property ==============================
		private OTPatternList objOTPatternList;
		public OTPatternList ObjOTPatternList
		{
			get{return objOTPatternList;}
		}

		public string[] DataSourceOTRate
		{
			get
			{
				CTFunction ctFunction = new CTFunction();
				return ctFunction.OTRateTypeArray;			
			}
		}

		public string[] DataSourceOTPeriod
		{
			get
			{
				CTFunction ctFunction = new CTFunction();
				return ctFunction.PeriodTypeArray;
			}		
		}
//		============================== Constructor ==============================
		public OTPatternFacade() : base()
		{
			flowOtPattern = new OTPatternFlow();		
		}

//		============================== Public Method ==============================

		public bool DisplayOTPattern()
		{
			objOTPatternList = new OTPatternList(GetCompany());
			return flowOtPattern.FillOTPatternList(ref objOTPatternList);
		}

		public bool InsertOTPattern(OTPattern value)
		{
			if (objOTPatternList.Contain(value))
			{
				throw new DuplicateException("OTPatternFacade");
			}

			OTPattern otPattern = new OTPattern();
			otPattern.PatternName = value.PatternName;

			if(flowOtPattern.FillOTPattern(ref otPattern, objOTPatternList.Company))
			{
				throw new DuplicateException("OTPatternFacade");
			}
			else
			{
				if (flowOtPattern.InsertOTPattern(value, objOTPatternList.Company))
				{
					objOTPatternList.Add(value);
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public bool UpdateOTPattern(OTPattern value)
		{
			OTPattern otPattern = new OTPattern();
			otPattern.PatternId = value.PatternId;
			otPattern.PatternName = value.PatternName;

			if(!flowOtPattern.FillOTPattern(ref otPattern, objOTPatternList.Company))
			{
				otPattern = new OTPattern();
				otPattern.PatternName = value.PatternName;

				if(flowOtPattern.FillOTPattern(ref otPattern, objOTPatternList.Company))
				{
					throw new DuplicateException("OTPatternFacade");
				}
			}

			if (flowOtPattern.UpdateOTPattern(value, objOTPatternList.Company))
			{
				objOTPatternList[value.EntityKey] = value;
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool DeleteOTPattern(OTPattern value)
		{
			if (flowOtPattern.DeleteOTPattern(value, objOTPatternList.Company))
			{
				objOTPatternList.Remove(value);
				return true;
			}
			else
			{
				return false;
			}
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
						flowOtPattern.Dispose();
						objOTPatternList.Dispose();

						flowOtPattern = null;
						objOTPatternList = null;
						
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
