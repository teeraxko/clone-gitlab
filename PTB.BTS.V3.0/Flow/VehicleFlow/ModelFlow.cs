using System;

using Entity.VehicleEntities;

using DataAccess.VehicleDB;

using PTB.BTS.Common.Flow;
using ictus.Common.Entity;

namespace PTB.BTS.Vehicle.Flow
{
	public class ModelFlow : FlowBase
	{
		#region - Private -	
		private ModelDB dbModel;
		#endregion

        //====================================Constructor================
		public ModelFlow():base()
		{		
			dbModel = new ModelDB();
		}

        //====================================Public Method================
		public bool FillModel(ref ModelList aModelList)
		{
			return dbModel.FillModelList(ref aModelList);
		}

        public Vendor GetSpecificVendor(Model model, Company company)
        {
            return dbModel.GetSpecificVendor(model, company);
        }

		public bool InsertModel(Model aModel, Vendor vendor)
		{
			return dbModel.InsertModel(aModel, vendor);
		}

        public bool UpdateModel(Model aModel, Vendor vendor)
		{
            return dbModel.UpdateModel(aModel, vendor);
		}
		
		public bool DeleteModel(Model aModel)
		{
			return dbModel.DeleteModel(aModel);
		}

        public Model GetModel(string modelCode, string brandCode)
        {
            return dbModel.GetModel(modelCode, brandCode);
        }
	}
}
