using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities;

using PTB.BTS.Common.Flow;
using PTB.BTS.Contract.Flow;

using Facade.CommonFacade;
using Facade.PiFacade;
using Entity.AttendanceEntities;

namespace Facade.ContractFacade
{
	public class ServiceStaffAssignmentFacade : CommonPIFacadeBase
	{
		#region Private variable
		public ServiceStaffAssignmentList AServiceStaffAssignmentList;
		private ServiceStaffAssignmentFlow flowServiceStaffAssignment;
		private ServiceStaffFlow flowServiceStaff;
		private AgeFlow flowAge;
		#endregion

		#region Property
			public string[] DataSourceAssignmentRole
			{
				get
				{
					CTFunction ctFunction = new CTFunction();
					return ctFunction.AssignmentRoleTypeArray;
				}
			}

        private ServiceStaffAssignmentList listSSAssignmentMain;
        public ServiceStaffAssignmentList ListSSAssignmentMain
        {
            get { return listSSAssignmentMain; }
        }
		#endregion

        #region Constructor
        public ServiceStaffAssignmentFacade()
            : base()
        {
            AServiceStaffAssignmentList = new ServiceStaffAssignmentList(GetCompany());
            flowServiceStaffAssignment = new ServiceStaffAssignmentFlow();

            flowServiceStaff = new ServiceStaffFlow();
            flowAge = new AgeFlow();
        } 
        #endregion

        #region Public Method
        public bool CheckAvailable(string ServiceStaffNo, DateTime terminateDate)
        {
            ServiceStaff serviceStaff = new ServiceStaff(ServiceStaffNo, GetCompany());
            bool result = flowServiceStaffAssignment.CheckAvailable(serviceStaff, terminateDate);
            serviceStaff = null;
            return result;
        }

        public ServiceStaffType GetServiceStaffType(ContractBase contract)
        {
            return flowServiceStaffAssignment.GetServiceStaffType(contract, GetCompany());
        }

        public bool IsCurrentMain(ServiceStaffAssignment value)
        {
            return flowServiceStaffAssignment.IsCurrentMain(value);
        }

        public YearMonth CalculateAge(DateTime value)
        {
            return flowAge.CalculateAge(value);
        }

        public ServiceStaff GetServiceStaff(string employeeNo)
        {
            return flowServiceStaff.GetCompleteServiceStaff(employeeNo, GetCompany());
        }

        public bool DisplayServiceStaffAssignment()
        {
            AServiceStaffAssignmentList.Clear();
            return flowServiceStaffAssignment.FillServiceStaffAssignmentList(ref AServiceStaffAssignmentList);
        }

        public bool DisplayServiceStaffAssignment(ServiceStaffAssignmentList value)
        {
            return flowServiceStaffAssignment.FillServiceStaffAssignmentList(ref value);
        }

        public bool FillNotAvailableServiceStaffAssignment(ServiceStaffAssignment staffAssign)
        {
            return flowServiceStaffAssignment.FillNotAvailableServiceStaffAssignment(ref staffAssign, GetCompany());
        }

        public bool DisplaySSAssignmentMain(string mainEmployee)
        {
            listSSAssignmentMain = new ServiceStaffAssignmentList(GetCompany());
            return flowServiceStaffAssignment.FillSSAssignmentMainList(listSSAssignmentMain, mainEmployee);
        }

        public bool FillServiceStaffAssignmentList(ref ServiceStaffAssignmentList value, ServiceStaffAssignment condition)
        {
            return flowServiceStaffAssignment.FillServiceStaffAssignmentList(ref value, condition);
        }

        /// <summary>
        /// Get vehicle from VDContract by service staff contract
        /// </summary>
        /// <param name="contractNo"></param>
        /// <param name="employeeNo"></param>
        /// <returns>Vehicle</returns>
        //Modify by woranai 2009/04/27
        public Vehicle GetVehicle(DocumentNo contractNo, string employeeNo)
        {
            Vehicle vehicle = null;

            using (VDContractMatchFlow flow = new VDContractMatchFlow())
            {
                VehicleContract vehicleContract = new VehicleContract(GetCompany());
                DriverContract driverContract = new DriverContract(GetCompany());
                driverContract.ContractNo = contractNo;
                vehicleContract.ADriverContract = driverContract;

                if (flow.FillVDContractMatch(ref vehicleContract))
                {
                    vehicle = vehicleContract.AVehicleRoleList[0].AVehicle;
                }

                vehicleContract = null;
                driverContract = null;
            }            

            return vehicle;
        }

        public bool InsertServiceStaffAssignment(ServiceStaffAssignment value)
        {
            if (flowServiceStaffAssignment.InsertServiceStaffAssignment(value, GetCompany()))
            {
                AServiceStaffAssignmentList.Add(value);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateServiceStaffAssignment(ServiceStaffAssignment value, ServiceStaffAssignment condition)
        {
            if (flowServiceStaffAssignment.UpdateServiceStaffAssignment(value, condition))
            {
                AServiceStaffAssignmentList.Remove(condition);
                AServiceStaffAssignmentList.Add(value);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteServiceStaffAssignment(ServiceStaffAssignment value)
        {
            if (flowServiceStaffAssignment.DeleteServiceStaffAssignment(value))
            {
                if (AServiceStaffAssignmentList.Contain(value))
                {
                    AServiceStaffAssignmentList.Remove(value);
                }
                return true;
            }
            return false;
        }

        public ContractBase GetContract(DocumentNo contractNo)
        {
            using (ContractFlow flow = new ContractFlow())
            {
                return flow.RetriveContract(contractNo, GetCompany());
            }
        }

        /// <summary>
        /// To get employee detail with time period
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public ServiceStaff GetServiceStaffMainByPeriod(string employeeNo, TimePeriod timePeriod)
        {
            return flowServiceStaff.GetServiceStaffMainByPeriod(employeeNo, timePeriod,this.GetCompany());
        }

        /// <summary>
        /// To select data of service staff assignment who is main role on assign period date.
        /// </summary>
        /// <param name="staff"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public System.Collections.Generic.List<ServiceStaffAssignment> GetStaffMainAssignByPeriod(ServiceStaff staff, TimePeriod timePeriod)
        {
            return flowServiceStaffAssignment.GetStaffMainAssignByPeriod(staff, timePeriod,this.GetCompany());
        }

        /// <summary>
        /// To select data of main assign staff on period
        /// </summary>
        /// <param name="staffAssignList"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public bool FillStaffMainAssignByPeriodList(ServiceStaffAssignmentList staffAssignList, TimePeriod timePeriod)
        {
            return flowServiceStaffAssignment.FillStaffMainAssignByPeriodList(staffAssignList, timePeriod,this.GetCompany());
        }

        /// <summary>
        /// To select data don't have main and spare staff assignment between period date
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public ContractBase GetContractStaffSpareByPeriod(string employeeNo, TimePeriod timePeriod)
        {
            using (ContractFlow flow = new ContractFlow())
            {
                return flow.GetContractStaffSpareByPeriod(employeeNo, timePeriod,this.GetCompany());
            }
        }

        /// <summary>
        /// To select data don't have main and spare staff assignment between period date for assign new main staff
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <param name="timePeriod"></param>
        /// <returns></returns>
        public ContractBase GetContractStaffMainByPeriod(string employeeNo, TimePeriod timePeriod)
        {
            using (ContractFlow flow = new ContractFlow())
            {
                return flow.GetContractStaffMainByPeriod(employeeNo, timePeriod, this.GetCompany());
            }
        }
        #endregion
	}
}