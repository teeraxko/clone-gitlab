using System;
using System.Text;
using Entity.ContractEntities;
using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.SystemConnection.BizPac.AR;
using PTB.BTS.Attendance.BenefitChargeEntities;
using PTB.BTS.ContractEntities.ContractChargeRate;
using Entity.AttendanceEntities;

namespace PTB.BTS.BTS2BizPacEntity
{
    public class DriverContractChargeBP : DriverContractCharge, IBTS2BizPacHeader, IARHeader, IBenefitCharge, IStaffDNAttach
    {
        #region Constructor
        public DriverContractChargeBP(Company company)
            : base(company)
        {
        }

        #endregion

        #region Private Method
        private decimal roundAmount(decimal value)
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
        #endregion

        #region Property
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
                    StringBuilder stringBuilder = new StringBuilder("Driving service fee in ");
                    stringBuilder.Append(this.yearMonth.Month.ToString());
                    stringBuilder.Append("/");
                    stringBuilder.Append(this.yearMonth.Year.ToString());
                    return stringBuilder.ToString();
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
                if (base.aLatestServiceStaffRoleList.Count > 0 && this.Amount > 0 && this.Amount < 100000)
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
        private BizPacReference bizPacReference;
        public BizPacReference BizPacReference
        {
            get
            {
                return bizPacReference;
            }
            set
            {
                bizPacReference = value;
            }
        }

        public string BizPacRefNo
        {
            get
            {
                return bizPacReference.BizPacRefNo;
            }
            set
            {
                bizPacReference.BizPacRefNo = value.Trim();
            }
        }

        public DateTime BizPacRefDate
        {
            get
            {
                return bizPacReference.BizPacRefDate;
            }
            set
            {
                bizPacReference.BizPacRefDate = value;
            }
        }

        public string BizPacRemark1
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder("Driving service fee in ");
                stringBuilder.Append(BTS2BizPacCommon.StringBackMonthYear);
                return stringBuilder.ToString();
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
            get { return BizPacFixData.NEXT_MID_DATE_OF_MONTH; }// normal
            //For IMCT Special connect
            //get { return new DateTime(2016,01,15); }//IMCT

        }

        public DateTime DocDate
        {
            get { return BizPacFixData.BACK_END_DATE_OF_MONTH; }//normal
            //For IMCT Special connect
            //get { return new DateTime(2015,12,31); }//IMCT
        }

        public ictus.SystemConnection.BizPac.Core.IAccountDetail GetDetail(int index)
        {
            BTS2BizPacDetailAR detailAR = new BTS2BizPacDetailAR();
            detailAR.SeqNo = 1;
            detailAR.MiscItemCode = "DR0001";
            detailAR.ItemDescription = BizPacRemark1;
            detailAR.Quantity = 0;
            detailAR.Price = 0;
            detailAR.Amount = BaseAmount;
            detailAR.BusinessUnit = "02";
            return detailAR;
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

        protected decimal netAmount;
        public decimal NetAmount
        {
            get { return netAmount; }
            set { netAmount = value; }
        }

        protected decimal baseAmount;
        public decimal BaseAmount
        {
            get { return baseAmount; }
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
            get { return 1; }
        }
        #endregion

        #region IBenefitCharge Members

        public decimal Basic
        {
            get { return roundAmount(base.ChargeAmount); }
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

        protected decimal other;
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

        protected decimal deducAmount;
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
                return (Basic + TelephoneAmount + OTAAmount + OTBAmount + OTCAmount + HolidayAmount + (int)TaxiAmount + OneDayTripFarAmount + OneDayTripNearAmount + NightTripAmount + OtherChargeAmount + OTAAmountAllow + SpecialAmount - DeducAmount)
                         + (OTAAmountAdjust + OTBAmountAdjust + OTCAmountAdjust + HolidayAmountAdjust + TaxiAmountAdjust + TripNearAmountAdjust + TripFarAmountAdjust + NightTripAmountAdjust - DeducAmountAdjust);
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

        protected decimal telephoneAmount = decimal.Zero;
        public decimal TelephoneAmount
        {
            get { return telephoneAmount; }
            set { telephoneAmount = value; }
        }

        protected decimal specialAmount = decimal.Zero;
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
            get { return bizPacReference.BizPacRefNo; }
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
                    return "ไม่พบพนักงานขับรถในสัญญา";
                }
                else
                {
                    return serviceStaff.EmployeeNo + " " + serviceStaff.AName.English.Substring(0, 1).ToUpper() + serviceStaff.AName.English.Remove(0, 1).ToLower() + " " + serviceStaff.ASurname.English.Substring(0, 1).ToUpper() + ".";
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
            get { return vehiclePlateNo; }
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
            get { return roundAmount(otCRate * otCCharge); }
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
            get { return roundAmount(NightTripAmount); }
        }

        public decimal OtherChargeAmount
        {
            get { return roundAmount(Other); }
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

        #region Special Value
        private int totalDays;
        public int TotalDays
        {
            get { return totalDays; }
            set { totalDays = value; }
        }

        private string vehiclePlateNo = "";
        public string VehiclePlateNo
        {
            get { return vehiclePlateNo; }
            set { vehiclePlateNo = value; }
        }

        private decimal specialAmountJBIC = decimal.Zero;
        public decimal SpecialAmountJBIC
        {
            get { return specialAmountJBIC; }
            set { specialAmountJBIC = value; }
        }

        public TimePeriod DepartmentAssignedPeriod { get; set; }

        #endregion 
        #endregion

        public DriverContractChargeBP CloneDriverCharge(DriverContractChargeBP driverBP)
        {
            return new DriverContractChargeBP(driverBP.AContractChargeList.Company)
            {
                ContractCharge = driverBP.ContractCharge,
                YearMonth = driverBP.YearMonth,
                ChargeAmount = driverBP.ChargeAmount,
                AVehicleContract = driverBP.AVehicleContract,
                ALatestServiceStaffRoleList = driverBP.ALatestServiceStaffRoleList,
                ContractNo = driverBP.ContractNo,
                ACustomer = driverBP.ACustomer,
                ACustomerDepartment = driverBP.ACustomerDepartment,
                ContractDate = driverBP.ContractDate,
                APeriod = driverBP.APeriod,
                AContractType = driverBP.AContractType,
                UnitHire = driverBP.UnitHire,
                AKindOfContract = driverBP.AKindOfContract,
                RateStatus = driverBP.RateStatus,
                AContractStatus = driverBP.AContractStatus,
                CancelDate = driverBP.CancelDate,
                ACancelReason = driverBP.ACancelReason,
                Remark = driverBP.Remark,
                AContractChargeList = driverBP.AContractChargeList,
                DriverDeductCharge = driverBP.DriverDeductCharge,
                AssignedDepartmentList = driverBP.AssignedDepartmentList,
                BizPacReference = driverBP.BizPacReference
            };
        }
    }
}