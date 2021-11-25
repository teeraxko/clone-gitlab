using System;
using System.Collections.Generic;
using System.Text;
using Entity.VehicleEntities.Leasing;
using Flow.VehicleEntities.Leasing;
using SystemFramework.AppException;
using System.Collections;
using Entity.VehicleEntities;
using PTB.BTS.Vehicle.Flow;
using PTB.BTS.Contract.Flow;
using Entity.ContractEntities;
using Entity.CommonEntity;

namespace Facade.VehicleFacade.LeasingFacade
{
    public class QuotationFacade : Facade.PiFacade.CommonPIFacadeBase
    {
        private QuotationFlow flowQuotation;
        private PurchasingFlow flowPurchasing;

        //============================== Property ==============================
        private QuotationList listQuotation;
        public QuotationList ListQuotation
        {
            get { return listQuotation; }
        }

        #region - DataSource -
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
        public ArrayList DataSourceKindOfVehicle
        {
            get
            {
                KindOfVehicleList kindOfVehicleList = new KindOfVehicleList(GetCompany());
                using (KindOfVehicleFlow flowKindOfVehicle = new KindOfVehicleFlow())
                {
                    flowKindOfVehicle.FillMTBList(kindOfVehicleList);                    
                }
                return kindOfVehicleList.GetArrayList();
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

        public ArrayList DataSourceVendor
        {
            get
            {
                VendorList vendorList = new VendorList(GetCompany());
                using (VendorFlow flowVendor = new VendorFlow())
                {
                    flowVendor.FillVendorList(ref vendorList);                    
                }
                return vendorList.GetArrayList();
            }
        }

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
        #endregion

        //============================== Constructor ==============================
        public QuotationFacade() : base()
        {
            flowQuotation = new QuotationFlow();
            flowPurchasing = new PurchasingFlow();
        }

        //============================== Public method ==============================
        public bool DisplayQuotationMainList(DateTime fromIssueDate)
        {
            listQuotation = new QuotationList(GetCompany());
            return flowQuotation.FillQuotationMainList(listQuotation, fromIssueDate);
        }

        public bool FillQuotationDetail(Quotation quotation)
        {
            bool result = false;

            if (flowQuotation.FillQuotationDetail(quotation, GetCompany()))
            {
                result = true;
                if (quotation.PONo.Trim() != "")
                {
                    ((IPurchasing)quotation).PurchaseNo = new DocumentNo(quotation.PONo);
                    result &= flowPurchasing.FillPO(quotation, GetCompany());
                }
            }

            return result;
        }

        public DocumentNo RetriveRunningNo(DOCUMENT_TYPE docType)
        {
            DocumentNo documentNo;
            using (DocumentNoFlow flowContractRunningNo = new DocumentNoFlow())
            {
                documentNo = flowContractRunningNo.GetContractRunningNo(docType, GetCompany());
            }
            return documentNo;
        }

        public LeasingCalculation Calculate(VehicleCost vehicleCost, short LeaseTerm, decimal percentOfResidual, decimal rateOfReturn)
        {
            return LeasingCalculationFlow.Calculate(vehicleCost, LeaseTerm, percentOfResidual, rateOfReturn);
        }

        #region - Quotation -
        public bool InsertQuotation(Quotation value)
        {
            if (listQuotation.Contain(value))
            {
                throw new DuplicateException("QuotationFacade");
            }
            else
            {
                if (flowQuotation.InsertQuotation(value, GetCompany()))
                {
                    listQuotation.Add(value);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateQuotation(Quotation value)
        {
            if (flowQuotation.UpdateQuotation(value, GetCompany()))
            {
                listQuotation[value.EntityKey] = value;
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateQuotationIssueDate(DocumentNo quotationNo, DateTime issueDate)
        {
            return flowQuotation.UpdateQuotationIssueDate(quotationNo, issueDate, GetCompany());
        }

        public bool DeleteQuotation(Quotation value)
        {
            if (flowQuotation.DeleteQuotation(value, GetCompany()))
            {
                listQuotation.Remove(value);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region - PO -
        public bool FillPO(IPurchasing purchasing)
        {
            return flowPurchasing.FillPO(purchasing, GetCompany());
        }

        public bool InsertPO(IPurchasing po, PURCHAS_STATUS_TYPE poStatus)
        {
            po.PurchasStatus = poStatus;
            return flowPurchasing.InsertPO(po, GetCompany());
        }

        public bool UpdatePO(IPurchasing po)
        {
            return flowPurchasing.UpdatePO(po, GetCompany());
        }

        public bool UpdatePOIssueDate(DocumentNo poNo, DateTime issueDate)
        {
            return flowPurchasing.UpdatePOIssueDate(poNo, issueDate, GetCompany());
        }

        public bool DeleteQuotationPO(IPurchasing po, PURCHAS_STATUS_TYPE poStatus)
        {
            po.PurchasStatus = poStatus;
            return flowPurchasing.DeleteQuotationPO(po, GetCompany());
        }

        public Vendor GetSpecificVendor(Model model)
        {
            Vendor vendor = null;
            using (ModelFlow flowModel = new ModelFlow())
            {
                vendor = flowModel.GetSpecificVendor(model , GetCompany());
            }
            return vendor;
        }
        #endregion
    }
}
