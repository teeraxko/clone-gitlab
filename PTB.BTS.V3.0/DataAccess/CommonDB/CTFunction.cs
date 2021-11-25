using System;

using DataAccess.PiDB;
using DataAccess.ContractDB;
using DataAccess.VehicleDB;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.General;

namespace DataAccess.CommonDB
{
    internal class CTFunction 
    {
        public CTFunction()
        {
        }

        //----------------------------------------------------------------------------
        private const string IN = "IN";
        private const string OUT = "OUT";

        public static IN_OUT_STATUS_TYPE GetInOutStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case IN:
                    return IN_OUT_STATUS_TYPE.IN;
                case OUT:
                    return IN_OUT_STATUS_TYPE.OUT;
                default:
                    return IN_OUT_STATUS_TYPE.NULL;
            }
        }

        public static string GetString(IN_OUT_STATUS_TYPE value)
        {
            switch (value)
            {
                case IN_OUT_STATUS_TYPE.IN:
                    return IN;
                case IN_OUT_STATUS_TYPE.OUT:
                    return OUT;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------
        private const string CUSTOMER = "1";
        private const string PTB = "2";
        private const string EMPLOYEE = "3";
        private const string RESIGN = "4";

        public static PAYER_TYPE GetPayerType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case CUSTOMER:
                    return PAYER_TYPE.CUSTOMER;
                case PTB:
                    return PAYER_TYPE.PTB;
                case EMPLOYEE:
                    return PAYER_TYPE.EMPLOYEE;
                case RESIGN:
                    return PAYER_TYPE.RESIGN;
                default:
                    return PAYER_TYPE.NULL;
            }
        }

        public static string GetString(PAYER_TYPE value)
        {
            switch (value)
            {
                case PAYER_TYPE.CUSTOMER:
                    return CUSTOMER;
                case PAYER_TYPE.PTB:
                    return PTB;
                case PAYER_TYPE.EMPLOYEE:
                    return EMPLOYEE;
                case PAYER_TYPE.RESIGN:
                    return RESIGN;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------		
        private const string A = "A";
        private const string B = "B";
        private const string C = "C";

        public static OT_RATE_TYPE GetRateType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case A:
                    return OT_RATE_TYPE.A;
                case B:
                    return OT_RATE_TYPE.B;
                case C:
                    return OT_RATE_TYPE.C;
                default:
                    return OT_RATE_TYPE.NULL;
            }
        }

        public static string GetString(OT_RATE_TYPE value)
        {
            switch (value)
            {
                case OT_RATE_TYPE.A:
                    return A;
                case OT_RATE_TYPE.B:
                    return B;
                case OT_RATE_TYPE.C:
                    return C;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string WORKINGDAY = "W";
        private const string HOLIDAY = "H";

        public static WORKINGDAY_TYPE GetDayType(string value)
        {
            switch (value)
            {
                case WORKINGDAY:
                    return WORKINGDAY_TYPE.WORKINGDAY;
                case HOLIDAY:
                    return WORKINGDAY_TYPE.HOLIDAY;
                default:
                    return WORKINGDAY_TYPE.NULL;
            }
        }

        public static string GetString(WORKINGDAY_TYPE value)
        {
            switch (value)
            {
                case WORKINGDAY_TYPE.WORKINGDAY:
                    return WORKINGDAY;
                case WORKINGDAY_TYPE.HOLIDAY:
                    return HOLIDAY;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string BEFOREWORKINGTIME = "1";
        private const string BREAKTIME = "2";
        private const string AFTERWORKINGTIME = "3";
        private const string WORKINGTIME = "4";
        private const string ANYTIME = "9";

        public static PERIOD_TYPE GetPeriodType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case BEFOREWORKINGTIME:
                    return PERIOD_TYPE.BEFORE_WORKINGTIME;
                case BREAKTIME:
                    return PERIOD_TYPE.BREAK_TIME;
                case AFTERWORKINGTIME:
                    return PERIOD_TYPE.AFTER_WORKINGTIME;
                case WORKINGTIME:
                    return PERIOD_TYPE.WORKINGTIME;
                case ANYTIME:
                    return PERIOD_TYPE.ANYTIME;
                default:
                    return PERIOD_TYPE.NULL;
            }
        }

        public static string GetString(PERIOD_TYPE value)
        {
            switch (value)
            {
                case PERIOD_TYPE.BEFORE_WORKINGTIME:
                    return BEFOREWORKINGTIME;
                case PERIOD_TYPE.BREAK_TIME:
                    return BREAKTIME;
                case PERIOD_TYPE.AFTER_WORKINGTIME:
                    return AFTERWORKINGTIME;
                case PERIOD_TYPE.WORKINGTIME:
                    return WORKINGTIME;
                case PERIOD_TYPE.ANYTIME:
                    return ANYTIME;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string SHIFT_BLANK = " ";
        private const string NO1 = "1";
        private const string NO2 = "2";
        private const string NO3 = "3";

        public static SHIFT_TYPE GetShiftType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case SHIFT_BLANK:
                    return SHIFT_TYPE.BLANK;
                case NO1:
                    return SHIFT_TYPE.NO1;
                case NO2:
                    return SHIFT_TYPE.NO2;
                case NO3:
                    return SHIFT_TYPE.NO3;
                default:
                    return SHIFT_TYPE.NULL;
            }
        }

        public static string GetString(SHIFT_TYPE value)
        {
            switch (value)
            {
                case SHIFT_TYPE.BLANK:
                    return SHIFT_BLANK;
                case SHIFT_TYPE.NO1:
                    return NO1;
                case SHIFT_TYPE.NO2:
                    return NO2;
                case SHIFT_TYPE.NO3:
                    return NO3;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string ALLTAKE = "Y";
        private const string PERTIME = "N";

        public static WHOLE_RATE_TYPE GetWholeRateType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case ALLTAKE:
                    return WHOLE_RATE_TYPE.ALLTAKE;
                case PERTIME:
                    return WHOLE_RATE_TYPE.PERTIME;
                default:
                    return WHOLE_RATE_TYPE.NULL;
            }

        }

        public static string GetString(WHOLE_RATE_TYPE value)
        {
            switch (value)
            {
                case WHOLE_RATE_TYPE.ALLTAKE:
                    return ALLTAKE;
                case WHOLE_RATE_TYPE.PERTIME:
                    return PERTIME;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string Y = "Y";
        private const string N = "N";

        public static PAYMENT_STATUS_TYPE GetPaymentStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case Y:
                    return PAYMENT_STATUS_TYPE.YES;
                case N:
                    return PAYMENT_STATUS_TYPE.NO;
                default:
                    return PAYMENT_STATUS_TYPE.NULL;
            }

        }

        public static string GetString(PAYMENT_STATUS_TYPE value)
        {
            switch (value)
            {
                case PAYMENT_STATUS_TYPE.YES:
                    return Y;
                case PAYMENT_STATUS_TYPE.NO:
                    return N;
                default:
                    return NullConstant.STRING;
            }

        }

        //----------------------------------------------------------------------------	
        private const string EXTRA = "01";
        private const string FOOD = "02";
        private const string TAXI = "03";
        private const string ONEDAYTRIP = "04";
        private const string OVERNIGHTTRIP = "05";

        public static BENEFIT_CODE_TYPE GetBenefitCodeType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case EXTRA:
                    return BENEFIT_CODE_TYPE.EXTRA;
                case FOOD:
                    return BENEFIT_CODE_TYPE.FOOD;
                case TAXI:
                    return BENEFIT_CODE_TYPE.TAXI;
                case ONEDAYTRIP:
                    return BENEFIT_CODE_TYPE.ONEDAY_TRIP;
                case OVERNIGHTTRIP:
                    return BENEFIT_CODE_TYPE.OVERNIGHT_TRIP;
                default:
                    return BENEFIT_CODE_TYPE.NULL;
            }
        }

        public static string GetString(BENEFIT_CODE_TYPE value)
        {
            switch (value)
            {
                case BENEFIT_CODE_TYPE.EXTRA:
                    return EXTRA;
                case BENEFIT_CODE_TYPE.FOOD:
                    return FOOD;
                case BENEFIT_CODE_TYPE.TAXI:
                    return TAXI;
                case BENEFIT_CODE_TYPE.ONEDAY_TRIP:
                    return ONEDAYTRIP;
                case BENEFIT_CODE_TYPE.OVERNIGHT_TRIP:
                    return OVERNIGHTTRIP;
                default:
                    return NullConstant.STRING;
            }
        }
        //----------------------------------------------------------------------------	
        private const string SINCEHIREDATE = "1";
        private const string BEFOREHIREDATE = "2";


        public static HIRE_DATE_STATUS_TYPE GetHireDateStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case SINCEHIREDATE:
                    return HIRE_DATE_STATUS_TYPE.SINCE_HIRE;
                case BEFOREHIREDATE:
                    return HIRE_DATE_STATUS_TYPE.BEFORE_HIRE;

                default:
                    return HIRE_DATE_STATUS_TYPE.NULL;
            }
        }

        public static string GetString(HIRE_DATE_STATUS_TYPE value)
        {
            switch (value)
            {
                case HIRE_DATE_STATUS_TYPE.SINCE_HIRE:
                    return SINCEHIREDATE;
                case HIRE_DATE_STATUS_TYPE.BEFORE_HIRE:
                    return BEFOREHIREDATE;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string YES = "Y";
        private const string NO = "N";

        public static PAYROLL_SUBMIT_STATUS_TYPE GetPayrollSubmitStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case Y:
                    return PAYROLL_SUBMIT_STATUS_TYPE.YES;
                case N:
                    return PAYROLL_SUBMIT_STATUS_TYPE.NO;
                default:
                    return PAYROLL_SUBMIT_STATUS_TYPE.NULL;
            }
        }

        public static string GetString(PAYROLL_SUBMIT_STATUS_TYPE value)
        {
            switch (value)
            {
                case PAYROLL_SUBMIT_STATUS_TYPE.YES:
                    return Y;
                case PAYROLL_SUBMIT_STATUS_TYPE.NO:
                    return N;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string OTPERTIME = "1";
        private const string OTPERWHOLEMONTH = "2";

        public static KIND_OF_OT_TYPE GetKindOfOTType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case OTPERTIME:
                    return KIND_OF_OT_TYPE.PER_TIME;
                case OTPERWHOLEMONTH:
                    return KIND_OF_OT_TYPE.PER_WHOLE_MONTH;
                default:
                    return KIND_OF_OT_TYPE.NULL;
            }
        }

        public static string GetString(KIND_OF_OT_TYPE value)
        {
            switch (value)
            {
                case KIND_OF_OT_TYPE.PER_TIME:
                    return OTPERTIME;
                case KIND_OF_OT_TYPE.PER_WHOLE_MONTH:
                    return OTPERWHOLEMONTH;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string ABS = "A";
        private const string NORMAL = "N";

        public static BREAK_TYPE GetBreaktype(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case ABS:
                    return BREAK_TYPE.ABS;
                case NORMAL:
                    return BREAK_TYPE.NORMAL;
                default:
                    return BREAK_TYPE.NULL;
            }
        }

        public static string GetString(BREAK_TYPE value)
        {
            switch (value)
            {
                case BREAK_TYPE.ABS:
                    return ABS;
                case BREAK_TYPE.NORMAL:
                    return NORMAL;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string AUTO = "A";
        private const string MANUAL = "M";

        public static GEAR_TYPE GetGeartype(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case AUTO:
                    return GEAR_TYPE.AUTO;
                case MANUAL:
                    return GEAR_TYPE.MANUAL;
                default:
                    return GEAR_TYPE.NULL;
            }
        }

        public static string GetString(GEAR_TYPE value)
        {
            switch (value)
            {
                case GEAR_TYPE.AUTO:
                    return AUTO;
                case GEAR_TYPE.MANUAL:
                    return MANUAL;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string DRIVER = "D";
        private const string MACHANIC = "M";
        private const string BLANK = " ";

        public static POSITION_ROLE_TYPE GetPositionRoleType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case DRIVER:
                    return POSITION_ROLE_TYPE.DRIVER;
                case MACHANIC:
                    return POSITION_ROLE_TYPE.MACHANIC;
                case BLANK:
                    return POSITION_ROLE_TYPE.BLANK;
                default:
                    return POSITION_ROLE_TYPE.NULL;
            }
        }

        public static string GetString(POSITION_ROLE_TYPE value)
        {
            switch (value)
            {
                case POSITION_ROLE_TYPE.DRIVER:
                    return DRIVER;
                case POSITION_ROLE_TYPE.MACHANIC:
                    return MACHANIC;
                case POSITION_ROLE_TYPE.BLANK:
                    return BLANK;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string RED = "R";
        private const string NORMALPLATE = "N";

        public static PLATE_STATUS GetPlatestatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case RED:
                    return PLATE_STATUS.R;
                case NORMALPLATE:
                    return PLATE_STATUS.N;
                default:
                    return PLATE_STATUS.NULL;
            }
        }

        public static string GetString(PLATE_STATUS value)
        {
            switch (value)
            {
                case PLATE_STATUS.R:
                    return RED;
                case PLATE_STATUS.N:
                    return NORMALPLATE;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string MALE = "M";
        private const string FEMALE = "F";

        public static GENDER_TYPE GetGenderType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case MALE:
                    return GENDER_TYPE.MALE;
                case FEMALE:
                    return GENDER_TYPE.FEMALE;
                default:
                    return GENDER_TYPE.NULL;
            }
        }

        public static string GetString(GENDER_TYPE value)
        {
            switch (value)
            {
                case GENDER_TYPE.MALE:
                    return MALE;
                case GENDER_TYPE.FEMALE:
                    return FEMALE;
                default:
                    return NullConstant.STRING;
            }

        }

        //----------------------------------------------------------------------------	
        private const string PERSONAL_CAR_BLANK = " ";
        private const string PERSONAL_CAR = "1";
        private const string LICENSE_CAR_TYPE2 = "2";
        private const string LICENSE_CAR_TYPE3 = "3";
        private const string PUBLIC_CAR = "4";
        private const string LICENSE_CAR_TYPE4 = "5";

        public static DRIVER_LICENSE_TYPE GetDriverLicenceType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case PERSONAL_CAR_BLANK:
                    return DRIVER_LICENSE_TYPE.PERSONAL_CAR_BLANK;
                case PERSONAL_CAR:
                    return DRIVER_LICENSE_TYPE.PERSONAL_CAR;
                case LICENSE_CAR_TYPE2:
                    return DRIVER_LICENSE_TYPE.LICENSE_CAR_TYPE2;
                case LICENSE_CAR_TYPE3:
                    return DRIVER_LICENSE_TYPE.LICENSE_CAR_TYPE3;
                case PUBLIC_CAR:
                    return DRIVER_LICENSE_TYPE.PUBLIC_CAR;
                case LICENSE_CAR_TYPE4:
                    return DRIVER_LICENSE_TYPE.LICENSE_CAR_TYPE4;
                default:
                    return DRIVER_LICENSE_TYPE.NULL;
            }
        }

        public static string GetString(DRIVER_LICENSE_TYPE value)
        {
            switch (value)
            {
                case DRIVER_LICENSE_TYPE.PERSONAL_CAR_BLANK:
                    return PERSONAL_CAR_BLANK;
                case DRIVER_LICENSE_TYPE.PERSONAL_CAR:
                    return PERSONAL_CAR;
                case DRIVER_LICENSE_TYPE.LICENSE_CAR_TYPE2:
                    return LICENSE_CAR_TYPE2;
                case DRIVER_LICENSE_TYPE.LICENSE_CAR_TYPE3:
                    return LICENSE_CAR_TYPE3;
                case DRIVER_LICENSE_TYPE.PUBLIC_CAR:
                    return PUBLIC_CAR;
                case DRIVER_LICENSE_TYPE.LICENSE_CAR_TYPE4:
                    return LICENSE_CAR_TYPE4;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string MAIN = "M";
        private const string SPARE = "S";

        public static ASSIGNMENT_ROLE_TYPE GetAssignmentRoleType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case MAIN:
                    return ASSIGNMENT_ROLE_TYPE.MAIN;
                case SPARE:
                    return ASSIGNMENT_ROLE_TYPE.SPARE;
                default:
                    return ASSIGNMENT_ROLE_TYPE.NULL;
            }
        }

        public static string GetString(ASSIGNMENT_ROLE_TYPE value)
        {
            switch (value)
            {
                case ASSIGNMENT_ROLE_TYPE.MAIN:
                    return MAIN;
                case ASSIGNMENT_ROLE_TYPE.SPARE:
                    return SPARE;
                default:
                    return NullConstant.STRING;
            }

        }

        //----------------------------------------------------------------------------	
        private const string ACCIDENT = "A";
        private const string CONTRACT = "C";
        private const string MAINTENANCE = "M";
        private const string BIZPAC_REF_NO = "Z";
        private const string QUOTATION_VEHICLE = "Q";
        private const string LEASING_VEHICLE = "L";
        private const string PURCHASING_VEHICLE = "P";

        public static DOCUMENT_TYPE GetDocumentType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case ACCIDENT:
                    return DOCUMENT_TYPE.ACCIDENT;
                case CONTRACT:
                    return DOCUMENT_TYPE.CONTRACT;
                case MAINTENANCE:
                    return DOCUMENT_TYPE.MAINTENANCE;
                case BIZPAC_REF_NO:
                    return DOCUMENT_TYPE.BIZPAC_REF_NO;
                case QUOTATION_VEHICLE:
                    return DOCUMENT_TYPE.QUOTATION_VEHICLE;
                //Todsporn Modified 25/2/2020 PO. Discount 
                case LEASING_VEHICLE:
                    return DOCUMENT_TYPE.QUOTATION_VEHICLE;
                case PURCHASING_VEHICLE:
                    return DOCUMENT_TYPE.PURCHASING_VEHICLE;
                default:
                    return DOCUMENT_TYPE.NULL;
            }
        }

        public static string GetString(DOCUMENT_TYPE value)
        {

            //Todsporn Modified 25/2/2020 PO. Discount
            switch (value)
            {
                case DOCUMENT_TYPE.ACCIDENT:
                    return ACCIDENT;
                case DOCUMENT_TYPE.CONTRACT:
                    return CONTRACT;
                case DOCUMENT_TYPE.MAINTENANCE:
                    return MAINTENANCE;
                case DOCUMENT_TYPE.BIZPAC_REF_NO:
                    return BIZPAC_REF_NO;
                case DOCUMENT_TYPE.QUOTATION_VEHICLE:
                    return QUOTATION_VEHICLE;

                //Todsporn Modified 25/2/2020 PO. Discount
                case DOCUMENT_TYPE.LEASING_VEHICLE:

                    return QUOTATION_VEHICLE;
                case DOCUMENT_TYPE.PURCHASING_VEHICLE:
                    return PURCHASING_VEHICLE;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string REGIST = "1";
        private const string SUPPORT = "2";

        public static EDUCATION_STATUS_TYPE GetEducationStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case REGIST:
                    return EDUCATION_STATUS_TYPE.REGIST;
                case SUPPORT:
                    return EDUCATION_STATUS_TYPE.SUPPORT;
                default:
                    return EDUCATION_STATUS_TYPE.NULL;
            }
        }

        public static string GetString(EDUCATION_STATUS_TYPE value)
        {
            switch (value)
            {
                case EDUCATION_STATUS_TYPE.REGIST:
                    return REGIST;
                case EDUCATION_STATUS_TYPE.SUPPORT:
                    return SUPPORT;
                default:
                    return NullConstant.STRING;
            }

        }

        //----------------------------------------------------------------------------	
        private const string INSURANCE_COMPANY = "I";
        private const string COMPANY = "C";

        public static EXPENSE_STATUS_TYPE GetExpenseStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case INSURANCE_COMPANY:
                    return EXPENSE_STATUS_TYPE.INSURANCE_COMPANY;
                case COMPANY:
                    return EXPENSE_STATUS_TYPE.COMPANY;
                default:
                    return EXPENSE_STATUS_TYPE.NULL;
            }
        }

        public static string GetString(EXPENSE_STATUS_TYPE value)
        {
            switch (value)
            {
                case EXPENSE_STATUS_TYPE.INSURANCE_COMPANY:
                    return INSURANCE_COMPANY;
                case EXPENSE_STATUS_TYPE.COMPANY:
                    return COMPANY;
                default:
                    return NullConstant.STRING;
            }

        }

        //----------------------------------------------------------------------------	
        private const string ACCIDENTR = "A";
        private const string MAINTENANCER = "M";

        public static REPAIRING_TYPE GetRepairingType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case ACCIDENTR:
                    return REPAIRING_TYPE.ACCIDENTR;
                case MAINTENANCER:
                    return REPAIRING_TYPE.MAINTENANCER;
                default:
                    return REPAIRING_TYPE.NULL;
            }
        }

        public static string GetString(REPAIRING_TYPE value)
        {
            switch (value)
            {
                case REPAIRING_TYPE.ACCIDENTR:
                    return ACCIDENTR;
                case REPAIRING_TYPE.MAINTENANCER:
                    return MAINTENANCER;
                default:
                    return NullConstant.STRING;
            }

        }

        //----------------------------------------------------------------------------	
        private const string SECOND_HAND_YES = "Y";
        private const string SECOND_HAND_NO = "N";

        public static SECOND_HAND_STATUS_TYPE GetSecondHandStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case SECOND_HAND_YES:
                    return SECOND_HAND_STATUS_TYPE.SECOND_HAND_YES;
                case SECOND_HAND_NO:
                    return SECOND_HAND_STATUS_TYPE.SECOND_HAND_NO;
                default:
                    return SECOND_HAND_STATUS_TYPE.NULL;
            }
        }

        public static string GetString(SECOND_HAND_STATUS_TYPE value)
        {
            switch (value)
            {
                case SECOND_HAND_STATUS_TYPE.SECOND_HAND_YES:
                    return SECOND_HAND_YES;
                case SECOND_HAND_STATUS_TYPE.SECOND_HAND_NO:
                    return SECOND_HAND_NO;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string MONTH = "M";
        private const string DAY = "D";

        public static RATE_STATUS_TYPE GetRateStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case MONTH:
                    return RATE_STATUS_TYPE.MONTH;
                case DAY:
                    return RATE_STATUS_TYPE.DAY;
                default:
                    return RATE_STATUS_TYPE.NULL;
            }
        }

        public static string GetString(RATE_STATUS_TYPE value)
        {
            switch (value)
            {
                case RATE_STATUS_TYPE.MONTH:
                    return MONTH;
                case RATE_STATUS_TYPE.DAY:
                    return DAY;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string AM = "A";
        private const string PM = "P";
        private const string ONE_DAY = "O";

        public static LEAVE_PERIOD_TYPE GetLeavePeriodType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case AM:
                    return LEAVE_PERIOD_TYPE.AM;
                case PM:
                    return LEAVE_PERIOD_TYPE.PM;
                case ONE_DAY:
                    return LEAVE_PERIOD_TYPE.ONE_DAY;
                default:
                    return LEAVE_PERIOD_TYPE.NULL;
            }
        }

        public static string GetString(LEAVE_PERIOD_TYPE value)
        {
            switch (value)
            {
                case LEAVE_PERIOD_TYPE.AM:
                    return AM;
                case LEAVE_PERIOD_TYPE.PM:
                    return PM;
                case LEAVE_PERIOD_TYPE.ONE_DAY:
                    return ONE_DAY;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string NOT_RUN = "1";
        private const string RUNNING = "2";
        private const string FINISH = "3";

        public static PROCESS_STATUS_TYPE GetProcessStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case NOT_RUN:
                    return PROCESS_STATUS_TYPE.NOT_RUN;
                case RUNNING:
                    return PROCESS_STATUS_TYPE.RUNNING;
                case FINISH:
                    return PROCESS_STATUS_TYPE.FINISH;
                default:
                    return PROCESS_STATUS_TYPE.NULL;
            }
        }

        public static string GetString(PROCESS_STATUS_TYPE value)
        {
            switch (value)
            {
                case PROCESS_STATUS_TYPE.NOT_RUN:
                    return NOT_RUN;
                case PROCESS_STATUS_TYPE.RUNNING:
                    return RUNNING;
                case PROCESS_STATUS_TYPE.FINISH:
                    return FINISH;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private static PositionTypeList positionTypeList;
        public static PositionType GetPositionType(string value)
        {
            if (positionTypeList == null)
            {
                PositionTypeDB dbPositionType = new PositionTypeDB();
                Company company = new Company("12");
                positionTypeList = new PositionTypeList(company);
                dbPositionType.FillPositionTypeList(ref positionTypeList);
            }
            return positionTypeList[value];
        }

        public static string GetString(PositionType value)
        {
            return value.Type;
        }

        //----------------------------------------------------------------------------	
        private static VehicleStatusList vehicleStatusList;
        public static VehicleStatus GetVehicleStatasType(string value)
        {
            if (vehicleStatusList == null)
            {
                VehicleStatusDB dbVehicleStatus = new VehicleStatusDB();
                Company company = new Company("12");
                vehicleStatusList = new VehicleStatusList(company);
                dbVehicleStatus.FillMTBList(vehicleStatusList);
            }
            return (VehicleStatus)vehicleStatusList[value];
        }

        public static string GetString(VehicleStatus value)
        {
            return value.Code;
        }

        //----------------------------------------------------------------------------	
        private static KindOfVehicleList kindOfVehicleList;
        public static KindOfVehicle GetKindOfVehicleType(string value)
        {
            if (kindOfVehicleList == null)
            {
                KindOfVehicleDB dbKindOfVehicle = new KindOfVehicleDB();
                Company company = new Company("12");
                kindOfVehicleList = new KindOfVehicleList(company);
                dbKindOfVehicle.FillMTBList(kindOfVehicleList);
            }
            return (KindOfVehicle)kindOfVehicleList[value];
        }

        public static string GetString(KindOfVehicle value)
        {
            return value.Code;
        }

        //----------------------------------------------------------------------------	
        private static ContractStatusList contractStatusList;
        public static ContractStatus GetContractstatusType(string value)
        {
            if (contractStatusList == null)
            {
                ContractStatusDB dbContractStatus = new ContractStatusDB();
                Company company = new Company("12");
                contractStatusList = new ContractStatusList(company);
                dbContractStatus.FillMTBList(contractStatusList);
            }
            return (ContractStatus)contractStatusList[value];
        }

        public static string GetString(ContractStatus value)
        {
            return value.Code;
        }

        //----------------------------------------------------------------------------	
        private static ContractTypeList contractTypeList;
        public static ContractType GetContractType(string value)
        {
            if (contractTypeList == null)
            {
                ContractTypeDB dbContractType = new ContractTypeDB();
                Company company = new Company("12");
                contractTypeList = new ContractTypeList(company);
                dbContractType.FillMTBList(contractTypeList);
            }
            return (ContractType)contractTypeList[value];
        }

        public static string GetString(ContractType value)
        {
            return value.Code;
        }

        //----------------------------------------------------------------------------	
        private static KindOfContractList kindOfContractList;
        public static KindOfContract GetKindOfContractType(string value)
        {
            if (kindOfContractList == null)
            {
                KindOfContractDB dbKindOfContract = new KindOfContractDB();
                Company company = new Company("12");
                kindOfContractList = new KindOfContractList(company);
                dbKindOfContract.FillMTBList(kindOfContractList);
            }
            return (KindOfContract)kindOfContractList[value];
        }

        public static string GetString(KindOfContract value)
        {
            return value.Code;
        }

        //----------------------------------------------------------------------------	
        private const string CURRENT = "C";
        private const string PREVIOUS = "P";
        private const string MIX = "M";

        public static LEAVE_YEAR_STATUS_TYPE GetLeaveYearStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case CURRENT:
                    return LEAVE_YEAR_STATUS_TYPE.CURRENT;
                case PREVIOUS:
                    return LEAVE_YEAR_STATUS_TYPE.PREVIOUS;
                default:
                    return LEAVE_YEAR_STATUS_TYPE.MIX;
            }
        }

        public static string GetString(LEAVE_YEAR_STATUS_TYPE value)
        {
            switch (value)
            {
                case LEAVE_YEAR_STATUS_TYPE.CURRENT:
                    return CURRENT;
                case LEAVE_YEAR_STATUS_TYPE.PREVIOUS:
                    return PREVIOUS;
                default:
                    return MIX;
            }
        }

        //----------------------------------------------------------------------------	
        private const string TAX_INVOICE_STATUS_YES = "Y";
        private const string TAX_INVOICE_STATUS_NO = "N";
        private const string TAX_INVOICE_STATUS_BLANK = " ";

        public static TAX_INVOICE_STATUS_TYPE GetTaxInvoiceStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case TAX_INVOICE_STATUS_YES:
                    return TAX_INVOICE_STATUS_TYPE.YES;
                case TAX_INVOICE_STATUS_NO:
                    return TAX_INVOICE_STATUS_TYPE.NO;
                case TAX_INVOICE_STATUS_BLANK:
                    return TAX_INVOICE_STATUS_TYPE.BLANK;
                default:
                    return TAX_INVOICE_STATUS_TYPE.NULL;
            }
        }

        public static string GetString(TAX_INVOICE_STATUS_TYPE value)
        {
            switch (value)
            {
                case TAX_INVOICE_STATUS_TYPE.YES:
                    return TAX_INVOICE_STATUS_YES;
                case TAX_INVOICE_STATUS_TYPE.NO:
                    return TAX_INVOICE_STATUS_NO;
                case TAX_INVOICE_STATUS_TYPE.BLANK:
                    return TAX_INVOICE_STATUS_BLANK;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string DIFFERENCE_STATUS_YES = "Y";
        private const string DIFFERENCE_STATUS_NO = "N";

        public static DIFFERENCE_STATUS_TYPE GetDifferenceStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case DIFFERENCE_STATUS_YES:
                    return DIFFERENCE_STATUS_TYPE.YES;
                case DIFFERENCE_STATUS_NO:
                    return DIFFERENCE_STATUS_TYPE.NO;
                default:
                    return DIFFERENCE_STATUS_TYPE.NULL;
            }
        }

        public static string GetString(DIFFERENCE_STATUS_TYPE value)
        {
            switch (value)
            {
                case DIFFERENCE_STATUS_TYPE.YES:
                    return DIFFERENCE_STATUS_YES;
                case DIFFERENCE_STATUS_TYPE.NO:
                    return DIFFERENCE_STATUS_NO;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string NEWCAR = "0";
        private const string USEDCAR = "1";
        private const string RENEWAL = "2";

        public static KIND_OF_RENTAL_TYPE GetKindOfRantalType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case NEWCAR:
                    return KIND_OF_RENTAL_TYPE.NEWCAR;
                case RENEWAL:
                    return KIND_OF_RENTAL_TYPE.RENEWAL;
                case USEDCAR:
                    return KIND_OF_RENTAL_TYPE.USEDCAR;
                default:
                    return KIND_OF_RENTAL_TYPE.NEWCAR;
            }
        }

        public static string GetString(KIND_OF_RENTAL_TYPE value)
        {
            switch (value)
            {
                case KIND_OF_RENTAL_TYPE.NEWCAR:
                    return NEWCAR;
                case KIND_OF_RENTAL_TYPE.USEDCAR:
                    return USEDCAR;
                case KIND_OF_RENTAL_TYPE.RENEWAL:
                    return RENEWAL;
                default:
                    return NullConstant.STRING;
            }
        }

        //----------------------------------------------------------------------------	
        private const string APPROVE = "A";
        private const string CANCEL = "C";

        public static PURCHAS_STATUS_TYPE GetPurchasStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case APPROVE:
                    return PURCHAS_STATUS_TYPE.APPROVE;
                case CANCEL:
                    return PURCHAS_STATUS_TYPE.CANCEL;
                default:
                    return PURCHAS_STATUS_TYPE.APPROVE;
            }
        }

        public static string GetString(PURCHAS_STATUS_TYPE value)
        {
            switch (value)
            {
                case PURCHAS_STATUS_TYPE.APPROVE:
                    return APPROVE;
                case PURCHAS_STATUS_TYPE.CANCEL:
                    return CANCEL;
                default:
                    return APPROVE;
            }
        }

        //----------------------------------------------------------------------------	
        private const string DRIVERFAMILYMATCH = "B";
        private const string DRIVERMATCH = "M";
        private const string DRIVERONLY = "D";
        private const string OTHER = "O";

        public static DRIVER_DEDUCT_STATUS GetDriverDeductStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case DRIVERFAMILYMATCH:
                    return DRIVER_DEDUCT_STATUS.DRIVERFAMILYMATCH;
                case DRIVERMATCH:
                    return DRIVER_DEDUCT_STATUS.DRIVERMATCH;
                case DRIVERONLY:
                    return DRIVER_DEDUCT_STATUS.DRIVERONLY;
                default:
                    return DRIVER_DEDUCT_STATUS.OTHER;
            }
        }

        public static string GetString(DRIVER_DEDUCT_STATUS value)
        {
            switch (value)
            {
                case DRIVER_DEDUCT_STATUS.DRIVERFAMILYMATCH:
                    return DRIVERFAMILYMATCH;
                case DRIVER_DEDUCT_STATUS.DRIVERMATCH:
                    return DRIVERMATCH;
                case DRIVER_DEDUCT_STATUS.DRIVERONLY:
                    return DRIVERONLY;
                default:
                    return OTHER;
            }
        }

        //----------------------------------------------------------------------------	
        private const string NEWQ = "N";
        private const string RENEWALQ = "R";
        private const string USEDQ = "U";

        public static QUOTATION_STATUS_TYPE GetQuotationStatusType(string value)
        {
            switch (value.ToUpper().Trim())
            {
                case NEWQ:
                    return QUOTATION_STATUS_TYPE.NEWQ;
                case RENEWALQ:
                    return QUOTATION_STATUS_TYPE.RENEWALQ;
                case USEDQ:
                    return QUOTATION_STATUS_TYPE.USEDQ;
                default:
                    return QUOTATION_STATUS_TYPE.NEWQ;
            }
        }

        public static string GetString(QUOTATION_STATUS_TYPE value)
        {
            switch (value)
            {
                case QUOTATION_STATUS_TYPE.NEWQ:
                    return NEWQ;
                case QUOTATION_STATUS_TYPE.RENEWALQ:
                    return RENEWALQ;
                case QUOTATION_STATUS_TYPE.USEDQ:
                    return USEDQ;
                default:
                    return NEWQ;
            }
        }
    }
}