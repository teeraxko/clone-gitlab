using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTB.BTS.Common.Flow;
using System.Collections;
using DataAccess.CommonDB;
using System.Data.SqlClient;
using SystemFramework.AppException;
using DataAccess.PiDB;

namespace Flow.PiFlow
{
    public class EmployeeSalaryFlow : FlowBase
    {
        public bool ImportEmployeeSalary(Hashtable salaryData)
        {
            bool result = true;
            EmployeeSalaryDB dbEmployeeSalary = new EmployeeSalaryDB();

            try
            {
                dbEmployeeSalary.TableAccess.OpenTransaction();
                                
                foreach (DictionaryEntry item in salaryData)
                {
                    result &= dbEmployeeSalary.ImportEmployeeSalary(Convert.ToString(item.Key), Convert.ToDecimal(item.Value));
                }

                if (result)
                {
                    dbEmployeeSalary.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbEmployeeSalary.TableAccess.Transaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                dbEmployeeSalary.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (AppExceptionBase ex)
            {
                dbEmployeeSalary.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                dbEmployeeSalary.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                dbEmployeeSalary.TableAccess.CloseConnection();
            }

            dbEmployeeSalary = null;

            return result;
        }
    }
}
