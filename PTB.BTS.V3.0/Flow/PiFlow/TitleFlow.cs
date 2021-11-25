using System;

using ictus.PIS.PI.Entity;

using DataAccess.PiDB;

using PTB.BTS.Common.Flow;
namespace PTB.BTS.PI.Flow
{
	public class TitleFlow : FlowBase
	{
		#region - Private -
			private TitleDB dbTitle;
		#endregion

//		================================Constructor=====================
		public TitleFlow():base()
		{
			dbTitle = new TitleDB();
		}
//		================================public Method=====================
		public bool FillTitle(ref TitleList aTitleList)
		{
			return dbTitle.FillTitleData(ref aTitleList);
		}

		public bool InsertTitle(ref TitleList aTitleList, Title aTitle)
		{
			if (dbTitle.InsertTitle(aTitle, aTitleList.Company))
			{
				aTitleList.Add(aTitle);
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool UpdateTitle(ref TitleList aTitleList, Title aTitle)
		{
			if (dbTitle.UpdateTitle(aTitle, aTitleList.Company))
			{
				aTitleList[aTitle.EntityKey] = aTitle;
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool DeleteTitle(ref TitleList aTitleList, Title aTitle)
		{
			if (dbTitle.DeleteTitle(aTitle, aTitleList.Company))
			{
				aTitleList.Remove(aTitle);
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
