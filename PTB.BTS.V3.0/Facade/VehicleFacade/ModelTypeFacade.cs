using System;

using Entity.VehicleEntities;

using PTB.BTS.Vehicle.Flow;

using Facade.CommonFacade;
using System.Collections;

namespace Facade.VehicleFacade
{
	public class ModelTypeFacade : MTBFacadeBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================



		//		============================== Constructor ==============================
		public ModelTypeFacade() : base()
		{			
			objList = new ModelTypeList();
		}
		//		============================== Private Method ===========================

		//		============================== Public Method ============================

        /// <summary>
        /// Data source for contract attachment only √∂‡°Îß ·≈–√∂°√–∫–
        /// </summary>
        public ArrayList ContractAttachmentModelTypeDataSourceName
        {
            get
            {                
                ModelTypeList modeltypeListTemp = new ModelTypeList();
                flowMTB = new ModelTypeFlow();
                flowMTB.FillMTBList(modeltypeListTemp);                               
                string[] keyList = new string[] { "1", "2" };
                if (modeltypeListTemp != null)
                {
                    for (int i = 0; i < modeltypeListTemp.Count; i++)
                    {
                        if (Array.Exists(keyList, e => e == ((ModelType)modeltypeListTemp.BaseGet(i)).EntityKey))
                        {
                            objList.Add((ModelType)modeltypeListTemp.BaseGet(i));
                        }
                    }
                }
                flowMTB = null;
                return objList.GetArrayList();
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
