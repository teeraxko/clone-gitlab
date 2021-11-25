using System;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using PTB.BTS.Common.Flow;
using PTB.BTS.Contract.Flow;

using DataAccess.VehicleDB;
using DataAccess.CommonDB;

namespace PTB.BTS.Report.Flow
{
	public class TrExpiredVehicleTaxFlow : FlowBase
	{
		#region - Private -	
		private TrExpiredVehicleTaxDB dbTrExpiredVehicleTax;
		#endregion
//		==================================== Constructor =========================
		public TrExpiredVehicleTaxFlow() : base()
		{		
			dbTrExpiredVehicleTax = new TrExpiredVehicleTaxDB();
		}

//		==================================== Public Method =======================
		public bool PrintVehicleTaxByMonth(VehicleTaxList latestVehicleTaxList, VehicleTaxList currentVehicleTaxList)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();
			ContractFlow flowContract;
			try
			{
				flowContract = new PTB.BTS.Contract.Flow.ContractFlow();
				tableAccess.OpenTransaction();
				dbTrExpiredVehicleTax.TableAccess = tableAccess;

				dbTrExpiredVehicleTax.DeleteTrExpiredVehicleTax(latestVehicleTaxList.Company);
			
				ContractBase contractBase;
				for(int i=0;i<latestVehicleTaxList.Count; i++)
				{
					contractBase = flowContract.GetCurrentVehicleContract(latestVehicleTaxList[i].AVehicle, latestVehicleTaxList.Company);
					result &= dbTrExpiredVehicleTax.InsertTrExpiredVehicleTax(latestVehicleTaxList[i], currentVehicleTaxList[i], contractBase, latestVehicleTaxList.Company);			
				}
				contractBase = null;

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
				flowContract = null;
				tableAccess.CloseConnection();
			}

			return result;
		}
	}
}
