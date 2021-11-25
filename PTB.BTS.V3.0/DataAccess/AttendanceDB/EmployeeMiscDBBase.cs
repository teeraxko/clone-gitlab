using System;
using System.Text;
using System.Data.SqlClient;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public abstract class EmployeeMiscDBBase : DataAccessBase
	{
		#region - Constant -
			private const int EMPLOYEE_NO = 0;
			private const int BENEFIT_YEAR = 1;
			private const int BENEFIT_MONTH = 2;
			private const int BENEFIT_DESCTIPTION = 3;
			private const int BENEFIT_AMOUNT = 4;
		#endregion

		//==============================   Constructor  ==============================
		public EmployeeMiscDBBase() : base()
		{
		}

		//============================== Private Method ==============================
		#region - getSQL -
			protected abstract string getSQLSelect();
			protected abstract string getSQLInsert(MiscBenefit value, Employee employee);
			protected abstract string getSQLUpdate(MiscBenefit value, Employee employee);
			protected abstract string getSQLDelete();
			protected abstract string getKeyCondition(MiscBenefit value);
			protected abstract string getOrderby();
		#endregion

		#region - fill -
		protected virtual void fillMiscellaneousBenefit(ref MiscBenefit value, SqlDataReader dataReader)
		{
			value.TotalAmount = dataReader.GetDecimal(BENEFIT_AMOUNT);
			value.Description = (string)dataReader[BENEFIT_DESCTIPTION];
		}

		private bool fillMiscellaneousBenefitList(ref EmployeeMiscBenefit value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				MiscBenefit miscBenefit;
				while (dataReader.Read())
				{
					result = true;
					miscBenefit = new MiscBenefit();
					fillMiscellaneousBenefit(ref miscBenefit, dataReader);
					value.Add(miscBenefit);
				}
				miscBenefit = null;
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();				
			}
			return result;
		}
		#endregion

		//============================== Public Method ==============================
		public bool FillMiscBenefitList(ref EmployeeMiscBenefit value, MiscBenefit aMiscBenefit)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(aMiscBenefit));
			stringBuilder.Append(getOrderby());

			return fillMiscellaneousBenefitList(ref value, stringBuilder.ToString());
		}

		public bool InsertMiscBenefit(MiscBenefit value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateMisceBenefit(MiscBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteMiscBenefit(MiscBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	}
}