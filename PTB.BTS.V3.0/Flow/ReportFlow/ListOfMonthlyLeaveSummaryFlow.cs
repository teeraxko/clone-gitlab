using System;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;
using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Report.Flow
{
	public class ListOfMonthlyLeaveSummaryFlow : FlowBase
	{
		#region - Private -	
		private TrLateSummaryDB dbLateSummary;
		private TrSickLeaveSummaryDB dbSickLeaveSummary;
		private TrAnnualLeaveSummaryDB dbAnnualLeaveSummary;
		private TrPrivateLeaveSummaryDB dbPrivateLeaveSummary;
		#endregion

//		==================================== Constructor =========================
		public ListOfMonthlyLeaveSummaryFlow() : base()
		{
			dbLateSummary = new TrLateSummaryDB();
			dbSickLeaveSummary = new TrSickLeaveSummaryDB();
			dbAnnualLeaveSummary = new TrAnnualLeaveSummaryDB();
			dbPrivateLeaveSummary = new TrPrivateLeaveSummaryDB();
		}

//		==================================== Public Method =======================
		public bool PrintListOfMonthlyLeaveSummary(DateTime value, Company aCompany)
		{
			bool result = true;
			YearMonth yearMonth = new YearMonth(value);

			LateSummaryList listLateSummaryList = new LateSummaryList(aCompany, yearMonth);
			SickLeaveSummaryList listSickLeaveSummary = new SickLeaveSummaryList(aCompany, yearMonth);
			AnnualLeaveSummaryList listAnnualLeaveSummary = new AnnualLeaveSummaryList(aCompany, yearMonth);
			PrivateLeaveSummaryList listPrivateLeaveSummary = new PrivateLeaveSummaryList(aCompany, yearMonth);

			TableAccess tableAccess = new TableAccess();

			try
			{				
				dbLateSummary.FillViewLateSummaryList(ref listLateSummaryList);
				dbSickLeaveSummary.FillViewLeaveSummaryListBase(listSickLeaveSummary, yearMonth);
				dbAnnualLeaveSummary.FillViewLeaveSummaryListBase(listAnnualLeaveSummary, yearMonth);
				dbPrivateLeaveSummary.FillViewLeaveSummaryListBase(listPrivateLeaveSummary, yearMonth);

				tableAccess.OpenTransaction();
				dbLateSummary.TableAccess = tableAccess;
				dbSickLeaveSummary.TableAccess = tableAccess;
				dbAnnualLeaveSummary.TableAccess = tableAccess;
				dbPrivateLeaveSummary.TableAccess = tableAccess;

				dbLateSummary.DeleteLateSummary(aCompany);
				dbSickLeaveSummary.DeleteLeaveSummaryBase(aCompany);
				dbAnnualLeaveSummary.DeleteLeaveSummaryBase(aCompany);
				dbPrivateLeaveSummary.DeleteLeaveSummaryBase(aCompany);

				if(listLateSummaryList.Count != 0)
				{
					result &= dbLateSummary.InsertLateSummary(listLateSummaryList);
				}

				for(int i=0; i<listSickLeaveSummary.Count; i++)
				{
					result &= dbSickLeaveSummary.InsertLeaveSummaryBase(listSickLeaveSummary[i]);
				}
			
				for(int i=0; i<listAnnualLeaveSummary.Count; i++)
				{
					result &= dbAnnualLeaveSummary.InsertLeaveSummaryBase(listAnnualLeaveSummary[i]);
				}

				for(int i=0; i<listPrivateLeaveSummary.Count; i++)
				{
					result &= dbPrivateLeaveSummary.InsertLeaveSummaryBase(listPrivateLeaveSummary[i]);
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