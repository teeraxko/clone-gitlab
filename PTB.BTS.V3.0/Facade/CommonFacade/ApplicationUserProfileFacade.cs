using System;

using PTB.BTS.Common.Flow;

using Facade.CommonFacade;

using SystemFramework.AppConfig;
using SystemFramework.AppException;

namespace Facade.CommonFacade
{
	public class ApplicationUserProfileFacade
	{
		#region - Private -
		private ApplicationUserProfileFlow flowApplicationUserProfile;
		private CommonFlow flowCommon;
		private ApplicationUserProfile objApplicationUserProfile;
		#endregion

//		============================== Property ==============================
		private ApplicationUserProfileList objApplicationUserProfileList;
		public ApplicationUserProfileList ObjApplicationUserProfileList
		{
			get{return objApplicationUserProfileList;}
		}

		

//		============================== Constructor ==============================
		public ApplicationUserProfileFacade()
		{
			flowApplicationUserProfile = new ApplicationUserProfileFlow();
			flowCommon = new CommonFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayApplicationUserProfile()
		{
			objApplicationUserProfileList = new ApplicationUserProfileList();

			if(UserProfile.UserROLE == USER_ROLE.ADMIN)
			{
				return flowApplicationUserProfile.FillApplicationUserProfileList(ref objApplicationUserProfileList);
			}
			else if(UserProfile.UserROLE == USER_ROLE.POWER_USER)
			{
				objApplicationUserProfile = new ApplicationUserProfile();
				objApplicationUserProfile.UserRole = USER_ROLE.ADMIN;
				return flowApplicationUserProfile.FillExcludeApplicationUserProfileList(ref objApplicationUserProfileList, objApplicationUserProfile);
			}
			return false;
		}

		public bool InsertApplicationUserProfile(ApplicationUserProfile value)
		{
			if (objApplicationUserProfileList.Contain(value.UserName))
			{
				throw new DuplicateException("ApplicationUserProfileFacade");
			}
			else
			{
				if (flowApplicationUserProfile.InsertApplicationUserProfile(value))
				{
					objApplicationUserProfileList.Add(value);
					return true;
				}
				else
				{return false;}
			}			
		}

		public bool UpdateApplicationUserProfile(ApplicationUserProfile value)
		{
			if (flowApplicationUserProfile.UpdateApplicationUserProfile(value))
			{
				objApplicationUserProfileList[value.UserName] = value;
				return true;
			}
			else
			{return false;}
		}

		public bool DeleteApplicationUserProfile(ApplicationUserProfile value)
		{
			if(flowApplicationUserProfile.DeleteApplicationUserProfile(value))
			{
				objApplicationUserProfileList.Remove(value.UserName);
				return true;
			}
			else
			{return false;}
		}

	}
}
