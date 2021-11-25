using System;
using System.Collections;
using Entity.VehicleEntities;

using PTB.BTS.Vehicle.Flow;

using Facade.PiFacade;

namespace Facade.VehicleFacade
{
	public class SparePartsFacade : MTBCompanyFacadeBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================
		//      ===============================Datasource ===============================
		public ArrayList DataSourceSpareParts
		{
			get
			{
				SparePartsFlow flowSpareParts= new SparePartsFlow();
				flowSpareParts.FillMTBList(objList);
				flowSpareParts = null;
				return objList.GetArrayList();
			}
		}

		//		============================== Constructor ==============================
		public  SparePartsFacade() : base()
		{
			flowMTB = new SparePartsFlow();
			objList = new SparePartsList(GetCompany());
		}
		//		============================== Private Method ===========================

		//		============================== Public Method ============================

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
