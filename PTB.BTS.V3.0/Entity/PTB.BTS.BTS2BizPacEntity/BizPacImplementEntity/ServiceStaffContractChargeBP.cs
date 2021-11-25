using System;

using Entity.ContractEntities;
using ictus.SystemConnection.BizPac.AR;
using ictus.Common.Entity;
using System.Text;
using PTB.BTS.Attendance.BenefitChargeEntities;
using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;
using PTB.BTS.ContractEntities.ContractChargeRate;
using Entity.PTB.BTS.BTS2BizPacEntity;
using ictus.SystemConnection.BizPac.Core;

namespace PTB.BTS.BTS2BizPacEntity
{
    public class ServiceStaffContractChargeBP : ServiceStaffContractCharge, IBTS2BizPacHeader, IARHeader, IBenefitCharge, IStaffDNAttach
    {
        //=============================== Constructor ===============================
        public ServiceStaffContractChargeBP(Company company)
            : base(company)
        {
        }

        protected decimal roundAmount(decimal value)
        {
            decimal sumRemainder = decimal.Remainder(value, 1);
            if (sumRemainder == 0.5m)
            {
                return value + 0.5m;
            }
            else
            {
                return Math.Round(value, MidpointRounding.AwayFromZero);
            }
        }

        public enum ServiceType
        {
            General,
            GeneralCCTV,
            Maintenance,
        }

