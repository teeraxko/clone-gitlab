using System;

using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

using SystemFramework.AppConfig;

namespace PTB.BTS.Common.Flow
{
	public class ApplicationUserProfileFlow : FlowBase
	{
		#region - Private -
		private ApplicationUserProfileDB dbApplicationUserProfile;
		#endregion

//		============================== Constructor ==============================
		public ApplicationUserProfileFlow() : base()
		{
			dbApplicationUserProfile = new ApplicationUserProfileDB();
		}

//		============================== Public Method ==============================
		public bool FillApplicationUserProfileList(ref ApplicationUserProfileList value)
		{
			return dbApplicationUserProfile.FillApplicationUserProfileList(ref value);
		}

		public bool FillExcludeApplicationUserProfileList(ref ApplicationUserProfileList value, ApplicationUserProfile aApplicationUserProfile)
		{
			return dbApplicationUserProfile.FillExcludeApplicationUserProfileList(ref value, aApplicationUserProfile);
		}

		public bool FillApplicationUserProfile(ref ApplicationUserProfile value)
		{
			return dbApplicationUserProfile.FillApplicationUserProfile(ref value);
		}

		public bool InsertApplicationUserProfile(ApplicationUserProfile value)
		{
			value.Password = CommonFlow.Encrypt(value.Password);
			return dbApplicationUserProfile.InsertApplicationUserProfile(value);
		}

		public bool UpdateApplicationUserProfile(ApplicationUserProfile value)
		{
			value.Password = CommonFlow.Encrypt(value.Password);
			return dbApplicationUserProfile.UpdateApplicationUserProfile(value);
		}

		public bool DeleteApplicationUserProfile(ApplicationUserProfile value)
		{
			return dbApplicationUserProfile.DeleteApplicationUserProfile(value);
		}
	}
}
