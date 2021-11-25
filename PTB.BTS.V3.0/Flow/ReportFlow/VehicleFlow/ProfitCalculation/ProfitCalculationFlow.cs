using System;
using PTB.BTS.Common.Flow;
using Entity.VehicleEntities.Leasing;
using Entity.VehicleEntities.ProfitCalculation;
using Flow.VehicleEntities.Leasing;
using Flow.VehicleFlow.LeasingFlow;
using DataAccess.VehicleDB;
using DataAccess.CommonDB;
using System.Data.SqlClient;

namespace Flow.VehicleFlow.ProfitCalculation
{
    public class ProfitCalculationFlow : FlowBase
    {
        //================================= Constructor ================================
        public ProfitCalculationFlow() : base()
        {}

        //================================= Private method ================================
        #region - Private method -
        private bool calculateInterestCost(ProfitCal value)
        {
            InterestCostFlow flowInterestCost = new InterestCostFlow();
            value.InterestCostList.Rate = value.InterestRate;
            value.InterestCostList.TotalCost = value.VehiclePrice;
            value.InterestCostList.LeaseTerm = value.LeaseTerm;
            value.InterestCostList.PercentResidualValue = value.LeasingCalculation.PercentOfResidual;
            return flowInterestCost.CalculateInterestCost(value.InterestCostList);
        }

        private void copyYear(ProfitCalDetailList value, int year)
        {
            switch (year)
            {
                case 5:
                    {
                        for (int i = 0; i < value.Count; i++)
                        {
                            value[i].Year5 = value[i].Year1;
                        }
                        goto case 4;
                    }
                case 4:
                    {
                        for (int i = 0; i < value.Count; i++)
                        {
                            value[i].Year4 = value[i].Year1;
                        }
                        goto case 3;
                    }
                case 3:
                    {
                        for (int i = 0; i < value.Count; i++)
                        {
                            value[i].Year3 = value[i].Year1;
                        }
                        goto case 2;
                    }
                case 2:
                    {
                        for (int i = 0; i < value.Count; i++)
                        {
                            value[i].Year2 = value[i].Year1;
                        }
                        goto case 1;
                    }
                case 1:
                case 0:
                    {
                        return;
                    }
                default:
                    { 
                        goto case 5;
                    }
            }
        }

