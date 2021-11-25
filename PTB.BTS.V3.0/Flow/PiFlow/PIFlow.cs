using System;
using System.Data.SqlClient;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using Entity.AttendanceEntities;
using Entity.ContractEntities;

using DataAccess.PiDB;
using DataAccess.CommonDB;
using DataAccess.ContractDB;
using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;
using PTB.BTS.Contract.Flow;
using Flow.AttendanceFlow;

using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace PTB.BTS.PI.Flow
{
    public class PIFlow : FlowBase
    {
        #region Private Variable
        protected PITransactionBase dbTransaction;
        private ServiceStaffFlow flowServiceStaff;
        private AppExceptionBase leaveException;
        #endregion

        #region Property for Change
        public bool EmployeeChange
        {
            set { dbTransaction.EmployeeChange = value; }
            get { return dbTransaction.EmployeeChange; }
        }
        public bool EmployeeParentChange
        {
            set { dbTransaction.EmployeeParentChange = value; }
            get { return dbTransaction.EmployeeParentChange; }
        }
        public bool ReferencePersonChange
        {
            set { dbTransaction.ReferencePersonChange = value; }
            get { return dbTransaction.ReferencePersonChange; }
        }
        public bool GuarantorChange
        {
            set { dbTransaction.GuarantorChange = value; }
            get { return dbTransaction.GuarantorChange; }
        }
        public bool EmployeeAddressChange
        {
            set { dbTransaction.EmployeeAddressChange = value; }
            get { return dbTransaction.EmployeeAddressChange; }
        }
        public bool EmployeeSpouseChange
        {
            set { dbTransaction.EmployeeSpouseChange = value; }
            get { return dbTransaction.EmployeeSpouseChange; }
        }
        public bool EmployeeWorkBackgroundChange
        {
            set { dbTransaction.EmployeeWorkBackgroundChange = value; }
            get { return dbTransaction.EmployeeWorkBackgroundChange; }
        }
        public bool EmployeeChildrenListChange
        {
            set { dbTransaction.EmployeeChildrenListChange = value; }
            get { return dbTransaction.EmployeeChildrenListChange; }
        }
        public bool EmployeeEducationChange
        {
            set { dbTransaction.EmployeeEducationChange = value; }
            get { return dbTransaction.EmployeeEducationChange; }
        }
        public bool SalaryChange
        {
            set { dbTransaction.SalaryChange = value; }
            get { return dbTransaction.SalaryChange; }
        }
        public bool EmployeeSpecialAllowanceChange
        {
            set { dbTransaction.EmployeeSpecialAllowanceChange = value; }
            get { return dbTransaction.EmployeeSpecialAllowanceChange; }
        }
        #endregion

        #region Property
        public EmployeeInfo AEmployeeInfo
        {
            get { return dbTransaction.AEmployeeInfo; }
            set { dbTransaction.AEmployeeInfo = value; }
        }
        public EmployeeAddress AEmployeeAddress
        {
            get { return dbTransaction.AEmployeeAddress; }
            set { dbTransaction.AEmployeeAddress = value; }
        }
        public EmployeeFather AEmployeeFather
        {
            get { return dbTransaction.AEmployeeFather; }
            set { dbTransaction.AEmployeeFather = value; }
        }
        public EmployeeMother AEmployeeMother
        {
            get { return dbTransaction.AEmployeeMother; }
            set { dbTransaction.AEmployeeMother = value; }
        }
        public ReferencePerson AReferencePerson
        {
            get { return dbTransaction.AReferencePerson; }
            set { dbTransaction.AReferencePerson = value; }
        }
        public ReferencePerson AGuarantor
        {
            get { return dbTransaction.AGuarantor; }
            set { dbTransaction.AGuarantor = value; }
        }
        public EmployeeSpouse AEmployeeSpouse
        {
            get { return dbTransaction.AEmployeeSpouse; }
            set { dbTransaction.AEmployeeSpouse = value; }
        }
        public Salary ASalary
        {
            get { return dbTransaction.ASalary; }
            set { dbTransaction.ASalary = value; }
        }
        public EmployeeEducation AEmployeeEducation
        {
            get { return dbTransaction.AEmployeeEducation; }
            set { dbTransaction.AEmployeeEducation = value; }
        }
        public EmployeeWorkBackground AEmployeeWorkBackground
        {
            get { return dbTransaction.AEmployeeWorkBackground; }
            set { dbTransaction.AEmployeeWorkBackground = value; }
        }
        public EmployeeChildrenList AEmployeeChildrenList
        {
            get { return dbTransaction.AEmployeeChildrenList; }
            set { dbTransaction.AEmployeeChildrenList = value; }
        }
        public EmployeeSpecialAllowance AEmployeeSpecialAllowance
        {
            get { return dbTransaction.AEmployeeSpecialAllowance; }
            set { dbTransaction.AEmployeeSpecialAllowance = value; }
        }
        #endregion

        #region Constructor
        public PIFlow(Company value)
            : base()
        {
            BaseNew(value);
            leaveException = new AppExceptionBase("PiFlow");
            leaveException.SetMessage(MessageList.Error.E0014, "คำนวณวันลาพักร้อนได้");
        } 
        #endregion

        #region Protected Method
        protected virtual void BaseNew(Company value)
        {
            dbTransaction = new PiTransactionDB(value);
            flowServiceStaff = new ServiceStaffFlow();
        } 
        #endregion

        #region Private Method
        private void nullException(Exception ex)
        {
            ex = null;
        }

        private bool addServiceStaff(Employee value, TableAccess tableAccess)
        {
            bool result;
            ServiceStaff serviceStaff = new ServiceStaff(value.EmployeeNo, value.Company);
            ServiceStaffType serviceStaffType = new ServiceStaffType();
            serviceStaffType.Type = value.APosition.PositionCode + "Z";
            serviceStaff.AServiceStaffType = serviceStaffType;
            ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
            dbServiceStaff.TableAccess = tableAccess;

            result = dbServiceStaff.InsertServiceStaff(serviceStaff);

            serviceStaff = null;
            dbServiceStaff = null;
            return result;
        }

        //This function not used : woranai 2007/01/11
        //private bool addAnnualLeaveHead(Employee value, TableAccess tableAccess)
        //{
        //    bool result;
        //    GenerateAnnualLeaveDayFlow flowGenerateAnnualLeaveDay = new GenerateAnnualLeaveDayFlow();
        //    AnnualLeaveHead annualLeaveHead = flowGenerateAnnualLeaveDay.GenAnnualLeaveHead(value);

        //    EmployeeAnnualLeaveHeadDB dbEmployeeAnnualLeaveHead = new EmployeeAnnualLeaveHeadDB();
        //    dbEmployeeAnnualLeaveHead.TableAccess = tableAccess;

        //    result = dbEmployeeAnnualLeaveHead.InsertAnnualLeaveHead(annualLeaveHead);

        //    flowGenerateAnnualLeaveDay = null;
        //    dbEmployeeAnnualLeaveHead = null;
        //    annualLeaveHead = null;
        //    return result;
        //}

        private bool deleteServiceStaff(ServiceStaff value, TableAccess tableAccess)
        {
            bool result;
            ServiceStaffDB dbServiceStaff = new ServiceStaffDB();

            if (value.AServiceStaffType.IsSpare)
            {
                dbServiceStaff.TableAccess = tableAccess;
                result = dbServiceStaff.DeleteServiceStaff(value);
            }
            else
            {
                AppExceptionBase appExceptionBase = new AppExceptionBase("PIFlow");
                appExceptionBase.SetMessage("ไม่สามารถลบข้อมูลได้เนื่องจากไม่ใช่พนักงาน Spare");
                throw appExceptionBase;
            }

            dbServiceStaff = null;
            return result;
        }

        private bool updateServiceStaff(ServiceStaff value, TableAccess tableAccess)
        {
            bool result;
            ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
            dbServiceStaff.TableAccess = tableAccess;
            result = dbServiceStaff.UpdateServiceStaff(value);
            dbServiceStaff = null;
            return result;
        }

        private bool validateServiceStaffAssignment(ServiceStaff staff, Employee employee)
        {
            ServiceStaffAssignmentDB dbserviceStaffAssignment = new ServiceStaffAssignmentDB();
            ServiceStaffAssignment serviceStaffAssignment = new ServiceStaffAssignment(new ServiceStaff(AEmployeeInfo));
            string strWorkingStatus = AEmployeeInfo.AWorkingStatus.Code;
            bool result = true;

            if (dbserviceStaffAssignment.FillCurrentServiceStaffAssignment(ref serviceStaffAssignment, AEmployeeInfo.Company))
            {
                if (strWorkingStatus.Equals("06") || strWorkingStatus.Equals("07") || strWorkingStatus.Equals("08") || strWorkingStatus.Equals("10"))
                {
                    if (serviceStaffAssignment.APeriod.To >= AEmployeeInfo.TerminationDate)
                    {
                        result = false;
                    }
                }
                else
                {
                    if (staff.APosition.PositionCode != employee.APosition.PositionCode 
                        && serviceStaffAssignment.APeriod.To.Date >= DateTime.Today)
                    {
                        result = false;
                    }
                }
            }

            if (!result)
            {
                AppExceptionBase appExceptionBase = new AppExceptionBase("PIFlow");
                appExceptionBase.SetMessage("ไม่สามารถแก้ไขพนักงานที่ระบุได้ เนื่องจากอยู่ในระยะเวลาการจ่ายงาน \nกรุณาแก้ไขระยะเวลาการจ่ายงานของพนักงานก่อน");
                throw appExceptionBase;
            }

            return true;
        } 
        #endregion

        #region Public Method
        public void ReNew(Company value)
        {
            dbTransaction.ReNew(value);
        }

        public void ClearAllList()
        {
            AEmployeeEducation.Clear();
            AEmployeeWorkBackground.Clear();
            AEmployeeChildrenList.Clear();
            AEmployeeSpecialAllowance.Clear();
        }

        public void changeAll(bool change)
        {
            dbTransaction.changeAll(change);
        }

        public bool Display()
        {
            return dbTransaction.FillList();
        }

        public bool CheckAnnualLeaveControl(DateTime hireDate, Company company)
        {
            AnnualLeaveControl annualLeaveControl = new AnnualLeaveControl(hireDate);
            AnnualLeaveControlDB dbAnnualLeaveControl = new AnnualLeaveControlDB();
            bool result = dbAnnualLeaveControl.FillAnnualLeaveControl(ref annualLeaveControl, company);
            annualLeaveControl = null;
            return result;
        }

        public bool CheckAnnualLeaveDay(Employee value)
        {
            EmployeeAnnualLeaveDetailDB dbAnnualLeaveDetail = new EmployeeAnnualLeaveDetailDB();
            AnnualLeaveDayList annualLeaveDayList = new AnnualLeaveDayList(value);

            bool result = dbAnnualLeaveDetail.FillEmployeeAnnualLeaveDetail(ref annualLeaveDayList);
            dbAnnualLeaveDetail = null;
            annualLeaveDayList = null;
            return result;
        }

        public bool CheckServiceStaffAssignment(Employee value)
        {
            bool result = false;
            ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
            ServiceStaffAssignment serviceStaffAssignment;
            ServiceStaff serviceStaff = new ServiceStaff(value);

            serviceStaffAssignment = new ServiceStaffAssignment();
            serviceStaffAssignment.AAssignedServiceStaff = serviceStaff;
            result |= dbServiceStaffAssignment.FillServiceStaffAssignment(ref serviceStaffAssignment, value.Company);

            serviceStaffAssignment = new ServiceStaffAssignment();
            serviceStaffAssignment.AMainServiceStaff = serviceStaff;
            result |= dbServiceStaffAssignment.FillServiceStaffAssignment(ref serviceStaffAssignment, value.Company);

            serviceStaffAssignment = null;
            dbServiceStaffAssignment = null;

            return result;
        }

        public bool Insert()
        {
            bool result = true;
            TableAccess tableAccess = new TableAccess();
            Employee employee = dbTransaction.AEmployeeInfo;

            try
            {
                tableAccess.OpenTransaction();
                if (dbTransaction.InsertTransaction(tableAccess))
                {
                    int employeeAnnualLeaveHeadCount;
                    EmployeeAnnualLeaveHeadDB dbEmployeeAnnualLeaveHead = new EmployeeAnnualLeaveHeadDB();
                    employeeAnnualLeaveHeadCount = dbEmployeeAnnualLeaveHead.CountEmployeeAnnualLeaveHead(employee);

                    if (employeeAnnualLeaveHeadCount > 1)
                    {
                        dbEmployeeAnnualLeaveHead = null;
                        throw leaveException;
                    }
                    else
                    {
                        AnnualLeaveHead annualLeaveHead = new AnnualLeaveHead(employee, employee.HireDate.Year);
                        dbEmployeeAnnualLeaveHead.FillAnnualLeaveHead(ref annualLeaveHead);

                        if (annualLeaveHead.UseDays + annualLeaveHead.SellDays > 0)
                        {
                            dbEmployeeAnnualLeaveHead = null;
                            throw leaveException;
                        }
                        else
                        {
                            GenerateAnnualLeaveDayFlow flowGenerateAnnualLeaveDay = new GenerateAnnualLeaveDayFlow();
                            AnnualLeaveHead newAnnualLeaveHead = flowGenerateAnnualLeaveDay.GenAnnualLeaveHeadForPI(employee);

                            dbEmployeeAnnualLeaveHead.TableAccess = tableAccess;
                            dbEmployeeAnnualLeaveHead.DeleteEmployeeAnnualLeaveHead(annualLeaveHead);
                            result = dbEmployeeAnnualLeaveHead.InsertAnnualLeaveHead(newAnnualLeaveHead);
                        }
                    }

                    if (result && employee.APosition.APositionType.Type == "S")
                    {
                        result = addServiceStaff(employee, tableAccess);
                    }
                }

                if (result)
                {
                    tableAccess.Transaction.Commit();
                    ClearAllList();
                    dbTransaction.changeAll(false);
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
            catch (AppExceptionBase ex)
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
            }

            tableAccess = null;
            employee = null;
            return result;
        }

        public bool Update()
        {
            EmployeeDB dbEmployee = new EmployeeDB();
            Employee tempEmployee = dbEmployee.GetAllEmployee(AEmployeeInfo.EmployeeNo, AEmployeeInfo.Company);
            dbEmployee = null;

            TableAccess tableAccess = new TableAccess();
            string changeCode = "O";
            bool isStaff = false;

            Employee employee = dbTransaction.AEmployeeInfo;
            ServiceStaff serviceStaff = new ServiceStaff(employee.EmployeeNo, employee.Company);

            ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
            isStaff = dbServiceStaff.FillAllStaff(ref serviceStaff);

            if (isStaff)
            {
                if (serviceStaff.APosition.APositionType.Type == "S")
                {
                    changeCode = "S";
                }
            }

            changeCode += employee.APosition.APositionType.Type;
            dbServiceStaff = null;

            bool result = true;

            try
            {
                tableAccess.OpenTransaction();
                //Allow to change only day of hire. : woranai 2008/05/13
                if ((tempEmployee.HireDate.Month == employee.HireDate.Month) && (tempEmployee.HireDate.Year == employee.HireDate.Year))
                {
                    result = true;
                }
                else
                {
                    int employeeAnnualLeaveHeadCount;
                    EmployeeAnnualLeaveHeadDB dbEmployeeAnnualLeaveHead = new EmployeeAnnualLeaveHeadDB();
                    employeeAnnualLeaveHeadCount = dbEmployeeAnnualLeaveHead.CountEmployeeAnnualLeaveHead(employee);

                    if (employeeAnnualLeaveHeadCount > 1)
                    {
                        dbEmployeeAnnualLeaveHead = null;
                        throw leaveException;
                    }
                    else
                    {
                        AnnualLeaveHead annualLeaveHead = new AnnualLeaveHead(employee, employee.HireDate.Year);
                        dbEmployeeAnnualLeaveHead.FillAnnualLeaveHead(ref annualLeaveHead);

                        if (annualLeaveHead.UseDays + annualLeaveHead.SellDays > 0)
                        {
                            dbEmployeeAnnualLeaveHead = null;
                            throw leaveException;
                        }
                        else
                        {
                            GenerateAnnualLeaveDayFlow flowGenerateAnnualLeaveDay = new GenerateAnnualLeaveDayFlow();
                            AnnualLeaveHead newAnnualLeaveHead = flowGenerateAnnualLeaveDay.GenAnnualLeaveHeadForPI(employee);

                            dbEmployeeAnnualLeaveHead.TableAccess = tableAccess;
                            dbEmployeeAnnualLeaveHead.DeleteEmployeeAnnualLeaveHead(annualLeaveHead);
                            result = dbEmployeeAnnualLeaveHead.InsertAnnualLeaveHead(newAnnualLeaveHead);
                        }
                    }
                }

                if (result && (changeCode.Equals("SO") || changeCode.Equals("SS")))
                {
                    result = validateServiceStaffAssignment(serviceStaff, employee);
                }

                if (result && dbTransaction.UpdateTransaction(tableAccess))
                {
                    switch (changeCode)
                    {
                        case "OO":
                            {
                                result = true;
                                break;
                            }
                        case "OS":
                            {
                                if (isStaff)
                                {
                                    serviceStaff.AServiceStaffType.Type = employee.APosition.PositionCode + "Z";
                                    result = updateServiceStaff(serviceStaff, tableAccess);
                                }
                                else
                                {
                                    result = addServiceStaff(employee, tableAccess);
                                }

                                break;
                            }
                        case "SO":
                            {
                                serviceStaff.AServiceStaffType.Type = ServiceStaffType.DUMMYCODE;
                                serviceStaff.ACurrentContract = null;
                                result = updateServiceStaff(serviceStaff, tableAccess);
                                break;
                            }
                        case "SS":
                            {
                                if (serviceStaff.AServiceStaffType.IsSpare)
                                {
                                    if (serviceStaff.APosition.PositionCode == employee.APosition.PositionCode)
                                    {
                                        result = true;
                                    }
                                    else
                                    {
                                        serviceStaff.AServiceStaffType.Type = employee.APosition.PositionCode + "Z";
                                        result = updateServiceStaff(serviceStaff, tableAccess);
                                    }
                                }
                                else
                                {
                                    result = true;
                                }
                                break;
                            }
                    }
                }

                if (result)
                {
                    tableAccess.Transaction.Commit();
                    ClearAllList();
                    dbTransaction.changeAll(false);
                }
                else
                {
                    tableAccess.Transaction.Rollback();
                }
            }
            catch (AppExceptionBase ex)
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
                tempEmployee = null;
            }
            employee = null;
            return result;
        }

        public virtual bool Delete()
        {
            bool result = true;

            Employee employee = dbTransaction.AEmployeeInfo;
            ServiceStaff serviceStaff = new ServiceStaff(employee.EmployeeNo, employee.Company);

            ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
            EmployeeAnnualLeaveHeadDB dbAnnualLeaveHead = new EmployeeAnnualLeaveHeadDB();

            bool isServiceStaff = dbServiceStaff.FillAllStaff(ref serviceStaff);
            dbServiceStaff = null;

            TableAccess tableAccess = new TableAccess();

            try
            {
                tableAccess.OpenTransaction();
                dbAnnualLeaveHead.TableAccess = tableAccess;

                if (isServiceStaff)
                {
                    result &= deleteServiceStaff(serviceStaff, tableAccess);
                }

                dbAnnualLeaveHead.DeleteEmployeeAnnualLeaveHead(employee);
                result &= dbTransaction.DeleteTransaction(tableAccess);

                if (result)
                {
                    tableAccess.Transaction.Commit();
                    ClearAllList();
                    dbTransaction.changeAll(false);
                }
                else
                {
                    tableAccess.Transaction.Rollback();
                }
            }
            catch (AppExceptionBase ex)
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
                employee = null;
            }

            return result;
        } 
        #endregion
    }
}
#region - Old Data -

