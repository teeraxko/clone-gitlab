using System;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using DataAccess.PiDB;
using DataAccess.CommonDB;
using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class EmployeeWorkAttedanceFlow : FlowBase
	{
		#region - Private -	
		private EmployeeTimeCardDB dbEmployeeTimeCard;
		private EmployeeWorkScheduleDB dbEmployeeWorkSchedule;
		#endregion

//		==================================== Constructor ====================================
		public EmployeeWorkAttedanceFlow() : base()
		{
			dbEmployeeTimeCard = new EmployeeTimeCardDB();
			dbEmployeeWorkSchedule = new EmployeeWorkScheduleDB();
		}

//		==================================== Public Method ====================================
		public bool FillEmployeeWorkAttedance(ref EmployeeWorkSchedule aEmployeeWorkSchedule, ref EmployeeTimeCard aEmployeeTimeCard)
		{
			bool result = true;
			result &= dbEmployeeWorkSchedule.FillWorkScheduleList(ref aEmployeeWorkSchedule);
			result &= dbEmployeeTimeCard.FillTimeCardList(ref aEmployeeTimeCard);
			return result;
		}

		public bool InsertEmployeeWorkAttedance(WorkSchedule aWorkSchedule, TimeCard aTimeCard, Employee aEmployee)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();

			try
			{
				tableAccess.OpenTransaction();
				dbEmployeeTimeCard.TableAccess = tableAccess;
				dbEmployeeWorkSchedule.TableAccess = tableAccess;

				result &= dbEmployeeTimeCard.InsertTimeCard(aTimeCard, aEmployee);
				result &= dbEmployeeWorkSchedule.InsertWorkSchedule(aWorkSchedule, aEmployee);

				if(result)
				{
					tableAccess.Transaction.Commit();
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}

			}
			catch(SqlException ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
            catch (Exception ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
			finally
			{
				tableAccess.CloseConnection();
			}

			return result;
		}

		public bool UpdateEmployeeWorkAttedance(WorkSchedule aWorkSchedule, TimeCard aTimeCard, Employee aEmployee)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();

			try
			{
				tableAccess.OpenTransaction();
				dbEmployeeTimeCard.TableAccess = tableAccess;
				dbEmployeeWorkSchedule.TableAccess = tableAccess;

				result &= dbEmployeeTimeCard.UpdateTimeCard(aTimeCard, aEmployee);
				result &= dbEmployeeWorkSchedule.UpdateWorkSchedule(aWorkSchedule, aEmployee);

				if(result)
				{
					tableAccess.Transaction.Commit();
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}

			}
			catch(SqlException ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
            catch (Exception ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
			finally
			{
				tableAccess.CloseConnection();
			}

			return result;	
		}
		
		public bool DeleteEmployeeWorkAttedance(WorkSchedule aWorkSchedule, TimeCard aTimeCard, Employee aEmployee)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();

			try
			{
				tableAccess.OpenTransaction();
				dbEmployeeTimeCard.TableAccess = tableAccess;
				dbEmployeeWorkSchedule.TableAccess = tableAccess;

				result &= dbEmployeeTimeCard.DeleteTimeCard(aTimeCard, aEmployee);
				result &= dbEmployeeWorkSchedule.DeleteWorkSchedule(aWorkSchedule, aEmployee);

				if(result)
				{
					tableAccess.Transaction.Commit();
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}

			}
			catch(SqlException ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
            catch (Exception ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
			finally
			{
				tableAccess.CloseConnection();
			}

			return result;	
		}
	}
}
