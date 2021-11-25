using System;
using System.Collections.Generic;
using System.Text;
using Entity.VehicleEntities.Leasing;
using PTB.BTS.Common.Flow;
using DataAccess.CommonDB;
using DataAccess.VehicleDB;
using ictus.Framework.ASC.VBFuntion;
using Entity.CommonEntity;
using DataAccess.ContractDB;
using Entity.ContractEntities;

namespace Flow.VehicleFlow.LeasingFlow
{
    public class ProfitAndLostFlow : FlowBase
    {
        private Compensate compensate;
        AgeFlow ageFlow = new AgeFlow();

        //================================= Private method ================================
        private decimal calculateBV(ProfitAndLost profitAndLost, ProfitAndLostList listPL)
        {
            Age age = ageFlow.CalculateFineAge(profitAndLost.Vehicle.RegisterDate, listPL.BVDate);
            int useTime = age.Year * 12 + age.Month;
            int remainTime = 60 - useTime;

            if (remainTime > 0)
            {
                return profitAndLost.Price * remainTime / 60;
            }
            else
            {
                return 0;
            }
        }
        
        private bool calculateProfitAndLost(ProfitAndLostList listPL)
        {
            decimal rate;
            ProfitAndLost profitAndLost;

            for (int i = 0; i < listPL.Count; i++)
            {
                profitAndLost = (ProfitAndLost)listPL[i];

                rate = profitAndLost.Rate/1200m;
                profitAndLost.RemainingCostPV = Math.Round(Financial.PV(rate, profitAndLost.Remain, profitAndLost.Pmt, 0), 2);
                profitAndLost.ResidualValuePV = Math.Round(Financial.PV(rate, profitAndLost.Remain, 0, profitAndLost.FV), 2);
                profitAndLost.Compensate = profitAndLost.Rental * profitAndLost.Remain * listPL.PercentCompensate / 100m;
                profitAndLost.BV = calculateBV(profitAndLost, listPL);
            }
            return true;
        }

        //================================= Public method ================================
        public bool PrintProfitAndLost(ProfitAndLostList listPL)
        {
            bool result = false;

            if (compensate == null)
            {
                using (CompensateRateDB dbCompensateRate = new CompensateRateDB())
                {
                    compensate = dbCompensateRate.GetCompensate();
                }
            }

            if (compensate != null)
            {
                listPL.PercentCompensate = compensate.CompensateRate;
            }

            if (calculateProfitAndLost(listPL))
            {
                TableAccess tableAccess = new TableAccess();
                TrProfitAndLostDB dbPL = new TrProfitAndLostDB();

                try
                {
                    tableAccess.OpenTransaction();
                    dbPL.TableAccess = tableAccess;

                    dbPL.DeleteProfitAndLost();
                    result = dbPL.InsertProfitAndLost(listPL);

                    if (result)
                    {
                        tableAccess.Transaction.Commit();
                        result = true;
                    }
                    else
                    {
                        tableAccess.Transaction.Rollback();
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
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
                    dbPL = null;
                }
            }

            return result;
        }
    }
}
