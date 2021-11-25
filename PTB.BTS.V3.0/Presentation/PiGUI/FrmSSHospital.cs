using System;
using System.Collections.Generic;
using System.Text;
using Presentation.CommonGUI;
using Facade.PiFacade;

namespace Presentation.PiGUI
{
    public class FrmSSHospital : DualFieldGUIMainBase
    {
        public FrmSSHospital()
		{
            frmEntry = new FrmSSHospitalEntry(this);
            facadeMTB = new SSHospitalFacade();
			title = "ข้อมูลโรงพยาบาลประกันสังคม";
            columnCode = "รหัสโรงพยาบาลประกันสังคม";
            columnTHName = "ชื่อโรงพยาบาลประกันสังคม (ภาษาไทย)";
            columnENName = "ชื่อโรงพยาบาลประกันสังคม (ภาษาอังกฤษ)";
		}
    }
}
