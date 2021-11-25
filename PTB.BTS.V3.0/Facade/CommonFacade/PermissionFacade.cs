using System;

using SystemFramework.AppConfig;

using PTB.BTS.Common.Flow;

namespace Facade.CommonFacade
{
	public class PermissionFacade
	{
		#region - Constant -
		#endregion

		#region - Private - 
			private PermissionFlow flowPermission;
		#endregion

		//============================== Property ==============================
		private ApplicationUserPermissionList userPermissionList;
		public ApplicationUserPermissionList UserPermissionList
		{
			get{return userPermissionList;}
			set{userPermissionList = value;}
		}

		//============================== Constructor ==============================
		public PermissionFacade()
		{
			flowPermission = new PermissionFlow();
			userPermissionList = new ApplicationUserPermissionList();
		}

		//============================== Private Method ==============================

		//============================== Public Method ==============================
		public bool DisplayApplicationUserPermissionList()
		{
			userPermissionList.Clear();
			return flowPermission.FillUserPermissionList(ref userPermissionList);
		}

		public bool UpdateModulePermission(ModulePermission value, ApplicationUserProfile userProfile)
		{
			return flowPermission.UpdateModulePermission(value, userProfile);
		}

		public bool UpdateFunctionPermission(ModulePermission value, ApplicationUserProfile userProfile)
		{
			return flowPermission.UpdateFunctionPermission(value, userProfile);
		}

		public bool DeleteUserPermission(ApplicationUserPermission value)
		{
			return flowPermission.DeleteUserPermission(value);
		}
	}
}
