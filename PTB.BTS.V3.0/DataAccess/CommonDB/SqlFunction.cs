using System;
using System.Text;

using ictus.Common.Entity.Time;
using Entity.CommonEntity;

namespace DataAccess.CommonDB
{
	internal class SqlFunction
	{
		public SqlFunction()
		{			
		}
//------------------------------ DB Function ------------------------------
		protected static string internalGetMonthCondition(string fieldName, string value)
		{
			StringBuilder stringBuilder = new StringBuilder("(MONTH(");
			stringBuilder.Append(fieldName);
			stringBuilder.Append(") = ");
			stringBuilder.Append(value);
			stringBuilder.Append(") ");
			return  stringBuilder.ToString();
		}

		protected static string internalGetYearCondition(string fieldName, string value)
		{
			StringBuilder stringBuilder = new StringBuilder("(YEAR(");
			stringBuilder.Append(fieldName);
			stringBuilder.Append(") = ");
			stringBuilder.Append(value);
			stringBuilder.Append(") ");
			return  stringBuilder.ToString();
		}

		protected static string internalGetMonthYearCondition(string fieldName, string month,string year)
		{
			StringBuilder stringBuilder = new StringBuilder(internalGetMonthCondition(fieldName, month));
			stringBuilder.Append(" AND ");
			stringBuilder.Append(internalGetYearCondition(fieldName,year));
			return  stringBuilder.ToString();
		}

		public static string GetYearCondition(string fieldName, YearMonth value)
		{
			return  internalGetYearCondition(fieldName,value.Year.ToString());
		}

		public static string GetYearMonthCondition(string fieldName, YearMonth value)
		{
			return  internalGetMonthYearCondition(fieldName, value.Month.ToString(), value.Year.ToString());
		}
	}
}