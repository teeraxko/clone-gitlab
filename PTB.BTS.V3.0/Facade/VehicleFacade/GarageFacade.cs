using System;
using System.Data;
using System.Collections;

using SystemFramework.AppException;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using PTB.BTS.Common.Flow;
using PTB.BTS.Vehicle.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using ictus.Common.Entity;

namespace Facade.VehicleFacade 
{
	public class GarageFacade : CommonPIFacadeBase
	{	
		#region - Private -
		private GarageFlow flowGarage;
		private bool disposed = false;
		#endregion

		//		============================== Property ==============================
		private GarageList objGarageList;
		public GarageList ObjGarageList
		{
			get
			{
				return objGarageList;
			}
		}
		public ArrayList DataSourceStreet
		{
			get
			{
				StreetFlow flowStreet = new StreetFlow();
				StreetList streetList = new StreetList();
				flowStreet.FillMTBList(streetList);
				return streetList.GetArrayList();
			}
		}
		public ArrayList DataSourceSubDistrict
		{
			get
			{
				SubDistrictFlow flowSubDistrict = new SubDistrictFlow();
				SubDistrictList subDistrictList = new SubDistrictList();
				flowSubDistrict.FillMTBList(subDistrictList);
				return subDistrictList.GetArrayList();
			}
		}

		public ArrayList DataSourceDistrict
		{
			get
			{
				DistrictFlow flowDistrict = new DistrictFlow();
				DistrictList districtList = new DistrictList();
				flowDistrict.FillMTBList(districtList);
				return districtList.GetArrayList();
			}
		}
		
		public ArrayList DataSourceProvince
		{
			get
			{
				ProvinceFlow flowProvince = new ProvinceFlow();
				ProvinceList provinceList = new ProvinceList();
				flowProvince.FillMTBList(provinceList);
				return provinceList.GetArrayList();
			}
		}

		//		============================== Constructor ==============================
		public GarageFacade()
		{
			flowGarage = new GarageFlow();
		}

		//		============================== Public Method ==============================
		public bool DisplayGarage()
		{
			objGarageList = new GarageList(GetCompany());
			return flowGarage.FillGarageList(ref objGarageList);
		}

		public bool InsertGarage(Garage value)
		{
			if (objGarageList.Contain(value))
			{
				throw new DuplicateException("GarageFacade");
			}
			else
			{
				if (flowGarage.InsertGarage(value, objGarageList.Company))
				{
					objGarageList.Add(value);

					StreetFlow flowStreet = new StreetFlow();
					flowStreet.UpdateMTB(value.ACurrentAddress.StreetName);

					SubDistrictFlow flowSubDistrict = new SubDistrictFlow();
					flowSubDistrict.UpdateMTB(value.ACurrentAddress.Tambon);

					DistrictFlow flowDistrict = new DistrictFlow();
					flowDistrict.UpdateMTB(value.ACurrentAddress.District);

					ProvinceFlow flowProvince = new ProvinceFlow();
					flowProvince.UpdateMTB(value.ACurrentAddress.Province);

					return true;
				}
				else
				{
					return false;
				}
			}			
		}
		public bool UpdateGarage(Garage value)
		{
			if (flowGarage.UpdateGarage(value, objGarageList.Company))
			{
				StreetFlow flowStreet = new StreetFlow();
				flowStreet.UpdateMTB(value.ACurrentAddress.StreetName);

				SubDistrictFlow flowSubDistrict = new SubDistrictFlow();
				flowSubDistrict.UpdateMTB(value.ACurrentAddress.Tambon);

				DistrictFlow flowDistrict = new DistrictFlow();
				flowDistrict.UpdateMTB(value.ACurrentAddress.District);

				ProvinceFlow flowProvince = new ProvinceFlow();
				flowProvince.UpdateMTB(value.ACurrentAddress.Province);

				objGarageList[value.EntityKey] = value;
				return true;
			}
			else
			{
				return false;
			}

		}
		public bool DeleteGarage(Garage value)
		{	
			if(flowGarage.DeleteGarage(value, objGarageList.Company))
			{
				objGarageList.Remove(value);
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
