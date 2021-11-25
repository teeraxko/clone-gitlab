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
	public class SaleAnnualLeaveFlow : FlowBase
	{
		#region - Private -
		private EmployeeDB dbEmployee;
		private AnnualLeaveControlDB dbAnnualLeaveControl;
		private EmployeeAnnualLeaveHeadDB dbEmployeeAnnualLeaveHead;
		#endregion

//		==============================  Constructor  ==============================
		public SaleAnnualLeaveFlow() : base()
		{
			dbEmployee = new EmployeeDB();
			dbAnnualLeaveControl = new AnnualLeaveControlDB();
			dbEmployeeAnnualLeaveHead = new EmployeeAnnualLeaveHeadDB();
		}

//		============================== Public Method ==============================
		public bool FillAnnualLeaveHeadList(ref AnnualLeaveHeadList value, int forYear)
		{
			bool result = true;

			EmployeeList employeeList = new EmployeeList(value.Company);
			result &= dbEmployee.FillAvailableEmployeeList(ref employeeList);	
			
			if(result)
			{
				result &= dbEmployeeAnnualLeaveHead.FillAnnualLeaveHeadList(ref value, employeeList, forYear);
			}
			return result;
		}

		public bool ProcessSaleAnnualLeave(AnnualLeaveHeadList value)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();

			try
			{
				tableAccess.OpenTransaction();
				dbAnnualLeaveControl.TableAccess = tableAccess;
				dbEmployeeAnnualLeaveHead.TableAccess = tableAccess;

				if(value.LeaveControl != null)
				{
					result &= dbAnnualLeaveControl.UpdateAnnualLeaveControl(value.LeaveControl, value.Company);
				}
				
				result &= dbEmployeeAnnualLeaveHead.UpdateEmployeeAnnualLeaveHeadList(value);

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