//		private void maintainServiceStaff(ServiceStaff value, TableAccess tableAccess)
//		{
//			ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
//			dbServiceStaff.TableAccess = tableAccess;
//			switch(value.APosition.APositionType.Type)
//			{
//				case "O" :
//				{
//					dbServiceStaff.DeleteServiceStaff(value, value.Company);
//					break;
//				}
//				case "S" :
//				{
//					dbServiceStaff.DeleteServiceStaff(value, value.Company);
//					value.AServiceStaffType = new ServiceStaffType();
//					value.AServiceStaffType.Type  = value.APosition.PositionCode + "Z";
//					dbServiceStaff.InsertServiceStaff(value, value.Company);
//					break;
//				}
//			}
//			dbServiceStaff = null;
//		}
//
//		private void deleteServiceStaff(Employee value, TableAccess tableAccess)
//		{
//			switch(value.APosition.APositionType.Type)
//			{
//				case "O" :
//				{
//					dbServiceStaff.TableAccess = tableAccess;
//					dbServiceStaff.DeleteServiceStaff(objServiceStaff, objServiceStaff.Company);
//					break;
//				}
//				case "S" :
//				{
////					bool result = false;
////					try
////					{
////						result = dbServiceStaff.FillStaff(objServiceStaff);
////					}
////					catch(ServiceStaffNotFoundException snf)
////					{
////						nullServiceStaffNotFoundException(snf);
////					}
//					dbServiceStaff.TableAccess = tableAccess;
//					if(result)
//					{
//						objServiceStaff.AServiceStaffType.Type = value.APosition.APositionType.Type + "Z";
//						dbServiceStaff.UpdateServiceStaff(objServiceStaff, objServiceStaff.Company);
//					}
//					else
//					{
//						objServiceStaff.AServiceStaffType = new ServiceStaffType();
//						objServiceStaff.AServiceStaffType.Type = value.APosition.APositionType.Type + "Z";
//						dbServiceStaff.InsertServiceStaff(objServiceStaff, objServiceStaff.Company);
//					}
//					break;
//				}
//				default :
//				{
//					break;
//				}
//			}
//			objServiceStaff = null;
//			dbServiceStaff = null;
//		}
#endregion