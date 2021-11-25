using System;
using System.Data;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;

namespace Facade.PiFacade
{
	public class TitleFacade : CommonPIFacadeBase
	{
		#region - Private -
		private TitleFlow flowTitle;
		#endregion

//		============================== Property ==============================
		private TitleList objTitleList;
		public TitleList ObjTitleList
		{
			get
			{
				return objTitleList;
			}
		}

		//		============================== Constructor ==============================
		public TitleFacade()
		{
			flowTitle = new TitleFlow();	
		}
		//		============================== Public Method ==============================

		public bool DisplayTitle()
		{
			objTitleList = new TitleList(GetCompany());
			Title aTitle = new Title();
			aTitle.Code = "ZZ";
			if(flowTitle.FillTitle(ref objTitleList))
			{
				objTitleList.Remove(aTitle);
				return true;
			}
			else
				return false;
		}

		public bool InsertTitle(Title aTitle)
		{
			if (objTitleList.Contain(aTitle))
			{
				throw new DuplicateException("TitleFacade");
			}
			else
			{
				return flowTitle.InsertTitle(ref objTitleList, aTitle);
			}
		}

		public bool UpdateTitle(Title aTitle)
		{
			return flowTitle.UpdateTitle(ref objTitleList, aTitle);
		}

		public bool DeleteTitle(Title aTitle)
		{
			return flowTitle.DeleteTitle(ref objTitleList, aTitle);
		}

		
	}
}
