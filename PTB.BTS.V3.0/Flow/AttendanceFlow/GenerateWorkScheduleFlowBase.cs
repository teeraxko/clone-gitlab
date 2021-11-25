using System;

using Entity.AttendanceEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using PTB.BTS.Common.Flow;
using System.Data.SqlClient;

namespace Flow.AttendanceFlow
{
	public class GenerateWorkScheduleFlowBase : FlowBase
	{
		#region - Constant -
		#endregion

		#region - Private -
			private EmployeeDB dbEmployee;
			private AttendanceCommonFlow flowAttendanceCommon;
		#endregion

		#region - Property -
		#endregion

		//==============================  Constructor  ==============================
		public GenerateWorkScheduleFlowBase() : base()
		{
			dbEmployee = new EmployeeDB();
			flowAttendanceCommon = new AttendanceCommonFlow();
		}

		#region - Private Method -
		private DateTime getEffectiveDate(DateTime value)
		{
			DateTime temp = value.AddMonths(-1);
			YearMonth yearMonth = new YearMonth(temp.Year, temp.Month);
			return yearMonth.MaxDateOfMonth;
//			return new DateTime(value.Year, value.Month, 1);
		}
		#endregion

		#region - Protected Method -
		protected TimePeriod getTimePeriod(TimePeriod value, DateTime forDate)
		{
			return flowAttendanceCommon.GetTimePeriod(value, forDate);
		}

		protected TimePeriod getBreakTimePeriod(TimePeriod breakTime, TimePeriod workTime, DateTime forDate)
		{
			return flowAttendanceCommon.GetBreakTimePeriod(breakTime, workTime, forDate);
		}
		#endregion

		//==============================  Base Event   ==============================

		//============================== Public Method ==============================
		public bool FillEmployeeList(EmployeeList value, DateTime effectiveDate)
		{
			value.Clear();
			return dbEmployee.FillAvailableEmployeeList(value, getEffectiveDate(effectiveDate));
		}

		public bool FillEmployeeList(EmployeeList value, PositionType condition, DateTime effectiveDate)
		{
			value.Clear();
			bool result = false;
			EmployeeList tempEmployeeList = new EmployeeList(value.Company);
			if(dbEmployee.FillAvailableEmployeeList(tempEmployeeList, getEffectiveDate(effectiveDate)))
			{
				for(int i=0; i<tempEmployeeList.Count; i++)
				{
					if(tempEmployeeList[i].APosition.APositionType.Type == condition.Type)
					{
						result = true;
						value.Add(tempEmployeeList[i]);
					}
				}
			}
			tempEmployeeList = null;
			return result;
		}

		public bool FillEmployeeList(EmployeeList value, ServiceStaffType condition, DateTime effectiveDate)
		{
			value.Clear();
			ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
			bool result = dbServiceStaff.FillAvailableStaffList(ref value, condition, getEffectiveDate(effectiveDate));
			dbServiceStaff = null;
			return result;
		}

		public virtual bool InsertWorkSchedule(CompanyStuffBase value, TableAccess tableAccess)
		{
			return false;
		}

		public virtual CompanyStuffBase CreateWorkSchedule(EmployeeList value, YearMonth yearMonth)
		{
			return null;
		}

		public virtual bool GenWorkSchedule(EmployeeList value, YearMonth yearMonth)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();
			try
			{
				tableAccess.OpenTransaction();

				CompanyStuffBase employeeWorkSchedule = CreateWorkSchedule(value, yearMonth);
				result = result && InsertWorkSchedule(employeeWorkSchedule, tableAccess);

				if(result)
				{
					tableAccess.Transaction.Commit();
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}
			}
            catch (SqlException ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
			catch(Exception ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				tableAccess.CloseConnection();
				tableAccess = null;
			}

			return result;
		}
	}
}