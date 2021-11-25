using System;
using System.Data;
using System.Collections;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using Entity.ContractEntities;

using PTB.BTS.PI.Flow;
using PTB.BTS.Contract.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;
namespace Facade.ContractFacade
{
	
	public class ServiceStaffTypeFacade : CommonPIFacadeBase
	{
		#region - Private -
		private ServiceStaffTypeFlow flowServiceStaffType;
		private bool disposed = false;
		#endregion
		//		============================== Property =================================
		private ServiceStaffTypeList objServiceStaffTypeList;
		public ServiceStaffTypeList ObjServiceStaffTypeList
		{
			get{return objServiceStaffTypeList;}
		}
		
//		============================== DataSource ==============================
		public ArrayList DataSourcePosition
		{
			get
			{
				PositionFlow flowPosition = new PositionFlow();
				PositionList positionList = new PositionList(GetCompany());
				PositionList tempPositionList = new PositionList(GetCompany());
				flowPosition.FillOtherServiceStaffPosition(ref positionList);
				flowPosition = null;
				for(int i=0; i<positionList.Count; i++)
				{
					if((positionList[i].APositionType.Type == "S"))
					{
						tempPositionList.Add(positionList[i]);
					}
				}
				return tempPositionList.GetArrayList();
			}
		}

//		============================== Constructor ==============================
		public ServiceStaffTypeFacade()
		{
			flowServiceStaffType = new ServiceStaffTypeFlow();
		}
		
//		============================== Public Method ============================
		public bool DisplayServiceStaffType()
		{
			objServiceStaffTypeList = new ServiceStaffTypeList(GetCompany());
			ServiceStaffType aServiceStaffType = new ServiceStaffType();
			aServiceStaffType.Type = "ZZZ";
			if(flowServiceStaffType.FillOtherServiceStaffTypeList(ref objServiceStaffTypeList))
			{
				objServiceStaffTypeList.Remove(aServiceStaffType);
				return true;
			}
			else
				return false;
		}
		public bool InsertServiceStaffType(ServiceStaffType value)
		{
			if (objServiceStaffTypeList.Contain(value))
			{
				throw new DuplicateException("ServiceStaffTypeFacade");
			}
			else
			{
				if (flowServiceStaffType.InsertServiceStaffType(value, GetCompany()))
				{
					ObjServiceStaffTypeList.Add(value);
					return true;
				}
				else
				{
					return false;
				}
			}			
		}
		public bool UpdateServiceStaffType(ServiceStaffType value)
		{
			if (flowServiceStaffType.UpdateServiceStaffType(value, GetCompany()))
			{
				ObjServiceStaffTypeList[value.EntityKey] = value;
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool DeleteServiceStaffType(ServiceStaffType value)
		{
			if(flowServiceStaffType.DeleteServiceStaffType(value, GetCompany()))
			{
				objServiceStaffTypeList.Remove(value);
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
						// Dispose object here.
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