        private bool calculateProfit(ProfitCal value)
        {
            ProfitCalDetail profitCalDetail;
            value.ProfitCalDetailList = new ProfitCalDetailList();
            int year = value.LeaseTerm / 12;

            profitCalDetail = new ProfitCalDetail();
            profitCalDetail.GroupCode = 1;
            profitCalDetail.Line = 1;
            profitCalDetail.Item = "Yearly Charge " + value.LeasingCalculation.MonthlyRoundCharge.ToString("#,##0.00") + "*12";
            profitCalDetail.Year1 = value.LeasingCalculation.MonthlyRoundCharge * 12;
            value.ProfitCalDetailList.Add(profitCalDetail);

            profitCalDetail = new ProfitCalDetail();
            profitCalDetail.GroupCode = 1;
            profitCalDetail.Line = 2;
            profitCalDetail.Item = "Residual Value";
            profitCalDetail.Year1 = 0;
            value.ProfitCalDetailList.Add(profitCalDetail);

            profitCalDetail = new ProfitCalDetail();
            profitCalDetail.GroupCode = 2;
            profitCalDetail.Line = 3;
            profitCalDetail.Item = "Book Value";
            profitCalDetail.Year1 = 0;
            value.ProfitCalDetailList.Add(profitCalDetail);

            profitCalDetail = new ProfitCalDetail();
            profitCalDetail.GroupCode = 2;
            profitCalDetail.Line = 4;
            profitCalDetail.Item = "Depreciation";
            profitCalDetail.Year1 = value.VehiclePrice * value.Depreciation / 100m;
            value.ProfitCalDetailList.Add(profitCalDetail);

            profitCalDetail = new ProfitCalDetail();
            profitCalDetail.GroupCode = 2;
            profitCalDetail.Line = 5;
            profitCalDetail.Item = "Insurance";
            profitCalDetail.Year1 = value.VehicleCost.InsurancePremium;
            value.ProfitCalDetailList.Add(profitCalDetail);

            profitCalDetail = new ProfitCalDetail();
            profitCalDetail.GroupCode = 2;
            profitCalDetail.Line = 6;
            profitCalDetail.Item = "Vehicle Tax";
            profitCalDetail.Year1 = value.VehicleCost.VehicleRegister;
            value.ProfitCalDetailList.Add(profitCalDetail);

            profitCalDetail = new ProfitCalDetail();
            profitCalDetail.GroupCode = 2;
            profitCalDetail.Line = 7;
            profitCalDetail.Item = "Maintenance";
            profitCalDetail.Year1 = value.VehicleCost.MaintenanceCharge * 12;
            value.ProfitCalDetailList.Add(profitCalDetail);

            copyYear(value.ProfitCalDetailList, value.ForYear);

            profitCalDetail = new ProfitCalDetail();
            profitCalDetail.GroupCode = 2;
            profitCalDetail.Line = 8;
            profitCalDetail.Item = "Interest " + value.InterestCostList.Rate.ToString() + "%";
            for(int i=0; i<value.InterestCostList.Count; i++)
            {
                switch(value.InterestCostList[i].Year)
                {
                    case 0:
                        {
                            profitCalDetail.Year1 += value.InterestCostList[i].Interest;
                            break;
                        }
                    case 1:
                        {
                            profitCalDetail.Year2 += value.InterestCostList[i].Interest;
                            break;
                        }
                    case 2:
                        {
                            profitCalDetail.Year3 += value.InterestCostList[i].Interest;
                            break;
                        }
                    case 3:
                        {
                            profitCalDetail.Year4 += value.InterestCostList[i].Interest;
                            break;
                        }
                    default:
                        {
                            profitCalDetail.Year5 += value.InterestCostList[i].Interest;
                            break;
                        }
                }
            }
            value.ProfitCalDetailList.Add(profitCalDetail);

            decimal depre;
            switch (value.ForYear)
            {
                case 0:
                case 1:
                    {
                        value.ProfitCalDetailList[1].Year1 = value.LeasingCalculation.ResidualValue;
                        depre = (100 - 1 * value.Depreciation) * value.VehiclePrice / 100;
                        if(depre<0)
                        {
                            depre = 0;
                        }
                        value.ProfitCalDetailList[2].Year1 = depre;
                        break;
                    }
                case 2:
                    {
                        value.ProfitCalDetailList[1].Year2 = value.LeasingCalculation.ResidualValue;
                        depre = (100 - 2 * value.Depreciation) * value.VehiclePrice / 100;
                        if (depre < 0)
                        {
                            depre = 0;
                        }
                        value.ProfitCalDetailList[2].Year2 = depre;
                        break;
                    }
                case 3:
                    {
                        value.ProfitCalDetailList[1].Year3 = value.LeasingCalculation.ResidualValue;
                        depre = (100 - 3 * value.Depreciation) * value.VehiclePrice / 100;
                        if (depre < 0)
                        {
                            depre = 0;
                        }
                        value.ProfitCalDetailList[2].Year3 = depre;
                        break;
                    }
                case 4:
                    {
                        value.ProfitCalDetailList[1].Year4 = value.LeasingCalculation.ResidualValue;
                        depre = (100 - 4 * value.Depreciation) * value.VehiclePrice / 100;
                        if (depre < 0)
                        {
                            depre = 0;
                        }
                        value.ProfitCalDetailList[2].Year4 = depre;
                        break;
                    }
                default:
                    {
                        value.ProfitCalDetailList[1].Year5 = value.LeasingCalculation.ResidualValue;
                        depre = (100 - 5 * value.Depreciation) * value.VehiclePrice / 100;
                        if (depre < 0)
                        {
                            depre = 0;
                        }
                        value.ProfitCalDetailList[2].Year5 = depre;
                        break;
                    }
            }

            return true;
        }
        #endregion

        //================================= Public method ================================
        public bool CalculateProfit(ProfitCal value)
        {
            bool result = calculateInterestCost(value);
            result &= calculateProfit(value);

            if (result)
            {
                TableAccess tableAccess = new TableAccess();
                TrInterestCostHeadDB dbCostHead = new TrInterestCostHeadDB();
                TrInterestCostDetailDB dbCostDetail = new TrInterestCostDetailDB();
                TrProfitCalculationHeaderDB dbTrProfitCalHeader = new TrProfitCalculationHeaderDB();
                TrProfitCalculationDetailDB dbTrProfitCalDetail = new TrProfitCalculationDetailDB();

                try
                {
                    tableAccess.OpenTransaction();
                    dbCostHead.TableAccess = tableAccess;
                    dbCostDetail.TableAccess = tableAccess;
                    dbTrProfitCalHeader.TableAccess = tableAccess;
                    dbTrProfitCalDetail.TableAccess = tableAccess;

                    dbCostHead.DeleteInterestCostHead();
                    dbCostDetail.DeleteInterestCostDetail();

                    result &= dbCostHead.InsertInterestCostHead(value.InterestCostList);
                    result &= dbCostDetail.InsertInterestCostDetail(value.InterestCostList);
                    result &= dbTrProfitCalHeader.InsertProfitCalDetail(value);
                    result &= dbTrProfitCalDetail.InsertProfitCalDetail(value.ProfitCalDetailList);

                    if (result)
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
                    dbTrProfitCalHeader = null;
                    dbTrProfitCalDetail = null;
                }
            }

            return result;
        }
    }
}