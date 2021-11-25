using System;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;

using DataAccess.CommonDB;
using System.Data.SqlClient;

namespace Flow.AttendanceFlow
{
	public class GenerateEmployeeWorkScheduleAndTimcardFlow : GenerateWorkScheduleFlowBase
	{
		#region - Private -
			private GenerateEmployeeWorkScheduleFlow flowGenerateEmployeeWorkSchedule;
			private GenerateEmployeeTimeCardFlow flowGenerateEmployeeTimeCard;
		#endregion

		//==============================  Constructor  ==============================
		public GenerateEmployeeWorkScheduleAndTimcardFlow() : base()
		{
			flowGenerateEmployeeWorkSchedule = new GenerateEmployeeWorkScheduleFlow();
			flowGenerateEmployeeTimeCard = new GenerateEmployeeTimeCardFlow();			
		}

		//============================== Public Method ==============================
		public override bool GenWorkSchedule(EmployeeList value, YearMonth yearMonth)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();

			EmployeeWorkScheduleList employeeWorkScheduleList = (EmployeeWorkScheduleList)flowGenerateEmployeeWorkSchedule.CreateWorkSchedule(value, yearMonth);
			EmployeeTimeCardList employeeTimeCardList = (EmployeeTimeCardList)flowGenerateEmployeeTimeCard.CreateWorkSchedule(employeeWorkScheduleList, yearMonth);

			try
			{
				tableAccess.OpenTransaction();


				result = result && flowGenerateEmployeeWorkSchedule.InsertWorkSchedule(employeeWorkScheduleList, tableAccess);
				result = result && flowGenerateEmployeeTimeCard.InsertWorkSchedule(employeeTimeCardList, tableAccess);
				
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

				employeeWorkScheduleList = null;
				employeeTimeCardList = null;
			}

			return result;
		}
	}
}