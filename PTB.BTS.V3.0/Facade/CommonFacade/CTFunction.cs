using System;
using System.Collections;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities;

namespace Facade.CommonFacade
{
	public class CTFunction
	{
		public CTFunction()
		{
		}

		public static string GetString(string value)
		{
			return value;
		}
		//----------------------------------------------------------------------------
		private const string IN = "���";
		private const string OUT = "�͡";

		public String[] InOutStatusArray = {IN,OUT};

		public static IN_OUT_STATUS_TYPE GetInOutStatusType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case IN : 
					return IN_OUT_STATUS_TYPE.IN;
				case OUT : 
					return IN_OUT_STATUS_TYPE.OUT;
				default :
					return IN_OUT_STATUS_TYPE.NULL;
			}
		}

		public static string GetString(IN_OUT_STATUS_TYPE value)
		{
			switch (value)
			{
				case IN_OUT_STATUS_TYPE.IN : 
					return IN;
				case IN_OUT_STATUS_TYPE.OUT : 
					return OUT;
				default :
					return NullConstant.STRING;
			}
		}
		//----------------------------------------------------------------------------		
		private const string A = "A";
		private const string B = "B";
		private const string C = "C";

		public String[] OTRateTypeArray = {A, B, C};

		public static OT_RATE_TYPE GetRateType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case A : 
					return OT_RATE_TYPE.A;
				case B : 
					return OT_RATE_TYPE.B;
				case C :
					return OT_RATE_TYPE.C;
				default :
					return OT_RATE_TYPE.NULL;
			}
		}

		public static string GetString(OT_RATE_TYPE value)
		{
			switch (value)
			{
				case OT_RATE_TYPE.A : 
					return A;
				case OT_RATE_TYPE.B : 
					return B;
				case OT_RATE_TYPE.C : 
					return C;
				default :
					return NullConstant.STRING;
			}
		}
		//----------------------------------------------------------------------------	
		private const string WORKINGDAY = "�ѹ�ӧҹ";
		private const string HOLIDAY = "�ѹ��ش";

		public String[] OTDayTypeArray = {WORKINGDAY, HOLIDAY};

		public static WORKINGDAY_TYPE GetDayType(string value)
		{
			switch (value)
			{
				case WORKINGDAY : 
					return WORKINGDAY_TYPE.WORKINGDAY;
				case HOLIDAY : 
					return WORKINGDAY_TYPE.HOLIDAY;
				default :
					return WORKINGDAY_TYPE.NULL;
			}
		}

		public static string GetString(WORKINGDAY_TYPE value)
		{
			switch (value)
			{
				case WORKINGDAY_TYPE.WORKINGDAY: 
					return WORKINGDAY;
				case WORKINGDAY_TYPE.HOLIDAY : 
					return HOLIDAY;
				default :
					return NullConstant.STRING;
			}
		}
		//----------------------------------------------------------------------------	
		private const string BEFOREWORKINGTIME = "��͹���ҷӧҹ";
		private const string BREAKTIME = "���Ҿѡ";
		private const string AFTERWORKINGTIME = "��ѧ���ҷӧҹ";
		private const string WORKINGTIME = "���ҷӧҹ";
		private const string ANYTIME = "�ء��ǧ";

		public String[] PeriodTypeArray = {BEFOREWORKINGTIME, BREAKTIME, AFTERWORKINGTIME, WORKINGTIME, ANYTIME};

		public static PERIOD_TYPE GetPeriodType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case BEFOREWORKINGTIME : 
					return PERIOD_TYPE.BEFORE_WORKINGTIME;
				case BREAKTIME : 
					return PERIOD_TYPE.BREAK_TIME;
				case AFTERWORKINGTIME :
					return PERIOD_TYPE.AFTER_WORKINGTIME;
				case WORKINGTIME :
					return PERIOD_TYPE.WORKINGTIME;
				case ANYTIME :
					return PERIOD_TYPE.ANYTIME;
				default :
					return PERIOD_TYPE.NULL;
			}
		}

		public static string GetString(PERIOD_TYPE value)
		{
			switch (value)
			{
				case PERIOD_TYPE.BEFORE_WORKINGTIME: 
					return BEFOREWORKINGTIME;
				case PERIOD_TYPE.BREAK_TIME : 
					return BREAKTIME;
				case PERIOD_TYPE.AFTER_WORKINGTIME : 
					return AFTERWORKINGTIME;
				case PERIOD_TYPE.WORKINGTIME : 
					return WORKINGTIME;
				case PERIOD_TYPE.ANYTIME:
					return ANYTIME;
				default :
					return NullConstant.STRING;
			}
		}
		//----------------------------------------------------------------------------	
		private const string SHIFT_BLANK = " ";
		private const string NO1 = "1";
		private const string NO2 = "2";
		private const string NO3 = "3";

		public String[] ShiftTypeArray = {SHIFT_BLANK, NO1, NO2, NO3};

		public static SHIFT_TYPE GetShiftType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case SHIFT_BLANK : 
					return SHIFT_TYPE.BLANK;
				case NO1 : 
					return SHIFT_TYPE.NO1;
				case NO2 : 
					return SHIFT_TYPE.NO2;
				case NO3 : 
					return SHIFT_TYPE.NO3;
				default : 
					return SHIFT_TYPE.NULL;
			}
		}

		public static string GetString(SHIFT_TYPE value)
		{
			switch (value)
			{
				case SHIFT_TYPE.BLANK : 
					return SHIFT_BLANK;
				case SHIFT_TYPE.NO1 : 
					return NO1;
				case SHIFT_TYPE.NO2 : 
					return NO2;
				case SHIFT_TYPE.NO3 : 
					return NO3;
				default : 
					return NullConstant.STRING;
			}
		}
		//----------------------------------------------------------------------------	
		private const string ALLTAKE = "���Ҩ���";
		private const string PERTIME = "��ͤ���";

		public String[] WholeRateArray = {ALLTAKE, PERTIME};

		public static WHOLE_RATE_TYPE GetWholeRate(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case ALLTAKE : 
					return WHOLE_RATE_TYPE.ALLTAKE;
				case PERTIME : 
					return WHOLE_RATE_TYPE.PERTIME;
				default : 
					return WHOLE_RATE_TYPE.NULL;
			}
		}

		public static string GetString(WHOLE_RATE_TYPE value)
		{
			switch (value)
			{
				case WHOLE_RATE_TYPE.ALLTAKE : 
					return ALLTAKE;
				case WHOLE_RATE_TYPE.PERTIME : 
					return PERTIME;
				default : 
					return NullConstant.STRING;
			}
		}

		//----------------------------------------------------------------------------	
		private const string Y = "YES";
		private const string N = "NO";

		public String[] PaymentStatusTypeArray = {Y, N};


		public static PAYMENT_STATUS_TYPE GetPaymentStatusType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case Y : 
					return PAYMENT_STATUS_TYPE.YES;
				case N : 
					return PAYMENT_STATUS_TYPE.NO;
				default : 
					return PAYMENT_STATUS_TYPE.NULL;
			}
			
		}

		public static string GetString(PAYMENT_STATUS_TYPE value)
		{
			switch (value)
			{
				case PAYMENT_STATUS_TYPE.YES : 
					return Y;
				case PAYMENT_STATUS_TYPE.NO : 
					return N;
				default : 
					return NullConstant.STRING;
			}
			
		}

		//----------------------------------------------------------------------------	
		private const string EXTRA = "���¢�ѹ";
		private const string FOOD = "��������";
		private const string TAXI = "����ꡫ��";
		private const string ONEDAYTRIP = "����Թ�ҧ���� 1 �ѹ";
		private const string OVERNIGHTTRIP = "����Թ�ҧ�óդ�ҧ�׹";

		public String[] BenefitCodeTypeArray = {EXTRA, FOOD, TAXI, ONEDAYTRIP, OVERNIGHTTRIP};

		public static BENEFIT_CODE_TYPE GetBenefitCodeType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case EXTRA:
					return BENEFIT_CODE_TYPE.EXTRA;
				case FOOD : 
					return BENEFIT_CODE_TYPE.FOOD;
				case TAXI :
					return BENEFIT_CODE_TYPE.TAXI;
				case ONEDAYTRIP : 
					return BENEFIT_CODE_TYPE.ONEDAY_TRIP;
				case OVERNIGHTTRIP :
					return BENEFIT_CODE_TYPE.OVERNIGHT_TRIP;
				default :
					return BENEFIT_CODE_TYPE.NULL;
			}
		}

		public static string GetString(BENEFIT_CODE_TYPE value)
		{
			switch (value)
			{
				case BENEFIT_CODE_TYPE.EXTRA: 
					return EXTRA;
				case BENEFIT_CODE_TYPE.FOOD : 
					return FOOD;
				case BENEFIT_CODE_TYPE.TAXI: 
					return TAXI;
				case BENEFIT_CODE_TYPE.ONEDAY_TRIP : 
					return ONEDAYTRIP;
				case BENEFIT_CODE_TYPE.OVERNIGHT_TRIP: 
					return OVERNIGHTTRIP;
				default :
					return NullConstant.STRING;
			}
		}
		//----------------------------------------------------------------------------	
		private const string SINCEHIREDATE = "Since Hire Date";
		private const string BEFOREHIREDATE = "Before Hire Date";

		public String[] HireDateStatusTypeArray = {SINCEHIREDATE, BEFOREHIREDATE};


		public static HIRE_DATE_STATUS_TYPE GetHireDateStatusType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case SINCEHIREDATE:
					return HIRE_DATE_STATUS_TYPE.SINCE_HIRE;
				case BEFOREHIREDATE : 
					return HIRE_DATE_STATUS_TYPE.BEFORE_HIRE;
				
				default :
					return HIRE_DATE_STATUS_TYPE.NULL;
			}
		}

		public static string GetString(HIRE_DATE_STATUS_TYPE value)
		{
			switch (value)
			{
				case HIRE_DATE_STATUS_TYPE.SINCE_HIRE: 
					return SINCEHIREDATE;
				case HIRE_DATE_STATUS_TYPE.BEFORE_HIRE : 
					return BEFOREHIREDATE;
				default :
					return NullConstant.STRING;
			}
		}

		//----------------------------------------------------------------------------	
		private const string YES = "YES";
		private const string NO = "NO";

		public String[] PayrollSubmitStatusTypeArray = {YES, NO};


		public static PAYROLL_SUBMIT_STATUS_TYPE GetPayrollSubmitStatusType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case Y : 
					return PAYROLL_SUBMIT_STATUS_TYPE.YES;
				case N : 
					return PAYROLL_SUBMIT_STATUS_TYPE.NO;
				default : 
					return PAYROLL_SUBMIT_STATUS_TYPE.NULL;
			}
			
		}

		public static string GetString(PAYROLL_SUBMIT_STATUS_TYPE value)
		{
			switch (value)
			{
				case PAYROLL_SUBMIT_STATUS_TYPE.YES : 
					return Y;
				case PAYROLL_SUBMIT_STATUS_TYPE.NO : 
					return N;
				default : 
					return NullConstant.STRING;
			}
			
		}
		
		//----------------------------------------------------------------------------	
		private const string OTPERTIME = "���µ����ԧ";
		private const string OTPERWHOLEMONTH = "���Ҩ���";

		public String[] KindOfOTTypeArray = {OTPERTIME, OTPERWHOLEMONTH};


		public static KIND_OF_OT_TYPE GetKindOfOTType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case OTPERTIME : 
					return KIND_OF_OT_TYPE.PER_TIME;
				case OTPERWHOLEMONTH : 
					return KIND_OF_OT_TYPE.PER_WHOLE_MONTH;
				default : 
					return KIND_OF_OT_TYPE.NULL;
			}
			
		}

		public static string GetString(KIND_OF_OT_TYPE value)
		{
			switch (value)
			{
				case KIND_OF_OT_TYPE.PER_TIME : 
					return OTPERTIME;
				case KIND_OF_OT_TYPE.PER_WHOLE_MONTH : 
					return OTPERWHOLEMONTH;
				default : 
					return NullConstant.STRING;
			}
			
		}
		//----------------------------------------------------------------------------	
		
		private const string ABS = "�ä�ͺ����";
		private const string NORMAL = "�ä������";

		public String[] BreakTypeArray = {ABS, NORMAL};


		public static BREAK_TYPE GetBreakType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case ABS : 
					return BREAK_TYPE.ABS;
				case NORMAL : 
					return BREAK_TYPE.NORMAL;
				default : 
					return BREAK_TYPE.NULL;
			}
			
		}

		public static string GetString(BREAK_TYPE value)
		{
			switch (value)
			{
				case BREAK_TYPE.ABS : 
					return ABS;
				case BREAK_TYPE.NORMAL : 
					return NORMAL;
				default : 
					return NullConstant.STRING;
			}
			
		}
		//----------------------------------------------------------------------------	
		private const string AUTO = "������ѵ��ѵ�";
		private const string MANUAL = "����������";

		public String[] GearTypeArray = {AUTO, MANUAL};


		public static GEAR_TYPE GetGearType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case AUTO : 
					return GEAR_TYPE.AUTO;
				case MANUAL : 
					return GEAR_TYPE.MANUAL;
				default : 
					return GEAR_TYPE.NULL;
			}
			
		}

		public static string GetString(GEAR_TYPE value)
		{
			switch (value)
			{
				case GEAR_TYPE.AUTO : 
					return AUTO;
				case GEAR_TYPE.MANUAL : 
					return MANUAL;
				default : 
					return NullConstant.STRING;
			}
			
		}
	
		//----------------------------------------------------------------------------	
		private const string DRIVER = "��ѡ�ҹ�Ѻö";
		private const string MACHANIC = "��ѡ�ҹ�������ا";
		private const string BLANK = " ";

		public String[] PositionRoleTypeArray = {DRIVER, MACHANIC, BLANK};


		public static POSITION_ROLE_TYPE GetPositionRoleType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case DRIVER : 
					return POSITION_ROLE_TYPE.DRIVER;
				case MACHANIC : 
					return POSITION_ROLE_TYPE.MACHANIC;
				case BLANK :
					return POSITION_ROLE_TYPE.BLANK;
				default : 
					return POSITION_ROLE_TYPE.NULL;
			}
			
		}

		public static string GetString(POSITION_ROLE_TYPE value)
		{
			switch (value)
			{
				case POSITION_ROLE_TYPE.DRIVER : 
					return DRIVER;
				case POSITION_ROLE_TYPE.MACHANIC : 
					return MACHANIC;
				case POSITION_ROLE_TYPE.BLANK :
					return BLANK;
				default : 
					return NullConstant.STRING;
			}
			
		}
		//----------------------------------------------------------------------------	
		private const string RED = "����ᴧ";
		private const string NORMALPLATE = "���¸�����";

		public String[] PlateStatusArray = {RED, NORMALPLATE};


		public static PLATE_STATUS GetPlatestatusType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case RED : 
					return PLATE_STATUS.R;
				case NORMALPLATE : 
					return PLATE_STATUS.N;
				default : 
					return PLATE_STATUS.NULL;
			}
			
		}

		public static string GetString(PLATE_STATUS value)
		{
			switch (value)
			{
				case PLATE_STATUS.R : 
					return RED;
				case PLATE_STATUS.N : 
					return NORMALPLATE;
				default : 
					return NullConstant.STRING;
			}
			
		}

		//----------------------------------------------------------------------------	
		private const string MALE = "���";
		private const string FEMALE = "˭ԧ";

		public String[] GenderTypeArray = {MALE, FEMALE};


		public static GENDER_TYPE GetGenderType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case MALE : 
					return GENDER_TYPE.MALE;
				case FEMALE : 
					return GENDER_TYPE.FEMALE;
				default : 
					return GENDER_TYPE.NULL;
			}				
		}

		public static string GetString(GENDER_TYPE value)
		{
			switch (value)
			{
				case GENDER_TYPE.MALE : 
					return MALE;
				case GENDER_TYPE.FEMALE : 
					return FEMALE;
				default : 
					return NullConstant.STRING;
			}			
		}
		//----------------------------------------------------------------------------	
		private const string PERSONAL_CAR_BLANK = "";
		private const string PERSONAL_CAR = "ö��ǹ�ؤ��";
		private const string LICENSE_CAR_TYPE2 = "��������� 2";
		private const string LICENSE_CAR_TYPE3 = "��������� 3";
        private const string PUBLIC_CAR = "ö�Ҹ�ó�";
        private const string LICENSE_CAR_TYPE4 = "��������� 4";

        public String[] DriverLicenseTypeArray = { PERSONAL_CAR_BLANK, PERSONAL_CAR, LICENSE_CAR_TYPE2, LICENSE_CAR_TYPE3, LICENSE_CAR_TYPE4, PUBLIC_CAR };

		public static DRIVER_LICENSE_TYPE GetDriverLicenseType(string value)
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
				default : 
					return NullConstant.STRING;
			}			
		}
		//----------------------------------------------------------------------------	
		private const string MAIN = "Main";
		private const string SPARE = "Spare";

		public String[] AssignmentRoleTypeArray = {MAIN, SPARE};


		public static ASSIGNMENT_ROLE_TYPE GetAssignmentRoleType(string value)
		{
			switch (value)
			{
				case MAIN : 
					return ASSIGNMENT_ROLE_TYPE.MAIN;
				case  SPARE: 
					return ASSIGNMENT_ROLE_TYPE.SPARE;
				default : 
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
				default : 
					return NullConstant.STRING;
			}			
		}

		//----------------------------------------------------------------------------	
		private const string ACCIDENT = "A";
		private const string CONTRACT = "C";
		private const string MAINTENANCE = "M";

		public String[] DocumentTypeArray = {ACCIDENT, CONTRACT, MAINTENANCE};


		public static DOCUMENT_TYPE GetDocumentType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case ACCIDENT : 
					return DOCUMENT_TYPE.ACCIDENT;
				case CONTRACT : 
					return DOCUMENT_TYPE.CONTRACT;
				case MAINTENANCE : 
					return DOCUMENT_TYPE.MAINTENANCE;
				default : 
					return DOCUMENT_TYPE.NULL;
			}			
		}

		public static string GetString(DOCUMENT_TYPE value)
		{
			switch (value)
			{
				case DOCUMENT_TYPE.ACCIDENT : 
					return ACCIDENT;
				case DOCUMENT_TYPE.CONTRACT : 
					return CONTRACT;
				case DOCUMENT_TYPE.MAINTENANCE : 
					return MAINTENANCE;
				default : 
					return NullConstant.STRING;
			}
		}

		//----------------------------------------------------------------------------	
		private const string REGIST = "�زԷ������Ѥçҹ";
		private const string SUPPORT = "�زԷ�����ѷ�Ѻ�ͧ";

		public String[] EducationStatusType = {REGIST, SUPPORT};


		public static EDUCATION_STATUS_TYPE GetEducationStatusType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case REGIST : 
					return EDUCATION_STATUS_TYPE.REGIST;
				case SUPPORT : 
					return EDUCATION_STATUS_TYPE.SUPPORT;
				default : 
					return EDUCATION_STATUS_TYPE.NULL;
			}			
		}

		public static string GetString(EDUCATION_STATUS_TYPE value)
		{
			switch (value)
			{
				case EDUCATION_STATUS_TYPE.REGIST : 
					return REGIST;
				case EDUCATION_STATUS_TYPE.SUPPORT : 
					return SUPPORT;
				default : 
					return NullConstant.STRING;
			}
			
		}
		//----------------------------------------------------------------------------
		private const string INSURANCE_COMPANY = "��Сѹ����";
		private const string COMPANY = "�Ѳ���¨���";

		public String[] ExpenseStatusArray = {INSURANCE_COMPANY,COMPANY};

		public static EXPENSE_STATUS_TYPE GetExpenseStatusType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case INSURANCE_COMPANY : 
					return EXPENSE_STATUS_TYPE.INSURANCE_COMPANY;
				case COMPANY : 
					return EXPENSE_STATUS_TYPE.COMPANY;
				default :
					return EXPENSE_STATUS_TYPE.NULL;
			}
		}

		public static string GetString(EXPENSE_STATUS_TYPE value)
		{
			switch (value)
			{
				case EXPENSE_STATUS_TYPE.INSURANCE_COMPANY : 
					return INSURANCE_COMPANY;
				case EXPENSE_STATUS_TYPE.COMPANY : 
					return COMPANY;
				default : 
					return NullConstant.STRING;
			}
			
		}

		//----------------------------------------------------------------------------	
		private const string ACCIDENTR = "A";
		private const string MAINTENANCER = "M";

		public String[] RepairingArray = {ACCIDENTR,MAINTENANCER};

		public static REPAIRING_TYPE GetRepairingType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case ACCIDENTR : 
					return REPAIRING_TYPE.ACCIDENTR;
				case MAINTENANCER : 
					return REPAIRING_TYPE.MAINTENANCER;
				default :
					return REPAIRING_TYPE.NULL;
			}	
		}

		public static string GetString(REPAIRING_TYPE value)
		{
			switch (value)
			{
				case REPAIRING_TYPE.ACCIDENTR : 
					return ACCIDENTR;
				case REPAIRING_TYPE.MAINTENANCER : 
					return MAINTENANCER;
				default : 
					return NullConstant.STRING;
			}
			
		}
		//----------------------------------------------------------------------------	
		private const string SECOND_HAND_YES = "��";
		private const string SECOND_HAND_NO = "�����";

		public String[] SecondHandStatusArray = {SECOND_HAND_YES,SECOND_HAND_NO};

		public static SECOND_HAND_STATUS_TYPE GetSecondHandStatusType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case SECOND_HAND_YES : 
					return SECOND_HAND_STATUS_TYPE.SECOND_HAND_YES;
				case SECOND_HAND_NO : 
					return SECOND_HAND_STATUS_TYPE.SECOND_HAND_NO;
				default : 
					return SECOND_HAND_STATUS_TYPE.NULL;
			}			
		}
		public static string GetString(SECOND_HAND_STATUS_TYPE value)
		{
			switch (value)
			{
				case SECOND_HAND_STATUS_TYPE.SECOND_HAND_YES : 
					return SECOND_HAND_YES;
				case SECOND_HAND_STATUS_TYPE.SECOND_HAND_NO : 
					return SECOND_HAND_NO;
				default : 
					return NullConstant.STRING;
			}
		}

		//----------------------------------------------------------------------------	
		private const string CUSTOMER = "�١���";
		private const string PTB = "����ѷ�Ѳ���º�ԡ��";
		private const string EMPLOYEE = "��ѡ�ҹ";
        //private const string RESIGN = "��ѡ�ҹ���͡";
	
		public String[] PayerTypeArray = {CUSTOMER, PTB, EMPLOYEE};

		public static PAYER_TYPE GetPayerType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case CUSTOMER : 
					return PAYER_TYPE.CUSTOMER;
				case PTB : 
					return PAYER_TYPE.PTB;
				case EMPLOYEE : 
					return PAYER_TYPE.EMPLOYEE;
                //case RESIGN :
                //    return PAYER_TYPE.RESIGN;
				default : 
					return PAYER_TYPE.NULL;
			}
		}
		public static string GetString(PAYER_TYPE value)
		{
			switch (value)
			{
				case PAYER_TYPE.CUSTOMER : 
					return CUSTOMER;
				case PAYER_TYPE.PTB : 
					return PTB;
				case PAYER_TYPE.EMPLOYEE :
					return EMPLOYEE;
                //case PAYER_TYPE.RESIGN :
                //    return RESIGN;
				default : 
					return NullConstant.STRING;
			}
		}

		//----------------------------------------------------------------------------	
		private const string MONTH = "�����͹";
		private const string DAY = "����ѹ";

		public String[] RateStatusArray = {MONTH, DAY};

		public static RATE_STATUS_TYPE GetRateStatusType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case MONTH : 
					return RATE_STATUS_TYPE.MONTH;
				case DAY : 
					return RATE_STATUS_TYPE.DAY;
				default : 
					return RATE_STATUS_TYPE.NULL;
			}			
		}
		public static string GetString(RATE_STATUS_TYPE value)
		{
			switch (value)
			{
				case RATE_STATUS_TYPE.MONTH : 
					return MONTH;
				case RATE_STATUS_TYPE.DAY : 
					return DAY;
				default : 
					return NullConstant.STRING;
			}
		}

		//----------------------------------------------------------------------------	
		private const string HOLIDAYDATE = "�ѹ��ش";
		private const string LATE_AM = "����ª�ǧ���";
		private const string LATE_PM = "����ª�ǧ����";
		private const string WORKING = "��Ժѵԧҹ";

		public String[] AttendanceStatusArray = {HOLIDAYDATE, LATE_AM, LATE_PM, WORKING};

		public static ATTENDANCE_STATUS_TYPE GetAttendanceStatusType(string value)
		{
			switch (value.ToUpper().Trim())
			{
				case HOLIDAY : 
					return ATTENDANCE_STATUS_TYPE.HOLIDAY;
				case LATE_AM : 
					return ATTENDANCE_STATUS_TYPE.LATE_AM;
				case LATE_PM : 
					return ATTENDANCE_STATUS_TYPE.LATE_PM;
				case WORKING : 
					return ATTENDANCE_STATUS_TYPE.WORKING;
				default : 
					return ATTENDANCE_STATUS_TYPE.NULL;
			}			
		}
		public static string GetString(ATTENDANCE_STATUS_TYPE value)
		{
			switch (value)
			{
				case ATTENDANCE_STATUS_TYPE.HOLIDAY : 
					return HOLIDAYDATE;
				case ATTENDANCE_STATUS_TYPE.LATE_AM : 
					return LATE_AM;
				case ATTENDANCE_STATUS_TYPE.LATE_PM : 
					return LATE_PM;
				case ATTENDANCE_STATUS_TYPE.WORKING : 
					return WORKING;
				default : 
					return NullConstant.STRING;
			}
		}

        //----------------------------------------------------------------------------	
        private const string NEWCAR = "New car";
        private const string USEDCAR = "Used car";
        private const string RENEWAL = "Renewal";

        public String[] KindOfRentalArray = { NEWCAR, USEDCAR, RENEWAL };

        public static KIND_OF_RENTAL_TYPE GetKindOfRentalType(string value)
        {
            switch (value.Trim())
            {
                case NEWCAR:
                    return KIND_OF_RENTAL_TYPE.NEWCAR;
                case USEDCAR:
                    return KIND_OF_RENTAL_TYPE.USEDCAR;
                case RENEWAL:
                    return KIND_OF_RENTAL_TYPE.RENEWAL;
                default :
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
        private const string APPROVE = "Approve";
        private const string CANCEL = "Cancel";

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
		public static PositionType GetPositionType(string value)
		{
			PositionType positionType = new PositionType();
			positionType.Type = value;
			return positionType;
		}

		public static string GetString(PositionType value)
		{
			return value.ADescription.Thai;
		}

		//----------------------------------------------------------------------------	
		public static VehicleStatus GetVehicleStatusType(string value)
		{
			VehicleStatus vehicleStatus = new VehicleStatus();
			vehicleStatus.Code = value;
			return vehicleStatus;		
		}

		public static string GetString(VehicleStatus value)
		{
			return value.AName.Thai;		
		}

		//----------------------------------------------------------------------------	
		public static KindOfVehicle GetKindOfVehicleType(string value)
		{
			KindOfVehicle kindOfVehicle = new KindOfVehicle();
			kindOfVehicle.Code = value;
			return kindOfVehicle;
		}

		public static string GetString(KindOfVehicle value)
		{
			return value.AName.Thai;
		}
		
		//----------------------------------------------------------------------------	
		public static ContractStatus GetContractstatusType(string value)
		{
			ContractStatus contractStatus = new ContractStatus();
			contractStatus.Code = value;
			return contractStatus;
		}

		public static string GetString(ContractStatus value)
		{
			return value.AName.Thai;
		}
		
		//----------------------------------------------------------------------------	
		public static ContractType GetContractType(string value)
		{
			ContractType contractType = new ContractType();
			contractType.Code = value;
			return contractType;
		}

		public static string GetString(ContractType value)
		{
			return value.AName.Thai;
		}
	}
}