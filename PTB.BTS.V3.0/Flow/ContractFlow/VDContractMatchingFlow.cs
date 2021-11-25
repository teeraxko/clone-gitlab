using System;

using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using DataAccess.ContractDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;
using PTB.BTS.PI.Flow;
using System.Data.SqlClient;

namespace PTB.BTS.Contract.Flow
{
	public class VDContractMatchFlow : FlowBase
	{
		#region Private Variable
			private VDContractMatchDB dbVDContractMatch;
		#endregion Private

        #region Constructor
        public VDContractMatchFlow()
            : base()
        {
            dbVDContractMatch = new VDContractMatchDB();
        }
        #endregion

        #region Private Method
        private void fillVehicleAssignmentList(ref VehicleAssignmentList vehicleAssignmentList, VehicleContract value)
        {
            VehicleAssignmentDB dbVehicleAssignment = new VehicleAssignmentDB();
            VehicleAssignment vehicleAssignment = new VehicleAssignment();
            vehicleAssignment.AContract = value;
            dbVehicleAssignment.FillVehicleAssignmentList(ref vehicleAssignmentList, vehicleAssignment);
            dbVehicleAssignment = null;
            vehicleAssignment = null;
        }

        private void fillServiceStaffAssignmentList(ref ServiceStaffAssignmentList serviceStaffAssignmentList, DriverContract value)
        {
            ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
            ServiceStaffAssignment serviceStaffAssignment = new ServiceStaffAssignment();
            serviceStaffAssignment.AContract = value;
            dbServiceStaffAssignment.FillServiceStaffAssignmentList(ref serviceStaffAssignmentList, serviceStaffAssignment);
            dbServiceStaffAssignment = null;
            serviceStaffAssignment = null;
        } 
        #endregion

        #region Public Method
        public bool FillVDContractMatch(ref ContractList value, ContractBase condition)
        {
            ContractFlow contractFlow = new ContractFlow();
            bool result = contractFlow.FillVehicleContractList(ref value, condition);
            contractFlow = null;

            if (result)
            {
                for (int i = 0; i < value.Count; i++)
                {
                    condition = value[i];
                    dbVDContractMatch.FillVDContractMatchList(ref value, condition);
                }
            }
            return result;
        }

        public bool FillVDContractMatch(ref VehicleContract value)
        {
            return dbVDContractMatch.FillVDContractMatch(ref value);
        }

        public int CheckDriverOnly(DocumentNo driverContractNo, Company company)
        {
            return dbVDContractMatch.FillVDContractMatch(driverContractNo, company);
        }

        public bool FillVDContractMatchByVehicle(ref VehicleContract value, int vehicleNo)
        {
            return dbVDContractMatch.FillVDContractMatchByVehicle(ref value, vehicleNo);
        }

        public bool FillVDContractMatchByEmployeeOrder(ref VehicleContract value, int employeeOrder)
        {
            return dbVDContractMatch.FillVDContractMatchByEmployeeOrder(ref value, employeeOrder);
        }

        public bool FillVehicleAssignmentList(ref VehicleContract value)
        {
            bool result = false;
            VehicleAssignmentList vehicleAssignmentList = new VehicleAssignmentList(value.AVehicleRoleList.Company);
            fillVehicleAssignmentList(ref vehicleAssignmentList, value);

            if (vehicleAssignmentList.Count != 0)
            {
                for (int i = 0; i < value.AVehicleRoleList.Count; i++)
                {
                    string vehicleNo = value.AVehicleRoleList[i].AVehicle.VehicleNo.ToString();
                    string key = value.EntityKey + value.APeriod.From.ToShortDateString() + value.APeriod.To.ToShortDateString() + vehicleNo + vehicleNo;

                    if (vehicleAssignmentList[key] != null)
                    {
                        value.AVehicleRoleList[vehicleNo].AHirer = vehicleAssignmentList[key].AHirer;
                    }
                    else
                    {
                        value.AVehicleRoleList[vehicleNo].AHirer.Name = "";
                    }

                    result = true;
                }
            }
            return result;
        }

