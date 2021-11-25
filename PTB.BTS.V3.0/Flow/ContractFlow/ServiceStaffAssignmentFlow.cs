using System;
using System.Data.SqlClient;
using DataAccess.ContractDB;
using Entity.AttendanceEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;
using PTB.BTS.Common.Flow;

namespace PTB.BTS.Contract.Flow
{
	
	public class ServiceStaffAssignmentFlow : FlowBase
	{
		#region Private
		private ServiceStaffAssignmentDB dbServiceStaffAssignment;
		private ContractDB dbContract;
		#endregion

        #region Constructor 
        public ServiceStaffAssignmentFlow()
		{
			dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
			dbContract = new ContractDB();
        }
        #endregion

        #region Public Method
        public bool IsCurrentMain(ServiceStaffAssignment value)
        {
            ServiceStaffAssignment serviceStaffAssignment = new ServiceStaffAssignment(value.AAssignedServiceStaff);
            if (dbServiceStaffAssignment.FillCurrentServiceStaffAssignment(ref serviceStaffAssignment, value.AContract.AContractChargeList.Company))
            {
                if (value.AMainServiceStaff.EmployeeNo.Equals(serviceStaffAssignment.AMainServiceStaff.EmployeeNo))
                {
                    serviceStaffAssignment = null;
                    return true;
                }
            }
            serviceStaffAssignment = null;

            ServiceStaffContract serviceStaffContract = (ServiceStaffContract)dbContract.GetContract(value.AContract.ContractNo, value.AContract.AContractChargeList.Company);
            ServiceStaffRole serviceStaffRole;
            for (int i = 0; i < serviceStaffContract.ALatestServiceStaffRoleList.Count; i++)
            {
                serviceStaffRole = serviceStaffContract.ALatestServiceStaffRoleList[i];
                if (serviceStaffRole.ServiceStaffOrder == value.EmployeeOrder && serviceStaffRole.AServiceStaff.EmployeeNo == value.AAssignedServiceStaff.EmployeeNo)
                {
                    serviceStaffContract = null;
                    return true;
                }
            }
            serviceStaffContract = null;
            return false;
        }

        public bool FillServiceStaffAssignment(ref ServiceStaffAssignment value, Company aCompany)
        {
            return dbServiceStaffAssignment.FillServiceStaffAssignment(ref value, aCompany);
        }

        public bool FillNotAvailableServiceStaffAssignment(ref ServiceStaffAssignment value, Company aCompany)
        {
            return dbServiceStaffAssignment.FillNotAvailableServiceStaffAssignment(ref value, aCompany);
        }

        public bool FillServiceStaffAssignmentList(ref ServiceStaffAssignmentList value)
        {
            value.Clear();
            return dbServiceStaffAssignment.FillServiceStaffAssignmentList(ref value);
        }

        public bool FillServiceStaffAssignmentList(ref ServiceStaffAssignmentList value, ServiceStaffAssignment condition)
        {
            value.Clear();
            return dbServiceStaffAssignment.FillServiceStaffAssignmentList(ref value, condition);
        }

        public bool FillServiceStaffAssignmentInPeriodList(ref ServiceStaffAssignmentList value, YearMonth yearMonth)
        {
            return dbServiceStaffAssignment.FillServiceStaffAssignmentInPeriodList(ref value, yearMonth);
        }

        public bool FillSSAssignmentMainList(ServiceStaffAssignmentList listSS, string mainEmpNo)
        {
            return dbServiceStaffAssignment.FillSSAssignmentMainList(listSS, mainEmpNo);
        }

        public bool CheckAvailable(ServiceStaff value, DateTime terminateDate)
        {
            ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
            bool result = dbServiceStaff.FillAvailableStaff(ref value, terminateDate); ;
            dbServiceStaff = null;
            return result;
        }

       

        public ServiceStaffType GetServiceStaffType(ContractBase contract, Company company)
        {
            ServiceStaffContractDB dbServiceStaffContract = new ServiceStaffContractDB();
            ServiceStaffType serviceStaffType = dbServiceStaffContract.GetServiceStaffType(contract, company);
            dbServiceStaffContract = null;
            return serviceStaffType;
        }

