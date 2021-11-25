using System;

using Entity.VehicleEntities;
using ictus.PIS.PI.Entity;

using DataAccess.VehicleDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace PTB.BTS.Vehicle.Flow
{
	public class VendorFlow : FlowBase
	{
		#region - Private -	
		private VendorDB dbVendor;
		#endregion
		
//  ================================Constructor=====================
		public VendorFlow():base()
		{
			dbVendor = new VendorDB();
		}
		
//  ================================public Method=====================
		public bool FillVendorList(ref VendorList aVendorList)
		{
			return dbVendor.FillVendorList(ref aVendorList);
		}

        public Vendor GetVendor(string vendorCode, Company company)
        {
            return dbVendor.GetVendor(vendorCode, company);
        }

		public bool InsertVendor(Vendor value, Company aCompany)
		{
			return dbVendor.InsertVendor(value, aCompany);
		}

		public bool UpdateVendor(Vendor value, Company aCompany)
		{
			return dbVendor.UpdateVendor(value, aCompany);
		}

		public bool DeleteVendor(Vendor value, Company aCompany)
		{
			return dbVendor.DeleteVendor(value, aCompany);
		}

	}
}
