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
	public class VehicleSpareAssignmentFacade : CommonPIFacadeBase
	{
		#region - Private -
		private AgeFlow flowAge;
		private VehicleFlow flowVehicle;
		private VehicleAssignmentFlow flowVehicleAssignment;
		private ContractFlow flowContract;
		private bool disposed = false;
		#endregion - Private -

//		============================== Property =================================
		private VehicleAssignmentList objVehicleAssignmentList;
		public VehicleAssignmentList ObjVehicleAssignmentList
		{
			get{return objVehicleAssignmentList;}
		}

//		============================== DataSource ==============================
		public ArrayList DataSourceAssignmentReason
		{
			get
			{
				SpareVehicleInternalUsageReasonFlow flowSpareVehicleInternalUsageReason = new SpareVehicleInternalUsageReasonFlow();
				AssignmentReasonList assignmentReasonList = new AssignmentReasonList();
				flowSpareVehicleInternalUsageReason.FillMTBList(assignmentReasonList);
				return assignmentReasonList.GetArrayList();			
			}
		}

//		============================== Constructor ==============================
		public VehicleSpareAssignmentFacade() : base()
		{
			flowAge = new AgeFlow();
			flowVehicle = new VehicleFlow();
			flowVehicleAssignment = new VehicleAssignmentFlow();
			flowContract = new ContractFlow();
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

		public bool DisplayVehicleSpareAssignment(VehicleAssignment value)
		{
			objVehicleAssignmentList.Clear();
			return flowVehicleAssignment.FillVehicleSpareAssignmentList(ref objVehicleAssignmentList, value);
		}

		public bool FillExcludeAvailableVehicleSpareAssignment(VehicleAssignment value)
		{
			return flowVehicleAssignment.FillExcludeAvailableVehicleSpareAssignment(ref value, GetCompany());
		}

		public bool FillVehicleSpareAssignmentList(ref VehicleAssignmentList value, VehicleAssignment aVehicleAssignment)
		{
			return flowVehicleAssignment.FillVehicleSpareAssignmentList(ref value, aVehicleAssignment);
		}

		public bool InsertVehicleAssignment(VehicleAssignment value)
		{
			if (flowVehicleAssignment.InsertVehicleSpareAssignment(value, GetCompany()))
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
			if (flowVehicleAssignment.UpdateVehicleSpareAssignment(oldVehicleAssignment, newVehicleAssignment, GetCompany()))
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