        #region IBTS2BizPacHeader Members
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
                if (base.aCustomerDepartment == null || base.aCustomerDepartment.AName.English.Trim() == "")
                {
                    return base.aCustomer.AName.English;
                }
                else
                {
                    return base.aCustomer.AName.English + "(" + base.aCustomerDepartment.AName.English + ")";
                }
            }
        }

        //Change customer code to customer BizPac code : woranai 2011/07/07
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
                if (base.aLatestServiceStaffRoleList.Count > 0)
                {
                    return base.ALatestServiceStaffRoleList[0].AServiceStaffType.ADescription.English + " in " + this.yearMonth.Month.ToString() + "/" + this.yearMonth.Year.ToString();
                }
                else
                {
                    return "ไม่พบพนักงานขับรถในสัญญา";
                }
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
                if (base.aLatestServiceStaffRoleList.Count > 0 && this.Amount > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion

        #region IAccountHeader Members
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
                if (this.details.Count >= 2)
                {
                    StringBuilder stringBuilder = new StringBuilder("General Service and Office Maintenance Fee in ");
                    stringBuilder.Append(BTS2BizPacCommon.StringBackMonthYear);
                    return stringBuilder.ToString();
                }
                else if (this.details.Count == 1)
                {
                    StringBuilder stringBuilder = new StringBuilder(this.details[0].ItemDescription);
                    return stringBuilder.ToString();
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder("General Service Fee in ");
                    stringBuilder.Append(BTS2BizPacCommon.StringBackMonthYear);
                    return stringBuilder.ToString();
                }
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
            get { return BizPacFixData.BACK_END_DATE_OF_MONTH; }
        }

        public IAccountDetail GetDetail(int index)
        {
            return details[index];
        }

        private BTS2BizPacDetailList details;
        public BTS2BizPacDetailList Details
        {
            get { return details; }
            set { details = value; }
        }

        public string InvoiceType
        {
            get { return "S"; }
        }

        public DateTime TaxInvoiceDate
        {
            get { return DateTime.Today; }
        }

        public string TaxInvoiceNo
        {
            get { return ""; }
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

        public decimal NetAmount
        {
            get { return baseAmount + vatAmount; }
        }

        protected decimal baseAmount;
        public decimal BaseAmount
        {
            get { return Math.Round(baseAmount, 2); }
            set { baseAmount = value; }
        }

        protected decimal vatAmount;
        public decimal VATAmount
        {
            get { return vatAmount; }
            set { vatAmount = value; }
        }
        #endregion

        #region IARHeader Members

        //Change customer code to customer BizPac code : woranai 2011/07/07
        public string CustomerCode
        {
            get { return base.aCustomer.BizPacCode; }
        }

        public string CustomerName
        {
            get { return base.aCustomer.AName.English; }
        }

        #endregion

        #region for build detail
        public int BizPacCount
        {
            get { return details.Count; }
        }
        #endregion

        #region IBenefitCharge Members

        public decimal Basic
        {
            get { return base.ChargeAmount; }
        }

        protected int otADay;
        public int OTADay
        {
            get { return otADay; }
            set { otADay = value; }
        }

        protected decimal otARate;
        public decimal OTARate
        {
            get { return otARate; }
            set { otARate = value; }
        }

        protected decimal otACharge;
        public decimal OTACharge
        {
            get { return otACharge; }
            set { otACharge = value; }
        }

        public decimal OTAAmount
        {
            get { return roundAmount(otARate * otACharge); }
        }

        protected decimal otBRate;
        public decimal OTBRate
        {
            get { return otBRate; }
            set { otBRate = value; }
        }

        protected decimal otBCharge;
        public decimal OTBCharge
        {
            get { return otBCharge; }
            set { otBCharge = value; }
        }

        public decimal OTBAmount
        {
            get { return roundAmount(otBRate * otBCharge); }
        }

        protected decimal otCRate;
        public decimal OTCRate
        {
            get { return otCRate; }
            set { otCRate = value; }
        }

        protected decimal otCCharge;
        public decimal OTCCharge
        {
            get { return otCCharge; }
            set { otCCharge = value; }
        }

        public decimal OTCAmount
        {
            get { return roundAmount(otCRate * otCCharge); }
        }

        protected int holiday;
        public int Holiday
        {
            get { return holiday; }
            set { holiday = value; }
        }

        protected decimal holidayAmount;
        public decimal HolidayAmount
        {
            get { return holidayAmount; }
            set { holidayAmount = value; }
        }

        protected int taxi;
        public int Taxi
        {
            get { return taxi; }
            set { taxi = value; }
        }

        protected decimal taxiAmount;
        public decimal TaxiAmount
        {
            get { return taxiAmount; }
            set { taxiAmount = value; }
        }

        protected int tripNear;
        public int TripNear
        {
            get { return tripNear; }
            set { tripNear = value; }
        }

        protected decimal tripNearAmount;
        public decimal TripNearAmount
        {
            get { return tripNearAmount; }
            set { tripNearAmount = value; }
        }

        protected int tripFar;
        public int TripFar
        {
            get { return tripFar; }
            set { tripFar = value; }
        }

        protected decimal tripFarAmount;
        public decimal TripFarAmount
        {
            get { return tripFarAmount; }
            set { tripFarAmount = value; }
        }

        protected int nightTrip;
        public int NightTrip
        {
            get { return nightTrip; }
            set { nightTrip = value; }
        }

        protected decimal nightTripAmount;
        public decimal NightTripAmount
        {
            get { return nightTripAmount; }
            set { nightTripAmount = value; }
        }

        public decimal other;
        public decimal Other
        {
            get { return other; }
            set { other = value; }
        }

        protected decimal deducTime;
        public decimal DeducTime
        {
            get { return deducTime; }
            set { deducTime = value; }
        }

        protected decimal deducAmountPerDay;
        public decimal DeducAmountPerDay
        {
            get { return deducAmountPerDay; }
            set { deducAmountPerDay = value; }
        }

        private decimal deducAmount;
        public decimal DeducAmount
        {
            //get { return deducTime * deducAmountPerDay; }
            get { return deducAmount; }
            set { deducAmount = value; }
        }

        public decimal Amount
        {
            get
            {
                decimal amount = (Basic + TelephoneAmount + OTAAmount + OTBAmount + OTCAmount + HolidayAmount + (int)taxiAmount + OneDayTripFarAmount + OneDayTripNearAmount + OvernightTripAmount + OtherChargeAmount + OTAAmountAllow + SpecialAmount - DeducAmount)
                         + (OTAAmountAdjust + OTBAmountAdjust + OTCAmountAdjust + HolidayAmountAdjust + TaxiAmountAdjust + TripNearAmountAdjust + TripFarAmountAdjust + NightTripAmountAdjust - DeducAmountAdjust);
                return roundAmount(amount);
            }
        }

        public decimal VAT
        {
            get { return vatAmount; }
        }

        public decimal Total
        {
            get { return Amount + VAT; }
        }

        protected decimal telephoneAmount;
        public decimal TelephoneAmount
        {
            get { return telephoneAmount; }
            set { telephoneAmount = value; }
        }

        protected decimal specialAmount;
        public decimal SpecialAmount
        {
            get { return specialAmount; }
            set { specialAmount = value; }
        }

        protected ServiceStaff serviceStaff;
        public ServiceStaff ServiceStaff
        {
            get { return serviceStaff; }
            set { serviceStaff = value; }
        }

        protected ChargeRate chargeRate;
        public ChargeRate ChargeRate
        {
            get { return chargeRate; }
            set { chargeRate = value; }
        }

        private decimal otAHourAdjust = decimal.Zero;
        public decimal OTAHourAdjust
        {
            get { return otAHourAdjust; }
            set { otAHourAdjust = value; }
        }

        private decimal otAAmountAdjust = decimal.Zero;
        public decimal OTAAmountAdjust
        {
            get { return roundAmount(otAAmountAdjust); }
            set { otAAmountAdjust = value; }
        }

        private decimal otBHourAdjust = decimal.Zero;
        public decimal OTBHourAdjust
        {
            get { return otBHourAdjust; }
            set { otBHourAdjust = value; }
        }

        private decimal otBAmountAdjust = decimal.Zero;
        public decimal OTBAmountAdjust
        {
            get { return roundAmount(otBAmountAdjust); }
            set { otBAmountAdjust = value; }
        }

        private decimal otCHourAdjust = decimal.Zero;
        public decimal OTCHourAdjust
        {
            get { return otCHourAdjust; }
            set { otCHourAdjust = value; }
        }

        private decimal otCAmountAdjust = decimal.Zero;
        public decimal OTCAmountAdjust
        {
            get { return roundAmount(otCAmountAdjust); }
            set { otCAmountAdjust = value; }
        }

        private int holidayAdjust = 0;
        public int HolidayAdjust
        {
            get { return holidayAdjust; }
            set { holidayAdjust = value; }
        }

        private decimal holidayAmountAdjust = decimal.Zero;
        public decimal HolidayAmountAdjust
        {
            get { return holidayAmountAdjust; }
            set { holidayAmountAdjust = value; }
        }

        private int taxiAdjust = 0;
        public int TaxiAdjust
        {
            get { return taxiAdjust; }
            set { taxiAdjust = value; }
        }

        private decimal taxiAmountAdjust = decimal.Zero;
        public decimal TaxiAmountAdjust
        {
            get { return taxiAmountAdjust; }
            set { taxiAmountAdjust = value; }
        }

        private int tripNearAdjust = 0;
        public int TripNearAdjust
        {
            get { return tripNearAdjust; }
            set { tripNearAdjust = value; }
        }

        private int tripFarAdjust = 0;
        public int TripFarAdjust
        {
            get { return tripFarAdjust; }
            set { tripFarAdjust = value; }
        }

        private decimal tripNearAmountAdjust = decimal.Zero;
        public decimal TripNearAmountAdjust
        {
            get { return tripNearAmountAdjust; }
            set { tripNearAmountAdjust = value; }
        }

        private decimal tripFarAmountAdjust = decimal.Zero;
        public decimal TripFarAmountAdjust
        {
            get { return tripFarAmountAdjust; }
            set { tripFarAmountAdjust = value; }
        }

        private int nightTripAdjust = 0;
        public int NightTripAdjust
        {
            get { return nightTripAdjust; }
            set { nightTripAdjust = value; }
        }

        private decimal nightTripAmountAdjust = decimal.Zero;
        public decimal NightTripAmountAdjust
        {
            get { return nightTripAmountAdjust; }
            set { nightTripAmountAdjust = value; }
        }

        private decimal deducAdjust = decimal.Zero;
        public decimal DeducAdjust
        {
            get { return deducAdjust; }
            set { deducAdjust = value; }
        }

        private decimal deducAmountAdjust = decimal.Zero;
        public decimal DeducAmountAdjust
        {
            get { return deducAmountAdjust; }
            set { deducAmountAdjust = value; }
        }

        private int line = 1;
        public int Line
        {
            get { return line; }
            set { line = value; }
        }

        private string chargeRemark = "";
        public string ChargeRemark
        {
            get { return chargeRemark; }
            set { chargeRemark = value.Trim(); }
        }
        #endregion

        #region IStaffDNAttach Members
        string IStaffDNAttach.CustomerCode
        {
            get { return base.aCustomer.Code.Trim(); }
        }

        public string ContractNumber
        {
            get { return base.contractNo.ToString(); }
        }

        public string CustomerDepartmentCode
        {
            get { return base.aCustomerDepartment.Code; }
        }

        public string BizPacReferenceNo
        {
            get { return bizPacRefNo; }
        }

        public int AttachLine
        {
            get { return Line; }
        }

        public string MainEmployeeNo
        {
            get { return serviceStaff.EmployeeNo; }
        }

        public string CustomerDeptName
        {
            get { return base.aCustomerDepartment.ShortName; }
        }

        public string EmployeeName
        {
            get
            {
                if (base.aLatestServiceStaffRoleList.Count <= 0)
                {
                    return "ไม่พบพนักงานในสัญญา";
                }
                else if (base.aLatestServiceStaffRoleList.Count == 1)
                {
                    return serviceStaff.AName.English + " " + serviceStaff.ASurname.English.Substring(0, 1).ToUpper() + ".";
                }
                else
                {
                    return serviceStaff.APosition.ShortName;
                }
            }
        }

        public string ServiceStaffType
        {
            get { return serviceStaff.AServiceStaffType.Type; }
        }

        public string ServiceStaffName
        {
            get { return serviceStaff.AServiceStaffType.ADescription.English; }
        }

        public string PlateNo
        {
            get { return ""; }
        }

        public int BasicChargeAmount
        {
            get { return (int)base.ChargeAmount; }
        }

        public decimal OTAHourAllow
        {
            get { return OTADay * 3.0m; }
        }

        protected decimal otAAmountAllow;
        public decimal OTAAmountAllow
        {
            get { return otAAmountAllow; }
            set { otAAmountAllow = roundAmount(value); }
        }

        public decimal OTAHour
        {
            get { return otACharge; }
        }

        decimal IStaffDNAttach.OTAAmount
        {
            get { return roundAmount(otARate * otACharge); }
        }

        public decimal OTBHour
        {
            get { return otBCharge; }
        }

        decimal IStaffDNAttach.OTBAmount
        {
            get { return roundAmount(otBRate * otBCharge); }
        }

        public decimal OTCHour
        {
            get { return otCCharge; }
        }

        decimal IStaffDNAttach.OTCAmount
        {
            get { return OTCAmount; }
        }

        public int HolidayTime
        {
            get { return holiday; }
        }

        public decimal FixOTAmount
        {
            get { return 0; }
        }

        public int TaxiTimes
        {
            get { return taxi; }
        }

        int IStaffDNAttach.TaxiAmount
        {
            get { return (int)taxiAmount; }
        }

        int IStaffDNAttach.TelephoneAmount
        {
            get { return (int)telephoneAmount; }
        }

        public decimal DeductionAmountPerDay
        {
            get { return deducAmountPerDay; }
        }

        public decimal DeductionDays
        {
            get { return deducTime; }
        }

        public decimal DeductionAmount
        {
            get { return roundAmount(DeducAmount); }
        }

        public int OneDayTripFarTimes
        {
            get { return TripFar; }
        }

        public decimal OneDayTripFarAmount
        {
            get { return roundAmount(TripFarAmount); }
        }

        public int OneDayTripNearTimes
        {
            get { return TripNear; }
        }

        public decimal OneDayTripNearAmount
        {
            get { return roundAmount(TripNearAmount); }
        }

        public int OvernightTripTimes
        {
            get { return nightTrip; }
        }

        public decimal OvernightTripAmount
        {
            get { return roundAmount(nightTripAmount); }
        }

        public decimal OtherChargeAmount
        {
            get { return roundAmount(other); }
        }

        public decimal TotalAmount
        {
            get { return Amount; }
        }

        public decimal GrandTotalAmount
        {
            get { return Total; }
        }

        public string CustomerShortName
        {
            get { return base.aCustomer.ShortName; }
        }

        public string AttachRemark
        {
            get { return chargeRemark.Trim(); }
        }

        public string CustBizPacCode
        {
            get { return base.aCustomer.BizPacCode; }
        }
        #endregion
    }
}