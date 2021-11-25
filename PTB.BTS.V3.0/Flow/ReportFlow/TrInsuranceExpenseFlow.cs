using System;
using System.Collections.Generic;
using System.Text;

using PTB.BTS.Common.Flow;
using Entity.VehicleEntities;
using DataAccess.VehicleDB;
using ictus.Common.Entity;
using ictus.Common.Entity.General;
using PTB.BTS.BTS2BizPacEntity;
using Entity.AttendanceEntities;
using ictus.Common.Entity.Time;
using DataAccess.CommonDB;
using System.Data.SqlClient;

namespace Flow.ReportFlow
{
    //Not use now : woranai
    public class TrInsuranceExpenseFlow : FlowBase
    {
        //==================================== Private Method =======================
        //private void generateData(InsuranceExpenseList expenseList, DateTime forDate, Company company)
        //{
        //    expenseList.Clear();
        //    InsuranceTypeOneList insuranceTypeOnes = new InsuranceTypeOneList(company);
        //    InsuranceTypeOneDB dbInsuranceTypeOne = new InsuranceTypeOneDB();

        //    if (dbInsuranceTypeOne.FillInsuranceTypeOneByFromDateList(insuranceTypeOnes, forDate))
        //    {
        //        InsuranceTypeOne insuranceTypeOne;
        //        InsuranceExpense insuranceExpense;
        //        TimePeriod period;

        //        for (int i = 0; i < insuranceTypeOnes.Count; i++)
        //        {
        //            insuranceExpense = new InsuranceExpense();
        //            insuranceTypeOne = insuranceTypeOnes[i];
        //            period = insuranceTypeOne.APeriod;

        //            insuranceExpense.PolicyNo = insuranceTypeOne.PolicyNo;
        //            insuranceExpense.Period = period;
        //            insuranceExpense.TaxInvoiceNo = insuranceTypeOne.TaxInvoiceNo;
        //            insuranceExpense.TotalAmount = insuranceTypeOne.PremiumAmount;

        //            int count = 0;
        //            for (DateTime date = period.From; date <= period.To; date = date.AddMonths(1))
        //            {
        //                count++;
        //                #region - switch case -
        //                switch (count)
        //                { 
        //                    case 1 :
        //                        insuranceExpense.Month1Amount = BTS2BizPacCommon.ShareExpendForCurrent(period.From, period.To, new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month)), insuranceExpense.TotalAmount);
        //                        break;
        //                    case 2 :
        //                        insuranceExpense.Month2Amount = BTS2BizPacCommon.ShareExpendForAdvanceForMonth(period.From, period.To, new YearMonth(date), insuranceExpense.TotalAmount);
        //                        break;
        //                    case 3 :
        //                        insuranceExpense.Month3Amount = BTS2BizPacCommon.ShareExpendForAdvanceForMonth(period.From, period.To, new YearMonth(date), insuranceExpense.TotalAmount);
        //                        break;
        //                    case 4 :
        //                        insuranceExpense.Month4Amount = BTS2BizPacCommon.ShareExpendForAdvanceForMonth(period.From, period.To, new YearMonth(date), insuranceExpense.TotalAmount);
        //                        break;
        //                    case 5:
        //                        insuranceExpense.Month5Amount = BTS2BizPacCommon.ShareExpendForAdvanceForMonth(period.From, period.To, new YearMonth(date), insuranceExpense.TotalAmount);
        //                        break;
        //                    case 6:
        //                        insuranceExpense.Month6Amount = BTS2BizPacCommon.ShareExpendForAdvanceForMonth(period.From, period.To, new YearMonth(date), insuranceExpense.TotalAmount);
        //                        break;
        //                    case 7:
        //                        insuranceExpense.Month7Amount = BTS2BizPacCommon.ShareExpendForAdvanceForMonth(period.From, period.To, new YearMonth(date), insuranceExpense.TotalAmount);
        //                        break;
        //                    case 8:
        //                        insuranceExpense.Month8Amount = BTS2BizPacCommon.ShareExpendForAdvanceForMonth(period.From, period.To, new YearMonth(date), insuranceExpense.TotalAmount);
        //                        break;
        //                    case 9:
        //                        insuranceExpense.Month9Amount = BTS2BizPacCommon.ShareExpendForAdvanceForMonth(period.From, period.To, new YearMonth(date), insuranceExpense.TotalAmount);
        //                        break;
        //                    case 10:
        //                        insuranceExpense.Month10Amount = BTS2BizPacCommon.ShareExpendForAdvanceForMonth(period.From, period.To, new YearMonth(date), insuranceExpense.TotalAmount);
        //                        break;
        //                    case 11:
        //                        insuranceExpense.Month11Amount = BTS2BizPacCommon.ShareExpendForAdvanceForMonth(period.From, period.To, new YearMonth(date), insuranceExpense.TotalAmount);
        //                        break;
        //                    case 12:
        //                        insuranceExpense.Month12Amount = BTS2BizPacCommon.ShareExpendForAdvanceForMonth(period.From, period.To, new YearMonth(date), insuranceExpense.TotalAmount);
        //                        break;
        //                }
        //                #endregion
        //            }

        //            expenseList.Add(insuranceExpense);
        //        }

        //        insuranceExpense = null;
        //        insuranceTypeOne = null;
        //        period = null;
        //    }

        //    dbInsuranceTypeOne = null;
        //}

        //==================================== Public Method =======================
        //public bool GenInsuranceExpense(DateTime forDate, Company company) 
        //{            
            //TrInsuranceExpenseDB dbTrInsuranceExpense = new TrInsuranceExpenseDB();
            //InsuranceExpenseList expenseList = new InsuranceExpenseList(company);

            //generateData(expenseList, forDate, company);
            
            //bool result = false;
            //TableAccess tableAccess = new TableAccess();

            //try
            //{
            //    tableAccess.OpenTransaction();
            //    dbTrInsuranceExpense.TableAccess = tableAccess;

            //    dbTrInsuranceExpense.DeleteTrInsuranceExpense();
            //    for (int i = 0; i < expenseList.Count; i++)
            //    {
            //        result = dbTrInsuranceExpense.InsertTrInsuranceExpense(expenseList[i]);
            //    }

            //    if(result)
            //    {
            //        tableAccess.Transaction.Commit();
            //    }
            //    else
            //    {
            //        tableAccess.Transaction.Rollback();
            //    }
            //}
            //catch(SqlException ex)
            //{
            //    tableAccess.Transaction.Rollback();
            //    throw ex;
            //}
            //catch (Exception ex)
            //{
            //    tableAccess.Transaction.Rollback();
            //    throw ex;
            //}
            //finally
            //{
            //    tableAccess.Close();
            //}

            //return result;
        //    return true;

        //}
    }
}
