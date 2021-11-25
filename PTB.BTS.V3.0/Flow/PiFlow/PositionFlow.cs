using System;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.ContractEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace PTB.BTS.PI.Flow
{
	
	public class PositionFlow : FlowBase
	{
		#region - Private -
		private PositionDB dbPosition;
		private ServiceStaffTypeDB dbServiceStaffType;
		#endregion

		//  ================================Constructor=========================
		public PositionFlow() : base()
		{
			dbPosition = new PositionDB();
			dbServiceStaffType = new ServiceStaffTypeDB();
		}
		
		//  ================================ private Method =====================
		private bool insertServicStafftype(Position value, Company aCompany, TableAccess tableAccess)
		{
			bool result = true;
			ServiceStaffTypeDB dbServiceStaffType = new ServiceStaffTypeDB();
			dbServiceStaffType.TableAccess = tableAccess;

			switch(value.APositionRole)
			{
				case POSITION_ROLE_TYPE.DRIVER :
				{
					ServiceStaffType serviceStaffType = new ServiceStaffType();
					serviceStaffType.APosition = value;

					serviceStaffType.Type = value.PositionCode + "1";
					serviceStaffType.ADescription.Thai = "¾¹Ñ¡§Ò¹¢ÑºÃ¶";
					serviceStaffType.ADescription.English = "Driver";
					result &= dbServiceStaffType.InsertServiceStaffType(serviceStaffType, aCompany);

					serviceStaffType.Type = value.PositionCode + "2";
					serviceStaffType.ADescription.Thai = "¾¹Ñ¡§Ò¹¢ÑºÃ¶ Family Car";
					serviceStaffType.ADescription.English = "Family Car Driver";
					result &= dbServiceStaffType.InsertServiceStaffType(serviceStaffType, aCompany);

					serviceStaffType.Type = value.PositionCode + "Z";
					serviceStaffType.ADescription.Thai = "¾¹Ñ¡§Ò¹¢ÑºÃ¶ Spare";
					serviceStaffType.ADescription.English = "Spare Driver";
					result &= dbServiceStaffType.InsertServiceStaffType(serviceStaffType, aCompany);
					break;
				}
				default :
				{
					ServiceStaffType serviceStaffType = new ServiceStaffType();
					serviceStaffType.APosition = value;
					serviceStaffType.Type = value.PositionCode + "Z";
					serviceStaffType.ADescription.Thai = value.AName.Thai + " Spare";
					serviceStaffType.ADescription.English = value.AName.English + " Spare";
					result &= dbServiceStaffType.InsertServiceStaffType(serviceStaffType, aCompany);

					break;
				}
			}
			dbServiceStaffType = null;
			return result;
		}

		private bool insertDriverServicStafftype(Position value, Company aCompany, TableAccess tableAccess)
		{
			bool result = true;
			ServiceStaffTypeDB dbServiceStaffType = new ServiceStaffTypeDB();
			dbServiceStaffType.TableAccess = tableAccess;

			ServiceStaffType serviceStaffType = new ServiceStaffType();
			serviceStaffType.APosition = value;

			serviceStaffType.Type = value.PositionCode + "1";
			serviceStaffType.ADescription.Thai = "¾¹Ñ¡§Ò¹¢ÑºÃ¶";
			serviceStaffType.ADescription.English = "Driver";
			result &= dbServiceStaffType.InsertServiceStaffType(serviceStaffType, aCompany);

			serviceStaffType.Type = value.PositionCode + "2";
			serviceStaffType.ADescription.Thai = "¾¹Ñ¡§Ò¹¢ÑºÃ¶ Family Car";
			serviceStaffType.ADescription.English = "Family Car Driver";
			result &= dbServiceStaffType.InsertServiceStaffType(serviceStaffType, aCompany);
			
			dbServiceStaffType = null;
			return result;
		}
		
		private bool insertPosition(Position value, Company aCompany, TableAccess tableAccess)
		{
			PositionDB dbPosition = new PositionDB();
			dbPosition.TableAccess = tableAccess;

			bool result = dbPosition.InsertPosition(value, aCompany);

			if(value.APositionType.Type == "S")
			{
				insertServicStafftype(value, aCompany, tableAccess);
			}

			dbServiceStaffType = null;
			dbPosition = null;

			return result;
		}

		private bool updatePosition(Position newPosition, Position oldPosition, Company aCompany, TableAccess tableAccess)
		{
			bool result = true;
			string change = oldPosition.APositionType.Type + newPosition.APositionType.Type;

			ServiceStaffType serviceStaffType;
			ServiceStaffTypeDB dbServiceStaffType = new ServiceStaffTypeDB();
			dbServiceStaffType.TableAccess = tableAccess;
			PositionDB dbPosition = new PositionDB();
			dbPosition.TableAccess = tableAccess;

			switch(change)
			{
				case "OO" :
				{
					result &= dbPosition.UpdatePosition(newPosition, aCompany);
					break;
				}
				case "OS" :
				{
					result &= dbPosition.UpdatePosition(newPosition, aCompany);
					result &= insertServicStafftype(newPosition, aCompany, tableAccess);
					break;
				}
				case "SO" :
				{
					result &= dbServiceStaffType.DeleteServiceStaffType(oldPosition, aCompany);
					result &= dbPosition.UpdatePosition(newPosition, aCompany);
					break;
				}
				case "SS" :
				{
					result &= dbPosition.UpdatePosition(newPosition, aCompany);
					if(oldPosition.APositionRole != newPosition.APositionRole)
					{
						if(newPosition.APositionRole == POSITION_ROLE_TYPE.DRIVER)
						{
							result &= insertDriverServicStafftype(newPosition, aCompany, tableAccess);
						}
						else if (oldPosition.APositionRole == POSITION_ROLE_TYPE.DRIVER)
						{							
							dbServiceStaffType.DeleteExcludeServiceStaffType(oldPosition, aCompany);
						}
//						result &= dbServiceStaffType.DeleteServiceStaffType(oldPosition, aCompany);
//						result &= insertServicStafftype(newPosition, aCompany, tableAccess);

					}
					serviceStaffType = new ServiceStaffType();
					serviceStaffType.APosition = newPosition;
					serviceStaffType.Type = newPosition.PositionCode + "Z";
					serviceStaffType.ADescription.Thai = newPosition.AName.Thai + " Spare";
					serviceStaffType.ADescription.English = newPosition.AName.English + " Spare";

					result &= dbServiceStaffType.UpdateServiceStaffType(serviceStaffType, aCompany);
					serviceStaffType = null;
					break;
				}
			}

			dbServiceStaffType = null;
			dbPosition = null;

			return result;
		}

		private bool deletePosition(Position value, Company aCompany, TableAccess tableAccess)
		{
			bool result = true;;

			PositionDB dbPosition = new PositionDB();
			ServiceStaffTypeDB dbServiceStaffType = new ServiceStaffTypeDB();

			dbPosition.TableAccess = tableAccess;
			dbServiceStaffType.TableAccess = tableAccess;
			
			if(value.APositionType.Type == "S")
			{
				result &= dbServiceStaffType.DeleteServiceStaffType(value, aCompany);
			}
			result &= dbPosition.DeletePosition(value, aCompany);

			
			dbPosition = null;
			dbServiceStaffType = null;
			
			return result;
		}

//		================================ Public Method =====================
		public Position GetPositionByRole(POSITION_ROLE_TYPE value, Company aCompany)
		{
			Position position = new Position();
			position.APositionType = new PositionType();
			position.APositionType.Type = "S";
			position.APositionRole = value;

			dbPosition.FillPosition(ref position, aCompany);

			return position;
		}

		public bool FillPosition(ref PositionList aPositionList)
		{
			return dbPosition.FillPositionList(ref aPositionList);
		}

		public bool FillPosition(ref Position value, Company aCompany)
		{
			return dbPosition.FillPosition(ref value, aCompany);
		}

		public bool FillOtherServiceStaffPosition(ref PositionList aPositionList)
		{
			Position conditionPosition = new Position();
			conditionPosition.APositionType = new PositionType();
			conditionPosition.APositionType.Type = "S";
			if(dbPosition.FillPositionList(ref aPositionList, conditionPosition))
			{
				conditionPosition.APositionRole = POSITION_ROLE_TYPE.DRIVER;
				aPositionList.Remove(conditionPosition);
				return true;
			}
			else
			{
				return false;
			}			
		}

		public bool InsertPosition(ref PositionList aPositionList, Position aPosition)
		{
			bool result = false;
			TableAccess tableAccess = new TableAccess();
			
			try
			{
				tableAccess.OpenTransaction();

				if(insertPosition(aPosition, aPositionList.Company, tableAccess))
				{
					tableAccess.Transaction.Commit();
					aPositionList.Add(aPosition);
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

		public bool DeletePosition(ref PositionList aPositionList, Position aPosition)
		{
			bool result = false;
			TableAccess tableAccess = new TableAccess();
			
			try
			{
				tableAccess.OpenTransaction();

				if(deletePosition(aPosition, aPositionList.Company, tableAccess))
				{
					tableAccess.Transaction.Commit();
					aPositionList.Remove(aPosition);
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

		public bool UpdatePosition(ref PositionList aPositionList, Position aPosition)
		{
			PositionDB dbPosition = new PositionDB();
			Position oldPosition = dbPosition.GetPosition(aPosition.PositionCode, aPositionList.Company);

			bool tempResult = false;
			bool result = false;
			TableAccess tableAccess = new TableAccess();
			
			try
			{
				if(aPosition.APositionRole == POSITION_ROLE_TYPE.BLANK)
				{
					tempResult = true;		
				}
				else
				{
					Position objPosition = new Position();
					objPosition.APositionRole = aPosition.APositionRole;

					if(dbPosition.FillPosition(ref objPosition, aPositionList.Company))
					{
						if(aPosition.APositionRole == oldPosition.APositionRole)
						{
							tempResult = true;	
						}						
					}
					else
					{
						tempResult = true;
					}
				}


				if(tempResult)
				{
					tableAccess.OpenTransaction();

					if(updatePosition(aPosition, oldPosition, aPositionList.Company, tableAccess))
					{
						tableAccess.Transaction.Commit();
						aPositionList[aPosition.EntityKey] = aPosition;
						result = true;
					}
					else
					{
						tableAccess.Transaction.Rollback();
					}
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
			}

			return result;
		}

		#region - Old data -
//		public bool InsertPosition(ref PositionList aPositionList, Position aPosition)
//		{
//			// Check Position Role Type "D" and "M" already exist or not before insert to database.
//			Position aDPositionRole = new Position();
//			Position aMPositionRole = new Position();
//			aDPositionRole.APositionRole = POSITION_ROLE_TYPE.DRIVER;
//			aMPositionRole.APositionRole = POSITION_ROLE_TYPE.MACHANIC;
//			
//			if(aPosition.APositionRole == POSITION_ROLE_TYPE.DRIVER)
//			{
//				if(dbPosition.FillPosition(ref aDPositionRole, aPositionList.Company))
//				{
//					return false;
//				}
//				else
//				{
//					if (dbPosition.InsertPosition(aPosition, aPositionList.Company))
//					{
//						aPositionList.Add(aPosition);
//						return true;
//					}
//					else
//						return false;
//				}
//			}
//			
//			if(aPosition.APositionRole == POSITION_ROLE_TYPE.MACHANIC)
//			{
//				if(dbPosition.FillPosition(ref aMPositionRole, aPositionList.Company))
//				{
//					return false;
//				}
//				else
//				{
//					if (dbPosition.InsertPosition(aPosition, aPositionList.Company))
//					{
//						aPositionList.Add(aPosition);
//						return true;
//					}
//					else
//						return false;
//				}
//			}
//			else
//			{
//				if (dbPosition.InsertPosition(aPosition, aPositionList.Company))
//				{
//					aPositionList.Add(aPosition);
//					return true;
//				}
//				else
//					return false;
//			}
//		}

//		public bool UpdatePosition(ref PositionList aPositionList, Position aPosition)
//		{
//			// Check Position Role Type "D" and "M" already exist or not before insert to database.
//			Position aDPositionRole = new Position();
//			Position aMPositionRole = new Position();
//			aDPositionRole.APositionRole = POSITION_ROLE_TYPE.DRIVER;
//			aMPositionRole.APositionRole = POSITION_ROLE_TYPE.MACHANIC;
//			
//			// Driver "D"
//			if(aPosition.APositionRole == POSITION_ROLE_TYPE.DRIVER)
//			{
//				if(dbPosition.FillPosition(ref aDPositionRole, aPositionList.Company))
//				{
//					if(aDPositionRole.EntityKey == aPosition.EntityKey)
//					{
//						if (dbPosition.UpdatePosition(aPosition, aPositionList.Company))
//						{
//							aPositionList[aPosition.EntityKey] = aPosition;
//							return true;
//						}
//						else
//							return false;
//					}
//					else
//						return false;
//				}
//				else
//				{
//					if(dbPosition.UpdatePosition(aPosition, aPositionList.Company))
//					{
//						aPositionList[aPosition.EntityKey] = aPosition;
//						return true;
//					}
//					else
//					{
//						return false;
//					}
//				}
//			}
//			// Mechanic "M"
//			if(aPosition.APositionRole == POSITION_ROLE_TYPE.MACHANIC)
//			{
//				if(dbPosition.FillPosition(ref aMPositionRole, aPositionList.Company))
//				{
//					if(aMPositionRole.EntityKey == aPosition.EntityKey)
//					{
//						if (dbPosition.UpdatePosition(aPosition, aPositionList.Company))
//						{
//							aPositionList[aPosition.EntityKey] = aPosition;
//							return true;
//						}
//						else
//							return false;
//					}
//					else
//						return false;
//				}
//				else
//				{
//					if (dbPosition.UpdatePosition(aPosition, aPositionList.Company))
//					{
//						aPositionList[aPosition.EntityKey] = aPosition;
//						return true;
//					}
//					else
//					{
//						return false;
//					}
//				}
//			}
//				// OTHERS
//			else
//			{
//				if (dbPosition.UpdatePosition(aPosition, aPositionList.Company))
//				{
//					aPositionList[aPosition.EntityKey] = aPosition;
//					return true;
//				}
//				else
//				{
//					return false;
//				}
//			}
//		}



//		//CASE 1 : Convert from one Position Type to another.
//		// >>>	Edit PositionType from "O" to "S"
//		public bool UpdatePositionCaseOthertoServiceStaff(Position aPosition)
//		{
//			if(flowServiceStaffType.InsertSpareServiceStaffType(aPosition, objPositionList.Company))
//			{	
//				if(aPosition.APositionRole == POSITION_ROLE_TYPE.DRIVER)
//				{
//					flowServiceStaffType.InsertFamilyDriverServiceStaffType(aPosition, objPositionList.Company);
//					flowServiceStaffType.InsertPositionDriverServiceStaffType(aPosition, objPositionList.Company);
//					return UpdatePosition(ref objPositionList, aPosition);
//				}
//				else
//					return UpdatePosition(ref objPositionList, aPosition);
//			}
//			else
//				return false;
//		}
//		// >>> Edit PositionType from "S" to "O"
//		public bool UpdatePositionCaseServicetoOtherStaff(Position aPosition)
//		{
//			if(flowServiceStaffType.DeleteSpareServiceStaffType(aPosition, objPositionList.Company))
//			{	
//				if(aPosition.APositionRole == POSITION_ROLE_TYPE.DRIVER)
//				{
//					flowServiceStaffType.DeleteFamilyDriverServiceStaffType(aPosition, objPositionList.Company);
//					flowServiceStaffType.DeletePositionDriverServiceStaffType(aPosition, objPositionList.Company);
//					return UpdatePosition(ref objPositionList, aPosition);
//				}
//				else
//					return UpdatePosition(ref objPositionList, aPosition);
//			}
//			else
//				return false;
//		}
//
//		//CASE 2 : No Convert from one Position Type to another. <<Only Service Staff>>
//		//SUBCASE 2.1 : Convert from Position_Role_Driver to Other Position Role.
//		public bool UpdatePositionCaseDrivertoOtherPositionRole(Position aPosition)
//		{
//			if(aPosition.APositionRole == POSITION_ROLE_TYPE.DRIVER)
//			{
//				flowServiceStaffType.InsertFamilyDriverServiceStaffType(aPosition, objPositionList.Company);
//				flowServiceStaffType.InsertPositionDriverServiceStaffType(aPosition, objPositionList.Company);
//				flowServiceStaffType.UpdateSpareServiceStaffType(aPosition, objPositionList.Company);
//				return UpdatePosition(ref objPositionList, aPosition);
//			}
//			else
//			{
//				flowServiceStaffType.DeleteFamilyDriverServiceStaffType(aPosition, objPositionList.Company);
//				flowServiceStaffType.DeletePositionDriverServiceStaffType(aPosition, objPositionList.Company);
//				flowServiceStaffType.UpdateSpareServiceStaffType(aPosition, objPositionList.Company);
//				return UpdatePosition(ref objPositionList, aPosition);
//			}
//		}
//		//SUBCASE 2.2 : No Convert from Position_Role_Driver to Other Position Role.
//		public bool UpdatePositionCaseNoConvertPositionRole(Position aPosition)
//		{
//			if(aPosition.APositionRole == POSITION_ROLE_TYPE.DRIVER)
//			{
//				flowServiceStaffType.UpdateFamilyDriverServiceStaffType(aPosition, objPositionList.Company);
//				flowServiceStaffType.UpdatePositionDriverServiceStaffType(aPosition, objPositionList.Company);
//				flowServiceStaffType.UpdateSpareServiceStaffType(aPosition, objPositionList.Company);
//				return UpdatePosition(ref objPositionList, aPosition);
//			}
//			else
//			{
//				flowServiceStaffType.UpdateSpareServiceStaffType(aPosition, objPositionList.Company);
//				return UpdatePosition(ref objPositionList, aPosition);
//			}
//		}
		#endregion
	}
}


