using System;
using System.Data;
using System.Collections;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;
using PTB.BTS.Contract.Flow;
using PTB.BTS.Vehicle.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

namespace Facade.ContractFacade
{	
	public class VehicleAssignmentFacade : CommonPIFacadeBase
	{
		#region - Private -
		private AgeFlow flowAge;
		private VehicleFlow flowVehicle;
		private VehicleAssignmentFlow flowVehicleAssignment;
		private ContractFlow flowContract;
        private VDContractMatchFlow flowVDContractMatchFlow;
        private ServiceStaffContractFlow flowServiceStaffContract;
        private bool disposed = false;
		#endregion - Private -

//		============================== Property =================================
		private VehicleAssignmentList objVehicleAssignmentList;
		public VehicleAssignmentList ObjVehicleAssignmentList
		{
			get{return objVehicleAssignmentList;}
		}

        private VehicleAssignmentList objVehicleMainList;
        public VehicleAssignmentList ObjVehicleMainList
        {
            get { return objVehicleMainList; }
        }
		
//		============================== DataSource ==============================
		public ArrayList DataSourceAssignmentReason
		{
			get
			{
				SpareVehicleReplacementReasonFlow flowSpareVehicleReplacementReason = new SpareVehicleReplacementReasonFlow();
				AssignmentReasonList assignmentReasonList = new AssignmentReasonList();
				flowSpareVehicleReplacementReason.FillMTBList(assignmentReasonList);
				return assignmentReasonList.GetArrayList();			
			}
		}

//		============================== Constructor ==============================
		public VehicleAssignmentFacade()
		{
			flowAge = new AgeFlow();
			flowVehicle = new VehicleFlow();
			flowVehicleAssignment = new VehicleAssignmentFlow();
			flowContract = new ContractFlow();
            flowVDContractMatchFlow = new VDContractMatchFlow();
            flowServiceStaffContract = new ServiceStaffContractFlow();
			objVehicleAssignmentList = new VehicleAssignmentList(GetCompany());
		}

//      ============================= Calculate Holding Time ====================
		public YearMonth CalculateAge(DateTime value)
		{			
			return flowAge.CalculateAge(value);
		}
		
//		============================== Public Method ============================
		public Vehicle GetVehicle(string platePrefix, string plateNo)
		{
			Vehicle vehicle = new Vehicle();
			vehicle.PlatePrefix = platePrefix;
			vehicle.PlateRunningNo = plateNo;

			if(flowVehicle.FillVehicleGeneral(ref vehicle, GetCompany()))
			{
				return vehicle;
			}
			else
			{
				vehicle = null;
				return null;
			}
		}

		public ContractBase GetCurrentVehicleContract(Vehicle value)
		{
			return flowContract.GetCurrentVehicleContract(value, GetCompany());
		}

        /// <summary>
        /// Get vehicle assignment from condition in conditionVehicleAssing
        /// </summary>
        /// <param name="conditionVehicleAssign"></param>
        /// <returns></returns>
        public VehicleAssignment GetCurrentVehicleAssignment(VehicleAssignment conditionVehicleAssign)
        {
            return flowVehicleAssignment.GetCurrentVehicleAssignment(conditionVehicleAssign, GetCompany());
        }

		public bool DisplayVehicleAssignment(VehicleAssignment value)
		{
			objVehicleAssignmentList.Clear();
			return flowVehicleAssignment.FillVehicleAssignmentList(ref objVehicleAssignmentList, value);
		}

        public bool DisplayVehicleMain(int vehicleNo )
        {
            objVehicleMainList = new VehicleAssignmentList(GetCompany());
            return flowVehicleAssignment.FillVehicleMainAssignmentList(objVehicleMainList, vehicleNo);
        }

        public bool FillExcludeAvailableVehicleSpareAssignment(VehicleAssignment value)
        {
            return flowVehicleAssignment.FillExcludeAvailableVehicleSpareAssignment(ref value, GetCompany());
        }

		public bool FillVehicleGeneral(Vehicle value)
		{
			return flowVehicle.FillVehicleGeneral(ref value,GetCompany());
		}	

		public bool RetriveVehicleIsAssign(int vehicleNo)
		{
			Vehicle vehicle = new Vehicle();
			vehicle.VehicleNo = vehicleNo;
			return flowVehicle.FillVehicleIsAssign(ref vehicle, GetCompany());
		}

        public bool ValidateMainAssignInPeriod(int vehicleNo, DateTime fromDate, DateTime toDate)
        {
            //TODO : Ya

            VehicleList vehicleList = new VehicleList(GetCompany());
            Vehicle vehicle = new Vehicle();
            vehicle.VehicleNo = vehicleNo;

            flowVehicle.FillVehicleIsAssignList(vehicleList, fromDate, toDate, vehicle);

            return (vehicleList.Count > 0);
        }

		public bool FillVehicleSpareAssignmentList(ref VehicleAssignmentList value, VehicleAssignment aVehicleAssignment)
		{
			return flowVehicleAssignment.FillVehicleSpareAssignmentList(ref value, aVehicleAssignment);
		}

        public bool FillVehicleSpareAssignmentByRoleList(VehicleAssignmentList value, VehicleAssignment aVehicleAssignment)
        {
            return flowVehicleAssignment.FillVehicleSpareAssignmentByRoleList(value, aVehicleAssignment);
        }

        public Employee GetDriver(DocumentNo contractNo, int vehicleNo)
        { 
            ServiceStaffContract serviceStaffContract;
            VehicleContract vehicleContract = new VehicleContract(GetCompany());
            vehicleContract.ContractNo = contractNo;

            if (flowVDContractMatchFlow.FillVDContractMatchByVehicle(ref vehicleContract, vehicleNo))
            {
                serviceStaffContract = new ServiceStaffContract(GetCompany());
                serviceStaffContract.ContractNo = vehicleContract.ADriverContract.ContractNo;

                if (flowServiceStaffContract.FillServiceStaffContractByEmployeeOrder(ref serviceStaffContract, vehicleContract.ADriverContract.ALatestServiceStaffRoleList[0].ServiceStaffOrder))
                {
                    return serviceStaffContract.ALatestServiceStaffRoleList[0].AServiceStaff;
                }
            }
            return null;
        }

		public bool InsertVehicleAssignment(VehicleAssignment value)
		{
			if (flowVehicleAssignment.InsertVehicleAssignment(value, GetCompany()))
			{
				ObjVehicleAssignmentList.Add(value);
				return true;
			}
			else
			{
				return false;
			}		
		}

		public bool UpdateVehicleAssignment(VehicleAssignment oldVehicleAssignment, VehicleAssignment newVehicleAssignment)
		{
			if (flowVehicleAssignment.UpdateVehicleAssignment(oldVehicleAssignment, newVehicleAssignment, GetCompany()))
			{
				ObjVehicleAssignmentList.Remove(oldVehicleAssignment);
				ObjVehicleAssignmentList.Add(newVehicleAssignment);
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool DeleteVehicleAssignment(VehicleAssignment value)
		{
			if(flowVehicleAssignment.DeleteVehicleAssignment(value, GetCompany()))
			{
				objVehicleAssignmentList.Remove(value);
				return true;
			}
			else
			{
				return false;
			}
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
						flowAge = null;
						flowVehicle = null;
						flowVehicleAssignment = null;
						flowContract = null;
						objVehicleAssignmentList = null;
					
						flowAge.Dispose();
						flowVehicle.Dispose();
						flowContract.Dispose();
						objVehicleAssignmentList.Dispose();
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
