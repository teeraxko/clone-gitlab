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
	public class VendorFacade : CommonPIFacadeBase
	{	
		#region - Private -
		private VendorFlow flowVendor;
		private bool disposed = false;
		#endregion

		//		============================== Property ==============================
		private VendorList objVendorList;
		public VendorList ObjVendorList
		{
			get
			{
				return objVendorList;
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
                ictus.Common.Entity.DistrictList districtList = new ictus.Common.Entity.DistrictList();
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
		public VendorFacade()
		{
			flowVendor = new VendorFlow();
		}

		//		============================== Public Method ==============================
		public bool DisplayVendor()
		{
			objVendorList = new VendorList(GetCompany());
			return flowVendor.FillVendorList(ref objVendorList);
		}

		public bool InsertVendor(Vendor value)
		{
			if (objVendorList.Contain(value))
			{
				throw new DuplicateException("VendorFacade");
			}
			else
			{
				if (flowVendor.InsertVendor(value, objVendorList.Company))
				{
					objVendorList.Add(value);

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
		public bool UpdateVendor(Vendor value)
		{
			if (flowVendor.UpdateVendor(value, objVendorList.Company))
			{
				StreetFlow flowStreet = new StreetFlow();
				flowStreet.UpdateMTB(value.ACurrentAddress.StreetName);

				SubDistrictFlow flowSubDistrict = new SubDistrictFlow();
				flowSubDistrict.UpdateMTB(value.ACurrentAddress.Tambon);

				DistrictFlow flowDistrict = new DistrictFlow();
				flowDistrict.UpdateMTB(value.ACurrentAddress.District);

				ProvinceFlow flowProvince = new ProvinceFlow();
				flowProvince.UpdateMTB(value.ACurrentAddress.Province);

				objVendorList[value.EntityKey] = value;
				return true;
			}
			else
			{
				return false;
			}

		}
		public bool DeleteVendor(Vendor value)
		{	
			if(flowVendor.DeleteVendor(value, objVendorList.Company))
			{
				objVendorList.Remove(value);
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
