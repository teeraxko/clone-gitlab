using System;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.ContractEntities;
using Entity.VehicleEntities;

using DataAccess.ContractDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Contract.Flow
{
	public class VehicleAssignmentFlow : FlowBase
	{
		#region - Private -
		private VehicleAssignmentDB dbVehicleAssignment;
		
		#endregion - Private -
		
//		================================ Constructor =====================
		public VehicleAssignmentFlow()
		{
			dbVehicleAssignment = new VehicleAssignmentDB();
		}

//		================================ Public Method =====================
		public VehicleAssignment GetCurrentVehicleAssignment(int assignVehicleNo, Company aCompany)
		{	
			return dbVehicleAssignment.GetCurrentVehicleAssignment(assignVehicleNo, aCompany);
		}

        /// <summary>
        /// Get vehicle assignment from condition in conditionVehicleAssing
        /// </summary>
        /// <param name="conditionVehicleAssign"></param>
        /// <param name="aCompany"></param>
        /// <returns></returns>
        public VehicleAssignment GetCurrentVehicleAssignment(VehicleAssignment conditionVehicleAssign, Company aCompany)
        {
            conditionVehicleAssign.AssignmentRole = Entity.CommonEntity.ASSIGNMENT_ROLE_TYPE.MAIN;
            return dbVehicleAssignment.GetCurrentVehicleAssignment(conditionVehicleAssign, aCompany);
        }
		public bool FillVehicleAssignmentList(ref VehicleAssignmentList value, VehicleAssignment aVehicleAssignment)
		{	
			return dbVehicleAssignment.FillVehicleAssignmentList(ref value, aVehicleAssignment);
		}

		public bool FillVehicleSpareAssignmentList(ref VehicleAssignmentList value, VehicleAssignment aVehicleAssignment)
		{	
			return dbVehicleAssignment.FillVehicleSpareAssignmentList(ref value, aVehicleAssignment);
		}

        public bool FillVehicleSpareAssignmentByRoleList(VehicleAssignmentList value, VehicleAssignment aVehicleAssignment)
        {
            return dbVehicleAssignment.FillVehicleSpareAssignmentByRoleList(value, aVehicleAssignment);
        }

		public bool FillExcludeAvailableVehicleSpareAssignment(ref VehicleAssignment value, Company aCompany)
		{
			return dbVehicleAssignment.FillExcludeAvailableVehicleSpareAssignment(ref value, aCompany);
		}

        public bool FillVehicleMainAssignmentList(VehicleAssignmentList listAssignment, int vehicleNo)
        {
            return dbVehicleAssignment.FillVehicleMainAssignmentList(listAssignment, vehicleNo);
        }

        public VehicleAssignment GetMaxAssignedByContract(DocumentNo contractNo, Company company)
        {
            return dbVehicleAssignment.GetMaxAssignedByContract(contractNo, company);
        }

		public bool InsertVehicleAssignment(VehicleAssignment value, Company aCompany)
		{
			bool result = true;			
			TableAccess tableAccess = new TableAccess();			
			
			try
			{
				SpareVehicleReplacementReasonDB dbSpareVehicleReplacementReason = new SpareVehicleReplacementReasonDB();

				tableAccess.OpenTransaction();

				dbVehicleAssignment.TableAccess = tableAccess;
				dbSpareVehicleReplacementReason.TableAccess = tableAccess;

				result &= dbVehicleAssignment.InsertVehicleAssignment(value, aCompany);
				result &= dbSpareVehicleReplacementReason.UpdateMTB(value.AAssignmentReason);

				if(result)
				{
					tableAccess.Transaction.Commit();
					result = true;
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}

				dbSpareVehicleReplacementReason = null;
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

		public bool UpdateVehicleAssignment(VehicleAssignment oldVehicleAssignment, VehicleAssignment newVehicleAssignment, Company aCompany)
		{
			bool result = true;			
			TableAccess tableAccess = new TableAccess();			
			
			try
			{
				SpareVehicleReplacementReasonDB dbSpareVehicleReplacementReason = new SpareVehicleReplacementReasonDB();

				tableAccess.OpenTransaction();

				dbVehicleAssignment.TableAccess = tableAccess;
				dbSpareVehicleReplacementReason.TableAccess = tableAccess;

				result &= dbVehicleAssignment.DeleteVehicleAssignment(oldVehicleAssignment, aCompany);
				result &= dbVehicleAssignment.InsertVehicleAssignment(newVehicleAssignment, aCompany);
				result &= dbSpareVehicleReplacementReason.UpdateMTB(newVehicleAssignment.AAssignmentReason);

				if(result)
				{
					tableAccess.Transaction.Commit();
					result = true;
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}

				dbSpareVehicleReplacementReason = null;
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

		public bool DeleteVehicleAssignment(VehicleAssignment value, Company aCompany)
		{
			return dbVehicleAssignment.DeleteVehicleAssignment(value, aCompany);
		}

		public bool InsertVehicleSpareAssignment(VehicleAssignment value, Company aCompany)
		{
			bool result = true;			
			TableAccess tableAccess = new TableAccess();			
			
			try
			{
				VehicleContractDB dbVehicleContract = new VehicleContractDB();
				SpareVehicleInternalUsageReasonDB dbSpareVehicleInternalUsageReason = new SpareVehicleInternalUsageReasonDB();

				VehicleContract vehicleContract = new VehicleContract(aCompany);
				VehicleRole vehicleRole = new VehicleRole();
				KindOfVehicle kindOfVehicle = new KindOfVehicle();

				kindOfVehicle.Code = KindOfVehicle.SPARE;

				vehicleRole.AVehicle = value.AAssignedVehicle;
				vehicleRole.AKindOfVehicle = kindOfVehicle;

				vehicleContract.ContractNo = value.AContract.ContractNo;
				vehicleContract.AVehicleRoleList.Add(vehicleRole);

                Entity.VehicleEntities.Vehicle vehicle = value.AAssignedVehicle;

				tableAccess.OpenTransaction();

				if(!dbVehicleContract.FillVehicleContract(vehicleContract, vehicle))
				{
					dbVehicleContract.TableAccess = tableAccess;
					result &= dbVehicleContract.InsertVehicleContract(vehicleContract);
				}
				
				dbVehicleAssignment.TableAccess = tableAccess;	
				dbSpareVehicleInternalUsageReason.TableAccess = tableAccess;

				result &= dbVehicleAssignment.InsertVehicleAssignment(value, aCompany);
				result &= dbSpareVehicleInternalUsageReason.UpdateMTB(value.AAssignmentReason);

				if(result)
				{
					tableAccess.Transaction.Commit();
					result = true;
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}

				vehicleContract = null;
				vehicleRole = null;
				kindOfVehicle = null;
				vehicle = null;
				dbVehicleContract = null;
				dbSpareVehicleInternalUsageReason = null;
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

		public bool UpdateVehicleSpareAssignment(VehicleAssignment oldVehicleAssignment, VehicleAssignment newVehicleAssignment, Company aCompany)
		{
			bool result = true;			
			TableAccess tableAccess = new TableAccess();			
			
			try
			{
				tableAccess.OpenTransaction();			
				SpareVehicleInternalUsageReasonDB dbSpareVehicleInternalUsageReason = new SpareVehicleInternalUsageReasonDB();
	
				dbVehicleAssignment.TableAccess = tableAccess;	
				dbSpareVehicleInternalUsageReason.TableAccess = tableAccess;
	
				result &= dbVehicleAssignment.DeleteVehicleAssignment(oldVehicleAssignment, aCompany);
				result &= dbVehicleAssignment.InsertVehicleAssignment(newVehicleAssignment, aCompany);
				result &= dbSpareVehicleInternalUsageReason.UpdateMTB(newVehicleAssignment.AAssignmentReason);

				if(result)
				{
					tableAccess.Transaction.Commit();
					result = true;
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}
				dbSpareVehicleInternalUsageReason = null;
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

