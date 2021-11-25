using System;
using System.Text;
using System.Reflection;

using Entity.ContractEntities;
using ictus.SystemConnection.BizPac.AR;
using ictus.Common.Entity;
using Entity.PTB.BTS.BTS2BizPacEntity;
using ictus.Common.Entity.General;

namespace PTB.BTS.BTS2BizPacEntity
{
    public class VehicleContractChargeBP : VehicleContractCharge, IBTS2BizPacHeader, IARHeader
    {

        //=============================== Constructor ===============================
        public VehicleContractChargeBP(Company company) : base(company)
        { }

        #region IBTS2BizPacHeader Members
        private ContractCharge contractCharge;
        public ContractCharge ContractCharge
        {
            get { return contractCharge; }
            set { contractCharge = value; }
        }

        private int attachGroup = NullConstant.INT;
        public int AttachGroup
        {
            get { return attachGroup; }
            set { attachGroup = value; }
        }

        public string DocNo
        {
            get { return base.contractNo.ToString(); }
        }

        public string PaidTo
        {
            get
            {
                if (base.aCustomerDepartment == null || base.aCustomerDepartment.ShortName.Trim() == "")
                {
                    return base.aCustomer.AName.English;
                }
                else
                {
                    return base.aCustomer.AName.English + "(" + base.aCustomerDepartment.ShortName + ")";
                }
            }
        }

        //Change customer code to customer BizPac code : Woranai 2011/07/07
        public string PaidToCode
        {
            get { return base.aCustomer.Code.Trim(); }
        }

        //for additional
        public string AdditionalInfo
        {
            get { return base.aPeriod.From.ToShortDateString(); }
        }

        public string AdditionalDate
        {
            get { return base.aPeriod.To.ToShortDateString(); }
        }

        public string BTSRemark
        {
            get 
            {
                StringBuilder stringBuilder = new StringBuilder("Car Rental Fee ");
                stringBuilder.Append(base.AVehicleRoleList[0].AVehicle.PlateNumber);
                stringBuilder.Append(" for ");
                stringBuilder.Append(base.yearMonth.Month.ToString());
                stringBuilder.Append("/");
                stringBuilder.Append(base.yearMonth.Year.ToString());
                string remark = stringBuilder.ToString();
                stringBuilder = null;
                return remark; 
            }
        }

        public decimal BTSAmount
        {
            get { return this.chargeAmount; }
        }

        public int BTSCheck
        {
            get 
            {
                return 1;
            }
        }

        
        private bool conContractSts = false;
        /// <summary>
        /// Status of continuous contract
        /// </summary>
        public bool ConContractSts
        {
            get { return conContractSts; }
            set { conContractSts = value; }
        }
	
        #endregion

        #region IAccountHeader Members

        public decimal BaseAmount
        {
            set { base.chargeAmount = value; }
            get { return base.chargeAmount; }
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
                return bizPacRefDate;
            }
            set
            {
                bizPacRefDate = value;
            }
        }

        public string BizPacRemark1
        {
            get 
            {
                return "Car Rental Fee in " + BTS2BizPacCommon.StringMonthYear;
            }
        }

        public string BusinessPlace
        {
            get { return BizPacFixData.BUSINESS_PLACE; }
        }

        public string DocumentType
        {
            get { return "R2"; }
        }

        public DateTime DueDate
        {
            get { return BizPacFixData.NEXT_MID_DATE_OF_MONTH; }
        }

        public DateTime DocDate
        {
            get { return bizPacRefDate; }
        }

        public int BizPacCount
        {
            get
            {
                return 1;      
            }
        }

        public ictus.SystemConnection.BizPac.Core.IAccountDetail GetDetail(int index)
        {
            BTS2BizPacDetailAR detailAR = new BTS2BizPacDetailAR();
            detailAR.SeqNo = 1;
            detailAR.MiscItemCode = "RE0001";
            detailAR.ItemDescription = BizPacRemark1;
            detailAR.Quantity = 0;
            detailAR.Price = 0;
            detailAR.Amount = this.BaseAmount;
            detailAR.BusinessUnit = "01";

            //User request to cancel this condition (Request from Ms.Siwanee) : woranai 2009/11/27
            //if (conContractSts)
            //{
            //    detailAR.BizPacRemark2 = "(บริษัทฯ ได้รับการยกเว้นในการหักภาษี ณ ที่จ่าย ตาม ท.ป. 4/2528)";           
            //}

            return detailAR;
        }

        public string InvoiceType
        {
            get { return "S"; }
        }

        public decimal NetAmount
        {
            get { return this.BaseAmount + this.VATAmount ; }
        }

        public DateTime TaxInvoiceDate
        {
            get { return DateTime.Today; }
        }

        public string TaxInvoiceNo
        {
            get { return ""; }
        }

        protected decimal vatAmount = NullConstant.DECIMAL;
        public decimal VATAmount
        {
            set { vatAmount = value; }
            get { return vatAmount; }
        }

        public string VATCalcType
        {
            get { return "E"; }
        }

        public string VATCode
        {
            get { return "O7"; }
        }

        public string VATType
        {
            get { return "Y"; }
        }

        #endregion

        #region IARHeader Members

        //Change customer code to customer BizPac code : Woranai 2011/07/07
        public string CustomerCode
        {
            get { return base.aCustomer.BizPacCode.Trim(); }
        }

        public string CustomerName
        {
            get { return base.aCustomer.AName.English; }
        }

        #endregion

        public VehicleContractChargeBP CloneVehicleCharge(VehicleContractChargeBP vehicleBP)
        {
            return new VehicleContractChargeBP(vehicleBP.AContractChargeList.Company)
            {
                ContractCharge = vehicleBP.ContractCharge,
                YearMonth = vehicleBP.YearMonth,
                ChargeAmount = vehicleBP.ChargeAmount,
                ADriverContract = vehicleBP.ADriverContract,
                AVehicleRoleList = vehicleBP.AVehicleRoleList,
                LeaseTermMonth = vehicleBP.LeaseTermMonth,
                KindOfRental = vehicleBP.KindOfRental,
                ContinuousStatus = vehicleBP.ContinuousStatus,
                ContractNo = vehicleBP.ContractNo,
                ACustomer = vehicleBP.ACustomer,
                ACustomerDepartment = vehicleBP.ACustomerDepartment,
                ContractDate = vehicleBP.ContractDate,
                APeriod = vehicleBP.APeriod,
                AContractType = vehicleBP.AContractType,
                UnitHire = vehicleBP.UnitHire,
                AKindOfContract = vehicleBP.AKindOfContract,
                RateStatus = vehicleBP.RateStatus,
                AContractStatus = vehicleBP.AContractStatus,
                CancelDate = vehicleBP.CancelDate,
                ACancelReason = vehicleBP.ACancelReason,
                Remark = vehicleBP.Remark,
                AContractChargeList = vehicleBP.AContractChargeList,
                DriverDeductCharge = vehicleBP.DriverDeductCharge,
                AssignedDepartmentList = vehicleBP.AssignedDepartmentList
            };
        }

        // 14/2/2019 Napat C.
        public DateTime PostingDate { get; set; }
    }
}
