using System;

namespace Entity.CommonEntity
{
	public enum IN_OUT_STATUS_TYPE
	{
		NULL,
		IN,
		OUT
	}

	public enum OT_RATE_TYPE
	{
		NULL,
		A,
		B,
		C
	}
	
	public enum WORKINGDAY_TYPE
	{
		NULL,
		WORKINGDAY,
		HOLIDAY
	}

	public enum PERIOD_TYPE
	{
		NULL,
		BEFORE_WORKINGTIME,
		BREAK_TIME,
		AFTER_WORKINGTIME,
		WORKINGTIME,
		ANYTIME
	}

	public enum WHOLE_RATE_TYPE
	{	
		NULL,
		ALLTAKE,
		PERTIME,
	}

	public enum PAYMENT_STATUS_TYPE
	{
		NULL,
		YES,
		NO,
	}

	public enum BENEFIT_CODE_TYPE
	{
		NULL,
		EXTRA,
		FOOD,
		TAXI,
		ONEDAY_TRIP,
		OVERNIGHT_TRIP
	}
	public enum HIRE_DATE_STATUS_TYPE
	{
		NULL,
		SINCE_HIRE,
		BEFORE_HIRE
	}
	public enum PAYROLL_SUBMIT_STATUS_TYPE
	{
		NULL,
		YES,
		NO
	}

	public enum BREAK_TYPE
	{
		NULL,
		ABS,
		NORMAL
	}
	public enum GEAR_TYPE
	{
		NULL,
		AUTO,
		MANUAL
	}
	public enum PLATE_STATUS
	{
		NULL,
		N,
		R
	}

	public enum ASSIGNMENT_ROLE_TYPE
	{
		NULL,
		MAIN,
		SPARE
	}

	public enum DOCUMENT_TYPE
	{
		NULL,
		ACCIDENT,
		CONTRACT,
		MAINTENANCE,
        BIZPAC_REF_NO,
        QUOTATION_VEHICLE,

        //Todsporn Modified 25/2/2020 PO. Discount
        LEASING_VEHICLE,
        PURCHASING_VEHICLE,

        //Add new type for D21018
        CONTRACT_RENEWAL,
        CONTRACT_TEMPORARY,
        CONTRACT_DRIVER

	}

	public enum EXPENSE_STATUS_TYPE
	{
		NULL,
		INSURANCE_COMPANY,
		COMPANY
	}

	public enum REPAIRING_TYPE
	{
		NULL,
		ACCIDENTR,
		MAINTENANCER
	}

	public enum SECOND_HAND_STATUS_TYPE
	{
		NULL,
		SECOND_HAND_YES,
		SECOND_HAND_NO
	}

	public enum PAYER_TYPE
	{
		NULL,
		CUSTOMER,
		PTB,
		EMPLOYEE,
        RESIGN
	}

	public enum RATE_STATUS_TYPE
	{
		NULL,
		MONTH,
		DAY
	}

	public enum ATTENDANCE_STATUS_TYPE
	{
		NULL, 
		HOLIDAY,
		LATE_AM,
		LATE_PM,
		WORKING	
	}

	public enum DISTANCE_TYPE
	{
		NULL,
		NEAR,
		FAR,
	}

	public enum LEAVE_PERIOD_TYPE
	{
		NULL,
		AM,
		PM,
		ONE_DAY
	}

	public enum PROCESS_STATUS_TYPE
	{
		NULL,
		NOT_RUN,
		RUNNING,
		FINISH
	}

	public enum LEAVE_YEAR_STATUS_TYPE
	{
		CURRENT,
		PREVIOUS,
		MIX,
	}

	public enum GENERATE_TYPE
	{
		TELEPHONE,
		EXTRA,
		OTHER
	}

    public enum VEHICLE_SPEC_CAR_STATUS_TYPE {
        NULL, OLD, NEW
    }

    public enum VEHICLE_USING_TYPE {
        NULL
    }

    public enum QUOTATION_RESPONSE_TYPE {
        NULL
    }

    public enum TAX_INVOICE_STATUS_TYPE
    {
        YES,
        NO,
        BLANK, 
        NULL
    }

    public enum DIFFERENCE_STATUS_TYPE
    {
        YES, 
        NO,
        NULL
    }

    public enum KIND_OF_RENTAL_TYPE
    {
        NEWCAR, 
        USEDCAR, 
        RENEWAL
    }

    public enum PURCHAS_STATUS_TYPE
    { 
        APPROVE, 
        CANCEL
    }

    public enum DRIVER_DEDUCT_STATUS
    {
        DRIVERONLY,
        DRIVERMATCH,
        DRIVERFAMILYMATCH,
        OTHER
    }

    public enum QUOTATION_STATUS_TYPE
    { 
        NEWQ,
        RENEWALQ, 
        USEDQ
    }

    public enum MEDICAL_AID_FOR
    { 
        OWNER,
        FAMILY,
        NULL
    }

    public enum MEDICAL_AID_LETTER
    { 
        YES,
        NO,
        NULL
    }   
}