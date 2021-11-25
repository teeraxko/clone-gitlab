using System;

using Entity.ContractEntities;
using Entity.CommonEntity;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using DataAccess.ContractDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Contract.Flow
{
	public class ServiceStaffTypeFlow : FlowBase
	{
		#region - Private -
			private bool disposed = false;
			private ServiceStaffTypeDB dbServiceStaffType;
		#endregion - Private -

		public ServiceStaffTypeFlow() : base()
		{
			dbServiceStaffType = new ServiceStaffTypeDB();
		}

//		============================== Public Method ============================
		public ServiceStaffTypeList GetServiceStaffTypeList(Company value)
		{
			ServiceStaffTypeList serviceStaffTypeList = new ServiceStaffTypeList(value);
			dbServiceStaffType.FillServiceStaffTypeList(ref serviceStaffTypeList);
			return serviceStaffTypeList;
		}

		public bool FillServiceStaffTypeList(ref ServiceStaffTypeList value)
		{
			return dbServiceStaffType.FillServiceStaffTypeList(ref value);
		}

		public bool FillServiceStaffTypeList(ref ServiceStaffTypeList value, ServiceStaffType aServiceStaffType)
		{
			return dbServiceStaffType.FillServiceStaffTypeList(ref value, aServiceStaffType);
		}

		public bool FillOtherServiceStaffTypeList(ref ServiceStaffTypeList value)
		{
			ServiceStaffType serviceStaffType = new ServiceStaffType();
			serviceStaffType.APosition.APositionRole = POSITION_ROLE_TYPE.DRIVER;
			if(dbServiceStaffType.FillExcludeServiceStaffTypeList(ref value, serviceStaffType))
			{
				serviceStaffType = null;
				return true;
			}
			else
			{
				return false;
			}			
		}

        public bool FillExcludeServiceStaffTypeList(ServiceStaffTypeList value, ServiceStaffType condition)
        {
            return dbServiceStaffType.FillExcludeServiceStaffTypeList(ref value, condition);
        }

        //============================= Insert Service Staff Type ========================//
		public bool InsertServiceStaffType(ServiceStaffType value, Company aCompany)
		{
			return dbServiceStaffType.InsertServiceStaffType(value, aCompany);
		}
        //Case Driver : Service Staff Position Car Driver.
		public bool InsertPositionDriverServiceStaffType(Position value, Company aCompany)
		{
			ServiceStaffType serviceStaffType = new ServiceStaffType();
			serviceStaffType.APosition = value;
			serviceStaffType.Type = value.PositionCode + "1";
			serviceStaffType.ADescription.English = value.AName.English + "Spare";
			serviceStaffType.ADescription.Thai = value.AName.Thai + "สำรอง";
			return dbServiceStaffType.InsertServiceStaffType(serviceStaffType, aCompany);
		}
	   //Case Driver : Service Staff Family Car Driver.
		public bool InsertFamilyDriverServiceStaffType(Position value, Company aCompany)
		{
			ServiceStaffType serviceStaffType = new ServiceStaffType();
			serviceStaffType.APosition = value;
			serviceStaffType.Type = value.PositionCode + "2";
			serviceStaffType.ADescription.English = value.AName.English + "Spare";
			serviceStaffType.ADescription.Thai = value.AName.Thai + "สำรอง";
			return dbServiceStaffType.InsertServiceStaffType(serviceStaffType, aCompany);
		}
        //All Case : Service Staff Spare for all case. <Driver, Mechanic, Other> 
		public bool InsertSpareServiceStaffType(Position value, Company aCompany)
		{
			ServiceStaffType serviceStaffType = new ServiceStaffType();
			serviceStaffType.APosition = value;
			serviceStaffType.Type = value.PositionCode + "Z";
			serviceStaffType.ADescription.English = value.AName.English + "Spare";
			serviceStaffType.ADescription.Thai = value.AName.Thai + "สำรอง";
			return dbServiceStaffType.InsertServiceStaffType(serviceStaffType, aCompany);
		}


        //============================= Update Service Staff Type ========================//
		public bool UpdateServiceStaffType(ServiceStaffType value, Company aCompany)
		{
			return dbServiceStaffType.UpdateServiceStaffType(value, aCompany);
		}
		//Case Driver : Service Staff Position Car Driver.
		public bool UpdatePositionDriverServiceStaffType(Position value, Company aCompany)
		{
			ServiceStaffType serviceStaffType = new ServiceStaffType();
			serviceStaffType.APosition = value;
			serviceStaffType.Type = value.PositionCode + "1";
			serviceStaffType.ADescription.English = value.AName.English + "Spare";
			serviceStaffType.ADescription.Thai = value.AName.Thai + "สำรอง";
			return dbServiceStaffType.UpdateServiceStaffType(serviceStaffType, aCompany);
		}
		//Case Driver : Service Staff Family Car Driver.
		public bool UpdateFamilyDriverServiceStaffType(Position value, Company aCompany)
		{
			ServiceStaffType serviceStaffType = new ServiceStaffType();
			serviceStaffType.APosition = value;
			serviceStaffType.Type = value.PositionCode + "2";
			serviceStaffType.ADescription.English = value.AName.English + "Spare";
			serviceStaffType.ADescription.Thai = value.AName.Thai + "สำรอง";
			return dbServiceStaffType.UpdateServiceStaffType(serviceStaffType, aCompany);
		}
		//All Case : Service Staff Spare for all case. <Driver, Mechanic, Other> 
		public bool UpdateSpareServiceStaffType(Position value, Company aCompany)
		{
			ServiceStaffType serviceStaffType = new ServiceStaffType();
			serviceStaffType.APosition = value;
			serviceStaffType.Type = value.PositionCode + "Z";
			serviceStaffType.ADescription.English = value.AName.English + "Spare";
			serviceStaffType.ADescription.Thai = value.AName.Thai + "สำรอง";
			return dbServiceStaffType.UpdateServiceStaffType(serviceStaffType, aCompany);
		}
		

		//============================= Delete Service Staff Type ========================//
		public bool DeleteServiceStaffType(ServiceStaffType value, Company aCompany)
		{
			return dbServiceStaffType.DeleteServiceStaffType(value, aCompany);
		}
		//Case Driver : Service Staff Position Car Driver.
		public bool DeletePositionDriverServiceStaffType(Position value, Company aCompany)
		{
			ServiceStaffType serviceStaffType = new ServiceStaffType();
			serviceStaffType.APosition = value;
			serviceStaffType.Type = value.PositionCode + "1";
			serviceStaffType.ADescription.English = value.AName.English + "Spare";
			serviceStaffType.ADescription.Thai = value.AName.Thai + "สำรอง";
			return dbServiceStaffType.DeleteServiceStaffType(serviceStaffType, aCompany);
		}
		//Case Driver : Service Staff Family Car Driver.
		public bool DeleteFamilyDriverServiceStaffType(Position value, Company aCompany)
		{
			ServiceStaffType serviceStaffType = new ServiceStaffType();
			serviceStaffType.APosition = value;
			serviceStaffType.Type = value.PositionCode + "2";
			serviceStaffType.ADescription.English = value.AName.English + "Spare";
			serviceStaffType.ADescription.Thai = value.AName.Thai + "สำรอง";
			return dbServiceStaffType.DeleteServiceStaffType(serviceStaffType, aCompany);
		}
		//All Case : Service Staff Spare for all case. <Driver, Mechanic, Other> 
		public bool DeleteSpareServiceStaffType(Position value, Company aCompany)
		{
			ServiceStaffType serviceStaffType = new ServiceStaffType();
			serviceStaffType.Type = value.PositionCode + "Z";
			return dbServiceStaffType.DeleteServiceStaffType(serviceStaffType, aCompany);
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
						dbServiceStaffType.Dispose();

						dbServiceStaffType = null;
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
