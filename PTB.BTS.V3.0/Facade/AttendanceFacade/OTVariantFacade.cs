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
	public class OTVariantFacade : CommonPIFacadeBase
	{
		#region - Private -
			private OTVariantFlow flowOTVariant;
			private bool disposed = false;
		#endregion

//		============================== Property ==============================
		private OTVariantList objOTVariantList;
		public OTVariantList ObjOTVariantList
		{
			get
			{return objOTVariantList;}
		}

//		============================== Constructor ==============================
		public OTVariantFacade()
		{
			flowOTVariant = new OTVariantFlow();			
		}

//		============================== Public Method ==============================
		public bool DisplayOTVariant()
		{
			objOTVariantList = new OTVariantList(GetCompany());
			return flowOTVariant.FillOTVariantList(ref objOTVariantList);
		}

		public bool InsertOTVariant(OTVariant value)
		{
			if (objOTVariantList.Contain(value))
			{
				throw new DuplicateException("OTVariantFacade");
			}
			else
			{
				if (flowOTVariant.InsertOTVariant(value, objOTVariantList.Company))
				{
					objOTVariantList.Add(value);
					return true;
				}
				else
				{return false;}
			}			
		}

		public bool UpdateOTVariant(OTVariant value)
		{
			if (flowOTVariant.UpdateOTVariant(value, objOTVariantList.Company))
			{
				objOTVariantList[value.EntityKey] = value;
				return true;
			}
			else
			{return false;}
		}

		public bool DeleteOTVariant(OTVariant value)
		{
			if(flowOTVariant.DeleteOTVariant(value, objOTVariantList.Company))
			{
				objOTVariantList.Remove(value);
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
						flowOTVariant.Dispose();
						objOTVariantList.Dispose();

						flowOTVariant = null;
						objOTVariantList = null;
						
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
