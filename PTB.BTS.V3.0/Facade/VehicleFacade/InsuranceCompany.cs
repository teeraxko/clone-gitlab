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
	public class InsuranceCompanyFacade : CommonPIFacadeBase
	{	
		#region - Private -
		private InsuranceCompanyFlow flowInsuranceCompany;
		private bool disposed = false;
		#endregion

		//		============================== Property ==============================
		private InsuranceCompanyList objInsuranceCompanyList;
		public InsuranceCompanyList ObjInsuranceCompanyList
		{
			get
			{
				return objInsuranceCompanyList;
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
		public InsuranceCompanyFacade()
		{
			flowInsuranceCompany = new InsuranceCompanyFlow();
		}

		//		============================== Public Method ==============================
		public bool DisplayInsuranceCompany()
		{
			objInsuranceCompanyList = new InsuranceCompanyList(GetCompany());
			return flowInsuranceCompany.FillInsuranceCompanyList(ref objInsuranceCompanyList);
		}

		public bool InsertInsuranceCompany(InsuranceCompany value)
		{
			if (objInsuranceCompanyList.Contain(value))
			{
				throw new DuplicateException("InsuranceCompanyFacade");
			}
			else
			{
				if (flowInsuranceCompany.InsertInsuranceCompany(value, objInsuranceCompanyList.Company))
				{
					objInsuranceCompanyList.Add(value);

					StreetFlow flowStreet = new StreetFlow();
					flowStreet.UpdateMTB(value.AAddress.StreetName);

					SubDistrictFlow flowSubDistrict = new SubDistrictFlow();
					flowSubDistrict.UpdateMTB(value.AAddress.Tambon);

					DistrictFlow flowDistrict = new DistrictFlow();
					flowDistrict.UpdateMTB(value.AAddress.District);

					ProvinceFlow flowProvince = new ProvinceFlow();
					flowProvince.UpdateMTB(value.AAddress.Province);

					return true;
				}
				else
				{
					return false;
				}
			}			
		}
		public bool UpdateInsuranceCompany(InsuranceCompany value)
		{
			if (flowInsuranceCompany.UpdateInsuranceCompany(value, objInsuranceCompanyList.Company))
			{
				StreetFlow flowStreet = new StreetFlow();
				flowStreet.UpdateMTB(value.AAddress.StreetName);

				SubDistrictFlow flowSubDistrict = new SubDistrictFlow();
				flowSubDistrict.UpdateMTB(value.AAddress.Tambon);

				DistrictFlow flowDistrict = new DistrictFlow();
				flowDistrict.UpdateMTB(value.AAddress.District);

				ProvinceFlow flowProvince = new ProvinceFlow();
				flowProvince.UpdateMTB(value.AAddress.Province);

				objInsuranceCompanyList[value.EntityKey] = value;
				return true;
			}
			else
			{
				return false;
			}

		}
		public bool DeleteInsuranceCompany(InsuranceCompany value)
		{	
			if(flowInsuranceCompany.DeleteInsuranceCompany(value, objInsuranceCompanyList.Company))
			{
				objInsuranceCompanyList.Remove(value);
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
