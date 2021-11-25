using System;
using PTB.BTS.Common.Flow;
using Entity.VehicleEntities.Leasing;
using ictus.Framework.ASC.VBFuntion;
using DataAccess.CommonDB;
using DataAccess.VehicleDB;
using System.Data.SqlClient;

namespace Flow.VehicleFlow.LeasingFlow
{
    public class InterestCostFlow : FlowBase
    {
        //================================= Constructor ================================
        public InterestCostFlow()
            : base()
        {
        }

        //================================= Private method ================================
        private bool calculateInterestCost(InterestCostList value)
        {
            InterestCost interestCost;
            decimal rate = value.Rate / 1200;
            value.PVofResidualValue = Financial.NegativePV(rate, value.LeaseTerm, 0, value.ResidualValue);

            decimal carryValue = value.TotalCost;

            for (int i = 1; i <= value.LeaseTerm; i++)
            {
                interestCost = new InterestCost();

                interestCost.Year = (i - 1) / 12;
                interestCost.Month = i;
                interestCost.Payment = Financial.NegativePMT(rate, value.LeaseTerm, value.PVofAnnuity);
                interestCost.Interest = carryValue * value.Rate / 1200;
                interestCost.CarryingValue = carryValue - interestCost.Cost;

                value.Add(interestCost);

                carryValue = interestCost.CarryingValue;
            }

            return true;
        }

        //================================= Public method ================================
        public bool CalculateInterestCost(InterestCostList value)
        {
            return calculateInterestCost(value);
        }
        
        public bool PrintInterestCost(InterestCostList listCost)
        {
            bool result = false;

            if (calculateInterestCost(listCost))
            {
                result = true;

                TableAccess tableAccess = new TableAccess();
                TrInterestCostHeadDB dbCostHead = new TrInterestCostHeadDB();
                TrInterestCostDetailDB dbCostDetail = new TrInterestCostDetailDB();

                try
                {
                    tableAccess.OpenTransaction();
                    dbCostHead.TableAccess = tableAccess;
                    dbCostDetail.TableAccess = tableAccess;

                    dbCostHead.DeleteInterestCostHead();
                    dbCostDetail.DeleteInterestCostDetail();

                    result &= dbCostHead.InsertInterestCostHead(listCost);
                    result &= dbCostDetail.InsertInterestCostDetail(listCost);

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
                catch (SqlException ex)
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
                    dbCostHead = null;
                    dbCostDetail = null;
                }
            }

            return result;
        }

    }
}
