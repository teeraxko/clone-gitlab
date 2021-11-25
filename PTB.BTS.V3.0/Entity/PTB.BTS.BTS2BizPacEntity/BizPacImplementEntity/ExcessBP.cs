using System;

using ictus.SystemConnection.BizPac.AP;

using ictus.Common.Entity;
using ictus.SystemConnection.BizPac.Core;

using Entity.PTB.BTS.BTS2BizPacEntity;
using ictus.Common.Entity.General;
using ictus.Common.Entity.Time;

namespace PTB.BTS.BTS2BizPacEntity
{
    public class ExcessBP : Entity.VehicleEntities.Accident, IBTS2BizPacHeader, IAPHeader
    {
        #region IBTS2BizPacHeader Members

        public string DocNo
        {
            get { return repairingNo; }
        }

        public string PaidToCode
        {
            get
            {
                if (base.billByInsuranceStatus)
                {
                    return base.aInsuranceCompany.Code;
                }
                else
                {
                    return base.garage.BizPacVendorCode;
                }
            }
        }

        public string PaidTo
        {
            get 
            {
                if (base.billByInsuranceStatus)
                {
                    return base.aInsuranceCompany.AName.English;
                }
                else
                {
                    return base.garage.AName.English;
                }
            }
        }

        public string AdditionalInfo
        {
            get { return base.InsuranceReceiptNo; }
        }

        public string AdditionalDate
        {
            get { return base.InsuranceReceiptDate.ToShortDateString(); }
        }

        public string BTSRemark
        {
            get { return "Payment Excess for " + base.VehicleInfo.PlateNumber; }
        }

        public decimal BTSAmount
        {
            get { return base.ActualExcessAmount; }
        }

        public int BTSCheck
        {
            get { return 1; }
        }
        #endregion

        #region IAccountHeader Members

        public decimal BaseAmount
        {
            get
            {
                return excessTotalAmount;
            }
        }

        public int BizPacCount
        {
            get { return details.Count; }
        }

        private string bizPacRefNo = NullConstant.STRING;
        public string BizPacRefNo
        {
            get
            {
                return bizPacRefNo;
            }
            set
            {
                bizPacRefNo = value.Trim();
            }
        }

        private DateTime bizPacRefDate;
        public DateTime BizPacRefDate
        {
            get
            {
                return endDateOfMonth;
            }
            set
            {
                bizPacRefDate = value;
            }
        }

        private int caseForRemark = 0;
        public int CaseForRemark
        {
            get { return caseForRemark; }
            set { caseForRemark = value; }
        }

        public string BizPacRemark1
        {
            get { return "Payment for Excess " + caseForRemark.ToString() + " case(s)"; }
        }

        public string BusinessPlace
        {
            get { return BizPacFixData.BUSINESS_PLACE; }
        }

        public string DocumentType
        {
            get { return BizPacFixData.DOCUMENT_TYPE_AP; }
        }

        public DateTime DueDate
        {
            get { return BizPacFixData.END_DATE_OF_MONTH; }
        }

        public DateTime DocDate
        {
            //DocDate input from user : woranai 30/05/2007
            //get { return bizPacRefDate; }
            get { return _docDateControl; }
        }

        private BTS2BizPacDetailList details;
        public BTS2BizPacDetailList Details
        {
            get { return details; }
            set { details = value; }
        }

        public IAccountDetail GetDetail(int index)
        {
            return details[index];
        }

        public string InvoiceType
        {
            get { return "S"; }
        }

        public decimal NetAmount
        {
            get { return BaseAmount; }
        }

        public decimal VATAmount
        {
            get { return 0; }
        }

        public string VATCalcType
        {
            get { return BizPacFixData.VAT_CALC_TYPE; }
        }

        public string VATCode
        {
            get { return BizPacFixData.NO_VAT_CODE_AP; }
        }

        public string VATType
        {
            get { return BizPacFixData.NO_VAT_TYPE; }
        }

        #endregion

        #region IAPHeader Members

        public bool HaveTaxInvoice
        {
            get { return false; }
        }

        public string VendorCode
        {
            get
            {
                //if (base.billByInsuranceStatus)
                //{
                return base.aInsuranceCompany.Code;
                //}
                //else
                //{
                //    return base.garage.BizPacVendorCode;
                //}
            }
        }

        public DateTime VendorDate
        {
            get { return insuranceReceiptDate; }
        }

        public string VendorInvoice
        {
            get { return insuranceReceiptNo; ; }
        }

        public string VendorName
        {
            get
            {
                //if (base.billByInsuranceStatus)
                //{
                return base.aInsuranceCompany.AName.English;
                //}
                //else
                //{
                //    return base.garage.AName.English;
                //}
            }
        }

        #endregion

        public static DateTime endDateOfMonth;

        public ExcessBP()
            : base(new Company("12"))
        {
            YearMonth yearMonth = new YearMonth(DateTime.Today);
            endDateOfMonth = yearMonth.MaxDateOfMonth;
        }

