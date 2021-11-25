using System;

using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using DataAccess.PiDB;
using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

using SystemFramework.AppException;

using ictus.Common.Entity;
using System.Data.SqlClient;

namespace Flow.AttendanceFlow
{
    public class GenerateAnnualLeaveDayFlow : FlowBase
    {
        #region - Private -
        private EmployeeDB dbEmployee;
        private EmployeeAnnualLeaveHeadDB dbEmployeeAnnualLeaveHead;
        private AnnualLeaveControlDB dbAnnualLeaveControl;
        #endregion

        //==============================  Constructor  ==============================
        public GenerateAnnualLeaveDayFlow()
            : base()
        {
            dbEmployee = new EmployeeDB();
            dbEmployeeAnnualLeaveHead = new EmployeeAnnualLeaveHeadDB();
            dbAnnualLeaveControl = new AnnualLeaveControlDB();
        }

        #region - Private Method -
        private int calculateAnnualDays(DateTime hireDate)
        {
            switch (hireDate.Month)
            {
                case 4:
                case 5:
                    {
                        return 6;
                    }
                case 6:
                case 7:
                    {
                        return 5;
                    }
                case 8:
                case 9:
                    {
                        return 4;
                    }
                case 10:
                case 11:
                    {
                        return 3;
                    }
                case 12:
                case 1:
                    {
                        return 2;
                    }
                case 2:
                case 3:
                    {
                        return 1;
                    }
            }
            return 0;
        }

        private decimal adjustAnnualDays(decimal days)
        {
            if (days < 6)
            {
                return 6;
            }

            if (days > 14)
            {
                return 14;
            }

            return days;
        }

        private AnnualLeaveHead GenAnnualLeaveHead(AnnualLeaveHead previous)
        {
            AnnualLeaveHead annualLeaveHead = new AnnualLeaveHead(previous.Employee, previous.ForYear + 1);
            annualLeaveHead.SellDays = 0;
            annualLeaveHead.UseDays = 0;
            annualLeaveHead.TotalDays = adjustAnnualDays(previous.TotalDays + 1);
            return annualLeaveHead;
        }

        private bool usedAnnualLeaveHead(AnnualLeaveHead value)
        {
            if (value.SellDays + value.UseDays > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        //============================== Public Method ==============================
        public AnnualLeaveHead GenAnnualLeaveHeadForPI(Employee value)
        {
            int year = 0;

            if (value.HireDate.Year <= 2007)
            {
                year = value.HireDate.Year;
            }
            else
            {
                if (value.HireDate.Month <= 3)
                {
                    year = value.HireDate.Year - 1;
                }
                else
                {
                    year = value.HireDate.Year;
                }
            }

            AnnualLeaveHead annualLeaveHead = new AnnualLeaveHead(value, year);
            annualLeaveHead.SellDays = 0;
            annualLeaveHead.UseDays = 0;
            annualLeaveHead.TotalDays = calculateAnnualDays(value.HireDate);
            return annualLeaveHead;
        }

        /// <summary>
        /// Create new AnnualLeaveControl (Define sale date and valid period from - to)
        /// </summary>
        /// <param name="forYear"></param>
        /// <param name="company"></param>
        /// <returns>AnnualLeaveControl</returns>
        public AnnualLeaveControl GetAnnualLeaveControl(int forYear, Company company)
        {
            AnnualLeaveControl annualLeaveControl = new AnnualLeaveControl(forYear);
            if (!dbAnnualLeaveControl.FillAnnualLeaveControl(ref annualLeaveControl, company))
            {
                annualLeaveControl = new AnnualLeaveControl(forYear);
                annualLeaveControl.CreateDate = DateTime.Today;
                annualLeaveControl.SaleDate = new DateTime(forYear + 1, 6, 1);
                annualLeaveControl.ValidPeriod.From = new DateTime(forYear, 4, 1);

                //New carry over from 6 month to 12 month : woranai 2008/04/22
                annualLeaveControl.ValidPeriod.To = new DateTime(forYear + 2, 3, 31);
            }
            return annualLeaveControl;
        }

        public bool FillAnnualLeaveHeadList(AnnualLeaveDualHeadList value)
        {
            bool result = true;

            value.Clear();

            EmployeeList employeeList = new EmployeeList(value.Company);
            dbEmployee.FillAvailableEmployeeList(ref employeeList);

            AnnualLeaveHeadList currentYear = new AnnualLeaveHeadList(value.LeaveControl, value.Company);
            dbEmployeeAnnualLeaveHead.FillAnnualLeaveHeadList(ref currentYear, employeeList);

            AnnualLeaveHeadList previousYear = new AnnualLeaveHeadList(GetAnnualLeaveControl(value.ForYear - 1, value.Company), value.Company);
            dbEmployeeAnnualLeaveHead.FillAnnualLeaveHeadList(ref previousYear, employeeList);

            string key;
            AnnualLeaveDualHead annualLeaveDualHead;

            for (int i = 0; i < employeeList.Count; i++)
            {
                key = employeeList[i].EntityKey;

                if (previousYear.Contain(key))
                {
                    if (currentYear.Contain(key) && usedAnnualLeaveHead(currentYear[key]))
                    {
                        result = false;
                        annualLeaveDualHead = new AnnualLeaveDualHead(currentYear[key], previousYear[key]);
                        value.Add(annualLeaveDualHead);
                    }
                    else
                    {
                        annualLeaveDualHead = new AnnualLeaveDualHead(GenAnnualLeaveHead(previousYear[key]), previousYear[key]);
                        value.Add(annualLeaveDualHead);
                    }
                }
                else
                {
                    //					employeeList = null;
                    //					currentYear = null;
                    //					previousYear = null;
                    //					key = null;
                    //					annualLeaveDualHead = null;
                    //
                    //					throw new NotFoundException("การกำหนดข้อมูลการลาของพนักงานบางคนในปีก่อนหน้านี้", "GenerateAnnualLeaveDayFlow");
                }
            }

            employeeList = null;
            currentYear = null;
            previousYear = null;
            key = null;
            annualLeaveDualHead = null;

            return result;
        }

        public bool InsertAnnualLeaveDualHeadList(AnnualLeaveDualHeadList value)
        {
            bool result = true;

            AnnualLeaveControlDB dbtAnnualLeaveControl = new AnnualLeaveControlDB();
            EmployeeAnnualLeaveHeadDB dbtEmployeeAnnualLeaveHead = new EmployeeAnnualLeaveHeadDB();
            dbtEmployeeAnnualLeaveHead.TableAccess = dbtAnnualLeaveControl.TableAccess;

            try
            {
                dbtAnnualLeaveControl.TableAccess.OpenTransaction();
                result = result && dbtAnnualLeaveControl.UpdateAnnualLeaveControl(value.LeaveControl, value.Company);
                result = result && dbtEmployeeAnnualLeaveHead.UpdateAnnualLeaveDualHeadList(value);

                if (result)
                {
                    dbtAnnualLeaveControl.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbtAnnualLeaveControl.TableAccess.Transaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                dbtAnnualLeaveControl.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                dbtAnnualLeaveControl.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                dbtAnnualLeaveControl.TableAccess.CloseConnection();
                dbtAnnualLeaveControl = null;
                dbtEmployeeAnnualLeaveHead = null;
            }

            return result;
        }
    }
}