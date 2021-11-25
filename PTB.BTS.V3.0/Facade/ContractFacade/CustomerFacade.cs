using System;
using System.Data;
using System.Collections;

using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.AttendanceEntities;

using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;
using PTB.BTS.Contract.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

namespace Facade.ContractFacade
{
	public class CustomerFacade : CommonPIFacadeBase
	{
		#region - Private -
		private CustomerFlow flowCustomer;
		private bool disposed = false;
		#endregion

		//		============================== Property ==============================
		private CustomerList objCustomerList;
		public CustomerList ObjCustomerList
		{
			get
			{
				return objCustomerList;
			}
		}

		public ArrayList DataSourceCustomerGroup
		{
			get
			{
				CustomerGroupFlow flowCustomerGroup = new CustomerGroupFlow();
				CustomerGroupList CustomerGroupList = new CustomerGroupList(GetCompany());
				flowCustomerGroup.FillMTBData(CustomerGroupList);
				return CustomerGroupList.GetArrayList();			
			}
		}
		public ArrayList DataSourceCustomerContractGroup
		{
			get
			{
				CustomerContractGroupFlow flowCustomerContractGroup = new CustomerContractGroupFlow();
				CustomerContractGroupList CustomerContractGroupList = new CustomerContractGroupList(GetCompany());
				flowCustomerContractGroup.FillMTBData(CustomerContractGroupList);
				return CustomerContractGroupList.GetArrayList();			
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

		//		============================== Constructor ===============================
		public CustomerFacade()
		{
			flowCustomer = new CustomerFlow();
		}

		//		============================= Public Method ==============================
		public bool DisplayCustomer()
		{
			Customer aCustomer = new Customer();
            aCustomer.Code = Customer.DUMMYCODE;
			objCustomerList = new CustomerList(GetCompany());
			if(flowCustomer.FillCustomer(ref objCustomerList))
			{
				objCustomerList.Remove(aCustomer);
				return true;
			}
			else
				return false;
		}

		public bool InsertCustomer(Customer aCustomer)
		{
			if (objCustomerList.Contain(aCustomer))
			{
				throw new DuplicateException("");
			}
			else
			{
				if(flowCustomer.InsertCustomer(ref objCustomerList, aCustomer))
				{
					StreetFlow flowStreet = new StreetFlow();
					flowStreet.UpdateMTB(aCustomer.ACurrentAddress.StreetName);

					SubDistrictFlow flowSubDistrict = new SubDistrictFlow();
					flowSubDistrict.UpdateMTB(aCustomer.ACurrentAddress.Tambon);

					DistrictFlow flowDistrict = new DistrictFlow();
					flowDistrict.UpdateMTB(aCustomer.ACurrentAddress.District);

					ProvinceFlow flowProvince = new ProvinceFlow();
					flowProvince.UpdateMTB(aCustomer.ACurrentAddress.Province);
				} 
				return true;
			}
		
		}

		public bool UpdateCustomer(Customer aCustomer)
		{
			if(flowCustomer.UpdateCustomer(ref objCustomerList, aCustomer))
			{
				SubDistrictFlow flowSubDistrict = new SubDistrictFlow();
				flowSubDistrict.UpdateMTB(aCustomer.ACurrentAddress.Tambon);

				DistrictFlow flowDistrict = new DistrictFlow();
				flowDistrict.UpdateMTB(aCustomer.ACurrentAddress.District);

				ProvinceFlow flowProvince = new ProvinceFlow();
				flowProvince.UpdateMTB(aCustomer.ACurrentAddress.Province);
			}
			return true;

		}
		public bool DeleteCustomer(Customer aCustomer)
		{	
			return flowCustomer.DeleteCustomer(ref objCustomerList, aCustomer);
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
