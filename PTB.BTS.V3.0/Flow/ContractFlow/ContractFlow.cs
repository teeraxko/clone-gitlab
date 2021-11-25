using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using DataAccess.CommonDB;
using DataAccess.VehicleDB;
using DataAccess.ContractDB;
using DataAccess.ContractDB.ContractChargeRateDB;

using Flow.ContractFlow;
using PTB.BTS.Common.Flow;
using PTB.BTS.ContractEntities.ContractChargeRate;
using SystemFramework.AppException;
using System.Text;
using DataAccess.VehicleDB.VehicleLeasingDB;
using Entity.VehicleEntities.VehicleLeasing;
using ictus.Common.Entity.General;
using Entity.AttendanceEntities;
using Entity.Constants;
using SystemFramework.AppMessage;

namespace PTB.BTS.Contract.Flow
{
    /// <summary>
    /// 
    /// </summary>
	public class ContractFlow : FlowBase
	{
		#region Declaration
	    
        private ContractDB dbContract;
		
        #endregion

        #region Constructor
		public ContractFlow() : base()
		{
			dbContract = new ContractDB();
        }
        #endregion

        #region Validate Methods

        /// <summary>
        /// Check match between contract department and assigned department,
        /// in case the contract has only on assigned department
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public bool ValidateMatchDepartment(ContractBase contract, Company company)
        {
            using (ContractDepartmentAssignmentFlow flow = new ContractDepartmentAssignmentFlow(company))
            {
                return flow.GetListByCustomerDepartment(contract, contract.ACustomerDepartment).Count > 0;
            }
        }

