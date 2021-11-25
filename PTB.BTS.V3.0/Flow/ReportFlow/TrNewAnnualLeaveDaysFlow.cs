using System;
using System.Data.SqlClient;

using Entity.AttendanceEntities;

using DataAccess.CommonDB;
using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Report.Flow
{
	public class TrNewAnnualLeaveDaysFlow : FlowBase
	{
		#region - Private -	
		private TrNewAnnualLeaveDaysDB dbTrNewAnnualLeaveDays;
		#endregion

//		==================================== Constructor =========================
		public TrNewAnnualLeaveDaysFlow() : base()
		{
			dbTrNewAnnualLeaveDays = new TrNewAnnualLeaveDaysDB();
		}

//		==================================== Public Method =======================
		public bool PrintTrNewAnnualLeaveDays(AnnualLeaveDualHeadList value)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();
			try
			{
				tableAccess.OpenTransaction();
				dbTrNewAnnualLeaveDays.TableAccess = tableAccess;

				dbTrNewAnnualLeaveDays.DeleteTrNewAnnualLeaveDays(value.Company);			
				result &= dbTrNewAnnualLeaveDays.InsertTrNewAnnualLeaveDays(value);

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
