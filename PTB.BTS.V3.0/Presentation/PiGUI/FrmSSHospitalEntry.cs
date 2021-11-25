using System;
using System.Collections.Generic;
using System.Text;
using Presentation.CommonGUI;
using ictus.PIS.PI.Entity;

namespace Presentation.PiGUI
{
    public class FrmSSHospitalEntry : DualFieldGUIEntryBase
    {
        public FrmSSHospitalEntry(DualFieldGUIMainBase parentForm)
            : base(parentForm)
		{
			maxLength = 6;
            title = "โรงพยาบาลประกันสังคม";
            lable1 = "รหัสรพ.ประกันสังคม";
            lable2 = "ชื่อรพ.ประกันสังคม(ภาษาไทย)";
            lable3 = "ชื่อรพ.ประกันสังคม(ภาษาอังกฤษ)";
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new SSHospital();
		}
    }
}