        public ServiceStaff GetServiceStaffMainAssignment(ContractBase contract, YearMonth yearMonth, Company company)
        {
            ServiceStaff serviceStaff = new ServiceStaff(company);
            ServiceStaffAssignmentList listServiceStaffAssignment = new ServiceStaffAssignmentList(company);
            if (dbServiceStaffAssignment.FillServiceStaffAssignmentMainInYearmonth(listServiceStaffAssignment, contract, yearMonth))
            {
                ServiceStaffAssignment serviceStaffAssignment = new ServiceStaffAssignment();
                for (int i = 0; i < listServiceStaffAssignment.Count; i++)
                {
                    if (i == 0)
                    {
                        serviceStaffAssignment = listServiceStaffAssignment[i];
                    }
                    else
                    {
                        if (serviceStaffAssignment.APeriod.From > listServiceStaffAssignment[i].APeriod.From)
                        {
                            serviceStaffAssignment = listServiceStaffAssignment[i];
                        }
                    }
                }
                serviceStaff = serviceStaffAssignment.AAssignedServiceStaff;
                serviceStaffAssignment = null;
            }
            else
            {
                serviceStaff = null;
            }
            listServiceStaffAssignment = null;

            return serviceStaff;
        }

        public ServiceStaff GetStaffAssignmentInYearMonthList(AssignmentList assignmentList)
        {
            bool result = false;
            ServiceStaff serviceStaff = null;

            if (dbServiceStaffAssignment.FillSpecificServiceStaffAssignmentInYearMonthList(assignmentList))
            {
                DateTime tempFromDate = DateTime.Today;

                foreach (ServiceStaffAssignment serviceStaffAssignment in assignmentList)
                {
                    for (int i = 0; i < assignmentList.Count; i++)
                    {
                        if (serviceStaffAssignment.AssignmentRole == Entity.CommonEntity.ASSIGNMENT_ROLE_TYPE.MAIN)
                        {
                            result = true;
                            if (serviceStaff == null)
                            {
                                serviceStaff = serviceStaffAssignment.AAssignedServiceStaff;
                                tempFromDate = serviceStaffAssignment.APeriod.From;
                            }
                            else if (tempFromDate < serviceStaffAssignment.APeriod.From)
                            {
                                serviceStaff = serviceStaffAssignment.AAssignedServiceStaff;
                                tempFromDate = serviceStaffAssignment.APeriod.From;
                            }
                        }
                    }
                }
            }

            if (result)
            {
                return serviceStaff;
            }
            else
            {
                serviceStaff = null;
                return null;
            }
        }

        public ServiceStaffAssignment GetMainAssignmentInDate(ContractBase contract, DateTime date, Company company)
        {
            return dbServiceStaffAssignment.GetMainAssignmentInDate(contract, date, company);
        }

        public ServiceStaffAssignment GetMaxAssignedByContract(DocumentNo contractNo, Company company)
        {
            return dbServiceStaffAssignment.GetMaxAssignedByContract(contractNo, company);
        }

