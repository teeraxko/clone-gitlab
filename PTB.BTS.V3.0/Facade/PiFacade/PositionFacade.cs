using System;
using System.Data;
using System.Collections;

using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

namespace Facade.PiFacade
{
	public class PositionFacade : CommonPIFacadeBase
	{
		#region - Private -
			private PositionFlow flowPosition;
//			private ServiceStaffTypeFlow flowServiceStaffType;
			private bool disposed = false;
		#endregion

		#region - Data Source -
		public ArrayList DataSourcePositionGroup
		{
			get
			{
				PositionGroupFlow flowPositionGroup = new PositionGroupFlow();
				PositionGroupList positionGroupList = new PositionGroupList(GetCompany());
				flowPositionGroup.FillMTBData(positionGroupList);
				return positionGroupList.GetArrayList();			
			}
		}

		public ArrayList DataSourcePositionType
		{
			get
			{
				PositionTypeFlow flowPositionType = new PositionTypeFlow();
				return flowPositionType.GetPositionTypeList(GetCompany()).GetArrayList();
			}
		}
		#endregion - Data Source -

//		============================== Property ==============================
		private PositionList objPositionList;
		public PositionList ObjPositionList
		{
			get{return objPositionList;}
		}
		
//		============================== Constructor ==============================
		public PositionFacade()
		{
			flowPosition = new PositionFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayPosition()
		{
			objPositionList = new PositionList(GetCompany());
			return flowPosition.FillPosition(ref objPositionList);
		}

		public bool FillPosition(Position value)
		{
			return flowPosition.FillPosition(ref value, GetCompany());
		}

		public bool InsertPosition(Position aPosition)
		{
			if(aPosition.APositionRole != POSITION_ROLE_TYPE.BLANK)
			{
//				if(aPosition.APositionRole != POSITION_ROLE_TYPE.NULL)
//				{
					Position objPosition = new Position();
					objPosition.APositionRole = aPosition.APositionRole;
					if(flowPosition.FillPosition(ref objPosition, GetCompany()))
					{
						return false;
					}
//				}
			}	
			return flowPosition.InsertPosition(ref objPositionList, aPosition);
		}

		public bool UpdatePosition(Position aPosition)
		{
			return flowPosition.UpdatePosition(ref objPositionList, aPosition);
		}

		public bool DeletePosition(Position aPosition)
		{				
			return flowPosition.DeletePosition(ref objPositionList, aPosition);
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
						flowPosition.Dispose();
						objPositionList.Dispose();

						flowPosition = null;
						objPositionList = null;
						
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

























//		public bool UpdatePosition(Position aPosition, PositionType aOldPositionType, POSITION_ROLE_TYPE aOldPositionRole)
//		{		
//			ServiceStaffTypeFlow flowServiceStaffType = new ServiceStaffTypeFlow();
//			if(flowPosition.UpdatePosition(ref objPositionList, aPosition))
//			{
//				objPositionList[aPosition.EntityKey] = aPosition;
//				//CASE 1 : Convert from one Position Type to another.
//				if(aPosition.APositionType.Type != aOldPositionType.Type)
//				{
//					// >>> Edit PositionType from "O" to "S" -> To Insert Data in Service Staff Type Table.
//					if(aOldPositionType.Type == "O")
//					{
//						if(flowServiceStaffType.InsertSpareServiceStaffType(aPosition, objPositionList.Company))
//						{	
//							if(aPosition.APositionRole == POSITION_ROLE_TYPE.DRIVER)
//							{
//								flowServiceStaffType.InsertFamilyDriverServiceStaffType(aPosition, objPositionList.Company);
//								return flowServiceStaffType.InsertPositionDriverServiceStaffType(aPosition, objPositionList.Company);
//							}
//							else
//							   return true;
//						}
//						else
//							return false;
//						
//					}
//					// >>> Edit PositionType from "S" to "O" -> To Delete Data in Service Staff Type Table.
//					else
//					{
//						if(flowServiceStaffType.DeleteSpareServiceStaffType(aPosition, objPositionList.Company))
//						{	
//							if(aPosition.APositionRole == POSITION_ROLE_TYPE.DRIVER)
//							{
//								flowServiceStaffType.DeleteFamilyDriverServiceStaffType(aPosition, objPositionList.Company);
//								return flowServiceStaffType.DeletePositionDriverServiceStaffType(aPosition, objPositionList.Company);
//							}
//							else
//								return true;
//						}
//						else
//							return false;
//					}
//				}
//		    	//CASE 2 : No Convert from one Position Type to another.
//				else
//				{
//					if(aOldPositionType.Type == "S")
//					{
//							//SUBCASE 2.1 : Convert from Position_Role_Driver to Other Position Role.
//							if(aOldPositionRole != aPosition.APositionRole)
//							{
//								if(aPosition.APositionRole == POSITION_ROLE_TYPE.DRIVER)
//								{
//									flowServiceStaffType.InsertFamilyDriverServiceStaffType(aPosition, objPositionList.Company);
//									flowServiceStaffType.InsertPositionDriverServiceStaffType(aPosition, objPositionList.Company);
//									return flowServiceStaffType.UpdateSpareServiceStaffType(aPosition, objPositionList.Company);
//								}
//								else
//								{
//									flowServiceStaffType.DeleteFamilyDriverServiceStaffType(aPosition, objPositionList.Company);
//									flowServiceStaffType.DeletePositionDriverServiceStaffType(aPosition, objPositionList.Company);
//									return flowServiceStaffType.UpdateSpareServiceStaffType(aPosition, objPositionList.Company);
//								}
//							}
//							//SUBCASE 2.2 : No Convert from Position_Role_Driver to Other Position Role.
//							else
//							{
//								if(aPosition.APositionRole == POSITION_ROLE_TYPE.DRIVER)
//								{
//									flowServiceStaffType.UpdateFamilyDriverServiceStaffType(aPosition, objPositionList.Company);
//									flowServiceStaffType.UpdatePositionDriverServiceStaffType(aPosition, objPositionList.Company);
//									return flowServiceStaffType.UpdateSpareServiceStaffType(aPosition, objPositionList.Company);
//								}
//								else
//									return flowServiceStaffType.UpdateSpareServiceStaffType(aPosition, objPositionList.Company);
//							}
//					}
//					else
//						return true;
//				}
//			}
//			else
//				return false;
//		}




