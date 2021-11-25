using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.Common.Flow;
using ictus.Common.Entity;
using Entity.VehicleEntities;
using DataAccess.VehicleDB;
using DataAccess.CommonDB;
using System.Data.SqlClient;
using Entity.AttendanceEntities;
using Entity.CommonEntity;
using PTB.BTS.BTS2BizPacEntity;
using ictus.Common.Entity.General;

namespace Flow.ReportFlow
{
    //Not use now : woranai
    public class TrCompulsoryExpenseFlow : FlowBase
    {
        //==================================== Private Method ====================================
        //private void generateData(CompulsoryExpenseList compulsoryList, DateTime forDate, Company company)
        //{
            //compulsoryList.Clear();
            //CompulsoryInsuranceList compulsoryInsurances = new CompulsoryInsuranceList(company);
            //CompulsoryInsuranceDB dbCompulsoryInsurance = new CompulsoryInsuranceDB();

            //if (dbCompulsoryInsurance.FillCompulsoryInsuranceByFromDateList(compulsoryInsurances, forDate))
            //{
            //    VehicleDB dbVehicle = new VehicleDB();
            //    VehicleInfo vehicleInfo;

            //    CompulsoryInsurance compulsoryInsurance;
            //    CompulsoryExpense compulsoryExpense;
            //    TimePeriod period;
            //    FiscalYear fiscalYear = CommonFlow.FiscalYear;

            //    for (int i = 0; i < compulsoryInsurances.Count; i++)
            //    {
            //        compulsoryExpense = new CompulsoryExpense();
            //        compulsoryInsurance = compulsoryInsurances[i];
            //        period = compulsoryInsurance.APeriod;

            //        vehicleInfo = dbVehicle.GetVehicleInfo(compulsoryInsurance.AVehicle.VehicleNo, company);

            //        if (vehicleInfo != null)
            //        {
            //            if (vehicleInfo.PlateStatus == PLATE_STATUS.R)
            //            {
            //                compulsoryExpense.PlateNo = vehicleInfo.ChassisNo;
            //            }
            //            else
            //            {
            //                compulsoryExpense.PlateNo = vehicleInfo.PlateNumber;
            //            }
            //        }

            //        if (compulsoryExpense.TaxInvoiceNo == "")
            //        {
            //            compulsoryExpense.TaxInvoiceNo = "FOR TEST";
            //        }
            //        else
            //        {
            //            compulsoryExpense.TaxInvoiceNo = compulsoryInsurance.TaxInvoiceNo;
            //        }

            //        if (compulsoryExpense.TaxInvoiceDate == NullConstant.DATETIME)
            //        {
            //            compulsoryExpense.TaxInvoiceDate = DateTime.Today;
            //        }
            //        else
            //        {
            //            compulsoryExpense.TaxInvoiceDate = compulsoryInsurance.TaxInvoiceDate;
            //        }

            //        compulsoryExpense.Period = period;
            //        compulsoryExpense.CompulsoryAmount = compulsoryInsurance.PremiumAmount + compulsoryInsurance.RevenueStampFee;
            //        compulsoryExpense.VatAmount = compulsoryInsurance.VatAmount;
            //        compulsoryExpense.TotalAmount = compulsoryExpense.CompulsoryAmount + compulsoryInsurance.VatAmount;
            //        compulsoryExpense.Year1Days = BTS2BizPacCommon.ShareDayForCurrent(period.From, period.To, fiscalYear);
            //        compulsoryExpense.Year2Days = BTS2BizPacCommon.ShareDayForAdvance(period.From, period.To, fiscalYear);
            //        compulsoryExpense.Year1Amount = BTS2BizPacCommon.ShareExpendForCurrent(period.From, period.To, new DateTime(period.From.Year, period.From.Month, DateTime.DaysInMonth(period.From.Year, period.From.Month)), compulsoryExpense.CompulsoryAmount);
            //        compulsoryExpense.Year2Amount = BTS2BizPacCommon.ShareExpendForAdvance(period.From, period.To, new DateTime(period.From.Year, period.From.Month, DateTime.DaysInMonth(period.From.Year, period.From.Month)), compulsoryExpense.CompulsoryAmount);
                    
            //        compulsoryList.Add(compulsoryExpense);
            //    }

            //    compulsoryInsurance = null;
            //    compulsoryExpense = null;
            //    period = null;
            //    fiscalYear = null;
            //    dbVehicle = null;
            //    vehicleInfo = null;
            //}

            //dbCompulsoryInsurance = null;
        //}

        //==================================== Public Method =======================
        public bool GenCompulsoryExpense(DateTime forDate, Company company)
        {

            //TrCompulsoryExpenseDB dbTrCompulsoryExpense = new TrCompulsoryExpenseDB();
            //CompulsoryExpenseList compulsoryList = new CompulsoryExpenseList(company);

            //generateData(compulsoryList, forDate, company);

            //bool result = false;
            //TableAccess tableAccess = new TableAccess();

            //try
            //{
            //    tableAccess.OpenTransaction();
            //    dbTrCompulsoryExpense.TableAccess = tableAccess;

            //    dbTrCompulsoryExpense.DeleteTrCompulsoryExpense();
            //    for (int i = 0; i < compulsoryList.Count; i++)
            //    {
            //        result = dbTrCompulsoryExpense.InsertTrCompulsoryExpense(compulsoryList[i]);
            //    }

            //    if (result)
            //    {
            //        tableAccess.Transaction.Commit();
            //    }
            //    else
            //    {
            //        tableAccess.Transaction.Rollback();
            //    }
            //}
            //catch (SqlException ex)
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

            return true;

        }
    }
}
