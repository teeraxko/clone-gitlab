using System;

namespace PTB.BTS.BTS2BizPacEntity
{
    public interface IStaffDNAttach
    {
        string CustomerCode { get; }   
        string CustomerDepartmentCode { get; }
        string BizPacReferenceNo { get; }
        int AttachGroup { get; }
        int AttachLine { get; }
        string MainEmployeeNo { get; }
        string ContractNumber { get; }
        string CustomerName { get; }
        string CustomerShortName { get; }
        string CustomerDeptName { get; }
        string EmployeeName { get; }
        string ServiceStaffType { get; }
        string ServiceStaffName { get; }
        string PlateNo { get; }
        int BasicChargeAmount { get; }
        decimal OTAHourAllow { get; }
        decimal OTAAmountAllow { get; }
        decimal OTAHour { get; }
        decimal OTAAmount { get; }
        decimal OTBHour { get; }
        decimal OTBAmount { get; }
        decimal OTCHour { get; }
        decimal OTCAmount { get; }
        int HolidayTime { get;}
        decimal HolidayAmount { get;}
        decimal FixOTAmount { get; }
        int TaxiTimes { get; }
        int TaxiAmount  { get; }
        int TelephoneAmount { get; }
        decimal DeductionAmountPerDay { get; }
        decimal DeductionDays { get; }
        decimal DeductionAmount { get; }
        int OneDayTripFarTimes { get; }
        decimal OneDayTripFarAmount { get; }
        int OneDayTripNearTimes { get; }
        decimal OneDayTripNearAmount { get; }
        int OvernightTripTimes { get; }
        decimal OvernightTripAmount { get; }
        decimal OtherChargeAmount { get; }
        decimal TotalAmount { get; }
        decimal VATAmount { get; }  
        decimal GrandTotalAmount { get; }
        string AttachRemark { get; }
        string CustBizPacCode { get; }
    }
}
