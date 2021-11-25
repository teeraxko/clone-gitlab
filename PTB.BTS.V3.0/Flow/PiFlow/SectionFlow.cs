using System;

using ictus.PIS.PI.Entity;

using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.PI.Flow
{
	public class SectionFlow : FlowBase
	{
		#region - Private -
		private SectionDB dbSection;
		#endregion

//  ================================Constructor=====================
		public SectionFlow():base()
		{
			dbSection = new SectionDB();
		}
//  ================================public Method=====================

		public bool FillSectionList(ref SectionList aSectionList)
		{
			return dbSection.FillSectionList(ref aSectionList);
		}

		public bool FillSectionList(ref SectionList aSectionList, Section aSection)
		{
			return dbSection.FillSectionList(ref aSectionList, aSection);
		}

		public bool InsertSection(ref SectionList aSectionList, Section aSection)
		{
			if (dbSection.InsertSection(aSection, aSectionList.Company))
			{
				aSectionList.Add(aSection);
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool UpdateSection(ref SectionList aSectionList, Section aSection)
		{
			if (dbSection.UpdateSection(aSection, aSectionList.Company))
			{
				aSectionList[aSection.EntityKey] = aSection;
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool DeleteSection(ref SectionList aSectionList, Section aSection)
		{
			if (dbSection.DeleteSection(aSection, aSectionList.Company))
			{
				aSectionList.Remove(aSection);
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
