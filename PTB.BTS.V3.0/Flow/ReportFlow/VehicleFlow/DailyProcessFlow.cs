using System;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;
using Entity.AttendanceEntities;

using PTB.BTS.Common.Flow;

using DataAccess.CommonDB;
using DataAccess.VehicleDB;
using DataAccess.ContractDB;
using DataAccess.AttendanceDB;

using ictus.Common.Entity;
using System.Data;
using SystemFramework.AppConfig;

namespace PTB.BTS.Vehicle.Flow
{
	public class DailyProcessFlow : FlowBase
	{
		#region - Private -
		private bool disposed = false;
		private VehicleDB dbVehicle;
		private ServiceStaffDB dbServiceStaff;
		#endregion

//		============================== Constructor ==============================
		public DailyProcessFlow() : base()
		{
			dbVehicle = new VehicleDB();
			dbServiceStaff = new ServiceStaffDB();
		}

//		============================== Private method ==============================
		private bool updateDaily(VehicleContract value, Company aCompany)
		{
			bool result = true;

			KindOfVehicle kindOfVehicle = new KindOfVehicle();
			kindOfVehicle.Code = "Z";
            
            //Update vehicle to spare : woranai 2007/12/26
            foreach (VehicleRole entity in value.AVehicleRoleList)
            {
                result &= dbVehicle.UpdateKindOfVehicle(entity.AVehicle, kindOfVehicle, aCompany);
            }

			return result;
		}

		private bool updateDaily(ServiceStaffContract value, Company aCompany)
		{
			bool result = true;
			ServiceStaff serviceStaff;

			ServiceStaffType serviceStaffType;

			for(int i=0; i<value.ALatestServiceStaffRoleList.Count; i++)
			{
				serviceStaff = new ServiceStaff(aCompany);
				serviceStaffType = new ServiceStaffType();

				serviceStaff = value.ALatestServiceStaffRoleList[i].AServiceStaff;
				serviceStaffType.Type = serviceStaff.APosition.PositionCode + "Z";

				if(serviceStaff != null && serviceStaff.EmployeeNo != "")
				{
					if(serviceStaff.ACurrentContract != null && serviceStaff.ACurrentContract.ContractNo != null)
					{
						if(serviceStaff.ACurrentContract.ContractNo.ToString() == value.ContractNo.ToString())
						{
							serviceStaff.ACurrentContract = new ServiceStaffContract(aCompany);					
							result &= dbServiceStaff.UpdateServiceStaff(serviceStaff, serviceStaffType);
						}
					}
				}
			}
			return result;
		}