        public DocumentNo GetSpecificVDMatchByContract(ContractType contractType, DocumentNo contractNo, Company company)
        {
            return dbVDContractMatch.GetSpecificVDMatchByContract(contractType, contractNo, company);
        }

        public bool InsertVDContractMatch(VehicleContract value)
        {
            Company company = value.AVehicleRoleList.Company;

            bool resultServiceStaff = false;
            bool resultVehicle = true;
            ServiceStaffRole serviceStaffRole;
            ServiceStaffAssignment serviceStaffAssignment;
            VehicleAssignment vehicleAssignment;
            ServiceStaffType serviceStaffType;
            ServiceStaffRoleList serviceStaffRoleList = new ServiceStaffRoleList(company);

            VehicleAssignmentList vehicleAssignmentList = new VehicleAssignmentList(company);
            fillVehicleAssignmentList(ref vehicleAssignmentList, value);

            ServiceStaffContractDB dbServiceStaffContract = new ServiceStaffContractDB();
            dbServiceStaffContract.TableAccess = dbVDContractMatch.TableAccess;

            ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
            dbServiceStaffAssignment.TableAccess = dbVDContractMatch.TableAccess;

            ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
            dbServiceStaff.TableAccess = dbVDContractMatch.TableAccess;

            VehicleAssignmentDB dbVehicleAssignment = new VehicleAssignmentDB();
            dbVehicleAssignment.TableAccess = dbVDContractMatch.TableAccess;

            try
            {
                dbVDContractMatch.TableAccess.OpenTransaction();
                for (int i = 0; i < value.AVehicleRoleList.Count; i++)
                {
                    if (value.AVehicleRoleList[i].ADriver != null)
                    {
                        serviceStaffRole = new ServiceStaffRole();
                        serviceStaffRole.AServiceStaff = value.AVehicleRoleList[i].ADriver;
                        serviceStaffRole.AServiceStaff.ACurrentContract = value.ADriverContract;
                        serviceStaffRole.ServiceStaffOrder = i + 1;

                        serviceStaffType = new ServiceStaffType();
                        serviceStaffType.Type = value.AVehicleRoleList[i].ADriver.APosition.PositionCode + value.AVehicleRoleList[i].AKindOfVehicle.Code.ToString();
                        serviceStaffRole.AServiceStaffType = serviceStaffType;
                        serviceStaffRoleList.Add(serviceStaffRole);
                        value.ADriverContract.ALatestServiceStaffRoleList = serviceStaffRoleList;

                        serviceStaffAssignment = new ServiceStaffAssignment(value.AVehicleRoleList[i].ADriver);
                        serviceStaffAssignment.APeriod = value.ADriverContract.APeriod;
                        serviceStaffAssignment.AMainServiceStaff = value.AVehicleRoleList[i].ADriver;
                        serviceStaffAssignment.AContract = value.ADriverContract;
                        serviceStaffAssignment.AssignmentRole = ASSIGNMENT_ROLE_TYPE.MAIN;
                        serviceStaffAssignment.EmployeeOrder = serviceStaffRole.ServiceStaffOrder;
                        serviceStaffAssignment.AHirer = value.AVehicleRoleList[i].AHirer;

                        if (dbServiceStaffAssignment.InsertServiceStaffAssignment(serviceStaffAssignment, company))
                        {
                            resultServiceStaff = dbServiceStaff.UpdateServiceStaff(serviceStaffRole.AServiceStaff, serviceStaffRole.AServiceStaffType);
                        }
                    }

                    vehicleAssignment = vehicleAssignmentList[i];
                    vehicleAssignment.AHirer = value.AVehicleRoleList[i].AHirer;
                    if (!dbVehicleAssignment.UpdateVehicleAssignment(vehicleAssignment, company))
                    {
                        resultVehicle = false;
                    }
                }

                if (resultServiceStaff)
                {
                    resultServiceStaff = false;
                    resultVehicle = false;
                    if (dbServiceStaffContract.InsertServiceStaffContract(value.ADriverContract))
                    {
                        if (dbVDContractMatch.InsertVDContractMatch(value))
                        {
                            resultServiceStaff = true;
                            resultVehicle = true;
                        }
                    }
                }

                if (resultVehicle || resultServiceStaff)
                {
                    dbVDContractMatch.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbVDContractMatch.TableAccess.Transaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                dbVDContractMatch.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                dbVDContractMatch.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                dbVDContractMatch.TableAccess.CloseConnection();

                company = null;
                serviceStaffRole = null;
                serviceStaffAssignment = null;
                vehicleAssignment = null;
                vehicleAssignmentList = null;
                dbServiceStaffContract = null;
                dbServiceStaffAssignment = null;
                dbServiceStaff = null;
                dbVehicleAssignment = null;
            }

            return resultVehicle || resultServiceStaff;
        }

        public bool UpdateVDContractMatch(VehicleContract value)
        {
            Company company = value.AVehicleRoleList.Company;

            bool result = false;
            ServiceStaffAssignment serviceStaffAssignment;
            VehicleAssignment vehicleAssignment;

            VehicleAssignmentList vehicleAssignmentList = new VehicleAssignmentList(company);
            fillVehicleAssignmentList(ref vehicleAssignmentList, value);

            ServiceStaffAssignmentList serviceStaffAssignmentList = new ServiceStaffAssignmentList(company);
            fillServiceStaffAssignmentList(ref serviceStaffAssignmentList, value.ADriverContract);

            ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
            dbServiceStaffAssignment.TableAccess = dbVDContractMatch.TableAccess;

            VehicleAssignmentDB dbVehicleAssignment = new VehicleAssignmentDB();
            dbVehicleAssignment.TableAccess = dbVDContractMatch.TableAccess;

            try
            {
                dbVDContractMatch.TableAccess.OpenTransaction();
                for (int i = 0; i < value.AVehicleRoleList.Count; i++)
                {
                    if (value.AVehicleRoleList[i].ADriver != null)
                    {
                        serviceStaffAssignment = new ServiceStaffAssignment(value.AVehicleRoleList[i].ADriver);
                        serviceStaffAssignment = serviceStaffAssignmentList[value.ADriverContract.EntityKey + value.ADriverContract.APeriod.From.ToShortDateString() + value.ADriverContract.APeriod.To.ToShortDateString() + value.AVehicleRoleList[i].ADriver.EmployeeNo + value.AVehicleRoleList[i].ADriver.EmployeeNo];
                        serviceStaffAssignment.AHirer = value.AVehicleRoleList[i].AHirer;

                        result = dbServiceStaffAssignment.UpdateServiceStaffAssignment(serviceStaffAssignment, company);
                    }

                    vehicleAssignment = vehicleAssignmentList[value.EntityKey + value.APeriod.From.ToShortDateString() + value.APeriod.To.ToShortDateString() + value.AVehicleRoleList[i].AVehicle.VehicleNo.ToString() + value.AVehicleRoleList[i].AVehicle.VehicleNo.ToString()];
                    vehicleAssignment.AHirer = value.AVehicleRoleList[i].AHirer;

                    result &= dbVehicleAssignment.UpdateVehicleAssignment(vehicleAssignment, company);
                }

                if (result)
                {
                    dbVDContractMatch.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbVDContractMatch.TableAccess.Transaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                dbVDContractMatch.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                dbVDContractMatch.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                dbVDContractMatch.TableAccess.CloseConnection();

                company = null;

                serviceStaffAssignment = null;
                vehicleAssignment = null;
                vehicleAssignmentList = null;
                dbServiceStaffAssignment = null;
                dbVehicleAssignment = null;
            }

            return result;
        }

        public bool ValidateVDContractMatch(ContractBase aContractBase, ServiceStaff aServiceStaff)
        {
            ServiceStaffAssignmentList serviceStaffAssignmentList = new ServiceStaffAssignmentList(aServiceStaff, aServiceStaff.Company);
            ServiceStaffAssignment serviceStaffAssignment;
            ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
            dbServiceStaffAssignment.FillServiceStaffAssignmentList(ref serviceStaffAssignmentList);

            for (int i = 0; i < serviceStaffAssignmentList.Count; i++)
            {
                serviceStaffAssignment = serviceStaffAssignmentList[i];
                if ((serviceStaffAssignment.APeriod.From <= aContractBase.APeriod.To) && (serviceStaffAssignment.APeriod.To >= aContractBase.APeriod.From))
                    return false;
            }
            return true;
        }

        public bool ValidateDeleteVDContractMatch(VehicleContract value)
        {
            ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
            ServiceStaffAssignment serviceStaffAssignment;
            ServiceStaffRoleList serviceStaffRoleList = value.ADriverContract.ALatestServiceStaffRoleList;
            for (int i = 0; i < serviceStaffRoleList.Count; i++)
            {
                serviceStaffAssignment = new ServiceStaffAssignment(serviceStaffRoleList[i].AServiceStaff);
                serviceStaffAssignment.APeriod = value.APeriod;
                if (dbServiceStaffAssignment.FillServiceStaffAssignment(ref serviceStaffAssignment, value.AVehicleRoleList.Company))
                {
                    if (serviceStaffAssignment.AMainServiceStaff.EmployeeNo != serviceStaffAssignment.AAssignedServiceStaff.EmployeeNo)
                    { return false; }
                }
                else
                { return false; }
            }
            return true;
        }

        public bool DeleteVDContractMatch(VehicleContract value)
        {
            bool result = false;
            TableAccess tableAccess = new TableAccess();

            ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
            dbServiceStaffAssignment.TableAccess = tableAccess;
            ServiceStaffAssignment serviceStaffAssignment = new ServiceStaffAssignment();
            serviceStaffAssignment.AContract = value.ADriverContract;

            VehicleAssignmentList vehicleAssignmentList = new VehicleAssignmentList(value.AVehicleRoleList.Company);
            fillVehicleAssignmentList(ref vehicleAssignmentList, value);

            ServiceStaffContractDB dbServiceStaffContract = new ServiceStaffContractDB();
            dbServiceStaffContract.TableAccess = tableAccess;

            ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
            dbServiceStaff.TableAccess = tableAccess;

            dbVDContractMatch.TableAccess = tableAccess;

            try
            {
                tableAccess.OpenTransaction();
                if (dbVDContractMatch.DeleteVDContractMatch(value))
                {
                    if (dbServiceStaffAssignment.DeleteServiceStaffAssignment(serviceStaffAssignment, value.AVehicleRoleList.Company))
                    {
                        if (dbServiceStaffContract.DeleteServiceStaffContract(value.ADriverContract))
                        {
                            ServiceStaff serviceStaff;
                            for (int i = 0; i < value.ADriverContract.ALatestServiceStaffRoleList.Count; i++)
                            {
                                serviceStaff = value.ADriverContract.ALatestServiceStaffRoleList[i].AServiceStaff;
                                serviceStaff.ACurrentContract = null;
                                serviceStaff.AServiceStaffType.Type = serviceStaff.APosition.PositionCode + "Z";
                                if (dbServiceStaff.UpdateServiceStaff(serviceStaff))
                                {
                                    result = true;
                                }
                            }
                        }

                    }
                }

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
                tableAccess = null;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleContract"></param>
        /// <returns></returns>
        public EmployeeList GetAvailableDriverByPeriod(VehicleContract vehicleContract)
        {
            //TODO : P'Ya

            EmployeeList employeeList = new EmployeeList(vehicleContract.AVehicleRoleList.Company);

            using (ServiceStaffDB dbServiceStaff = new ServiceStaffDB())
            {
                dbServiceStaff.FillDriverSpareByPeriod(employeeList, vehicleContract.APeriod);
            }

            return employeeList;
        }
        #endregion

		#region Comment Code
//		public bool DeleteVDContractMatch(VehicleContract value)
//		{
//			bool result = false;
//			TableAccess tableAccess = new TableAccess();
//
//			ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
//			dbServiceStaffAssignment.TableAccess = tableAccess;
//			ServiceStaffAssignment serviceStaffAssignment = new ServiceStaffAssignment();
//			serviceStaffAssignment.AContract = value.ADriverContract;
//            
//			ServiceStaffContractDB dbServiceStaffContract = new ServiceStaffContractDB();
//			dbServiceStaffContract.TableAccess = tableAccess;
//
//			ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
//			dbServiceStaff.TableAccess = tableAccess;
//
//			dbVDContractMatch.TableAccess = tableAccess;
//			value.ADriverContract = new DriverContract(value.AVehicleRoleList.Company);
//
//			try
//			{
//				tableAccess.OpenTransaction();
//				if(dbServiceStaffAssignment.DeleteServiceStaffAssignment(serviceStaffAssignment, value.AVehicleRoleList.Company))
//				{
//					if(dbServiceStaffContract.DeleteServiceStaffContract(value.ADriverContract))
//					{
//						ServiceStaff serviceStaff;
//						bool tempResult = true;
//						for(int i=0; i<value.ADriverContract.ALatestServiceStaffRoleList.Count; i++)
//						{
//							serviceStaff = value.ADriverContract.ALatestServiceStaffRoleList[i].AServiceStaff;
//							serviceStaff.ACurrentContract = null;
//							serviceStaff.AServiceStaffType.Type = serviceStaff.APosition.PositionCode + "Z";
//							tempResult &= dbServiceStaff.UpdateServiceStaff(serviceStaff, value.AVehicleRoleList.Company);
//						}
//						if(tempResult)
//						{
//							if(dbVDContractMatch.UpdateVDContractMatch(value))
//							{
//								result = true;
//							}
//						}
//					}
//				}
//
//				if(result)
//				{
//					tableAccess.Transaction.Commit();
//				}
//				else
//				{
//					tableAccess.Transaction.Rollback();
//				}
//			}
//			catch
//			{
//				tableAccess.Transaction.Rollback();
//			}
//			finally
//			{
//				tableAccess.Close();
//				tableAccess = null;
//			}
//
//			return result;
//		}

        //public EmployeeList GetAvailableDriver(VehicleContract value)
        //{
        //    ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
        //    EmployeeList employeeList = new EmployeeList(value.AVehicleRoleList.Company);
        //    ServiceStaff serviceStaff = new ServiceStaff(value.AVehicleRoleList.Company);

        //    PositionFlow flowPosition = new PositionFlow();
        //    serviceStaff.APosition = flowPosition.GetPositionByRole(POSITION_ROLE_TYPE.DRIVER, value.AVehicleRoleList.Company);
        //    flowPosition = null;

        //    EmployeeList tempEmployeeList = new EmployeeList(value.AVehicleRoleList.Company);

        //    if (dbServiceStaff.FillStaffByPositionList(ref employeeList, serviceStaff))
        //    {
        //        ServiceStaffAssignment serviceStaffAssignment;
        //        ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();

        //        for (int i = 0; i < employeeList.Count; i++)
        //        {
        //            serviceStaffAssignment = new ServiceStaffAssignment((ServiceStaff)employeeList[i]);
        //            serviceStaffAssignment.APeriod.From = value.APeriod.From;
        //            serviceStaffAssignment.APeriod.To = value.APeriod.To;

        //            if (dbServiceStaffAssignment.FillNotAvailableServiceStaffAssignment(ref serviceStaffAssignment, value.AVehicleRoleList.Company))
        //            {
        //                tempEmployeeList.Add(serviceStaffAssignment.AAssignedServiceStaff);
        //            }
        //        }

        //        serviceStaffAssignment = null;
        //        dbServiceStaffAssignment = null;

        //        for (int i = 0; i < tempEmployeeList.Count; i++)
        //        {
        //            employeeList.Remove(tempEmployeeList[i]);
        //        }
        //    }

        //    tempEmployeeList = new EmployeeList(value.AVehicleRoleList.Company);

        //    Employee employee;
        //    for (int i = 0; i < employeeList.Count; i++)
        //    {
        //        tempEmployeeList.Add(employeeList[i]);
        //    }

        //    for (int i = 0; i < tempEmployeeList.Count; i++)
        //    {
        //        employee = new Employee();
        //        employee = tempEmployeeList[i];
        //        string status = tempEmployeeList[i].AWorkingStatus.Code;

        //        if (employee.TerminationDate != NullConstant.DATETIME && employee.TerminationDate <= value.APeriod.To)
        //        {
        //            employeeList.Remove(employee);
        //        }
        //    }
        //    tempEmployeeList = null;

        //    return employeeList;
        //}
		#endregion
	}
}