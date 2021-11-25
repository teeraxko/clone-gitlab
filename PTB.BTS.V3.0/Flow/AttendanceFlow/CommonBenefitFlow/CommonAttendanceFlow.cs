using System;

namespace Flow.AttendanceFlow.CommonBenefitFlow
{
    public class CommonAttendanceFlow
    {
        public static decimal AddTime(decimal value1, decimal value2)
        {
            decimal sumFloor = decimal.Floor(value1) + decimal.Floor(value2);
            decimal sumRemainder = decimal.Remainder(value1, 1) + decimal.Remainder(value2, 1);

            if (sumRemainder >= 0.6m)
            {
                sumFloor++;
                sumRemainder = sumRemainder - 0.6m;
            }

            return sumFloor + sumRemainder;
        }

        public static decimal DiffTime(decimal value1, decimal value2)
        {
            decimal absValue2 = Math.Abs(value2);
            decimal diffFloor = decimal.Floor(value1) - decimal.Floor(absValue2);
            decimal diffRemainder = decimal.Remainder(value1, 1) - decimal.Remainder(absValue2, 1);

            if (diffRemainder <= -0.6m)
            {
                diffFloor--;
                diffRemainder = diffRemainder + 0.6m;
            }

            return diffFloor + diffRemainder;
        }

        public static decimal HalfRound(decimal value)
        {
            bool isNegate = false;
            decimal resultValue = decimal.Zero;

            if (value < 0m)
            {
                isNegate = true;
                value = decimal.Negate(value);
            }

            decimal sumRemainder = decimal.Remainder(value, 1);
            if (sumRemainder == 0m)
            {
                resultValue = value;
            }
            else if (sumRemainder <= 0.3m)
            {
                resultValue = value - sumRemainder + 0.5m;
            }
            else
            {
                resultValue = value - sumRemainder + 1m;
            }

            if (isNegate)
            {
                resultValue = decimal.Negate(resultValue);
            }

            return resultValue;
        }

        public static decimal TISHalfRound(decimal value)
        {
            #region Old coding 2007/11/15 : woranai
            //decimal sumRemainder = decimal.Remainder(value, 1);
            //if (sumRemainder == 0m)
            //{
            //    return value;
            //}
            //else
            //{
            //    return value - sumRemainder + 1m;
            //} 
            #endregion

            bool isNegate = false;
            decimal resultValue = decimal.Zero;

            if (value < 0m)
            {
                isNegate = true;
                value = decimal.Negate(value);
            }

            decimal sumRemainder = decimal.Remainder(value, 1);
            if (sumRemainder == 0m)
            {
                resultValue = value;
            }
            else
            {
                resultValue = value - sumRemainder + 1m;
            }

            if (isNegate)
            {
                resultValue = decimal.Negate(resultValue);
            }

            return resultValue;
        }
    }
}