        public ExcessBP Clone()
        {
            ExcessBP excessBP = new ExcessBP();
            excessBP.accidentPlace = this.accidentPlace;
            excessBP.aCustomer = this.aCustomer;
            excessBP.aCustomerDepartment = this.aCustomerDepartment;
            excessBP.aDriver = this.aDriver;
            excessBP.aDriverExcessDeduction = this.aDriverExcessDeduction;
            excessBP.aHirer = this.aHirer;
            excessBP.aInsuranceCompany = this.aInsuranceCompany;
            excessBP.aPayer = this.aPayer;
            excessBP.aPoliceStation = this.aPoliceStation;
            excessBP.aReceiver = this.aReceiver;
            excessBP.aRepairSparePartsList = this.aRepairSparePartsList;
            excessBP.aReporter = this.aReporter;
            excessBP.aVehicleContract = this.aVehicleContract;
            excessBP.billByInsuranceStatus = this.billByInsuranceStatus;
            excessBP.bizPacRefDate = this.bizPacRefDate;
            excessBP.bizPacRefNo = this.bizPacRefNo;
            excessBP.caseForRemark = this.caseForRemark;
            excessBP.damagePercentage = this.damagePercentage;
            excessBP.detailOfAccident1 = this.detailOfAccident1;
            excessBP.detailOfAccident2 = this.detailOfAccident2;
            excessBP.detailOfAccident3 = this.detailOfAccident3;
            excessBP.detailOfAccident4 = this.detailOfAccident4;
            excessBP.details = this.details;
            excessBP.driverName = this.driverName;
            excessBP.excessPaidAmount = this.excessPaidAmount;
            excessBP.excessRemainAmount = this.excessRemainAmount;
            excessBP.excessTotalAmount = this.excessTotalAmount;
            excessBP.actualExcessAmount = this.actualExcessAmount;
            excessBP.frontGlassBroken = this.frontGlassBroken;
            excessBP.garage = this.garage;
            excessBP.garageInchargeName = this.garageInchargeName;
            excessBP.garageTelNo = this.garageTelNo;
            excessBP.happenTime = this.happenTime;
            excessBP.hasClaimnant = this.hasClaimnant;
            excessBP.hasExcess = this.hasExcess;
            excessBP.insuranceClaimNo = this.insuranceClaimNo;
            excessBP.insuranceReceiptDate = this.insuranceReceiptDate;
            excessBP.insuranceReceiptNo = this.insuranceReceiptNo;
            excessBP.invoiceDate = this.invoiceDate;
            excessBP.invoiceNo = this.invoiceNo;
            excessBP.kindOfVehicle = this.kindOfVehicle;
            excessBP.latestAccidentUpdateDate = this.latestAccidentUpdateDate;
            excessBP.latestAccidentUpdateUser = this.latestAccidentUpdateUser;
            excessBP.maintainStatus = this.maintainStatus;
            excessBP.maintenanceAmount = this.maintenanceAmount;
            excessBP.mileage = this.mileage;
            excessBP.paidToCompanyDate = this.paidToCompanyDate;
            excessBP.paidToCompanyStatus = this.paidToCompanyStatus;
            excessBP.paidToInsurance = this.paidToInsurance;
            excessBP.paidToInsuranceDate = this.paidToInsuranceDate;
            excessBP.payToCompanyBizPacConnectionDate = this.payToCompanyBizPacConnectionDate;
            excessBP.payToCompanyBizPacReferenceNo = this.payToCompanyBizPacReferenceNo;
            excessBP.payToInsuranceBizPacConnectionDate = this.payToInsuranceBizPacConnectionDate;
            excessBP.payToInsuranceBizPacReferenceNo = this.payToInsuranceBizPacReferenceNo;
            excessBP.policemanName = this.policemanName;
            excessBP.remark1 = this.remark1;
            excessBP.remark2 = this.remark2;
            excessBP.repairFinishStatus = this.repairFinishStatus;
            excessBP.repairingNo = this.repairingNo;
            excessBP.repairingPaymentType = this.repairingPaymentType;
            excessBP.repairingType = this.repairingType;
            excessBP.repairPeriod = this.repairPeriod;
            excessBP.reportDate = this.reportDate;
            excessBP.taxInvoiceDate = this.taxInvoiceDate;
            excessBP.taxInvoiceNo = this.taxInvoiceNo;
            excessBP.taxInvoiceStatus = this.taxInvoiceStatus;
            excessBP.totalAmount = this.totalAmount;
            excessBP.vatAmount = this.vatAmount;
            excessBP.vatStatus = this.vatStatus;
            excessBP.vehicleInfo = this.vehicleInfo;
            excessBP.DocDateControl = this._docDateControl;
            return excessBP;
        }

        private DateTime _docDateControl = DateTime.Today;
        public DateTime DocDateControl
        {
            set { _docDateControl = value; }
        }	
    }
}
