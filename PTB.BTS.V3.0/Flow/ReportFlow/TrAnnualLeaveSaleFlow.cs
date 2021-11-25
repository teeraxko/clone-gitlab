using System;
using System.Data.SqlClient;

using PTB.BTS.Common.Flow;

using DataAccess.CommonDB;
using DataAccess.AttendanceDB;

using Entity.AttendanceEntities;

namespace PTB.BTS.Report.Flow
{
	public class TrAnnualLeaveSaleFlow : FlowBase
	{
		private TrAnnualLeaveSaleDB dbTrAnnualLeaveSale;

//		==================================== Constructor ====================================
		public TrAnnualLeaveSaleFlow() : base()
		{
			dbTrAnnualLeaveSale = new TrAnnualLeaveSaleDB();
		}

//		==================================== Public Method ====================================
		public bool PrintAnnualLeaveSale(AnnualLeaveSaleList value)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();
			try
			{
				tableAccess.OpenTransaction();
				dbTrAnnualLeaveSale.TableAccess = tableAccess;

				dbTrAnnualLeaveSale.DeleteTrAnnualLeaveSale(value.Company);			
				result &= dbTrAnnualLeaveSale.InsertTrAnnualLeaveSale(value);

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