        /// <summary>
        /// Validate contract that can assign department
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="contractMode"></param>
        /// <returns></returns>
        public bool ValidateAssignDepartmentPermission(ContractBase contract)
        {
            if (contract.AContractType == null || contract.ACustomer == null || contract.AContractStatus == null)
            {
                return false;
            }
            if ((contract.AContractType.Code != ContractType.CONTRACT_TYPE_DRIVER) && (contract.AContractType.Code != ContractType.CONTRACT_TYPE_VEHICLE))
            {
                return false;
            }
            if (contract.ACustomer.Code != CustomerCodeValue.TIS)
            {
                return false;
            }
            if (!((contract.AContractStatus.Code == ContractStatus.CONTRACT_STS_CREATED) || (contract.AContractStatus.Code == ContractStatus.CONTRACT_STS_APPROVED)))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Other Private Methods

        private void getContractChargeDetail(ref ContractChargeDetailList value, ContractCharge contractCharge)
        {
            ContractChargeDetail contractChargeDetail;
            //DateTime fromDate;
            //if (contractCharge.APeriod.From < DateTime.Today)
            //{
            //    fromDate = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
            //}
            //else
            //{
            //    fromDate = new DateTime(contractCharge.APeriod.From.Year, contractCharge.APeriod.From.Month, 1);
            //}

            DateTime fromDate = new DateTime(contractCharge.APeriod.From.Year, contractCharge.APeriod.From.Month, 1);
            DateTime toDate = new DateTime(contractCharge.APeriod.To.Year, contractCharge.APeriod.To.Month, 25);

            int countMonth = 0;

            for (DateTime temp = fromDate; temp <= toDate; temp = temp.AddMonths(1))
            {
                ++countMonth;
            }

            switch (countMonth)
            {
                case 1:
                    contractChargeDetail = new ContractChargeDetail();
                    contractChargeDetail.YearMonth = new YearMonth(fromDate.Year, fromDate.Month);
                    contractChargeDetail.ChargeAmount = contractCharge.FirstMonthCharge;
                    value.Add(contractChargeDetail);
                    break;
                case 2:
                    contractChargeDetail = new ContractChargeDetail();
                    contractChargeDetail.YearMonth = new YearMonth(fromDate.Year, fromDate.Month);
                    contractChargeDetail.ChargeAmount = contractCharge.FirstMonthCharge;
                    value.Add(contractChargeDetail);

                    contractChargeDetail = new ContractChargeDetail();
                    contractChargeDetail.YearMonth = new YearMonth(toDate.Year, toDate.Month);
                    contractChargeDetail.ChargeAmount = contractCharge.LastMonthCharge;
                    value.Add(contractChargeDetail);
                    break;
                default:

                    for (int i = 0; i < countMonth; i++)
                    {
                        if (i == 0)
                        {
                            contractChargeDetail = new ContractChargeDetail();
                            contractChargeDetail.YearMonth = new YearMonth(fromDate.Year, fromDate.Month);
                            contractChargeDetail.ChargeAmount = contractCharge.FirstMonthCharge;
                            value.Add(contractChargeDetail);
                        }
                        else if (i == countMonth-1)
                        {
                            contractChargeDetail = new ContractChargeDetail();
                            contractChargeDetail.YearMonth = new YearMonth(toDate.Year, toDate.Month);
                            contractChargeDetail.ChargeAmount = contractCharge.LastMonthCharge;
                            value.Add(contractChargeDetail);
                        }
                        else 
                        {
                            contractChargeDetail = new ContractChargeDetail();
                            contractChargeDetail.YearMonth = new YearMonth(fromDate.Year, fromDate.Month);
                            contractChargeDetail.ChargeAmount = contractCharge.MonthlyCharge;
                            value.Add(contractChargeDetail);
                        }

                        fromDate = fromDate.AddMonths(1);
                    }
                    break;
            }
        }

        private ChargeRate InternalGetChargeRate(ContractBase contract, Customer customer, ServiceStaffType serviceStaffType, bool isDriverOnly, Company company)
        {
            ChargeRateByContractDB dbChargeRateByContract = new ChargeRateByContractDB();
            ChargeRateByServiceStaffTypeDB dbChargeRateByServiceStaffType = new ChargeRateByServiceStaffTypeDB();
            ChargeRate chargeRate = null;
            ChargeRateByServiceStaffType chargeRateByServiceStaffType = null;

            ChargeRateByContract chargeRateByContract = new ChargeRateByContract();
            chargeRateByContract.ContractBase = contract;

            if (contract != null && dbChargeRateByContract.FillChargeRateByContract(chargeRateByContract, company))
            {
                chargeRate = chargeRateByContract.ChargeRate;
            }
            else
            {
                chargeRateByServiceStaffType = new ChargeRateByServiceStaffType();
                chargeRateByServiceStaffType.ServiceStaffType = serviceStaffType;
                chargeRateByServiceStaffType.DriverOnlyStatus = isDriverOnly;
                chargeRateByServiceStaffType.Customer = customer;

                if (customer != null && dbChargeRateByServiceStaffType.FillChargeRateByServiceStaffType(chargeRateByServiceStaffType, company))
                {
                    chargeRate = chargeRateByServiceStaffType.ChargeRate;
                }
                else
                {
                    chargeRateByServiceStaffType.Customer = new Customer(Customer.DUMMYCODE);

                    if (dbChargeRateByServiceStaffType.FillChargeRateByServiceStaffType(chargeRateByServiceStaffType, company))
                    {
                        chargeRate = chargeRateByServiceStaffType.ChargeRate;
                    }
                    else
                    {
                        AppExceptionBase appExceptionBase = new AppExceptionBase("ContractFlow : InternalGetChargeRate");
                        appExceptionBase.SetMessage("ไม่พบค่าบริการสำหรับลูกค้า " + customer.ShortName);
                        throw appExceptionBase;
                    }
                }                
            }

            chargeRateByContract = null;
            chargeRateByServiceStaffType = null;
            dbChargeRateByContract = null;
            dbChargeRateByServiceStaffType = null;

            return chargeRate;
        }

        private DriverDeductCharge InternalGetDriverDeductCharge(ContractBase contract, Company company)
        {
            DriverDeductCharge driverDeductCharge = new DriverDeductCharge();
            ChargeRateByContractDB dbChargeRateByContract = new ChargeRateByContractDB();
            ChargeRateByServiceStaffTypeDB dbChargeRateByServiceStaffType = new ChargeRateByServiceStaffTypeDB();
            ChargeRateByServiceStaffType chargeRateByServiceStaffType = null;
            ServiceStaffType serviceStaffType = null;

            ChargeRateByContract chargeRateByContract = new ChargeRateByContract();
            chargeRateByContract.ContractBase = contract;

            if (dbChargeRateByContract.FillChargeRateByContract(chargeRateByContract, company))
            {
                driverDeductCharge.DeductAmount = chargeRateByContract.ChargeRate.AbsenceDeduction;
                driverDeductCharge.DriverDeductStatus = DRIVER_DEDUCT_STATUS.OTHER;                
            }
            else
            {
                chargeRateByServiceStaffType = new ChargeRateByServiceStaffType();
                serviceStaffType = ((ServiceStaffContract)contract).ALatestServiceStaffRoleList[0].AServiceStaffType;
                chargeRateByServiceStaffType.ServiceStaffType = serviceStaffType;
                if (contract.AContractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
                {
                    chargeRateByServiceStaffType.DriverOnlyStatus = IsDriverOnly(contract, company);
                }
                chargeRateByServiceStaffType.Customer = contract.ACustomer;

                if (contract.ACustomer != null && dbChargeRateByServiceStaffType.FillChargeRateByServiceStaffType(chargeRateByServiceStaffType, company))
                {
                    driverDeductCharge.DeductAmount = chargeRateByServiceStaffType.ChargeRate.AbsenceDeduction;
                }
                else
                {
                    chargeRateByServiceStaffType.Customer = new Customer(Customer.DUMMYCODE);

                    if (dbChargeRateByServiceStaffType.FillChargeRateByServiceStaffType(chargeRateByServiceStaffType, company))
                    {
                        driverDeductCharge.DeductAmount = chargeRateByServiceStaffType.ChargeRate.AbsenceDeduction;
                    }
                    else
                    {
                        AppExceptionBase appExceptionBase = new AppExceptionBase("ContractFlow : InternalGetContractDeductChargeRate");
                        appExceptionBase.SetMessage("ไม่พบค่าบริการสำหรับลูกค้า " + contract.ACustomer.ShortName);
                        throw appExceptionBase;
                    }
                }

                switch (serviceStaffType.Type)
                {
                    case "281":
                        if (chargeRateByServiceStaffType.DriverOnlyStatus)
                        {
                            driverDeductCharge.DriverDeductStatus = DRIVER_DEDUCT_STATUS.DRIVERONLY;
                        }
                        else
                        {
                            driverDeductCharge.DriverDeductStatus = DRIVER_DEDUCT_STATUS.DRIVERMATCH;
                        }
                        break;
                    case "282":
                        //Family only not declare : woranai

                        //if (chargeRateByServiceStaffType.DriverOnlyStatus)
                        //{
                        //    driverDeductCharge.DriverDeductStatus = DRIVER_DEDUCT_STATUS.DRIVERFAMILYONLY;
                        //}
                        //else
                        //{
                            driverDeductCharge.DriverDeductStatus = DRIVER_DEDUCT_STATUS.DRIVERFAMILYMATCH;
                        //}
                        break;
                    default:
                        driverDeductCharge = null;
                        break;
                }
            }

            chargeRateByContract = null;
            chargeRateByServiceStaffType = null;
            dbChargeRateByContract = null;
            dbChargeRateByServiceStaffType = null;

            return driverDeductCharge;
        }

        private bool IsDriverOnly(ContractBase contract, Company company)
        {
            using (VDContractMatchDB dbVDContractMatch = new VDContractMatchDB())
            {
                return (dbVDContractMatch.FillVDContractMatch(contract.ContractNo, company) == -1);                
            }
        }

        #region ============================== Insert Method ==============================

        /// <summary>
        /// Save assigned department to database
        /// </summary>
        /// <param name="assignedList"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        private void saveAssignedDepartment(List<ContractDepartmentAssignment> assignedList,Company company,TableAccess tableAccess)
        {
            if ((assignedList != null) && (assignedList.Count > 0))
            {
                using (ContractDepartmentAssignmentDB dbAssignedDepartment = new ContractDepartmentAssignmentDB(company))
                {
                    dbAssignedDepartment.Save(assignedList, tableAccess);
                }
            }

        }

        /// <summary>
        /// Insert assigned department to database
        /// </summary>
        /// <param name="assignedList"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        private void insertAssignedDepartment<T>(T contract, Company company, TableAccess tableAccess) where T:ContractBase
        {
            using (ContractDepartmentAssignmentFlow flowAssignedDepartment = new ContractDepartmentAssignmentFlow(company))
            {
                if (this.ValidateAssignDepartmentPermission(contract))
                {
                    if ((contract.ACustomerDepartment != null))
                    {
                        contract.AssignedDepartmentList = flowAssignedDepartment.InitializeAssignedDepartment(contract);

                        this.saveAssignedDepartment(contract.AssignedDepartmentList, company, tableAccess);
                    }
                }
            }
        }

        private bool insertContract(DriverContract value, ContractChargeDetailList listCharge, Company aCompany)
		{
			bool result = false;

			ContractChargeDB dbContractCharge = new ContractChargeDB();
            ContractChargeDetailDB dbContractChargeDetail = new ContractChargeDetailDB();

            dbContractChargeDetail.TableAccess = dbContract.TableAccess;
			dbContractCharge.TableAccess = dbContract.TableAccess;

			try
			{
				dbContract.TableAccess.OpenTransaction();

                //Contract
				result = dbContract.InsertContract(value, aCompany);

                //ContractCharge
				if(result && value.AContractChargeList.Count>0)
				{
					result = result && dbContractCharge.MaintainContractCharge(value.AContractChargeList);
				}
				else
				{
					dbContractCharge.MaintainContractCharge(value.AContractChargeList);
				}

                //ContractChargeDetail
                if (result && listCharge.Count > 0)
                {
                    result &= dbContractChargeDetail.MaintainContractChargeDetail(listCharge);
                }

                // Assignment Department
                this.insertAssignedDepartment<DriverContract>(value, aCompany, dbContract.TableAccess);

				if(result)
				{
					dbContract.TableAccess.Transaction.Commit();
				}
				else
				{
                    dbContract.TableAccess.Transaction.Rollback();
				}
			}
            catch (SqlException ex)
            {
                dbContract.TableAccess.Transaction.Rollback();
                throw ex;
            }
			catch(Exception ex)
			{
				dbContract.TableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				dbContract.TableAccess.CloseConnection();
                dbContractCharge = null;
                dbContractChargeDetail = null;
			}

			return result;
		}

		private bool insertContract(ServiceStaffContract value, ContractChargeDetailList listCharge, Company aCompany)
		{
			bool result = false;

			ContractChargeDB dbContractCharge = new ContractChargeDB();
            ContractChargeDetailDB dbContractChargeDetail = new ContractChargeDetailDB();

            dbContractChargeDetail.TableAccess = dbContract.TableAccess;
			dbContractCharge.TableAccess = dbContract.TableAccess;

			try
			{
				dbContract.TableAccess.OpenTransaction();

				result = dbContract.InsertContract(value, aCompany);

				if(result && value.AContractChargeList.Count>0)
				{
					result = result && dbContractCharge.MaintainContractCharge(value.AContractChargeList);
				}
				else
				{
					dbContractCharge.MaintainContractCharge(value.AContractChargeList);
				}

                if (result && listCharge.Count > 0)
                {
                    result &= dbContractChargeDetail.MaintainContractChargeDetail(listCharge);
                }

				if(result)
				{
					dbContract.TableAccess.Transaction.Commit();
				}
				else
				{
					dbContract.TableAccess.Transaction.Rollback();
				}
			}
            catch (SqlException ex)
            {
                dbContract.TableAccess.Transaction.Rollback();
                throw ex;
            }
			catch(Exception ex)
			{
				dbContract.TableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				dbContract.TableAccess.CloseConnection();
                dbContractCharge = null;
                dbContractChargeDetail = null;
			}

			return result;
		}

        private bool insertContract(VehicleContract value, ContractChargeDetailList listCharge, Company aCompany)
		{
			bool result = true;
			VehicleContractDB dbVehicleContract = new VehicleContractDB();
			VehicleDB dbVehicle = new VehicleDB();
			TableAccess tableAccess = new TableAccess();
			ContractChargeDB dbContractCharge = new ContractChargeDB();
            ContractChargeDetailDB dbContractChargeDetail = new ContractChargeDetailDB();

            ContractCharge contractCharge = value.AContractChargeList[0];

            dbContractChargeDetail.TableAccess = tableAccess;
			dbContractCharge.TableAccess = tableAccess;
			
			try
			{
				tableAccess.OpenTransaction();
				dbContract.TableAccess = tableAccess;
				dbVehicleContract.TableAccess = tableAccess;
				dbVehicle.TableAccess = tableAccess;

				result = dbContract.InsertContract(value, aCompany);

				if(value.AContractChargeList.Count>0)
				{
					result = result && dbContractCharge.MaintainContractCharge(value.AContractChargeList);
				}
				else
				{
					dbContractCharge.MaintainContractCharge(value.AContractChargeList);
				}

                if (result && listCharge.Count > 0)
                {
                    result &= dbContractChargeDetail.MaintainContractChargeDetail(listCharge);
                }

				if(result)
				{
					result = dbVehicleContract.InsertVehicleContract(value);
				}
				
				if(result && value.APeriod.To >= DateTime.Today)
				{
					for(int i=0; i < value.AVehicleRoleList.Count; i++)
					{
						result &= dbVehicle.UpdateVehicleGeneral(value.AVehicleRoleList[i].AVehicle, value.AVehicleRoleList[i].AKindOfVehicle, aCompany);
					}				
				}

                // Assignment Department
                this.insertAssignedDepartment<VehicleContract>(value, aCompany,tableAccess);

				if(result)
				{
					tableAccess.Transaction.Commit();
					result = true;
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}
			}
			catch(SqlException ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				tableAccess.CloseConnection();
				tableAccess = null;
				dbVehicleContract = null;
				dbContractCharge = null;
				dbVehicle = null;
                dbContractChargeDetail = null;
			}

			return result;
        }
        #endregion

        #region ============================== Update Method ==============================
        private bool updateContract(DriverContract value, ContractChargeDetailList listCharge, Company aCompany)
		{
			bool result = false;

			ContractChargeDB dbContractCharge = new ContractChargeDB();
            ContractChargeDetailDB dbContractChargeDetail = new ContractChargeDetailDB();

            ContractChargeDetailList chargeDetailList = new ContractChargeDetailList(aCompany);
            chargeDetailList.AContract = value;
            dbContractChargeDetail.FillContractChargeDetailNoneBPNoList(chargeDetailList);

            dbContractChargeDetail.TableAccess = dbContract.TableAccess;
			dbContractCharge.TableAccess = dbContract.TableAccess;

			try
			{
				dbContract.TableAccess.OpenTransaction();

                if (value.AContractStatus.Code == "2")
                { 
                    if (value.APeriod.To < DateTime.Today)
                    {
                        //Set contract status to expire : woranai
                        value.AContractStatus = new ContractStatus();
                        value.AContractStatus.Code = "4";
                    }
                }
				result = dbContract.UpdateContract(value, aCompany);

                //Validate for Charge connect BizPac : woranai
                if (value.AContractStatus.Code != "3")
                {
                    if (result && value.AContractChargeList.Count > 0)
                    {
                        result = result && dbContractCharge.MaintainContractCharge(value.AContractChargeList);
                    }
                    else
                    {
                        dbContractCharge.MaintainContractCharge(value.AContractChargeList);
                    }

                    if (result && listCharge.Count > 0)
                    {
                        DateTime genChargeDate = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
                        StringBuilder stringBuilder = new StringBuilder();                        
                        foreach (ContractChargeDetail charge in listCharge)
                        {
                            if (!chargeDetailList.Contain(charge) && genChargeDate <= charge.YearMonth.MinDateOfMonth)
                            {
                                stringBuilder.Append(dbContractChargeDetail.InsertSpecificChargeDetail(charge, value, aCompany));
                            }
                        }

                        dbContractChargeDetail.DeleteSpecificChargeDetail(value.ContractNo, aCompany);
                        if (stringBuilder.Length > 0)
                        {
                            result &= dbContractChargeDetail.ExecuteSpecific(stringBuilder.ToString());
                        }
                    }
                }

				if(result)
				{
					dbContract.TableAccess.Transaction.Commit();
				}
				else
				{
					dbContract.TableAccess.Transaction.Rollback();
				}
			}
            catch (SqlException ex)
            {
                dbContract.TableAccess.Transaction.Rollback();
                throw ex;
            }
			catch(Exception ex)
			{
				dbContract.TableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				dbContract.TableAccess.CloseConnection();
                dbContractCharge = null;
                dbContractChargeDetail = null;
			}

			return result;
		}

		private bool updateContract(ServiceStaffContract value, ContractChargeDetailList listCharge, Company aCompany)
		{
			bool result = false;

			ContractChargeDB dbContractCharge = new ContractChargeDB();
            ContractChargeDetailDB dbContractChargeDetail = new ContractChargeDetailDB();

            ContractChargeDetailList chargeDetailList = new ContractChargeDetailList(aCompany);
            chargeDetailList.AContract = value;
            dbContractChargeDetail.FillContractChargeDetailNoneBPNoList(chargeDetailList);

            dbContractChargeDetail.TableAccess = dbContract.TableAccess;
			dbContractCharge.TableAccess = dbContract.TableAccess;

			try
			{
				dbContract.TableAccess.OpenTransaction();

                if (value.AContractStatus.Code == "2")
                {
                    if (value.APeriod.To < DateTime.Today)
                    {
                        //Set contract status to expire : woranai
                        value.AContractStatus = new ContractStatus();
                        value.AContractStatus.Code = "4";
                    }
                }
				result = dbContract.UpdateContract(value, aCompany);

                //Validate for Charge connect BizPac : woranai
                if (value.AContractStatus.Code != "3")
                {
                    if (result && value.AContractChargeList.Count > 0)
                    {
                        result = result && dbContractCharge.MaintainContractCharge(value.AContractChargeList);
                    }
                    else
                    {
                        dbContractCharge.MaintainContractCharge(value.AContractChargeList);
                    }

                    if (result && listCharge.Count > 0)
                    {
                        DateTime genChargeDate = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
                        StringBuilder stringBuilder = new StringBuilder();
                        foreach (ContractChargeDetail charge in listCharge)
                        {
                            if (!chargeDetailList.Contain(charge) && genChargeDate <= charge.YearMonth.MinDateOfMonth)
                            {
                                stringBuilder.Append(dbContractChargeDetail.InsertSpecificChargeDetail(charge, value, aCompany));
                            }
                        }

                        dbContractChargeDetail.DeleteSpecificChargeDetail(value.ContractNo, aCompany);
                        if (stringBuilder.Length > 0)
                        {
                            result &= dbContractChargeDetail.ExecuteSpecific(stringBuilder.ToString());
                        }
                    }
                }

				if(result)
				{
					dbContract.TableAccess.Transaction.Commit();
				}
				else
				{
					dbContract.TableAccess.Transaction.Rollback();
				}
			}
            catch (SqlException ex)
            {
                dbContract.TableAccess.Transaction.Rollback();
                throw ex;
            }
			catch(Exception ex)
			{
				dbContract.TableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				dbContract.TableAccess.CloseConnection();
                dbContractCharge = null;
                dbContractChargeDetail = null;
			}

			return result;
		}

        private bool updateContract(VehicleContract value, ContractChargeDetailList listCharge, Company aCompany)
		{
			bool result = true;
			bool isCheck = true;
			TableAccess tableAccess = new TableAccess();

			ContractChargeDB dbContractCharge = new ContractChargeDB();
            ContractChargeDetailDB dbContractChargeDetail = new ContractChargeDetailDB();

            ContractChargeDetailList chargeDetailList = new ContractChargeDetailList(aCompany);
            chargeDetailList.AContract = value;
            dbContractChargeDetail.FillContractChargeDetailNoneBPNoList(chargeDetailList);

            dbContractChargeDetail.TableAccess = dbContract.TableAccess;
			dbContractCharge.TableAccess = tableAccess;

			VehicleContract oldVehicleContract = new VehicleContract(aCompany);
			VehicleContractDB dbVehicleContract = new VehicleContractDB();
			VehicleDB dbVehicle = new VehicleDB();
			
			oldVehicleContract.ContractNo = value.ContractNo;
			isCheck &= dbVehicleContract.FillVehicleContract(oldVehicleContract);

			try
			{
				tableAccess.OpenTransaction();

				dbContract.TableAccess = tableAccess;
				dbVehicleContract.TableAccess = tableAccess;
				dbVehicle.TableAccess = tableAccess;

				if(isCheck)
				{
					for(int i=0; i<value.AVehicleRoleList.Count; i++)
					{
						oldVehicleContract.AVehicleRoleList.Remove(value.AVehicleRoleList[i]);			
					}

					for(int i=0; i<oldVehicleContract.AVehicleRoleList.Count; i++)
					{
                        KindOfVehicle kindOfVehicle = new KindOfVehicle();
                        kindOfVehicle.Code = "Z";

                        oldVehicleContract.AVehicleRoleList[i].AKindOfVehicle = kindOfVehicle;
                        result &= dbVehicle.UpdateVehicleGeneral(oldVehicleContract.AVehicleRoleList[i].AVehicle, kindOfVehicle, aCompany);					
					}
				}

                //Validate for Charge connect BizPac : woranai
                if (value.AContractStatus.Code != "3")
                {
                    if (value.AContractChargeList.Count > 0)
                    {
                        result = result && dbContractCharge.MaintainContractCharge(value.AContractChargeList);
                    }
                    else
                    {
                        dbContractCharge.MaintainContractCharge(value.AContractChargeList);
                    }

                    if (result && listCharge.Count > 0)
                    {
                        DateTime genChargeDate = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
                        StringBuilder stringBuilder = new StringBuilder();

                        foreach (ContractChargeDetail charge in listCharge)
                        {
                            if (!chargeDetailList.Contain(charge) && genChargeDate <= charge.YearMonth.MinDateOfMonth)
                            {
                                stringBuilder.Append(dbContractChargeDetail.InsertSpecificChargeDetail(charge, value, aCompany));
                            }
                        }

                        dbContractChargeDetail.DeleteSpecificChargeDetail(value.ContractNo, aCompany);
                        if (stringBuilder.Length > 0)
                        {
                            result &= dbContractChargeDetail.ExecuteSpecific(stringBuilder.ToString());
                        }
                    }
                }

                if (value.AContractStatus.Code == "2")
                {
                    if (value.APeriod.To < DateTime.Today)
                    {
                        //Set contract status to expire : woranai
                        value.AContractStatus = new ContractStatus();
                        value.AContractStatus.Code = "4";
                    }
                }

                result = dbContract.UpdateContract(value, aCompany);

                if (result)
                {
                    if (value.AContractStatus.Code == "1")
                    {
                        dbVehicleContract.DeleteVehicleContract(value);
                        result &= dbVehicleContract.InsertVehicleContract(value);
                    }
                    else if (value.AContractStatus.Code == "2" || value.AContractStatus.Code == "4")
                    {
                        result &= dbVehicleContract.UpdateVehicleContract(value);
                    }
                }                

				for(int i=0; i < value.AVehicleRoleList.Count; i++)
				{
                    if (value.AContractStatus.Code == "3" || value.AContractStatus.Code == "4")
					{
                        KindOfVehicle kindOfVehicle = new KindOfVehicle();
                        kindOfVehicle.Code = "Z";

                        value.AVehicleRoleList[i].AKindOfVehicle = kindOfVehicle;
					}
                    result &= dbVehicle.UpdateVehicleGeneral(value.AVehicleRoleList[i].AVehicle, value.AVehicleRoleList[i].AKindOfVehicle, aCompany);
				}

				if(result)
				{
					tableAccess.Transaction.Commit();
					result = true;
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}
			}
			catch(SqlException ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				tableAccess.CloseConnection();
				dbVehicleContract = null;
				dbContractCharge = null;
				dbVehicle = null;
                dbContractChargeDetail = null;
			}

			return result;
        }

        private bool updateSpecificContract(DriverContract driverContract, VehicleContract vehicleContract, ContractChargeDetailList listDriverCharge, ContractChargeDetailList listVehilceCharge, Company aCompany)
        {
            bool result = false;

            ContractChargeDB dbContractCharge = new ContractChargeDB();
            ContractChargeDetailDB dbContractChargeDetail = new ContractChargeDetailDB();
            VehicleDB dbVehicle = new VehicleDB();
            ContractDepartmentAssignmentDB dbDeptAssign = new ContractDepartmentAssignmentDB(aCompany);

            ContractChargeDetailList chargeDetailDriverList = new ContractChargeDetailList(aCompany);
            chargeDetailDriverList.AContract = driverContract;
            dbContractChargeDetail.FillContractChargeDetailNoneBPNoList(chargeDetailDriverList);

            ContractChargeDetailList chargeDetailVehicleList = new ContractChargeDetailList(aCompany);
            chargeDetailVehicleList.AContract = vehicleContract;
            dbContractChargeDetail.FillContractChargeDetailNoneBPNoList(chargeDetailVehicleList);

            dbContractChargeDetail.TableAccess = dbContract.TableAccess;
            dbContractCharge.TableAccess = dbContract.TableAccess;
            dbVehicle.TableAccess = dbContract.TableAccess;
            dbDeptAssign.TableAccess = dbContract.TableAccess;

            try
            {
                dbContract.TableAccess.OpenTransaction();

                #region - Driver Contract -
                if (driverContract.AContractStatus.Code == "2")
                {
                    if (driverContract.APeriod.To < DateTime.Today)
                    {
                        //Set contract status to expire : woranai
                        //driverContract.AContractStatus.Code = "4";
                        driverContract.AContractStatus = new ContractStatus();
                        driverContract.AContractStatus.Code = "4";
                    }
                }
                result = dbContract.UpdateContract(driverContract, aCompany);
                #endregion

                #region - Vehicle Contract -
                if (vehicleContract.AContractStatus.Code == "2")
                {
                    if (vehicleContract.APeriod.To < DateTime.Today)
                    {
                        //Set contract status to expire : woranai
                        vehicleContract.AContractStatus = new ContractStatus();
                        vehicleContract.AContractStatus.Code = "4";
                    }
                }

                //Update department assignment when amend contract to date : Woranai 2009/04/28
                dbDeptAssign.UpdateByMaxToDate(vehicleContract.ContractNo, vehicleContract.APeriod.To);

                result &= dbContract.UpdateContract(vehicleContract, aCompany);

                if (result)
                {
                    for (int i = 0; i < vehicleContract.AVehicleRoleList.Count; i++)
                    {
                        if (vehicleContract.AContractStatus.Code == "3" || vehicleContract.AContractStatus.Code == "4")
                        {
                            KindOfVehicle kindOfVehicle = new KindOfVehicle();
                            kindOfVehicle.Code = "Z";

                            vehicleContract.AVehicleRoleList[i].AKindOfVehicle = kindOfVehicle;
                        }
                        result &= dbVehicle.UpdateVehicleGeneral(vehicleContract.AVehicleRoleList[i].AVehicle, vehicleContract.AVehicleRoleList[i].AKindOfVehicle, aCompany);
                    }
                }
                #endregion

                #region - Driver Charge -
                if (driverContract.AContractStatus.Code != "3")
                {
                    if (result && driverContract.AContractChargeList.Count > 0)
                    {
                        result = result && dbContractCharge.MaintainContractCharge(driverContract.AContractChargeList);
                    }
                    else
                    {
                        dbContractCharge.MaintainContractCharge(driverContract.AContractChargeList);
                    }

                    if (result && listDriverCharge.Count > 0)
                    {
                        DateTime genChargeDate = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
                        StringBuilder stringBuilder = new StringBuilder();
                        foreach (ContractChargeDetail charge in listDriverCharge)
                        {
                            if (!chargeDetailDriverList.Contain(charge) && genChargeDate <= charge.YearMonth.MinDateOfMonth)
                            {
                                stringBuilder.Append(dbContractChargeDetail.InsertSpecificChargeDetail(charge, driverContract, aCompany));
                            }
                        }

                        dbContractChargeDetail.DeleteSpecificChargeDetail(driverContract.ContractNo, aCompany);
                        if (stringBuilder.Length > 0)
                        {
                            result &= dbContractChargeDetail.ExecuteSpecific(stringBuilder.ToString());
                        }
                    }
                }
                #endregion

                #region - Vehicle Charge -
                if (vehicleContract.AContractStatus.Code != "3")
                {
                    if (result && vehicleContract.AContractChargeList.Count > 0)
                    {
                        result = result && dbContractCharge.MaintainContractCharge(vehicleContract.AContractChargeList);
                    }
                    else
                    {
                        dbContractCharge.MaintainContractCharge(vehicleContract.AContractChargeList);
                    }

                    if (result && listVehilceCharge.Count > 0)
                    {
                        DateTime genChargeDate = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
                        StringBuilder stringBuilder = new StringBuilder();
                        foreach (ContractChargeDetail charge in listVehilceCharge)
                        {
                            if (!chargeDetailVehicleList.Contain(charge) && genChargeDate <= charge.YearMonth.MinDateOfMonth)
                            {
                                stringBuilder.Append(dbContractChargeDetail.InsertSpecificChargeDetail(charge, vehicleContract, aCompany));
                            }
                        }

                        dbContractChargeDetail.DeleteSpecificChargeDetail(vehicleContract.ContractNo, aCompany);
                        if (stringBuilder.Length > 0)
                        {
                            result &= dbContractChargeDetail.ExecuteSpecific(stringBuilder.ToString());
                        }
                    }
                }
                #endregion

                if (result)
                {
                    dbContract.TableAccess.Transaction.Commit();
                }
                else
                {
                    dbContract.TableAccess.Transaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                dbContract.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                dbContract.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                dbContract.TableAccess.CloseConnection();
                dbContractCharge = null;
                dbContractChargeDetail = null;
            }

            return result;
        }

        #endregion

        #region ============================== Delete Method ==============================
        private bool deleteContract(DriverContract value, Company aCompany)
		{
			bool result = false;
			ContractChargeDB dbContractCharge = new ContractChargeDB();
            ContractChargeDetailDB dbContractChargeDetail = new ContractChargeDetailDB();

            dbContractChargeDetail.TableAccess = dbContract.TableAccess;
			dbContractCharge.TableAccess = dbContract.TableAccess;

			try
			{
				dbContract.TableAccess.OpenTransaction();

				result = dbContractCharge.DeleteContractCharge(value.AContractChargeList);
                dbContractChargeDetail.DeleteContractChargeDetail(value, aCompany);

				if(result)
				{
					result = dbContract.DeleteContract(value, aCompany);
				}

				if(result)
				{
					dbContract.TableAccess.Transaction.Commit();
				}
				else
				{
					dbContract.TableAccess.Transaction.Rollback();
				}
			}
            catch (SqlException ex)
            {
                dbContract.TableAccess.Transaction.Rollback();
                throw ex;
            }
			catch(Exception ex)
			{
				dbContract.TableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				dbContract.TableAccess.CloseConnection();
				dbContractCharge = null;
                dbContractChargeDetail = null;
			}

			return result;
		}

		private bool deleteContract(ServiceStaffContract value, Company aCompany)
		{
			bool result = false;
			ContractChargeDB dbContractCharge = new ContractChargeDB();
            ContractChargeDetailDB dbContractChargeDetail = new ContractChargeDetailDB();

            dbContractChargeDetail.TableAccess = dbContract.TableAccess;
			dbContractCharge.TableAccess = dbContract.TableAccess;

			try
			{
				dbContract.TableAccess.OpenTransaction();

				result = dbContractCharge.DeleteContractCharge(value.AContractChargeList);
                dbContractChargeDetail.DeleteContractChargeDetail(value, aCompany);

				if(result)
				{
					result = dbContract.DeleteContract(value, aCompany);
				}

				if(result)
				{
					dbContract.TableAccess.Transaction.Commit();
				}
				else
				{
					dbContract.TableAccess.Transaction.Rollback();
				}
			}
            catch (SqlException ex)
            {
                dbContract.TableAccess.Transaction.Rollback();
                throw ex;
            }
			catch(Exception ex)
			{
				dbContract.TableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				dbContract.TableAccess.CloseConnection();
				dbContractCharge = null;
                dbContractChargeDetail = null;
			}

			return result;
		}

		private bool deleteContract(VehicleContract value, Company aCompany)
		{
			ContractChargeList contractChargeList = new ContractChargeList(aCompany);
			contractChargeList.AContract = value;
            List<VehiclePurchasingContract> listPurchaseContract;

			bool result = true;

			VehicleContractDB dbVehicleContract = new VehicleContractDB();
			VehicleDB dbVehicle = new VehicleDB();
            ContractChargeDetailDB dbContractChargeDetail = new ContractChargeDetailDB();
            ContractChargeDB dbContractCharge = new ContractChargeDB();
            VehiclePurchaseDB dbVehiclePurchase = new VehiclePurchaseDB();
			TableAccess tableAccess = new TableAccess();

            //Check delete car for purchasing.
            using (VehiclePurchaseContractDB purchaseContractDB = new VehiclePurchaseContractDB())
            {
                listPurchaseContract = purchaseContractDB.GetPurchasingContractListByContract(value.ContractNo);
            }
			
			try
			{
				tableAccess.OpenTransaction();
				dbVehicleContract.TableAccess = tableAccess;
				dbContract.TableAccess = tableAccess;				
				dbVehicle.TableAccess = tableAccess;
                dbContractChargeDetail.TableAccess = tableAccess;				
				dbContractCharge.TableAccess = tableAccess;
                dbVehiclePurchase.TableAccess = tableAccess;

                //Clear contract in purchase order or quotation : woranai 2008/10/21
                deleteLeasing(value, tableAccess);

                dbContractCharge.DeleteContractCharge(value.AContractChargeList);
                dbContractChargeDetail.DeleteContractChargeDetail(value, aCompany);

				result = dbVehicleContract.DeleteVehicleContract(value);
				result &= dbContract.DeleteContract(value, aCompany);

                //Check purchase car
                if (listPurchaseContract.Count == 0)
                {
                    for (int i = 0; i < value.AVehicleRoleList.Count; i++)
                    {
                        KindOfVehicle kindOfVehicle = new KindOfVehicle();
                        kindOfVehicle.Code = "Z";

                        value.AVehicleRoleList[i].AKindOfVehicle = kindOfVehicle;
                        result &= dbVehicle.UpdateVehicleGeneral(value.AVehicleRoleList[i].AVehicle, kindOfVehicle, aCompany);
                    }
                }
                else
                {
                    foreach (VehiclePurchasingContract entity in listPurchaseContract)
                    {
                        result &= dbVehicle.DeleteVehicle(entity.Vehicle, aCompany);
                    }
                }
				
				if(result)
				{
					tableAccess.Transaction.Commit();
					result = true;
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}

				dbVehicleContract = null;
				dbVehicle = null;
                dbContractChargeDetail = null;
                dbContractCharge = null;
			}
			catch(SqlException ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				tableAccess.CloseConnection();
			}

            return result;
        }

        /// <summary>
        /// Clear contract in purchase order or quotation
        /// </summary>
        /// <param name="vehicleContract"></param>
        /// <param name="tableAccess"></param>
        private void deleteLeasing(VehicleContract vehicleContract, TableAccess tableAccess)
        {
            if (vehicleContract.AKindOfContract.Code == KindOfContract.KIND_OF_CONTRACT_LONG)
            {
                VehiclePurchaseContractDB dbPurchaseContract = new VehiclePurchaseContractDB();
                dbPurchaseContract.TableAccess = tableAccess;
                dbPurchaseContract.DeleteContractPurchasing((ContractBase)vehicleContract);
            }
            
            if (vehicleContract.ContractNo != null)
            {
                VehicleQuotationDB dbVehicleQuotation = new VehicleQuotationDB();
                dbVehicleQuotation.TableAccess = tableAccess;
                dbVehicleQuotation.DeleteContractQuotation((ContractBase)vehicleContract);
            }
        }
        #endregion

        #endregion


        #region Other Public Methods

        public DocumentNo GetContractNo(string yy, string mm, string xxx)
		{
			return new DocumentNo(DOCUMENT_TYPE.CONTRACT, yy, mm, xxx);
		}

		public ContractBase RetriveContract(DocumentNo value, Company aCompany)
		{
			return dbContract.GetContract(value, aCompany);
		}

		public bool FillContract(ref ContractList value)
		{
			return dbContract.FillContractList(ref value);
		}

		public bool FillContractList(ref ContractList value, ContractBase condition)
		{
			return dbContract.FillContractList(ref value, condition);
		}

		public bool FillContract(ref ContractList value, ContractBase condition, string yy, string mm, string xxx)
		{
			condition.ContractNo = GetContractNo(yy, mm, xxx);
			return dbContract.FillContractList(ref value, condition);
		}

		public bool FillVehicleContractList(ref ContractList value, ContractBase condition)
		{
			bool result;
			condition.AContractType.Code = "V";
			if(condition.AContractStatus == null || condition.AContractStatus.Code == "")
			{
				ContractStatus contractStatus = new ContractStatus();
				contractStatus.Code = "1";
				condition.AContractStatus = contractStatus;
				result = dbContract.FillExcludeVehicleContractList(ref value, condition);
				contractStatus = null;
			}
			else
			{result = dbContract.FillContractList(ref value, condition);}

			return result;
		}

		public bool FillAvailableContractList(ref ContractList value, ContractBase condition, string yy, string mm, string xxx)
		{
			condition.ContractNo = GetContractNo(yy, mm, xxx);
			return dbContract.FillAvailableContractList(ref value, condition);
		}

        public ContractBase GetCurrentVehicleContract(Entity.VehicleEntities.Vehicle aVehicle, Company aCompany)
		{
			ContractBase contractBase = new ContractBase(aCompany);
			if(dbContract.FillCurrentVehicleContract(ref contractBase, aVehicle, aCompany))
			{
				return contractBase;
			}
			else
			{
				contractBase = null;
				return null;
			}
		}

        public ChargeRate GetChargeRate(ContractBase contract, Customer customer, DRIVER_DEDUCT_STATUS deductStatus, Company company)
        {
            bool isDriverOnly = false;
            ServiceStaffType serviceStaffType = null;

            switch (deductStatus)
            {
                case DRIVER_DEDUCT_STATUS.DRIVERONLY:
                    serviceStaffType = new ServiceStaffType("281");
                    isDriverOnly = true;
                    break;
                case DRIVER_DEDUCT_STATUS.DRIVERMATCH:
                    serviceStaffType = new ServiceStaffType("281");
                    isDriverOnly = false;
                    break;

                //Family only not declare : woranai

                //case DRIVER_DEDUCT_STATUS.DRIVERFAMILYONLY:
                //    serviceStaffType = new ServiceStaffType("282");
                //    isDriverOnly = true;
                //    break;
                case DRIVER_DEDUCT_STATUS.DRIVERFAMILYMATCH:
                    serviceStaffType = new ServiceStaffType("282");
                    isDriverOnly = false;
                    break;
                default:
                    return null;
            }

            return InternalGetChargeRate(contract, customer, serviceStaffType, isDriverOnly, company);
        }

        public DriverDeductCharge GetDriverDeductCharge(ContractBase contract, Company company)
        {
            return InternalGetDriverDeductCharge(contract, company);
        }

		public bool InsertContract(ContractBase value, Company aCompany)
		{
            ContractChargeDetailList listCharge = new ContractChargeDetailList(aCompany);

            for (int i = 0; i < value.AContractChargeList.Count; i++)
            {
                getContractChargeDetail(ref listCharge, value.AContractChargeList[i]);
            }

            listCharge.AContract = value;

			switch(value.AContractType.Code)
			{
				case ContractType.CONTRACT_TYPE_DRIVER :
				{
                    return insertContract((DriverContract)value, listCharge, aCompany);
				}
				case ContractType.CONTRACT_TYPE_OTHER :
				{
                    return insertContract((ServiceStaffContract)value, listCharge, aCompany);
				}
				case ContractType.CONTRACT_TYPE_VEHICLE :
				{
					return insertContract((VehicleContract) value, listCharge, aCompany);
				}
				default :
					return false;
			}
		}

		public bool UpdateContract(ContractBase value, Company aCompany)
		{
            ContractChargeDetailList listCharge = new ContractChargeDetailList(aCompany);
            for (int i = 0; i < value.AContractChargeList.Count; i++)
            {
                getContractChargeDetail(ref listCharge, value.AContractChargeList[i]);
            }

            listCharge.AContract = value;

			switch(value.AContractType.Code)
			{
				case ContractType.CONTRACT_TYPE_DRIVER :
				{
					return updateContract((DriverContract) value, listCharge, aCompany);
				}
				case ContractType.CONTRACT_TYPE_OTHER :
				{
                    return updateContract((ServiceStaffContract)value, listCharge, aCompany);
				}
				case ContractType.CONTRACT_TYPE_VEHICLE :
				{
                    return updateContract((VehicleContract)value, listCharge, aCompany);
				}
				default :
					return false;
			}
		}

        public bool UpdateSpecificContract(DriverContract driverContract, VehicleContract vehicleContract, Company company)
        {
            ContractChargeDetailList listDriverCharge = new ContractChargeDetailList(company);
            for (int i = 0; i < driverContract.AContractChargeList.Count; i++)
            {
                getContractChargeDetail(ref listDriverCharge, driverContract.AContractChargeList[i]);
            }

            listDriverCharge.AContract = driverContract;

            ContractChargeDetailList listVehicleCharge = new ContractChargeDetailList(company);
            for (int i = 0; i < vehicleContract.AContractChargeList.Count; i++)
            {
                getContractChargeDetail(ref listVehicleCharge, vehicleContract.AContractChargeList[i]);
            }

            listVehicleCharge.AContract = vehicleContract;

            return updateSpecificContract(driverContract, vehicleContract, listDriverCharge, listVehicleCharge, company);
        }

		public bool DeleteContract(ContractBase value, Company aCompany)
		{
			switch(value.AContractType.Code)
			{
				case ContractType.CONTRACT_TYPE_DRIVER :
				{
					return deleteContract((DriverContract) value, aCompany);
				}
				case ContractType.CONTRACT_TYPE_OTHER :
				{
					return deleteContract((ServiceStaffContract) value, aCompany);
				}
				case ContractType.CONTRACT_TYPE_VEHICLE :
				{
					return deleteContract((VehicleContract) value, aCompany);
				}
				default :
					return false;
			}
		}

		public bool UpdateContractApproveCancel(ContractBase value, Company aCompany)
		{
			return dbContract.UpdateContract(value, aCompany);
		}

		public bool UpdateContractCancel(ContractBase value, Company aCompany)
		{
			bool result = true;
			ServiceStaffAssignment serviceStaffAssignment;
			ServiceStaff serviceStaff;
			ServiceStaffContract serviceStaffContract;
			ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
			ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
			
			TableAccess tableAccess = new TableAccess();			
			
			try
			{
				tableAccess.OpenTransaction();
				dbContract.TableAccess = tableAccess;
				dbServiceStaffAssignment.TableAccess = tableAccess;
				dbServiceStaff.TableAccess = tableAccess;

				serviceStaffAssignment = new ServiceStaffAssignment();
				serviceStaffAssignment.AContract = value;

				serviceStaffContract = new ServiceStaffContract(aCompany);
				serviceStaffContract = (ServiceStaffContract)value;
				
				for(int i=0; i<serviceStaffContract.ALatestServiceStaffRoleList.Count; i++)
				{
					serviceStaff = new ServiceStaff(aCompany);
					serviceStaff = serviceStaffContract.ALatestServiceStaffRoleList[i].AServiceStaff;

					if(serviceStaff.ACurrentContract != null && serviceStaff.ACurrentContract.ContractNo != null && serviceStaff.ACurrentContract.ContractNo.ToString() != "")
					{
						if(serviceStaff.ACurrentContract.ContractNo.ToString() == serviceStaffContract.ContractNo.ToString())
						{
							ServiceStaffType serviceStaffType = new ServiceStaffType();
							serviceStaffType.Type = serviceStaff.APosition.PositionCode + "Z";
							serviceStaff.ACurrentContract = new ServiceStaffContract(aCompany);
							result &= dbServiceStaff.UpdateServiceStaff(serviceStaff, serviceStaffType);
							serviceStaffType = null;
						}
					}
				}

				dbServiceStaffAssignment.DeleteServiceStaffAssignment(serviceStaffAssignment, aCompany);
				result &= dbContract.UpdateContract(value, aCompany);
				serviceStaffAssignment = null;

				if(result)
				{
					tableAccess.Transaction.Commit();
					result = true;
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}

				dbServiceStaffAssignment = null;
				dbServiceStaff = null;
			}
			catch(SqlException ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				tableAccess.CloseConnection();
			}

			return result;
		}

		public bool UpdateContractCancel(VehicleContract value)
		{
			bool result = true;
			VehicleAssignment vehicleAssignment;
			VehicleAssignmentDB dbVehicleAssignment = new VehicleAssignmentDB();
			VehicleDB dbVehicle = new VehicleDB();

			TableAccess tableAccess = new TableAccess();			
			
			try
			{
				tableAccess.OpenTransaction();
				dbContract.TableAccess = tableAccess;
				dbVehicle.TableAccess = tableAccess;
				dbVehicleAssignment.TableAccess = tableAccess;					

                //Comment by : woranai
                //Comment Description : if contract approve, not clear in purchasing.

                // delete leasing before update contract
                //this.deleteLeasing(value, tableAccess);

				result &= dbContract.UpdateContract(value, value.AVehicleRoleList.Company);
			
				for(int i=0; i < value.AVehicleRoleList.Count; i++)
				{
                    KindOfVehicle kindOfVehicle = new KindOfVehicle();
                    kindOfVehicle.Code = "Z";

                    value.AVehicleRoleList[i].AKindOfVehicle = kindOfVehicle;
                    result &= dbVehicle.UpdateVehicleGeneral(value.AVehicleRoleList[i].AVehicle, kindOfVehicle, value.AVehicleRoleList.Company);
					
					vehicleAssignment = new VehicleAssignment();
					vehicleAssignment.AAssignedVehicle = value.AVehicleRoleList[i].AVehicle;
					vehicleAssignment.APeriod = value.APeriod;
					vehicleAssignment.AContract = value;

					dbVehicleAssignment.DeleteVehicleAssignment(vehicleAssignment, value.AVehicleRoleList.Company);
				}

				if(result)
				{
					tableAccess.Transaction.Commit();
					result = true;
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}

				dbVehicleAssignment = null;
				dbVehicle = null;
			}
			catch(SqlException ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				tableAccess.CloseConnection();
			}

			return result;
		}

		public bool UpdateContractApprove(VehicleContract value)
		{
			bool result = true;
			VehicleAssignment vehicleAssignment;
			VehicleAssignmentDB dbVehicleAssignment = new VehicleAssignmentDB();
			TableAccess tableAccess = new TableAccess();			
			
			try
			{
				tableAccess.OpenTransaction();
				dbContract.TableAccess = tableAccess;
				dbVehicleAssignment.TableAccess = tableAccess;	
				
				result &= dbContract.UpdateContract(value, value.AVehicleRoleList.Company);
			
				for(int i=0; i < value.AVehicleRoleList.Count; i++)
				{					
					vehicleAssignment = new VehicleAssignment();
					vehicleAssignment.AAssignedVehicle = value.AVehicleRoleList[i].AVehicle;
					vehicleAssignment.APeriod = value.APeriod;
					vehicleAssignment.AContract = value;
					vehicleAssignment.AMainVehicle = value.AVehicleRoleList[i].AVehicle;
					vehicleAssignment.AssignmentRole = ASSIGNMENT_ROLE_TYPE.MAIN;
					vehicleAssignment.AHirer.Name = "";

					result &= dbVehicleAssignment.InsertVehicleAssignment(vehicleAssignment, value.AVehicleRoleList.Company);
				}

				if(result)
				{
					tableAccess.Transaction.Commit();
					result = true;
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}

				dbVehicleAssignment = null;
				vehicleAssignment = null;
			}
			catch(SqlException ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				tableAccess.CloseConnection();
			}

			return result;
        }

         /// <summary>
         /// Issue contract for renewal car
         /// Author      : Thawatchai B.
         /// Create Date : 03/10/08 
         /// </summary>
         /// <param name="calculation"></param>
         /// <param name="company"></param>
         /// <param name="tableAccess"></param>
         /// <returns>Contract No.</returns>
        public string IssueContractByQuotation(VehicleCalculation calculation, Company company, TableAccess tableAccess)
        {
            ContractDB dbContract = new ContractDB();
            VehicleContractDB dbVehicleContract = new VehicleContractDB();
            VehicleDB dbVehicle = new VehicleDB();
            ContractChargeDB dbContractCharge = new ContractChargeDB();
            DocumentNo contractNo = null;
            using (DocumentNoFlow flow = new DocumentNoFlow())
            {
                contractNo = flow.GetContractRunningNo(DOCUMENT_TYPE.CONTRACT, company);
            }
            bool result = true;
            try
            {
                dbContract.TableAccess = tableAccess;
                dbVehicleContract.TableAccess = tableAccess;
                dbVehicle.TableAccess = tableAccess;
                dbContractCharge.TableAccess = tableAccess;

                ContractBase contractBase = new ContractBase();
                contractBase.AContractType = new ContractType();
                contractBase.AKindOfContract = new KindOfContract();
                contractBase.ACustomer = new Customer();
                contractBase.ACustomerDepartment = new CustomerDepartment();
                contractBase.AContractStatus = new ContractStatus();

                //1.4 Create object ContractBase and insert contract by call function 
                contractBase.ContractNo = contractNo;
                contractBase.ContractDate = calculation.Quotation.IssueDate.Value;
                contractBase.AContractType.Code = ContractType.CONTRACT_TYPE_VEHICLE;
                contractBase.AKindOfContract.Code = KindOfContract.KIND_OF_CONTRACT_LONG;
                contractBase.APeriod.From = calculation.Quotation.IssueDate.Value;
                contractBase.APeriod.To = calculation.Quotation.IssueDate.Value;
                contractBase.ACustomer = calculation.Customer;
                contractBase.ACustomerDepartment.ACustomer = calculation.Customer;
                contractBase.UnitHire = 1;
                contractBase.RateStatus = RATE_STATUS_TYPE.MONTH;
                contractBase.AContractStatus.Code = ContractStatus.CONTRACT_STS_CREATED;
                contractBase.CancelDate = NullConstant.DATETIME;

                result &= dbContract.InsertContract(contractBase, company);

                //1.5 Create object VehicleContract and insert vehicle contract by call function
                VehicleContract vehicleContract = new VehicleContract(company);

                vehicleContract.ContractNo = contractNo;

                if (calculation.Quotation.QuotationStatus == QUOTATION_STATUS_TYPE.NEWQ)
                {
                    vehicleContract.KindOfRental = KIND_OF_RENTAL_TYPE.NEWCAR;
                }
                else if (calculation.Quotation.QuotationStatus == QUOTATION_STATUS_TYPE.RENEWALQ)
                {
                    vehicleContract.KindOfRental = KIND_OF_RENTAL_TYPE.RENEWAL;
                }
                else if(calculation.Quotation.QuotationStatus == QUOTATION_STATUS_TYPE.USEDQ)
                { 
                    vehicleContract.KindOfRental = KIND_OF_RENTAL_TYPE.USEDCAR;
                }

                if (calculation.Quotation.QuotationStatus == QUOTATION_STATUS_TYPE.RENEWALQ)
                {
                    vehicleContract.ContinuousStatus = true;
                }
                else
                {
                    vehicleContract.ContinuousStatus = false;                
                }

                vehicleContract.LeaseTermMonth = calculation.LeaseTerm;

                vehicleContract.AVehicleRoleList = new VehicleRoleList(company);
                VehicleRole vehicleRole = new VehicleRole();
                vehicleContract.AVehicleRoleList.Company.CompanyCode = company.CompanyCode;
                vehicleRole.AVehicle = new Entity.VehicleEntities.Vehicle();

                vehicleRole.AVehicle = calculation.Quotation.VehicleContract.AVehicleRoleList[0].AVehicle;
                vehicleRole.AKindOfVehicle = calculation.Quotation.KindOfVehicle;

                vehicleContract.AVehicleRoleList.Add(vehicleRole);

                result &= dbVehicleContract.InsertVehicleContract(vehicleContract);

                if (vehicleRole.AKindOfVehicle.Code == "Z")
                {
                    result &= dbVehicle.UpdateKindOfVehicle(vehicleRole.AVehicle, vehicleRole.AKindOfVehicle, company);
                }

                //1.6 Create object ContractChargeList and insert charge by call function 
                ContractChargeList contractChargeList = new ContractChargeList(company);
                contractChargeList.Company.CompanyCode = company.CompanyCode;
                contractChargeList.AContract = contractBase;

                ContractCharge contractCharge = new ContractCharge();
                contractCharge.APeriod.From = calculation.Quotation.IssueDate.Value;
                contractCharge.APeriod.To = calculation.Quotation.IssueDate.Value;
                contractCharge.UnitChargeAmount = calculation.MonthlyCharge;
                contractCharge.FirstMonthCharge = 0;
                contractCharge.MonthlyCharge = 0;
                contractCharge.LastMonthCharge = 0;

                contractChargeList.Add(contractCharge);
                result &= dbContractCharge.MaintainContractCharge(contractChargeList);


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
            }
            if (result)
            {
                return contractNo.ToString();
            }
            else return string.Empty;
        }

        /// <summary>
        /// Issue contract for new car
        /// </summary>
        /// <param name="calculation"></param>
        /// <param name="company"></param>
        /// <param name="tableAccess"></param>
        /// <returns>Contract No.</returns>
        public string IssueContractByPurchaseOrder(VehicleCalculation calculation, Company company, TableAccess tableAccess)
        {
            ContractDB dbContract = new ContractDB();
            VehicleContractDB dbVehicleContract = new VehicleContractDB();
            VehicleDB dbVehicle = new VehicleDB();
            ContractChargeDB dbContractCharge = new ContractChargeDB();

            DocumentNo contractNo = null;   
            using (DocumentNoFlow flow = new DocumentNoFlow())
            {
                contractNo = flow.GetContractRunningNo(DOCUMENT_TYPE.CONTRACT, company);
            }
            bool result = true;
            
            try
            {
                dbContract.TableAccess = tableAccess;
                dbVehicleContract.TableAccess = tableAccess;
                dbVehicle.TableAccess = tableAccess;
                dbContractCharge.TableAccess = tableAccess;

                ContractBase contractBase = new ContractBase();
                contractBase.AContractType = new ContractType();
                contractBase.AKindOfContract = new KindOfContract();
                contractBase.ACustomerDepartment = new CustomerDepartment();
                contractBase.AContractStatus = new ContractStatus();

                //Create object ContractBase and insert contract by call function 
                contractBase.ContractNo = contractNo;
                contractBase.ContractDate = calculation.Quotation.Purchasing.IssueDate.Date;
                contractBase.AContractType.Code = ContractType.CONTRACT_TYPE_VEHICLE;
                contractBase.AKindOfContract.Code = KindOfContract.KIND_OF_CONTRACT_LONG;
                contractBase.APeriod.From = calculation.Quotation.Purchasing.IssueDate.Date;
                contractBase.APeriod.To = calculation.Quotation.Purchasing.IssueDate.Date;
                contractBase.ACustomer = calculation.Customer;
                contractBase.ACustomerDepartment.ACustomer = calculation.Customer;
                contractBase.UnitHire = 1;
                contractBase.RateStatus = RATE_STATUS_TYPE.MONTH;
                contractBase.AContractStatus.Code = ContractStatus.CONTRACT_STS_CREATED;
                contractBase.CancelDate = NullConstant.DATETIME ;

                result &= dbContract.InsertContract(contractBase,company);


                //Create object VehicleContract and insert vehicle contract by call function
                VehicleContract vehicleContract = new VehicleContract(company);

                vehicleContract.ContractNo = contractNo;
                vehicleContract.KindOfRental = KIND_OF_RENTAL_TYPE.NEWCAR;
                vehicleContract.LeaseTermMonth = calculation.LeaseTerm;
                vehicleContract.ContinuousStatus = false;
                vehicleContract.AVehicleRoleList = new VehicleRoleList(company);
                VehicleRole vehicleRole = new VehicleRole();
                vehicleContract.AVehicleRoleList.Company.CompanyCode = company.CompanyCode;
                vehicleRole.AVehicle = new Entity.VehicleEntities.Vehicle();
                vehicleRole.AVehicle = calculation.Quotation.VehicleContract.AVehicleRoleList[0].AVehicle;
                vehicleRole.AKindOfVehicle = calculation.Quotation.KindOfVehicle;

                vehicleContract.AVehicleRoleList.Add(vehicleRole);

                result &= dbVehicleContract.InsertVehicleContract(vehicleContract);

                //1.6 Create object ContractChargeList and insert charge by call function 
                ContractChargeList contractChargeList = new ContractChargeList(company);
                contractChargeList.Company.CompanyCode = company.CompanyCode;
                contractChargeList.AContract = contractBase;

                ContractCharge contractCharge = new ContractCharge();
                contractCharge.APeriod.From = calculation.Quotation.IssueDate.Value;
                contractCharge.APeriod.To = calculation.Quotation.IssueDate.Value;
                contractCharge.UnitChargeAmount = calculation.MonthlyCharge;
                contractCharge.FirstMonthCharge = 0;
                contractCharge.MonthlyCharge = 0;
                contractCharge.LastMonthCharge = 0;

                contractChargeList.Add(contractCharge);
                result &= dbContractCharge.MaintainContractCharge(contractChargeList);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
            }

            if (result)
            {
                return contractNo.ToString();
            }
            else return string.Empty;
        }

        /// <summary>
        /// To select data don't have main and spare staff assignment between period date
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public ContractBase GetContractStaffSpareByPeriod(string employeeNo, TimePeriod timePeriod,Company aCompany)
        {
            return dbContract.GetContractStaffSpareByPeriod(employeeNo, timePeriod,aCompany);
        }

        /// <summary>
        /// To select data don't have main and spare staff assignment between period date for assign new main staff
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public ContractBase GetContractStaffMainByPeriod(string employeeNo, TimePeriod timePeriod, Company aCompany)
        {
            return dbContract.GetContractStaffMainPeriod(employeeNo, timePeriod, aCompany);
        }

        public bool FillContractExpireByYearMonth(ContractList contractList, ContractBase condition)
        {
            return dbContract.FillContractExpireByYearMonth(contractList, condition);
        }

        public bool FillContractExpireByYearMonthExistsPurchasing(ContractList contractList, ContractBase condition)
        {
            return dbContract.FillContractExpireByYearMonthExistsPurchasing(contractList, condition);
        }

        /// <summary>
        /// Fill vehicle contract purchasing
        /// </summary>
        /// <param name="contractList"></param>
        /// <param name="condition"></param>
        /// <returns>bool</returns>
        public bool FillContractVehiclePurchasing(ContractList contractList, ContractBase condition)
        {
           
            return dbContract.FillContractVehiclePurchasing(contractList, condition);
        }

        #endregion
    }
}