        public bool InsertServiceStaffAssignment(ServiceStaffAssignment value, Company aCompany)
        {

            bool result = false;
            ServiceStaffDB dbServiceStaff;
            ServiceStaffRole serviceStaffRole;

            ServiceStaffContractDB dbServiceStaffContract;

            ServiceStaff tempAssignServiceStaff = new ServiceStaff(value.AAssignedServiceStaff.EmployeeNo, value.AAssignedServiceStaff.Company);
            ServiceStaff tempMainServiceStaff = new ServiceStaff(value.AMainServiceStaff.EmployeeNo, value.AMainServiceStaff.Company);

            try
            {
                dbServiceStaffAssignment.TableAccess.OpenTransaction();

                result = dbServiceStaffAssignment.InsertServiceStaffAssignment(value, aCompany);
                if (result && value.AssignmentRole == ASSIGNMENT_ROLE_TYPE.MAIN)
                {
                    dbServiceStaff = new ServiceStaffDB();
                    dbServiceStaff.TableAccess = dbServiceStaffAssignment.TableAccess;

                    //Case assign staff to main
                    if (result)
                    {
                        //tempMainServiceStaff.ACurrentContract = (ServiceStaffContract)value.AContract;
                        //tempMainServiceStaff.AServiceStaffType = GetServiceStaffType(value.AContract, aCompany);
                        //result = dbServiceStaff.UpdateServiceStaff(tempMainServiceStaff);
                    }

                    if (result)
                    {
                        tempAssignServiceStaff.ACurrentContract = (ServiceStaffContract)value.AContract;
                        tempAssignServiceStaff.AServiceStaffType = GetServiceStaffType(value.AContract, aCompany);

                        //tempAssignServiceStaff.ACurrentContract = value.AMainServiceStaff.ACurrentContract;
                        //tempAssignServiceStaff.AServiceStaffType = value.AMainServiceStaff.AServiceStaffType;

                        result = dbServiceStaff.UpdateServiceStaff(tempAssignServiceStaff);
                    }



                    if (result)
                    {
                        dbServiceStaffContract = new ServiceStaffContractDB();
                        dbServiceStaffContract.TableAccess = dbServiceStaffAssignment.TableAccess;

                        serviceStaffRole = new ServiceStaffRole();
                        serviceStaffRole.AServiceStaff = value.AAssignedServiceStaff;
                        serviceStaffRole.AServiceStaff.ACurrentContract = (ServiceStaffContract)value.AContract;
                        serviceStaffRole.AServiceStaffType = tempAssignServiceStaff.AServiceStaffType;
                        serviceStaffRole.ServiceStaffOrder = value.EmployeeOrder;
                        result = dbServiceStaffContract.UpdateServiceStaffContract(serviceStaffRole);
                    }
                }

                if (result)
                {
                    if (value.AssignmentRole == ASSIGNMENT_ROLE_TYPE.MAIN)
                    {
                        value.AAssignedServiceStaff.AServiceStaffType = tempAssignServiceStaff.AServiceStaffType;
                        value.AAssignedServiceStaff.ACurrentContract = tempAssignServiceStaff.ACurrentContract;
                        //value.AMainServiceStaff.AServiceStaffType = tempMainServiceStaff.AServiceStaffType;
                        //value.AMainServiceStaff.ACurrentContract = tempMainServiceStaff.ACurrentContract;
                    }
                    dbServiceStaffAssignment.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbServiceStaffAssignment.TableAccess.Transaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                dbServiceStaffAssignment.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                dbServiceStaffAssignment.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                dbServiceStaffAssignment.TableAccess.CloseConnection();
                dbServiceStaff = null;
                dbServiceStaffContract = null;
                serviceStaffRole = null;
                tempAssignServiceStaff = null;
                tempMainServiceStaff = null;
            }

            return result;
        }

        public bool UpdateServiceStaffAssignment(ServiceStaffAssignment value, ServiceStaffAssignment condition)
        {
            bool result = false;
            ServiceStaffDB dbServiceStaff;

            try
            {
                bool isCurrentMain = IsCurrentMain(value);

                dbServiceStaffAssignment.TableAccess.OpenTransaction();
                result = dbServiceStaffAssignment.UpdateServiceStaffAssignment(value, condition);

                //เพื่อให้คนที่เป็น main ถูกหด assignment กลับเป็น spare
                if (isCurrentMain && !(DateTime.Today <= value.APeriod.To && DateTime.Today >= value.APeriod.From))
                {
                    if (value.AAssignedServiceStaff.ACurrentContract != null && value.AContract.ContractNo.ToString() == value.AAssignedServiceStaff.ACurrentContract.ContractNo.ToString())
                    {
                        value.AAssignedServiceStaff.AServiceStaffType.Type = value.AAssignedServiceStaff.APosition.PositionCode + "Z";
                        value.AAssignedServiceStaff.ACurrentContract = null;
                        dbServiceStaff = new ServiceStaffDB();
                        dbServiceStaff.TableAccess = dbServiceStaffAssignment.TableAccess;
                        result = dbServiceStaff.UpdateServiceStaff(value.AAssignedServiceStaff);
                    }
                }

                if (result)
                {
                    dbServiceStaffAssignment.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbServiceStaffAssignment.TableAccess.Transaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                dbServiceStaffAssignment.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                dbServiceStaffAssignment.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                dbServiceStaffAssignment.TableAccess.CloseConnection();
            }

            return result;
        }

        public bool DeleteServiceStaffAssignment(ServiceStaffAssignment value)
        {
            bool result = true;

            ServiceStaff tempAssignServiceStaff = new ServiceStaff(value.AAssignedServiceStaff.EmployeeNo, value.AAssignedServiceStaff.Company);
            ServiceStaff tempMainServiceStaff = new ServiceStaff(value.AMainServiceStaff.EmployeeNo, value.AMainServiceStaff.Company);

            try
            {
                dbServiceStaffAssignment.TableAccess.OpenTransaction();

                if (value.AssignmentRole == ASSIGNMENT_ROLE_TYPE.MAIN)
                {
                    ServiceStaffContractDB dbServiceStaffContract = new ServiceStaffContractDB();
                    dbServiceStaffContract.TableAccess = dbServiceStaffAssignment.TableAccess;

                    ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
                    dbServiceStaff.TableAccess = dbServiceStaffAssignment.TableAccess;

                    //					if(result)
                    //					{
                    //						tempMainServiceStaff.AServiceStaffType = value.AAssignedServiceStaff.AServiceStaffType;
                    //						tempMainServiceStaff.ACurrentContract = value.AAssignedServiceStaff.ACurrentContract;
                    //						result = dbServiceStaff.UpdateServiceStaff(tempMainServiceStaff);
                    //					}

                    if (result && value.APeriod.From <= DateTime.Today && DateTime.Today <= value.APeriod.To)
                    {
                        tempAssignServiceStaff.ACurrentContract = null;
                        tempAssignServiceStaff.AServiceStaffType = new ServiceStaffType(value.AMainServiceStaff.APosition.PositionCode + "Z");
                        result = dbServiceStaff.UpdateServiceStaff(tempAssignServiceStaff);
                    }

                    ServiceStaffRole serviceStaffRole = new ServiceStaffRole();
                    serviceStaffRole.AServiceStaff = value.AMainServiceStaff;
                    serviceStaffRole.AServiceStaff.ACurrentContract = (ServiceStaffContract)value.AContract;
                    serviceStaffRole.AServiceStaffType = GetServiceStaffType(value.AContract, value.AAssignedServiceStaff.Company);
                    serviceStaffRole.ServiceStaffOrder = value.EmployeeOrder;
                    result = dbServiceStaffContract.UpdateServiceStaffContract(serviceStaffRole);

                    dbServiceStaffContract = null;
                    dbServiceStaff = null;
                }

                if (result)
                {
                    result = dbServiceStaffAssignment.DeleteServiceStaffAssignment(value, value.AAssignedServiceStaff.Company);
                }

                if (result)
                {
                    if (value.AssignmentRole == ASSIGNMENT_ROLE_TYPE.MAIN)
                    {
                        value.AAssignedServiceStaff.AServiceStaffType = tempAssignServiceStaff.AServiceStaffType;
                        value.AAssignedServiceStaff.ACurrentContract = tempAssignServiceStaff.ACurrentContract;
                        value.AMainServiceStaff.AServiceStaffType = tempMainServiceStaff.AServiceStaffType;
                        value.AMainServiceStaff.ACurrentContract = tempMainServiceStaff.ACurrentContract;
                    }
                    dbServiceStaffAssignment.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbServiceStaffAssignment.TableAccess.Transaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                dbServiceStaffAssignment.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                dbServiceStaffAssignment.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                dbServiceStaffAssignment.TableAccess.CloseConnection();
                tempAssignServiceStaff = null;
                tempMainServiceStaff = null;
            }

            return result;
        }

        /// <summary>
        /// To select data of service staff assignment who is main role on assign period date.
        /// </summary>
        /// <param name="staff"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public System.Collections.Generic.List<ServiceStaffAssignment> GetStaffMainAssignByPeriod(ServiceStaff staff, TimePeriod timePeriod,Company aCompany)
        {
            return dbServiceStaffAssignment.GetStaffMainAssignByPeriod(staff, timePeriod,aCompany);
        }

        /// <summary>
        /// To select data of main assign staff on period
        /// </summary>
        /// <param name="staffAssignList"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public bool FillStaffMainAssignByPeriodList(ServiceStaffAssignmentList staffAssignList, TimePeriod timePeriod,Company aCompany)
        {
            return dbServiceStaffAssignment.FillStaffMainAssignByPeriodList(staffAssignList, timePeriod,aCompany);
        }
        #endregion
	}
}