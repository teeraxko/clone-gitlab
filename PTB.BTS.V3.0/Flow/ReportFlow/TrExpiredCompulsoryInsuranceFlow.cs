using System;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using PTB.BTS.Common.Flow;
using PTB.BTS.Contract.Flow;

using DataAccess.VehicleDB;
using DataAccess.CommonDB;
using System.Collections.Generic;

namespace PTB.BTS.Report.Flow
{
	public class TrExpiredCompulsoryInsuranceFlow : FlowBase
	{
		#region - Private -	
		private TrExpiredCompulsoryInsuranceDB dbTrExpiredCompulsoryInsurance;
		#endregion

//		==================================== Constructor =========================
		public TrExpiredCompulsoryInsuranceFlow() : base()
		{
			dbTrExpiredCompulsoryInsurance = new TrExpiredCompulsoryInsuranceDB();
		}

//		==================================== Public Method =======================
		public bool PrintCompulsoryInsuranceByMonth(CompulsoryInsuranceList value)
		{
            List<CompulsoryInsurance> listComp = new List<CompulsoryInsurance>();

            foreach (CompulsoryInsurance entity in value)
            {
                CompulsoryInsurance comp = listComp.Find(delegate(CompulsoryInsurance item) { return item.AVehicle.VehicleNo == entity.AVehicle.VehicleNo; });
                
                if (comp != null)
                {
                    comp.PremiumAmount = decimal.Add(entity.PremiumAmount, comp.PremiumAmount);
                    comp.RevenueStampFee = decimal.Add(entity.RevenueStampFee, comp.RevenueStampFee);
                    comp.VatAmount = decimal.Add(entity.VatAmount, comp.VatAmount);

                    if (comp.APeriod.To.Date > entity.APeriod.To.Date)
                    {
                        comp.APeriod.To = comp.APeriod.To;
                    }
                    else
                    {
                        comp.APeriod.To = entity.APeriod.To;
                    }
                }
                else
                {
                    CompulsoryInsurance tempComp = new CompulsoryInsurance();
                    tempComp.AVehicle = entity.AVehicle;
                    tempComp.PremiumAmount = entity.PremiumAmount;
                    tempComp.RevenueStampFee = entity.RevenueStampFee;
                    tempComp.VatAmount = entity.VatAmount;
                    tempComp.APeriod.To = entity.APeriod.To;

                    listComp.Add(tempComp);
                }
            }


			bool result = true;
			TableAccess tableAccess = new TableAccess();
			ContractFlow flowContract;

			try
			{
				flowContract = new PTB.BTS.Contract.Flow.ContractFlow();
				tableAccess.OpenTransaction();
				dbTrExpiredCompulsoryInsurance.TableAccess = tableAccess;

				dbTrExpiredCompulsoryInsurance.DeleteTrExpiredCompulsoryInsurance(value.Company);
			
				ContractBase contractBase;

                foreach (CompulsoryInsurance entity in listComp)
                {
                    contractBase = flowContract.GetCurrentVehicleContract(entity.AVehicle, value.Company);
                    result &= dbTrExpiredCompulsoryInsurance.InsertTrExpiredCompulsoryInsurance(entity, contractBase, value.Company);
                }
                //for(int i=0;i<value.Count; i++)
                //{
                //    contractBase = flowContract.GetCurrentVehicleContract(value[i].AVehicle, value.Company);
                //    result &= dbTrExpiredCompulsoryInsurance.InsertTrExpiredCompulsoryInsurance(value[i], contractBase, value.Company);			
                //}
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
