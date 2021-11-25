using System;
using System.Collections.Generic;
using System.Text;

using PTB.BTS.Contract.Flow;
using PTB.BTS.Vehicle.Flow;

using Flow.VehicleFlow.VehicleLeasingFlow;
using Flow.VehicleEntities.Leasing;

using ictus.Common.Entity;
using System.Collections;

using Entity.VehicleEntities.VehicleLeasing;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using Facade.PiFacade;
using Facade.CommonFacade;
using Facade.VehicleFacade.LeasingFacade;

namespace Facade.VehicleFacade.VehicleLeasingFacade
{
    public class VehiclePurchasingFacade : CommonPIFacadeBase
    {
        #region Private variable
        private VehiclePurchasingFlow flowVehiclePurchasing;
        #endregion

        #region Property
        private VehiclePurchasing objVehiclePurchasing;
        private List<VehiclePurchasing> objVehiclePurchasingList;

        public VehiclePurchasing ObjVehiclePurchasing
        {
            get { return objVehiclePurchasing; }
            set { objVehiclePurchasing = value; }
        }

        public List<VehiclePurchasing> ObjVehiclePurchasingList
        {
            get { return objVehiclePurchasingList; }
            set { objVehiclePurchasingList = value; }
        } 
        #endregion

        #region Constructor
        public VehiclePurchasingFacade()
            : base()
        {
            flowVehiclePurchasing = new VehiclePurchasingFlow();
        } 
        #endregion

        public ArrayList DataSourceCustomer
        {
            get
            {
                CustomerList CustomerList = new CustomerList(GetCompany());
                using (CustomerFlow flowCustomer = new CustomerFlow())
                {
                    flowCustomer.FillCustomer(ref CustomerList);
                }
                return CustomerList.GetArrayList();
            }
        }

        public ArrayList DataSourceBrand
        {
            get
            {
                BrandList brandList = new BrandList();
                using (BrandFlow flowBrand = new BrandFlow())
                {
                    flowBrand.FillMTBList(brandList);
                }
                return brandList.GetArrayList();
            }
        }

        public ArrayList DataSourceModel(Brand value)
        {

            ModelList modelList = new ModelList();
            modelList.ABrand = value;
            using (ModelFlow flowModel = new ModelFlow())
            {
                flowModel.FillModel(ref modelList);
            }

            return modelList.GetArrayList();
        }

        public ArrayList DataSourceColor
        {
            get
            {
                ColorList colorList = new ColorList();
                using (ColorFlow flowColor = new ColorFlow())
                {
                    flowColor.FillMTBList(colorList);
                }
                return colorList.GetArrayList();
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

        public List<VehiclePurchasing> SearchPurchaseOrder(DocumentNo purchaseNo, DateTime aIssueDate)
        {
            return flowVehiclePurchasing.FillPurchasing(purchaseNo, aIssueDate, GetCompany());
        }

        public List<VehiclePurchasing> SearchPurchaseOrderByVehicle(DocumentNo purchaseNo)
        {
            return flowVehiclePurchasing.FillPurchasingByVehicle(purchaseNo,GetCompany());
        }

        public VehiclePurchasing SearchPurchaseOrderByPurchaseNo(string purchaseNo)
        {
            return flowVehiclePurchasing.FillPurchasingByPurchaseNo(purchaseNo, GetCompany());
        }

        public List<VehiclePurchasingContract> GetPurchasingContractListByPurchase(VehiclePurchasing vehiclePurchasing)
        {
            using (VehiclePurchasingContractFlow flow = new VehiclePurchasingContractFlow())
            {
                return flow.GetPurchasingContractListByPurchase(vehiclePurchasing, GetCompany());
            }
        }

        public VehicleQuotation GetQuotationByPurchaseNo(DocumentNo purchaseNo)
        {
            return flowVehiclePurchasing.GetQuotationByPurchaseNo(purchaseNo, GetCompany());
        }

        public List<VehiclePurchasingContract> GetPurchasingContractListByVehicleSelling(VehiclePurchasing vehclePurchasing)
        {
            using (VehiclePurchasingContractFlow flow = new VehiclePurchasingContractFlow())
            {
                return flow.GetPurchasingContractListByVehicleSelling(vehclePurchasing);
            }
        }

        public bool InsertPurchasing(VehiclePurchasing vehiclePurchasing, DocumentNo quotationNo)
        {
            return flowVehiclePurchasing.InsertPurchasing(vehiclePurchasing, quotationNo, GetCompany());
        }

        public bool UpdatePurchasing(VehiclePurchasing vehiclePurchasing, DocumentNo quotationNo)
        {
            return flowVehiclePurchasing.UpdatePurchasing(vehiclePurchasing,quotationNo, GetCompany());
        }

        public bool CancelPurchaseOrder(VehiclePurchasing vehiclePurchasing)
        {
            return flowVehiclePurchasing.CancelPurchaseOrder(vehiclePurchasing, GetCompany());
        }

        public List<VehiclePurchasingContract> GetPurchasingContractByContractStatus(VehiclePurchasing vehclePurchasing, ContractStatus contractStauts)
        {
            using (VehiclePurchasingContractFlow flow = new VehiclePurchasingContractFlow())
            {
                return flow.GetPurchasingContractByContractStatus(vehclePurchasing, contractStauts);
            }
        }
    }
}
