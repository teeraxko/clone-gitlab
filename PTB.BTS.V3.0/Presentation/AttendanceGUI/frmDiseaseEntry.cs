using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmDiseaseEntry : SingleFieldGUIEntryBase
	{
		public frmDiseaseEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "ชื่อโรค";
			lable = "ชื่อโรค";
			Maxlength = 30;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miDisease");
		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Disease();
		}
	}
}
