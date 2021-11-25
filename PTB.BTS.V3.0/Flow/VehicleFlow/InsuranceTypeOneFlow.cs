using System;

using Entity.VehicleEntities;
using ictus.PIS.PI.Entity;

using DataAccess.CommonDB;
using DataAccess.VehicleDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace PTB.BTS.Vehicle.Flow
{
	public class InsuranceTypeOneFlow : FlowBase
	{
		#region - Private -	
		private InsuranceTypeOneDB dbInsuranceTypeOne;
		private InsuranceTypeOneDetailDB dbInsuranceTypeOneDetail;
		#endregion

//		====================================Constructor================
		public InsuranceTypeOneFlow(): base()
		{
			dbInsuranceTypeOne = new InsuranceTypeOneDB();
			dbInsuranceTypeOneDetail = new InsuranceTypeOneDetailDB();
		}
		
//		====================================Public Method================
		public bool FillInsuranceTypeOneDetail(ref VehicleInsuranceTypeOne value, Company aCompany)
		{
			return dbInsuranceTypeOneDetail.FillInsuranceTypeOneDetail(ref value, aCompany);
		}

		public bool FillInsuranceTypeOne(ref InsuranceTypeOne value)
		{
			return dbInsuranceTypeOne.FillInsuranceTypeOne(ref value);
		}

		public bool FillInsuranceTypeOneDetail(ref InsuranceTypeOne value)
		{
			return dbInsuranceTypeOneDetail.FillInsuranceTypeOneDetail(ref value);
		}

		public bool FillInsuranceTypeOneList(ref InsuranceTypeOneList value, InsuranceTypeOne condition)
		{
			return dbInsuranceTypeOne.FillInsuranceTypeOneList(ref value, condition);
		}
		
		public bool FillExpireInsuranceTypeOneList(ref InsuranceTypeOneList value, DateTime expireDate)
		{
			return dbInsuranceTypeOne.FillExpireInsuranceTypeOneList(ref value, expireDate);
		}

        public InsuranceTypeOne GetLatestInsuranceTypeOne(Entity.VehicleEntities.VehicleInfo value, Company aCompany)
		{	
			InsuranceTypeOne insuranceTypeOne = new InsuranceTypeOne(aCompany);
			InsuranceTypeOne tempInsuranceTypeOne;
			VehicleInsuranceList vehicleInsuranceList = new VehicleInsuranceList(aCompany);
			VehicleInsuranceTypeOne vehicleInsuranceTypeOne = new VehicleInsuranceTypeOne();
			vehicleInsuranceTypeOne.AVehicleInfo = value;

			if(dbInsuranceTypeOneDetail.FillInsuranceTypeOneDetailList(ref vehicleInsuranceList, vehicleInsuranceTypeOne))
			{
				for(int i=0; i<vehicleInsuranceList.Count; i++)
				{
					tempInsuranceTypeOne = dbInsuranceTypeOne.GetInsuranceTypeOne(vehicleInsuranceList[i].PolicyNo, aCompany);

					if(i==0)
					{
						insuranceTypeOne = tempInsuranceTypeOne;
					}
					else
					{
						if(insuranceTypeOne.APeriod.To < tempInsuranceTypeOne.APeriod.To)
						{
							insuranceTypeOne = tempInsuranceTypeOne;
						}					
					}
				}	
				vehicleInsuranceList = null;
				tempInsuranceTypeOne = null;
				return insuranceTypeOne;
			}
			else
			{
				insuranceTypeOne = null;
				return null;
			}
		}

		public bool InsertInsuranceTypeOne(InsuranceTypeOne value)
		{
			bool result = false;
			TableAccess tableAccess = new TableAccess();
			dbInsuranceTypeOne.TableAccess = tableAccess;
			dbInsuranceTypeOneDetail.TableAccess = tableAccess;

			try
			{
				tableAccess.OpenTransaction();

				if(dbInsuranceTypeOne.InsertInsuranceTypeOne(value, value.AVehicleInsuranceList.Company))
				{
					result = dbInsuranceTypeOneDetail.InsertInsuranceTypeOneDetail(value);
				}

				if(result)
				{
					tableAccess.Transaction.Commit();
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}
			}
			catch
			{
				tableAccess.Transaction.Rollback();
			}
			finally
			{
				tableAccess.CloseConnection();
				tableAccess = null;
			}

			return result;
		}

        public bool InsertInsuranceTypeOneDetail(VehicleInsuranceTypeOne value, Company aCompany)
		{
			return dbInsuranceTypeOneDetail.InsertInsuranceTypeOneDetail(value, aCompany);
		}

        public bool UpdateInsuranceTypeOne(InsuranceTypeOne value, Company aCompany)
		{
            return dbInsuranceTypeOne.UpdateInsuranceTypeOne(value, aCompany);
		}

        public bool UpdateInsuranceTypeOneDetail(VehicleInsuranceTypeOne value, Company aCompany)
		{
			return dbInsuranceTypeOneDetail.UpdateInsuranceTypeOneDetail(value, aCompany);
		}

        public bool DeleteInsuranceTypeOne(InsuranceTypeOne value, Company aCompany)
		{
			bool result = false;
			TableAccess tableAccess = new TableAccess();
			dbInsuranceTypeOne.TableAccess = tableAccess;
			dbInsuranceTypeOneDetail.TableAccess = tableAccess;

			try
			{
				tableAccess.OpenTransaction();
				dbInsuranceTypeOneDetail.DeleteInsuranceTypeOneDetail(value);
                result = dbInsuranceTypeOne.DeleteInsuranceTypeOne(value, aCompany);
				if(result)
				{
					tableAccess.Transaction.Commit();
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}
			}
			catch
			{
				tableAccess.Transaction.Rollback();
			}
			finally
			{
				tableAccess.CloseConnection();
				tableAccess = null;
			}

			return result;
		}

        public bool DeleteInsuranceTypeOneDetail(VehicleInsuranceTypeOne value, Company aCompany)
		{
			return dbInsuranceTypeOneDetail.DeleteInsuranceTypeOneDetail(value, aCompany);
		}

	}
}