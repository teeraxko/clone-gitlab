using System;
using System.Collections;
using System.Data;

using Entity.VehicleEntities;

using PTB.BTS.Vehicle.Flow;

using Facade.CommonFacade;
using Facade.PiFacade;

using SystemFramework.AppException;

namespace Facade.VehicleFacade
{
	public class ModelFacade : CommonPIFacadeBase
	{
		#region - Private -
		private ModelFlow flowModel;		
		#endregion
		
//		============================== Property ==============================
		private ModelList objModelList;
		public ModelList AModelList
		{
			get{return objModelList;}
		}

//		============================== DataSource ==============================
		public ArrayList DataSourceModelType
		{
			get
			{
				ModelTypeFlow flowModelType = new ModelTypeFlow();
				ModelTypeList modelTypeList = new ModelTypeList();
				flowModelType.FillMTBList(modelTypeList);
				flowModelType = null;
				return modelTypeList.GetArrayList();
			}
		}

		public string[] DataSourceGearType
		{
			get
			{
				CTFunction ctFunction = new CTFunction();
				return ctFunction.GearTypeArray;
			}
		}
		public string[] DataSourceBreakType
		{
			get
			{
				CTFunction ctFunction = new CTFunction();
				return ctFunction.BreakTypeArray;
			}
		}
		public ArrayList DataSourceGasolineType
		{
			get
			{
				GasolineTypeFlow flowGasolineType = new GasolineTypeFlow();
				GasolineTypeList gasolineTypeList = new GasolineTypeList();
				flowGasolineType.FillMTBList(gasolineTypeList);
				flowGasolineType = null;
				return gasolineTypeList.GetArrayList();
			}
		}

		public ArrayList DataSourceBrand
		{
			get
			{
				BrandFlow flowBrand = new BrandFlow();
				BrandList brandList = new BrandList();
				flowBrand.FillMTBList(brandList);
				flowBrand = null;
				return brandList.GetArrayList();
			}
		}

        public ArrayList DataSourceVendor
        {
            get
            {
                VendorFlow flowVendor = new VendorFlow();
                VendorList vendorList = new VendorList(GetCompany());
                vendorList.Add("", new Vendor());
                flowVendor.FillVendorList(ref vendorList);
                flowVendor = null;
                return vendorList.GetArrayList();
            }
        }

//		============================== Constructor ==============================
		public ModelFacade()
		{
			flowModel = new ModelFlow();	
		}

//		============================== Public Method ==============================
		public bool DisplayModel(string brandCode)
		{
			objModelList = new ModelList();
			BrandFlow flowBrand = new BrandFlow();
			objModelList.ABrand = flowBrand.GetBrand(brandCode);
			return flowModel.FillModel(ref objModelList);
		}

        public Vendor GetSpecificVendor(Model model)
        {
            return flowModel.GetSpecificVendor(model, GetCompany());
        }

		public bool InsertModel(Model aModel, Vendor vendor)
		{
			if (objModelList.Contain(aModel))
			{
				throw new DuplicateException("ModelFacade");
			}
			else
			{
                if (flowModel.InsertModel(aModel, vendor))
				{
					objModelList.Add(aModel);
					return true;
				}
				else
				{
					return false;
				}
			}
		}

        public bool UpdateModel(Model aModel, Vendor vendor)
		{
            if (flowModel.UpdateModel(aModel, vendor))
			{
				objModelList[aModel.EntityKey] = aModel;
				return true;
			}
			else
			{
				return false;
			}
		
		}

		public bool DeleteModel(Model aModel)
		{
			if(flowModel.DeleteModel(aModel))
			{
				objModelList.Remove(aModel);
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
