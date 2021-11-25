using System;
using System.Text;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities;

namespace Facade.CommonFacade
{
	public class GUIFunction
	{
		public GUIFunction()
		{
		}

		//------------------------------ get normal type ------------------------------
		public static string GetString(string value)
		{return value;}

		public static string GetString(byte value)
		{return (value == 0) ? "" : value.ToString();}

		public static string GetString(float value)
		{return (value == NullConstant.FLOAT) ? "" : value.ToString();}

		public static string GetString(decimal value)
		{return (value == NullConstant.DECIMAL) ? "" : value.ToString();}

		public static string GetString(int value)
		{return (value == NullConstant.INT) ? "" : value.ToString();}

		public static string GetString(DateTime value)
		{return (value == NullConstant.DATETIME) ? "" : value.ToString();}

		public static string GetShortDateString(DateTime value)
		{return (value == NullConstant.DATETIME) ? "" : value.ToShortDateString();}

		public static string GetLongDateString(DateTime value)
		{return (value == NullConstant.DATETIME) ? "" : value.ToLongDateString();}

		//------------------------------ get common type ------------------------------
		public static string GetString(IN_OUT_STATUS_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(OT_RATE_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(WORKINGDAY_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(PERIOD_TYPE value)
		{return CTFunction.GetString(value);}
		
		public static string GetString(SHIFT_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(WHOLE_RATE_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(PAYMENT_STATUS_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(BENEFIT_CODE_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(HIRE_DATE_STATUS_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(PAYROLL_SUBMIT_STATUS_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(KIND_OF_OT_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(GEAR_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(BREAK_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(POSITION_ROLE_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(PLATE_STATUS value)
		{return CTFunction.GetString(value);}

		public static string GetString(GENDER_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(DRIVER_LICENSE_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(ASSIGNMENT_ROLE_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(DOCUMENT_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(EDUCATION_STATUS_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(EXPENSE_STATUS_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(REPAIRING_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(SECOND_HAND_STATUS_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(PAYER_TYPE value)
		{return CTFunction.GetString(value);}

		public static string GetString(RATE_STATUS_TYPE value)
		{return CTFunction.GetString(value);}

        public static string GetString(KIND_OF_RENTAL_TYPE value)
        { return CTFunction.GetString(value); }

        public static string GetString(PURCHAS_STATUS_TYPE value)
        { return CTFunction.GetString(value); }

		public static string GetString(PositionType value)
		{return value.ADescription.Thai;}

		public static string GetString(VehicleStatus value)
		{return value.AName.Thai;}

		public static string GetString(KindOfVehicle value)
		{return value.AName.English;}

		public static string GetString(ContractStatus value)
		{return value.AName.Thai;}

		public static string GetString(ContractType value)
		{return value.AName.Thai;}

//------------------------------  ------------------------------
		public static decimal ConverToDecimal(string hour, string minute)
		{
			return decimal.Parse(getTwoDigit(hour) + "." + getTwoDigit(minute));
		}

		public static decimal ConverToDecimal(int hour, int minute)
		{
			return decimal.Parse(getTwoDigit(hour) + "." + getTwoDigit(minute));
		}

		public static string ConverToHourMinute(decimal value)
		{
			if (value == NullConstant.DECIMAL)
			{
				return "";
			}
			else
			{
				int hour = (int)value;
				decimal f1 = (decimal)hour;
				decimal f2 = value - f1;
				decimal f3 = f2*100m;
				int minute = (int)(f3);
				return getTwoDigit(hour) + ":" + getTwoDigit(minute);			
			}
		}

		public static string ConverToMinute(decimal value)
		{
			if (value == NullConstant.DECIMAL)
			{
				return "";
			}
			else
			{
				int hour = (int)value;
				decimal f1 = (decimal)hour;
				decimal f2 = value - f1;
				decimal f3 = f2*100m;
				int minute = (int)(f3);
				return minute.ToString();			
			}
		}

		public static string ConverToMinute(int value)
		{
			if (value == NullConstant.INT)
			{
				return "";
			}
			else
			{
				int hour = 0;  
				int minute = value;	        
				return getTwoDigit(hour) + ":" + getTwoDigit(minute);			
			}
		}

		private static string getTwoDigit(int value)
		{
			if (value.ToString().Length == 1)
			{
				return "0" + value.ToString();
			}
			else
			{
				return value.ToString();
			}			
		}

		private static string getTwoDigit(string value)
		{
			if (value.Length == 1)
			{
				return "0" + value;
			}
			else
			{
				return value;
			}			
		}
	}
}