		private bool updateDaily(DriverContract value, Company aCompany)
		{
			bool result = true;
			ServiceStaff serviceStaff;

			ServiceStaffType serviceStaffType;

			for(int i=0; i<value.ALatestServiceStaffRoleList.Count; i++)
			{
				serviceStaff = new ServiceStaff(aCompany);
				serviceStaffType = new ServiceStaffType();

				serviceStaff = value.ALatestServiceStaffRoleList[i].AServiceStaff;
				serviceStaffType.Type = serviceStaff.APosition.PositionCode + "Z";

				if(serviceStaff != null && serviceStaff.EmployeeNo != "")
				{
					if(serviceStaff.ACurrentContract != null && serviceStaff.ACurrentContract.ContractNo != null)
					{
						if(serviceStaff.ACurrentContract.ContractNo.ToString() == value.ContractNo.ToString())
						{
							serviceStaff.ACurrentContract = new ServiceStaffContract(aCompany);
							result &= dbServiceStaff.UpdateServiceStaff(serviceStaff, serviceStaffType);				
						}
					}
				}
			}
			return result;
		}

//		==============================Public method ==============================
		public bool UpdateDailyProcess(DateTime forDate, Company aCompany)
		{
			bool result = true;
            bool resultPayroll = false;
            bool resultNonPayroll = false;
			TableAccess tableAccess = new TableAccess();

            ServiceStaffAssignmentDB dbServiceStaffAssignment;
			ContractDB dbContract;
			PayrollPaymentControlDB dbPayrollPaymentControl;
			VehicleRepairingHistoryDB dbVehicleRepairingHistory;	
			NonPayrollPaymentControlDB dbNonPayrollPaymentControl;
			DriverExcessDeductionDB dbDriverExcessDeduction;

			ContractList objContractList;
			VehicleMaintenance objVehicleMaintenance;
            ServiceStaffAssignmentList listServiceStaffAssignment;

			YearMonth forYearMonth;					
			PayrollPaymentControl payrollPaymentControl;
			PayrollPaymentControlList listPayrollPaymentControl;
			NonPayrollPaymentControl nonPayrollPaymentControl;
			NonPayrollPaymentControlList listNonPayrollPaymentControl;
			ExcessDeduction excessDeduction;
			DriverExcessDeduction listDriverExcessDeduction;

			
			try
			{				
				dbContract = new ContractDB();
				dbPayrollPaymentControl = new PayrollPaymentControlDB();
				dbVehicleRepairingHistory = new VehicleRepairingHistoryDB();
				dbNonPayrollPaymentControl = new NonPayrollPaymentControlDB();
				dbDriverExcessDeduction = new DriverExcessDeductionDB();
                dbServiceStaffAssignment = new ServiceStaffAssignmentDB();

				forYearMonth = new YearMonth(forDate);
				objContractList = new ContractList(aCompany);
				objVehicleMaintenance = new VehicleMaintenance(aCompany);

                dbContract.FillContractForDaily(objContractList, forDate, aCompany);
                dbVehicleRepairingHistory.fillVehicleRepairingHistoryForDaily(ref objVehicleMaintenance);

				listPayrollPaymentControl = new PayrollPaymentControlList(aCompany, forYearMonth);
				resultPayroll = dbPayrollPaymentControl.FillPayrollPaymentControlByDateList(ref listPayrollPaymentControl, forDate);

				listDriverExcessDeduction = new DriverExcessDeduction(aCompany);
				for(int i=0; i<listPayrollPaymentControl.Count; i++)
				{
					excessDeduction = new ExcessDeduction();
					excessDeduction.AForMonth = listPayrollPaymentControl[i].AYearMonth;
					if(dbDriverExcessDeduction.FillDriverExcessDeduction(ref excessDeduction, aCompany))
					{
						listDriverExcessDeduction.Add(excessDeduction);
					}
				}

				listNonPayrollPaymentControl = new NonPayrollPaymentControlList(aCompany, forYearMonth);
				resultNonPayroll = dbNonPayrollPaymentControl.FillNonPayrollPaymentControlByDateList(ref listNonPayrollPaymentControl, forDate);

                listServiceStaffAssignment = new ServiceStaffAssignmentList(aCompany);
                dbServiceStaffAssignment.FillSpecificAssignExpire(listServiceStaffAssignment, forDate.AddDays(-1));
                //dbServiceStaffAssignment.FillServiceStaffAssignmentInDateList(ref listServiceStaffAssignment, forDate.AddDays(-1));
                dbServiceStaffAssignment = null;

				tableAccess.OpenTransaction();
				dbServiceStaff.TableAccess = tableAccess;
				dbContract.TableAccess = tableAccess;
				dbVehicle.TableAccess = tableAccess;
				dbPayrollPaymentControl.TableAccess = tableAccess;
				dbNonPayrollPaymentControl.TableAccess = tableAccess;
				dbDriverExcessDeduction.TableAccess = tableAccess;

				#region - Contract -
                foreach (ContractBase contract in objContractList)
                {
                    ContractStatus contractStatus;

                    if (contract.APeriod.To.Date < forDate.Date)
                    {
                        switch (contract.AContractType.Code)
                        {
                            case "V":
                                {
                                    result &= updateDaily((VehicleContract)contract, aCompany);
                                    break;
                                }
                            case "D":
                                {
                                    result &= updateDaily((DriverContract)contract, aCompany);
                                    break;
                                }
                            case "O":
                                {
                                    result &= updateDaily((ServiceStaffContract)contract, aCompany);
                                    break;
                                }
                            default:
                                {
                                    result &= false;
                                    break;
                                }
                        }

                        contractStatus = new ContractStatus();
                        contractStatus.Code = "4";

                        contract.AContractStatus = contractStatus;
                        result &= dbContract.UpdateContract(contract, aCompany);
                    }
                }
				#endregion

				#region - Vehicle -
                VehicleStatus vehicleStatus = new VehicleStatus();
                vehicleStatus.Code = "1";

                foreach (RepairingInfoBase repairing in objVehicleMaintenance)
                {
                    if (repairing.RepairPeriod.To < forDate)
                    {
                        if (repairing.VehicleInfo.AVehicleStatus.Code == "2" || repairing.VehicleInfo.AVehicleStatus.Code == "3")
                        {
                            result &= dbVehicle.UpdateVehicleForDaily(repairing.VehicleInfo, vehicleStatus, aCompany);
                            //result &= dbVehicle.UpdateVehicleInfo(vehicleInfo, vehicleInfo.AKindOfVehicle, aCompany);
                        }
                    }
                }
				#endregion

				#region - PayrollPaymentControl -
				if(result && resultPayroll)
				{		
					payrollPaymentControl = new PayrollPaymentControl();

					for(int i=0; i<listPayrollPaymentControl.Count; i++)
					{
						payrollPaymentControl = listPayrollPaymentControl[i];
						payrollPaymentControl.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.YES;
						result &= dbPayrollPaymentControl.UpdatePayrollPaymentControl(payrollPaymentControl, aCompany);
					}
	
					for(int i=0; i<listDriverExcessDeduction.Count; i++)
					{
						dbDriverExcessDeduction.UpdateDriverExcessDeductionByYearMonth(listDriverExcessDeduction[i].AForMonth, forDate, aCompany);
					}
				}
				#endregion

				#region - NonPayrollPaymentControl -
                if (result && resultNonPayroll)
				{			
					nonPayrollPaymentControl = new NonPayrollPaymentControl();

					for(int i=0; i<listNonPayrollPaymentControl.Count; i++)
					{					
						nonPayrollPaymentControl = listNonPayrollPaymentControl[i];
						nonPayrollPaymentControl.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.YES;
						result &= dbNonPayrollPaymentControl.UpdateNonPayrollPaymentControl(nonPayrollPaymentControl, aCompany);
					}
				}
				#endregion

                #region - ServiceStaff -
                if (result)
                {
                    ServiceStaff serviceStaff;
                    ServiceStaffType serviceStaffType;

                    foreach (ServiceStaffAssignment entity in listServiceStaffAssignment)
                    {
                        if (entity.AAssignedServiceStaff.ACurrentContract != null)
                        {
                            if (entity.AAssignedServiceStaff.ACurrentContract.ContractNo.ToString() == entity.AContract.ContractNo.ToString())
                            {
                                serviceStaff = new ServiceStaff(aCompany);
                                serviceStaffType = new ServiceStaffType();

                                serviceStaff = entity.AAssignedServiceStaff;
                                serviceStaffType.Type = serviceStaff.APosition.PositionCode + "Z";

                                serviceStaff.ACurrentContract = new ServiceStaffContract(aCompany);
                                result &= dbServiceStaff.UpdateServiceStaff(serviceStaff, serviceStaffType);
                            }
                        }
                    }

                    serviceStaff = null;
                    serviceStaffType = null;
                }
               
                #endregion

                #region - Loan -

                if (result && resultPayroll)
                {
                    SqlCommand command = new SqlCommand("SMonthlyProcessLoan");
                    command.Parameters.Add("@forMonthYear", SqlDbType.DateTime).Value = forDate;
                    command.Parameters.Add("@processUser", SqlDbType.VarChar).Value = UserProfile.UserID;

                    result &= (Convert.ToInt32(tableAccess.ExecuteScalarStoredProcedure(command)) == 1);
                }

                #endregion

                #region - Employee Children -
                if (result)
                {
                    SqlCommand command = new SqlCommand("SUpdatePrefixEmployeeChildren");
                    command.Parameters.Add("@DailyDate", SqlDbType.DateTime).Value = forDate;
                    command.Parameters.Add("@ProcessUser", SqlDbType.VarChar).Value = UserProfile.UserID;

                    tableAccess.ExecuteStoredProcedure(command);
                }
                #endregion

                #region - Update vehicle status for selled vehicle -

                if (result)
                {
                    //Created from D08014_PGMS_07_DailyProcess prog. spec.
                    dbVehicle.UpdateSellingVehicle(aCompany);
                }

                #endregion

                #region  - Update welfare payment control -
                if (result)
                {
                    SqlCommand command = new SqlCommand("SUpdateWelfarePaymentControl");
                    command.Parameters.Add("@DailyDate", SqlDbType.DateTime).Value = forDate;
                    command.Parameters.Add("@ProcessUser", SqlDbType.VarChar).Value = UserProfile.UserID;

                    result &= (Convert.ToInt32(tableAccess.ExecuteScalarStoredProcedure(command)) == 1);
                }
                #endregion

                if (result)
				{
					tableAccess.Transaction.Commit();
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
            catch (Exception ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
			finally
			{
				tableAccess.CloseConnection();

				dbContract = null;
				dbPayrollPaymentControl = null;
				dbVehicleRepairingHistory = null;	
				dbNonPayrollPaymentControl = null;
				dbDriverExcessDeduction = null;
				
				objContractList = null;
				objVehicleMaintenance = null;
				payrollPaymentControl = null;
				listPayrollPaymentControl = null;
				nonPayrollPaymentControl = null;
				excessDeduction = null;
				listDriverExcessDeduction = null;
				listNonPayrollPaymentControl = null;
                listServiceStaffAssignment = null;
			}

			return result;
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{						
						dbVehicle.Dispose();
						dbServiceStaff.Dispose();

						dbVehicle = null;
						dbServiceStaff = null;
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion
	}
}
