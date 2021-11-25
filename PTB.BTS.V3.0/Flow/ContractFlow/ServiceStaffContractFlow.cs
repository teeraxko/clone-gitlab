using System;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.ContractEntities;
using Entity.VehicleEntities;
using Entity.CommonEntity;

using DataAccess.ContractDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Contract.Flow
{		
	public class ServiceStaffContractFlow: FlowBase
	{
		#region - Private -
		private ServiceStaffContractDB dbServiceStaffContract;
		#endregion - Private -

//		================================Constructor=====================
		public ServiceStaffContractFlow()
		{
			dbServiceStaffContract = new ServiceStaffContractDB();
		}

//		================================public Method=====================
		public bool FillServiceStaffContract(ref ServiceStaffContract value)
		{
			return dbServiceStaffContract.FillServiceStaffContract(value);
		}

        public bool FillServiceStaffContractByEmployeeOrder(ref ServiceStaffContract value, int empOrder)
        {
            return dbServiceStaffContract.FillServiceStaffContractByEmployeeOrder(ref value, empOrder);
        }

        public bool FillServiceStaffContractByEmployeeNo(ref ServiceStaffContract value, ServiceStaff serviceStaff)
        {
            return dbServiceStaffContract.FillServiceStaffContractByEmployeeNo(ref value, serviceStaff); 
        }

		public bool DeleteServiceStaffContract(ServiceStaffContract aServiceStaffContract, ServiceStaff aServiceStaff)
		{
			return dbServiceStaffContract.DeleteServiceStaffContract(aServiceStaffContract, aServiceStaff);
		}

		public bool InsertServiceStaffContract(ServiceStaffContract aServiceStaffContract, ServiceStaffAssignment aServiceStaffAssignment, ServiceStaff aServiceStaff)
		{
			bool result = true;
			ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
			ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
			TableAccess tableAccess = new TableAccess();			
			
			try
			{
				tableAccess.OpenTransaction();
				dbServiceStaffContract.TableAccess = tableAccess;
				dbServiceStaff.TableAccess = tableAccess;
				dbServiceStaffAssignment.TableAccess = tableAccess;

				result &= dbServiceStaffContract.MaintainServiceStaffContract(aServiceStaffContract);

                //if(aServiceStaffContract.APeriod.From <= DateTime.Today && DateTime.Today <= aServiceStaffContract.APeriod.To)
                if (DateTime.Today <= aServiceStaffContract.APeriod.From || DateTime.Today <= aServiceStaffContract.APeriod.To)
				{
					result &= dbServiceStaff.UpdateServiceStaff(aServiceStaff);
				}

				result &= dbServiceStaffAssignment.InsertServiceStaffAssignment(aServiceStaffAssignment, aServiceStaffAssignment.AAssignedServiceStaff.Company);
	
				if(result)
				{
					tableAccess.Transaction.Commit();
					result = true;
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}
				dbServiceStaff = null;
				dbServiceStaffAssignment = null;
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
			}

			return result;			
		}

		public bool UpdateServiceStaffContract(ServiceStaffContract aServiceStaffContract, ServiceStaffAssignment aServiceStaffAssignment, ServiceStaff aServiceStaff)
		{
			bool result = true;
			ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
			ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
			TableAccess tableAccess = new TableAccess();			
			
			try
			{
				tableAccess.OpenTransaction();
				dbServiceStaffContract.TableAccess = tableAccess;
				dbServiceStaff.TableAccess = tableAccess;
				dbServiceStaffAssignment.TableAccess = tableAccess;

				for(int i=0; i<aServiceStaffContract.ALatestServiceStaffRoleList.Count; i++)
				{
					result &= dbServiceStaffContract.UpdateServiceStaffContract(aServiceStaffContract.ALatestServiceStaffRoleList[i]);
				}

				//if (DateTime.Today <= aServiceStaffContract.APeriod.From || DateTime.Today <= aServiceStaffContract.APeriod.To)
                if (DateTime.Today <= aServiceStaffContract.APeriod.From || DateTime.Today <= aServiceStaffContract.APeriod.To)
				{
					result &= dbServiceStaff.UpdateServiceStaff(aServiceStaff);
				}

				result &= dbServiceStaffAssignment.UpdateServiceStaffAssignment(aServiceStaffAssignment, aServiceStaffContract.ALatestServiceStaffRoleList.Company);
	
				if(result)
				{
					tableAccess.Transaction.Commit();
					result = true;
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}
				dbServiceStaff = null;
				dbServiceStaffAssignment = null;
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
			}

			return result;			
		}

		public bool DeleteServiceStaffContract(ServiceStaffContract aServiceStaffContract, ServiceStaffAssignment aServiceStaffAssignment, ServiceStaff aServiceStaff)
		{
			bool result = true;
			ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
			ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
			TableAccess tableAccess = new TableAccess();			
			
			try
			{
				tableAccess.OpenTransaction();
				dbServiceStaffContract.TableAccess = tableAccess;
				dbServiceStaff.TableAccess = tableAccess;
				dbServiceStaffAssignment.TableAccess = tableAccess;

				result &= dbServiceStaffContract.DeleteServiceStaffContract(aServiceStaffContract, aServiceStaff);
				result &= dbServiceStaffAssignment.DeleteServiceStaffAssignment(aServiceStaffAssignment, aServiceStaffContract.ALatestServiceStaffRoleList.Company);
	
				if(aServiceStaff.ACurrentContract != null && aServiceStaffContract.ContractNo != null)
				{
					if(aServiceStaff.ACurrentContract.ContractNo == aServiceStaffContract.ContractNo)
					{
                        ServiceStaffType serviceStaffType = new ServiceStaffType();
                        serviceStaffType.Type = aServiceStaff.APosition.PositionCode + "Z";
						aServiceStaff.ACurrentContract = new ServiceStaffContract(aServiceStaffContract.ALatestServiceStaffRoleList.Company);
                        result &= dbServiceStaff.UpdateServiceStaff(aServiceStaff, serviceStaffType);
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
				dbServiceStaff = null;
				dbServiceStaffAssignment = null;
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
			}

			return result;			
		}
	}
}
